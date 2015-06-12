<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaiXu.aspx.cs" Inherits="EyouSoft.Web.WebMaster.PaiXu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增</title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/swfupload/swfupload.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th width="120" height="30" align="right">
                    <font class="fred">*</font>序号：
                </th>
                <td align="left">
                    <input type="text" id="XuHao" valid="required|isNumber" errmsg="序号必须填写!|序号必须是大于0的正整数！" class="formsize260 inputtext"
                        name="XuHao" value=<%= xuhao %> />
                </td>
            </tr>
        </tbody>
    </table>
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center">
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:;" id="btn" runat="server">保存</a>
                </td>
                <td height="40" align="center" class="tjbtn02">
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        $(function() {

            LinkEdit.BindBtn();
        })
        var LinkEdit = {
            BindBtn: function() {
                $("#<%=btn.ClientID %>").click(function() {

                    $(this).html("正在保存");

                    if (!LinkEdit.CheckForm()) {
                        return false;
                    }

                    var url = "/WebMaster/PaiXu.aspx?dotype=save&type=" + '<%=Request.QueryString["type"] %>' + "&id=" + '<%=Request.QueryString["id"] %>';
                    LinkEdit.GoAjax(url);

                })
            },
            GoAjax: function(url) {
                $("#<%=btn.ClientID %>").unbind("click");
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                    parent.tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "parent");
            }
        }
    </script>

    </form>
</body>
</html>
