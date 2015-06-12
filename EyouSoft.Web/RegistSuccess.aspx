<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="RegistSuccess.aspx.cs" Inherits="EyouSoft.Web.RegistSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<!----mainbox------>
    <div class="mainbox">
    
      <div class="reg_box">
         
         <div class="reg_bar">
              
              <div class="reg_side">
                 <p class="txt">恭喜您，注册成功！以下信息极为重要，<br />请及时修改密码并妥善保存！</p>
                 <p class="font16 fontblue"><strong>登录帐号：<%= account%><br />初始密码：<%= password%></strong></p>
              </div>
                 
              <div class="user_side floatR">
                 <div class="title">用户登录</div>
                 <div class="userbox">
                     <h5>已经是会员/贵宾/代理，马上登录</h5>
                     <ul>
                         <li><span class="user-txt">账户：</span><input type="text" id="txtaccount" readonly="readonly" runat="server" class="inputbk formsize140" /></li>
                         <li><span class="user-txt">密码：</span><input id="txtpassword" readonly="readonly" runat="server" class="inputbk formsize140" /></li>
                         <%--<li class="padd"><a href="#" class="font_yellow">忘记密码，请点这里取回！</a></li>--%>
                         <li class="padd"><input type="button" value="马上登录" class="user-btn" onclick="login()" /></li>
                     </ul>
                 </div>
                 <div class="bot"></div>
              </div>
         
         </div>
 
         
      </div>
    
  </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<script type="text/javascript">
    function login() {
        location.href = "/Member/MemberInfo.aspx";
     }
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
