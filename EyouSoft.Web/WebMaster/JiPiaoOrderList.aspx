<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiPiaoOrderList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.JiPiaoOrderList" %>

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

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1">
                    <div class="searchbox">
                        <label>
                            交易日期：</label>
                        <input id="StartTime" name="StartTime" class="inputtext formsize120" onfocus="WdatePicker()"
                            type="text" value="<%=Request.QueryString["StartTime"] %>" />-<input id="EndTime"
                                name="EndTime" class="inputtext formsize120" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'StartTime\')}'})" type="text"
                                value="<%=Request.QueryString["EndTime"] %>" />下单渠道：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
                        <option value="-1">请选择</option>
                            <%=GetSellersHtml(EyouSoft.Common.Utils.GetQueryStringValue("qudaolist"))%>
                        </select>
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
            <thead>
                <tr>
                    <th align="center">
                        订单类型
                    </th>
                    <th align="center">
                        下单渠道
                    </th>
                    <th align="center">
                        产品名称
                    </th>
                    <th align="center" style="width: 80px">
                        交易时间
                    </th>
                    <th align="center" style="width: 100px">
                        交易金额
                    </th>
                    <th align="center" style="width: 100px">
                        佣金
                    </th>
                    <th align="center" style="width: 100px">
                        操作人
                    </th>
                    <th align="center" style="width: 100px">
                        客人信息
                    </th>
                    <th align="center" style="width: 80px">
                        订单状态
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="center">
                                <%#(Eval("OrderType"))%>
                            </td>
                            <td align="center">
                                    <%# GetWangDianByID(Eval("AgencyId"))%>
                            </td>
                            <td align="left">
                                <a href="JiPiaoOrderXX.aspx?OrderId=<%#Eval("OrderId") %>"><%#GetOrderName(Eval("OrderName"))%></a>
                            </td>
                            <td align="center">
                                <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#((decimal)Eval("JinE")).ToString("f2")%>
                            </td>
                            <td align="center">
                             <%# Eval("AgencyId").ToString().Trim().Length > 20 ? (Convert.ToDouble(Eval("JinE")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2") : "0"%>元
                            </td>
                            <td align="center">
                                <%# GetMemberNameByID(Eval("XDRId"))%>
                            </td>
                            <td align="center">
                                <%#Eval("LXRName")%><br />
                                    <%#Eval("LXRMoblie")%>
                            </td>
                            <td align="center">
                                <%# GetStatus(Eval("OrderStatus"), Eval("AgencyId"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="8">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right">
                        合计金额：
                    </td>
                    <td>
                        ￥<%=SumMoney.ToString("f2") %>
                    </td>
                    <td>
                        ￥<%=SumLiRun.ToString("f2")%>
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <th align="center">
                        订单类型
                    </th>
                    <th align="center">
                        下单渠道
                    </th>
                    <th align="center">
                        产品名称
                    </th>
                    <th align="center" style="width: 80px">
                        交易时间
                    </th>
                    <th align="center" style="width: 100px">
                        交易金额
                    </th>
                    <th align="center" style="width: 100px">
                        佣金
                    </th>
                    <th align="center" style="width: 100px">
                        操作人
                    </th>
                    <th align="center" style="width: 100px">
                        客人信息
                    </th>
                    <th align="center" style="width: 80px">
                        订单状态
                    </th>
                </tr>
            </tfoot>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br /><br />

    <script type="text/javascript">
        $(function() {
            $(".AgencyId").click(function() {
                var id = $(this).attr("data-id");
                if (window.location.href.indexOf("?") > 0) {
                    if (window.location.href.indexOf("AgencyId") > 0) {
                        window.location.href = window.location.href;
                    }
                    else {
                        window.location.href = window.location.href + "&AgencyId=" + id;
                    }
                }
                else {
                    window.location.href = window.location.href + "?AgencyId=" + id;
                }
            });
            $(".OrderName").click(function() {
                var id = $(this).attr("data-id");
                if (window.location.href.indexOf("?") > 0) {
                    if (window.location.href.indexOf("ProductID") > 0) {
                        window.location.href = window.location.href;
                    }
                    else {
                        window.location.href = window.location.href + "&ProductID=" + id;
                    }
                }
                else {
                    window.location.href = window.location.href + "?ProductID=" + id;
                }
            });
            $(".LXRMoblie").click(function() {
                var id = $(this).attr("data-id");
                if (window.location.href.indexOf("?") > 0) {
                    if (window.location.href.indexOf("lxrmoblie") > 0) {
                        window.location.href = window.location.href;
                     }
                    else {
                        window.location.href = window.location.href + "&lxrmoblie=" + id;
                    }
                }
                else {
                    window.location.href = window.location.href + "?lxrmoblie=" + id;
                }
            });
            $(".memberID").click(function() {
                var id = $(this).attr("data-id");
                if (window.location.href.indexOf("?") > 0) {
                    if (window.location.href.indexOf("memberid") > 0) {
                        window.location.href = window.location.href;
                     }
                    else {
                        window.location.href = window.location.href + "&memberid=" + id;
                    }
                }
                else {
                    window.location.href = window.location.href + "?memberid=" + id;
                }
            });
        });
    </script>

</body>
</html>

