<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="EyouSoft.WAP.Hotel" %>

<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>
        <%=FenXiangBiaoTi %></title>
    <link href="/css/hotel.css" rel="stylesheet" type="text/css" />
    <link href="/css/slider.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/jipiao.sanzima.js" type="text/javascript"></script>

   <script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
        <div class="user_form h_form mt10">
            <ul>
                <li class="R_jiantou"><span class="label_name"><s class="ico_city"></s>入住城市</span>
                    <input readonly="readonly" class="u-input " type="text" id="startcity" value="杭州" />
                    <input id="CitySZM" type="hidden" value="HGH" />
                </li>
            </ul>
        </div>
        <div class="user_form h_form mt10">
            <ul>
                <li class="R_jiantou2">
                    <!-----点击后的li样式是down_jiantou------->
                    <span class="label_name"><s class="ico_address"></s>地理位置</span>
                    <input type="text" class="u-input" id="DiLiWeiZhi" value="">
                </li>
            </ul>
        </div>
        <div class="user_form h_form mt10">
            <ul>
                <li id="RuZhuTime" class="R_jiantou" style="padding-right: 104px;"><span class="ruzhu_R">
                    <i class="font_blue floatR">入住</i> <em id="ruweekday"></em></span><span class="label_name">
                        <s class="ico_ruzhu_date"></s>入住日期</span>
                    <input readonly="readonly" value="<%=DateTime.Now.Date.AddDays(7).ToString("yyyy-MM-dd") %>"
                        class="u-input" type="text" id="ruzhu" />
                </li>
            </ul>
        </div>
        <div class="user_form h_form mt10">
            <ul>
                <li id="LiDianTime" class="R_jiantou" style="padding-right: 104px;"><span class="ruzhu_R">
                    <i class="font_blue floatR">离店</i> <em id="liweekday"></em></span><span class="label_name">
                        <s class="ico_ruzhu_date"></s>离店日期</span>
                    <input readonly="readonly" class="u-input" type="text" id="lidian" value="<%=DateTime.Now.Date.AddDays(8).ToString("yyyy-MM-dd") %>" />
                </li>
            </ul>
        </div>
        <div class="user_form h_form mt10">
            <ul>
                <li class="up_jiantou">
                    <!-----点击后的li样式是down_jiantou------->
                    <span class="label_name"><s class="ico_price"></s>价格筛选</span>
                    <input type="text" id="PriceRange" name="PriceRange" readonly="readonly" class="u-input"
                        value="价格筛选">
                    <input id="StartPrice" name="StartPrice" value="" type="hidden" /><input id="EndPrice"
                        name="EndPrice" type="hidden" value="" />
                </li>
            </ul>
            <div class="price_more padd" style="display: none;">
                <div class="price_box">
                    <a data-price="jiage" data-start="0" data-end="150" href="javascript:void(0);">0~150元</a>
                    <a data-price="jiage" data-start="150" data-end="300" href="javascript:void(0);">150~300元</a>
                    <a data-price="jiage" data-start="300" data-end="500" href="javascript:void(0);">300~500元</a>
                    <a data-price="jiage" data-start="500" data-end="1000" href="javascript:void(0);">500~1000元</a>
                </div>
                <div class="font13 font_gray">
                    自定义
                    <input name="startP" id="startP" type="text" class="input_bk" style="width: 90px;"
                        onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')">
                    -
                    <input name="endP" id="endP" type="text" class="input_bk" style="width: 90px;" onkeyup="this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')"></div>
            </div>
        </div>
        <div class="user_form h_form mt10">
            <ul>
                <li class="up_jiantou">
                    <!-----点击后的li样式是down_jiantou------->
                    <span class="label_name"><s class="ico_star"></s>星级筛选</span>
                    <input type="text" id="HotelStar" name="HotelStar" readonly="readonly" class="u-input"
                        value="星级筛选">
                    <input id="StarNum" name="StarNum" type="hidden" value="" />
                </li>
            </ul>
            <div class="star_more padd" style="display: none;">
                <div class="star_box">
                    <ul>
                        <li data-star="xingji" data-num="" data-name="星级筛选"><a href="javascript:void(0);"
                            class="a_input"></a>星级筛选</li>
                        <li data-star="xingji" data-num="2" data-name="二星级"><a href="javascript:void(0);"
                            class="a_input"></a>二星级</li>
                        <li data-star="xingji" data-num="3" data-name="三星级"><a href="javascript:void(0);"
                            class="a_input"></a>三星级</li>
                        <li data-star="xingji" data-num="4" data-name="四星级"><a href="javascript:void(0);"
                            class="a_input"></a>四星级</li>
                        <li data-star="xingji" data-num="5" data-name="五星级"><a href="javascript:void(0);"
                            class="a_input"></a>五星级</li>
                        <li data-star="xingji" data-num="7" data-name="参考二星级"><a href="javascript:void(0);"
                            class="a_input"></a>参考二星级</li>
                        <li data-star="xingji" data-num="8" data-name="参考三星级"><a href="javascript:void(0);"
                            class="a_input"></a>参考三星级</li>
                        <li data-star="xingji" data-num="9" data-name="参考四星级"><a href="javascript:void(0);"
                            class="a_input"></a>参考四星级</li>
                        <li data-star="xingji" data-num="10" data-name="参考五星级"><a href="javascript:void(0);"
                            class="a_input"></a>参考五星级</li>
                        <li data-star="xingji" data-num="11" data-name="其他"><a href="javascript:void(0);"
                            class="a_input"></a>其他</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="user_form h_form mt10">
            <ul>
                <li class="R_jiantou"><span class="label_name"><s class="ico_city"></s>酒店名称</span>
                    <input class="u-input " type="text" id="HotelName" value="" />
                </li>
            </ul>
        </div>
        <div class="hotel_address mt10 clearfix">
            <ul>
                <li><a id="GetYouAdd" class="yudin_btn" href="javascript:void(0);">周边酒店</a>
                    <input id="YouAddress" name="YouAddress" type="text" readonly="readonly" value="您的位置">
                    <input id="mylatitude" name="mylatitude" type="hidden" /><input id="mylongitude"
                        name="mylongitude" type="hidden" />
                </li>
            </ul>
        </div>
        <div class="padd cent clearfix">
            <ul>
                <li><a id="LieBiaoGet" href="javascript:void(0);" class="y_btn"><i class="s-ico"></i>
                    马上搜索</a></li>
                <li class="mt10"><a id="MapGet" href="javascript:void(0);" class="y_btn"><i class="s-ico">
                </i>地图搜索</a></li>
            </ul>
        </div>
    </div>
    <div id="l-map" style="display: none">
    </div>
    <div class="datelist" style="display: none; padding-top: 48px; width: 100%; height: 100%;
        box-sizing: border-box;">
        <asp:Literal ID="litMonth" runat="server"></asp:Literal>
    </div>
    <div class="citylist" style="display: none; padding-top: 48px; width: 100%; height: 100%;
        box-sizing: border-box;">
        <div class="jq_search" style="background: #fff;">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="text" placeholder="请输入城市拼音/中文" class="input_txt floatL" value="" id="citySeachBox" />
                    <input name="" type="button" class="icon_search_i floatR">
                </div>
            </div>
        </div>
        <div class="city_list" style="padding-top: 56px;">
            <ul>
                <li class="city_li">
                    <div class="city_group_title">
                        热门城市</div>
                    <ul id="remen" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        A</div>
                    <ul id="A" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        B</div>
                    <ul id="B" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        C</div>
                    <ul id="C" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        D</div>
                    <ul id="D" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        E</div>
                    <ul id="E" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        F</div>
                    <ul id="F" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        G</div>
                    <ul id="G" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        H</div>
                    <ul id="H" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        I</div>
                    <ul id="I" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        J</div>
                    <ul id="J" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        K</div>
                    <ul id="K" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        L</div>
                    <ul id="L" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        M</div>
                    <ul id="M" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        N</div>
                    <ul id="N" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        O</div>
                    <ul id="O" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        P</div>
                    <ul id="P" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        Q</div>
                    <ul id="Q" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        R</div>
                    <ul id="R" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        S</div>
                    <ul id="S" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        T</div>
                    <ul id="T" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        U</div>
                    <ul id="U" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        V</div>
                    <ul id="V" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        W</div>
                    <ul id="W" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        X</div>
                    <ul id="X" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        Y</div>
                    <ul id="Y" class="city_group_box">
                    </ul>
                </li>
                <li class="city_li">
                    <div class="city_group_title">
                        Z</div>
                    <ul id="Z" class="city_group_box">
                    </ul>
                </li>
            </ul>
        </div>
    </div>
    <input id="JiaoDian" type="hidden" />
    <input id="JianDianWeek" type="hidden" />
    <!---位置区域--->
    <div class="user-mask" data-name="area" data-class="searchdiv" style="display: block;
        z-index: 999; visibility: hidden">
        <div class="hotel-mask-cnt box" style="margin-top: 0; height: 300px; position: absolute;
            bottom: 0; left: 0;">
            <div class="place_box clearfix padd10">
                <div id="fdibiao" class="place_list box" style="top: 0px; bottom: 0px; left: 0px;
                    overflow: hidden; position: absolute;">
                    <ul id="AreaNameList">
                    </ul>
                </div>
                <div id="sdibiao" class="place_list2 box" data-class="landdibiao" style="top: 0px;
                    bottom: 0px; left: 30%; overflow: hidden; position: absolute;">
                    <ul class="dibiao_listTab">
                    </ul>
                </div>
                <div id="tdibiao" class="star_box box" data-class="dibiao" style="width: 40%; top: 0px;
                    right: 0px; bottom: 0px; overflow: hidden; position: absolute;">
                    <ul class="dibiao_name">
                    </ul>
                </div>
                <input id="LandMarkID" type="hidden" />
                <input id="LandMark" type="hidden" />
            </div>
        </div>
    </div>
