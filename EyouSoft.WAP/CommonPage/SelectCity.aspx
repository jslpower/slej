<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCity.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.SelectCity" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/jipiao.sanzima.js" type="text/javascript"></script>



<script type="text/javascript">
    $(function() {
        $("#Umdli li").click(function() {
            var idname = $(this).html();
            if (idname != "热门") {
                var top = $("#Div" + idname).offset().top;
                $("html,body").animate({ scrollTop: (top - 100) }, 1000);
            }
            else {
                var top = $("#DivTop").offset().top;
                $("html,body").animate({ scrollTop: (top - 100) }, 1000);
            }
        });

    });
    
</script>
</head>
<body>
    <form id="myform" method="post">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="选择城市" />
   <div class="city_letter_fixed">
        <div class="city_letter_mt">
            <ul id="Umdli" class="city_letter">
                <li>热门</li>
                <li>A</li>
                <li>B</li>
                <li>C</li>
                <li>D</li>
                <li>E</li>
                <li>F</li>
                <li>G</li>
                <li>H</li>
                
                <li>J</li>
                <li>K</li>
                <li>L</li>
                <li>M</li>
                <li>N</li>
                
                <li>P</li>
                <li>Q</li>
                <li>R</li>
                <li>S</li>
                <li>T</li>
               
                <li>W</li>
                <li>S</li>
                <li>Y</li>
                <li>Z</li>
            </ul>
        </div>
    </div>
    <div class="warp">
        <div class="jq_search" style="background: #fff;">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="text" placeholder="请输入城市拼音/中文" class="input_txt floatL" value="" id="citySeachBox" />
                    <input name="" type="button" class="icon_search_i floatR">
                </div>
            </div>
        </div>
        <div id="slider" class="city_list" style="padding-top: 56px;">
            <div class="slider-content">
                <ul>
                    <li class="city_li">
                        <div class="city_group_title" id="DivTop">
                            热门城市</div>
                        <ul id="remen" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivA" class="city_group_title">
                            A</div>
                        <ul id="A" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivB" class="city_group_title">
                            B</div>
                        <ul id="B" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivC" class="city_group_title">
                            C</div>
                        <ul id="C" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivD" class="city_group_title">
                            D</div>
                        <ul id="D" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivE" class="city_group_title">
                            E</div>
                        <ul id="E" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivF" class="city_group_title">
                            F</div>
                        <ul id="F" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivG" class="city_group_title">
                            G</div>
                        <ul id="G" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivH" class="city_group_title">
                            H</div>
                        <ul id="H" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivI" class="city_group_title">
                            I</div>
                        <ul id="I" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivJ" class="city_group_title">
                            J</div>
                        <ul id="J" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivK" class="city_group_title">
                            K</div>
                        <ul id="K" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivL" class="city_group_title">
                            L</div>
                        <ul id="L" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivM" class="city_group_title">
                            M</div>
                        <ul id="M" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivN" class="city_group_title">
                            N</div>
                        <ul id="N" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivO" class="city_group_title">
                            O</div>
                        <ul id="O" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivP" class="city_group_title">
                            P</div>
                        <ul id="P" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivQ" class="city_group_title">
                            Q</div>
                        <ul id="Q" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivR" class="city_group_title">
                            R</div>
                        <ul id="R" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivS" class="city_group_title">
                            S</div>
                        <ul id="S" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivT" class="city_group_title">
                            T</div>
                        <ul id="T" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivU" class="city_group_title">
                            U</div>
                        <ul id="U" class="city_group_box">
                        </ul>
                    </li>
                   
                    <li class="city_li">
                        <div id="DivW" class="city_group_title">
                            W</div>
                        <ul id="W" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivX" class="city_group_title">
                            X</div>
                        <ul id="X" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivY" class="city_group_title">
                            Y</div>
                        <ul id="Y" class="city_group_box">
                        </ul>
                    </li>
                    <li class="city_li">
                        <div id="DivZ" class="city_group_title">
                            Z</div>
                        <ul id="Z" class="city_group_box">
                        </ul>
                    </li>
                </ul>
            </div>
            <input type="hidden" name="startcity" id="startcity" value="<%= EyouSoft.Common.Utils.GetFormValue("startcity") %>" />
            <input type="hidden" name="endcity" id="endcity" value="<%= EyouSoft.Common.Utils.GetFormValue("endcity") %>" />
            <input type="hidden" name="rili" id="rili" value="<%= EyouSoft.Common.Utils.GetFormValue("rili") %>" />
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            url: '<%= HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString()  %>',
            initCityList: function(guolv) {
                var dataBox = [];
                if (guolv != "" && guolv != 'undefined' && guolv != null) {
                    for (var k = 0; k < jiPiaoSanZiMaData.length; k++) {
                        if (jiPiaoSanZiMaData[k].CityName.toUpperCase().indexOf(guolv.toUpperCase()) >= 0
                        || jiPiaoSanZiMaData[k].PY2.toUpperCase().indexOf(guolv.toUpperCase()) >= 0
                        || jiPiaoSanZiMaData[k].PY1.toUpperCase().indexOf(guolv.toUpperCase()) >= 0) {
                            dataBox.push(jiPiaoSanZiMaData[k]);
                        }
                    }
                }
                else {
                    dataBox = jiPiaoSanZiMaData;
                }

                $(".city_group_box").html('');


                if (dataBox == jiPiaoSanZiMaData) {
                    var rm = "";
                    for (var i = 0; i < 12; i++) {
                        if (dataBox[i].IsReDian == true) {
                            rm += '<li class="ckLi" data-Code=' + dataBox[i].Code + '>' + dataBox[i].CityName + '</li>';
                        }
                    }
                    $("#remen").html(rm);
                }

                for (var j = 0; j < dataBox.length; j++) {
                    $("#" + dataBox[j].PY3.replace(/(^\s*)|(\s*$)/g, "")).append('<li  class="ckLi" data-Code=' + dataBox[j].Code + '>' + dataBox[j].CityName + '</li>');
                }
                $(".city_group_box").each(function() {
                    if ($(this).html().replace(/(^\s*)|(\s*$)/g, "") == "") {
                        $(this).parent().hide();
                    } else {
                        $(this).parent().show();
                    }
                })
                pageOpt.initClick();
            },

            initClick: function() {
                $(".ckLi").click(function() {
                    var word = $(this).text().replace(/(^\s*)|(\s*$)/g, "");
                    var code = $(this).attr("data-Code").replace(/(^\s*)|(\s*$)/g, "");
                    var type = '<%= EyouSoft.Common.Utils.GetQueryStringValue("type") %>';

                    if (type == "0") {
                        $("#startcity").val(word + "-" + code);
                    }
                    else {
                        $("#endcity").val(word + "-" + code);
                    }
                    document.getElementById("myform").submit();
                })
            }

        }

        $(function() {
            pageOpt.initCityList();

            if (pageOpt.url != "" && pageOpt.url != "undefined") {
                document.getElementById("myform").action = pageOpt.url;
            }

            //绑定chang事件
            var bind_name = "input"; //定义所要绑定的事件名称
            if (navigator.userAgent.indexOf("MSIE") != -1) bind_name = "propertychange"; //判断是否为IE内核 IE内核的事件名称要改为propertychange
            $("#citySeachBox").bind(bind_name, function() {
                pageOpt.initCityList($(this).val().replace(/(^\s*)|(\s*$)/g, ""));
            })
        })
    </script>

</body>
</html>
