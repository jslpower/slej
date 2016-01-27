<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxJingQu.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxJingQu" %>

<asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li><a href="/JingQuXX.aspx?ScenicId=<%#Eval("ScenicId")%>&TicketsId=<%#Eval("TicketFirst.TicketsId") %>">
                                                <div class="jq_img">
                                                    <img src="<%# EyouSoft.Common.TuPian.F1(Eval("ImgFirst.Address").ToString(), 320, 240) %>" /></div>
                                                <dl>
                                                    <dt>
                                                        <%# Eval("ScenicName")%></dt>
                                                    <dd class="wid">
                                                        <%# Eval("ScenicLevel")%></dd>
                                                    <dd class="wid R">
                                                        挂牌：¥<strike><%# ((decimal)Eval("TicketFirst.RetailPrice")).ToString("0")%></strike>起</dd>
                                                    <dd class="wid">
                                                        零售：¥<strike><%# ((decimal)Eval("TicketFirst.WebsitePrices")).ToString("0")%></strike>起</dd>
                                                    <dd class="wid R">
                                                        优惠：<span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("TicketFirst.DistributionPrice"), (decimal)Eval("TicketFirst.WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("TicketFirst.FeeSetting"), EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%></i></span>起</dd>
                                                </dl>
                                            </a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
