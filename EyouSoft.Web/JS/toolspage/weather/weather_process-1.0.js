/**
 * 天气信息处理静态类
 * @version 1.0
 */
var WeatherProcesser = {
    //显示温度
    getTemperature: function(temperature1,temperature2){
        var res;
		if(temperature1 =='' && temperature2 == ''){
			return '';
		}
        if (temperature1 == temperature2) {
            res = temperature1 + "℃";
        }
        else {
            res = temperature1 + "℃～" + temperature2 + "℃";
        }
        return res;
    },
    
    //显示天气状况
    getStatus: function(status1, status2){
        var res;
		if(status1 == '' && status2 == ''){
			return '';	
		}
        if (status1 == status2) {
            res = status1;
        }
        else {
            res = status1 + "转" + status2;
        }
        return res;
    },
    
    //天气大图标
    getBFigure: function(figure1, figure2, status1,status2){
        var res;
		if(figure1 == '' && figure2 == ''){
			return '';	
		}
        if (figure1 == figure2) {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_big.gif title=" + status1 + ">";
        }
        else {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_big.gif title=" + status1 + "> - <img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure2 + "_big.gif title=" + status2 + ">";
        }
        return res;
    },
    
    //天气中图标
    getMFigure: function(figure1, figure2, status1,status2){
        var res;
		if(figure1 == '' && figure2 == ''){
			return '';	
		}
        if (figure1 == figure2) {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_mid.gif title=" + status1 + ">";
        }
        else {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_mid.gif title=" + status1 + "> - <img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure2 + "_mid.gif title=" + status2 + ">";
        }
        return res;
    },
    
    //天气小图标
    getSFigure: function(figure1, figure2, status1,status2){
        var res;
		if(figure1 == '' && figure2 == ''){
			return '';	
		}
		var status = this.getStatus(status1,status2);
        if (figure1 == figure2) {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_small.gif title=" + status + ">";
        }
        else {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_small.gif title=" + status + "><img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure2 + "_small.gif title=" + status + ">";
        }
        return res;
    },
    
    //显示日期
    getDate: function(year1, month1, day1, year2, month2, day2){
        var res = year1 + "年" + month1 + "月" + day1 + "日-";
        if (year1 != year2) {
            res += year2 + "年";
        }
        else {
            if (month1 != month2) {
                res += month2 + "月";
            }
        }
        res += day2 + "日";
        return res;
    },
    
    //显示风向
    getDirection: function(direction1, direction2){
        var res = "";
        if (direction1 != "" && direction2 != "" && direction1 != direction2) {
            res = direction1 + "转" + direction2;
        } else if (direction1 != "" && direction2 != "" && direction1 == direction2) {
			res = direction1;
		} else if (direction1 != "" && direction2 == "") {
			res = direction1;
		} else if (direction2 != "" && direction1 == "") {
			res = direction2;
		} else {
			res = "-";
		}
        return res;
    },
    
    //显示风力
    getPower: function(power1, power2){
        var res = "";
        if (power1 == power2 && power1 == "") {
            res = "小于3级";
        }
        else 
            if (power1 != "" && power2 == "") {
                res = power1 + "级";
            }
            else 
                if (power2 != "" && power1 == "") {
                    res = power2 + "级";
                }
                else 
                    if (power1 != "" && power2 != "" && power1 != power2) {
                        res = power1 + "级 至 " + power2 + "级";
                    }
                    else 
                        if (power1 != "" && power2 != "" && power1 == power2) {
                            res = power1 + "级";
                        }
        return res;
    },
    
    //显示空气质量
    getPollution: function(pollution){
        var res = "";
        if (pollution == "") {
            res = "-";
        }
        else 
            if (pollution == 1) {
                res = "优";
            }
            else 
                if (pollution == 2) {
                    res = "良";
                }
                else 
                    if (pollution == 3) {
                        res = "中";
                    }
                    else 
                        if (pollution == 4) {
                            res = "较差";
                        }
                        else {
                            res = "很差";
                        }
        return res;
    },
    
    //显示紫外线强度
    getZWX: function(zwx){
        var res = "";
        if (zwx == "") {
            res = "-";
        }
        else 
            if (zwx == 0 || zwx == 1 || zwx == 2) {
                res = "最弱";
            }
            else 
                if (zwx == 3 || zwx == 4) {
                    res = "弱";
                }
                else 
                    if (zwx == 5 || zwx == 6) {
                        res = "中等";
                    }
                    else 
                        if (zwx == 7 || zwx == 8) {
                            res = "强";
                        }
                        else {
                            res = "很强";
                        }
        return res;
    },
    
    //显示舒适度
    getSSD: function(ssd){
        var res;
        if (ssd == "") {
            res = "-";
        }
        else 
            if (ssd == 1) {
                res = "舒适";
            }
            else 
                if (ssd == 2) {
                    res = "较舒适";
                }
                else 
                    if (ssd == 3) {
                        res = "一般舒适";
                    }
                    else 
                        if (ssd == 4) {
                            res = "较不舒适";
                        }
                        else {
                            res = "不舒适";
                        }
        return res;
    },
    
    //显示洗车状况
    getXCZ: function(){
        var res;
        if (xcz == "") {
            res = "-";
        }
        else 
            if (xcz == 1) {
                res = "适宜洗车";
            }
            else 
                if (xcz == 2) {
                    res = "较适宜洗车";
                }
                else 
                    if (xcz == 3) {
                        res = "较不适宜洗车";
                    }
                    else {
                        res = "不宜洗车";
                    }
        return res;
    }
};



