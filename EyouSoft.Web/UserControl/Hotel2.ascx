<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hotel2.ascx.cs" Inherits="EyouSoft.Web.UserControl.Hotel2" %>
<div class="tj_hotel margin_T10">
    <div class="jinqu_tableT hotelT">
        推荐酒店</div>
    <table class="jinqu_table tj_hotel_table" border="0" cellspacing="0" cellpadding="0"
        width="98%" align="center">
        <tbody>
            <tr>
                <th>
                    酒店名称
                </th>
                <th>
                    酒店销售价
                </th>
                <th>
                    优惠价
                </th>
                <th>
                    预订
                </th>
            </tr>
            <asp:Repeater runat="server" ID="Repeater1">
                <ItemTemplate>
                    <tr>
                        <td align="middle">
                            <a class="xiangxi" href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>">
                                <%#Eval("HotelName") %></a>
                        </td>
                        <td align="middle">
                            <b class="price_red">￥<strike><%#((decimal)Eval("RoomRateInfo[0].PreferentialPrice") * EyouSoft.BLL.HotelStructure.BHotel2.RetialPricePercent).ToString("0")%></strike></b>
                        </td>
                        <td align="middle">
                            <b class="fontgreen">￥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("RoomRateInfo[0].SettlementPrice"), (decimal)Eval("RoomRateInfo[0].PreferentialPrice"), CurrentUser.UserType, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("RoomRateInfo[0].FeeSetting"), FeeTypes.酒店).ToString("0")%></b>
                        </td>
                        <td align="middle">
                            <a class="yudin_btn" href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>">
                                <span>预订</span></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>
