<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="HotelMap.aspx.cs" Inherits="EyouSoft.Web.HotelMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/Css/icore.css" rel="stylesheet" type="text/css" />
<link href="../Css/jquery.autocomplete.jipiao.css" rel="stylesheet" type="text/css" />
<script src="/JS/jquery.tipsy.js" type="text/javascript"></script>

<script src="/JS/jipiao.sanzima.js" type="text/javascript"></script>

<script src="/JS/jipiao.core.js" type="text/javascript"></script>

<script src="/JS/jquery.autocomplete.jipiao.js" type="text/javascript"></script>

<script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            ticketLKE.initAutoComplete();

            $("#CityName").click(function() {
                ticketLKE.__showDiv({ txtCode: "CityCode", txtName: "CityName", top: 2 });
            });

        });
    </script>

    <!--left_focus-->

    <script type="text/javascript" src="/js/bt.min.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=<%= BaiduMapKey %>"></script>
<script type="text/javascript">
    var instance = new InitialPageInputTagValue();
    instance.Init();
    instance.tiaozhuan = function() {
        location.href = "/Hotel.aspx";
    }
    instance.animate = function() {
        $('#newsSlider').loopedSlider({
            autoStart: 3000
        });
        $('.validate_Slider').loopedSlider({
            autoStart: 3000
        });
    };
    onload = instance.animate;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="jinqu_search margin_T10">
        <div class="jinqu_searchbox">
            <div class="hotel-search">
                <form method="get">
                输入城市：<input name="CityName" id="CityName" class="formsize120 input_bluebk" /><input
                    name="CityCode" id="CityCode" type="hidden" />&nbsp;&nbsp;
                酒店位置：<input id="LandMark" name="LandMark" type="text" class="formsize140 input_bluebk" /><input id="LandMarkID" name="LandMarkID" type="hidden" />
                 &nbsp;&nbsp;酒店名称：<input name="HotelName" id="HotelName" class="formsize140 input_bluebk" />
                 &nbsp;&nbsp;酒店星级：<select name="Star" id="Star">
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
                </select><br />
                入住日期：<input name="RuZhuRiQi" id="RuZhuRiQi" value="<%=DateTime.Now.Date.AddDays(7).Date.ToString("yyyy-MM-dd") %>"
                    class="formsize100 input_bluebk" onclick="var nowdate=new Date();nowdate=nowdate.getFullYear()+'-'+(nowdate.getMonth()+1)+'-'+nowdate.getDate();WdatePicker({readOnly:true,minDate:nowdate,isShowClear:false,onpicked:function(){ var data0=$('#LiDianRiQi').val().split('-');var s0=new Date(parseInt(data0[0]),parseInt(data0[1],10)-1,parseInt(data0[2],10)); var data=$('#RuZhuRiQi').val().split('-');var s=new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime();if(s0<=s){s=new Date(s+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1<10?'0'+(s.getMonth()+1):(s.getMonth()+1))+'-'+(s.getDate()<10?'0'+s.getDate():s.getDate());$('#LiDianRiQi').val(s);}}});" />
                &nbsp;&nbsp;离店日期：<input name="LiDianRiQi" id="LiDianRiQi" value="<%=DateTime.Now.Date.AddDays(8).Date.ToString("yyyy-MM-dd") %>"
                    class="formsize100 input_bluebk" onclick="var data=$('#RuZhuRiQi').val().split('-');if(data[0]==''){return;}var s = new Date(new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime()+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1)+'-'+s.getDate();WdatePicker({readOnly:true,isShowClear:false,minDate:s})" />
                &nbsp;&nbsp;价格范围：<input name="JiaGe1" id="JiaGe1" class="formsize60 input_bluebk" onblur="instance.calculate(this);" />-<input
                    name="JiaGe2" id="JiaGe2" class="formsize60 input_bluebk" onblur="instance.calculate(this);" />
               
                
                <input type="button" value="搜索 >>" class="line-s-btn" onclick="instance.Search();" /><input type="button" value="列表搜索" class="line-s-btn" onclick="instance.tiaozhuan();" /></form>
                
            </div>
        </div>
    </div>
    <div id="i_div_jipiaochengshi">
