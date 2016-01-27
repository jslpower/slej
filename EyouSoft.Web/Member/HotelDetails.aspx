<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="HotelDetails.aspx.cs" Inherits="EyouSoft.Web.Member.HotelDetails" %>
<%@ Register src="/UserControl/UserLeft.ascx" tagname="UserLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />
<script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>
<script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>
<script src="/Js/menu_min.js"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>
<style type="text/css">
.doti
{
background-color:#c1def0;
border: #c1def0 solid 1px;
text-align: right;
font-size: 12px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
<uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <form id="form1" runat="server">
<div class="user_right">
          <div class="title_bar">
            <h4>&gt; 线路订单详情</h4>
          <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单 > 酒店订单详情</span></div>
          
          <%= hotelhtml%>
          
          <%= youkehtml%>
          
          <%= lianxihtml%>
          <%= Jiagehtml%>
          <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
 </div>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
