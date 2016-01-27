<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDanMingXi.aspx.cs" Inherits="EyouSoft.WAP.Member.DingDanMingXi" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>订单明细</title>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan_xx mt10">
            <ul>
                <li><asp:Literal ID="ltrDingDanName" runat="server"></asp:Literal></li>
                <li>订单类型：<asp:Literal ID="DingDanType" runat="server"></asp:Literal></li>   
                <li>订单编号：<asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal></li>
                <li>预订日期：<asp:Literal ID="litInTime" runat="server"></asp:Literal></li>
                <li>订单金额：<i class="font22 font_yellow">
                    <asp:Literal ID="litJinE" runat="server"></asp:Literal></i></li>
                <li>分销金额：<asp:Literal ID="FenXianJinE" runat="server"></asp:Literal></li>
                <li>分销利润：<asp:Literal ID="FenXiaoLiRun" runat="server"></asp:Literal></li>
                <li>订单状态：<asp:Literal ID="orderstatus" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="mt10 user_T font16">客人信息</div>
        <div class="user_dindan">
            <ul>
                <li style="border: none 0;">
                    <p>
                        客人名称：<asp:Literal ID="YuDingName" runat="server"></asp:Literal></p>
                    <p>
                        客人手机：<asp:Literal ID="YuDingMoblie" runat="server"></asp:Literal></p>
                </li>
            </ul>
        </div>
        <div class="mt10 user_T font16">预订人信息</div>
        <div class="user_dindan">
            <ul>
                <li style="border: none 0;">
                    <p>
                        预定人：<asp:Literal ID="txtYContact" runat="server"></asp:Literal></p>
                    <p>
                        手机：<asp:Literal ID="txtYContactTel" runat="server"></asp:Literal></p>
                </li>
            </ul>
        </div>
        <asp:Literal ID="xianshi" runat="server"></asp:Literal>
    </div>
</body>

</html>
