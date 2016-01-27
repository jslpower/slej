<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cartwo.aspx.cs" Inherits="EyouSoft.WAP.zlceshi.cartwo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
<script type="text/javascript">
    var longitude1 = "<%= longitude1%>";
    var latitude1 = "<%= latitude1%>";
    var longitude2 = "<%= longitude2%>";
    var latitude2 = "<%= latitude2%>";
    function GetDrivingInfo(id, longitude1, latitude1, longitude2, latitude2) {
        var map = new BMap.Map("allmap");
        map.centerAndZoom(new BMap.Point(longitude1, latitude1), 15);
        // 百度地图API功能
        var sP1 = new BMap.Point(longitude1, latitude1);    //起点
        var sP2 = new BMap.Point(longitude2, latitude2);    //终点
        var v1, v2;
        var searchComplete = function(results) {
            if (transit.getStatus() != BMAP_STATUS_SUCCESS) {
                return;
            }
            var plan = results.getPlan(0);
            v1 = plan.getDuration(true);                //获取时间
            v2 = plan.getDistance(true) + "\n";             //获取距离
        }
        var transit = new BMap.DrivingRoute(map, { renderOptions: { map: map },
            onSearchComplete: searchComplete,
            onPolylinesSet: function() {
                setTimeout(function() {
                    $("#juli").html(v2);
                }, "1000");
            }
        });
        transit.search(sP1, sP2);
    }
</script>
</html>
