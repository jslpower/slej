<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRouteDate.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.EditRouteDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <script src="../JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="../JS/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="99%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
            <tbody>
                <tr>
                    <td height="35" align="left" bgcolor="#e3f1fc">
                        <strong>提前报名天数：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox ID="txtTiqiandays" Enabled="false" CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="left" bgcolor="#e3f1fc">
                        <strong>计划人数：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox ID="txtPlanCount" Enabled="false" CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="left" bgcolor="#e3f1fc">
                        <strong>市场价：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        成人:
                        <asp:TextBox ID="txtShiadultprice" CssClass="inputtext formsize120" runat="server"></asp:TextBox>&nbsp;
                        儿童:
                        <asp:TextBox ID="txtShichildprice" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="left" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>结算价：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        成人:
                        <asp:TextBox ID="txtJieadultprice" valid="required|isMoney" errmsg="请填写成人结算价|价格格式有误"
                            CssClass="inputtext formsize120" runat="server"></asp:TextBox>&nbsp; 儿童:
                        <asp:TextBox ID="txtJiechlidprice" valid="required|isMoney" errmsg="请填写儿童结算价|价格格式有误"
                            CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="center" colspan="2">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="84" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:;" id="btn_save">保存</a>
                                    </td>
                                    <td width="114" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:;" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()"
                                            id="btn_close">关闭</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
    var iPage = {
        PageInit: function() {
            $("#btn_save").html("保存").css({ "color": "" });
            $("#btn_save").click(function() {
                iPage.PageSave();
                return false;
            })
        },
        PageSave: function() {

            var jieaduprice = $.trim($("#<%= txtJieadultprice.ClientID %>").val());
            var jieadultprice = $.trim($("#<%= txtJiechlidprice.ClientID %>").val());

            if (jieadultprice == "" && jieaduprice == "") {
                parent.tableToolbar._showMsg("请填写要修改的值");
                return false;
            }
            $("#btn_save").html("提交中").unbind("click").css({ "color": "#999999" });
            var data = {
                tourid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("tourid") %>',
                type: "save"
            };
            $.newAjax({
                type: "post",
                cache: false,
                url: "/WebMaster/EditRouteDate.aspx?" + $.param(data),
                data: $("#btn_save").closest("form").serialize(),
                dataType: "json",
                success: function(ret) {
                    //ajax回发提示
                    if (ret.result == "1") {
                        parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href });
                    }
                    else {
                        parent.tableToolbar._showMsg(ret.msg, function() { iPage.PageInit(); });
                    }
                },
                error: function() {
                    parent.tableToolbar._showMsg(tableToolbar.errorMsg, function() { iPage.PageInit(); });
                }
            });

        }
    }
    $(function() {
        iPage.PageInit();
    })
    
</script>

