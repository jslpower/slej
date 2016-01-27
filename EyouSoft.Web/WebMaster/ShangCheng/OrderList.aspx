<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShangCheng.OrderList" %>

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
    <style type="text/css">
    .pnone{display:none;}
    </style>
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
                        <input type="text" class="inputtext" name="CName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CName") %>" />
                        <label>
                            <label>
                                订单状态：</label>
                            <select id="ddlType" name="ddlType" class="inputselect">
                                <%=EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), EyouSoft.Common.Utils.GetQueryStringValue("ddlType"), true, "", "请选择") %>
                            </select>
                            下单渠道：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
                        <option value="-1">请选择</option>
                            <%=GetSellersHtml(EyouSoft.Common.Utils.GetQueryStringValue("qudaolist"))%>
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
    <%--<div class="btnbox btnboxme">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>--%>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tr>
                <th width="30" height="32" align="center">
                    序号
                </th>
                <th align="center">
                    订单内容
                </th>
                <th width="130" align="center">
                    订单渠道
                </th>
                <th width="90" align="center">
                    操作人
                </th>
                <th width="90" align="center">
                    联系人
                </th>
                <th width="130" align="center">
                    交易金额
                </th>
                
                <th width="130" align="center">
                    分销金额
                </th>
                <th width="60" align="center">
                    分销利润
                </th>
                <th width="60" align="center">
                    平台交易费
                </th>
                <%if (UserInfo.LeiXing == WebmasterUserType.后台用户){ %>
                <th width="60" align="center">
                    应付供应商款
                </th>
                <%} %>
                <th width="70" align="center">
                    下单时间
                </th>
                <%--<th align="center">
                    订单状态
                </th>--%>
                <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                <th width="60" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                        <td height="28" align="center">
                            <%# Container.ItemIndex+1 %>
                        </td>
                        <td height="28" align="left">
                            <a class="table_update" href="javascript:;" data-id="<%#Eval("OrderID") %>">订单号：<%# Eval("OrderCode")%></a><br />
                            <%# Eval("ProductName")%>
                        </td>
                        <td align="center">
                            <%# GetWangDianByID(Eval("SupplierID"))%>
                            <br />
                            <%# GetGongYingByID(Eval("ProductID"))%>
                        </td>
                        <td align="left">
                            <span style="color:Red"><%# Eval("UserType")%></span><br /><%# Eval("OperatorName")%> <br />
                     <%# Eval("OperatorMobile")%>
                        </td>
                        <td align="left">
                            <%# Eval("ContactName")%><br />
                     <%# Eval("ContactPhone")%>
                        </td>
                        <td align="left">
                            商品数：<%# Eval("ProductNum")%> 份<br />
                     单价：<%#  (Convert.ToDouble(Eval("OrderPrice")) / Convert.ToDouble(Eval("ProductNum"))).ToString("f2")%> 元/份<br />
                     金额：<%#  Convert.ToDouble(Eval("OrderPrice")).ToString("f2")%> 元
                        </td>
                        
                        <td align="left" class="<%#Eval("SupplierID").ToString().Trim().Length > 20?"":"pnone"%>">
                            商品数：<%# Eval("ProductNum")%> 张<br />
                     单价：<%#  (Convert.ToDouble(Eval("SupplierMoney")) / Convert.ToDouble(Eval("ProductNum"))).ToString("f2")%> 元/份<br />
                     金额：<%# Eval("SupplierID").ToString().Trim().Length > 20 ? Convert.ToDouble(Eval("SupplierMoney")).ToString("f2") : "0"%> 元
                        </td>
                        <td align="center" class="<%#Eval("SupplierID").ToString().Trim().Length > 20?"pnone":""%>">
                            总站交易
                        </td>
                        <td align="center">
                           <%# Eval("SupplierID").ToString().Trim().Length > 20 ? (Convert.ToDouble(Eval("OrderPrice")) - Convert.ToDouble(Eval("SupplierMoney"))).ToString("f2") : "0"%>
                        </td>
                         <td align="center">
                              <%#  Convert.ToDecimal(Convert.ToDecimal(Eval("OrderPrice")) * Convert.ToDecimal(Eval("JiaoYiLv")) / 100).ToString("f4")%>元  
                            </td>
                            <%if (UserInfo.LeiXing == WebmasterUserType.后台用户)
                      { %>
                      <td align="center">
                      <%#  Convert.ToDecimal(Convert.ToDecimal(Eval("SalePrice")) - Convert.ToDecimal(Eval("OrderPrice")) * Convert.ToDecimal(Eval("JiaoYiLv")) / 100).ToString("f4")%>元  
                      </td>
                    <%} %>
                        <td align="center">
                            <%#  Eval("IssueTime","{0:yyyy-MM-dd}") %>
                        </td>
                        <%--<td align="center">
                            <%# Eval("OrderState")%>
                        </td>--%>
                        <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("OrderId"), Eval("OrderState"))%></td>
                        <td align="center">
                            <%# setOptClick(Eval("OrderId").ToString(), Eval("OrderState"), Eval("SupplierID"))%><br />
                            <%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("OrderState"))%>
                            <%--  <a class="table_update" href="javascript:;" data-id="<%#Eval("OrderID") %>">修改</a>
                            <a class="table_del" href="javascript:;" data-id="<%#Eval("OrderID") %>">删除</a>--%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="litNoMsg" runat="server"></asp:Literal>
            <tfoot>
            <tr class="<%= recordCount % 2 == 0 ?  "even" : "odd"%>">
                <td colspan="5" align="right">合计金额：</td>
                <td align="center">￥<%=SumMoney.ToString("f2") %></td>
                <td align="center">￥<%=SumAMoney.ToString("f2")%></td>
                <td align="center">￥<%=SumLiRun.ToString("f2")%></td>
                <td align="center">￥<%=PingTaiJiaoYiFei.ToString("f2")%></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <th width="30" height="32" align="center">
                    序号
                </th>
                <th align="center">
                    订单内容
                </th>
                <th width="130" align="center">
                    订单渠道
                </th>
                <th width="90" align="center">
                    操作人
                </th>
                <th width="90" align="center">
                    联系人
                </th>
                <th width="130" align="center">
                    交易金额
                </th>
                <th width="130" align="center">
                    分销金额
                </th>
                <th width="60" align="center">
                    分销利润
                </th>
                <th width="60" align="center">
                    平台交易费
                </th>
                <%if (UserInfo.LeiXing == WebmasterUserType.后台用户){ %>
                <th width="60" align="center">
                    应付供应商款
                </th>
                <%} %>
                <th width="70" align="center">
                    下单时间
                </th>
                <%--<th align="center">
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
                        url: "/WebMaster/ShangCheng/OrderList.aspx?setState=1&id=" + oid + "&state=" + state,
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
            FanQian:function(oid,state){
               if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/WebMaster/ShangCheng/OrderList.aspx?setState=2&id=" + oid + "&state=" + state,
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

            $("a.table_update").click(function() {

                window.location.href = "/WebMaster/shangcheng/OrderEdit.aspx?dotype=update&id=" + $(this).attr("data-id");
            });

            $("a.table_del").click(function() {
                if (confirm("数据不可回复，确认删除？")) {
                    $.ajax({
                        url: "/WebMaster/ShangCheng/OrderList.aspx?del=1&id=" + $(this).attr("data-id"),
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
                }
            });

        })
    </script>

</body>
</html>
