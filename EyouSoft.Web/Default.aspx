<%@ Page Title="首页" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="Default.aspx.cs" Inherits="EyouSoft.Web.Defalut" %>

<%@ Register Src="~/UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TravelTools.ascx" TagName="TravelTools" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/UserLoginOrReg.ascx" TagName="UserLoginOrReg" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Links.ascx" TagName="Links" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/MainDefault.ascx" TagName="MainDefault" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/DaiLiDefault.ascx" TagName="DaiLiDefault" TagPrefix="uc1" %>
<%@ Import Namespace="EyouSoft.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <form id="form1" runat="server">
    <uc1:UserLoginOrReg runat="server" ID="UserLoginOrReg1" />
    <!------searchbox-------->
    <uc1:Search runat="server" ID="Search1" />
    <!------L_list-------->
    <div class="L_list margin_T10">
        <div class="list_T">
            <h3>
                最新公告</h3>
            <a class="more" href="/ZiXun.aspx?type=0">更多&gt;&gt;</a>
        </div>
        <ul>
            <asp:Repeater ID="rpt_GongGao" runat="server">
                <ItemTemplate>
                    <li><a href="/ZiXunDetails.aspx?id=<%# Eval("ArticleID") %>">
                        <%#Container.ItemIndex + 1%>、<%# EyouSoft.Common.Utils.GetText2(Eval("ArticleTitle").ToString(), 14, true)%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="l_img">
        <%= youad1%></div>
    <div class="l_img">
        <%=youad2 %></div>
    <div class="l_img">
        <%=youad3 %></div>
    <!------L_list-------->
    <div class="L_list margin_T10">
        <div class="list_T">
            <h3>
                旅游资讯</h3>
            <a class="more" href="/ZiXun.aspx?type=1">更多&gt;&gt;</a>
        </div>
        <ul>
            <asp:Repeater ID="rpt_Article" runat="server">
                <ItemTemplate>
                    <li><a href="/ZiXunDetails.aspx?id=<%# Eval("ArticleID") %>">
                        <%#Container.ItemIndex + 1%>、<%# EyouSoft.Common.Utils.GetText2( Eval("ArticleTitle").ToString(),14,true)%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!------tool-------->
    <uc1:TravelTools runat="server" ID="TravelTools2" />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <asp:PlaceHolder ID="MainD" runat="server">
        <uc1:MainDefault runat="server" ID="MainDefault1" />
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="DaiLi" runat="server" Visible="false">
    <uc1:DaiLiDefault runat="server" ID="DaiLiDefault1" />
    </asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
    <%--<uc1:Links runat="server" ID="Links1" />--%>
</asp:Content>
