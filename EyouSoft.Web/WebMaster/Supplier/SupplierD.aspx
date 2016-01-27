<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierD.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Supplier.SupplierD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="110" height="30" align="center">
                    单位名称:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtDanWeiMingCheng" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    单位简称:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtJC" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    联系人:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtLianXiRen" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    电话:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtDianHua" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    手机:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtShouJi" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    QQ:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtQQ" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    资质:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtZiZhi" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    邮箱:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtYouXiang" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    地址:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal ID="txtDiZhi" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="4">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td height="40" align="center" class="tjbtn02" style="padding-left: 50px;">
                                    <a href="javascript:history.go(-1);" align="center" style="text-align: center">返回</a>
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
