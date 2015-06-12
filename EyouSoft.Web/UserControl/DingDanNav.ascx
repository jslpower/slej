<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DingDanNav.ascx.cs" Inherits="EyouSoft.Web.UserControl.DingDanNav" %>
<div class="dindan_t margin_T10">
<%if (isAgency == 1){ %><li><a data-nav="navti" href="/Member/DingDanList.aspx" data-num="0">交易统计</a></li><%} %>
<li><a data-nav="navti" href="/Member/DuanXianOrder.aspx" data-num="1">短线订单</a></li>
<li><a data-nav="navti" href="/Member/ChangXianOrder.aspx" data-num="2">长线订单</a></li>
<li><a data-nav="navti" href="/Member/ChuJingOrder.aspx" data-num="3">出境订单</a></li>
<li><a data-nav="navti" href="/Member/ZuTuanOrderList.aspx" data-num="4">报价订单</a></li>
<li><a data-nav="navti" href="/Member/HotelOrderList.aspx" data-num="5">酒店订单</a></li>
<li><a data-nav="navti" href="/Member/ScenicList.aspx" data-num="6">门票订单</a></li>
<li><a data-nav="navti" href="/Member/ZuCheOrderList.aspx" data-num="7">租车订单</a></li>
<li><a data-nav="navti" href="/Member/SCOrderList.aspx" data-num="8">商城订单</a></li>
<li><a data-nav="navti" href="/Member/TuanGouDingDan.aspx" data-num="9">促销订单</a></li>
<li><a data-nav="navti" href="/Member/VisaOrderList.aspx" data-num="10">签证订单</a></li>
</div>