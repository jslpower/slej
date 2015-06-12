<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line_LXRXX.aspx.cs" Inherits="EyouSoft.WAP.Line_LXRXX" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="/css/zt.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="信息填写" />
    <div class="warp paddB">
        <div class="jq_cont">
            <h2>
                <asp:Label ID="lblPeopleNum" runat="server" Text="1成人，0儿童"></asp:Label></h2>
        </div>
        <div class="add_box add_box_no mt10">
            <span class="del_icon" style="display: none;"></span>
            <ul>
                <li><span class="label_name">游客联系人</span>
                    <input name="yklxr" id="yklxr" type="text" class="u-input" value="联系人姓名" onfocus="javascript:if(this.value=='联系人姓名')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='联系人姓名';" />
                </li>
                <li><span class="label_name">手机号码</span>
                    <input name="yksj" id="yksj" type="text" class="u-input" value="联系人手机号码" onfocus="javascript:if(this.value=='联系人手机号码')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='联系人手机号码';" />
                </li>
            </ul>
        </div>
        <div id="box">
            <div class="tempdiv add_box mt10">
                <span class="del_icon" style="display: block;" onclick="javascript:pageOpt.removePeople(this)">
                </span>
                <ul>
                    <li><span class="label_name">游客类型</span><select name="txtYouKeLeiXing"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.YouKeType)), "" )%></select></li>
                    <li><span class="label_name">游客姓名</span>
                        <input type="text" class="u-input" value="姓名" onfocus="javascript:if(this.value=='姓名')this.value='';"
                            onblur="javascript:if(this.value=='')this.value='姓名';" name="txtYouKeName">
                    </li>
                    <li><span class="label_name">手机号码</span>
                        <input type="text" class="u-input" value="联系人手机号码" onfocus="javascript:if(this.value=='联系人手机号码')this.value='';"
                            onblur="javascript:if(this.value=='')this.value='联系人手机号码';" name="txtYouKeTelephone" />
                    </li>
                    <li><span class="label_name">证件类型</span>
                        <select name="txtYouKeZhengJianLeiXing">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.CardType),new string[]{"0"}), "" )%>
                        </select>
                    </li>
                    <li><span class="label_name">证件号码</span>
                        <input type="text" class="u-input" value="证件号码" onfocus="javascript:if(this.value=='证件号码')this.value='';"
                            onblur="javascript:if(this.value=='')this.value='证件号码';" name="txtYouKeZhengJianHao" />
                    </li>
                </ul>
            </div>
        </div>
        <div class="mt10 font16 cent add_more">
            <span id="addPeople"><i class="add_icon"></i>添加联系人</span></div>
    </div>
    <div class="line_pay">
        <div class="line_pay_box">
            <div class="pay_total">
                订单总额：<asp:Label ID="lblZJ" runat="server" Text="0"></asp:Label>
                元</span></div>
            <div class="pay_btn">
                <a href="javascript:;" class="step_btn" id="step_btn">核对提交</a></div>
        </div>
    </div>
    <div id="price_Box" class="line-mask" style="display: none;">
        <div class="line-mask-cnt">
            <h3>
                价格详情</h3>
            <ul id="price_ul" runat="server">
            </ul>
        </div>
    </div>
    <input type="hidden" value="<%= Ldate%>" name="hidLDate" />
    <input type="hidden" name="jsc" id="jsc" value="<%=jsjcr %>" />
    <input type="hidden" name="jse" id="jse" value="<%=jsjet%>" />
    <input type="hidden" name="zj" id="zj" value="<%=lblZJ.Text%>" />
    <div id="TiJiaoMask" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在提交订单，请等待。。。
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            pageDatas: { xianluid: '<%=EyouSoft.Common. Utils.GetQueryStringValue("xianluid") %>', tourid: '<%=EyouSoft.Common. Utils.GetQueryStringValue("tid") %>', type: '<%=EyouSoft.Common. Utils.GetQueryStringValue("type") %>', crs: '<%=EyouSoft.Common. Utils.GetQueryStringValue("crs") %>', ets: '<%=EyouSoft.Common. Utils.GetQueryStringValue("ets") %>', hasFlightNO: '<%=EyouSoft.Common. Utils.GetQueryStringValue("hangban") %>' },
            removePeople: function(obj) {
                if ($(".tempdiv ").length > 1) {
                    $(obj).closest(".tempdiv").remove();
                }
                else {
                    alert("最少保留一位游客信息");
                }
            },
            addPeople: function(obj) {
                var temp = $(".tempdiv").eq(0).clone(true)
                temp.find("input").val("");
                $("#box").append(temp);
            },
            subOrder: function() {
                $("#step_btn").unbind("click");
                if (window.confirm("请确认提交")) {
                    $("#TiJiaoMask").toggle();
                    $.ajax({
                        type: "post",
                        url: "/Line_LXRXX.aspx?save=save&" + $.param(pageOpt.pageDatas),
                        cache: false,
                        data: $("#step_btn").closest("form").serialize(),
                        dataType: "json",
                        success: function(ret) {
                            $("#TiJiaoMask").toggle();
                            if (ret.result == "1") {
                                alert(ret.msg);
                                location.href = "/Member/XianLuOrderList.aspx?type=" + pageOpt.pageDatas.type;
                            }
                            else {
                                $("#TiJiaoMask").toggle();
                                alert(ret.msg);
                                $("#step_btn").bind("click", function() { pageOpt.subOrder() });
                            }
                        }
                    });
                }
            }
        }
        $(function() {
            $("#addPeople").click(function() { pageOpt.addPeople(this); })
            $("#step_btn").click(function() {
                var msg = "";
                if ($("#yklxr").val() == "") {
                    msg = "联系人姓名不可为空";
                }
                if (!(/^(13|15|18|14)\d{9}$/.test($("#yksj").val()))) {
                    msg += "联系人手机错误";
                }
                if (msg != "") {
                    alert(msg);
                    return false;
                }
                pageOpt.subOrder();
            })//
            $("#lblZJ").click(function() {
                var display = $("#price_Box").css("display");
                if (display == "none") {
                    $("#price_Box").show();
                } else {
                    $("#price_Box").hide();
                }
            })
        })
    </script>

</body>
</html>
