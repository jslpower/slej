//出团日期日历 刘树超 2014-07-01
//针对线路详细页面  需要页面上声明的方法 pageData.clickFunc   pageData.initRiLiUl();
var tourdate = {
    //riliselector 呈现日历容器的选择器 currentTourId:当前要呈现日历的计划编号 leaveDate:出团日期
    options: { "riliselector": "#rili", "currentTourId": "", "leaveDate": "2014-08-01" }
    //json date to datetime
    , jsonDateToDateTime: function(jsondate) {
        return new Date(parseInt(jsondate.replace("/Date(", "").replace(")/", ""), 10));
    }
    //获取日历HTML date:起始出团日期
    , _getRiLiHTML: function(date) {
        var year = date.getFullYear();
        var month = date.getMonth();
        var date1 = new Date(year, month, 1);
        //起始天
        var sd = date1.getDate();
        //起始天星期
        var sdOfWeek = date1.getDay();
        date1.setMonth(date1.getMonth() + 1, 0);
        //结束天
        var fd = date1.getDate();

        var s = [];

        date1.setMonth(date1.getMonth(), 1);



        s.push('<ul class="calendar_t"><li>星期日</li><li>星期一</li><li>星期二</li><li>星期三</li><li>星期四</li><li>星期五</li><li>星期六</li></ul><ul class="calendar_d">');



        //创建空白日期
        for (var i = 0; i < sdOfWeek; i++) {
            s.push('<li>&nbsp;</li>');
        }



        do {
            s.push('<li onclick="pageData.clickFunc(this)" class="riliday" id="' + year + '-' + (month + 1) + '-' + sd + '" title="' + year + '-' + (month + 1) + '-' + sd + '">');
            s.push('<div class="calendar_box"><span>' + sd + '</span></div>');
            s.push("</li>");
            sd++;
        } while (sd <= fd)
        //补全单元格
        var _cellCount = fd + sdOfWeek;
        for (var i = _cellCount; i < 42; i++) {
            s.push("<li>&nbsp;</li>");
        }
        s.push('</ul>');



        return s.join('')
    },
    initNext: function(date) {
        $("#next_month").unbind("click").click(function() { tourdate.init(date); pageData.initRiLiUl(); })
    },
    initPrev: function(date) {
        if (date.valueOf() > new Date().valueOf()) {
            var prevYear = date.getFullYear();
            var prevMonth = date.getMonth() - 1;
            var prevDate = new Date(prevYear, prevMonth, 1);
            $("#prev_month").attr("class", "jiantou_l").unbind("click").click(function() { tourdate.init(prevDate); pageData.initRiLiUl(); })
        }
        else {
            $("#prev_month").attr("class", "jiantou_l_on").unbind("click");
        }

    }
    //初始化 控件ID
    , init: function(obj) {
        var _leavedate = new Date();
        if (typeof obj != "undefined" && typeof obj == "string") {
            var _date = obj.split("-");
            _leavedate = new Date(_date[0], _date[1] - 1, 1);
        }
        if (typeof obj != "undefined" && typeof obj == "object") {
            _leavedate = obj;
        }

        $("#rilil").html(this._getRiLiHTML(new Date(_leavedate)));
        $("#month").html((_leavedate.getMonth() + 1));

        var prevYear = _leavedate.getFullYear();
        var prevMonth = _leavedate.getMonth();
        var prevDate = new Date(prevYear, prevMonth, 1);
        tourdate.initPrev(prevDate);

        _leavedate.setMonth(_leavedate.getMonth() + 1, 1);
        $("#rilir").html(this._getRiLiHTML(new Date(_leavedate)));
        $("#nextmonth").html((_leavedate.getMonth() + 1));

        var nextYear = _leavedate.getFullYear();
        var nextMonth = _leavedate.getMonth();
        var nextDate = new Date(nextYear, nextMonth, 1);
        tourdate.initNext(nextDate);
    }
};
