<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="TuanGouDingDan.aspx.cs" Inherits="EyouSoft.Web.Member.TuanGouDingDan" %>

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
        var pagingConfig = { pageSize: 10, pageIndex: <%=pageIndex %>, recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };

        $(document).ready(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
            $(".left_menu ul li").menu();
        }); 
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<uc2:UserNav runat="server" ID="UserNav1" />
<div class="mainbox">
        <div class="title_bar">
                <h4>&gt; 我的订单</h4>
              <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单</span></div>
              
              <uc1:DingDanNav runat="server" ID="DingDanNav1" />
              
              <div class="user_dindan">
               <form id="form1">           
                       <div class="user-s margin_T10"><b>产品名称：</b>
            <input type="text" class="inputbk formsize100" name="CpName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CpName") %>" />
            <b>订单号：</b>
            <input type="text" class="inputbk formsize100" name="OrderCode" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("OrderCode") %>" />
            <input value="搜索" type="submit" class="line-s-btn s_btn" /></form>
            </div>
                            
                 <table width="100%" border="0" class="tableList margin_T10">
                   <tr>
                     <th width="140" align="center" >订单号</th>
                     <th align="center">产品名称</th>
                     <th width="130" align="center">交易金额</th>
                     <th width="90" align="center">客人信息</th>
                     <th width="150" align="center">客人地址</th>
                     <th width="90" align="center">操作人员</th>
                     <th width="65" align="center">预定时间</th>
                     <th width="90" align="center">状态</th>
                     <th width="52" align="center">付款方式</th>
                     <th width="52" align="center">操作</th>
                   </tr>
                    <asp:Repeater ID="rptlist" runat="server">
              <ItemTemplate>
                   <tr>
                     <td height="28" align="center"><%# Eval("OrderCode")%></td>
                     <td align="left"><span title="<%# Eval("ProductName")%>"><%# Eval("ProductName").ToString().Length > 30 ? Eval("ProductName").ToString().Substring(0, 30) + "..." : Eval("ProductName")%></span></td>
                     <td align="left">
                     产品数：<%# Eval("ProductNum")%> 份<br />
                     单价：<%#  (Convert.ToDouble(Eval("OrderPrice")) / Convert.ToDouble(Eval("ProductNum"))).ToString("f2")%> 元/份<br />
                     金额：<%#  Convert.ToDouble(Eval("OrderPrice")).ToString("f2")%> 元</td>
                     <td align="left"><%# Eval("PeopleName")%><br />
                     <%# Eval("PeopleMobile")%></td>
                     <td align="left"><%# Eval("Peopleaddress")%></td>
                     <td align="left"><%# HuiYuanInfo.UserType%>：<%# HuiYuanInfo.MemberName%> <br />
                     <%# HuiYuanInfo.Mobile%></td>
                     <td align="center"><%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%><br />
                     <%# Convert.ToDateTime(Eval("IssueTime")).ToString("HH:mm:ss")%></td></td>
                     <td align="left"><%# getHuiYuanState(Eval("OrderState"))%></td>
                     <td align="center"><%# GetFuKuangCate(Eval("OrderID"), Eval("OrderState"))%></td>
                     <td align="left">
                     <%# getZhiFuURL(Eval("OrderID").ToString(), Eval("OrderState"), Eval("SupplierID"))%>
                     <br />
                     <%# DeleteUserOrder(Eval("OrderID").ToString(), Eval("OrderState"))%>
                     </td>
                   </tr>
                   </ItemTemplate>
                   </asp:Repeater>
                   <tfoot><tr><td colspan="12"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr></tfoot>
                </table>
                </div>
          <div class="page" id="page"></div>  
        </div>

    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Adv" runat="server">

    <script type="text/javascript">
        window.onload = function() {
            $("a[data-nav=navti]").removeClass("on");
            $("a[data-num=9]").addClass("on");
        }
        var pageData = {
            Pay: function(id, type, token) {
                window.location.href = "/Member/PayMoney.aspx?Pay=1&Classid=6&id=" + id + "&type=" + type + "&token=" + token;
                //                Boxy.iframeDialog({
                //                    iframeUrl: "/Member/PayMoney.aspx?Pay=1&Classid=6&id=" + id + "&type=" + type + "&token=" + token,
                //                    title: '订单支付',
                //                    modal: true,
                //                    width: '800px',
                //                    height: '600px'
                //                });
            },
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/Member/TuanGouDingDan.aspx?setState=1&id=" + oid + "&state=" + state,
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



    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
