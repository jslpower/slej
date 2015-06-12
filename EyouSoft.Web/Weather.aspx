<%@ Page Language="C#" Title="城市天气" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="Weather.aspx.cs" Inherits="EyouSoft.Web.ToolsPage.Weather" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="GENERATOR" content="MSHTML 8.00.6001.18702">
    <style type="text/css">
        H3
        {
            margin: 0px;
        }
        .clearit
        {
            clear: both;
        }
        .link14listStyle LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 23px;
            padding-left: 9px;
            padding-right: 0px;
            background: url(/images/toolspage/weather/news_law_hz_012.gif) no-repeat 0px 50%;
            font-size: 14px;
            padding-top: 0px;
        }
        .link14list LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 23px;
            padding-left: 0px;
            padding-right: 0px;
            font-size: 14px;
            padding-top: 0px;
        }
        .link12listStyle LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 20px;
            padding-left: 9px;
            padding-right: 0px;
            background: url(/images/toolspage/weather/news_law_hz_012.gif) no-repeat 0px 45%;
            font-size: 12px;
            padding-top: 0px;
        }
        .link12list LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 20px;
            padding-left: 0px;
            padding-right: 0px;
            font-size: 12px;
            padding-top: 0px;
        }
        #wrap
        {
            text-align: left;
            margin: 0px auto;
        }
        .sina_w_search
        {
            position: relative;
            text-align: right;
            margin-top: 10px;
            padding-right: 5px;
        }
        .sina_search_ico
        {
            z-index: 999;
            position: absolute;
            height: 27px;
            top: -3px;
            right: 195px;
        }
        .sina_w_city_input
        {
            padding-left: 10px;
            width: 150px;
            color: #ccc;
        }
        .sina_w_city_btn
        {
            width: 35px;
            margin-left: 2px;
        }
        .sina_w_custom
        {
            text-align: right;
            padding-right: 5px;
        }
        .sina_w_custom_province
        {
        }
        .sina_w_custom_city
        {
        }
        .sina_w_custom_submit
        {
            width: 35px;
            margin-left: 2px;
        }
        .sina_w_view
        {
        }
        .sina_w_view_title
        {
            line-height: 30px;
            margin-bottom: 8px;
            background: url(/images/toolspage/weather/dot_01.gif) repeat-x left bottom;
            height: 30px;
        }
        .sina_w_view_title SPAN
        {
            float: right;
        }
        .sina_w_view_title H3
        {
            color: #ff0000;
            font-size: 18px;
        }
        .sina_w_view_today
        {
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
        }
        .sina_w_view_today H3
        {
            color: #04086b;
            font-size: 16px;
        }
        .sina_w_view_today H3 STRONG
        {
            color: #999;
            font-size: 12px;
            font-weight: normal;
        }
        .sina_w_view_today H3 SPAN
        {
            color: #999;
            font-size: 12px;
            font-weight: normal;
        }
        .sina_w_view_today_status
        {
            padding-bottom: 4px;
            padding-top: 4px;
        }
        .sina_w_view_today_status IMG
        {
            vertical-align: middle;
            margin-right: 2px;
        }
        .sina_w_view_today_status STRONG
        {
            font-size: 12px;
        }
        .sina_w_view_today_status SPAN
        {
        }
        .sina_w_view_today_table
        {
        }
        .sina_w_view_today_table TABLE
        {
        }
        .sina_w_view_today_table TABLE TD
        {
            line-height: 18px;
        }
        .sina_w_view_today_table TABLE TD STRONG
        {
            color: #04086b;
            font-weight: normal;
        }
        .sina_w_view_today_more
        {
            text-align: right;
        }
        .sina_w_view_others
        {
            border-left: medium none;
            margin-top: 5px;
            background: url(/images/toolspage/weather/dot_01.gif) repeat-x left top;
            float: left;
            border-right: medium none;
        }
        .sina_w_view_others_patch
        {
            padding-bottom: 10px;
            line-height: 24px;
            padding-left: 10px;
            width: 100%;
            padding-right: 10px;
            display: inline-block;
            background: url(/images/toolspage/weather/dot_01.gif) repeat-x left bottom;
            float: left;
            padding-top: 10px;
        }
        .sina_w_view_tomorrow
        {
            width: 50%;
            float: left;
        }
        .sina_w_view_tomorrow H3
        {
            color: #999;
            font-size: 14px;
            ling-height: 35px;
        }
        .sina_w_view_tomorrow H3 IMG
        {
            vertical-align: middle;
            margin-right: 2px;
        }
        .sina_w_view_tomorrow P
        {
            line-height: 20px;
        }
        .sina_w_view_after_tomorrow
        {
            padding-left: 8px;
            width: 43%;
            background: url(/images/toolspage/weather/dot_02.gif) repeat-y left 50%;
            float: left;
            margin-left: 40px;
        }
        .sina_w_view_after_tomorrow H3
        {
            color: #999;
            font-size: 14px;
            ling-height: 35px;
        }
        .sina_w_view_after_tomorrow H3 IMG
        {
            vertical-align: middle;
            margin-right: 2px;
        }
        .sina_w_view_after_tomorrow P
        {
            line-height: 20px;
        }
    </style>
    <style>
        .main_div
        {
            width: 100%;
            height: 420px;
        }
        .bottom_words
        {
            padding-right: 10px;
            font-family: verdana;
            color: #e1e1e1;
            font-size: 10px;
        }
        FORM
        {
            margin: 0px;
        }
        .color_red
        {
            color: #ce5834;
            font-size: 14px;
        }
    </style>

    <script type="text/javascript" src="/JS/toolspage/weather/io_script-1.0.js"></script>

    <script type="text/javascript" src="/JS/toolspage/weather/jscookie.js"></script>

    <script type="text/javascript" src="/JS/toolspage/weather/weather_process-1.0.js"></script>

    <script type="text/javascript"> 
