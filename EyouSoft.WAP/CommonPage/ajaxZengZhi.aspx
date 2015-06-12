<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxZengZhi.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxZengZhi" %>

<asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <%#Eval("DealDate", "{0:yyyy-MM-dd}")%></li>
                                        <li>
                                            <%#Eval("Account") %></li>
                                        <li>
                                            <%#Convert.ToDecimal(Eval("IntersetRate"))/10000M%></li>
                                        <li>
                                            <%#Eval("DayInCome") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>