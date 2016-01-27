<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaJiFenXiao.aspx.cs" Inherits="EyouSoft.WAP.Member.XiaJiFenXiao" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>下级分销奖励</title>
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
                var para = { pageindex: $("#pageindex").val() };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxFenXiao.aspx?" + $.param(para),
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
                    
                        <div class="car_banner">
                            <img src="/images/e-fx.jpg">
                        </div>
                        <div class="e_fenxiao">
                        <em id="linelist">
                            <asp:Repeater runat="server" ID="rpt">
                                <ItemTemplate>
                                    <ul class="clearfix">
                                        <li>
                                            <label>
                                                下级网站：</label>
                                            <%# GetWebSite(Eval("DaiLiShangId"))%></li>
                                        <li>
                                            <label>
                                                奖励比例：</label><%# Convert.ToDecimal(Convert.ToDecimal(Eval("JiangLiBi"))*100).ToString("f2")%>%</li>
                                        <li>
                                            <label>
                                                下级名称：</label><a href="FenSi.aspx?fensiid= <%#Eval("DaiLiShangHuiYuanId") %>"><%# GetMember(Eval("DaiLiShangHuiYuanId"))%></a></li>
                                        <li>
                                            <label>
                                                下级佣金：</label><span class="font_z"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Eval("YongJinJinE", "{0:F2}")%></span></li>
                                        <li>
                                            <label>
                                                交易时间：</label><%#Eval("XiaDanShiJian", "{0:yyyy-MM-dd}")%></li>
                                        <li>
                                            <label>
                                                奖金额度：</label><span class="font_yellow"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Convert.ToDecimal(Convert.ToDecimal(Eval("YongJinJinE")) * Convert.ToDecimal(Eval("JiangLiBi"))).ToString("f2")%></span></li>
                                        <li>
                                            <label>
                                                消费状态：</label><span class="font_red"><%#GetDingDanStatus(Eval("DingDanStatus"))%></span></li>
                                        <li>
                                            <label>
                                                可结算额：</label><span class="font_green"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : (GetIsXiaoFei(Eval("DingDanStatus")) == "0" ? "0.00" : Convert.ToDecimal(Convert.ToDecimal(Eval("YongJinJinE")) * Convert.ToDecimal(Eval("JiangLiBi"))).ToString("f2"))%></span></li>
                                        <li>
                                            <label>
                                                操 作：</label><a class="e_ck radius4" href="/Member/DingDanMingXi.aspx?dingdanid=<%# Eval("DingDanId")%>">查看明细</a></li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                            </em>
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
    <div class="e_bot" style="height: 90px;">
        <div class="e_bot_box" style="height: 90px;">
            <div class="side_fx">
                已结算额：<asp:Literal ID="YiJieSuan" runat="server"></asp:Literal>
                未结算额：<asp:Literal ID="WeiJieSuan" runat="server"></asp:Literal>
                <span class="font_yellow">总计：<asp:Literal ID="ZongJInE" runat="server"></asp:Literal></span>
                <span class="up_jiantou">注释</span>
            </div>
            <div class="side03">
                <div class="txt">
                    可申请结算额：<em><asp:Literal ID="KeShenQing" runat="server"></asp:Literal></em></div>
                <div class="btn">
                    <a href="/Member/JieSuanShenQing.aspx" class="step_btn">申请结算</a></div>
            </div>
        </div>
    </div>
    <!---注释--->
    <div class="e-mask" style="display: none;">
        <div class="e-mask-cnt box">
            <h3 class="paddB">
                下级分销奖励制度</h3>
            <p class="font_gray indent">
                <span class="font_hei">(1) 什么是下级分销</span>——您的用户如果在您的网站上也购买了一个代理帐号（这个功能您可以屏蔽），他也成为跟您一样的代理商，这个代理商就永远都是您的下级代理，他也可以跟您一样销售系统中所有产品并且获取销售佣金。</p>
            <p class="font_gray indent">
                <span class="font_hei">(2) 什么是下级分销奖</span>——商旅E家公司会按您的粉丝代理的佣金的一定比例，从公司额外给您进行奖励，该奖励不是从粉丝代理佣金中扣除，而是公司给您额外奖励给您的。试想一下，如果您有100个粉丝代理，他们每人每月产生10000元代理佣金，100个人就是100万，您的下级分销奖就是100万*（奖励率比如为10%）
                = 10万元。</p>
            <p class="font_gray indent">
                <span class="font_hei">(3) 了解粉丝经营情况</span>——您可以通过后台查看您的粉丝销售和佣金明细，并计算出您的粉丝分销奖金！您可以帮助您的粉丝提升销售业绩，您的奖励就增加。</p>
            <p class="font_gray indent">
                <span class="font_hei">(4) 奖金结算</span>——您可以直接提交粉丝分销奖的结算申请，系统收到申请后会及时将奖金划入您的E额宝帐户。</p>
            <p class="font_gray indent">
                <span class="font_hei">(5) 特别说明</span>——您的下级的下级就不是您自己的下级了，否则就变传销了！同样，如果您自己也是从别的网站上购买的代理帐号，那么您也是那家网站的下级，他们也会帮助你提升销售以获取奖金！
                （注：只推广一级，奖金是从总部获得，网站有丰富的产品，不属于传销！）</p>
        </div>
    </div>

    <script type="text/javascript">
        $(".up_jiantou").click(function() {
            $(".e-mask").toggle();
        });
        $(".e-mask").click(function() {
            $(".e-mask").hide();
        });
        $(function() {
        $("#wrapper").css("top", "40px");
        $("#wrapper").css("bottom", "100px");
        });
    </script>

</body>
</html>
