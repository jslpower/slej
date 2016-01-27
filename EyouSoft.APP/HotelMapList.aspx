<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelMapList.aspx.cs" Inherits="EyouSoft.WAP.HotelMapList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>酒店地图搜索</title>


<script type="text/javascript" src="http://api.map.baidu.com/api?type=quick&ak=ovOm8pf0QIyWC4n4jx8I5vPG&v=1.0"></script>
<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
<style type="text/css">
.BMap_bubble_content a{color: #fff;}
</style>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
  <div id="allmap" style="width:100%; height:1000px;"></div>
  

  
</body>
<script type="text/javascript">
    $("#allmap").css("height", window.screen.height);
	// 百度地图API功能	
	map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(<%=lngnum %>, <%= latnum%>), 12);
	var data_info = [<%=hotellist %>];
	var opts = {
				width : 250,     // 信息窗口宽度
				height: 105,     // 信息窗口高度
				enableMessage:true//设置允许信息窗发送短息
			   };
	for(var i=0;i<data_info.length;i++){
		var marker = new BMap.Marker(new BMap.Point(data_info[i][0],data_info[i][1]));  // 创建标注
		var content = data_info[i][2];
		map.addOverlay(marker);               // 将标注添加到地图中
		addClickHandler(content,marker);
	}
	function addClickHandler(content,marker){
		marker.addEventListener("click",function(e){
			openInfo(content,e)}
		);
	}
	function openInfo(content,e){
		var p = e.target;
		var point = new BMap.Point(p.getPosition().lng, p.getPosition().lat);
		var infoWindow = new BMap.InfoWindow(content,opts);  // 创建信息窗口对象 
		map.openInfoWindow(infoWindow,point); //开启信息窗口
	}
</script>
</html>
