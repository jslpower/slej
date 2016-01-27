<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="EyouSoft.WAP.Mall.OrderPage" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="配送信息" />
    <form id="form1">
    <div class="warp">
        <h2 class="mall_title">
            订单信息</h2>
        <div class="jq_cont">
            <h2 class="paddB">
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </h2>
            <p>
                单价：¥<asp:Label ID="lblSinglePrice" runat="server" Text="0"></asp:Label></p>
            <p style="padding: 5px 0;">
                数量：<span class="number"><i class="num-minus"></i><input id="lblNum" name="lblNum"
                    type="tel" value="<%= goumainum%>"><i class="num-add"></i></span> (最多可购买<asp:Literal
                        ID="shengyushu" runat="server"></asp:Literal>份)</p>
            </p>
            <p>
                总额：<span class="font_yellow">¥<i class="font18"><asp:Label ID="lblSumPrice" runat="server"
                    Text="0"></asp:Label></i></span></p>
        </div>
        <%if (isLogin)
          { %>
        <h2 class="mall_title">
            客户信息</h2>
        <div class="add_box add_box_no">
            <ul>
                <li><span class="label_name font14"><i class="font_red">*</i> 收件人</span>
                    <input type="text" class="u-input" value="" placeholder="请填写收件人" runat="server" id="txtShouHuoRen" />
                </li>
                <li><span class="label_name font14"><i class="font_red">*</i> 手机</span>
                    <input type="text" class="u-input" value="" placeholder="请填写手机号码" runat="server"
                        id="txtShouJi" />
                </li>
                <li><span class="label_name font14"><i class="font_red">&nbsp;&nbsp;&nbsp;</i>电话</span>
                    <input type="text" class="u-input" value="" placeholder="请填写电话" runat="server" id="txtDianHua" />
                </li>
                <li><span class="label_name font14"><i class="font_red">*</i> 地址</span>
                    <select name="ddprovince" id="ddprovince">
                    </select>
                    <select name="ddlcity" id="ddlcity">
                    </select>
                    <select name="ddlqu" id="ddlqu">
                    </select>
                </li>
                <li><span class="label_name font14"></span>
                    <input name="" type="text" class="u-input" value="" placeholder="请填写收货地址" runat="server"
                        id="txtDiZhi" />
                </li>
                <li style="line-height: 36px;">
                    <div class="font_gray font14">
                        <a href="javascript:;" class="fxk">设为默认收货地址</a></div>
                    <!---勾选样式fxk_on------>
                </li>
            </ul>
        </div>
        <%
            }
          else
          {
        %>
        <div class="padd cent">
            <input id="BtnLogin" type="button" class="y_btn gray_btn" value="非会员直接预订"></div>
        <% } %>
        <div class="padd cent" style="padding-top: 0;">
            <input name="y_btn" type="button" class="y_btn" value="核对提交" id="y_btn" /></div>
        <input type="hidden" id="isDefault" name="isDefault" value="0" />
        <input name="hidnum" type="hidden" value="" runat="server" id="hidnum" />
        <input name="hidjsj" type="hidden" value="" runat="server" id="hidjsj" />
        <input name="hidmsj" type="hidden" value="" runat="server" id="hidmsj" />
        <input name="hidaddid" type="hidden" value="" runat="server" id="hidaddid" />
    </div>
    <input name="hidpid" type="hidden" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>" />
    <div id="TiJiaoMask" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在提交订单，请等待。。。
            </div>
        </div>
    </div>
    </form>

    <script>
        var onejiage = "<%=danjia %>";
        $(".num-minus").click(function() {
            var getNum = $(this).parent().find("input").eq(0);
            if (tableToolbar.getInt(getNum.val()) > 1) {
                getNum.val(tableToolbar.getInt(getNum.val()) - 1);
            } else {
                getNum.val(1);
            }
            $("#lblSumPrice").html(tableToolbar.getFloat(tableToolbar.getInt(getNum.val()) * tableToolbar.getFloat(onejiage)) + "元");
        });
        $(".num-add").click(function() {
            var getNum = $(this).parent().find("input").eq(0);
            var shengyu = "<%=shengyu %>";
            if (tableToolbar.getInt(shengyu) >= tableToolbar.getInt(getNum.val()) + 1) {
                getNum.val(tableToolbar.getInt(getNum.val()) + 1);
            }
            else {
                alert("最多只能购买" + shengyu + "份");
            }
            $("#lblSumPrice").html(tableToolbar.getFloat(tableToolbar.getInt(getNum.val()) * tableToolbar.getFloat(onejiage)) + "元");
        });
    </script>

    <script type="text/javascript">
        var pageOpt = {
            pageSave: function() {
                if (window.confirm("请确认提交")) {
                    $(".y_btn").unbind("click");
                    $("#TiJiaoMask").toggle();
                    $.ajax({
                        type: "post",
                        url: "OrderPage.aspx?save=save&",
                        dataType: "json",
                        data: $("#y_btn").closest("form").serialize(),
                        success: function(ret) {
                            if (ret.result == "1") {
                                $("#TiJiaoMask").toggle();
                                alert("下单成功，请前往订单中心查看!");

                                location.href = '/Member/DingDanList.aspx?ordertype=3';
                            } else {
                                $("#TiJiaoMask").toggle();
                                alert(ret.msg);
                                $(".y_btn").bind("click");
                            }

                        },
                        error: function() {
                            $("#TiJiaoMask").toggle();
                            alert(tableToolbar.errorMsg);
                            $(".y_btn").bind("click");
                        }
                    });
                }
            }
        };
        $(function() {
            $("#BtnLogin").click(function() { window.location.href = '/HuiYuanReg.aspx?rurl=' + encodeURIComponent(window.location.href); return false; });
            $(".fxk").click(function() {
                if ($(this).hasClass("fxk_on")) {
                    $(this).removeClass("fxk_on");
                } else {
                    $(this).addClass("fxk_on");
                }
            })

            pcToobar.init({
                pID: "#ddprovince",
                cID: "#ddlcity",
                xID: "#ddlqu",
                pSelect: "<%= pSelect%>",
                cSelect: "<%= cSelect%>",
                xSelect: "<%= xSelect%>",
                comID: '1'
            });

            $("#y_btn").click(function() {
                if (!iLogin.getM().isLogin) {
                    location.href = "/Login.aspx?rurl=" + encodeURIComponent(location.href);
                    return false;
                }
                var msg = "";
                if ($("#<%=txtShouHuoRen.ClientID %>").val() == '') {
                    msg += "收件人不能为空 \n"
                }
                if ($("#<%=txtShouJi.ClientID %>").val() == "" && $("#<%=txtDianHua.ClientID %>").val() == "") {
                    msg += "手机和电话必须填写一项";
                }
                if (msg != '') {
                    alert(msg);
                    return false;
                }
                pageOpt.pageSave();
            })
        })
    </script>

</body>
</html>
