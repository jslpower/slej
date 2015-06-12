<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="ZuCheDetails.aspx.cs" Inherits="EyouSoft.Web.Member.ZuCheDetails" %>
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
            <h4>&gt; 租车订单详情</h4>
          <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单 > 租车订单详情</span></div>
        <table border="0" class="tchuang" style="width: 100%">
            <tr class="odd">
                <th height="25" align="right" width="20%" class="doti">
                    订单号：
                </th>
                <td align="left" width="30%">
                    <asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" width="20%" class="doti">
                    租车方式：
                </th>
                <td align="left" width="30%">
                    <asp:Literal ID="ZuCheType" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    汽车名称：
                </th>
                <td align="left">
                    <asp:Literal ID="ltrCarName" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" class="doti">
                    租车数辆：
                </th>
                <td align="left">
                    <asp:Literal ID="ltrNumber" runat="server"></asp:Literal>
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    出发时间：
                </th>
                <td align="left">
                    <asp:Literal ID="litLDate" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" class="doti">
                    回归时间：
                </th>
                <td align="left">
                    <asp:Literal ID="ltrEDate" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    租车天数：
                </th>
                <td align="left">
                    <asp:Literal ID="ltrTianShu" runat="server"></asp:Literal>天
                </td>
                <th height="25" align="right" class="doti">
                    公里数：
                </th>
                <td align="left">
                    <asp:Literal ID="ltrGongLiShu" runat="server"></asp:Literal>
                    公里
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    乘车联系人：
                </th>
                <td align="left">
                    <asp:Literal ID="txtContact" runat="server"></asp:Literal>
                </td>
                <th align="right" class="doti">
                    乘车联系人手机：
                </th>
                <td align="left">
                    <asp:Literal ID="txtContactTel" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    下单人：
                </th>
                <td align="left">
                    <asp:Literal ID="txtYContact" runat="server"></asp:Literal>
                </td>
                <th align="right" class="doti">
                    下单人手机：
                </th>
                <td align="left">
                    <asp:Literal ID="txtYContactTel" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    下单时间：
                </th>
                <td align="left">
                    <asp:Literal ID="litInTime" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" class="doti">
                    合计金额：
                </th>
                <td align="left">
                    <asp:Literal ID="litJinE" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    租车行程：
                </th>
                <td colspan="3" align="left">
                    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tbl_Customer_AutoAdd">
                        <tbody>
                            <tr class="odd">
                                <%--<th align="center" width="50" height="30">
                                    日期
                                </th>--%>
                                <th align="center">
                                    起始地
                                </th>
                                <th align="center">
                                    目的地
                                </th>
                                <th align="center">
                                    车程
                                </th>
                            </tr>
                            <asp:Repeater runat="server" ID="rptlist">
                                <ItemTemplate>
                                    <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#E3F1FC" : "#BDDCF4" %>">
                                        <%--<td height="50" align="center">
                                            <b>
                                               第 <%#Container.ItemIndex+1 %> 天
                                            </b>
                                        </td>--%>
                                        <td align="center">
                                            <%#Eval("LPlace")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("EPlace")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("GongLiShu")%> 公里
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    订单状态：
                </th>
                <td align="left">
                    <asp:Literal ID="orderstatus" runat="server"></asp:Literal>
                    <%--<select class="inputselect select" id="orderstatus" name="orderstatus">
                        <%=StrOrderStatus %>
                    </select>--%>
                </td>
                <th align="right" class="doti">
                    付款状态：
                </th>
                <td align="left">
                    <asp:Literal ID="PayState" runat="server"></asp:Literal>
                    <%--<select class="inputselect select" id="sel_PayState" name="sel_PayState">
                        <%=StrPayState%>
                    </select>--%>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right" class="doti">
                    备注：
                </th>
                <td colspan="3" align="left">
                    <asp:Literal ID="txtBeiZhu" runat="server"></asp:Literal>
                    <%--<textarea name="txtBeiZhu" id="txtBeiZhu" cols="65" rows="5" runat="server"></textarea>--%>
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
