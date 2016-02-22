<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrder.aspx.cs" Inherits="EyouSoft.WAP.HotelOrder" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>酒店订单</title>

<script src="/js/jq.mobi.min.js" type="text/javascript"></script>

<script src="/js/jquery_cm.js" type="text/javascript"></script>
<script src="/js/table-toolbar.js" type="text/javascript"></script>
<script src="js/slogin.js" type="text/javascript"></script>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
  <form>
<div class="warp">
     
         <div class="jq_cont">
            <h2>
                <asp:Literal ID="HotelName" runat="server"></asp:Literal></h2>
         </div>
         
         <div class="fx_box font_gray">
           <p>入住：<asp:Literal ID="RuZhuDay" runat="server"></asp:Literal></p>
           <p>离店：<asp:Literal ID="LiDianDay" runat="server"></asp:Literal>    共<asp:Literal ID="DayNum" runat="server"></asp:Literal>晚</p>
         </div>
         <%if (isLogin)
           { %>
         <div class="user_form hotel_form mt10">
            <ul>
               <li>
                  <span class="label_name"><%= HotelRoomName%></span>
                  <span class="number"><i class="num-minus"></i><input id="RoomNum" name="RoomNum" type="tel" value="1"><i class="num-add"></i></span>
               </li>
               
               <li class="hotel_booking_name">
                  <span class="label_name">入住人姓名</span>
                  <ul class="adduser">
                     <li><input name="RuZhuRenName" type="text" class="u-input" value="每房填写一位" onfocus="javascript:if(this.value=='每房填写一位')this.value='';" onblur="javascript:if(this.value=='')this.value='每房填写一位';" ForeColor="#999999" style="width:47%; float:left;">
                  <input type="text" name="RuZhuRenMoblie" class="u-input" value="入住人需填写手机号" onfocus="javascript:if(this.value=='入住人需填写手机号')this.value='';" onblur="javascript:if(this.value=='')this.value='入住人需填写手机号';" ForeColor="#999999" style="width:50%; float:left;margin-left:2%;"></li>
                  </ul>
                  
               </li>
               
               <li>
                  <span class="label_name">预订人</span>
                   <asp:Literal ID="ConName" runat="server"></asp:Literal> 
                   <asp:Literal ID="ConMoblie" runat="server"></asp:Literal>
               </li>

               <li id="DDTime" class="R_jiantou">
                  <span class="label_name">到店时间</span>
                 <em class="shijian">18：00之前</em>
                 <input id="DaoDianTime" name="DaoDianTime" value="1800" type="hidden" />
               </li>
               
               <li class="paddB paddT">
                  <span class="label_name">有关说明</span>
                  <textarea id="BeiZhu" name="BeiZhu" class="u-input car-input" style="height:80px;"></textarea>
               </li>
               
            </ul>
         </div>
         
         <div class="user_form mt10">
            <ul>
               <li class="cent L_jiantou" style="padding-left:0;"><a href="javascript:history.go(-1);">选择其他房型</a></li>
            </ul>
         </div>
         
         <div class="youhui_box">
            <ul id="jiagelist">
               
            </ul>
         </div>
         
		 <%}
           else
           { %>
		  <div class="user_form hotel_form mt10">
            <ul>
               <li><span class="label_name"><%= HotelRoomName%></span>           
                  <span class="number"><i class="num-minus"></i><input id="RoomNum" name="RoomNum" type="tel" value="1"><i class="num-add"></i></span>
               </li>              
         </div>
         
         <div class="youhui_box">
            <ul id="jiagelist">
               
            </ul>
         </div>
         
         <div class="padd cent"><input id="BtnLogin" type="button" class="y_btn gray_btn" value="非会员直接预订"></div>
   
    <%} %>
     
  </div>
  
  <div class="pay">
     <div class="pay_box">
         <input id="DanJia" name="DanJia" value="<%= DanJia%>" type="hidden" />
         <input id="DaysNum" name="DaysNum" value="<%= DaysNum%>" type="hidden" />
         <input id="HuiYuanDanJia" name="HuiYuanDanJia" value="<%= HuiYuanDanJia%>" type="hidden" />
         <input id="GuiBingDanJia" name="GuiBingDanJia" value="<%= GuiBingDanJia%>" type="hidden" />
         <input id="DaiLiDanJia" name="DaiLiDanJia" value="<%= DaiLiDanJia%>" type="hidden" />
         <input id="DaiXiaoDanJia" name="DaiXiaoDanJia" value="<%= DaiXiaoDanJia%>" type="hidden" />
         <input id="DanZongJia" name="DanZongJia" value="<%= ZongJia%>" type="hidden" />
         <div class="pay_total"> 金额：¥<em id="ZongJinE" name="ZongJinE"><%= ZongJia%></em></div>
         <div class="pay_mx R_jiantou">明细</div>
         <div class="pay_btn"><a href="javascript:;" class="step_btn">核对提交</a></div>
     </div>
  </div>

