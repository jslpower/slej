<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinUs.aspx.cs" Inherits="EyouSoft.WAP.JoinUs" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>
        <%=FenXiangBiaoTi %></title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
<script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
    <style type="text/css">
        body
        {
            background: #fff;
        }
        .about_box img
        {
            width: 90%;
            display: block;
            margin: 5px auto;
        }
    </style>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="加入商旅e家" />
    <div class="warp">
        <div class="about_title">
            加入我们</div>
        <div class="jq_cont mt10 padd10">
            <asp:Literal ID="JIARUWOMEN" runat="server"></asp:Literal>
                    <div class="cent code_box">
            <p>
                <img src="/ErWeiMa.aspx?codeurl=<%=HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("p.","m.") %>" />
            </p>
            
            <p>
                分享给朋友~~</p>
        </div>
           
        </div>
    </div>

    <script type="text/javascript">
        $("#btn_shenq").click(function() {
            window.location = "/ShenQing.aspx";
        });

    </script>

</body>
</html>
