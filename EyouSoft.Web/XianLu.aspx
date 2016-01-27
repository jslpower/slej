<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="XianLu.aspx.cs" Inherits="EyouSoft.Web.XianLu" %>

<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TravelTools.ascx" TagName="TravelTools" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .page
        {
            padding-top: 5px;
            padding-right: 5px;
            margin: 0;
        }
        .hline
        {
            text-decoration: line-through;
        }
    </style>

    <script src="/JS/_tourDatePP.js" type="text/javascript"></script>

    <script type="text/javascript">
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

        $(function() {
            $('#newsSlider').loopedSlider({
                autoStart: 3000
            });
            $('.validate_Slider').loopedSlider({
                autoStart: 3000
            });
        });
    </script>

    <!--left_focus-->

    <script src="/js/left_focus.js" type="text/javascript"></script>

    <!--left_focus-->
    <!--paopao star-->
    <!--[if IE]><script src="js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->

    <script type="text/javascript" src="/js/ajaxpagecontrols.js"></script>

    <script type="text/javascript" src="/js/bt.min.js"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <!--paopao end-->
    <!--paopao start-->
    <%--<script type="text/javascript">
        $(function() {
            $('.fanban_date').bt({
                contentSelector: function() { return "<div>正在加载操作备注</div>" },
                positions: ['bottom'],
                fill: '#fff5c4',
                strokeStyle: '#ff9913',
                noShadowOpts: { strokeStyle: "#ff9913" },
                spikeLength: 10,
                spikeGirth: 15,
                width: 560,
                overlap: 0,
                centerPointY: 1,
                cornerRadius: 4,
                shadow: true,
                shadowColor: 'rgba(0,0,0,.5)',
                cssStyles: { color: '#666666', 'line-height': '180%' },
                ajaxCache: false,
                ajaxPath: function() { return "/CommonPage/XianLuRiLi.aspx?tourid=" + $(this).attr("data-xianlu") }
            });
        })
    </script>--%>
    <!--paopao end-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <div class="leftbox">
        <!------searchbox-------->
        <uc1:Search runat="server" ID="search1" />
        <!------L_side01-------->
        <div class="L_side01 margin_T10">
            <uc1:TuanGou runat="server" ID="TuanGou1" />
        </div>
        <!------tool-------->
        <uc1:TravelTools ID="Traveltools1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="rightbox">
        <!------n_banner-------->
        <div class="banner n_banner" id="newsSlider">
            <div class="piclist">
                <ul class="slides">
                    <%= toplist%>
                </ul>
                <div class="validate_Slider">
                </div>
                <ul class="pagination">
                    <%= dianlist%>
                </ul>
            </div>
        </div>
        <div class="line_fenlei margin_T10">
            <div class="line_type">
                <ul>
                    <asp:Literal ID="litFenlei" runat="server"></asp:Literal>
                </ul>
                <div class="clear">
                </div>
            </div>
            <ul class="line_nav">
                <li><span>价 格：</span>
                    <p>
                        <a class="jg" class="jg" pid="" data-sp="" data-ep="" href="javascript:; ">全部</a>
                        <a class="jg" class="jg" pid="0" data-sp="0" data-ep="100" href="javascript:; ">100元以下</a>
                        <a class="jg" pid="100" data-sp="100" data-ep="300" href="javascript:; ">100-300元</a>
                        <a class="jg" pid="300" data-sp="300" data-ep="1000" href="javascript:; ">300-1000元</a>
                        <a class="jg" pid="1000" data-sp="1000" data-ep="3000" href="javascript:;">1000-3000元</a>
                        <a class="jg" pid="3000" data-sp="3000" data-ep="10000" href="javascript:;">3000-10000元</a>
                        <a class="jg" pid="10000" data-sp="10000" data-ep="" href="javascript:;">10000元以上</a>
                        <input type="hidden" id="sprice" name="sprice" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("sprice") %>" />
                        <input type="hidden" id="eprice" name="eprice" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("eprice") %>" />
                    </p>
                </li>
                <li><span>天 数：</span>
                    <p>
                        <a class="ts" did="" href="javascript:;">全部</a> <a class="ts" did="1" href="javascript:;">
                            1日游</a> <a class="ts" did="2" href="javascript:;">2日游</a> <a class="ts" did="3" href="javascript:;">
                                3日游</a> <a class="ts" did="4" href="javascript:;">4日游</a> <a class="ts" did="5" href="javascript:;">
                                    5日游</a> <a class="ts" did="6" href="javascript:;">6日游</a> <a class="ts" did="7" href="javascript:;">
                                        7日游</a> <a class="ts" did="9" href="javascript:;">7日游及以上</a>
                        <input type="hidden" id="days" name="days" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("days") %>" />
                    </p>
                </li>
                <li><span>出发地：</span>
                    <p>
                        <a class="city_a " data-cityid="" href="javascript:;">不限</a>
                        <asp:Literal ID="ltrChuFas" runat="server"></asp:Literal>
                    </p>
                </li>
                <li><span>渠道代码：</span>
                    <p>
                        <a data-source="" class="source_a" href="javascript:;">不限</a> <a data-source="0"
                            class="source_a" href="javascript:;">JA</a> <a data-source="1" class="source_a" href="javascript:;">
                                BK</a> <a data-source="3" class="source_a" href="javascript:;">SZL</a> <a data-source="4"
                                    class="source_a" href="javascript:;">GD</a> <a data-source="5" class="source_a" href="javascript:;">
                                        LYQ</a>
                    </p>
                </li>
            </ul>
            <div class="line-search">
                关键字：
                <input type="text" id="words" name="words" class="input-style" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("keyword") %>"
                    style="width: 304px; margin-right: 28px;" />
                出发日期从
                <input type="text" id="stime" name="stime" class="formsize100 input-style" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("stime") %>"
                    onfocus="WdatePicker();" />
                到
                <input type="text" id="etime" name="etime" class="formsize100 input-style" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("etime") %>"
                    onfocus="javascript:WdatePicker();" />
                <input id="searchBtn" type="button" value="搜索>>" class="line-s-btn" />
            </div>
        </div>
        <div class="tablebox margin_T10">
            <div class="table_bar">
                <h3>
                    最新<%=(EyouSoft.Model.Enum.AreaType)EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("type"), 1)%>线路</h3>
                <div id="page" class="page">
                </div>
            </div>
            <div class="table_bk">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="60">
                            出发
                        </th>
                        <th width="40">
                            来源
                        </th>
                        <th>
                            线路
                        </th>
                        <th width="35">
                            天数
                        </th>
                        <th width="130">
                            最近发班
                        </th>
                        <th width="97" align="center">
                            门市价<span class="nojiacu font12">（元/人）</span>
                        </th>
                        <th width="97" align="center">
                            优惠价<span class="nojiacu font12">（元/人）</span>
                        </th>
                        <th width="65">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rptlist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center" class="nojiacu">
                                    <%# getCityName(Eval("DepCityId"))%>
                                </td>
                                <td align="center" class="nojiacu">
                                    <%# getSourceJP(Eval("Line_Source"))%>
                                </td>
                                <td align="left" class="nojiacu">
                                    <a href="/XianLuYuDing.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                        class="fontblue">
                                        <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></a>
                                </td>
                                <td align="center">
                                    <%# Eval("TianShu","{0:0}")%>
                                </td>
                                <td align="center" class="nojiacu font12">
                                    <%# getLastDate(Eval("Tours"))%>
                                </td>
                                <td align="center" class="fontblue hline">
                                    <%# getHYJ("门市",EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>起
                                </td>
                                <td align="center" class="font_yellow">
                                    <%# getHYJ("优惠", EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>起
                                </td>
                                <td align="center">
                                    <a href="/XianLuYuDing.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                        class="yudin_btn"><span>查看</span></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="table_bar table_bot">
                <div id="Fpage" class="page">
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        pagingConfig = { pageSize: 10, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        var pageData = {
            serPar: { sprice: '<%=EyouSoft.Common. Utils.GetQueryStringValue("sprice") %>'
                   , eprice: '<%=EyouSoft.Common. Utils.GetQueryStringValue("sprice") %>'
                           , days: '<%=EyouSoft.Common. Utils.GetQueryStringValue("days") %>'
                           , area: '<%=EyouSoft.Common. Utils.GetQueryStringValue("area") %>'
                           , keyword: '<%=EyouSoft.Common. Utils.GetQueryStringValue("keyword") %>'
                           , type: '<%=EyouSoft.Common. Utils.GetQueryStringValue("type") %>'
                           , cityid: '<%=EyouSoft.Common. Utils.GetQueryStringValue("cityid") %>'
                           , source: '<%=EyouSoft.Common. Utils.GetQueryStringValue("source") %>'


            },
            initCss: function() {
                if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>' == '1' || '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>' == '2') {
                    $(".ts[did=1]").remove();
                    $(".ts[did=2]").remove();
                    $(".ts[did=3]").remove();
                    $(".jg[pid=0]").remove();

                }
                if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>' == '3') {
                    $(".ts[did=5]").remove();
                    $(".ts[did=6]").remove();
                    $(".ts[did=7]").remove();
                    $(".ts[did=9]").remove();
                    $(".jg[pid=3000]").remove();
                    $(".jg[pid=10000]").remove();

                }
                $(".jg[pid=" + pageData.serPar.sprice + "]").attr("class", "on");
                $(".ts[did=" + pageData.serPar.days + "]").attr("class", "on");
                $(".city_a[data-cityid=" + pageData.serPar.cityid + "]").attr("class", "on");
                $(".source_a[data-source=" + pageData.serPar.source + "]").attr("class", "on");
            },
            createUrl: function(url, params) {
                var isHaveParam = false;
                var isHaveQuestionMark = false;
                var questionMark = "?";
                var questionMarkIndex = url.indexOf(questionMark);
                var urlLength = url.length;

                if (questionMarkIndex == urlLength - 1) {
                    isHaveQuestionMark = true;
                } else if (questionMarkIndex != -1) {
                    isHaveParam = true;
                }

                if (isHaveParam == true) {
                    for (var key in params) {
                        url = url + "&" + key + "=" + params[key];
                    }
                } else {
                    if (isHaveQuestionMark == false) {
                        url += questionMark;
                    }
                    for (var key in params) {
                        url = url + key + "=" + params[key] + "&";
                    }
                    url = url.substr(0, url.length - 1);
                }

                return url;
            },
            getUrlParms: function(removeParms) {
                var argsArr = new Object();
                var query = window.location.search;
                query = query.substring(1);
                var pairs = query.split("&");

                for (var i = 0; i < pairs.length; i++) {
                    var sign = pairs[i].indexOf("=");
                    if (sign == -1) {
                        continue;
                    }

                    var aKey = pairs[i].substring(0, sign);
                    var aValue = pairs[i].substring(sign + 1);

                    //移除不需要要的键
                    var isRemove = false
                    for (var j = 0; j < removeParms.length; j++) {
                        if (aKey.toLowerCase() == removeParms[j].toLowerCase()) {
                            isRemove = true;
                            break;
                        }
                    }

                    if (isRemove) {
                        continue;
                    }

                    argsArr[aKey] = aValue;
                }

                return argsArr;
            },
            initOpt: function(objClass) {
                $(objClass).click(function() {
                    if ($(this).attr("class") == "ts") {
                        pageData.serPar.days = $(this).attr("did");
                    } else if ($(this).attr("class") == "jg") {
                        pageData.serPar.sprice = $(this).attr("data-sp");
                        pageData.serPar.eprice = $(this).attr("data-ep");
                    } else if ($(this).attr("class") == "city_a") {
                        pageData.serPar.cityid = $(this).attr("data-cityid");
                    }
                    else if ($(this).attr("class") == "source_a") {
                        pageData.serPar.source = $(this).attr("data-source");
                    }
                    window.location.href = "/XianLu.aspx?" + $.param(pageData.serPar);
                });
            }
        }

        $(function() {
            pageData.initOpt(".city_a");
            pageData.initOpt(".source_a");
            pageData.initOpt(".ts");
            pageData.initOpt(".jg");

            tourdate.init();
            pageData.initCss();
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
            $("#Fpage").html($("#page").html());
            $("#searchBtn").click(function() {
                pageData.serPar.keyword = $("#words").val();
                pageData.serPar.stime = $("#stime").val();
                pageData.serPar.etime = $("#etime").val();
                window.location.href = "/XianLu.aspx?" + $.param(pageData.serPar);
            })
        });
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
