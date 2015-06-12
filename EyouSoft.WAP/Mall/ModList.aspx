<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModList.aspx.cs" Inherits="EyouSoft.WAP.Mall.ModList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">


    <script src="/js/jquery_cm.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="会员供销商城" />
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

        <form id="form2">
        <div class="jq_search">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="text" class="input_txt floatL" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("cName") %>"
                        name="cName" placeholder="商品名称">
                    <input name="" type="button" class="icon_search_i floatR" id="searchBtn">
                </div>
            </div>
        </div>
        </form>
        <div class="mall_list" style="padding-top: 56px;">
            <h2>
                <asp:Label ID="lblTypeName" runat="server" Text=""></asp:Label>
            </h2>
            <ul class="clearfix">
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="img_box">
                                <a href="MoDetail.aspx?ID=<%# Eval("ProductID")%>">
                                    <img src='<%# retuImgUrl(Eval("ProductImgs")) %>' /></a></div>
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
        $("#searchBtn").click(function() {
            $("#form2").submit();
        })
    </script>

</body>
</html>
