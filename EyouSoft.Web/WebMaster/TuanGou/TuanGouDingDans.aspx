<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuanGouDingDans.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TuanGou.TuanGouDingDans" %>

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
                            订单号：</label>
                        <input type="text" class="inputtext" name="OrderCode" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("OrderCode") %>" />
                        <label>
                            产品名称：</label>
                        <input type="text" class="inputtext" name="CpName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CpName") %>" />
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
    <%--<div class="btnbox btnboxme">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a class="table_add" href="javascript:;">新 增</a>
                </td>
            </tr>
        </table>
    </div>--%>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        产品内容
                    </th>
                    <th width="140" align="center">
                        订单渠道
                    </th>
                    <th width="130" align="center">
                        订单金额
                    </th>
                    <th width="100" align="center">
                        客人信息
                    </th>
                    <th width="150" align="center">
                        客人地址
                    </th>
                    <th width="100" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        下单时间
                    </th>
                    <th width="60" align="center">
                        订单状态
                    </th>
                    <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="60" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="center">
                                <%# Container.ItemIndex+1 %>
                            </td>
                            <td align="left">
                                <%#Eval("OrderCode")%><br />
                                <%#Eval("ProductName")%>
                            </td>
                            <td align="center">
                                <%# GetWangDianByID(Eval("SupplierID"))%>
                            </td>
                            <td align="left">
                                产品数：<%# Eval("ProductNum")%> 份<br />
                     单价：<%#  (Convert.ToDouble(Eval("OrderPrice")) / Convert.ToDouble(Eval("ProductNum"))).ToString("f2")%> 元/份<br />
                     金额：<%#  Convert.ToDouble(Eval("OrderPrice")).ToString("f2")%>
                            </td>
                            <td align="left">
                                <%# Eval("PeopleName")%><br />
                     <%# Eval("PeopleMobile")%>
                            </td>
                            <td align="left">
                            <%# Eval("Peopleaddress")%>
                            </td>
                            <td align="left">
                                <%# GetMemberNameByID(Eval("PeopleID"))%>
                            </td>
                            <td align="center">
                            <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd HH:mm:ss")%>   
                            </td>
                            <td align="center">
                            <%# (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)(int)(Eval("OrderState")) == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利 ? "交易完成" : Eval("OrderState")%>
                            </td>
                            <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("OrderId"), Eval("OrderState"))%></td>
                            <td align="center">
                                <%# setOptClick(Eval("OrderId").ToString(), Eval("OrderState"))%><br />
                                <%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("OrderState"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litNoMsg" runat="server"></asp:Literal>
            </tbody>
            <tfoot>
            <tr class="<%= recordCount % 2 == 0 ?  "even" : "odd"%>">
                <td colspan="3" align="right">合计金额：</td>
                <td align="center">￥<%=SumMoney.ToString("f2") %></td>
                <td colspan="7"></td>
            </tr>
            <tr>
                    <th width="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        产品内容
                    </th>
                    <th width="140" align="center">
                        订单渠道
                    </th>
                    <th width="130" align="center">
                        订单金额
                    </th>
                    <th width="100" align="center">
                        客人信息
                    </th>
                    <th width="150" align="center">
                        客人地址
                    </th>
                    <th width="100" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        下单时间
                    </th>
                    <th width="60" align="center">
                        订单状态
                    </th>
                    <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="60" align="center">
                        操作
                    </th>
                </tr>
            </tfoot>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
<br /><br />
    <script type="text/javascript">
        var pageData = {
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/WebMaster/TuanGou/TuanGouDingDans.aspx?setState=1&id=" + oid + "&state=" + state,
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
                    })
                }
            },
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
            $("a.table_add").click(function() { pageData.ShowBoxy({ iframeUrl: "/WebMaster/TuanGou/TuanGouEdit.aspx?dotype=add", title: "新增", width: "900px", height: "450px" }) });
            $("a.table_update").click(function() { pageData.ShowBoxy({ iframeUrl: "/WebMaster/TuanGou/TuanGouEdit.aspx?dotype=update&id=" + $(this).attr("data-id"), title: "修改", width: "900px", height: "450px" }) });

            $("a.table_del").click(function() {
                $.ajax({
                    url: "/WebMaster/TuanGou/TuanGouList.aspx?del=1&id=" + $(this).attr("data-id"),
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
