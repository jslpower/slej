<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenSiJiaoYi.aspx.cs" Inherits="EyouSoft.WAP.Member.FenSiJiaoYi" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>粉丝交易</title>
    <link rel="stylesheet" href="/css/e.css" type="text/css" media="screen">
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

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
                var para = { fensiid:"<%= fensiid%>", pageindex: $("#pageindex").val() };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxFenSiJiaoYi.aspx?" + $.param(para),
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

        function change(i) {
            if (i == 1) {
                $("#a1").show();
                $("#a2").hide();

            }
            else {
                $("#a2").show();
                $("#a1").hide();
            }

            myScroll.scrollToPage(0, 0, 100);


        }


    </script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div id="wrapper">
            <div id="scroller">
                <div id="a1">
                    <div class="e_fenxiao" id="linelist">
                        <asp:Repeater runat="server" ID="rpt">
                            <ItemTemplate>
                                <ul class="clearfix">
                                    <li class="wid">
                                        <label>
                                            产品名称：</label><%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()), 30, true)%></li>
                                    <li>
                                        <label>
                                            订单类型：</label><%#Eval("DingDanLeiXing") %></li>
                                    <li>
                                        <label>
                                            交易时间：</label><%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %></li>
                                    <li>
                                        <label>
                                            交易金额：</label><span class="font_red"><%#Eval("DingDanJinE","{0:F2}") %></span></li>
                                    <li>
                                        <label>
                                            佣 金：</label><span class="font_green"><%#Eval("YongJinJinE", "{0:F2}")%></font></span></li>
                                    <li>
                                        <label>
                                            操作人：</label><%#Eval("XiaDanRenName") %></li>
                                    <li>
                                        <label>
                                            客户信息：</label><%#Eval("KeRenName") %></li>
                                    <li class="wid">
                                        <label>
                                            订单状态：</label><%#Eval("DingDanStatus")%></li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <div id="pullUp" style="text-align: center">
                        <span class="pullUpIcon"></span><span class="pullUpLabel">
                            <asp:Literal ID="XianShi" runat="server"></asp:Literal></span>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
        <input id="pageindex" type="hidden" value="1" />
    </div>
</body>

<script type="text/javascript">
    $(function() {
        $("#wrapper").css("top", "40px");
    });
</script>

</html>
