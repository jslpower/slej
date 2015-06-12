<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShangCheng.OrderEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="110" height="30" align="center">
                    产品名称
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblChanPinMingCheng" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30" align="center">
                    下单日期:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblXiaDanRiQi" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    订单号:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblDingDanHao" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30" align="center">
                    订单金额：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblDingDanJinE" runat="server" Text=""></asp:Label>
                    <%-- <asp:TextBox ID="txtDingDanJinE" runat="server" class="inputtext formsize180"></asp:TextBox>--%>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    产品数量:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblChanPinShuLiang" runat="server" Text=""></asp:Label><%--
                    <asp:TextBox ID="txtChanPinShuLiang" runat="server" class="inputtext formsize180"></asp:TextBox>--%>
                </td>
                <th width="90" height="30" align="center">
                    订单状态:
                </th>
                <td bgcolor="#E3F1FC">
                <asp:Label ID="lblDingDanZhuangTai" runat="server" Text=""></asp:Label>
                 <%--   <select id="ddlDingDanZhuangTai" name="ddlDingDanZhuangTai">
                        <%=getOpt  %>
                    </select>--%>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    收货地址:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblShouHuoDiZhi" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30" align="center">
                    支付状态:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblZhiFuZhuangTai" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    下单人:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblXiaDanRen" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30" align="center">
                    联系电话:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblLianXiDianHua" runat="server" Text=""></asp:Label>
                    <%--<asp:TextBox ID="txtLianXiDianHua" runat="server" class="inputtext formsize180"></asp:TextBox>--%>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    订单备注:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:Label ID="lblBeiZhu" runat="server" Text=""></asp:Label>
                    <%--     <asp:TextBox TextMode="MultiLine" ID="txtDingDanBeiZhu" Height="60" name="txtShiYong"
                        runat="server" CssClass="inputtext formsize600"></asp:TextBox>--%>
                </td>
            </tr>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="left" colspan="4">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="96" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:;" id="btn" hidefocus="true">保存</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
    </div>
    </form>

    <script type="text/javascript">
        var pageData = {
            parm: { dotype: '<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>', id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>' },
            CheckForm: function() {
                return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            pageSave: function() {
                $.newAjax({
                    type: "post",
                    url: "OrderEdit.aspx?save=save&" + $.param(pageData.parm),
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
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
        }
        $(function() {
            $("#btn").click(function() { if (pageData.CheckForm()) { pageData.pageSave() } })
        })
    </script>

</body>
</html>
