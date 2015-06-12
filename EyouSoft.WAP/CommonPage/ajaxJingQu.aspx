<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxJingQu.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxJingQu" %>

<asp:Repeater ID="Repeater1" runat="server">
                           <ItemTemplate>
                           <li><a href="jinqu_xx.html">
                               <div class="jq_img"><a href="YouHuiMenPiaoXiangQing.aspx?ScenicId=<%#Eval("ScenicId")%>&TicketsId=<%#Eval("TicketFirst.TicketsId") %>">
                            <img src="<%# EyouSoft.Common.TuPian.F1(Eval("ImgFirst.Address").ToString(), 320, 240) %>" /></div>
                               <dl>
                                  <dt><a href="YouHuiMenPiaoXiangQing.aspx?ScenicId=<%# Eval("ScenicId")%>&TicketsId=<%#Eval("TicketFirst.TicketsId") %>">
                                    <%# Eval("ScenicName")%></a></dt>
                                  <dd class="wid50"><%# Eval("ScenicLevel")%></dd>
                                  <%--<dd class="wid50 right_txt">2.5 公里</dd>--%>
                                  <dd class="wid">挂牌价：¥<strike><%# ((decimal)Eval("TicketFirst.RetailPrice")).ToString("0")%></strike> 起/人</dd>
                                  <dd class="wid R">零售价：¥<strike><%# ((decimal)Eval("TicketFirst.WebsitePrices")).ToString("0")%></strike> 起/人</dd>
                                  <dd class="wid">会员价：<span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("TicketFirst.DistributionPrice"), (decimal)Eval("TicketFirst.WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("TicketFirst.FeeSetting"), EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%></i></span>起/人</dd>
                               </dl></a>
                           </li>
                           </ItemTemplate>
                           </asp:Repeater>
