<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XieYi.aspx.cs" Inherits="EyouSoft.WAP.Member.XieYi" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/zhifu.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

</head>
<body>
    <form id="form1">
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan font16 mt10">
            <ul>
                <li>商品名称：<asp:Label ID="lblchanpinmingcheng" runat="server" Text=""></asp:Label></li>
                <li>商品总价：<i class="font22 font_yellow">
                    <asp:Literal ID="TradeMoney" runat="server"></asp:Literal></i></li>
            </ul>
        </div>
        <div class="padd10 mt10" style="background: #fff; overflow: hidden;">
            <div>
                <asp:Literal runat="server" ID="txtXieYi"></asp:Literal>
            </div>
        </div>
        <div class="pay">
            <div class="pay_box">
                <a href="javascript:;" class="y_btn">同意并付款</a>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            parData: {
                Pay: '<%=EyouSoft.Common. Utils.GetQueryStringValue("Pay") %>',
                Classid: '<%=EyouSoft.Common. Utils.GetQueryStringValue("Classid") %>',
                id: '<%=EyouSoft.Common. Utils.GetQueryStringValue("id") %>',
                type: '<%=EyouSoft.Common. Utils.GetQueryStringValue("type") %>',
                token: '<%=EyouSoft.Common. Utils.GetQueryStringValue("token") %>' 
            }
        }
        $(function() {
            $(".y_btn").click(function() {
                window.location.href = "/Member/ZhiFu.aspx?" + $.param(pageOpt.parData)
            })
        })
    </script>

</body>
</html>
