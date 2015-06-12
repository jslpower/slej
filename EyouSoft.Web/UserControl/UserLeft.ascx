<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLeft.ascx.cs" Inherits="EyouSoft.Web.UserControl.UserLeft" %>
<div class="user_left">
    <h5>
        会员中心</h5>
    <div class="left_menu">
        <ul id="navigation">
            <li><a class="inactive" href="javascript:;">我的资料</a>
                <ul style="display: none;">
                    <li><a href="/Member/UpdateMember.aspx">修改资料</a></li>
                    <li><a href="/Member/UpdatePassWord.aspx">修改密码</a></li>
                    
                </ul>
            </li>
            <li><a class="inactive" href="javascript:;">我的订单</a>
                <ul style="display: none;">
                    <% if (isfenxiao == 1)
                       { %>
                    <li><a href="/Member/DingDanList.aspx">订单列表</a></li>
                    <%} %>
                    <li><a href="/Member/DuanXianOrder.aspx">短线订单</a></li>
                    <li><a href="/Member/ChangXianOrder.aspx">长线订单</a></li>
                    <li><a href="/Member/ChuJingOrder.aspx">出境订单</a></li>
                    <li><a href="/Member/ZuTuanOrderList.aspx">报价订单</a></li>
                    <li><a href="/Member/HotelOrderList.aspx">酒店订单</a></li>
                    <li><a href="/Member/ScenicList.aspx">门票订单</a></li>
                    <li><a href="/Member/ZuCheOrderList.aspx">租车订单</a></li>
                    <li><a href="/Member/SCOrderList.aspx">商城订单</a></li>
                    <li><a href="/Member/TuanGouDingDan.aspx">团购订单</a></li>
                    <li><a href="/Member/VisaOrderList.aspx">签证订单</a></li>
                </ul>
            </li>
            <li><a class="inactive" href="/Member/GongGao.aspx">会员公告</a> </li>
            <li><a class="inactive" href="javascript:;">Ｅ&nbsp;&nbsp;额&nbsp;&nbsp;宝</a>
                <ul style="display: none;">
                	<li><a href="/Ebao.aspx" target=_blank>什么是E额宝？</a></li>
                    <li><a href="/Member/UserTransaction.aspx">E额宝余额管理</a></li>
                    <li><a href="/Member/ChongzhiList.aspx">E额宝充值明细</a></li>
                    <% if (isfenxiao == 1)
                       { %>
                    <li><a href="/Member/FanLiList.aspx">E额宝返利明细</a></li>
                    <%} %>
                    <li><a href="/Member/TiXianList.aspx">E额宝提现明细</a></li>
                    <li><a href="/member/ZengZhi.aspx">E额宝积分增值</a></li>
                    <li><a href="/Member/DuiHuanList.aspx">E额宝积分兑换</a></li>
                    <% if (isfenxiao == 1)
                       { %>
                    <li><a href="/member/FenSiJiangLi.aspx">我的下级分销奖</a></li>
                    <%} %>
                    <li style="display:none;"><a href="/member/fensi.aspx">粉丝信息</a></li>
                    <li style="display:none;"><a href="/member/fensijiaoyi.aspx">粉丝交易</a></li>
                    <li><a href="/Member/TransactionList.aspx?type=1">E 额宝综合明细</a></li>
                    <li><a href="/Member/TransactionList.aspx">系统交易总明细</a></li>
                </ul>
            </li>
            
            <li><a class="inactive" href="javascript:void(0)">联盟推广</a>
                <ul style="display: none">
                    <li><a href="/member/tuiguangdaima.aspx">推广链接</a></li>
                    <li><a href="/member/tuiguangfanli.aspx">联盟返利</a></li>
                    <% if (isfenxiao == 1)
                       { %>
                    <li><a href="/webmaster/login.aspx?type=s" target=_blank>网站设置</a></li>
                      <%} %>
                </ul>
            </li>
            
        </ul>
    </div>
</div>
