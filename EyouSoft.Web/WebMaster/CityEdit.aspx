<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.CityEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑城市</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="../JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

</head>
<body>
    <form id="ce_form" runat="server">
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="18%" height="30" align="right">
                    <font color="red">*</font>所属省份：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:DropDownList runat="server" ID="ddlProvince" CssClass="inputselect" valid="required|isNo" noValue="0"
                        errmsg="省份不为空|请选择省份">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th width="18%" height="30" align="right">
                    <font color="red">*</font>城市名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="inputtext" MaxLength="20"
                        size="40" valid="required|isNo" noValue="0" errmsg="城市不为空|请选择省份"></asp:TextBox>
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

        var CityEdit = {
            save: function() {
                if (!ValiDatorForm.validator($("#<%=ce_form.ClientID %>").get(0), "parent")) {
                    return false;
                }
                $("#btnsave").html("提交中...").unbind("click").css({ "color": "#999999" });
                var data = {
                    action: '<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>',
                    cid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("cid") %>',
                    pid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("pid") %>',
                    save: "1"
                };

                $.newAjax({
                    url: "/WebMaster/CityEdit.aspx?" + $.param(data),
                    data: $("#btnsave").closest("form").serialize(),
                    dataType: "json",
                    cache: false,
                    type: "post",
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg, function() { CityEdit.BindBtn() });
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(parent.tableToolbar.errorMsg, function() { CityEdit.BindBtn() });
                    }
                });
            },
            BindBtn: function() {
                //绑定Add事件
                $("#btnsave").click(function() {
                    CityEdit.save();
                })

                $("#btnsave").html("保存").css({ "color": "" });
            }
        }

        $(document).ready(function() {
            CityEdit.BindBtn();
        })
    </script>

</body>
</html>
