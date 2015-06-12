<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="ZiZhuTuan.aspx.cs" Inherits="EyouSoft.Web.ZiZhuTuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="JS/_jquery-1.4.4.js" type="text/javascript"></script>

    <script src="JS/ValiDatorForm.js" type="text/javascript"></script>
<style>
.car_price,.car_price li{ height:124px;}
.car_price .tixing{ height:96px;text-align:left;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <div class="mainbox">
        <div class="baojiaoT" style="position: relative;">
            单独组团报价<a href="javascript:void(0);" id="chakan" class="btn02_blue" style="position: absolute;
                right: 10px; top: 5px;">查看行程</a>
        </div>
        <div class="baojia_table mt10">
            <table width="100%" border="0">
                <tr class="bg_gray">
                    <th align="right">
                        单独组团说明：
                    </th>
                    <td colspan="3" align="left">
                        客户单独组团，独立享受旅游相关服务，不必跟不相关的人拼在一起，避免尴尬,尊享自在！以下单独组团报价是在不减少行程内容的情况下，根据成团人数和客户需求，在拼团价格基础上进行合理调整之后的总价格。
                    </td>
                </tr>
                <tr class="bg_gray">
                    <th width="160" align="right">
                        线路名称：
                    </th>
                    <td align="left" width="500px">
                        <asp:Label ID="lblXLMC" runat="server" Text=""></asp:Label>
                    </td>
                    <th align="right" width="100px">
                        出发城市：
                    </th>
                    <td align="left">
                        <asp:Label ID="cfd" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <strong>游玩日期</strong>：
                    </th>
                    <td align="left">
                        <select id="txtFaBan" name="txtFaBan" style="width: 450px">
                            <asp:Literal ID="ltrFaBanOptions" runat="server"><option value="">暂无发班信息</option></asp:Literal>
                        </select>
                    </td>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                        <th align="right">
                            <strong>航班选择</strong>：
                        </th>
                        <td align="left">
                            <select id="hangban" name="hangban" style="width: 247px;">
                                <asp:Literal ID="litHangBan" runat="server"><option value="">暂无航班信息</option></asp:Literal>
                            </select>
                        </td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="true">
                        <th align="right">
                            &nbsp;
                        </th>
                        <td align="left">
                            &nbsp;
                        </td>
                    </asp:PlaceHolder>
                </tr>
                <tr>
                    <th align="right">
                        成团人数：
                    </th>
                    <td colspan="3" align="left">
                        成人 <span class="dindan_num" style="margin-left: 0;"><a class="js_min" href="javascript:;">
                            -</a><input id="RenShu" name="RenShu" readonly="readonly" type="text" value="2"><a class="js_max" href="javascript:;">+</a></span>
                        人 <em style="padding-left: 20px;"></em><em class="ertongnumjia">儿童 <span class="dindan_num" style="margin-left: 0;"><a
                            class="etjs_min" href="javascript:;"> -</a><input id="ETRenShu" name="ETRenShu" readonly="readonly" type="text"
                                value="0"><a class="etjs_max" href="javascript:;">+</a></span> 人(儿童为2-12周岁)</em>  <em style="padding-left: 20px;"></em>旅游天数 <asp:Literal ID="lvYouTianShu" runat="server"></asp:Literal> 天
                        <input id="BiaoZhunNum" runat="server" type="hidden" />
                    </td>
                </tr>
                <tr class="bg_yellow">
                    <th align="right">
                        <input type="checkbox" name="checkbox5" id="checkbox5" class="xuanze" />
                        一、增加人均车费：
                    </th>
                    <td colspan="3" align="left" style="color:#000; font-weight:400;">
                        本线路拼团价是按最少<asp:Literal ID="ZuiDiRenShu" runat="server"></asp:Literal>人标准核计的费用，单独组团若不足<asp:Literal
                            ID="ZuiDiRenShu1" runat="server"></asp:Literal>人，请补足目的地人均车费差价。包括汽车乘用、司机食宿、燃油损耗和路桥停车费等。安排的汽车保证每人一正座。
                    </td>
                </tr>
                <tr style="display: none;" id="check_open5">
                    <th colspan="4" align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder">
                            <tr>
                                <td colspan="2" align="left" style="padding-left: 270px;">
                                    <input type="radio" name="radio5" checked="checked" id="radio5" value="radio5" />
                                    非自由行线路（默认勾选）<em style="padding-left: 25px;"></em>
                                    <input type="radio" name="radio5" id="radio6" value="radio5" />
                                    纯自由行线路
                                </td>
                            </tr>
                            <tr class="font14 fontblue">
                                <th width="38%" align="right">
                                    人均汽车费共增加 ：
                                </th>
                                <th align="left">
                                    <input id="CarMoney" name="CarMoney" data-id="Money" readonly="readonly" type="text"
                                        class="bj_input formsize80 fontred16" runat="server" value="0" />
                                    <input id="CarFei" name="CarFei" type="hidden" runat="server" />
                                     <input id="CarFeiCB" name="CarFeiCB" type="hidden" runat="server" />
                                     <input id="CarMoneyCB" name="CarMoneyCB" data-cb="MoneyCB" type="hidden" runat="server" value="0" />
                                    元/人
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr class="bg_yellow">
                    <th align="right">
                        <input type="checkbox" name="checkbox4" id="checkbox4" class="xuanze" />
                        二、需要增加餐标：
                    </th>
                    <td colspan="3" align="left" style="color:#000; font-weight:400;">
                        增加用餐标准是指菜品结构搭配与菜量的合理优化，如有需要，可提供菜单。
                    </td>
                </tr>
                <tr style="display: none;" id="check_open4">
                    <td colspan="4" align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder">
                            <tr>
                                <td width="38%" align="right">
                                    增加早餐餐标：
                                </td>
                                <td width="12%" align="left">
                                    <select id="ZaoCanMoney" name="ZaoCanMoney" style="width: 72px">
                                        <%=ZaoCanList%>
                                    </select>
                                    <%--<input id="ZaoCanMoney" name="ZaoCanMoney" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                        runat="server" />--%>
                                    <strong>元/人餐 </strong>
                                </td>
                                <td width="2%" align="center">
                                    <strong>*</strong>
                                </td>
                                <td width="6%" align="center">
                                    <strong>增加餐数</strong>
                                </td>
                                <td align="left">
                                    <span class="dindan_num2">
                                        <a class="jsmin" href="javascript:;">-</a><input id="ZaoCanNum" name="ZaoCanNum" type="text" value="0" /><a class="jsmax" href="javascript:;">+</a></span>
                                        <strong>餐 =
                                        <input id="ZaoCanZong" name="ZaoCanZong" readonly="readonly" type="text" class="bj_input formsize60 fontred16" value="0" /><input id="ZaoCanZongCB" name="ZaoCanZongCB" type="hidden" value="0" />
                                        元/人 </strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    增加午餐餐标：
                                </td>
                                <td align="left">
                                    <select id="WuCanMoney" name="WuCanMoney" style="width: 72px">
                                        <%=WuCanList%>
                                    </select>
                                    <strong>元/人餐 </strong>
                                </td>
                                <td align="center">
                                    <strong>*</strong>
                                </td>
                                <td align="center">
                                    <strong>增加餐数</strong>
                                </td>
                                <td align="left">
                                    <span class="dindan_num2">
                                        <a class="jsmin" href="javascript:;">-</a><input id="WuCanNum" name="WuCanNum" type="text" value="0" /><a class="jsmax" href="javascript:;">+</a></span>
                                        <strong>餐 =
                                        <input id="WuCanZong" name="WuCanZong" readonly="readonly" type="text" class="bj_input formsize60 fontred16" value="0" /><input id="WuCanZongCB" name="WuCanZongCB" type="hidden" value="0" />
                                        元/人 </strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    增加晚餐餐标：
                                </td>
                                <td align="left">
                                    <select id="WanCanMoney" name="WanCanMoney" style="width: 72px">
                                        <%=WanCanList%>
                                    </select>
                                    <%--<input id="WanCanMoney" name="WanCanMoney" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                        runat="server" />--%>
                                    <strong>元/人餐 </strong>
                                </td>
                                <td align="center">
                                    <strong>*</strong>
                                </td>
                                <td align="center">
                                    <strong>增加餐数</strong>
                                </td>
                                <td align="left">
                                   <span class="dindan_num2">
                                        <a class="jsmin" href="javascript:;">-</a><input id="WanCanNum" name="WanCanNum" type="text" value="0" /><a class="jsmax" href="javascript:;">+</a></span>
                                        <strong>餐 =
                                        <input id="WanCanZong" name="WanCanZong" readonly="readonly" type="text" class="bj_input formsize60 fontred16" value="0" /><input id="WanCanZongCB" name="WanCanZongCB" type="hidden" value="0" />
                                        元/人 </strong>
                                </td>
                            </tr>
                            <tr class="font14 fontblue">
                                <th align="right">
                                    人均餐标费共增加 ：
                                </th>
                                <th colspan="4" align="left">
                                    <input id="CanWuFei" name="CanWuFei" data-id="Money" readonly="readonly" type="text"
                                        class="bj_input formsize80 fontred16" value="0" /><input id="CanWuFeiCB" name="CanWuFeiCB" type="hidden" value="0" data-cb="MoneyCB" />
                                    元/人
                                </th>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="bg_yellow">
                    <th align="right">
                        <input type="checkbox" name="checkbox3" id="checkbox3" class="xuanze" />
                        三、需要增加保险：
                    </th>
                    <td colspan="3" align="left" style="color:#000; font-weight:400;">
                        建议购买以下意外保险，安心出游！
                    </td>
                </tr>
                <tr style="display: none;" id="check_open3">
                    <td colspan="4" align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder">
                            <tr>
                                <td width="38%" align="right">
                                    <input id="Checkbox6" name="baoxian" type="checkbox" />
                                    <%-- <input type="radio" name="radio" id="radio2" value="radio" />--%>
                                    <strong>
                                    <%if (routeType == 2)
                                      { %>
                                    境外人身意外保险<%}
                                      else
                                      { %>旅游人身意外保险： <%} %></strong>
                                </td>
                                <td width="12%" align="left">
                                    <select id="RenShenBX" name="RenShenBX" style="width: 72px">
                                        <%= RSBXList%>
                                    </select>
                                    <%--<input id="RenShenBX" name="RenShenBX" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                        runat="server" />--%>
                                    <strong>元/人/天</strong>
                                </td>
                                <td width="2%" align="center">
                                    <strong>* </strong>
                                </td>
                                <td width="6%" align="center">
                                    <strong>旅游天数</strong>
                                </td>
                                <td align="left">
                                    <strong>
                                        <input id="RSTianShu" name="RSTianShu" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                            runat="server" />
                                        天 =
                                        <input id="RSJiaGe" name="RSJiaGe" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                            runat="server" /><input id="RSJiaGeCB" name="RSJiaGeCB" type="hidden" value="0" />
                                        元/人 </strong>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="left" style="padding-left: 270px;">
                                    （因自身原因或不可控的其他原因发生意外，导致人身受到伤害所投保的保险，保额最多10万元/人）
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <input id="Checkbox7" name="baoxian" type="checkbox" />
                                    <%--<input type="radio" name="radio" id="radio3" value="radio" />--%>
                                    <strong>综合交通意外保险：</strong>
                                </td>
                                <td align="left">
                                    <select id="JiaoTongBX" name="JiaoTongBX" style="width: 72px">
                                        <%= JTBXList%>
                                    </select>
                                    <%--<input id="JiaoTongBX" name="JiaoTongBX" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                        runat="server" />--%>
                                    <strong>元/人/天</strong>
                                </td>
                                <td align="center">
                                    <strong>* </strong>
                                </td>
                                <td align="center">
                                    <strong>旅游天数</strong>
                                </td>
                                <td align="left">
                                    <strong>
                                        <input id="JTTianShu" name="JTTianShu" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                            runat="server" />
                                        天 =
                                        <input id="JTJiaGe" name="JTJiaGe" readonly="readonly" type="text" class="bj_input formsize60 fontred16"
                                            runat="server" /><input id="JTJiaGeCB" name="JTJiaGeCB" type="hidden" value="0" />
                                        元/人 </strong>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="left" style="padding-left: 270px;">
                                    （含飞机、火车、汽车、轮船等四大交通工具发生意外而投保的保险，保额最多40万元/人）
                                </td>
                            </tr>
                            <tr class="font14 fontblue">
                                <th align="right">
                                    人均保险费共增加 ：
                                </th>
                                <th colspan="4" align="left">
                                    <input id="RJBXF" name="RJBXF" data-id="Money" readonly="readonly" type="text" class="bj_input formsize80 fontred16"
                                        value="0" /><input id="RJBXFCB" name="RJBXFCB" data-cb="MoneyCB" type="hidden" value="0" />
                                    元/人
                                </th>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="bg_yellow">
                    <th align="right">
                        <input type="checkbox" name="checkbox2" id="checkbox2" class="xuanze" />
                        <label for="checkbox">
                        </label>
                        四、需要全陪导游：
                    </th>
                    <td colspan="3" align="left" style="color:#000; font-weight:400;">
                    本线路拼团价是按最少<asp:Literal ID="ZuiDiNum" runat="server"></asp:Literal>人标准核计的费用，单独组团若不足<asp:Literal
                            ID="ZuiDiRS" runat="server"></asp:Literal>人，请补足目的地导游费用差价,
                    <%if (routeType == 2)
                      { %>
                        包括导游大交通、导游工资、导游津贴、食宿费等。保证每车一名目的地导游和一名全陪导游。
                    <%}else{ %>
                        每车保证一名目的地导游。全陪导游可自愿选择，导游服务费包括大交通、导游工资、导游津贴、食宿费等。
                       <%} %>
                    </td>
                </tr>
                <tr style="display: none;" id="check_open2">
                    <td colspan="4" align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder">
                        <tr>
                                <td width="38%" align="right">
                                    <%--<input type="radio" name="radio" id="radio1" value="radio" />--%>
                                    <strong>目的地 导游服务，保</strong>
                                </td>

                                <td width="10%" align="left">
                                    <input id="DiPeiDaoYouNum" style="display:none;" name="DiPeiDaoYouNum" style="text-align:center;padding-left:0; width:70px;" readonly="readonly" type="text" class="bj_input formsize60 fontred16" value="1" />
                                    <strong>证每车 1 名</strong>
                                </td>
                                <td width="10%" align="center">
                                    <strong>平摊至每人增加</strong>
                                </td>
                                <td align="left">
                                    <strong>
                                        <input type="text" id="DiPeiDaoYouFei" name="DiPeiDaoYouFei" readonly="readonly" class="bj_input formsize60 fontred16" value="0" /><input id="DiPeiDaoYouFeiCB" name="DiPeiDaoYouFeiCB" type="hidden" />
                                        元/人</strong>
                                </td>
                                <input id="DiPeiDaoYou" name="DiPeiDaoYou" runat="server" type="hidden" />
                                <input id="DiPeiDaoYouCB" name="DiPeiDaoYouCB" runat="server" type="hidden" />
                            </tr>
                            <tr>
                                <td width="38%" align="right">
                                    <%--<input type="radio" name="radio" id="radio3" value="radio" />--%>
                                    <%if (routeType == 2)
                                  { %>
                                  <strong>全程陪 导游服务，保</strong>
                                  <%}else{ %>
                                    <strong>全程陪 导游服务，需</strong>
                                    <%} %>
                                </td>
                                <td width="10%" align="left">
                                <%if (routeType == 2)
                                  { %>
                                    <input id="DaoYouNum" style=" display:none;" style="text-align:center;padding-left:0; width:70px;" name="DaoYouNum" readonly="readonly" type="text" class="bj_input formsize60 fontred16" value="1" /><strong>证每团 1 名</strong>&nbsp;&nbsp;
                                    <%} else{%>
                                      <span class="dindan_num2">
                                        <a class="jsmin" href="javascript:;">-</a><input id="DaoYouNum" name="DaoYouNum" type="text" value="0" /><a class="jsmax" href="javascript:;">+</a></span><strong>名</strong>&nbsp;&nbsp;
                                    <%} %>
                                </td>
                                <td width="10%" align="center">
                                    <strong>平摊至每人增加</strong>
                                </td>
                                <td align="left">
                                    <strong>
                                        <input type="text" id="QuanPeiDaoYouFei" readonly="readonly" name="QuanPeiDaoYouFei" class="bj_input formsize60 fontred16" value="0" /><input id="QuanPeiDaoYouFeiCB" name="QuanPeiDaoYouFeiCB" type="hidden" />
                                        元/人</strong>
                                </td>
                                <input id="DaoYouMoney" name="DaoYouMoney" runat="server" type="hidden" />
                                <input id="DaoYouMoneyCB" name="DaoYouMoneyCB" runat="server" type="hidden" />
                            </tr>
                            
                            <tr class="font14 fontblue">
                                <th align="right">
                                    人均导游费共增加 ：
                                </th>
                                <th align="left" colspan="3">
                                    <input id="DaoYouFei" name="DaoYouFei" data-id="Money" readonly="readonly" runat="server"
                                        type="text" class="bj_input formsize80 fontred16" value="0" /><input id="DaoYouFeiCB" name="DaoYouFeiCB" data-cb="MoneyCB" type="hidden" />
                                    元/人
                                </th>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="bg_yellow">
                    <th align="right">
                        <input type="checkbox" name="checkbox1" id="checkbox1" class="xuanze" />
                        五、需要安排接送：
                    </th>
                    <td colspan="3" align="left" style="color:#000; font-weight:400;">
                        需统一安排汽车接送机场、火车站等，请选择并填写接机送站名称
                    </td>
                </tr>
                <tr align="center" id="check_open1" style="display: none;">
                    <th colspan="4">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder"
                            style="border-bottom: #ddd dashed 1px;" id="Table_ZuChe">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <%--<input type="radio" id="radio4" value="radio" />--%>
                                        <strong>去程 —— 集合出发地点：</strong>
                                    </td>
                                    <td align="left">
                                        <input id="QuQiDian" name="QuQiDian" type="text" style="font-weight:400; width:185px;" data-name="txtPlace" class="bj_input formsize180"
                                            value="浙江省杭州市武林广场" onfocus="javascript:if(this.value=='浙江省杭州市武林广场')this.value='';"
                                            onblur="javascript:if(this.value=='')this.value='浙江省杭州市武林广场';" /><a class="btn001"
                                                href="javascript:void(0);"><span>地图选址</span></a>
                                    </td>
                                    <td colspan="2" align="center">
                                        <strong>送达机场车站：</strong>
                                        <input id="QuZhongDian" name="QuZhongDian" style="font-weight:400; width:185px;"  data-name="txtPlace" type="text" class="bj_input formsize180"
                                            value="请详细正确填写市县区和道路名称" onfocus="javascript:if(this.value=='请详细正确填写市县区和道路名称')this.value='';"
                                            onblur="javascript:if(this.value=='')this.value='请详细正确填写市县区和道路名称';" /><a class="btn001"
                                                href="javascript:void(0);"><span>地图选址</span></a>
                                        <input id="QuGongLi" name="QuGongLi" type="hidden" />
                                    </td>
                                </tr>
                                <tr class="TempZu">
                                    <td width="24%" align="right">
                                        选择车型：
                                    </td>
                                    <td width="30%" align="left">
                                        <%=GetQuCarHtml()%>
                                    </td>
                                    <td width="15%" align="right">
                                        租车数量：
                                        <span class="dindan_num2">
                                        <a class="jsmin" href="javascript:;">-</a><input name="QuZuCheNum" type="text" value="1" /><a class="jsmax" href="javascript:;">+</a></span>
                                        辆
                                    </td>
                                    <td width="31%" align="center">
                                        增加车费：
                                        <input name="QuCheFei" type="text" readonly="readonly" class="bj_input formsize60"
                                            value="0" /><input name="QuCheFeiCB" type="hidden" value="0" />
                                       元/人
                                    </td>
                                </tr>
                            </tbody>
                            <%--<tr>
                                <td align="right">
                                    选择车型：
                                </td>
                                <td align="left">
                                    <%=GetQuCarHtml()%>
                                </td>
                                <td align="right">
                                    租车数量：
                                    <input name="QuZuCheNum" type="text" class="bj_input formsize60" value="1" />
                                    辆
                                </td>
                                <td align="center">
                                    增加车费：
                                    <input name="QuCheFei" type="text" class="bj_input formsize60" value="0" />
                                    元/人
                                </td>
                            </tr>--%>
                            <tfoot>
                                <tr>
                                    <td align="right">
                                        <a href="javascript:void(0);" class="baojia_btn addbtncontract"><span>添加车型</span></a>
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <%--<input type="radio" id="radio4" value="radio" />--%>
                                        回程 —— 机场车站名称<strong>：</strong>
                                    </td>
                                    <td align="left">
                                        <input id="HuiQiDian" name="HuiQiDian" style="font-weight:400; width:185px;"  data-name="txtPlace" type="text" class="bj_input formsize180"
                                            value="请详细正确填写市县区和道路名称" onfocus="javascript:if(this.value=='请详细正确填写市县区和道路名称')this.value='';"
                                            onblur="javascript:if(this.value=='')this.value='请详细正确填写市县区和道路名称';" /><a class="btn001"
                                                href="javascript:void(0);"><span>地图选址</span></a>
                                    </td>
                                    <td colspan="2" align="center">
                                        <strong>接回具体地点：</strong>
                                        <input id="HuiZhongDian" name="HuiZhongDian" style="font-weight:400; width:185px;"  data-name="txtPlace" type="text" class="bj_input formsize180"
                                            value="请详细正确填写市县区和道路名称" onfocus="javascript:if(this.value=='请详细正确填写市县区和道路名称')this.value='';"
                                            onblur="javascript:if(this.value=='')this.value='请详细正确填写市县区和道路名称';" /><a class="btn001"
                                                href="javascript:void(0);"><span>地图选址</span></a><input id="HuiGongLi" name="HuiGongLi"
                                                    type="hidden" />
                                    </td>
                                </tr>
                                <tr class="TempZu">
                                    <td width="24%" align="right">
                                        选择车型：
                                    </td>
                                    <td width="30%" align="left">
                                        <%=GetHuiCarHtml()%>
                                    </td>
                                    <td width="15%" align="right">
                                        租车数量：
                                        <span class="dindan_num2">
                                        <a class="jsmin" href="javascript:;">-</a><input name="HuiZuCheNum" type="text" value="1" /><a class="jsmax" href="javascript:;">+</a></span>
                                        辆
                                    </td>
                                    <td width="31%" align="center">
                                        增加车费：
                                        <input name="HuiCheFei" type="text" readonly="readonly" class="bj_input formsize60"
                                            value="0" /><input name="HuiCheFeiCB" type="hidden" value="0" />
                                        元/人
                                    </td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td align="right">
                                        <a href="javascript:void(0);" class="baojia_btn addbtncontract"><span>添加车型</span></a>
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_noborder">
                            <tr class="font14 fontblue">
                                <th width="38%" align="right">
                                    人均接送费共增加 ：
                                </th>
                                <th align="left">
                                    <input name="ZuCheMoney" id="ZuCheMoney" readonly="readonly" data-id="Money" type="text"
                                        class="bj_input formsize80 fontred16" value="0" /><input id="ZuCheMoneyCB" name="ZuCheMoneyCB" data-cb="MoneyCB" type="hidden" />
                                    元/人
                                </th>
                            </tr>
                            <tr class="font14 fontblue">
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr class="bg_tatol">
                    <th colspan="4" align="center" bgcolor="#FFF5C4" class="font14 fontblue">
                        单独成团累计增加：
                        <input type="text" readonly="readonly" id="ZongMoney" name="ZongMoney" runat="server"
                            class="bj_input formsize80 fontred16" value="0" />
                        <input id="ZongMoneyCB" name="ZongMoneyCB" type="hidden" value="0" />
                        元/人
                    </th>
                </tr>
                <tr class="bg_tatol">
                    <th colspan="4" align="left">
                        <input type="hidden" readonly="readonly" id="XLXianLuId" name="XLXianLuId" runat="server" />
                        <input type="hidden" readonly="readonly" id="XLTourId" name="XLTourId" runat="server" />
                        <input type="hidden" readonly="readonly" id="BaoXianFS" name="BaoXianFS" />
                        综合, 按照
                        <input id="RenShuNum" name="RenShuNum" type="text" readonly="readonly" value="2"
                            class="bj_input formsize30" />
                        人单独成团，
                        <input type="text" id="XianLuYear" name="XianLuYear" runat="server" class="bj_input formsize60" />
                        年
                        <input type="text" id="XianLuMonth" name="XianLuMonth" runat="server" class="bj_input formsize30" />
                        月
                        <input type="text" id="XianLuDay" name="XianLuDay" runat="server" class="bj_input formsize30" />
                        日出发的
                        <input type="text" id="XianLuName" name="XianLuName" runat="server" class="bj_input"
                            style="width: 430px;" />
                        线路的价格为：
                    </th>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <table width="80%" border="0" cellpadding="0" cellspacing="0" class="table_noborder font14 fontblue">
                            <asp:Literal ID="JiaGeDengJiList" runat="server"></asp:Literal>
                        </table>
                        <table width="80%" border="0" cellpadding="0" cellspacing="0" class="table_noborder font14 fontblue">
                        <tr>
                <td>
<div class="car_price margin_T10">
    <em id="carpricelist"></em>
</div>
                </td>
                </tr></table>
                        <div class="yd_btn">
                            <!--成人门市价-->
                            <input type="hidden" readonly="readonly" id="ChengRenMS" name="ChengRenMS" runat="server" />
                            <!--儿童门市价-->
                            <input type="hidden" readonly="readonly" id="ErTongMS" name="ErTongMS" runat="server" />
                            <!--当前会员成人价-->
                            <input type="hidden" readonly="readonly" id="UChengRenJia" name="UChengRenJia" />
                            <!--当前会员儿童价-->
                            <input type="hidden" readonly="readonly" id="UErTongJia" name="UErTongJia" />
                            <!--成人结算价-->
                            <input type="hidden" readonly="readonly" id="ChengRenJieSuan" name="ChengRenJieSuan" runat="server" />
                            <!--儿童结算价-->
                            <input type="hidden" readonly="readonly" id="ErTongJieSuan" name="ErTongJieSuan" runat="server" />
                            <input id="JianCe" type="hidden" value="0" />
                            <em style="padding-right:35px;" id="denglu"><a id="gotologin" class="btn02_yellow"><span>立即登录</span></a></em><em style="padding-right:35px"><a id="link01" class="yudin_btn02" href="javascript:void(0);"><span id="sp_Islogin">非会员直接预订 >></span></a></em><a href="/Lg.aspx" class="btn02_blue" id="zhuce"><span>立即注册</span></a>  
                        </div>
                        <%--<div class="user-tip mt10" style="border-top: #ddd dashed 1px;">
                            已是会员/贵宾/分销商 请<a class="btn001" href="login.html"><span>登 录</span></a></div>
                        <div class="yd_btn mt10" style="padding-bottom: 30px;">
                            <a id="link01" class="yudin_btn02" href="#"><span>非会员直接预订 &gt;&gt;</span></a></div>--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="mt10" style="text-align: center;">
            <img src="images/baoji_step.gif" /></div>
    </div>
    </form>
    <div style="width: 300px; display: none; height: 218px; border: #ccc solid 1px; padding: 1px;
        float: left;" id="map_canvas">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">

    <script src="js/jquery-1.4.2.min.js"></script>

    <script src="JS/bt.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ovOm8pf0QIyWC4n4jx8I5vPG"></script>

    <script type="text/javascript">
        var PageOrder = {
            CheckForm: function() {
                return ValiDatorForm.validator($("#link01").closest("form").get(0), "alert")
            },
            Init: function() {
                var _m = iLogin.getM();
                if (!_m.isLogin) {
                    $("#link01").click(function() {
                        var aid = $(this).closest("td").find("[data-name=txtPlace]").attr("id");
                        Boxy.iframeDialog({
                            iframeUrl: "/LoginOrReg.aspx",
                            title: "注册与登录",
                            modal: true,
                            width: "630px",
                            height: "350px",
                            draggable: false,
                            afterHide: function() { PageOrder.subit() }
                        });

                        return false;
                    });
                    $("#gotologin").click(function() {
                        window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href);
                    });
                }
                else {
                    $("#denglu").css('display', 'none');
                    $("#zhuce").css('display', 'none');
                    $("#sp_Islogin").html("直接预订");
                    $("#link01").click(function() {
                        if (PageOrder.CheckForm()) { PageOrder.subit(); }
                    });
                }
            },
            subit: function() {
            if ($("#QuGongLi").val() == "0" && $("#QuZhongDian").val() != "请详细正确填写市县区和道路名称" && $("#QuZhongDian").val() != "") {
                    alert("去程起点和终点无法计算出距离，请重新选择起点和终点！");
                    return false;
                }
                if ($("#HuiGongLi").val() == "0" && $("#HuiZhongDian").val() != "请详细正确填写市县区和道路名称" && $("#HuiZhongDian").val() != "") {
                    alert("回程起点和终点无法计算出距离，请重新选择起点和终点！");
                    return false;
                }
                var _m = iLogin.getM();
                if (!_m.isLogin) { return false; };
                if (PageOrder.CheckForm() == false) { return false; }
                $("#sp_Islogin").html("正在提交");
                $("#link01").unbind("click");
                var url = "/ZiZhuTuan.aspx?dotype=save";
                $.ajax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#link01").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            location.href = "/Member/ZuTuanOrderList.aspx";
                        }
                        else {
                            $("#sp_Islogin").html("直接预订");
                            alert(ret.msg);
                            $("#link01").bind("click");
                        }
                    },
                    error: function() {
                        $("#sp_Islogin").html("直接预订");
                        alert("报价失败");
                        $("#link01").bind("click");
                    }
                });
            },
            Bind: function() {
                PageOrder.Init();
            },
            boxClick: function() { if (PageOrder.CheckForm()) { PageOrder.subit(); } }
        };


        function test(obj, aid) {
            $("#" + aid).val(obj);
            $("#" + aid).blur();
        }

        $(function() {
            PageOrder.Bind();
            $(".baojia_btn").click(function() {
                var html = $(this).closest("table").find(".TempZu").eq(0).clone(true);
                $(this).closest("table").children("tbody").append(html);
            });
            $(".btn001").click(function() {
                var aid = $(this).closest("td").find("[data-name=txtPlace]").attr("id");
                Boxy.iframeDialog({
                    iframeUrl: "/GetAddress.aspx?callback=test&aid=" + aid,
                    title: "选择地址",
                    modal: true,
                    width: "930px",
                    height: "500px",
                    draggable: false
                });

                return false;
            });
        })
        function login(data) {
            $("#sp_Islogin").html("直接预订");
            $("#link01").click(function() {
                if (PageOrder.CheckForm()) { PageOrder.subit(); }

            });
        }
    </script>

    <script type="text/javascript">
        var pageData = {
            CreatBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.url,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            initClick: function() {

                $(".jsmin").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    var aid = $(this).parent().find("input").attr("id");
                    if (tableToolbar.getInt(getNum.val()) > 0) {//成人数量不能低于2人
                        getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                    } else {
                        getNum.val(0);
                    }
                    if (aid == "") {
                        var aname = $(this).parent().find("input").attr("name");
                        $("input[name=" + aname + "]").blur();
                    }
                    else {
                        $("#" + aid).blur();
                    }
                    OrderPage.ZongJia();
                })
                $(".jsmax").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    var aid = $(this).parent().find("input").attr("id");
                    getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                    
                    if (aid == "") {
                        var aname = $(this).parent().find("input").attr("name");
                        $("input[name=" + aname + "]").blur();
                    }
                    else {
                        $("#" + aid).blur();
                    }

                    OrderPage.ZongJia();
                })





                //成人数量减小
                $(".js_min").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    if (tableToolbar.getInt(getNum.val()) > 2) {//成人数量不能低于2人
                        getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                    } else {
                        getNum.val(2);
                    }
                    $("#RenShuNum").val(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#ETRenShu").val())); //总人数
                    //判断总人数是否低于标准人数
                    if (tableToolbar.getInt($("#RenShuNum").val()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                        $("#<%= CarMoney.ClientID%>").val("0");
                        $("#<%= CarMoneyCB.ClientID%>").val("0");
                    }
                    else {
                        var jiage = $("#<%= CarFei.ClientID%>").val();
                        var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                        var tianshu = $("#<%= JTTianShu.ClientID%>").val();
                        $("#<%= CarMoney.ClientID%>").val(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                        $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                    }

                    $("#DaoYouNum").blur();
                    $("#DiPeiDaoYouNum").blur();
                    OrderPage.ZongJia();
                })
                $(".js_max").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                    $("#RenShuNum").val(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#ETRenShu").val()));
                    if (tableToolbar.getInt($("#RenShuNum").val()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                        $("#<%= CarMoney.ClientID%>").val("0");
                        $("#<%= CarMoneyCB.ClientID%>").val("0");
                    }
                    else {
                        var jiage = $("#<%= CarFei.ClientID%>").val();
                        var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                        var tianshu = $("#<%= JTTianShu.ClientID%>").val();
                        $("#<%= CarMoney.ClientID%>").val(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                        $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                    }
                    $("#DaoYouNum").blur();
                    $("#DiPeiDaoYouNum").blur();
                    OrderPage.ZongJia();
                })
                $(".etjs_min").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    if (tableToolbar.getInt(getNum.val()) > 0) {
                        getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                    } else {
                        getNum.val(0);
                    }

                    $("#RenShuNum").val(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#RenShu").val()));
                    if (tableToolbar.getInt($("#RenShuNum").val()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                        $("#<%= CarMoney.ClientID%>").val("0");
                        $("#<%= CarMoneyCB.ClientID%>").val("0");
                    }
                    else {
                        var jiage = $("#<%= CarFei.ClientID%>").val();
                        var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                        var tianshu = $("#<%= JTTianShu.ClientID%>").val();
                        $("#<%= CarMoney.ClientID%>").val(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                        $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                    }

                    $("#DaoYouNum").blur();
                    $("#DiPeiDaoYouNum").blur();
                    OrderPage.ZongJia();
                })
                $(".etjs_max").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                    $("#RenShuNum").val(tableToolbar.getInt(getNum.val()) + tableToolbar.getInt($("#RenShu").val()));
                    if (tableToolbar.getInt($("#RenShuNum").val()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                        $("#<%= CarMoney.ClientID%>").val("0");
                        $("#<%= CarMoneyCB.ClientID%>").val("0");
                    }
                    else {
                        var jiage = $("#<%= CarFei.ClientID%>").val();
                        var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                        var tianshu = $("#<%= JTTianShu.ClientID%>").val();
                        $("#<%= CarMoney.ClientID%>").val(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                        $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                    }
                    $("#DaoYouNum").blur();
                    $("#DiPeiDaoYouNum").blur();
                    OrderPage.ZongJia();
                })
            },
            initChangeHangBan: function() {
                $("#hangban").change(function() {
                    var url = window.location.pathname;
                    var urlParms = tableToolbar.getUrlParms(["hangban"]);
                    urlParms["hangban"] = $(this).val();
                    if ($(this).val() == undefined)
                    { return false; }
                    window.location.href = tableToolbar.createUrl(url, urlParms);
                })
                $("#txtFaBan").change(function() {
                    var url = window.location.pathname;
                    var urlParms = tableToolbar.getUrlParms(["tid"]);
                    urlParms["tid"] = $(this).val();
                    if ($(this).val() == undefined)
                    { return false; }
                    window.location.href = tableToolbar.createUrl(url, urlParms);
                })
            } //更改航班和游玩日期刷新页面



        };
        $(function() {
            pageData.initChangeHangBan();
            pageData.initClick();
            $("#input_cr,#input_et").change(function() { pageData.jiesuan() });
            $("#login_a,#reg_a").click(function() { window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href) });
            $("#chakan").click(function() {
                window.open("/XianLuYuDing.aspx" + location.search);
            });
        })
    </script>

    <script type="text/javascript">
        var usercate = '<%= usertp%>';
        window.onload = function() {
            $("input[type=checkbox]").click(function() {

                var mudicount = $(".xuanze").length;
                for (var i = 1; i <= mudicount; i++) {
                    if ($("#checkbox" + i).attr("checked")) {
                        $("#check_open" + i).css("display", "");
                    } else { $("#check_open" + i).css("display", "none"); }

                }
            });
            var BiaoZhunRS = $("#<%= BiaoZhunNum.ClientID%>").val();
            $("#RenShu").val(BiaoZhunRS);
            $("#RenShuNum").val(BiaoZhunRS);
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
            var zongjia = $("#<%= ZongMoney.ClientID%>").val();
            var zhifucount = $("input[name=ZhiFuMoney]").length;
            for (var i = 0; i < zhifucount; i++) {
                var zhifujiage = $("input[name=ZhiFuMoney]").eq(i).val();
                $("input[name=ZhiFuMoney]").eq(i).val(tableToolbar.getFloat(zhifujiage) + tableToolbar.getFloat(zongjia));
            }
            if (tableToolbar.getFloat($("#<%= ErTongMS.ClientID%>").val()) < 1) {
                $(".ertongnumjia").hide();
            }
        }
        $("#ZaoCanMoney").change(function() {
            $("#ZaoCanNum").blur();
        });
        $("#WuCanMoney").change(function() {
            $("#WuCanNum").blur();
        });
        $("#WanCanMoney").change(function() {
            $("#WanCanNum").blur();
        });
        $("#ZaoCanNum").blur(function() {
            if ($('#ZaoCanNum').val() != "") {
                //var canwufei = tableToolbar.getFloat($('#CanWuFei').val());
                var zaocanfei = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").val());
                var wucanfei = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").val());
                var wancanfei = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").val());
                var zaocanfeicb = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").find("option:selected").attr("data-cb"));
                var wucanfeicb = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").find("option:selected").attr("data-cb"));
                var wancanfeicb = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").find("option:selected").attr("data-cb"));
                $("#ZaoCanZong").val(zaocanfei);
                $("#ZaoCanZongCB").val(zaocanfeicb);
                $('#CanWuFei').val(zaocanfei + wucanfei + wancanfei);
                $('#CanWuFeiCB').val(zaocanfeicb + wucanfeicb + wancanfeicb);
                OrderPage.ZongJia();
            }
        });
        $("#WuCanNum").blur(function() {
            if ($('#WuCanNum').val() != "") {
                var zaocanfei = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").val());
                var wucanfei = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").val());
                var wancanfei = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").val());
                var zaocanfeicb = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").find("option:selected").attr("data-cb"));
                var wucanfeicb = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").find("option:selected").attr("data-cb"));
                var wancanfeicb = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").find("option:selected").attr("data-cb"));
                $("#WuCanZong").val(wucanfei);
                $("#WuCanZongCB").val(wucanfeicb);
                $('#CanWuFei').val(zaocanfei + wucanfei + wancanfei);
                $('#CanWuFeiCB').val(zaocanfeicb + wucanfeicb + wancanfeicb);
                OrderPage.ZongJia();
            }
        });
        $("#WanCanNum").blur(function() {
            if ($('#WanCanNum').val() != "") {
                var zaocanfei = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").val());
                var wucanfei = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").val());
                var wancanfei = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").val());
                var zaocanfeicb = tableToolbar.getFloat($('#ZaoCanNum').val()) * tableToolbar.getFloat($("#ZaoCanMoney").find("option:selected").attr("data-cb"));
                var wucanfeicb = tableToolbar.getFloat($('#WuCanNum').val()) * tableToolbar.getFloat($("#WuCanMoney").find("option:selected").attr("data-cb"));
                var wancanfeicb = tableToolbar.getFloat($('#WanCanNum').val()) * tableToolbar.getFloat($("#WanCanMoney").find("option:selected").attr("data-cb"));
                $("#WanCanZong").val(wancanfei);
                $("#WanCanZongCB").val(wancanfeicb);
                $('#CanWuFei').val(zaocanfei + wucanfei + wancanfei);
                $('#CanWuFeiCB').val(zaocanfeicb + wucanfeicb + wancanfeicb);
                OrderPage.ZongJia();
            }
        });
        $("#RenShenBX").change(function() {
            $("input[name=baoxian]").change();
        });
        $("#JiaoTongBX").change(function() {
            $("input[name=baoxian]").change();
        });
        $("input[name=baoxian]").change(function() {

            $("#<%= RSJiaGe.ClientID%>").val(tableToolbar.getFloat($("#RenShenBX").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val()));
            $("#<%= JTJiaGe.ClientID%>").val(tableToolbar.getFloat($("#JiaoTongBX").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val()));
            $("#RSJiaGeCB").val("0");
            $("#JTJiaGeCB").val("0");
            if ($("#Checkbox7").attr("checked") == true && $("#Checkbox6").attr("checked") == true) {
                $("#RSJiaGeCB").val(tableToolbar.getFloat($("#RenShenBX").find("option:selected").attr("data-cb")) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val()));
                $("#JTJiaGeCB").val(tableToolbar.getFloat($("#JiaoTongBX").find("option:selected").attr("data-cb")) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val()));
                $("#RJBXF").val(tableToolbar.getFloat(tableToolbar.getFloat($("#<%= RSJiaGe.ClientID%>").val()) + tableToolbar.getFloat($("#<%= JTJiaGe.ClientID%>").val())));
                $("#RJBXFCB").val(tableToolbar.getFloat(tableToolbar.getFloat($("#RSJiaGeCB").val()) + tableToolbar.getFloat($("#JTJiaGeCB").val())));
                $("#BaoXianFS").val("人身保险,交通保险");
            }
            else if ($("#Checkbox7").attr("checked")) {
                $("#JTJiaGeCB").val(tableToolbar.getFloat($("#JiaoTongBX").find("option:selected").attr("data-cb")) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val()));
                $("#RJBXF").val(tableToolbar.getFloat($("#<%= JTJiaGe.ClientID%>").val()));
                $("#RJBXFCB").val(tableToolbar.getFloat($("#JTJiaGeCB").val()));
                $("#BaoXianFS").val("交通保险");
            }
            else if ($("#Checkbox6").attr("checked")) {
                $("#RSJiaGeCB").val(tableToolbar.getFloat($("#RenShenBX").find("option:selected").attr("data-cb")) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val()));
                $("#RJBXF").val(tableToolbar.getFloat($("#<%= RSJiaGe.ClientID%>").val()));
                $("#RJBXFCB").val(tableToolbar.getFloat($("#RSJiaGeCB").val()));
                $("#BaoXianFS").val("人身保险");
            }
            else {
                $("#RJBXF").val("0");
                $("#RJBXFCB").val("0");
                $("#BaoXianFS").val("");
            }
            OrderPage.ZongJia();
        });

        $("#radio5").change(function() {
            if ($("#radio5").attr("checked")) {
                $("#RenShuNum").val(tableToolbar.getInt($("#RenShu").val()) + tableToolbar.getInt($("#ETRenShu").val())); //总人数
                //判断总人数是否低于标准人数
                if (tableToolbar.getInt($("#RenShuNum").val()) >= tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val())) {
                    $("#<%= CarMoney.ClientID%>").val("0");
                    $("#<%= CarMoneyCB.ClientID%>").val("0");
                }
                else {
                    var jiage = $("#<%= CarFei.ClientID%>").val();
                    var jiagecb = $("#<%= CarFeiCB.ClientID%>").val();
                    var tianshu = $("#<%= JTTianShu.ClientID%>").val();
                    $("#<%= CarMoney.ClientID%>").val(tableToolbar.getFloat(jiage * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                    $("#<%= CarMoneyCB.ClientID%>").val(tableToolbar.getFloat(jiagecb * tianshu * (tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val())) / $("#RenShuNum").val()));
                }
                OrderPage.ZongJia();
            }
        });
        $("#radio6").change(function() {
            if ($("#radio6").attr("checked")) {
                $("#<%= CarMoney.ClientID%>").val("0");
                $("#<%= CarMoneyCB.ClientID%>").val("0");
            }
            OrderPage.ZongJia();
        });
        //        $("#radio2").change(function() {
        //            if ($("#radio2").attr("checked")) {
        //                $("#RJBXF").val($("#<%= RSJiaGe.ClientID%>").val());
        //                $("#BaoXianFS").val("人身保险");
        //            }
        //            OrderPage.ZongJia();
        //        });

        //        $("#radio3").change(function() {
        //            if ($("#radio3").attr("checked")) {
        //                $("#RJBXF").val($("#<%= JTJiaGe.ClientID%>").val());
        //                $("#BaoXianFS").val("交通保险");
        //            }
        //            OrderPage.ZongJia();
        //        });
