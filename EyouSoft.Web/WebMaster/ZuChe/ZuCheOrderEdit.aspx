<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZuCheOrderEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.ZuChe.ZuCheOrderEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>租车订单修改</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; margin: 0px auto;">
        <table border="0" class="tchuang" style="width: 100%">
            <tr class="odd">
                <th height="25" align="right" width="20%">
                    订单号：
                </th>
                <td align="left" bgcolor="#E3F1FC" width="30%">
                    <asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" width="20%">
                    租车方式：
                </th>
                <td align="left" bgcolor="#E3F1FC" width="30%">
                    <asp:Literal ID="ZuCheType" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    汽车名称：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ltrCarName" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    租车数辆：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ltrNumber" runat="server"></asp:Literal>
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    出发时间：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="litLDate" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    回归时间：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ltrEDate" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    租车天数：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ltrTianShu" runat="server"></asp:Literal>天
                </td>
                <th height="25" align="right">
                    公里数：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ltrGongLiShu" runat="server"></asp:Literal>
                    公里
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    乘车联系人：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtContact" runat="server"></asp:Literal>
                </td>
                <th align="right">
                    乘车联系人手机：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtContactTel" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    下单人：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtYContact" runat="server"></asp:Literal>
                </td>
                <th align="right">
                    下单人手机：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtYContactTel" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    下单时间：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="litInTime" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    合计金额：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="litJinE" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    租车行程：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tbl_Customer_AutoAdd">
                        <tbody>
                            <tr class="odd">
                                <%--<th align="center" width="50" height="30">
                                    日期
                                </th>--%>
                                <th align="center">
                                    起始地
                                </th>
                                <th align="center">
                                    目的地
                                </th>
                                <th align="center">
                                    车程
                                </th>
                            </tr>
                            <asp:Repeater runat="server" ID="rptlist">
                                <ItemTemplate>
                                    <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#E3F1FC" : "#BDDCF4" %>">
                                        <%--<td height="50" align="center">
                                            <b>
                                               第 <%#Container.ItemIndex+1 %> 天
                                            </b>
                                        </td>--%>
                                        <td align="center">
                                            <%#Eval("LPlace")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("EPlace")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("GongLiShu")%> 公里
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    订单状态：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="orderstatus" runat="server"></asp:Literal>
                    <%--<select class="inputselect select" id="orderstatus" name="orderstatus">
                        <%=StrOrderStatus %>
                    </select>--%>
                </td>
                <th align="right">
                    付款状态：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="PayState" runat="server"></asp:Literal>
                    <%--<select class="inputselect select" id="sel_PayState" name="sel_PayState">
                        <%=StrPayState%>
                    </select>--%>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    备注：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtBeiZhu" runat="server"></asp:Literal>
                    <%--<textarea name="txtBeiZhu" id="txtBeiZhu" cols="65" rows="5" runat="server"></textarea>--%>
                </td>
            </tr>
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
    </div>
    </form>

    <%--<script type="text/javascript">
        var Page = {
            PageInit: function() {
                $("#i_a_xiugai").click(function() {
                    $("#i_a_xiugai").html("提交中...").unbind("click").css({ "color": "#999999" });
                    var url = '/WebMaster/ZuChe/ZuCheOrderEdit.aspx?dotype=sava&orderid=' + '<%=Request.QueryString["orderid"] %>' + "&type=" + '<%=Request.QueryString["type"] %>';
                    Page.GoAjax(url);
                });
                $("#i_a_xiugai").html("提交修改").css({ "color": "" });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#i_a_xiugai").closest("form").get(0), "parent");
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg, function() {
                                Page.PageInit();
                            });
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(tableToolbar.errorMsg, function() {
                            Page.PageInit();
                        });
                    }
                });
            }
        }
        $(function() {
            Page.PageInit();
        });
    </script>--%>

</body>
</html>