</form>
<!---到店时间--->
<div id="DDTimeMask" class="user-mask" style="display:none;">

   <div class="h-mask-cnt">
       
            <div class="day_xuanze">
               <div class="day_T">选择到店时间</div>
                  <ul>
                      <li class="on" data-time="1800">18：00之前</li>
                      <li data-time="1900">19：00之前</li>
                      <li data-time="2000">20：00之前</li>
                      <li data-time="2100">21：00之前</li>
                      <li data-time="2200">22：00之前</li>
                      <li data-time="2300">23：00之前</li>
                  </ul>
               </div>   
            </div>
          
   </div>
  
  
<!---明细--->
<div id="MingXiMask" class="user-mask" style="display:none;">
   <div class="h-mask-cnt">
       
       <div class="day_xuanze">
          <div class="day_T">费用明细</div>
          <ul class="hotel_mx_box">
              <%= MingXi %>
          </ul>
          <div class="right_txt padd">总额：<span class="font_yellow">¥<em id="AmountPrice"><%= ZongJia%></em></span></div>
       </div>
          
   </div>
</div>

<div id="TiJiaoMask" class="user-mask" style="display:none;">
   <div class="h-mask-cnt" style="margin-top:200px;">
       
       <div class="cent font_yellow font16" style="padding-top:20px;">
            正在提交订单，请等待。。。
       </div>
          
   </div>
</div>

