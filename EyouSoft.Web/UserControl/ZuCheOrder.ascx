<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZuCheOrder.ascx.cs"
    Inherits="EyouSoft.Web.UserControl.ZuCheOrder" %>
<div class="car_table">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="botborder font14">
        <tr>
            <td width="100" align="right">
                <b class="fontblue">租车方式：</b>
            </td>
            <td colspan="3">
                <label>
                    <input type="radio" name="radioSelect" checked="checked" id="radio" value="1" />
                    同城往返带司机包租车</label>
                <label>
                    <input type="radio" name="radioSelect" id="radio" value="2" />
                    单接或单送带司机包租车</label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <b class="fontblue">选择车型：</b>
            </td>
            <td>
                <%=GetCarHtml()%>
            </td>
            <td width="100" align="right">
                <b class="fontblue">租车数量：</b>
            </td>
            <td width="150">
                <input type="text" name="txtCarNumber" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                    id="txtCarNumber" class=" input_bluebk formsize100" />
                台
            </td>
        </tr>
    </table>
    <table width="100%" id="table_Banks" border="0" cellspacing="0" cellpadding="0">
        <tr class="tempRow">
            <td align="right">
                第<span class="tr-number">1</span>目的地：
            </td>
            <td name="td-gongli">
                <input type="text" id="txtfirstPlace" name="txtfirstPlace" class="input_bluebk formsize200"
                    value="" />&nbsp;-&nbsp;<input type="text" id="txtlastPlace" name="txtlastPlace"
                        class="input_bluebk formsize200" value="" />
            </td>
            <td class="font_yellow">
                请正确填写 市县区和道路名称
            </td>
            <td width="100" align="right">
                增加公里数：
            </td>
            <td width="150">
                <input type="text" readonly="readonly" name="txtGongli" id="txtGongli" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                    class=" input_bluebk formsize100" />
                公里 <a href="javascript:void(0);" class="add_btn addbtncontract">添加目的地</a>
            </td>
        </tr>
    </table>
    <div style="background: #f3f3f3;" class="padd">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="100" align="right">
            </td>
            <td>
            </td>
            <td width="100" align="right">
                往返全程公里数：
            </td>
            <td width="150">
                <input type="text" readonly="readonly" name="txtGongLiZong" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                    id="txtGongLiZong" class=" input_bluebk formsize100" />
                公里
            </td>
        </tr>
        <tr>
            <td align="right">
                出发日期：
            </td>
            <td>
                <span class="date_style formsize140">
                    <input id="txtInTime" name="txtInTime" type="text" onfocus="WdatePicker({minDate:'%y-%M-#{%d}'})" />
                    <a href="javascript:;">
                        <img src="images/rili.gif" /></a></span>
            </td>
            <td width="100" align="right">
                回归日期：
            </td>
            <td width="150">
                <span class="date_style formsize140">
                    <input type="text" id="txtBackTime" name="txtBackTime" onfocus="WdatePicker({minDate:'%y-%M-#{%d}'})" />
                    <a href="javascript:;">
                        <img src="images/rili.gif" /></a></span>
            </td>
        </tr>
        <tr>
            <td align="right">
                乘车人姓名：
            </td>
            <td>
                <input type="text" class=" input_bluebk formsize140" id="txtChengCheName" name="txtChengCheName" />
            </td>
            <td width="100" align="right">
                乘车人电话：
            </td>
            <td width="150">
                <input type="text" class=" input_bluebk formsize140" id="txtChengCheTel" name="txtChengCheTel" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" class="padd">
                <b class="font14 font_yellow">(请根据淡旺季情况提前足够时间定车)</b>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" class="padd">
                <b class="font14 fontblue">租车单价：</b>
            </td>
        </tr>
        <tr>
            <td id="tr_JinE" colspan="4" align="left" class="padd2">
                <strong>门市价：<font class="font14 fontblue">0</font> 元/台； 会员价：<font class="font14 fontblue">0</font>
                    元/台； 贵宾价 ：<font class="font14 fontblue">0</font>元/台； 代理价：<font class="font14 fontblue">0</font>
                    元/台； 员工价：<font class="font14 fontblue">0</font> 元/台；</strong>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" class="padd">
                <b class="font14 fontblue">租车总费：</b>
            </td>
        </tr>
        <tr>
            <td id="tr_JinEZong" colspan="4" align="left" class="padd2">
                <strong>门市费：<font class="font14 fontblue">0</font> 元/台； 会员费：<font class="font14 fontblue">0</font>
                    元/台； 贵宾费 ：<font class="font14 fontblue">0</font>元/台； 代理费：<font class="font14 fontblue">0</font>
                    元/台； 员工费：<font class="font14 fontblue">0</font> 元/台；</strong>
            </td>
        </tr>
    </table>
