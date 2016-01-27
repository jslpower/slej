<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoDetail.aspx.cs" Inherits="EyouSoft.WAP.Mall.MoDetail" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title><%=FenXiangBiaoTi %></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="/css/zt.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="产品详情" />
    <form id="form1" runat="server">
    <div id="wrapper1" class="warp">
        <!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
        <div class="jq_cont gray_lineB">
            <h2>
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label></h2>
        </div>
        <div class="jq_cont gray_lineB">
            <ul class="mall_price">
                <li class="L line_x">门市：¥<asp:Label ID="lblMarketPrice" runat="server" Text="0"></asp:Label></li>
                <li><em>
                    <asp:Label ID="lblMemberType" runat="server" Text="Label"></asp:Label></em><span
                        class="font_yellow">¥<i class="font18"><asp:Label ID="lblMemberPrice" runat="server"
                            Text="0"></asp:Label></i></span></li>
                <li>供应商：<a href="/Mall/ModList.aspx?gid=<%=gysid %>"><asp:Label ID="lblSupplier"
                    runat="server" Text=""></asp:Label></a></li>
                <li class="L">姓名：<asp:Literal ID="MemberName" runat="server"></asp:Literal></li>
                <li>联系电话：<asp:Literal ID="MemberMoblie" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="user_form mall_form">
            <ul>
                <%if (ysisbool == true)
                  { %>
                <li class="color_box"><span class="label_name">颜色</span>
                    <div class="color_list">
                        <asp:Label ID="lblColors" runat="server" Text=""></asp:Label>
                        <input type="hidden" value="" id="color_a" />
                    </div>
                </li>
                <%} %>
                <%if (xhisbool == true)
                  { %>
                <li class="color_box"><span class="label_name">型号</span>
                    <div class="color_list">
                        <asp:Label ID="lblTypes" runat="server" Text=""></asp:Label>
                        <input type="hidden" value="" id="type_a" />
                    </div>
                </li>
                <%} %>
                <%if (ksisbool == true)
                  { %>
                <li class="color_box"><span class="label_name">款式</span>
                    <div class="color_list">
                        <asp:Label ID="lblModel" runat="server" Text=""></asp:Label>
                        <input type="hidden" value="" id="model_a" />
                    </div>
                </li>
                <%} %>
                <li>
                    <%if (KuCunNum > 0)
                      { %>
                    <span class="label_name">数量</span> <span class="number"><i class="num-minus"></i>
                        <input name="num" id="num" type="tel" value="1"><i class="num-add"></i></span>
                    <%}
                      else
                      { %>暂时缺货<%} %>
                </li>
            </ul>
        </div>
        <div class="youhui_box mt10" style="background: #fff;">
            <ul id="ulyouhui">
                <asp:Literal ID="litYouHui" runat="server"></asp:Literal>
            </ul>
        </div>
        <div class="jq_tab mall_tab mt10" id="n4Tab">
            <div class="jq_TabTitle mall_TabTitle">
                <ul class="clearfix">
                    <li id="n4Tab_Title0" onclick="nTabs('n4Tab',this);" class="active"><a href="javascript:void(0);">
                        产品详情</a></li>
                    <li id="n4Tab_Title1" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                        注意事项</a></li>
                    <%if (kdisbool == true)
                      { %>
                    <li id="n4Tab_Title2" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                        快递方式</a></li>
                    <%} %>
                </ul>
            </div>
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                    <div class="jq_xx_cont">
                        <p>
                            <asp:Literal ID="litInfo" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
                <div id="n4Tab_Content1" class="none">
                    <div class="jq_xx_cont">
                        <p>
                            <asp:Literal ID="litNotice" runat="server"></asp:Literal></p>
                    </div>
                </div>
                <div id="n4Tab_Content2" class="none">
                    <div class="jq_xx_cont">
                        <p>
                            <asp:Literal ID="litMailWay" runat="server"></asp:Literal></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="line_pay">
        <div class="line_pay_box">
            <input id="PJiaGe" type="hidden" value="<%= pjiage%>" />
            <div class="pay_total">
                订单总额：<em id="PZongJia"><%= pjiage.ToString("f2")%></em> 元</div>
            <div class="pay_btn">
                <a href="javascript:;" class="step_btn">我要购买</a></div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pjiage = "<%= pjiage%>";
        var pageOpt = {
            id: '<%= EyouSoft.Common. Utils.GetQueryStringValue("id") %>',
            initClick: function() {
                $(".num-minus").click(function() {
                    if (parseInt($(this).parent().find("input").val()) > 0) {
                        if ($(this).parent().find("input").attr("name") != "num") {
                            $(this).parent().find("input").val(parseInt($(this).parent().find("input").val()) - 1)
                        } else {
                            if (parseInt($(this).parent().find("input").val()) > 1) {
                                $(this).parent().find("input").val(parseInt($(this).parent().find("input").val()) - 1)
                            }
                        }
                    }
                    else {
                        $(this).closest("input").val(0);
                    }
                    pageOpt.setOrderSum(pageOpt.id, $("#num").val());
                    var zongjia = parseFloat(parseInt($(this).parent().find("input").val()) * parseFloat(pjiage));
                    $("#PZongJia").html(parseFloat(zongjia).toFixed(2));
                })
                $(".num-add").click(function() {
                    var goumailiang = parseInt($(this).parent().find("input").val()) + 1;
                    var kucun = "<%= KuCunNum%>";
                    if (parseInt(goumailiang) > parseInt(kucun)) {
                        alert("已超出购买量，最多购买" + kucun + "件");
                    }
                    else {
                        $(this).parent().find("input").val(parseInt($(this).parent().find("input").val()) + 1);
                        pageOpt.setOrderSum(pageOpt.id, $("#num").val());
                    }
                    var zongjia = parseFloat(parseInt($(this).parent().find("input").val()) * parseFloat(pjiage));
                    $("#PZongJia").html(parseFloat(zongjia).toFixed(2));
                })
            },
            initClickClass: function() {
                $(".color_a").click(function() {
                    $(".color_a").removeClass("on");
                    $(this).addClass("on");
                    $(this).parent().next().val($(this).html());
                })
                $(".type_a").click(function() {
                    $(".type_a").removeClass("on");
                    $(this).addClass("on");
                    $(this).parent().next().val($(this).html());
                })
                $(".model_a").click(function() {
                    $(".model_a").removeClass("on");
                    $(this).addClass("on");
                    $(this).parent().next().val($(this).html());
                })


            },
            setOrderSum: function(id, sl) {
                if (id == "" || id.length == "undefined" || id == "0") {
                    alert("系统出错，请重试！");
                    return false;
                }
                $.ajax({
                    url: "/Mall/MoDetail.aspx?getSum=1&" + $.param({ id: id, sl: sl }),
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            $("#ulyouhui").html(ret.obj);
                            $("#span_price").html(parseFloat(ret.msg));
                        }
                    }
                });


            }
        };
        $(function() {
            pageOpt.initClick();
            pageOpt.initClickClass();
            $(".step_btn").click(function() {
                location.href = "/Mall/OrderPage.aspx?" + $.param({ id: pageOpt.id, color: encodeURIComponent($("#color_a").val()), model: encodeURIComponent($("#model_a").val()), type: encodeURIComponent($("#type_a").val()), num: $("#num").val() })
            })

        })
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

</body>
</html>
