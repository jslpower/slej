<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UntreatedOrders.aspx.cs" Inherits="EyouSoft.Web.WebMaster.UntreatedOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:15px;">
        <div style=" padding-bottom:20px; padding-left:10px;"><span style="font-size:20px; font-weight:bolder; color:rgb(21, 97, 167)">您好，截止到<%=Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd") %>,共有<span style="color:Red; font-weight:bold;">&nbsp;&nbsp;<asp:Label ID="lblCount" runat="server"></asp:Label>&nbsp;&nbsp;</span>位会员即将过有效日期。<a href="MemberCenter/MemberList.aspx?type=valid">查看明细</a></span></div>
    <div style=" padding-bottom:10px; padding-left:10px;"><span style="font-size:20px; font-weight:bolder; color:rgb(21, 97, 167)">您好，现阶段您还有以下订单未处理，请立即处理！</span></div>
    <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
    <thead>
    <tr class='odd' style="line-height:35px;"><td style="font-size:20px; text-align:center; font-weight:bolder;">订单类型</td><td style="font-size:20px; text-align:center; font-weight:bolder;">未处理</td><td style="font-size:20px; text-align:center; font-weight:bolder;">未付款</td><td style="font-size:20px; text-align:center; font-weight:bolder;">未返利</td><td style="font-size:20px; text-align:center; font-weight:bolder;">操作</td></tr>
    </thead>
    <tbody>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </tbody>
    </table>
    </div>
    </form>
</body>
</html>
