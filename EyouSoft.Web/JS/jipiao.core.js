/*
汪奇志 2013-11-11 jipiao  
*/99

var ticketLKE = {
    cacheData: new Array(),
    config: { focus: null },
    //出发、抵达城市输入框自动完成功能 对jquery.autocomplete.js做了一点点修改
    initAutoComplete: function() {
        //出发城市
        $("#txtDepCityName").autocomplete(jiPiaoSanZiMaData, {
            minChars: 1,
            width: 200,
            matchContains: "text",
            autoFill: true,
            formatItem: function(row, i, max) {
                return '<span class="sp1">' + row.CityName + '</span>' + '<span class="sp2">' + row.PY1 + '</span>';
            },
            formatMatch: function(row, i, max) {
                //return row.cName + "," + row.shortName + "," + row.eName;
                return row.PY1 + "," + row.PY2 + "," + row.CityName + "," + row.Code + "|" + row.Code;
            },
            formatResult: function(row) {
                return row.CityName;
            },
            formatHidResult: function(row) {
                return { hidInputId: "txtDepCitySanZiMa", value: row.Code };
            }
        });
        //抵达城市
        $("#txtArrCityName").autocomplete(jiPiaoSanZiMaData, {
            minChars: 1,
            width: 200,
            matchContains: "text",
            autoFill: true,
            formatItem: function(row, i, max) {
                return '<span class="sp1">' + row.CityName + '</span>' + '<span class="sp2">' + row.PY1 + '</span>';
            },
            formatMatch: function(row, i, max) {
                //return row.cName + "," + row.shortName + "," + row.eName;
                return row.PY1 + "," + row.PY2 + "," + row.CityName + "," + row.Code + "|" + row.Code;
            },
            formatResult: function(row) {
                return row.CityName;
            },
            formatHidResult: function(row) {
                return { hidInputId: "txtArrCitySanZiMa", value: row.Code };
            }
        });


        $("#CityName").autocomplete(jiPiaoSanZiMaData, {
            minChars: 1,
            width: 200,
            matchContains: "text",
            autoFill: true,
            formatItem: function(row, i, max) {
                return '<span class="sp1">' + row.CityName + '</span>' + '<span class="sp2">' + row.PY1 + '</span>';
            },
            formatMatch: function(row, i, max) {
                //return row.cName + "," + row.shortName + "," + row.eName;
                return row.PY1 + "," + row.PY2 + "," + row.CityName + "," + row.Code + "|" + row.Code;
            },
            formatResult: function(row) {
                return row.CityName;
            },
            formatHidResult: function(row) {
                return { hidInputId: "CityCode", value: row.Code };
            }
        });

        $("#mudidi").autocomplete(jiPiaoSanZiMaData, {
            minChars: 1,
            width: 200,
            matchContains: "text",
            autoFill: true,
            formatItem: function(row, i, max) {
                return '<span class="sp1">' + row.CityName + '</span>' + '<span class="sp2">' + row.PY1 + '</span>';
            },
            formatMatch: function(row, i, max) {
                //return row.cName + "," + row.shortName + "," + row.eName;
                return row.PY1 + "," + row.PY2 + "," + row.CityName + "," + row.Code + "|" + row.Code;
            },
            formatResult: function(row) {
                return row.CityName;
            },
            formatHidResult: function(row) {
                return { hidInputId: "sanzima", value: row.Code };
            }
        });


        $("#txt_jps_chufa_chengshi").autocomplete(jiPiaoSanZiMaData, {
            minChars: 1,
            width: 200,
            matchContains: "text",
            autoFill: true,
            formatItem: function(row, i, max) {
                return '<span class="sp1">' + row.CityName + '</span>' + '<span class="sp2">' + row.PY1 + '</span>';
            },
            formatMatch: function(row, i, max) {
                //return row.cName + "," + row.shortName + "," + row.eName;
                return row.PY1 + "," + row.PY2 + "," + row.CityName + "," + row.Code + "|" + row.Code;
            },
            formatResult: function(row) {
                return row.CityName;
            },
            formatHidResult: function(row) {
                return { hidInputId: "txt_jps_chufa_sanzima", value: row.Code };
            }
        });
        //抵达城市
        $("#txt_jps_daoda_chengshi").autocomplete(jiPiaoSanZiMaData, {
            minChars: 1,
            width: 200,
            matchContains: "text",
            autoFill: true,
            formatItem: function(row, i, max) {
                return '<span class="sp1">' + row.CityName + '</span>' + '<span class="sp2">' + row.PY1 + '</span>';
            },
            formatMatch: function(row, i, max) {
                //return row.cName + "," + row.shortName + "," + row.eName;
                return row.PY1 + "," + row.PY2 + "," + row.CityName + "," + row.Code + "|" + row.Code;
            },
            formatResult: function(row) {
                return row.CityName;
            },
            formatHidResult: function(row) {
                return { hidInputId: "txt_jps_daoda_sanzima", value: row.Code };
            }
        });

        $("#CityName").bind("blur", function() { ticketLKE.setDefaultValue(this); });
        $("#mudidi").bind("blur", function() { ticketLKE.setDefaultValue(this); });
        $("#txtDepCityName").bind("blur", function() { ticketLKE.setDefaultValue(this); });
        $("#txtArrCityName").bind("blur", function() { ticketLKE.setDefaultValue(this); });
        $("#txt_jps_chufa_chengshi").bind("blur", function() { ticketLKE.setDefaultValue(this); });
        $("#txt_jps_daoda_chengshi").bind("blur", function() { ticketLKE.setDefaultValue(this); });

        $("#CityName").attr("jipiao_city_input", "1");
        $("#mudidi").attr("jipiao_city_input", "1");
        $("#txtDepCityName").attr("jipiao_city_input", "1");
        $("#txtArrCityName").attr("jipiao_city_input", "1");
        $("#txt_jps_chufa_chengshi").attr("jipiao_city_input", "1");
        $("#txt_jps_daoda_chengshi").attr("jipiao_city_input", "1");
    },
    //鼠标离开设定输入框值
    setDefaultValue: function(_obj) {
        var obj = $(_obj);
        var objV = obj.val().toLowerCase();
        if ($.trim(objV).length < 1) {
            obj.next().val('');
            return;
        }
        if (this.cacheData.length > 0) {
            var arr1 = this.cacheData[0].split('|')

            if (arr1.length != 2) { return; }

            var arr2 = arr1[0].toLowerCase().split(",");

            if (arr2.length != 4) { return; }

            var isMatch = false;
            for (var i = 0; i < arr2.length; i++) {
                if (arr2[i].indexOf(objV) == 0) { isMatch = true; break; }
                //if (arr2[i] == objV) { isMatch = true; break; }
            }

            if (isMatch) {
                obj.val(arr2[2]);
                obj.next().val(arr1[1]);
            }

            this.cacheData = new Array();
        }
    },
    // 关闭div
    __hideDiv: function() {
        this.__getDiv().hide();
    },
    //显示未匹配到数据时的提示信息
    sWeiPiPei: function() {
        var _$obj = $("#i_div_jipiao_weipipei");
        var jObjInput = $("#" + this.config.focus.txtName);
        var offset = jObjInput.offset();
        var left = offset.left;
        var top = offset.top + jObjInput.height() + 2;
        _$obj.css({ 'left': left, 'top': top });
        _$obj.show();
        _$obj.html("&nbsp;&nbsp;对不起，找不到" + jObjInput.val());
        //jObjInput.val('')
        jObjInput.next().val('');
    },
    //关闭未匹配到数据时的提示信息
    hWeiPiPei: function() {
        $("#i_div_jipiao_weipipei").hide();
    },
    __getDiv: function() {
    return $("#i_div_jipiaochengshi").css("font-family", "'宋体' Verdana Geneva sans-serif");
    },
    __getUl: function() {
        return $("#i_ul_jipiaochengshi");
    },
    __showDiv: function(options) {
        this.config.focus = options;
        var _$div = this.__getDiv();
        var _$inputobj = $("#" + options.txtName);
        var _offset = _$inputobj.offset();
        var _left = _offset.left + (typeof (options.left) == "undefined" ? 0 : options.left);
        var _top = _offset.top + _$inputobj.height() + (typeof (options.top) == "undefined" ? 0 : options.top);
        _$div.css({ 'left': _left, 'top': _top });
        _$div.show();
    },
    __hideDiv: function() {
        this.__getDiv().hide();
    },
    __xuanZhong: function(obj) {
        var _$obj = $(obj);

        $("#" + this.config.focus.txtCode).val(_$obj.attr("i_code"));
        $("#" + this.config.focus.txtName).val(_$obj.attr("i_name"));

        this.__hideDiv();
    },
    __initChengShiLi: function(obj) {
        var _$obj = $(obj);
        var _s = [];
        var _leiXing = _$obj.attr("i_leixing");
        var _data = [];
        var _zimu = "";
        switch (_leiXing) {
            case "0": _zimu = ""; break;
            case "1": _zimu = ["A", "B", "C", "D", "E", "F"]; break;
            case "2": _zimu = ["G", "H", "I", "J"]; break;
            case "3": _zimu = ["K", "L", "M", "N"]; break;
            case "4": _zimu = ["O", "P", "Q", "R", "S", "T"]; break;
            case "5": _zimu = ["U", "V", "W", "X", "Y", "Z"]; break;
            default: _zimu = ""; break;
        }

        for (var i = 0; i < jiPiaoSanZiMaData.length; i++) {
            if (typeof (_zimu) == "string") {
                if (jiPiaoSanZiMaData[i].IsReDian) _data.push(jiPiaoSanZiMaData[i]);
            } else {
                if (_zimu.join('').indexOf(jiPiaoSanZiMaData[i].PY3) > -1) _data.push(jiPiaoSanZiMaData[i]);
            }
        }

        if (_data.length > 0 && typeof (_zimu) == "string") {
            for (var i = 0; i < _data.length; i++) {
                _s.push('<li i_code="' + _data[i].Code + '" i_name="' + _data[i].CityName + '"><a href="javascript:void(0)">&nbsp;' + _data[i].CityName + '</a></li>');
            }
        }

        if (_data.length > 0 && typeof (_zimu) == "object") {
            for (var j = 0; j < _zimu.length; j++) {
                var __zimu = _zimu[j];
                var _zimuData = [];

                for (var i = 0; i < _data.length; i++) {
                    if (_data[i].PY3 == __zimu) _zimuData.push(_data[i]);
                }

                if (_zimuData.length == 0) continue;

                //if (j > 0) _s.push('<li class="jiange">&nbsp;</li>');
                _s.push('<li class="zimu">' + __zimu + '</li>');
                for (var i = 0; i < _zimuData.length; i++) {
                    if (i > 0 && i % 4 == 0) _s.push('<li class="zimu">&nbsp;</li>');
                    _s.push('<li i_code="' + _zimuData[i].Code + '" i_name="' + _zimuData[i].CityName + '"><a href="javascript:void(0)">&nbsp;' + _zimuData[i].CityName + '</a></li>');
                }

                if (_zimuData.length % 4 != 0)
                    for (var i = 0; i < 4 - _zimuData.length % 4; i++) {
                    _s.push('<li>&nbsp;</li>');
                }
            }
        }

        var _self = this;
        var _$ul = this.__getUl();
        _$ul.html(_s.join(''));
        _$ul.find("li").click(function() { _self.__xuanZhong(this); return false; });

        _$obj.siblings().find("a").css({ color: "" });
        _$obj.find("a").css({ color: "#ff0000" });
    },
    __initChengShi: function() {
        var _self = this;
        var _s = [];
        _s.push('<div class="header">');
        _s.push('<div class="leixing" i_leixing="0">&nbsp;<a href="javascript:void(0)">热门</a></div>');
        _s.push('<div class="leixing leixing1" i_leixing="1">&nbsp;<a href="javascript:void(0)">ABCDEF</a></div>');
        _s.push('<div class="leixing leixing1" i_leixing="2">&nbsp;<a href="javascript:void(0)">GHIJ</a></div>');
        _s.push('<div class="leixing leixing1" i_leixing="3">&nbsp;<a href="javascript:void(0)">KLMN</a></div>');
        _s.push('<div class="leixing leixing1" i_leixing="4">&nbsp;<a href="javascript:void(0)">OPQRST</a></div>');
        _s.push('<div class="leixing leixing1" i_leixing="5">&nbsp;<a href="javascript:void(0)">UVWXYZ</a></div>');
        _s.push('<div class="close"><a href="javascript:void(0)"><b>×</b></a></div>');
        _s.push('</div>');

        _s.push('<ul id="i_ul_jipiaochengshi">');
        _s.push('</ul>');

        this.__getDiv().html(_s.join(''));

        this.__getDiv().find("div.leixing").click(function() { _self.__initChengShiLi(this); return false; });
        this.__getDiv().find("div.close").click(function() { _self.__hideDiv(); });
    },
    __init: function() {
        this.__getDiv().addClass("divJiPiaoChengShi");
        this.__initChengShi();
        this.__getDiv().find("div.leixing")[0].click();
    }
};

$(document).ready(function() {
    ticketLKE.__init();
    $(document).click(function(e) {
        if (document.all) e = event;
        var ele = e.target == undefined ? event.srcElement : e.target;

        if ($(ele).attr("jipiao_city_input") != 1) ticketLKE.__hideDiv();
        ticketLKE.hWeiPiPei();
    });
});
