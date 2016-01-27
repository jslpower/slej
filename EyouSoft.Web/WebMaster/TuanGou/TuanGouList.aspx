<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuanGouList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.TuanGou.TuanGouList" %>

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
                            产品名称：</label>
                        <input type="text" class="inputtext" name="CpName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CpName") %>" />
                        <label>
                            供应商名称：</label>
                        <input type="text" class="inputtext" name="CompanyName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CompanyName") %>" />
                        促销形式：
                        <select class="inputselect" name="CxType">
                            <%=EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.CuXiaoLeiXing)), EyouSoft.Common.Utils.GetQueryStringValue("CxType"), true, "-1", "请选择")%>
                        </select>
                        产品类型：
                        <select class="inputselect" name="CpType">
                            <%=EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.ChanPinLeiXing)), EyouSoft.Common.Utils.GetQueryStringValue("CpType"), true, "-1", "请选择")%>
                        </select>
                        <input name="type" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("type") %>" type="hidden" />
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
    <% if (EyouSoft.Common.Utils.GetQueryStringValue("type") == "g")
       {%>
    <div class="btnbox btnboxme">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a class="table_add" href="javascript:;">新 增</a>
                </td>
            </tr>
        </table>
    </div>
    <%} %>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th align="center">
                        产品名称
                    </th>
                    <th align="center">
                        促销形式
                    </th>
                    <th align="center">
                        产品类型
                    </th>
                    <th align="center">
                        门市价
                    </th>
                    <th align="center">
                        团购价
                    </th>
                    <th align="center">
                        数量
                    </th>
                    <th align="center">
                        有效期
                    </th>
                    <% if (EyouSoft.Common.Utils.GetQueryStringValue("type") != "g")
                       {%>
                    <th>
                    供应商
                    </th>
                    <%} %>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="left">
                                <%#Eval("ProductName")%>
                            </td>
                            <td align="center">
                                <%#Eval("SaleType")%>
                            </td>
                            <td align="center">
                                <%#Eval("ProductType")%>
                            </td>
                            <td align="center">
                                <%#Eval("MarketPrice","{0:C2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("GroupPrice", "{0:C2}")%>
                            </td>
                            <td align="center">
                                <%# Eval("ProductNum")%>
                            </td>
                            <td align="center">
                                <%# Eval("ValiDate", "{0:yyyy-MM-dd}")%>
                            </td>
                             <% if (EyouSoft.Common.Utils.GetQueryStringValue("type") != "g")
                                {%>
                            <td align="center">
                                <a href="/webmaster/Supplier/SupplierD.aspx?dlsid=<%# Eval("SupplierID")%>">
                                    <%# GetCompanyName(Eval("SupplierID"))%>
                                    </a>
                            </td>
                            <%} %>
                            <td align="center">
                            <% if (EyouSoft.Common.Utils.GetQueryStringValue("type") != "s")
                               {%>
                               <%#CheIsIndex(Eval("IsIndex"), Eval("ID"))%><br />
                                <a class="table_update" href="javascript:;" data-id="<%#Eval("ID") %>">修改</a> <a
                                    class="table_del" href="javascript:;" data-id="<%#Eval("ID") %>">删除</a>
                            <%}else{ %><%# GetDaiLiPro(Eval("IsIndex"), Eval("ValiDate"), Eval("ID"))%> 
                            
                                    <%} %>
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
            },
            EnIndex: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var url = "/WebMaster/TuanGou/TuanGouList.aspx?dotype=isindex&id=" + id + "&state=" + state;
            pageData.GoAjax(url);
        },
        SheZhiStatus: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var probool = $(obj).attr("data-bool");
            var url = "/WebMaster/TuanGou/TuanGouList.aspx?dotype=isdaili&id=" + id + "&state=" + state + "&probool=" + probool;
            pageData.GoAjax(url);
        },
        GoAjax: function(url) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                async: false,
                dataType: "json",
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
        }
        };
        $(function() {
        $("a.table_add").click(function() {
        window.location.href = "/WebMaster/TuanGou/TuanGouEdit.aspx?dotype=add&otype=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>";
        //             pageData.ShowBoxy({ iframeUrl: "/WebMaster/TuanGou/TuanGouEdit.aspx?dotype=add", title: "新增", width: "900px", height: "450px" }) 
});
$("a.table_update").click(function() {
window.location.href = "/WebMaster/TuanGou/TuanGouEdit.aspx?dotype=update&otype=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>&id=" + $(this).attr("data-id");
//            pageData.ShowBoxy({ iframeUrl: "/WebMaster/TuanGou/TuanGouEdit.aspx?dotype=update&id=" + $(this).attr("data-id"), title: "修改", width: "900px", height: "450px" }) 
});

            $("a.table_del").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("您确定要删除此条记录吗？", function() {
                    $.ajax({
                        url: "/WebMaster/TuanGou/TuanGouList.aspx?del=1&id=" + id,
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
