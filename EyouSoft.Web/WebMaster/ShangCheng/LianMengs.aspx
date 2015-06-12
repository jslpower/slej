<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LianMengs.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShangCheng.LianMengs" %>

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
                    <form id="from1" action="LianMengs.aspx">
                    <div class="searchbox">
                        <label>
                            类别名称：</label>
                        <input type="text" class="inputtext" name="CName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CName") %>" />
                        <label>
                            <label>
                                站点名称：</label>
                            <input type="text" class="inputtext" name="site" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("site") %>" />
                            <input type="hidden" name="mt" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("mt") %>" />
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
    <div class="btnbox btnboxme">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a class="table_add" href="javascript:;">新 增</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th align="center">
                        类别名称
                    </th>
                    <th align="center">
                        站点名称
                    </th>
                    <th align="center">
                        广告链接
                    </th>
                    <th align="center">
                        添加时间
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="center">
                                <%#Eval("LeiBieMingCheng")%>
                            </td>
                            <td align="center">
                                <%#Eval("SiteName")%>
                            </td>
                            <td align="center">
                                <%#Eval("SiteUrl")%>
                            </td>
                            <td align="center">
                                <%#Eval("IssueTime", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center">
                                <a class="table_update" href="javascript:;" data-id="<%#Eval("ID") %>">修改</a> <a
                                    class="table_del" href="javascript:;" data-id="<%#Eval("ID") %>">删除</a>
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

    <script type="text/javascript">
        $(function() {
            $("a.table_add").click(function() {
                window.location.href = "/WebMaster/shangcheng/LianMengE.aspx?dotype=add&mt=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("mt") %>';
            });
            $("a.table_update").click(function() {
                window.location.href = "/WebMaster/shangcheng/LianMengE.aspx?dotype=update&id=" + $(this).attr("data-id") + "&mt=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("mt") %>';

            });

            $("a.table_del").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("您确定要删除此条记录吗？", function() {
                    $.ajax({
                        url: "/WebMaster/ShangCheng/LianMengs.aspx?del=1&id=" + id,
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg);
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                        }
                    });


                });
            });

        })
    </script>

</body>
</html>
