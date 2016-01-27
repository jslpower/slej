<%@ Page Title="酒店" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="Hotel.aspx.cs" Inherits="EyouSoft.Web.Hotel" %>

<%@ Register Src="UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TravelTools.ascx" TagName="TravelTools" TagPrefix="uc1" %>
<%@ Register Src="UserControl/XianLu.ascx" TagName="XianLu" TagPrefix="uc1" %>
<%@ Import Namespace="EyouSoft.BLL.HotelStructure" %>
<asp:Content ContentPlaceHolderID="head" runat="server">

    <script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $('#newsSlider').loopedSlider({
                autoStart: 3000
            });
            $('.validate_Slider').loopedSlider({
                autoStart: 3000
            });
            ticketLKE.initAutoComplete();

            $("#CityName").click(function() {
                ticketLKE.__showDiv({ txtCode: "CityCode", txtName: "CityName", top: 2 });
            });

        });
    </script>

    <!--left_focus-->

    <script src="/js/left_focus.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/bt.min.js"></script>

    <style type="text/css">
        .starclass
        {
            font-size: 11px;
            color: brown;
        }
    </style>
    <!--left_focus-->
</asp:Content>
<asp:Content ContentPlaceHolderID="Left" runat="server">
    <uc1:Search runat="server" ID="search1" />
    <div class="L_side01 margin_T10">
        <uc1:TuanGou runat="server" ID="TuanGou1" />
    </div>
    <uc1:XianLu runat="server" ID="XianLu1" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Right" runat="server">
    <div class="banner n_banner" id="newsSlider">
        <div class="piclist">
            <ul class="slides">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li><a href="<%#Eval("AdvLink")%>" target="_blank">
                            <img src="<%#Eval("ImgPath")%>" /></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="validate_Slider">
            </div>
            <ul class="pagination">
                <li><a href="javascript:;">1</a></li>
                <li><a href="javascript:;">2</a></li>
                <li><a href="javascript:;">3</a></li>
                <li><a href="javascript:;">4</a></li>
                <li><a href="javascript:;">5</a></li>
            </ul>
        </div>
    </div>
    <!------jinqu_search-------->
    <div class="jinqu_search margin_T10">
        <div class="jinqu_searchbox">
            <div class="hotel-search">
                <form method="get">
                输入城市：<input name="CityName" id="CityName" class="formsize140 input_bluebk" /><input
                    name="CityCode" id="CityCode" type="hidden" />&nbsp;&nbsp;
                酒店位置：<input id="LandMark" name="LandMark" type="text" class="formsize140 input_bluebk" /><input id="LandMarkID" name="LandMarkID" type="hidden" />&nbsp;&nbsp;
                酒店名称：<input name="HotelName" id="HotelName" class="formsize140 input_bluebk" />
                酒店星级：<select name="Star" id="Star">
                    <option value="">请选择</option>
                    <option value="2">二星级</option>
                    <option value="3">三星级</option>
                    <option value="4">四星级</option>
                    <option value="5">五星级</option>
                    <option value="7">参考二星级</option>
                    <option value="8">参考三星级</option>
                    <option value="9">参考四星级</option>
                    <option value="10">参考五星级</option>
                    <option value="11">其他</option>
                </select>&nbsp;&nbsp;
                <br />
                入住日期：<input name="RuZhuRiQi" id="RuZhuRiQi" value="<%=DateTime.Now.Date.AddDays(7).ToString("yyyy-MM-dd") %>"
                    class="formsize100 input_bluebk" onclick="var nowdate=new Date();nowdate=nowdate.getFullYear()+'-'+(nowdate.getMonth()+1)+'-'+nowdate.getDate();WdatePicker({readOnly:true,minDate:nowdate,isShowClear:false,onpicked:function(){ var data0=$('#LiDianRiQi').val().split('-');var s0=new Date(parseInt(data0[0]),parseInt(data0[1],10)-1,parseInt(data0[2],10)); var data=$('#RuZhuRiQi').val().split('-');var s=new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime();if(s0<=s){s=new Date(s+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1<10?'0'+(s.getMonth()+1):(s.getMonth()+1))+'-'+(s.getDate()<10?'0'+s.getDate():s.getDate());$('#LiDianRiQi').val(s);}}});" />
                &nbsp;&nbsp;离店日期：<input name="LiDianRiQi" id="LiDianRiQi" value="<%=DateTime.Now.Date.AddDays(8).Date.ToString("yyyy-MM-dd") %>"
                    class="formsize100 input_bluebk" onclick="var data=$('#RuZhuRiQi').val().split('-');if(data[0]==''){return;}var s = new Date(new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime()+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1)+'-'+s.getDate();WdatePicker({readOnly:true,isShowClear:false,minDate:s})" />
                &nbsp;&nbsp;价格范围：<input name="JiaGe1" id="JiaGe1" class="formsize60 input_bluebk" onblur="instance.calculate(this);" />-<input
                    name="JiaGe2" id="JiaGe2" class="formsize60 input_bluebk" onblur="instance.calculate(this);" />
                
                <input type="button" value="搜索 >>" class="line-s-btn" onclick="instance.Search();" />
                <input type="button" value="地图搜索" class="line-s-btn" onclick="instance.tiaozhuan();" />
                </form>
            </div>
        </div>
    </div>
    <div class="jinqu_box margin_T10">
        <div class="B_Titel">
            热门酒店推荐</div>
        <div class="hotellist">
            <ul>
                <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <div class="hotel_detail">
                                <div class="hotelpic">
                                    <a href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>&RuZhuRiQi=<%=Model.RuZhuRiQi.HasValue?Model.RuZhuRiQi.Value.ToString("yyyy-MM-dd"):"" %>&lidianriqi=<%=Model.LiDianRiQi.HasValue?Model.LiDianRiQi.Value.ToString("yyyy-MM-dd"):"" %>">
                                        <img src="<%# Eval("FirstImageAddress")%>" /></a></div>
                                <dl>
                                    <dt><a style="vertical-align: middle;" href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>&RuZhuRiQi=<%=Model.RuZhuRiQi.HasValue?Model.RuZhuRiQi.Value.ToString("yyyy-MM-dd"):"" %>&lidianriqi=<%=Model.LiDianRiQi.HasValue?Model.LiDianRiQi.Value.ToString("yyyy-MM-dd"):"" %>">
                                        <%#Eval("HotelName") %></a><%# EyouSoft.Web.Hotel.GetHotelStarString(Eval("Star"))%>
                                    </dt>
                                    <dd class="content" style="word-break: break-all;">
                                        <span>
                                            <%#  Eval("LongDesc")==null?"":(Eval("LongDesc").ToString().Length>155?(Eval("LongDesc").ToString().Substring(0,154)+"...") :Eval("LongDesc").ToString()) %></span><a
                                                href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>&RuZhuRiQi=<%=Model.RuZhuRiQi.HasValue?Model.RuZhuRiQi.Value.ToString("yyyy-MM-dd"):"" %>&lidianriqi=<%=Model.LiDianRiQi.HasValue?Model.LiDianRiQi.Value.ToString("yyyy-MM-dd"):"" %>"><b
                                                    class="font_yellow">[查看详情]</b></a>
                                    </dd>
                                    <dd>
                                        区域：<%# GetAddress(Eval("HotelId"))%>
                                    </dd>
                                </dl>
                            </div>
                            <div class="hotel_table">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th rowspan="2" align="center">
                                            房型
                                        </th>
                                        <th rowspan="2" align="center">
                                            床型
                                        </th>
                                        <th width="100" rowspan="2" align="center">
                                            早餐
                                        </th>
                                        <th width="70" rowspan="2" align="center">
                                            宽带
                                        </th>
                                        <th colspan="<%=IsShowHuiYuan()?2:1 %>" align="center">
                                            &nbsp;&nbsp;&nbsp;房价<font class="nojiacu">（含服务费）</font>
                                        </th>
                                        <th width="80" rowspan="2" align="center">
                                            &nbsp;
                                        </th>
                                    </tr>
                                    <tr>
                                        <th width="100" align="center" colspan="<%=IsShowHuiYuan()?1:2 %>" class="nojiacu">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;酒店销售价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|
                                        </th>
                                        <% if (IsShowHuiYuan())
                                           { %>
                                        <th width="90" align="center" class="nojiacu">
                                            优惠价
                                        </th>
                                        <%} %>
                                    </tr>
                                    <asp:Repeater ID="Repeater3" runat="server">
                                        <ItemTemplate>
                                            <tr <%# Container.ItemIndex>2?"style=\"display:none;\"":"" %>>
                                                <td align="left">
                                                    <img src="/images/bed.gif" width="14" height="11" />
                                                    <%#(RoomType)Eval("RoomTypeInfo.RoomType") == RoomType.其它 ? Eval("RoomTypeInfo.RoomName") : Eval("RoomTypeInfo.RoomType")%>
                                                </td>
                                                <td align="center">
                                                    <%# (int)Eval("RoomTypeInfo.BedType") == 0 ? Eval("RoomTypeInfo.BedTypeDescription") : Eval("RoomTypeInfo.BedType")%>
                                                </td>
                                                <td align="center">
                                                    <%# BHotel2.TransBreakFastBetweenInterfaceAndSelfProject(Convert.ToDouble(Eval("Breakfast")))%>
                                                </td>
                                                <td align="center" class="fontgreen">
                                                    <%#Eval("RoomTypeInfo.IsInternet")%>
                                                </td>
                                                <td align="center" class="font16 fontgreen">
                                                    ¥<strike><%#((decimal)Eval("PreferentialPrice") * BHotel2.RetialPricePercent).ToString("0")%></strike>
                                                </td>
                                                <% if (IsShowHuiYuan())
                                                   { %>
                                                <td align="center" class="font16 font_yellow">
                                                    ¥<%# BHotel2.CalculateFee((decimal)Eval("SettlementPrice"), (decimal)Eval("PreferentialPrice"), MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)(Eval("FeeSetting")), FeeTypes.酒店).ToString("0")%>
                                                </td>
                                                <%} %>
                                                <td align="center">
                                                    <a class="yudin_btn" href="/HotelXiangQing.aspx?HotelId=<%#Eval("HotelId")%>&RuZhuRiQi=<%=Model.RuZhuRiQi.HasValue?Model.RuZhuRiQi.Value.ToString("yyyy-MM-dd"):"" %>&lidianriqi=<%=Model.LiDianRiQi.HasValue?Model.LiDianRiQi.Value.ToString("yyyy-MM-dd"):"" %>">
                                                        <span>查看</span></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <div class="caozuo_box" runat="server" id="caozuo_box">
                                <a href="javascript:;"><b class="fontblue" id="b1" onclick="instance.zhanKai(this);"
                                    runat="server"></b>
                                    <img src="/images/blue_jtb.gif" /></a></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                
            </ul>
            <asp:PlaceHolder ID="TiShiXinXi" runat="server" Visible="false">
                <span style="color:red; font-size:17px; margin-left:280px; padding-top:40px; font-weight:bolder">没房？房型不适合？调整日期试试看！</span>
            </asp:PlaceHolder>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="page" id="page">
    </div>
    <input id="isPageNum" type="hidden" value="1" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">

    <script type="text/javascript">
        var pagingConfig = { pageSize: <%=Model.SearchInfo.PageInfo.PageSize %>, pageIndex: <%=Model.SearchInfo.PageInfo.PageIndex %>, recordCount: <%=Model.SearchInfo.PageInfo.TotalCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) 
            AjaxPageControls.replace("page", pagingConfig);
        });
    </script>

    <script type="text/javascript">
        var instance = new InitialPageInputTagValue();
        instance.Init();
        instance.tiaozhuan = function() {
        location.href = "/HotelMap.aspx?keyword=&CityName=" + $("#CityName").val() + "&CityCode=" + $("#CityCode").val() + "&LandMark=" + $("#LandMark").val() + "&LandMarkID=" + $("#LandMarkID").val() + "&HotelName=" + $("#HotelName").val() + "&Star=" + $("#Star").val() + "&RuZhuRiQi=" + $("#RuZhuRiQi").val() + "&LiDianRiQi=" + $("#LiDianRiQi").val() + "&JiaGe1=" + $("#JiaGe1").val() + "&JiaGe2=" + $("#JiaGe2").val();
        }
        instance.zhanKai = function(o) {
            if (o.innerHTML.indexOf('展开全部房型') > -1) {
                $(o).parents('li:first').find('.hotel_table tr:gt(4)').show();
                o.innerHTML = o.innerHTML = '收起';
                $(o).next().attr('src', '/images/blue_jtt.gif');
            }
            else {
                $(o).parents('li:first').find('.hotel_table tr:gt(4)').hide();
                o.innerHTML = '展开全部房型（' + (parseInt($(o).attr('totalNumber')) - 3) + '）';
                $(o).next().attr('src', '/images/blue_jtb.gif');

            }
        };
        instance.calculate = function(o) {
            if (isNaN($('#' + o.id).val())) {
                if (o.id == 'JiaGe1') {
                    if (IsNaN($('#JiaGe2').val())) {
                        $('#JiaGe2').val(100);
                    }
                    o.value = parseInt($('#JiaGe2').val()) - 50;
                    if (o.value <= 0) {
                        o.value = 1;
                    }
                }
                else {
                    if (IsNaN($('#JiaGe1').val())) {
                        $('#JiaGe1').val(100);
                    }
                    o.value = parseInt($('#JiaGe1').val()) + 50;
                    if (o.value <= 0) {
                        o.value = 1;
                    }
                }
            }
        };
    </script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Link" runat="server">
    
    
    <div id="removeDiv" class="dibiao_box" style="position: absolute; left: 774px;
        top: 499px; z-index: 999999; display: none;">
   <div class="dibiao_title fixed">
      <div class="dibiao_h3">附近搜索</div>
      <a href="javascript:void(0)" class="dibiao_close">x</a>
   </div>
   
   <div class="dibiao_list">
      <ul class="fixed" id="AreaNameList">
         
      </ul>
   </div>
   
   <div class="dibiao_listTab">
      
   </div>
   
   <div class="dibiao_name">
      
   </div>
