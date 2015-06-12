<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZuCheOrder1.ascx.cs"
    Inherits="EyouSoft.Web.UserControl.ZuCheOrder1" %>
<div class="car_table">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="botborder font14">
        <tr>
            <td width="100" align="right">
                <b class="fontblue">租车方式：</b>
            </td>
            <td colspan="3">
                <label>
                    <input type="radio" name="radioSelect" checked="checked" id="radio1" value="1" />
                    同城往返带司机包租车</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <label>
                    <input type="radio" name="radioSelect" id="radio2" value="2" />
                    单接或单送带司机包租车
                </label>
                ( <span style="color: Red">注：当天单程500公里内</span> )
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
                <select id="txtCarNumber" name="txtCarNumber" style="width:100px;" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                </select>
                <%--<input type="text" name="txtCarNumber" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                    id="txtCarNumber" class=" input_bluebk formsize100" value="1" />--%>
                台
            </td>
        </tr>
    </table>
    <table width="100%" id="table_Banks" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td name="abc" style="padding-left: 25px">
                <span id="Starting">往返地址：&nbsp;&nbsp;</span><input type="text" id="txtfirstPlace"
                    name="txtfirstPlace" class="input_bluebk formsize400" value="浙江省杭州市武林广场" valid="required"
                    errmsg="请输入往返地址!" />
            </td>
        </tr>
        <tr class="tempRow">
            <td name="td-gongli" style="padding-left: 25px">
                <em id="Destination">第<span class="tr-number">1</span></em>目的地：<input type="text"
                    id="txtlastPlace" name="txtlastPlace" class="input_bluebk formsize400" value="请详细正确填写市县区和道路名称"
                    valid="required" errmsg="请输入第一目的地!" /><span style="margin-left: 63px">公里数：</span><input
                        type="text" readonly="readonly" name="txtGongli" id="Text1" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                        class=" input_bluebk formsize100" />公里
            </td>
        </tr>
        <tr class="tempRow danjie">
            <td name="td-gongli" style="padding-left: 25px">
                第<span class="tr-number">2</span>目的地：<input type="text" id="Text2" name="txtlastPlace"
                    class="input_bluebk formsize400" value="请详细正确填写市县区和道路名称" /><span style="margin-left: 63px">公里数：</span><input
                        type="text" readonly="readonly" name="txtGongli" id="Text3" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                        class=" input_bluebk formsize100" />公里
            </td>
        </tr>
        <tr class="tempRow danjie">
            <td name="td-gongli" style="padding-left: 25px">
                第<span class="tr-number">3</span>目的地：<input type="text" id="Text4" name="txtlastPlace"
                    class="input_bluebk formsize400" value="请详细正确填写市县区和道路名称" /><span style="margin-left: 63px">公里数：</span><input
                        type="text" readonly="readonly" name="txtGongli" id="Text5" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                        class=" input_bluebk formsize100" />公里
            </td>
        </tr>
        <tfoot>
            <tr>
                <td style="padding-left: 25px" align="left" bgcolor="#f3f3f3" class="padd">
                    <em  class="danjie" style="padding-left:65px;"><a href="javascript:void(0);" class="add_btn addbtncontract">添加目的地</a></em><em style="padding-left:65px"><a href="javascript:void(0);" id="chakanditu" class="add_btn">查看地图</a></em>
                </td>
            </tr>
        </tfoot>
    </table>
    <div style="background: #f3f3f3;" class="padd">
    </div>
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1030px;">
        <tr class="danjie">
            <td align="left" colspan="4" style="padding-left: 25px">
                <span id="quancheng"></span><span>全程往返总公里数：<input id="endchufa" type="hidden" />
                    <input type="text" readonly="readonly" name="wangfan" onkeyup="this.value=this.value.replace(/[^\d]/g,&#39;&#39;)"
                        id="wangfan" class=" input_bluebk formsize140" />公里</span>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="padding-left: 25px">
                出发日期：
                <input id="txtInTime" name="txtInTime" type="text" onfocus="WdatePicker({minDate:'%y-%M-#{%d}'})"
                    valid="required" errmsg="请选择出发日期!" class="input_bluebk  formsize120 Wdate" style="border: #7f9db9 solid 1px;
                    height: 22px;" />
                &nbsp;出发时刻
                <select id="SelectShiKe" name="SelectShiKe" style="width:70px;">
                    <option value="0">0:00</option>
                    <option value="1">1:00</option>
                    <option value="2">2:00</option>
                    <option value="3">3:00</option>
                    <option value="4">4:00</option>
                    <option value="5">5:00</option>
                    <option value="6">6:00</option>
                    <option value="7">7:00</option>
                    <option value="8">8:00</option>
                    <option value="9" selected="selected">9:00</option>
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
                <em class="danjie"><span style="padding-left: 30px">回归日期</span>：<input type="text"
                    id="txtBackTime" name="txtBackTime" onfocus="WdatePicker({minDate:'%y-%M-#{%d}'})"
                    class="input_bluebk  formsize120 Wdate" style="border: #7f9db9 solid 1px; height: 22px;" /></em>
                <%--<a href="javascript:;">
                    <img src="images/rili.gif" /></a>--%>
                <b class="font14 font_yellow" style="padding-left: 17px; color:Red;">(请提前足够时间定车)</b>
            </td>
        </tr>
        <tr>
        <td style="padding-left: 25px; padding-top:20px;" colspan="4">
        乘车联系人：<input id="txtChengCheName" type="text" class="input_bluebk" style="width:220px;"  name="txtChengCheName" valid="required|isName" errmsg="乘车联系人姓名不能为空!|请填写正确的乘车人姓名,不能有数字!"/> <em style=" padding-left:90px;">乘车人联系手机：<input id="txtChengCheTel" type="text" class="input_bluebk" style="width:220px;" name="txtChengCheTel" valid="required|isMobile" errmsg="乘车联系人手机不能为空!|请填写正确乘车联系人手机!"/></em></td>
        </tr>
        <tr><td style="padding-left:25px; width:40px;">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td><td colspan="3" style="padding-top:10px; ">
        <textarea id="txtBeiZhu" name="txtBeiZhu" cols="20" rows="6" style="height:30px; width:645px;" class="input_bluebk"></textarea>           </td>
        </tr>
        <%--<tr id="wangfantishi">
            <td colspan="4" align="left" class="padd">
                <b class="font14 font_yellow">(请根据淡旺季情况提前足够时间定车)</b>
            </td>
        </tr>--%>
        <tr>
            <td colspan="4" align="left" class="padd">
                <b class="font14 fontblue">租车单价：</b>
            </td>
        </tr>
        <tr>
            <td id="tr_JinE" colspan="4" align="left" class="padd2">
                <strong>门市价：<font class="font14 fontblue">0</font> 元/台； 会员价：<font class="font14 fontblue">0</font>
                    元/台； 贵宾价 ：<font class="font14 fontblue">0</font>元/台； 二级代理价 ：<font class="font14 fontblue">0</font>元；
                    代理价：<font class="font14 fontblue">0</font> 元/台； 员工价：<font class="font14 fontblue">0</font>
                    元/台；</strong>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" class="padd">
                <b class="font14 fontblue">租车总费：</b>
            </td>
        </tr>
        <tr>
            <td id="tr_JinEZong" colspan="4" align="left" class="padd2">
                <strong>门市费：<font class="font14 fontblue">0</font> 元； 会员费：<font class="font14 fontblue">0</font>
                    元； 贵宾费 ：<font class="font14 fontblue">0</font>元； 二级代理费：<font class="font14 fontblue">0</font>元；
                    代理费：<font class="font14 fontblue">0</font> 元； 员工费：<font class="font14 fontblue">0</font>
                    元；</strong>
            </td>
        </tr>
    </table>
    
    
