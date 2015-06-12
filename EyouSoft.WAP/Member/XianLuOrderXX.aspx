<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XianLuOrderXX.aspx.cs"
    Inherits="EyouSoft.WAP.Member.XianLuOrderXX" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>无标题文档</title>
    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan_xx mt10">
            <ul>
                <li>
                    <asp:Literal ID="ltrCarName" runat="server"></asp:Literal></li>
                <li>订单编号：<asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal></li>
                <li>预订日期：<asp:Literal ID="litInTime" runat="server"></asp:Literal></li>
                <li>订单金额：<i class="font22 font_yellow">
                    ￥<asp:Literal ID="litJinE" runat="server"></asp:Literal></i></li>
                <%if(isAgency==true){ %>
                   <li>分销金额：￥<asp:Literal ID="AgencyJinE" runat="server"></asp:Literal></li>
                   <li>分销利润：￥<asp:Literal ID="AgencyLiRui" runat="server"></asp:Literal></li>
                <%} %>
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
                        预定价格：<asp:Literal ID="YuDingJiaGe" runat="server"></asp:Literal></p>
                    <p>
                        发团时间：<asp:Literal ID="litLDate" runat="server"></asp:Literal></p>
                    <asp:Literal ID="ltrQu" runat="server"></asp:Literal>
                    <asp:Literal ID="ltrHui" runat="server"></asp:Literal>
                </li>
                <li>备注：<asp:Literal ID="txtBeiZhu" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="mt10 user_T font16">
            游客名单</div>
        <div class="add_box add_box_no u-list">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <ul>
                        <li><span class="label_name">姓名</span> <span class="font_gray">
                            <%# Eval("Name")%></span> </li>
                        <li><span class="label_name">证件类型</span> <span class="font_gray">
                            <%# Eval("LeiXing")%></span> </li>
                        <li><span class="label_name">证件号码</span> <span class="font_gray">
                            <%# Eval("ZhengJianCode")%></span> </li>
                        <li><span class="label_name">联系电话</span> <span class="font_gray">
                            <%# Eval("Telephone")%></span> </li>
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
        </div>
    </div>
 </body>

<script type="text/javascript">
    var pageData = {
    Pay: function(id, type, token) {
        var classid='<%=EyouSoft.Common.Utils.GetQueryStringValue("classid")  %>'
        window.location.href = "/Member/XieYi.aspx?classid=" + classid + "&pay=1&id=" + id + "&type=" + type + "&token=" + token;
        },
        DeleteOrder: function(oid) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=2&ordertype=8&id=" + oid,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                    }
                })
            }
        },
        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=1&ordertype=8&id=" + oid + "&state=" + state,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                    }
                })
            }
        }
    };
</script>

</html>
