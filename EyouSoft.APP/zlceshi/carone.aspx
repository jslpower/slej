<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carone.aspx.cs" Inherits="EyouSoft.WAP.zlceshi.carone" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?type=quick&ak=ovOm8pf0QIyWC4n4jx8I5vPG&v=1.0"></script>
</head>
<body>
    <div id="mapdiv">
        <input id="FirstAddress" type="text" data-lng="" data-lat="" />
        <input id="OneMap" type="button" value="地图选址" />
        <input id="LastAddress"  type="text" />
        <input id="TwoMap" type="button" value="button" />
    </div>
    <div id="allmap" style="display:none;width:100%; height:480px;"></div>
</body>
<script type="text/javascript">
    $(document).ready(function() {
    pageOpt.InputChange();
        PageOrder.Show();
    });
</script>
<script type="text/javascript">
    $("#OneMap").click(function() {
        $("#allmap").css("height", window.screen.height);
        $("#mapdiv").hide();
        $("#allmap").toggle();
        pageOpt.initMapAddress("FirstAddress");
    })
    $("#TwoMap").click(function() {
        $("#allmap").css("height", window.screen.height);
        $("#mapdiv").hide();
        $("#allmap").toggle();
        pageOpt.initMapAddress("LastAddress");
    })
</script>
<script type="text/javascript">
    var pageOpt = {
        initMapAddress: function(inputid) {
            // 百度地图API功能
            var map = new BMap.Map("allmap");
            map.centerAndZoom(new BMap.Point(120.169874, 30.276608), 12);
            function showInfo(e) {
                var point = new BMap.Point(e.point.lng, e.point.lat);
                $("#" + inputid).attr("data-lng", "e.point.lng");
                $("#" + inputid).attr("data-lng", "e.point.lat");
                map.centerAndZoom(point, 12);
                map.addControl(new BMap.ZoomControl());
                var gc = new BMap.Geocoder();

                map.addEventListener("click", function(e) {
                    var pt = e.point;
                    gc.getLocation(pt, function(rs) {
                        var addComp = rs.addressComponents;
                        var mapaddress = addComp.province + addComp.city;
                        if (addComp.district != null && addComp.district != "") {
                            mapaddress = mapaddress + addComp.district;
                        }
                        if (addComp.street != null && addComp.street != "") {
                            mapaddress = mapaddress + addComp.street;
                        }
                        if (addComp.streetNumber != null && addComp.streetNumber != "") {
                            mapaddress = mapaddress + addComp.streetNumber;
                        }
                        $("#" + inputid).val(mapaddress);
                        $("#allmap").toggle();
                        $("#mapdiv").show();
                    });
                });
            }
            map.addEventListener("click", showInfo);
        },
        InputChange: function() {
            $("#FirstAddress").blur(function() {
                if ($("#FirstAddress").val() != "" && $("#LastAddress").val() != "") {
                    var para = { fir-lng:$("#FirstAddress").attr("data-lng"),fir-lng: $("#FirstAddress").attr("data-lat"), last-lng:$("#LastAddress").attr("data-lng"),last-lng:$("#LastAddress").attr("data-lat")};
                    $.ajax({
                        type: "post",
                        url: "/zlceshi/cartwo.aspx?" + $.param(para),
                        dataType: "text",
                        cache: false,
                        success: function(result) {
                            
                        }
                    });
                }
            });
            $("#LastAddress").blur(function() {
                if ($("#FirstAddress").val() != "" && $("#LastAddress").val() != "") {

                }
            });
        }
    }
</script>
</html>
