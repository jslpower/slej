<%@ Page Title="景区订单详情查看" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="ScenicDetails.aspx.cs" Inherits="EyouSoft.Web.Member.ScenicDetails" %>
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
            <h4>&gt; 景区订单详情</h4>
          <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单 > 景区订单详情</span></div>
    <div style="padding-top:20px; font-weight:bolder;">订单信息</div>
          <table width="100%" border="0" class="tableList margin_T10">
            <tr>
              <td class="doti">订单确认号：</td><td>
                  <asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal></td>
              <td class="doti">景点名称：</td><td><asp:Literal ID="ltrJingQuName" runat="server"></asp:Literal></td>
              <td class="doti">数量：</td><td><asp:Literal ID="ltrShuLiang" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td class="doti">总金额：</td><td>￥<asp:Literal ID="litJinE" runat="server"></asp:Literal></td>
              <td class="doti">支付状态：</td><td><asp:Literal ID="PayState" runat="server"></asp:Literal></td>
              <td class="doti">订单状态：</td><td><asp:Literal ID="orderstatus" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td class="doti">出游时间：</td><td><asp:Literal ID="litLDate" runat="server"></asp:Literal></td>
              <td class="doti">下单时间：</td><td>
              <asp:Literal ID="litInTime" runat="server"></asp:Literal></td>
              <td class="doti"></td><td></td>
            </tr>
            <tr>
            <td class="doti">备注：</td><td colspan="5"><asp:Literal ID="txtBeiZhu" runat="server"></asp:Literal></td>
            </tr>
          </table>
          <div style="padding-top:20px; font-weight:bolder;">取票人信息</div>
          <table width="100%" border="0" class="tableList margin_T10">
            <tr>
              <td class="doti" style="width:16%">取票人姓名：</td><td style="width:34%"><asp:Literal ID="txtContact" runat="server"></asp:Literal></td>
              <td class="doti" style="width:16%">取票人手机：</td><td style="width:34%"><asp:Literal ID="txtContactTel" runat="server"></asp:Literal></td>
            </tr>
          </table>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
          <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
 </div>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>