//        $("#QuanPeiDaoYouNum").blur(function() {
//            alert("sss");
//            alert($("#QuanPeiDaoYouNum").val());
//            $("#DaoYouNum").val($("#QuanPeiDaoYouNum").val());
//            alert($("#DaoYouNum").val());
//            $("#DaoYouNum").blur();
//        });
        $("#DaoYouNum").blur(function() {
            var type = "<%= routeType %>";
            var daoyounum = $("#DaoYouNum").val();
            if (type == "1") {
                //国内长线  全陪背后公式 = 【线路门市价/2 + 400元/天*自动识别的旅游天数】/成团人数
                if (tableToolbar.getInt(daoyounum) < 0) {
                    $("#DaoYouNum").val("0");
                }
                $("#QuanPeiDaoYouFei").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenMS.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoney.ClientID%>").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DaoYouNum").val())));
                $("#QuanPeiDaoYouFeiCB").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenJieSuan.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoneyCB.ClientID%>").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DaoYouNum").val())));
            }
            else if (type == "2") {
            //国际线路  全陪：公式 =【线路门市价/2 + 300元/员/天*天数】/ 标准人数 *【标准人数15-成团人数】/成团人数(如果成团人数大于标准人数，则按1算)
                if (tableToolbar.getInt(daoyounum) < 1) {
                    $("#DaoYouNum").val("1");
                }
                var rsnum = tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val());
                if (tableToolbar.getInt(rsnum) < 1) {
                    $("#QuanPeiDaoYouFei").val("0");
                    $("#QuanPeiDaoYouFeiCB").val("0");
                }
                else {
                    $("#QuanPeiDaoYouFei").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenMS.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoney.ClientID%>").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val())) / tableToolbar.getFloat($("#<%= BiaoZhunNum.ClientID%>").val()) * tableToolbar.getFloat(rsnum) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DaoYouNum").val())));
                    $("#QuanPeiDaoYouFeiCB").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenJieSuan.ClientID%>").val()) / 2 + tableToolbar.getFloat($("#<%= DaoYouMoneyCB.ClientID%>").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val())) / tableToolbar.getFloat($("#<%= BiaoZhunNum.ClientID%>").val()) * tableToolbar.getFloat(rsnum) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DaoYouNum").val())));
                }
            }
            else if (type == "3") {
                //周边短线   全陪背后公式 = 【线路门市价/3 + 400元/天*自动识别的旅游天数】/成团人数
                if (tableToolbar.getInt(daoyounum) < 0) {
                    $("#DaoYouNum").val("0");
                }
                $("#QuanPeiDaoYouFei").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenMS.ClientID%>").val()) / 3 + tableToolbar.getFloat($("#<%= DaoYouMoney.ClientID%>").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DaoYouNum").val())));
                $("#QuanPeiDaoYouFeiCB").val(tableToolbar.getFloat((tableToolbar.getFloat($("#<%= ChengRenJieSuan.ClientID%>").val()) / 3 + tableToolbar.getFloat($("#<%= DaoYouMoneyCB.ClientID%>").val()) * tableToolbar.getFloat($("#<%= JTTianShu.ClientID%>").val())) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DaoYouNum").val())));
            }
            var dipeifei = $("#DiPeiDaoYouFei").val();
            var dipeifeicb = $("#DiPeiDaoYouFeiCB").val();
            var quanpeifei = $("#QuanPeiDaoYouFei").val();
            var quanpeifeicb = $("#QuanPeiDaoYouFeiCB").val();
            $("#<%= DaoYouFei.ClientID%>").val(tableToolbar.getFloat(tableToolbar.getFloat(dipeifei) + tableToolbar.getFloat(quanpeifei)));
            $("#DaoYouFeiCB").val(tableToolbar.getFloat(tableToolbar.getFloat(dipeifeicb) + tableToolbar.getFloat(quanpeifeicb)));
            OrderPage.ZongJia();
        });
        $("#DiPeiDaoYouNum").blur(function() {
            var dipeidaoyounum = $("#DiPeiDaoYouNum").val();
            if (tableToolbar.getInt(dipeidaoyounum) < 1) {
                $("#DiPeiDaoYouNum").val("1");
            }
            var rsnum = tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) - tableToolbar.getInt($("#RenShuNum").val());
            if (tableToolbar.getInt(rsnum) < 1) { rsnum = 0; }

            //地陪背后公式 =  200元/员/天*天数 / 标准成团人数   *  [标准人数25-成团人数]/成团人数
            $("#DiPeiDaoYouFei").val(tableToolbar.getFloat(tableToolbar.getFloat($("#<%= DiPeiDaoYou.ClientID%>").val()) * rsnum * tableToolbar.getInt($("#<%= JTTianShu.ClientID%>").val()) / tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DiPeiDaoYouNum").val())));
            $("#DiPeiDaoYouFeiCB").val(tableToolbar.getFloat(tableToolbar.getFloat($("#<%= DiPeiDaoYouCB.ClientID%>").val()) * rsnum * tableToolbar.getInt($("#<%= JTTianShu.ClientID%>").val()) / tableToolbar.getInt($("#<%= BiaoZhunNum.ClientID%>").val()) / tableToolbar.getInt($("#RenShuNum").val()) * tableToolbar.getInt($("#DiPeiDaoYouNum").val())));

            var dipeifei = $("#DiPeiDaoYouFei").val();
            var quanpeifei = $("#QuanPeiDaoYouFei").val();
            var dipeifeicb = $("#DiPeiDaoYouFeiCB").val();
            var quanpeifeicb = $("#QuanPeiDaoYouFeiCB").val();
            $("#<%= DaoYouFei.ClientID%>").val(tableToolbar.getFloat(tableToolbar.getFloat(dipeifei) + tableToolbar.getFloat(quanpeifei)));
            $("#DaoYouFeiCB").val(tableToolbar.getFloat(tableToolbar.getFloat(dipeifeicb) + tableToolbar.getFloat(quanpeifeicb)));
            OrderPage.ZongJia();
        });



        $("#QuZhongDian").blur(function(obj) {
            $("#QuGongLi").val("0");
            $("input[name=QuCheFei]").val("0");
            GetJuLi($("#QuQiDian").val(), $("#QuZhongDian").val(), "Qu", this);
        });
        $("#QuQiDian").blur(function(obj) {
            $("#QuGongLi").val("0");
            $("input[name=QuCheFei]").val("0");
            if ($("#QuZhongDian").val() != "请详细正确填写市县区和道路名称" && $("#QuZhongDian").val() != "") {
                GetJuLi($("#QuQiDian").val(), $("#QuZhongDian").val(), "Qu", this);
            }
        });
        $("#HuiQiDian").blur(function(obj) {
            $("#HuiGongLi").val("0");
            $("input[name=HuiCheFei]").val("0");
            if ($("#HuiZhongDian").val() != "请详细正确填写市县区和道路名称" && $("#HuiZhongDian").val() != "") {
                GetJuLi($("#HuiQiDian").val(), $("#HuiZhongDian").val(), "Hui", this);
            }
        });
        $("#HuiZhongDian").blur(function(obj) {
            $("#HuiGongLi").val("0");
            $("input[name=HuiCheFei]").val("0");
            GetJuLi($("#HuiQiDian").val(), $("#HuiZhongDian").val(), "Hui", this);
        });
        $("input[name=QuZuCheNum]").blur(function() {
            if ($("#QuZhongDian").val() != "请详细正确填写市县区和道路名称" && $("#QuZhongDian").val() != "") {
                $(this).closest("tr").find("select[name=ddl_Qucarlist]").change();
            }
        });
        $("input[name=HuiZuCheNum]").blur(function() {
            if ($("#HuiZhongDian").val() != "请详细正确填写市县区和道路名称" && $("#HuiZhongDian").val() != "") {
                $(this).closest("tr").find("select[name=ddl_Huicarlist]").change();
            }
        });


        function GetJuLi(start, end, name, obj) {
            // 百度地图API功能
            var map = new BMap.Map("map_canvas");
            map.centerAndZoom(new BMap.Point(116.404, 39.915), 12);
            var juli;
            var objet = $(obj);
            var searchComplete = function(results) {
                if (transit.getStatus() != BMAP_STATUS_SUCCESS) {
                    return;
                }
                var plan = results.getPlan(0);
                juli = plan.getDistance(false);             //获取距离
            }
            var transit = new BMap.DrivingRoute(map, { renderOptions: { map: map },
                onSearchComplete: searchComplete,
                onPolylinesSet: function() {
                    $("#" + name + "GongLi").val(juli / 1000);
                    $("#JianCe").val("1");
                    var Checount = objet.closest("table").find("select[name=ddl_" + name + "carlist]").length;
                    for (var i = 0; i < Checount; i++) {
                        var objtr = objet.closest("table").find("select[name=ddl_" + name + "carlist]").eq(i);
                        $(objtr).change();
                    }

                }
            });
            transit.search(start, end);
        }

        //        function jisuanjiage(obj) {
        //            if (tableToolbar.getFloat($("#QuGongLi").val()) > 500) {
        //                tableToolbar._showMsg("您的去程公里数大于500公里，请联系旅游社解决！");
        //                return false;
        //            }
        //            if (tableToolbar.getFloat($("#HuiGongLi").val()) > 500) {
        //                tableToolbar._showMsg("您的回程公里数大于500公里，请联系旅游社解决！");
        //                return false;
        //            }
        //            OrderPage.Show();
        //            $(obj).closest("tr").find("input[name=CheFei]").val(jsonZ.Zhy);
        //        }
        $("select[name=ddl_Qucarlist]").change(function(num) {
            if (tableToolbar.getFloat($("#QuGongLi").val()) < 1) {
                alert("去程起点和终点无法计算出距离，请重新选择起点和终点！");
                return false;
            }
            var that = $(this).closest("tr").find("input[name=QuCheFei]");
            var thatcb = $(this).closest("tr").find("input[name=QuCheFeiCB]");
            var cheNum = $(this).closest("tr").find("input[name=QuZuCheNum]").val();
            var GongLiName = $(this).closest("table").find("input[type=hidden]").attr("id");
            var _data = { id: $(this).val() };
            $.ajax({
                type: "post",
                cache: false,
                url: "/ZiXunXX.aspx?dotype=select",
                dataType: "json",
                data: _data,
                success: function(ret) {
                    if (ret.result == "0") {
                        var list = eval('(' + ret.obj + ')');
                        OrderPage.alt(list, GongLiName);
                        var chefeijiage = jsonZ.Zjc;
                        //                        if (usercate == 1) {
                        //                            chefeijiage = jsonZ.Zhy;
                        //                        }
                        //                        else if (usercate == 2) {
                        //                            chefeijiage = jsonZ.Zgb;
                        //                        }
                        //                        else if (usercate == 3) {
                        //                            chefeijiage = jsonZ.Zmfx;
                        //                        }
                        //                        else if (usercate == 4) {
                        //                            chefeijiage = jsonZ.Zfx;
                        //                        }
                        //                        else if (usercate == 5) {
                        //                            chefeijiage = jsonZ.Zyg;
                        //                        }
                        that.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        var CheFeicount = $("input[name=QuCheFei]").length;
                        var ZongChefei = 0;
                        var ZongChefeiCB = 0;
                        for (var i = 0; i < CheFeicount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=QuCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                        }
                        var CheFeihuicount = $("input[name=HuiCheFei]").length;
                        for (var i = 0; i < CheFeihuicount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=HuiCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                        }
                        $("#ZuCheMoney").val(tableToolbar.getFloat(ZongChefei));
                        $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        OrderPage.ZongJia();
                    }
                    else {
                        var list = eval('(' + ret.obj + ')');
                        OrderPage.alt(list, GongLiName);
                        var chefeijiage = jsonZ.Zjc;
                        //                        if (usercate == 1) {
                        //                            chefeijiage = jsonZ.Zhy;
                        //                        }
                        //                        else if (usercate == 2) {
                        //                            chefeijiage = jsonZ.Zgb;
                        //                        }
                        //                        else if (usercate == 3) {
                        //                            chefeijiage = jsonZ.Zmfx;
                        //                        }
                        //                        else if (usercate == 4) {
                        //                            chefeijiage = jsonZ.Zfx;
                        //                        }
                        //                        else if (usercate == 5) {
                        //                            chefeijiage = jsonZ.Zyg;
                        //                        }
                        that.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        var CheFeicount = $("input[name=QuCheFei]").length;
                        var ZongChefei = 0;
                        var ZongChefeiCB = 0;
                        for (var i = 0; i < CheFeicount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=QuCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                        }
                        var CheFeihuicount = $("input[name=HuiCheFei]").length;
                        for (var i = 0; i < CheFeihuicount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=HuiCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                        }
                        $("#ZuCheMoney").val(tableToolbar.getFloat(ZongChefei));
                        $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        OrderPage.ZongJia();
                    }
                },
                error: function() {
                }
            });
        });
        $("select[name=ddl_Huicarlist]").change(function(num) {
        var that = $(this).closest("tr").find("input[name=HuiCheFei]");
        var thatcb = $(this).closest("tr").find("input[name=QuCheFeiCB]");
            var cheNum = $(this).closest("tr").find("input[name=HuiZuCheNum]").val();
            var GongLiName = $(this).closest("table").find("input[type=hidden]").attr("id");
            var _data = { id: $(this).val() };
            $.ajax({
                type: "post",
                cache: false,
                url: "/ZiXunXX.aspx?dotype=select",
                dataType: "json",
                data: _data,
                success: function(ret) {
                    if (ret.result == "0") {
                        var list = eval('(' + ret.obj + ')');
                        OrderPage.alt(list, GongLiName);
                        var chefeijiage = jsonZ.Zjc;
//                        if (usercate == 1) {
//                            chefeijiage = jsonZ.Zhy;
//                        }
//                        else if (usercate == 2) {
//                            chefeijiage = jsonZ.Zgb;
//                        }
//                        else if (usercate == 3) {
//                            chefeijiage = jsonZ.Zmfx;
//                        }
//                        else if (usercate == 4) {
//                            chefeijiage = jsonZ.Zfx;
//                        }
//                        else if (usercate == 5) {
//                            chefeijiage = jsonZ.Zyg;
//                        }
                        that.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        var CheFeicount = $("input[name=HuiCheFei]").length;
                        var ZongChefei = 0;
                        var ZongChefeiCB = 0;
                        for (var i = 0; i < CheFeicount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=HuiCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                        }
                        var CheFeiqucount = $("input[name=QuCheFei]").length;
                        for (var i = 0; i < CheFeiqucount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=QuCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                        }
                        $("#ZuCheMoney").val(tableToolbar.getFloat(ZongChefei));
                        $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        OrderPage.ZongJia();
                    }
                    else {
                        var list = eval('(' + ret.obj + ')');
                        OrderPage.alt(list, GongLiName);
                        var chefeijiage = jsonZ.Zjc;
//                        if (usercate == 1) {
//                            chefeijiage = jsonZ.Zhy;
//                        }
//                        else if (usercate == 2) {
//                            chefeijiage = jsonZ.Zgb;
//                        }
//                        else if (usercate == 3) {
//                            chefeijiage = jsonZ.Zmfx;
//                        }
//                        else if (usercate == 4) {
//                            chefeijiage = jsonZ.Zfx;
//                        }
//                        else if (usercate == 5) {
//                            chefeijiage = jsonZ.Zyg;
//                        }
                        that.val(tableToolbar.getFloat(tableToolbar.getFloat(chefeijiage) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        thatcb.val(tableToolbar.getFloat(tableToolbar.getFloat(jsonZ.Zcb) * tableToolbar.getFloat(cheNum) / tableToolbar.getInt($("#RenShuNum").val())));
                        var CheFeicount = $("input[name=HuiCheFei]").length;
                        var ZongChefei = 0;
                        var ZongChefeiCB = 0;
                        for (var i = 0; i < CheFeicount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=HuiCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=HuiCheFeiCB]").eq(i).val());
                        }
                        var CheFeiqucount = $("input[name=QuCheFei]").length;
                        for (var i = 0; i < CheFeiqucount; i++) {
                            ZongChefei = tableToolbar.getFloat(ZongChefei) + tableToolbar.getFloat($("input[name=QuCheFei]").eq(i).val());
                            ZongChefeiCB = tableToolbar.getFloat(ZongChefeiCB) + tableToolbar.getFloat($("input[name=QuCheFeiCB]").eq(i).val());
                        }
                        $("#ZuCheMoney").val(tableToolbar.getFloat(ZongChefei));
                        $("#ZuCheMoneyCB").val(tableToolbar.getFloat(ZongChefeiCB));
                        OrderPage.ZongJia();
                    }
                },
                error: function() {
                }
            });
        });
    </script>

    <script type="text/javascript">


        var map = new BMap.Map("map_canvas");          // 创建地图实例
        var point = new BMap.Point('106.486654,29.490295', '106.581515,29.615467');  // 创建点坐标
        map.centerAndZoom(point, 16);                 // 初始化地图，设置中心点坐标和地图级别
        map.enableScrollWheelZoom();
        var mkr = new BMap.Marker(point);

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
            var zongmoney = $("#<%= ZongMoney.ClientID%>").val();
            var zongmoneycb = $("#ZongMoneyCB").val();
            
            var YHuiYuanJia = tableToolbar.getFloat(zongmoneycb)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney)-tableToolbar.getFloat(zongmoneycb))*FeetSeting.Mhy/100);
            var YGuiBingJia = tableToolbar.getFloat(zongmoneycb)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney)-tableToolbar.getFloat(zongmoneycb))*FeetSeting.Mgb/100);
            var YDaiLiJia = tableToolbar.getFloat(zongmoneycb)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney)-tableToolbar.getFloat(zongmoneycb))*FeetSeting.Mfx/100);
            var YYuanGongJia = tableToolbar.getFloat(zongmoneycb)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(zongmoney)-tableToolbar.getFloat(zongmoneycb))*FeetSeting.Myg/100);
           //原增加价格结束 
            var CheFeicount = $("input[data-id=Money]").length;
            var ZongJiaGe = 0;
            var ZongJiaGeCB = 0;
            for (var i = 0; i < CheFeicount; i++) {
                ZongJiaGe = tableToolbar.getFloat(ZongJiaGe) + tableToolbar.getFloat($("input[data-id=Money]").eq(i).val());
                ZongJiaGeCB = tableToolbar.getFloat(ZongJiaGeCB) + tableToolbar.getFloat($("input[data-cb=MoneyCB]").eq(i).val());
            }
            $("#<%= ZongMoney.ClientID%>").val(tableToolbar.getFloat(ZongJiaGe));
            $("#ZongMoneyCB").val(tableToolbar.getFloat(ZongJiaGeCB));
            //现增加价格
            var MenShiJia = ZongJiaGe;
            var ChengBenJia = ZongJiaGeCB;
            var HuiYuanJia = tableToolbar.getFloat(ChengBenJia)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia)-tableToolbar.getFloat(ChengBenJia))*FeetSeting.Mhy/100);
            var GuiBingJia = tableToolbar.getFloat(ChengBenJia)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia)-tableToolbar.getFloat(ChengBenJia))*FeetSeting.Mgb/100);
            var DaiLiJia = tableToolbar.getFloat(ChengBenJia)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia)-tableToolbar.getFloat(ChengBenJia))*FeetSeting.Mfx/100);
            var YuanGongJia = tableToolbar.getFloat(ChengBenJia)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia)-tableToolbar.getFloat(ChengBenJia))*FeetSeting.Myg/100);
            //现增加价格结束
            
            var ChengRenNum=$("#RenShu").val();
            var ErTongNum=$("#ETRenShu").val();
            var ChengRenJia=0;
            var ErTongJia=0;
            //门市
            var zhifucount = $("input[data-name=MenShiMoney]").length;
            for (var i = 0; i < zhifucount; i++) {
                var zhifujiage = $("input[data-name=MenShiMoney]").eq(i).val();
                $("input[data-name=MenShiMoney]").eq(i).val(tableToolbar.getFloat(tableToolbar.getFloat(MenShiJia) - tableToolbar.getFloat(zongmoney) + tableToolbar.getFloat(zhifujiage)));
                }
                
               ChengRenJia = $("input[data-name=MenShiMoney]").eq(0).val();
               ErTongJia = $("input[data-name=MenShiMoney]").eq(1).val();
               $("input[data-name=ZongMenShiMoney]").val(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia)*tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia)*tableToolbar.getInt(ErTongNum)));
                
             if(tableToolbar.getInt(usercate) >= 1)
            {
            //会员
            var zhifucount = $("input[data-name=HuiYuanMoney]").length;
            for (var i = 0; i < zhifucount; i++) {
                var zhifujiage = $("input[data-name=HuiYuanMoney]").eq(i).val();
                $("input[data-name=HuiYuanMoney]").eq(i).val(tableToolbar.getFloat(tableToolbar.getFloat(HuiYuanJia) - tableToolbar.getFloat(YHuiYuanJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("input[data-name=HuiYuanMoney]").eq(0).val();
               ErTongJia = $("input[data-name=HuiYuanMoney]").eq(1).val();
               $("#UChengRenJia").val(ChengRenJia);
               $("#UErTongJia").val(ErTongJia);
               $("input[data-name=ZongHuiYuanMoney]").val(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia)*tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia)*tableToolbar.getInt(ErTongNum)));
                }
            if(tableToolbar.getInt(usercate) >= 2)
            {    
            //贵宾
            var zhifucount = $("input[data-name=GuiBingMoney]").length;
            for (var i = 0; i < zhifucount; i++) {
                var zhifujiage = $("input[data-name=GuiBingMoney]").eq(i).val();
                $("input[data-name=GuiBingMoney]").eq(i).val(tableToolbar.getFloat(tableToolbar.getFloat(GuiBingJia) - tableToolbar.getFloat(YGuiBingJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("input[data-name=GuiBingMoney]").eq(0).val();
               ErTongJia = $("input[data-name=GuiBingMoney]").eq(1).val();
               $("#UChengRenJia").val(ChengRenJia);
               $("#UErTongJia").val(ErTongJia);
               $("input[data-name=ZongGuiBingMoney]").val(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia)*tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia)*tableToolbar.getInt(ErTongNum)));
                }
             
             if(tableToolbar.getInt(usercate) >= 4)
            { 
            //代理
            var zhifucount = $("input[data-name=DaiLiMoney]").length;
            for (var i = 0; i < zhifucount; i++) {
                var zhifujiage = $("input[data-name=DaiLiMoney]").eq(i).val();
                $("input[data-name=DaiLiMoney]").eq(i).val(tableToolbar.getFloat(tableToolbar.getFloat(DaiLiJia) - tableToolbar.getFloat(YDaiLiJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("input[data-name=DaiLiMoney]").eq(0).val();
               ErTongJia = $("input[data-name=DaiLiMoney]").eq(1).val();
               $("#UChengRenJia").val(ChengRenJia);
               $("#UErTongJia").val(ErTongJia);
               $("input[data-name=ZongDaiLiMoney]").val(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia)*tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia)*tableToolbar.getInt(ErTongNum)));
                }
             
             if(tableToolbar.getInt(usercate) >= 5)
            {   
            //员工
            var zhifucount = $("input[data-name=YuanGongMoney]").length;
            for (var i = 0; i < zhifucount; i++) {
                var zhifujiage = $("input[data-name=YuanGongMoney]").eq(i).val();
                $("input[data-name=YuanGongMoney]").eq(i).val(tableToolbar.getFloat(tableToolbar.getFloat(YuanGongJia) - tableToolbar.getFloat(YYuanGongJia) + tableToolbar.getFloat(zhifujiage)));
                }
                ChengRenJia = $("input[data-name=YuanGongMoney]").eq(0).val();
               ErTongJia = $("input[data-name=YuanGongMoney]").eq(1).val();
               $("#UChengRenJia").val(ChengRenJia);
               $("#UErTongJia").val(ErTongJia);
               $("input[data-name=ZongYuanGongMoney]").val(tableToolbar.getFloat(tableToolbar.getFloat(ChengRenJia)*tableToolbar.getInt(ChengRenNum) + tableToolbar.getFloat(ErTongJia)*tableToolbar.getInt(ErTongNum)));
                }
                
                
            var crms = $("#<%= ChengRenMS.ClientID%>").val();//成人门市
            var etms = $("#<%= ErTongMS.ClientID%>").val();//儿童门市
            var crjs = $("#<%= ChengRenJieSuan.ClientID%>").val();//成人结算
            var etjs = $("#<%= ErTongJieSuan.ClientID%>").val();//儿童结算
            var addjia =$("#<%= ZongMoney.ClientID%>").val();//增加门市价
            var addcb =$("#ZongMoneyCB").val();//增加成本价
            
            
            var guibingcr = tableToolbar.getFloat(crjs)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(crms)-tableToolbar.getFloat(crjs))* FeetSeting.Mgb/ 100);
            var guibinget = tableToolbar.getFloat(etjs)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(etms)-tableToolbar.getFloat(etjs))* FeetSeting.Mgb/ 100);
            var dailicr = tableToolbar.getFloat(crjs)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(crms)-tableToolbar.getFloat(crjs))* FeetSeting.Mfx/ 100);
            var dailiet = tableToolbar.getFloat(etjs)+tableToolbar.getFloat(tableToolbar.getFloat(tableToolbar.getFloat(etms)-tableToolbar.getFloat(etjs))* FeetSeting.Mfx/ 100);
            
            var guibingcr=tableToolbar.getFloat(guibingcr)+tableToolbar.getFloat(GuiBingJia);
            var guibinget=tableToolbar.getFloat(guibinget)+tableToolbar.getFloat(GuiBingJia);
            var dailicr=tableToolbar.getFloat(dailicr)+tableToolbar.getFloat(DaiLiJia);
            var dailiet=tableToolbar.getFloat(dailiet)+tableToolbar.getFloat(DaiLiJia);
            var hyzj =tableToolbar.getFloat($("input[data-name=ZongHuiYuanMoney]").val());
            var guibingzj =tableToolbar.getFloat(tableToolbar.getFloat(guibingcr)*tableToolbar.getFloat(ChengRenNum)+tableToolbar.getFloat(guibinget)*tableToolbar.getFloat(ErTongNum)); 
            var dailizj =tableToolbar.getFloat(tableToolbar.getFloat(dailicr)*tableToolbar.getFloat(ChengRenNum)+tableToolbar.getFloat(dailiet)*tableToolbar.getFloat(ErTongNum));
                
            var guibinname ="申请贵宾身份";
            var dailiname ="申请代理身份";
            
            var dailiurl="<a href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+(hyzj-dailizj).toFixed(2)+"元</b>";
            
            var guibinurl ="<a href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+(hyzj-guibingzj).toFixed(2)+"元</b>";
            if(usercate ==2){
            guibinname ="贵宾价格总金额";dailiname ="申请代理身份";
            guibinurl ="";
            
            }
            if(usercate ==3){
            guibinname ="贵宾价格总金额";dailiname ="申请代理身份";
            guibinurl ="";
            
            }
            if(usercate ==4){
            dailiname ="代理价格总金额";guibinname ="贵宾价格总金额";
            guibinurl=""; dailiurl="";
            }
            if(usercate ==5)
            {
            dailiname ="代理价格总金额";guibinname ="贵宾价格总金额";
            guibinurl=""; dailiurl="";
            }
            
            html2 = "<div class=\"car_price\" style=\"width:1030px;margin:10px auto;\">"
               +"<ul><li class=\"mar5\"><div class=\"tixing\"><b>会员价总金额：</b><br />"
               +"<font class=\"fontyellow\">成人（<b class=\"font14\">"+ $("input[data-name=HuiYuanMoney]").eq(0).val() +"</b>元/人 x <b class=\"font14\">"+ChengRenNum+"</b>人）+儿童(<b class=\"font14\">"+ $("input[data-name=HuiYuanMoney]").eq(1).val() +"</b>元/人 x <b class=\"font14\">"+ErTongNum+"</b>人) = </font> <font class=\"fontblue\"><b class=\"font14\">"+hyzj+"</b>元</font></div></li>"
                  +"<li class=\"mar5\"><div class=\"tixing\"><b>"+guibinname+"：</b><br />"
                  +"<font class=\"fontyellow\">成人（<b class=\"font14\">"+tableToolbar.getFloat(guibingcr)+"</b>元/人 x <b class=\"font14\">"+ChengRenNum+"</b>人）+儿童(<b class=\"font14\">"+tableToolbar.getFloat(guibinget)+"</b>元/人 x <b class=\"font14\">"+ErTongNum+"</b>人) = </font> <font class=\"fontblue\"><b class=\"font14\">"+ tableToolbar.getFloat(guibingzj) +"</b>元</font>"+guibinurl+"</div></li>"
                  +"<li><div class=\"tixing\"><b>"+dailiname+"：</b><br />"
                  +"<font class=\"fontyellow\">成人（<b class=\"font14\">"+tableToolbar.getFloat(dailicr)+"</b>元/人 x <b class=\"font14\">"+ChengRenNum+"</b>人）+儿童(<b class=\"font14\">"+tableToolbar.getFloat(dailiet)+"</b>元/人 x <b class=\"font14\">"+ErTongNum+"</b>人) = </font> <font class=\"fontblue\"><b class=\"font14\">"+ tableToolbar.getFloat(dailizj) +"</b>元</font>"+dailiurl+"</div></li></ul></div>";
            
            
            $("#carpricelist").html(html2);  
                
                
                
                
        }
    }
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
