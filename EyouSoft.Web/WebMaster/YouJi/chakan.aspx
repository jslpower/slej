<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chakan.aspx.cs" Inherits="EyouSoft.Web.WebMaster.YouJi.chakan" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    </title><link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" /><link
        href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" /><link href="/Css/swfupload/default.css"
            rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th width="120" height="30" align="right">
                    标题：
                </th>
                <td align="left">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    链接地址：
                </th>
                <td align="left">
                    <asp:Literal ID="ltrLink" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    内容：
                </th>
                <td align="left">
                    <asp:Repeater ID="rptlist" runat="server">
                        <ItemTemplate>
                            <div class="line_xx_cont">
                                <p>
                                    <img src="<%#  Eval("ImgFile") %>" />
                                </p>
                                <p>
                                    <%# Eval("XingChengContent")%>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </tbody>
    </table>
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center" class="tjbtn02">
                    <a href="YouJiList.aspx">返回</a>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
