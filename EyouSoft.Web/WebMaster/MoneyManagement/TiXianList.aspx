<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiXianList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MoneyManagement.TiXianList" %>

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
                        <%--<label>
                            用户帐号：</label>
                        <input id="UserName" name="UserName" type="text" class = "inputtext" value="<%=Request.QueryString["UserName"] %>" />--%>
                        <%--<label>
                            提现金额：</label>
                        <input id="ChongZhiJinE1" name="ChongZhiJinE1" type="text" class = "inputtext formsize50"  value="<%=Request.QueryString["ChongZhiJinE1"] %>"/>-<input id="ChongZhiJinE2" name="ChongZhiJinE2" type="text" class = "inputtext formsize50" value="<%=Request.QueryString["ChongZhiJinE2"] %>" />--%>
                        <label>
                            提现日期：</label>
                            <input id="StartTime" name="StartTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["StartTime"] %>" />-<input id="EndTime" name="EndTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["EndTime"] %>" />
                       <%-- <%=Html.TextBoxFor(x => x.StartTime, new { @class = "inputtext formsize50", size = 10, onfocus = "WdatePicker({minDate:'#F{$dp.$D(\\'EndTime\\')}'})" })%>-
                        <%=Html.TextBoxFor(x => x.EndTime, new { @class = "inputtext formsize50", size = 10, onfocus = "WdatePicker({minDate:'#F{$dp.$D(\\'StartTime\\')}'})" })%>--%>
                        <%--<label>
                            状态：</label>--%>
                        <%--<%=Html.DropDownListFor(x=>x.State2, new Linq.Web.SelectListItem{  Text="-请选择-"}) %>--%>
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
    <div style="text-align:center; font-size:16px; color:Red; font-weight:bolder;">总账户金额：<asp:Literal ID="Literal2" runat="server"></asp:Literal>元</div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        交易号
                    </th>
                    <th align="center">
                        提现用户
                    </th>
                    <th align="center">
                        提现金额
                    </th>
                    <th align="center">
                        开户银行
                    </th>
                    <th align="center">
                        开户姓名
                    </th>
                    <th align="center">
                        银行卡号
                    </th>
                    <th align="center">
                        提现状态
                    </th>
                    <th align="center">
                        审核状态
                    </th>
                    <th align="center">
                        提现时间
                    </th>
                    <th align="center">
                        提现备注
                    </th>
                    <th align="center">
                        审核备注
                    </th>
                    <th align="center">操作</th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                           <%-- <td height="30" align="center">
                                <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>">
                            </td>--%>
                            <td align="center">
                                <%#Eval("TransactionID")%>
                            </td>
                            <td align="center">
                                <%#GetMemberNameByID(Eval("UserId"))%>
                            </td>
                            <td align="center">
                                <%# Eval("JinE", "{0:f2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("KaiHuBank")%>
                            </td>
                            <td align="center">
                                <%#Eval("KaiHuName")%>
                            </td>
                            <td align="center">
                                <%#Eval("BankNum")%>
                            </td>
                            <td align="center">
                                <%#Eval("TiXianStatus")%>
                            </td>
                            <td align="center">
                                <%#Eval("ApplyStatus")%>
                            </td>
                            <td align="center">
                                <%# Convert.ToDateTime(Eval("TiXianTime")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#Eval("BeiZhu")%>
                            </td>
                            <td align="center">
                                <%#Eval("ShenHeBeiZhu")%>
                            </td>
                            <td align="center"><%# GetCaoZuo(Eval("ApplyStatus"),Eval("TiXianStatus"),Eval("TiXianId"))%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot><tr><td colspan="12"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td></tr>
            <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        交易号
                    </th>
                    <th align="center">
                        提现用户
                    </th>
                    <th align="center">
                        提现金额
                    </th>
                    <th align="center">
                        开户银行
                    </th>
                    <th align="center">
                        开户姓名
                    </th>
                    <th align="center">
                        银行卡号
                    </th>
                    <th align="center">
                        提现状态
                    </th>
                    <th align="center">
                        审核状态
                    </th>
                    <th align="center">
                        提现时间
                    </th>
                    <th align="center">
                        提现备注
                    </th>
                    <th align="center">
                        审核备注
                    </th>
                    <th align="center">操作</th>
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
    </div><br /><br />
</body>

<script type="text/javascript">
    var intance = new InitialPageInputTagValue();
    intance.Init();


    $(function() {
        $(".ShenHeTG").click(function() {
            if (window.confirm("请确认操作")) {
                var tixianid = $(this).attr("data-id");
                $.ajax({
                    url: "/WebMaster/MoneyManagement/TiXianList.aspx?setState=1&id=" + tixianid,
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
        });
        $(".ShenHeSB").click(function() {
            var tixianid = $(this).attr("data-id");
            location.href = "/WebMaster/MoneyManagement/TiXianEdit.aspx?setState=1&tixianid=" + tixianid;
        });
        $(".QueRenTX").click(function() {
            if (window.confirm("请确认操作")) {
                var tixianid = $(this).attr("data-id");
                $.ajax({
                    url: "/WebMaster/MoneyManagement/TiXianList.aspx?setState=2&id=" + tixianid,
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
        });
        $(".QuXiaoTX").click(function() {
            var tixianid = $(this).attr("data-id");
            location.href = "/WebMaster/MoneyManagement/TiXianEdit.aspx?setState=2&tixianid=" + tixianid;
        });
    });
</script>

</html>
