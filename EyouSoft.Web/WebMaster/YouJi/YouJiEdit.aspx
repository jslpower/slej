<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouJiEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.YouJi.YouJiEdit"
    ValidateRequest="false" %>

<%@ Register Src="../UserControl/FenXiang.ascx" TagName="FenXiang" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th width="120" height="30" align="right">
                    <font class="fred">*</font>分享标题：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtTitle" runat="server" valid="required" errmsg="标题不可为空!" CssClass="formsize260 inputtext"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd shipin" <%=shipinStyle %>>
                <th align="right">
                    链接地址：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtLink" runat="server" CssClass="formsize260 inputtext" name="txtAdvLink"
                        valid="isUrl" errmsg="链接格式错误!"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd temp">
                <th align="right">
                    分享内容：
                </th>
                <td colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtInfo" Height="60" name="txtInfo" runat="server"
                        CssClass="inputtext formsize800 kingbox"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center">
                    <asp:HiddenField ID="GongYSId" runat="server" />
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:;" id="btn">保存</a>
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a id="linkCancel" href="YouJiList.aspx">返回</a>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        var pageOpt = {
            GoAjax: function(url, obj) {
                $(obj).unbind("click");
                KEditer.sync();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = "YouJiList.aspx"; });
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
                return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DelImg: function(obj) {
                $(obj).parent().prev("img").remove();
                $(obj).parent().remove();
            }
        };
        $(function() {
            KEditer.init("<%=txtInfo.ClientID %>", { height: "280px", items: keSimple_HaveImage });

            $("#btn").click(function() {
                if (pageOpt.CheckForm()) {
                    $(this).html("提交中");
                    pageOpt.GoAjax('YouJiEdit.aspx?type=save&dotype=<%=Request.QueryString["dotype"] %>&youjid=<%=Request.QueryString["youjid"] %>', $(this));
                }
            })

        })
       
    </script>

    </form>
</body>
</html>
