<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenSi.aspx.cs" Inherits="EyouSoft.WAP.Member.FenSi" %>

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
                <li><asp:Literal ID="ltrName" runat="server"></asp:Literal></li>
                <li>用户名：<asp:Literal ID="ltrUser" runat="server"></asp:Literal></li>   
                <li>手机：<asp:Literal ID="ltrMoblie" runat="server"></asp:Literal></li>
                <li>网站名称：<asp:Literal ID="litWebSite" runat="server"></asp:Literal></li>
                <li>注册时间：<asp:Literal ID="CreatTime" runat="server"></asp:Literal></li>
                <li>到期时间：<asp:Literal ID="CherkTime" runat="server"></asp:Literal></li>
                <li>交易记录：<a href="/Member/FenSiJiaoYi.aspx?fensiid=<%=HuiYuanId %>">查看交易</a></li>
            </ul>
        </div>
    </div>
</body>

</html>
