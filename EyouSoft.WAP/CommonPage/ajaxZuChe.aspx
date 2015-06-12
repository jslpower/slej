<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxZuChe.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxZuChe" %>
<asp:Repeater ID="rpt_ZuChe" runat="server">
                                <ItemTemplate>
                                    <li><a href="/Car.aspx?id=<%# Eval("ZuCheID") %>">
                                        <div class="img_box">
                                            <%#IMGhtml(Eval("ZucheInfoImg"), Eval("CarName"))%></div>
                                        <div class="txt_box">
                                            <%# Eval("CarName")%></div>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>