</div>
<div id="i_div_jipiao_weipipei" class="jipiao_weipiwei">
    没有数据</div>
    <input id="isPageNum" type="hidden" value="1" />
    
    <div class="map_box margin_T10" id="baomap"></div>
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<div id="removeDiv" class="dibiao_box" style="position: absolute; left: 638px;
        top: 234px; z-index: 999999; display: none;">
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
                                    $("#AreaNameList").append("<li><a href=\"javascript:void(0)\" data-arcode=\"" + response[i].AreaCode + "\" data-class=\"onedibiao\">" + response[i].AreaName + "</li>");
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
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
<script type="text/javascript">
    //  标注点数组
    var BASEDATA = [<%= database%> ]
         
    //创建和初始化地图函数：
    function initMap(){
        window.map = new BMap.Map("baomap");
        map.centerAndZoom(new BMap.Point(120.1639,30.288648),14);
        map.enableScrollWheelZoom();
     map.addControl(new BMap.NavigationControl());
        window.searchClass = new SearchClass();
        searchClass.setData(BASEDATA)
        var dd = searchClass.search({k:"content",d:"电话",t:"",s:""});//t:{single|more},s{all|!all}
        addMarker(dd);//向地图中添加marker
    }
    window.search = function(name_t,name_s,id_d){
        var t_o = document.getElementsByName(name_t);
        var s_o = document.getElementsByName(name_s);
        var s_v,t_v,d_v = document.getElementById(id_d).value;
        for(var i = 0; i < t_o.length; i++){
            if(t_o[i].checked){
                t_v = t_o[i].value;
            }
        }
        for(var i = 0; i < s_o.length; i++){
            if(s_o[i].checked){
                s_v = s_o[i].value;
            }
        }
        searchClass.trim(t_v) == "" && (t_v = "single");
        var dd = searchClass.search({k:"title",d:d_v,t:t_v,s:s_v});
        addMarker(dd);//向地图中添加marker
    }
    
    //创建marker
    window.addMarker = function (data){
        map.clearOverlays();
        for(var i=0;i<data.length;i++){
            var json = data[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0,p1);
            var iconImg = createIcon(json.icon);
            var marker = new BMap.Marker(point,{icon:iconImg});
            var iw = createInfoWindow(i);
            var label = new BMap.Label(json.title,{"offset":new BMap.Size(json.icon.lb-json.icon.x+10,-20)});
            marker.setLabel(label);
            map.addOverlay(marker);
            label.setStyle({
                        borderColor:"#808080",
                        color:"#333",
                        cursor:"pointer"
            });

            (function(){
    var _json = json;
    var _iw = createInfoWindow(_json);
    var _marker = marker;
    _marker.addEventListener("click",function(){
        this.openInfoWindow(_iw);
       });
       _iw.addEventListener("open",function(){
        _marker.getLabel().hide();
       })
       _iw.addEventListener("close",function(){
        _marker.getLabel().show();
       })
    label.addEventListener("click",function(){
        _marker.openInfoWindow(_iw);
       })
    if(!!json.isOpen){
     label.hide();
     _marker.openInfoWindow(_iw);
    }
   })()
        }
    }
    //创建InfoWindow
    function createInfoWindow(json){
        var iw = new BMap.InfoWindow("<b class='iw_poi_title' title='" + json.title + "'>" + json.title + "</b><div class='iw_poi_content'>"+json.content+"</div>");
        return iw;
    }
    //创建一个Icon
    function createIcon(json){
    var icon = new BMap.Icon("/Images/12.png", new BMap.Size(json.w,json.h),{imageOffset: new BMap.Size(-json.l,-json.t),infoWindowOffset:new BMap.Size(json.lb+5,1),offset:new BMap.Size(json.x,json.h)})
       return icon;
    }
    
    function SearchClass(data){
        this.datas = data;
    }
    // rule = {k:"title",d:"酒店",s:"all",t:"single"}=>t{single:(key=?),more:(key like[%?%])}//t:{single|more},s{all|!all}
    SearchClass.prototype.search = function(rule){
        if(this.datas == null){alert("数据不存在!");return false;}
        if(this.trim(rule) == ""){ alert(this.trim(rule.t));alert("请指定要搜索内容!");return false;}
        var reval = [];
        var datas = this.datas;
        var len = datas.length;
        var me = this;
        var ruleReg = new RegExp(this.trim(rule.d));
        var hasOpen = false;
        
        var addData = function(data,isOpen){
            // 第一条数据打开信息窗口
            if(isOpen && !hasOpen){
                hasOpen = true;
                data.isOpen = 1;
            }else{
                data.isOpen = 0;
            }
            reval.push(data);
        }
        var getData = function(data,key){
            var ks = me.trim(key).split(/\./);
            var i = null,s = "data";
            if(ks.length == 0){
                return data;
            }else{
                for(var i = 0; i < ks.length; i++){
                    s += '["' + ks[i] + '"]';
                }
                return eval(s);
            }
        }
        for(var cnt = 0; cnt < len; cnt++){
            var data = datas[cnt];
            var d = getData(data,rule.k);
            if(rule.t == "single" && rule.d == d){
                addData(data,true);
            }else if(rule.t != "single" && ruleReg.test(d)){
                addData(data,true);
            }else if(rule.s == "all"){
                addData(data,false);
            }
        }
        return reval;
    }
    SearchClass.prototype.setData = function(data){
        this.datas = data;
    }
    SearchClass.prototype.trim = function(str){
     if(str == null){str = "";}else{ str = str.toString();}
        return str.replace(/(^[\s\t\xa0\u3000]+)|([\u3000\xa0\s\t]+$)/g, "");
    }
    
    
    initMap();//创建和初始化地图
      </script>
</asp:Content>
