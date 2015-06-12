<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="MyTiXian.aspx.cs" Inherits="EyouSoft.Web.Member.MyTiXian" %>
<%@ Register src="/UserControl/UserLeft.ascx" tagname="UserLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />
<script type="text/javascript" src="/js/validatorform.js"></script>
<script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>
<script src="/Js/menu_min.js"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>
<style type="text/css">
.doti
{
background-color:#c1def0;
border: #c1def0 solid 1px;
text-align: right;
font-size: 12px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
<uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <form id="form1" runat="server">
    <div class="user_right">
          <div class="title_bar">
            <h4>&gt; 账户提现</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 账户提现</span></div>
              <table width="100%" border="0" class="tableList margin_T10">
              <tr style="height:40px;"><td width="25%" align="right"><span style="color:Red">*</span>开户银行：</td>
              <td width="75%">
                  <input id="KaihuHang" name="KaihuHang" type="text" class="input_bluebk formsize240" valid="required" errmsg="请填写您的开户银行!"/>
              </td>
              </tr>
              <tr style="height:40px;"><td width="25%" align="right"><span style="color:Red">*</span>开户姓名：</td>
              <td width="75%">
              <input id="KaiHuMing" name="KaiHuMing" type="text" class="input_bluebk formsize240" valid="required" errmsg="请填写您的开户姓名!"/>
              </tr>
              <tr style="height:40px;"><td width="25%" align="right"><span style="color:Red">*</span>银行帐号：</td>
              <td width="75%">
              <input id="ZhangHao" name="ZhangHao" type="text" class="input_bluebk formsize240" valid="required" errmsg="请填写您的银行帐号!"/>
              </td>
              </tr>
              <tr style="height:40px;"><td width="25%" align="right"><span style="color:Red">*</span>提现金额：</td>
              <td width="75%">
              <input id="TixianJinE" name="TixianJinE" type="text" class="input_bluebk formsize240" valid="required|isMoney" errmsg="请填写您要提现的金额!|请填写您要提现的金额！" value="<%= yuetishi%>" onfocus="javascript:if(this.value=='<%= yuetishi%>')this.value='';" onblur="javascript:if(this.value=='')this.value='<%= yuetishi%>';" ForeColor="#999999" style="color:#a4a4a4"/> <span style="color:Red">提现金额必须大于100且为整数</span>
              </td>
              </tr>
              <tr style="height:40px;"><td width="25%" align="right">备注信息：</td>
              <td width="75%">
                  <textarea id="beizhu" name="beizhu" cols="20" rows="4" class="input_bluebk formsize400" style="height:120px;"></textarea>
              </tr>
              </table>
            <div class="u-btn tjbtn02" style="padding-top:15px;padding-left:300px;">
                <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" >保存 >></asp:LinkButton>--%>
           <a href="javascript:;" id="btn">保存 >></a>
              <%--<a href="#" onclick="">保存 >></a>--%>
          </div>
</div>

</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
<script type="text/javascript">
        var PageInfo = {
            Sava: function() {
                if (!PageInfo.CheckForm()) {
                    return false;
                }
                var url = '/Member/MyTiXian.aspx?type=tixian';
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
                                location.href = "/Member/UserTransaction.aspx";
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