<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Supplier.SupplierList" %>

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
                            供应商名称：</label>
                        <input type="text" class="inputtext" name="CName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CName") %>" />
        <label>
                            供应商手机：</label>
                        <input type="text" class="inputtext" name="CMoblie" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CMoblie") %>" />
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
                        单位名称
                    </th>
                    <th align="center">
                        分销商类别
                    </th>
                    <th align="center">
                        联系人
                    </th>
                    <th align="center">
                        联系电话
                    </th>
                    <th align="center">
                        联系手机
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="center">
                                <%#Eval("SupplierName")%>
                            </td>
                            <td align="center">
                                <%#Eval("SupplierType")%>
                            </td>
                            <td align="center">
                                <%# Eval("ContactName")%>
                            </td>
                            <td align="center">
                                <%# Eval("ContactPhone")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactMobile")%>
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
        var pageData = {
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            } //
        };
        $(function() {
        $("a.table_add").click(function() {
        window.location.href = "/WebMaster/Supplier/SupplierEdit.aspx?dotype=add";
//        pageData.ShowBoxy({ iframeUrl: "/WebMaster/Supplier/SupplierEdit.aspx?dotype=add", title: "新增", width: "800px", height: "650px" })
             });
             $("a.table_update").click(function() {
             window.location.href = "/WebMaster/Supplier/SupplierEdit.aspx?dotype=update&id=" + $(this).attr("data-id");
//             pageData.ShowBoxy({ iframeUrl: "/WebMaster/Supplier/SupplierEdit.aspx?dotype=update&id=" + $(this).attr("data-id"), title: "修改", width: "800px", height: "650px" })
             });

            $("a.table_del").click(function() {
                $.ajax({
                    url: "/WebMaster/Supplier/SupplierList.aspx?del=1&id=" + $(this).attr("data-id"),
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

        })
    </script>

</body>
</html>
