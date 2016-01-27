<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxLine_List.aspx.cs"
    Inherits="EyouSoft.WAP.CommonPage.ajaxLine_List" %>

<asp:repeater id="rptlist" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="jq_img">
                                            <a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>">
                                                <img src="<%# getImgSrc(Eval("TeSeFilePath"),Eval("XianLuId").ToString())%>"></a>
                                            <div class="line_txt">
                                                <%# getCityName(Eval("DepCityId"))%>出发
                                                <span class="gys_code">
                                                    <%# getSourceJP( Eval("Line_Source"))%></span>
                                            </div>
                                        </div>
                                        <dl>
                                            <dt><a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                                class="fontblue">
                                                <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></a></dt>
                                            <dd>
                                                <a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                                    class="floatR font_yellow">更多</a>团期：
                                                <%# getLastDate(Eval("Tours"))%></dd>
                                            <dd class="wid font_gray">
                                                <i class="line_x">
                                                    <%# getHYJ("门市",EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%></i></dd>
                                            <dd class="wid R">
                                                <span class="font_yellow">
                                                    <%# getHYJ("优惠", EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>
                                                </span>起
                                            </dd>
                                        </dl>
                                    </li>
                                </ItemTemplate>
                            </asp:repeater>
