<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiZuTuan.aspx.cs" Inherits="EyouSoft.WAP.ZiZuTuan" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<%@ Register Src="/userControl/ZuTuanHead.ascx" TagName="ZuTuanHead" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>组团报价</title>
    <link href="/css/zt.css" rel="stylesheet" type="text/css" />

    <script src="/js/slogin.js" type="text/javascript"></script>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <em id="zhuyemian">
        <uc1:WapHeader runat="server" ID="WapHeader1" />
        <div class="warp">
            <div class="zt_item">
                <ul>
                    <li><span class="left_name">组团说明：</span></li>
                </ul>
            </div>
            <div class="zt_txt" style="background: #fff;">
                <div class="paddL paddR font13">
                    客户单独组团，独立享受旅游相关服务，不必跟不相关的人拼在一起，避免尴尬,尊享自在！以下单独组团报价是在不减少行程内容的情况下，根据成团人数和客户需求，在拼团价格基础上进行合理调整之后的总价格。</div>
            </div>
            <div class="zt_item">
                <ul>
                    <li><span class="left_name">线路名称：</span><a href="javascript:window.history.go(-1);"><asp:Label
                        ID="lblXLMC" runat="server" Text=""></asp:Label></a></li>
                    <li><span class="left_name">出发城市：</span><asp:Label ID="cfd" runat="server" Text=""></asp:Label></li>
                </ul>
            </div>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
                <div class="zt_item zt_riqi mt10">
                    <ul>
                        <li class="R_jiantou" data-class="HangBan"><span class="left_name">航班/舱位</span><asp:Literal
                            ID="HangBanXinXI" runat="server"></asp:Literal><asp:HiddenField ID="HangBanId" runat="server" />
                        </li>
                    </ul>
                </div>
            </asp:PlaceHolder>
            <div class="zt_item zt_riqi">
                <ul>
                    <li class="R_jiantou" data-class="YouWan"><span class="left_name">游玩日期</span><asp:Literal
                        ID="YouWanXinXi" runat="server"></asp:Literal><asp:HiddenField ID="YouWanId" runat="server" />
                    </li>
                </ul>
            </div>
            <div class="zt_item">
                <ul>
                    <li><span class="left_name">成团人数：</span>成人 <span class="number"><i data-class="js_min"
                        class="num-minus"></i>
                        <input id="RenShu" name="RenShu" readonly="readonly" type="text" value="2"><i data-class="js_max"
                            class="num-add"></i></span> </li>
                    <li class="paddT">儿童 <span class="number"><i data-class="etjs_min" class="num-minus">
                    </i>
                        <input id="ETRenShu" name="ETRenShu" readonly="readonly" type="text" value="0"><i
                            data-class="etjs_max" class="num-add"></i></span></li>
                    <li class="font12 font_gray paddT">注：(儿童为2-12周岁) 旅游天数
                        <asp:Literal ID="lvYouTianShu" runat="server"></asp:Literal>
                        天</li>
                    <input id="BiaoZhunNum" runat="server" type="hidden" />
                    <input id="LYTianShu" runat="server" type="hidden" />
                </ul>
            </div>
            <div class="zt_y_item">
                <a href="javascript:void(0);" data-money="zong" data-div="CarMoneyDiv" class="a_fxk_on">
                </a><span class="R_jiantou" data-class="CarMoneyDiv"><em class="font_yellow">增加人均车费</em>
                    <em class="font_gray">人均汽车费共增加 ：<em id="CarMoneyXS">0</em> 元</em></span>
            </div>
            <div class="zt_txt">
                <div class="paddL paddR font13">
                    注：本线路拼团价是按最少<asp:Literal ID="ZuiDiRenShu" runat="server"></asp:Literal>人标准核计的费用，单独组团若不足<asp:Literal
                        ID="ZuiDiRenShu1" runat="server"></asp:Literal>人，请补足目的地人均车费差价。包括汽车乘用、司机食宿、燃油损耗和路桥停车费等。安排的汽车保证每人一正座。</div>
            </div>
            <div class="zt_y_item">
                <a href="javascript:void(0);" data-money="zong" data-div="CanMoneyDiv" data-class="fxk_ok"
                    class="a_fxk"></a><span class="R_jiantou" data-class="CanMoneyDiv"><em class="font_yellow">
                        需要增加餐标</em> <em class="font_gray">人均餐标费共增加 ：<em id="CanMoneyXS">0</em> 元</em></span>
            </div>
            <div class="zt_txt">
                <div class="paddL paddR font13">
                    注：增加用餐标准是指菜品结构搭配与菜量的合理优化，如有需要，可提供菜单。</div>
            </div>
            <div class="zt_y_item">
                <a href="javascript:void(0);" data-money="zong" data-div="BaoXianDiv" data-class="fxk_ok"
                    class="a_fxk"></a><span class="R_jiantou" data-class="BaoXianDiv"><em class="font_yellow">
                        需要增加保险</em> <em class="font_gray">人均保险费共增加：<em id="BaoXianXS">0</em> 元</em></span>
            </div>
            <div class="zt_txt">
                <div class="paddL paddR font13">
                    注：建议购买以下意外保险，安心出游！</div>
            </div>
            <div class="zt_y_item">
                <a href="javascript:void(0);" data-money="zong" data-div="DaoYouDiv" class="a_fxk_on">
                </a><span class="R_jiantou" data-class="DaoYouDiv"><em class="font_yellow">需要增加导游</em>
                    <em class="font_gray">增加：<em id="DaoYouXS">0</em> 元</em></span>
            </div>
            <div class="zt_txt">
                <div class="paddL paddR font13">
                    本线路拼团价是按最少<asp:Literal ID="ZuiDiNum" runat="server"></asp:Literal>人标准核计的费用，单独组团若不足<asp:Literal
                        ID="ZuiDiRS" runat="server"></asp:Literal>人，请补足目的地导游费用差价,
                    <%if (routeType == 2)
                      { %>
                    包括导游大交通、导游工资、导游津贴、食宿费等。保证每车一名目的地导游和一名全陪导游。
                    <%}
                      else
                      { %>
                    每车保证一名目的地导游。全陪导游可自愿选择，导游服务费包括大交通、导游工资、导游津贴、食宿费等。
                    <%} %></div>
            </div>
            <div class="zt_y_item">
                <a href="javascript:void(0);" data-money="zong" data-div="ZuCheDiv" data-class="fxk_ok"
                    class="a_fxk"></a><span class="R_jiantou" data-class="ZuCheDiv"><em class="font_yellow">
                        需要安排接送</em> <em class="font_gray">人均接送费共增加：<em id="JieSongXS">0</em> 元</em></span>
            </div>
            <div class="zt_txt">
                <div class="paddL paddR font13">
                    需统一安排汽车接送机场、火车站等，请选择并填写接机送站名称。</div>
            </div>
            <div class="zt_y_item">
                <span class="font_yellow">单独成团累计增加： <em id="ZongMoney">0</em> 元<input id="ZongMoneyCB"
                    name="ZongMoneyCB" type="hidden" value="0" /><input type="hidden" name="ZongMoney" /></span>
            </div>
            <div class="mt10 padd10" style="background: #fff;">
                <!--成人门市价-->
                <input type="hidden" readonly="readonly" id="ChengRenMS" name="ChengRenMS" runat="server" />
                <!--儿童门市价-->
                <input type="hidden" readonly="readonly" id="ErTongMS" name="ErTongMS" runat="server" />
                <!--当前会员成人价-->
                <input type="hidden" readonly="readonly" id="UChengRenJia" name="UChengRenJia" />
                <!--当前会员儿童价-->
                <input type="hidden" readonly="readonly" id="UErTongJia" name="UErTongJia" />
                <!--成人结算价-->
                <input type="hidden" readonly="readonly" id="ChengRenJieSuan" name="ChengRenJieSuan"
                    runat="server" />
                <!--儿童结算价-->
                <input type="hidden" readonly="readonly" id="ErTongJieSuan" name="ErTongJieSuan"
                    runat="server" />
                <input type="hidden" readonly="readonly" id="XLXianLuId" name="XLXianLuId" runat="server" />
                <input type="hidden" readonly="readonly" id="XLTourId" name="XLTourId" runat="server" />
                <input type="hidden" readonly="readonly" id="BaoXianFS" name="BaoXianFS" />
                <div class="gray_lineB paddB">
                    综合, 按照<span class="font_yellow"><em id="RenShuNum"></em></span> 人单独成团，<asp:Literal
                        ID="XianLuYear" runat="server"></asp:Literal><input type="hidden" readonly="readonly"
                            id="XianLuChuYear" name="XianLuChuYear" runat="server" />年<asp:Literal ID="XianLuMonth"
                                runat="server"></asp:Literal><input type="hidden" readonly="readonly" id="XianLuChuMonth"
                                    name="XianLuChuMonth" runat="server" />月<asp:Literal ID="XianLuDay" runat="server"></asp:Literal><input
                                        type="hidden" readonly="readonly" id="XianLuChuDay" name="XianLuChuDay" runat="server" />日出发的
                    <span class="font_yellow">
                        <asp:Literal ID="XianLuName" runat="server"></asp:Literal><input type="hidden" readonly="readonly"
                            id="XianLuTitle" name="XianLuTitle" runat="server" /></span> 线路的价格为：</div>
                <asp:Literal ID="JiaGeDengJiList" runat="server"></asp:Literal>
            </div>
            <%if (isShow)
              { %>
            <div class="youhui_box" style="padding-bottom: 0;">
                <em id="carpricelist"></em>
                <%--<div class="youhui_L">
                    优惠</div>
                <ul>
                    <li><a href="javascript:;" class="yudin_btn">申请</a><span class="font_yellow">会员价：</span>成人2690元/人
                        x 1人+ 儿童1840元/人 x 0人 = <span class="font_yellow">2690</span>元</li>
                    <li><a href="javascript:;" class="yudin_btn">申请</a><span class="font_yellow">贵宾价：</span>成人2570元/人
                        x 1人+ 儿童1800元/人 x 0人 = <span class="font_yellow">2570</span>元</li>
                    <li><a href="javascript:;" class="yudin_btn">申请</a><span class="font_yellow">代理价：</span>成人2450元/人
                        x 1人+ 儿童1760元/人 x 0人 = <span class="font_yellow">2450</span>元</li>
                </ul>--%>
            </div>
            <%} %>
            <%if (!isLogin)
              { %>
            <div class="padd cent" data-class="Tologin">
                <input id="BtnLogin" type="button" class="y_btn gray_btn" value="非会员直接预订"></div>
            <%} else{ %>
            <div class="cent" style="padding: 0 20px 20px 20px;" data-class="ToTiJiao">
                <a href="javascript:void(0);" id="link01" class="y_btn">核对后直接预定</a></div>
                <%} %>
        </div>
    </em>
    <!---游玩日期--->
    <div id="YouWan" class="user-mask zt-mask" style="display: none;">
        <div class="h-mask-cnt">
            <div class="day_xuanze">
                <div class="close_icon" data-class="YouWan">
                </div>
                <div class="day_T">
                    日期选择</div>
                <ul>
                    <asp:Literal ID="ltrFaBanOptions" runat="server"><li class="on">暂无发班信息</li></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <!---航班选择--->
    <div id="HangBan" class="user-mask zt-mask" style="display: none;">
        <div class="h-mask-cnt">
            <div class="day_xuanze">
                <div class="close_icon" data-class="HangBan">
                </div>
                <div class="day_T">
                    航班选择</div>
                <ul>
                    <asp:Literal ID="litHangBan" runat="server"><li class="on">暂无航班信息</li></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <em id="CarMoneyDiv" style="display: none;">
        <uc1:ZuTuanHead runat="server" ID="ZuTuanHead1" HeadText="增加车费" HeadNum="1" />
        <div class="warp">
            <div class="zt_item mt10">
                <ul>
                    <li><span class="left_name">请选择：</span></li>
                </ul>
            </div>
            <div class="zt_qiche">
                <ul>
                    <li><a href="javascript:void(0);" class="on" data-value="0">非自由行线路（默认选择）</a></li>
                    <li><a href="javascript:void(0);" data-value="1">纯自由行线路</a></li>
                    <input id="CarFei" name="CarFei" type="hidden" runat="server" />
                    <input id="CarFeiCB" name="CarFeiCB" type="hidden" runat="server" />
                    <input id="CarMoneyCB" name="CarMoneyCB" data-cb="MoneyCB" type="hidden" runat="server"
                        value="0" />
                    <input name="CarMoney" type="hidden" />
                    <li class="font16">人均汽车费共增加 ： <span class="font_yellow" id="CarMoney" data-id="Money">
                        0</span> 元/人</li>
                </ul>
            </div>
            <div class="padd cent">
                <a href="javascript:void(0);" data-class="guanbi" data-name="CarMoneyDiv" class="y_btn">
                    确定</a></div>
        </div>
    </em><em id="CanMoneyDiv" style="display: none;">
        <uc1:ZuTuanHead runat="server" ID="ZuTuanHead2" HeadText="增加餐标" HeadNum="2" />
        <div class="warp">
            <div class="zt_item mt10">
                <ul>
                    <li><span class="left_name">请选择：</span></li>
                </ul>
            </div>
            <div class="zt_can">
                <ul>
                    <li><span class="left_name">增加早餐餐标：</span> <span class="can_price">
                        <%=ZaoCanList%>
                        <input id="ZaoCanMoney" name="ZaoCanMoney" type="hidden" />
                        <input id="ZaoCanCBMoney" name="ZaoCanCBMoney" type="hidden" />
                    </span></li>
                    <li><span class="left_name">增加餐数：</span> <span class="number"><i data-class="jmin"
                        class="num-minus"></i>
                        <input id="ZaoCanNum" name="ZaoCanNum" type="tel" value="0"><i data-class="jmax"
                            class="num-add"></i></span> <span class="can_danwei">
                                <input id="ZaoCanZongCB" name="ZaoCanZongCB" type="hidden" value="0" />
                                餐=<em id="ZaoCanZong">0</em>元/人</span> </li>
                </ul>
            </div>
            <div class="zt_can">
                <ul>
                    <li><span class="left_name">增加午餐餐标：</span> <span class="can_price">
                        <%= WuCanList%>
                        <input id="WuCanMoney" name="WuCanMoney" type="hidden" />
                        <input id="WuCanCBMoney" name="WuCanCBMoney" type="hidden" />
                    </span></li>
                    <li><span class="left_name">增加餐数：</span> <span class="number"><i data-class="jmin"
                        class="num-minus"></i>
                        <input id="WuCanNum" name="WuCanNum" type="tel" value="0"><i data-class="jmax" class="num-add"></i></span>
                        <span class="can_danwei">
                            <input id="WuCanZongCB" name="WuCanZongCB" type="hidden" value="0" />
                            餐=<em id="WuCanZong">0</em>元/人</span> </li>
                </ul>
            </div>
            <div class="zt_can">
                <ul>
                    <li><span class="left_name">增加晚餐餐标：</span> <span class="can_price">
                        <%= WanCanList%>
                        <input id="WanCanMoney" name="WanCanMoney" type="hidden" />
                        <input id="WanCanCBMoney" name="WanCanCBMoney" type="hidden" />
                    </span></li>
                    <li><span class="left_name">增加餐数：</span> <span class="number"><i data-class="jmin"
                        class="num-minus"></i>
                        <input id="WanCanNum" name="WanCanNum" type="tel" value="0"><i data-class="jmax"
                            class="num-add"></i></span> <span class="can_danwei">
                                <input id="WanCanZongCB" name="WanCanZongCB" type="hidden" value="0" />餐=<em id="WanCanZong">0</em>元/人</span>
                    </li>
                </ul>
            </div>
            <div class="cent font16 mt10">
                <input id="CanWuFeiCB" name="CanWuFeiCB" type="hidden" value="0" data-cb="MoneyCB" />
                <input name="CanWuFei" type="hidden" />
                人均餐标费共增加 ：<span class="font_yellow" id="CanWuFei" data-id="Money">0</span> 元/人</div>
            <div class="padd cent">
                <a href="javascript:void(0);" data-class="guanbi" data-name="CanMoneyDiv" class="y_btn">
                    确定</a></div>
        </div>
    </em><em id="BaoXianDiv" style="display: none;">
        <uc1:ZuTuanHead runat="server" ID="ZuTuanHead3" HeadText="增加保险" HeadNum="3" />
        <div class="warp">
            <div class="zt_item mt10">
                <ul>
                    <li><span class="left_name">请选择：</span></li>
                </ul>
            </div>
            <div class="zt_can zt_baoxian">
                <ul>
                    <li><span class="left_name">
                        <%if (routeType == 2)
                          { %>
                        境外人身意外保险：<%}
                          else
                          { %>旅游人身意外保险：<%} %></span> <span class="can_price">
                              <%= RSBXList%>
                              <asp:HiddenField ID="RenShenBX" runat="server" />
                          </span></li>
                    <li class="gray_lineB paddB"><span class="left_name">旅游天数：</span><em><asp:Literal
                        ID="RSTianShu" runat="server"></asp:Literal></em>天=<em id="RSJiaGe"><%= RsBxJiage%></em>元/人<input
                            id="RSJiaGeCB" name="RSJiaGeCB" type="hidden" value="0" /></li>
                    <li class="font_gray last">注：（因自身原因或不可控的其他原因发生意外，导致人身受到伤害所投保的保险，保额最多10万元/人）</li>
                </ul>
            </div>
            <div class="zt_can zt_baoxian">
                <ul>
                    <li><span class="left_name">综合交通意外保险：</span> <span class="can_price">
                        <%= JTBXList%>
                        <asp:HiddenField ID="JiaoTongBX" runat="server" />
                    </span></li>
                    <li class="gray_lineB paddB"><span class="left_name">旅游天数：</span><em><asp:Literal
                        ID="JTTianShu" runat="server"></asp:Literal></em>天=<em id="JTJiaGe"><%= JtBxJiage%></em>元/人<input
                            id="JTJiaGeCB" name="JTJiaGeCB" type="hidden" value="0" /></li>
                    <li class="font_gray last">注：（含飞机、火车、汽车、轮船等四大交通工具发生意外而投保的保险，保额最多40万元/人）</li>
                </ul>
            </div>
            <div class="cent font16 mt10">
                人均保险费共增加 ：<span class="font_yellow" id="RJBXF" data-id="Money">0</span> 元/人<input
                    id="RJBXFCB" name="RJBXFCB" data-cb="MoneyCB" type="hidden" value="0" /><input type="hidden"
                        name="RJBXF" /></div>
            <div class="padd cent">
                <a href="javascript:void(0);" data-class="guanbi" data-name="BaoXianDiv" class="y_btn">
                    确定</a></div>
        </div>
    </em><em id="DaoYouDiv" style="display: none;">
        <uc1:ZuTuanHead runat="server" ID="ZuTuanHead4" HeadText="全陪导游" HeadNum="4" />
        <div class="warp">
            <div class="zt_item mt10">
                <ul>
                    <li><span class="left_name">请选择：</span></li>
                </ul>
            </div>
            <div class="zt_baoxian zt_daoyou">
                <ul>
                    <li class="gray_lineB">目的地 导游服务，保证每车<input id="DiPeiDaoYouNum" name="DiPeiDaoYouNum"
                        type="hidden" value="1" /><em>1</em>名 平摊至每人增加<input id="DiPeiDaoYouFeiCB" name="DiPeiDaoYouFeiCB"
                            type="hidden" /><em id="DiPeiDaoYouFei">0</em>元/人</li>
                    <input name="DiPeiDaoYouFei" type="hidden" />
                    <input id="DiPeiDaoYou" name="DiPeiDaoYou" runat="server" type="hidden" />
                    <input id="DiPeiDaoYouCB" name="DiPeiDaoYouCB" runat="server" type="hidden" />
                    <li>
                        <%if (routeType == 2)
                          { %>全程陪 导游服务，保证每团 1 名<input id="DaoYouNum" name="DaoYouNum" type="hidden" value="1" />
                        <%}
                          else
                          { %>
                        全程陪 导游服务，需<span class="number"><i class="num-minus" data-class="jmin"></i><input
                            id="DaoYouNum" name="DaoYouNum" type="text" value="0" /><i class="num-add" data-class="jmax"></i></span>
                        名
                        <%} %>
                    </li>
                    <input id="QuanPeiDaoYouFeiCB" name="QuanPeiDaoYouFeiCB" type="hidden" />
                    <li>平摊至每人增加<em id="QuanPeiDaoYouFei">0</em>元/人</li>
                    <input name="QuanPeiDaoYouFei" type="hidden" />
                    <input id="DaoYouMoney" name="DaoYouMoney" runat="server" type="hidden" />
                    <input id="DaoYouMoneyCB" name="DaoYouMoneyCB" runat="server" type="hidden" />
                </ul>
            </div>
            <input id="DaoYouFeiCB" name="DaoYouFeiCB" data-cb="MoneyCB" type="hidden" />
            <input name="DaoYouFei" type="hidden" />
            <div class="cent font16 mt10">
                人均导游费共增加 ：<span class="font_yellow" id="DaoYouFei" data-id="Money">0</span> 元/人</div>
            <div class="padd cent">
                <a href="javascript:void(0);" data-class="guanbi" data-name="DaoYouDiv" class="y_btn">
                    确定</a></div>
        </div>
    </em><em id="ZuCheDiv" style="display: none;">
        <uc1:ZuTuanHead runat="server" ID="ZuTuanHead5" HeadText="安排接送" HeadNum="5" />
        <div class="warp">
            <div class="zt_item mt10">
                <ul>
                    <li><span class="left_name">请选择：</span></li>
                </ul>
            </div>
            <div class="zt_car">
                <ul>
                    <li><span class="label_name"><em class="font_yellow">去程<input id="QuGongLi" name="QuGongLi"
                        type="hidden" /></em>—集合出发地点：</span>
                        <input id="QuQiDian" name="QuQiDian" type="text" readonly="readonly" data-name="txtPlace"
                            class="u-input" value="浙江省杭州市武林广场" /><input id="QuQilng" data-name="lng" name="QuQilng"
                                type="hidden" value="120.170004" /><input id="QuQilat" data-name="lat" name="QuQilat"
                                    type="hidden" value="30.276711" /></li>
                    <li><a class="yudin_btn" data-class="ditu" data-name="QuQiDian" readonly="readonly"
                        href="javascript:;">地图选址</a></li>
                    <li><span class="label_name">送达机场车站：</span><input id="QuZhongDian" name="QuZhongDian"
                        data-name="txtPlace" type="text" readonly="readonly" class="u-input" value="请填写具体地址" /><input
                            id="QuZhonglng" data-name="lng" name="QuZhonglng" type="hidden" /><input id="QuZhonglat"
                                data-name="lat" name="QuZhonglat" type="hidden" /></li>
                    <li><a class="yudin_btn" data-class="ditu" data-name="QuZhongDian" href="javascript:;">
                        地图选址</a></li>
                    <em data-class="chexing">
                        <li><span class="label_name">选择车型：</span><div class="select">
                            <select id="ddl_QuGongLi" name="ddl_QuGongLi">
                                <%=GetQuCarHtml()%>
                            </select>
                        </div>
                        </li>
                        <li><span class="label_name">租车数量：</span><span class="number"><i data-class="jmin"
                            class="num-minus"></i><input name="QuZuCheNum" type="tel" value="1"><i data-class="jmax"
                                class="num-add"></i></span> 增加车费：<em class="font_yellow" name="QuCheFei">0</em>元<input
                                    name="QuCheFei" type="hidden" /><input name="QuCheFeiCB" type="hidden" value="0" /></li>
                    </em>
                    <li><a data-class="addcar" class="yudin_btn" href="javascript:;">添加车型</a></li>
                </ul>
            </div>
            <div class="zt_car">
                <ul>
                    <li><span class="label_name"><em class="font_yellow">回程<input id="HuiGongLi" name="HuiGongLi"
                        type="hidden" /></em>—机场车站名称：</span><input id="HuiQiDian" readonly="readonly" name="HuiQiDian"
                            data-name="txtPlace" type="text" class="u-input" value="请填写具体地址" /><input id="HuiQilng"
                                data-name="lng" name="HuiQilng" type="hidden" /><input id="HuiQilat" data-name="lat"
                                    name="HuiQilat" type="hidden" /></li>
                    <li><a class="yudin_btn" data-class="ditu" data-name="HuiQiDian" href="javascript:;">
                        地图选址</a></li>
                    <li><span class="label_name">接回具体地点：</span><input id="HuiZhongDian" readonly="readonly"
                        name="HuiZhongDian" data-name="txtPlace" type="text" class="u-input" value="请填写具体地址" /><input
                            id="HuiZhonglng" data-name="lng" name="HuiZhonglng" type="hidden" /><input id="HuiZhonglat"
                                data-name="lat" name="HuiZhonglat" type="hidden" /></li>
                    <li><a class="yudin_btn" data-class="ditu" data-name="HuiZhongDian" href="javascript:;">
                        地图选址</a></li>
                    <em data-class="chexing">
                        <li><span class="label_name">选择车型：</span><div class="select">
                            <select id="ddl_HuiGongLi" name="ddl_HuiGongLi">
                                <%=GetQuCarHtml()%>
                            </select>
                        </div>
                        </li>
                        <li><span class="label_name">租车数量：</span><span class="number"><i data-class="jmin"
                            class="num-minus"></i><input name="HuiZuCheNum" type="tel" value="1"><i data-class="jmax"
                                class="num-add"></i></span> 增加车费：<em class="font_yellow" name="HuiCheFei">0</em>元<input
                                    name="HuiCheFeiCB" type="hidden" value="0" /><input type="hidden" name="HuiCheFei" /></li>
                    </em>
                    <li><a data-class="addcar" class="yudin_btn" href="javascript:;">添加车型</a></li>
                </ul>
            </div>
            <div class="cent font16 mt10">
                人均接送费共增加 ：<span class="font_yellow" id="ZuCheMoney" data-id="Money">0</span> 元/人<input
                    id="ZuCheMoneyCB" name="ZuCheMoneyCB" data-cb="MoneyCB" type="hidden" /><input name="ZuCheMoney"
                        type="hidden" /></div>
            <div class="padd cent">
                <a href="javascript:void(0);" data-class="guanbi" data-name="ZuCheDiv" class="y_btn">
                    确定</a></div>
        </div>
    </em>
    </form>
    <div id="allmap" style="display: none; width: 100%; height: 480px;">
    </div>
    <div data-class="JStishi" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="width: 95%; margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在计算两地之间的距离，请稍后...
            </div>
        </div>
    </div>
    <div id="TiJiaoMask" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在提交订单，请等待。。。
            </div>
        </div>
    </div>
