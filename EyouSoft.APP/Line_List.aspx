<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line_List.aspx.cs" Inherits="EyouSoft.WAP.Line_List" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>
        <%=FenXiangBiaoTi %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
    <script type="text/javascript">
        //        window.onload = function() {
        //            var sxH = +document.getElementById("sxcontent").offsetHeight;
        //            document.getElementById("sxcontent").style.height = sxH + "px";
        //            var arrli = $(".areali");
        //            var liH = +arrli[0].offsetHeight;
        //            var liCount = +arrli.length;
        //            var setH = Math.floor(liH * liCount + 65);
        //            $(".line_namebox").css("heigth", setH + "px");

        //        }

        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;



        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                var para = { SearchName: $("#routeName").val(), pageindex: $("#pageindex").val(), sprice: pageOpt.serPar.spri, eprice: pageOpt.serPar.epri, days: pageOpt.serPar.days, type: pageOpt.serPar.type, cityid: pageOpt.serPar.cityid, source: pageOpt.serPar.source };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxLine_List.aspx?isGet=1&pageindex=" + $("#pageindex").val() + "&" + $.param(pageOpt.serPar),
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

        //        var shaixuan;
        //        function shaixuan() {

        //            test = new iScroll('shaixuan');
        //        }
        //        document.addEventListener('DOMContentLoaded', shaixuan, false);

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
        </style>
