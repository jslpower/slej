<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelXiangQing2Room.aspx.cs"
    Inherits="EyouSoft.Web.HotelXiangQing2Room" %>

<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="EyouSoft.Model.HotelStructure.WebModel" %>
<%@ Import Namespace="EyouSoft.BLL.HotelStructure" %>
<%@ Import Namespace="EyouSoft.Web" %>
<tr>
    <th>
        入住日期
        <%=Html.HiddenFor(x=>x.RoomTypeId) %>
    </th>
    <th>
        房型
    </th>
    <th>
        套餐名称
    </th>
    <th>
        酒店销售价
    </th>
    <% if (IsShowHuiYuan())
       { %>
    <th>
        会员价
    </th>
    <%} %>
    <% if (IsShowErJiDaiLi())
       { %>
    <th>
        代销价
    </th>
    <%} %>
    <% if (IsShowGuiBin())
       { %>
    <th>
        贵宾价
    </th>
    <%} %>
    <% if (IsShowShengQingGuiBin())
       { %>
    <th>
        申请贵宾身份
    </th>
    <%} %>
    <% if (IsShowDaiLi())
       { %>
    <th>
        代理价
    </th>
    <%} %>
    <% if (IsShowShengQingDaiLi())
       { %>
    <th>
        申请代理身份
    </th>
    <%} %>
    <% if (IsShowYuanGong())
       { %>
    <th>
        员工价
    </th>
    <%} %>
</tr>
<%
    if (Model.RoomRateInfo != null && Model.RoomRateInfo.Count > 0)
    {
        var gs = Model.RoomRateInfo.OrderBy(y => y.InterfaceID + "$" + y.RoomRateName).GroupBy(x => x.InterfaceID + "$" + x.RoomRateName).ToArray();
        var roomTypeInfo = Model.RoomRateInfo.First().RoomTypeInfo;
        foreach (var g in gs)
        {
            decimal total0 = 0;
            decimal total1 = 0; //销售价
            decimal total2 = 0; //会员
            decimal total3 = 0; //贵宾
            decimal total4 = 0; //代理
            decimal total5 = 0; //代理
            decimal total6 = 0; //员工价
            DateTime t1 = Model.RuZhuRiQi.Value.Date;
            while (t1 < Model.LiDianRiQi.Value.Date)
            {
                MHotelRoomRateBindModel item = g.FirstOrDefault(x => x.StartDate <= t1 && t1 <= x.EndDate);
                total0 += BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, CurrentUser.UserType, item.FeeSetting, FeeTypes.酒店);
                total1 += item.PreferentialPrice * BHotel2.RetialPricePercent;
                total2 += BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.普通会员, item.FeeSetting, FeeTypes.酒店);
                total3 += BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.贵宾会员, item.FeeSetting, FeeTypes.酒店);
                total4 += BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店);
                total5 += BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.免费代理, item.FeeSetting, FeeTypes.酒店);
                total6 += BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.员工, item.FeeSetting, FeeTypes.酒店);
%>
<tr class="datatr">
    <td align="center" rid="<%=item.RoomRateId %>" dj="<%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, CurrentUser.UserType, item.FeeSetting, FeeTypes.酒店)%>">
        <%=t1.ToString("yyyy-MM-dd")%>
    </td>
    <td align="center">
        <%=roomTypeInfo.RoomType == RoomType.其它 ? roomTypeInfo.RoomName : roomTypeInfo.RoomType.ToString()%>
    </td>
    <td align="center">
        <%=string.IsNullOrEmpty(item.InterfaceID) ? "无名" : item.RoomRateName%>
    </td>
    <td align="center">
        <span class="danjia">
            <%=(item.PreferentialPrice * BHotel2.RetialPricePercent).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_yellow totalMoney"><%=((item.PreferentialPrice * BHotel2.RetialPricePercent) * 1).ToString("0")%></font>
    </td>
    <% if (IsShowHuiYuan())
       { %>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.普通会员, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_hy totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.普通会员, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>
    </td>
    <%} %>
    <% if (IsShowErJiDaiLi())
       {%>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.免费代理, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_hy totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.免费代理, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>
    </td>
    <%} %>
    <% if (IsShowGuiBin())
       {%>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.贵宾会员, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_hy totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.贵宾会员, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>
    </td>
    <%} %>
    <% if (IsShowShengQingGuiBin())
       { %>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.贵宾会员, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_gb totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.贵宾会员, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>，立省<font
                    class="font_gb lisheng"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, CurrentUser.UserType, item.FeeSetting, FeeTypes.酒店) * 1 - BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.贵宾会员, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>元
    </td>
    <% } %>
    <% if (IsShowDaiLi())
       {%>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_hy totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>
    </td>
    <%} %>
    <% if (IsShowShengQingDaiLi())
       { %>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_dl totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>，立省<font
                    class="font_dl lisheng"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, CurrentUser.UserType, item.FeeSetting, FeeTypes.酒店) * 1 - BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>元
    </td>
    <% } %>
    <% if (IsShowYuanGong())
       {%>
    <td align="center">
        <span class="danjia">
            <%=BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.员工, item.FeeSetting, FeeTypes.酒店).ToString("0")%></span>*<span
                class="jian">1</span>间=<font class="font_hy totalMoney"><%=(BHotel2.CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.员工, item.FeeSetting, FeeTypes.酒店) * 1).ToString("0")%></font>
    </td>
    <%} %>
</tr>
<% t1 = t1.AddDays(1);
            }
%>
<tr class="last_tr">
    <td colspan="3" align="right">
        <strong>合计：</strong>
    </td>
    <td align="center">
        总额：<span class="zonge"><strike><%=total1.ToString("0")%></strike></span>元
    </td>
    <% if (IsShowHuiYuan())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total2.ToString("0")%></span>元
    </td>
    <%} %>
    <% if (IsShowGuiBin())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total3.ToString("0")%></span>元
    </td>
    <%} %>
    <% if (IsShowShengQingGuiBin())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total3.ToString("0")%></span>元，立省<span class="lisheng"><%=(total0 - total3).ToString("0")%></span>元<br />
        <a href="javascript:;" <%=HotelXiangQing.ShowLink(MemberTypes.贵宾会员)%>>马上申请贵宾</a>
    </td>
    <%} %>
    <% if (IsShowErJiDaiLi())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total5.ToString("0")%></span>元
    </td>
    <%} %>
    <% if (IsShowDaiLi())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total4.ToString("0")%></span>元
    </td>
    <%} %>
    <% if (IsShowShengQingDaiLi())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total4.ToString("0")%></span>元，立省<span class="lisheng"><%=(total0 - total4).ToString("0")%></span>元<br />
        <a href="javascript:;" <%=HotelXiangQing.ShowLink(MemberTypes.代理)%>>马上申请代理</a>
    </td>
    <% } %>
    <% if (IsShowYuanGong())
       { %>
    <td align="center">
        总额：<span class="zonge"><%=total6.ToString("0")%></span>元
    </td>
    <%} %>
</tr>
<% }
    }
    else
    {%>
<tr>
    <td height="50" colspan="7" align="center" class="fontred font18">
        <strong>该日期段内余房不够，请调整日期或更换房型</strong>
    </td>
</tr>
<% }%>