</div>
<%if(ShowOrHidden==0){ %>
<div class="car_price margin_T10">
    <em id="carpricelist"></em>
</div>
<%} %>
<div class="car_shm margin_T10">
    <strong>费用说明：</strong>租车费用包含：车辆使用费、司机工资、油费、过路过桥费。包租车标准时长每天不超过10小时， 超过10小时以上的，请现付给司机40元/小时的加时费。
    以上费用不含司机食宿费用，租车阶段涉及用餐或住宿的，请租车单位提供司机食宿，或按以下标 准现付给司机津贴：正餐30元/人餐，早餐10元/人餐，住宿150元/人天。
</div>
<div style="width: 300px; display: none; height: 218px; border: #ccc solid 1px; padding: 1px;
    float: left;" id="map_canvas">
</div>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=ovOm8pf0QIyWC4n4jx8I5vPG"></script>

<script type="text/javascript">
    window.onload = function() {

        var myDate = new Date();
        myDate.setDate(myDate.getDate() + 4);
        $("#txtInTime").val(myDate.getFullYear() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getDate());
        $("#txtBackTime").val(myDate.getFullYear() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getDate());

        // myDate.toLocaleDateString()
        var _data = { id: $("#ddl_carlist").val() };
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
    }
    $(function() {
        $("#txtfirstPlace").focus(function() {
            if ($('#txtfirstPlace').val() == "浙江省杭州市武林广场") { $('#txtfirstPlace').val(""); }
        });
        $("#txtfirstPlace").blur(function() {
            if ($('#txtfirstPlace').val() == "") { $('#txtfirstPlace').val("浙江省杭州市武林广场"); }
        });
        $("#chakanditu").click(function() {
            var dibiao = $('#txtfirstPlace').val() + ",";
            var mudicount = $(".tr-number").length;
            for (var i = 0; i < mudicount; i++) {
                var didian = $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(i).val();
                if (didian != "请详细正确填写市县区和道路名称") {
                   dibiao += didian + ",";
                }
            }
            window.open("/XingCheLuXian.aspx?dibiao=" + dibiao);
        });
    });
