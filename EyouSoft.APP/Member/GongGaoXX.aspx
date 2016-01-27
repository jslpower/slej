<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongGaoXX.aspx.cs" Inherits="EyouSoft.WAP.Member.GongGaoXX" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>会员中心</title>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
  <div class="warp">
    
       <div class="jq_cont mt10 gray_lineB">
           <div class="font16 cent"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></div>
           <div class="font_gray cent"> <asp:Label ID="lblTime" runat="server" Text=""></asp:Label></div>
        </div>
        
        <div class="jq_cont indent">
           <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
       </div>
      <asp:Literal ID="PicHtml" runat="server"></asp:Literal>
</div>

  
</body>
</html>
