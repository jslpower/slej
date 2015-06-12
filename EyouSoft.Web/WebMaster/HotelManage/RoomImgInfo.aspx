<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomImgInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.RoomImgInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        ul div
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="99%" border="0" align="center">
            <tr>
                <th>
                    所属酒店
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbl_hotelName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th width="10%">
                    房型名称
                </th>
                <td bgcolor="#E3F1FC" width="90%">
                    <asp:Label ID="lbl_typeName" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th>
                    数量
                </th>
                <td bgcolor="#E3F1FC" nowrap="nowrap">
                    <asp:Label ID="lbl_roomNum" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th>
                    床型
                </th>
                <td bgcolor="#E3F1FC">
                    <p>
                        <asp:Label ID="lbl_bedType" runat="server" Text=""></asp:Label>
                        &nbsp;</p>
                </td>
            </tr>
            <tr>
                <th>
                    能否加床
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbl_isAddBed" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th>
                    早餐
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbl_isContainBr" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th>
                    支付方式
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbl_payType" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th>
                    挂牌价
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbl_price" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th>
                    房型介绍
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbl_roomTypeInfo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    图片
                </th>
                <td bgcolor="#E3F1FC">
                    <ul style="width: 100%; padding: 0px;">
                        <asp:Repeater runat="server" ID="rpt_list">
                            <ItemTemplate>
                                <li style="width: 19%; padding: 0px; margin: 0px; float: left">
                                    <div>
                                        <img name="" src="<%# Eval("FilePath") %>" width="120" height="120" alt="<%# Eval("Desc") %>" /></div>
                                    <div>
                                        <%# Eval("Desc") %>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" nowrap="nowrap">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
                        <tbody>
                            <tr class="odd">
                                <td height="40" bgcolor="#E3F1FC" colspan="14">
                                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                                        <tbody>
                                            <tr>
                                                <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                                    <%--<a id="btnsave" class="save" href="javascript:;">提交</a>--%>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
