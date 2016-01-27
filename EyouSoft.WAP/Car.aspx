<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="EyouSoft.WAP.Car" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title><%=FenXiangBiaoTi %></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        #allmap
        {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }
        #golist
        {
            display: none;
        }
        @media (max-device-width: 780px)
        {
            #golist
            {
                display: block !important;
            }
        }
    </style>
    <link href="/css/zt.css" rel="stylesheet" type="text/css" />

    <script src="js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="js/jquery_cm.js" type="text/javascript"></script>

    <script src="js/table-toolbar.js" type="text/javascript"></script>

    <script src="js/slogin.js" type="text/javascript"></script>

    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    $("#WForDC").val(i);
                    if ($("#WForDC").val() == "1") {
                        $("#Starting").html("出发地");
                        $("#danjietixing").show();
                        $("#Destination").hide();
                        $(".danjie").hide();
                    }
                    else {
                        $("#Starting").html("往返地址");
                        $("#danjietixing").hide();
                        $("#Destination").show();
                        $(".danjie").show();
                    }
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                }
            }

        }
    </script>

</head>
<body>
    <form id="form1">
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="car_banner">
            <%= CarImg%>
            <a href="CarXX.aspx?id=<%=carid  %>">
                <div class="car_banner_txt">
                    <span class="floatR">汽车详情</span>当前车型：<%= CarName%></div>
            </a>
        </div>
        <div class="padd cent">
           <div class="select down_jiantou" style="position:relative;">
           <select  name="ddl_carlist" id="ddl_carlist">
             <%=GetCarHtml()%>
           </select>
           </div> 
        </div>
        <div class="car_tab" id="n4Tab">
            <h2>
                租车方式 <em id="danjietixing" style="display: none;">(<span style="color: Red; font-size: 10px;">注:当天单程500公里内</span>)</em></h2>
            <div class="jq_TabTitle">
                <ul class="clearfix">
                    <li id="n4Tab_Title0" onclick="nTabs('n4Tab','n4Tab_Title0');" class="active"><a
                        href="javascript:void(0);">同城往返带司机包租车</a></li>
                    <li id="n4Tab_Title1" onclick="nTabs('n4Tab','n4Tab_Title1');" class="normal"><a
                        href="javascript:void(0);">单接或单送带司机包租车</a></li>
                    <input id="WForDC" name="WForDC" type="hidden" value="0" />
                </ul>
            </div>
            <div class="jq_TabContent">
                <div class="user_form">
                    <ul>
                        <li class="wid"><span class="label_name">数量</span> </li>
                    </ul>
                </div>
                <div id="n4Tab_Content0">
                    <div class="user_form mt10">
                        <ul>
                            <li><a class="yudin_btn" href="javascript:void(0);">地图选址</a> <span class="label_name">
                                <em id="Starting">往返地址</em></span>
                                <input type="text" name="txtfirstPlace" class="u-input car-input" value="浙江省杭州市武林广场"
                                    onfocus="javascript:if(this.value=='浙江省杭州市武林广场')this.value='';" onblur="javascript:if(this.value=='')this.value='浙江省杭州市武林广场';"
                                    forecolor="#999999">
                            </li>
                        </ul>
                    </div>
                    <div class="user_form mt10" data-name="zengjia">
                        <ul>
                            <li><a class="yudin_btn" href="javascript:void(0);">地图选址</a> <span class="label_name">
                                <em id="Destination">第<span class="tr-number">1</span></em>目的地</span>
                                <input type="text" name="txtlastPlace" class="u-input car-input" value="宁波">
                            </li>
                            <li><span class="label_name">增加公里数</span>
                                <input type="text" name="txtGongli" readonly="readonly" class="u-input car-input"
                                    style="width: 60px;" value="">公里 </li>
                        </ul>
                    </div>
                    <em class="danjie">
                        <div class="user_form mt10">
                            <ul>
                                <li><a class="yudin_btn" href="javascript:void(0);">地图选址</a> <span class="label_name">
                                    第<span class="tr-number">2</span>目的地</span>
                                    <input type="text" name="txtlastPlace" class="u-input car-input" value="请填写具体地址">
                                </li>
                                <li><span class="label_name">增加公里数</span>
                                    <input type="text" name="txtGongli" readonly="readonly" class="u-input car-input"
                                        style="width: 60px;" value="">公里 </li>
                            </ul>
                        </div>
                        <div class="padd">
                            <a class="add_btn" href="javascript:void(0);" style="padding-left: 40px;">
                                <div data-text="+" class="ico">
                                </div>
                                增加目的地</a><a href="javascript:void(0);" class="add_btn2 floatR">租车线路图</a></div>
                    </em>
                </div>
                <%--<div id="n4Tab_Content1" class="none">

                 
                 
                 <div class="user_form mt10">
                    <ul>
                       <li>
                          <a class="yudin_btn" href="#">地图选址</a>
                          <span class="label_name">出发地</span>
                          <input type="text" class="u-input car-input" value="杭州武林广场">
                       </li>

                       <li>
                          <a class="yudin_btn" href="#">地图选址</a>
                          <span class="label_name">目的地</span>
                          <input type="text" class="u-input car-input" value="杭州武林广场">
                       </li>
                       
                       <li>
                          <span class="label_name">增加公里数</span>
                          <input type="text" class="u-input car-input" style="width:60px;" value="20"> 公里
                       </li>
                       
                    </ul>
                 </div>
                 
                  
                </div>--%>
                <div class="car_form">
                    <ul class="line">
                        <em class="danjie">
                            <li id="quancheng" style="padding-right:10px;"></li>
                            <li>
                                <label>
                                    全程公里数</label>
                                <span class="font_yellow"><em id="wfzgl"></em>
                                    <input id="QiZhongGL" type="hidden" />
                                    <input id="WangFanGongLi" name="WangFanGongLi" type="hidden" />
                                </span>公里 </li>
                        </em>
                        <li>
                            <label>
                                出发日期</label>
                            <span class="font_yellow" id="chufa">
                                <%=shijian %></span> <a href="javascript:void(0);" id="strattime" class="yudin_btn1">
                                    重选</a><span class="font_red" style="white-space: nowrap;">请提前足够时间定车</span>
                            <input id="chufatime" name="chufatime" type="hidden" value="<%=shijian %>" />
                        </li>
                        <li>
                            <label>
                                出发时刻</label>
                            <div class="select formsize100 floatL">
                                <select id="ShiKe" name="ShiKe">
                                    <option value="0">00:00</option>
                                    <option value="1">1:00</option>
                                    <option value="2">2:00</option>
                                    <option value="3">3:00</option>
                                    <option value="4">4:00</option>
                                    <option value="5">5:00</option>
                                    <option value="6">6:00</option>
                                    <option value="7">7:00</option>
                                    <option selected="selected" value="8">8:00</option>
                                    <option value="9">9:00</option>
                                    <option value="10">10:00</option>
                                    <option value="11">11:00</option>
                                    <option value="12">12:00</option>
                                    <option value="13">13:00</option>
                                    <option value="14">14:00</option>
                                    <option value="15">15:00</option>
                                    <option value="16">16:00</option>
                                    <option value="17">17:00</option>
                                    <option value="18">18:00</option>
                                    <option value="19">19:00</option>
                                    <option value="20">20:00</option>
                                    <option value="21">21:00</option>
                                    <option value="22">22:00</option>
                                    <option value="23">23:00</option>
                                </select>
                            </div>
                            &nbsp;点 </li>
                        <em class="danjie">
                            <li>
                                <label>
                                    回归日期</label>
                                <span class="font_yellow" id="huigui">
                                    <%=shijian %></span> <a href="javascript:void(0);" id="endtime" class="yudin_btn1">重选</a>
                                <input id="huiguitime" name="huiguitime" type="hidden" value="<%=shijian %>" />
                            </li>
                        </em>
                        <li>
                            <label>
                                租车数量</label>
                            <span class="number"><i class="num-minus"></i>
                                <input id="WFCheNum" name="WFCheNum" type="tel" value="1"><i class="num-add"></i></span>
                        </li>
                    </ul>
                </div>
                <div class="user_form car_form2">
                    <ul class="line" style="padding-bottom: 15px;">
                        <li><span class="label_name">乘车联系人</span>
                            <input id="LxrName" name="LxrName" type="text" class="u-input car-input" value="">
                        </li>
                        <li><span class="label_name">乘车人手机</span>
                            <input id="LxrMoblie" name="LxrMoblie" type="tel" class="u-input car-input" value="">
                        </li>
                        <li style="height: auto;"><span class="label_name">备注</span>
                            <input id="BeiZhu" name="BeiZhu" type="text" class="u-input car-input" value="">
                        </li>
                    </ul>
                </div>
                <div class="car_form3">
                    <ul>
                        <li><span class="paddR">租车单价</span> <em class="tr_JinE"></em></li>
                        <li><span class="paddR">租车总价</span> <em class="tr_JinEZong"></em></li>
                    </ul>
                </div>
                <%if(isShow){ %>
                <div class="youhui_box mt10" style="background: #fff;">
                    <ul id="jiagelist">
                    </ul>
                </div>
                <%} %>
                <%if (!isLogin)
                  { %>
                <div class="padd cent" style="background: #fff;">
                    <input id="BtnLogin" type="button" class="y_btn gray_btn" value="非会员直接预订" /></div>
                <%} %>
            </div>
        </div>
    </div>
    <div id="l-map" style="display: none; width: 100%; height: 100%; box-sizing: border-box;">
    </div>
    <div class="datelist" style="display: none; padding-top: 48px; width: 100%; height: 100%;
        box-sizing: border-box;">
        <asp:Literal ID="litMonth" runat="server"></asp:Literal>
    </div>
    <input id="JiaoDian" type="hidden" />
    <div class="pay">
        <div class="pay_box">
            <div class="pay_total">
                订单总额：¥<em id="ZongJia">0</em></div>
            <div class="pay_btn">
                <a href="javascript:void(0);" class="step_btn">核对提交</a></div>
        </div>
    </div>
    </form>
    <div id="allmap" style="display: none; width: 100%; height: 480px;">
    </div>
    <div id="XCMap" style="display: none; width: 100%; height: 480px;">
    </div>
    <input id="XingC" type="hidden" value="浙江省杭州市武林广场,宁波" />
    <div id="TiJiaoMask" class="user-mask" style="display:none;">
   <div class="h-mask-cnt" style="margin-top:200px;">
       
       <div class="cent font_yellow font16" style="padding-top:20px;">
            正在提交订单，请等待。。。
       </div>
          
   </div>
