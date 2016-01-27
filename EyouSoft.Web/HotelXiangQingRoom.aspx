<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelXiangQingRoom.aspx.cs"
    Inherits="EyouSoft.Web.HotelXiangQingRoom" %>

<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="EyouSoft.Model.HotelStructure.WebModel" %>
<%@ Import Namespace="EyouSoft.BLL.HotelStructure" %>
<tr>
    <th>
        房型
    </th>
    <th>
        套餐名称
    </th>
    <th>
        早餐
    </th>
    <th>
        床型
    </th>
    <th>
        宽带
    </th>
    <th>
        酒店销售价
    </th>
    <% if (IsShowHuiYuan())
       { %>
    <th>
        优惠价
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
    <% if (IsShowDaiLi())
       { %>
    <th>
        代理价
    </th>
    <%} %>
    <% if (IsShowYuanGong())
       { %>
    <th>
        员工价
    </th>
    <%} %>
    <th>
        预订
    </th>
</tr>
<% if (Model != null && Model.RoomRateInfo != null)
   {
       DateTime checkInDate = Model.RuZhuRiQi.Value.Date;
       DateTime checkOutDate = Model.LiDianRiQi.Value.Date;

       var group = Model.RoomRateInfo.OrderBy(x => x.RoomTypeInfo.RoomTypeId).ThenByDescending(x=>x.RoomRateId).GroupBy(x => x.RoomTypeInfo.RoomTypeId);
       foreach (var g in group)
       {
           var roomTypeInfo = Model.RoomRateInfo.FirstOrDefault(x => x.RoomTypeInfo.RoomTypeId == g.Key).RoomTypeInfo;
           var currentGroupArr = g.OrderBy(x => x.StartDate).ToArray();

           Dictionary<string, EyouSoft.Web.TempClass> rooRateInfo = new Dictionary<string, EyouSoft.Web.TempClass>();

           //对价格按rate_plan_code进行组合
           for (int k = 0; k < currentGroupArr.Length; k++)
           {
               MHotelRoomRateBindModel currentRoomRate = currentGroupArr[k];
               string rate_plan_code = string.IsNullOrEmpty(currentGroupArr[k].InterfaceID) ? "" : (currentGroupArr[k].InterfaceID + "$" + currentGroupArr[k].RoomRateName);

               //完全匹配列表
               if (currentRoomRate.StartDate <= checkInDate && currentRoomRate.EndDate >= checkOutDate.AddDays(-1))
               {
                   if (!rooRateInfo.ContainsKey(rate_plan_code))
                   {
                       rooRateInfo.Add(rate_plan_code, new EyouSoft.Web.TempClass
                       {
                           RoomRateIds = new List<int> { currentRoomRate.RoomRateId },
                           FeeSetting = currentRoomRate.FeeSetting,
                           PreferentialPrice = new List<decimal> { currentRoomRate.PreferentialPrice },
                           RoomRateName = new List<string> { currentRoomRate.RoomRateName },
                           SettlementPrice = new List<decimal> { currentRoomRate.SettlementPrice },
                           BreakFasts = new List<string> { currentRoomRate.Breakfast },
                       });
                   }
                   else
                   {
                       Response.Write("数据错误：计划重复了"); //同一个rate_plan_code下有多个价格计划都满足当前日期条件，这是不应当的，表示源数据有问题。
                       Response.End();
                   }
               }
               else //部分匹配列表
               {
                   if (!rooRateInfo.ContainsKey(rate_plan_code))
                   {
                       rooRateInfo.Add(rate_plan_code,
                           new EyouSoft.Web.TempClass
                           {
                               RoomRateIds = new List<int> { currentRoomRate.RoomRateId },
                               FeeSetting = currentRoomRate.FeeSetting,
                               PreferentialPrice = new List<decimal> { currentRoomRate.PreferentialPrice },
                               RoomRateName = new List<string> { currentRoomRate.RoomRateName },
                               SettlementPrice = new List<decimal> { currentRoomRate.SettlementPrice },
                               BreakFasts = new List<string> { currentRoomRate.Breakfast },
                           });
                   }
                   else
                   {
                       rooRateInfo[rate_plan_code].RoomRateIds.Add(currentRoomRate.RoomRateId);
                       rooRateInfo[rate_plan_code].PreferentialPrice.Add(currentRoomRate.PreferentialPrice);
                       rooRateInfo[rate_plan_code].SettlementPrice.Add(currentRoomRate.SettlementPrice);
                       rooRateInfo[rate_plan_code].BreakFasts.Add(currentRoomRate.Breakfast);
                       rooRateInfo[rate_plan_code].RoomRateName.Add(currentRoomRate.RoomRateName);
                   }
               }
           }

           int i = 0;
           foreach (var item in rooRateInfo)
           {
               int index;
               decimal min_settlementprice = SearchMin(item.Value.SettlementPrice, out index);
               decimal min_preferentialprice = item.Value.PreferentialPrice[index];
%>
<tr>
    <td align="center" class="fontblue">
        <%=(i++) == 0 ? (roomTypeInfo.RoomType == RoomType.其它 ? roomTypeInfo.RoomName : roomTypeInfo.RoomType.ToString()) : "&nbsp;"%>
    </td>
    <td align="center">
        <span>
            <%=string.IsNullOrEmpty(item.Key) ? "无名" : item.Value.RoomRateName[0] %></span>
    </td>
    <td align="center">
        <%
            for (int f = 0; f < item.Value.BreakFasts.Count; f++)
            {
                string bf = BHotel2.TransBreakFastBetweenInterfaceAndSelfProject(item.Value.BreakFasts[f]).ToString();
                if (!string.IsNullOrEmpty(bf))
                {
                    Response.Write((f > 0 ? "，" : "") + "&nbsp;" + bf);
                }
            }
        %>
    </td>
    <td align="center">
        <%=roomTypeInfo.BedType == 0 ? roomTypeInfo.BedTypeDescription : roomTypeInfo.BedType.ToString()%>
    </td>
    <td align="center">
        <%=roomTypeInfo.IsInternet%>
    </td>
    <td align="center">
        <b class="font_yellow">¥<strike><%=(min_preferentialprice*BHotel2.RetialPricePercent).ToString("0")%></strike>起</b>
    </td>
    <% if (IsShowHuiYuan())
       { %>
    <td align="center">
        <b class="fontgreen">¥<%=BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, MemberTypes.普通会员, item.Value.FeeSetting, FeeTypes.酒店).ToString("0")%>起</b>
    </td>
    <%} %>
    <% if (IsShowErJiDaiLi())
       { %>
    <td align="center">
        <b class="fontgreen">¥<%=BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, MemberTypes.免费代理, item.Value.FeeSetting, FeeTypes.酒店).ToString("0")%>起</b>
    </td>
    <%} %>
    <% if (IsShowGuiBin())
       { %>
    <td align="center">
        <b class="fontgreen">¥<%=BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, MemberTypes.贵宾会员, item.Value.FeeSetting, FeeTypes.酒店).ToString("0")%>起</b>
    </td>
    <%} %>
    <% if (IsShowDaiLi())
       { %>
    <td align="center">
        <b class="fontgreen">¥<%=BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, MemberTypes.代理, item.Value.FeeSetting, FeeTypes.酒店).ToString("0")%>起</b>
    </td>
    <%} %>
    <% if (IsShowYuanGong())
       { %>
    <td align="center">
        <b class="fontgreen">¥<%=BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, MemberTypes.员工, item.Value.FeeSetting, FeeTypes.酒店).ToString("0")%>起</b>
    </td>
    <%} %>
    <td align="center">
        <a href="javascript:;" roomrateid="<%=string.Join(",",item.Value.RoomRateIds.Select(x=>x.ToString()).ToArray()) %>"
            class="yudin_btn link01" onclick="instance.yuDing('<%=roomTypeInfo.RoomTypeId%>','<%=checkInDate.ToString("yyyy-MM-dd")%>','<%=checkOutDate.ToString("yyyy-MM-dd") %>','<%=string.Join(",",item.Value.RoomRateIds.Select(x=>x.ToString()).ToArray())%>');return false;">
            <span>预订</span></a>
    </td>
</tr>
<%
    }%>
<tr>
    <% int colsNumber = 8;
       if (IsShowHuiYuan()) { colsNumber++; }
       if (IsShowGuiBin()) { colsNumber++; }
       if (IsShowDaiLi()) { colsNumber++; }
       if (IsShowErJiDaiLi()) { colsNumber++; } 
    %>
    <td colspan="<%=colsNumber %>" align="left">
        <b>房型描述：</b><%=roomTypeInfo.Desc%>
    </td>
</tr>
<%}
   }%>