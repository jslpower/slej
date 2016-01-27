<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JpOrderXX.aspx.cs" Inherits="EyouSoft.WAP.Member.JpOrderXX" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>机票订单详情</title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan_xx mt10">
            <ul>
                <li>
                    <asp:Literal ID="ltrFlightName" runat="server"></asp:Literal></li>
                <li>订单编号：<asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal></li>
                <li>预订日期：<asp:Literal ID="litInTime" runat="server"></asp:Literal></li>
                <li>订单金额：<i class="font22 font_yellow"> ￥<asp:Literal ID="litJinE" runat="server"></asp:Literal></i></li>
                <li>支付状态：<asp:Literal ID="PayState" runat="server"></asp:Literal></li>
                <li>订单状态：<asp:Literal ID="orderstatus" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="mt10 user_T font16">
            详细信息</div>
        <div class="user_dindan">
            <ul>
                <li>
                    <p>
                        预订数量：<asp:Literal ID="ltrNumber" runat="server"></asp:Literal></p>
                    <p>
                        出发时间：<asp:Literal ID="litLDate" runat="server"></asp:Literal></p>
                </li>
            </ul>
        </div>
        <div class="mt10 user_T font16">
            乘客名单</div>
        <div class="add_box add_box_no u-list">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <ul>
                        <li><span class="label_name">姓名</span> <span class="font_gray">
                            <%# Eval("XingMing")%></span> </li>
                        <li><span class="label_name">证件类型</span> <span class="font_gray">
                            <%# Eval("ZhengJianLeiXing")%></span> </li>
                        <li><span class="label_name">证件号码</span> <span class="font_gray">
                            <%# Eval("ZhengJianHao")%></span> </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="user_T font16">
            预订人信息</div>
        <div class="user_dindan">
            <ul>
                <li style="border: none 0;">
                    <p>
                        预定人：<asp:Literal ID="txtYContact" runat="server"></asp:Literal></p>
                    <p>
                        手机：<asp:Literal ID="txtYContactTel" runat="server"></asp:Literal></p>
                </li>
            </ul>
        </div>
        <div class="pay mt10">
            <div class="pay_box">
                <asp:Literal ID="AnNiu" runat="server"></asp:Literal>
            </div>
            <asp:PlaceHolder ID="plaZhiFu" runat="server" Visible="false">
                <div id="CLICKBOX" class="pay_box font_blue cent" style="background: #fff;">
                    <span class="down">退改签</span></div>
            </asp:PlaceHolder>
        </div>
    </div>
    <div id="TPBOX" class="user-mask" style="display: none;">
        <div class="user-mask-cnt box" style="position: absolute; width: 100%; bottom: 30px;">
            <h3>
                退改签说明：</h3>
            <p class="font_gray">
                退改签请联系400-6588-180</p>
            <p class="font_gray">
                退 票：<asp:Literal ID="ltrTuiPiao" runat="server"></asp:Literal></p>
            <p class="font_gray">
                变 更：<asp:Literal ID="ltrGaiQian" runat="server"></asp:Literal></p>
            <p>
            </p>
        </div>
    </div>
</body>

<script type="text/javascript">
    var pageData = {
        Pay: function(id, type, token) {
            window.location.href = "/Member/XieYi.aspx?classid=11&pay=1&id=" + id + "&type=" + type + "&token=" + token;
        },
        DeleteOrder: function(oid) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/JpOrderList.aspx?setState=2&ordertype=10&id=" + oid,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                        else {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                        window.location.href = window.location.href;
                    }
                })
            }
        },
        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/JpOrderList.aspx?setState=1&ordertype=10&id=" + oid + "&state=" + state,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                        else {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                        window.location.href = window.location.href;
                    }
                })
            }
        }
    };

    $(function() {
        $("#CLICKBOX").click(function() {
            $("#TPBOX").show();
        })
        $("#TPBOX").click(function() {
            $(this).hide()
        });
    })
</script>

</html>
