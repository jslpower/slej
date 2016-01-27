<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EJiaFenXiang.aspx.cs" Inherits="EyouSoft.WAP.Member.EJiaFenXiang" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html >
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link href="/css/fenxiang.css" rel="stylesheet" type="text/css" />
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>
 <script type="text/javascript" src="../cordova.js"></script>
    <script type="text/javascript" src="../js/enow.core.js"></script>
    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;



        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);

                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxFenXiang.aspx?isGet=1&page=" + index,
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

</head>
<body>
    <form id="form1">
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="e家分享" />
    <div class="warp">
        <div id="wrapper" style="top: 44px; background: #fff;">
            <div id="scroller">
               <div class="cent"><img src="/images/2.jpg"  style="width:100%; vertical-align:top;"></div>
       <div class="fenxiang_title"><img src="/images/fx_t.gif"></div>
                <div class="fenxiang_news">
                    <ul id="linelist">
                        <asp:Repeater ID="rptlist" runat="server">
                            <ItemTemplate>
                                <li><a href="EJiaFenXiangInfo.aspx?id=<%#Eval("YouJiid") %>">
                                    <%# EyouSoft.Common.Utils.GetText(Eval("YouJiTitle").ToString(), 15, true)%></a><span
                                        class="date"><%#Eval("issuetime","{0:yyyy-MM-dd}") %></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="ltrNoMsg" runat="server" Visible="false"><li style="text-align:center">暂无数据</li></asp:Literal>
                    </ul>
                </div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <div id="pullUp" style="text-align: center">
                        <span class="pullUpIcon"></span><span class="pullUpLabel">
                            <asp:Literal ID="XianShi" runat="server"></asp:Literal></span>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
    <input type="hidden" id="pageindex" value="1" />

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: 'E家分享',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: 'E家分享',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: 'E家分享',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>

    </form>
</body>
</html>
