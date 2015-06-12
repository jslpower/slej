<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingQuOrder.aspx.cs" Inherits="EyouSoft.WAP.JingQuOrder" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head runat="server">
   <meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>景区订单</title>

<script src="/js/jquery_cm.js" type="text/javascript"></script>
    <script src="js/jq.mobi.min.js" type="text/javascript"></script>
    <script src="js/slogin.js" type="text/javascript"></script>
    <script src="js/table-toolbar.js" type="text/javascript"></script>
</head>
<body>
<form>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
  
<div class="warp">
     
         <div class="jq_cont">
            <h2><%=ScenicName %></h2>
         </div>
         
         <div class="user_form mt10">
            <ul>
               <li class="R_jiantou" id="inputriqi">
                  <span class="label_name">使用日期</span>
                  <input id="riqi" name="riqi" type="type"  readonly="readonly"  class="u-input" value="请选择游玩日期">
               </li>
               
               <li>
                  <span class="label_name">购买份数</span>
                  <span class="number"><i class="num-minus"></i><input type="tel" id="TickNum" name="TickNum" value="1"><i class="num-add"></i></span>
               </li>
               
               <li>
                  <span class="label_name">取票人</span>
                  <input id="QuPiaoName" name="QuPiaoName" type="text" class="u-input" value="取票人姓名" onfocus="javascript:if(this.value=='取票人姓名')this.value='';" onblur="javascript:if(this.value=='')this.value='取票人姓名';" ForeColor="#999999">
               </li>
               <li>
                  <span class="label_name">取票人手机</span>
                  <input id="QuPiaoMobile" name="QuPiaoMobile" type="text" class="u-input" value="取票人手机"  onfocus="javascript:if(this.value=='取票人手机')this.value='';" onblur="javascript:if(this.value=='')this.value='取票人手机';" ForeColor="#999999">
               </li>
            </ul>
         </div>
 
         <%if(isShow){ %>
         <div class="youhui_box">
            <ul id="jiagelist">
               
            </ul>
         </div>
         <%} %>
		  <%if (!isLogin)
      { %>
         <div class="padd cent"><input id="BtnLogin" type="button" class="y_btn gray_btn" value="非会员直接预订" /></div>
   <%} %>
    
  
  </div>
  <div class="datelist" style="display: none; padding-top:48px;  width:100%; height:100%; box-sizing:border-box;">
        <asp:Literal ID="litMonth" runat="server"></asp:Literal>
    </div>
  <div class="pay">
     <div class="pay_box">
         <div class="pay_total">订单总额：¥<em id="zongjiage"><%=OrderPrice.ToString("f2")%></em></div>
         <input id="DanJia" name="DanJia" type="hidden" value="<%=OrderPrice%>" />
         <input id="HuiYuanDanJia" type="hidden" value="<%=HuiYuanDanJia%>" />
         <input id="GuiBingDanJia" type="hidden" value="<%=GuiBingDanJia%>" />
         <input id="DaiLiDanJia" type="hidden" value="<%=DaiLiDanJia%>" />

         <div class="pay_btn"><a href="javascript:;" class="step_btn" >核对提交</a></div>
     </div>
  </div> </form>  
 <div id="TiJiaoMask" class="user-mask" style="display:none;">
   <div class="h-mask-cnt" style="margin-top:200px;">
       
       <div class="cent font_yellow font16" style="padding-top:20px;">
            正在提交订单，请等待。。。
       </div>
          
   </div>
