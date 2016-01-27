<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line_Tours.aspx.cs" Inherits="EyouSoft.WAP.Line_Tours" %>

<%@ Register Src="/userControl/PriceInfo.ascx" TagName="PriceInfo" TagPrefix="uc2" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <link href="/css/zt.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

    <script src="/js/xianlu_rili.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="选择日期和人数" />
    <div class="warp">
        <div class="date_type">
            <ul>
                <li id="prev_li" class="prev"></li>
                <li id="month" class="font16"></li>
                <li id="next_li" class="next"></li>
            </ul>
        </div>
        <div class="date_week">
            <ul>
                <li>日</li>
                <li>一</li>
                <li>二</li>
                <li>三</li>
                <li>四</li>
                <li>五</li>
                <li>六</li>
            </ul>
        </div>
        <section id="rili" class="tuanqi">
        
     </section>
        <div class="car_tab  mt10" style="background: #fff;">
            <h2>
                选择出行人数</h2>
            <div class="user_form gray_lineB">
                <ul>
                    <li class="wid"><span class="label_name">成人</span> <span class="number"><i class="num-minus">
                    </i>
                        <input type="tel" value="1" class="inputrs" name="crs" id="crs" /><i class="num-add"></i></span>
                    </li>
                    <li class="wid"><span class="label_name">儿童</span> <span class="number"><i class="num-minus">
                    </i>
                        <input type="tel" value="0" class="inputrs" name="ets" id="ets" /><i class="num-add"></i></span>
                    </li>
                </ul>
            </div>
            <div class="paddL mt10">
                至少1人起订</div>
            <div class="paddL paddB">
                不含床、不含早餐。</div>
        </div>
        <div id="divyouhui" class="youhui_box" runat="server">
            <ul id="youhui">
                <asp:Literal ID="litHtml" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
    <div class="line_pay">
        <div class="line_pay_box">
            <div class="pay_total">
                订单总额：<span><em id="span_price"> 0</em> 元</span> </span></div>
            <div class="pay_btn">
                <a href="javascript:;" class="step_btn">下一步</a></div>
        </div>
    </div>
    <!---订单总额点击显示层--->
    <div id="price_Box" class="line-mask" style="display: none;">
        <div class="line-mask-cnt">
            <h3>
                价格详情</h3>
            <ul id="price_ul">
                <li>成人：<span class="floatR">¥2690x1人</span></li>
                <li>儿童：<span class="floatR">¥1840x0人</span></li>
            </ul>
        </div>
    </div>
    <input id="hid_tour" value="0" name="hid_tour" type="hidden" />
    <input id="hidDate" value="<%=   DateTime.Now.ToString("yyyy-MM-dd") %>" type="hidden" />
    </form>

    <script type="text/javascript">
        var pageOpt = {
            parmData: {},
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
                    pageOpt.setOrderSum($("#hid_tour").val(), $("#crs").val(), $("#ets").val(), '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>');
                })
                $(".num-add").click(function() {
                    $(this).parent().find(".inputrs").val(parseInt($(this).parent().find(".inputrs").val()) + 1)
                    pageOpt.setOrderSum($("#hid_tour").val(), $("#crs").val(), $("#ets").val(), '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>');
                })

                //pageOpt.setOrderSum(crj, crs, etj, ets)
            },
            initRiLiUl: function() {
                for (var i = 0; i < dataBox.length; i++) {
                    $("#" + dataBox[i].ldate).addClass("bg_white").attr("data-tour", dataBox[i].tid).append(" <p class='font_blue'>¥<span class=\"dj\">" + dataBox[i].msj + "</span></p><p class=\"font_green\">余：" + dataBox[i].yw + "</p>");
                    $("#" + dataBox[i].ldate).bind("click", function() {
                        $(".bg_white").removeClass("bg_select"); $(this).addClass("bg_select"); $("#hid_tour").val($(this).attr("data-tour"));

                        pageOpt.setOrderSum($("#hid_tour").val(), $("#crs").val(), $("#ets").val(), '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>');

                    });

                }
            }, //end,
            setOrderInfo: function() {
                if ($("#hid_tour").val() == "0" || $("#hid_tour").val() == "undefined") {
                    alert("请选择出行日期");
                    return false;
                }
                var url = "/Line_LXRXX.aspx?" + $.param({
                    xianluid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("xianluid")%>',
                    hasFlightNO: '<%= EyouSoft.Common.Utils.GetQueryStringValue("hasFlightNO")%>',
                    tourid: $("#hid_tour").val(),
                    crs: $("#crs").val(),
                    ets: $("#ets").val(),
                    type: '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>'
                });
                if (iLogin.getM().isLogin) {
                    window.location.href = url;
                }
                else {
                    window.location.href = "/Login.aspx?rurl=" + encodeURIComponent(url);
                }
            },
            setOrderSum: function(id, crs, ets, type) {
                if (id == "" || id.length == "undefined" || id == "0") {
                    alert("请选择出发日期");
                    return false;
                }
                $.ajax({
                    url: "/Line_Tours.aspx?getSum=1&" + $.param({ id: id, crs: crs, ets: ets, type: type }),
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            $("#price_ul").html(ret.obj.YH);
                            $("#span_price").html(parseFloat(ret.msg));
                        }
                    }
                });


            }
        }
        $(function() {
            tourdate.init();
            pageOpt.initRiLiUl();
            pageOpt.initClick();
            //$(".bg_white").click(function() { pageOpt.setCss(this) })//选择团期
            $(".step_btn").click(function() { pageOpt.setOrderInfo() })

            $(".inputrs").change(function() {
                if ($(this).attr("name") == "crs") {
                    if (parseInt($(this).val()) <= 0) {
                        $(this).val("1")
                    }
                } else {
                    if (parseInt($(this).val()) <= 0) {
                        $(this).val("0")
                    }
                }
            }); //
            $("#span_price").click(function() {
                var display = $("#price_Box").css("display");
                if (display == "none") {
                    $("#price_Box").show();
                } else {
                    $("#price_Box").hide();
                }
            })


        })
    </script>

</body>
</html>
