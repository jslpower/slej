(function (window) {
 


var fxPublic = {
    ShareSDKAppKey: '68c674555f80',
    WeiXinAppId: 'wx652dcc845dac8507',
    WeiXinAppSecret: '38d9147bb0bd3e8f604aa5aee5679837',
    fximgUrl: "",
    ShareTitle:"",
    ShareDescription:"",
    fxwebpageUrl:""
}
//分享Start
function shareinit() {
    $sharesdk.open(fxPublic.ShareSDKAppKey, true);
    var wxConf = {};
    wxConf["app_key"] =fxPublic.WeiXinAppId;
    wxConf["app_secret"] = fxPublic.WeiXinAppSecret;
    //            wxConf["redirect_uri"] = window.location.href;
    $sharesdk.setPlatformConfig($sharesdk.platformID.WeChatSession, wxConf);
    $sharesdk.setPlatformConfig($sharesdk.platformID.WeChatTimeline, wxConf);
};

var ipage = {
shareoption: { webpageUrl: fxPublic.fxwebpageUrl, title: fxPublic.ShareTitle, description: fxPublic.ShareDescription, imgUrl: fxPublic.fximgUrl },
    shareonsuccess: function(result) {
        var _s = JSON.stringify(result);
        console.log(_s);
        alert(_s);
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
//分享End
window.$fxPublic = fxPublic;
window.$ipage = ipage;



})(window)
