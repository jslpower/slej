<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.HotelInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="99%" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th width="13%">
                        酒店名称
                    </th>
                    <td bgcolor="#E3F1FC" width="43%">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        &nbsp;照片&gt;&gt;
                    </td>
                    <td bgcolor="#E3F1FC" width="44%" rowspan="10">
                        <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        星级
                    </th>
                    <td bgcolor="#E3F1FC" nowrap="nowrap">
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        地址
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        地标区域
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        邮编
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        客服电话
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        开业时间
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        装修时间
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        房间总数
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        楼层数
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        酒店详细介绍
                    </th>
                    <td bgcolor="#E3F1FC" colspan="2">
                        <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        交通情况
                    </th>
                    <td bgcolor="#E3F1FC" colspan="2">
                        <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        额外收费
                    </th>
                    <td bgcolor="#E3F1FC" colspan="2">
                        <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        其它联系方式
                    </th>
                    <td bgcolor="#E3F1FC" colspan="2">
                        <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th colspan="3" nowrap="nowrap">
                        房型预定
                    </th>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        <br />
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th height="20" align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        房型
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        市场价
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        优惠价
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        结算价
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        早餐
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        床型
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        宽带
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        支付
                    </th>
                    <th align="middle" nowrap="nowrap" bgcolor="#ffffff">
                        数量
                    </th>
                </tr>
                <asp:Repeater ID="rpt_list" runat="server">
                    <ItemTemplate>
                        <tr class="odd">
                            <td bgcolor="#E3F1FC" nowrap="nowrap" align="middle">
                                <a href="/WebMaster/HotelManage/RoomImgInfo.aspx?roomid=<%# Eval("RoomTypeId")%>">
                                    <%# Eval("RoomName")%>
                                </a>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle">
                                <%# this.ToMoneyString( Eval("AmountPrice"))%>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle">
                                <%# this.ToMoneyString(Eval("PreferentialPrice"))%>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle">
                                <%# this.ToMoneyString(Eval("SettlementPrice"))%>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle">
                                <%# Eval("IsBreakfast").ToString()%>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle">
                                <%# ((int)Eval("BedType"))==0?(Eval("BedTypeDescription")??"").ToString():""%>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle">
                                <%# Eval("IsInternet").ToString()%>
                            </td>
                            <td bgcolor="#E3F1FC" align="middle" nowrap="nowrap">
                                <%# Eval("Payment").ToString()%>
                            </td>
                            <td bgcolor="#E3F1FC" valign="center" align="center">
                                <%# Eval("TotalNumber").ToString()%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
