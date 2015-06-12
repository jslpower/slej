<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>杭州金奥国际旅行社-网站后台</title>
</head>
<frameset id="attachucp" framespacing="0" border="0" frameborder="no" cols="*" rows="100,*">
    <frame src="Top.aspx" name="topFrame" scrolling="No" style=" padding-right:20px" noresize />
    <frameset id="attachucp1" framespacing="0" border="0" frameborder="no" cols="200,10,*" rows="*">
    <frame noresize="" scrolling="yes" frameborder="no" name="leftFrame" src="LeftMenuList.aspx"  >
    </frame>
    <frame id="leftbar" scrolling="no" noresize="" name="leftbar" src="swich.html"></frame>
    <frame scrolling="yes" noresize="" border="0" name="mainFrame" src="<%= rightUrl%>"  style=" padding-right:20px"></frame>
</frameset>
</frameset>

<noframes>
</noframes>
</html>
