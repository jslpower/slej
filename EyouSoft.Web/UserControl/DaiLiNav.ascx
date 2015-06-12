<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DaiLiNav.ascx.cs" Inherits="EyouSoft.Web.UserControl.DaiLiNav" %>
<style type="text/css">
.menu .menu_has{ padding-left:18px;}
.menu .menu_has span{ padding-right:18px;}
</style>
<div class="menu">
       <div class="menubox" id="DaiLiHeadNav">
           <ul>
               <li><a class="menu_has" data-index='1'  href="/Default.aspx" ><span>首页</span></a></li>
               <li class="line"></li>
               <li><a class="menu_has"  data-index='15' href="/TuanGou.aspx?type=3"><span>特惠促销</span></a></li>
               <li class="line"></li>
               <li><a class="menu_has" data-index='16' href="/TuanGou.aspx?type=1"><span>秒杀抢购</span></a></li>
               <li class="line"></li>
               <li><a class="menu_has menu_icon" data-index='5' href="/Hotel.aspx" id="link_menu"><span >商务差旅</span></a></li>
               <li class="line"></li>
               <li><a class="menu_has menu_icon" data-index='4' href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.国内长线 %>" id="link_menu2"><span>旅行度假</span></a></li>
               <li class="line"></li>
               <li><a class="menu_has" data-index='9' href="/ShangCheng.aspx" id="link_menu3"><span>商城联盟</span></a></li>
               <li class="line"></li>
               <li><a class="menu_has" data-index='10' href="/Ebao.aspx"><span>E额宝</span></a></li>
               <li class="line"></li>            
                <%--<li><a class="menu_has" data-index='11' href="/CompanyContent.aspx"><span>关于我们</span></a></li>--%>
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
                    var isquanxian = "<%= isquanxian%>";
                    var visaurl = "/QianZheng.aspx";
                    if (isquanxian != 1) { visaurl = "/Visa.aspx"; }
                    return "<div class='menu_more'><a href='/JiPiao.aspx'>机票预订</a><a href='/Hotel.aspx'>酒店预订</a><a href='/ZuChe.aspx'>客车包租</a><a href='" + visaurl + "' class='last'>出国签证</a></div>";
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

            $('#link_menu2').bt({
                contentSelector: function() {
                return "<div class='menu_more'><a href='/YouHuiMenPiao.aspx?ProvinceId=11'>特价门票</a><a href='/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.周边短线 %>'>周边旅游</a><a href='/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.国内长线 %>'>国内旅游</a><a href='/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.出境线路 %>' class='last'>出境旅游</a></div>";
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
            $('#link_menu3').bt({
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
        })

</script>