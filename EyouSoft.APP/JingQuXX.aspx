<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingQuXX.aspx.cs" Inherits="EyouSoft.WAP.JingQuXX" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title><%=FenXiangBiaoTi %></title>
    <link href="/css/slider.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="cordova.js" type="text/javascript"></script>
    <script src="js/enow.core.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $(".ck_more").click(function() {
                var classname = $(this).find("a").attr("class");
                if (classname == "down") {
                    $(".jq_more").show();
                    $(this).find("a").removeClass("down").addClass("up");
                    $(".up").html("收起");
                }
                else {
                    $(".jq_more").hide();
                    $(this).find("a").removeClass("up").addClass("down");
                    $(".down").html("展开");
                }
            })
        })

    </script>

    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <%--<div class="jq_banner" id="newsSlider">
    
            <div class="piclist">
                 <ul class="slides clearfix"> 
                 <%= toplist%>
                 </ul>
                      
                 <div class=validate_Slider></div>
                 
                 <div class="pagination">
                 <%= dianlist%>
                 </div>
           </div>
         </div>
     --%>
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <div class="jq_cont">
            <h2>
                <%=ScenicName%></h2>
            <p class="font13 font_gray mt10">
                <span class="right_txt line_x floatR">零售价：<strike><%=WebsitePrices == 0 ? "空" : "¥"+WebsitePrices.ToString("0") + "元起/人"%></strike></span><i
                    class="line_x">挂牌价：<strike><%=RetailPrice == 0 ? "空" : "¥" + RetailPrice.ToString("0")+"元起/人"%></strike></i></p>
            <p class="font13 font_gray mt10">
                <%if (UIsLogin)
                                               { %><%if (HUserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                                                { %>代理价<%}
                                                                else if (HUserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                                                { %>贵宾价<%}
                                                                else if (HUserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                                                { %>代销价<%}
                                                                else if (HUserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                                                { %>员工价<%}
                                                                else
                                                                { %>优惠价<%} %><%}else{ %>优惠价<%} %>：<span class="font_yellow"><i class="font18"><%if (UIsLogin){ %><%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(DistributionPrice, WebsitePrices, (EyouSoft.Model.Enum.MemberTypes)EyouSoft.Common.Utils.GetInt(((int)HUserType).ToString()), FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票) == 0 ? "空" : "¥" + EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(DistributionPrice, WebsitePrices, (EyouSoft.Model.Enum.MemberTypes)EyouSoft.Common.Utils.GetInt(((int)HUserType).ToString()), FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0") + "元起/人"%><%} else{ %><%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(DistributionPrice, WebsitePrices, EyouSoft.Model.Enum.MemberTypes.普通会员, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票) == 0 ? "空" : "¥" + EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(DistributionPrice, WebsitePrices, EyouSoft.Model.Enum.MemberTypes.普通会员, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0") + "元起/人"%><%} %></i></span></p>
            <p class="paddT font12">
                电话：<asp:Literal ID="JingQuTel" runat="server"></asp:Literal></p>
            <p class="font12">
                景区地址：<asp:Literal ID="JingQuAddress" runat="server"></asp:Literal></p>
            <p class="font12">
                景区等级：<asp:Literal ID="JingQuLv" runat="server"></asp:Literal></p>
        </div>
        <div class="ck_more">
            <a href="javascript:void(0)" class="up">收起</a></div>
        <div class="jq_more">
            <asp:Repeater ID="ticklist" runat="server">
                <ItemTemplate>
                    <div class="jq_cont">
                        <h2>
                            <a href="javascript:void(0)" name="XiangQing" class="Rtxt font_blue">产品详情</a><%#Eval("EnName")%></h2>
                        <p class="font13 font_gray mt10">
                            <span class="right_txt line_x floatR">零售价：<strike>￥<%#((decimal)Eval("WebsitePrices")).ToString("0")%></strike>
                                元/人</span><i class="line_x">挂牌价：<strike>￥<%#((decimal)Eval("RetailPrice")).ToString("0")%></strike>
                                    元/人</i></p>
                        <p class="font13 font_gray mt10">
                            <a href="/JingQuOrder.aspx?TicketsId=<%# Eval("TicketsId")%>" class="yudin_btn">预订</a><%if (UIsLogin)
                                                                                                                    { %>
                            <%if (HUserType == EyouSoft.Model.Enum.MemberTypes.代理)
                              { %>
                            代理价：<span class="font_yellow">¥<i class="font18"><%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.代理, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%>
                                <%}
                              else if (HUserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                              { %>
                                贵宾价：<span class="font_yellow">¥<i class="font18"><%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.贵宾会员, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%>
                                    <%}
                              else if (HUserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                              { %>
                                    代销价：<span class="font_yellow">¥<i class="font18"><%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.免费代理, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%>
                                        <%}
                              else if (HUserType == EyouSoft.Model.Enum.MemberTypes.员工)
                              { %>
                                        员工价：<span class="font_yellow">¥<i class="font18"><%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.员工, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%>
                                            <%}
                              else
                              { %>优惠价：<span class="font_yellow">¥<i class="font18"><%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.普通会员, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%><%} %><%}else{ %>优惠价：<span class="font_yellow">¥<i class="font18"><%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.普通会员, FeeSettings, EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%><%} %></i></span>元/人</p>
                        <p class="paddT font12">
                            类型：<%# Eval("TypeName") %></p>
                        <p class="font12">
                            门票时限：<%# Eval("EndTime") != null ? Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd") : "无"%></p>
                        <div class="user-mask" style="display: none;">
                            <div class="user-mask-cnt">
                                <%#Eval("Description")%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="jq_tab mt10" id="n4Tab">
            <div class="jq_TabTitle">
                <ul class="clearfix">
                    <li id="n4Tab_Title0" onclick="nTabs('n4Tab',this);" class="active"><a href="javascript:void(0);">
                        景区介绍</a></li>
                    <li id="n4Tab_Title1" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                        交通指南</a></li>
                </ul>
            </div>
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                    <div class="jq_xx_cont">
                        <%=Description%>
                    </div>
                </div>
                <div id="n4Tab_Content1" class="none">
                    <div class="jq_xx_cont">
                        <%=Traffic%>
                    </div>
                </div>
            </div>
        </div>
        <div class="basic_t mt10">
            其他相关门票</div>
        <div class="jq_list mt10">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li><a href="/JingQuXX.aspx?ScenicId=<%#Eval("ScenicId")%>">
                            <div class="jq_img">
                                <%#GetScenicImg(Eval("ImgList"))%></div>
                            <dl>
                                <dt>
                                    <%# EyouSoft.Common.Utils.GetText2(Eval("ScenicName").ToString(), 12, true)%></dt>
                                <dd>
                                    <%# Eval("ScenicLevel")%>
                                </dd>
                                <dd class="wid">
                                    零售价：<i class="line_x">¥<%# Eval("WebPrice") == "0" ? "空" : "<i class=\"line_x\">¥" + Convert.ToDecimal(Eval("WebPrice")).ToString("0") + "元起/人</i>"%></i>
                                    起/人</dd>
                                <dd class="wid R">
                                    优惠价：<span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("SettlementPrice"), (decimal)Eval("WebPrice"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("FeeSetting"), EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%></i></span>起/人</dd>
                            </dl>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="paddB">
                <a href="/JingQu.aspx" class="y_btn">查看所有门票 ></a></div>
        </div>
    </div>
</body>

<script type="text/javascript">
    $("a[name=XiangQing]").click(function() {
        $(this).closest(".jq_cont").find(".user-mask").show();
        $('body').css("overflow", "hidden");
    })
    $(".user-mask").click(function() {
        $(".user-mask").hide();
        $('body').css("overflow", "auto");
    })
</script>

<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

<script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
</script>

<script type="text/javascript">
    wx.ready(function() {
        //分享到朋友圈
        wx.onMenuShareTimeline({
            title: '<%=FenXiangBiaoTi %>',
            link: '<%= FenXiangLianJie %>',
            imgUrl: '<%=FenXiangTuPianFilepath %>'
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

</html>
