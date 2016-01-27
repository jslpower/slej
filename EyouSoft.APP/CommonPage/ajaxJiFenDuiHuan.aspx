<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxJiFenDuiHuan.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxJiFenDuiHuan" %>

<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li>兑换额度：<%# Eval("DuiHuanJinE")%></li>
                                        <li>兑换时间：<%# Eval("IssueTime")%></li>
                                        <li>剩余积分：<%# Eval("ShengYuJinE")%></li>
                                        <li>兑换状态：<%# Eval("DuiHuanStatus")%></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
