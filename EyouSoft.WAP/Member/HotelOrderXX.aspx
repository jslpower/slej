<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrderXX.aspx.cs" Inherits="EyouSoft.WAP.Member.HotelOrderXX" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>酒店订单详情</title>
    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan_xx mt10">
            <ul>
                <li>
                    <asp:Literal ID="ltrHotelName" runat="server"></asp:Literal></li>
                <li>
                    <asp:Literal ID="LitRoomName" runat="server"></asp:Literal></li>
                <li>订单编号：<asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal></li>
                <li>预订日期：<asp:Literal ID="litInTime" runat="server"></asp:Literal></li>
                <li>订单金额：<i class="font22 font_yellow">
                    <asp:Literal ID="litJinE" runat="server"></asp:Literal></i></li>
                <%if(isAgency==true){ %>
                   <li>分销金额：<asp:Literal ID="AgencyJinE" runat="server"></asp:Literal></li>
                   <li>分销利润：<asp:Literal ID="AgencyLiRui" runat="server"></asp:Literal></li>
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
                        星级：<asp:Literal ID="StarNum" runat="server"></asp:Literal></p>
                    <p>
                        入住时间：<asp:Literal ID="litLDate" runat="server"></asp:Literal></p>
                    <p>
                        离店时间：<asp:Literal ID="ltrEDate" runat="server"></asp:Literal></p>
                    <p>
                        房间数量：<asp:Literal ID="ltrTianShu" runat="server"></asp:Literal>间</p>
                </li>
                <li>备注：<asp:Literal ID="txtBeiZhu" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="dindan_mx">
            <h2 class="font_yellow paddB">
                入住人信息</h2>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        入住人
                    </th>
                    <th>
                        入住人手机
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr>
                            <td align="center" style="font-size: 12px;">
                                <%#Eval("ContactName")%>
                            </td>
                            <td align="center" style="font-size: 12px;">
                                <%#Eval("Mobile")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </table>
        </div>
        <div class="mt10 user_T font16">
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
            window.location.href = "/Member/XieYi.aspx?Pay=1&Classid=2&id=" + id + "&type=" + type + "&token=" + token;
        },
        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=1&ordertype=5&id=" + oid + "&state=" + state,
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
