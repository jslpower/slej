<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoblieSheZhi.aspx.cs" Inherits="EyouSoft.WAP.Member.MoblieSheZhi" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>手机栏目设置</title>
<link rel="stylesheet" href="css/style.css" type="text/css" media="screen">


</head>

<body>
   <uc1:WapHeader runat="server" ID="WapHeader1" />
  
  
<div class="warp">
    
       <div class="about_title">手机栏目设置</div>
    
       <div class="jq_cont font_gray mt10 indent">
           <asp:Literal ID="WapSet" runat="server"></asp:Literal>
       </div>

     
</div>
  

  
</body>
</html>
