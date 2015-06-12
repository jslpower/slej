<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxFenSiJiaoYi.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxFenSiJiaoYi" %>

<asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <ul class="clearfix">
                        <li class="wid">
                            <label>
                                产品名称：</label><%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()), 30, true)%></li>
                        <li>
                            <label>
                                订单类型：</label><%#Eval("DingDanLeiXing") %></li>
                        <li>
                            <label>
                                交易时间：</label><%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %></li>
                        <li>
                            <label>
                                交易金额：</label><span class="font_red"><%#Eval("DingDanJinE","{0:F2}") %></span></li>
                        <li>
                            <label>
                                佣 金：</label><span class="font_green"><%#Eval("YongJinJinE", "{0:F2}")%></font></span></li>
                        <li>
                            <label>
                                操作人：</label><%#Eval("XiaDanRenName") %></li>
                        <li>
                            <label>
                                客户信息：</label><%#Eval("KeRenName") %></li>
                        <li class="wid">
                            <label>
                                订单状态：</label><%#Eval("DingDanStatus")%></li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>