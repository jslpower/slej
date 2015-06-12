<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAddress.aspx.cs" Inherits="EyouSoft.Web.GetAddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body, html
        {
            width: 100%;
            height: 100%;
            margin: 0;
            font-family: "微软雅黑";
            font-size: 14px;
        }
        #allmap
        {
            width: 100%;
            height: 500px;
        }
    </style>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ovOm8pf0QIyWC4n4jx8I5vPG"></script>

</head>
<body>
    <div id="allmap">
    </div>
</body>

<script type="text/javascript">
    // 百度地图API功能
    var map = new BMap.Map("allmap");
    var point = new BMap.Point(120.169874, 30.276608);
    map.centerAndZoom(point, 12);
    var geoc = new BMap.Geocoder();
    map.enableKeyboard();
    map.enableScrollWheelZoom();
    map.addEventListener("click", function(e) {
        var pt = e.point;
        geoc.getLocation(pt, function(rs) {
            var addComp = rs.addressComponents;
            // window.parent.document.getElementById("txtfirstPlace").value = addComp.province + addComp.city + addComp.district + addComp.street + addComp.streetNumber;
            var callBackBox = '<%=Request.QueryString["callback"] %>';
            var aid = '<%=Request.QueryString["aid"] %>';
            window.parent[callBackBox](addComp.province + addComp.city + addComp.district + addComp.street, aid);
            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
        });
    });
</script>

</html>
