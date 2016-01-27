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
                <img src="/ErWeiMa.aspx?codeurl=<%=HttpContext.Current.Request.Url.AbsoluteUri.ToLower() %>" />
            </p>
             <p>
                长按上方二维码</p>
            <p>
                分享给朋友~~</p>
        </div>
            <dl>
                <dd>
                    <div class="padd cent">
                        <input type="button" id="btn_shenq" class="y_btn" value="免费代理开通"></div>
                </dd>
            </dl>
        </div>
    </div>

    <script type="text/javascript">
        $("#btn_shenq").click(function() {
            window.location = "/ShenQing.aspx";
        });

    </script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
        var wx_jsapi_config = <%=weixin_jsapi_config %>;
        wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>

</body>
</html>
