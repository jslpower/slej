<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxHotel.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxHotel" %>

<asp:Repeater ID="Repeater1" runat="server">
             <ItemTemplate>
             <li><a href="/HotelXX.aspx?HotelId=<%#Eval("HotelId")%>&RuZhuRiQi=<%= ruzhuriqi%>&lidianriqi=<%= lidianriqi%>">
             <div class="jq_img"><img src="<%# EyouSoft.Common.TuPian.F1(string.Format("{0}",Eval("FirstImageAddress")), 320, 240) %>" /></div>
             <dl>
               <dt><%#Eval("HotelName") %></dt>
               <dd>星级：<%# Eval("Star")%></dd>
               <dd>位置：<%#Eval("Address")%></dd>
               <dd class="wid">门市价：<i class="line_x">¥<%#((decimal)Eval("RoomRateInfo[0].PreferentialPrice") * EyouSoft.BLL.HotelStructure.BHotel2.RetialPricePercent).ToString("0")%></i> 起</dd>
               <dd class="wid R"><span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("RoomRateInfo[0].SettlementPrice"), (decimal)Eval("RoomRateInfo[0].PreferentialPrice"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)(Eval("RoomRateInfo[0].FeeSetting")), EyouSoft.Model.Enum.FeeTypes.酒店).ToString("0")%></i></span>起</dd>
             </dl></a>
           </li>
             </ItemTemplate>
             </asp:Repeater>