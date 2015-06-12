<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="EyouSoft.WAP.Member.UserCenter" %>
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
    <div class="user_form">
       <ul>
           <li>
              <span class="label_name">姓名</span>
              <span class="font_yellow"><%= m.MemberName%></span>
           </li>
           <li>
              <span class="label_name">账号</span>
              <span class="font_gray"><%= m.Username%></span>
           </li>
           <li class="R_jiantou" data-url="/Member/EBaoList.aspx">
              <span class="label_name">E额宝余额</span>
              <span class="font_yellow"><%= mymoney.ToString("f2")%></span>
           </li>
      </ul>
     </div>
     
     <div class="user_T mt10 R_jiantou" style="position:relative;" data-url="/Member/WeiChuLiDingDan.aspx">
         <div class="user_wcl">
             <span class="font16">未处理订单<em class="radiusl"><%= WeiChuLiNum%></em></span>
         </div>
     </div>
     
     <div class="user_down" data-div="dingdan">我的订单</div>
     
     <div data-name="dingdan" class="user_form user_form2 mt10" style="display:none">
            <ul>
               <li class="R_jiantou" data-url="/Member/XianLuOrderList.aspx?type=3">
                  <span class="label_name"><s class="ico_dxian"></s>短线订单</span>
               </li>

               <li class="R_jiantou" data-url="/Member/XianLuOrderList.aspx?type=1">
                  <span class="label_name"><s class="ico_chxian"></s>长线订单</span>
               </li>

               <li class="R_jiantou" data-url="/Member/XianLuOrderList.aspx?type=2">
                  <span class="label_name"><s class="ico_chujin"></s>出境订单</span>
               </li>

               <li class="R_jiantou" data-url="/Member/DingDanList.aspx?OrderType=5">
                  <span class="label_name"><s class="ico_hotel"></s>酒店订单</span>
               </li>

               <li class="R_jiantou" data-url="/Member/DingDanList.aspx?OrderType=4">
                  <span class="label_name"><s class="ico_jinqu"></s>门票订单</span>
               </li>
               
               <li class="R_jiantou" data-url="/Member/JpOrderList.aspx">
                  <span class="label_name"><s class="ico_jinqu"></s>机票订单</span>
               </li>
               
               <li class="R_jiantou" data-url="/Member/DingDanList.aspx?OrderType=9">
                  <span class="label_name"><s class="ico_jinqu"></s>单团订单</span>
               </li>
               
               <li class="R_jiantou" data-url="/Member/DingDanList.aspx?OrderType=8">
                  <span class="label_name"><s class="ico_car"></s>租车订单</span>
               </li>

               <li class="R_jiantou" data-url="/Member/DingDanList.aspx?OrderType=3">
                  <span class="label_name"><s class="ico_mall"></s>商城订单</span>
               </li>
               <li class="R_jiantou" data-url="/Member/DingDanList.aspx?OrderType=7">
                  <span class="label_name"><s class="ico_tg"></s>团购订单</span>
               </li>
            </ul>
     </div>


    <div class="user_down" data-div="ebao">Ｅ&nbsp;&nbsp;额&nbsp;&nbsp;宝</div>
     
     <div data-name="ebao" class="user_form user_form2 mt10" style="display:none">
            <ul>
               <li class="R_jiantou" data-url="/EBao.aspx">
                  <span class="label_name"><s class="ico_e01"></s>什么是E额宝？</span>
               </li>

               <li class="R_jiantou" data-url="/Member/YuEGuanLi.aspx">
                  <span class="label_name"><s class="ico_e02"></s>E额宝余额管理</span>
               </li>

               <li class="R_jiantou" data-url="/Member/ChongZhiList.aspx">
                  <span class="label_name"><s class="ico_e03"></s>E额宝充值明细</span>
               </li>
 <%if (isfenxiao == 1)
   { %>
               <li class="R_jiantou" data-url="/Member/FanLiList.aspx">
                  <span class="label_name"><s class="ico_e03"></s>E额宝返利明细</span>
               </li>
<%} %>
               <li class="R_jiantou" data-url="/Member/TiXianList.aspx">
                  <span class="label_name"><s class="ico_e03"></s>E额宝提现明细</span>
               </li>
               
               <li class="R_jiantou" data-url="/Member/ZengZhi.aspx">
                  <span class="label_name"><s class="ico_e04"></s>E额宝积分增值</span>
               </li>
               
               <li class="R_jiantou" data-url="/Member/JiFenDuiHuan.aspx">
                  <span class="label_name"><s class="ico_e04"></s>E额宝积分兑换</span>
               </li>
               
               <%if(isfenxiao==1){ %>
               <li class="R_jiantou" data-url="/Member/XiaJiFenXiao.aspx">
                  <span class="label_name"><s class="ico_e05"></s>我的下级分销奖</span>
               </li>
<%} %>
               <li class="R_jiantou" data-url="/Member/ZongHeMingXi.aspx?type=1">
                  <span class="label_name"><s class="ico_e03"></s>E 额宝综合明细</span>
               </li>
               <li class="R_jiantou" data-url="/Member/ZongHeMingXi.aspx">
                  <span class="label_name"><s class="ico_e03"></s>系统交易总明细</span>
               </li>
            </ul>
     </div>

     <div class="user_down" data-div="ziliao">个人信息</div>
 
      <div data-name="ziliao" class="user_form user_form2 mt10" style="display:none">
            <ul>
               <li class="R_jiantou" data-url="/Member/UpdateMiMa.aspx">
                  <span class="label_name"><s class="ico_mima"></s>修改密码</span>
               </li>

               <li class="R_jiantou" data-url="/Member/UpdateMember.aspx">
                  <span class="label_name"><s class="ico_xinxi"></s>修改信息</span>
               </li>

               <li class="R_jiantou" data-url="/Member/GongGaoList.aspx">
                  <span class="label_name"><s class="ico_gonggao"></s>会员公告</span>
               </li>
            </ul>
     </div>
 
     <div class="padd cent"><a href="javascript:void(0);" class="y_btn">退出</a></div>
     
  </div>
  

  
</body>
<script type="text/javascript">
    $(".R_jiantou").click(function() {
        var url = $(this).attr("data-url");
        window.location.href = url;
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
    $("div[data-div=ziliao]").click(function() {
        if ($(this).attr("class") == "user_up") {
            $(this).removeClass("user_up").addClass("user_down");
        }
        else {
            $(this).removeClass("user_down").addClass("user_up");
        }
        $("div[data-name=ziliao]").toggle();
    });
    $(".y_btn").click(function() {
        if (!confirm("确定退出当前登录！")) return false;

        $.ajax({ type: "post", cache: false, url: "/LogOut.aspx?r=1", dataType: "json",
            success: function(ret) {
                if (ret.result == "1") window.location.reload();
                else window.location.reload();
            },
            error: function() {
                window.location.reload();
            }
        });

        return false;
    });
</script>
</html>
