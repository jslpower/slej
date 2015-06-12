<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelXiangQingImg.aspx.cs"
    Inherits="EyouSoft.Web.HotelXiangQingImg" %>

<% if (Model.Images != null)
   {
       for (int i = 0; i < Model.Images.Count; i++)
       {%>
<li><a href="javascript:;">
    <img src="<%=Model.Images[i].FilePath %>" /></a> </li>
<%}
       }%>