</div>
</body>

<script type="text/javascript" src="http://api.map.baidu.com/api?type=quick&ak=ovOm8pf0QIyWC4n4jx8I5vPG&v=1.0"></script>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ovOm8pf0QIyWC4n4jx8I5vPG"></script>

<script type="text/javascript">
    $(function() {

        $(".num-minus").click(function() {
            var getNum = $(this).parent().find("input").eq(0);
            if (tableToolbar.getInt(getNum.val()) > 1) {
                getNum.val(tableToolbar.getInt(getNum.val()) - 1);
            } else {
                getNum.val(1);
            }
            PageOrder.Show();
        });
        $(".num-add").click(function() {
            var getNum = $(this).parent().find("input").eq(0);
            getNum.val(tableToolbar.getInt(getNum.val()) + 1);
            PageOrder.Show();
        });


        $("#strattime").click(function() {
            $(".warp").toggle();
            $(".datelist").toggle();
            $('body,html').animate({ scrollTop: 0 }, 500);
            $("#JiaoDian").val("chufa");
        })
        $("#endtime").click(function() {
            $(".warp").toggle();
            $(".datelist").toggle();
            $('body,html').animate({ scrollTop: 0 }, 500);
            $("#JiaoDian").val("huigui");
        })

        $(".riqi_day_select").click(function() {
            $("#" + $("#JiaoDian").val()).html($(this).attr("data-date"));
            $("#" + $("#JiaoDian").val() + "time").val($(this).attr("data-date"));
            if ($("#JiaoDian").val() == "chufa") {
                $("#huigui").html($(this).attr("data-date"));
                $("#huiguitime").val($(this).attr("data-date"));
            }
            $(".warp").toggle();
            $(".datelist").toggle();
            PageOrder.Show();
        })


        $(".yudin_btn").click(function() {
            $("#allmap").css("height", window.screen.height);
            var obj = $(this).closest("li").find("input");
            $("#allmap").show();
            $("#form1").hide();
            PageOrder.GetAdress(obj);
        })
        $(".add_btn").click(function() {
            var html = $("div[data-name=zengjia]").eq(0).clone(true);
            var mudicount = $(".tr-number").length + 1;
            html.find(".tr-number").html(mudicount);
            html.find("input[name=txtlastPlace]").val("请填写具体地址");
            html.find("input[name=txtGongli]").val("");
            $(this).closest(".padd").before(html);
        })
        $(".add_btn2").click(function() {
            $("#XCMap").css("height", window.screen.height);
            $("#XCMap").show();
            $("#form1").hide();
            PageOrder.GetXingCheng();
        });
        $("#XCMap").click(function() {

        $("#XCMap").hide();
        $("#form1").show();
         });
         $("#BtnLogin").click(function() { window.location.href = '/HuiYuanReg.aspx?rurl=' + encodeURIComponent(window.location.href); });
         $("#ddl_carlist").change(function() {
             var _data = { id: $(this).val() };
             $.ajax({
                 type: "post",
                 cache: false,
                 url: "/CommonPage/ajaxGetCarPrice.aspx?dotype=select",
                 dataType: "json",
                 data: _data,
                 success: function(ret) {
                     if (ret.result == "0") {
                         var list = eval('(' + ret.obj + ')');
                         PageOrder.alt(list);
                     }
                     else {
                         var list = eval('(' + ret.obj + ')');
                         PageOrder.alt(list);
                     }
                 },
                 error: function() {
                 }
             });
         });
        $(".step_btn").click(function() {
            var _m = iLogin.getM();
            if (!_m.isLogin) {
                window.location.href = '/Login.aspx?rurl=' + encodeURIComponent(window.location.href);
            }
            else {
                if (PageOrder.CheckForm()) {
                    var url = location.href;
                    url = url + "&dotype=save";
                    if (window.confirm("请确认提交")) {
                        $("#TiJiaoMask").toggle();
                        $.ajax({
                            type: "post",
                            cache: false,
                            url: url,
                            dataType: "json",
                            data: $(".step_btn").closest("form").serialize(),
                            success: function(ret) {
                            if (ret.result == "1") {
                                $("#TiJiaoMask").toggle();
                                    alert(ret.msg);
                                    window.location.href = "/Member/DingDanList.aspx?OrderType=8";
                                }
                                else {
                                    $("#TiJiaoMask").toggle();
                                    alert(ret.msg);
                                }
                            },
                            error: function() {
                            $("#TiJiaoMask").toggle();
                                alert("提交失败");
                            }
                        });
                    }
                }
            }
        });
    });
