<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XieYi.aspx.cs" Inherits="EyouSoft.Web.WebMaster.XieYi"   ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网站协议</title>
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
                网站协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtXieYi" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                签证协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtVisa" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                门票协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtTicket" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                酒店协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtHotel" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                租车协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtZuChe" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                商城协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtShop" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                出境协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtChuJing" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                短线协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtDuanXian" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                团购协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtTuanGou" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                报价协议：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtBaoJia" class="editText"></asp:TextBox>
            </td>
        </tr>
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
    </table><br /><br />
    </form>

    <script type="text/javascript">
        var CompanyInfo = {
            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        items: keSimple_HaveImage,
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
