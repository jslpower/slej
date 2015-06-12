<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenDuiHuan.aspx.cs" Inherits="EyouSoft.Web.WebMaster.JiFenDuiHuan" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>积分兑换审核</title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/bt.min.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" method="get">
                    <div class="searchbox">
                        订单状态：
                        <select class="inputselect select" id="orderstatus" name="orderstatus">
                            <%=StrOrderStatus %>
                        </select>
                        下单日期：
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" value='<%=Request.QueryString["txtStartTime"] %>'
                            id="txtStartTime" size="10" class="inputtext" />-<input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})"
                                value='<%=Request.QueryString["txtEndTime"] %>' class="inputtext" name="txtEndTime"
                                id="txtEndTime" size="10" />
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
                    <th width="30" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        兑换额度
                    </th>
                    <th width="150" align="center">
                        兑换日期
                    </th>
                    <th width="200" align="center">
                        操作人
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <th width="200" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rpt_orders" runat="server">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ?  "even" : "odd" %>" data-id='<%#Eval("DuiHuanId") %>'>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="center">
                            <%# Eval("DuiHuanJinE")%>
                            </td>
                            <td align="center">
                            <%# Eval("IssueTime")%>
                            </td>
                            <td align="center">
                            <%# GetMemberNameByID(Eval("UserId"))%>
                            </td>
                            <td align="center">
                            <%# Eval("DuiHuanStatus")%>
                            </td>
                            <td align="center">
                                <%# setOptClick(Eval("DuiHuanId").ToString(), Eval("DuiHuanStatus"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
            <tfoot>
                <tr>
                    <th width="30" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        兑换额度
                    </th>
                    <th width="150" align="center">
                        兑换日期
                    </th>
                    <th width="200" align="center">
                        操作人
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <th width="120" align="center">
                        操作
                    </th>
                </tr>
            </tfoot>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="11">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
</body>

<script type="text/javascript">

    var OrderList = {

        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                url: "/WebMaster/JiFenDuiHuan.aspx?setState=1&id=" + oid + "&state=" + state,
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
        reload: function() {
            window.location.href = window.location.href;
        }
    };

    
</script>

</html>