<!--        //--><![CDATA[//><!--
        function $_$(id) {
            return document.getElementById(id);
        }

        function rtrim(str, s) {
            if (typeof s == 'undefined') {
                s = "\s+";
            }
            var reg = new RegExp(s + "$");
            return str.replace(reg, '');
        }
        /**
        * 判断字符串是否全为汉字
        * @author abear
        * @param {string} chinese char
        * @return {Boolean}
        * @example
        * (code)
        * isChinese('张');
        * (returns)
        * true
        */
        var isChinese = function(sStr) {
            return /^[\u4e00-\u9fa5]+$/.test(sStr);
        };
        //--><!]]>
    </script>
<script type="text/javascript">
    $(function() {
        //$('.n_leftbox').css('width', 0);
        //$('.n_leftbox').hide();
        ///$('.n_rightbox').css('width', 1090);
        //$('.n_rightbox').css('height', 394);

        //$('.main_div').css('margin-left', $('.n_rightbox').width() / 2 - $('.main_div')[0].offsetWidth / 2)
    });
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="main_div">
        <form style="height:auto;">
        <table border="0" cellspacing="0" cellpadding="0" width="100%">
            <tbody>
                <tr>
                    <td>
                        <img src="/images/toolspage/weather/title.gif" width="143" height="45">
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#e0dcd1" height="323" valign="top" align="middle">
                        <table border="0" cellspacing="0" cellpadding="0" width="90%">
                            <tbody>
                                <tr>
                                    <td height="54" align="right">
                                        <label for="wide_01">
                                            <input id="wide_01" checked=checked align="absMiddle" type="radio" name="wide">
                                            <span class="color_red">国内城市</span></label>
                                        &nbsp;&nbsp;<label for="wide_02">
                                        <%--<input id="wide_02" align="absMiddle" type="radio"  name="wide">--%>
                                            <span class="color_red">
                                                <select style="color: #000000" id="sina_w_custom_province" class="sina_w_custom_province"
                                                    title="请选择省份" onchange="CitysHandler.insertCitys(this.options[this.selectedIndex].value);"
                                                    name="sina_w_custom_province">
                                                    <option selected value="">请选择省份</option>
                                                    <option value="北京">北京</option>
                                                    <option value="天津">天津</option>
                                                    <option value="河北">河北</option>
                                                    <option value="山西">山西</option>
                                                    <option value="山东">山东</option>
                                                    <option value="内蒙古">内蒙古</option>
                                                    <option value="湖北">湖北</option>
                                                    <option value="湖南">湖南</option>
                                                    <option value="河南">河南</option>
                                                    <option value="江西">江西</option>
                                                    <option value="上海">上海</option>
                                                    <option value="江苏">江苏</option>
                                                    <option value="浙江">浙江</option>
                                                    <option value="安徽">安徽</option>
                                                    <option value="广东">广东</option>
                                                    <option value="广西">广西</option>
                                                    <option value="海南">海南</option>
                                                    <option value="福建">福建</option>
                                                    <option value="黑龙江">黑龙江</option>
                                                    <option value="吉林">吉林</option>
                                                    <option value="辽宁">辽宁</option>
                                                    <option value="陕西">陕西</option>
                                                    <option value="甘肃">甘肃</option>
                                                    <option value="新疆">新疆</option>
                                                    <option value="青海">青海</option>
                                                    <option value="宁夏">宁夏</option>
                                                    <option value="四川">四川</option>
                                                    <option value="重庆">重庆</option>
                                                    <option value="贵州">贵州</option>
                                                    <option value="云南">云南</option>
                                                    <option value="西藏">西藏</option>
                                                    <option value="港澳台">港澳台</option>
                                                </select>
                                                <select id="sina_w_custom_city" class="sina_w_custom_city" title="请选择城市" name="sina_w_custom_city">
                                                    <option selected value="">请选择城市</option>
                                                </select>

                                                <script type="text/javascript">
