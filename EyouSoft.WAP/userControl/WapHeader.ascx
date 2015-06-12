<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WapHeader.ascx.cs" Inherits="EyouSoft.WAP.userControl.WapHeader" %>
<link href="/css/Style.css?v20150609" rel="stylesheet" type="text/css"  media="screen"/>
<header>
    <a id="back_btn_a" href="javascript:window.history.go(-1);"><i class="returnico"></i></a>
    <h1><%=this.HeadText %></h1>
    <a id="menus" href="javascript:void(0);"><b class="icon_home"></b></a>
  </header>
<div data-div="head_div" class="head_div" style="display:none;">
      <div class="head_box">
          <ul>
              <li><a href="tel:<%= TelNum%>">联系电话</a></li>
              <li><a href="/default.aspx">返回首页</a></li>
              <li><a href="/Member/UserCenter.aspx">后台管理</a></li>
              <li><a href="/Login.aspx">注册登录</a></li>
          </ul>
      </div>
  </div><script type="text/javascript"> 
   $("#menus").click(function() {
        $("div[data-div=head_div]").toggle();
    });</script>