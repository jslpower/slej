<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.CompanyInfo"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <%--<tr class="lr_hangbg">
            <td align="right" style="width: 15%">
                加入我们：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtCompanyIntroduce" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                关于我们：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtAboutUs" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                联系方式：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtContact" class="editText"></asp:TextBox>
            </td>
        </tr>--%>
        <tr class="lr_hangbg">
            <td align="right">
                我要做分销商：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtFenXiao" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做分销商手机版：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtWapFenXiao" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做贵宾会员：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtGuiBin" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做贵宾会员手机版：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtWapGuiBin" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做普通会员：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtPuTong" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做普通会员手机版：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtWapPuTong" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要应聘专职：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtYingPin" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要应聘专职手机版：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtWapYingPin" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做供应商：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtGongYing" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                我要做供应商手机版：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtWapGongYing" class="editText"></asp:TextBox>
            </td>
        </tr>
        <%--<tr class="lr_hangbg">
            <td align="right">
                诚聘英才：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtJoinUs" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                法律声明：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtLegalDisclaimer" class="editText"></asp:TextBox>
            </td>
        </tr>--%>
        <tr class="lr_hangbg">
            <td align="right">
                版权信息：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtCopyright" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                E额宝说明：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtEbao" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                手机版E额宝说明：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="MoblieEBao" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                关于商旅E家：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtSLEJ" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                手机版关于商旅E家：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="MoblieSLEJ" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                免费代理申请条款：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="DaiLiTiaoKuan" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                系统操作手册：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="WapSet" class="editText"></asp:TextBox>
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
