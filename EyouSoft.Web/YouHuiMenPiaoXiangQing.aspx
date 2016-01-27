<%@ Page Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="YouHuiMenPiaoXiangQing.aspx.cs" Inherits="EyouSoft.Web.YouHuiMenPiaoXiangQing" %>

<%@ Register Src="UserControl/Share.ascx" TagName="Share" TagPrefix="uc1" %>
<%@ Register Src="UserControl/ZhuCe.ascx" TagName="ZhuCe" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Hotel2.ascx" TagName="Hotel2" TagPrefix="uc1" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <link rel="Stylesheet" href="Css/ref.css" />
    <style type="text/css">
        .imgtext li
        {
            height: 25px;
            line-height: 25px;
        }
        .imgtext li label
        {
            height: 25px;
            line-height: 25px;
            float: left;
        }
        .imgtext li font
        {
            height: 25px;
            line-height: 25px;
        }
        .imgtext li b
        {
            height: 25px;
            line-height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox">
        <div class="n_title">
            &gt; 优惠门票</div>
        <div class="line_xx_box margin_T10">
            <div class="line_xx_tit">
                <h1>
                    <%=Model.ScenicArea.ScenicName%></h1>
                <div class="fenxiang">
                    <uc1:Share runat="server" ID="Share1" />
                </div>
            </div>
            <div class="line_xx_cont fixed">
                <div class="jinqu_xx_left">
                    <div id="ifocus">
                        <div id="ifocus_pic">
                            <div style="top: 0px; left: 0px" id="ifocus_piclist">
                                <ul>
                                    <li><a href="#" target="_blank">
                                        <img id="showImg" alt="<%=img1Desc %>" src="<%=img1Address %>"></a></li>
                                </ul>
                            </div>
                        </div>
                        <div id="ifocus_btn">
                            <ul>
                                <asp:Repeater ID="Repeater4" runat="server">
                                    <ItemTemplate>
                                        <li class="<%# Container.ItemIndex == 0 ? "current" : "normal"%>" onclick="instance.selectShowImg(this,$(this).children().eq(0)[0])">
                                            <img alt="<%#Eval("Description")%>" src="<%#Eval("Address")%>"></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="jinqu_xx_right">
                    <ul class="imgtext">
                        <li>
                            <label>
                                挂牌价：</label><font class="font13 font_yellow"><strike><%=Model.RetailPrice == 0 ? "空" : "¥" + Model.RetailPrice.ToString("0")+"元起"%></strike></font><font>&nbsp;&nbsp;&nbsp;&nbsp;网络零售价：</font><font
                                    class="font13 font_yellow"><strike><%=Model.WebsitePrices == 0 ? "空" : "¥"+Model.WebsitePrices.ToString("0") + "元起"%></strike></font><font>&nbsp;&nbsp;&nbsp;&nbsp;优惠价：</font><font
                                        class="font13 font_yellow"><%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.普通会员, Model.FeeSettings, FeeTypes.门票) == 0 ? "空" : "¥" + EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.普通会员, Model.FeeSettings, FeeTypes.门票).ToString("0") + "元起"%></font><font></font></li>
                        <li>
                            <label>
                                电话：</label><b class="fontblue">&nbsp;<%=Model.ScenicArea.ContactTel%></b></li>
                        <li>
                            <label>
                                传真：</label><b class="fontblue">&nbsp;<%=Model.ScenicArea.ContactFax%></b></li>
                        <li>
                            <label>
                                景区地址：</label>&nbsp;<%=Model.ScenicArea.CnAddress%></li>
                        <li>
                            <label>
                                景区等级：</label>&nbsp;<b><font class="font14 font_yellow"><%=Model.ScenicArea.ScenicLevel.HasValue?((int)Model.ScenicArea.ScenicLevel.Value==9?"未评级":Model.ScenicArea.ScenicLevel.Value+"&nbsp;级景区"):"未知" %></font></b></li>
                        <li>
                            <label>
                                网址：</label>&nbsp;<a style="text-decoration: underline; color: Blue;" href="<%=Model.ScenicArea.NetAddress%>"><%=Model.ScenicArea.NetAddress%></a></li>
                        <li>
                            <label>
                                导航：</label>
                            <div class="jinqu_dh" style="float: left; width: 340px;">
                                <a class="cur" href="#a1" onclick="instance.switchTab2('jingqujieshao',this)">景区介绍</a><a
                                    href="#a2" onclick="instance.switchTab2('jingqutupian',this)">景区图片</a><a href="#a4"
                                        onclick="instance.switchTab2('jiaotongzhinan',this)">交通指南</a></div>
                        </li>
                    </ul>
                    <div class="page_code" style="bottom: 10px; right: 10px;">
                        <div class="code_box">
                            <div class="code_small">
                                <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                            <div class="code_big" style="display: none;">
                                <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                        </div>
                        <p class="font_yellow">
                            扫描二维码，分享手机版</p>
                    </div>
                </div>
            </div>
            <uc1:ZhuCe ID="ZhuCe1" runat="server" />
            <div class="line_xx_cont">
                <% if (Model.IsShowShenQing)
                   { %>
                <div class="jinqu_tableT">
                    相关门票</div>
                <table class="jinqu_table" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <th>
                                门票名称
                            </th>
                            <th>
                                类型
                            </th>
                            <th>
                                门票时限
                            </th>
                            <th>
                                挂牌价
                            </th>
                            <th>
                                网络零售价
                            </th>
                            <%if (IsShowHuiYuan())
                              {%>
                            <th>
                                优惠价
                            </th>
                            <%} %>
                            <%if (IsShowErJiDaiLi())
                              {%>
                            <th>
                                代销价
                            </th>
                            <%if (IsShowGuiBin())
                              {%>
                            <th>
                                贵宾价
                            </th>
                            <%} %>
                            <%} %>
                            <%if (IsShowDaiLi())
                              {%>
                            <th>
                                代理价
                            </th>
                            <%} %>
                            <%if (IsShowShengQingGuiBin())
                              {%>
                            <th>
                                申请贵宾身份
                            </th>
                            <%} %>
                            <% if (IsShowShengQingDaiLi())
                               {%>
                            <th>
                                申请代理身份
                            </th>
                            <%}%>
                            <%if (IsShowYuanGong())
                              {%>
                            <th>
                                员工价
                            </th>
                            <%} %>
                        </tr>
                        <tr>
                            <td align="left">
                                <%=Html.HiddenFor(x=>x.TicketsId) %>
                                <%=Model.EnName%><a class="xiangxi" href="javascript:;" onclick="instance.chaKanXiangQing(this,1);return false;">详情&gt;&gt;</a>
                            </td>
                            <td align="middle">
                                <%= Model.TypeName%>
                            </td>
                            <td align="middle">
                                <%=Model.EndTime.HasValue ? Model.EndTime.Value.ToString("yyyy-MM-dd") : ""%>为止
                            </td>
                            <td align="middle">
                                <b class="fontgreen"><strike>￥<%=Model.RetailPrice.ToString("0")%></strike></b>
                            </td>
                            <td align="middle">
                                <b class="fontgreen"><strike>￥<%=Model.WebsitePrices.ToString("0")%></strike></b>
                            </td>
                            <%if (IsShowHuiYuan())
                              {%>
                            <td align="middle">
                                <b class="price_red">￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.普通会员, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                            </td>
                            <%} %>
                            <% if (IsShowErJiDaiLi())
                               { %>
                            <td align="middle">
                                <b class="price_red">￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.免费代理, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                            </td>
                            <%} %>
                            <% if (IsShowGuiBin())
                               { %>
                            <td align="middle">
                                <b class="price_red">￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                            </td>
                            <%} %>
                            <% if (IsShowDaiLi())
                               { %>
                            <td align="middle">
                                <b class="price_red">￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.代理, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                            </td>
                            <%} %>
                            <% if (IsShowYuanGong())
                               { %>
                            <td align="middle">
                                <b class="price_red">￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.员工, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                            </td>
                            <%} %>
                            <% if (IsShowShengQingGuiBin())
                               {%>
                            <td align="middle">
                                <font class="font_gb">
                                    <%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSettings, FeeTypes.门票).ToString()%></font>，立省<font
                                        class="font_gb"><%=(EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, CurrentUser.UserType, Model.FeeSettings, FeeTypes.门票) - EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSettings, FeeTypes.门票)).ToString("0")%></font>元
                            </td>
                            <%} %>
                            <% if (IsShowShengQingDaiLi())
                               {%>
                            <td align="middle">
                                <font class="font_dl">
                                    <%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.代理, Model.FeeSettings, FeeTypes.门票).ToString()%></font>，立省<font
                                        class="font_dl"><%=(EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, CurrentUser.UserType, Model.FeeSettings, FeeTypes.门票) - EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.代理, Model.FeeSettings, FeeTypes.门票)).ToString("0")%></font>元
                            </td>
                            <%} %>
                        </tr>
                        <tr class="last_tr">
                            <td class="padd60" align="right">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                总额：￥<%=Model.WebsitePrices.ToString("0")%>
                            </td>
                            <%if (IsShowHuiYuan())
                              {%>
                            <td align="center">
                                总额：￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.普通会员, Model.FeeSettings, FeeTypes.门票).ToString("0")%>
                            </td>
                            <%} %>
                            <% if (IsShowErJiDaiLi())
                               { %>
                            <td align="center">
                                总额：￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.免费代理, Model.FeeSettings, FeeTypes.门票).ToString("0")%>
                            </td>
                            <%} %>
                            <% if (IsShowGuiBin())
                               { %>
                            <td align="center">
                                总额：￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSettings, FeeTypes.门票).ToString("0")%>
                            </td>
                            <%} %>
                            <% if (IsShowDaiLi())
                               { %>
                            <td align="center">
                                总额：￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.代理, Model.FeeSettings, FeeTypes.门票).ToString("0")%>
                            </td>
                            <%} %>
                            <% if (IsShowYuanGong())
                               { %>
                            <td align="center">
                                总额：￥<%=EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(Model.DistributionPrice, Model.WebsitePrices, MemberTypes.员工, Model.FeeSettings, FeeTypes.门票).ToString("0")%>
                            </td>
                            <%} %>
                            <%if (IsShowShengQingGuiBin())
                              {%>
                            <td align="center">
                                <a href="/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767">马上申请</a>
                            </td>
                            <%}%>
                            <% if (IsShowShengQingDaiLi())
                               {%>
                            <td align="center">
                                <a href="/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652">马上申请</a>
                            </td>
                            <% }%>
                        </tr>
                        <% int colspan = 5;
                           if (IsShowHuiYuan()) { colspan++; }
                           if (IsShowShengQingGuiBin()) { colspan++; }
                           if (IsShowShengQingDaiLi()) { colspan++; }
                           if (IsShowDaiLi()) { colspan++; }
                           if (IsShowGuiBin()) { colspan++; }
                           if (IsShowErJiDaiLi()) { colspan++; }
                           if (IsShowYuanGong()) { colspan++; }
                        %>
                        <tr class="noborder xq" style="display: none;">
                            <td colspan="<%=colspan %>">
                                <div class="detail">
                                    <%=Model.Description%>
                                </div>
                            </td>
                        </tr>
                        <%if (CurrentUser.UserType == MemberTypes.未注册用户)
                          { %>
                        <tr>
                            <td colspan="<%=colspan %>">
                                <table width="100%">
                                    <tr>
                                        <% if (CurrentUser.UserType == MemberTypes.未注册用户)
                                           { %>
                                        <td width="33%" align="center">
                                            <a style="margin-left: 55px;" class="btn02_blue zjyd" href="javascript:location='/lg.aspx?rurl='+encodeURIComponent(location.href);">
                                                立即注册</a>
                                        </td>
                                        <td align="left" width="33%">
                                            <b style="font-size: 14px;">已是会员/贵宾/代理:</b><a class="btn02_yellow zjyd" href="javascript:location='/lg.aspx?rurl='+encodeURIComponent(location.href);">立即登录</a>
                                        </td>
                                        <td width="33%" align="left">
                                            <b style="font-size: 14px; margin-left: 5px;">非会员：</b><a class="btn02_blue zjyd"
                                                href="javascript:;" onclick="instance.yuDing($('#TicketsId').val(),this,true);">
                                                直接预订</a>
                                        </td>
                                        <%} %>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%}
                          else
                          { %>
                        <tr>
                            <td colspan="<%=colspan %>">
                                <div style="padding-top: 4px; text-align: center;">
                                    <a class="btn02_blue zjyd" href="javascript:;" onclick="instance.yuDing($('#TicketsId').val(),this,true);">
                                        直接预订</a>
                                </div>
                            </td>
                        </tr>
                        <%} %>
                    </tbody>
                </table>
                <%} %>
                <div class="jinqu_tableT">
                    <%=Model.IsShowShenQing ? "其它门票" : "相关门票"%></div>
                <table class="jinqu_table" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <th>
                                门票名称
                            </th>
                            <th>
                                类型
                            </th>
                            <th>
                                门票时限
                            </th>
                            <th>
                                挂牌价
                            </th>
                            <th>
                                网络零售价
                            </th>
                            <%if (IsShowHuiYuan())
                              {%>
                            <th>
                                优惠价
                            </th>
                            <%} %>
                            <%if (IsShowErJiDaiLi())
                              {%>
                            <th>
                                代销价
                            </th>
                            <%} %>
                            <%if (IsShowGuiBin())
                              {%>
                            <th>
                                贵宾价
                            </th>
                            <%} %>
                            <%if (IsShowDaiLi())
                              {%>
                            <th>
                                代理价
                            </th>
                            <%} %>
                            <%if (IsShowYuanGong())
                              {%>
                            <th>
                                员工价
                            </th>
                            <%} %>
                            <th>
                                预订
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="Repeater1">
                            <ItemTemplate>
                                <tr>
                                    <td align="left">
                                        <%#Eval("EnName")%><a class="xiangxi" href="javascript:;" onclick="instance.chaKanXiangQing(this,2);return false;">详情&gt;&gt;</a>
                                    </td>
                                    <td align="middle">
                                        <%#Eval("TypeName")%>
                                    </td>
                                    <td align="middle">
                                        <%#  Eval("EndTime")!=null?((DateTime)Eval("EndTime")).GetDateTimeFormats('D')[0]:"" %>为止
                                    </td>
                                    <td align="middle">
                                        <b class="fontgreen"><strike>￥<%#((decimal)Eval("RetailPrice")).ToString("0")%></strike></b>
                                    </td>
                                    <td align="middle">
                                        <b class="fontgreen"><strike>￥<%#((decimal)Eval("WebsitePrices")).ToString("0")%></strike></b>
                                    </td>
                                    <%if (IsShowHuiYuan())
                                      {%>
                                    <td align="middle">
                                        <b class="price_red">￥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), MemberTypes.普通会员 , (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("FeeSetting"), FeeTypes.门票).ToString("0")%></b>
                                    </td>
                                    <%} %>
                                    <% if (IsShowErJiDaiLi())
                                       { %>
                                    <td align="middle">
                                        <b class="price_red">￥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), MemberTypes.免费代理, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                                    </td>
                                    <%} %>
                                    <% if (IsShowGuiBin())
                                       { %>
                                    <td align="middle">
                                        <b class="price_red">￥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), MemberTypes.贵宾会员, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                                    </td>
                                    <%} %>
                                    <% if (IsShowDaiLi())
                                       { %>
                                    <td align="middle">
                                        <b class="price_red">￥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), MemberTypes.代理, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                                    </td>
                                    <%} %>
                                    <% if (IsShowYuanGong())
                                       { %>
                                    <td align="middle">
                                        <b class="price_red">￥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("DistributionPrice"), (decimal)Eval("WebsitePrices"), MemberTypes.员工, Model.FeeSettings, FeeTypes.门票).ToString("0")%></b>
                                    </td>
                                    <%} %>
                                    <td align="middle">
                                        <a class="yudin_btn link01" href="javascript:;" onclick="instance.yuDing('<%#Eval("TicketsId")%>',this, false);return false;">
                                            <span>预订</span></a>
                                    </td>
                                </tr>
                                <% int colspan2 = 5;
                                   if (IsShowHuiYuan()) { colspan2++; }
                                   if (IsShowShengQingGuiBin()) { colspan2++; }
                                   if (IsShowShengQingDaiLi()) { colspan2++; }
                                   if (IsShowDaiLi()) { colspan2++; }
                                   if (IsShowGuiBin()) { colspan2++; }
                                   if (IsShowErJiDaiLi()) { colspan2++; }
                                   if (IsShowYuanGong()) { colspan2++; }
                                %>
                                <tr class="noborder" style="display: none;">
                                    <td colspan="<%= colspan2+1 %>">
                                        <div class="detail">
                                            <%#Eval("Description")%>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
        <!------qzh_xxtab-------->
        <div class="xingchen qzh_xxtab">
            <div class="B_TabTitle">
                <ul>
                    <li id="jingqujieshao" onclick="instance.switchTab(this.id,'tab_on')" class="tab_on">
                        <a href="javascript:;">景区介绍</a></li>
                    <li id="jingqutupian" onclick="instance.switchTab(this.id,'tab_on')"><a href="javascript:;">
                        景区图片</a></li>
                    <li id="jiaotongzhinan" onclick="instance.switchTab(this.id,'tab_on')"><a href="javascript:;">
                        交通指南</a></li></ul>
                <div class="clear">
                </div>
            </div>
            <div class="qzh_xxbox">
                <!------qzh_basic-------->
                <div class="qzh_basic" id="jingqujieshaoTab">
                    <h4>
                        <a href="javascript:;" name="a1">景区介绍</a></h4>
                    <%=Model.ScenicArea.Description%>
                </div>
                <div class="qzh_basic hide" id="jingqutupianTab">
                    <h4>
                        <a href="javascript:;" name="a2">景区图片</a></h4>
                    <ul class="jinqu_pic fixed">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <li class="<%# (Container.ItemIndex==((Repeater2.DataSource as IList).Count-1)?"marginR":"") %>">
                                    <img alt="" src="<%#Eval("Address")%>">
                                    <p>
                                        <%#Eval("Description")%></p>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="qzh_basic hide" id="jiaotongzhinanTab">
                    <h4>
                        <a href="javascript:;" name="a4">交通指南</a></h4>
                    <p>
                        <%=Model.ScenicArea.Traffic%>
                    </p>
                </div>
            </div>
        </div>
        <div class="jq_link margin_T10">
            <asp:Repeater ID="Repeater3" runat="server">
                <ItemTemplate>
                    <a href="javascript:;" onclick="location='/YouHuiMenPiao.aspx?CityId=<%#Eval("Id")%>'">
                        <%#Eval("Name")%></a></ItemTemplate>
            </asp:Repeater>
        </div>
        <uc1:Hotel2 runat="server" ID="Hotel2" />
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">

    <script type="text/javascript">
        var instance = {};
        instance.animate = function() {
            setInterval(function() {
                instance.animate.index++;
                if (instance.animate.index == 3) { instance.animate.index = 0; }
                $('#ifocus_btn li:eq(' + instance.animate.index + ')').click();
            }, 3500);
        };
        instance.animate.index = 0;
        instance.switchTab = function(tabId) {
            if (tabId == 'jingquditu' && !document.getElementById('ditu').src) {
                document.getElementById('ditu').src = "/YouHuiMenPiaoMap.aspx?scenicName=<%=Server.UrlEncode(Model.ScenicArea.ScenicName)%>&cityName=<%=Server.UrlEncode(Model.ScenicArea.CityName) %>&x=<%=Model.ScenicArea.X %>&y=<%=Model.ScenicArea.Y %>&contact=<%=Model.ScenicArea.Contact %>&mobile=<%=Model.ScenicArea.ContactMobile %>&address=<%=Server.UrlEncode(Model.ScenicArea.CnAddress) %>&tre=" + Math.random();
            }
            $('#' + tabId).addClass('tab_on');
            $('#' + tabId).siblings().removeClass('tab_on');
            $('#' + tabId + 'Tab').show();
            $('#' + tabId + 'Tab').siblings().hide();
            return tabId + 'Tab';
        };

        instance.switchTab2 = function(tabId, linkA) {
            linkA.className = 'cur';
            $(linkA).siblings().removeClass('cur');
            setTimeout(function() {
                var tabcardId = instance.switchTab(tabId);
                document.documentElement.scrollTop = $('#' + tabcardId).offset().top;
            }, 300);
        };

        instance.chaKanXiangQing = function(o, t) {
            var xiangqing = null;
            if (t === 1) {
                xiangqing = $(o).parents('table:first').find('tr.xq');
            }
            if (t === 2) {
                xiangqing = $(o).parents('tr:first').next();
            }

            if (o.innerHTML.indexOf('&gt;') > -1) {
                o.innerHTML = '详情<i></i>';
                xiangqing.css('display', '');
            }
            else {
                o.innerHTML = '详情&gt;&gt;';
                xiangqing.css('display', 'none');
            }
        };

        instance.selectShowImg = function(obj, img) {
            instance.animate.index = $(obj).index();
            document.getElementById('showImg').src = img.src;
            obj.className = 'current';
            $(obj).siblings().removeClass('current').addClass('normal');
        };
        instance.yuDing = function(ticketId, btn, isCurTicket) {
            if (!ticketId) { return; }
            var querydata = {
                ret: Math.random(),
                ticketsId: ticketId,
                ScenicId: '<%=Model.ScenicId%>'
            };
            if (isCurTicket && '<%=Model.IsShowShenQing %>'.toLowerCase() == 'true') {
                if (iLogin.getM().isLogin) {
                    location = '/YouHuiMenPiaoOrder.aspx?' + $.param(querydata);
                }
                else {
                    location = '/YuDing.aspx?callback=/YouHuiMenPiaoOrder.aspx?' + $.param(querydata);
                }
            }
            else {
                location = '/YouHuiMenPiaoXiangQing.aspx?isshowshenqing=true&ScenicId=<%=Model.ScenicId%>&ticketsId=' + ticketId;
            }
        };
        onload = instance.animate;
    </script>

    <script type="text/javascript">
        $(".code_small").mouseover(function() {
            $(".code_big").toggle();
        });
        $(".code_small").mouseout(function() {
            $(".code_big").toggle();
        });
    </script>

</asp:Content>
<asp:Content ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
