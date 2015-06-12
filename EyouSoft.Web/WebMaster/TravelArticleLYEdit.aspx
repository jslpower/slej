<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelArticleLYEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TravelArticleLYEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言回复</title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th width="120" height="30" align="right">
                    留言人：
                </th>
                <td align="left">
                    <asp:Label ID="labLYRSJ" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th width="120" height="30" align="right">
                    留言内容：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtLiuYan" Enabled="false" ReadOnly="true" runat="server" valid="required" errmsg="留言内容不能为空" TextMode="MultiLine"
                        Columns="45" Rows="5" CssClass="inputarea formsize600"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    回复内容：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtHuiFu" runat="server" valid="required" errmsg="回复内容不能为空" TextMode="MultiLine"
                        Columns="45" Rows="5" CssClass="inputarea formsize600"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th height="30" align="right">
                    是否审核
                </th>
                <td align="left">
                    <asp:CheckBox ID="chk_shenhe" runat="server" Checked="true" />是
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
                    <a onclick="parent.Boxy.getIframeDialog(parent.Boxy.queryString('iframeId')).hide()"
                        id="linkCancel" href="javascript:;">关闭</a>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        $(function() {
            ObjPage.BindBtn();
        })
        var ObjPage = {
            BindBtn: function() {
                $("#<%=btn.ClientID %>").click(function() {

                    $(this).html("正在保存");

                    if (!ObjPage.CheckForm()) {
                        return false;
                    }

                    var dotype = '<%=Request.QueryString["dotype"] %>';
                    var url = '/WebMaster/TravelArticleLYEdit.aspx?type=save&dotype=" + dotype + "&tid=<%=EyouSoft.Common.Utils.GetQueryStringValue("tid") %>';
                    ObjPage.GoAjax(url);

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
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
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
