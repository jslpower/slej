<%@ Page Title="房型详情" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="HotelXiangQing.aspx.cs" Inherits="EyouSoft.Web.HotelXiangQing" %>

<%@ Import Namespace="EyouSoft.Model.HotelStructure.Interface" %>
<%@ Import Namespace="System.ComponentModel" %>
<%@ Register Src="UserControl/ZhuCe.ascx" TagName="ZhuCe" TagPrefix="uc1" %>
<%@ Import Namespace="System.Linq" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>酒店</title>

    <script type="text/javascript">
        $(function() {
            $('#newsSlider').loopedSlider({
                autoStart: 3000
            });
            $('.validate_Slider').loopedSlider({
                autoStart: 3000
            });
        });
    </script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <form id="form1">
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
                <%=Model.HotelName %></div>
            <div class="hotel_tab">
                <ul class="fixed">
                    <li class="tab_on" onclick="instance.switchTab(this);"><a href="#">基本信息</a></li>
                    <li onclick="instance.switchTab(this);"><a href="#t1">酒店图片</a></li>
                    <li onclick="instance.switchTab(this);"><a href="#t2">酒店简介</a></li>
                    <li onclick="instance.switchTab(this);"><a href="#t3">房型价格</a></li>
                    <li onclick="instance.switchTab(this);"><a href="#t4">相关信息</a></li>
                </ul>
            </div>
            <%=Html.HiddenFor(x=>x.HotelId) %>
            <div class="msgbox fixed">
                <dl>
                    <dt>酒店名称：<b class="font_yellow"><%=Model.HotelName %></b></dt>
                    <dd>
                        开业时间：<%=string.IsNullOrEmpty(Model.OpenDate)?"未知":(Model.OpenDate.Length==4? Model.OpenDate+"年" : (Model.OpenDate.Length==6?Model.OpenDate.Substring(0,4)+"年"+Model.OpenDate.Substring(4,2)+"月":Model.OpenDate)) %></dd>
                    <dd>
                        楼层数量：<%=string.IsNullOrEmpty(Model.Floor)? "未知":(Model.Floor.ToString()+"层")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;装修时间：<%=string.IsNullOrEmpty(Model.Fitment) ? "未知" : (Model.Fitment.Length == 4 ? Model.Fitment + "年" : (Model.Fitment.Length == 6 ? Model.Fitment.Substring(0, 4) + "年" + Model.Fitment.Substring(4, 2) + "月" : Model.Fitment))%></dd>
                    <dd>
                        房间数量：<b class="font_yellow"><%=Model.RoomQuantity %>间</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;酒店星级：<b
                            class="font_yellow"><%=Model.Star.HasValue?(((int)Model.Star.Value) >5 ? Model.Star.ToString().Replace("准","参考"):Model.Star.Value.ToString()):"未知" %></b></dd>
                    <dd>
                        酒店电话：<%=Model.ServiceTel %></dd>
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
                    <dd>
                        周围景观： 暂无数据</dd>
                </dl>
                <div class="hotel_map">
                    <iframe width="640px" id="map1" height="220px" frameborder="0"  scrolling="no"></iframe>
                </div>
            </div>
        </div>
        <div class="B_hotel" id="jiudiantupian">
            <div class="basicT">
                <h3>
                    <a href="#" name="t1">酒店图片</a></h3>
            </div>
            <div class="shangch_list h_img">
                <span class="left_jt" onclick="instance.imgUp();"><a href="javascript:;">
                    <img src="/images/h_jtleft.gif" /></a></span> <span class="right_jt" onclick="instance.imgDown();">
                        <a href="javascript:;">
                            <img src="/images/h_jtright.gif" /></a></span>
                <ul class="b_imglist fixed">
                    <!--此处待修改-->
                    <%=Url.RenderPartial("~/HotelXiangQingImg.aspx")%>
                </ul>
            </div>
        </div>
        <div class="B_hotel" id="jianjiujianjie">
            <div class="basicT">
                <h3>
                    <a href="#" name="t2">酒店简介</a></h3>
            </div>
            <div class="hotel_cont">
                <p>
                    <%=Model.LongDesc %>
                </p>
            </div>
        </div>
        <div class="B_hotel" id="fangxingjiage">
            <div class="basicT fixed">
                <h3>
                    <a href="#" name="t3">房型价格</a></h3>
                <div class="search_r">
                    入住日期：<span class="date_style formsize140"><%=Html.TextBoxFor(x => x.RuZhuRiQi, new { onclick = "var nowdate=new Date();nowdate=nowdate.getFullYear()+'-'+(nowdate.getMonth()+1)+'-'+nowdate.getDate();WdatePicker({readOnly:true,minDate:nowdate,isShowClear:false,onpicked:function(){ var data0=$('#LiDianRiQi').val().split('-');var s0=new Date(parseInt(data0[0]),parseInt(data0[1],10)-1,parseInt(data0[2],10)); var data=$('#RuZhuRiQi').val().split('-');var s=new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime();if(s0<=s){s=new Date(s+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1<10?'0'+(s.getMonth()+1):(s.getMonth()+1))+'-'+(s.getDate()<10?'0'+s.getDate():s.getDate());$('#LiDianRiQi').val(s);}}});" })%>
                        <a href="javascript:;" onclick="instance.triggerEvent($('#RuZhuRiQi')[0]);">
                            <img src="/images/rili.gif"></a></span> 离店日期：<span class="date_style formsize140"><%=Html.TextBoxFor(x => x.LiDianRiQi, new { onclick = "var data=$('#RuZhuRiQi').val().split('-');if(data[0]==''){return;};var s = new Date(new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime()+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1)+'-'+s.getDate();WdatePicker({readOnly:true,isShowClear:false,minDate:s})" })%>
                                <a href="javascript:;" onclick="instance.triggerEvent($('#LiDianRiQi')[0]);">
                                    <img src="/images/rili.gif"></a></span> <a href="javascript:;" onclick="instance.xiuGai(this);">
                                        <img src="/images/update.gif" /></a></div>
            </div>
            <div class="tablestyle">
                <table id="roomTypeTable" width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody>
                        <%=Url.RenderPartial("~/HotelXiangQingRoom.aspx")%>
                    </tbody>
                </table>
            </div>
        </div>
        <uc1:ZhuCe ID="ZhuCe1" runat="server" />
        <div class="B_hotel xiangguan" id="xiangguanxinxi">
            <div class="basicT">
                <h3>
                    <a href="#" name="t4">相关信息</a></h3>
            </div>
            <ul>
                <li><span>周边设施</span>
                    <table>
                        <% if (Model.SheShi != null && Model.SheShi.Count > 0)
                           {
                               foreach (var item in Model.SheShi.GroupBy(x => x.AMENITY_TYPE))
                               {
                                   string type = item.Key;
                                   if (!string.IsNullOrEmpty(type))
                                   {
                                       Response.Write("<tr><td width='99px' align='left' valign='top' style='padding:0;color:brown;font-weight:bold;'>" + FillWhiteSpace(99, 12, ((DescriptionAttribute)typeof(Hotel_HotelAmenity.AmenityType).GetField(item.Key).GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description) + "：</td><td>");
                                       int i = 0;
                                       foreach (var g in item)
                                       {
                                           if (i > 0)
                                           {
                                               Response.Write(",");
                                           }
                                           Response.Write(g.AMENITY_NAME);
                                           i++;
                                       }
                                       Response.Write("</td></tr>");
                                   }
                               }
                           }%>
                    </table>
                </li>
                <li><span>交通信息</span><p>
                    <% if (Model.Traffic != null && Model.Traffic.Count > 0)
                       {
                           foreach (var item in Model.Traffic)
                           { %>
                    <%=item.TRAFFIC_NAME %>&nbsp;&nbsp;&nbsp;距离：<%=item.DISTANCE %>公里，车程信息：<%=string.IsNullOrEmpty(item.CAR_INTERVAL) ? "未知" : item.CAR_INTERVAL%>，步行信息：<%=string.IsNullOrEmpty(item.FOOT_INTERVAL) ? "未知" : item.FOOT_INTERVAL%>;<br />
                    <%}
                       }
                       else
                       { %>
                    <%=Model.Transport %>
                    <% } %></p>
                </li>
            </ul>
        </div>
    </div>
    <%=Html.HiddenFor(x=>x.SearchInfo.PageInfo.PageIndex) %>
    <%=Html.Hidden("Direction") %>
    <%  %>
    </form>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Foot">

    <script type="text/javascript">

        var instance = new PageSubmitForm();

        instance.switchTab = function(li) {
            $(li).addClass('tab_on');
            $(li).siblings().removeClass('tab_on');
        };
        instance.xiuGai = function(btn) {
            instance.SetButtonUnableClick(btn, '查询中..');
            $.get('/HotelXiangQingRoom.aspx?t=' + Math.random(), $('form').serialize(), function(txt) {
                $('#roomTypeTable tr').remove();
                $('#roomTypeTable tbody').html(txt);
                instance.SetButtonEnableClick(btn);
            });
        };
        instance.yuDing = function(roomTypeId, checkInDate, checkOutDate, roomRateIds) {
            if (!roomTypeId || !checkInDate || !checkOutDate || !roomRateIds) {
                alert('数据有误，请联系管理员');
                return;
            }

            var roomRateIds2 = [];
            $('a.yudin_btn').each(function() {
                var rids = $(this).attr('roomrateid');
                if (rids != roomRateIds) {
                    roomRateIds2.push(rids);
                }
            });
            location = '/HotelXiangQing2.aspx?RoomTypeId=' + roomTypeId + '&RoomRateIds=' + roomRateIds + '&hotelid=<%=Model.HotelId %>&ruzhuriqi=' + checkInDate + '&lidianriqi=' + checkOutDate;
        };
        instance.imgUp = function() {
            $('#Direction').val('up');
            $.get('/HotelXiangQingImg.aspx', $('form').serialize(), function(txt) {
                $('.b_imglist').html(txt);
            });
        };
        instance.imgDown = function() {
            $('#Direction').val('down');
            $.get('/HotelXiangQingImg.aspx', $('form').serialize(), function(txt) {
                $('.b_imglist').html(txt);
            });
        };
        onload = function() {
            var mapurl = "/YouHuiMenPiaoMap.aspx?ScenicName=<%=Server.UrlEncode(Model.HotelName) %>&CityName=<%=Server.UrlEncode(Model.CityName) %>&x=<%=Model.Longitude %>&y=<%=Model.Latitude %>&address=<%=Server.UrlEncode(Model.Address) %>&mobile=<%=Server.UrlEncode(Model.Mobile) %>&tre=" + Math.random(); ;
            if ($.browser.msie) {
                mapurl += '&h=215&w=635';
            }
            else if ($.browser.mozilla) {
                mapurl += '&h=215&w=635';
            }
            document.getElementById('map1').src = mapurl;
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
