<%@ Page Title="房型详情" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="HotelXiangQing2.aspx.cs" Inherits="EyouSoft.Web.HotelXiangQing2" %>

<%@ Import Namespace="EyouSoft.Model.HotelStructure.Interface" %>
<%@ Import Namespace="System.ComponentModel" %>
<%@ Register Src="UserControl/ZhuCe.ascx" TagName="ZhuCe" TagPrefix="uc1" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="EyouSoft.Model.HotelStructure.WebModel" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="EyouSoft.Model.HotelStructure" %>
<%@ Import Namespace="EyouSoft.BLL.HotelStructure" %>
<%@ Import Namespace="EyouSoft.Web" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>酒店</title>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

    <script type="text/javascript" src="/JS/slogin.js"></script>

    <style type="text/css">
        .B_hotel2
        {
            padding: 0;
        }
        .B_hotel2 .tablestyle
        {
            padding-top: 0;
        }
        .B_hotel2 .tablestyle .last_tr td
        {
            background: #548fe5;
            color: #fff;
        }
        .B_hotel2 .tablestyle .last_tr td a
        {
            background: url(/images/last_a.gif) no-repeat;
            width: 149px;
            height: 23px;
            line-height: 23px;
            text-align: center;
            color: #fff;
            font-weight: bold;
            display: inline-block;
        }
        .hotel_jieshao
        {
            width: 99%;
            border: #e1e1e1 solid 1px;
            float: left;
            display: inline;
            margin-top: 5px;
        }
        .hotel_jieshao .hotel_cont
        {
            padding: 14px 11px 5px 11px;
            line-height: 21px;
            overflow: hidden;
        }
        .hotel_login
        {
            width: 100%;
            float: none;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div class="mainbox">
        <div class="n_title">
            > 酒店预定</div>
        <div class="hotel_xxbox">
         <div class="page_code" style="top:5px; right:0;">
                <div class="code_box">
                     <div class="code_small"><img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                     <div class="code_big" style="display:none;"><img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                </div>
                 <p class="font_yellow">扫描二维码，分享手机版</p>
             </div>
        
            <div class="B_Titel" style="border: none 0;">
                <%=Model.HotelName %>
                <%=Html.HiddenFor(x=>x.HotelId) %>
                <%=Html.HiddenFor(x=>x.RoomRateIds) %>
            </div>
            <div class="hotel_tab">
                <ul class="fixed">
                    <li class="tab_on"><a href="#">基本信息</a></li>
                </ul>
            </div>
            <div class="msgbox fixed">
                <dl id="dlleft1">
                    <form id="form1">
                    <dt>酒店名称：<b class="font_yellow"><%=Model.HotelName %><%=Html.HiddenFor(x=>x.HotelId) %></b></dt>
                    <dd>
                        开业时间：<%=string.IsNullOrEmpty(Model.OpenDate)?"未知":(Model.OpenDate.Length==4? Model.OpenDate+"年" : (Model.OpenDate.Length==6?Model.OpenDate.Substring(0,4)+"年"+Model.OpenDate.Substring(4,2)+"月":Model.OpenDate)) %></dd>
                    <dd class="width50">
                        楼层数量：<%=string.IsNullOrEmpty(Model.Floor)? "未知":(Model.Floor.ToString()+"层") %></dd>
                    <dd class="width50">
                        装修时间：
                        <%=string.IsNullOrEmpty(Model.Fitment) ? "未知" : (Model.Fitment.Length == 4 ? Model.Fitment + "年" : (Model.Fitment.Length == 6 ? Model.Fitment.Substring(0, 4) + "年" + Model.Fitment.Substring(4, 2) + "月" : Model.Fitment))%></dd>
                    <dd class="width50">
                        房间数量：<b class="font_yellow"><%=Model.RoomQuantity %>间</b></dd>
                    <dd class="width50">
                        酒店星级：<b class="font_yellow"><%=Model.Star.HasValue ? ((int)Model.Star.Value > 5 ? Model.Star.ToString().Replace("准", "参考") : Model.Star.Value.ToString()) : "未知"%></b></dd>
                    <dd>
                        酒店电话：
                        <%=Model.ServiceTel %>
                    </dd>
                    <dd>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="16%" valign="top">
                                    酒店地址：
                                </td>
                                <td align="left" valign="top">
                                    <%=Model.Address%>
                                </td>
                            </tr>
                        </table>
                    </dd>
                    <dd class="width50">
                        周围景观：暂无数据
                    </dd>
                    <% if (Model.RoomTypeInfo != null)
                       { %>
                    <dd>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="16%" valign="top">
                                    房型描述：
                                </td>
                                <td align="left" valign="top">
                                    <%=Model.RoomTypeInfo.Desc%>
                                </td>
                            </tr>
                        </table>
                    </dd>
                    <% } %>
                    <dd class="width50 fontblue">
                        入住日期：<%=Html.TextBoxFor(x => x.RuZhuRiQi, new { @class = "input-style formsize100", onclick = "var nowdate=new Date();nowdate=nowdate.getFullYear()+'-'+(nowdate.getMonth()+1)+'-'+nowdate.getDate();WdatePicker({readOnly:true,minDate:nowdate,isShowClear:false,onpicked:function(){ var data0=$('#LiDianRiQi').val().split('-');var s0=new Date(parseInt(data0[0]),parseInt(data0[1],10)-1,parseInt(data0[2],10)); var data=$('#RuZhuRiQi').val().split('-');var s=new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime();if(s0<=s){s=new Date(s+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1<10?'0'+(s.getMonth()+1):(s.getMonth()+1))+'-'+(s.getDate()<10?'0'+s.getDate():s.getDate());$('#LiDianRiQi').val(s);};instance.xiuGai();}});" })%></dd>
                    <dd class="width50 fontblue">
                        离店日期：<%=Html.TextBoxFor(x => x.LiDianRiQi, new { @class = "input-style formsize100", onclick = "var data=$('#RuZhuRiQi').val().split('-');if(data[0]==''){return;};var s = new Date(new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime()+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1)+'-'+s.getDate();WdatePicker({readOnly:true,isShowClear:false,minDate:s,onpicked:instance.xiuGai })" })%></dd>
                    <dd class="fontblue">
                        预订数量：<select name="RoomCount" id="RoomCount" style="width: 50px;" onchange="instance.calculate();">
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
                        间</dd>
                    </form>
                </dl>
                <div class="hotel_map2">
                    <iframe width="100%" id="map1" height="100%" style="border: 0;"></iframe>
                </div>
            </div>
            <div class="B_hotel2">
                <div class="tablestyle">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="t1">
                        <tbody>
                            <%=Url.RenderPartial("~/HotelXiangQing2Room.aspx")%>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="B_hotel2">
                <div class="hotel_login">
                    <div class="user_side floatL" style="margin: 0; width: 100%;">
                        <table width="100%">
                            <tr>
                                <% if (CurrentUser.UserType == MemberTypes.未注册用户)
                                   { %>
                                <td width="33%" align="center">
                                    <a style="margin-left: 55px;" class="btn02_blue" href="javascript:location='/lg.aspx?rurl='+encodeURIComponent(location.href)">
                                        立即注册</a>
                                </td>
                                <td align="left" width="33%">
                                    <b style="font-size: 14px;">已是会员/贵宾/代理:</b><a class="btn02_yellow" href="javascript:javascript:location='/lg.aspx?rurl='+encodeURIComponent(location.href);">立即登录</a>
                                </td>
                                <td width="33%" align="left">
                                    <b style="font-size: 14px; margin-left: 5px;">非会员：</b><a class="btn02_blue zjyd"
                                        href="javascript:;" onclick="instance.yuDing2();"> 直接预订</a>
                                </td>
                                <%} %>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <% if (CurrentUser.UserType != MemberTypes.未注册用户)
               {  %>
            <div style="padding-top: 4px; text-align: center;">
                <a class="btn02_blue zjyd" href="javascript:;" onclick="instance.yuDing2();">直接预订</a>
            </div>
            <%}%>
            <div class="B_hotel2" id="qitataocan">
                <div class="hotel_jieshao" style="border: 0;">
                    <div class="basicT" style="margin-bottom: 3px;">
                        <h3>
                            <a href="#" name="t2">该房型其他套餐</a></h3>
                    </div>
                    <div class="" style="padding: 0; border: 0;">
                        <div class="tablestyle" style="border: 0; width: 100%;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="t2">
                                <tbody>
                                    <%=Url.RenderPartial("~/HotelXiangQingRoom.aspx", new { RuZhuRiQi = Model.RuZhuRiQi, LiDianRiQi = Model.LiDianRiQi, HotelId = Model.HotelId, RoomTypeId = Model.RoomTypeInfo.RoomTypeId, RoomRateId_Except = Model.RoomRateIds })%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="B_hotel2">
                <div class="hotel_jieshao">
                    <div class="basicT">
                        <h3>
                            <a href="#" name="t2">酒店简介</a></h3>
                    </div>
                    <div class="hotel_cont">
                        <img src="<%=Model.FirstImageAddress %>" /><p>
                            <%=Model.LongDesc%></p>
                    </div>
                </div>
            </div>
            <div class="B_hotel2">
                <div class="hotel_jieshao" style="border: 0;">
                    <div class="basicT" style="margin-bottom: 3px;">
                        <h3>
                            <a href="#" name="t2">其他房型</a></h3>
                    </div>
                    <div class="" style="padding: 0; border: 0;">
                        <div class="tablestyle" style="border: 0; width: 100%;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="t3">
                                <tbody>
                                    <%=Url.RenderPartial("~/HotelXiangQingRoom.aspx", new { RuZhuRiQi = Model.RuZhuRiQi, LiDianRiQi = Model.LiDianRiQi, HotelId = Model.HotelId, RoomTypeId_Except = Model.RoomTypeInfo.RoomTypeId })%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Foot">

    <script type="text/javascript">
        var instance = new PageSubmitForm();

        //修改日期后的数据刷新
        instance.xiuGai = function() {
            var step3 = function() {
                $.get('/HotelXiangQingRoom.aspx', //其他房型
                {
                ret: Math.random(),
                hotelid: $('#HotelId').val(),
                RuZhuRiQi: $('#RuZhuRiQi').val(),
                lidianriqi: $('#LiDianRiQi').val(),
                roomTypeId_Except: $('#RoomTypeId').val()
            }, function(txt) {
                $('#t3 tr').remove();
                $('#t3 tbody').html(txt);
                instance.refreshUI(); //刷新
            });
        };
        var step2 = function() { //该房型其他套餐
            var querydata = {
                ret: Math.random(),
                hotelid: $('#HotelId').val(),
                RuZhuRiQi: $('#RuZhuRiQi').val(),
                lidianriqi: $('#LiDianRiQi').val(),
                roomTypeId: $('#RoomTypeId').val()
            };
            querydata.roomRateId_Except = $('#RoomRateIds').val();
            $.get('/HotelXiangQingRoom.aspx', querydata, function(txt) {
                $('#t2 tr').remove();
                $('#t2 tbody').html(txt);
                step3();
            });
        };

        var step1 = function() {
            $.get('/HotelXiangQing2Room.aspx', //当前价格套餐
                {
                ret: Math.random(),
                hotelid: $('#HotelId').val(),
                RuZhuRiQi: $('#RuZhuRiQi').val(),
                lidianriqi: $('#LiDianRiQi').val(),
                RoomTypeId: $('#RoomTypeId').val(),
                RoomRateIds: $('#RoomRateIds').val()
            }, function(txt) {
                $('#t1 tr').remove();
                $('#t1 tbody').html(txt);
                step2();
            });
        }
        step1();
    };
    //其他房型下的预订事件
    instance.yuDing = function(roomTypeId, checkInDate, checkOutDate, roomRateIds) {
        var querydata = {
            ret: Math.random(),
            RuZhuRiQi: checkInDate,
            LiDianRiQi: checkOutDate,
            HotelId: $('#HotelId').val(),
            RoomTypeId: roomTypeId,
            RoomRateIds: roomRateIds
        };
        location = '/HotelXiangQing2.aspx?' + $.param(querydata);
    };
    //当前即将预订的套餐
    instance.yuDing2 = function() {
        var roomTypeId = $('#RoomTypeId').val()
        var checkInDate = $('#RuZhuRiQi').val();
        var checkOutDate = $('#LiDianRiQi').val();
        var rids = []; $('#t1 td[rid]').each(function() { rids[rids.length] = $(this).attr('rid'); });
        if (rids.length == 0) {
            tableToolbar._showMsg('未发现此房型的价格信息');
            return;
        };
        var roomRateIds = rids.toString();
        var querydata = {
            ret: Math.random(),
            roomCount: $('#RoomCount').val(),
            roomTypeId: roomTypeId,
            checkInDate: checkInDate,
            checkOutDate: checkOutDate,
            RoomRateIds: roomRateIds
        };

        if (iLogin.getM().isLogin) {
            location = '/HotelOrder.aspx?' + $.param(querydata);
        }
        else {
            location = '/YuDing.aspx?rurl=/HotelOrder.aspx?' + encodeURIComponent($.param(querydata));
        }
    };
    //当前房型其他套餐的预订
    instance.yuDing3 = function(roomRateIds) {
        var roomTypeId = $('#RoomTypeId').val()
        var checkInDate = $('#RuZhuRiQi').val();
        var checkOutDate = $('#LiDianRiQi').val();
        var querydata = {
            ret: Math.random(),
            roomCount: $('#RoomCount').val(),
            RuZhuRiQi: checkInDate,
            LiDianRiQi: checkOutDate,
            HotelId: $('#HotelId').val(),
            RoomTypeId: roomTypeId,
            RoomRateIds: roomRateIds
        };
        location = '/HotelXiangQing2.aspx?' + $.param(querydata);
    };
    //计算统计数据，总金额
    instance.calculate = function() {
        var jian = parseInt($('#RoomCount').val());
        $('.jian').html(jian);
        $('.totalMoney').each(function() {
            var p = $(this).parents('td:first');
            var danjia = parseInt(p.find('.danjia').html());
            this.innerHTML = danjia * jian;
            var danjia_currentuser = parseInt($(this).parents('tr:first').find('td:first').attr('dj'));
            var lisheng = p.find('.lisheng');
            if (lisheng.length == 1) {
                lisheng.html(danjia_currentuser * jian - danjia * jian);
            }
        });

        var tr_zonge_xiaoshou = 0;
        var tr_zonge_huiyuan = 0;
        var tr_zonge_daixiao = 0;
        var tr_zonge_guibin = 0;
        var tr_zonge_daili = 0;
        var tr_lisheng_guibin = 0;
        var tr_lisheng_daili = 0;
        $('#t1 tr:gt(0)').each(function() {
            if ($(this).is('.last_tr')) {
                $(this).find('td:eq(1)').find('.zonge').html(tr_zonge_xiaoshou);
                $(this).find('td:eq(2)').find('.zonge').html(tr_zonge_huiyuan);
                $(this).find('td:eq(3)').find('.zonge').html(tr_zonge_daixiao);
                $(this).find('td:eq(4)').find('.zonge').html(tr_zonge_guibin);
                $(this).find('td:eq(5)').find('.zonge').html(tr_zonge_daili);
                $(this).find('td:eq(3)').find('.lisheng').html(tr_lisheng_guibin);
                $(this).find('td:eq(4)').find('.lisheng').html(tr_lisheng_daili);
                tr_zonge_xiaoshou = 0;
                tr_zonge_huiyuan = 0;
                tr_zonge_daixiao = 0;
                tr_zonge_guibin = 0;
                tr_zonge_daili = 0;
                tr_lisheng_guibin = 0;
                tr_lisheng_daili = 0;
            }
            else {
                tr_zonge_xiaoshou += parseInt($(this).find('td:eq(3)').find('.totalMoney').html());
                tr_zonge_huiyuan += parseInt($(this).find('td:eq(4)').find('.totalMoney').html());
                tr_zonge_daixiao += parseInt($(this).find('td:eq(5)').find('.totalMoney').html());
                tr_zonge_guibin += parseInt($(this).find('td:eq(6)').find('.totalMoney').html());
                tr_zonge_daili += parseInt($(this).find('td:eq(7)').find('.totalMoney').html());
                tr_lisheng_guibin += parseInt($(this).find('td:eq(6)').find('.lisheng').html());
                tr_lisheng_daili += parseInt($(this).find('td:eq(7)').find('.lisheng').html());
            }
        });
    };
    //申请贵宾或代理的跳转
    instance.shenqing = function(userType, userTypeName) {
        if (userType == '<%=(int)MemberTypes.贵宾会员 %>') {
            location = '/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767';
        }
        if (userType == '<%=(int)MemberTypes.代理 %>') {
            location = '/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652';
        }
    };
    instance.refreshUI = function() {
        if ($('#t1 tr:gt(0):not(.last_tr)').length == 0) { //如果当前套餐无任何数据
            $('.zjyd').attr('disabled', true);
        } else {
            $('.zjyd').attr('disabled', false);
        }
        if ($('#t2 tbody tr:gt(0)').length == 0) {
            $('#qitataocan').hide();
        }
        else {
            $('#qitataocan').show();
        }
    };
    onload = function() {
        var mapurl = "/YouHuiMenPiaoMap.aspx?ScenicName=<%=Server.UrlEncode(Model.HotelName) %>&CityName=<%=Server.UrlEncode(Model.CityName) %>&x=<%=Model.Longitude %>&y=<%=Model.Latitude %>&address=<%=Server.UrlEncode(Model.Address) %>&mobile=<%=Server.UrlEncode(Model.Mobile) %>&tre=" + Math.random();
        if ($.browser.msie) {
            mapurl += '&h=306&w=632';
        }
        else if ($.browser.mozilla) {
            mapurl += '&h=310&w=635';
        }
        document.getElementById('map1').src = mapurl;
        instance.refreshUI();
    };
    </script>
<script type="text/javascript">
     $(".code_small").mouseover(function() {
         $(".code_big").toggle();
     });
     $(".code_small").mouseout(function() {
         $(".code_big").toggle();
     });
    </script>
</asp:Content>
