<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EBao.aspx.cs" Inherits="EyouSoft.WAP.EBao" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>E额宝</title>


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_form user_form2">
            <ul>
            <li class="R_jiantou" data-url="ebaoxx"><span class="label_name"><s class="ico_e03"></s>什么是E额宝?</span></li>
            <em data-id="xiangxi" style="display:none;">
            <asp:Literal ID="txtEbao" runat="server"></asp:Literal>
           </em>
                <asp:Literal ID="LinkList" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
</body>

<script type="text/javascript">
    $(".R_jiantou").click(function() {
        var url = $(this).attr("data-url");
        if (url == "ebaoxx") {
            $("em[data-id=xiangxi]").toggle();
        }
        else {
            window.location = url;
        }
    })
</script>

</html>
