<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xingchengdan.aspx.cs" Inherits="EyouSoft.Web.print.xingchengdan"
    MasterPageFile="~/MasterPage/Print.Master" Title="散拼" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">
                    <asp:Literal ID="RouteName" runat="server"></asp:Literal></b>
            </td>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th width="100" align="right">
                出发地：
            </th>
            <td width="240">
                <asp:Literal ID="chufadi" runat="server"></asp:Literal>
            </td>
            <th width="100" align="right">
                旅游天数：
            </th>
            <td width="180">
                <asp:Literal ID="TianShu" runat="server"></asp:Literal>天
            </td>
        </tr>
        <tr>
            <th align="right">
                出团日期：
            </th>
            <td>
                <asp:Literal ID="LDate" runat="server"></asp:Literal>
            </td>
            <th align="right">
                返程时间：
            </th>
            <td>
                <asp:Literal ID="RDate" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                去程交通：
            </th>
            <td>
                <asp:Literal ID="ChuFaJiaoTong" runat="server"></asp:Literal>
            </td>
            <th align="right">
                返程交通：
            </th>
            <td>
                <asp:Literal ID="FanChengJiaoTong" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                集合地点：
            </th>
            <td>
                <asp:Literal ID="JiHeFangShi" runat="server"></asp:Literal>
            </td>
            <th align="right">
                送机人员：
            </th>
            <td>
                <asp:Literal ID="LxrName" runat="server"></asp:Literal><asp:Literal ID="LxrMobile"
                    runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                产品说明：
            </th>
            <td colspan="3">
                <asp:Literal ID="TeSe" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="Description" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                成人门市：<b class="fontred20">￥<asp:Literal ID="SCJCR" runat="server"></asp:Literal></b>元/人
                儿童门市：<b class="fontred20">￥<asp:Literal ID="SCJET" runat="server"></asp:Literal></b>元/人
            </td>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th width="80" align="center" class="small_title">
                日期
            </th>
            <th class="small_title">
                行程安排
            </th>
            <th width="60" align="center" class="small_title">
                <b class="font14">餐饮</b>
            </th>
            <th width="60" align="center" class="small_title">
                <b class="font14">住宿</b>
            </th>
        </tr>
        <asp:Repeater ID="rpt" runat="server">
            <ItemTemplate>
                <tr>
                    <th align="center" valign="middle">
                        第<%#Container.ItemIndex+1 %>天
                    </th>
                    <td>
                        <%#Eval("XingCheng")%>
                    </td>
                    <td align="center" width="60">
                        <%#Eval("YongCan") %>
                    </td>
                    <td align="center" width="60">
                        <%#Eval("ZhuSu")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <th height="30" align="left">
                产品接待标准
            </th>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="right" width="100">
                报名须知：
            </th>
            <td align="left">
                <asp:Literal ID="BaoMingXuZhi" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                费用包含：
            </th>
            <td align="left">
                <asp:Literal ID="FuWuBiaoZhun" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                费用不含：
            </th>
            <td align="left">
                <asp:Literal ID="BuHanXiangMu" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                儿童安排：
            </th>
            <td align="left">
                <asp:Literal ID="ErTongAnPai" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                购物站信息：
            </th>
            <td align="left">
                <asp:Literal ID="GouWuAnPai" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                自费项目：
            </th>
            <td align="left">
                <asp:Literal ID="ZiFeiXiangMu" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                温馨提醒：
            </th>
            <td align="left">
                <asp:Literal ID="WenXinTiXing" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                注意事项：
            </th>
            <td align="left">
                <asp:Literal ID="ZhuYiShiXiang" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                赠送项目：
            </th>
            <td align="left">
                <asp:Literal ID="ZengSongXiangMu" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th align="right">
                其他事项：
            </th>
            <td align="left">
                <asp:Literal ID="QiTaShiXiang" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <strong>
                    <asp:Literal ID="litWL" runat="server"></asp:Literal>
                    <asp:Literal ID="litKW" runat="server"></asp:Literal>
                    免费热线：400-6588-180&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 质监：0571-87290599&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    传真：0571-86978069&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 许可证号：L-ZJ01409 </strong>
                <br />
                <strong>公司地址：中国·杭州西湖区文三路569号康新商务大厦17楼1号厅; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;网址：<%=Request.Url.Host %></strong>
            </td>
        </tr>
    </table>
</asp:Content>
