﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiuXianYuLe.aspx.cs" Inherits="EyouSoft.WAP.Mall.XiuXianYuLe" %>

<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title><%=FenXiangBiaoTi %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="休闲娱乐会所" />
    <div class="warp">
        <div id="mall_menu">
            <div class="nav_ico"><i></i></div> 
        </div>

        <div class="jq_search">
            <div class="search ">
                <form id="form2">
                <div class="search_form clearfix">
                    <input type="text" class="input_txt floatL" placeholder="商家导航" name="cName" value='<%= EyouSoft.Common.Utils.GetQueryStringValue("cName") %>'>
                    <input type="button" id="SearchBnt" class="icon_search_i floatR" />
                </div>
                </form>
            </div>
        </div>
        <!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
        <div class="mall_nav mt10">
            <ul>
                <li><a href="ModList.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        会员供销商城</div>
                </a></li>
                <li><a href="ShangChengLianMeng.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        购物广场联盟</div>
                </a></li>
                <li><a href="XiuXianYuLe.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        休闲娱乐会所</div>
                </a></li>
                <li><a href="ShangLvEJia.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        天下商旅e家</div>
                </a></li>
            </ul>
        </div>
        <div class="mall_list mt10">
            <h2>
                休闲娱乐会所</h2>
            <ul class="clearfix">
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="img_box">
                                <a href="<%# Eval("SiteUrl")%>">
                                    <img src='<%# retuImgUrl( Eval("ImgFile"))%>' title="<%# Eval("LeiBieMingCheng") %>"></a></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</body>

<script type="text/javascript">
    $("#SearchBnt").click(function() {
        $("#form2").submit();
    })
    $(".nav_ico").click(function(){           window.location ="/Mall/MallType.aspx?MType=2";        })
    $(".main_visual").css("margin-top", "56px");
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
