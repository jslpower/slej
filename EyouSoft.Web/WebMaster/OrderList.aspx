<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.OrderList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单管理</title>

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

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
</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" runat="server" method="get">
                    <div class="searchbox">
                        订单号：
                        <input type="text" value='<%=Request.QueryString["orderCode"] %>' name="txtPathName"
                            class="inputtext" maxlength="30" size="28">
                        下单人：
                        <input name="txtAuthor" type="text" class="inputtext" value='<%=Request.QueryString["orderMan"] %>'
                            size="10" />
                        下单日期：
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" value='<%=Request.QueryString["startE"] %>'
                            id="txtStartTime" size="10" class="inputtext" />-<input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})"
                                value='<%=Request.QueryString["endE"] %>' class="inputtext" name="txtEndTime"
                                id="txtEndTime" size="10" />
                        <input type="hidden" value="44" name="sl" />
                        订单状态:<select name="sleorderstatus" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), "", "", "请选择")%>
                        </select>
                        付款状态:<select name="slepaystatus" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)), "", "", "请选择")%>
                        </select>
                        <br />下单渠道：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
                        <option value="-1">请选择</option>
                            <%=GetSellersHtml()%>
                        </select>
                        <input type="button" class="search-btn" value="" />
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
                    <th width="45" align="center">
                        来源
                    </th>
                    <th width="130" align="center">
                        渠道
                    </th>
                    <th width="85" align="center">
                        出发日期
                    </th>
                    <th width="90" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        客人信息
                    </th>
                    <th width="170" align="center">
                        交易金额
                    </th>
                    <th width="170" align="center">
                        分销金额
                    </th>
                    <th width="60" align="center">
                        分销利润
                    </th>
                    <th width="85" align="center">
                        下单日期
                    </th>
                    <%--<th width="60" align="center">
                        订单状态
                    </th>--%>
                    <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="70" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rpt_orders" runat="server">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-id='<%#Eval("OrderId") %>'>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="left" style="width: 20%">
                                <a href="javascript:;" class="info" data-id="<%#Eval("OrderId")%>">订单号：<%#Eval("OrderCode")%></a><br />
                                <a href="/print/xingchengdan.aspx?routeid=<%# Eval("XianLuId")%>" target="_blank"><%# Eval("XianLuName")%></a>
                            </td>
                            <td align="center">
                                <%# Eval("Line_Source")%>
                            </td>
                            <td align="center">
                                <%# GetWangDianByID(Eval("AgencyId"))%>
                            </td>
                            <td align="center">
                                <%# Convert.ToDateTime(Eval("LDate")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="left">
                                <span style="color:Red"><%# Eval("UserType")%></span><br />
                                <%# GetMemberNameByID(Eval("OperatorId"))%><br />
                                <%# Eval("Mobile")%>
                            </td>
                            <td align="left">
                                <%# Eval("LxrName")%><br />
                                <%# Eval("LxrTelephone")%>
                            </td>
                            <td align="left">
                            人数：<%# Eval("ChengRenShu")%>成人<%# Eval("ErTongShu")%>儿童<br />
                     成人价：<%# UtilsCommons.GetGYStijia(feetype, Convert.ToDecimal(Eval("JSJCR")), Convert.ToDecimal(Eval("SCJCR")), (EyouSoft.Model.Enum.MemberTypes)EyouSoft.Common.Utils.GetInt(((int)Eval("UserType")).ToString())).ToString("f2")%> 元/人<br />
                     儿童价：<%# UtilsCommons.GetGYStijia(feetype, Convert.ToDecimal(Eval("JSJER")), Convert.ToDecimal(Eval("SCJET")), (EyouSoft.Model.Enum.MemberTypes)EyouSoft.Common.Utils.GetInt(((int)Eval("UserType")).ToString())).ToString("f2")%> 元/人<br />
                     金额：<%#  Convert.ToDouble(Eval("JinE")).ToString("f2")%> 元
                            </td>
                            <td align="left">
                                人数：<%# Eval("ChengRenShu")%>成人<%# Eval("ErTongShu")%>儿童<br />
                     成人价：<%# GetDengJiByID(feetype, Eval("JSJCR"), Eval("SCJCR"), Eval("AgencyId")).ToString("f2")%> 元/人<br />
                     儿童价：<%# GetDengJiByID(feetype, Eval("JSJER"), Eval("SCJET"), Eval("AgencyId")).ToString("f2")%> 元/人<br />
                     金额：<%# Eval("AgencyId").ToString().Trim().Length > 20 ? Convert.ToDouble(Eval("AgencyJinE")).ToString("f2") : "0"%> 元
                            </td>
                            <td align="center">
                            
                            <%# Eval("AgencyId").ToString().Trim().Length > 20 ? (Convert.ToDouble(Eval("JinE")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2") : "0"%>元
                            </td>
                            <td align="center">
                                <%#Convert.ToDateTime( Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                            </td>
                            <%--<td align="center">
                                <%#Eval("Status")%>
                            </td>--%>
                            <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("OrderId"), Eval("Status"))%></td>
                            <td align="center">
                                <%# setOptClick(Eval("OrderId").ToString(), Eval("Status"), Eval("AgencyId"))%><br />
                                <%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("Status"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
            <tr class="<%= recordCount % 2 == 0 ?  "even" : "odd"%>">
                <td colspan="7" align="right">合计金额：</td>
                <td align="center">￥<%=SumMoney.ToString("f2") %></td>
                <td align="center">￥<%=SumAMoney.ToString("f2")%></td>
                <td align="center">￥<%=SumLiRun.ToString("f2")%></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                    <th width="30" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        订单内容
                    </th>
                    <th width="45" align="center">
                        来源
                    </th>
                    <th width="130" align="center">
                        渠道
                    </th>
                    <th width="85" align="center">
                        出发日期
                    </th>
                    <th width="90" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        客人信息
                    </th>
                    <th width="170" align="center">
                        交易金额
                    </th>
                    <th width="170" align="center">
                        分销金额
                    </th>
                    <th width="60" align="center">
                        分销利润
                    </th>
                    <th width="85" align="center">
                        下单日期
                    </th>
                    <%--<th width="60" align="center">
                        订单状态
                    </th>--%>
                    <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="70" align="center">
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
</body>

<script type="text/javascript">
 
    var OrderList = {
        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/WebMaster/OrderList.aspx?setState=1&id=" + oid + "&state=" + state,
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
        $(".info").each(function() {
            var id = $(this).attr("data-id")
            $(this).click(function() {
            window.location.href = "OrderInfo.aspx?id=" + id;
                //OrderList.openXLwindow("OrderInfo.aspx?id=" + id, "查看订单", 800, 300);
            })
        }); //
        $(".search-btn").click(function() {
            var orderCode = $("input[name=txtPathName]").val();
            var orderMan = $("input[name=txtAuthor]").val();
            var startE = $("input[name=txtStartTime]").val();
            var endE = $("input[name=txtEndTime]").val();
            var orderS = $("[name=sleorderstatus]").val();
            var payS = $("[name=slepaystatus]").val();
            var qudaoS = $("[name=qudaolist]").val();
            window.location.href = "OrderList.aspx?orderCode=" + orderCode + "&orderMan=" + orderMan + "&startE=" + startE + "&orderS=" + orderS + "&payS=" + payS + "&endE=" + endE + "&qudaoS=" + qudaoS;
        })

    });
    
</script>

</html>
