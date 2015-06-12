<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="ZuTuanOrderList.aspx.cs" Inherits="EyouSoft.Web.Member.ZuTuanOrderList" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<form id="form1" runat="server">
<uc2:UserNav runat="server" ID="UserNav1" />
<div class="mainbox">
        <div class="title_bar">
                <h4>&gt; 我的订单</h4>
              <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单</span></div>
              
              <uc1:DingDanNav runat="server" ID="DingDanNav1" />
              <div class="user_dindan">
                          
                       <div class="user-s margin_T10"><b>下单时间：</b>
            <input type="text" id="starttime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100" />
            <b>-</b>
            <input type="text" id="endtime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100" />
            <%--<b>线路名称：</b>
            <input name="Input" id="XianluName" runat="server" type="text" class="inputbk formsize180" />--%>
            <input name="Input" value="搜索" type="submit" class="line-s-btn s_btn" />
            </div>
                            
                 <table width="100%" border="0" class="tableList margin_T10">
                   <tr>
                     <th width="110" align="center" >订单号</th>
                     <th align="center">线路名称</th>
                     <th width="60" align="center">人数</th>
                     <th width="65" align="center">出发时间</th>
                     <th width="130" align="center">价格</th>
                     <%if (isAgency == 1)
                       { %>
                     <th width="130" align="center">分销价格</th>
                     <th width="80" align="center">分销利润</th>
                     <%} %>
                     <th width="115" align="center">操作人员</th>
                     <th width="70" align="center">预定时间</th>
                     <th width="65" align="center">付款方式</th>
                     <th width="65" align="center">操作</th>
                   </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                   <tr>
                     <td height="28" align="center"><%# Eval("OrderCode")%></td>
                     <td align="left"> <a class="fontblue" href="/Member/ZuTuanDetails.aspx?orderid=<%#Eval("ZuTuanId")%>" title="<%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("XianLuName").ToString())%>"><%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("XianLuName").ToString())%></a></td>
                     <td align="center">
                     成人：<%#Eval("RenShu")%>人<br />
                     儿童：<%#Eval("ErTongNum")%>人
                     </td>
                     <td align="center"><%# Convert.ToDateTime(Eval("ChuFaTime")).ToString("yyyy-MM-dd")%>
                     </td>
                     <td align="left">
                     成人价：<%# Convert.ToDecimal(Eval("CRJiage")).ToString("f2")%>元
                                <br />
                                儿童价：<%# Convert.ToDecimal(Eval("ETJiage")).ToString("f2")%>元
                                <br />
                                总价：<%# Convert.ToDecimal(Convert.ToDecimal(Eval("CRJiage")) * Convert.ToDecimal(Eval("RenShu")) + Convert.ToDecimal(Eval("ETJiage")) * Convert.ToDecimal(Eval("ErTongNum"))).ToString("f2")%>元
                     </td>
                     <%if (isAgency == 1)
                       { %>
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
                     <%} %>
                     <td align="left"><span style="color:Red"><%# Eval("UserType") %></span><br />
                                <%#GetMemberNameByID(Eval("XDRId"))%></td>
                     <td align="center"><%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                     </td>
                     <td align="center"><%# GetFuKuangCate(Eval("ZuTuanId"), Eval("OrderState"))%></td>
                     <td align="center">
                     <%# getZhiFuURL(Eval("ZuTuanId").ToString(), Eval("OrderState"), Eval("AgencyId"))%>
                     <br />
                     <%# DeleteUserOrder(Eval("ZuTuanId").ToString(), Eval("OrderState"))%>
                     </td>
                   </tr>
                   </ItemTemplate>
                   </asp:Repeater>
                   <tfoot><tr><td colspan="8"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr>
                   <tr>
                     <th width="110" align="center" >订单号</th>
                     <th align="center">线路名称</th>
                     <th width="30" align="center">人数</th>
                     <th width="70" align="center">出发时间</th>
                     <th width="120" align="center">价格</th>
                     <%if (isAgency == 1)
                       { %>
                     <th width="120" align="center">分销价格</th>
                     <th width="80" align="center">分销利润</th>
                     <%} %>
                     <th width="115" align="center">操作人员</th>
                     <th width="70" align="center">预定时间</th>
                     <th width="65" align="center">付款方式</th>
                     <th width="65" align="center">操作</th>
                   </tr>
                   </tfoot>
                </table>
                </div>
          <div class="page" id="page"></div>  
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<script type="text/javascript">
var pageData = {
          Pay: function(id, type, token) {
          window.location.href = "/Member/PayMoney.aspx?Pay=1&Classid=10&id=" + id + "&type=" + type + "&token=" + token;
            },
//DeleteOrder: function(oid) {
//        if (window.confirm("请确认操作")) {
//            $.ajax({
//                url: "/Member/ZuTuanOrderList.aspx?setState=2&id=" + oid,
//                dataType: "json",
//                success: function(ret) {
//                    if (ret.result == "1") {
//                        tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
//                    }
//                    else {
//                        tableToolbar._showMsg(ret.msg);
//                    }
//                },
//                error: function() {
//                    tableToolbar._showMsg(tableToolbar.errorMsg);
//                }
//            })
//        }
//    },
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/Member/ZuTuanOrderList.aspx?setState=1&id=" + oid + "&state=" + state,
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


        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%= pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
        window.onload = function() {
        $("a[data-nav=navti]").removeClass("on");
        $("a[data-num=4]").addClass("on");
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
