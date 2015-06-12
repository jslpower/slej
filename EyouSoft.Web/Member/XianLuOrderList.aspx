<%@ Page Title="线路订单列表" Language="C#" MasterPageFile="~/MasterPage/Front3.Master"
    AutoEventWireup="true" CodeBehind="XianLuOrderList.aspx.cs" Inherits="EyouSoft.Web.Member.XianLuOrderList" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <form id="form1" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 线路订单</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 线路订单</span></div>
        <div class="user-s margin_T10">
            <b>交易时间：</b>
            <input type="text" id="starttime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100" />
            <b>-</b>
            <input type="text" id="endtime" runat="server" onfocus="WdatePicker()" class="inputbk formsize100" />
            <b>线路名称：</b>
            <input name="Input" id="XianluName" runat="server" type="text" class="inputbk formsize180" />
            <input name="Input" value="搜索" type="submit" class="line-s-btn s_btn" />
        </div>
        <table width="100%" border="0" class="tableList margin_T10">
            <tr>
                <th height="32" align="center">
                    序号
                </th>
                <th align="center">
                    订单号
                </th>
                <th align="center" style="width:200px">
                    线路名称
                </th>
                <th align="center">
                    发团时间
                </th>
                <th align="center">
                    交易金额
                </th>
                <%if (isAgency == 1)
                  { %>
                <th align="center">
                    分销金额
                </th>
                <th align="center">
                    分销利润
                </th>
                <%} %>
                <th align="center">
                    联系人
                </th>
                <th align="center">
                    操作人员
                </th>
                <th align="center">
                    下单时间
                </th>
                <%--              <th align="center">交易金额</th>--%>
                <th align="center">
                    订单状态
                </th>
                <th width="52" align="center">付款方式</th>
                <th width="52" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td height="28" align="center">
                            <%# Container.ItemIndex+1 %>
                        </td>
                        <td height="28" align="center">
                            <%# Eval("OrderCode")%>
                        </td>
                        <td align="left">
                                <%# Eval("XianLuName")%>
                        </td>
                        <td align="center">
                            <%# Convert.ToDateTime(Eval("LDate")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td align="center">
                            <b class="font_yellow">
                                <%#  Convert.ToDouble(Eval("JinE")).ToString("f2")%></b>元
                        </td>
                        <%if (isAgency == 1)
                          { %>
                        <td align="center">
                            <%# Convert.ToDouble(Eval("AgencyJinE")).ToString("f2")%>
                        </td>
                        <td align="center">
                            <%# (Convert.ToDouble(Eval("JinE")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2")%>
                        </td>
                        <%} %>
                        <td align="center">
                            <%# Eval("LxrName")%>
                        </td>
                        <td align="center">
                            <%# Eval("LxrName")%>
                        </td>
                        <td align="center">
                            <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td align="center">
                            <%# getHuiYuanState(Eval("Status"))%>
                        </td>
                        <td align="center"><%# GetFuKuangCate(Eval("OrderID"), Eval("Status"))%></td>
                        <td align="center">
                            <%# getZhiFuURL(Eval("OrderID").ToString(), Eval("Status"), Eval("AgencyId"))%> <br />
                            <%# DeleteUserOrder(Eval("OrderID").ToString(), Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tfoot><tr><td colspan="12"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr>
            <%if (isAgency == 1)
                       { %>
                       <tr>
                     <td colspan="3" align="right">合计金额：</td>
                     <td>￥<%=SumMoney.ToString("f2") %></td>
                     <td>￥<%=SumAMoney.ToString("f2")%></td>
                     <td>￥<%=SumLiRun.ToString("f2")%></td>
                     <td colspan="6"></td></tr>
                     <%} %>
            </tfoot>
        </table>
        <div class="page" id="page">
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">

    <script type="text/javascript">
     var pageData = {
         Pay: function(id, type, token) {
                Boxy.iframeDialog({
                    iframeUrl: "/Member/PayMoney.aspx?Pay=1&Classid=1&id=" + id + "&type=" + type + "&token=" + token,
                    title: '订单支付',
                    modal: true,
                    width: '800px',
                    height: '600px'
                });
            },
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/Member/XianLuOrderList.aspx?setState=1&id=" + oid + "&state=" + state,
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
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
