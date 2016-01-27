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

        s.push('<div class="mb10">');
        s.push('<div class="date_type">');
        s.push('<ul>');
        s.push('<li class="font16">' + year + '年' + (month + 1) + '月</li>');
        s.push('</ul>');
        s.push('</div>');

        s.push('<div class="date_week">');
        s.push('<ul>');
        s.push('<li>日</li>');
        s.push('<li>一</li>');
        s.push('<li>二</li>');
        s.push('<li>三</li>');
        s.push('<li>四</li>');
        s.push('<li>五</li>');
        s.push('<li>六</li>');
        s.push('</ul>');
        s.push('</div>');

        s.push('<section class="tuanqi">');
        s.push('<ul class="clearfix">');


        //s.push(' <ul class="clearfix">');
        /*
        <div class=\"date_type\"><ul><li id=\"prev_li\" class=\"prev\"></li><li class=\"font16\">2014年11月</li><li id=\"next_li\" class=\"next\"></li></ul></div>
        
        */



        //创建空白日期
        for (var i = 0; i < sdOfWeek; i++) {
            s.push('<li>&nbsp;</li>');
        }



        do {

            s.push('<li class="riliday" id="' + year + '-' + (month + 1) + '-' + sd + '" title="' + year + '-' + (month + 1) + '-' + sd + '">');
            s.push('<em>' + sd + '</em>');
            s.push("</li>");
            sd++;
        } while (sd <= fd)
        //补全单元格
        var _cellCount = fd + sdOfWeek;
        for (var i = _cellCount; i < 42; i++) {
            s.push("<li>&nbsp;</li>");
        }
        //s.push('</ul>');
        s.push('</ul>');
        s.push('</section>');
        s.push('</div>');
        return s.join('')
    },
    initNext: function(date) {
        $("#next_li").unbind("click").click(function() { tourdate.init(date); })
    },
    initPrev: function(date) {
        if (date.valueOf() > new Date().valueOf()) {
            var prevYear = date.getFullYear();
            var prevMonth = date.getMonth() - 1;
            var prevDate = new Date(prevYear, prevMonth, 1);
            $("#prev_li").attr("class", "prev").unbind("click").click(function() { tourdate.init(prevDate); })
        }
        else {
            $("#prev_li").attr("class", "prev l_disable").unbind("click");
        }

    }
    //初始化 控件ID
    , init: function(obj) {
        var _leavedate = $("#hidDate").val();
        var z = _leavedate.split("-");
        _leavedate = new Date(z[0], z[1] - 1, 1);

        var $html = '';
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 1), "-1"));
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 2), "-1"));
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 3), "-1"));
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 4), "-1"));
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 5), "-1"));
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 6), "-1"));
        $html += this._getRiLiHTML(new Date(_leavedate.getFullYear(), (_leavedate.getMonth() + 7), "-1"));


        $("#rili").prepend($html)


    }
};
