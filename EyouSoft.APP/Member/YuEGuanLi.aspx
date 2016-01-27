<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuEGuanLi.aspx.cs" Inherits="EyouSoft.WAP.Member.YuEGuanLi" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>账户余额</title>
    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="账户余额" />
  
  <div class="warp">

    <div class="user_form">
       <ul>
           <li>
              <span class="label_name">剩余金额：</span>
               <asp:Literal ID="ShengYuJInE" runat="server"></asp:Literal>
           </li>
           <li>
              <span class="label_name">冻结金额：</span>
               <asp:Literal ID="DongJieJinE" runat="server"></asp:Literal>
           </li>
           <li>
              <span class="label_name">可用金额：</span>
               <asp:Literal ID="KeYongJinE" runat="server"></asp:Literal>
           </li>
      </ul>
     </div>
     <div class="padd cent caozuo_box">
        <ul>
            <li class="box y_btn"><a href="/Member/ChongZhi.aspx">充值</a></li>
            <li class="box g_btn"><a href="/Member/TiXian.aspx">提现</a></li>
        </ul>
     </div>

     <div class="padd cent"><a href="/Member/ZhiFuMiMa.aspx" class="b_btn">设置支付密码</a></div>
  </div>
  

  
</body>
</html>