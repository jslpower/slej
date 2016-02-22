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
</head>
<body>
    <div class="index_head">
        <div class="logo">
            <%=Logourl %></div>
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
                    <li><a href="<%= PCUrl%>">电脑版</a></li>
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
        <div class="user-mask-i" style="height:560px;margin:-300px 0 0 -119px">
            <div class="font18 font_gray cent">
                扫描收藏我的微名片</div>
            <div class="cent code_big">
                <img src="/ErWeiMa.aspx?d=1&codeurl=<%=thisurl %>" /></div>
            <div class="cent font_gray">
                长按二维码保存到手机<br>
                可印在纸质名片和宣传单上</div>                
            <div class="font18 font_gray cent">
                <br />扫描二维码下载APP</div>
            <div class="cent code_big">
                <img src="http://m.slej.cn/ErWeiMa.aspx?d=1&codeurl=<%=appurl %>" /></div>
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
</script>

<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

<script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
</script>

<script type="text/javascript">
    wx.ready(function() {
        //分享到朋友圈
        wx.onMenuShareTimeline({
            title: '<%=FenXiangBiaoTi %>',
            link: '<%= FenXiangLianJie %>',
            imgUrl: '<%=FenXiangTuPianFilepath %>'
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
