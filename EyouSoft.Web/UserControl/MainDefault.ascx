<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainDefault.ascx.cs"
    Inherits="EyouSoft.Web.UserControl.MainDefault" %>
<script type="text/javascript">
    function nTabs(tabObj, obj) {
        var tabList = document.getElementById(tabObj).getElementsByTagName("li");
        for (i = 0; i < tabList.length; i++) {
            if (tabList[i].id == obj.id) {
                document.getElementById(tabObj + "_Title" + i).className = "active";
                document.getElementById(tabObj + "_Content" + i).style.display = "block";
                var url = '/YouHuiMenPiao.aspx';
                if (i == '0') url = '/YouHuiMenPiao.aspx';
                if (i == '1') url = '/XianLu.aspx?type=3';
                if (i == '2') url = '/XianLu.aspx?type=1';
                if (i == '3') url = '/XianLu.aspx?type=2';
                $("#mpMore").attr("href", url);
            } else {
                document.getElementById(tabObj + "_Title" + i).className = "normal";
                document.getElementById(tabObj + "_Content" + i).style.display = "none";
            }
        }
    }
</script>

<script type="text/javascript">
    //var intDiff = parseInt(5);//倒计时总秒数量
    function timer(i, intDiff) {
        window.setInterval(function() {
            var day = 0,
        hour = 0,
        minute = 0,
        second = 0; //时间默认值  
            if (intDiff > 0) {
                day = Math.floor(intDiff / (60 * 60 * 24));
                hour = Math.floor(intDiff / (60 * 60)) - (day * 24);
                minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
                second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
            }

            if (minute <= 9) minute = '0' + minute;
            if (second <= 9) second = '0' + second;
            $('#day_show' + i).html(day);
            $('#hour_show' + i).html('<s id="h"></s>' + hour);
            $('#minute_show' + i).html('<s></s>' + minute);
            $('#second_show' + i).html('<s></s>' + second);
            intDiff--;
        }, 1000);
    }
    $(function() {
        var count = $("input[name=mstime]").length;

        for (var i = 1; i <= count; i++) {
            timer(i, parseInt($("#time" + i).val()));
        }

        $("#CuXiaoSrcoll").cxScroll({
            prevBtn: false,
            nextBtn: false,
            step: 2
        });
        $("#MiaoShaSrcoll").cxScroll({
            prevBtn: false,
            nextBtn: false,
            step: 2
        });
        $("#ShangChengSrcoll").cxScroll({
            prevBtn: false,
            nextBtn: false,
            step: 4
        });
    }); 
</script>
<!------banner-------->
<div id="newsSlider" class="banner">
    <div class="piclist">
        <ul class="slides" style="width: 4150px; left: -1660px;">
            <%= toplist%>
        </ul>
        <div class="validate_Slider">
        </div>
        <ul class="pagination">
            <%= dianlist%>
        </ul>
    </div>
</div>
<!------R_side01-------->
<div class="R_side01 fixed margin_T10">
    <!------促销-------->
    <div id="CuXiaoSrcoll" class="R_side01L">
        <h3>
            <img src="images/cuxiao.png"><a class="more" href="/TuanGou.aspx?type=3">更多&gt;&gt;</a></h3>
        <div class="box">
            <ul>
                <asp:Repeater ID="CuXiao" runat="server">
                    <ItemTemplate>
                        <li><div class="list"><a class="cx_img" href="/TuanGouXX.aspx?id=<%# Eval("ID")%>">
                            <img src="<%# Eval("ProductImg")%>" /><div class="tuijian">
                            </div>
                        </a>
                            <p class="cx_title">
                                <a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>">
                                    <%# Eval("ProductName")%></a></p>
                            <p>
                                <span class="sales"><em>¥<%# Convert.ToInt32(Eval("GroupPrice"))%></em>起</span><span
                                    class="rate-info">原价：<s>¥<%# Convert.ToInt32(Eval("MarketPrice"))%></s></span></p>
                        </div></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="clear">
        </div>
    </div>
    <!------秒杀-------->
    <div id="MiaoShaSrcoll" class="R_side01L R_side01R" style="margin:0; float:right;">
        <h3>
            <img src="/images/miaosha.png"><a class="more" href="/TuanGou.aspx?type=1">更多&gt;&gt;</a></h3>
        <div class="box">
            <ul>
                <asp:Repeater ID="MiaoSha" runat="server">
                    <ItemTemplate>
                        <li><div class="list"><a class="cx_img" href="/TuanGouXX.aspx?id=<%# Eval("ID")%>">
                            <img src="<%# Eval("ProductImg")%>" /><p class="cx_title">
                                <%# Eval("ProductName")%></p>
                        </a>
                            <p class="borderB">
                                <span class="sales"><em>¥<%# Convert.ToInt32(Eval("GroupPrice"))%></em><span class="zhe"><%# GetZheKou(Eval("GroupPrice"),Eval("MarketPrice"))%>折</span></span><span
                                    class="rate-info">原价：<s>¥<%# Convert.ToInt32(Eval("MarketPrice"))%></s></span></p>
                            <p>
                                <input id="time<%# Container.ItemIndex+1 %>" name="mstime" type="hidden" value="<%# GetMiaoshu(Eval("ValiDate"))%>" />
                                剩余时间：<font class="fontblue font14" id="day_show<%# Container.ItemIndex+1 %>">0</font>
                                天 <font class="fontblue font14" id="hour_show<%# Container.ItemIndex+1 %>">0</font>
                                时 <font class="fontblue font14" id="minute_show<%# Container.ItemIndex+1 %>">0</font>
                                分 <font class="fontblue font14" id="second_show<%# Container.ItemIndex+1 %>">0</font>
                                秒</p>
                        </div></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="clear">
        </div>
    </div>
