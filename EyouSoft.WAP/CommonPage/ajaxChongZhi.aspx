<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxChongZhi.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxChongZhi" %>

<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li>交易编号：<%# Eval("JiaoYiHao")%></li>
                                        <li>充值金额：¥ <i class="font22 font_yellow">
                                            <%#((decimal)Eval("JinE")).ToString("f2")%></i></li>
                                        <li>充值时间：<%# Eval("IssueTime")%></li>
                                        <li>支付方式：<%# Eval("ZhiFuFangShi")%></li>
                                        <li>充值状态：<%# Eval("ZhiFuStatus")%></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>