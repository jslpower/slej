<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.HotelEdit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑酒店</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script src="/JS/HotelJSData.js" type="text/javascript"></script>

    <link href="/Css/tipsy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery.tipsy.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>酒店名称:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txthotelname" name="txthotelname" class="inputtext formsize180"
                        valid="required" errmsg="请输入酒店名称!" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    英文名称:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtEnName" MaxLength="30" name="txtEnName" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>是否热门:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <label>
                        <input type="checkbox" id="isHot" name="isHot" runat="server">
                        是</label>
                </td>
                <th width="90" height="30" align="center">
                    是否推荐:
                </th>
                <td bgcolor="#E3F1FC">
                    <label>
                        <input type="checkbox" id="isRecommend" name="isRecommend" runat="server">
                        是</label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    地图信息:
                </th>
                <td bgcolor="#E3F1FC">
                    <a id="Setmap" href="javascript:;">地图信息</a> (<label id="X" runat="server"></label>,<label
                        id="Y" runat="server"></label>)
                    <asp:HiddenField runat="server" ID="jingdu" Value="0" />
                    <asp:HiddenField runat="server" ID="weidu" Value="0" />
                </td>
                <th width="90" height="30" align="center">
                    酒店星级:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <select class="inputselect" id="hotellv" name="hotellv">
                        <%=HotelLv%>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    客服电话:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txtKefuTel" MaxLength="30" name="txtKefuTel" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    邮编:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtpost" MaxLength="30" name="txtpost" runat="server" class="inputtext formsize120"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    联系手机:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txtMobile" MaxLength="30" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                </th>
                <td bgcolor="#E3F1FC">
                </td>
            </tr>
            <tr class="odd" style="display: none;">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>城市代码:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <input type="text" class="inputtext formsize80" runat="server" id="searchcode" />
                    <select id="ddl_CityCode" name="ddl_CityCode" class="inputselect">
                    </select>
                    (注：文本框输入城市拼音,帮助您筛选)
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>酒店所在城市:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <select id="SelectHotelProvice" name="HotelProvice" style="width:130px" class="inputselect">
                        <%=BindHotelProvice(htprovice)%>
                    </select>
                    <select id="SelectHotelCity" name="SelectHotelCity" style="width:130px" class="inputselect">
                    </select>
                </td>
            </tr>
            <%--<tr class="odd">
                <th width="90" height="30" align="center">
                    国家代码:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <span class="fred">*</span>省份:
                    <select id="ddlprovince" class="inputselect proandcity" valid="required" errmsg="请选择省份!">
                    </select>
                    <input runat="server" id="hidproid" type="hidden" value="0" />
                    <span class="fred">*</span>城市:
                    <select id="ddlcity" class="inputselect proandcity" valid="required" errmsg="请选择城市!">
                    </select>
                    <input runat="server" id="hidcityid" type="hidden" value="0" />
                    县区
                    <select id="ddlarea" class="inputselect proandcity">
                    </select>
                    <input runat="server" id="hidareaid" type="hidden" value="0" />
                </td>
            </tr>--%>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    结算方式:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <label>
                        <input runat="server" type="radio" id="radxianjie" name="jiesuan" checked />现结</label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    中文地址:
                </th>
                <td bgcolor="#E3F1FC" colspan="3" width="400px">
                    <asp:TextBox ID="txtaddress" CssClass="inputtext formsize260" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    开业时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtYear" errmsg="必须是数字!" valid="isNumber" onkeyup="this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="4" CssClass="inputtext formsize80"
                        runat="server"></asp:TextBox>年
                </td>
                <th width="90" height="30" align="center">
                    装修时间:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox runat="server" ID="txtFitment" CssClass="inputtext formsize80" errmsg="必须是数字!"
                        valid="isNumber" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                        MaxLength="4"></asp:TextBox>年
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    房间总数:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txtroomcount" CssClass="inputtext formsize50" runat="server"></asp:TextBox>间
                </td>
                <th width="90" height="30" align="center">
                    楼层数:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtfloorcount" CssClass="inputtext formsize50" runat="server"></asp:TextBox>层
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    酒店详细介绍:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txthoteldesc" valid="required" errmsg="请填写酒店详细介绍!"
                        Height="60" name="txthoteldesc" runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    交通情况:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txttraffic" Height="80" name="txttraffic" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    额外收费:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtRemark" Height="80" name="txtRemark" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="40" bgcolor="#E3F1FC" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnsave" class="save" href="javascript:;">保存</a>
                                    </td>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnback" class="back" href="javascript:;">返回</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br /><br />
    </form>
</body>
</html>

