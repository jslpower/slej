<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ZiXunXX.aspx.cs" Inherits="EyouSoft.Web.ZiXunXX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <div class="leftbox">
        <!------L_side01-------->
        <div class="L_side01">
            <!------促销-------->
            <div class="left_focus borderB">
                <h3>
                    <img src="images/cuxiao.png"></h3>
                <ul class="left_focuslist b_imglist" style="position: relative; width: 232px; height: 259px;">
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/cx001.gif"><div class="tuijian">
                        </div>
                    </a>
                        <p class="cx_title">
                            <a href="#">广州－曼谷5天4晚自由行</a></p>
                        <p>
                            <span class="sales"><em>¥1999</em>起</span><span class="rate-info">原价：<s>¥2999</s></span></p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/cx001.gif"><div class="tuijian">
                        </div>
                    </a>
                        <p class="cx_title">
                            <a href="#">广州－曼谷5天4晚自由行</a></p>
                        <p>
                            <span class="sales"><em>¥1999</em>起</span><span class="rate-info">原价：<s>¥2999</s></span></p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: block;
                        opacity: 0.400508;"><a class="cx_img" href="#">
                            <img src="images/line-001.jpg">
                            <div class="tuijian">
                            </div>
                        </a>
                        <p class="cx_title">
                            <a href="#">广州－曼谷5天4晚自由行</a></p>
                        <p>
                            <span class="sales"><em>¥1999</em>起</span><span class="rate-info">原价：<s>¥2999</s></span></p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: block;
                        opacity: 0.601298;"><a class="cx_img" href="#">
                            <img src="images/xingchen01.jpg">
                            <div class="tuijian">
                            </div>
                        </a>
                        <p class="cx_title">
                            <a href="#">广州－曼谷5天4晚自由行</a></p>
                        <p>
                            <span class="sales"><em>¥1999</em>起</span><span class="rate-info">原价：<s>¥2999</s></span></p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/cx001.gif"><div class="tuijian">
                        </div>
                    </a>
                        <p class="cx_title">
                            <a href="#">广州－曼谷5天4晚自由行</a></p>
                        <p>
                            <span class="sales"><em>¥1999</em>起</span><span class="rate-info">原价：<s>¥2999</s></span></p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/tj001.jpg">
                        <div class="tuijian">
                        </div>
                    </a>
                        <p class="cx_title">
                            <a href="#">广州－曼谷5天4晚自由行</a></p>
                        <p>
                            <span class="sales"><em>¥1999</em>起</span><span class="rate-info">原价：<s>¥2999</s></span></p>
                    </li>
                </ul>
                <a href="javascript:void(0)" class="prev"></a><a href="javascript:void(0)" class="next">
                </a>
                <div class="num">
                    <ul>
                        <li class="">1</li><li class="">2</li><li class="">3</li><li class="on">4</li><li
                            class="">5</li><li class="">6</li></ul>
                </div>
            </div>
            <div class="left_focus R_side01R">
                <!------秒杀-------->
                <h3>
                    <img src="images/miaosha.png"></h3>
                <ul class="left_focuslist b_imglist" style="position: relative; width: 232px; height: 259px;">
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/msh001.jpg"><p class="cx_title">
                            香港-曼谷4天3晚自由行</p>
                    </a>
                        <p class="borderB">
                            <span class="sales"><em>¥1699</em><span class="zhe">7.3折</span></span><span class="rate-info">原价：<s>¥3658</s></span></p>
                        <p>
                            剩余时间：<font class="fontblue font14">26</font> 天 <font class="fontblue font14">8</font>
                            时 <font class="fontblue font14">20</font> 分 <font class="fontblue font14">1</font>
                            秒</p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/msh001.jpg"><p class="cx_title">
                            香港-曼谷4天3晚自由行</p>
                    </a>
                        <p class="borderB">
                            <span class="sales"><em>¥1699</em><span class="zhe">7.3折</span></span><span class="rate-info">原价：<s>¥3658</s></span></p>
                        <p>
                            剩余时间：<font class="fontblue font14">26</font> 天 <font class="fontblue font14">8</font>
                            时 <font class="fontblue font14">20</font> 分 <font class="fontblue font14">1</font>
                            秒</p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/msh001.jpg"><p class="cx_title">
                            香港-曼谷4天3晚自由行</p>
                    </a>
                        <p class="borderB">
                            <span class="sales"><em>¥1699</em><span class="zhe">7.3折</span></span><span class="rate-info">原价：<s>¥3658</s></span></p>
                        <p>
                            剩余时间：<font class="fontblue font14">26</font> 天 <font class="fontblue font14">8</font>
                            时 <font class="fontblue font14">20</font> 分 <font class="fontblue font14">1</font>
                            秒</p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: block;"><a
                        class="cx_img" href="#">
                        <img src="images/msh001.jpg"><p class="cx_title">
                            香港-曼谷4天3晚自由行</p>
                    </a>
                        <p class="borderB">
                            <span class="sales"><em>¥1699</em><span class="zhe">7.3折</span></span><span class="rate-info">原价：<s>¥3658</s></span></p>
                        <p>
                            剩余时间：<font class="fontblue font14">26</font> 天 <font class="fontblue font14">8</font>
                            时 <font class="fontblue font14">20</font> 分 <font class="fontblue font14">1</font>
                            秒</p>
                    </li>
                    <li style="position: absolute; width: 232px; left: 0px; top: 0px; display: none;"><a
                        class="cx_img" href="#">
                        <img src="images/msh001.jpg"><p class="cx_title">
                            香港-曼谷4天3晚自由行</p>
                    </a>
                        <p class="borderB">
                            <span class="sales"><em>¥1699</em><span class="zhe">7.3折</span></span><span class="rate-info">原价：<s>¥3658</s></span></p>
                        <p>
                            剩余时间：<font class="fontblue font14">26</font> 天 <font class="fontblue font14">8</font>
                            时 <font class="fontblue font14">20</font> 分 <font class="fontblue font14">1</font>
                            秒</p>
                    </li>
                </ul>
                <a href="javascript:void(0)" class="prev" style="opacity: 0.1; display: none;"></a>
                <a href="javascript:void(0)" class="next" style="opacity: 0.1; display: none;"></a>
                <div class="num">
                    <ul>
                        <li class="">1</li><li class="">2</li><li class="">3</li><li class="on">4</li><li
                            class="">5</li></ul>
                </div>
            </div>
        </div>
        <!------searchbox-------->
        <div id="n4Tab" class="searchbox margin_T10">
            <div class="TabTitle">
                <ul>
                    <li class="active" onclick="nTabs('n4Tab',this);" id="n4Tab_Title0"><a href="javascript:void(0);">
                        <s class="hotel"></s><span>酒店</span></a></li>
                    <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title1"><a href="javascript:void(0);"><s
                        class="jipiao"></s><span>机票</span></a></li>
                    <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title2"><a href="javascript:void(0);"><s
                        class="menpiao"></s><span>门票</span></a></li>
                    <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title3"><a href="javascript:void(0);"><s
                        class="zuche"></s><span>租车</span></a></li>
                    <li style="border-right: 0;" onclick="nTabs('n4Tab',this);" id="n4Tab_Title4"><a
                        href="javascript:void(0);"><s class="qianzhen"></s><span>签证</span></a></li>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="TabContent">
                <div id="n4Tab_Content0">
                    <div id="n4Tab1" class="S_line_n4Tab">
                        <div class="S-line-TabTitle">
                            <ul>
                                <li class="active" onclick="nTabs('n4Tab1',this);" id="n4Tab1_Title0"><a href="javascript:void(1);">
                                    国内酒店</a></li>
                                <li onclick="nTabs('n4Tab1',this);" id="n4Tab1_Title1"><a href="javascript:void(1);">
                                    海外酒店</a></li>
                            </ul>
                        </div>
                        <div class="S-line-TabContent">
                            <div id="n4Tab1_Content0">
                                <div class="userbox">
                                    <ul>
                                        <li><span class="user-txt">目的地：</span><input type="text" value="城市/地区" class="inputbk formsize140"></li>
                                        <li><span class="user-txt">入住日期：</span><span class="date_style formsize140"><input
                                            type="text">
                                            <a href="#">
                                                <img src="images/rili.gif"></a></span></li>
                                        <li><span class="user-txt">退房日期：</span><span class="date_style formsize140"><input
                                            type="text">
                                            <a href="#">
                                                <img src="images/rili.gif"></a></span></li>
                                        <li><span class="user-txt">关键词：</span><input type="text" value="关键词" class="inputbk formsize140"></li>
                                        <li class="padd">
                                            <input type="button" class="s-btn" value="搜索&gt;&gt;"></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="none" id="n4Tab1_Content1">
                                海外酒店
                            </div>
                        </div>
                    </div>
                </div>
                <div class="none" id="n4Tab_Content1">
                    机票</div>
                <div class="none" id="n4Tab_Content2">
                    门票</div>
                <div class="none" id="n4Tab_Content3">
                    租车</div>
                <div class="none" id="n4Tab_Content4">
                    签证</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="rightbox">
        <div class="n_title">
            &gt; 旅游资讯</div>
        <div class="companyin">
            <h3>
                三亚游艇游趋平民化：玩半天每人费用不过千元</h3>
            <h5>
                发布时间：2014-06-09</h5>
            <p>
                时间：节假日第一天0：00开始，节假日最后一天24：00结束
                <br>
                条件：七座以下(含七座)载客车辆</p>
            <p>
                范围：经依法批准设置的收费公路(含收费桥梁和隧道)</p>
            <p>
                8月2日，在合宁高速金寨路收费站，车辆交费后通行。 新华社发</p>
            <p>
                时报8月2日讯 (记者林江丽)备受关注的收费公路重大节假日免费的消息终于尘埃落定。 2日，中国政府网发布《国务院关于批转交通运输部等部门重大节假日免收小型客车通行费实施方案的通知》，春节、清明节、劳动节、国庆节四个重大节假日里，七座以下(含七座)载客车辆将可以在收费公路上免费通行了。</p>
            <p>
                四大节日小型客车免费</p>
            <p>
                根据《国务院关于批转交通运输部等部门重大节假日免收小型客车通行费实施方案的通知》，国务院已同意交通运输部、发展改革委、财政部、监察部、国务院纠风办制定的《重大节假日免收小型客车通行费实施方案》，要求认真贯彻执行。</p>
            <p>
                按照实施方案要求，免费通行的时间范围为春节、清明节、劳动节、国庆节四个国家法定节假日，以及当年国务院办公厅文件确定的上述法定节假日连休日。</p>
            <p>
                免费时段从节假日第一天00∶00开始，节假日最后一天24∶00结束(普通公路以车辆通过收费站收费车道的时间为准，高速公路以车辆驶离出口收费车道的时间为准)。</p>
            <p>
                免费通行的车辆范围为行驶收费公路的七座以下(含七座)载客车辆，包括允许在普通收费公路行驶的摩托车。</p>
            <p>
                免费通行的收费公路范围为符合《中华人民共和国公路法》和《收费公路管理条例》规定，经依法批准设置的收费公路(含收费桥梁和隧道)。</p>
            <p>
                各地机场高速公路是否实行免费通行，由各省(区、市)人民政府决定。<br>
            </p>
        </div>
    </div>
</asp:Content>
