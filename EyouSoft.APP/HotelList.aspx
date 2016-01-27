<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelList.aspx.cs" Inherits="EyouSoft.WAP.HotelList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title><%=FenXiangBiaoTi %></title>
    

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <link href="css/ustyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;

        function pullDownAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                for (i = 0; i < 12; i++) {
                    $(el).append("<li>Generated row " + (++generatedCount) + "</li>")
                }

                myScroll.refresh();
            }, 1000);
        }

        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                var url = window.location.href;
                url = url.replace(/pageindex=([\d]*?)&/, '');
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxHotel.aspx?" + url.split('?')[1] + "&pageindex=" + index,
                    cache: false,
                    success: function(result) {
                        if (result != "" && result.length > 2) {
                            $(el).append(result);
                        }
                        else {
                            pullUpEl.querySelector('.pullUpLabel').innerHTML = '已加载至最后';
                        }
                    }
                });
                myScroll.refresh();
            }, 1000);
        }

        function loaded() {

            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight

            myScroll = new iScroll('wrapper', {
                mouseWheel: true,
                click: true,
                checkDOMChanges: true,
                onRefresh: function() {
                    if (pullUpEl.className.match('loading')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                    }
                },
                onScrollMove: function() {
                    if (this.y < (this.maxScrollY - 5) && !pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'flip';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '放开刷新..';
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.className.match('flip')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                        this.maxScrollY = pullUpOffset;
                    }
                },
                onScrollEnd: function() {
                    if (pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'loading';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '正在加载...';
                        pullUpAction();
                    }
                }
            });
        }

        document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
        document.addEventListener('DOMContentLoaded', loaded, false);

        function change(i) {
            if (i == 1) {
                $("#a1").show();
                $("#a2").hide();

            }
            else {
                $("#a2").show();
                $("#a1").hide();
            }

            myScroll.scrollToPage(0, 0, 100);


        }


    </script>

    <style type="text/css">
        .a_input
        {
            margin-right: 20px;
        }
    </style>
