<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetGoogleMap.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.SetGoogleMap" %>

<%@ Import Namespace="EyouSoft.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置公司经纬度</title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=<%= BaiduMapKey %>"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/library/SearchControl/1.4/src/SearchControl_min.js"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/library/EventWrapper/1.2/src/EventWrapper.min.js"></script>

    <link rel="stylesheet" href="http://api.map.baidu.com/library/SearchControl/1.4/src/SearchControl_min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="searchBox">
    </div>
    <div id="Set_Map" style="margin-left: 5px; width: 99%; height: 450px">
    </div>
    </form>

    <script type="text/javascript">
        var map = new BMap.Map("Set_Map");          // 创建地图实例
        var point = new BMap.Point('<%= Longitude %>', '<%= Latitude %>');  // 创建点坐标
        var cityName = '<%= EyouSoft.Common.Utils.GetQueryStringValue("cName") %>'; //要设置的城市名称
        if (cityName == "") {
            map.centerAndZoom(point, '<%= ZoomLevel %>');
        }
        else {
            map.centerAndZoom(cityName, '<%= ZoomLevel %>');
        }
        //map.enableScrollWheelZoom();
        //map.enableKeyboard();
//        map.enableScrollWheelZoom();
        map.addControl(new BMap.NavigationControl());
        map.addControl(new BMap.ScaleControl());
        map.addControl(new BMap.OverviewMapControl());
        map.addControl(new BMap.MapTypeControl());

        var infoWin = new BMap.InfoWindow('此处为您当前所在地！<hr style="border:solid 1px #cccccc" /><a id="a_SetMapSite" href="javascript:void(0)" onclick="SetMapSite();">点击保存并结束设置</a>');

        var mkr = new BMap.Marker(point);
        if (cityName == "") {
            map.addOverlay(mkr);
            mkr.openInfoWindow(infoWin)
        }

        BMapLib.EventWrapper.addListener(map, 'click', function(e) {
            var point2 = new BMap.Point(e.point.lng, e.point.lat);
            map.panTo(point2);

            //map.removeOverlay(mkr);
            map.clearOverlays();
            mkr = new BMap.Marker(point2);
            map.addOverlay(mkr);
            mkr.openInfoWindow(infoWin);
        });

        function SetMapSite() {
            var p = mkr.getPosition();
            window.parent.document.getElementById("X").innerHTML = formatFloat(p.lng, 6);
            window.parent.document.getElementById("jingdu").value = formatFloat(p.lng, 6);
            window.parent.document.getElementById("Y").innerHTML = formatFloat(p.lat, 6);
            window.parent.document.getElementById("weidu").value = formatFloat(p.lat, 6);
            alert("设置成功！");
            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
        }

        //保留小数（src数据源  pos 保留位数）
        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }
    </script>

</body>
</html>
