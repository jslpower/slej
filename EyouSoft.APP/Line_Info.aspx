<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line_Info.aspx.cs" Inherits="EyouSoft.WAP.Line_Info" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<%@ Register Src="userControl/PriceInfo.ascx" TagName="PriceInfo" TagPrefix="uc2" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>
        <%=FenXiangBiaoTi %></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="format-detection" content="telephone=no" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

    <script src="/js/xianlu_rili.js" type="text/javascript"></script>
<script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
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
    <form id="form1" runat="server">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="产品详情" />
    <link href="/css/zt.css" rel="stylesheet" type="text/css" />
    <div class="warp">
        <div class="car_banner">
            <asp:Label ID="lblImg" runat="server" Text=""></asp:Label>
        </div>
        <div class="jq_cont gray_lineB">
            <h2>
                <asp:Label ID="lbl_routeName" runat="server" Text=""></asp:Label>
            </h2>
            <p class="paddT font12">
                出发地：<asp:Label ID="cfd" runat="server" Text=""></asp:Label></p>
            <p class="font12">
                送团人：<asp:Label ID="lblSongTuanRen" runat="server" Text="Label"></asp:Label></p>
            <p class="font12">
                集合地：<asp:Label ID="lblJiHeDi" runat="server" Text="Label"></asp:Label></p>
        </div>
        <div class="jiage_side gray_lineB">
            <ul class="clearfix">
                <li><span class="radius4">参团价格</span></li>
                <li><a href="ZiZuTuan.aspx?id=<%= EyouSoft.Common. Utils.GetQueryStringValue("id") %>&type=<%= EyouSoft.Common. Utils.GetQueryStringValue("type") %>">
                    <span class="radius4">独立组团价格</span></a></li>
            </ul>
        </div>
        <uc2:PriceInfo ID="PriceInfo1" runat="server" />
        <div class="paddL paddT paddB gray_lineB" style="background: #fff;">
            <p>
                人数：</p>
            <p class="paddT">
                成人 <span class="number"><i class="num-minus"></i>
                    <input type="tel" value="1" name="crs" id="crs" class="inputrs" /><i class="num-add"></i></span>儿童
                <span class="number"><i class="num-minus"></i>
                    <input type="tel" value="0" name="ets" id="ets" class="inputrs" /><i class="num-add"></i></span></p>
        </div>
        <asp:PlaceHolder ID="isNoFlight" runat="server" Visible="false">
            <div class="xx_hangban mt10">
                <h3 id="moreHB" style="position: relative;" class="paddL R_jiantou">
                    航班/舱位
                </h3>
                <ul>
                    <asp:Literal ID="ltrFlight" runat="server"></asp:Literal>
                </ul>
            </div>
        </asp:PlaceHolder>
        <div id="moreRQ" class=" xx_riqi mt10 R_jiantou">
            <h3>
                出发日期</h3>
            <ul>
                <asp:Repeater ID="rptTours" runat="server">
                    <ItemTemplate>
                        <li>
                            <%# Eval("LDate","{0:MM/dd}").ToString()%></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="car_tab mt10" id="n4Tab">
            <div class="jq_TabTitle">
                <ul class="clearfix">
                    <li id="n4Tab_Title0" onclick="nTabs('n4Tab',this);" class="active"><a href="javascript:void(0);">
                        详细行程</a></li>
                    <li id="n4Tab_Title1" onclick="nTabs('n4Tab',this);"><a href="javascript:void(0);">服务说明</a></li>
                </ul>
            </div>
            <div class="jq_TabContent">
                <div id="n4Tab_Content1" class="none">
                    <div class="line_cont">
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_shuoming">
                            <h3>
                                产品说明</h3>
                            <p>
                                <asp:Literal ID="litMiaoShu" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_baoming">
                            <h3>
                                报名须知</h3>
                            <p>
                                <asp:Literal ID="litBaoMing" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_zifei">
                            <h3>
                                自费项目</h3>
                            <p>
                                <asp:Literal ID="litZiFei" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_baohan">
                            <h3>
                                费用包含</h3>
                            <p>
                                <asp:Literal ID="litBaoHan" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_buhan">
                            <h3>
                                费用不含</h3>
                            <p>
                                <asp:Literal ID="litBuHan" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_ertong">
                            <h3>
                                儿童安排</h3>
                            <p>
                                <asp:Literal ID="litErTong" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_gouwu">
                            <h3>
                                购物站信息</h3>
                            <p>
                                <asp:Literal ID="litGouWu" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_tishi">
                            <h3>
                                温馨提示</h3>
                            <p>
                                <asp:Literal ID="litTiShi" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_zhuyi">
                            <h3>
                                注意事项</h3>
                            <p>
                                <asp:Literal ID="litZhuYi" runat="server"></asp:Literal></p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_zengsong">
                            <h3>
                                赠送项目</h3>
                            <p>
                                <asp:Literal ID="litZengSong" runat="server"></asp:Literal></p>
                        </div>
                        <div class="line_xx_cont gray_lineB" runat="server" id="div_qita">
                            <h3>
                                其他事项</h3>
                            <p>
                                <asp:Literal ID="litQiTa" runat="server"></asp:Literal></p>
                        </div>
                    </div>
                </div>
                <div id="n4Tab_Content0">
                    <div class="line_cont">
                        <asp:Repeater ID="rptJourneies" runat="server">
                            <ItemTemplate>
                                <div class="line_xx_cont gray_lineB">
                                    <h3>
                                        第<%# Container.ItemIndex+1 %>天 |
                                        <%# Eval("QuJian")%></h3>
                                    <p>
                                        <em class="font_yellow">交通：</em>
                                        <%# Eval("JiaoTong") %></p>
                                    <p>
                                        <em class="font_yellow">用餐：</em>
                                        <%# Eval("YongCan") %></p>
                                    <p>
                                        <em class="font_yellow">住宿：</em>
                                        <%# Eval("ZhuSu")%></p>
                                    <p>
                                        <%# EyouSoft.Common.Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(Eval("XingCheng").ToString()))%></p>
                                    <p class="cent">
                                        <img src='<%# Eval("FilePath")==""?"images/line_xx02.jpg":Eval("FilePath") %>' class="line_xx_img" /></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="line_pay">
        <div class="line_pay_box">
            <div id="pay_total" class="pay_total">
                订单总额：<span><em id="span_price" runat="server">0</em> 元</span> </span></div>
            <div class="pay_btn">
                <a id="yuding" href="javascript:;" class="step_btn y_btn">我要预定</a></div>
        </div>
    </div>
    <!---订单总额点击显示层--->
    <div id="price_Box" class="line-mask" style="display: none;">
        <div class="line-mask-cnt">
            <h3>
                价格详情</h3>
            <ul id="price_ul" runat="server">
                <li>成人：<span class="floatR">¥2690x1人</span></li>
                <li>儿童：<span class="floatR">¥1840x0人</span></li>
            </ul>
        </div>
    </div>
    <!---日期--->
    <div id="RQbox" class="user-mask" style="display: none;">
        <div id="rili" class="line-mask-cnt2" style="height: 3500px">
            <div class="pay mt10">
                <div class="pay_box">
                    <a id="a_selectRQ" href="javascript:;" class="y_btn">确定</a></div>
            </div>
        </div>
    </div>
    <!---航班--->
    <asp:PlaceHolder ID="plaFlight" runat="server">
        <div id="HBbox" class="user-mask" style="display: none; background: #E4E4E4;">
            <div class="line-mask-cnt2" style="background: #E4E4E4;">
                <div class="hangban_box">
                    <h3>
                        当前选择</h3>
                    <ul>
                        <asp:Repeater ID="rptHangBanList" runat="server">
                            <ItemTemplate>
                                <li class="f_li" data-no="<%# Eval("TrafficId") %>">
                                    <p>
                                        <i class="font_yellow">往：</i><%# Eval("Traffic_01")%></p>
                                    <p>
                                        <i class="fan">返：</i><%# Eval("Traffic_02")%></p>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="pay">
                    <div class="pay_box">
                        <a id="a_selectHB" href="javascript:;" class="y_btn">确定</a></div>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
    <input id="hid_tour" value="<%=tid %>" name="hid_tour" type="hidden" />
    <input id="hid_flight" value="<%=  defaultHBID %>" name="hid_flight" type="hidden" />
    <input id="hidDate" value="<%=   DateTime.Now.ToString("yyyy-MM-dd") %>" type="hidden" />
    </form>

    <script type="text/javascript">
        var pageOptData = {
            parm: { xianluid: '<%= EyouSoft.Common. Utils.GetQueryStringValue("id") %>', type: '<%= EyouSoft.Common. Utils.GetQueryStringValue("type") %>', tid: '<%=tid %>', hangban: '<%=  defaultHBID %>', crs: "", ets: "" },
            setURL: function() {
                pageOptData.parm.crs = $("#crs").val()
                pageOptData.parm.ets = $("#ets").val()
                var url = "/Line_LXRXX.aspx?" + $.param(pageOptData.parm);
                return url;

            },
            initClick: function() {
                $(".num-minus").click(function() {
                    if (parseInt($(this).parent().find(".inputrs").val()) > 0) {
                        if ($(this).parent().find(".inputrs").attr("name") != "crs") {
                            $(this).parent().find(".inputrs").val(parseInt($(this).parent().find(".inputrs").val()) - 1)
                        } else {
                            if (parseInt($(this).parent().find(".inputrs").val()) > 1) {
                                $(this).parent().find(".inputrs").val(parseInt($(this).parent().find(".inputrs").val()) - 1)
                            }
                        }
                    }
                    else {
                        $(this).closest(".inputrs").val(0);
                    }
                    pageOptData.setOrderSum(pageOptData.parm.xianluid, $("#crs").val(), $("#ets").val(), '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>', $("#hid_tour").val(), $("#hid_flight").val());
                })
                $(".num-add").click(function() {
                    $(this).parent().find(".inputrs").val(parseInt($(this).parent().find(".inputrs").val()) + 1)
                    pageOptData.setOrderSum(pageOptData.parm.xianluid, $("#crs").val(), $("#ets").val(), '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>', $("#hid_tour").val(), $("#hid_flight").val());
                })

            },
            setOrderSum: function(id, crs, ets, type, tid, hangban) {
                $.ajax({
                    url: "/Line_Info.aspx?getSum=1&" + $.param({ id: id, crs: crs, ets: ets, type: type, tid: tid, hangban: hangban }),
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            $("#price_ul").html(ret.obj.PRICE)
                            $("#span_price").html(parseFloat(ret.msg));
                        }
                    }
                });


            }, //
            initShowBox: function() {
                $("#moreRQ").click(function() {
                    var rqBox = $("#RQbox");
                    var $isShow = rqBox.is("show");
                    if ($isShow) {
                        rqBox.hide()
                    }
                    else {
                        rqBox.show()
                    }

                })//
                $("#moreHB").click(function() {
                    var hbBox = $("#HBbox");
                    var $isShow = hbBox.is("show");
                    if ($isShow) {
                        hbBox.hide()
                    }
                    else {
                        hbBox.show()
                    }
                })//
            }, //
            initSelect: function() {
                $("#a_selectRQ").click(function() {
                    var rqBox = $("#RQbox");
                    var tourid = rqBox.find(".bg_select").eq(0).attr("data-tour");
                    $("#hid_tour").val(tourid);
                    rqBox.hide()
                    var url = window.location.pathname;
                    var urlParms = pageOptData.getUrlParms(["tid"]);
                    urlParms["tid"] = tourid;
                    if (tourid == undefined)
                    { return false; }
                    window.location.href = pageOptData.createUrl(url, urlParms);
                })//
                $("#a_selectHB").click(function() {
                    var hbBox = $("#HBbox");
                    var hangban = hbBox.find(".xze").eq(0).attr("data-no");
                    $("#hid_flight").val(hangban);
                    hbBox.hide()
                    var url = window.location.pathname;
                    var urlParms = pageOptData.getUrlParms(["hangban"]);
                    urlParms["hangban"] = hangban;
                    urlParms["tid"] = "";
                    if (hangban == undefined)
                    { return false; }
                    window.location.href = pageOptData.createUrl(url, urlParms);

                })//
            }, //
            initRiLiUl: function() {
                for (var i = 0; i < dataBox.length; i++) {
                    $("#" + dataBox[i].ldate).addClass("bg_white").attr("data-tour", dataBox[i].tid).append(" <p class='font_blue'>¥<span class=\"dj\">" + dataBox[i].msj + "</span></p><p class=\"font_green\">余：" + dataBox[i].yw + "</p>");
                    $("#" + dataBox[i].ldate).bind("click", function() {
                        $(".bg_white").removeClass("bg_select"); $(this).addClass("bg_select"); $("#hid_tour").val($(this).attr("data-tour"));

                        pageOptData.setOrderSum($("#hid_tour").val(), $("#crs").val(), $("#ets").val(), '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>', $("#hid_tour").val(), $("#hid_flight").val());

                    });

                }
            },
            initSelectHangBan: function() {
                $(".f_li").removeClass("xze");
                $(".f_li").each(function() {
                    if ($(this).attr("data-no") == pageOptData.parm.hangban) {
                        $(this).addClass("xze");
                    }
                })
                $(".f_li").click(function() {
                    $(".f_li").removeClass("xze");
                    $(this).addClass("xze");
                    $()
                })
            },
            createUrl: function(url, params) {
                var isHaveParam = false;
                var isHaveQuestionMark = false;
                var questionMark = "?";
                var questionMarkIndex = url.indexOf(questionMark);
                var urlLength = url.length;

                if (questionMarkIndex == urlLength - 1) {
                    isHaveQuestionMark = true;
                } else if (questionMarkIndex != -1) {
                    isHaveParam = true;
                }

                if (isHaveParam == true) {
                    for (var key in params) {
                        url = url + "&" + key + "=" + params[key];
                    }
                } else {
                    if (isHaveQuestionMark == false) {
                        url += questionMark;
                    }
                    for (var key in params) {
                        url = url + key + "=" + params[key] + "&";
                    }
                    url = url.substr(0, url.length - 1);
                }

                return url;
            },
            getUrlParms: function(removeParms) {
                var argsArr = new Object();
                var query = window.location.search;
                query = query.substring(1);
                var pairs = query.split("&");

                for (var i = 0; i < pairs.length; i++) {
                    var sign = pairs[i].indexOf("=");
                    if (sign == -1) {
                        continue;
                    }

                    var aKey = pairs[i].substring(0, sign);
                    var aValue = pairs[i].substring(sign + 1);

                    //移除不需要要的键
                    var isRemove = false
                    for (var j = 0; j < removeParms.length; j++) {
                        if (aKey.toLowerCase() == removeParms[j].toLowerCase()) {
                            isRemove = true;
                            break;
                        }
                    }

                    if (isRemove) {
                        continue;
                    }

                    argsArr[aKey] = aValue;
                }

                return argsArr;
            }
        };
        $(function() {
            $("#yuding").click(function() {
                window.location.href = pageOptData.setURL();
            })//
            $("#pay_total").click(function() {
                var display = $("#price_Box").css("display");
                if (display == "none") {
                    $("#price_Box").show();
                } else {
                    $("#price_Box").hide();
                }
            })//
            pageOptData.initClick();
            pageOptData.initShowBox();
            pageOptData.initSelect();
            tourdate.init();
            pageOptData.initRiLiUl();
            pageOptData.initSelectHangBan();
        })
    </script>

   

</body>
</html>
