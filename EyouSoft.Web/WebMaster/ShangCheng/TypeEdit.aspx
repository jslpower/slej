<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShangCheng.TypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/swfupload/swfupload.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4"
            align="center">
            <tbody>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>类别名称：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox runat="server" ID="txtLeiBie" CssClass="inputtext formsize180" MaxLength="20"
                            valid="required" errmsg="请填写类别名称"></asp:TextBox>
                    </td>
                </tr>
                <tr runat="server" id="SecondType" visible="false">
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        所属分类：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:DropDownList ID="ddlLeiBie" runat="server" CssClass="inputselect"  valid="required" errmsg="请选择类别名称">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>描述：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox TextMode="MultiLine" ID="txtMiaoShu" Height="60" name="txtMiaoShu" runat="server"
                            CssClass="inputtext formsize450"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4"
            align="center">
            <tr>
                <td height="30" align="center">
                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn_save">保存</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var pageData = {
            parm: { dotype: '<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>', id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>' },
            CheckForm: function() {
                return ValiDatorForm.validator($("#btn_save").closest("form").get(0), "alert");
            },
            pageSave: function() {
                $.ajax({
                    type: "post",
                    url: "/WebMaster/ShangCheng/TypeEdit.aspx?save=save&" + $.param(pageData.parm),
                    dataType: "json",
                    data: $("#btn_save").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/ShangCheng/TypeList.aspx'; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        }
        $(function() {
            $("#btn_save").click(function() { if (pageData.CheckForm()) { pageData.pageSave() } })
        })
    </script>

</body>
</html>
