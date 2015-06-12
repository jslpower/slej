<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxJiaoYi.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxJiaoYi" %>

<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li>交易编号：<%# Eval("JiaoYiHao")%></li>
                                        <li>交易金额：¥ <i class="font22 font_yellow">
                                            <%#GetJinECaoZuoFu(Eval("ZhiFuFangSHi"),Eval("JiaoYiLeiBie")) %><%#Eval("JiaoYiJinE","{0:F2}") %></i></li>
                                        <li>交易时间：<%#Eval("JiaoYiShiJian","{0:yyyy-MM-dd}")%></li>
                                        <li>交易类别：<%# Eval("JiaoYiLeiBie")%></li>
                                        <li>交易方式：<%# Eval("ZhiFuFangShi")%></li>
                                        <li>交易状态：<%# Eval("JiaoYiStatus")%></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
