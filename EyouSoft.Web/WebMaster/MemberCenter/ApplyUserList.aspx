<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyUserList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MemberCenter.ApplyUserList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>
<link href="/Css/style.css" rel="stylesheet" type="text/css" />
    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>
<script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <script src="/Js/menu_min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <div class="searchbox" style="border: #3983e5 solid 0px;">
                            姓名：
                            <input id="UName" runat="server" type="text" />
                            手机：
                            <input id="UMoblie" runat="server" type="text" />
                            公司:
                            <input id="UCompany" runat="server" type="text" />
                            申请时间:
                            <input id="StartTime" runat="server" onfocus="WdatePicker()" type="text" />-<input id="EndTime" onfocus="WdatePicker()" runat="server" type="text" />
                            <asp:Button ID="Button1" runat="server" CssClass="search-btn" 
                                onclick="Button1_Click" />
                            <%--<input class="search-btn" type="button"/>--%>
                        </div>
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
                        <th width="60" height="30" align="center">
                            序号
                        </th>
                        <th align="center">
                            姓名
                        </th>
                        <th align="center">
                            公司名
                        </th>
                        <th align="center">
                            手机
                        </th>
                        <th align="center">
                            申请类型
                        </th>
                        <th align="center">
                            申请时间
                        </th>
                        <%--<th align="center">
                            申请状态
                        </th>
                        <th align="center">
                            操作
                        </th>--%>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr <%#Container.ItemIndex%2==0?" class=\"odd\" ":" class=\"even\" "  %> id="index<%#Container.ItemIndex %>">
                                <td height="30" align="center">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td align="center">
                                    <%#Eval("MemberName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("CompanyName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("MemberMoblie")%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserCate")%>
                                </td>
                                <td align="center">
                                    <%#Eval("ApplyTime")%>
                                </td>
                               <%-- <td align="center">
                                    <%#Eval("ApplyStatus")== "0" ? "未联系":"已联系"%>
                                </td>--%>
                                <td align="center">
                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
 <%--            <table width="100%" border="0" cellspacing="0" cellpadding="0">
               <tr>
                    <td height="30" align="right" class="pageup" colspan="13">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>--%>
        </div>
        <div class="page" id="page">
    </div>
    </form>
    <script type="text/javascript">
        var pagingConfig = { pageSize: 20, pageIndex:<%=Model.SearchInfo.PageInfo.PageIndex %> , recordCount: <%=Model.SearchInfo.PageInfo.TotalCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</body>
</html>

