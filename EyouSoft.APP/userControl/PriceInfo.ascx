<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PriceInfo.ascx.cs" Inherits="EyouSoft.WAP.userControl.PriceInfo" %>
<div class="youhui_box" style="background: #fff;">
    <ul id="<%=controlID %>">
        <li class="font_red font12 cent" style="border: #f00 solid 3px;">价格保障：若发现虚高门市价，可索取10倍差额赔偿！</li>
        <asp:Literal ID="litHtml" runat="server"></asp:Literal>
    </ul>
</div>
