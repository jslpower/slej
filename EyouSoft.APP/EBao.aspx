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
 <script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
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
                <img src="/ErWeiMa.aspx?codeurl=<%=HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("p.","m.") %>" />
            </p>
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

<script type="text/javascript">
    var fxPublic = {
        ShareSDKAppKey: '68c674555f80',
        WeiXinAppId: 'wxc976c6687dd92ebf',
        WeiXinAppSecret: '136f9bdf765f783f67f885fcde38c562',
        fximgUrl: '<%=FenXiangTuPianFilepath %>',
        ShareTitle: '<%=FenXiangMiaoShu %>',
        ShareDescription: '<%=FenXiangMiaoShu %>',
        fxwebpageUrl: '<%=FenXiangLianJie %>'
    }
    //分享Start
    function shareinit() {
        $sharesdk.open(fxPublic.ShareSDKAppKey, true);
        var wxConf = {};
        wxConf["app_key"] = fxPublic.WeiXinAppId;
        wxConf["app_secret"] = fxPublic.WeiXinAppSecret;
        //            wxConf["redirect_uri"] = window.location.href;
        $sharesdk.setPlatformConfig($sharesdk.platformID.WeChatSession, wxConf);
        $sharesdk.setPlatformConfig($sharesdk.platformID.WeChatTimeline, wxConf);
    };

    var ipage = {
        shareoption: { webpageUrl: fxPublic.fxwebpageUrl, title: fxPublic.ShareTitle, description: fxPublic.ShareDescription, imgUrl: fxPublic.fximgUrl },
        shareonsuccess: function(result) {
            var _s = JSON.stringify(result);
            alert(_s);
            console.log(_s);


            //                ipage.ShowMsg(result.xiaoxi);
        },
        shareonerror: function(message) {
            alert(message);
            console.log('分享错误信息：' + message);
        },
        weixinhaoyoushare: function() {

            //注：options.imgUrl指定的图片大小不能超过32KB，否则分享将会不成功
            //var _options = {webpageUrl:"http://www.enowinfo.com",title:"我是分享的标题2",description:"我是分享的内容2",imgUrl:"http://a.hiphotos.baidu.com/baike/s%3D220/sign=670fbb9e7e1ed21b7dc929e79d6fddae/8326cffc1e178a82599a55ccf503738da977e83c.jpg"};
            alert("微信好友");
            window.eNow.fenXiang.weiXin.haoYou(ipage.shareonsuccess, ipage.shareonerror, ipage.shareoption);
        },
        weixinpengyoushare: function() {

            //注：options.imgUrl指定的图片大小不能超过32KB，否则分享将会不成功
            //var _options = {webpageUrl:"http://www.baidu.com",title:"我是分享的标题1",description:"我是分享的内容1",imgUrl:"http://www.baidu.com/img/baidu_jgylogo3.gif"};
            alert("朋友圈");
            window.eNow.fenXiang.weiXin.pengYouQuan(ipage.shareonsuccess, ipage.shareonerror, ipage.shareoption);
        }
    }
</script>

</html>
