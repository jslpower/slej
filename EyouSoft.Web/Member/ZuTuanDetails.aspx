<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="ZuTuanDetails.aspx.cs" Inherits="EyouSoft.Web.Member.ZuTuanDetails" %>
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
            <h4>&gt; 报价订单详情</h4>
          <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单 > 报价订单详情</span></div>
          
    <table border="0" class="tchuang" style="width: 100%">
            <tr class="odd">
                <th height="25" align="right" width="20%" class="doti">
                    订单号：
                </th>
                <td align="left" width="30%">
                    <asp:Literal ID="OrderCode" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" width="20%" class="doti">
                    线路名称：
                </th>
                <td align="left" width="30%">
                    <asp:Literal ID="XianLuName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    出发城市：
                </th>
                <td align="left">
                    <asp:Literal ID="Chengshi" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" class="doti">
                    出发日期：
                </th>
                <td align="left">
                    <asp:Literal ID="ChufaTime" runat="server"></asp:Literal>
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    成团人数：
                </th>
                <td align="left">
                    <asp:Literal ID="RenShu" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" class="doti">
                    航班：
                </th>
                <td align="left">
                    <asp:Literal ID="HangBan" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    人均车费：
                </th>
                <td align="left">
                    <asp:Literal ID="CarMoney" runat="server"></asp:Literal>元
                </td>
                <th height="25" align="right" class="doti">
                    导游：
                </th>
                <td align="left">
                    需要<asp:Literal ID="DaoYouNum" runat="server"></asp:Literal>
                    名全陪导游，人均<asp:Literal ID="DaoYouFei" runat="server"></asp:Literal>元，<asp:Literal ID="DiPeiDaoYouNum" runat="server"></asp:Literal>
                    名地陪导游，人均<asp:Literal ID="DiPeiFei" runat="server"></asp:Literal>元
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    餐务标准：
                </th>
                <td align="left" colspan="3">
                    增加早餐<asp:Literal ID="ZaoCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="ZaoCanMoney" runat="server"></asp:Literal>元
                    <br />
                    增加午餐<asp:Literal ID="WuCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="WuCanMoney" runat="server"></asp:Literal>元
                    <br />
                    增加晚餐<asp:Literal ID="WanCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="WanCanMoney" runat="server"></asp:Literal>元
                    <br />
                    总共人均<asp:Literal ID="CanWuFei" runat="server"></asp:Literal>元
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    保险：
                </th>
                <td align="left" colspan="3">
                    <asp:Literal ID="BaoXian" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    租车：
                </th>
                <td align="left" colspan="3">
                    <table border="0" class="tchuang" style="width: 100%">
                    <thead>
                    <tr>
                    <td>起点</td><td>终点</td><td>车型</td><td>数量</td><td>公里数</td><td>价格</td>
                    </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#BDDCF4" : "" %>">
                         <td><%# Eval("QiDian")%></td><td><%# Eval("ZhongDian")%></td><td><%# GetCheName(Eval("ZucheId"))%></td><td><%# Eval("CheNum")%></td><td><%# Eval("GongLiShu")%></td><td><%# Eval("FeiYong")%></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot><tr><td colspan="6">人均<asp:Literal ID="ZuCheFei" runat="server"></asp:Literal>元</td></tr></tfoot>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    自组团增加总价：
                </th>
                <td align="left" colspan="3">
                    <asp:Literal ID="ZongMoney" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    操作人：
                </th>
                <td align="left" colspan="3">
                    <asp:Literal ID="CaoZuoRen" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right"  class="doti">
                    价格：
                </th>
                <td colspan="3" align="left">
                    成人价：<asp:Literal ID="ChengRenJia" runat="server"></asp:Literal>元
                    <br />
                    儿童价：<asp:Literal ID="ETJia" runat="server"></asp:Literal>元
                    <br />
                    总价：<asp:Literal ID="ZongJia" runat="server"></asp:Literal>
                </td>
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