</body>

<script src="js/jq.mobi.min.js" type="text/javascript"></script>

<script src="js/jquery_cm.js" type="text/javascript"></script>

<script src="js/table-toolbar.js" type="text/javascript"></script>

<script type="text/javascript" src="http://api.map.baidu.com/api?type=quick&ak=2F0K5eVGt0eFGXy6oWKgyNRY&v=1.0"></script>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=2F0K5eVGt0eFGXy6oWKgyNRY"></script>

<script type="text/javascript">
    var PageOrder = {
        Init: function() {
            var _m = iLogin.getM();
            if (!_m.isLogin) {
                $("#link01").click(function() {
                    alert("您还未登录，请先登录");
                    window.location.href = '/Login.aspx?rurl=' + encodeURIComponent(window.location.href);
                });
                $("#div[data-class=Tologin]").click(function() {
                    window.location.href = '/Login.aspx?rurl=' + encodeURIComponent(window.location.href);
                });
            }
            else {
                $("#link01").click(function() {
                    PageOrder.subit();
                });
            }
        },
        subit: function() {
        if ($("#QuGongLi").val() == "0" && $("#QuZhongDian").val() != "请填写具体地址" && $("#QuZhongDian").val() != "") {
                alert("去程起点和终点无法计算出距离，请重新选择起点和终点！");
                return false;
            }
            if ($("#HuiGongLi").val() == "0" && $("#HuiZhongDian").val() != "请填写具体地址" && $("#HuiZhongDian").val() != "") {
                alert("回程起点和终点无法计算出距离，请重新选择起点和终点！");
                return false;
            }
            var _m = iLogin.getM();
            if (!_m.isLogin) { return false; };
            $("#link01").html("正在提交");
            $("#link01").unbind("click");
            var url = "/ZiZuTuan.aspx?dotype=save";
            if (window.confirm("请确认提交")) {
                $("#TiJiaoMask").toggle();
                $.ajax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#link01").closest("form").serialize(),
                    success: function(ret) {
                    if (ret.result == "1") {
                        $("#TiJiaoMask").toggle();
                            alert(ret.msg);
                            location.href = "/Member/DingDanList.aspx?OrderType=9";
                        }
                        else {
                            $("#TiJiaoMask").toggle();
                            $("#link01").html("直接预订");
                            alert(ret.msg);
                            $("#link01").bind("click");
                        }
                    },
                    error: function() {
                    $("#TiJiaoMask").toggle();
                        $("#link01").html("直接预订");
                        alert("报价失败");
                        $("#link01").bind("click");
                    }
                });
            }
        },
        Bind: function() {
            PageOrder.Init();
        }
    };

    $(function() {
    PageOrder.Bind();
    $("#BtnLogin").click(function() { window.location.href = '/HuiYuanReg.aspx?rurl=' + encodeURIComponent(window.location.href); });
    })
