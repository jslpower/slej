<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.Ticket" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理景区门票列表</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script src="/JS/utilsUri.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="/css/webmaster/boxy.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="30">
                    门票名称：
                    <input type="text" id="txtName" class="searchinput inputtext" name="txtName" style="width: 150px;"
                        runat="server" />
                    状态：
                    <asp:DropDownList runat="server" ID="ddlState" CssClass="inputselect">
                    </asp:DropDownList>
                    <a href="javascript:void(0)" id="a_Search_Ticket">
                        <img src="/Images/webmaster/searchbtn.gif" style="width: 62px; height: 21px; border: 0 none;" /></a>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <div class="btnbox">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:;" id="btnAdd">新 增</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
            <tr>
                <th width="5%" align="center" bgcolor="#bddcf4">
                    序号
                </th>
                <th align="center" bgcolor="#bddcf4">
                    景区名称
                </th>
                <th align="center" bgcolor="#bddcf4">
                    门票名称
                </th>
                <th align="center" bgcolor="#bddcf4">
                    门票数量
                </th>
                <th align="center" bgcolor="#bddcf4">
                    市场价
                </th>
                <th align="center" bgcolor="#bddcf4">
                    网站优惠价
                </th>
                <th align="center" bgcolor="#bddcf4">
                    有效时间
                </th>
                <th align="center" bgcolor="#bddcf4">
                    状态
                </th>
                <th align="center" bgcolor="#bddcf4">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" data-id="<%# Eval("TicketsId") %>">
                        <td height="35" align="center">
                            <%# GetIndex(Container.ItemIndex) %>
                        </td>
                        <td height="35" align="center">
                            <%#Eval("ScenicName")%>
                        </td>
                        <td height="35" align="center">
                            <%#Eval("TypeName")%>
                        </td>
                        <td height="35" align="center">
                            <%#Eval("Number")%>
                        </td>
                        <td height="35" align="center">
                            <%# this.ToMoneyString(Eval("RetailPrice"))%>
                        </td>
                        <td height="35" align="center">
                            <%# this.ToMoneyString(Eval("WebsitePrices"))%>
                        </td>
                        <td height="35" align="center">
                            <%# GetTimeStr(Eval("StartTime"), Eval("EndTime"))%>
                        </td>
                        <td height="35" align="center">
                            <%# GetStateHtml(Eval("Status"))%>
                        </td>
                        <td align="center">
                            <%#(Eval("InterafaceTicketId") == null || Eval("InterafaceTicketId").ToString()=="") ? GetStateHadnleHtml(Eval("Status")) + "<a href=\"javascript:;\" class=\"editTicket\">修改</a>&nbsp;&nbsp;<a href=\"javascript:;\" class=\"delTicket\">删除</a>" : ""%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <th width="5%" align="center" bgcolor="#bddcf4">
                    序号
                </th>
                <th align="center" bgcolor="#bddcf4">
                    景区名称
                </th>
                <th align="center" bgcolor="#bddcf4">
                    门票名称
                </th>
                <th align="center" bgcolor="#bddcf4">
                    门票数量
                </th>
                <th align="center" bgcolor="#bddcf4">
                    市场价
                </th>
                <th align="center" bgcolor="#bddcf4">
                    网站优惠价
                </th>
                <th align="center" bgcolor="#bddcf4">
                    有效时间
                </th>
                <th align="center" bgcolor="#bddcf4">
                    状态
                </th>
                <th align="center" bgcolor="#bddcf4">
                    操作
                </th>
            </tr>
            <tr>
                <td height="30" colspan="10" align="right" class="pageup">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
<br /><br />
    <script type="text/javascript">
        var ScenicTicketList = {
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            searchTicket: function() {
                var data = {
                    sid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("sid") %>',
                    txtName: $("#<%= txtName.ClientID %>").val(),
                    states: $("#<%= ddlState.ClientID %>").val(),
                    scenicId_Interface: '<%=Request.QueryString["scenicId_Interface"] %>'
                };

                window.location.href = "/WebMaster/ScenicAndTicketManage/Ticket.aspx?" + $.param(data);
            },
            addTicket: function() {
            window.location.href = "/WebMaster/ScenicAndTicketManage/TicketEdit.aspx?action=add&sid=" + '<%= EyouSoft.Common.Utils.GetQueryStringValue("sid") %>';
//                ScenicTicketList.ShowBoxy({
//                    iframeUrl: "/WebMaster/ScenicAndTicketManage/TicketEdit.aspx?action=add&sid=" + '<%= EyouSoft.Common.Utils.GetQueryStringValue("sid") %>',
//                    title: "新增景区门票",
//                    width: "900px",
//                    height: "600px"
//                });
//                return false;
            },
            editTicket: function(id) {
                if (id == null || typeof (id) == "undefined" || id == "") return false;
                window.location.href = "/WebMaster/ScenicAndTicketManage/TicketEdit.aspx?action=edit&id=" + id;
//                ScenicTicketList.ShowBoxy({ iframeUrl: "/WebMaster/ScenicAndTicketManage/TicketEdit.aspx?action=edit&id=" + id, title: "修改景区门票", width: "900px", height: "600px" });
//                return false;
            },
            delTicket: function(id) {
                if (id == null || typeof (id) == "undefined" || id == "") return false;

                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/WebMaster/ScenicAndTicketManage/Ticket.aspx?action=del&id=" + id,
                    dataType: "json",
                    async: false,
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            },
            setTicket: function(id, state) {
                if (id == null || typeof (id) == "undefined" || id == "") return false;

                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/WebMaster/ScenicAndTicketManage/Ticket.aspx?action=setstate&id=" + id + "&state=" + state,
                    dataType: "json",
                    async: false,
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        };

        $(document).ready(function() {

            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行"
            });

            $("#a_Search_Ticket").click(function() {
                ScenicTicketList.searchTicket();
                return false;
            });

            $("#btnAdd").click(function() {
                ScenicTicketList.addTicket();
                return false;
            });

            $("#liststyle").find(".editTicket").each(function() {
                var id = $(this).closest("tr").attr("data-id");
                $(this).click(function() {
                    ScenicTicketList.editTicket(id);
                    return false;
                });
            });

            $("#liststyle").find(".delTicket").each(function() {
                var id = $(this).closest("tr").attr("data-id");
                $(this).click(function() {
                    tableToolbar.ShowConfirmMsg("您确定要删除此门票信息吗？", function() {
                        ScenicTicketList.delTicket(id);
                    });
                    return false;
                });
            });
            $("#liststyle").find(".setTicket").each(function() {
                var id = $(this).closest("tr").attr("data-id");
                var state = $(this).attr("data-state");
                $(this).click(function() {
                    tableToolbar.ShowConfirmMsg("您确定要删除此门票信息的状态吗？", function() {
                        ScenicTicketList.setTicket(id, state);
                    });
                    return false;
                });
            });
        });
    </script>

</body>
</html>