</div>
<!------R_side02-------->
<div id="n4Tab2" class="R-side02 margin_T10">
    <div class="R_side02_T">
        <ul class="imgList-TabTitle">
            <li class="active" onclick="nTabs('n4Tab2',this);curtab='menpiao';" id="n4Tab2_Title0">
                <a href="javascript:void(2);">特惠门票</a></li>
            <li onclick="nTabs('n4Tab2',this);curtab='zhoubianxianlu';" id="n4Tab2_Title1"><a
                href="javascript:void(2);">周边线路</a></li>
            <li onclick="nTabs('n4Tab2',this);curtab='guoneixianlu';" id="n4Tab2_Title2"><a href="javascript:void(2);">
                国内长线</a></li>
            <li onclick="nTabs('n4Tab2',this);curtab='chujingxianlu';" id="n4Tab2_Title3"><a
                href="javascript:void(2);">出境线路</a></li>
        </ul>
        <a id="mpMore" class="more" href="javascript:;" onclick="if(typeof curtab=='undefined'||curtab=='menpiao'){location='/youhuimenpiao.aspx';}else if(curtab=='zhoubianxianlu'){location='/xianlu.aspx?type=3';}else if(curtab=='guoneixianlu'){location='/xianlu.aspx?type=1';}else if(curtab=='chujingxianlu'){location='/xianlu.aspx?type=2';}">
            更多&gt;&gt;</a>
    </div>
    <div class="imgList-TabContent">
        <div id="n4Tab2_Content0">
            <div class="line-box fixed">
                <div class="leftBpic">
                    <%=MenPiaoShow%>
                </div>
                <ul>
                    <asp:Repeater runat="server" ID="rpt_MenPiao">
                        <ItemTemplate>
                            <li><a href="/YouHuiMenPiaoXiangQing.aspx?ScenicId=<%#Eval("ScenicId")%>">
                                <%#GetScenicImg(Eval("ImgList"))%></a>
                                <p style="text-align: center;">
                                    <a href="/YouHuiMenPiaoXiangQing.aspx?ScenicId=<%#Eval("ScenicId")%>" style="font-weight: bold;
                                        font-size: 14px;">
                                        <%# EyouSoft.Common.Utils.GetText2(Eval("ScenicName").ToString(), 12, true)%></a><br />
                                </p>
                                <p class="price" style="text-align: center; font-size: 14px;">
                                    ¥<%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("SettlementPrice"), (decimal)Eval("WebPrice"),CurrentUser.UserType,(EyouSoft.Model.SystemStructure.MFeeSettings)Eval("FeeSetting"), FeeTypes.门票).ToString("0")%>起/人
                                </p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="none" id="n4Tab2_Content1">
            <div class="line-box fixed">
                <div class="leftBpic">
                    <%=ZhouBianShow%>
                </div>
                <ul>
                    <asp:Repeater runat="server" ID="rpt_ZhouBian">
                        <ItemTemplate>
                            <li><a href="XianLuYuDing.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.周边短线 %>">
                                <%#GetRouteImgPath(Eval("TeSeFilePath"), Eval("RouteName"))%>
                                <p>
                                    <a href="XianLuYuDing.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.周边短线 %>">
                                        <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString()), 12, true)%></a></p>
                                <p class="price">
                                    <em>
                                        <%# getHYJ(EyouSoft.Model.Enum.FeeTypes.周边线路, Eval("Tours"))%>
                                    </em>起
                                </p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="none" id="n4Tab2_Content2">
            <div class="line-box fixed">
                <div class="leftBpic">
                    <%=GuoNeiShow%>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_GuoNeiRoute" runat="server">
                        <ItemTemplate>
                            <li><a href="XianLuYuDing.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.国内长线 %>">
                                <%#GetRouteImgPath(Eval("TeSeFilePath"), Eval("RouteName"))%></a>
                                <p>
                                    <a href="XianLuYuDing.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.国内长线 %>">
                                        <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString()), 12, true)%></a></p>
                                <p class="price">
                                    <em>
                                        <%# getHYJ(EyouSoft.Model.Enum.FeeTypes.国内线路, Eval("Tours"))%></em>起</p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="none" id="n4Tab2_Content3">
            <div class="line-box fixed">
                <div class="leftBpic">
                    <%=ChuJingShow%>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_ChuJingRoute" runat="server">
                        <ItemTemplate>
                            <li><a href="XianLuYuDing.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.出境线路 %>">
                                <%#GetRouteImgPath(Eval("TeSeFilePath"), Eval("RouteName"))%></a>
                                <p>
                                    <a href="XianLuYuDing.aspx?id=<%#Eval("XianLuId")%>&type=<%= (int)EyouSoft.Model.Enum.AreaType.出境线路 %>">
                                        <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString()), 12, true)%></a></p>
                                <p class="price">
                                    <em>
                                        <%# getHYJ(EyouSoft.Model.Enum.FeeTypes.国际线路, Eval("Tours"))%></em>起</p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</div>