</body>

<script type="text/javascript" src="http://api.map.baidu.com/api?type=quick&ak=ovOm8pf0QIyWC4n4jx8I5vPG&v=1.0"></script>

<script type="text/javascript">
    $("#GetYouAdd").click(function() {
        $("#YouAddress").val("正在获取您的位置...");
        if (navigator.geolocation) {

            var getOptions = {
                enableHighAccuracy: true,
                timeout: 5000, //毫秒
                maximumAge: 0
            };
            //成功回调
            function getSuccess(position) {
                $("#mylatitude").val(position.coords.latitude);
                // 估算的经度
                $("#mylongitude").val(position.coords.longitude);
                bdGEO();
            }
            //失败回调
            function getError(error) {
                switch (error.code) {
                    case error.TIMEOUT:
                        console.log('超时');
                        break;
                    case error.PERMISSION_DENIED:
                        console.log('用户拒绝提供地理位置');
                        break;
                    case error.POSITION_UNAVAILABLE:
                        console.log('地理位置不可用');
                        break;
                    default:
                        break;
                }
            }
            navigator.geolocation.getCurrentPosition(getSuccess, getError, getOptions);
        }
    });
    // 百度地图API功能
    var map = new BMap.Map("l-map");
    map.centerAndZoom(new BMap.Point(116.328749, 40.026922), 13);
    //map.enableScrollWheelZoom(true);
    var myGeo = new BMap.Geocoder();
    function bdGEO() {
        var pt = new BMap.Point($("#mylongitude").val(), $("#mylatitude").val());
        geocodeSearch(pt);
    }
    function geocodeSearch(pt) {
        myGeo.getLocation(pt, function(rs) {
            var addComp = rs.addressComponents;
            $("#YouAddress").val("您的位置：" + addComp.province + addComp.city +
addComp.district + addComp.street + addComp.streetNumber);
        });
    }
