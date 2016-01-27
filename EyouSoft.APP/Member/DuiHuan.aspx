<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DuiHuan.aspx.cs" Inherits="EyouSoft.WAP.Member.DuiHuan" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>E额宝增值管理</title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
<style>
.user_form li{ padding-left:115px;}
</style>
</head>

<body>

   <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="E额宝增值管理" />
  <form runat="server" id="form1">
  <div class="warp">
        <div class="paddL paddT">
            E额宝增值管理</div>
        <div class="jq_tab zhifu_tab mt10" id="n4Tab">
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                    <div class="user_form">
                        <ul>
                            <li><span class="label_name">兑换积分</span>
                                <input name="JiFenNum" type="text" class="u-input" id="JiFenNum" />
                            </li>
                            <li style="padding-left:10px;" class="font_yellow font14">您最高可兑换<asp:Literal ID="JiFen" runat="server"></asp:Literal>积分<asp:HiddenField ID="JiFenTop" runat="server" /></li>
                        </ul>
                    </div>
                    <div class="padd cent">
                        <input name="" type="button" class="y_btn" value="确认兑换" id="btn" /></div>
                </div>
            </div>
        </div>
    </div>
  </form>
  <script type="text/javascript">
      var PageInfo = {
          Sava: function() {
              if (!PageInfo.CheckForm()) {
                  return false;
              }
              var url = '/Member/DuiHuan.aspx?type=add';
              PageInfo.GoAjax(url);
          },
          CheckForm: function() {
              if ($("#JiFenNum").val() == "") {
                  alert("兑换积分不能为空！");
                  $("#JiFenNum").focus();
                  return false;
              }
              else {
                  if (!/^\d+(\.\d+)?$/.test($("#JiFenNum").val())) {
                      alert('请填写正确的兑换积分');
                      $("#JiFenNum").focus();
                      return false;
                  }
                  else {
                      var jifentop = $("#<%= JiFenTop.ClientID%>").val();
                      if (parseFloat(jifentop) < parseFloat($("#JiFenNum").val())) {
                          alert('您输入的兑换积分超过您的现有积分');
                          $("#JiFenNum").focus();
                          return false;
                      }
                  }
              }
              return true;
          },
          GoAjax: function(url) {
              //KEditer.sync();
              $.ajax({
                  type: "post",
                  cache: false,
                  url: url,
                  dataType: "json",
                  data: $("#<%=form1.ClientID %>").serialize(),
                  success: function(ret) {
                  if (ret.result == "1") {
                          alert(ret.msg)
                          parent.location.href = "/member/ZengZhi.aspx";
                      }
                      else {
                          alert(ret.msg);
                      }
                  },
                  error: function() {
                      alert(tableToolbar.errorMsg);
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