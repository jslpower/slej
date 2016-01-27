<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrderEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.HotelManage.HotelOrderEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            background: #BDDCF4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
                     <table border="0" class="tchuang" style="width: 100%">
                        <tr sizcache="24" sizset="77">
                            <th width="146" height="28" align="right">
                                订单编号：
                            </th>
                            <td height="28" width="607" sizcache="24" sizset="77" bgcolor="#E3F1FC">
                                <asp:Literal ID="orderCode" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th height="28" align="right">
                                酒店名称：
                            </th>
                            <td height="28" bgcolor="#E3F1FC">
                                <asp:Literal ID="hotelName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr runat="server" id="trBuyCompanyName">
                            <th height="28" align="right">
                               单位名称：
                            </th>
                            <td height="28" bgcolor="#E3F1FC">
                                <asp:Literal ID="lbBuyCompanyName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="78">
                            <th height="28" align="right">
                                预订日期：
                            </th>
                            <td height="28" sizcache="24" sizset="78" bgcolor="#E3F1FC">
                                <asp:Label ID="destineDate" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="80">
                            <th align="right">
                                入住日期：
                            </th>
                            <td sizcache="24" sizset="80" bgcolor="#E3F1FC">
                                <asp:Literal ID="txt_inDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="80">
                            <th align="right">
                                离开日期：
                            </th>
                            <td sizcache="24" sizset="80" bgcolor="#E3F1FC">
                                <asp:Literal ID="txt_outDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="80">
                            <th align="right">
                                房间数：
                            </th>
                            <td sizcache="24" sizset="80"  bgcolor="#E3F1FC">
                                <asp:Literal ID="txt_roomNum" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="82">
                            <th height="28" align="right">
                                金额：
                            </th>
                            <td height="28" sizcache="24" sizset="82" bgcolor="#E3F1FC">
                                <asp:Literal ID="orderMoney" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="84">
                            <th height="7" align="right">
                                联系人姓名：
                            </th>
                            <td height="0" sizcache="24" sizset="84" bgcolor="#E3F1FC">
                                <asp:Literal ID="txt_linkName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="84">
                            <th height="7" align="right">
                                联系人手机：
                            </th>
                            <td height="0" sizcache="24" sizset="84" bgcolor="#E3F1FC">
                                <asp:Literal ID="txt_linkMobil" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="84">
                            <th height="7" align="right">
                                订单状态：
                            </th>
                            <td height="0" sizcache="24" sizset="84" bgcolor="#E3F1FC">
                                <asp:Literal ID="orderState" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="84">
                            <th height="7" align="right">
                                付款状态：
                            </th>
                            <td height="0" sizcache="24" sizset="84" bgcolor="#E3F1FC">
                                <asp:Literal ID="PayState" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr sizcache="24" sizset="84">
                            <th height="14" align="right">
                                备注：
                            </th>
                            <td height="0" sizcache="24" sizset="84" bgcolor="#E3F1FC">
                                <asp:Literal ID="txt_hotelback" runat="server"></asp:Literal>
                            </td>
                        </tr>
                         
                    </table>
                    <table border="0" class="tchuang" style="width: 100%">
                    <tr>
                    <td colspan="3" style=" font-size:16px; font-weight:bold; text-align:center"> 酒店价格列表 </td>
                    </tr>
                        <tr sizcache="24" sizset="77">
                            <th width="146" height="28" align="right" style=" font-size:13px; font-weight:bold; text-align:center">
                                日期
                            </th>
                            <td height="28" width="300"  bgcolor="#E3F1FC" style=" font-size:13px; font-weight:bold; text-align:center">
                                金额
                            </td>
                            <td height="28" width="300"   bgcolor="#E3F1FC" style=" font-size:13px; font-weight:bold; text-align:center">
                                分销金额
                            </td>
                        </tr>
                        <asp:Literal ID="XC" runat="server"></asp:Literal>
                    </table>
                    <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
    </div>
    </form>

    <%--<script type="text/javascript">
        $(function() {
            $("#btnsave").click(function() {
                $(this).html("提交中...").unbind("click").css({ "color": "#999999" });
                var id = '<%=Request.QueryString["id"] %>';
                var hotelid = '<%=Request.QueryString["hotelid"] %>';
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: '/WebMaster/HotelManage/HotelOrderEdit.aspx?dotype=save&id=' + id + '&hotelid=' + hotelid + '',
                    dataType: "json",
                    data: $("#btnsave").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = 'HotelOrderList.aspx'; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { window.location.href = window.location.href; });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
                return false;
            });
            $("#btnback").click(function() {
                window.location.href = "HotelOrderList.aspx";
            });
            $("#txt_roomNum").keyup(function() {
                var num = tableToolbar.getFloat($("#txt_roomNum").val());
                var price = tableToolbar.getFloat($("#lbl_singPrice").html());
                $("#orderMoney").val(num * price);

            });

            var Tatol = '<%=EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>';
            if (Tatol == 'Tatol') {
                $("#tblCaoZuo").attr("style", "display:none;");
            }
        });
    </script>--%>

</body>
</html>