</script>

<script type="text/javascript">
    <%=JSON() %>
//    var jsonJE = { Qjc: 0, Qgl: 0, Qcc: 0, Qcs: 0, Djc: 0, Dgl: 0, Dcc: 0 };
//    var jsonTJ = { Qhy: 0, Qgb: 0, Qfx: 0, Qyg: 0, Dhy: 0, Dgb: 0, Dfx: 0, Dyg: 0 }
    var jsonZ = { Zjc: 0, Zhy: 0, Zgb: 0, Zmfx: 0, Zfx: 0, Zyg: 0 };
    var usercate = <%= usertype%>;
    var isguibin = <%= isguibin%>;
    var OrderPage = {
    setStart:"",
        radioClick: function() {
            $("input[name=radioSelect]").change(function() {
                if ($("input[name=radioSelect]:checked").val() == "2") {
                    $("#Starting").html("出发地：");
                    $("#Destination").css("display","none");  
                    $(".danjie").css("display","none"); 
                    var mudicount =$(".tr-number").length;
                    for(var zongnum= mudicount;zongnum>0;zongnum--)
                    {
                       if(zongnum !=1)
                       {
                          $("td[name=td-gongli]").find("input[name=txtGongli]").eq(zongnum-1).val("");
                          $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(zongnum-1).val("请详细正确填写市县区和道路名称");
                       }
                    }
                }
                else
                {
                    $("#Starting").html("往返地址：&nbsp;&nbsp;");
                    $("#Destination").css("display","");  
                    $(".danjie").css("display","");     
                }
                OrderPage.Show();
            });
        },
        panduan: function() {
        var mudicount =$(".tr-number").length;
            $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(mudicount-1).val("请详细正确填写市县区和道路名称");
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
        InputChange: function(obj) {
        
            $("input[name=txtlastPlace]").focus(function() {
            
             var mudicount =$(".tr-number").length;
                for(var zongnum= mudicount;zongnum>0;zongnum--)
                {
                    var jiaodianlast = $(this).closest("tr").find("input[name=txtlastPlace]").val()
                    if(jiaodianlast =="请详细正确填写市县区和道路名称")
                    {
                    $(this).closest("tr").find("input[name=txtlastPlace]").val("");
                    }
                }
            
            });
            $("input[name=txtlastPlace]").blur(function() {
            var first,end;
            var num = $(this).closest("tr").find("span[class=tr-number]").html();
            end = $(this).closest("tr").find("input[name=txtlastPlace]").val();
            if(num==1)
            {
              first = $("td[name=abc]").find("input[name=txtfirstPlace]").val();
            }
            else 
            {
            first = $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(num-2).val();
            }
            
            if(first =="请详细正确填写市县区和道路名称")
            {
               first="";
            }
            if(end =="请详细正确填写市县区和道路名称")
            {
               end="";
            }
            var mudicount =$(".tr-number").length;
                var zongdian;
                for(var zongnum= mudicount;zongnum>0;zongnum--)
                {
                        zongdian = $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(zongnum-1).val();
                        if(zongdian !="请详细正确填写市县区和道路名称" && zongdian !="")
                        {
                           break;
                        }
                }
                for(var zongnum= mudicount;zongnum>0;zongnum--)
                {
                     var jiaodianlast = $(this).closest("tr").find("input[name=txtlastPlace]").val()
                    if(jiaodianlast =="")
                    {
                    $(this).closest("tr").find("input[name=txtlastPlace]").val("请详细正确填写市县区和道路名称");
                    }
                }
                var chufa = $("td[name=abc]").find("input[name=txtfirstPlace]").val();
                if (first != "" && end != "") {
                    initeMap(first, end, $(this));
                    
                }
                else
                {
                   $(this).closest("tr").find("input[name=txtGongli]").val("");
                }
                if (chufa != "" && zongdian != "") {
                    initeMap1(zongdian, chufa, $(this));
                }
            });
            $("#txtInTime").blur(function() {
                OrderPage.Show();
            });
            $("#txtBackTime").blur(function() {
                OrderPage.Show();
            });
            $("#txtCarNumber").change(function() {
                OrderPage.Show();
            });
        },
        InputJinE: function(typenum) {
            var Gongli = 0;
            $("input[name='txtGongli']").each(function() {
                if (tableToolbar.getFloat($(this).val()) > 0) {
                    Gongli = tableToolbar.calculate(Gongli, $(this).val(), "+");
                }
            });

            var endchuf = $("#endchufa").val();
             if ($("input[name=radioSelect]:checked").val() == "1") {
            $("#wangfan").val((tableToolbar.getFloat(Gongli)+tableToolbar.getFloat(endchuf)).toFixed(2));
            }
            else
            {
            $("#wangfan").val(tableToolbar.getFloat(Gongli).toFixed(2));
            }
            Gongli = $("#wangfan").val();
            var gotoplace = $("td[name=abc]").find("input[name=txtfirstPlace]").val();
            if(gotoplace =="请详细正确填写市县区和道路名称")
                 {
                 gotoplace="";
                 }
            var lutu ="出行全程：<span style='color:Red; font-weight:bolder;'>"+gotoplace+"</span>";
            var zongshulutu=gotoplace;
            var count =$(".tr-number").length;
            if( count>0){
              for(var i=0;i<count;i++)
              {
                 var mudi = $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(i).val();
                 if(mudi !="请详细正确填写市县区和道路名称" && mudi !="")
                 {
                 lutu +=" 到 <span style='color:Red; font-weight:bolder;'>"+mudi+"</span>";
                 zongshulutu += mudi;
                 }
              }
            }
            if(gotoplace !="" && $("input[name=radioSelect]:checked").val() == "1")
            {
            lutu +=" 到 <span style='color:Red; font-weight:bolder;'>"+gotoplace+"</span>";
            zongshulutu += gotoplace;
            }
            if(zongshulutu.length>=50 && zongshulutu.length<=64)
            {
             lutu += "<br />";
            }
            $("#quancheng").html(lutu+"&nbsp;&nbsp;&nbsp;&nbsp;");
            var tianshu = 0;
            if ($("#txtInTime").val() != "" && $("#txtBackTime").val() != "") {
                var tianshu = OrderPage.DateDiff($("#txtInTime").val(), $("#txtBackTime").val());
            }
//            if(tianshu==0)
//            {
//            tianshu=1;
//            }
            var JinE = 0;
            if ($("input[name=radioSelect]:checked").val() == "1") {
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
                tableToolbar._showMsg("您的公里数大于500公里，请选择同城往返带司机包租车！",function(){
                $("#radio1").attr("checked",true);
                $("#Starting").html("往返地址：&nbsp;&nbsp;");
                    $("#Destination").css("display","");  
                    $(".danjie").css("display",""); 
                    OrderPage.Show();
                    });
                }
                if ((Gongli*2) > jsonJE.Dgl) {
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
            return JinE;
        },
        alt: function(objct) {
        if ('<%=Iscarlist %>' == 'True') {
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
                
                
            }
            OrderPage.Show();
        },
        Show: function() {
        var JinE = 0;
            if ($("input[name=radioSelect]:checked").val() == "1") {
                JinE = OrderPage.InputJinE(0);
                jsonZ.Zjc = tableToolbar.calculate(JinE, jsonJE.Qjc, "+");
                JinE = OrderPage.InputJinE(1);
                jsonZ.Zhy = tableToolbar.calculate(JinE, jsonTJ.Qhy, "+");
                JinE = OrderPage.InputJinE(2);
                jsonZ.Zgb = tableToolbar.calculate(JinE, jsonTJ.Qgb, "+");
                JinE = OrderPage.InputJinE(3);
                jsonZ.Zmfx = tableToolbar.calculate(JinE, jsonTJ.Qmfx, "+");
                JinE = OrderPage.InputJinE(4);
                jsonZ.Zfx = tableToolbar.calculate(JinE, jsonTJ.Qfx, "+");
                JinE = OrderPage.InputJinE(5);
                jsonZ.Zyg = tableToolbar.calculate(JinE, jsonTJ.Qyg, "+");
            }
            else {
                JinE = OrderPage.InputJinE(0);
                jsonZ.Zjc = tableToolbar.calculate(JinE, jsonJE.Djc, "+");
                JinE = OrderPage.InputJinE(1);
                jsonZ.Zhy = tableToolbar.calculate(JinE, jsonTJ.Dhy, "+");
                JinE = OrderPage.InputJinE(2);
                jsonZ.Zgb = tableToolbar.calculate(JinE, jsonTJ.Dgb, "+");
                JinE = OrderPage.InputJinE(3);
                jsonZ.Zmfx = tableToolbar.calculate(JinE, jsonTJ.Dmfx, "+");
                JinE = OrderPage.InputJinE(4);
                jsonZ.Zfx = tableToolbar.calculate(JinE, jsonTJ.Dfx, "+");
                JinE = OrderPage.InputJinE(5);
                jsonZ.Zyg = tableToolbar.calculate(JinE, jsonTJ.Dyg, "+");
            }
            if (tableToolbar.getInt($("#txtCarNumber").val()) > 0) {
                jsonZ.Zjc = tableToolbar.calculate(jsonZ.Zjc, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zhy = tableToolbar.calculate(jsonZ.Zhy, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zgb = tableToolbar.calculate(jsonZ.Zgb, tableToolbar.getInt($("#txtCarNumber").val()), "*");
                jsonZ.Zmfx = tableToolbar.calculate(jsonZ.Zmfx, tableToolbar.getInt($("#txtCarNumber").val()), "*");
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
            var carnum = $("#txtCarNumber").val();
//            if ($("input[name=radioSelect]:checked").val() == "1") {
            
                var html = "<strong>门市价：<font class=\"font14 fontblue\" style=\"text-decoration:line-through\">" + (jsonZ.Zjc/carnum).toFixed(2) + "</font> 元/台； 会员价：<font class=\"font14 fontblue\">" + (jsonZ.Zhy/carnum).toFixed(2) + "</font>元/台；";
                if(usercate==2)
                {
                  html += " 代销价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zmfx/carnum).toFixed(2) + "</font>元/台； 贵宾价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zgb/carnum).toFixed(2) + "</font>元/台；";
                }
                else if(usercate==3)
                {
                html += " 代销价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zmfx/carnum).toFixed(2) + "</font>元/台；";
                }
                else if(usercate ==4)
                {
                html += " 代销价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zmfx/carnum).toFixed(2) + "</font>元/台； 贵宾价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zgb/carnum).toFixed(2) + "</font>元/台； 代理价：<font class=\"font14 fontblue\">" + (jsonZ.Zfx/carnum).toFixed(2) + "</font>元/台；";
                }
                else if(usercate==5)
                {
                html += " 代销价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zmfx/carnum).toFixed(2) + "</font>元/台； 贵宾价 ：<font class=\"font14 fontblue\">" + (jsonZ.Zgb/carnum).toFixed(2) + "</font>元/台； 代理价：<font class=\"font14 fontblue\">" + (jsonZ.Zfx/carnum).toFixed(2) + "</font>元/台；员工价：<font class=\"font14 fontblue\">" + (jsonZ.Zyg/carnum).toFixed(2) + "</font> 元/台；";
                }
                html += " </strong>";

                $("#tr_JinE").html(html);

//            }
//            else {
//                var html = "<strong>门市价：<font class=\"font14 fontblue\">" + (jsonZ.Zjc/carnum) + "</font> 元/台； 会员价：<font class=\"font14 fontblue\">" + (jsonZ.Zhy/carnum) + "</font>元/台；";
//                if(usercate==2)
//                {
//                  html += " 贵宾价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dgb + "</font>元/台；";
//                }
//                else if(usercate==3)
//                {
//                html += " 贵宾价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dgb + "</font>元/台；二级代理价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dmfx + "</font>元/台；";
//                }
//                else if(usercate ==4)
//                {
//                html += " 贵宾价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dgb + "</font>元/台；二级代理价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dmfx + "</font>元/台； 代理价：<font class=\"font14 fontblue\">" + jsonTJ.Dfx + "</font>元/台；";
//                }
//                else if(usercate==5)
//                {
//                html += " 贵宾价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dgb + "</font>元/台；二级代理价 ：<font class=\"font14 fontblue\">" + jsonTJ.Dmfx + "</font>元/台； 代理价：<font class=\"font14 fontblue\">" + jsonTJ.Dfx + "</font>元/台；员工价：<font class=\"font14 fontblue\">" + jsonTJ.Dyg + "</font> 元/台；";
//                }
//                html += "</strong>";
//                $("#tr_JinE").html(html);
//            }
            var html1 = "<strong>门市费：<font class=\"font14 fontblue\" style=\"text-decoration:line-through\">" + jsonZ.Zjc.toFixed(2) + "</font> 元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;会员费：<font class=\"font14 fontblue\">" + jsonZ.Zhy.toFixed(2) + "</font>元；";
            
            if(usercate==2)
                {
                  html1 += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;代销费 ：<font class=\"font14 fontblue\">" + jsonZ.Zmfx.toFixed(2) + "</font>元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;贵宾费 ：<font class=\"font14 fontblue\">" + jsonZ.Zgb.toFixed(2) + "</font>元；";
                }
                else if(usercate==3)
                {
                html1 += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;代销费 ：<font class=\"font14 fontblue\">" + jsonZ.Zmfx.toFixed(2) + "</font>元；";
                }
                else if(usercate ==4)
                {
                html1 += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;代销费 ：<font class=\"font14 fontblue\">" + jsonZ.Zmfx.toFixed(2) + "</font>元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;贵宾费 ：<font class=\"font14 fontblue\">" + jsonZ.Zgb.toFixed(2) + "</font>元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;代理费：<font class=\"font14 fontblue\">" + jsonZ.Zfx.toFixed(2) + "</font>元；";
                }
                else if(usercate==5)
                {
                html1 += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;代销费 ：<font class=\"font14 fontblue\">" + jsonZ.Zmfx.toFixed(2) + "</font>元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;贵宾费 ：<font class=\"font14 fontblue\">" + jsonZ.Zgb.toFixed(2) + "</font>元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;代理费：<font class=\"font14 fontblue\">" + jsonZ.Zfx.toFixed(2) + "</font>元；&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;员工费：<font class=\"font14 fontblue\">" + jsonZ.Zyg.toFixed(2) + "</font> 元；";
                }
            
            html1 += "</strong>";
            $("#tr_JinEZong").html(html1);
            
            var guibinname ="申请贵宾身份";
            var dailiname ="申请代理身份";
            
            var dailiurl="<a href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+(jsonZ.Zhy-jsonZ.Zfx).toFixed(2)+"元</b>";
            
            var guibinurl ="<a href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+(jsonZ.Zhy-jsonZ.Zgb).toFixed(2)+"元</b>";
            if(isguibin==1)
            {
            if(usercate ==2){
            guibinname ="贵宾价格总金额";dailiname ="申请代理身份";
            guibinurl ="";
            
            }
            if(usercate ==3){
            guibinname ="贵宾价格总金额";dailiname ="申请代理身份";
            guibinurl ="";
            
            }
            if(usercate ==4){
            dailiname ="代理价格总金额";guibinname ="贵宾价格总金额";
            guibinurl=""; dailiurl="";
            }
            if(usercate ==5)
            {
            dailiname ="代理价格总金额";guibinname ="贵宾价格总金额";
            guibinurl=""; dailiurl="";
            }
            }
            
            html2 ="<ul><li class=\"mar5\"><div class=\"tixing\"><b>会员价总金额：</b><br /><font class=\"fontyellow\"><b class=\"font14\">"+(jsonZ.Zhy/carnum).toFixed(2)+"</b>元/台 x <b class=\"font14\">"+carnum+"</b>台 = </font> <font class=\"fontblue\"><b class=\"font14\">"+jsonZ.Zhy.toFixed(2)+"</b>元</font></div> </li><li class=\"mar5\"><div class=\"tixing\"><b>"+guibinname+"：</b><br /><font class=\"fontyellow\"><b class=\"font14\">"+(jsonZ.Zgb/carnum).toFixed(2)+"</b>元/台 x <b class=\"font14\">"+carnum+"</b>台 = </font><font class=\"fontblue\"><b class=\"font14\">"+jsonZ.Zgb.toFixed(2)+"</b>元</font>&nbsp;&nbsp;&nbsp;&nbsp;"+guibinurl+" </div> </li><li><div class=\"tixing\"><b>"+dailiname+"：</b><br /><font class=\"fontyellow\"><b class=\"font14\">"+(jsonZ.Zfx/carnum).toFixed(2)+"</b>元/台 x <b class=\"font14\">"+carnum+"</b>台 = </font><font class=\"fontblue\"><b class=\"font14\">"+jsonZ.Zfx.toFixed(2)+"</b>元</font>&nbsp;&nbsp;&nbsp;&nbsp; "+dailiurl+"</div>  </li></ul>";
            
            
            $("#carpricelist").html(html2);
            
        }
    }
    $(document).ready(function() {
        OrderPage.Bind();
        $("#table_Banks").autoAdd({ tempRowClass: "tempRow", addButtonClass: "addbtncontract", delButtonClass: "delbtncontract", indexClass: "tr-number",addCallBack:OrderPage.panduan});
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
//                $("#txtvalue").val(km);
                results2 = km; OrderPage.Show();
            }
            catch (e) {
                $(obj).closest("tr").find("input[name=txtGongli]").val("");
//                $("#txtvalue").val(0);
            }
        })
        driving.search(start, end); return results2;
    }
    function initeMap1(start, end, obj) {
        var map = new BMap.Map("map_canvas");
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
                $("#endchufa").val(km);
                results3 = km; OrderPage.Show();
            }
            catch (e) {
                $("#endchufa").val(0);
            }
        })
        driving.search(start, end); return results3;
    }
    
</script>

<script type="text/javascript">
    var pageBox = {
        CreatBoxy: function(data) {
            Boxy.iframeDialog({
                iframeUrl: data.url,
                title: data.title,
                modal: true,
                width: '500px',
                height: '300px'
            });
        }
    };

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

