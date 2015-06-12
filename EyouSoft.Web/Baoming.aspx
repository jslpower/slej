<%@ Page Language="C#" Title="报名网点" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="Baoming.aspx.cs" Inherits="EyouSoft.Web.Baoming" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script src="JS/ajaxpagecontrols.js" type="text/javascript"></script>
<script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=<%= BaiduMapKey %>"></script>
<script type="text/javascript">

    var instance = {};

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
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<form id="form1" runat="server"></form>
    <div class="n_title">
        > 报名网点</div>
    <div style="position: relative;">
        <div class="baom_name">
            <img src="images/wdian.gif"></div>
        <div class="line_xx_box baom_box margin_T10">
            <div class="baom_shm">
                友情提醒：代理商报名前请先登陆系统，游客请到以下代理报名网点报名或拨打<font class="font_yellow"> 400-6588-180</font>
                报名！</div>
            <div class="baom_map">
            <div style="width:100%;height:380px;border:1px solid gray" id="baomap"></div>
                <%--<img src="images/wangdian_map.gif">--%></div>
        </div>
    </div>
    <form>
    <%if (isfenxiao == 0)
      { %>
    <div class="qzh-search baom-search margin_T10">
        <b class="font14">网点名称：</b>
        <input type="text" name="websitename" class="formsize140 input-style" value='<%=Request.QueryString["websitename"] %>' />
<%--        <input type="text" class="formsize140 input-style">--%>
        <input type="submit" value="搜索 >>" class="line-s-btn" />
        <%--<input type="button" class="line-s-btn" value="搜索 &gt;&gt;">--%>
    </div>
    <%} %>
    </form>
    <div class="baom_list">
        <ul>
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
            <li>
                <div class="bm_num">
                    <%# Container.ItemIndex+1 %></div>
                <dl>
                    <dt>网点名称：<font class="font_yellow"><%# Eval("Seller.WebsiteName")%></font></dt>
                    <dd>
                        联系人员：<em><%# Eval("MemberName")%></em></dd>
                    <dd>
                        手机：<em><%# Eval("Mobile")%></em></dd>
                    <dd>
                        联系方式：电话：<em><%# Eval("Contact")%></em></dd>
                    <dd>
                        传真：<em><%# Eval("Fax")%></em></dd>
                    <dd class="wid">
                        网点地址：<%# Eval("Address")%></dd>
                </dl>
            </li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clear">
        </div>
    </div>

    <div class="page" id="page"></div>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Adv">
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
        var dd = searchClass.search({k:"content",d:"电话",t:"more",s:""});//t:{single|more},s{all|!all}
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
        if(this.trim(rule) == "" || this.trim(rule.d) == "" || this.trim(rule.k) == "" || this.trim(rule.t) == ""){alert("请指定要搜索内容!");return false;}
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
<script type="text/javascript">
        var pagingConfig = { pageSize: 10, pageIndex:<%=Model.SearchInfo.PageInfo.PageIndex %> , recordCount: <%=Model.SearchInfo.PageInfo.TotalCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</asp:Content>
