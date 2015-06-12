<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScenicOrderEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.ScenicOrderEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>景点修改</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 98%; margin: 0px auto;" id="i_div_form">
        <table border="0" class="tchuang" style="width: 100%">
            <tr class="odd">
                <th height="35" align="right" width="90">
                    景区名称：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ScenicName" runat="server"></asp:Literal>
                </td>
                <th height="35" align="right" width="110">
                    门票类型名称：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="TicketType" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="35" align="right" width="90">
                   门票数：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtTicketNum" runat="server"></asp:Literal>
                </td>
                <th align="right" width="90">
                   价格：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtticketPrice" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="35" align="right" width="90">
                   联系人：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtContactName" runat="server"></asp:Literal>
                </td>
                <th align="right" width="90">
                    联系电话：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtContactTel" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="35" width="90" align="right">
                    订单状态：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="OrderStatus" runat="server"></asp:Literal>
                </td>
                <th height="35" width="90" align="right">
                    下单人：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtopeater" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="35" width="90" align="right">
                    付款状态：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="PayState" runat="server"></asp:Literal>
                </td>
                <th height="35" width="90" align="right">
                    单位名称：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="lbBuyCompanyName" runat="server"></asp:Literal>
                </td>
            </tr>
            
            <tr class="odd">
                <th height="35" width="90" align="right">
                    备注：
                </th>
                <td align="left" colspan="3" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtRemark" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
        <%--<table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="40" bgcolor="#E3F1FC" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnsave" runat="server" class="save" href="javascript:;">提交修改</a>
                                    </td>
                                    <td align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnback" class="back" runat="server" href="javascript:;">返回</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>--%>
    </div>
    <%--<input type="hidden" value="" runat="server" id="hidsource" />--%>
    </form>
</body>
</html>

<%--<script type="text/javascript">
    var ScenicOrderEdit = {
        PageInit: function() {
            $("#<%=btnsave.ClientID %>").click(function() {
                if (!ScenicOrderEdit.CheckForm()) {
                    return false;
                }
                $("#<%=btnsave.ClientID %>").html("提交中...").unbind("click").css({ "color": "#999999" });
                if ($("#sltscenci").val() == "0") {
                    tableToolbar._showMsg("请选择景区!");
                    return false;
                }
                if ($("#slttickettype").val() == "0") {
                    tableToolbar._showMsg("请选择景区类型!");
                    return false;
                }
                ScenicOrderEdit.GoAjax('/WebMaster/ScenicAndTicketManage/ScenicOrderEdit.aspx?type=save&dotype=' + '<%=Request.QueryString["dotype"] %>' + "&orderid=" + '<%=Request.QueryString["orderid"] %>');
                return false;
            })
            $("#<%=btnsave.ClientID %>").html("提交修改").css({ "color": "" });
            $("#btnback").click(function() {
                parent.location.href = "/WebMaster/ScenicAndTicketManage/ScenicOrderList.aspx";
                return false;
            })
            $("#sltscenci").change(function() {
                var url = "/WebMaster/ScenicAndTicketManage/ScenicOrderEdit.aspx?scenicid=" + $(this).val() + "&dotype=showticket";
                ScenicOrderEdit.AjaxTicket(url);
                return false;
            })
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
                        parent.tableToolbar._showMsg(ret.msg, function() { ScenicOrderEdit.PageInit(); });
                    }
                },
                error: function() {
                    parent.tableToolbar._showMsg(tableToolbar.errorMsg, function() { ScenicOrderEdit.PageInit(); });
                }
            });
        },
        AjaxTicket: function(url) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "html",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(result) {
                    $("#slttickettype").html(result);
                },
                error: function() {
                    parent.tableToolbar._showMsg(tableToolbar.errorMsg, function() { ScenicOrderEdit.PageInit(); });
                }
            });
        },
        CheckForm: function() {
            return ValiDatorForm.validator($("#<%=btnsave.ClientID %>").closest("form").get(0), "parent");
        }
    }

    $(document).ready(function() {
        ScenicOrderEdit.PageInit();
    })
</script>--%>

