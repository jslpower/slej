<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxFanLi.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxFanLi" %>

<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li>交易编号：<%# Eval("FanLiJiaoYiHao")%></li>
                                        <li>充值金额：¥ <i class="font22 font_yellow">
                                            <%#((decimal)Eval("FanLiJinE")).ToString("f2")%></i></li>
                                        <li>剩余金额：¥ <i class="font22 font_yellow">
                                            <%#((decimal)Eval("HuiYuanYuE")).ToString("f2")%></i></li>
                                        <li>充值时间：<%# Eval("IssueTime")%></li>
                                        <li>充值状态：交易成功</li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
