<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaiDuMap.aspx.cs" Inherits="EyouSoft.WAP.BaiDuMap" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;}
		#golist {display: none;}
		@media (max-device-width: 780px){#golist{display: block !important;}}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?type=quick&ak=ovOm8pf0QIyWC4n4jx8I5vPG&v=1.0"></script>
	<title></title>
</head>
<body>
<uc1:WapHeader runat="server" ID="WapHeader1" />
	<div id="allmap" style="top:44px;"></div>
</body>
</html>
<script type="text/javascript">
	// 百度地图API功能
	var map = new BMap.Map("allmap");
	var point = new BMap.Point("<%= jingdu%>","<%= weidu%>");
	map.centerAndZoom(point, 15);
	map.addControl(new BMap.ZoomControl());

	var marker = new BMap.Marker(new BMap.Point("<%= jingdu%>","<%= weidu%>"));  //创建标注
	map.addOverlay(marker);    // 将标注添加到地图中
	var opts = {
		width : 260,    // 信息窗口宽度
		height: 95,     // 信息窗口高度
		title : "<%= title%>", // 信息窗口标题
		enableAutoPan : true //自动平移
	}
	var infoWindow = new BMap.InfoWindow("<%= content%>", opts);  // 创建信息窗口对象
	marker.addEventListener("click", function(){          
		map.openInfoWindow(infoWindow,point); //开启信息窗口
	});
	
</script>