</script>

<script type="text/javascript">
    var usercate = '<%= usertp%>';
    $(function() {

        $("#zthead1").click(function() {
            $("div[data-div=zthead1]").toggle();
        });
        $("#zthead2").click(function() {
            $("div[data-div=zthead2]").toggle();
        });
        $("#zthead3").click(function() {
            $("div[data-div=zthead3]").toggle();
        });
        $("#zthead4").click(function() {
            $("div[data-div=zthead4]").toggle();
        });
        $("#zthead5").click(function() {
            $("div[data-div=zthead5]").toggle();
        });
        //绑定事件
        pageData.initClick();
        //绑定标准人数
        var BiaoZhunRS = $("#<%= BiaoZhunNum.ClientID%>").val();
        $("#RenShu").val(BiaoZhunRS);
        $("#RenShuNum").html(BiaoZhunRS);
        var type = "<%= routeType %>";
        if (type == "1") {
            $("#DaoYouNum").val("0");
            $("#DiPeiDaoYouNum").val("1");
        }
        if (type == "2") {
            $("#DaoYouNum").val("1");
            $("#DiPeiDaoYouNum").val("1");
        }
        if (type == "3") {
            $("#DaoYouNum").val("0");
            $("#DiPeiDaoYouNum").val("1");
        }
        $("#DaoYouNum").blur();
        $("#DiPeiDaoYouNum").blur();
        OrderPage.ZongJia();
    });
    var pageData = {
        initClick: function() {
            //打开隐藏层事件
            $(".R_jiantou").click(function() {

                var divid = $(this).attr("data-class");
                if (divid == "YouWan" || divid == "HangBan") {
                    $("#" + divid).toggle();
                }
                else {
                    $("#zhuyemian").hide();
                    $("#" + divid).toggle();
                }
                $('body,html').animate({ scrollTop: 0 }, 500);
            });
            //打勾去勾事件
            $("a[data-class=fxk_ok]").click(function() {
                if ($(this).attr("class") == "a_fxk_on") {
                    $(this).removeClass("a_fxk_on").addClass("a_fxk");
                }
                else {
                    $(this).removeClass("a_fxk").addClass("a_fxk_on");
                }
                OrderPage.ZongJia();
            });
            //游玩时间选择事件
            $("li[data-day=youwan]").click(function() {
                var youwanid = $(this).attr("data-value");
                var url = window.location.href;
                if (url.indexOf("tid") > 0) {
                    url = url.replace(/tid=([\s\S]*?)&/, 'tid=' + youwanid + '&');
                }
                else {
                    url = url + "&tid=" + youwanid + "&";
                }
                window.location.href = url;
            });
            //航班选择事件
            $("li[data-hb=hangban]").click(function() {
                var youwanid = $(this).attr("data-value");
                var url = window.location.href;
                if (url.indexOf("hangban") > 0) {
                    url = url.replace(/hangban=([\s\S]*?)&/, 'hangban=' + youwanid + '&');
                }
                else {
                    url = url + "&hangban=" + youwanid + "&";
                }
                window.location.href = url;
            });
            //关闭事件（游玩日期和航班选择）
            $(".close_icon").click(function() {
                var divid = $(this).attr("data-class");
                $("#" + divid).toggle();
            });

            //成人数减少事件
            $("i[data-class=js_min]").click(function() {
                var getNum = $(this).parent().find("input").eq(0);
                if (tableToolbar.getInt(getNum.val()) > 2) {//成人数量不能低于2人
                    getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                } else {
                    getNum.val(2);
                }
                $("#RenShuNum").html(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#ETRenShu").val())); //总人数
                //判断总人数是否低于标准人数
                if (tableToolbar.getInt($("#RenShuNum").html()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                    $("#CarMoney").html("0");
                    $("#<%= CarMoneyCB.ClientID%>").val("0");
                }
                else {
                    var jiage = $("#<%= CarFei.ClientID%>").val();
                    var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                    var tianshu = $("#<%= LYTianShu.ClientID%>").val();
                    $("#CarMoney").html(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                    $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                }
                $("#CarMoneyXS").html($("#CarMoney").html());
                $("input[name=CarMoney]").val($("#CarMoney").html());
                $("#DaoYouNum").blur();
                $("#DiPeiDaoYouNum").blur();
                OrderPage.ZongJia();
            });
            //成人数增加事件
            $("i[data-class=js_max]").click(function() {
                var getNum = $(this).parent().find("input").eq(0);
                getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                $("#RenShuNum").html(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#ETRenShu").val()));
                if (tableToolbar.getInt($("#RenShuNum").html()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                    $("#CarMoney").html("0");
                    $("#<%= CarMoneyCB.ClientID%>").val("0");
                }
                else {
                    var jiage = $("#<%= CarFei.ClientID%>").val();
                    var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                    var tianshu = $("#<%= LYTianShu.ClientID%>").val();
                    $("#CarMoney").html(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                    $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                }
                $("#CarMoneyXS").html($("#CarMoney").html());
                $("input[name=CarMoney]").val($("#CarMoney").html());
                $("#DaoYouNum").blur();
                $("#DiPeiDaoYouNum").blur();
                OrderPage.ZongJia();
            });
            //儿童数减少事件
            $("i[data-class=etjs_min]").click(function() {
                var getNum = $(this).parent().find("input").eq(0);
                if (tableToolbar.getInt(getNum.val()) > 0) {//成人数量不能低于2人
                    getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                } else {
                    getNum.val(0);
                }
                $("#RenShuNum").html(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#RenShu").val())); //总人数
                if (tableToolbar.getInt($("#RenShuNum").html()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                    $("#CarMoney").html("0");
                    $("#<%= CarMoneyCB.ClientID%>").val("0");
                }
                else {
                    var jiage = $("#<%= CarFei.ClientID%>").val();
                    var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                    var tianshu = $("#<%= LYTianShu.ClientID%>").val();
                    $("#CarMoney").html(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                    $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                }
                $("#CarMoneyXS").html($("#CarMoney").html());
                $("input[name=CarMoney]").val($("#CarMoney").html());
                $("#DaoYouNum").blur();
                $("#DiPeiDaoYouNum").blur();
                OrderPage.ZongJia();
            });
            //儿童数增加事件
            $("i[data-class=etjs_max]").click(function() {
                var getNum = $(this).parent().find("input").eq(0);
                getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                $("#RenShuNum").html(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#RenShu").val()));
                if (tableToolbar.getInt($("#RenShuNum").html()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                    $("#CarMoney").html("0");
                    $("#<%= CarMoneyCB.ClientID%>").val("0");
                }
                else {
                    var jiage = $("#<%= CarFei.ClientID%>").val();
                    var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                    var tianshu = $("#<%= LYTianShu.ClientID%>").val();
                    $("#CarMoney").html(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                    $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                }
                $("#CarMoneyXS").html($("#CarMoney").html());
                $("input[name=CarMoney]").val($("#CarMoney").html());
                $("#DaoYouNum").blur();
                $("#DiPeiDaoYouNum").blur();
                OrderPage.ZongJia();
            });
            //减少事件
            $("i[data-class=jmin]").click(function() {
                var getNum = $(this).parent().find("input").eq(0);
                if (tableToolbar.getInt(getNum.val()) > 0) {
                    getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                } else {
                    getNum.val(0);
                }
                var aid = $(this).parent().find("input").attr("id");

                if (aid == "" || aid == "undefined" || aid == null) {
                    var aname = $(this).parent().find("input").attr("name");
                    $("input[name=" + aname + "]").blur();
                }
                else {
                    $("#" + aid).blur();
                }
                OrderPage.ZongJia();
            });
            //增加事件
            $("i[data-class=jmax]").click(function() {
                var getNum = $(this).parent().find("input").eq(0);
                getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                var aid = $(this).parent().find("input").attr("id");
                if (aid == "" || aid == "undefined" || aid == null) {
                    var aname = $(this).parent().find("input").attr("name");
                    $("input[name=" + aname + "]").blur();
                }
                else {
                    $("#" + aid).blur();
                }
                OrderPage.ZongJia();
            });
            //关闭弹出层
            $("i[data-class=guanbi]").click(function() {
                $("#zhuyemian").show();
                $(this).closest("em").toggle();
                OrderPage.ZongJia();
            });
            $("a[data-class=guanbi]").click(function() {
                $("#zhuyemian").show();
                $(this).closest("em").toggle();
                var DivId = $(this).attr("data-name");
                var obj = $("span[data-class=" + DivId + "]").closest("div").find("a[data-class=fxk_ok]");
                if ($(obj).attr("class") == "a_fxk_on") {
                    $(obj).removeClass("a_fxk_on").addClass("a_fxk");

                }
                else {
                    $(obj).removeClass("a_fxk").addClass("a_fxk_on");
                }
                OrderPage.ZongJia();
            });
            //选择自由行方式
            $(".zt_qiche ul li").click(function() {

                var dataval = $(this).find("a").attr("data-value");
                if (dataval == "0") {
                    $("#RenShuNum").html(tableToolbar.getInt($("#RenShu").val()) + tableToolbar.getInt($("#ETRenShu").val())); //总人数
                    //判断总人数是否低于标准人数
                    if (tableToolbar.getInt($("#RenShuNum").html()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                        $("#CarMoney").html("0");
                        $("#<%= CarMoneyCB.ClientID%>").val("0");
                    }
                    else {
                        var jiage = $("#<%= CarFei.ClientID%>").val();
                        var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                        var tianshu = $("#<%= LYTianShu.ClientID%>").val();
                        $("#CarMoney").html(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                        $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html())) / $("#RenShuNum").html()));
                    }
                    $(".zt_qiche ul li").find("a").removeClass("on");
                    $(this).find("a").addClass("on");
                }
                else {
                    $("#CarMoney").html("0");
                    $("#<%= CarMoneyCB.ClientID%>").val("0");
                    $(".zt_qiche ul li").find("a").removeClass("on");
                    $(this).find("a").addClass("on");
                }
                $("#CarMoneyXS").html($("#CarMoney").html());
                $("input[name=CarMoney]").val($("#CarMoney").html());
            });
            //选择早餐价格
            $("a[data-class=zaocanc]").click(function() {
                $(this).closest(".can_price").find("a").removeClass("on");
                $(this).addClass("on");
                $("#ZaoCanMoney").val($(this).attr("data-value"));
                $("#ZaoCanCBMoney").val($(this).attr("data-cb"));
                $("#ZaoCanNum").blur();
            });
            //选择午餐价格
            $("a[data-class=wucanc]").click(function() {
                $(this).closest(".can_price").find("a").removeClass("on");
                $(this).addClass("on");
                $("#WuCanMoney").val($(this).attr("data-value"));
                $("#WuCanCBMoney").val($(this).attr("data-cb"));
                $("#WuCanNum").blur();
            });
            //选择晚餐价格
            $("a[data-class=wancanc]").click(function() {
                $(this).closest(".can_price").find("a").removeClass("on");
                $(this).addClass("on");
                $("#WanCanMoney").val($(this).attr("data-value"));
                $("#WanCanCBMoney").val($(this).attr("data-cb"));
                $("#WanCanNum").blur();
            });
            //选择增加早餐数
            $("#ZaoCanNum").blur(function() {
                if ($('#ZaoCanNum').val() != "") {
                    var zaocanfei = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").val());
                    var wucanfei = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").val());
                    var wancanfei = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").val());
                    var zaocanfeicb = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanCBMoney").val());
                    var wucanfeicb = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanCBMoney").val());
                    var wancanfeicb = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanCBMoney").val());
                    $("#ZaoCanZong").html(zaocanfei);
                    $("#ZaoCanZongCB").html(zaocanfeicb);
                    $('#CanWuFei').html(zaocanfei + wucanfei + wancanfei);
                    $("input[name=CanWuFei]").val($("#CanWuFei").html());
                    $('#CanWuFeiCB').val(zaocanfeicb + wucanfeicb + wancanfeicb);
                    $("#CanMoneyXS").html($('#CanWuFei').html());
                }
            });
            //选择增加午餐数
            $("#WuCanNum").blur(function() {
                if ($('#WuCanNum').val() != "") {
                    var zaocanfei = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").val());
                    var wucanfei = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").val());
                    var wancanfei = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").val());
                    var zaocanfeicb = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanCBMoney").val());
                    var wucanfeicb = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanCBMoney").val());
                    var wancanfeicb = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanCBMoney").val());
                    $("#WuCanZong").html(wucanfei);
                    $("#WuCanZongCB").html(wucanfeicb);
                    $('#CanWuFei').html(zaocanfei + wucanfei + wancanfei);
                    $("input[name=CanWuFei]").val($("#CanWuFei").html());
                    $('#CanWuFeiCB').val(zaocanfeicb + wucanfeicb + wancanfeicb);
                    $("#CanMoneyXS").html($('#CanWuFei').html());
                }
            });
            //选择增加晚餐数
            $("#WanCanNum").blur(function() {
                if ($('#WanCanNum').val() != "") {
                    var zaocanfei = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").val());
                    var wucanfei = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").val());
                    var wancanfei = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").val());
                    var zaocanfeicb = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanCBMoney").val());
                    var wucanfeicb = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanCBMoney").val());
                    var wancanfeicb = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanCBMoney").val());
                    $("#WanCanZong").html(wancanfei);
                    $("#WanCanZongCB").html(wancanfeicb);
                    $('#CanWuFei').html(zaocanfei + wucanfei + wancanfei);
                    $("input[name=CanWuFei]").val($("#CanWuFei").html());
                    $('#CanWuFeiCB').val(zaocanfeicb + wucanfeicb + wancanfeicb);
                    $("#CanMoneyXS").html($('#CanWuFei').html());
                }
            });
            //人身保险
            $("a[data-class=rsbxc]").click(function() {
                $(this).closest(".can_price").find("a").removeClass("on");
                $(this).addClass("on");
                $("#<%= RenShenBX.ClientID%>").val($(this).attr("data-value"));
                $("#RSJiaGeCB").val(tableToolbar.getFloat($(this).attr("data-cb")) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val()));
                
                BaoXian();
            });
            //交通保险
            $("a[data-class=jtbxc]").click(function() {
                $(this).closest(".can_price").find("a").removeClass("on");
                $(this).addClass("on");
                $("#<%= JiaoTongBX.ClientID%>").val($(this).attr("data-value"));
                $("#JTJiaGeCB").val(tableToolbar.getFloat($(this).attr("data-cb")) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val()));
                BaoXian();
            });
            //保险计算
            function BaoXian() {

                $("#RSJiaGe").html(tableToolbar.getFloat($("#<%= RenShenBX.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val()));
                $("#JTJiaGe").html(tableToolbar.getFloat($("#<%= JiaoTongBX.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val()));

                if (tableToolbar.getFloat($("#<%= RenShenBX.ClientID%>").val()) > 0 && tableToolbar.getFloat($("#<%= JiaoTongBX.ClientID%>").val()) > 0) {
                    $("#RJBXF").html(tableToolbar.getFloat(tableToolbar.getFloat($("#RSJiaGe").html()) + tableToolbar.getFloat($("#JTJiaGe").html())));
                    $("#RJBXFCB").val(tableToolbar.getFloat(tableToolbar.getFloat($("#RSJiaGeCB").val()) + tableToolbar.getFloat($("#JTJiaGeCB").val())));
                    $("#BaoXianFS").val("人身保险,交通保险");
                    $("#BaoXianXS").html($("#RJBXF").html());
                }
                else if (tableToolbar.getFloat($("#<%= RenShenBX.ClientID%>").val()) > 0) {
                    $("#RJBXF").html(tableToolbar.getFloat($("#RSJiaGe").html()));
                    $("#RJBXFCB").val(tableToolbar.getFloat($("#RSJiaGeCB").val()));
                    $("#BaoXianFS").val("人身保险");
                    $("#BaoXianXS").html($("#RJBXF").html());

                }
                else if (tableToolbar.getFloat($("#<%= JiaoTongBX.ClientID%>").val()) > 0) {
                    $("#RJBXF").html(tableToolbar.getFloat($("#JTJiaGe").html()));
                    $("#RJBXFCB").val(tableToolbar.getFloat($("#JTJiaGeCB").val()));
                    $("#BaoXianFS").val("交通保险");
                    $("#BaoXianXS").html($("#RJBXF").html());

                }
                else {
                    $("#RJBXF").html("0");
                    $("#BaoXianFS").val("");
                    $("#BaoXianXS").html($("#RJBXF").html());
                }
                $("input[name=RJBXF]").val($("#RJBXF").html());
            }
            //全陪导游计算
            $("#DaoYouNum").blur(function() {
                var type = "<%= routeType %>";
                var daoyounum = $("#DaoYouNum").val();
                if (type == "1") {
                    //国内长线  全陪背后公式 = 【线路门市价/2 + 400元/天*自动识别的旅游天数】/成团人数
                    if (tableToolbar.getInt(daoyounum) < 0) {
                        $("#DaoYouNum").val("0");
                    }
                    $("#QuanPeiDaoYouFei").html(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenMS.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoney.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DaoYouNum").val())));
                    $("#QuanPeiDaoYouFeiCB").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenJieSuan.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoneyCB.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DaoYouNum").val())));
                }
                else if (type == "2") {
                    //国际线路  全陪：公式 =【线路门市价/2 + 300元/员/天*天数】/ 标准人数 *【标准人数15-成团人数】/成团人数(如果成团人数大于标准人数，则按1算)
                    if (tableToolbar.getInt(daoyounum) < 1) {
                        $("#DaoYouNum").val("1");
                    }
                    var rsnum = tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html());
                    if (tableToolbar.getInt(rsnum) < 1) {
                        $("#QuanPeiDaoYouFei").html("0");
                        $("#QuanPeiDaoYouFeiCB").val("0");
                    }
                    else {
                        $("#QuanPeiDaoYouFei").html(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenMS.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoney.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val())) / tableToolbar.getFloat($("#<%= BiaoZhunNum.ClientID%>").val()) * tableToolbar.getFloat(rsnum) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DaoYouNum").val())));
                        $("#QuanPeiDaoYouFeiCB").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenJieSuan.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoneyCB.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val())) / tableToolbar.getFloat($("#<%= BiaoZhunNum.ClientID%>").val()) * tableToolbar.getFloat(rsnum) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DaoYouNum").val())));
                    }
                }
                else if (type == "3") {
                    //周边短线   全陪背后公式 = 【线路门市价/3 + 400元/天*自动识别的旅游天数】/成团人数
                    if (tableToolbar.getInt(daoyounum) < 0) {
                        $("#DaoYouNum").val("0");
                    }
                    $("#QuanPeiDaoYouFei").html(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenMS.ClientID%>").val()) / 3 + tableToolbar.getFloat($("#<%= DaoYouMoney.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DaoYouNum").val())));
                    $("#QuanPeiDaoYouFeiCB").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenJieSuan.ClientID%>").val()) / 3 + tableToolbar.getFloat($("#<%= DaoYouMoneyCB.ClientID%>").val()) * tableToolbar.getFloat($("#<%= LYTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DaoYouNum").val())));
                }
                var dipeifei = $("#DiPeiDaoYouFei").html();
                var dipeifeicb = $("#DiPeiDaoYouFeiCB").val();
                $("input[name=DiPeiDaoYouFei]").val(dipeifei);
                $("input[name=QuanPeiDaoYouFei]").val(quanpeifei);
                var quanpeifei = $("#QuanPeiDaoYouFei").html();
                var quanpeifeicb = $("#QuanPeiDaoYouFeiCB").val();
                $("#DaoYouFei").html(tableToolbar.getFloat(tableToolbar.getFloat(dipeifei) + tableToolbar.getFloat(quanpeifei)));
                $("#DaoYouFeiCB").val(tableToolbar.getFloat(tableToolbar.getFloat(dipeifeicb) + tableToolbar.getFloat(quanpeifeicb)));
                $("#DaoYouXS").html($("#DaoYouFei").html());
                $("input[name=DaoYouFei]").val($("#DaoYouFei").html());
            });
            //地陪导游计算
            $("#DiPeiDaoYouNum").blur(function() {
                var dipeidaoyounum = $("#DiPeiDaoYouNum").val();
                if (tableToolbar.getInt(dipeidaoyounum) < 1) {
                    $("#DiPeiDaoYouNum").val("1");
                }
                var rsnum = tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").html());
                if (tableToolbar.getInt(rsnum) < 1) { rsnum = 0; }

                //地陪背后公式 =  200元/员/天*天数 / 标准成团人数   *  [标准人数25-成团人数]/成团人数
                $("#DiPeiDaoYouFei").html(tableToolbar.getFloat(tableToolbar.getFloat($("#<%= DiPeiDaoYou.ClientID%>").val()) * rsnum * tableToolbar.getInt($("#<%= LYTianShu.ClientID%>").val()) / tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DiPeiDaoYouNum").val())));
                $("#DiPeiDaoYouFeiCB").val(tableToolbar.getFloat(tableToolbar.getFloat($("#<%= DiPeiDaoYouCB.ClientID%>").val()) * rsnum * tableToolbar.getInt($("#<%= LYTianShu.ClientID%>").val()) / tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) / tableToolbar.getInt($("#RenShuNum").html()) * tableToolbar.getInt($("#DiPeiDaoYouNum").val())));

                var dipeifei = $("#DiPeiDaoYouFei").html();
                var quanpeifei = $("#QuanPeiDaoYouFei").html();
                $("input[name=DiPeiDaoYouFei]").val(dipeifei);
                $("input[name=QuanPeiDaoYouFei]").val(quanpeifei);
                var dipeifeicb = $("#DiPeiDaoYouFeiCB").val();
                var quanpeifeicb = $("#QuanPeiDaoYouFeiCB").val();
                $("#DaoYouFei").html(tableToolbar.getFloat(tableToolbar.getFloat(dipeifei) + tableToolbar.getFloat(quanpeifei)));
                $("#DaoYouFeiCB").val(tableToolbar.getFloat(tableToolbar.getFloat(dipeifeicb) + tableToolbar.getFloat(quanpeifeicb)));
                $("#DaoYouXS").html($("#DaoYouFei").html());
                $("input[name=DaoYouFei]").val($("#DaoYouFei").html());
            });
            //打开地图选择地址
            $("a[data-class=ditu]").click(function() {
                $("#allmap").css("height", window.screen.height);
                var obj = $(this).attr("data-name");
                $("#allmap").show();
                $("#form1").hide();
                pageData.GetAdress(obj);
            });
            //增加车型
            $("a[data-class=addcar]").click(function() {
                var html = $(this).closest("ul").find("em[data-class=chexing]").eq(0).clone(true);
                $(this).closest("ul").children("em[data-class=chexing]").append(html);
            });
            //去程起点变化（失去焦点）
            $("#QuQiDian").blur(function() {
                var quqilng = $("#QuQilng").val();
                var quqilat = $("#QuQilat").val();
                var quzhonglng = $("#QuZhonglng").val();
                var quzhonglat = $("#QuZhonglat").val();
                if (quqilat != "" && quqilng != "" && quzhonglat != "" && quzhonglng != "") {
                    pageData.GetDrivingInfo(quqilng, quqilat, quzhonglng, quzhonglat, "Qu");
                }
            });
            //去程终点点变化（失去焦点）
            $("#QuZhongDian").blur(function() {
                var quqilng = $("#QuQilng").val();
                var quqilat = $("#QuQilat").val();
                var quzhonglng = $("#QuZhonglng").val();
                var quzhonglat = $("#QuZhonglat").val();
                if (quqilat != "" && quqilng != "" && quzhonglat != "" && quzhonglng != "") {
                    pageData.GetDrivingInfo(quqilng, quqilat, quzhonglng, quzhonglat, "Qu");
                }
            });
            $("input[name=QuZuCheNum]").blur(function() {
                $(this).closest("em").find("select[name=ddl_QuGongLi]").change();
            });
            //去程起点变化（失去焦点）
            $("#HuiQiDian").blur(function() {
                var quqilng = $("#HuiQilng").val();
                var quqilat = $("#HuiQilat").val();
                var quzhonglng = $("#HuiZhonglng").val();
                var quzhonglat = $("#HuiZhonglat").val();
                if (quqilat != "" && quqilng != "" && quzhonglat != "" && quzhonglng != "") {
                    pageData.GetDrivingInfo(quqilng, quqilat, quzhonglng, quzhonglat, "Hui");
                }
            });
            //去程终点点变化（失去焦点）
            $("#HuiZhongDian").blur(function() {
                var quqilng = $("#HuiQilng").val();
                var quqilat = $("#HuiQilat").val();
                var quzhonglng = $("#HuiZhonglng").val();
                var quzhonglat = $("#HuiZhonglat").val();
                if (quqilat != "" && quqilng != "" && quzhonglat != "" && quzhonglng != "") {
                    pageData.GetDrivingInfo(quqilng, quqilat, quzhonglng, quzhonglat, "Hui");
                }
            });
            $("input[name=HuiZuCheNum]").blur(function() {
                $(this).closest("em").find("select[name=ddl_HuiGongLi]").change();
            });
            $("select[name=ddl_QuGongLi]").change(function() {
                if (tableToolbar.getFloat($("#QuGongLi").val()) < 1) {
                    alert("去程起点和终点无法计算出距离，请重新选择起点和终点！");
                    return false;
                }
                var that = $(this).closest("em").find("em[name=QuCheFei]");
                var thatin = $(this).closest("em").find("input[name=QuCheFei]");
                var thatcb = $(this).closest("em").find("input[name=QuCheFeiCB]");
                var cheNum = $(this).closest("em").find("input[name=QuZuCheNum]").val();
                var GongLiName = "QuGongLi";
                var _data = { id: $(this).val() };
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/CommonPage/ajaxChe.aspx?dotype=select",
                    dataType: "json",
                    data: _data,
                    success: function(ret) {
                        if (ret.result == "0") {
                            var list = eval('(' + ret.obj + ')');
                            OrderPage.alt(list, GongLiName);
                            var chefeijiage = jsonZ.Zjc;
                            that.html(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatin.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            var CheFeicount = $("em[name=QuCheFei]").length;
                            var ZongChefei = 0;
                            var ZongChefeiCB = 0;
                            for (var i = 0; i < CheFeicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=QuCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("em[name=QuCheFeiCB]").eq(i).val());
                            }
                            var CheFeihuicount = $("em[name=HuiCheFei]").length;
                            for (var i = 0; i < CheFeihuicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=HuiCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                            }
                            $("#ZuCheMoney").html(tableToolbar.getFloat(ZongChefei));
                            $("#JieSongXS").html($("#ZuCheMoney").html());
                            $("input[name=ZuCheMoney]").val($("#ZuCheMoney").html());
                            $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        }
                        else {
                            var list = eval('(' + ret.obj + ')');
                            OrderPage.alt(list, GongLiName);
                            var chefeijiage = jsonZ.Zjc;
                            that.html(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatin.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            var CheFeicount = $("em[name=QuCheFei]").length;
                            var ZongChefei = 0;
                            var ZongChefeiCB = 0;
                            for (var i = 0; i < CheFeicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=QuCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                            }
                            var CheFeihuicount = $("em[name=HuiCheFei]").length;
                            for (var i = 0; i < CheFeihuicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=HuiCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                            }
                            $("#ZuCheMoney").html(tableToolbar.getFloat(ZongChefei));
                            $("#JieSongXS").html($("#ZuCheMoney").html());
                            $("input[name=ZuCheMoney]").val($("#ZuCheMoney").html());
                            $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        }
                    },
                    error: function() {
                    }
                });
            });
            $("select[name=ddl_HuiGongLi]").change(function() {
                if (tableToolbar.getFloat($("#HuiGongLi").val()) < 1) {
                    alert("去程起点和终点无法计算出距离，请重新选择起点和终点！");
                    return false;
                }
                var that = $(this).closest("em").find("em[name=HuiCheFei]");
                var thatin = $(this).closest("em").find("input[name=HuiCheFei]");
                var thatcb = $(this).closest("em").find("input[name=HuiCheFeiCB]");
                var cheNum = $(this).closest("em").find("input[name=HuiZuCheNum]").val();
                var GongLiName = "QuGongLi";
                var _data = { id: $(this).val() };
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/CommonPage/ajaxChe.aspx?dotype=select",
                    dataType: "json",
                    data: _data,
                    success: function(ret) {
                        if (ret.result == "0") {
                            var list = eval('(' + ret.obj + ')');
                            OrderPage.alt(list, GongLiName);
                            var chefeijiage = jsonZ.Zjc;
                            that.html(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatin.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            var CheFeicount = $("em[name=QuCheFei]").length;
                            var ZongChefei = 0;
                            var ZongChefeiCB = 0;
                            for (var i = 0; i < CheFeicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=QuCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                            }
                            var CheFeihuicount = $("em[name=HuiCheFei]").length;
                            for (var i = 0; i < CheFeihuicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=HuiCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                            }
                            $("#ZuCheMoney").html(tableToolbar.getFloat(ZongChefei));
                            $("#JieSongXS").html($("#ZuCheMoney").html());
                            $("input[name=ZuCheMoney]").val($("#ZuCheMoney").html());
                            $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        }
                        else {
                            var list = eval('(' + ret.obj + ')');
                            OrderPage.alt(list, GongLiName);
                            var chefeijiage = jsonZ.Zjc;
                            that.html(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatin.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").html())));
                            var CheFeicount = $("em[name=QuCheFei]").length;
                            var ZongChefei = 0;
                            var ZongChefeiCB = 0;
                            for (var i = 0; i < CheFeicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=QuCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                            }
                            var CheFeihuicount = $("em[name=HuiCheFei]").length;
                            for (var i = 0; i < CheFeihuicount; i++) {
                                ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("em[name=HuiCheFei]").eq(i).html());
                                ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                            }
                            $("#ZuCheMoney").html(tableToolbar.getFloat(ZongChefei));
                            $("#JieSongXS").html($("#ZuCheMoney").html());
                            $("input[name=ZuCheMoney]").val($("#ZuCheMoney").html());
                            $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        }
                    },
                    error: function() {
                    }
                });
            });
        },
        //点击地图获取地址
        GetAdress: function(obj) {
            var map = new BMap.Map("allmap");
            map.centerAndZoom(new BMap.Point(120.170004, 30.276711), 12);
            map.addControl(new BMap.ZoomControl());
            var gc = new BMap.Geocoder();
            function showInfo(e) {
                var pt = e.point;
                $("#" + obj).closest("li").find("input[data-name=lng]").val(pt.lng);
                $("#" + obj).closest("li").find("input[data-name=lat]").val(pt.lat)
                gc.getLocation(pt, function(rs) {
                    var addComp = rs.addressComponents;
                    $("#" + obj).val(addComp.province + addComp.city + addComp.district + addComp.street);
                    $("#allmap").hide();
                    $("#form1").show();
                    $("#" + obj).focus();
                    $("#" + obj).blur();
                });
            }
            map.addEventListener("click", showInfo);
        },
        //根据经纬度得到两地间的距离
        GetDrivingInfo: function(longitude1, latitude1, longitude2, latitude2, id) {
            $("div[data-class=JStishi]").show();
            var map = new BMap.Map("allmap");
            map.centerAndZoom(new BMap.Point(120.170004, 30.276711), 15);
            // 百度地图API功能
            var sP1 = new BMap.Point(longitude1, latitude1);    //起点
            var sP2 = new BMap.Point(longitude2, latitude2);    //终点
            var v1, v2;
            var searchComplete = function(results) {
                if (transit.getStatus() != BMAP_STATUS_SUCCESS) {
                    return;
                }
                var plan = results.getPlan(0);
                v1 = plan.getDuration(true);                //获取时间
                v2 = plan.getDistance(true) + "\n";             //获取距离
            }
            var transit = new BMap.DrivingRoute(map, { renderOptions: { map: map },
                onSearchComplete: searchComplete,
                onPolylinesSet: function() {
                    setTimeout(function() {
                        var objet = $($("#" + id + "GongLi"));
                        $("#" + id + "GongLi").val(v2.replace("公里", ""));
                        $("div[data-class=JStishi]").hide();
                        var Checount = objet.closest("ul").find("select[name=ddl_" + id + "GongLi]").length;
                        for (var i = 0; i < Checount; i++) {
                            var objtr = objet.closest("ul").find("select[name=ddl_" + id + "GongLi]").eq(i);
                            $(objtr).change();
                        }
                        //$("#" + id).text("相距" + v2 + "，驾车需" + v1);
                    }, "1000");
                }
            });
            transit.search(sP1, sP2);
        }
    }
</script>

<script type="text/javascript">
        <%= JSON() %>;
        <%= FeetSetingJSON() %>;
    var jsonZ = { Zjc: 0, Zhy: 0, Zgb: 0, Zmfx: 0, Zfx: 0, Zyg: 0, Zcb:0 };
    var OrderPage = {
        InputJinE: function(typenum, gongliname) {
            var Gongli = tableToolbar.getFloat($("#" + gongliname).val());
            var JinE = 0;
            if (Gongli > jsonJE.Dgl) {
                var chaochengmoney = 0;
                if (typenum == 0) {
                    chaochengmoney = jsonCC.DCms;
                }
                else if (typenum == 1) {
                    chaochengmoney = jsonCC.DChy;
                }
                else if (typenum == 2) {
                    chaochengmoney = jsonCC.DCgb;
                }
                else if (typenum == 3) {
                    chaochengmoney = jsonCC.DCmfx;
                }
                else if (typenum == 4) {
                    chaochengmoney = jsonCC.DCfx;
                }
                else if (typenum == 5) {
                    chaochengmoney = jsonCC.DCyg;
                }
                else if (typenum == 6) {
                    chaochengmoney = jsonCC.DCcb;
                }
                var Dchaochu = tableToolbar.calculate((Gongli * 2), jsonJE.Dgl * 2, "-");
                var DchachuJinE = tableToolbar.calculate(Dchaochu, chaochengmoney, "*");
                JinE = tableToolbar.calculate(JinE, DchachuJinE, "+");
            }

            return JinE;
        },
        alt: function(objct, gongliname) {
            jsonJE.Qjc = tableToolbar.getFloat(objct.MenShiJia);
            jsonJE.Qgl = tableToolbar.getFloat(objct.MenShiJiaGeZuChe);
            jsonJE.Qcc = tableToolbar.getFloat(objct.MenShiJiaGeChaoCheng);
            jsonJE.Qcs = tableToolbar.getFloat(objct.MenShiJiaGeChaoShi);
            jsonJE.Djc = tableToolbar.getFloat(objct.YouHuiJia);
            jsonJE.Dgl = tableToolbar.getFloat(objct.YouHuiJiaGeZuChe);
            jsonJE.Dcc = tableToolbar.getFloat(objct.YouHuiJiaGeZuChe);

            jsonTJ.Qhy = tableToolbar.getFloat(objct.QHuiYuanJieE);
            jsonTJ.Qgb = tableToolbar.getFloat(objct.QGuiBingJieE);
            jsonTJ.Qmfx = tableToolbar.getFloat(objct.QFreeFenXiaoShangJieE);
            jsonTJ.Qfx = tableToolbar.getFloat(objct.QFenXiaoShangJieE);
            jsonTJ.Qyg = tableToolbar.getFloat(objct.QYuanGongJieE);
            jsonTJ.Dhy = tableToolbar.getFloat(objct.DHuiYuanJieE);
            jsonTJ.Dgb = tableToolbar.getFloat(objct.DGuiBingJieE);
            jsonTJ.Dmfx = tableToolbar.getFloat(objct.DFreeFenXiaoShangJieE);
            jsonTJ.Dfx = tableToolbar.getFloat(objct.DFenXiaoShangJieE);
            jsonTJ.Dyg = tableToolbar.getFloat(objct.DYuanGongJieE);
            jsonTJ.Dcb = tableToolbar.getFloat(objct.DChengBenJieE);


            jsonCC.QCms = tableToolbar.getFloat(objct.QCMenShi);
            jsonCC.QChy = tableToolbar.getFloat(objct.QCHuiYuan);
            jsonCC.QCgb = tableToolbar.getFloat(objct.QCGuiBing);
            jsonCC.QCmfx = tableToolbar.getFloat(objct.QCFreeFenXiaoShang);
            jsonCC.QCfx = tableToolbar.getFloat(objct.QCFenXiaoShang);
            jsonCC.QCyg = tableToolbar.getFloat(objct.QCYuanGong);
            jsonCC.DCcb = tableToolbar.getFloat(objct.DCChengBen);
            jsonCC.DCms = tableToolbar.getFloat(objct.DCMenShi);
            jsonCC.DChy = tableToolbar.getFloat(objct.DCHuiYuan);
            jsonCC.DCgb = tableToolbar.getFloat(objct.DCGuiBing);
            jsonCC.DCmfx = tableToolbar.getFloat(objct.DCFreeFenXiaoShang);
            jsonCC.DCfx = tableToolbar.getFloat(objct.DCFenXiaoShang);
            jsonCC.DCyg = tableToolbar.getFloat(objct.DCYuanGong);


            jsonCS.QSms = tableToolbar.getFloat(objct.QSMenShi);
            jsonCS.QShy = tableToolbar.getFloat(objct.QSHuiYuan);
            jsonCS.QSgb = tableToolbar.getFloat(objct.QSGuiBing);
            jsonCS.QSmfx = tableToolbar.getFloat(objct.QSFreeFenXiaoShang);
            jsonCS.QSfx = tableToolbar.getFloat(objct.QSFenXiaoShang);
            jsonCS.QSyg = tableToolbar.getFloat(objct.QSYuanGong);
            jsonCS.DSms = tableToolbar.getFloat(objct.DSMenShi);
            jsonCS.DShy = tableToolbar.getFloat(objct.DSHuiYuan);
            jsonCS.DSgb = tableToolbar.getFloat(objct.DSGuiBing);
            jsonCS.DSmfx = tableToolbar.getFloat(objct.DSFreeFenXiaoShang);
            jsonCS.DSfx = tableToolbar.getFloat(objct.DSFenXiaoShang);
            jsonCS.DSyg = tableToolbar.getFloat(objct.DSYuanGong);


            OrderPage.Show(gongliname);
        },
        Show: function(gongliname) {
            var JinE = 0;
            JinE = OrderPage.InputJinE(0, gongliname);
            jsonZ.Zjc = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonJE.Djc);
            JinE = OrderPage.InputJinE(1, gongliname);
            jsonZ.Zhy = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonTJ.Dhy);
            JinE = OrderPage.InputJinE(2, gongliname);
            jsonZ.Zgb = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonTJ.Dgb);
            JinE = OrderPage.InputJinE(3, gongliname);
            jsonZ.Zmfx = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonTJ.Dmfx);
            JinE = OrderPage.InputJinE(4, gongliname);
            jsonZ.Zfx = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonTJ.Dfx);
            JinE = OrderPage.InputJinE(5, gongliname);
            jsonZ.Zyg = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonTJ.Dyg);
            JinE = OrderPage.InputJinE(6, gongliname);
            jsonZ.Zcb = tableToolbar.getFloat(JinE) + tableToolbar.getFloat(jsonTJ.Dcb);
        },
        ZongJia: function() {
            //原增加价格
            var zongmoney = $("#ZongMoney").html();
            var zongmoneycb = $("#ZongMoneyCB").val();

            var YHuiYuanJia = tableToolbar.getFloat(zongmoneycb) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney) - tableToolbar.getFloat(zongmoneycb)) * FeetSeting.Mhy / 100);
            var YGuiBingJia = tableToolbar.getFloat(zongmoneycb) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney) - tableToolbar.getFloat(zongmoneycb)) * FeetSeting.Mgb / 100);
            var YDaiLiJia = tableToolbar.getFloat(zongmoneycb) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney) - tableToolbar.getFloat(zongmoneycb)) * FeetSeting.Mfx / 100);
            var YYuanGongJia = tableToolbar.getFloat(zongmoneycb) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney) - tableToolbar.getFloat(zongmoneycb)) * FeetSeting.Myg / 100);
            //原增加价格结束 
            //            var CheFeicount = $("span[data-id=Money]").length;
            //            var ZongJiaGe = 0;
            //            var ZongJiaGeCB = 0;
            //            for (var i = 0; i < CheFeicount; i++) {
            //                ZongJiaGe = tableToolbar.getFloat(ZongJiaGe) + tableToolbar.getFloat($("span[data-id=Money]").eq(i).html());
            //                ZongJiaGeCB = tableToolbar.getFloat(ZongJiaGeCB) + tableToolbar.getFloat($("input[data-cb=MoneyCB]").eq(i).val());
            //            }

            var goucount = $("a[data-money=zong]").length;
            var ZongJiaGe = 0;
            var ZongJiaGeCB = 0;
            for (var i = 0; i < goucount; i++) {
                if ($("a[data-money=zong]").eq(i).attr("class") == "a_fxk_on") {
                    var DivId =$("a[data-money=zong]").eq(i).attr("data-div");
                    ZongJiaGe = tableToolbar.getFloat(ZongJiaGe) + tableToolbar.getFloat($("#"+DivId).find("span[data-id=Money]").html());
                    ZongJiaGeCB = tableToolbar.getFloat(ZongJiaGeCB) + tableToolbar.getFloat($("#"+DivId).find("input[data-cb=MoneyCB]").val());
                }
            }

            $("#ZongMoney").html(tableToolbar.getFloat(ZongJiaGe));
            $("input[name=ZongMoney]").val(tableToolbar.getFloat(ZongJiaGe));
            $("#ZongMoneyCB").val(tableToolbar.getFloat(ZongJiaGeCB));
            //现增加价格
            var MenShiJia = ZongJiaGe;
            var ChengBenJia = ZongJiaGeCB;
            var HuiYuanJia = tableToolbar.getFloat(ChengBenJia) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia) - tableToolbar.getFloat(ChengBenJia)) * FeetSeting.Mhy / 100);
            var GuiBingJia = tableToolbar.getFloat(ChengBenJia) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia) - tableToolbar.getFloat(ChengBenJia)) * FeetSeting.Mgb / 100);
            var DaiLiJia = tableToolbar.getFloat(ChengBenJia) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia) - tableToolbar.getFloat(ChengBenJia)) * FeetSeting.Mfx / 100);
            var YuanGongJia = tableToolbar.getFloat(ChengBenJia) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia) - tableToolbar.getFloat(ChengBenJia)) * FeetSeting.Myg / 100);
            //现增加价格结束

            var ChengRenNum = $("#RenShu").val();
            var ErTongNum = $("#ETRenShu").val();
            var ChengRenJia = 0;
            var ErTongJia = 0;
            //门市
            //            var zhifucount = $("input[data-name=MenShiMoney]").length;
            //            for (var i = 0; i < zhifucount; i++) {
            //                var zhifujiage = $("input[data-name=MenShiMoney]").eq(i).val();
            //                $("input[data-name=MenShiMoney]").eq(i).val(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia) - tableToolbar.getFloat(zongmoney) + tableToolbar.getFloat(zhifujiage)));
            //                }
            //                
            //               ChengRenJia = $("input[data-name=MenShiMoney]").eq(0).val();
            //               ErTongJia = $("input[data-name=MenShiMoney]").eq(1).val();
            //               $("input[data-name=ZongMenShiMoney]").val(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia)*tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia)*tableToolbar.getInt(ErTongNum)));

            if (tableToolbar.getInt(usercate) >= 1) {
                //会员
                var zhifucount = $("span[data-name=HuiYuanMoney]").length;
                for (var i = 0; i < zhifucount; i++) {
                    var zhifujiage = $("span[data-name=HuiYuanMoney]").eq(i).html();
                    $("span[data-name=HuiYuanMoney]").eq(i).html(tableToolbar.getFloat(tableToolbar.getFloat(HuiYuanJia) - tableToolbar.getFloat(YHuiYuanJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("span[data-name=HuiYuanMoney]").eq(0).html();
                ErTongJia = $("span[data-name=HuiYuanMoney]").eq(1).html();
                $("#UChengRenJia").val(ChengRenJia);
                $("#UErTongJia").val(ErTongJia);
                $("span[data-name=ZongHuiYuanMoney]").html(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia) * tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia) * tableToolbar.getInt(ErTongNum)));
            }
            if (tableToolbar.getInt(usercate) >= 2) {
                //贵宾
                var zhifucount = $("span[data-name=GuiBingMoney]").length;
                for (var i = 0; i < zhifucount; i++) {
                    var zhifujiage = $("span[data-name=GuiBingMoney]").eq(i).html();
                    $("span[data-name=GuiBingMoney]").eq(i).html(tableToolbar.getFloat(tableToolbar.getFloat(GuiBingJia) - tableToolbar.getFloat(YGuiBingJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("span[data-name=GuiBingMoney]").eq(0).html();
                ErTongJia = $("span[data-name=GuiBingMoney]").eq(1).html();
                $("#UChengRenJia").val(ChengRenJia);
                $("#UErTongJia").val(ErTongJia);
                $("span[data-name=ZongGuiBingMoney]").html(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia) * tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia) * tableToolbar.getInt(ErTongNum)));
            }

            if (tableToolbar.getInt(usercate) >= 4) {
                //代理
                var zhifucount = $("span[data-name=DaiLiMoney]").length;
                for (var i = 0; i < zhifucount; i++) {
                    var zhifujiage = $("span[data-name=DaiLiMoney]").eq(i).html();
                    $("span[data-name=DaiLiMoney]").eq(i).html(tableToolbar.getFloat(tableToolbar.getFloat(DaiLiJia) - tableToolbar.getFloat(YDaiLiJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("span[data-name=DaiLiMoney]").eq(0).html();
                ErTongJia = $("span[data-name=DaiLiMoney]").eq(1).html();
                $("#UChengRenJia").val(ChengRenJia);
                $("#UErTongJia").val(ErTongJia);
                $("span[data-name=ZongDaiLiMoney]").html(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia) * tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia) * tableToolbar.getInt(ErTongNum)));
            }

            if (tableToolbar.getInt(usercate) >= 5) {
                //员工
                var zhifucount = $("span[data-name=YuanGongMoney]").length;
                for (var i = 0; i < zhifucount; i++) {
                    var zhifujiage = $("span[data-name=YuanGongMoney]").eq(i).html();
                    $("span[data-name=YuanGongMoney]").eq(i).html(tableToolbar.getFloat(tableToolbar.getFloat(YuanGongJia) - tableToolbar.getFloat(YYuanGongJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("span[data-name=YuanGongMoney]").eq(0).html();
                ErTongJia = $("span[data-name=YuanGongMoney]").eq(1).html();
                $("#UChengRenJia").val(ChengRenJia);
                $("#UErTongJia").val(ErTongJia);
                $("span[data-name=ZongYuanGongMoney]").html(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia) * tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia) * tableToolbar.getInt(ErTongNum)));
            }


            var crms = $("#<%= ChengRenMS.ClientID%>").val(); //成人门市
            var etms = $("#<%= ErTongMS.ClientID%>").val(); //儿童门市
            var crjs = $("#<%= ChengRenJieSuan.ClientID%>").val(); //成人结算
            var etjs = $("#<%= ErTongJieSuan.ClientID%>").val(); //儿童结算
            var addjia = $("#ZongMoney").html(); //增加门市价
            var addcb = $("#ZongMoneyCB").val(); //增加成本价


             var huiyuancr = tableToolbar.getFloat(crjs) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(crms) - tableToolbar.getFloat(crjs)) * FeetSeting.Mhy / 100);
            var huiayuanet = tableToolbar.getFloat(etjs) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(etms) - tableToolbar.getFloat(etjs)) * FeetSeting.Mhy / 100);
            var guibingcr = tableToolbar.getFloat(crjs) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(crms) - tableToolbar.getFloat(crjs)) * FeetSeting.Mgb / 100);
            var guibinget = tableToolbar.getFloat(etjs) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(etms) - tableToolbar.getFloat(etjs)) * FeetSeting.Mgb / 100);
            var dailicr = tableToolbar.getFloat(crjs) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(crms) - tableToolbar.getFloat(crjs)) * FeetSeting.Mfx / 100);
            var dailiet = tableToolbar.getFloat(etjs) + tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(etms) - tableToolbar.getFloat(etjs)) * FeetSeting.Mfx / 100);

            var huiyuancr = tableToolbar.getFloat(huiyuancr) + tableToolbar.getFloat(HuiYuanJia);
            var huiyuanet = tableToolbar.getFloat(huiayuanet) + tableToolbar.getFloat(HuiYuanJia);
            var guibingcr = tableToolbar.getFloat(guibingcr) + tableToolbar.getFloat(GuiBingJia);
            var guibinget = tableToolbar.getFloat(guibinget) + tableToolbar.getFloat(GuiBingJia);
            var dailicr = tableToolbar.getFloat(dailicr) + tableToolbar.getFloat(DaiLiJia);
            var dailiet = tableToolbar.getFloat(dailiet) + tableToolbar.getFloat(DaiLiJia);
            var hyzj = tableToolbar.getFloat(tableToolbar.getFloat(huiyuancr) * tableToolbar.getFloat(ChengRenNum) + tableToolbar.getFloat(huiyuanet) * tableToolbar.getFloat(ErTongNum));
            var guibingzj = tableToolbar.getFloat(tableToolbar.getFloat(guibingcr) * tableToolbar.getFloat(ChengRenNum) + tableToolbar.getFloat(guibinget) * tableToolbar.getFloat(ErTongNum));
            var dailizj = tableToolbar.getFloat(tableToolbar.getFloat(dailicr) * tableToolbar.getFloat(ChengRenNum) + tableToolbar.getFloat(dailiet) * tableToolbar.getFloat(ErTongNum));











            var guibinname ="申请";
            var dailiname ="申请";
            var dailiurl="<a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a>";
            var guibinurl ="<a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a>";