</div>
</body>
<script type="text/javascript">


    $("#inputriqi").click(function() {
        $(".warp").toggle();
        $(".datelist").toggle();
        $('body,html').animate({ scrollTop: 0 }, 500);
    });
    $(".riqi_day_select").click(function() {
        $("#riqi").val($(this).attr("data-date"));
        $(".warp").toggle();
        $(".datelist").toggle();
    })
    $(".num-minus").click(function() {
        var getNum = $(this).parent().find("input").eq(0);
        if (tableToolbar.getInt(getNum.val()) > 1) {//成人数量不能低于2人
            getNum.val(tableToolbar.getInt(getNum.val()) - 1);
        } else {
            getNum.val(1);
        }
        var danjia = $("#DanJia").val();
        $("#zongjiage").html(tableToolbar.getFloat(tableToolbar.getInt(getNum.val()) * tableToolbar.getFloat(danjia)) + "元");
        PageOrder.GetYouHui();
    });
    $(".num-add").click(function() {
        var getNum = $(this).parent().find("input").eq(0);
        getNum.val(tableToolbar.getInt(getNum.val()) + 1);
        var danjia = $("#DanJia").val();
        $("#zongjiage").html(tableToolbar.getFloat(tableToolbar.getInt(getNum.val()) * tableToolbar.getFloat(danjia)) + "元");
        PageOrder.GetYouHui();
    });
    $("#BtnLogin").click(function() { window.location.href = '/HuiYuanReg.aspx?rurl=' + encodeURIComponent(window.location.href); });
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
                                window.location.href = "/Member/DingDanList.aspx?OrderType=4";
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
    var PageOrder = {
        CheckForm: function() {
            if ($("#QuPiaoName").val() == "取票人姓名") {
                alert("请填写取票人姓名");
                return false;
            }
            else {
                if (!/^[\u4e00-\u9fa5a-zA-Z_]+$/.test($("#QuPiaoName").val())) {
                    alert('请填写正确的取票人姓名');
                    return false;
                }
            }

            if ($("#QuPiaoMobile").val() == "取票人手机") {
                alert("请填写取票人手机");
                return false;
            }
            else {
                var mobile = $("#QuPiaoMobile").val();
                if (!/^(13|15|18|14)\d{9}$/.test(mobile)) {
                    alert('请填写正确的取票人手机');
                    return false;
                }
            }
            if ($("#riqi").val() == "请选择游玩日期") {
                alert('请选择游玩日期！');
                return false;
            }
            else {
                var mobile = $("#riqi").val();
                if (!/^\d{4}-\d{1,2}-\d{1,2}$/.test(mobile)) {
                    alert('请选择正确的游玩日期');
                    return false;
                }
            }
            return true;
        },
        GetYouHui: function() {
            var usercate = "<%=usercate %>";
            var num = $("#TickNum").val();
            var html = "";
            var hysq = "";
            var gbsq = "<a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a>";
            var dlsq = "<a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a>";
            var gbls = "立省<span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat($("#HuiYuanDanJia").val()) * tableToolbar.getInt(num)) - tableToolbar.getFloat(tableToolbar.getFloat($("#GuiBingDanJia").val()) * tableToolbar.getInt(num))) + "元</span>";
            var dlls = "立省<span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat($("#HuiYuanDanJia").val()) * tableToolbar.getInt(num)) - tableToolbar.getFloat(tableToolbar.getFloat($("#DaiLiDanJia").val()) * tableToolbar.getInt(num))) + "元</span>";
            if (usercate == 1) {
                hysq = "";
            }
            else if (usercate == 2) {
                hysq = "";
                gbsq = "";
                gbls = "";
            }
            else if (usercate == 3) {
                hysq = "";
            }
            else if (usercate == 4 || usercate == 5) {
                hysq = "";
                gbsq = "";
                dlsq = "";
                gbls = "";
                dlls = "";
            }
            html += "<li>" + hysq + "<span class=\"font_yellow\">会员：</span>成人" + $("#HuiYuanDanJia").val() + "元/人 x " + num + "人 = <span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat($("#HuiYuanDanJia").val()) * tableToolbar.getInt(num)) + "</span>元</li>";
            html += "<li>" + gbsq + "<span class=\"font_yellow\">贵宾：</span>成人" + $("#GuiBingDanJia").val() + "元/人 x " + num + "人 = <span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat($("#GuiBingDanJia").val()) * tableToolbar.getInt(num)) + "</span>元 " + gbls + "</li>";
            html += "<li>" + dlsq + "<span class=\"font_yellow\">代理：</span>成人" + $("#DaiLiDanJia").val() + "元/人 x " + num + "人 = <span class=\"font_yellow\">" + tableToolbar.getFloat(tableToolbar.getFloat($("#DaiLiDanJia").val()) * tableToolbar.getInt(num)) + "</span>元 " + dlls + "</li>";
            $("#jiagelist").html(html);
        }
    };
    window.onload = function() {
        PageOrder.GetYouHui();
    }
</script>
</html>
