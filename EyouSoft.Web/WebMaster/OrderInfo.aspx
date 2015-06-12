<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.OrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预定信息</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    订单号:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbordercode" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30px" align="center">
                    下单时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lborderdate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    出发日期:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbleavedate" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30px" align="center">
                    人数:
                </th>
                <td bgcolor="#E3F1FC">
                    成人:<asp:Label ID="lbadultcount" runat="server" Text=""></asp:Label>
                    &nbsp; 儿童:
                    <asp:Label ID="lblertongshu" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    联系人:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    姓名:<asp:Label ID="lbcontactname" runat="server" Text=""></asp:Label>&nbsp; 性别:<asp:Label
                        ID="lbcontactsex" runat="server" Text=""></asp:Label>&nbsp; 手机:<asp:Label ID="lbcontactmobile"
                            runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    价格:
                </th>
                <td bgcolor="#E3F1FC">
                    成人:<asp:Label ID="lbadultprice" runat="server" Text=""></asp:Label>&nbsp; 儿童:<asp:Label
                        ID="lbchildprice" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30px" align="center">
                    合同金额:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbhetongmoney" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    订单状态:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lborderstatus" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30px" align="center">
                    付款状态:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbpaystatus" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    下单备注:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <p style="text-indent: 25px">
                        <asp:Label ID="lborderremark" runat="server" Text=""></asp:Label></p>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    处理备注:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <p style="text-indent: 25px">
                        <asp:Label ID="lbchuliremark" runat="server" Text=""></asp:Label></p>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    其他要求:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <p style="text-indent: 25px">
                        <asp:Label ID="lbother" runat="server" Text=""></asp:Label></p>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    游客名单:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                            <asp:Repeater runat="server" ID="rptcustomlist">
                            <HeaderTemplate>
                             <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tbl_Customer_AutoAdd">
                        <tbody>
                            <tr class="odd">
                                <th width="36" height="30">
                                    编号
                                </th>
                                <th>
                                    姓名
                                </th>
                                <th>
                                    性别
                                </th>
                                <th>
                                    证件类型
                                </th>
                                <th>
                                    证件号码
                                </th>
                                <th>
                                    联系电话
                                </th>
                            </tr>
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#E3F1FC" : "#BDDCF4" %>">
                                        <td height="30" align="center">
                                            <b>
                                                <%#Container.ItemIndex+1 %>
                                            </b>
                                        </td>
                                        <td align="center">
                                            <%#Eval("Name")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("Gender").ToString()%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("ZhengJianType").ToString()%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("ZhengJianCode")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("Telephone")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                </tbody>
                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        
                </td>
            </tr>
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
    </div>
    </form>
</body>
</html>
