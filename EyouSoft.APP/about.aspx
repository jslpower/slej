<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="EyouSoft.WAP.about" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>关于我们</title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <style type="text/css">
        body{background:#fff;}
        .about_box img
        {
            width: 90%;
            display: block;
            margin: 5px auto;
        }
    </style>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="about_title">
            关于商旅e家</div>
        <div class="jq_cont mt10 padd10">
            <asp:Literal ID="SLEJ" runat="server"></asp:Literal>
        </div>
    </div>
</body>
</html>
