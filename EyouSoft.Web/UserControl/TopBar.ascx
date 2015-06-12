<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBar.ascx.cs" Inherits="EyouSoft.Web.UserControl.TopBar" %>
<!--paopao star--> 
<!--[if IE]><script src="js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
<script src="/JS/bt.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {
        $('#code2').bt({
            contentSelector: function() {
                return "<div class='code2'><a href='#'><img src='<%=erweimapic %>' /></a></div>";
            },
            positions: ['bottom'],
            fill: '#fff',
            strokeStyle: '#ccc',
            strokeWidth: 1,
            noShadowOpts: { strokeStyle: "#ccc" },
            spikeLength: 6,
            spikeGirth: 12,
            width: 155,
            overlap: 0,
            centerPointY: 14,
            cornerRadius: 0,
            shadow: true,
            shadowColor: 'rgba(0,0,0,.5)',
            padding: 3,
            cssStyles: { color: '#00387E', 'line-height': '180%' }
        });
    });
</script>

<div class="top">
    <div class="topbox fixed">
        <div class="welcom">
            <asp:Label ID="lblShenFen" runat="server" Text=""></asp:Label><asp:Literal ID="ltrUserName" runat="server"></asp:Literal>您好,欢迎访问商旅e家电子商务平台！&nbsp;&nbsp; <% if (uislogin == 1)
                                                                                                                                                                {  %><a id="b_LoginOut" href="javascript:void(0);" style="color:Red">点击退出</a><%} %><em class="font_yellow" style=" padding-left:20px;">友情提醒：</em>敬请阅读旅游产品的所有文字说明，感谢您的光临！
        </div>
        <ul class="top_R">
            <li><span><a href="#" id="code2">扫描二维码</a></span></li>
            <li><span><a href="/about.aspx">关于商旅e家</a></span></li>
            <asp:Literal ID="lithuiyuan" runat="server"></asp:Literal>
            <li><span><a href="/Joinus.aspx">加入我们</a></span></li>
            <li><span class="noborder"><a id="a_Head_AddFavorite" href="javascript:void(0);">收藏本站</a></span></li>
        </ul>
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function() {
        $("#alogin").click(function() {
            window.location.href = '/Lg.aspx?rurl=' + encodeURIComponent(window.location.href);
        })
        $("#a_Head_AddFavorite").click(function() {
            var sURL = window.location.href;
            var sTitle = document.title;
            try {
                window.external.addFavorite(sURL, sTitle);
            }
            catch (e) {
                try {
                    window.sidebar.addPanel(sTitle, sURL, "");
                }
                catch (e) {
                    alert("加入收藏失败，请使用Ctrl+D进行添加");
                }
            }
        });
        $("#b_LoginOut").click(function() {
            if (!confirm("确定退出当前登录！")) return false;

            $.ajax({ type: "post", cache: false, url: "/LogOut.aspx?r=1", dataType: "json",
                success: function(ret) {
                    if (ret.result == "1") window.location.reload();
                    else window.location.reload();
                },
                error: function() {
                    window.location.reload();
                }
            });

            return false;
        });

    });
</script>