</script>

<script type="text/javascript">
    $(".up_jiantou").click(function() {
        if ($(this).attr("class") == "up_jiantou") {
            $(this).removeClass("up_jiantou").addClass("down_jiantou");
        }
        else {
            $(this).removeClass("down_jiantou").addClass("up_jiantou");
        }
        $(this).closest(".user_form").find(".padd").toggle();
    });
    //价格部分开始
    $("a[data-price=jiage]").click(function() {
        $("a[data-price=jiage]").removeClass("on");
        $(this).addClass("on");
        $("#PriceRange").val($(this).html().replace("元", ""));
        $("#StartPrice").val($(this).attr("data-start"));
        $("#EndPrice").val($(this).attr("data-end"));
        $(this).closest(".user_form").find(".padd").toggle();
    });
    $("#startP").change(function() {
        if ($("#endP").val() != "") {
            $("#PriceRange").val($("#startP").val() + "~" + $("#endP").val());
            $("#StartPrice").val($("#startP").val());
            $("#EndPrice").val($("#endP").val());
        }
        else {
            $("#PriceRange").val("大于" + $("#startP").val());
            $("#StartPrice").val($("#startP").val());
        }
        $("a[data-price=jiage]").removeClass("on");
    });
    $("#endP").change(function() {
        if ($("#startP").val() != "") {
            $("#PriceRange").val($("#startP").val() + "~" + $("#endP").val());
            $("#StartPrice").val($("#startP").val());
            $("#EndPrice").val($("#endP").val());
        }
        else {
            $("#PriceRange").val("小于" + $("#endP").val());
            $("#EndPrice").val($("#endP").val());
        }
        $("a[data-price=jiage]").removeClass("on");
    });

    $("#RuZhuTime").click(function() {
        $(".warp").toggle();
        $(".datelist").toggle();
        $('body,html').animate({ scrollTop: 0 }, 500);
        $("#JiaoDian").val("ruzhu");
        $("#JianDianWeek").val("ruweekday");
    });
    $("#LiDianTime").click(function() {
        $(".warp").toggle();
        $(".datelist").toggle();
        $('body,html').animate({ scrollTop: 0 }, 500);
        $("#JiaoDian").val("lidian");
        $("#JianDianWeek").val("liweekday");
    });
    $(".riqi_day_select").click(function() {
        var weekday = $(this).attr("data-week");
        if (weekday == "Monday") { $("#" + $("#JianDianWeek").val()).html("周一"); }
        else if (weekday == "Tuesday") { $("#" + $("#JianDianWeek").val()).html("周二"); }
        else if (weekday == "Wednesday") { $("#" + $("#JianDianWeek").val()).html("周三"); }
        else if (weekday == "Thursday") { $("#" + $("#JianDianWeek").val()).html("周四"); }
        else if (weekday == "Friday") { $("#" + $("#JianDianWeek").val()).html("周五"); }
        else if (weekday == "Saturday") { $("#" + $("#JianDianWeek").val()).html("周六"); }
        else if (weekday == "Sunday") { $("#" + $("#JianDianWeek").val()).html("周日"); }
        $("#" + $("#JiaoDian").val()).val($(this).attr("data-date"));
        if ($("#JiaoDian").val() == "ruzhu") {
            var weekday = $(this).attr("data-week");
            if (weekday == "Monday") { $("#liweekday").html("周二"); }
            else if (weekday == "Tuesday") { $("#liweekday").html("周三"); }
            else if (weekday == "Wednesday") { $("#liweekday").html("周四"); }
            else if (weekday == "Thursday") { $("#liweekday").html("周五"); }
            else if (weekday == "Friday") { $("#liweekday").html("周六"); }
            else if (weekday == "Saturday") { $("#liweekday").html("周日"); }
            else if (weekday == "Sunday") { $("#liweekday").html("周一"); }
            var timeadd = new Date($(this).attr("data-date"));
            var mymonth = (parseInt(timeadd.getMonth()) + 1);
            var myday = (parseInt(timeadd.getDate()) + 1);
            if (mymonth < 10) {
                mymonth = "0" + mymonth;
            }
            if (myday < 10) {
                myday = "0" + myday;
            }
            timeadd = timeadd.getFullYear() + "-" + (mymonth) + "-" + (myday);
            $("#lidian").val(timeadd);

        }
        $(".warp").toggle();
        $(".datelist").toggle();
    })

    $("#startcity").click(function() {
        $(".warp").toggle();
        $(".citylist").toggle();
        $('body,html').animate({ scrollTop: 0 }, 500);
    })

    //价格结束
    //星级开始
    $("li[data-star=xingji]").click(function() {
        $("li[data-star=xingji]").find("a").removeClass("a_input_on");
        $(this).find("a").addClass("a_input_on");
        $("#HotelStar").val($(this).attr("data-name"));
        $("#StarNum").val($(this).attr("data-num"));
        $(this).closest(".user_form").find(".padd").toggle();
    });
    //星级结束
    $("#LieBiaoGet").click(function() {
        var url = "/HotelList.aspx?CityName=" + $("#startcity").val() + "&CityCode=" + $("#CitySZM").val() + "&longitude=" + $("#mylongitude").val() + "&latitude=" + $("#mylatitude").val() + "&HotelName=" + $("#HotelName").val() + "&Star=" + $("#StarNum").val() + "&RuZhuRiQi=" + $("#ruzhu").val() + "&LiDianRiQi=" + $("#lidian").val() + "&JiaGe1=" + $("#StartPrice").val() + "&JiaGe2=" + $("#EndPrice").val() + "&LandMark=" + $("#LandMark").val() + "&LandMarkID=" + $("#LandMarkID").val() + "&";
        window.location.href = url;
    });
    $("#MapGet").click(function() {
        if ($("#mylatitude").val() != null && $("#mylongitude").val() != null && $("#mylatitude").val() != "" && $("#mylongitude").val() != "") {
            var url = "/HotelMapList.aspx?CityName=" + $("#startcity").val() + "&CityCode=" + $("#CitySZM").val() + "&longitude=" + $("#mylongitude").val() + "&latitude=" + $("#mylatitude").val() + "&HotelName=" + $("#HotelName").val() + "&Star=" + $("#StarNum").val() + "&RuZhuRiQi=" + $("#ruzhu").val() + "&LiDianRiQi=" + $("#lidian").val() + "&JiaGe1=" + $("#StartPrice").val() + "&JiaGe2=" + $("#EndPrice").val() + "&LandMark=" + $("#LandMark").val() + "&LandMarkID=" + $("#LandMarkID").val() + "&";
            window.location.href = url;
        }
        else {
            var url = "/HotelMapList.aspx?CityName=" + $("#startcity").val() + "&CityCode=" + $("#CitySZM").val() + "&longitude=" + $("#mylongitude").val() + "&latitude=" + $("#mylatitude").val() + "&HotelName=" + $("#HotelName").val() + "&Star=" + $("#StarNum").val() + "&RuZhuRiQi=" + $("#ruzhu").val() + "&LiDianRiQi=" + $("#lidian").val() + "&JiaGe1=" + $("#StartPrice").val() + "&JiaGe2=" + $("#EndPrice").val() + "&LandMark=" + $("#LandMark").val() + "&LandMarkID=" + $("#LandMarkID").val() + "&";
            window.location.href = url;
        }
    });
