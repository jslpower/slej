<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="GetMiMa.aspx.cs" Inherits="EyouSoft.Web.GetMiMa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="JS/ValiDatorForm.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<form id="form1">
<div class="mainbox">
    <table border="0px" width="600px" style=" margin-left:200px;">
    <tr style="background-color:#def6fa; height:30px;"><td colspan="2"><span style="font-size:16px; font-weight:bolder">重置登录密码</span></td></tr>
    <tr style="height:30px;"><td colspan="2"></td></tr>
    
    <tr style=" height:30px;">
    <td style="width:30%; text-align:right;">请输入登录名：</td>
    <td><input id="loginName" name="loginName" value="请输入手机号" onfocus="javascript:if(this.value=='请输入手机号')this.value='';" onblur="javascript:if(this.value=='')this.value='请输入手机号';" type="text" valid="required|isMobile" errmsg="请填写您的登录名！|登录名为手机号码！" class="inputbk formsize180" /></td>
    </tr>
    <tr style="height:30px;"><td colspan="2"></td></tr>
    <tr>
    <td colspan="2" style=" padding-left:200px;">
        <input type="button" id="btntijiao" class="user-btn" value="确认提交">
        </td>
    </tr>
    </table>       
</div>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<script type="text/javascript">
    var PageInfo = {
        Sava: function() {
            if (!PageInfo.CheckForm()) {
                return false;
            }
            var url = '/GetMiMa.aspx?type=update';
            PageInfo.GoAjax(url);
        },
        CheckForm: function() {
        return ValiDatorForm.validator($("#btntijiao").closest("form").get(0), "alert");
        },
        GoAjax: function(url) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#btntijiao").closest("form").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() {
                            location.href = "/Default.aspx";
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
        $("#btntijiao").click(function() {
                PageInfo.Sava(); return false;
            });
        }
    };
    $(function() {
        PageInfo.BindBth();
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
