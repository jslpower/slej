<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EJiaFenXiangInfo.aspx.cs"
    Inherits="EyouSoft.WAP.Member.EJiaFenXiangInfo" %>

<%@ Register Src="~/userControl/DaiLiDefault.ascx" TagName="DaiLiDefault" TagPrefix="uc1" %>
<%@ Register Src="~/userControl/MainDefault.ascx" TagName="MainDefault" TagPrefix="uc1" %>
<%@ Register Src="~/userControl/TwoDefault.ascx" TagName="TwoDefault" TagPrefix="uc2" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link href="/css/home.css" rel="stylesheet" type="text/css" />
    <link href="/css/fenxiang.css" rel="stylesheet" type="text/css" />
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />
    <link href="/css/fx.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>
<script type="text/javascript" src="../cordova.js"></script>
    <script type="text/javascript" src="../js/enow.core.js"></script>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="e家分享" />
    <div class="warp">
        <div class="cent"><img src="/images/1.jpg" style="width:100%; vertical-align:top;"></div>
       
       <div class="fenxiang_title"><img src="/images/fx_t.gif"></div>
        <div class="fenxiang_cont gray_lineB">
            <div class="cent font16">
                <asp:Label ID="lblTitle" runat="server"></asp:Label></div>
            <asp:Repeater ID="rptlist" runat="server">
                <ItemTemplate>
                    <div class="line_xx_cont">
                        <p>
                            <%# getImgSrc(Eval("ImgFile"),youjiid )%>
                        </p>
                        <p>
                            <%# Eval("XingChengContent")%>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="ltrLink" runat="server"></asp:Literal>
        </div>
        <div class="cent padd10 font_yellow" style="background: #fff; line-height: 2;">
            <p>
                <asp:Literal ID="ltrPrev" runat="server">上一篇:没有更多了</asp:Literal>
            </p>
            <p>
                <asp:Literal ID="ltrNext" runat="server">下一篇:没有更多了</asp:Literal>
            </p>
        </div>
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
                        <li><a href="/Member/EJiaFenXiang.aspx">E家分享</a></li>
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
                    长按二维码保存到手机<br>
                    可印在纸质名片和宣传单上</div>
            </div>
        </div>
    </div>

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
                window.location.href = "/searchlist.aspx?keyword=";
            }
            else {
                window.location.href = "/searchlist.aspx?keyword=" + $("#SearchWord").val();
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
                desc: '<%=FenXiangMiaoShu %>',
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

</body>
</html>