<!--                                                    //--><![CDATA[//><!--
                                                    var CitysHandler = {
                                                        init: function() {
                                                            this.io = "http://php.weather.sina.com.cn/iframe/get_citys.php?province=@province@&code=js&charset=gbk" + "&_=@random@";
                                                            this.eSelectCity = $_$('sina_w_custom_city');
                                                            this.eSelectProvince = $_$('sina_w_custom_province');
                                                            this.__initSelect();
                                                        },
                                                        /**
                                                        * 初始化selected
                                                        */
                                                        __initSelect: function() {
                                                            this.eSelectCity.options[0].selected = 'selected';
                                                            this.eSelectProvince.options[0].selected = 'selected';
                                                        },
                                                        /**
                                                        * 插入城市列表
                                                        */
                                                        insertCitys: function(sProvince) {
                                                            if (sProvince == '') {
                                                                this.__clearOption(eSelect, true);
                                                                return false;
                                                            }
                                                            //clear select citys options
                                                            this.eSelectCity.options.length = 1;
                                                            var url = this.io;
                                                            var random = (new Date()).getTime();
                                                            url = url.replace(/@province@/g, sProvince);
                                                            url = url.replace(/@random@/g, random);
                                                            var jsloader = new IO.Script();
                                                            jsloader.load(url, function() {
                                                                try {
                                                                    this.__insertCitys(this.eSelectCity, SINA_W_CITYS[sProvince]);
                                                                } catch (e) { }
                                                            } .Bind(this));

                                                        },
                                                        __insertCitys: function(eSelect, aCitys) {
                                                            var sOptionText, sOptionValue;
                                                            for (var i = 0; i < aCitys.length; i++) {
                                                                sOptionText = sOptionValue = aCitys[i];
                                                                this.__insertOption(eSelect, sOptionText, sOptionValue);
                                                            }
                                                        },
                                                        __clearOption: function(eSelect, bDefault) {
                                                            //eSelect.options.length = 0;
                                                            bDefault = !!bDefault;
                                                            if (bDefault) {
                                                                //this.__insertOption(eSelect,'请选择城市','',true);
                                                                eSelect.options.length = 1;
                                                            } else {
                                                                eSelect.options.length = 0;
                                                            }
                                                        },
                                                        //add a option for a select
                                                        __insertOption: function(eSelect, sOptionText, sOptionValue, bSelected) {
                                                            if (!eSelect || sOptionText == '') {
                                                                return false;
                                                            }
                                                            try {
                                                                option = new Option(sOptionText, sOptionValue);
                                                                eSelect.options.add(option);
                                                                if ((!!bSelected) === true) {
                                                                    //option.selected = "selected";
                                                                    option.selected = true;
                                                                }
                                                                //alert('ss')
                                                            } catch (e) {
                                                                return false;
                                                            }
                                                            return true;
                                                        }
                                                    };
                                                    CitysHandler.init();
                                                    //--><!]]>
                                                </script>

                                                <input class="sina_w_custom_submit" title="定制该城市天气信息" onclick="Customer.custom(CitysHandler.eSelectCity.options[CitysHandler.eSelectCity.selectedIndex].value);"
                                                    value="查看" type="button" name="submit">
                                            </span>
                                        </label>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <!---动态天气显示开始-->
                                        <div class="sina_w_view">
                                            <div style="visibility: hidden" id="sina_w_view_title" class="sina_w_view_title">
                                                <h3 style="text-align: left">
                                                    @city@</h3>
                                            </div>
                                            <!-- today begin -->
                                            <div style="visibility: hidden" id="sina_w_view_today" class="sina_w_view_today">
                                                <h3 style="text-align: left; margin-left: 10px">
                                                    今天 <strong>@Y@-@m@-@d@ @week@</strong></h3>
                                                <div style="text-align: left; margin-left: 10px" class="sina_w_view_today_status">
                                                    @figure@@status@ @temperature@<span>风力：@power@</span></div>
                                                <div class="sina_w_view_today_table">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="padding-left: 10px" width="52%" align="left">
                                                                    <strong>穿衣说明：</strong>@chy_l@
                                                                </td>
                                                                <td style="padding-left: 10px" width="48%" align="left">
                                                                    <strong>污染说明：</strong>@pollution_l@
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-left: 10px" align="left">
                                                                    <strong>防晒说明：</strong>@fas_l@
                                                                </td>
                                                                <td style="padding-left: 10px" align="left">
                                                                    <strong>洗车说明：</strong>@xcz_l@
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; padding-left: 10px" align="left">
                                                                    <strong>舒适度说明：</strong>@ssd_l@
                                                                </td>
                                                                <td align="left">
                                                                    <div class="sina_w_view_today_more">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <!-- today end -->
                                            <!-- tomorrow and day after tomorrow begin -->
                                            <div class="sina_w_view_others">
                                                <div class="sina_w_view_others_patch">
                                                    <!-- tomorrow begin -->
                                                    <div style="visibility: hidden" id="sina_w_view_tomorrow" class="sina_w_view_tomorrow">
                                                        <h3 style="text-align: left">
                                                            明天 @figure@</h3>
                                                        <div style="text-align: left">
                                                            @status@ @temperature@</div>
                                                        <div style="text-align: left">
                                                            风力：@power@ <span><a title="查看详细" href="http://php.weather.sina.com.cn/search.php?city=@city@&amp;f=1"
                                                                target="_blank"></a></span>
                                                        </div>
                                                    </div>
                                                    <!-- tomorrow end -->
                                                    <!-- day after tomorrow begin -->
                                                    <div style="visibility: hidden" id="sina_w_view_after_tomorrow" class="sina_w_view_after_tomorrow">
                                                        <h3 style="text-align: left">
                                                            后天 @figure@</h3>
                                                        <div style="text-align: left">
                                                            @status@ @temperature@</div>
                                                        <div style="text-align: left">
                                                            风力：@power@ <span><a title="查看详细" href="http://php.weather.sina.com.cn/search.php?city=@city@&amp;f=1"
                                                                target="_blank"></a></span>
                                                        </div>
                                                    </div>
                                                    <!-- day after tomorrow end -->
                                                </div>
                                            </div>
                                            <!-- tomorrow and day after tomorrow end -->
                                        </div>
                                        <!---动态天气显示结束-->
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
    </div>
    <div style="display: none; margin-bottom:10px;" >
        <form method="get" name="sina_search_form" action="http://php.weather.sina.com.cn/search.php"
        target="_blank">
        <fieldset>
            <a title="天气" href="http://weather.news.sina.com.cn/" target="_blank"></a>
            <input style="display: none" id="city_input" class="sina_w_city_input" title="请输入城市名"
                value="请输入城市名" type="text" name="city"><input value="1" type="hidden" name="f"><input
                    value="1" type="hidden" name="dpc"></fieldset>
        </form>
        <div id="wrap">
            <!-- search begin -->
            <!-- 城市天气搜索 begin -->

            <script type="text/javascript">
		<!--                //--><![CDATA[//><!--

                var deafultTxt = '请输入城市名'; //trim($('city_input').value);

                $_$('city_input').onfocus = function() {
                    if ($.trim(this.value) == deafultTxt) {
                        this.value = '';
                        this.style.color = '#000';
                    }
                }

                $_$('city_input').onblur = function() {
                    if ($.trim(this.value) == '') {
                        this.value = deafultTxt;
                        this.style.color = '#ccc';
                    }
                }
                if ($.trim($_$('city_input').value) == deafultTxt) {
                    $_$('city_input').style.color = '#ccc';
                } else {
                    $_$('city_input').style.color = '#000';
                }
                //--><!]]>
            </script>

            <!-- 城市天气搜索 end -->
        </div>

        <script type="text/javascript"> 
