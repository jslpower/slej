<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScenicOrderList.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.ScenicOrderList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单管理</title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
    .pnone{display:none;}
    </style>
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
                        订单号：
                        <input type="text" value='<%=Request.QueryString["txtOrderCode"] %>' name="txtOrderCode"
                            class="inputtext" maxlength="30" size="28" />
                        景点名称:
                        <input type="text" value='<%=Request.QueryString["ScenicName"] %>' name="ScenicName"
                            class="inputtext" maxlength="30" size="28" />
                        订单状态：
                        <select class="inputselect select" id="orderstatus" name="orderstatus">
                            <%=StrOrderStatus %>
                        </select>
                        下单日期：
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" value='<%=Request.QueryString["txtStartTime"] %>'
                            id="txtStartTime" size="10" class="inputtext" />-<input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})"
                                value='<%=Request.QueryString["txtEndTime"] %>' class="inputtext" name="txtEndTime"
                                id="txtEndTime" size="10" />
                        订单来源:<select name="sltsource" id="sltsource" class="inputselect">
                            <%=SourceStr %>
                        </select>
                        <br />
                        单位名称:<input name="txtcompanyName" id="txtcompanyName" size="20" class="inputtext" value='<%=Request.QueryString["txtcompanyName"] %>' />
                        下单渠道：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
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
            <tbody>
                <tr>
                    <th width="30" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        订单内容
                    </th>
                    <th width="135" align="center">
                        渠道
                    </th>
                    <th width="90" align="center">
                        出游日期
                    </th>
                    <th width="90" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        客人信息
                    </th>
                    <th width="110" align="center">
                        交易金额
                    </th>
                    <th width="110" align="center">
                        分销金额
                    </th>
                    <th width="60" align="center">
                        分销利润
                    </th>
                    <th width="90" align="center" nowrap="nowrap">
                        下单日期
                    </th>
                    <%--<th width="60" align="center">
                    订单状态
                    </th>--%>
                     <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="60" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rpt_orders" runat="server">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ?  "even" : "odd" %>" data-id='<%#Eval("OrderId") %>'>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                订单号：<a href="javascript:;" class="info">
                                    <%#Eval("OrderCode")%></a><br />
                                     <%# Eval("ScenicName")%>&nbsp;<%#Eval("TypeName")%>
                            </td>
                            <td align="center">
                                <%# GetWangDianByID(Eval("SellerID"))%>
                            </td>
                            <td align="center">
                                <%#Convert.ToDateTime(Eval("ChuFaRiQi")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="left">
                               <span style="color:Red"><%# Eval("UserType")%></span><br /><%# Eval("OperatorName")%> <br />
                     <%# Eval("OperatorMobile")%>
                            </td>
                            <td align="left">
                            <%#Eval("ContactName")%><br /><%#Eval("ContactTel")%>
                            </td>
                            <td align="left">
                            门票数：<%# Eval("Num")%> 张<br />
                     单价：<%#  (Convert.ToDouble(Eval("Price")) / Convert.ToDouble(Eval("Num"))).ToString("f2")%> 元/张<br />
                     金额：<%#  Convert.ToDouble(Eval("Price")).ToString("f2")%> 元
                            </td>
                             <td align="left" class="<%#Eval("SellerID").ToString().Trim().Length > 20?"":"pnone"%>">
                               门票数：<%# Eval("Num")%> 张<br />
                     单价：<%#  (Convert.ToDouble(Eval("AgencyJinE")) / Convert.ToDouble(Eval("Num"))).ToString("f2")%> 元/张<br />
                     金额：<%# Eval("SellerID").ToString().Trim().Length > 20 ? Convert.ToDouble(Eval("AgencyJinE")).ToString("f2") : "0"%> 元</td>
                             <td align="center" class="<%#Eval("SellerID").ToString().Trim().Length > 20?"pnone":""%>">
                            总站交易
                        </td>
                            <td align="center">
                            <%# Eval("SellerID").ToString().Trim().Length > 20 ? (Convert.ToDouble(Eval("Price")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2") : "0"%>元
                            </td>
                            <td height="30" align="center" nowrap="nowrap">
                                <%#Convert.ToDateTime( Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                            </td>
                            <%--<td align="center">
                            <%#Eval("Status")%>
                            </td>--%>
                            <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("OrderId"), Eval("Status"))%></td>
                            <td align="center">
                            <%# setOptClick(Eval("OrderId").ToString(), Eval("Status"), Eval("SellerID"))%><br />
                            <%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("Status"))%>
                               <%-- <%#GetOpeartor(Eval("Status"))%>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
            <tfoot>
            <tr class="<%= recordCount % 2 == 0 ?  "even" : "odd"%>"><td colspan="6" align="right">合计金额：</td><td align="center"><%= SumMoney.ToString("f2")%></td><td align="center"><%= SumAMoney.ToString("f2")%></td><td align="center"><%= SumLiRun.ToString("f2")%></td><td colspan="3"></td></tr>
            <tr>
                    <th width="30" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        订单内容
                    </th>
                    <th width="135" align="center">
                        渠道
                    </th>
                    <th width="90" align="center">
                        出游日期
                    </th>
                    <th width="90" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        客人信息
                    </th>
                    <th width="110" align="center">
                        交易金额
                    </th>
                    <th width="110" align="center">
                        分销金额
                    </th>
                    <th width="60" align="center">
                        分销利润
                    </th>
                    <th width="90" align="center" nowrap="nowrap">
                        下单日期
                    </th>
                    <%--<th width="60" align="center">
                    订单状态
                    </th>--%>
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
                <td height="30" align="right" class="pageup" colspan="11">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br /><br />
</body>

<script type="text/javascript">
    function test(oid, state)
    { alert(oid + state) }

    var OrderList = {
    setOrder: function(oid, state) {
        if (window.confirm("请确认操作")) {
            $.ajax({
            url: "/WebMaster/ScenicAndTicketManage/ScenicOrderList.aspx?setState=1&id=" + oid + "&state=" + state,
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
        $("#liststyle .info").click(function() {
        var id = $(this).closest("tr").attr("data-id");
        window.location.href = "ScenicOrderEdit.aspx?orderid=" + id + "&dotype=show";
        });
        $("#liststyle .update").click(function() {
            var orderid = $(this).closest("tr").attr("data-id");
            OrderList.openXLwindow("ScenicOrderEdit.aspx?orderid=" + orderid + "&dotype=update", "订单修改", 530, 370);
        });
    });
    
</script>

</html>
