<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhiFuMiMa.aspx.cs" Inherits="EyouSoft.WAP.Member.ZhiFuMiMa" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>会员中心</title>
<script src="/js/jq.mobi.min.js" type="text/javascript"></script>
<style type="text/css">
.user_form li{padding-left:130px;}
</style>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  <form id="form1">
  <div class="warp">
  
    <div class="user_form">
       <ul>
           <li>
              <span class="label_name">旧支付密码</span>
              <input id="oldword" name="oldword" type="password" class="u-input" placeholder="初始密码为您的系统登陆密码" />
           </li>
           <li>
              <span class="label_name">新支付密码</span>
              <input id="newword" name="newword"  type="password" class="u-input" placeholder="6位以上的数字或字母组合"/>
           </li>
           <li>
              <span class="label_name">确认新支付密码</span>
              <input id="twoword" name="twoword"  type="password" class="u-input" placeholder="6位以上的数字或字母组合"/>
           </li>
       </ul>
    </div>
     
    <div class="padd cent"><input type="button" class="y_btn" value="保存" /></div>
     
     
  </div>
  </form>

  
</body>
<script type="text/javascript">
    var PageInfo = {
        Sava: function() {
            if (!PageInfo.CheckForm()) {
                return false;
            }
            var url = '/Member/ZhiFuMiMa.aspx?type=update';
            PageInfo.GoAjax(url);
        },
        CheckForm: function() {
            if ($("#oldword").val() == "") {
                alert("旧支付密码不能为空！");
                $("#oldword").focus();
                return false;
            }
            else if ($("#newword").val() == "" || $("#newword").val().length < 6) {
                alert("新支付密码不能为空且长度大于6位！");
                $("#newword").focus();
                return false;
            }
            else if ($("#twoword").val() == "" || $("#twoword").val().length < 6) {
                alert("确认新支付密码不能为空且长度大于6位！");
                $("#twoword").focus();
                return false;
            }
            else if ($("#newword").val() != $("#twoword").val()) {
                alert("两次输入的新支付密码不同，请确认！");
                return false;
            }
            else {
                return true;
            }
        },
        GoAjax: function(url) {
            $.ajax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#form1").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        alert(ret.msg);
                        window.location.href = "/Member/YuEGuanLi.aspx";
                    }
                    else {
                        alert(ret.msg);
                    }
                },
                error: function() {
                    alert("修改失败");
                }
            });
        },
        BindBth: function() {
            $(".y_btn").click(function() {
                PageInfo.Sava(); return false;
            });
        }
    };
    $(function() {
        PageInfo.BindBth();
    });
    </script>
</html>
