<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxFenXiang.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxFenXiang" %>

<asp:repeater id="rptlist" runat="server">
                    <ItemTemplate>
                        <li><a href="EJiaFenXiangInfo.aspx?id=<%#Eval("YouJiid") %>">
                            <%# EyouSoft.Common.Utils.GetText(Eval("YouJiTitle").ToString(), 15, true)%></a><span
                                class="date"><%#Eval("issuetime","{0:yyyy-MM-dd}") %></span></li>
                    </ItemTemplate>
                </asp:repeater>
