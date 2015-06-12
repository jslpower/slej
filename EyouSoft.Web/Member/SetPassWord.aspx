<%@ Page Title="修改支付密码" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="SetPassWord.aspx.cs" Inherits="EyouSoft.Web.Member.SetPassWord" %>
<%@ Register src="/UserControl/UserLeft.ascx" tagname="UserLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/Css/style.css" rel="stylesheet" />
<script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/validatorform.js"></script>
<script src="/Js/menu_min.js"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
<uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
<form id="form1" runat="server">
<div class="user_right">
          <div class="title_bar">
            <h4>&gt; 账户余额</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 账号余额</span></div>
          <div class="user_Rbox margin_T10">
             <div class="R_title">资金账户</div>
              <div class="zhifu_box">
                <ul class="fixed">
                 <li><span>&nbsp;旧的支付密码：</span>
                      <input name="input" id="oldpassword" type="password" runat="server" maxlength="20"  class="input_bluebk formsize180" valid="required" errmsg="请填写您的旧密码!" /><font class="fontyellow">第一次修改，您的支付密码即为您的登录密码</font>
                  </li>
                  <li><span>&nbsp;新的支付密码：</span>
                      <input name="input" id="passwordone" type="password" runat="server" maxlength="20"  class="input_bluebk formsize180" valid="required|isNumOrEng" errmsg="请填写您的新密码!|新密码只能是数字或字母的组合！"/> <font class="fontyellow">6位以上的数字或字母组合</font>
                  </li>
                  <li><span>&nbsp;确认支付密码：</span>
                      <input name="input" id="passwordtwo" type="password" runat="server" maxlength="20" class="input_bluebk formsize180"  valid="required|isNumOrEng" errmsg="请再次填写您的新密码!|确认新的密码只能是数字或字母的组合！"/> <font class="fontyellow">6位以上的数字或字母组合</font>
                  </li>
                </ul>
              </div>
            <div class="u-btn tjbtn02">
                <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">保存 >></asp:LinkButton>--%>
           <a href="javascript:;" id="btn">保存 >></a>
           <%--   <a href="#" onclick="" id="">保存 >></a>--%>
              <%--<a href="#">返回 >></a>--%>
          </div>
          
          </div>
</div></form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
    <script type="text/javascript">
        var PageInfo = {
            Sava: function() {
                if (!PageInfo.CheckForm()) {
                    return false;
                }
                var url = '/Member/SetPassWord.aspx?type=update';
                PageInfo.GoAjax(url);
            },
            CheckForm: function() {
            return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                                parent.location.href = parent.location.href;
                            });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
