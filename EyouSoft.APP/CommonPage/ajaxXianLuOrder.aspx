<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxXianLuOrder.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxXianLuOrder" %>

<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li class="orderurl" data-orderid="<%# Eval("OrderId")%>" >
                                            <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("XianLuName").ToString())%></li>
                                        <li>订单号：<%# Eval("OrderCode")%></li>
                                        <li>下单日期：<%# Eval("IssueTime")%></li>
                                        <li>订单金额：¥ <i class="font22 font_yellow">
                                            <%#((decimal)Eval("JinE")).ToString("f2")%></i></li>
                                        <li>订单状态：<%# getHuiYuanState(Eval("Status"))%></li>   
                                        <li>操作：<%#getZhiFuURL(Eval("OrderId").ToString(), Eval("Status"), Eval("AgencyId"), ordertype, Eval("AgencyId"))%></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
