<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxEBao.aspx.cs" Inherits="EyouSoft.Web.CommonPage.ajaxEBao" %>

<asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <ul>
            <li><%#Eval("Issuetime")%> <br/><%# Eval("JiaoYiHao")%></li>
            <li class="font_yellow"> <%# Eval("JinE","{0:F2}")%><br />
                                            <%# Eval("ZhiFuStatus")%></li>
        </ul>
                                    </ItemTemplate>
                                </asp:Repeater>