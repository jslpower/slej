<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HuiYuanCenter.aspx.cs" Inherits="EyouSoft.WAP.HuiYuanCenter" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>会员中心</title>


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>

<body>

    <uc1:WapHeader runat="server" ID="WapHeader1" />
  <div class="warp">
    
     <div data-div="dingdan" class="user_down">我的订单</div><!-----点击后的li样式是user_up------->
     
     <div data-name="dingdan" class="user_form user_form2" style="display:none;">
            <ul>
               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_dxian"></s>短线订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_chxian"></s>长线订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_chujin"></s>出境订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_hotel"></s>酒店订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_jinqu"></s>门票订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_jinqu"></s>机票订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_dantuan"></s>单团订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_car"></s>租车订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_mall"></s>商城订单</span>
               </li>

               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_tg"></s>团购订单</span>
               </li>
               
            </ul>
     </div>

     
     <div data-div="xinxi" class="user_down">个人信息</div><!-----点击后的li样式是user_down------->
 
      <div data-name="xinxi" class="user_form user_form2" style="display:none;">
            <ul>
               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_mima"></s>修改密码</span>
               
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_xinxi"></s>修改信息</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_gonggao"></s>会员公告</span>
                </li>
            </ul>
        </div>
        <div data-div="ebao" class="user_down">
            E额宝</div>
        <!-----点击后的li样式是user_up------->
        <div data-name="ebao" class="user_form user_form2" style="display: none;">
            <ul>
                <li class="R_jiantou" data-num="1"><span class="label_name"><s class="ico_e01"></s>什么是E额宝？</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e02"></s>E额宝余额管理</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e03"></s>E额宝充值明细</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e03"></s>E额宝返利明细</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e03"></s>E额宝提现明细</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e04"></s>E额宝积分增值</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e04"></s>E额宝积分兑换</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e05"></s>我的下级分销奖</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e03"></s>E额宝综合明细</span>
                </li>
                <li class="R_jiantou"><span class="label_name"><s class="ico_e03"></s>系统交易总明细</span>
                </li>
            </ul>
        </div>
        
         <div class="padd10 cent">
            <a href="/Login.aspx" class="y_btn">马上登录</a></div>
        <div class="padd10 cent">
            <a href="/RegisterStep1.aspx" class="b_btn">1分钟免费注册</a></div>
    </div>
</body>

<script type="text/javascript">
    $(".R_jiantou").click(function() {
        if ($(this).attr("data-num") == "1") {
            window.location = "/EBao.aspx";
        }
        else {
            window.location = "/Login.aspx";
        }
    });
    //订单显示隐藏
    $("div[data-div=dingdan]").click(function() {
        if ($(this).attr("class") == "user_up") {
            $(this).removeClass("user_up").addClass("user_down");
        }
        else {
            $(this).removeClass("user_down").addClass("user_up");
        }
        $("div[data-name=dingdan]").toggle();
    });
    //e额宝显示隐藏
    $("div[data-div=ebao]").click(function() {
        if ($(this).attr("class") == "user_up") {
            $(this).removeClass("user_up").addClass("user_down");
        }
        else {
            $(this).removeClass("user_down").addClass("user_up");
        }
        $("div[data-name=ebao]").toggle();
    });
    //资料显示隐藏
    $("div[data-div=xinxi]").click(function() {
        if ($(this).attr("class") == "user_up") {
            $(this).removeClass("user_up").addClass("user_down");
        }
        else {
            $(this).removeClass("user_down").addClass("user_up");
        }
        $("div[data-name=xinxi]").toggle();
    });
</script>

</html>
