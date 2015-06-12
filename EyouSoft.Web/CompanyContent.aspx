<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="CompanyContent.aspx.cs" Inherits="EyouSoft.Web.CompanyContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
    <div class="n_title"><a href="Baoming.aspx" class="btn001 wd"><span>联系店主</span></a>> 关于 <span style=" font-size:20px;"><asp:Literal ID="WebSite" runat="server"></asp:Literal></span> 介绍</div>
    <div class="about_box margin_T10">
    <asp:Literal ID="CompanyJieShao" runat="server"></asp:Literal>
    </div>
    <div class="margin_T10"></div>
</asp:Content>
