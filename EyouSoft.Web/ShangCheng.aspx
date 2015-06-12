<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/FrontFixed.Master"
    CodeBehind="ShangCheng.aspx.cs" Inherits="EyouSoft.Web.ShangCheng" %>

<%@ Register Src="UserControl/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="/css/style.css" rel="stylesheet" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $('#newsSlider').loopedSlider({
                autoStart: 3000
            });
            $('.validate_Slider').loopedSlider({
                autoStart: 3000
            });
        });
    </script>

    <script type="text/javascript">
        //左侧导航
        $(document).ready(function() {
            $('.L_side01box > li').mousemove(function() {
                $(this).find('.sub-menu').show();
                if ($.browser.msie) {
                    if (parseFloat($.browser.version) <= 6) {
                        $(this).find('.sub-menu').bgiframe();
                    }
                }
                $(this).addClass('curr');
            });
            $('.L_side01box > li').mouseleave(function() {
                $(this).find('.sub-menu').hide();
                $(this).removeClass('curr');
            });
            $(".mainbox").css("overflow", "visible");
        });

        
        
    </script>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div class="leftbox">
        <!------分类-------->
        <div class="mall_type">
            <h2>
                全部商品分类</h2>
            <ul class="L_side01box">
                <asp:Repeater ID="rptMenu" runat="server">
                    <ItemTemplate>
                        <li <%# Container.ItemIndex%2==0?" class='bg'":"" %>>
                            <div class="type_name">
                                <h3>
                                    <a href="ShangCheng.aspx?lid=<%# Eval("TypeID") %>">
                                        <%# Eval("TypeName")%></a></h3>
                                <s></s>
                            </div>
                            <div class="sub-menu">
                                <%# getMenu(Eval("TypeID"))%>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div class="rightbox">
        <!------n_banner-------->
        <div class="banner n_banner" id="newsSlider">
            <div class="piclist">
                <ul class="slides">
                    <%= toplist%>
                    <%--<asp:Repeater runat="server" ID="Repeater1">
                        <ItemTemplate>
                            <li><a href="ShangChengXiangQing.aspx?id=<%# Eval("ProductID") %>" target="_blank">
                                <img src="<%#Eval("ImgUrl") %>" /></a></li>
                        </ItemTemplate>
                    </asp:Repeater>--%>
                </ul>
                <div class="validate_Slider">
                </div>
                <ul class="pagination">
                    <%= dianlist%>
                    <%--<li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>--%>
                </ul>
            </div>
        </div>
        <!------mall-search-------->
        <div class="qzh-search mall-search margin_T10">
            <form id="serForm">
            商品名称：<input type="text" class="formsize180 input-style" name="cName" id="cName" />
            <input type="submit" value="搜索>>" class="line-s-btn" />
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Adv" runat="server">
    <div class="mainbox" style="margin-top: 0;">
        <div class="mall_piclist">
            <ul>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li><a href="ShangChengXiangQing.aspx?ID=<%# Eval("ProductID")%>">
                            <img src="<%# retuImgUrl(Eval("ProductImgs"))%>" /></a>
                            <div class="m_title">
                                <%#Eval("ProductName")%></div>
                            <div class="m_cont">
                                <%# EyouSoft.Common.Utils.GetText2(Eval("Remark").ToString(), 40, true)%>
                            </div>
                            <div class="m_price">
                                <div class="rain-price">
                                    <p>
                                        会员价：<font class="font14 font_yellow">¥</font> <font class="font24 font_yellow">
                                            <%# GetJINE( Eval("SalePrice"),Eval("MarketPrice"))%></font>
                                        <%#Eval("Unit")%></p>
                                    <p class="font_95">
                                        门市价:¥
                                        <%#Eval("MarketPrice", "{0:F0}")%><%#Eval("Unit")%></p>
                                </div>
                                <div class="rain-btn">
                                    <a href="ShangChengXiangQing.aspx?ID=<%# Eval("ProductID")%>" class="chakan_btn">查看
                                        >></a></div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
   
    <div class="page" id="page">
    </div>
 </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Foot">
    <!------foot-------->
    <%--<uc2:Footer ID="Footer1" runat="server" />--%>

    <script type="text/javascript">
        pagingConfig = { pageSize: 16, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>

    <form runat="server" id="form1">
    </form>
</asp:Content>