</script>

<script type="text/javascript">

    //位置区域

    $(".R_jiantou2").click(function() {
        $("div[data-name=area]").css("visibility", "visible");
        PageDind.GetMarkName();
    });

    var PageDind = {
        GetMarkName: function() {
            var CityCode = $("#CitySZM").val();
            $.ajax({
                type: "post", url: "/ashx/CityHandler.ashx?dotype=SanZiMa&CityCode=" + encodeURI(CityCode), dataType: "json",
                success: function(response) {
                    $("#AreaNameList").html("");
                    for (var i = 0; i < response.length; i++) {
                        if (i == 0) {
                            $("#AreaNameList").append("<li data-arcode=\"" + response[i].AreaCode + "\" data-class=\"onedibiao\" class=\"on\">" + response[i].AreaName + "</li>");
                            PageDind.GetLandMarkName(response[i].AreaCode);
                        }
                        else {
                            $("#AreaNameList").append("<li data-arcode=\"" + response[i].AreaCode + "\" data-class=\"onedibiao\">" + response[i].AreaName + "</li>");
                        }
                    }
                    var theight = 39 * response.length + 10;
                    $("#AreaNameList").css("height", theight + "px");

                    document.addEventListener('DOMContentLoaded', PageDind.loaded2(), false);
                    $("#AreaNameList").find("li").bind("click", function() {
                        var AreaCode = $(this).attr("data-arcode");
                        $("#AreaNameList li").removeClass("on");
                        $(this).addClass("on");
                        PageDind.GetLandMarkName(AreaCode);
                    });
                }
            });
        },
        GetLandMarkName: function(AreaCode) {
            var CityCode = $("#CitySZM").val();
            $.ajax({
                type: "post", url: "/ashx/CityHandler.ashx?dotype=LandMarkName&CityCode=" + encodeURI(CityCode) + "&AreaCode=" + encodeURI(AreaCode), dataType: "json",
                success: function(response) {
                    $(".dibiao_listTab").html("");
                    var LandName = response[0].LandMarkName;
                    for (var i = 0; i < response.length; i++) {
                        if (response[0].LandMarkName == "NONE") {
                            PageDind.GetLandChildName(AreaCode, "");
                        }
                        else {
                            if (i == 0) {
                                if (response[0].LandMarkName == "无相关地标") {
                                    $(".dibiao_listTab").append("<li class=\"on\">" + response[i].LandMarkName + "</li>");
                                    $(".dibiao_name").html("");
                                }
                                else {
                                    $(".dibiao_listTab").append("<li  data-acode=\"" + AreaCode + "\" data-class=\"twodibiao\" data-mark=\"" + response[i].LandMarkName + "\" class=\"on\">" + response[i].LandMarkName + "</li>"); PageDind.GetLandChildName(AreaCode, response[i].LandMarkName);
                                }
                            }
                            else {
                                if (response[0].LandMarkName == "无相关地标") {
                                    $(".dibiao_listTab").append("<li>" + response[i].LandMarkName + "</li>");
                                    $(".dibiao_name").html("");
                                }
                                else {
                                    $(".dibiao_listTab").append("<li data-acode=\"" + AreaCode + "\" data-class=\"twodibiao\" data-mark=\"" + response[i].LandMarkName + "\">" + response[i].LandMarkName + "</li>");
                                }
                            }
                        }
                    }

                    if ($(".dibiao_listTab").html() == "") {
                        $("div[data-class=landdibiao]").hide();
                        $("div[data-class=dibiao]").css("width", "70%");
                    }
                    else {
                        $("div[data-class=landdibiao]").show();
                        $("div[data-class=dibiao]").css("width", "40%");
                    }

                    var theight = 39 * response.length + 10;
                    $(".dibiao_listTab").css("height", theight + "px");

                    document.addEventListener('DOMContentLoaded', PageDind.loaded3(), false);

                    $(".dibiao_listTab").find("li").bind("click", function() {
                        var AreaCode = $(this).attr("data-acode");
                        var LandMarkName = $(this).attr("data-mark");
                        $(".dibiao_listTab li").removeClass("on");
                        $(this).addClass("on");
                        PageDind.GetLandChildName(AreaCode, LandMarkName);
                    });
                }
            });
        },
        GetLandChildName: function(AreaCode, LandMarkName) {
            var CityCode = $("#CitySZM").val();
            $.ajax({
                type: "post", url: "/ashx/CityHandler.ashx?dotype=LandChildName&CityCode=" + encodeURI(CityCode) + "&AreaCode=" + encodeURI(AreaCode) + "&LandMarkName=" + encodeURI(LandMarkName), dataType: "json",
                success: function(response) {
                    $(".dibiao_name").html("");
                    var LandName = response[0].LandMarkName;
                    for (var i = 0; i < response.length; i++) {
                        var LandMarkChildName = response[i].LandMarkChildName;
                        $(".dibiao_name").append("<li><a href=\"javascript:\" title=" + LandMarkChildName + " data-id=\"" + response[i].ID + "\" data-class=\"threemark\" class=\"a_input\"></a>" + LandMarkChildName + "</li>");
                    }
                    var theight = 39 * response.length + 10;
                    $(".dibiao_name").css("height", theight + "px");

                    document.addEventListener('DOMContentLoaded', PageDind.loaded1(), false);
                    $(".dibiao_name").find("li").bind("click", function() {
                        $("#LandMarkID").val($(this).find("a").attr("data-id"));
                        $("#LandMark").val($(this).find("a").attr("title"));
                        $("#DiLiWeiZhi").val($(this).find("a").attr("title"));
                        $(".dibiao_name li a").removeClass("a_input_on").addClass("a_input");
                        $(this).find("a").addClass("a_input_on");
                        $("div[data-name=area]").css("visibility", "hidden");
                    });
                }
            });
        },
        loaded1: function() {
            myScroll = new iScroll('tdibiao', { mouseWheel: true, click: true, checkDOMChanges: true, hScrollbar: false, vScrollbar: false });
        },
        loaded2: function() {
            myScroll = new iScroll('fdibiao', { mouseWheel: true, click: true, checkDOMChanges: true, hScrollbar: false, vScrollbar: false });
        },
        loaded3: function() {
            myScroll = new iScroll('sdibiao', { mouseWheel: true, click: true, checkDOMChanges: true, hScrollbar: false, vScrollbar: false });
        }

    }

    var pageOpt = {
        initCityList: function(guolv) {
            var dataBox = [];
            if (guolv != "" && guolv != 'undefined' && guolv != null) {
                for (var k = 0; k < jiPiaoSanZiMaData.length; k++) {
                    if (jiPiaoSanZiMaData[k].CityName.toUpperCase().indexOf(guolv.toUpperCase()) >= 0
                        || jiPiaoSanZiMaData[k].PY2.toUpperCase().indexOf(guolv.toUpperCase()) >= 0
                        || jiPiaoSanZiMaData[k].PY1.toUpperCase().indexOf(guolv.toUpperCase()) >= 0) {
                        dataBox.push(jiPiaoSanZiMaData[k]);
                    }
                }
            }
            else {
                dataBox = jiPiaoSanZiMaData;
            }
            var rm = "";
            $(".city_group_box").html('');
            //            for (var i = 0; i < 8; i++) {
            //                if (dataBox[i].IsReDian == true) {
            //                    rm += '<li class="ckLi" data-Code=' + dataBox[i].Code + '>' + dataBox[i].CityName + '</li>';
            //                }
            //            }
            //            $("#remen").html(rm);

            if (dataBox == jiPiaoSanZiMaData) {
                var rm = "";
                for (var i = 0; i < 30; i++) {
                    if (dataBox[i].IsReDian == true) {
                        rm += '<li class="ckLi" data-Code=' + dataBox[i].Code + '>' + dataBox[i].CityName + '</li>';
                    }
                }
                $("#remen").html(rm);
            }

            for (var j = 0; j < dataBox.length; j++) {
                $("#" + dataBox[j].PY3.replace(/(^\s*)|(\s*$)/g, "")).append('<li  class="ckLi" data-Code=' + dataBox[j].Code + '>' + dataBox[j].CityName + '</li>');
            }
            $(".city_group_box").each(function() {
                if ($(this).html().replace(/(^\s*)|(\s*$)/g, "") == "") {
                    $(this).parent().hide();
                } else {
                    $(this).parent().show();
                }
            })
            pageOpt.initClick();
        },

        initClick: function() {
            $(".ckLi").click(function() {
                var word = $(this).text().replace(/(^\s*)|(\s*$)/g, "");
                var code = $(this).attr("data-Code").replace(/(^\s*)|(\s*$)/g, "");

                $("#CitySZM").val(code);
                $("#startcity").val(word);
                $(".warp").toggle();
                $(".citylist").toggle();
                //document.getElementById("myform").submit();

            })
        }

    }

    $(function() {
        pageOpt.initCityList();
        //绑定chang事件
        var bind_name = "input"; //定义所要绑定的事件名称
        if (navigator.userAgent.indexOf("MSIE") != -1) bind_name = "propertychange"; //判断是否为IE内核 IE内核的事件名称要改为propertychange
        $("#citySeachBox").bind(bind_name, function() {
            pageOpt.initCityList($(this).val().replace(/(^\s*)|(\s*$)/g, ""));
        })
    })
</script>

</html>
