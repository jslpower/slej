<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelJieShao.aspx.cs" Inherits="EyouSoft.WAP.HotelJieShao" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>酒店介绍</title>

</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
  <div class="warp">
  
    <div class="hotel_xx_cont">
    
         <div class="jq_cont gray_line">
            <h2>
                <asp:Literal ID="HotelName" runat="server"></asp:Literal></h2>
         </div>
     
         <div class="jq_xx_cont ">
             <ul>
                <li>开业时间：<asp:Literal ID="KaiYe" runat="server"></asp:Literal></li>
                <li>楼层数量：<asp:Literal ID="LouCeng" runat="server"></asp:Literal></li>
                <li>装修时间：<asp:Literal ID="ZhuangXiu" runat="server"></asp:Literal></li>
                <li>房间数量：<asp:Literal ID="FangJian" runat="server"></asp:Literal></li>
                <li>酒店星级：<asp:Literal ID="XingJi" runat="server"></asp:Literal></li>
                <li>酒店电话：<asp:Literal ID="DianHua" runat="server"></asp:Literal></li>
                <li>酒店地址：<asp:Literal ID="DiZhi" runat="server"></asp:Literal></li>
                <li>周围景观： <asp:Literal ID="JIngGuang" runat="server"></asp:Literal></li>
             </ul>
         </div>		  

         <div class="jq_cont gray_line mt10">
            <h2>酒店介绍</h2>
         </div>
     
         <div class="jq_xx_cont ">
             <div><asp:Literal ID="JieShao" runat="server"></asp:Literal></div>
         </div>		  

         <div class="jq_cont gray_line mt10">
            <h2>设施交通</h2>
         </div>

         <div class="jq_xx_cont ">
             <asp:Literal ID="JiaoTong" runat="server"></asp:Literal>
         </div>		  

    </div>
         
     
  </div>
  

  
</body>
</html>