<script type="text/javascript">
    $(function() {
        HotelEdit.PageInit();

        $("#ddlprovince").change(function() { diBiao.change("shengfen"); });
        $("#ddlcity").change(function() { diBiao.change("chengshi"); });
        $("#ddlarea").change(function() { diBiao.change("xianqu"); });

        setTimeout(function() {
            diBiao.change("shengfen");
            diBiao.change("chengshi");
            diBiao.change("xianqu");
            HotelEdit.SetHotelMarkList();
        }, 500);
    });
    var SearchTimeOut = null;
    var HotelEdit = {
        PageInit: function() {
            pcToobar.init({
                pID: "#ddlprovince",
                cID: "#ddlcity",
                xID: "#ddlarea",
                pSelect: "<%=this.ProvinceId %>",
                cSelect: "<%=this.CityId %>",
                xSelect: "<%=this.AreaId %>",
                comID: '1'
            });
            $(".proandcity").change(function() {
                $(this).next("input[type='hidden']").val($(this).val());
            });

            /*$("#ddlprovince").change(function() {
            $("#Td_ChbLankId").html("");
            });
            $("#ddlcity").change(function() {
            HotelEdit.BindArea($(this).val());
            });*/

            //$("#<%= searchcode.ClientID %>").tipsy({ fade: true, content: '城市中文、拼音、三字码筛选', gravity: "s" });
            HotelEdit.SetMapInfo();
            //HotelEdit.AddItemToCity("<%=CityId %>");
            KEditer.init("<%=txthoteldesc.ClientID %>");
            $("#btnsave").click(function() {
                KEditer.sync();
                if (!HotelEdit.CheckForm()) {
                    return false;
                }
                $("#btnsave").html("提交中...").unbind("click").css({ "color": "#999999"
                });
                HotelEdit.GoAjax('/WebMaster/HotelManage/HotelEdit.aspx?type=save&dotype='
+ '<%=Request.QueryString["dotype"] %>' + "&id=" + '<%=Request.QueryString["id"] %>',
$(this));
                return false;
            })
            $("#btnsave").html("保存").css({ "color": "" });
            $("#btnback").click(function() {
                location.href = "/WebMaster/HotelManage/HotelList.aspx";
                return false;
            })
            //城市文本框按键事件
            //            $("#<%= searchcode.ClientID %>").keyup(function() {
            //                if (SearchTimeOut != null) {
            //                    clearTimeout(SearchTimeOut);
            //                }
            //                SearchTimeOut = setTimeout(HotelEdit.TxtKeyUp, 200);
            //            });
            //            //加载城市数据
            //            if ('<%=CityCode %>' != "") {
            //                HotelEdit.AddItemToCity('<%=CityCode %>');
            //            }
            //            else {
            //                HotelEdit.AddItemToCity("Load");
            //            }
            //$("#ddl_CityCode").change(function() {
            //    HotelEdit.BindArea($(this).val());
            //})

        },
        GoAjax: function(url, obj) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() {
                            location.href = "/WebMaster/HotelManage/HotelList.aspx";
                        });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg, function() {
                            HotelEdit.PageInit();
                        });
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg, function() {
                        HotelEdit.PageInit();
                    });
                }
            });
        },
        CheckForm: function() {
            return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "alert");
        },
        SetMapInfo: function() {
            //设置公司经纬度
            $("#Setmap").click(function() {
                var data = { weidu: $("#weidu").val(), jindu: $("#jingdu").val() };
                if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype").ToLower() %>' == "add") {
                    //                    if ($("#ddl_CityCode").val() != "" && CityList != null && CityList.length > 0) {
                    //                        for (var i = 0; i < CityList.length; i++) {
                    //                            if ($("#ddl_CityCode").val() == CityList[i].C) {
                    //                                data.cName = CityList[i].CN;
                    //                                break;
                    //                            }
                    //                        }
                    //                    }
                    $("#ddlcity").find("option").each(function() {
                        if ($(this).val() == $("#ddlcity").val() && $(this).val() != "" && $(this).val() != "0") {
                            data.cName = $(this).text();
                        }
                    });
                }
                var url = "/WebMaster/ScenicAndTicketManage/SetGoogleMap.aspx?" + $.param(data);
                var title = "设置地图";
                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 480, width: 800,
                    draggable: false
                })
                return false;
            });
        },
        //        BindArea: function(citycode) {
        //            $("#Td_ChbLankId").html("");
        //            $.ajax({
        //                url: "HotelEdit.aspx?type=BinLankId&arg=" + citycode,
        //                cache: false,
        //                type: "post",
        //                success: function(result) {
        //                    if (result != "error") {
        //                        var list = eval(result);
        //                        for (var i = 0; i < list.length; i++) {
        //                            $("#Td_ChbLankId").append("<input type=\"checkbox\" name=\"chkboxLankid\" value=\"" + list[i].Id + "\" id=\"cbxl_" + i + "\" /><label for=\"cbxl_" + i + "\">" + list[i].Por + "</label>");
        //                            if (i % 7 == 0 && i > 0) {
        //                                $("#Td_ChbLankId").append("<br>");
        //                            }
        //                        }

        //                        HotelEdit.SetHotelMarkList();
        //                    }
        //                },
        //                error: function() {
        //                    tableToolbar._showMsg("操作失败!");
        //                }
        //            });
        //        },
        //        bindHotelCity: function() {
        //            $("#ddl_CityCode").empty();
        //            $("<option value=''>--请选择--</option>").appendTo($("#ddl_CityCode"));
        //            if (CityList.length > 0) {
        //                for (var i = 0; i < CityList.length; i++) {
        //                    var Ping = CityList[i].P;
        //                    var Code = CityList[i].C;
        //                    var cityName = CityList[i].CN;
        //                    $("<option value='" + Code + "'>" + Ping + cityName + Code +
        //"</option>").appendTo($("#ddl_CityCode"));
        //                }
        //            }
        //        },
        //按键事件
        //        TxtKeyUp: function() {
        //            var val = $("#<%= searchcode.ClientID %>").val();
        //            if ($.trim(val) != "") {
        //                HotelEdit.AddItemToCity(val);
        //            }
        //        },
        //添加城市
        //        AddItemToCity: function(val) {
        //            if (val == "Load") {
        //                HotelEdit.bindHotelCity();
        //            } else {
        //                HotelEdit.bindHotelCity();
        //                if ($.trim(val) != "") {
        //                    if (CityList.length > 0) {
        //                        for (var i = 0; i < CityList.length; i++) {
        //                            var Ping = CityList[i].P;
        //                            var Code = CityList[i].C;
        //                            var cityName = CityList[i].CN;
        //                            var indexVal = (Ping + cityName + Code).toUpperCase().indexOf(val.toUpperCase());
        //                            if (indexVal == 0) {
        //                                $("#ddl_CityCode").val(Code);
        //                                //HotelEdit.BindArea(Code);
        //                                return "1";
        //                            }
        //                            if (indexVal > 0) {
        //                                $("#ddl_CityCode").val(Code);
        //                                //HotelEdit.BindArea(Code);
        //                                return "2";
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        },
        SetHotelMarkList: function() {
            var markList = "<%= CheckedHotelMarkId %>";
            if (markList == "") return;

            var ids = markList.split(",");
            if (ids == null || ids.length <= 0) return;

            $("#Td_ChbLankId").find("input[name='chkboxLankid']").each(function() {
                for (var i = 0; i < ids.length; i++) {
                    if ($(this).val() == ids[i]) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
        }
    }

    var diBiao = {
        shengFen: function() {
            $("#Td_ChbLankId").html("");
        },
        chengShi: function() {
            var $obj = $("#ddlcity");
            var _items = this.getDiBiaos("chengshi", $obj.val());

            if (_items == null || _items.length == 0) $("#Td_ChbLankId").html("");
            else this.initDiBiaos(_items);
        },
        xianQu: function() {
            var $obj = $("#ddlarea");
            if ($obj.val() == "") { this.chengShi(); return; }

            var _items = this.getDiBiaos("xianqu", $obj.val());

            if (_items == null || _items.length == 0) $("#Td_ChbLankId").html("");
            else this.initDiBiaos(_items);
        },
        initDiBiaos: function(_items) {
            var s = [];
            for (var i = 0; i < _items.length; i++) {
                s.push("<input type=\"checkbox\" name=\"chkboxLankid\" value=\"" + _items[i].Id + "\" id=\"cbxl_" + i + "\" /><label for=\"cbxl_" + i + "\">" + _items[i].Name + "</label>");
                if (i % 7 == 0 && i > 0) s.push("<br/>");
            }
            $("#Td_ChbLankId").html(s.join(''));
        },
        getDiBiaos: function(type, id) {
            var _data = { txtType: type, txtId: id };
            var _items = [];
            $.ajax({
                type: "GET", url: "/ashx/Handler.ashx?dotype=dibiao", data: _data, cache: false, dataType: "json", async: false,
                success: function(response) {
                    _items = response;
                }
            });
            return _items;
        },
        change: function(type) {
            if (type == "shengfen") this.shengFen();
            if (type == "chengshi") this.chengShi();
            if (type == "xianqu") this.xianQu();
        }
    };
</script>

<script type="text/javascript">
 var htcitycode='<%= htcitycode %>';
    $("#SelectHotelProvice").change(function() {
        PageDataing.InteCity();
    })
    var PageDataing = {
        InteCity: function() {
            var checkValue = $("#SelectHotelProvice").val();
            $.ajax({
                type: "post", url: "/ashx/CityHandler.ashx?dotype=city&provicename=" + encodeURI(checkValue), dataType: "json",
                success: function(response) {
                $("#SelectHotelCity").html("<option value='0' >请选择</option>");
                    for (var i = 0; i < response.length; i++) {
                        if (htcitycode != "" && htcitycode == response[i].CityCode) {
                            $("#SelectHotelCity").append("<option value=" + response[i].CityCode + " selected='selected'>" + response[i].AreaName + "</option>");
                        }
                        else {
                            $("#SelectHotelCity").append("<option value=" + response[i].CityCode + " >" + response[i].AreaName + "</option>");
                        }
                    }

                }
            });
        }
    }
    window.onload = function() {
    PageDataing.InteCity();
    }
    
</script>

