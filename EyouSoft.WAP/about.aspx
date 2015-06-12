<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="EyouSoft.WAP.about" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>关于我们</title>


<script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
<div class="warp">
    
       <div class="about_title">关于商旅e家</div>
    
       <asp:Literal ID="SLEJ" runat="server"></asp:Literal>

     
</div>
  

  
</body>
</html>