<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.AdvEdit" %>

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
                    <font class="fred">*</font>广告标题：
                </th>
                <td align="left">
                    <input type="text" id="txtAdvTitle" valid="required" errmsg="广告标题必须填写!" class="formsize260 inputtext"
                        runat="server" name="txtAdvTitle" />
                    <input type="hidden" id="hidClick" runat="server" value="0" />
                </td>
            </tr>
            <%if (UserInfo.LeiXing != WebmasterUserType.代理商用户)
              { %>
           <tr class="odd">
                <th width="120" height="30" align="right">
                    广告位置：
                </th>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlAreaId" class="inputselect">
                    </asp:DropDownList>
                </td>
            </tr>
            <%} %>
            <tr class="odd">
                <th align="right">
                    链接地址：
                </th>
                <td align="left">
                    <asp:TextBox ID="txtAdvLink" runat="server" CssClass="formsize260 inputtext" name="txtAdvLink"></asp:TextBox>
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
                    <asp:TextBox ID="txtSort" runat="server" Text="0" CssClass="formsize50 inputtext"
                        name="txtSort"></asp:TextBox>
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
            AdvEdit.PageInit();
            AdvEdit.BindBtn();
        })
        var AdvEdit = {
            PageInit: function() {
                $("input[readonly='readonly']").css({ "background-color": "#dadada" });

                swfUploadHandler.init({
                    movies: [window["<%=upload1.ClientID %>"]],
                    startFn: function() { $("#<%= btn.ClientID %>").unbind("click").html("正在提交").css({ "color": "#999999" }) /*开始上传事件*/ },
                    completeFn: function() {
                        var dotype = '<%=Request.QueryString["dotype"] %>';
                        var url = "/WebMaster/AdvEdit.aspx?type=save&dotype=" + dotype + "&id=" + '<%=Request.QueryString["id"] %>';
                        AdvEdit.GoAjax(url); /*完成上传事件*/
                    }
                });
            },
            BindBtn: function() {
                $("#<%=btn.ClientID %>").click(function() {

                    $(this).html("正在保存");

                    if (!AdvEdit.CheckForm()) {
                        $(this).html("保存");
                        return false;
                    }

                    var swfFile = window["<%=upload1.ClientID %>"];
                    if (swfFile != null && swfFile.getStats().files_queued > 0) {
                        swfFile.startUpload();
                    }
                    else {
                        var dotype = '<%=Request.QueryString["dotype"] %>';
                        var url = "/WebMaster/AdvEdit.aspx?type=save&dotype=" + dotype + "&id=" + '<%=Request.QueryString["id"] %>';
                        AdvEdit.GoAjax(url);
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
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/AdvList.aspx'; });
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
                return ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "alert");
            }
        }
    </script>

    </form>
</body>
</html>
