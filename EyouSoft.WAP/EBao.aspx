<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EBao.aspx.cs" Inherits="EyouSoft.WAP.EBao" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>
        <%=FenXiangBiaoTi %></title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_form user_form2">
            <ul>
                <li class="R_jiantou" data-url="ebaoxx"><span class="label_name"><s class="ico_e03">
                </s>什么是E额宝?</span></li>
                <em data-id="xiangxi" style="display: none;">
                    <asp:Literal ID="txtEbao" runat="server"></asp:Literal>
                </em>
                <asp:Literal ID="LinkList" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
        <div class="cent code_box mt10">
            <p>
                <img src="/ErWeiMa.aspx?codeurl=<%=HttpContext.Current.Request.Url.AbsoluteUri.ToLower() %>" />
            </p>
              <p>
                长按上方二维码</p>
            <p>
                分享给朋友~~</p>
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

</html>
