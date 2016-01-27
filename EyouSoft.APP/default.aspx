<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EyouSoft.WAP._default" %>

<%@ Register Src="~/userControl/DaiLiDefault.ascx" TagName="DaiLiDefault" TagPrefix="uc1" %>
<%@ Register Src="~/userControl/MainDefault.ascx" TagName="MainDefault" TagPrefix="uc1" %>
<%@ Register Src="~/userControl/TwoDefault.ascx" TagName="TwoDefault" TagPrefix="uc2" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title><%=FenXiangBiaoTi %></title>
    <link rel="stylesheet" href="/css/style.css" type="text/css" media="screen">
    <link href="/css/home.css" rel="stylesheet" type="text/css" />
    <link href="/css/fx.css" rel="stylesheet" type="text/css" />
      <link href="css/iconfont.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {

            window.eNow.ready();
        });
    </script>
</head>
<body>
    <div class="index_head">
        <div class="logo">
            <img src="/images/logo.png"></div>
        <div class="head_m">
            <a href="tel:<%= TelNum%>">
                <div class="i_tel">
                </div>
            </a>
            <div class="head_title">
                <%if (isfenxiao)
                  { %><%= companyName == "" ? "旅游有道，请找金奥！" : companyName%><%}
                  else
                  { %>旅游有道，请找金奥！<%} %></div>
            <div class="search">
                <div class="search_form clearfix">
                <a class="city_select"  href="/CommonPage/SelectSYCity.aspx"><%=CityName%></a>
                    <input type="text" id="SearchWord" name="SearchWord" class="input_txt floatL" value="目的地或关键词"
                        onfocus="javascript:if(this.value=='目的地或关键词')this.value='';" onblur="javascript:if(this.value=='')this.value='目的地或关键词';"
                        forecolor="#999999">
                    <input id="SearchBnt" type="button" class="icon_search_i floatR">
                </div>
            </div>
        </div>
    </div>
    <%if (isfenxiao)
      { %>
    <div class="msg_box">
        <div class="contact down_jiantou">
            <!------点击后up_jiantou------>
            <ul class="clearfix">
                <li class="box"><span class="radiusl">
                    <img src="<%= uTouXiang%>"></span><em class="font_yellow">外联：</em><asp:Literal ID="UName"
                        runat="server"></asp:Literal></li>
                <li class="box"><span class="radiusl">
                    <img src="<%= slTouXiang%>"></span><em class="font_yellow">客服：</em><%= slname%></li>
            </ul>
        </div>
        <div class="contact_more" style="display: none;">
            <ul>
                <li><em>手机：</em><asp:Literal ID="UMoblie" runat="server"></asp:Literal></li>
                <li><em>电话：</em><%= utel%></li>
                <li><em>微信：</em><%= uweixin%></li>
                <li><em>QQ：</em><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%= uqq%>&site=qq&menu=yes"><%= uqq%></a></li>
            </ul>
            <ul>
                <li><em>手机：</em><asp:Literal ID="SLMoblie" runat="server"></asp:Literal></li>
                <li><em>电话：</em><asp:Literal ID="SLTel" runat="server"></asp:Literal></li>
                <li><em>微信：</em><%= slweixin%></li>
                <li><em>QQ：</em><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%= slqq%>&site=qq&menu=yes"><%=slqq %></a></li>
            </ul>
        </div>
    </div>
    <%} %>
    <div class="warp" style="margin-top: 0;">
        <asp:PlaceHolder ID="MainD" runat="server">
            <uc1:MainDefault runat="server" ID="MainDefault1" />
            <uc2:TwoDefault runat="server" ID="TwoDefault1" />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="DaiLi" runat="server" Visible="false">
            <uc1:DaiLiDefault runat="server" ID="DaiLiDefault1" />
        </asp:PlaceHolder>
        <div class="foot_box">
            <div class="foot_menu">
                <ul class="clearfix">
                    <li><a id="afx" href="javascript:void(0);">分享到</a></li>
                    <li>
                        <%= houtaiurl%></li>
                    <li><a href="/JoinUs.aspx">加入我们</a></li>
                    <%if (!isfenxiao)
                      { %>
                    <li><a href="/about.aspx">关于我们</a></li>
                    <%}
                      else
                      { %>
                    <li><a href="/Member/EJiaFenXiang.aspx">e家分享</a></li>
                    <%} %>
                    <li><a id="erweima" href="javascript:void(0);">二维码</a></li>
                </ul>
            </div>
            <div class="cent paddR mt10">
                版权所有：<%=BanQuan %>
                <br />
                许可证号：<%= Xuke%></div>
            <div class="cent paddR mt10 font_gray">
                出境线均受天天商旅和深圳海外等社委托金奥国旅合法代理</div>
        </div>
    </div>
    <div id="ErWeiMaMask" class="user-mask" style="display: none;">
        <div class="user-mask-i">
            <div class="font18 font_gray cent">
                扫描收藏我的微名片</div>
            <div class="cent code_big">
                <img src="/ErWeiMa.aspx?d=1&codeurl=<%=thisurl %>" /></div>
            <div class="cent font_gray">
                可印在纸质名片和宣传单上</div>
        </div>
    </div>
    <!-----分享--------->
