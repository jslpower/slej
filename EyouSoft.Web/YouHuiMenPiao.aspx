<%@ Page Title="景区" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="YouHuiMenPiao.aspx.cs" Inherits="EyouSoft.Web.YouHuiMenPiao" %>

<%@ Register Src="UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Hotel.ascx" TagName="Hotel" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TravelTools.ascx" TagName="TravelTools" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="head" runat="server">

    <script src="JS/ajaxpagecontrols.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script type="text/javascript">

        var instance = {};

        instance.animate = function() {
            $('#newsSlider').loopedSlider({
                autoStart: 3000
            });
            $('.validate_Slider').loopedSlider({
                autoStart: 3000
            });
        };
        onload = instance.animate;
    </script>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Left">
    <%--<uc1:Search runat="server" ID="search1" />
    <div class="L_side01 margin_T10">
            <uc1:TuanGou runat="server" ID="TuanGou1" />
        </div>--%>
    <uc1:Hotel runat="server" ID="Hotel1" />
    <uc1:TravelTools runat="server" ID="TravelTools1" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Right">
    <!------n_banner-------->
    <div class="banner n_banner" id="newsSlider">
        <div class="piclist">
            <asp:Repeater ID="Repeater2" runat="server">
                <HeaderTemplate>
                    <ul class="slides">
                </HeaderTemplate>
                <ItemTemplate>
                    <li style='position: absolute; left: <%# (830 * Container.ItemIndex) %>px; display: block;'>
                        <a target='_blank' href='<%#Eval("AdvLink")%>'>
                            <img src='<%#Eval("ImgPath")%>'></a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    <div class="validate_Slider">
                    </div>
                    <ul class="pagination">
                        <%  string lie = ""; for (int i = 1; i <= Repeater2.Items.Count; i++) { lie += "<li><a href='#'>" + i + "</a></li>"; } Response.Write(lie);%>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!------jinqu_search-------->
    <div class="jinqu_search margin_T10">
        <div class="jinqu_searchbox">
            <div class="qzh-search">
                <form>
                <b class="font14">省份：</b><%= GetProvince()%><%--<%=Html.DropDownListFor(x=>x.ProvinceId,new Linq.Web.SelectListItem{  Text="请选择", }) %>--%>&nbsp;&nbsp;
                <b class="font14">城市：</b><select name="CityId" id="CityId"><%=GetCity() %></select><%--<%=Html.DropDownListFor(x=>x.CityId,new Linq.Web.SelectListItem{  Text="请选择", }) %>--%>&nbsp;&nbsp;<b
                    class="font14">景点：</b><%=Html.TextBoxFor(x => x.ScenicName, new { @class="formsize180 input_bluebk"  })%>
                <input type="button" value="搜索 >>" onclick="instance.Search()" class="line-s-btn" />
                </form>
            </div>
        </div>
    </div>
    <div class="jinqu_box margin_T10">
        <div class="B_Titel">
            优惠门票</div>
        <div class="B_piclist">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li style="width: 252px;"><a href="YouHuiMenPiaoXiangQing.aspx?ScenicId=<%#Eval("ScenicId")%>&TicketsId=<%#Eval("TicketFirst.TicketsId") %>">
                            <img src="<%#Eval("ImgFirst.Address") %>" /></a>
                            <dl>
                                <dt><a href="YouHuiMenPiaoXiangQing.aspx?ScenicId=<%#Eval("ScenicId")%>&TicketsId=<%#Eval("TicketFirst.TicketsId") %>">
                                    <%#Eval("ScenicName")%></a></dt>
                                <dd>
                                    <strong>挂牌价：</strong><font class="font18 font_yellow">¥<strike><%# ((decimal)Eval("TicketFirst.RetailPrice")).ToString("0")%></strike></span></font>起/人</dd><dd><strong>零售价：</strong><font
                                        class="font18 font_yellow">¥<strike><%# ((decimal)Eval("TicketFirst.WebsitePrices")).ToString("0")%></strike></font>起/人</dd>
                                <% if (IsShowHuiYuan())
                                   { %>
                                <dd>
                                    <strong>优惠价：</strong><font class="font18 font_yellow">¥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("TicketFirst.DistributionPrice"), (decimal)Eval("TicketFirst.WebsitePrices"), MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("TicketFirst.FeeSetting"), FeeTypes.门票).ToString("0")%></font>起/人</dd>
                                <%} %>
                            </dl>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="page" id="page">
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Foot">

    <script type="text/javascript">
        var pagingConfig = { pageSize: <%=Model.SearchInfo.PageInfo.PageSize %>, pageIndex: <%=Model.SearchInfo.PageInfo.PageIndex %>, recordCount: <%=Model.SearchInfo.PageInfo.TotalCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>

    <script type="text/javascript">

        //pcToobar.init({ pID: "#ProvinceId", cID: '#CityId' });
        var instance = new InitialPageInputTagValue();
        instance.Init();
        $("#ProvinceId").change(function() {
        $.ajax({
        type: "post", url: "/YouHuiMenPiao.aspx?gettype=city&ProvinceId=" + $("#ProvinceId").val(), dataType: "text",
            success: function(response) {
                $("#CityId").html(response);
            }
        });
         });
    </script>

</asp:Content>
