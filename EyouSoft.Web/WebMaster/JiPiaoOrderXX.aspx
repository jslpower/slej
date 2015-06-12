<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiPiaoOrderXX.aspx.cs" Inherits="EyouSoft.Web.WebMaster.JiPiaoOrderXX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机票订单详情</title>
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
                <th height="25" align="right">
                    航班名称：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="HangBanName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    航班号：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="HangBanHao" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    舱位：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="CangWei" runat="server"></asp:Literal>
                    
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
                <th height="25" align="right" width="20%">
                    下单时间：
                </th>
                <td align="left" bgcolor="#E3F1FC" width="30%">
                    <asp:Literal ID="XiaDanShiJian" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    出发时间：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="litLDate" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    票面价格：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="PiaoMianJia" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    订票人数：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="RenShuNum" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    税费金额：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ShuiFei" runat="server"></asp:Literal>
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
                    乘客信息：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tbl_Customer_AutoAdd">
                        <tbody>
                            <tr class="odd">
                                <th align="center">
                                    姓名
                                </th>
                                <th align="center">
                                    证件类型
                                </th>
                                <th align="center">
                                    证件号
                                </th>
                            </tr>
                            <asp:Repeater runat="server" ID="rptlist">
                                <ItemTemplate>
                                    <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#E3F1FC" : "#BDDCF4" %>">
                                        <td align="center">
                                            <%#Eval("XingMing")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("ZhengJianLeiXing")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("ZhengJianHao")%>
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
                </td>
                <th align="right">
                    付款状态：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="PayState" runat="server"></asp:Literal>
                </td>
            </tr>
            <%--<tr class="odd">
                <th height="25" align="right">
                    备注：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtBeiZhu" runat="server"></asp:Literal>
                </td>
            </tr>--%>
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
    </div>
    </form>

</body>
</html>
