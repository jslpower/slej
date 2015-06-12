<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="XianLuBox.aspx.cs" Inherits="EyouSoft.Web.XianLuBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $(".tchuang tr:even").addClass("tb_even");
        })
    </script>

    <style>
        .tixing
        {
            line-height: 30px;
        }
        .hline
        {
            text-decoration: line-through;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <div id="istijiao" class="line_xx_box">
        <table width="908" border="0" class="tchuang">
            <tr>
                <th colspan="2" align="right" width="100px">
                    线路名称&nbsp;&nbsp;&nbsp;&nbsp;：
                </th>
                <td colspan="5" align="left">
                    <asp:Label ID="lblxianlu" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="2" align="right">
                    发团日期&nbsp;&nbsp;&nbsp;&nbsp;：
                </th>
                <td colspan="5" align="left">
                    <input type="hidden" value="<%= lblfatuan.Text%>" name="hidLDate" />
                    <asp:Label ID="lblfatuan" runat="server" Text=""></asp:Label><em class="jiage"><span
                        class="fontblue" style="padding-left: 45px;">余位：<asp:Label ID="lblsy" runat="server"
                            Text=""></asp:Label>位</span></em>
                </td>
            </tr>
            <tr class="jiage">
                <th colspan="2" align="right">
                    相关价格&nbsp;&nbsp;&nbsp;&nbsp;：
                </th>
                <td colspan="5" align="left">
                    &nbsp;
                </td>
            </tr>
            <tr class="jiage">
                <td colspan="7" align="center">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="price_table">
                        <asp:Literal ID="litHeadHtml" runat="server"></asp:Literal>
                        <asp:Literal ID="litCRHtml" runat="server"></asp:Literal>
                        <asp:Literal ID="litETHtml" runat="server"></asp:Literal>
                    </table>
                </td>
            </tr>
            <tr>
                <th colspan="2" align="right">
                    成人数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：
                </th>
                <td colspan="3" align="left">
                    <span class="dindan_num"><a href="javascript:;" class="ajisuan">-</a><input id="txtcrs"
                        name="txtcrs" type="text" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("crs") %>"
                        class="renshu" min="1" valid="required|isInt|range" errmsg="成人数不可为空!|数字错误!|成人数必须大于0！" /><a
                            href="javascript:;" class="ajisuan">+</a></span> 人
                </td>
                <th align="right">
                    儿童数：（2-12岁）（不占床）
                </th>
                <td align="left">
                    <span class="dindan_num"><a href="javascript:;" class="ajisuan">-</a><input name="txtets"
                        id="txtets" type="text" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("ets") %>"
                        class="renshu" /><a href="javascript:;" class="ajisuan">+</a></span> 人
                </td>
            </tr>
            <tr>
                <th colspan="2" align="right">
                    <span class="fontred">*</span>&nbsp;游客联系人：
                </th>
                <td colspan="3" align="left">
                    <input name="yklxr" type="text" id="yklxr" size="15" class="tc_inputbk formsize100"
                        valid="required" errmsg="游客联系人必须填写!" />
                </td>
                <th align="right">
                    <span class="fontred">*</span>&nbsp;游客联系人手机&nbsp;&nbsp;&nbsp;&nbsp;：
                </th>
                <td align="left">
                    <input name="yksj" type="text" id="yksj" size="15" class="tc_inputbk formsize100"
                        valid="required|isMobile" errmsg="游客联系人手机必须填写!|手机号码有误！" />
                </td>
            </tr>
            <tr>
                <th colspan="2" align="right">
                    预定人姓名：
                </th>
                <td align="left">
                    <asp:Label ID="lblYRDXM" runat="server" Text="Label"></asp:Label>
                </td>
                <th align="right">
                    预定人身份：
                </th>
                <td align="left">
                    <asp:Label ID="lblYDRSF" runat="server" Text="Label"></asp:Label>
                </td>
                <th align="right">
                    预定人手机：
                </th>
                <td align="left">
                    <asp:Label ID="lblYDRSJ" runat="server" Text="Label"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <th colspan="2" align="right">
                    交易总金额：
                </th>
                <td colspan="5" align="left" class="jstd">
                </td>
            </tr>
            <tr class="jiage">
                <td colspan="7" align="left">
                    <div class="tixing">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    <table id="addTable" style="width: 99%">
                        <th align="center">
                            姓名
                        </th>
                        <th align="center">
                            性别
                        </th>
                        <th align="center">
                            类型
                        </th>
                        <th align="center">
                            证件类别
                        </th>
                        <th align="center">
                            证件号
                        </th>
                        <th align="center">
                            联系方式<span class="nojiacu">（手机）</span>
                        </th>
                        <th align="center" class="jiage">
                            操作
                        </th>
            </tr>
            <tr class="tempRow">
                <td align="center">
                    <input name="txtYouKeName" type="text" size="8" class="tc_inputbk formsize100" />
                </td>
                <td align="center">
                    <select name="txtYouKeGender">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Gender),new string[]{"2"}),"" ) %>
                    </select>
                </td>
                <td align="center">
                    <select name="txtYouKeLeiXing">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.YouKeType)), "" )%>
                    </select>
                </td>
                <td align="center">
                    <select name="txtYouKeZhengJianLeiXing">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.CardType),new string[]{"0"}), "" )%>
                    </select>
                </td>
                <td align="center">
                    <input type="text" name="txtYouKeZhengJianHao" class="tc_inputbk formsize180" />
                </td>
                <td align="center">
                    <input type="text" name="txtYouKeTelephone" class="tc_inputbk formsize180" />
                </td>
                <td class="jiage">
                    <a href="javascript:void(0)" class="delbtn1">删除</a>
                </td>
            </tr>
        </table>
        </td>
        <tr>
            <th colspan="2" align="right">
                备注&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：
            </th>
            <td colspan="5" align="left">
                <textarea name="txtarea" class="tc_inputbk" id="txtarea" style="width: 700px; height: 100px;"></textarea>
            </td>
        </tr>
        </table>
        <table width="90%" border="0" style="margin: 15px auto;">
            <tr>
                <td align="center" class="tjbtn02">
                    <a id="btnSave" data-id="1" href="javascript:;">提 交</a><a href="javascript:;" id="btnQuXiao"
                        style="display: none">返回编辑</a>
                </td>
            </tr>
        </table>
        <input type="hidden" name="hidcrj" id="hidcrj" value="" />
        <input type="hidden" name="hidetj" id="hidetj" value="" />
        <input type="hidden" name="hidzj" id="hidzj" />
        <input type="hidden" name="hidtourid" id="hidtourid" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("tourid") %>" />
        <input type="hidden" name="hidxianlu" id="hidxianlu" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("id") %>" />
        <input type="hidden" name="hangban" id="hangban" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("hangban") %>" />
        <input type="hidden" name="type" id="type" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>" />
        <input type="hidden" name="jsc" id="jsc" value="<%=jsjcr %>" />
        <input type="hidden" name="jse" id="jse" value="<%=jsjet%>" />
        <input type="hidden" name="gbcrj" id="gbcrj" value="<%=gbcrj %>" />
        <input type="hidden" name="gbetj" id="gbetj" value="<%=gbetj%>" />
    </div>
    </form>

    <script type="text/javascript">
        var inputdata = null;
        var fanhuibianji = null;
        var beizhuxinxi = null;
        var pageData = {
            CreatBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.url,
                    title: data.title,
                    modal: true,
                    width: '500px',
                    height: '300px'
                });
            },
            initAutoAdd: function() {
                var crs = parseInt($("#txtcrs").val());
                var ets = parseInt($("#txtets").val());
                var intCount = crs + ets; //统计总人数

                if (intCount > $(".tempRow").length) {
                    var addRow = intCount - $(".tempRow").length;
                    for (var i = 0; i < addRow; i++) {
                        _temp = $(".tempRow").eq(0).clone(true);
                        _temp.find("input").val("");
                        if (i < addRow) {
                            $("#addTable").append(_temp);
                        }
                    }
                } //添加
                if ($(".tempRow").length > intCount) {
                    for (var i = $(".tempRow").length; i > intCount; i--) {
                        if ($(".tempRow").length > intCount && intCount > 0) {
                            $(".tempRow").eq($(".tempRow").length - 1).remove();
                        }
                    }
                } //删除
            },
            initDelRow: function() {
                $(".delbtn1").click(function() {
                    if ($(".tempRow").length == 1) {
                        alert("最少保留一位游客信息！");
                        return false;
                    }
                    if (tableToolbar.getInt($("#txtets").val()) > 0) {
                        $("#txtets").val(tableToolbar.getInt($("#txtets").val()) - 1)
                    }
                    else {
                        $("#txtcrs").val(tableToolbar.getInt($("#txtcrs").val()) - 1)
                    }
                    $(this).closest(".tempRow").remove();
                })
            },
            initClick: function() {
                var maxCount = tableToolbar.getInt($("#<%=lblsy.ClientID %>").html());

                $("a.ajisuan").click(function() {
                    var crs_txt = tableToolbar.getInt($("#txtcrs").val());
                    var ets_txt = tableToolbar.getInt($("#txtets").val());
                    var getNum = $(this).parent().find("input").eq(0);
                    if ($(this).html() == "+") {
                        if ((crs_txt + ets_txt) > maxCount) {
                            alert("合计人数不可超过余位数！");
                            return false;
                        }
                        getNum.val(tableToolbar.getInt(getNum.val()) + 1);

                    }
                    else {
                        if (tableToolbar.getInt(getNum.val()) > 1) {
                            getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                        } else {
                            getNum.val(0);
                        }
                    }
                    pageData.pageHtml();
                })
            }, //end
            pageSave: function() {
                if (ValiDatorForm.validator($("#btnSave").closest("form").get(0), "parent")) {
                    if ($('#btnSave').attr("data-id") == 1) {
                        inputdata = $("#btnSave").closest("form").serialize();
                        fanhuibianji = $("#istijiao").clone(true);
                        beizhuxinxi = $("#txtarea").val();
                        $("#btnSave").html("确认提交");
                        var elements = $("#btnSave").closest("form").find('input[type=text]');
                        pageData.RemoveControl(elements);
                        //textarea控件
                        elements = $("#btnSave").closest("form").find('textarea');
                        pageData.RemoveControl(elements);

                        //select 控件
                        elements = $("#btnSave").closest("form").find('select');
                        pageData.RemoveControl(elements);
                        $('.ajisuan').remove();

                        $('.jiage').remove();
                        $('span[class=dindan_num]').removeAttr("class");
                        $("#btnQuXiao").css('display', '');
                        $('#btnSave').attr("data-id", 2);
                    }
                    else {
                        $("#btnSave").html("正在提交");
                        $("#btnSave").unbind("click");
                        $.ajax({
                            type: "POST",
                            url: window.location.href + "&save=save",
                            data: inputdata,
                            cache: false,
                            dataType: "json",
                            success: function(response) {
                                if (response.result == "1") {
                                    alert(response.msg);
                                    var type = $("#type").val();
                                    if (type == 1) {
                                        location.href = '/Member/ChangXianOrder.aspx';
                                    }
                                    else if (type == 2) {
                                        location.href = '/Member/ChuJingOrder.aspx';
                                    }
                                    else {
                                        location.href = '/Member/DuanXianOrder.aspx';
                                    }
                                } else {
                                    alert(response.msg);
                                    $(this).bind("click", function() { pageData.pageSave(); }).css({ "color": "" });
                                }
                            },
                            error: function() {
                                $(this).bind("click", function() { pageData.pageSave(); }).css({ "color": "" });
                            }
                        });
                    }
                }
            },
            RemoveControl: function(elements) {
                var count = elements.length;
                for (var i = 0; i < count; i++) {
                    if (elements[i] == undefined)
                        continue;

                    var obj = document.createElement('span');
                    switch (elements[i].type) {
                        case "text":
                            obj.style.width = elements[i].style.width;
                            obj.className = "word_warpbreak";
                            obj.innerHTML = elements[i].value;
                            break;
                        case "textarea":
                            obj.style.width = elements[i].style.width;
                            obj.className = "word_warpbreak";
                            obj.innerHTML = elements[i].value;
                            break;
                        default:
                            for (var j = 0; j < elements[i].length; j++) {
                                if (elements[i][j].selected) {
                                    obj.style.width = elements[i].style.width;
                                    obj.className = "word_warpbreak";
                                    obj.innerHTML = elements[i][j].text;
                                    break;
                                }
                            }
                            elements[i].options.length = 0;
                            break;
                    }
                    elements[i].parentNode.appendChild(obj);
                    //删除表单控件
                    $("#" + elements[i].id + "").remove();
                }
            },
            pageHtml: function() {

                var crs = tableToolbar.getInt($("#txtcrs").val());
                var ets = tableToolbar.getInt($("#txtets").val());
                if ((crs + ets) > tableToolbar.getInt($("#<%=lblsy.ClientID %>").html())) {
                    alert("本团名额已满，请另选其他产品！");
                    history.go(-1);
                    return false;
                }
                pageData.initAutoAdd();
                $("#hidcrj").val(tableToolbar.getFloat($("#lblhycrj").html()));
                $("#hidetj").val(tableToolbar.getFloat($("#lblhyetj").html()));
                var zj = (tableToolbar.getFloat("<%=crj %>") * crs + tableToolbar.getFloat("<%=etj %>") * ets);
                $("#hidzj").val(zj);
                var mszj = (tableToolbar.getFloat($("#lblhycrj").html()) * crs + tableToolbar.getFloat($("#lblhyetj").html()) * ets);
                var strHtml = '';
                if ('<%=userTp %>' != '代理' && '<%=userTp %>' != '贵宾会员' && '<%=userTp %>' != '免费代理') {
                    strHtml += '<b>申请贵宾身份&nbsp;&nbsp;&nbsp;&nbsp;：</b>';

                }
                else {
                    strHtml += '<b>贵宾价总金额&nbsp;&nbsp;&nbsp;&nbsp;：</b>';

                }

                strHtml += '<font class="fontred">成人<strong></strong><b class="font14">' + tableToolbar.getInt($("#gbcrj").val()) + '</b>元/人 x<strong> ' + crs + '</strong>人+儿童<b class="font14">' + tableToolbar.getInt($("#gbetj").val()) + '</b>元/人x <b class="font14">' + ets + '</b>人= </font><font class="fontblue"><b class="font14">' + tableToolbar.getFloat((tableToolbar.getFloat($("#gbcrj").val()) * crs + tableToolbar.getFloat($("#gbetj").val()) * ets)) + '</b>元，</font><b class="fontblue">立省' + tableToolbar.getInt(mszj - (tableToolbar.getFloat($("#gbcrj").val()) * crs + tableToolbar.getFloat($("#gbetj").val()) * ets)) + '元</b>';
                if ('<%=userTp %>' != '代理' && '<%=userTp %>' != '贵宾会员' && '<%=userTp %>' != '免费代理') {
                    strHtml += ' <a target="_blank" href="/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767" class="btn001 vipuser" id="vipuser"><span>马上申请</span></a> <br />';
                }
                else {
                    strHtml += ' <br />';
                }

                if ('<%=userTp %>' != '代理') {
                    strHtml += '<b>申请代理身份&nbsp;&nbsp;&nbsp;&nbsp;：</b>';
                }
                else {
                    strHtml += '<b>代理价总金额&nbsp;&nbsp;&nbsp;&nbsp;：</b>';

                }
                strHtml += '<font class="fontred">成人<strong></strong><b class="font14">'
                + tableToolbar.getFloat($("#lblfxcrj").html()) + '</b>元/人x<strong> ' + crs + '</strong>人+儿童<b class="font14">'
                + tableToolbar.getFloat($("#lblfxetj").html()) + '</b>元/人 x <b class="font14">' + ets + '</b>人= </font><font class="fontblue"><b class="font14">'
                 + tableToolbar.getInt(tableToolbar.getFloat($("#lblfxcrj").html() * crs) + tableToolbar.getFloat($("#lblfxetj").html()) * ets) + '</b>元，</font><b class="fontblue">立省'
                 + tableToolbar.getInt( tableToolbar.getInt(mszj - (tableToolbar.getFloat($("#lblfxcrj").html()) * crs + tableToolbar.getFloat($("#lblfxetj").html()) * ets))) + '元</b>';
                if ('<%=userTp %>' != '代理') {
                    strHtml += ' <a target="_blank" href="/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652" class="btn001 supplier" id="supplier"><span>马上申请</span></a>';
                }
                var jsHTML = ' <font class="fontred">成人<b class="font14">' + tableToolbar.getFloat("<%=crj %>") + '</b>元/人 x <b class="font14">' + crs + '</b>人 + 儿童<b class="font14">' + tableToolbar.getFloat("<%=etj %>") + '</b>元/人 x <b class="font14">' + ets + '</b>人= </font><font class="fontblue"> <b class="font14">' + tableToolbar.getFloat(tableToolbar.getFloat("<%=crj %>") * crs + tableToolbar.getFloat("<%=etj %>") * ets) + '</b>元</font>';
                if ('<%=userTp %>' != '员工' && '<%=isDisplay %>' == 'True') {
                    $(".tixing").html(strHtml);
                } else {
                    $(".tixing").remove();
                }
                $(".jstd").html(jsHTML);
            }
        };
        $(function() {
            pageData.initDelRow();
            pageData.initClick();
            pageData.pageHtml();
            $("#btnSave").click(function() { pageData.pageSave(); })
            $("#btnQuXiao").click(function() { $("#<%=form1.ClientID %>").html(fanhuibianji); $("#txtarea").val(beizhuxinxi); $("#btnSave").html("提交"); })
            $(".renshu").change(function() { if (tableToolbar.getInt($("#txtcrs").val()) < 1) { $("#txtcrs").val(1) } pageData.pageHtml() });
        })
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
