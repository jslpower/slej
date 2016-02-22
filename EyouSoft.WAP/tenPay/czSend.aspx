<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="czSend.aspx.cs" Inherits="EyouSoft.WAP.tenPay.czSend" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html >
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>微信安全支付</title>
    <link rel="stylesheet" href="/css/zhifu.css" type="text/css" media="screen">

    <script type="text/javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js"></script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
     var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script language="javascript" type="text/javascript">

        $(function() {
            jQuery('#getBrandWCPayRequest').click(function() {
                wx.chooseWXPay({
                    timestamp: '<%= _TenPayTradeModel.TimeStamp %>', // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                    nonceStr: '<%= _TenPayTradeModel.NonceStr %>', // 支付签名随机串，不长于 32 位
                    package: 'prepay_id=<%= _TenPayTradeModel.PrepayId %>', // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                    signType: 'MD5', // 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
                    paySign: '<%= _TenPayTradeModel.Sign %>', // 支付签名
                    success: function(res) {
                        // 支付成功后的回调函数
                    }
                });
            })

            jQuery("#menus").html("");
        })
    </script>

</head>
<body>
    <form id="form1">
    <uc1:wapheader runat="server" id="WapHeader1" headtext="微信安全支付" />
    <div class="warp">
        <div class="jq_tab zhifu_tab mt10" id="n4Tab">
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                   <asp:PlaceHolder runat=server ID=phChongZhi Visible=false>
                    <div class="user_form">
                        <ul>
                            <li><span class="label_name"></span><span class="font18 font_yellow">
                                <asp:Literal ID="MyMoney" runat="server"></asp:Literal></span> </li>
                            <li><span class="label_name">订单号：</span>
                                <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                            </li>
                            <li><span class="label_name">订单金额：</span>
                                <asp:Label ID="lblJinE" runat="server" Text="Label"></asp:Label>
                            </li>
                            <li><span class="label_name">充值账号：</span>
                                <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                            </li>
                            <li><span class="label_name">操作人：</span>
                                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                            </li>
                            <li><span class="label_name">充值时间：</span>
                                <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                            </li>
                        </ul>
                    </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat=server ID=phOrderPay Visible=true>
                    <div class="user_form">
                        <ul>
                            <li><span class="label_name">订单名称：</span>
                                <asp:Label ID="lblchanpinmingcheng" runat="server" Text="Label"></asp:Label>
                            </li>
                            <li><span class="label_name">订单金额：</span>
                                <%=lblJinE.Text %>
                            </li>
                        </ul>
                    </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="plaIsWxBow" runat="server">
                        <div class="padd cent">
                            <input name="" type="button" class="y_btn" value="微信支付" id="getBrandWCPayRequest" /></div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