<div class="user-mask" data-div="head_fenxiang" style="display: none;" id="fenxiang">
    <div class="fenxiang-tx">
        <div class="fx_menu radius4">
            <ul>
                <li onclick="ipage.weixinhaoyoushare()">
                    <img src="../images/fx_weixin.png"><p>
                        发送给微信好友</p>
                </li>
                <li onclick="ipage.weixinpengyoushare()">
                    <img src="../images/fx_pengyouquan.png"><p>
                        分享到朋友圈</p>
                </li>
            </ul>
        </div>
        <div class="item mt10 radius4 fxquxiao">
            取消</div>
    </div>
</div>
</body>

<script type="text/javascript">
    $(".contact").click(function() {
        if ($(this).attr("class").indexOf('down') >= 0) {
            $(this).removeClass("down_jiantou").addClass("up_jiantou");
        }
        else {
            $(this).removeClass("up_jiantou").addClass("down_jiantou");
        }
        $(".contact_more").toggle();
    });
    $("#SearchBnt").click(function() {
        if ($("#SearchWord").val() == "目的地或关键词") {
            window.location.href = "/searchlist.aspx?cityid=<%=CityId %>&keyword=";
        }
        else {
            window.location.href = "/searchlist.aspx?cityid=<%=CityId %>&keyword=" + $("#SearchWord").val();
        }
    })
    $("#erweima").click(function() {
        $("#ErWeiMaMask").toggle();
    })
    $("#ErWeiMaMask").click(function() {
        $("#ErWeiMaMask").toggle();
    })

    $("#afx").click(function() {
        $("div[data-div=head_fenxiang]").toggle();
    });
    $(".fxquxiao").click(function() {
        $("div[data-div=head_fenxiang]").toggle();
    });
</script>
<!-----分享--------->
<script type="text/javascript">
    var fxPublic = {
        ShareSDKAppKey: '68c674555f80',
        WeiXinAppId: 'wx23b4841aaff3ad7e',
        WeiXinAppSecret: '75f1353f873294696b1d61588b92d8bd',
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
            console.log(_s);

            //                ipage.ShowMsg(result.xiaoxi);
        },
        shareonerror: function(message) {
            console.log('分享错误信息：' + message);
        },
        weixinhaoyoushare: function() {

            //注：options.imgUrl指定的图片大小不能超过32KB，否则分享将会不成功
            //var _options = {webpageUrl:"http://www.enowinfo.com",title:"我是分享的标题2",description:"我是分享的内容2",imgUrl:"http://a.hiphotos.baidu.com/baike/s%3D220/sign=670fbb9e7e1ed21b7dc929e79d6fddae/8326cffc1e178a82599a55ccf503738da977e83c.jpg"};
            window.eNow.fenXiang.weiXin.haoYou(ipage.shareonsuccess, ipage.shareonerror, ipage.shareoption);
        },
        weixinpengyoushare: function() {

            //注：options.imgUrl指定的图片大小不能超过32KB，否则分享将会不成功
            //var _options = {webpageUrl:"http://www.baidu.com",title:"我是分享的标题1",description:"我是分享的内容1",imgUrl:"http://www.baidu.com/img/baidu_jgylogo3.gif"};

            window.eNow.fenXiang.weiXin.pengYouQuan(ipage.shareonsuccess, ipage.shareonerror, ipage.shareoption);
        }
    }
</script>
</html>
