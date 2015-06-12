<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProvinceEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ProvinceEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>省份编辑</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="../JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="18%" height="30" align="right">
                    <font color="red">*</font>省份名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" ID="txtProvinceName" MaxLength="20" CssClass="inputtext"
                        size="40" valid="required" errmsg="省份不为空"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="324" cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td width="90" height="40" align="center">
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btnsave">保存</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>

    <script type="text/javascript">

        var ProvinceEdit = {
            save: function() {
                if (!ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent")) {
                    return false;
                }
                $("#btnsave").html("提交中...").unbind("click").css({ "color": "#999999" });
                var data = {
                    action: '<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>',
                    pid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("pid") %>',
                    save: "1"
                };

                $.newAjax({
                    url: "/WebMaster/ProvinceEdit.aspx?" + $.param(data),
                    data: $("#btnsave").closest("form").serialize(),
                    dataType: "json",
                    cache: false,
                    type: "post",
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg, function() { ProvinceEdit.BindBtn() });
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(parent.tableToolbar.errorMsg, function() { ProvinceEdit.BindBtn() });
                    }
                });
            },
            BindBtn: function() {
                //绑定Add事件
                $("#btnsave").click(function() {
                    ProvinceEdit.save();
                })

                $("#btnsave").html("保存").css({ "color": "" });
            }
        }

        $(document).ready(function() {
            ProvinceEdit.BindBtn();
        })
    </script>

</body>
</html>
