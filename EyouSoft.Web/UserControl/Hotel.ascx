<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hotel.ascx.cs" Inherits="EyouSoft.Web.UserControl.Totel" %>
<div class="L_list line_list margin_T10">
    <div class="list_T">
        <h3>
            推荐酒店</h3>
    </div>
    <ul>
        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>
                <li><a href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>">
                    <%#Container.ItemIndex+1 %>、<%#Eval("HotelName")%></a><span class="price"><em>¥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("RoomRateInfo[0].SettlementPrice"), (decimal)Eval("RoomRateInfo[0].PreferentialPrice"), CurrentUser.UserType, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("RoomRateInfo[0].FeeSetting"), FeeTypes.酒店).ToString("0")%></em>起</span></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
