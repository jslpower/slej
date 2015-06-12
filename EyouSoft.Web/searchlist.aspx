<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="searchlist.aspx.cs" Inherits="EyouSoft.Web.searchlist" %>

<%@ Register Src="~/UserControl/Search.ascx" TagName="Search" TagPrefix="uc2" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TravelTools.ascx" TagName="TravelTools" TagPrefix="uc3" %>
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
    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->

    <script type="text/javascript" src="/js/ajaxpagecontrols.js"></script>

    <script type="text/javascript" src="/js/bt.min.js"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <!--paopao end-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <div class="leftbox">
        <!------searchbox-------->
        <uc2:Search ID="Search1" runat="server" />
        <!------L_side01-------->
        <div class="L_side01 margin_T10">
            <!------促销-------->
            <uc1:TuanGou runat="server" ID="TuanGou1" />
        </div>
        <!------tool-------->
        <uc3:TravelTools ID="TravelTools1" runat="server" />
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
        <div class="tablebox margin_T10">
            <div class="table_bar">
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
                        <th width="40">
                            天数
                        </th>
                        <th width="130">
                            最近发班
                        </th>
                        <th width="97" align="center">
                            门市价<span class="nojiacu font12">（元/人）</span>
                        </th>
                        <th width="97" align="center">
                            会员价<span class="nojiacu font12">（元/人）</span>
                        </th>
                        <th width="70">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rptlist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# getCityName(Eval("DepCityId"))%>
                                </td>
                                <td align="center">
                                    <%# getSourceJP(Eval("Line_Source"))%>
                                </td>
                                <td align="left">
                                    <a href="/XianLuYuDing.aspx?id=<%# Eval("XianLuId") %>&type=<%# (int)(Eval("LineType"))==0 ?"1" : (int)(Eval("LineType"))==1?"3":"2" %>"
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
                                    <%# getHYJ("会员", EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>起
                                </td>
                                <td align="center">
                                    <a href="/XianLuYuDing.aspx?id=<%# Eval("XianLuId") %>&type=<%# (int)(Eval("LineType"))==0 ?"1" : (int)(Eval("LineType"))==1?"3":"2" %>"
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
            initCss: function() {
                $(".jg[pid=" + $("#sprice").val() + "]").attr("class", "on");
                $(".ts[did=" + $("#days").val() + "]").attr("class", "on");
            },
            serch: function() {
                var data = {
                    sprice: $("#sprice").val(),
                    eprice: $("#eprice").val(),
                    days: $("#days").val(),
                    keyword: $("#keyword").val(),
                    stime: $("#stime").val(),
                    etime: $("#etime").val()
                }
                window.location.href = "/XianLu.aspx?" + $.param(data);
            }
        }

        $(function() {
            pageData.initCss();
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
            $("#Fpage").html($("#page").html());
            $("#searchBtn").click(function() {
                pageData.serch();
            })
        });
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
