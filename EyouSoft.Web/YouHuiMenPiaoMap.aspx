<%@ Page Title="公司经纬度" Language="C#" AutoEventWireup="true" CodeBehind="YouHuiMenPiaoMap.aspx.cs"
    Inherits="EyouSoft.Web.YouHuiMenPiaoMap" %>

<%@ Import Namespace="EyouSoft.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=<%=EyouSoft.Common.Utils.GetBaiduMapKeyByXml() %>"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/library/SearchControl/1.4/src/SearchControl_min.js"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/library/EventWrapper/1.2/src/EventWrapper.min.js"></script>

    <link rel="stylesheet" href="http://api.map.baidu.com/library/SearchControl/1.4/src/SearchControl_min.css" />
    <style type="text/css">
       body{padding:0;margin:0;}
       form{padding:0;margin:0;}
       #searchBox{padding:0;margin:0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="searchBox">
    </div>
    <div id="Set_Map" style="width: 635px; height: 310px;">
        <a href="YouHuiMenPiaoXiangQing.aspx">YouHuiMenPiaoXiangQing.aspx</a></div>
    </form>
</body>

<script type="text/javascript">
    var info = {
        cityName: '<%=EyouSoft.Common.Utils.GetQueryStringValue("cityName") %>',
        scenicName: '<%=EyouSoft.Common.Utils.GetQueryStringValue("scenicName") %>',
        contact: '<%=EyouSoft.Common.Utils.GetQueryStringValue("contact") %>',
        mobile: '<%=EyouSoft.Common.Utils.GetQueryStringValue("mobile") %>',
        address: '<%=EyouSoft.Common.Utils.GetQueryStringValue("address") %>',
        x: ('<%=EyouSoft.Common.Utils.GetQueryStringValue("x") %>' == '' ? '' : '<%=EyouSoft.Common.Utils.GetQueryStringValue("x") %>'),
        y: ('<%=EyouSoft.Common.Utils.GetQueryStringValue("y") %>' == '' ? '' : '<%=EyouSoft.Common.Utils.GetQueryStringValue("y") %>'),
        height: '<%=EyouSoft.Common.Utils.GetQueryStringValue("h") %>',
        width: '<%=EyouSoft.Common.Utils.GetQueryStringValue("w") %>'
        
    };
    
    if (parent != null) {
        var ifs = parent.document.getElementsByTagName('iframe');
        for (var i = 0; i < ifs.length; i++) {
            if (ifs[i].contentWindow == self) {
                document.getElementById('Set_Map').style.height = $(ifs[i], ifs[i].contentWindow.document).height() - 5;
                document.getElementById('Set_Map').style.width = $(ifs[i], ifs[i].contentWindow.document).width() - 5;
            }
        }
    }

    if (info.x && info.y) {
        var map = new BMap.Map("Set_Map"); // 创建地图实例
        var point = new BMap.Point(info.x, info.y);  // 创建点坐标
        var cityName = info.cityName; //要设置的城市名称
        if (cityName == "") {
            map.centerAndZoom(point, '15');
        }
        else {
            map.centerAndZoom(cityName, '15');
        }
        //map.enableScrollWheelZoom()
        map.addControl(new BMap.NavigationControl());
        map.addControl(new BMap.ScaleControl());
        map.addControl(new BMap.OverviewMapControl());
        map.addControl(new BMap.MapTypeControl());

        var str = "<div style='width:270px;'><div>" + info.scenicName + '<div><div style="font-size:14px;"><hr style="border:solid 1px #cccccc;margin:0px;" />';

        if (info.contact) {
            str += '联系人：' + info.contact;
        }
        if (info.mobile) {
            str += '手机：' + info.mobile;
        }
        if (info.address) {
            str += '<br/>地址：' + info.address;
        }
        str += '</div></div>';
        var infoWin = new BMap.InfoWindow(str);

        var mkr = new BMap.Marker(point);
        map.addOverlay(mkr);
        mkr.openInfoWindow(infoWin)


        document.getElementById('Set_Map').style.height = info.height+'px';
        document.getElementById('Set_Map').style.width = info.width + 'px';
        
        BMapLib.EventWrapper.addListener(map, 'click', function(e) {
            var point2 = new BMap.Point(e.point.lng, e.point.lat);
            map.panTo(point2);
        });
        
    }
    else {
        $('#Set_Map').html('无法定位该地址');
    }
</script>

</html>
