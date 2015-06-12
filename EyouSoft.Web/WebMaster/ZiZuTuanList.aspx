<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiZuTuanList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ZiZuTuanList" %>

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
                        
                        <label>
                            下单日期：</label>
                            <input id="StartTime" name="StartTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["StartTime"] %>" />-<input id="EndTime" name="EndTime" class = "inputtext formsize120" onfocus = "WdatePicker({minDate:'#F{$dp.$D(\'StartTime\')}'})" type="text" value="<%=Request.QueryString["EndTime"] %>" />

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
                        订单号
                    </th>
                    <th align="center">
                        线路名称
                    </th>
                    <th width="60"  align="center">
                        人数
                    </th>
                    <th width="110"  align="center">
                        保险方式
                    </th>
                    <th width="65"  align="center">
                        出发时间
                    </th>
                    <th width="130"  align="center">
                        价格
                    </th>
                    <th width="130" align="center">
                        分销价格
                    </th>
                    <th width="80" align="center">
                        利润
                    </th>
                    <th width="130"  align="center">
                        操作人
                    </th>
                    <th width="65"  align="center">
                        下单时间
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
                        <%# Eval("OrderCode")%>
                        </td>
                            <td align="center">
                                <a href="/WebMaster/ZiZuTuanXX.aspx?orderid=<%#Eval("ZuTuanId")%>"><%#Eval("XianLuName")%></a>
                            </td>
                            <td align="center">
                                成人：<%#Eval("RenShu")%>人<br />
                                儿童：<%#Eval("ErTongNum")%>人
                            </td>
                            <td align="center">
                                <%#Eval("BaoXian")%>
                            </td>
                            <td align="center">
                                <%# Convert.ToDateTime(Eval("ChuFaTime")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="left">
                                成人价：<%# Convert.ToDecimal(Eval("CRJiage")).ToString("f2")%>元
                                <br />
                                儿童价：<%# Convert.ToDecimal(Eval("ETJiage")).ToString("f2")%>元
                                <br />
                                总价：<%# Convert.ToDecimal(Convert.ToDecimal(Eval("CRJiage")) * Convert.ToDecimal(Eval("RenShu")) + Convert.ToDecimal(Eval("ETJiage")) * Convert.ToDecimal(Eval("ErTongNum"))).ToString("f2")%>元
                            </td>
                            <td align="left">
                                成人价：<%# Convert.ToDecimal(Eval("AgencyJinE")).ToString("f2")%>元
                                <br />
                                儿童价：<%# Convert.ToDecimal(Eval("ETAgencyJinE")).ToString("f2")%>元
                                <br />
                                总价：<%# Convert.ToDecimal(Convert.ToDecimal(Eval("AgencyJinE")) * Convert.ToDecimal(Eval("RenShu")) + Convert.ToDecimal(Eval("ETAgencyJinE")) * Convert.ToDecimal(Eval("ErTongNum"))).ToString("f2")%>元
                            </td>
                            <td align="left">
                                <%# Convert.ToDecimal(Convert.ToDecimal(Convert.ToDecimal(Eval("CRJiage")) * Convert.ToDecimal(Eval("RenShu")) + Convert.ToDecimal(Eval("ETJiage")) * Convert.ToDecimal(Eval("ErTongNum"))) - Convert.ToDecimal(Convert.ToDecimal(Eval("AgencyJinE")) * Convert.ToDecimal(Eval("RenShu")) + Convert.ToDecimal(Eval("ETAgencyJinE")) * Convert.ToDecimal(Eval("ErTongNum")))).ToString("f2")%>元
                            </td>
                            <td align="left">
                            <span style="color:Red"><%# Eval("UserType") %></span><br />
                                <%#GetMemberNameByID(Eval("XDRId"))%>
                            </td>
                             <td align="center">
                                <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("ZuTuanId"), Eval("OrderState"))%></td>
                            <td align="center">
                                <%# setOptClick(Eval("ZuTuanId").ToString(), Eval("OrderState"))%><br />
                        <%# DeleteUserOrder(Eval("ZuTuanId").ToString(), Eval("OrderState"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot><tr><td colspan="12"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td></tr>
            <tr>
                <th align="center">
                        订单号
                    </th>
                    <th align="center">
                        线路名称
                    </th>
                    <th width="60"  align="center">
                        人数
                    </th>
                    <th width="110"  align="center">
                        保险方式
                    </th>
                    <th width="65"  align="center">
                        出发时间
                    </th>
                    <th width="130"  align="center">
                        价格
                    </th>
                    <th width="130" align="center">
                        分销价格
                    </th>
                    <th width="80" align="center">
                        利润
                    </th>
                    <th width="130"  align="center">
                        操作人
                    </th>
                    <th width="65"  align="center">
                        下单时间
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
                    <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                </td>
            </tr>
        </table>
    </div><br /><br />
    <script type="text/javascript">
        function test(oid, state)
        { alert(oid + state) }

        var OrderList = {

            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                    url: "/WebMaster/ZiZuTuanList.aspx?setState=1&id=" + oid + "&state=" + state,
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
            DeleteOrder: function(oid) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                    url: "/WebMaster/ZiZuTuanList.aspx?setState=2&id=" + oid,
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

            BindBtn: function() {
                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行"
                });
            },
            openXLwindow: function(url, title, width, height) {
                url = url;
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: title,
                    modal: true,
                    width: width,
                    height: height,
                    afterHide: function() { OrderList.reload(); }
                });
            },
            reload: function() {
                window.location.href = window.location.href;
            }
        };

        $(function() {
            OrderList.BindBtn();
        });
    
</script>
</body>
</html>