<!------酒店-------->
<div class="R-side02 margin_T10">
    <div class="R_side02_T">
        <ul class="imgList-TabTitle">
            <li class="active"><a href="javascript:void(0);">精选酒店</a></li>
        </ul>
        <a class="more" href="/Hotel.aspx">更多&gt;&gt;</a>
    </div>
    <div class="imgList-TabContent">
        <div class="hotelbox">
            <ul>
                <asp:Repeater ID="rpt_Hotel" runat="server">
                    <ItemTemplate>
                        <li><a title="<%# ((HotelStar?)Eval("Star")).HasValue? ((int)((HotelStar?)Eval("Star")).Value>5?((HotelStar?)Eval("Star")).Value.ToString().Replace("准","参考"): ((HotelStar?)Eval("Star")).Value.ToString()):"" %>"
                            href="/HotelXiangQing.aspx?HotelId=<%# Eval("HotelId")%>&RuZhuRiQi=<%= DateTime.Now.AddDays(7).ToString("yyyy-MM-dd")%>&lidianriqi=<%=DateTime.Now.AddDays(8).ToString("yyyy-MM-dd") %>">
                            <img alt="<%#Eval("HotelName") %>" src="<%# Eval("FirstImageAddress") %>" /></a><p
                                class="name">
                                <span class="H_title"><a title="<%# ((HotelStar?)Eval("Star")).HasValue? ((int)((HotelStar?)Eval("Star")).Value>5?((HotelStar?)Eval("Star")).Value.ToString().Replace("准","参考"): ((HotelStar?)Eval("Star")).Value.ToString()):"" %>"
                                    href="/HotelXiangQing.aspx?HotelId=<%# Eval("HotelId")%>&RuZhuRiQi=<%= DateTime.Now.AddDays(7).ToString("yyyy-MM-dd")%>&lidianriqi=<%=DateTime.Now.AddDays(8).ToString("yyyy-MM-dd") %>">
                                    <%# EyouSoft.Common.Utils.GetText2(Eval("HotelName").ToString(), 29, true)%></a></span><span
                                        class="satr"><%# EyouSoft.Web.Hotel.GetHotelStarString(Eval("Star"))%></span></p>
                            <p class="name">
                                <span class="font_yellow"><i>¥
                                    <%#EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("RoomRateInfo[0].SettlementPrice"), (decimal)Eval("RoomRateInfo[0].SettlementPrice"), CurrentUser.UserType, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("RoomRateInfo[0].FeeSetting"), FeeTypes.酒店)%></i>起/人</span></p>
                            <p class="cont">
                                <%# Eval("Address") %></p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
    </div>
