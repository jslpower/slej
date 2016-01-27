<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModList.aspx.cs" Inherits="EyouSoft.WAP.Mall.ModList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta charset="utf-8">
    <title><%=FenXiangBiaoTi %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="会员供销商城" />
    <div class="warp">
        <div id="mall_menu">
            <div class="nav_ico">
                <i></i>
            </div>
        </div>
        <form id="form2">
        <div class="jq_search">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="hidden" id="lid" name="lid" value='<%= EyouSoft.Common.Utils.GetQueryStringValue("lid") %>' />
                    <input type="text" class="input_txt floatL" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("cName") %>"
                        name="cName" placeholder="商品名称">
                    <input name="" type="button" class="icon_search_i floatR" id="searchBtn">
                </div>
            </div>
        </div>
        </form>
        <div class="mall_list" style="padding-top: 56px;">
            <h2>
                <asp:Label ID="lblTypeName" runat="server" Text=""></asp:Label>
            </h2>
            <div id="wrapper">
                <div id="scroller1">
                    <div id="a1">
                        <ul class="clearfix" id="linelist">
                            <asp:Repeater ID="rptlist" runat="server">
                                <ItemTemplate>
                                    <li class="liCount">
                                        <div class="img_box">
                                            <a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                                <img src='<%# retuImgUrl(Eval("ProductImgs")) %>' /></a></div>
                                        <div class="txt_box">
                                            <dl>
                                                <dt><a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                                    <%#  Eval("ProductName")%></a></dt>
                                                <dd>
                                                    <i class="line_x">¥<%# Eval("MarketPrice","{0:F0}") %></i></dd>
                                                <dd class="txt">
                                                    <i class="font_yellow">¥
                                                        <%# GetJINE( Eval("SalePrice"),Eval("MarketPrice"))%></i></dd>
                                            </dl>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                  
                        <div id="pullUp">  <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                            <span class="pullUpIcon"></span><span class="pullUpLabel"></span>  </asp:PlaceHolder>
                        </div>
                  
                </div>
            </div>
        </div>
    </div>
    <input id="pageindex" type="hidden" value="1" />

    <script type="text/javascript">
        $("#searchBtn").click(function() {
            $("#form2").submit();
        })

        $(".nav_ico").click(function() {
            window.location = "/Mall/MallType.aspx";
        })
    </script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
        var wx_jsapi_config = <%=weixin_jsapi_config %>;
        wx.config(wx_jsapi_config); </script>

    <script type="text/javascript">        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu    %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu    %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            }); //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        }); 
    </script>

    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;

        function pullDownAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                for (i = 0; i < 12; i++) {
                    $(el).append("<li>Generated row " + (++generatedCount) + "</li>")
                }

                myScroll.refresh();
            }, 1000);
        }

        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);

                var para = { pageindex: index, cName: $("input[name=cName]").val(),gid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("gid") %>', lid: $("#lid").val(), t: '<%= EyouSoft.Common.Utils.GetQueryStringValue("t") %>' };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxShangChengList.aspx?isGet=1&" + $.param(para),
                    cache: false,
                    success: function(result) {
                        if (result != "" && result.length > 2) {
                            $(el).append(result);
                        }
                        else {
                            pullUpEl.querySelector('.pullUpLabel').innerHTML = '已加载至最后';
                        }
                    }
                });
                myScroll.refresh();
            }, 1000);
        }

        function loaded() {

            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight

            myScroll = new iScroll('wrapper', {
                mouseWheel: true,
                click: true,
                checkDOMChanges: true,
                onRefresh: function() {
                    if (pullUpEl.className.match('loading')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                    }
                },
                onScrollMove: function() {
                    if (this.y < (this.maxScrollY - 5) && !pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'flip';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '放开刷新..';
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.className.match('flip')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                        this.maxScrollY = pullUpOffset;
                    }
                },
                onScrollEnd: function() {
                    if (pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'loading';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '正在加载...';
                        pullUpAction();
                    }
                }
            });
        }

        document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
        document.addEventListener('DOMContentLoaded', loaded, false);

  


    </script>

</body>
</html>
