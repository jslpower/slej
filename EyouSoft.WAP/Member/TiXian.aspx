<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiXian.aspx.cs" Inherits="EyouSoft.WAP.Member.TiXian" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>账户提现</title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
<style>
.user_form li{ padding-left:115px;}
</style>
</head>

<body>

   <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="账户提现" />
  <form>
  <div class="warp">
  
    <div class="user_form">
       <ul>
           <li>
              <span class="label_name">开户银行</span>
              <input id="KaihuHang" name="KaihuHang" type="text" class="u-input" placeholder="填写您的开户银行!"/>
           </li>
         
           <li>
              <span class="label_name">开户姓名</span>
              <input id="KaiHuMing" name="KaiHuMing" type="text" class="u-input" placeholder="填写您的开户姓名!"/>
           </li>
         
           <li>
              <span class="label_name">银行账号</span>
              <input id="ZhangHao" name="ZhangHao" type="text" class="u-input" placeholder="填写您的银行帐号!"/>
           </li>
          
           <li>
              <span class="label_name">提现金额</span>
              <input id="TixianJinE" name="TixianJinE" type="text" class="u-input" placeholder="<%= yuetishi%>"/>
           </li>
          
           <li>
              <span class="label_name">备注信息</span>
              <textarea id="beizhu" name="beizhu" cols="20" rows="4" class="u-input" style="height:120px;"></textarea>
           </li>
           
       </ul>
    </div>
     
    <div class="padd cent"><input id="btn" type="button" class="y_btn" value="保存"></div>
     
  </div>
  </form>
  <script type="text/javascript">
      var PageInfo = {
          Sava: function() {
              if (!PageInfo.CheckForm()) {
                  return false;
              }
              var url = '/Member/TiXian.aspx?type=tixian';
              PageInfo.GoAjax(url);
          },
          CheckForm: function() {
              if ($("#KaihuHang").val() == "") {
                  alert("开户银行不能为空！");
                  $("#KaihuHang>").focus();
                  return false;
              }
              if ($("#KaiHuMing").val() == "") {
                  alert("开户姓名不能为空！");
                  $("#KaiHuMing>").focus();
                  return false;
              }
              if ($("#ZhangHao").val() == "") {
                  alert("银行账号不能为空！");
                  $("#ZhangHao>").focus();
                  return false;
              }
              if ($("#TixianJinE").val() == "") {
                  alert("提现金额不能为空！");
                  $("#TixianJinE").focus();
                  return false;
              }
              else {
                  if (!/^\d+(\.\d+)?$/.test($("#TixianJinE").val())) {
                      alert('请填写正确的提现金额');
                      $("#TixianJinE").focus();
                      return false;
                  }
                  else {
                      if (parseFloat($("#TixianJinE").val()) < 100) {
                          alert('提现金额必须大于等于100元');
                          $("#TixianJinE").focus();
                          return false;
                      }
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
                  data: $("#btn").closest("form").serialize(),
                  success: function(ret) {
                      if (ret.result == "1") {
                          alert(ret.msg)
                          location.href = "/Member/YuEGuanLi.aspx";
                      }
                      else {
                          alert(ret.msg);
                      }
                  },
                  error: function() {
                      alert("提现失败！");
                  }
              });
          },
          BindBth: function() {
              $("#btn").click(function() {
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