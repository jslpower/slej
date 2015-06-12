/// <reference path="/js/jquery.js" />

var loadXls = {
    array: new Array(),
    sel: null,
    box: null,
    selval: null,
    ///初使化arr二维数组， box:table容器 ，sel列表选择器
    init: function(arr, box, sel) {
        var that = this;
        that.array = arr;
        that.sel = sel;
        that.box = $(box);
        that._createTable();
        that._bindSelect();
    },
    InitTourSite: function(arr, box, sel) {
        var _s = this;
        _s.array = arr;
        _s.sel = sel;
        _s.box = $(box);
        _s._CreateTableTour();
    },
    //建表
    _createTable: function() {
        var that = this;
        var html = [];
        if (that.array.length > 0) {
            html.push("<table width=\"100%\" border=\"0\"  cellpadding=\"0\" cellspacing=\"1\" id=\"xlstable\" >");
            html.push("<tr bgcolor=\"#BDDCF4\">");
            html.push("<th width=\"35px\">序号</th>");
            for (var j = 0; j < that.array[0].length; j++) {
                html.push("<th>" + that.array[0][j] + "</th>");
            }
            html.push("</tr>");
            for (var i = 1; i < that.array.length; i++) {
                html.push("<tr tid='" + i + "' bgcolor=\"#e3f1fc\">");
                html.push("<td><input type=\"checkbox\" class=\"checkbox\" /></td>");
                for (var j = 0; j < that.array[i].length; j++) {
                    html.push("<td>" + that.array[i][j] + "</td>");
                }
                html.push("</tr>");
            }
            html.push("</table>");
            that.box.html(html.join(""));
        } else {
            that.box.html("");
        }
    },
    _CreateTableTour: function() {
        var _s = this;
        var tabHtml = [];
        if (_s.array.length > 0) {
            tabHtml.push("<table width=\"100%\" border=\"0\"  cellpadding=\"0\" cellspacing=\"1\" id=\"xlstable\" >");
            tabHtml.push("<tr bgcolor=\"#BDDCF4\">");
            tabHtml.push("<th width=\"35px\">序号</th>");
            tabHtml.push("<th>" + _s.array[0].Riqi + "</th>");
            tabHtml.push("<th>" + _s.array[0].XingQi + "</th>");
            tabHtml.push("<th>" + _s.array[0].Hangduan + "</th>");
            tabHtml.push("<th>" + _s.array[0].HangBanHao + "</th>");
            tabHtml.push("<th>" + _s.array[0].Renshu + "</th>");
            tabHtml.push("<th>" + _s.array[0].Tuanxing + "</th>");
            tabHtml.push("<th>" + _s.array[0].Lvxshe + "</th>");
            tabHtml.push("<th>" + _s.array[0].Bianma + "</th>");
            tabHtml.push("<th>" + _s.array[0].Jiage + "</th>");
            tabHtml.push("<th>" + _s.array[0].Zhekou + "</th>");
            tabHtml.push("<th>" + _s.array[0].Beizhu + "</th>");
            tabHtml.push("</tr>");
            for (var i = 1; i < _s.array.length; i++) {
                tabHtml.push("<tr tid='" + i + "' bgcolor=\"#e3f1fc\">");
                tabHtml.push("<td><input type=\"checkbox\" class=\"checkbox\" /></td>");

                var _rhtml = "";
                _rhtml += "<table width=\"100%\" class=\"tb_slist\">";
                if (_s.array[i].Riqi.toString().split(',').length > 0) {
                    for (var j = 0; j < _s.array[i].Riqi.toString().split(',').length; j++) {
                        _rhtml += "<tr><td>" + _s.array[i].Riqi.toString().split(',')[j] + "</td></tr>";
                    }
                }
                _rhtml += "</table>";
                tabHtml.push("<td>" + _rhtml + "</td>");

                var _xHtml = "";
                _xHtml += "<table width=\"100%\" class=\"tb_slist\">";
                if (_s.array[i].XingQi.toString().split(',').length > 0) {
                    for (var j = 0; j < _s.array[i].XingQi.toString().split(',').length; j++) {
                        _xHtml += "<tr><td>" + _s.array[i].XingQi.toString().split(',')[j] + "</td></tr>";
                    }
                }
                _xHtml += "</table>";
                tabHtml.push("<td>" + _xHtml + "</td>");

                var _fHtml = "";
                _fHtml += "<table width=\"100%\" class=\"tb_slist\">";
                if (_s.array[i].Hangduan.toString().split(',').length > 0) {
                    for (var j = 0; j < _s.array[i].Hangduan.toString().split(',').length; j++) {
                        _fHtml += "<tr><td>" + _s.array[i].Hangduan.toString().split(',')[j] + "</td></tr>";
                    }
                }
                _fHtml += "</table>";
                tabHtml.push("<td>" + _fHtml + "</td>");

                var _fnHtml = "";
                _fnHtml += "<table width=\"100%\" class=\"tb_slist\">";
                if (_s.array[i].HangBanHao.toString().split(',').length > 0) {
                    for (var j = 0; j < _s.array[i].HangBanHao.toString().split(',').length; j++) {
                        _fnHtml += "<tr><td>" + _s.array[i].HangBanHao.toString().split(',')[j] + "</td></tr>";
                    }
                }
                _fnHtml += "</table>";
                tabHtml.push("<td>" + _fnHtml + "</td>");


                tabHtml.push("<td>" + _s.array[i].Renshu + "</td>");
                tabHtml.push("<td>" + _s.array[i].Tuanxing + "</td>");
                tabHtml.push("<td>" + _s.array[i].Lvxshe + "</td>");
                tabHtml.push("<td>" + _s.array[i].Bianma + "</td>");
                tabHtml.push("<td>" + _s.array[i].Jiage + "</td>");
                tabHtml.push("<td>" + _s.array[i].Zhekou + "</td>");
                tabHtml.push("<td>" + _s.array[i].Beizhu + "</td>");
                tabHtml.push("</tr>");
            }
            tabHtml.push("</table>");
            _s.box.html(tabHtml.join(""));
        }
        else {
            _s.box.html("");
        }
    },
    //绑定设置返回选择数组
    bindIndex: function(newarr) {
        var that = this;
        var retarr = [];
        $("#xlstable").find("input.checkbox").each(function() {
            if ($(this).attr("checked")) {
                var _this = $(this);
                var tid = parseInt(_this.parent().parent().attr("tid"));
                retarr.push(that.array[tid]);
            }
        });
        return retarr;
    },
    //初始化绑定
    _bindSelect: function() {
        var that = this;
        if (that.sel) {
            var selhtml = [];
            if (that.array.length > 0) {
                selhtml.push("<option value='-1'>请选择</option>");
                for (var j = 0; j < that.array[0].length; j++) {
                    selhtml.push("<option value='" + j + "' text='" + that.array[0][j] + "'>" + that.array[0][j] + "</option>");
                }
            }
            selhtml = selhtml.join("");
            $(that.sel).html(selhtml);
            $(that.sel).each(function() {
                var _tha = $(this);
                var _text = $.trim(_tha.prev("label").text().replace("：", ""));
                setTimeout(function() {
                    if (_tha.find("option[text='" + _text + "']").length > 0) {
                        _tha.find("option[text='" + _text + "']").attr("selected", true);
                    }
                }, 200);
            });
        }
    },

    //全选清空
    selectAll: function(o) {
        $("#xlstable").find("input.checkbox").attr("checked", o ? true : false);
        return false;
    },
    //反选
    selectback: function() {
        $("#xlstable").find("input.checkbox").each(function() {
            var _this = $(this);
            _this.attr("checked", _this.attr("checked") ? false : true);
        })
        return false;
    }
}
