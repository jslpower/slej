<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MallType.aspx.cs" Inherits="EyouSoft.WAP.Mall.MallType" %>


<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>商城分类</title>
<link rel="stylesheet" href="/css/style.css" type="text/css" media="screen">
<link rel="stylesheet" href="/css/mall.css" type="text/css" media="screen">
<script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>

</head>

<body>

  <div class="mall_head">
    <div class="mall_headbox">
        <a id="back_btn_a" href="javascript:window.history.go(-1);"><i class="icon_fanhui"></i></a>
         <div class="search ">
         <form id="form2">
                   <div class="search_form clearfix">
                       <input type="text" class="input_txt floatL" placeholder="商品名称" id="cName" name="cName" value='<%= EyouSoft.Common.Utils.GetQueryStringValue("cName") %>'>
                       <input id="SearchBnt" type="button" class="icon_search_i floatR">
                   </div>
                   </form>
        </div>
        
    </div>
  </div>
  
<div class="warp" style="margin-top:50px;">
  <div class="mall_type">
      <asp:Literal ID="MTypeList" runat="server"></asp:Literal>
     
  </div>
</div>
  <script type="text/javascript">
        $("#SearchBnt").click(function() {
           window.location="/Mall/ModList.aspx?cName="+$("#cName").val();
        })
    </script>
</body>
</html>
