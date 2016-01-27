<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxXianLuList.aspx.cs"
    Inherits="EyouSoft.WAP.CommonPage.ajaxXianLuList" %>

<asp:repeater id="rptlist" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="jq_img">
                                            <img src="<%# getImgSrc(Eval("TeSeFilePath"),Eval("XianLuId"))%>">
                                            <div class="line_txt">
                                                <%# getCityName(Eval("DepCityId"))%></div>
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
                                                门市价：<i class="line_x"><%# getHYJ("门市",EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%></i></dd>
                                            <dd class="wid R">
                                                优惠价：<span class="font_yellow">
                                                    <%# getHYJ("优惠", EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>
                                                </span>
                                            </dd>
                                        </dl>
                                    </li>
                                </ItemTemplate>
                            </asp:repeater>
