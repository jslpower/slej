<%@ Page Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="DingDanList.aspx.cs" Inherits="EyouSoft.Web.Member.DingDanList" %>
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
            <h4>
                &gt; 我的订单</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单</span></div>
        <uc1:DingDanNav runat="server" ID="DingDanNav1" />
        <div class="user_dindan">
            <div class="user-s margin_T10">
                <b>交易时间：</b>
                <input type="text" id="starttime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100" />
                <b>-</b>
                <input type="text" id="endtime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100" />
                <input name="Input" value="搜索" type="submit" class="line-s-btn s_btn" />
            </div>
            <table width="100%" border="0" class="tableList margin_T10">
                   <tr>
                     <th width="110" align="center" >订单类型</th>
                     <th align="center">订单名称</th>
                     <th width="80" align="center">交易金额</th>
                     <th width="80" align="center">分销金额</th>
                     <th width="70" align="center">分销利润</th>
                     <th width="85" align="center">客人信息</th>
                     <th width="85" align="center">操作人员</th>
                     <th width="65" align="center">预定时间</th>
                     <th width="90" align="center">状态</th>
                   </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                   <tr>
                     <td height="28" align="center"><%# Eval("OrderType")%></td>
                     <td align="left"><%#(Eval("OrderName"))%></td>
                     <td align="left"><%#((decimal)Eval("JinE")).ToString("f2")%>元</td>
                     <td align="left"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("OrderType"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Eval("AgencyJinE", "{0:F2}")%>元</td>
                     <td align="left"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("OrderType"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : (Convert.ToDouble(Eval("JinE")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2")%>元</td>
                     <td align="left"><%# Eval("LXRName")%><br />
                     <%# Eval("LXRMoblie")%></td>
                     <td align="left"><%# GetMemberNameByID(Eval("XDRId"))%></td>
                     <td align="center"><%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%><br />
                     <%# Convert.ToDateTime(Eval("IssueTime")).ToString("HH:mm:ss")%></td>
                     <td align="left"><%# GetStatus(Eval("OrderStatus"))%>   </td>
                   </tr>
                   </ItemTemplate>
                   </asp:Repeater>
                   <tfoot><tr><td colspan="11"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr>
                  <tr>
                     <td colspan="2" align="right">合计金额：</td>
                     <td>￥<%=SumMoney.ToString("f2") %></td>
                     <td>￥<%=SumAMoney.ToString("f2")%></td>
                     <td>￥<%=SumLiRun.ToString("f2")%></td>
                     <td colspan="4"></td></tr>
                   </tfoot>
                </table>
        </div>
        <div class="page" id="page">
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">

    <script type="text/javascript">
     var pageData = {
         Pay: function(id, type, token) {
         window.location.href ="/Member/PayMoney.aspx?Pay=1&Classid=8&id=" + id + "&type=" + type + "&token=" + token;
//                Boxy.iframeDialog({
//                    iframeUrl: "/Member/PayMoney.aspx?Pay=1&Classid=1&id=" + id + "&type=" + type + "&token=" + token,
//                    title: '订单支付',
//                    modal: true,
//                    width: '800px',
//                    height: '600px'
//                });
            },
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/Member/ChuJingOrder.aspx?setState=1&id=" + oid + "&state=" + state,
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
        $("a[data-num=0]").addClass("on");
        }
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>

