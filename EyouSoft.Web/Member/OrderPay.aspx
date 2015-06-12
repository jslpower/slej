<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPay.aspx.cs" Inherits="EyouSoft.YlWeb.Hangqi.OrderPay"
    MasterPageFile="~/MasterPage/Front.Master" Title="订单支付" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Link" runat="server">
    <div class="step_mainbox">
        <div class="step_T">
            <div class="basicT floatL">
                您的位置：商旅e家 > 订单支付</div>
            <div class="step_Rimg">
                <img src="../images/online_book.jpg" /></div>
            <div class="step_num">
                <ul>
                    <li>
                        <img src="../images/step01_1.jpg" /><span class="bfontblue">选择产品</span></li>
                    <li>
                        <img src="../images/step02_1.jpg" /><span class="bfontblue">核对与填写信息</span></li>
                    <li>
                        <img src="../images/step03_1.jpg" /><span class="bfontblue" style="text-indent: 79px;">客服审核</span></li>
                    <li>
                        <img src="../images/step04_1.jpg" /><span class="bfontblue" style="text-indent: 96px;">订单支付</span></li>
                    <li>
                        <img src="../images/step05.jpg" /><span style="text-indent: 107px;">预订成功</span></li>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="step_box1 margin_T16">
            <div class="basic_mainT_color">
                <h5>
                    订单支付</h5>
            </div>
            <div class="ddzf_yellbox">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            订单号
                        </th>
                        <th align="left">
                            产品
                        </th>
                        <th>
                            付款金额
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrJiaoYiHao"></asp:Literal>
                        </td>
                        <td align="left" valign="middle">
                            <asp:Literal runat="server" ID="ltrMingCheng"></asp:Literal>
                        </td>
                        <td align="center" valign="middle">
                            <font class="font34 price_yellow">
                                <asp:Literal runat="server" ID="ltrJinE"></asp:Literal></font>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="n4Tab_bank" id="n4Tab4">
                <div class="bank_T">
                    <ul>
                        <%--<li id="n4Tab4_Title0" onclick="nTabs('n4Tab4',this);" class="active"><a href="javascript:void(0);">
                            信用卡</a></li>--%>
                        <li id="n4Tab4_Title0" onclick="bank_fs(0);" class="active"><a href="javascript:void(0);">
                            网上银行</a></li>
                        <li id="n4Tab4_Title1" onclick="bank_fs(1);" class="normal"><a href="javascript:void(0);">
                            第三方支付</a></li>
                    </ul>
                </div>
                <div class="bank_Content">
                    <%--<div id="n4Tab4_Content0">
                        <ul>
                            <li><a href="#">
                                <input name="" type="radio" value="" checked="checked" /><label class="current"><img
                                    src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                            <li><a href="#">
                                <input name="" type="radio" value="" /><label><img src="../images/zhg_bank.jpg" /></label></a></li>
                        </ul>
                        <div class="clear">
                        </div>
                        <div class="bank_qt">
                            <a href="select_bank.html">选择其他银行
                                <img src="../images/bot_jt.png" /></a></div>
                    </div>--%>
                    <div id="n4Tab4_Content0">
                        <ul id="bank_01">
                        </ul>
                        <div class="clear">
                        </div>
                        <div class="bank_qt">
                            <a href="javascript:void(0)" id="a_bank_03">选择其他银行
                                <img src="../images/bot_jt.png" /></a></div>
                    </div>
                    <div id="n4Tab4_Content1" style="display: none;">
                        <ul id="bank_02">
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="zhifu_btn">
            <div class="leftTxt">
                <%--<a href="step2.html">
                    <img src="../images/left_jt.jpg" />
                    返回上一步</a>--%></div>
            <a href="javascript:void(0)" class="btn" id="i_btn_zhifu">现在去支付</a></div>
        <div class="guild">
            <h5>
                支付安全承诺：</h5>
            <p>
                维诗达游轮网采用国际标准加密算法来保证支付信息安全传输，并承诺保障用户在维诗达游轮网的信息安全，如因维诗达安全问题造成资金损失，维诗达全额赔付。
            </p>
        </div>
    </div>
    <input type="hidden" id="txt_bank_id" value="" />
    <input type="hidden" id="txt_bank_fs" value="" />
    <form runat="server" id="form1">
    </form>
</asp:Content>
