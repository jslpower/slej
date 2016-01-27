<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxGongGao.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxGongGao" %>

<asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li><a href="GongGaoXX.aspx?id=<%# Eval("ArticleID") %>">
                            <%# Eval("ArticleTitle")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
