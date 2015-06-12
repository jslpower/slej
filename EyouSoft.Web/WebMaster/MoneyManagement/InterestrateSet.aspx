<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterestrateSet.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.MoneyManagement.InterestrateSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

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
                        <span style="color: Red; font-size: 12px;">*</span><strong>每一万元获取积分：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox runat="server" ID="txtrate" CssClass="inputtext formsize180" MaxLength="50"
                            valid="required" errmsg="每万份收益金额!"></asp:TextBox>
                        <span style="color: Red; font-size: 12px;"></span><strong>元</strong>
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
                                    <asp:Button ID="btn_save" runat="server" Text="保 存" OnClick="btn_save_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
