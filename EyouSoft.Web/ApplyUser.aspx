<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyUser.aspx.cs" Inherits="EyouSoft.Web.ApplyUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery-1.4.2.min.js" type="text/javascript"></script>

    <link href="/Css/style.css" rel="stylesheet" />

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top: 20px">
        <div style="text-align: center;">
            <span style="font-size: 16px; font-weight: bolder; color: Red;">购买商旅e家独立代理网站：做<asp:Literal
                ID="litApplyType" runat="server"></asp:Literal>!</span></div>
        <table width="100%" border="0" class="tableList margin_T10">
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    姓名：
                </td>
                <td width="75%">
                    <input id="MyName" name="MyName" type="text" class="input_bluebk formsize180" valid="required|isName"
                        errmsg="姓名不能为空|请正确填写姓名!" />
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    手机号码：
                </td>
                <td width="75%">
                    <input id="MyMobile" name="MyMobile" type="text" class="input_bluebk formsize180"
                        valid="required|isMobile" errmsg="请输入手机号码!|请输入正确的手机号码" />
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    公司名称：
                </td>
                <td width="75%">
                    <input id="CompanyName" name="CompanyName" type="text" class="input_bluebk formsize180"
                        valid="required" errmsg="请正确填写公司名称!" />
                </td>
            </tr>
        </table>
    </div>
    <div style="padding-top: 20px; text-align: center;">
        <a href="#" class="loginbtn" id="btn">确认提交</a></div>
    </form>

    <script type="text/javascript">
        var PageInfo = {
            Sava: function() {
                if (!PageInfo.CheckForm()) {
                    return false;
                }
                var url = '/ApplyUser.aspx?type=Apply&Classid=<%= EyouSoft.Common.Utils.GetQueryStringValue("Classid")%>';
                PageInfo.GoAjax(url);
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#btn").closest("form").get(0), "parent");
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

</body>
</html>
