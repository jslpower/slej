<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxShangChengList.aspx.cs"
    Inherits="EyouSoft.WAP.CommonPage.ajaxShangChengList" %>

<asp:repeater id="rptlist" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="img_box">
                                            <a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                                <img src='<%# retuImgUrl(Eval("ProductImgs")) %>' /></a></div>
                                        <div class="txt_box">
                                            <dl>
                                                <dt><a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                                    <%#  Eval("ProductName")%></a></dt>
                                                <dd>
                                                    <i class="line_x">¥<%# Eval("MarketPrice","{0:F0}") %></i></dd>
                                                <dd class="txt">
                                                    <i class="font_yellow">¥
                                                        <%# GetJINE( Eval("SalePrice"),Eval("MarketPrice"))%></i></dd>
                                            </dl>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:repeater>
