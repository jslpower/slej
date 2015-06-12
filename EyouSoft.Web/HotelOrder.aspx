<%@ Page Title="酒店房型预订" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="HotelOrder.aspx.cs" Inherits="EyouSoft.Web.HotelOrder" %>

<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="EyouSoft.BLL.HotelStructure" %>
<%@ Import Namespace="EyouSoft.Web" %>
<%@ Import Namespace="EyouSoft.Model.HotelStructure.WebModel" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tixing { line-height: 30px; }
        .style1 { height: 372px; }
        .style2 { height: 138px; }
    </style>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox">
    <form id="hotelorderform">
        <div  id="istijiao" class="line_xx_box">
            
            <table width="908" border="0" class="tchuang">
                <tr class="tb_even">
                    <th colspan="2" align="right" style="white-space:nowrap;">酒店名称&nbsp;&nbsp;&nbsp;&nbsp;：</th>
                    <td colspan="3" align="left">
                        <%=Model.Hotel.HotelName %>
                    </td>
                    <th align="right">
                        星级标准&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td colspan="3" align="left">
                        <%=Model.Hotel.Star.HasValue? ((int)(Model.Hotel.Star.Value)>5?Model.Hotel.Star.ToString().Replace("准","参考"): Model.Hotel.Star.Value.ToString()):"" %>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" align="right">
                        入住房型&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th> 
                    <td colspan="7" align="left">
                        <%=Model.RommType.RoomName%><span class="fontblue"></span>
                    </td>
                </tr>
                <tr class="tb_even">
                    <th colspan="2" align="right" class="style2">
                        相关价格&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td colspan="7" align="left" class="style2">
                        <% 
                            List<KeyValuePair<DateTime, decimal>> list = new List<KeyValuePair<DateTime, decimal>>();
                            DateTime t11 = Model.CheckInDate;
                            while (t11 < Model.CheckOutDate)
                            {
                                list.Add(new KeyValuePair<DateTime, decimal>(t11, Model.RoomRates.First(x => x.Time.Contains(t11)).DanJia));
                                t11 = t11.AddDays(1);
                            }
                            for (int s = 0; s < list.Count; s++)
                            {
                                Response.Write((s > 0 ? "，" : "&nbsp") + list[s].Key.ToString("MM月dd日") + "：" + list[s].Value.ToString("0") + "元");
                            }
                        %>
                        <%=Html.HiddenFor(a=>a.RoomRateIds) %>
                    </td>
                </tr>
                <tr id="jiage">
                    <td colspan="9" align="center">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="price_table">
                            <tr>
                                <th class="Rline">
                                    日期
                                </th>
                                <th>
                                    酒店销售价
                                </th>
                                <%if (IsShowHuiYuan())
                                  { %>
                                <th class="Rline">
                                    会员价
                                </th>
                                <% } %>
                                 <%if (IsShowErJiDaiLi())
                                  { %>
                                <th class="Rline">
                                    代销价
                                </th>
                                <%} %>
                                <%if (IsShowGuiBin())
                                  { %>
                                <th class="Rline">
                                    贵宾价
                                </th>
                                <% } %>
                               
                                <%if (IsShowDaiLi())
                                  { %>
                                <th class="Rline">
                                    代理价
                                </th>
                                <%} %>
                                <%if (IsShowYuanGong())
                                  { %>
                                <th>
                                    员工价
                                </th>
                                <%} %>
                            </tr>
                            <% DateTime t2 = Model.CheckInDate;
                               while (t2 < Model.CheckOutDate)
                               {
                                   var roomRate = Model.RoomRates.FirstOrDefault(y => y.Time.Contains(t2));
                                   if (roomRate == null) continue;
                            %>
                            <tr>
                                <td>
                                    <%=t2.ToString("MM月dd日") %>
                                </td>
                                <td>
                                    <b class="fontblue">¥<strike><%= (roomRate.PreferentialPrice*BHotel2.RetialPricePercent).ToString("0")%></strike></b>
                                </td>
                                <%if (IsShowHuiYuan())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, MemberTypes.普通会员, roomRate.FeeSetting, FeeTypes.酒店).ToString("0")%></b>
                                </td>
                                <%} %>
                                 <%if (IsShowErJiDaiLi())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, MemberTypes.免费代理, roomRate.FeeSetting, FeeTypes.酒店).ToString("0")%></b>
                                </td>
                                <% } %>
                                <%if (IsShowGuiBin())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, MemberTypes.贵宾会员, roomRate.FeeSetting, FeeTypes.酒店).ToString("0")%></b>
                                </td>
                                <% } %>
                                <%if (IsShowDaiLi())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, MemberTypes.代理, roomRate.FeeSetting, FeeTypes.酒店).ToString("0")%></b>
                                </td>
                                <% } %>
                                <%if (IsShowYuanGong())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, MemberTypes.员工, roomRate.FeeSetting, FeeTypes.酒店).ToString("0")%></b>
                                </td>
                                <% } %>
                            </tr>
                            <%  t2 = t2.AddDays(1);
                               } %>
                        </table>
                    </td>
                </tr>
                <tr class="tb_even">
                    <th colspan="2" align="right">
                        入住日期&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td colspan="3" align="left" id="startDate">
                        <%=Html.TextBoxFor(x => x.CheckInDate, new { onclick = "var nowdate=new Date();nowdate=nowdate.getFullYear()+'-'+(nowdate.getMonth()+1)+'-'+nowdate.getDate();WdatePicker({readOnly:true,minDate:nowdate,isShowClear:false,onpicked:function(){ var data0=$('#CheckOutDate').val().split('-');var s0=new Date(parseInt(data0[0]),parseInt(data0[1],10)-1,parseInt(data0[2],10)); var data=$('#CheckInDate').val().split('-');var s=new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime();if(s0<=s){s=new Date(s+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1<10?'0'+(s.getMonth()+1):(s.getMonth()+1))+'-'+(s.getDate()<10?'0'+s.getDate():s.getDate());$('#CheckOutDate').val(s);};instance.xiuGai(); }});" })%>
                    </td>
                    <th align="right" id="endDate">
                        离开日期&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td align="left" width="140px">
                        <%=Html.TextBoxFor(x => x.CheckOutDate, new { onclick = "var data=$('#CheckInDate').val().split('-');if(data[0]==''){return;};var s = new Date(new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime()+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1)+'-'+s.getDate();WdatePicker({readOnly:true,isShowClear:false,minDate:s,onpicked:instance.xiuGai })" })%>
                    <th align="right" id="Th1">
                        到店时间&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td align="left" width="140px">
                        <select name="DaoDianShiJian" id="DaoDianShiJian">
                            <option value="1800">18:00</option>
                            <option value="1900">19:00</option>
                            <option value="2000">20:00</option>
                            <option value="2100">21:00</option>
                            <option value="2200">22:00</option>
                            <option value="2300">23:00</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" align="right">
                        入住晚数&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td colspan="3" align="left">
                        <%=Model.Day %>
                    </td>
                    <th align="right">
                        宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 带&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td align="left">
                        <%=Model.RommType.IsInternet %>
                    </td>
                    <th align="right">
                        早&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 餐&nbsp;&nbsp;&nbsp; ：
                    </th>
                    <td align="left">
                        <% 
                            DateTime t = Model.CheckInDate;
                            while (t < Model.CheckOutDate)
                            {
                                var item = Model.RoomRates.FirstOrDefault(x => x.Time.Contains(t));
                                if (item != null)
                                {
                                    Response.Write((t > Model.CheckInDate ? "<br/>" : "") + t.ToString("MM月dd日") + "：" + item.Breakfast);
                                }
                                t = t.AddDays(1);
                            } %>
                    </td>
                </tr>
                <tr class="tb_even">
                    <th align="right" colspan="2"   style="white-space:nowrap;">
                        间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 数&nbsp;&nbsp;&nbsp;&nbsp; ：
                    </th>
                    <th colspan="8" align="left" class="style1">
                        <select name="RoomCount" id="RoomCount" style="width: 50px;"
                            onchange="instance.calculate();">
                            <option value="1" <%=Model.RoomCount==1?" selected='selected'":""%>>1</option>
                            <option value="2" <%=Model.RoomCount==2?" selected='selected'":""%>>2</option>
                            <option value="3" <%=Model.RoomCount==3?" selected='selected'":""%>>3</option>
                            <option value="4" <%=Model.RoomCount==4?" selected='selected'":""%>>4</option>
                            <option value="5" <%=Model.RoomCount==5?" selected='selected'":""%>>5</option>
                            <option value="6" <%=Model.RoomCount==6?" selected='selected'":""%>>6</option>
                            <option value="7" <%=Model.RoomCount==7?" selected='selected'":""%>>7</option>
                            <option value="8" <%=Model.RoomCount==8?"  selected='selected'":""%>>8</option>
                            <option value="9" <%=Model.RoomCount==9?" selected='selected'":""%>>9</option>
                            <option value="10" <%=Model.RoomCount==10?"  selected='selected'":""%>>10</option>
                        </select>
                    </th>
                </tr>
                <tr class="tb_even">
                    <th colspan="2" align="right">
                        预定人姓名：
                    </th>
                    <td align="left">
                        <%=Model.ContactName %>
                        <%=Html.HiddenFor(x=>x.ContactName) %>
                    </td>
                    <th align="right">
                        预定人身份：
                    </th>
                    <td align="left">
                        <%=CurrentUser.UserType %>
                    </td>
                    <th align="right">
                        预定人手机：
                    </th>
                    <td colspan="3" align="left">
                        <%=Model.ContactMobile %>
                        <%=Html.HiddenFor(x=>x.ContactMobile) %>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" align="right">
                        交易总金额：
                    </th>
                    <td colspan="7" align="left">
                        <%=Html.HiddenFor(x=>x.HotelId) %>
                        <%=Html.HiddenFor(x=>x.RoomTypeId) %>
                        <%=Html.HiddenFor(x=>x.TotalAmount) %>
                        <%=Html.HiddenFor(x => x.Day)%>
                        <%=Html.HiddenFor(x=>x.VenderCode) %>
                        <%
                            string pricesStr = string.Join("|", Model.RoomRates.Select(x => x.DanJia.ToString("0")).ToArray());
                            string settlementPricesStr = string.Join("|", Model.RoomRates.Select(x => x.SettlementPrice.ToString("0")).ToArray());
                        %><font class="fontblue"><b class="font14 totalMoney" id="totalMoney" jsp="<%=settlementPricesStr %>"
                            danjias="<%=pricesStr %>">
                            <% string jisuan = ""; for (int m = 0; m < pricesStr.Split('|').Length; m++)
                               {
                                   jisuan += pricesStr.Split('|')[m] + "元 * " + Model.RoomCount + "间 + ";
                               } jisuan = jisuan.Substring(0, jisuan.Length - 2);
                                 %>
                            <%= jisuan%>
                             = <%=Model.RoomRates.Sum(x=>x.DanJia*Model.RoomCount).ToString("0")%></b>元</font>
                    </td>
                </tr>
                <% if (IsShowShengQingGuiBin() || IsShowShengQingDaiLi() || CurrentUser.UserType == MemberTypes.贵宾会员)
                   { %>
                <tr class="tb_even">
                    <td colspan="9" align="left">
                        <div class="tixing">
                            <% if (IsShowShengQingGuiBin())
                               {
                                   IEnumerable<decimal> prices1 = Model.RoomRates.Select(x => BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.酒店));
                                   string prices1Str = string.Join("|", prices1.Select(x => x.ToString("0")).ToArray());
                                   string totalPrice = prices1.Sum(x => x * Model.RoomCount).ToString("0");
                                   string liSheng = Model.RoomRates.Select(x => Model.RoomCount * (BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, CurrentUser.UserType, Model.FeeSetting, FeeTypes.酒店) - BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.酒店))).Sum().ToString("0");
                            %>
                            <div>
                                <b>申&nbsp;&nbsp;&nbsp;请&nbsp;&nbsp;&nbsp;贵&nbsp;&nbsp;&nbsp;宾&nbsp;&nbsp;&nbsp;身&nbsp;&nbsp;份：</b><font
                                    class="fontblue"><b class="font14 totalMoney" danjias="<%=prices1Str %>">
                                        <%=totalPrice%></b>元，</font><b class="fontblue">立省<span class="lisheng"><%=liSheng%></span>元</b>
                                <a href="javascript:;" <%=HotelXiangQing.ShowLink(MemberTypes.贵宾会员)%> class="btn001">
                                    <span>马上申请</span></a>
                            </div>
                            <%} %>
                            <% if (CurrentUser.UserType == MemberTypes.贵宾会员)
                               {
                                   IEnumerable<decimal> prices1 = Model.RoomRates.Select(x => BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.酒店));
                                   string prices1Str = string.Join("|", prices1.Select(x => x.ToString("0")).ToArray());
                                   string totalPrice = prices1.Sum(x => x * Model.RoomCount).ToString("0");
                                   string liSheng = Model.RoomRates.Select(x => Model.RoomCount * (BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, CurrentUser.UserType, Model.FeeSetting, FeeTypes.酒店) - BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.酒店))).Sum().ToString("0");
                            %>
                            <div>
                                <b>贵&nbsp;&nbsp;&nbsp;宾&nbsp;&nbsp;&nbsp;价&nbsp;&nbsp;&nbsp;总&nbsp;&nbsp;&nbsp;金&nbsp;&nbsp;额：</b><font
                                    class="fontblue"><b class="font14 totalMoney" danjias="<%=prices1Str %>">
                                        <%=totalPrice%></b>元</font>
                            </div>
                            <%} %>
                            <% if (IsShowShengQingDaiLi())
                               {
                                   IEnumerable<decimal> prices3 = Model.RoomRates.Select(x => BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, MemberTypes.代理, Model.FeeSetting, FeeTypes.酒店));
                                   string prices3Str = string.Join("|", prices3.Select(x => x.ToString("0")).ToArray());
                                   string totalPrice3 = prices3.Sum(x => x * Model.RoomCount).ToString("0");
                                   string liSheng = Model.RoomRates.Select(x => Model.RoomCount * (BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, CurrentUser.UserType, Model.FeeSetting, FeeTypes.酒店) - BHotel2.CalculateFee(x.SettlementPrice, x.PreferentialPrice, MemberTypes.代理, Model.FeeSetting, FeeTypes.酒店))).Sum().ToString("0");
                            %>
                            <div>
                                <b>申&nbsp;&nbsp; 请&nbsp; 代&nbsp;&nbsp; 理&nbsp;&nbsp; 身&nbsp;&nbsp; 份：</b><font class="fontblue"><b
                                    class="font14 totalMoney" danjias="<%=prices3Str %>">
                                    <%=totalPrice3%></b>元，</font><b class="fontblue">立省<span class="lisheng"><%=liSheng%></span>元</b>
                                <a href="javascript:;" <%=HotelXiangQing.ShowLink(MemberTypes.代理)%> class="btn001"><span>
                                    马上申请</span></a>
                            </div>
                            <%} %>
                        </div>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <th width="87px" align="center">
                        序号
                    </th>
                    <th align="center" colspan="5">
                        入住人姓名
                    </th>
                    <th align="center">
                        身份证
                    </th>
                    <th colspan="3" align="center">
                        入住人手机
                    </th>
                </tr>
                <tr class="tb_even rzr">
                    <td align="center">
                        1
                    </td>
                    <th align="center" colspan="5">
                        <%=Html.TextBoxFor(x => x.OrderCotact[0].ContactName , new { size=15 ,@class="tc_inputbk formsize140", valid="required", errmsg="入住人姓名必须填写" })%>&nbsp;&nbsp;&nbsp;&nbsp;
                    </th>
                    <th align="center">
                        <%=Html.TextBoxFor(x => x.OrderCotact[0].CardNum , new { size=20 ,@class="tc_inputbk formsize140" })%>
                    </th>
                    <th colspan="3" align="center">
                        <%=Html.TextBoxFor(x => x.OrderCotact[0].Mobile, new { size = 15, @class = "tc_inputbk formsize140", valid="required", errmsg="入住人手机号必须填写" })%>
                    </th>
                </tr>
                <tr class="tb_even">
                    <th colspan="2" align="center">
                        备注：
                    </th>
                    <td colspan="8" align="left">
                        <%=Html.TextAreaFor(x=>x.Remark,new { style="width:700px;height:100px;" }) %>
                    </td>
                </tr>
            </table>
            <table width="90%" border="0" style="margin: 15px auto;">
                <tr>
                    <td align="center" class="tjbtn02">
                        <a href="javascript:;" onclick="instance.tiJiao(this)" data-id="1" id="btnSave">提交</a><a href="javascript:;"
                            onclick="instance.QuXiao()" id="QuXiao" style="display:none;">返回编辑</a><a href="javascript:;"
                            onclick="self.history.back();" id="Fanhui">取消</a>
                    </td>
                </tr>
            </table>
            
        </div>
        </form>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">

    <script type="text/javascript">
        var instance = new PageSubmitForm();
        var inputdata = null;
        var fanhuibianji = null;
        var beizhuxinxi = null;
        instance.QuXiao = function() { $("#hotelorderform").html(fanhuibianji); $("#Remark").val(beizhuxinxi); $("#btnSave").html("提交"); };
        instance.tiJiao = function(btn) {
            if (!instance.Validate($('#hotelorderform'))) {
                return;
            }
            if ($('#btnSave').attr("data-id") == 1) {
                inputdata = $("#btnSave").closest("form").serialize();
                fanhuibianji = $("#istijiao").clone(true);
                beizhuxinxi = $("#Remark").val();
                $("#btnSave").html("确认提交");
                var elements = $("#btnSave").closest("form").find('input[type=text]');
                instance.RemoveControl(elements);
                //textarea控件
                elements = $("#btnSave").closest("form").find('textarea');
                instance.RemoveControl(elements);
                //select 控件
                elements = $("#btnSave").closest("form").find('select');
                instance.RemoveControl(elements);

                $('.tixing').remove();
                $('.jiage').remove();
                $('span[class=dindan_num]').removeAttr("class");
                $("#QuXiao").css('display', '');
                $("#Fanhui").css('display', 'none');
                $('#btnSave').attr("data-id", 2);
            }
            else {
                $("#btnSave").html("正在提交");
                $("#btnSave").unbind("click");
                instance.SetButtonUnableClick(btn, { background: 'url(../images/tc_btn.gif) no-repeat left 50%', color: '#fff' });
                $.get('/HotelOrder.aspx', inputdata + '&submit=1', function(ret) {
                    ret = ret.split(':');
                    tableToolbar._showMsg(ret[1], function() {
                        instance.SetButtonEnableClick(btn);
                        if (ret[0] == '1') {
                            location = '/Member/HotelOrderList.aspx';
                        }
                    });
                });
            }
        };
        instance.RemoveControl = function(elements) {
            var arrObj = new Array();
            var count = elements.length;
            for (var i = 0; i < count; i++) {
                if (elements[i] == undefined)
                    continue;

                var obj = document.createElement('span');
                switch (elements[i].type) {
                    case "text":
                        obj.style.width = elements[i].style.width;
                        obj.className = "word_warpbreak";
                        obj.innerHTML = elements[i].value;
                        break;
                    case "textarea":
                        obj.style.width = elements[i].style.width;
                        obj.className = "word_warpbreak";
                        obj.innerHTML = elements[i].value;
                        break;
                    default:
                        for (var j = 0; j < elements[i].length; j++) {
                            if (elements[i][j].selected) {
                                obj.style.width = elements[i].style.width;
                                obj.className = "word_warpbreak";
                                obj.innerHTML = elements[i][j].text;
                                break;
                            }
                        }
                        elements[i].options.length = 0;
                        break;
                }
                elements[i].parentNode.appendChild(obj);
                //删除表单控件
                $("#" + elements[i].id + "").remove();
            }
        };
        instance.calculate = function() {
            var roomCount = parseInt($('#RoomCount').val());

            //更新价格
            var danjias = $('#totalMoney').attr('danjias').split('|');
            var totalAmount = 0;
            $(danjias).each(function() {
                totalAmount += (parseInt(this) || 0) * roomCount;
            });
            $('#TotalAmount').val(totalAmount);
            $('.totalMoney').each(function() {
                var danjias2 = $(this).attr('danjias').split('|');
                var lisheng = 0;
                var totalMoney = 0;
                var jisuanzhi = "";
                for (var k = 0; k < danjias2.length; k++) {
                    lisheng += (danjias[k] - danjias2[k]) * roomCount;
                    totalMoney += danjias2[k] * roomCount;
                    jisuanzhi += danjias2[k] + "元 * " + roomCount + "间 + ";
                }
                jisuanzhi = jisuanzhi.substring(0, jisuanzhi.length - 2);
                $(this).html(jisuanzhi+" = " + totalMoney);
                $(this).parents('div:first').find('.lisheng').html(lisheng.toFixed(0));
            });

            //联系人
            var rzr_length = $('tr.rzr').length;
            if (roomCount > rzr_length) {
                for (var i = rzr_length - 1; i < roomCount - 1; i++) {
                    var rzr = $('tr.rzr:last').clone();
                    rzr.find(':text').each(function() { this.name = this.name.replace(/\[\d+\]/g, '[' + (i + 1) + ']'); this.id = this.id.replace(/\[\d+\]/, '[' + (i + 1) + ']'); });
                    $('tr.rzr:last').after(rzr);
                    rzr.find('td:eq(0)').html(i + 2);
                    rzr.find(':text').val('');
                }
            }
            else {
                while (rzr_length > roomCount) {
                    $('tr.rzr:last').remove();
                    rzr_length--;
                }
            }
        };

        instance.shenqing = function(userType, userTypeName) {
            if (userType == '<%=(int)MemberTypes.贵宾会员 %>') {
                location = '/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767';
            }
            if (userType == '<%=(int)MemberTypes.代理 %>') {
                location = '/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652';
            }
        };

        instance.xiuGai = function() {
            var queryData = {
                CheckInDate: $('#CheckInDate').val(),
                checkoutdate: $('#CheckOutDate').val(),
                RoomRateIds: $('#RoomRateIds').val(),
                RoomTypeId: $('#RoomTypeId').val(),
                roomcount: $('#RoomCount').val()
            };
            location = '/hotelorder.aspx?' + $.param(queryData);
        };
    </script>

</asp:Content>
