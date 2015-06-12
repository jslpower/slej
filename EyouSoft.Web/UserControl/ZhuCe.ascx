<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZhuCe.ascx.cs" Inherits="EyouSoft.Web.UserControl.ZhuCe" %>
<%--<div class="line_xx_box02">
    <ul>
        <%if (isfenxiao == 0)
          { %>
        <li class="bg01">
            <p class="cont">
                <a>开网店，省更多，赚更多！可快速购买商旅e家独立分销网站，我的宝贝也能放会员商城让大家代销！<br />
                    我也能代销别人的宝贝！</a></p>
            <p class="title">
                <a class="supplier" href="javascript:;">我要成为分销商 >></a>
                </p>
        </li>
        <%} %>
        <asp:PlaceHolder ID="plahuiyuan" runat="server">
        <li class="bg02">
            <p class="cont">
                <a>享受优惠的会员低价，还可以参加无穷多的公司活动：比如积分送礼、送旅游代金券、抽奖、获取特价或秒杀<br />
                    通知等！</a></p>
            <p class="title">
                <a class="normaluser" href="#">我要成为普通会员 >></a></p>
        </li>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plaguibin" runat="server">
        <li class="bg03">
            <p class="cont">
                <a>还嫌价格不够低，可快速申请贵宾帐号！我的宝贝也能放会员商城让大家代销！</a></p>
            <p class="title">
                <a class="vipuser" href="javascript:;">我要成为贵宾会员 >></a></p>
        </li>
        </asp:PlaceHolder>
        <li class="bg04">
            <p class="cont">
                <a>还嫌价格不够低，可快速申请钻石帐号！我要在所有栏目享受贵宾价格后还有现金券抵用，我的宝贝也<br />
                    能放会员商城让大家代销！</a></p>
            <p class="title">
                <a class="diamonduser" href="javascript:;">我要成为钻石会员 >></a></p>
        </li>
    </ul>
    <div class="clear">
    </div>
</div>

<script type="text/javascript">
    var pageInfo = {
        CreatBoxy: function(data) {
            Boxy.iframeDialog({
                iframeUrl: data.url,
                title: data.title,
                modal: true,
                width: '500px',
                height: '300px'
            });
        }
    };
    $(function() {
        $("a.supplier").click(function() { pageInfo.CreatBoxy({ url: '/ApplyUser.aspx?Classid=<%=(int)EyouSoft.Model.Enum.MemberTypes.分销商 %>', title: '申请成为分销商' }) })
        $("a.normaluser").click(function() { window.open('/default.aspx') })
        $("a.vipuser").click(function() { pageInfo.CreatBoxy({ url: '/ApplyUser.aspx?Classid=<%=(int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 %>', title: '申请成为贵宾会员' }) })
    })
</script>

--%>