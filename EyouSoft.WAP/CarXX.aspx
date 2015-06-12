<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarXX.aspx.cs" Inherits="EyouSoft.WAP.CarXX" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>

<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<!doctype html>
<html>
<head runat="server">
    <title>车辆详情</title>


<script src="/js/jquery_cm.js" type="text/javascript"></script> 
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
  
<div class="warp">
     
       <!--baner------------start-->
       
         <uc2:ScrollImg ID="ScrollImg1" runat="server" />
       <!--baner------------end-->
         
         <div class="jq_cont gray_line">
            <h2>
                <asp:Literal ID="CarName" runat="server"></asp:Literal></h2>
         </div>
     
         <div class="jq_xx_cont ">

                      <h3>车辆介绍：</h3>
             <asp:Literal ID="CarJieSao" runat="server"></asp:Literal>
         </div>		  
    
     
  </div>
</body>
</html>
