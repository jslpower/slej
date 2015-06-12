<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZuTuanHead.ascx.cs" Inherits="EyouSoft.WAP.userControl.ZuTuanHead" %>
<header>
    <i class="returnico" data-class="guanbi"></i>
    <h1><%=this.HeadText %></h1>
    <a id="zthead<%=HeadNum %>" href="javascript:void(0);"><b class="icon_home"></b></a>
  </header>
  <div data-div="zthead<%=HeadNum %>" class="head_div" style="display:none;">
      <div class="head_box">
          <ul>
              <li><a href="tel:<%= TelNum%>">联系电话</a></li>
              <li><a href="/default.aspx">返回首页</a></li>
              <li><a href="/Member/UserCenter.aspx">后台管理</a></li>
              <li><a href="/Login.aspx">注册登录</a></li>
          </ul>
      </div>
  </div>