</div>
<div class="car_shm margin_T10">
    <strong>费用说明：</strong>租车费用包含：车辆使用费、司机工资、油费、过路过桥费。包租车标准时长每天不超过10小时， 超过10小时以上的，请现付给司机40元/小时的加时费。
    以上费用不含司机食宿费用，租车阶段涉及用餐或住宿的，请租车单位提供司机食宿，或按以下标 准现付给司机津贴：正餐30元/人餐，早餐10元/人餐，住宿150元/人天。
</div>
<div style="width: 300px; display: none; height: 218px; border: #ccc solid 1px; padding: 1px;
    float: left;" id="map_canvas">
</div>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=<%=BaiDuMapKey %>"></script>

<script type="text/javascript">

    <%=JSON() %>
//    var jsonJE = { Qjc: 0, Qgl: 0, Qcc: 0, Qcs: 0, Djc: 0, Dgl: 0, Dcc: 0 };
//    var jsonTJ = { Qhy: 0, Qgb: 0, Qfx: 0, Qyg: 0, Dhy: 0, Dgb: 0, Dfx: 0, Dyg: 0 }
    var jsonZ = { Zjc: 0, Zhy: 0, Zgb: 0, Zfx: 0, Zyg: 0 }
    var OrderPage = {
        radioClick: function() {
            $("input[name=radioSelect]").change(function() {

                OrderPage.Show();
            });
        },
        selectClick: function() {
            $("#ddl_carlist").change(function() {
                var _data = { id: $(this).val() };
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/ZiXunXX.aspx?dotype=select",
                    dataType: "json",
                    data: _data,
                    success: function(ret) {
                        if (ret.result == "0") {
                            var list = eval('(' + ret.obj + ')');
                            OrderPage.alt(list);
                        }
                        else {
                            var list = eval('(' + ret.obj + ')');
                            OrderPage.alt(list);
                        }
                    },
                    error: function() {
                    }
                });
            });
        },
        Bind: function() {
            OrderPage.radioClick();
            OrderPage.selectClick();

            OrderPage.InputChange();
            if ('<%=Iscarlist %>' == 'False'){
                OrderPage.Show();
            }
        },
        InputChange: function() {
            $("td[name=td-gongli]").find("input[type=text]").blur(function() {
                var first = $(this).closest("td").find("input[name=txtfirstPlace]").val();
                var end = $(this).closest("td").find("input[name=txtlastPlace]").val();
                if (first != "" && end != "") {
                    initeMap(first, end, $(this));
                }
            });
            $("#txtInTime").blur(function() {
                OrderPage.Show();
            });
            $("#txtBackTime").blur(function() {
                OrderPage.Show();
            });
            $("#txtCarNumber").blur(function() {
                OrderPage.Show();
            });
        },
        InputJinE: function() {
            var Gongli = 0;
            $("input[name='txtGongli']").each(function() {
                if (tableToolbar.getFloat($(this).val()) > 0) {
                    Gongli = tableToolbar.calculate(Gongli, $(this).val(), "+");
                }
            });
            $("#txtGongLiZong").val(Gongli);
            var tianshu = 0;
            if ($("#txtInTime").val() != "" && $("#txtBackTime").val() != "") {
                var tianshu = OrderPage.DateDiff($("#txtInTime").val(), $("#txtBackTime").val());
            }
            var JinE = 0;
            if ($("input[name=radioSelect]:checked").val() == "1") {
                if (Gongli > jsonJE.Qgl) {
                    var chaochu = tableToolbar.calculate(Gongli, jsonJE.Qgl, "-");
                    var chachuJinE = tableToolbar.calculate(chaochu, jsonJE.Qcc, "*");
                    JinE = tableToolbar.calculate(JinE, chachuJinE, "+");
                }
                if (tianshu > 0) {
                    var t = tableToolbar.calculate(tianshu, 1, "+");
                    var tJinE = tableToolbar.calculate(t, jsonJE.Qcs, "*");
                    JinE = tableToolbar.calculate(JinE, tJinE, "+");
                }
            }
            else {
                if (Gongli > jsonJE.Dgl) {
                    var Dchaochu = tableToolbar.calculate(Gongli, jsonJE.Dgl, "-");
                    var DchachuJinE = tableToolbar.calculate(Dchaochu, jsonJE.Dcc, "*");
                    JinE = tableToolbar.calculate(JinE, DchachuJinE, "+");
                }
            }
            return JinE;
        },
        alt: function(objct) {
        if ('<%=Iscarlist %>' == 'True') {
                jsonJE.Qjc = tableToolbar.getFloat(objct.MenShiJiaGeDanCheng);
                jsonJE.Qgl = tableToolbar.getFloat(objct.MenShiJiaGeZuChe);
                jsonJE.Qcc = tableToolbar.getFloat(objct.MenShiJiaGeChaoCheng);
                jsonJE.Qcs = tableToolbar.getFloat(objct.MenShiJiaGeChaoShi);
                //jsonJE.Dcs = tableToolbar.getFloat(objct.MenShiJiaGeChaoShi);
                jsonJE.Djc = tableToolbar.getFloat(objct.YouHuiJiaGeDanCheng);
                jsonJE.Dgl = tableToolbar.getFloat(objct.YouHuiJiaGeZuChe);
                jsonJE.Dcc = tableToolbar.getFloat(objct.YouHuiJiaGeZuChe);

                jsonTJ.Qhy = tableToolbar.getFloat(objct.QHuiYuanJieE);
                jsonTJ.Qgb = tableToolbar.getFloat(objct.QGuiBingJieE);
                jsonTJ.Qfx = tableToolbar.getFloat(objct.QFenXiaoShangJieE);
                jsonTJ.Qyg = tableToolbar.getFloat(objct.QYuanGongJieE);
                jsonTJ.Dhy = tableToolbar.getFloat(objct.DHuiYuanJieE);
                jsonTJ.Dgb = tableToolbar.getFloat(objct.DGuiBingJieE);
                jsonTJ.Dfx = tableToolbar.getFloat(objct.DFenXiaoShangJieE);
                jsonTJ.Dyg = tableToolbar.getFloat(objct.DYuanGongJieE);
            }
            OrderPage.Show();
        },
        Show: function() {
        var JinE = OrderPage.InputJinE();
            if ($("input[name=radioSelect]:checked").val() == "1") {
                jsonZ.Zjc = tableToolbar.calculate(JinE, jsonJE.Qjc, "+");
                jsonZ.Zhy = tableToolbar.calculate(JinE, jsonTJ.Qhy, "+");
                jsonZ.Zgb = tableToolbar.calculate(JinE, jsonTJ.Qgb, "+");
                jsonZ.Zfx = tableToolbar.calculate(JinE, jsonTJ.Qfx, "+");
                jsonZ.Zyg = tableToolbar.calculate(JinE, jsonTJ.Qyg, "+");
            }
            else {
                jsonZ.Zjc = tableToolbar.calculate(JinE, jsonJE.Djc, "+");
                jsonZ.Zhy = tableToolbar.calculate(JinE, jsonTJ.Dhy, "+");
                jsonZ.Zgb = tableToolbar.calculate(JinE, jsonTJ.Dgb, "+");
                jsonZ.Zfx = tableToolbar.calculate(JinE, jsonTJ.Dfx, "+");
                jsonZ.Zyg = tableToolbar.calculate(JinE, jsonTJ.Dyg, "+");
            }
            if (tableToolbar.getInt($("#txtCarNumber").val()) > 0) {
                jsonZ.Zjc = tableToolbar.calculate(jsonZ.Zjc, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zhy = tableToolbar.calculate(jsonZ.Zhy, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zgb = tableToolbar.calculate(jsonZ.Zgb, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zfx = tableToolbar.calculate(jsonZ.Zfx, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zyg = tableToolbar.calculate(jsonZ.Zyg, tableToolbar.getInt($("#txtCarNumber").val()), "*");
            }
            OrderPage.Html();
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
            if ($("input[name=radioSelect]:checked").val() == "1") {
                var html = "<strong>门市价：<font class=\"font14 fontblue\">" + jsonJE.Qjc + "</font> 元/台； 会员价：<font class=\"font14 fontblue\">" + jsonTJ.Qhy + "</font>";
                html += "元/台； 贵宾价 ：<font class=\"font14 fontblue\">" + jsonTJ.Qgb + "</font>元/台； 代理价：<font class=\"font14 fontblue\">" + jsonTJ.Qfx + "</font>"
                html += "元/台； 员工价：<font class=\"font14 fontblue\">" + jsonTJ.Qyg + "</font> 元/台；</strong>";
                $("#tr_JinE").html(html);

            }
            else {
                var html = "<strong>门市价：<font class=\"font14 fontblue\">" + jsonJE.Djc + "</font> 元/台； 会员价：<font class=\"font14 fontblue\">" + jsonTJ.Dhy + "</font>";
                html += "元/台； 贵宾价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dgb + "</font>元/台； 代理价：<font class=\"font14 fontblue\">" + jsonTJ.Dfx + "</font>"
                html += "元/台； 员工价：<font class=\"font14 fontblue\">" + jsonTJ.Dyg + "</font> 元/台；</strong>";
                $("#tr_JinE").html(html);
            }
            var html1 = "<strong>门市费：<font class=\"font14 fontblue\">" + jsonZ.Zjc + "</font> 元/台； 会员费：<font class=\"font14 fontblue\">" + jsonZ.Zhy + "</font>";
            html1 += "元/台； 贵宾费 ：<font class=\"font14 fontblue\">" + jsonZ.Zgb + "</font>元/台； 代理费：<font class=\"font14 fontblue\">" + jsonZ.Zfx + "</font>"
            html1 += "元/台； 员工费：<font class=\"font14 fontblue\">" + jsonZ.Zyg + "</font> 元/台；</strong>";
            $("#tr_JinEZong").html(html1);
        }
    }
    $(document).ready(function() {
        OrderPage.Bind();
        $("#table_Banks").autoAdd({ tempRowClass: "tempRow", addButtonClass: "addbtncontract", delButtonClass: "delbtncontract", indexClass: "tr-number" });
    });
    function initeMap(start, end, obj) {
        var map = new BMap.Map("map_canvas");
        var driving = new BMap.DrivingRoute(map, {
            renderOptions: {
                map: map
            }
        });
        var results2 = 0;
        driving.setSearchCompleteCallback(function(results) {
            try {
                var plan = results.getPlan(0);
                var km = parseInt(plan.getDistance(false)) / 1000;  // 驾车距离就是他了
                $(obj).closest("tr").find("input[name=txtGongli]").val(tableToolbar.getFloat(km));
                $("#txtvalue").val(km);
                results2 = km; OrderPage.Show();
            }
            catch (e) {
                $(obj).closest("tr").find("input[name=txtGongli]").val(0);
                $("#txtvalue").val(0);
            }
        })
        driving.search(start, end); return results2;
    }
</script>

<script type="text/javascript">


    var map = new BMap.Map("map_canvas");          // 创建地图实例
    var point = new BMap.Point('106.486654,29.490295', '106.581515,29.615467');  // 创建点坐标
    map.centerAndZoom(point, 16);                 // 初始化地图，设置中心点坐标和地图级别
    map.enableScrollWheelZoom();

    var infoWin = new BMap.InfoWindow('<div style="font-size: 9pt; width:250px;height:20px">名称：你好<br /><br />地址：北京</div>');

    var mkr = new BMap.Marker(point);
    map.addOverlay(mkr);
    mkr.openInfoWindow(infoWin)

    mkr.addEventListener("click", function(e) {
        mkr.openInfoWindow(infoWin);
    })

    
</script>

