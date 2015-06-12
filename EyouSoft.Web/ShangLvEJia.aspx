<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="ShangLvEJia.aspx.cs" Inherits="EyouSoft.Web.ShangLvEJia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .page
        {
            padding-top: 5px;
            padding-right: 5px;
            margin: 0;
        }
    </style>

    <script type="text/javascript">
        $(function() {
            $('#newsSlider').loopedSlider({
                autoStart: 3000
            });
            $('.validate_Slider').loopedSlider({
                autoStart: 3000
            });
        });
    </script>

    <script type="text/javascript" src="/js/ajaxpagecontrols.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox fixed">
        <div class="leftbox m_left">
            <!------分类-------->
            <div class="mall2_type">
                <h2>
                    全部商品分类</h2>
                <div class="mall2_menu">
                    <ul>
                        <asp:Repeater ID="rptmenus" runat="server">
                            <ItemTemplate>
                                <li><a href="/ShangLvEJia.aspx?lid=<%# Eval("LeiBieID") %>">
                                    <%# Eval("LeiBieMingCheng")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="rightbox m_right">
            <!------n_banner-------->
            <div class="banner" id="newsSlider">
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
            <!------mall-search-------->
            <div class="mall2-search margin_T10">
                <div class="mall2-01 fixed">
                    <h2>
                        商家导航</h2>
                    <div class="s_bar">
                        <form id="searchFrom">
                        <input type="text" name="key" class="search_input" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("key") %>" />
                        <input type="submit" class="search_btn" value="" />
                        </form>
                    </div>
                    <h4>
                    </h4>
                </div>
                <div class="mall2-02">
                    <%--   <a href="#" class="on">会员供销商城</a> <a href="#">购物广场联盟</a> <a href="#">休闲娱乐会所</a>
                    <a href="#">天下商旅e家</a>--%>
                </div>
            </div>
            <div class="mall2_list margin_T10">
                <ul>
                    <asp:Repeater ID="rptlist" runat="server">
                        <ItemTemplate>
                            <li><a target="_blank" href="<%# Eval("SiteUrl")%>">
                                <img title="<%# Eval("SiteName")%>" src="<%# Eval("ImgFile") == "" ? "/images/none_img.jpg" : Eval("ImgFile")%>" /></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div id="page" class="page">
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var pagingConfig = { pageSize: 10, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        })
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
