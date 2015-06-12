<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinUs.aspx.cs" Inherits="EyouSoft.WAP.JoinUs" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>加入我们</title>

<script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
<div class="warp">
    
       <div class="about_title">加入我们</div>
    
       <div class="about_box margin_T10">
         <dl>
            <dt><img src="images/join_01.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="FenXiao" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_02.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="GuiBing" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_03.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="PuTong" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_04.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="YingPing" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_05.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="Gongying" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         
      </div>

     
</div>
  

  
</body>
</html>