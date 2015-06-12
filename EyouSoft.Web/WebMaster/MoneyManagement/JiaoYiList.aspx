<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiaoYiList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MoneyManagement.JiaoYiList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                            分销网点：</label>
                        <input id="UserName" name="UserName" type="text" class = "inputtext" value="<%=Request.QueryString["UserName"] %>" />--%>
                        <%--<%=Html.TextBoxFor(x => x.UserName, new { @class = "inputtext" })%>--%>
                        <label>
                            订单类型：</label>
                        <select id="ddlClass" name="ddlClass" class="inputselect">
                            <%=BindClass(EyouSoft.Common.Utils.GetQueryStringValue("ddlClass"))%>
                        </select>
                        <%--<%=Html.TextBoxFor(x => x.ChongZhiJinE1, new { @class = "inputtext formsize50" })%>-
                        <%=Html.TextBoxFor(x => x.ChongZhiJinE2, new { @class = "inputtext formsize50" })%>--%>
                        <label>
                            交易日期：</label>
                            <input id="StartTime" name="StartTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["StartTime"] %>" />-<input id="EndTime" name="EndTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["EndTime"] %>" /> 
    交易对象：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
                        <option value="-1">请选择</option>
                            <%=GetSellersHtml(EyouSoft.Common.Utils.GetQueryStringValue("qudaolist"))%>
                        </select> 操作人：<input id="UserName" name="UserName" type="text" class="inputtext formsize120" />
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
                        订单类型
                    </th>
                    <th align="center">
                        交易金额
                    </th>
                    <th align="center">
                        交易对象
                    </th>
                    <th align="center">
                        操作人
                    </th>
                    <th align="center">
                        交易时间
                    </th>
                    <th align="center">
                        状态
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <%--<td height="30" align="center">
                                <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>">
                            </td>--%>
                            <td align="center">
                                <%# Eval("OrderType")%>
                            </td>
                            <td align="center">
                                <%#((decimal)Eval("Amounts")).ToString("f2")%>
                            </td>
                            <td align="center">
                                <%#GetMemberNameByID(Eval("TranUserId"))%>
                            </td>
                            <td align="center">
                                <%#GetMemberInfoByID("UserId")%>
                            </td>
                            <td align="center">
                                <%#Eval("TransactionTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("TransactionState")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
            </tbody>
            <tfoot>
            <tr><td colspan="6"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td></tr>
            <tr class="<%= refcount % 2 == 0 ? "even" : "odd"%>"><td style="text-align:right">总金额：</td><td colspan="5" align="center"><%= SumMoney%></td></tr>
            <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        订单类型
                    </th>
                    <th align="center">
                        交易金额
                    </th>
                    <th align="center">
                        交易对象
                    </th>
                    <th align="center">
                        操作人
                    </th>
                    <th align="center">
                        交易时间
                    </th>
                    <th align="center">
                        状态
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
    </div><br /><br />
</body>
<script type="text/javascript">
    var instance = new InitialPageInputTagValue();
    instance.Init();
</script>
</html>