</div>
<!------汽车包租-------->
<div class="R-side02 margin_T10">
    <div class="R_side02_T">
        <ul class="imgList-TabTitle">
            <li class="active"><a href="javascript:void(0);">汽车包租</a></li>
        </ul>
        <a class="more" href="/ZuChe.aspx">更多&gt;&gt;</a>
    </div>
    <div class="imgList-TabContent">
        <div class="hotelbox">
            <ul>
                <asp:Repeater ID="rpt_ZuChe" runat="server">
                    <ItemTemplate>
                        <li><a href="/ZuCheXX.aspx?id=<%# Eval("ZuCheID") %>">
                            <img src='<%# Eval("FilePath") %>' alt='<%# Eval("CarName") %>'></a>
                            <p class="name">
                                <font class="font12">车辆名称</font> <a class="fontblue" href="/ZuCheXX.aspx?id=<%# Eval("ZuCheID") %>">
                                    <%#EyouSoft.Common.Utils.GetText2(Eval("CarName").ToString(),20,true)%></a></p>
                            <p class="font_yellow">
                                限坐人数：<%#Eval("XianZuoRenShu")%>人</p>
                            <p class="cont">
                                车辆介绍&mdash;&mdash;<%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("Remark").ToString()), 20, true) %></p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
    </div>
</div>
<!------出国签证-------->
<div id="Visa" runat="server" class="R-side02 margin_T10">
    <div class="R_side02_T">
        <ul class="imgList-TabTitle">
            <li class="active"><a href="javascript:void(0);">出国签证</a></li>
        </ul>
        <a class="more" href="/Visa.aspx">更多&gt;&gt;</a>
    </div>
    <div class="imgList-TabContent">
        <div class="hotelbox qianzh_box">
            <ul>
                <asp:Repeater ID="rpt_QianZheng" runat="server">
                    <ItemTemplate>
                        <li><a href="/VisaXX.aspx?visaid=<%# Eval("QianZhengId")%>">
                            <img src="<%# GetVisaImg(Eval("GuoJiaId"))%>" /></a>
                            <p class="name">
                                <a href="/VisaXX.aspx?visaid=<%# Eval("QianZhengId")%>">
                                    <%# Eval("Name")%></a></p>
                            <p class="score">
                                <span class="rate-price"><i>¥
                                    <%# Convert.ToInt32(Eval("JiaGeMenShi"))%></i></span></p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
    </div>
</div>
<!------会员商城-------->
<div class="R-side02 margin_T10">
    <div class="R_side02_T">
        <ul class="imgList-TabTitle">
            <li class="active"><a href="javascript:void(0);">会员商城</a></li>
        </ul>
        <a class="more" href="/ShangCheng.aspx">更多&gt;&gt;</a>
    </div>
        <div id="ShangChengSrcoll" class="shangch_list">
                <div class="box">
                    <ul>
                        <asp:Repeater ID="rpt_HuiYuanShopping" runat="server">
                            <ItemTemplate>
                                <li><div class="list"><a href="/ShangChengXiangQing.aspx?ID=<%#  Eval("ProductID") %>" class="cx_img">
                                    <img src="<%# getImgs(Eval("ProductImgs")) %>" />
                                    <div class="tuijian">
                                        优惠价</div>
                                </a>
                                    <p class="cx_title">
                                        <a href="/ShangChengXiangQing.aspx?ID=<%#  Eval("ProductID") %>">
                                            <%# Eval("ProductName")%></a></p>
                                    <p>
                                        <span class="sales"><em>¥
                                            <%# EyouSoft.Common.UtilsCommons.GetGYStijia(FeeTypes.商城,  (decimal)Eval("SalePrice"),(decimal)Eval("MarketPrice"), MemberTypes.普通会员).ToString("F0")%></em></span><span
                                                class="rate-info">门市价：<s><%#  Eval("MarketPrice", "{0:C0}")%></s></span></p>
                                </div></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            <div class="clear">
            </div>
        </div>
</div>

<script src="/JS/jquery.cxscroll.min.js" type="text/javascript"></script>

