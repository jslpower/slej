<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTGGysList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MyTGGysList" %>


<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>


</head>
<body>
    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="from1">
                    <div class="searchbox">
                        <label>
                            网店名称：</label>
                        <input type="text" class="inputtext" name="WebsiteName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("WebsiteName") %>" />
                        <label>
                            公司名称：</label>
                        <input type="text" class="inputtext" name="CompanyName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CompanyName") %>" />
                        <label>
                            联系人：</label>
                        <input type="text" class="inputtext" name="MemberName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("MemberName") %>" />
                        <label>
                            联系人手机：</label>
                        <input type="text" class="inputtext" name="Mobile" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("Mobile") %>" />
                        <input type="submit" class="search-btn" value="" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th align="center">
                        网店名称
                    </th>
                    <th align="center">
                        网店域名
                    </th>
                    <th align="center">
                        公司名称
                    </th>
                    <th align="center">
                        联系人
                    </th>
                    <th align="center">
                        联系人手机
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="left">
                                <%#Eval("WebsiteName")%>
                            </td>
                            <td align="left">
                                <%# Eval("WebSite")%>
                            </td>
                            <td align="center">
                                <%#Eval("CompanyName")%>
                            </td>
                            <td align="center">
                                <%#Eval("MemberName")%>
                            </td>
                            <td align="center">
                                <%#Eval("Mobile")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litNoMsg" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
