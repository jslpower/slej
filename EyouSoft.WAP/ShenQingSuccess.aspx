<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShenQingSuccess.aspx.cs" Inherits="EyouSoft.WAP.ShenQingSuccess" %>
<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>申请成功</title>
<link rel="stylesheet" href="/css/style.css" type="text/css" media="screen">
<script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>

<body>

  <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="申请成功" />
  
  <div class="warp">
     
     <div class="reg_ok cent font_yellow font26">恭喜！申请成功</div>
     <div class="t10  padd10 cent font16">
         <asp:Literal ID="XinXi" runat="server"></asp:Literal></div>
     
     
  </div>
  

  
</body>
<script type="text/javascript">
        var second = parseInt($("#second").html());
        var timer;
        function change() {
            second--;
            if (second > -1) {
                $("#second").html(second);
                timer = setTimeout('change()', 1000); //调用自身实现
            }
            else {
                window.location.href = "/Member/UpdateMember.aspx"
            }
        }
        //timer = setTimeout('change()', 1000);
    </script>
</html>
