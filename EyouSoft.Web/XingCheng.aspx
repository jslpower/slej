<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XingCheng.aspx.cs" Inherits="EyouSoft.Web.XingCheng" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ovOm8pf0QIyWC4n4jx8I5vPG"></script>
    <style type="text/css">
       body{padding:0;margin:0;}
       form{padding:0;margin:0;}
    </style>
</head>
<body>
    <div id="allmap" style=" width:418px; height:287px;"></div>
</body>
<script type="text/javascript">
    // 百度地图API功能
    var map = new BMap.Map("allmap");
    var dianlist = '<%=Request.QueryString["dibiao"] %>'
    var didian = new Array();
    didian = dianlist.split(',');
    map.enableKeyboard();
    map.enableScrollWheelZoom();
    map.centerAndZoom(new BMap.Point(120.169874, 30.276608), 11);
    //三种驾车策略：最少时间，最短距离，避开高速
    var routePolicy = BMAP_DRIVING_POLICY_LEAST_DISTANCE;
    for (var i = 0; i < didian.length - 1; i++) {
        search(didian[i], didian[i + 1], routePolicy);
        function search(start, end, route) {
            var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true }, policy: route });
            driving.search(start, end);
        }
    }
</script>
</html>
