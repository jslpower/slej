<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.WAP.Mall.Default" %>

<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="商城联盟" />
    <div class="warp">
        <div id="mall_menu">
            <div id="m_menu_box">
                <div class="nav_ico2" style="display: none;">
                    <i></i>
                </div>
                <div class="leftNav">
                    <ul>
                        <asp:Repeater ID="rptMenu" runat="server">
                            <ItemTemplate>
                                <li><a href="javascript:;">
                                    <%# Eval("TypeName")%></a>
                                    <div class="menu_more">
                                        <%# getMenu(Eval("TypeID"))%>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="nav_ico">
                <i></i>
            </div>
        </div>

        <script type="text/javascript">
            $(".leftNav").find("li").click(function() {
                $(this).find(".menu_more").show();
                $("#m_menu_box").css("width", "245px");
            })
            $(".menu_more").mouseleave(function() {
                $(this).find(".menu_more").hide();
                $("#m_menu_box").css("width", "100px");
            })
            $(".leftNav").find("li").mouseleave(function() {
                $(this).find(".menu_more").hide();
                $("#m_menu_box").css("width", "100px");
            })
            function bbs_bar_max() {
                $('#mall_menu').stop(true, true).delay(150).animate({ left: 0 }, 300, "linear", bbs_bar_max_status);
                $(".nav_ico2").show();

            }
            function bbs_bar_min() {
                $('#mall_menu').stop(true, true).delay(150).animate({ left: -100 }, 300, "linear", bbs_bar_min_status);
                $(".nav_ico2").hide();

            }
            function bbs_bar_min_status() {
                $(".nav_ico").show();
            }
            function bbs_bar_max_status() {
                $(".nav_ico").hide();
            }
            $("#m_menu_box").css("height", window.screen.height);
            $(".nav_ico,#m_menu_box").bind("click", bbs_bar_max);
            $("#mall_menu").bind("mouseleave", bbs_bar_min);
        </script>

        <div class="jq_search">
            <div class="search ">
                <form id="form2">
                <div class="search_form clearfix">
                    <input type="text" class="input_txt floatL" placeholder="商品名称" name="cName" value='<%= EyouSoft.Common.Utils.GetQueryStringValue("cName") %>'>
                    <input type="button" id="SearchBnt" class="icon_search_i floatR" />
                </div>
                </form>
            </div>
        </div>
        <!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
        <div class="mall_nav mt10">
            <ul>
                <li><a href="ModList.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        会员供销商城</div>
                </a></li>
                <li><a href="ShangChengLianMeng.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        购物广场联盟</div>
                </a></li>
                <li><a href="XiuXianYuLe.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        休闲娱乐会所</div>
                </a></li>
                <li><a href="ShangLvEJia.aspx">
                    <div class="radiusl ico">
                    </div>
                    <div class="title">
                        天下商旅e家</div>
                </a></li>
            </ul>
        </div>
        <div class="mall_list mt10">
            <h2>
                热销商品</h2>
            <ul class="clearfix">
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="img_box">
                                <a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                    <img src='<%# retuImgUrl(Eval("ProductImgs")) %>'></a></div>
                            <div class="txt_box">
                                <dl>
                                    <dt><a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                        <%#  Eval("ProductName")%></a></dt>
                                    <dd>
                                        <i class="line_x">¥<%# Eval("MarketPrice","{0:F0}") %></i></dd>
                                    <dd class="txt">
                                        <i class="font_yellow">¥
                                            <%# GetJINE( Eval("SalePrice"),Eval("MarketPrice"))%></i></dd>
                                </dl>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        $("#SearchBnt").click(function() {
            $("#form2").submit();
        })
        $(".main_visual").css("margin-top", "56px");
    </script>
    
      <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
        var wx_jsapi_config = <%=weixin_jsapi_config %>;
        wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>

</body>
</html>
