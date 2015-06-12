<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="EyouSoft.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>杭州金奥国际旅行社-管理登陆</title>
    <link href="../Css/login.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="login_box">
    
       <div class="login_logo"><img src="/images/logo.png" width="287" height="50" /></div>
    
       <div class="login_form">
          <ul>
             <li><em class="name"></em> <input type="text" name="t_u" id="t_u" /></li>
             <li><em class="mima"></em> <input type="password" name="t_p" id="t_p"/></li>
          </ul>
          
          <div class="login_btn">
              <asp:LinkButton ID="btnLogin" runat="server" onclick="btnLogin_Click" class="btn01">登录</asp:LinkButton><a href="#" class="btn02" id="chongzhi">重置</a>
          <%--<asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text=" 登  录 " class="btn01" />--%>
             <%--<a href="#" class="btn01">登录</a>
             <a href="#" class="btn02">重置</a>
          </div>--%>
          
       </div>
       
    </div>
    </div>
    
    <div class="login_bot">版权所有 杭州金奥国际旅行社有限公司  备案证编号：浙ICP备00000000号-1  许可证号：L-ZJ01409
<br />地址：杭州市西湖区文三路569号康新商务大厦17楼1号厅  服务热线：400-6588-180</div>
    
    </form>

    <script type="text/javascript">

//        function EnterPress() {
//            if (window.event.keyCode == 13) {
//                $("#<%=btnLogin.ClientID%>").click();
//            }
//        }

        function WebForm_OnSubmit_Validate() {
            if ($.trim($("#t_u").val()) == "") {
                alert('用户名不可为空！');
               $("#t_u").focus();
                return false;
            }
            if ($.trim($("#t_p").val()) == "") {
                alert('密码不可为空！');
                $("#t_p").focus();
                return false;
            }
            return true;
        }

        $(document).ready(function() {
            $("#t_u").focus();
            $("#<%=btnLogin.ClientID %>").bind("click", function() { return WebForm_OnSubmit_Validate(); });
            $("#chongzhi").bind("click", function() { $("#t_u").val(""); $("#t_p").val(""); });
        });

//        $(function() {
//        $("#t_u").focus(function() {
//        if ($('#t_u').val() == "请输入用户名") { $('#t_u').val(""); }
//            });
//            $("#t_u").blur(function() {
//            if ($('#t_u').val() == "") { $('#t_u').val("请输入用户名"); }
//            });
//        });
    </script>

</body>
</html>
