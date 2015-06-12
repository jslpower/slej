<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Top" %>

<%@ Import Namespace="EyouSoft.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="/Css/webmaster/manager.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div style=" width:100%; height:100px; background-color:#008fde;">
<div style="background-image:url(/Images/guanlihoutai.jpg); float:left; height:100px; width:498px;"></div>
<div style=" height:100px; width:200px; float:right; padding-top:20px;">
<a href="#" onclick="parent.history.back(-1);" style=" color:White">返回上一页</a><br /><br />
<a href="#" onclick="parent.mainFrame.location.href='/WebMaster/UntreatedOrders.aspx'" style=" color:White" >回到首页<br /><br />
<a href="logout.aspx" target="_top" style=" color:White;">退出管理系统</a>
</div>
</div>
    <%--<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#f5f5f5">
        <tr>
            <td width="10%" height="30" align="right">
                <a href="#" onclick="parent.history.back(-1);">返回</a>
            </td>
            <td width="90%" align="right">
                &nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/webmaster/tuic.gif" width="9"
                    height="9" />&nbsp;<a href="logout.aspx" target="_top">退出管理系统</a>&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>--%>
</body>
</html>
