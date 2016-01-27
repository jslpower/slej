<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetMiMa.aspx.cs" Inherits="EyouSoft.WAP.GetMiMa" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>重置密码</title>


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  <form>
  <div class="warp">
  
     <div class="reg_step">
        <ul class="clearfix">
           <li class="jiantou font_yellow">重置密码</li>
        </ul>
     </div>
     
     <div class="user_form">
        <ul>
           <li>
              <span class="label_name">用户名</span>
             <input id="txt_shouji" name="txt_shouji" type="tel" class="u-input" value="请输入11位手机号"
                        onfocus="javascript:if(this.value=='请输入11位手机号')this.value='';" onblur="javascript:if(this.value=='')this.value='请输入11位手机号';" />
           </li>
        </ul>
     </div>
     
     <div class="padd cent"><input id="btntijiao" type="button" class="y_btn" value="确认重置"></div>
     
     
  </div>
  </form>

  <script type="text/javascript">
      var PageInfo = {
          Sava: function() {
              if (!PageInfo.CheckForm()) {
                  return false;
              }
              $("#btntijiao").val("正在重置");
              var url = '/GetMiMa.aspx?type=update';
              PageInfo.GoAjax(url);
          },
          CheckForm: function() {
              if ($("#txt_shouji").val() == "") {
                  alert("用户名不能为空！");
                  $("#txt_shouji").focus();
                  return false;
              }
              else {
                  if (!/^(13|15|18|14)\d{9}$/.test($("#txt_shouji").val())) {
                      alert('请填写正确的用户名');
                      $("#txt_shouji").focus();
                      return false;
                  }
              }
              return true;
          },
          GoAjax: function(url) {
              $.ajax({
                  type: "post",
                  cache: false,
                  url: url,
                  dataType: "json",
                  data: $("#btntijiao").closest("form").serialize(),
                  success: function(ret) {
                      if (ret.result == "1") {
                          alert(ret.msg);
                          location.href = "/Default.aspx";
                      }
                      else {
                          alert(ret.msg);
                      }
                  },
                  error: function() {
                      alert("重置失败，请重试！");
                  }
              });
          },
          BindBth: function() {
              $("#btntijiao").click(function() {
                  PageInfo.Sava(); return false;
              });
          }
      };
    $(function() {
        PageInfo.BindBth();
    });
</script>
</body>
</html>
