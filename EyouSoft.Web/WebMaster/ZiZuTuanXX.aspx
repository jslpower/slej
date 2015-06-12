<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiZuTuanXX.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ZiZuTuanXX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>
</head>
<body>
    <div style="width: 100%; margin: 0px auto;">
        <table border="0" class="tchuang" style="width: 100%">
            <tr class="odd">
                <th height="25" align="right" width="20%">
                    订单号：
                </th>
                <td align="left" bgcolor="#E3F1FC" width="30%">
                    <asp:Literal ID="OrderCode" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right" width="20%">
                    线路名称：
                </th>
                <td align="left" bgcolor="#E3F1FC" width="30%">
                    <asp:Literal ID="XianLuName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    出发城市：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="Chengshi" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    出发日期：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="ChufaTime" runat="server"></asp:Literal>
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    成团人数：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="RenShu" runat="server"></asp:Literal>
                </td>
                <th height="25" align="right">
                    航班：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="HangBan" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    人均车费：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <asp:Literal ID="CarMoney" runat="server"></asp:Literal>元
                </td>
                <th height="25" align="right">
                    导游：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    需要<asp:Literal ID="DaoYouNum" runat="server"></asp:Literal>
                    名全陪导游，人均<asp:Literal ID="DaoYouFei" runat="server"></asp:Literal>元，<asp:Literal ID="DiPeiDaoYouNum" runat="server"></asp:Literal>
                    名地陪导游，人均<asp:Literal ID="DiPeiFei" runat="server"></asp:Literal>元
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    餐务标准：
                </th>
                <td align="left" bgcolor="#E3F1FC" colspan="3">
                    增加早餐<asp:Literal ID="ZaoCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="ZaoCanMoney" runat="server"></asp:Literal>元
                    <br />
                    增加午餐<asp:Literal ID="WuCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="WuCanMoney" runat="server"></asp:Literal>元
                    <br />
                    增加晚餐<asp:Literal ID="WanCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="WanCanMoney" runat="server"></asp:Literal>元
                    <br />
                    总共人均<asp:Literal ID="CanWuFei" runat="server"></asp:Literal>元
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    保险：
                </th>
                <td align="left" bgcolor="#E3F1FC" colspan="3">
                   <asp:Literal ID="BaoXian" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    租车：
                </th>
                <td align="left" bgcolor="#E3F1FC" colspan="3">
                    <table border="0" class="tchuang" style="width: 100%">
                    <thead>
                    <tr>
                    <td>起点</td><td>终点</td><td>车型</td><td>数量</td><td>公里数</td><td>价格</td>
                    </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#BDDCF4" : "#E3F1FC" %>">
                         <td><%# Eval("QiDian")%></td><td><%# Eval("ZhongDian")%></td><td><%# GetCheName(Eval("ZucheId"))%></td><td><%# Eval("CheNum")%></td><td><%# Eval("GongLiShu")%></td><td><%# Eval("FeiYong")%></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot><tr><td colspan="5">人均<asp:Literal ID="ZuCheFei" runat="server"></asp:Literal>元</td></tr></tfoot>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    自组团增加总价：
                </th>
                <td align="left" bgcolor="#E3F1FC" colspan="3">
                    <asp:Literal ID="ZongMoney" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    操作人：
                </th>
                <td align="left" bgcolor="#E3F1FC" colspan="3">
                    <asp:Literal ID="CaoZuoRen" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    价格：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    成人价：<asp:Literal ID="ChengRenJia" runat="server"></asp:Literal>元
                    <br />
                    儿童价：<asp:Literal ID="ETJia" runat="server"></asp:Literal>元
                    <br />
                    总价：<asp:Literal ID="ZongJia" runat="server"></asp:Literal>
                </td>
            </tr>
            
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
    </div>
    </form>
</body>
</html>
