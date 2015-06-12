<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxTuanGou.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxTuanGou" %>

<asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li> <a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>">
                                <div class="img_box">
                                   <img src="<%# EyouSoft.Common.TuPian.F1(Eval("ProductImg").ToString(), 640, 200)%>" />
                                </div>
                                <div class="txt_box">
                                    <dl>
                                        <dt><%# Eval("ProductName")%></dt>
                                        <dd>
                                            <i class="font_yellow">¥<em class="font18"><%# Convert.ToInt32(Eval("GroupPrice"))%></em></i>起</dd>
                                        <dd class="txt">
                                            <i class="line_x font12">原价：¥<%# Convert.ToInt32(Eval("MarketPrice"))%></i></dd>
                                    </dl>
                                </div>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