</script>

<script type="text/javascript">
     <%=JSON() %>;
    var jsonZ = { Zjc: 0, Zhy: 0, Zgb: 0, Zmfx: 0, Zfx: 0, Zyg: 0 };
    var usercate = <%= usercate%>;
    $(document).ready(function() {
    PageOrder.InputChange();
    PageOrder.Show();
    $("input[name=txtlastPlace]").blur();
    });
    var PageOrder = {
    CheckForm: function() {
            if ($("#LxrName").val() == "乘车人姓名") {
                alert("请填写乘车人姓名");
                return false;
            }
            else {
                if (!/^[\u4e00-\u9fa5a-zA-Z_]+$/.test($("#LxrName").val())) {
                    alert('请填写正确的乘车人姓名');
                    return false;
                }
             }

            if ($("#LxrMoblie").val() == "乘车人手机") {
                alert("请填写乘车人手机");
                return false;
            }
            else {
                var mobile = $("#LxrMoblie").val();
                if (!/^(13|15|18|14)\d{9}$/.test(mobile)) {
                    alert('请填写正确的乘车人手机');
                    return false;
                }
            }
            return true;
        },
        GetXingCheng: function()
        {
        var map = new BMap.Map("XCMap");
        var dianlist = $("#XingC").val();
var didian = new Array();
    didian = dianlist.split(',');
    map.enableKeyboard();
    map.enableScrollWheelZoom();
    map.centerAndZoom(new BMap.Point(120.169874, 30.276608), 11);
    //三种驾车策略：最少时间，最短距离，避开高速
    var routePolicy = BMAP_DRIVING_POLICY_LEAST_DISTANCE;
    for (var i = 0; i < didian.length - 1; i++) {
        search(didian[i], didian[i + 1], routePolicy);
        function search(start, end, route) {
            var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true }, policy: route });
            driving.search(start, end);
        }
    }
        },
        GetAdress: function(obj) {
        
//        var map = new BMap.Map("allmap");
//	map.centerAndZoom(new BMap.Point(120.169874, 30.276608), 11);
//	function showInfo(e){
//	alert(e.point.lng+","+e.point.lat);
//		bdGEO(e.point.lng,e.point.lat,obj);
//	}
//	map.addEventListener("click", showInfo);


var map = new BMap.Map("allmap");
	var point = new BMap.Point(120.169874, 30.276608);
	map.centerAndZoom(point,12);
	map.addControl(new BMap.ZoomControl());          
	var gc = new BMap.Geocoder();    

	map.addEventListener("click", function(e){        
		var pt = e.point;
		gc.getLocation(pt, function(rs){
			var addComp = rs.addressComponents;
			$(obj).val(addComp.province + addComp.city + addComp.district + addComp.street);
                    $("#allmap").hide();
                    $("#form1").show();
                    obj.focus();
                    obj.blur();
		});        
	});




        
//            // 百度地图API功能
//            var map = new BMap.Map("allmap");
//            var point = new BMap.Point(120.169874, 30.276608);
//            map.centerAndZoom(point, 12);
//            var geoc = new BMap.Geocoder();
//            map.enableKeyboard();
//            map.enableScrollWheelZoom();
//            map.addEventListener("click", function(e) {
//                var pt = e.point;
//                geoc.getLocation(pt, function(rs) {
//                    var addComp = rs.addressComponents;
//                    $(obj).val(addComp.province + addComp.city + addComp.district + addComp.street);
//                    $(".user-mask").hide();
//                    obj.focus();
//                    obj.blur();
//                });
//            });
        },
        InputChange: function() {
            $("input[name=txtlastPlace]").focus(function() {
                var mudicount = $(".tr-number").length;
                for (var zongnum = mudicount; zongnum > 0; zongnum--) {
                    var jiaodianlast = $(this).closest("li").find("input[name=txtlastPlace]").val();
                    if (jiaodianlast == "请填写具体地址") {
                        $(this).closest("li").find("input[name=txtlastPlace]").val("");
                    }
                }

            });
            $("input[name=txtlastPlace]").blur(function() {
                var first, end;
                var num = $(this).closest("li").find("span[class=tr-number]").html();
                end = $(this).closest("li").find("input[name=txtlastPlace]").val();
                if (num == 1) {
                    first = $("input[name=txtfirstPlace]").val();
                }
                else {
                    first = $("input[name=txtlastPlace]").eq(num - 2).val();
                }

                if (first == "请填写具体地址") {
                    first = "";
                }
                if (end == "请填写具体地址") {
                    end = "";
                }
                var mudicount = $(".tr-number").length;
                for (var zongnum = mudicount; zongnum > 0; zongnum--) {
                    var jiaodianlast = $(this).closest("li").find("input[name=txtlastPlace]").val()
                    if (jiaodianlast == "") {
                        $(this).closest("li").find("input[name=txtlastPlace]").val("请填写具体地址");
                    }
                }
                if (first != "" && end != "" && first != "请填写具体地址" && end != "请填写具体地址") {
                    initeMap(first, end, $(this));
                }
                else {
                    $(this).closest("ul").find("input[name=txtGongli]").val("");
                }


                var zongdian;
                for (var zongnum = mudicount; zongnum > 0; zongnum--) {
                    zongdian = $("input[name=txtlastPlace]").eq(zongnum - 1).val();
                    if (zongdian != "请填写具体地址" && zongdian != "") {
                        break;
                    }
                }
                for (var zongnum = mudicount; zongnum > 0; zongnum--) {
                    var jiaodianlast = $(this).closest("li").find("input[name=txtlastPlace]").val()
                    if (jiaodianlast == "") {
                        $(this).closest("li").find("input[name=txtlastPlace]").val("请填写具体地址");
                    }
                }
                var chufa = $("input[name=txtfirstPlace]").val();
                if (chufa != "" && zongdian != "" && first != "请填写具体地址" && end != "请填写具体地址") {
                    initeMap1(zongdian, chufa, $(this));
                }
                var nextend = $("input[name=txtlastPlace]").eq(num).val();
                if (nextend != "请填写具体地址" && nextend != "") {
                    $("input[name=txtlastPlace]").eq(num).blur();
                }
                PageOrder.Html();
            });
        },
        InputJinE: function(typenum) {
        
            var Gongli = 0;
            $("input[name=txtGongli]").each(function() {
                if (tableToolbar.getFloat($(this).val()) > 0) {
                    Gongli = tableToolbar.calculate(Gongli, $(this).val(), "+");
                }
            });

            var endchuf = $("#QiZhongGL").val();
            
             if ($("#WForDC").val() == "0") {
            $("#wfzgl").html((tableToolbar.getFloat(Gongli)+tableToolbar.getFloat(endchuf)).toFixed(2));
            }
            else
            {
            $("#wfzgl").html(tableToolbar.getFloat(Gongli).toFixed(2));
            }
            Gongli = $("#wfzgl").html();
            $("#WangFanGongLi").val(Gongli);
            var gotoplace = $("input[name=txtfirstPlace]").val();
            xingcheng ="";
            xingcheng +=gotoplace+",";
            if(gotoplace =="请填写具体地址")
                 {
                 gotoplace="";
                 }
            var lutu ="<label>出行全程</label>从<span class=\"font_yellow\">"+gotoplace+"</span>";
            var zongshulutu=gotoplace;
            var count =$(".tr-number").length;
            if( count>0){
              for(var i=0;i<count;i++)
              {
                 var mudi = $("input[name=txtlastPlace]").eq(i).val();
                 if(mudi !="请填写具体地址" && mudi !="")
                 {
                 lutu +=" 到 <span class=\"font_yellow\">"+mudi+"</span>";
                 zongshulutu += mudi;
                 xingcheng +=mudi+",";
                 }
              }
            }
            $("#XingC").val(xingcheng+gotoplace);
            if(gotoplace !="" && $("#WForDC").val() == "0")
            {
            lutu +=" 到 <span class=\"font_yellow\">"+gotoplace+"</span>";
            zongshulutu += gotoplace;
            }
            if(zongshulutu.length>=50 && zongshulutu.length<=64)
            {
             lutu += "<br />";
            }
            $("#quancheng").html(lutu);
            var tianshu = 0;
            if ($("#chufatime").val() != "" && $("#huiguitime").val() != "") {
                var tianshu = PageOrder.DateDiff($("#chufatime").val(), $("#huiguitime").val());
            }
//            if ($("#txtInTime").val() != "" && $("#txtBackTime").val() != "") {
//                var tianshu = PageOrder.DateDiff($("#txtInTime").val(), $("#txtBackTime").val());
//            }
//            if(tianshu==0)
//            {
//            tianshu=1;
//            }
            var JinE = 0;
            if ($("#WForDC").val() == "0") {
                if (Gongli > jsonJE.Qgl) {
                var chaochengmoney=0;
                if(typenum==0)
                {
                chaochengmoney=jsonCC.QCms;
                }
                else if(typenum==1)
                {
                chaochengmoney=jsonCC.QChy;
                }
                else if(typenum==2)
                {
                chaochengmoney=jsonCC.QCgb;
                }
                else if(typenum==3)
                {
                chaochengmoney=jsonCC.QCmfx;
                }
                else if(typenum==4)
                {
                chaochengmoney=jsonCC.QCfx;
                }
                else if(typenum==5)
                {
                chaochengmoney=jsonCC.QCyg;
                }
                    var chaochu = tableToolbar.calculate(Gongli, jsonJE.Qgl, "-");
                    var chachuJinE = tableToolbar.calculate(chaochu, chaochengmoney, "*");
                    JinE = tableToolbar.calculate(JinE, chachuJinE, "+");
                }
                if (tianshu > 0) {
                var chaoshimoney=0;
                if(typenum==0)
                {
                chaoshimoney=jsonCS.QSms;
                }
                else if(typenum==1)
                {
                chaoshimoney=jsonCS.QShy;
                }
                else if(typenum==2)
                {
                chaoshimoney=jsonCS.QSgb;
                }
                else if(typenum==3)
                {
                chaoshimoney=jsonCS.QSmfx;
                }
                else if(typenum==4)
                {
                chaoshimoney=jsonCS.QSfx;
                }
                else if(typenum==5)
                {
                chaoshimoney=jsonCS.QSyg;
                }
                    //var t = tableToolbar.calculate(tianshu, 1, "+");
                    var tJinE = tableToolbar.calculate(tianshu, chaoshimoney, "*");
                    JinE = tableToolbar.calculate(JinE, tJinE, "+");
                }
            }
            else {
                if(Gongli>500)
                {
                alert("您的公里数大于500公里，请选择同城往返带司机包租车！");
                nTabs('n4Tab','n4Tab_Title0');
                $("input[name=txtlastPlace]").eq(0).blur();
                }
                //返回往返接送
else{
                if (Gongli > jsonJE.Dgl) {
                var chaochengmoney=0;
                if(typenum==0)
                {
                chaochengmoney=jsonCC.DCms;
                }
                else if(typenum==1)
                {
                chaochengmoney=jsonCC.DChy;
                }
                else if(typenum==2)
                {
                chaochengmoney=jsonCC.DCgb;
                }
                else if(typenum==3)
                {
                chaochengmoney=jsonCC.DCmfx;
                }
                else if(typenum==4)
                {
                chaochengmoney=jsonCC.DCfx;
                }
                else if(typenum==5)
                {
                chaochengmoney=jsonCC.DCyg;
                }
                    var Dchaochu = tableToolbar.calculate((Gongli*2), jsonJE.Dgl*2, "-");
                    var DchachuJinE = tableToolbar.calculate(Dchaochu, chaochengmoney, "*");
                    JinE = tableToolbar.calculate(JinE, DchachuJinE, "+");
                }
                if (tianshu > 0) {
               var chaoshimoney=0;
               if(typenum==0)
               {
               chaoshimoney=jsonCS.DSms;
               }
               else if(typenum==1)
               {
               chaoshimoney=jsonCS.DShy;
               }
               else if(typenum==2)
               {
               chaoshimoney=jsonCS.DSgb;
               }
               else if(typenum==3)
               {
               chaoshimoney=jsonCS.DSmfx;
               }
               else if(typenum==4)
               {
               chaoshimoney=jsonCS.DSfx;
               }
               else if(typenum==5)
               {
               chaoshimoney=jsonCS.DSyg;
                 }
                    //var t = tableToolbar.calculate(tianshu, 1, "+");
                    var tJinE = tableToolbar.calculate(tianshu, chaoshimoney, "*");
                    JinE = tableToolbar.calculate(JinE, tJinE, "+");
                }
           }
           }
            return JinE;
        },
        alt: function(objct) {
                jsonJE.Qjc = tableToolbar.getFloat(objct.MenShiJia);
                jsonJE.Qgl = tableToolbar.getFloat(objct.MenShiJiaGeZuChe);
//              jsonJE.Qcc = tableToolbar.getFloat(objct.);
                jsonJE.Qcc = tableToolbar.getFloat(objct.MenShiJiaGeChaoCheng);
                jsonJE.Qcs = tableToolbar.getFloat(objct.MenShiJiaGeChaoShi);
                //jsonJE.Dcs = tableToolbar.getFloat(objct.MenShiJiaGeChaoShi);
                jsonJE.Djc = tableToolbar.getFloat(objct.YouHuiJia);
                jsonJE.Dgl = tableToolbar.getFloat(objct.YouHuiJiaGeZuChe);
                jsonJE.Dcc = tableToolbar.getFloat(objct.YouHuiJiaGeZuChe);

                jsonTJ.Qhy = tableToolbar.getFloat(objct.QHuiYuanJieE);
                jsonTJ.Qgb = tableToolbar.getFloat(objct.QGuiBingJieE);
                jsonTJ.Qmfx = tableToolbar.getFloat(objct.QFreeFenXiaoShangJieE);
                jsonTJ.Qfx = tableToolbar.getFloat(objct.QFenXiaoShangJieE);
                jsonTJ.Qyg = tableToolbar.getFloat(objct.QYuanGongJieE);
                jsonTJ.Dhy = tableToolbar.getFloat(objct.DHuiYuanJieE);
                jsonTJ.Dgb = tableToolbar.getFloat(objct.DGuiBingJieE);
                jsonTJ.Dmfx = tableToolbar.getFloat(objct.DFreeFenXiaoShangJieE);
                jsonTJ.Dfx = tableToolbar.getFloat(objct.DFenXiaoShangJieE);
                jsonTJ.Dyg = tableToolbar.getFloat(objct.DYuanGongJieE);
                
                
                jsonCC.QCms = tableToolbar.getFloat(objct.QCMenShi);
                jsonCC.QChy = tableToolbar.getFloat(objct.QCHuiYuan);
                jsonCC.QCgb = tableToolbar.getFloat(objct.QCGuiBing);
                jsonCC.QCmfx = tableToolbar.getFloat(objct.QCFreeFenXiaoShang);
                jsonCC.QCfx = tableToolbar.getFloat(objct.QCFenXiaoShang);
                jsonCC.QCyg = tableToolbar.getFloat(objct.QCYuanGong);
                jsonCC.DCms = tableToolbar.getFloat(objct.DCMenShi);
                jsonCC.DChy = tableToolbar.getFloat(objct.DCHuiYuan);
                jsonCC.DCgb = tableToolbar.getFloat(objct.DCGuiBing);
                jsonCC.DCmfx = tableToolbar.getFloat(objct.DCFreeFenXiaoShang);
                jsonCC.DCfx = tableToolbar.getFloat(objct.DCFenXiaoShang);
                jsonCC.DCyg = tableToolbar.getFloat(objct.DCYuanGong);
                
                
                jsonCS.QSms = tableToolbar.getFloat(objct.QSMenShi);
                jsonCS.QShy = tableToolbar.getFloat(objct.QSHuiYuan);
                jsonCS.QSgb = tableToolbar.getFloat(objct.QSGuiBing);
                jsonCS.QSmfx = tableToolbar.getFloat(objct.QSFreeFenXiaoShang);
                jsonCS.QSfx = tableToolbar.getFloat(objct.QSFenXiaoShang);
                jsonCS.QSyg = tableToolbar.getFloat(objct.QSYuanGong);
                jsonCS.DSms = tableToolbar.getFloat(objct.DSMenShi);
                jsonCS.DShy = tableToolbar.getFloat(objct.DSHuiYuan);
                jsonCS.DSgb = tableToolbar.getFloat(objct.DSGuiBing);
                jsonCS.DSmfx = tableToolbar.getFloat(objct.DSFreeFenXiaoShang);
                jsonCS.DSfx = tableToolbar.getFloat(objct.DSFenXiaoShang);
                jsonCS.DSyg = tableToolbar.getFloat(objct.DSYuanGong);
                
            PageOrder.Show();
        },
        Show: function() {
        var JinE = 0;
            if ($("#WForDC").val() == "0") {
                JinE = PageOrder.InputJinE(0);
                jsonZ.Zjc = tableToolbar.calculate(JinE, jsonJE.Qjc, "+");
                JinE = PageOrder.InputJinE(1);
                jsonZ.Zhy = tableToolbar.calculate(JinE, jsonTJ.Qhy, "+");
                JinE = PageOrder.InputJinE(2);
                jsonZ.Zgb = tableToolbar.calculate(JinE, jsonTJ.Qgb, "+");
                JinE = PageOrder.InputJinE(3);
                jsonZ.Zmfx = tableToolbar.calculate(JinE, jsonTJ.Qmfx, "+");
                JinE = PageOrder.InputJinE(4);
                jsonZ.Zfx = tableToolbar.calculate(JinE, jsonTJ.Qfx, "+");
                JinE = PageOrder.InputJinE(5);
                jsonZ.Zyg = tableToolbar.calculate(JinE, jsonTJ.Qyg, "+");
            }
            else {
                JinE = PageOrder.InputJinE(0);
                jsonZ.Zjc = tableToolbar.calculate(JinE, jsonJE.Djc, "+");
                JinE = PageOrder.InputJinE(1);
                jsonZ.Zhy = tableToolbar.calculate(JinE, jsonTJ.Dhy, "+");
                JinE = PageOrder.InputJinE(2);
                jsonZ.Zgb = tableToolbar.calculate(JinE, jsonTJ.Dgb, "+");
                JinE = PageOrder.InputJinE(3);
                jsonZ.Zmfx = tableToolbar.calculate(JinE, jsonTJ.Dmfx, "+");
                JinE = PageOrder.InputJinE(4);
                jsonZ.Zfx = tableToolbar.calculate(JinE, jsonTJ.Dfx, "+");
                JinE = PageOrder.InputJinE(5);
                jsonZ.Zyg = tableToolbar.calculate(JinE, jsonTJ.Dyg, "+");
            }
            if (tableToolbar.getInt($("#WFCheNum").val()) > 0) {
                jsonZ.Zjc = tableToolbar.calculate(jsonZ.Zjc, tableToolbar.getInt($("#WFCheNum").val()), "*");
                jsonZ.Zhy = tableToolbar.calculate(jsonZ.Zhy, tableToolbar.getInt($("#WFCheNum").val()), "*");
                jsonZ.Zgb = tableToolbar.calculate(jsonZ.Zgb, tableToolbar.getInt($("#WFCheNum").val()), "*");
                jsonZ.Zmfx = tableToolbar.calculate(jsonZ.Zmfx, tableToolbar.getInt($("#WFCheNum").val()), "*");
                jsonZ.Zfx = tableToolbar.calculate(jsonZ.Zfx, tableToolbar.getInt($("#WFCheNum").val()), "*");
                jsonZ.Zyg = tableToolbar.calculate(jsonZ.Zyg, tableToolbar.getInt($("#WFCheNum").val()), "*");
            }
            PageOrder.Html();
        },
        DateDiff: function(DateOne, DateTwo) {
            var OneMonth = DateOne.substring(5, DateOne.lastIndexOf('-'));
            var OneDay = DateOne.substring(DateOne.length, DateOne.lastIndexOf('-') + 1);
            var OneYear = DateOne.substring(0, DateOne.indexOf('-'));

            var TwoMonth = DateTwo.substring(5, DateTwo.lastIndexOf('-'));
            var TwoDay = DateTwo.substring(DateTwo.length, DateTwo.lastIndexOf('-') + 1);
            var TwoYear = DateTwo.substring(0, DateTwo.indexOf('-'));

            var cha = ((Date.parse(OneMonth + '/' + OneDay + '/' + OneYear) - Date.parse(TwoMonth + '/' + TwoDay + '/' + TwoYear)) / 86400000);
            return Math.abs(cha);
        },
        Html: function() {
            var carnum = $("#WFCheNum").val();
              
              
              var mudicount = $(".tr-number").length;
                var zongdian;
                for (var zongnum = 0; zongnum < mudicount; zongnum++) {
                    zongdian = $("input[name=txtlastPlace]").eq(zongnum).val();
                    if (zongdian != "请填写具体地址" && zongdian != "") {
                        if ($("input[name=txtGongli]").eq(zongnum).val() == "0" || $("input[name=txtGongli]").eq(zongnum).val()=="") {
                            $("input[name=txtGongli]").eq(zongnum).val("无法计算距离，请重选");
                            $("input[name=txtGongli]").eq(zongnum).css("color","red");
                            html = html1 = "<strong style=\"color:red;\">第" + (zongnum + 1) + "目的地地址无法计算出两地距离，请重新选择地址</strong>";
                            $(".tr_JinE").html(html);
                            $(".tr_JinEZong").html(html1);
                             //$("#XiangxiShuJu").hide();
                             //$(".car_price").hide();
                            return false;
                        }
                    }
                }
            
            
            
                var html = "<span class=\"paddR\" style=\"width:170px;display:inline-block;\">门市价：<i class=\"line_x\">" + (jsonZ.Zjc/carnum).toFixed(2) + " 元</i>/辆</span>";
                if(usercate==2)
                {
                html += "<span style=\"white-space:nowrap; padding-left:70px;\">贵宾价：<i class=\"font_yellow\">" + (jsonZ.Zgb/carnum).toFixed(2) + "元</i>/辆</span>";
                }
                else if(usercate==3)
                {
                 html += "<span style=\"white-space:nowrap; padding-left:70px;\">代销价：<i class=\"font_yellow\">" + (jsonZ.Zmfx/carnum).toFixed(2) + "元</i>/辆</span>";
                }
                else if(usercate ==4)
                {
                html += "<span style=\"white-space:nowrap; padding-left:70px;\">代理价：<i class=\"font_yellow\">" + (jsonZ.Zfx/carnum).toFixed(2) + "元</i>/辆</span>";
                }
                else if(usercate==5)
                {
                 html += "<span style=\"white-space:nowrap; padding-left:70px;\">员工价：<i class=\"font_yellow\">" + (jsonZ.Zyg/carnum).toFixed(2) + "元</i>/辆</span>";
                }
                else
                {
                html += "<span style=\"white-space:nowrap; padding-left:70px;\">优惠价：<i class=\"font_yellow\">" + (jsonZ.Zhy/carnum).toFixed(2) + "元</i>/辆</span>";
                }

                $(".tr_JinE").html(html);


    
                          
                          
                          
                          
            var html1 = "<span class=\"paddR\" style=\"width:170px;display:inline-block;\">门市费：" + jsonZ.Zjc.toFixed(2) + " 元</span>";
            
            if(usercate==2)
                {
                html1 += "<span style=\"white-space:nowrap; padding-left:70px;\">贵宾费：<i class=\"font_yellow\">" + jsonZ.Zgb.toFixed(2) + "元</i></span>";
             $("#ZongJia").html(jsonZ.Zgb.toFixed(2));
                }
                else if(usercate==3)
                {
                html1 += "<span style=\"white-space:nowrap; padding-left:70px;\">代销费：<i class=\"font_yellow\">" + jsonZ.Zmfx.toFixed(2) + "元</i></span>";
             $("#ZongJia").html(jsonZ.Zmfx.toFixed(2));
                }
                else if(usercate ==4)
                {
                html1 += "<span style=\"white-space:nowrap; padding-left:70px;\">代理费：<i class=\"font_yellow\">" + jsonZ.Zfx.toFixed(2) + "元</i></span>";
             $("#ZongJia").html(jsonZ.Zfx.toFixed(2));
                }
                else if(usercate==5)
                {
                html1 += "<span style=\"white-space:nowrap; padding-left:70px;\">员工费：<i class=\"font_yellow\">" + jsonZ.Zyg.toFixed(2) + "元</i></span>";
             $("#ZongJia").html(jsonZ.Zyg.toFixed(2));
                }
                else
                {
                 html1 += "<span style=\"white-space:nowrap; padding-left:70px;\">优惠费：<i class=\"font_yellow\">" + jsonZ.Zhy.toFixed(2) + "元</i></span>";
             $("#ZongJia").html(jsonZ.Zhy.toFixed(2));
                }
                
            $(".tr_JinEZong").html(html1);
            
            
            
            var html2 = "";
            var num = $("#WFCheNum").val();
            var hysq = "";
            var gbsq = "<a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a>";
            var dlsq = "<a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a>";
            var hyls ="";
            var gbls ="立省<span class=\"font_yellow\">"+tableToolbar.getFloat((jsonZ.Zhy-jsonZ.Zgb))+"元</span>";
            var dlls ="立省<span class=\"font_yellow\">"+tableToolbar.getFloat((jsonZ.Zhy-jsonZ.Zfx))+"元</span>";
            if (usercate == 1) {
                hysq = "";
                hyls= "";
            }
            else if (usercate == 2) {
                hysq = "";
                gbsq = "";
                hyls= "";
                gbls ="";
            }
            else if (usercate == 3) {
                hysq = "";
                hyls= "";
            }
            else if (usercate == 4 || usercate == 5) {
                hysq = "";
                gbsq = "";
                dlsq = "";
                hyls= "";
                gbls ="";
                dlls ="";
            }
           
            html2 += "<li>" + hysq + "<span class=\"font_yellow\">优惠：</span>" + tableToolbar.getFloat(jsonZ.Zhy/num) + "元 x " + num + "辆 = <span class=\"font_yellow\">" + jsonZ.Zhy.toFixed(2) + "</span>元 "+hyls+"</li>";
            html2 += "<li>" + gbsq + "<span class=\"font_yellow\">贵宾：</span>" + tableToolbar.getFloat(jsonZ.Zgb/num) + "元 x " + num + "辆 = <span class=\"font_yellow\">" + jsonZ.Zgb.toFixed(2) + "</span>元 "+gbls+"</li>";
            html2 += "<li>" + dlsq + "<span class=\"font_yellow\">代理：</span>" + tableToolbar.getFloat(jsonZ.Zfx/num) + "元 x " + num + "辆 = <span class=\"font_yellow\">" + jsonZ.Zfx.toFixed(2) + "</span>元 "+dlls+"</li>";
            
            $("#jiagelist").html(html2);
            
        }
    }
    function initeMap(start, end, obj) {
        $(obj).closest("ul").find("input[name=txtGongli]").val("0");
        var map = new BMap.Map("l-map");
        var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map} });
        var results2 = 0;
        driving.setSearchCompleteCallback(function(results) {
            try {
                var plan = results.getPlan(0);
                var km = parseInt(plan.getDistance(false)) / 1000;  //驾车距离就是他了
                $(obj).closest("ul").find("input[name=txtGongli]").val(tableToolbar.getFloat(km));
                results2 = km;  PageOrder.Show();
            }
            catch (e) {
                $(obj).closest("ul").find("input[name=txtGongli]").val("");
            }
        })
        driving.search(start, end); return results2;
    }
    function initeMap1(start, end, obj) {
        var map = new BMap.Map("l-map");
        var driving = new BMap.DrivingRoute(map, {
            renderOptions: {
                map: map
            }
        });
        var results3 = 0;
        driving.setSearchCompleteCallback(function(results4) {
            try {
                var plan = results4.getPlan(0);
                var km = parseInt(plan.getDistance(false)) / 1000;  // 驾车距离就是他了
                $("#QiZhongGL").val(tableToolbar.getFloat(km));
                PageOrder.Show();
            }
            catch (e) {
                $("#QiZhongGL").val(0);
            }
        })
        driving.search(start, end);
    }
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
</html>
