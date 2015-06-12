<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.LinkEdit" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增</title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/swfupload/swfupload.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th width="120" height="30" align="right">
                    <font class="fred">*</font>链接名称：
                </th>
                <td align="left">
                    <input type="text" id="txtLinkText" valid="required" errmsg="链接名称必须填写!" class="formsize260 inputtext"
                        runat="server" name="txtLinkText" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>链接地址：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtLinkAddre" Text="http://"  valid="required|isUrl" errmsg="链接地址必须填写!|链接地址格式错误!" runat="server" CssClass="formsize260 inputtext" name="txtLinkAddre"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    链接图片：
                </th>
                <td align="left">
                    <uc1:UploadControl runat="server" ID="upload1" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    排序数字：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtSort" Text="0" runat="server" CssClass="formsize50 inputtext" name="txtSort"></asp:TextBox>
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
                    <a id="linkCancel" href="javascript:history.go(-1);">返回</a>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        $(function() {
            LinkEdit.PageInit();
            LinkEdit.BindBtn();
        })
        var LinkEdit = {
            PageInit: function() {
                $("input[readonly='readonly']").css({ "background-color": "#dadada" });

                swfUploadHandler.init({
                    movies: [window["<%=upload1.ClientID %>"]],
                    startFn: function() { $("#<%= btn.ClientID %>").unbind("click").html("正在提交").css({ "color": "#999999" }) /*开始上传事件*/ },
                    completeFn: function() {
                        var dotype = '<%=Request.QueryString["dotype"] %>';
                        var url = "/WebMaster/LinkEdit.aspx?type=save&dotype=" + dotype + "&id=" + '<%=Request.QueryString["id"] %>';
                        LinkEdit.GoAjax(url); /*完成上传事件*/
                    }
                });
            },
            BindBtn: function() {
                $("#<%=btn.ClientID %>").click(function() {

                    $(this).html("正在保存");

                    if (!LinkEdit.CheckForm()) {
                        return false;
                    }

                    var swfFile = window["<%=upload1.ClientID %>"];
                    if (swfFile != null && swfFile.getStats().files_queued > 0) {
                        swfFile.startUpload();
                    }
                    else {
                        var dotype = '<%=Request.QueryString["dotype"] %>';
                        var url = "/WebMaster/LinkEdit.aspx?type=save&dotype=" + dotype + "&id=" + '<%=Request.QueryString["id"] %>';
                        LinkEdit.GoAjax(url);
                    }

                    return false;
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
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/LinkList.aspx'; });
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
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "parent");
            }
        }
    </script>

    </form>
</body>
</html>