</div>
    <script type="text/javascript">
        $(function() {
        $("#LandMark").focus(function() {
        $("#isPageNum").val("1");
                if ($('#CityName').val() == "") {
                    tableToolbar._showMsg("请先选择入住城市！"); $('#CityName').click();
                }
                else {
                    var CityCode = $("#CityCode").val();
                    $.ajax({
                        type: "post", url: "/ashx/CityHandler.ashx?dotype=SanZiMa&CityCode=" + encodeURI(CityCode), dataType: "json",
                        success: function(response) {
                            $("#AreaNameList").html("");
                            for (var i = 0; i < response.length; i++) {
                                if (i == 0) {
                                    $("#AreaNameList").append("<li><a href=\"javascript:void(0)\" data-arcode=\"" + response[i].AreaCode + "\" data-class=\"onedibiao\" class=\"on\">" + response[i].AreaName + "</a></li>");
                                    iPage.GetLandMarkName(response[i].AreaCode);
                                }
                                else {
                                    $("#AreaNameList").append("<li><a href=\"javascript:void(0)\" data-arcode=\"" + response[i].AreaCode + "\" data-class=\"onedibiao\">" + response[i].AreaName + "</a></li>");
                                }
                            }
                        }
                    });
                    $("#removeDiv").css('display', '');
                }
            });
            $("#LandMark").blur(function() {
            if ($("#isPageNum").val() != "1") {
                    $("#removeDiv").hide();
                }
            });
            $(".dibiao_close").click(function() {
                $("#removeDiv").hide();
            });
            $('a[data-class="onedibiao"]').live("click", function() {
                var AreaCode = $(this).attr("data-arcode");
                $("#AreaNameList li a").removeClass("on");
                $(this).addClass("on");
                iPage.GetLandMarkName(AreaCode);
            });
            $('a[data-class="twodibiao"]').live("click", function() {
                var AreaCode = $(this).attr("data-acode");
                var LandMarkName = $(this).attr("data-mark");
                $(".dibiao_listTab a").removeClass("on");
                $(this).addClass("on");
                iPage.GetLandChildName(AreaCode, LandMarkName);
            });
            $('a[data-class="threemark"]').live("click", function() {
                $("#LandMark").val($(this).attr("title"));
                $("#LandMarkID").val($(this).attr("data-id"));
                $("#isPageNum").val("2");
                $("#removeDiv").hide();
            });

        });
        var iPage = {
            GetLandMarkName: function(AreaCode) {
                var CityCode = $("#CityCode").val();
                $.ajax({
                    type: "post", url: "/ashx/CityHandler.ashx?dotype=LandMarkName&CityCode=" + encodeURI(CityCode) + "&AreaCode=" + encodeURI(AreaCode), dataType: "json",
                    success: function(response) {
                    $(".dibiao_listTab").html("");
                        var LandName = response[0].LandMarkName;
                        for (var i = 0; i < response.length; i++) {
                            if (response[0].LandMarkName == "NONE") {
                                iPage.GetLandChildName(AreaCode, "");
                            }
                            else {
                                if (i == 0) {
                                    if (response[0].LandMarkName == "无相关地标") {
                                        $(".dibiao_listTab").append("<a href=\"javascript:\" class=\"on\">" + response[i].LandMarkName + "</a>");
                                        $(".dibiao_name").html("");
                                    }
                                    else {
                                        $(".dibiao_listTab").append("<a href=\"javascript:\" data-acode=\"" + AreaCode + "\" data-class=\"twodibiao\" data-mark=\"" + response[i].LandMarkName + "\" class=\"on\">" + response[i].LandMarkName + "</a>"); iPage.GetLandChildName(AreaCode, response[i].LandMarkName);
                                    }
                                }
                                else {
                                    if (response[0].LandMarkName == "无相关地标") {
                                        $(".dibiao_listTab").append("<a href=\"javascript:\">" + response[i].LandMarkName + "</a>");
                                        $(".dibiao_name").html("");
                                    }
                                    else {
                                        $(".dibiao_listTab").append("<a href=\"javascript:\" data-acode=\"" + AreaCode + "\" data-class=\"twodibiao\" data-mark=\"" + response[i].LandMarkName + "\">" + response[i].LandMarkName + "</a>");
                                    }
                                }
                            }
                        }
                    }
                });
            },
            GetLandChildName: function(AreaCode, LandMarkName) {
                var CityCode = $("#CityCode").val();
                $.ajax({
                    type: "post", url: "/ashx/CityHandler.ashx?dotype=LandChildName&CityCode=" + encodeURI(CityCode) + "&AreaCode=" + encodeURI(AreaCode) + "&LandMarkName=" + encodeURI(LandMarkName), dataType: "json",
                    success: function(response) {
                    $(".dibiao_name").html("");
                        var LandName = response[0].LandMarkName;
                        for (var i = 0; i < response.length; i++) {
                            var LandMarkChildName = response[i].LandMarkChildName;
                            if (LandMarkChildName.length > 5) {
                               LandMarkChildName = LandMarkChildName.substring(0, 4) + "..";
                            }
                            $(".dibiao_name").append("<a href=\"javascript:\" title=\"" + response[i].LandMarkChildName + "\" data-id=\"" + response[i].ID + "\" data-class=\"threemark\">" + LandMarkChildName + "</a>");
                        }
                    }
                });
            }
        }
    </script>

</asp:Content>
