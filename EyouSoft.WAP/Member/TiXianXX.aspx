<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiXianXX.aspx.cs" Inherits="EyouSoft.WAP.Member.TiXianXX" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>提现详情</title>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan_xx mt10">
            <ul>
                <li>交易编号：<asp:Literal ID="JiaoYiHao" runat="server"></asp:Literal></li>
                <li>提现日期：<asp:Literal ID="litInTime" runat="server"></asp:Literal></li>
                <li>提现金额：<i class="font22 font_yellow">
                    <asp:Literal ID="litJinE" runat="server"></asp:Literal></i></li>
                <li>开户银行：<asp:Literal ID="BankName" runat="server"></asp:Literal></li>
                <li>开户姓名：<asp:Literal ID="UserName" runat="server"></asp:Literal></li>
                <li>银行帐号：<asp:Literal ID="BankNum" runat="server"></asp:Literal></li>
                <li>提现状态：<asp:Literal ID="TiXianStatus" runat="server"></asp:Literal></li>
                <li>审核状态：<asp:Literal ID="ShenHeStatus" runat="server"></asp:Literal></li>
                <li>提现备注：<asp:Literal ID="TiXianBZ" runat="server"></asp:Literal></li>
                <li>审核备注：<asp:Literal ID="ShenHeBZ" runat="server"></asp:Literal></li>
            </ul>
        </div>
    </div>
</body>

</html>