</head>
<body>
    <form id="form1">
    <uc1:WapHeader ID="WapHeader1" runat="server" />
    <div class="warp">
        <div class="line_xz_warp">
            <div class="line_xz">
                <ul>
                    <li><a id="re_a" href="javascript:;">线路区域<i></i></a></li><!--------点击a出现层加上样式on------层隐藏页面最底部------->
                    <li><a id="shai_a" href="javascript:;">筛&nbsp;&nbsp;&nbsp;&nbsp;选<i></i></a></li>
                </ul>
            </div>
        </div>
        <div class="jq_search" style="top: 79px;">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="text" class="input_txt floatL" value="<%=EyouSoft.Common. Utils.GetQueryStringValue("keyword")==""?"目的地或关键词": EyouSoft.Common. Utils.GetQueryStringValue("keyword")%>"
                        name="routeName" id="routeName" onfocus="javascript:if(this.value=='目的地或关键词')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='目的地或关键词';" />
                    <input name="serchBtn" id="serchBtn" type="button" class="icon_search_i floatR" />
                </div>
            </div>
        </div>
        <div class="jq_list line_list" style="padding-top: 91px;">
            <div id="wrapper">
                <div id="scroller1">
                    <div id="a1">
                        <ul id="linelist">
                            <asp:Repeater ID="rptlist" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="jq_img">
                                            <a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>">
                                                <img src="<%# getImgSrc(Eval("TeSeFilePath"),Eval("XianLuId").ToString())%>"></a>
                                            <div class="line_txt">
                                                <%# getCityName(Eval("DepCityId"))%>出发 <span class="gys_code">
                                                    <%# getSourceJP( Eval("Line_Source"))%></span>
                                            </div>
                                        </div>
                                        <dl>
                                            <dt><a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                                class="fontblue">
                                                <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></a></dt>
                                            <dd>
                                                <a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                                    class="floatR font_yellow">更多</a>团期：
                                                <%# getLastDate(Eval("Tours"))%></dd>
                                            <dd class="wid font_gray">
                                                <i class="line_x">
                                                    <%# getHYJ("门市",EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%></i></dd>
                                            <dd class="wid R">
                                                <span class="font_yellow">
                                                    <%# getHYJ("优惠", EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>
                                                </span>起
                                            </dd>
                                        </dl>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <div id="pullUp">
                            <span class="pullUpIcon"></span><span class="pullUpLabel"></span>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <div class="user-mask shai_a" style="display: block; z-index: 100; visibility: hidden">
        <div class="line-mask-cnt" id="shaixuan" style="padding-top: 0px; margin-top display: block;
            top: 0px; bottom: 0px; position: absolute;">
            <div class="padd clearfix" id="sxcontent">
                <h3 class="font_gray paddB">
                    价格范围</h3>
                <div class="price_box paddB gray_lineB">
                    <a class="select_pri" data-spri="" data-epri="" href="javascript:;">不限</a> <a class="select_pri"
                        data-spri="100" data-epri="300" href="javascript:;">100~300元</a> <a class="select_pri"
                            data-spri="300" data-epri="1000" href="javascript:;">300~1000元</a> <a class="select_pri"
                                data-spri="1000" data-epri="3000" href="javascript:;">1000~3000元</a>
                    <a class="select_pri" data-spri="3000" data-epri="10000" href="javascript:;">3000~10000元</a>
                    <a class="select_pri" data-spri="10000" data-epri="" href="javascript:;">10000元以上</a>
                </div>
                <h3 class="font_gray paddB mt10">
                    天数</h3>
                <div class="price_box paddB gray_lineB">
                    <a class="select_a" data-day="" href="javascript:;">全部</a> <a class="select_a" data-day="4"
                        href="javascript:;">4日游</a> <a class="select_a" data-day="5" href="javascript:;">5日游</a>
                    <a class="select_a" data-day="6" href="javascript:;">6日游</a> <a class="select_a"
                        data-day="7" href="javascript:;">7日游</a> <a class="select_a" data-day="8" href="javascript:;">
                            7日游及以上</a>
                </div>
                <h3 class="font_gray paddB mt10">
                    出发地</h3>
                <div class="place_box paddB gray_lineB">
                    <a class="city_a " data-cityid="" href="javascript:;">不限</a>
                    <asp:Literal ID="ltrChuFas" runat="server"></asp:Literal>
                </div>
                <h3 class="font_gray paddB mt10">
                    渠道代码<span class="font_red paddL">(方便旅游同行选择)</span></h3>
                <div class="place_box paddB gray_lineB">
                    <a data-source="" class="source_a" href="javascript:;">不限</a> <a data-source="0"
                        class="source_a" href="javascript:;">JA</a> <a data-source="1" class="source_a" href="javascript:;">
                            BK</a> <a data-source="3" class="source_a" href="javascript:;">SZL</a> <a data-source="4"
                                class="source_a" href="javascript:;">GD</a> <a data-source="5" class="source_a" href="javascript:;">
                                    LYQ</a>
                </div>
                <div class="cent mt10 clearfix">
                    <a id="search_a" href="javascript:;" class="y_btn">完成</a></div>
            </div>
        </div>
    </div>
    <!---热门专线--->
    <div class="user-mask re_a" style="display: block; z-index: 100; visibility: hidden">
        <div id="remenfenlei" class="line-mask-cnt" style="display: block; top: 0px; bottom: 0px;
            position: absolute;">
            <div class="line_namebox" style="height: 260px;">
                <ul>
                    <asp:Literal ID="litFenlei" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
        <div style="display: block; height: 1px;">
        </div>
    </div>
    <input id="pageindex" type="hidden" value="1" />

    <script type="text/javascript">
        var pageOpt = {
            serPar: { spri: '<%=EyouSoft.Common. Utils.GetQueryStringValue("sprice") %>'
                           , epri: '<%=EyouSoft.Common. Utils.GetQueryStringValue("eprice") %>'
                           , days: '<%=EyouSoft.Common. Utils.GetQueryStringValue("days") %>'
                           , area: '<%=EyouSoft.Common. Utils.GetQueryStringValue("area") %>'
                           , keyword: '<%=EyouSoft.Common. Utils.GetQueryStringValue("keyword") %>'
                           , type: '<%=EyouSoft.Common. Utils.GetQueryStringValue("type") %>'
                           , cityid: '<%=EyouSoft.Common. Utils.GetQueryStringValue("cityid") %>'
                           , source: '<%=EyouSoft.Common. Utils.GetQueryStringValue("source") %>'
            },
            loaded1: function() {
                myScroll = new iScroll('remenfenlei', { mouseWheel: true, click: true, checkDOMChanges: true, hScrollbar: false, vScrollbar: false });
            },
            loaded2: function() {
                myScroll = new iScroll('shaixuan', { mouseWheel: true, click: true, checkDOMChanges: true, hScrollbar: false, vScrollbar: false });
            },
            initOpt: function(objClass) {
                $(objClass).click(function() {
                    $(objClass).removeClass("on");
                    if ($(this).attr("class") == "select_a") {
                        pageOpt.serPar.days = $(this).attr("data-day");
                    } else if ($(this).attr("class") == "select_pri") {
                        pageOpt.serPar.spri = $(this).attr("data-spri");
                        pageOpt.serPar.epri = $(this).attr("data-epri");
                    } else if ($(this).attr("class") == "city_a") {
                        pageOpt.serPar.cityid = $(this).attr("data-cityid");
                    }
                    else if ($(this).attr("class") == "source_a") {
                        pageOpt.serPar.source = $(this).attr("data-source");
                    }
                    $(this).addClass("on");
                });
            }
        }
        $(function() {
            pageOpt.initOpt(".select_a");
            pageOpt.initOpt(".select_pri");
            pageOpt.initOpt(".city_a");
            pageOpt.initOpt(".source_a");
            $("#re_a").click(function() {
                var arrli = $(".areali");
                var liH = +arrli[0].offsetHeight;
                var liCount = +arrli.length;
                var setH = Math.floor(liH * liCount + 65);
                $(".line_namebox").css("height", setH + "px");
                document.addEventListener('DOMContentLoaded', pageOpt.loaded1(), false);


                $("#shai_a").removeClass("on");
                $(".shai_a").css("visibility", "hidden");
                if ($(this).attr("class") == "on") {
                    $(".re_a").css("visibility", "hidden");
                    $(this).removeClass("on");
                } else {
                    $(this).addClass("on");
                    $(".re_a").css("visibility", "");
                }

            })
            $("#shai_a").click(function() {
                var sxH = +document.getElementById("sxcontent").offsetHeight;
                var sHei = Math.floor(sxH + 65);
                $("#.sxcontent").css("height", sHei + "px");
                document.addEventListener('DOMContentLoaded', pageOpt.loaded2(), false);

                $("#re_a").removeClass("on");
                $(".re_a").css("visibility", "hidden");
                if ($(this).attr("class") == "on") {
                    $(".user-mask").css("visibility", "hidden");
                    $(this).removeClass("on");
                } else {
                    $(".shai_a").css("visibility", "");
                    $(this).addClass("on")
                }
            })
            $(".areali").click(function() {
                window.location.href = "/Line_List.aspx?" + $.param({ sprice: pageOpt.serPar.spri, eprice: pageOpt.serPar.epri, days: pageOpt.serPar.days, type: pageOpt.serPar.type, cityid: pageOpt.serPar.cityid, source: pageOpt.serPar.source, keyword: pageOpt.serPar.keyword, area: $(this).attr("id") });
            })
            $("#serchBtn").click(function() {
                window.location.href = "/Line_List.aspx?" + $.param({ sprice: pageOpt.serPar.spri, eprice: pageOpt.serPar.epri, days: pageOpt.serPar.days, type: pageOpt.serPar.type, cityid: pageOpt.serPar.cityid, source: pageOpt.serPar.source, area: pageOpt.serPar.area, keyword: $("#routeName").val() });
            })
            $("#search_a").click(function() {
                window.location.href = "/Line_List.aspx?" + $.param({ sprice: pageOpt.serPar.spri, eprice: pageOpt.serPar.epri, days: pageOpt.serPar.days, type: pageOpt.serPar.type, cityid: pageOpt.serPar.cityid, source: pageOpt.serPar.source, area: pageOpt.serPar.area, keyword: pageOpt.serPar.keyword });
            })
        })
    </script>

   

    </form>
</body>
</html>
