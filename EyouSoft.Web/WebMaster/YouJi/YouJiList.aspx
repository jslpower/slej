<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouJiList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.YouJi.YouJiList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" action="YouJiList.aspx" method="get">
                    <div class="searchbox">
                        <label>
                            标题：</label>
                        <input type="text" class="inputtext" name="txtArticleTitle" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtArticleTitle") %>" />
                        <label>
                            发布人：</label>
                        <input type="text" class="inputtext" name="txtOperatorName" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtOperatorName") %>" />
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
    <div class="btnbox">
        <table width="99%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <asp:PlaceHolder runat="server" ID="phadd">
                        <td width="90" align="center">
                            <a class="toolbar_add" href="javascript:void(0)">新增</a>
                        </td>
                    </asp:PlaceHolder>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        标题
                    </th>
                    <th align="center">
                        发布人
                    </th>
                    <th align="center">
                        发布时间
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td height="30" align="center">
                                <%# Container.ItemIndex +1%>
                            </td>
                            <td align="center">
                                <%#Eval("YouJiTitle")%></a>
                            </td>
                            <td align="center">
                                <%#Eval("HuiYuanName")%>
                            </td>
                            <td align="center">
                                <%#Eval("IssueTime","{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center" data-id="<%#Eval("YouJiId")%>">
                                <%#  getIsUpdateHtml(Eval("huiyuanid").ToString())%>
                                <a class="toolbar_delete" href="javascript:;">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="ltrNoMsg" runat="server" Visible="false"><tr><td colspan="5" align="center">暂无数据</td></tr></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        $(function() {
            $(".toolbar_add").click(function() { location.href = "YouJiEdit.aspx?dotype=add" })//
            $(".toolbar_delete").click(function() {
                var ajaxurl = "YouJiList.aspx?dotype=DelYouJi&youjid=" + $(this).parent().attr("data-id");
                if (confirm("确认删除操作？")) {
                    $.ajax({ url: ajaxurl, dataType: "json", async: false,
                        success: function(ret) {
                            alert(ret.msg);
                            location.href = window.location.href;
                        },
                        error: function() {
                            alert("未知错误");
                        }
                    });
                }
            })//
            $(".toolbar_update").click(function() {
                var ajaxurl = "YouJiEdit.aspx?youjid=" + $(this).parent().attr("data-id");
                location.href = ajaxurl;
            })//
            $(".toolbar_chakan").click(function() {
                var ajaxurl = "chakan.aspx?youjid=" + $(this).parent().attr("data-id");
                location.href = ajaxurl;
            })//
        })
   
    </script>

</body>
</html>