//            var dailiurl="<a href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+(hyzj-dailizj).toFixed(2)+"元</b>";
//            
//            var guibinurl ="<a href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+(hyzj-guibingzj).toFixed(2)+"元</b>";
            if(usercate ==2){
            //guibinname ="贵宾价格总金额";dailiname ="申请代理身份";
            guibinurl ="";
            
            }
            if(usercate ==3){
            //guibinname ="贵宾价格总金额";dailiname ="申请代理身份";
            guibinurl ="";
            
            }
            if(usercate ==4){
            //dailiname ="代理价格总金额";guibinname ="贵宾价格总金额";
            guibinurl=""; dailiurl="";
            }
            if(usercate ==5)
            {
            //dailiname ="代理价格总金额";guibinname ="贵宾价格总金额";
            guibinurl=""; dailiurl="";
            }
//            
            html2 = "<ul><li><span class=\"font_yellow\">会员：</span>成人"+ huiyuancr +"元/人 x "+ChengRenNum+"人+ 儿童"+ huiyuanet +"元/人 x "+ErTongNum+"人 = <span class=\"font_yellow\">"+hyzj+"</span>元</li>"
                    +"<li>"+guibinurl+"<span class=\"font_yellow\">贵宾：</span>成人"+guibingcr+"元/人 x "+ChengRenNum+"人+ 儿童"+guibinget+"元/人 x "+ErTongNum+"人 = <span class=\"font_yellow\">"+ guibingzj +"</span>元  立省<span class=\"font_yellow\">"+(hyzj-guibingzj).toFixed(2)+"元</span></li>"
                    +"<li>"+dailiurl+"<span class=\"font_yellow\">代理：</span>成人"+dailicr+"元/人 x "+ChengRenNum+"人+ 儿童"+dailiet+"元/人 x "+ErTongNum+"人 = <span class=\"font_yellow\">"+ dailizj +"</span>元  立省<span class=\"font_yellow\">"+(hyzj-dailizj).toFixed(2)+"元</span></li> </ul>";
                    
            
            $("#carpricelist").html(html2);  
                
                


        }
    }
</script>

</html>
