i<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EyouSoft.Web.index" %>
<%
if (!EyouSoft.Common.Utils.IsMobileDevice()||!string.IsNullOrEmpty(Request.QueryString["source"]) )
{
Response.Redirect("/default.aspx");
}
else
{
if(Request.Url.Host=="www.slej.cn")
   Response.Redirect("http://m.slej.cn/");
else
   Response.Redirect("http://m." + Request.Url.Host);
}
%>