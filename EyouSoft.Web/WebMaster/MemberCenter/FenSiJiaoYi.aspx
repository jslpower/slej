<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenSiJiaoYi.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MemberCenter.FenSiJiaoYi"
    MasterPageFile="~/WebMaster/default.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist" style="margin: 0px auto; margin-top: 10px;">
        <div style="width:100%; height:30px; text-align:left; font-size:24px;">会员[<%=HuiYuanXinXi%>]的粉丝交易信息</div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tr>
                <th style="width: 50px; height:30px;">
                    序号
                </th>
                <th style="width: 80px;">
                    订单类型
                </th>
                <th>
                    产品名称
                </th>
                <th style="width: 80px;">
                    交易时间
                </th>
                <th style="width: 80px; text-align: right;">
                    交易金额
                </th>
                <th style="width: 80px; text-align: right;">
                    佣金
                </th>
                <th style="width: 80px;">
                    操作人
                </th>
                <th style="width: 80px;">
                    客人信息
                </th>
                <th style="width: 100px;">
                    订单状态
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                        <td align="center" style="height: 30px;">
                            <%# Container.ItemIndex + 1+( this.PageIndex - 1) * this.PageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("DingDanLeiXing") %>
                        </td>
                        <td align="left" title="<%#EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()) %>">
                            <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()), 50, true)%>
                        </td>
                        <td align="center">
                            <%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %>
                        </td>
                        <td align="right">
                            <font class="fontred">
                                <%#Eval("DingDanJinE","{0:F2}") %></font>
                        </td>
                        <td align="right">
                            <font class="fontgreen">
                                <%#Eval("YongJinJinE", "{0:F2}")%></font>
                        </td>
                        <td align="center">
                            <%#Eval("XiaDanRenName") %>
                        </td>
                        <td align="center">
                            <%#Eval("KeRenName") %>
                        </td>
                        <td align="center">
                            <%#GetDingDanStatus(Eval("DingDanStatus"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr class="even">
                    <td colspan="10">
                        暂无粉丝交易信息
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="320" border="0" align="center">
            <tr>
                <td height="40" align="center" class="tjbtn02" style="padding-left: 25%;">
                    <a href="javascript:history.go(-1);">返回</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
