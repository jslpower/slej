<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrderLog.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.HotelManage.HotelOrderLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <th scope="col">
                        序号
                    </th>
                    <th scope="col">
                        订单号
                    </th>
                    <th scope="col">
                        操作单位
                    </th>
                    <th scope="col">
                        操作员
                    </th>
                    <th scope="col">
                        类型
                    </th>
                    <th scope="col">
                        操作日期
                    </th>
                    <th scope="col">
                        操作描述
                    </th>
                </tr>
                <asp:Repeater ID="rpt_OrderLog" runat="server">
                    <ItemTemplate>
                        <tr  class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td>
                                <%# Container.ItemIndex + 1 %>
                            </td>
                            <td>
                                104881309
                            </td>
                            <td>
                                易诺管路
                            </td>
                            <td>
                                杜丹丹
                            </td>
                            <td align="center">
                                酒店
                            </td>
                            <td>
                                2011-9-16 16:37:40
                            </td>
                            <td>
                                <span class="orderState">订单接受预订</span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
