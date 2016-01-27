<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxTiXian.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxTiXian" %>

<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li>交易编号：<%# Eval("TransactionID")%></li>
                                        <li>提现金额：¥ <i class="font22 font_yellow">
                                            <%# Eval("JinE","{0:f2}")%></i></li>
                                        <li>提现时间：<%# Eval("TiXianTime")%></li>
                                        <li>提现状态：<%# Eval("TiXianStatus")%></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>