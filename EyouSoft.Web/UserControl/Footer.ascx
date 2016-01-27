<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="EyouSoft.Web.UserControl.Footer" %>
<div class="foot">
    <div class="foot_menu">
        <a href="/Default.aspx">首页</a> | <a href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.周边短线 %>">
            周边短线</a> | <a href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.国内长线 %>">
                国内长线</a> | <a href="/XianLu.aspx?type=<%=(int)EyouSoft.Model.Enum.AreaType.出境线路 %>">
                    国际线路</a> |  <% if (isquanxian == 1)
                                   {%><a href="/QianZheng.aspx">出国签证</a><%}
                                   else
                                   { %><a href="/Visa.aspx">出国签证</a><%} %> | <a href="/JiPiao.aspx">机票预定</a>
        | <a href="/YouHuiMenPiao.aspx">优惠门票</a> | <a href="/Hotel.aspx">酒店预定</a> | <a href="/ZuChe.aspx">
            汽车包租</a> | <a href="/ShangCheng.aspx">会员商城</a> | <a href="/baoming.aspx">报名网点</a>
        | <a href="/about.aspx">关于商旅e家</a> | <a href="/webmaster">后台管理</a>
<!-- slej.cn Baidu tongji analytics -->
<script type="text/javascript">
var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F7d194f78b6b719498f06d9d70e76ba62' type='text/javascript'%3E%3C/script%3E"));
</script>
</div>

    <div class="foot_txt">
        <% if (isfenxiao != 1)
                                   {%>版权所有 杭州金奥国际旅行社有限公司<%} %> 浙ICP备14023376号-1 许可证号：<%= Xuke%></div>
    <div class="foot_txt">
        地址：<%=address %> 服务热线：<%= Tel%><br />
        本网站所有出境线路均受以下出境社委托合法代理出境产品：<br />中国天鹅国旅L-BJ-CJ00027，深圳海外国旅L-GD-CJ00052，上海中信国旅L-SH-CJ00038，浙江天天商旅L-ZJ-CJ00071 ……</div>
</div>
