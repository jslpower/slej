<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="ZuCheOrderList.aspx.cs" Inherits="EyouSoft.Web.Member.ZuCheOrderList" %>
<%@ Register Src="/UserControl/DingDanNav.ascx" TagName="DingDanNav" TagPrefix="uc1" %>
<%@ Register Src="/UserControl/UserNav.ascx" TagName="UserNav" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/Css/style.css" rel="stylesheet" />
<link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/table-toolbar.js"></script>
<script type="text/javascript" src="/js/jquery.boxy.js"></script>
<script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>
<script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>
<script src="/Js/menu_min.js"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<form id="form1" runat="server">
<uc2:UserNav runat="server" ID="UserNav1" />
<div class="mainbox">
        <div class="title_bar">
                <h4>&gt; 我的订单</h4>
              <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单</span></div>
        <uc1:DingDanNav runat="server" ID="DingDanNav1" />
        <div class="user_dindan">
                          
                       <div class="user-s margin_T10"><b>交易时间：</b>
             <input type="text" id="starttime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100"/>
              <b>-</b>
            <input type="text" id="endtime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100"/>
            <b>车辆名称：</b>
            <input name="CarName" id="CarName" runat="server" type="text" class="inputbk formsize180" />
              <input name="Input" value="搜索" type="submit"  class="line-s-btn s_btn" />
            </div>
                            
                 <table width="100%" border="0" class="tableList margin_T10">
                   <tr>
                     <th width="110" align="center" >订单号/租车方式</th>
                     <th align="center">车辆名称</th>
                     <th width="66" align="center">出发/回归</th>
                     <th width="120" align="center">交易金额</th>
                     <%if (isAgency == 1)
                       { %>
                     <th width="120" align="center">分销金额</th>
                     <th width="70" align="center">分销利润</th>
                     <%} %>
                     <th width="85" align="center">客人信息</th>
                     <th width="85" align="center">操作人员</th>
                     <th width="65" align="center">预定时间</th>
                     <th width="100" align="center">状态</th>
                     <th width="52" align="center">付款方式</th>
                     <th width="52" align="center">操作</th>
                   </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                   <tr>
                     <td height="28" align="center"><a class="fontblue" href="/Member/ZuCheDetails.aspx?orderid=<%#Eval("OrderId")%>"><%# Eval("OrderCode")%></a>
                     <br /><%# Eval("ZuCheType").ToString() == "1" ? "租车方式：同城往返" : "租车方式：单接单送"%>
                     </td>
                     <td align="left"><span title="<%# Eval("CarName")%>"><%# Eval("CarName").ToString().Length > 30 ? Eval("CarName").ToString().Substring(0, 30) + "..." : Eval("CarName")%></span></td>
                     <td align="center"><%# Convert.ToDateTime(Eval("LDate")).ToString("yyyy-MM-dd")%><br />
                     <%# Convert.ToDateTime(Eval("LDate")).ToString("HH:mm")%><br />
                     <%# Convert.ToDateTime(Eval("EDate")).ToString("yyyy-MM-dd")%>
                     </td>
                     <td align="left">
                     车辆数：<%# Eval("Number")%> 辆<br />
                     单价：<%#  (Convert.ToDouble(Eval("zujin")) / Convert.ToDouble(Eval("Number"))).ToString("f2")%> 元/辆<br />
                     金额：<%#  Convert.ToDouble(Eval("zujin")).ToString("f2")%> 元</td>
                     <%if (isAgency == 1)
                     { %>
                     <td align="left">
                     车辆数：<%# Eval("Number")%> 辆<br />
                     单价：<%#  (Convert.ToDouble(Eval("AgencyJinE")) / Convert.ToDouble(Eval("Number"))).ToString("f2")%> 元/辆<br />
                     金额：<%# Convert.ToDouble(Eval("AgencyJinE")).ToString("f2")%> 元</td>
                     <td align="center"><%# (Convert.ToDouble(Eval("zujin")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2")%> 元</td>
                     <%} %>
                     <td align="left"><%# Eval("LxrName")%><br />
                     <%# Eval("LxrTelephone")%></td>
                     <td align="left"><%# Eval("UserType")%>：<%# Eval("YuDingRName")%> <br />
                     <%# Eval("YuDingRTelephone")%></td>
                     <td align="center"><%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%><br />
                     <%# Convert.ToDateTime(Eval("IssueTime")).ToString("HH:mm:ss")%></td>
                     <td align="center"><%# getHuiYuanState(Eval("Status"))%></td>
                     <td align="center"><%# GetFuKuangCate(Eval("OrderId"), Eval("Status"))%></td>
                     <td align="left">
                     <%# getZhiFuURL(Eval("OrderId").ToString(), Eval("Status"), Eval("AgencyId"))%>
                     <br />
                     <%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("Status"))%>
                     </td>
                   </tr>
                   </ItemTemplate>
                   </asp:Repeater>
                   <tfoot><tr><td colspan="12"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr>
                   <%if (isAgency == 1)
                       { %>
                       <tr>
                     <td colspan="2" align="right">合计金额：</td>
                     <td>￥<%=SumMoney.ToString("f2") %></td>
                     <td>￥<%=SumAMoney.ToString("f2")%></td>
                     <td>￥<%=SumLiRun.ToString("f2")%></td>
                     <td colspan="6"></td></tr>
                     <%} %>
                   </tfoot>
                </table>
                </div>
        <div class="page" id="page"></div>  
</div>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Adv" runat="server">



<script type="text/javascript">
var pageData = {
          Pay: function(id, type, token) {
          window.location.href = "/Member/PayMoney.aspx?Pay=1&Classid=4&id=" + id + "&type=" + type + "&token=" + token;
//                Boxy.iframeDialog({
//                    iframeUrl: "/Member/PayMoney.aspx?Pay=1&Classid=4&id=" + id + "&type=" + type + "&token=" + token,
//                    title: '订单支付',
//                    modal: true,
//                    width: '500px',
//                    height: '600px'
//                });
            },
DeleteOrder: function(oid) {
        if (window.confirm("请确认操作")) {
            $.ajax({
                url: "/Member/ZuCheOrderList.aspx?setState=2&id=" + oid,
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
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/Member/ZuCheOrderList.aspx?setState=1&id=" + oid + "&state=" + state,
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
            }
        };


        var pagingConfig = { pageSize: 10, pageIndex:<%= PageIndex %> , recordCount: <%=TotalCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
        window.onload = function() {
        $("a[data-nav=navti]").removeClass("on");
        $("a[data-num=7]").addClass("on");
        }
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>