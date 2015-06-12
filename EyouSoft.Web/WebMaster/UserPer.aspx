<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPer.aspx.cs" Inherits="EyouSoft.Web.WebMaster.UserPer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑管理用户权限信息</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <style>
        .hr_5
        {
            clear: both;
            font-size: 1px;
            line-height: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; width: 97%; margin: 5px auto; background-color: #ffffff">
        <%=PowerStr %>
    </div>
    <div style="text-align: center; width: 97%; margin: 10px auto; background-color: #ffffff">
        <table cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td height="40" align="center" class="tjbtn02">
                        <asp:PlaceHolder ID="isPriv" runat="server"><a href="javascript:;" id="btnSave">保存</a>
                        </asp:PlaceHolder>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="hr_10">
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var RolePowerConfig = {
            UnBindBtn: function() {
                $("#btnSave").unbind("click");
                $("#btnSave").css("background-position", "0 -62px");
            },
            //按钮绑定事件
            BindBtn: function() {
                $("#btnSave").bind("click");
                $("#btnSave").text("保存");
                $("#btnSave").css("background-position", "0-31px");
                $("#btnSave").click(function() {
                    RolePowerConfig.Save();
                    return false;
                });
            },
            //提交表单
            Save: function() {
                $("#btnSave").text("提交中...");
                RolePowerConfig.UnBindBtn();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: '/WebMaster/UserPer.aspx?dotype=save&id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                    data: $("#btnSave").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/UserList.aspx' });
                        } else {
                            tableToolbar._showMsg(ret.msg);
                            RolePowerConfig.BindBtn();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg("操作失败，请稍后再试!");
                        RolePowerConfig.BindBtn();
                    }
                });
            }
        };
        $(function() {
            $("[name='chkAll']").click(function() {
                var MenuId = $(this).attr("value");
                var Checked = $(this).attr("checked");
                $("[MenuId='" + MenuId + "']").each(function() {
                    $(this).attr("checked", Checked);
                });
            });

            $("#btnSave").click(function() {
                var msg = "";
                var IsSelected = false;
                var chkMenu = document.getElementsByName("chkMenu");
                for (var i = 0; i < chkMenu.length; i++) {
                    if (chkMenu[i].checked == true) {
                        IsSelected = true;
                        break;
                    }
                }
                if (!IsSelected) {
                    msg = msg + "请选择权限!<br/>";
                }
                if (msg != "") {
                    tableToolbar._showMsg(msg);
                    return false;
                }
                RolePowerConfig.Save();
            });
        });
        
    </script>

</body>
</html>