</head>
<body scroll="no">
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <link href="/css/hotel.css" rel="stylesheet" type="text/css" />
    <div class="warp">
        <div class="jq_search  h-search">
            <div class="search ">
                <div class="search_form clearfix">
                    <input id="SearchName" type="text" class="input_txt floatL" value="酒店名称" onfocus="javascript:if(this.value=='酒店名称')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='酒店名称';" forecolor="#999999">
                    <input id="searchBnt" type="button" class="icon_search_i floatR">
                </div>
            </div>
            <div id="GetYouAdd" class="my_address">
                我的附近</div>
            <input id="mylatitude" name="mylatitude" type="hidden" /><input id="mylongitude"
                name="mylongitude" type="hidden" />
        </div>
        <input id="CityCode" type="hidden" value="<%= CitySanZiMa%>" />
        <div class="line_xz_warp" style="top: 100px;">
            <div class="line_xz hotel_xz">
                <ul>
                    <li style="width: 33%;"><a data-name="area" data-class="searchbox" href="javascript:;" class="">位置区域<i></i></a></li>
                    <li style="width: 33%;"><a data-name="jiage" data-class="searchbox" href="javascript:void(0);">价格筛选<i></i></a></li><!--------点击a出现层加上样式on------层隐藏页面最底部------->
                    <li style="width: 33%;"><a data-name="star" data-class="searchbox" href="javascript:void(0);">星级筛选<i></i></a></li>
                </ul>
            </div>
        </div>
        <div class="jq_list" style="padding-top: 101px;">
            <div id="wrapper">
                <div id="scroller">
                    <div id="a1">
                        <ul id="linelist">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li><a href="/HotelXX.aspx?HotelId=<%#Eval("HotelId")%>&RuZhuRiQi=<%= ruzhuriqi%>&lidianriqi=<%= lidianriqi%>">
                                        <div class="jq_img">
                                            <img src="<%# EyouSoft.Common.TuPian.F1(Eval("FirstImageAddress"),320,240)%>" /></div>
                                        <dl>
                                            <dt>
                                                <%#Eval("HotelName") %></dt>
                                            <dd>
                                                星级：<%# Eval("Star")%></dd>
                                            <dd>
                                                位置：<%# GetAddress(Eval("HotelId"))%></dd>
                                            <dd class="wid">
                                                门市价：<i class="line_x">¥<%#((decimal)Eval("RoomRateInfo[0].PreferentialPrice") * EyouSoft.BLL.HotelStructure.BHotel2.RetialPricePercent).ToString("0")%></i>
                                                起</dd>
                                            <dd class="wid R">
                                                <span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("RoomRateInfo[0].SettlementPrice"), (decimal)Eval("RoomRateInfo[0].PreferentialPrice"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)(Eval("RoomRateInfo[0].FeeSetting")), EyouSoft.Model.Enum.FeeTypes.酒店).ToString("0")%></i></span>起</dd>
                                        </dl>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <div id="pullUp" style="text-align:center;">
                            <span class="pullUpIcon"></span><span class="pullUpLabel"><asp:Literal ID="XianShi" runat="server"></asp:Literal></span>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <input id="pageindex" type="hidden" value="1" />
    <div data-name="jiage" data-class="searchdiv" class="user-mask" style="display: block;
        z-index: 100; visibility: hidden;">
        <div class="hotel-mask-cnt">
            <div class="padd clearfix">
                <h3 class="font_gray paddB">
                    价格范围</h3>
                <div class="price_box paddB gray_lineB">
                    <a data-price="jiage" data-start="0" data-end="150" href="javascript:void(0);">0~150元</a>
                    <a data-price="jiage" data-start="150" data-end="300" href="javascript:void(0);">150~300元</a>
                    <a data-price="jiage" data-start="300" data-end="500" href="javascript:void(0);">300~500元</a>
                    <a data-price="jiage" data-start="500" data-end="1000" href="javascript:void(0);">500~1000元</a>
                    <a class="on" data-price="jiage" data-start="" data-end="" href="javascript:void(0);">
                        不限</a>
                </div>
                <input id="StartPrice" name="StartPrice" value="" type="hidden" /><input id="EndPrice"
                    name="EndPrice" type="hidden" value="" />
                <div class="cent mt10 clearfix">
                    <a href="javascript:void(0);" id="pricetijiao" class="y_btn">完成</a></div>
            </div>
        </div>
    </div>
    <!---星级筛选--->
    <div data-name="star" data-class="searchdiv" class="user-mask" style="display: block;
        z-index: 100; visibility: hidden;">
        <div id="starxz" class="line-mask-cnt" style="padding-top: 135px; display: block;
            top: 0px; bottom: 0px; overflow: hidden; position: absolute;">
            <div class="star_more padd" style="background: #fff; height:580px;">
                <div class="star_box">
                    <ul>
                        <li data-star="xingji" data-num="" data-name="星级筛选"><a href="javascript:void(0);"
                            class="a_input"></a>星级筛选</li>
                        <li data-star="xingji" data-num="2"><a href="javascript:void(0);" class="a_input a_input_on">
                        </a>二星级</li>
                        <li data-star="xingji" data-num="3"><a href="javascript:void(0);" class="a_input"></a>
                            三星级</li>
                        <li data-star="xingji" data-num="4"><a href="javascript:void(0);" class="a_input"></a>
                            四星级</li>
                        <li data-star="xingji" data-num="5"><a href="javascript:void(0);" class="a_input"></a>
                            五星级</li>
                        <li data-star="xingji" data-num="7"><a href="javascript:void(0);" class="a_input"></a>
                            参考二星级</li>
                        <li data-star="xingji" data-num="8"><a href="javascript:void(0);" class="a_input"></a>
                            参考三星级</li>
                        <li data-star="xingji" data-num="9"><a href="javascript:void(0);" class="a_input"></a>
                            参考四星级</li>
                        <li data-star="xingji" data-num="10"><a href="javascript:void(0);" class="a_input"></a>
                            参考五星级</li>
                        <li data-star="xingji" data-num="11"><a href="javascript:void(0);" class="a_input"></a>
                            其他</li>
                    </ul>
                    <input id="StarNum" name="StarNum" type="hidden" value="2" />
                    <div class="cent padd clearfix" style="margin-bottom: 5px;">
                        <a href="javascript:void(0);" id="startijiao" class="y_btn">完成</a></div>
                </div>
            </div>
        </div>
    </div>
    <!---位置区域--->
    <%--<div class="user-mask" data-name="area" data-class="searchdiv" style="display: block; z-index: 100;   visibility:hidden">
        <div class="line-mask-cnt box">
                <div class="place_box clearfix padd10">
                    <div class="place_list box">
                        <ul id="AreaNameList">
                        </ul>
                    </div>
                    <div class="place_list2 box" data-class="landdibiao">
                        <ul class="dibiao_listTab">
                        </ul>
                    </div>
                    <div id="tdibiao" class="star_box box" data-class="dibiao" style="width: 40%; margin-top:135px; top: 0px; bottom: 0px; overflow: hidden; position: absolute;">
                            <ul class="dibiao_name">
                            </ul>
                    </div>
                </div>
                <div class="hotel-mask-bot">
                    <div class="hotel-mask-btn ">
                        <input id="LandMarkID" type="hidden" />
                        <input id="LandMark" type="hidden" />
                        <div class="cent">
                            <a href="javascript:void(0);" id="quyutijiao" class="y_btn">完成</a></div>
                    </div>
                </div>

        </div>
    </div>--%>
    <div class="user-mask" data-name="area" data-class="searchdiv" style="display: block;
        z-index: 100; visibility: hidden">
        <div class="hotel-mask-cnt box">
            <div class="place_box clearfix padd10">
                <div id="fdibiao" class="place_list box" style="margin-top: 135px; top:0px; bottom:0px;  left:0px; overflow: hidden; position: absolute;">
                    <ul id="AreaNameList"> 
                    </ul>
                </div>
                <div id="sdibiao" class="place_list2 box" data-class="landdibiao" style="margin-top: 135px; top:0px; bottom:0px;  left:30%; overflow: hidden; position: absolute;">
                    <ul class="dibiao_listTab">
                    </ul>
                </div>
                <div id="tdibiao" class="star_box box" data-class="dibiao" style="width: 40%; margin-top: 135px; top:0px; bottom:0px;  right:0px; overflow: hidden; position: absolute;">
                    <ul class="dibiao_name">
                    
                    </ul>
                </div>
            </div>
            <div class="hotel-mask-bot">
                <div class="hotel-mask-btn ">
                <input id="LandMarkID" type="hidden" />
                        <input id="LandMark" type="hidden" />
                    <div class="cent">
                        <a href="javascript:void(0);" id="quyutijiao" class="y_btn">完成</a></div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var myScroll;

        $("a[data-class=searchbox]").click(function() {
            if ($(this).attr("class") == "on") {
                $("a[data-class=searchbox]").removeClass("on");
                $("div[data-class=searchdiv]").css("visibility", "hidden");
            }
            else {
                $("a[data-class=searchbox]").removeClass("on");
                $("div[data-class=searchdiv]").css("visibility", "hidden");
                $(this).addClass("on");
                var divname = $(this).attr("data-name");
                $("div[data-name=" + divname + "]").css("visibility", "visible");
                if (divname == "area") {
                    PageDind.GetMarkName();
                }
            }
        });
        $("a[data-price=jiage]").click(function() {
            $("a[data-price=jiage]").removeClass("on");
            $(this).addClass("on");
            $("#StartPrice").val($(this).attr("data-start"));
            $("#EndPrice").val($(this).attr("data-end"));
        });
        //星级开始
        $("li[data-star=xingji]").click(function() {
            $("li[data-star=xingji]").find("a").removeClass("a_input_on");
            $(this).find("a").addClass("a_input_on");
            $("#StarNum").val($(this).attr("data-num"));
        });
        //星级结束
        $("#pricetijiao").click(function() {
            var url = window.location.href;
            url = url.replace(/JiaGe1=([\d]*?)&/, 'JiaGe1=' + $("#StartPrice").val() + '&');
            url = url.replace(/JiaGe2=([\d]*?)&/, 'JiaGe2=' + $("#EndPrice").val() + '&');
            window.location.href = url;
        });
        $("#startijiao").click(function() {
            var url = window.location.href;
            url = url.replace(/Star=([\d]*?)&/, 'Star=' + $("#StarNum").val() + '&');
            window.location.href = url;
        });
        $("#searchBnt").click(function() {
            if ($("#SearchName").val() != "酒店名称") {
                var url = window.location.href;
                url = url.replace(/HotelName=([\s\S]*?)&/, 'HotelName=' + $("#SearchName").val() + '&');
                window.location.href = url;
            }
        });


        //位置区域

        $("#quyutijiao").click(function() {
            if ($("#LandMarkID").val() != "") {
                var url = window.location.href;
                if (url.indexOf("LandMark") > 0) {
                    url = url.replace(/LandMark=([\s\S]*?)&/, 'LandMark=' + $("#LandMark").val() + '&');
                    url = url.replace(/LandMarkID=([\s\S]*?)&/, 'LandMarkID=' + $("#LandMarkID").val() + '&');
                }
                else {
                    url = url + "&LandMark=" + $("#LandMark").val() + "&LandMarkID=" + $("#LandMarkID").val() + "&";
                }
                window.location.href = url;
            }
            else {
                alert("请选择您需要住的地区位置！");
            }

        });

        var PageDind = {
            GetMarkName: function() {
                var CityCode = $("#CityCode").val();
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
                        var theight = 39 * response.length + 60;
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
                var CityCode = $("#CityCode").val();
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


                        var theight = 39 * response.length + 60;
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
                var CityCode = $("#CityCode").val();
                $.ajax({
                    type: "post", url: "/ashx/CityHandler.ashx?dotype=LandChildName&CityCode=" + encodeURI(CityCode) + "&AreaCode=" + encodeURI(AreaCode) + "&LandMarkName=" + encodeURI(LandMarkName), dataType: "json",
                    success: function(response) {
                        $(".dibiao_name").html("");
                        var LandName = response[0].LandMarkName;
                        for (var i = 0; i < response.length; i++) {
                            var LandMarkChildName = response[i].LandMarkChildName;
                            $(".dibiao_name").append("<li><a href=\"javascript:\" title=" + LandMarkChildName + " data-id=\"" + response[i].ID + "\" data-class=\"threemark\" class=\"a_input\"></a>" + LandMarkChildName + "</li>");
                        }
                        var theight = 39 * response.length + 60;
                        $(".dibiao_name").css("height", theight + "px");

                        document.addEventListener('DOMContentLoaded', PageDind.loaded1(), false);
                        $(".dibiao_name").find("li").bind("click", function() {
                            $("#LandMarkID").val($(this).find("a").attr("data-id"));
                            $("#LandMark").val($(this).find("a").attr("title"));
                            $(".dibiao_name li a").removeClass("a_input_on").addClass("a_input");
                            $(this).find("a").addClass("a_input_on");
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
        </script>

    <script type="text/javascript">

        var myScroll;

        function loaded1() {

            myScroll = new iScroll('starxz');
        }
        document.addEventListener('DOMContentLoaded', loaded1, false);

    </script>

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
                    if ($("#mylongitude").val() != "" && $("#mylatitude").val() != "") {
                        var url = window.location.href;
                        url = url.replace(/longitude=([\s\S]*?)&/, 'longitude=' + $("#mylongitude").val() + '&');
                        url = url.replace(/latitude=([\s\S]*?)&/, 'latitude=' + $("#mylatitude").val() + '&');
                        window.location.href = url;
                    }
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
    </script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>
</body>
</html>
