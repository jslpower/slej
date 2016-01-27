<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flight_Buy.aspx.cs" Inherits="EyouSoft.WAP.Flight.Flight_Buy" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>订单填写</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="/css/flight.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="订单填写" />
    <form id="form1">
    <div class="warp">
        <div class="f_tip">
            航班信息</div>
        <div class="flight_binfo paddB">
            <ul>
                <li class="paddL f_from">
                    <p>
                        <asp:Literal ID="litChuFaRiQi" runat="server">09-10 周五</asp:Literal></p>
                    <p class="font18">
                        <strong>
                            <asp:Literal ID="litChuFaShiJian" runat="server">10:25</asp:Literal></strong></p>
                </li>
                <li class="fly_time"><span class="flight_fx"><i class="flight_fx_ico"></i>
                    <div class="font12 cent">
                        飞行时长：<asp:Literal ID="litShiChang" runat="server">2小时08分</asp:Literal></div>
                </span></li>
                <li class="paddR f_end right_txt">
                    <p>
                        <asp:Literal ID="litDaoDaRiQi" runat="server">09-10 周五</asp:Literal></p>
                    <p class="font18">
                        <strong>
                            <asp:Literal ID="litDaoDaShiJian" runat="server">10:33</asp:Literal></strong></p>
                </li>
            </ul>
                        <div class="paddL">经停：<asp:Literal ID="litJingTing" runat=server></asp:Literal></div>
            <div class="paddL">
                <asp:Literal ID="litHangban" runat="server">南方航空CZ6412</asp:Literal></div>
            <div class="paddL">
                <asp:Literal ID="litHangBanXX" runat="server"> 经济舱：<span class="font_red">¥2136</span> 机/油：<span class="font_red">¥170</span> 总计：<span
                    class="font_red">¥<i class="font18">827</i></span></asp:Literal>
            </div>
        </div>
        <div class="flight_sm">
            <h3>
                <span id="span_t" class="up_jiantou">退改签说明</span></h3>
            <!--down_jiantou---->
            <ul id="ul_t">
                <li>
                    <asp:Literal ID="ltrGaiQian" runat="server"></asp:Literal></li>
                <li>
                    <asp:Literal ID="ltrTui" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="car_tab" style="display: none">
            <div class="user_form gray_lineB">
                <ul>
                    <li class="wid"><span class="label_name">机票</span> <span class="number"><i class="num-minus">
                    </i>
                        <input readonly="readonly" id="JiPiaoNum" name="JiPiaoNum" type="text" value="1"><i
                            class="num-add"></i></span> </li>
                </ul>
            </div>
        </div>
        <div class="mt10 padd10" style="border-bottom: #E9E9E9 solid 1px; background: #fff;">
            <em class="font18" style="color: #999;">乘机人</em> <em class="font16" id="em_rs">1成人&nbsp;儿童0人</em></div>
        <div class="add_box temp">
            <span class="del_icon" style="display: block;"></span>
            <ul>
                <li><span class="label_name">游客类型</span>
                    <select name="u-Type">
                        <option value="0">成人</option>
                        <option value="1">儿童</option>
                    </select></li>
                <li><span class="label_name">姓名</span>
                    <input name="u-Name" type="text" class="u-input" value="" placeholder="证件人姓名" />
                </li>
                <li><span class="label_name">身份证</span>
                    <input name="u-CardNo" type="text" class="u-input" value="" placeholder="身份证号码/儿童出生日期(19900101)" />
                </li>
                <li><span class="label_name">手机号</span>
                    <input name="u-Mobile" type="text" class="u-input" value="" placeholder="用于接短信通知" />
                </li>
                <li>
            </ul>
        </div>
        <div id="box">
        </div>
        <div class="paddT paddL paddB gray_line" style="background: #fff;">
            <a href="javascript:;" class="f_add_btn">添加更多乘机人</a></div>
    </div>
    <div id="showinfo">
    </div>
    <div class="pay">
        <div class="pay_box">
            <div class="pay_total">
                订单总额：¥<i id="sumPri"><%=sumByOne %></i></div>
            <div class="pay_btn">
                <a href="javascript:;" class="step_btn">核对提交</a></div>
        </div>
    </div>
    <input id="i-Model" name="i-Model" type="hidden" value="" />
    <span style="display: none" id="m-Span">
        <%=modeJson %></span>
    <div id="TiJiaoMask" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在提交订单，请等待。。。
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            CheckForm: function() {


            },
            BaoCun: function() {
                $(".step_btn").click(function() {
                    var msg = '';
                    var count = 1;
                    $(".temp").each(function() {
                        var isName = /^[\u4e00-\u9fa5]{2,4}$/;
                        var isIdCard = /(^\d{15}$)|(^\d{17}[0-9Xx]$)/;
                        var isDate = /^\d{4}\d{1,2}\d{1,2}$/;
                        var $NameVal = $(this).find("input[name=u-Name]").val();
                        var $CardVal = $(this).find("input[name=u-CardNo]").val();
                        if ($NameVal == "" || $NameVal == "undefined") {
                            msg += "第" + count + "位游客姓名不可为空 \n";
                        }
                        else {
                            if (!isName.test($NameVal)) {
                                msg += "第" + count + "个游客请填写中文姓名 \n";
                            }
                        }
                        if ($CardVal == "" || $CardVal == "undefined") {
                            msg += "第" + count + "证件号码或出生日期不可为空 \n";
                        } else {

                            if (!isIdCard.test($CardVal) && !isDate.test($CardVal)) {
                                msg += "第" + count + "证件号码或出生日期格式错误 \n";
                            }
                        }
                        count++
                    })
                    if (msg != '') { alert(msg); return false; }
                    var $that = this;
                    $(this).unbind("click");
                    $("#i-Model").val($("#m-Span").html());
                    if (window.confirm("请确认提交")) {
                        $("#TiJiaoMask").toggle();
                        $.ajax({
                            type: "post",
                            url: "Flight_Buy.aspx?dotype=save",
                            dataType: "json",
                            data: $("#form1").serialize(),
                            success: function(ret) {
                                $("#TiJiaoMask").toggle();
                                $($that).bind("click", function() { pageOpt.BaoCun(); })
                                if (ret.result == "1") {
                                    alert(ret.msg);
                                    window.location.href = "/Member/JpOrderList.aspx";
                                }
                                else {

                                    alert(ret.msg);
                                }
                            },
                            error: function() {
                                $("#TiJiaoMask").toggle();
                                $($that).bind("click", function() { pageOpt.BaoCun(); })
                                alert(ret.msg);
                            }
                        });
                    }
                })
            },
            sumPrice: function() {
                var $del_icon = $(".del_icon");
                var $count = $del_icon.length;
                var $sPrice = tableToolbar.getFloat($("#i_dr").html());
                $("#sumPri").html($sPrice * $count);
            },
            removeLinkMan: function() {
                $(".del_icon").click(function() {
                    if ($(".temp").length > 1) {
                        $(this).closest(".temp").remove();
                    }
                    else {
                        alert("最少保留一位乘客信息");
                    }
                    pageOpt.sumPrice();
                    pageOpt.chageCK();

                })

            },
            chageCK: function() {

                var $crs = 0, $ets = 0;
                $("[name=u-Type]").each(function() {
                    if ($(this).val() == "1") { $ets++; }
                    else { $crs++; }
                })
                $("#em_rs").html("" + $crs + "成人&nbsp;儿童" + $ets + "人")
            },
            addLinkMan: function() {
                $(".f_add_btn").click(function() {
                    var strHTML = $(".temp").eq(0).clone(true);
                    strHTML.find("input").val("");
                    $("#box").append(strHTML);

                    pageOpt.chageCK();
                    $("#JiPiaoNum").val($(".del_icon").length);
                    pageOpt.sumPrice();


                })

            }
        }

        $(function() {

            pageOpt.removeLinkMan();
            pageOpt.addLinkMan();
            pageOpt.BaoCun();
            $("[name=u-Type]").change(function() {
                pageOpt.chageCK();
            })




        })
    </script>

    <script type="text/javascript">

        $("#span_t").click(function() {
            var $that = $(this);
            var $ul = $("#ul_t");
            if ($that.attr("class") == "up_jiantou") {
                $that.attr("class", "down_jiantou");
                $ul.hide();
            } else {
                $that.attr("class", "up_jiantou");
                $ul.show();
            }
        })
    </script>

</body>
</html>