</body>
<script type="text/javascript">
    //修改房间数量开始
    $(".num-minus").click(function() {
        var getNum = $(this).parent().find("input").eq(0);
        if (tableToolbar.getInt(getNum.val()) > 1) {//成人数量不能低于2人
            getNum.val(tableToolbar.getInt(getNum.val()) - 1);
            var num = $(".adduser").find("li").length;
            $(".adduser").find("li").eq(num - 1).remove();
        } else {
            getNum.val(1);
        }
        $(".roomNum").html(getNum.val());
        var danjia = tableToolbar.getFloat($("#DanJia").val());
        $("#ZongJinE").html(tableToolbar.getFloat($("#DanZongJia").val()) * tableToolbar.getFloat(getNum.val()));
        $("#AmountPrice").html($("#ZongJinE").html());
        PageOrder.GetYouHui();
    });
    $(".num-add").click(function() {
        var getNum = $(this).parent().find("input").eq(0);
        getNum.val(tableToolbar.getInt(getNum.val()) + 1);
        html = "<li><input name=\"RuZhuRenName\" type=\"text\" class=\"u-input\" value=\"每房填写一位\" onfocus=\"javascript:if(this.value=='每房填写一位')this.value='';\" onblur=\"javascript:if(this.value=='')this.value='每房填写一位';\" ForeColor=\"#999999\" style=\"width:47%; float:left;\"><input type=\"text\" name=\"RuZhuRenMoblie\" class=\"u-input\" value=\"入住人需填写手机号\" onfocus=\"javascript:if(this.value=='入住人需填写手机号')this.value='';\" onblur=\"javascript:if(this.value=='')this.value='入住人需填写手机号';\" ForeColor=\"#999999\" style=\"width:50%; float:left;margin-left:2%;\"></li>";
        $(".adduser").append(html);
        var danjia = tableToolbar.getFloat($("#DanJia").val());
        $("#ZongJinE").html(tableToolbar.getFloat($("#DanZongJia").val()) * tableToolbar.getFloat(getNum.val()));
        $(".roomNum").html(getNum.val());
        $("#AmountPrice").html($("#ZongJinE").html());
        PageOrder.GetYouHui();
    });
    //修改房间数量结束
    //明细展示隐藏开始
    $(".pay_mx").click(function() {
        $("#MingXiMask").show();
    })
    $("#MingXiMask").click(function() {
        $("#MingXiMask").hide();
    })
    //明细展示隐藏结束
    //到店时间展示隐藏开始
    $("#DDTime").click(function() {
        $("#DDTimeMask").show();
    });
    $("#DDTimeMask").find("li").click(function() {
        $("#DDTimeMask").find("li").removeClass("on");
        $(this).addClass("on");
        $(".shijian").html($(this).html());
        $("#DaoDianTime").val($(this).attr("data-time"));
        $("#DDTimeMask").hide();
    });
    //到店时间展示隐藏结束
    var PageOrder = {
        CheckForm: function() {

            var count = $("input[name=RuZhuRenName]").length;
            for (var i = 0; i < count; i++) {
                if ($("input[name=RuZhuRenName]").eq(i).val() == "每房填写一位") {
                    alert("请填写入住人姓名");
                    return false;
                }
                else {
                    if (!/^[\u4e00-\u9fa5a-zA-Z_]+$/.test($("input[name=RuZhuRenName]").eq(i).val())) {
                        alert('请填写正确的入住人姓名');
                        return false;
                    }
                }
                if ($("input[name=RuZhuRenMoblie]").eq(i).val() == "入住人需填写手机号") {
                    alert("请填写入住人手机号");
                    return false;
                }
                else {
                    if (!/^(13|15|18|14)\d{9}$/.test($("input[name=RuZhuRenMoblie]").eq(i).val())) {
                        alert('请填写正确的入住人手机号');
                        return false;
                    }
                }
            }
            return true;
        },
        GetYouHui: function() {
            var usercate = "<%=usercate %>";
            var num = $("#RoomNum").val();
            var daynum = $("#DaysNum").val();
            var isShow = "<%= isShow %>";
            var html = "";
            var hysq = "";
            var gbsq = "<a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a>";
            var dlsq = "<a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a>";
            var gbls = "立省<span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat($("#HuiYuanDanJia").val()) * tableToolbar.getInt(num)) - tableToolbar.getFloat(tableToolbar.getFloat($("#GuiBingDanJia").val()) * tableToolbar.getInt(num))) + "元</span>";
            var dlls = "立省<span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat($("#HuiYuanDanJia").val()) * tableToolbar.getInt(num)) - tableToolbar.getFloat(tableToolbar.getFloat($("#DaiLiDanJia").val()) * tableToolbar.getInt(num))) + "元</span>";
            
            if (usercate == 1) {
                hysq = "";
                html += "<li class=\"on\">" + hysq + "<span class=\"font_yellow\">第一天入住优惠价：</span>" + $("#HuiYuanDanJia").val() + "元/间 (当前身份)</li>";
                if (isShow == "True") {
                    html += "<li>" + gbsq + "<span class=\"font_yellow\">第一天入住贵宾价：</span>" + $("#GuiBingDanJia").val() + "元/间 " + gbls + "</li>";
                    html += "<li>" + dlsq + "<span class=\"font_yellow\">第一天入住代理价：</span>" + $("#DaiLiDanJia").val() + "元/间 " + dlls + "</li>";
                }
            }
            else if (usercate == 2) {
                hysq = "";
                gbsq = "";
                gbls = "";
                html += "<li>" + hysq + "<span class=\"font_yellow\">第一天入住优惠价：</span>" + $("#HuiYuanDanJia").val() + "元/间</li>";
                html += "<li class=\"on\">" + gbsq + "<span class=\"font_yellow\">第一天入住贵宾价：</span>" + $("#GuiBingDanJia").val() + "元/间 (当前身份)</li>";
                if (isShow == "True") {
                    html += "<li>" + dlsq + "<span class=\"font_yellow\">第一天入住代理价：</span>" + $("#DaiLiDanJia").val() + "元/间 " + dlls + "</li>";
                }
            }
            else if (usercate == 3) {
                hysq = "";
                gbsq = "";
                html += "<li>" + hysq + "<span class=\"font_yellow\">第一天入住优惠价：</span>" + $("#HuiYuanDanJia").val() + "元/间</li>";
                html += "<li class=\"on\"><span class=\"font_yellow\">第一天入住代销价：</span>" + $("#DaiXiaoDanJia").val() + "元/间 (当前身份)</li>";
                if (isShow == "True") {
                    html += "<li>" + dlsq + "<span class=\"font_yellow\">第一天入住代理价：</span>" + $("#DaiLiDanJia").val() + "元/间 " + dlls + "</li>";
                }
            }
            else if (usercate == 4) {
                hysq = "";
                gbsq = "";
                dlsq = "";
                gbls = "";
                dlls = "";
                html += "<li>" + hysq + "<span class=\"font_yellow\">第一天入住优惠价：</span>" + $("#HuiYuanDanJia").val() + "元/间</li>";
                if (isShow == "True") {
                    html += "<li><span class=\"font_yellow\">第一天入住贵宾价：</span>" + $("#GuiBingDanJia").val() + "元/间</li>";
                }
                html += "<li class=\"on\"><span class=\"font_yellow\">第一天入住代理价：</span>" + $("#DaiLiDanJia").val() + "元/间 (当前身份)</li>";
            }
            else if (usercate == 5) {
                hysq = "";
                gbsq = "";
                dlsq = "";
                gbls = "";
                dlls = "";
                html += "<li>" + hysq + "<span class=\"font_yellow\">第一天入住优惠价：</span>" + $("#HuiYuanDanJia").val() + "元/间</li>";
                if (isShow == "True") {
                    html += "<li><span class=\"font_yellow\">第一天入住贵宾价：</span>" + $("#GuiBingDanJia").val() + "元/间</li>";
                    html += "<li><span class=\"font_yellow\">第一天入住代理价：</span>" + $("#DaiLiDanJia").val() + "元/间</li>";
                }
                html += "<li class=\"on\"><span class=\"font_yellow\">第一天入住员工价：</span>" + $("#DanJia").val() + "元/间 (当前身份)</li>";
            }
            $("#jiagelist").html(html);
        }
    }
    
    //非会员登录
    $("#BtnLogin").click(function() { window.location.href = '/HuiYuanReg.aspx?rurl=' + encodeURIComponent(window.location.href); });
    //提交
    $(".step_btn").click(function() {
        var _m = iLogin.getM();
        if (!_m.isLogin) {
            window.location.href = '/Login.aspx?rurl=' + encodeURIComponent(window.location.href);
        }
        else {
            if (PageOrder.CheckForm()) {
               
                var url = location.href;
                url = url + "&dotype=save";
                if (window.confirm("请确认提交")) {
                 $("#TiJiaoMask").toggle();
                    $.ajax({
                        type: "post",
                        cache: false,
                        url: url,
                        dataType: "json",
                        data: $(".step_btn").closest("form").serialize(),
                        success: function(ret) {
                            if (ret.result == "1") {
                                $("#TiJiaoMask").toggle();
                                alert(ret.msg);
                                window.location.href = "/Member/DingDanList.aspx?OrderType=5";
                            }
                            else {
                                $("#TiJiaoMask").toggle();
                                alert(ret.msg);

                            }
                        },
                        error: function() {
                            $("#TiJiaoMask").toggle();
                            alert("报价失败");
                        }
                    });
                }
            }
        }
    });
    window.onload = function() {
        PageOrder.GetYouHui();
    }
</script>
</html>