<!--            //--><![CDATA[//><!--
            /**
            * 静态类
            * 城市cookie记录器
            */
            var CityCookier = {
                init: function() {
                    this.cookieName = 'SINA_WEATHER_CUSTOMIZE_city';
                    this.cookier = new JSCookie();
                    this.expire_time = new Date();
                    this.expire_time.setFullYear(this.expire_time.getFullYear() + 1);
                    this.domain = 'php.weather.sina.com.cn';
                    this.path = '/';

                },
                setCityCookie: function(cityName) {
                    cityName = escape(cityName);
                    return this.cookier.setCookie(this.cookieName, cityName, this.expire_time, this.domain, this.path);
                },
                getCityCookie: function() {
                    return unescape(this.cookier.getCookie(this.cookieName));
                }
            };
            CityCookier.init();

            /**
            * 静态类
            * 城市定制器
            */
            var Customer = {
                custom: function(city_name) {
                    if (city_name == '') {
                        alert('请选择城市');
                        return false;
                    }
                    //设置城市cookie
                    CityCookier.setCityCookie(city_name);
                    //加载该城市天气
                    SWHandler.loadWeather(city_name);
                }
            };

            /**
            * 静态类
            * 天气信息处理器
            */
            var SWHandler = {
                init: function() {
                    this.cityName = '杭州'; //默认城市
                    this.defaultCity = '杭州'; //如果定制的城市无数据 则显示此城市天气
                    var cookieCity = CityCookier.getCityCookie();
                    if (cookieCity) {
                        this.cityName = cookieCity;
                    }
                    this.io = "http://php.weather.sina.com.cn/js2.php?city=@city@" + "&_=@random@";
                    //get tpl
                    this.tpl = [];

                    //页面打开 初始化加载天气
                    this.loadWeather(this.cityName, true);
                },
                loadWeather: function(sCityName, bPageOpen) {
                    bPageOpen = !!bPageOpen;
                    var jsloader = new IO.Script();
                    var io = this.io;
                    var random = (new Date()).getTime();
                    io = io.replace(/@city@/g, sCityName);
                    io = io.replace(/@random@/g, random);
                    jsloader.load(io, function() {
                        if (typeof w == 'undefined') {	//未找到指定城市的天气信息 切换到显示北京的
                            if (bPageOpen) {	//页面初始打开
                                Customer.custom(this.defaultCity);
                            } else {//人为操作
                                alert('对不起，暂无城市：' + sCityName + ' 的天气信息');
                                return; //
                            }
                        } else {	//找到了指定城市的天气信息
                            SWHandler.loadWeatherCallback(sCityName);
                        }

                    } .Bind(this));
                },
                loadWeatherCallback: function(sCityName) {
                    this.drawHtml('sina_w_view_today', 0, sCityName); //今日
                    this.drawHtml('sina_w_view_title', 0, sCityName); //今日 city
                    this.drawHtml('sina_w_view_tomorrow', 1, sCityName); //明日
                    this.drawHtml('sina_w_view_after_tomorrow', 2, sCityName); //后日
                    window['w'] = undefined;

                },
                drawHtml: function(elementId, day, sCityName) {
                    var elm = $_$(elementId);
                    //是否已经获得tpl?
                    var tpl = '';
                    if (typeof this.tpl[elementId] == 'undefined') {
                        this.tpl[elementId] = tpl = elm.innerHTML;
                    } else {
                        tpl = this.tpl[elementId];
                    }
                    //数据
                    /*
                    if(typeof w == 'undefined' || typeof w[day] == 'undefined'){
                    var w = [];
                    w[day] = [];
                    city = sCityName;
                    }
                    */
                    var __w = w[day];
                    var Y, m, d, week;
                    /*
                    var now = new Date();			
                    if(typeof year1 == 'undefined'){
                    Y = now.getFullYear();
                    }else{
                    Y = '20' + year1;
                    }
                    if(typeof month1 == 'undefined'){
                    m = now.getMonth()+1;
                    }else{
                    m = month1;
                    }
                    if(typeof day1 == 'undefined'){
                    d = now.getDate();
                    }else{
                    d = day1;
                    }
                    if(typeof week1 == 'undefined'){
                    var weeks = ['日','一','二','三','四','五','六'];
                    week = '星期' + weeks[now.getDay()];
                    }else{
                    week = week1;
                    }
                    */
                    Y = '20' + year1;
                    m = month1;
                    d = day1;
                    week = week1;

                    var figure1 = __w['figure1'] || '';
                    var figure2 = __w['figure2'] || '';
                    var status1 = __w['status1'] || '';
                    var status2 = __w['status2'] || '';
                    var temperature1 = __w['temperature1'] || '';
                    var temperature2 = __w['temperature2'] || '';
                    var power1 = __w['power1'] || '';
                    var power2 = __w['power2'] || '';
                    var chy_l = __w['chy_l'] || '暂缺'; //穿衣说明
                    var pollution_l = __w['pollution_l'] || '暂缺'; //污染说明
                    var fas_l = __w['fas_l'] || '暂缺'; //防晒说明
                    var xcz_l = __w['xcz_l'] || '暂缺'; //洗车说明
                    var ssd_l = __w['ssd_l'] || '暂缺'; //舒适度说明

                    tpl = tpl.replace(/@Y@/g, Y);
                    tpl = tpl.replace(/@m@/g, m);
                    tpl = tpl.replace(/@d@/g, d);
                    tpl = tpl.replace(/@week@/g, week);
                    //tpl = tpl.replace(/@title@/g,title);
                    tpl = tpl.replace(/@city@/g, city);
                    tpl = tpl.replace(/@city@/g, city);
                    //天气图标
                    var figure = WeatherProcesser.getSFigure(figure1, figure2, status1, status2);
                    tpl = tpl.replace(/@figure@/g, figure);
                    //天气文字
                    var status = WeatherProcesser.getStatus(status1, status2);
                    tpl = tpl.replace(/@status@/g, status);
                    //温度
                    var temperature = WeatherProcesser.getTemperature(temperature1, temperature2);
                    tpl = tpl.replace(/@temperature@/g, temperature);
                    //风力
                    var power = WeatherProcesser.getPower(power1, power2);
                    tpl = tpl.replace(/@power@/g, power);
                    //指数
                    tpl = tpl.replace(/@chy_l@/g, chy_l);
                    tpl = tpl.replace(/@pollution_l@/g, pollution_l);
                    tpl = tpl.replace(/@fas_l@/g, fas_l);
                    tpl = tpl.replace(/@xcz_l@/g, xcz_l);
                    tpl = tpl.replace(/@ssd_l@/g, ssd_l);

                    elm.innerHTML = tpl;
                    elm.style.visibility = 'visible';
                }

            };
            SWHandler.init();

            /**
            * 静态类
            * 城市天气搜索器
            * 重新定义搜索form 行为 仅在本页内显示搜索的城市天气信息
            */
            var Searcher = {
                //init
                init: function(cityInputId, deafultTxt) {
                    this.io = "http://php.weather.sina.com.cn/js2.php?city=@city@" + "&_=" + (new Date()).getTime();
                    //this.eSearchBtn = $(searchBtnId);	//搜索按钮
                    this.eCityInput = $_$(cityInputId); //城市input
                    this.eForm = this.eCityInput.form; //form
                    this.deafultTxt = deafultTxt;

                    this.eForm.onsubmit = function() {
                        var cityName = this.filtCity(this.eCityInput.value);
                        if (this.validateCity(cityName)) {
                            Searcher.loadWeather(cityName);
                        }
                        //控制 form 不提交跳转
                        return false;
                    } .Bind(this);
                },
                //好像是汽车的空气滤清器
                filtCity: function(cityName) {
                    cityName = $.trim(cityName);
                    cityName = $.rtrim(cityName, '直辖市');
                    cityName = $.rtrim(cityName, '县级市');
                    cityName = $.rtrim(cityName, '市');
                    cityName = $.rtrim(cityName, '特别行政区');
                    cityName = $.rtrim(cityName, '行政区');
                    cityName = $.rtrim(cityName, '地区');
                    cityName = $.rtrim(cityName, '区');

                    return cityName;
                },
                //验证city input
                validateCity: function(cityName) {
                    cityName = $.trim(cityName);
                    if (cityName == this.deafultTxt || cityName == '') {
                        alert(deafultTxt);
                        return false;
                    }
                    if (!isChinese(cityName)) {//全是汉字?
                        alert('请输入正确的城市名');
                        this.eCityInput.focus();
                        return false;
                    }
                    return true;
                },
                //加载天气信息
                loadWeather: function(sCityName) {
                    var jsloader = new IO.Script();
                    var io = this.io;
                    io = io.replace(/@city@/g, sCityName);
                    jsloader.load(io, function() {
                        if (typeof w == 'undefined') {//该城市是否有天气信息 如果没有 显示北京的
                            //alert('标记已经再试一次请求');
                            alert('对不起，未找到城市：' + sCityName + ' 的天气信息，请确认输入了正确的城市名！');
                            //SWHandler.loadWeather('北京');
                            //Customer.custom('北京');
                            //agin = true;//标记已经再试一次请求				
                            return false;
                        }
                        //display weather html
                        SWHandler.loadWeatherCallback(sCityName);
                        //set city cookie
                        CityCookier.setCityCookie(sCityName);
                    });
                }
            };
            Searcher.init('city_input', deafultTxt);

            //--><!]]>
        </script>

    </div>
</asp:Content>
