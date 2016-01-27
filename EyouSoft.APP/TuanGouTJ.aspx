<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuanGouTJ.aspx.cs" Inherits="EyouSoft.WAP.TuanGouTJ" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>团购订单</title>

<script src="/js/jq.mobi.min.js" type="text/javascript"></script>
<script src="js/jquery_cm.js" type="text/javascript"></script>
<script src="/js/table-toolbar.js" type="text/javascript"></script>
<script src="js/slogin.js" type="text/javascript"></script>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  <form id="form1" runat="server">
<div class="warp">
    
       <h2 class="mall_title">订单信息</h2>
    
       <div class="jq_cont">
            <h2 class="paddB"> <asp:Label ID="lblChanPinMingCheng" runat="server" Text=""></asp:Label></h2>
            <p>单价：¥<asp:Label ID="lblChanPinJiaGe" runat="server" Text=""></asp:Label><asp:HiddenField ID="hidChanPinJiaGe" runat="server" /></p>
            <p>数量：<span class="number"><i class="num-minus"></i><input id="GouMaiShu" name="GouMaiShu" type="tel" value="1"><i class="num-add"></i></span>(最多可购买<asp:Literal ID="shengyushu" runat="server"></asp:Literal>份)</p>
            <input id="chanpinshu" type="hidden" />
            <p>总额：<span class="font_yellow">¥<i class="font18"><span id="zongjia"><%= jsj%>元</span></i></span></p>
             <asp:HiddenField ID="hidpid" runat="server" />
       </div>

       <h2 class="mall_title">配送信息</h2>

       <div class="add_box add_box_no">
            <ul>
               <li>
                  <span class="label_name font14"><i class="font_red">*</i> 收件人</span>
                  <input id="GouMaiName" name="GouMaiName" type="text" class="u-input" value="收货人姓名" onfocus="javascript:if(this.value=='收货人姓名')this.value='';" onblur="javascript:if(this.value=='')this.value='收货人姓名';" ForeColor="#999999">
               </li>
               
               <li>
                  <span class="label_name font14"><i class="font_red">*</i> 手机</span>
                  <input id="GouMaiMoblie" name="GouMaiMoblie" type="text" class="u-input" value="收货人手机" onfocus="javascript:if(this.value=='收货人手机')this.value='';" onblur="javascript:if(this.value=='')this.value='收货人手机';" ForeColor="#999999">
               </li>

               <li>
                  <span class="label_name font14"><i class="font_red">*</i> 地址</span>
                  <input id="GouMaiAddress" name="GouMaiAddress" type="text" class="u-input" value="收货人地址" onfocus="javascript:if(this.value=='收货人地址')this.value='';" onblur="javascript:if(this.value=='')this.value='收货人地址';" ForeColor="#999999">
               </li>
            </ul>
       </div>
 
       <div class="padd cent"><input name="" type="button" class="y_btn" value="核对提交"></div>
        
     
  </div>
  </form>

  <div id="TiJiaoMask" class="user-mask" style="display:none;">
   <div class="h-mask-cnt" style="margin-top:200px;">
       
       <div class="cent font_yellow font16" style="padding-top:20px;">
            正在提交订单，请等待。。。
       </div>
          
   </div>
</div>
</body>
<script type="text/javascript">
    $(".num-minus").click(function() {
        var getNum = $(this).parent().find("input").eq(0);
        if (tableToolbar.getInt(getNum.val()) > 1) {//成人数量不能低于2人
            getNum.val(tableToolbar.getInt(getNum.val()) - 1);
        } else {
            getNum.val(1);
        }
        var danjia = $("#<%=hidChanPinJiaGe.ClientID%>").val();
        $("#zongjia").html(tableToolbar.getFloat(tableToolbar.getInt(getNum.val()) * tableToolbar.getFloat(danjia)) + "元");
    });
    $(".num-add").click(function() {
        var getNum = $(this).parent().find("input").eq(0);
        var shengyu = "<%=shengyu %>";
        if (tableToolbar.getInt(shengyu) >= tableToolbar.getInt(getNum.val()) + 1) {
            getNum.val(tableToolbar.getInt(getNum.val()) + 1);
        }
        else {
            alert("最多只能购买"+shengyu+"份");
        }
        var danjia = $("#<%=hidChanPinJiaGe.ClientID%>").val();
        $("#zongjia").html(tableToolbar.getFloat(tableToolbar.getInt(getNum.val()) * tableToolbar.getFloat(danjia)) + "元");
    });
    //$(".y_btn").click(function() { window.location.href = '/Login.aspx?rurl=' + encodeURIComponent(window.location.href); });
    $(".y_btn").click(function() {
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
                        data: $(".y_btn").closest("form").serialize(),
                        success: function(ret) {
                        if (ret.result == "1") {
                            $("#TiJiaoMask").toggle();
                                alert(ret.msg);
                                window.location.href = "/Member/DingDanList.aspx?OrderType=7";
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
            if ($("#GouMaiName").val() == "" || $("#GouMaiName").val() == "收货人姓名") {
                alert("收货人姓名不能为空！");
                $("#GouMaiName").focus();
                return false;
            }
            else {
                if (!/^[\u4e00-\u9fa5a-zA-Z_]+$/.test($("#GouMaiName").val())) {
                    alert('请填写正确的收货人姓名');
                    $("#GouMaiName").focus();
                    return false;
                }
            }
            if ($("#GouMaiMoblie").val() == "" || $("#GouMaiMoblie").val() == "收货人手机") {
                alert("收货人手机号码不能为空！");
                $("#GouMaiMoblie").focus();
                return false;
            }
            else {
                if (!/^(13|15|18|14)\d{9}$/.test($("#GouMaiMoblie").val())) {
                    alert('请填写正确的收货人手机号码');
                    $("#GouMaiMoblie").focus();
                    return false;
                }
            }
            if ($("#GouMaiAddress").val() == "" || $("#GouMaiAddress").val() == "收货人地址") {
                alert("收货人地址不能为空！");
                $("#GouMaiAddress").focus();
                return false;
            }
            return true;
        }
    };
</script>
</html>