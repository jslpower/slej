<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EBaoInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.EBaoInfo"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公司信息</title>
    <link href="/Css/webmaster/manager.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="98%" border="1" align="center" cellpadding="3" cellspacing="0" bordercolor="#CCCCCC"
        id="tableInfo">
        <tr class="lr_hangbg">
            <td align="right">
                什么是E额宝：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoSSM" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝余额管理：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoYEGL" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝充值明细：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoCZMX" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝购买明细：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoGMMX" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝返利明细：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoFLMX" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝提现明细：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoTXMX" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我的下级分销奖：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoFXJ" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝综合明细：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoZHMX" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                系统交易总明细：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoZMX" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝积分增值：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEBaoJFZZ" class="editText"></asp:TextBox>
            </td>
        </tr>
        <!--<tr class="lr_hangbg">
            <td align="right">
                统计代码：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtStatistical" TextMode="MultiLine" Columns="100"></asp:TextBox>
            </td>
        </tr>-->
        <tr>
            <td height="35" colspan="2" align="center" bgcolor="#FFFFFF">
                <table cellspacing="0" cellpadding="0" border="0" align="center">
                    <tbody>
                        <tr>
                            <td height="20" align="center" class="tjbtn02">
                                <asp:LinkButton runat="server" ID="btnSave" OnClick="btnSave_Click">保存</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    </form>

    <script type="text/javascript">
        var CompanyInfo = {
            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        items: keSimple,
                        height: $(this).attr("data-height") == undefined ? "360px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "680px" : $(this).attr("data-width")
                    });
                });
            },
            CheckForm: function() {
                KEditer.sync();

                return true;
            }
        };

        $(document).ready(function() {

            CompanyInfo.InitEdit();

            $("#<%= btnSave.ClientID %>").click(function() {
                return CompanyInfo.CheckForm();
            });
        });
    </script>

</body>
</html>
