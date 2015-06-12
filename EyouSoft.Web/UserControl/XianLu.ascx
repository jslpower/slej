<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XianLu.ascx.cs" Inherits="EyouSoft.Web.UserControl.XianLu" %>
<div class="L_list line_list margin_T10">
    <div class="list_T">
        <h3>
            推荐线路</h3>
    </div>
    <ul>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <li><a target=_blank href="/XianLuYuDing.aspx?id=<%# Eval("XianLuId")%>"><%# Container.ItemIndex + 1%>、<%# Eval("RouteName").ToString().Length > 12 ? Eval("RouteName").ToString().Substring(0, 12) : Eval("RouteName")%></a><span class="price"><em>¥<%# Convert.ToInt32(Eval("SCJCR"))%></em>起</span></li>
        </ItemTemplate>
        </asp:Repeater>
        
       </ul>
</div>
