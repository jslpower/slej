<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxDingDan.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxDingDan" %>

<asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="user_dindan font16 mt10">
                                <ul>
                                    <li>
                                        <%# Eval("OrderName")%></li>
                                    <li>订单号：<%# Eval("OrderCode")%></li>
                                    <li>下单日期：<%# Eval("IssueTime")%></li>
                                    <li>订单金额：¥ <i class="font22 font_yellow">
                                        <%#((decimal)Eval("JinE")).ToString("f2")%></i></li>
                                    <li>订单状态：<%# getHuiYuanState(Eval("OrderStatus"))%></li>
                                        <li>操作：
                                            <%# getZhiFuURL(Eval("OrderId").ToString(), Eval("OrderStatus"), Eval("AgencyId"), orderleibie, Eval("XDRId"))%>
                                        </li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>