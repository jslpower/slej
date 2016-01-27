<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoDefault.ascx.cs"
    Inherits="EyouSoft.WAP.userControl.TwoDefault" %>
<div class="home_tab" id="n4Tab">
    <div class="home_TabTitle">
        <ul class="clearfix">
            <li id="n4Tab_Title0" onclick="nTabs('n4Tab',this);" class="active"><a href="javascript:void(0);">
                特价门票</a></li>
            <li id="n4Tab_Title1" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                周边旅游</a></li>
            <li id="n4Tab_Title2" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                国内旅游</a></li>
            <li id="n4Tab_Title3" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                出境旅游</a></li>
        </ul>
    </div>
    <div class="home_TabContent">
        <div id="n4Tab_Content0">
            <div class="jq_list">
                <ul>
                    <asp:Repeater runat="server" ID="rpt_MenPiao">
                        <ItemTemplate>
                            <li><a href="/JingQuXX.aspx?ScenicId=<%#Eval("ScenicId")%>">
                                <div class="jq_img">
                                    <%#GetScenicImg(Eval("ImgList"))%></div>
                                <dl>
                                    <dt>
                                        <%# EyouSoft.Common.Utils.GetText2(Eval("ScenicName").ToString(), 12, true)%></dt>
                                    <dd class="wid">
                                        <%# Eval("ScenicLevel")%>
                                        <%--<span class="city_bg">
                                            <%# Eval("CityName")%></span>--%></dd>
                                    <dd class="wid R">
                                        挂牌：<%# Eval("RetailPrice") == "0" ? "空" : "<i class=\"line_x\">¥" + Convert.ToDecimal(Eval("RetailPrice")).ToString("0") + "起</i>"%></dd>
                                    <dd class="wid">
                                        零售：<%# Eval("WebPrice") == "0" ? "空" : "<i class=\"line_x\">¥" + Convert.ToDecimal(Eval("WebPrice")).ToString("0") + "起</i>"%></dd>
                                    <dd class="wid R">
                                        优惠：<span class="font_yellow">¥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("SettlementPrice"), (decimal)Eval("WebPrice"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("FeeSetting"), EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%></span>起</dd>
                                </dl>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="paddB"><a href="/JingQu.aspx" class="y_btn">查看更多></a></div>
            </div>
        </div>
        <div id="n4Tab_Content1" style="display:none">
            <div class="jq_list line_list">
                <ul>
                    <asp:Repeater runat="server" ID="rpt_ZhouBian">
                        <ItemTemplate>
                            <li><a href="Line_Info.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.周边短线 %>">
                                <div class="jq_img">
                                    <%#GetRouteImgPath(Eval("TeSeFilePath"), Eval("XianLuId"))%>
                                    <div class="line_txt"><%# getCityName(Eval("DepCityId"))%><span class="gys_code"><%# getSourceJP( Eval("Line_Source"))%></span></div>
                                </div>
                                <dl>
                                    <dt><span class="font_blue">
                                        <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></span></dt>
                                        <dd><span class="floatR font_yellow">更多</span>团期：<span class="font_yellow"><%# getLastDate(Eval("Tours"))%></span></dd>
                                    <dd class="wid font_gray">
                                        <i class="line_x">¥<%# Convert.ToDecimal(Eval("SCJCR")).ToString("f0")%></i></dd>
                                    <dd class="wid R">
                                        <span class="font_yellow">¥<%# getHYJ(EyouSoft.Model.Enum.FeeTypes.周边线路, Eval("Tours"))%>起</span></dd>
                                </dl>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="paddB"><a href="/Line_List.aspx?type=3" class="y_btn">查看更多></a></div>
            </div>
        </div>
        <div id="n4Tab_Content2" style="display:none">
            <div class="jq_list line_list">
                <ul>
                    <asp:Repeater runat="server" ID="rpt_GuoNeiRoute">
                        <ItemTemplate>
                            <li><a href="Line_Info.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.国内长线 %>">
                                <div class="jq_img">
                                    <%#GetRouteImgPath(Eval("TeSeFilePath"), Eval("XianLuId"))%>
                                    <div class="line_txt"><%# getCityName(Eval("DepCityId"))%><span class="gys_code"><%# getSourceJP( Eval("Line_Source"))%></span></div>
                                </div>
                                <dl>
                                    <dt><span class="font_blue">
                                        <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></span></dt>
                                        <dd><span class="floatR font_yellow">更多</span>团期：<span class="font_yellow"><%# getLastDate(Eval("Tours"))%></span></dd>
                                    <dd class="wid font_gray">
                                        <i class="line_x">¥<%# Convert.ToDecimal(Eval("SCJCR")).ToString("f0")%></i></dd>
                                    <dd class="wid R">
                                        <span class="font_yellow">¥<%# getHYJ(EyouSoft.Model.Enum.FeeTypes.国内线路, Eval("Tours"))%>起</span></dd>
                                </dl>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="paddB"><a href="/Line_List.aspx?type=1" class="y_btn">查看更多></a></div>
            </div>
        </div>
        <div id="n4Tab_Content3" style="display:none">
            <div class="jq_list line_list">
                <ul>
                    <asp:Repeater runat="server" ID="rpt_ChuJingRoute">
                        <ItemTemplate>
                            <li><a href="Line_Info.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.出境线路 %>">
                                <div class="jq_img">
                                    <%#GetRouteImgPath(Eval("TeSeFilePath"), Eval("XianLuId"))%>
                                    <div class="line_txt"><%# getCityName(Eval("DepCityId"))%><span class="gys_code"><%# getSourceJP( Eval("Line_Source"))%></span></div>
                                </div>
                                <dl>
                                    <dt><span class="font_blue">
                                        <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></span></dt>
                                        <dd><span class="floatR font_yellow">更多</span>团期：<span class="font_yellow"><%# getLastDate(Eval("Tours"))%></span></dd>
                                    <dd class="wid font_gray">
                                        <i class="line_x">¥<%# Convert.ToDecimal(Eval("SCJCR")).ToString("f0")%></i></dd>
                                    <dd class="wid R">
                                        <span class="font_yellow">¥<%# getHYJ(EyouSoft.Model.Enum.FeeTypes.国际线路, Eval("Tours"))%>起</span></dd>
                                </dl>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="paddB"><a href="/Line_List.aspx?type=2" class="y_btn">查看更多></a></div>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    $("#" + tabObj + "_Title" + i).removeClass("normal").addClass("active");
                    $("#" + tabObj + "_Content" + i).show();
                } else {
                    $("#" + tabObj + "_Title" + i).removeClass("active").addClass("normal");
                    $("#" + tabObj + "_Content" + i).hide();
                }
            }
        }
    </script>
