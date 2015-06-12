<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainNav.ascx.cs" Inherits="EyouSoft.Web.UserControl.MainNav" %>
<div class="menu">
    <div class="menubox" id="div_HeadMenu">
        <ul>
            <li><a class="menu_has" data-index='1' href="/Default.aspx"><span>首页</span> </a>
            </li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='12' href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.周边短线 %>">
                <span>周边短线</span></a></li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='2' href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.国内长线 %>">
                <span>国内长线</span></a></li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='3' href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.出境线路 %>">
                <span>国际线路</span></a></li>
            <li class="line"></li>
            <% if (isquanxian == 1)
               {%>
            <li><a class="menu_has" data-index='4' href="/QianZheng.aspx"><span>出国签证</span></a></li>
            <%}
               else
               {%>
            <li><a class="menu_has" data-index='4' href="/Visa.aspx"><span>出国签证</span></a></li>
            <%} %>
            <li class="line"></li>
            <li><a class="menu_has" data-index='5' href="/JiPiao.aspx"><span>机票预定</span></a></li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='6' href="/YouHuiMenPiao.aspx?ProvinceId=11"><span>优惠门票</span></a></li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='7' href="/Hotel.aspx"><span>酒店预定</span></a></li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='8' href="/ZuChe.aspx"><span>客车包租</span></a></li>
            <li class="line"></li>
            <li><a id="link_menu" class="menu_has menu_icon" data-index='9' href="/ShangCheng.aspx">
                <span>商城联盟</span><em></em></a> </li>
            <li class="line"></li>
            <li><a class="menu_has" data-index='10' href="/Ebao.aspx"><span>E额宝</span></a></li>
            <li class="line"></li>
            <% if (isfenxiao == 0)
                { %>
            <li><a class="menu_has" data-index='11' href="/about.aspx"><span>关于我们</span></a></li>
            <%}
                else
                {%>
                <li><a class="menu_has" data-index='11' href="/CompanyContent.aspx"><span>关于我们</span></a></li>
            <%} %>
        </ul>
    </div>
</div>

<script type="text/javascript">
    $(function() {

        $('#link_menu').bt({
            contentSelector: function() {
                return "<div class='menu_more'><a href='/ShangCheng.aspx'>会员供销商城</a><a href='/ShangChengLianMeng.aspx'>购物广场联盟</a><a href='XiuXianYuLe.aspx'>休闲娱乐会所</a><a href='/ShangLvEJia.aspx' class='last'>天下商旅e家</a></div>";
            },
            positions: ['bottom'],
            fill: '#008000',
            strokeStyle: '#006100',
            strokeWidth: 1,
            noShadowOpts: { strokeStyle: "#006100" },
            spikeLength: 6,
            spikeGirth: 12,
            width: 100,
            overlap: 0,
            centerPointY: 14,
            cornerRadius: 2,
            shadow: true,
            shadowColor: 'rgba(0,0,0,.5)',
            padding: 5,
            cssStyles: { color: '#00387E', 'line-height': '180%' }
        });
    });

</script>