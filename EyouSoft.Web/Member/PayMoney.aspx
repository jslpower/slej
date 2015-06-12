<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayMoney.aspx.cs" Inherits="EyouSoft.Web.Member.PayMoney"
    MasterPageFile="~/MasterPage/FrontFixed.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery-1.4.2.min.js" type="text/javascript"></script>

    <link href="/Css/style.css" rel="stylesheet" />

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="zhfu_table margin_T10">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <th width="20%" align="center">
                    商品名称
                </th>
                <td align="left" class="padd"><asp:Label ID="lblchanpinmingcheng" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th>应付金额</th>
                <td align="left" class="padd"><asp:Literal ID="TradeMoney" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </div>
    <div class="xieyi_box" style="padding-left:10px; padding-right:10px;">
                <div class="xieyi_txt" id="xieyi">
                    <asp:Literal runat="server" ID="txtXieYi"></asp:Literal>
                </div>
                <div style="padding-top: 20px; text-align: center;">
                    <a href="javascript:;" class="b-btn01 link01" id="toPay"><span>同意并付款</span></a></div>
            </div>
    <div class="zhfu_tab" id="n4Tab8" style="display:none;">
        <div class="zhfu-TabTitle">
            <ul>
                <li id="liX" class="active"><a href="javascript:;">使用E额宝支付</a></li>
                <li id="liY"><a href="javascript:">使用网银支付</a></li>
                <li id="liM"><a href="javascript:">银行汇款</a></li>
            </ul>
        </div>
        <div class="zhfu-TabContent">
            <form id="form1" runat="server">
            <div id="zhifu" class="none">
                <div class="zhfu-form">
                    <ul>
                    <li style="padding-left:240px; overflow:hidden;">
                        
                            <div style="float:left; margin-left:-240px; width:240px; display:inline;">
                                <i>E额宝余额：</i>
                                <span class="zf-price"><asp:Literal ID="MyMoney" runat="server"></asp:Literal> </span>
                            </div>
                            
                            <div style="overflow:hidden; line-height:2;">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                                <a href="/Member/MyChongzhi.aspx?tp=1" class="yudin_btn"><span>余额不足,马上充值</span></a>
                                </asp:PlaceHolder>
                                <span style="padding-left:10px;"> E额宝可一次充值多次支付，E额宝余额每天增值，既能保障资金安全，又是用于支付、反利、提现和综合结算的最佳工具！</span>
                                <a target="_blank" href="/Ebao.aspx" class="zf-blue">什么是E额宝？</a>
                            </div>
                        
                      </li>
                        <li><i>E额宝支付密码：</i>
                            <input id="zhifuPwd" name="zhifuPwd" type="password" class="inputbk formsize140" valid="required" errmsg="请输入支付密码!" /><span>在“E额宝”下拉的“E额宝余额管理”中可找回或设置该密码，<a href="/Member/SetPassWord.aspx" class="zf-blue">现在设置</a></span></li>
                        <li><i>动态支付验证码：</i>
                            <input id="viacode" name="viacode" type="text" class="inputbk formsize80" valid="required|isNumber"
                                errmsg="请输入验证码|请正确填写收到的验证码!">
                            <a class="zf-blue" href="javascript:void(0)" id="i_a_huoquyuezhifuyanzhengma">获取验证码</a><span style="padding-left:10px;">请输入您注册该帐号时的手机上收到的短信中动态验证码。</span></li>
                        <li><i></i><a href="javascript:;" class="btn b-btn01 link01"><span>确认付款</span></a> <%--<a
                            href="javascript:;" class="btn02_yellow" id="ChongZhi"><span>前往充值</span></a>--%><span
                                id="noMoney" class="fontred" style="padding-left: 10px;"></span> </li>
                    </ul>
                </div>
            </div>
            </form>
            <div id="yinhang" class="none">
                <div class="bank_Content">
                    <h3>
                        点下一步选择银行：</h3>
                    <ul class="fixed" style="display: none">
                        <li>
                            <label>
                                <input name="" type="radio" value="" checked="checked" /><span class="current"><img
                                    src="/images/banklogo/bank_99bill.jpg" /></span></label></li>
                    </ul>
                    <div style="padding-bottom: 15px">
                        特别声明：商旅E家系统交易均委托杭州金奥国际旅行社有限公司代收，用户可通过商旅E家系统支付费用至杭州金奥国际旅行社有限公司帐户或其法人代表刘钊的帐户。 特别提示，除此之外，通过个人其他渠道付款产生损失，商旅E家及杭州金奥国旅不承担任何责任！
                    </div>
                    <div style="padding-left: 20px;">
                        <a href="javascript:;" class="btn b-btn01 link01"><span>下一步</span></a> <a href="javascript:;"
                            class="btn02_yellow" id="Chongzhi1"><span>前往充值</span></a>
                    </div>
                </div>
            </div>
            <div id="huikuan" class="none">
                <div class="bank_huikuan">
                    <h3>
                        金奥国旅业务帐号：</h3>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th width="8%" rowspan="2" align="center" valign="middle">
                                对<br />
                                公<br />
                                账<br />
                                户
                            </th>
                            <td width="46%" valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>浙江泰隆商业银行</strong>&nbsp;杭州分行 </li>
                                    <li>户 名：杭州金奥国际旅行社有限公司</li>
                                    <li>账 号：33020 10120 1000 25496</li>
                                </ul>
                            </td>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>杭州银行</strong>&nbsp;建国路支行 </li>
                                    <li>户 名：杭州金奥国际旅行社有限公司</li>
                                    <li>账 号：7610 8100 176 136</li>
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>支付宝</strong></li>
                                    <li>户 名：杭州金奥国际旅行社有限公司</li>
                                    <li>账 号：hzjaly888@163.com</li>
                                </ul>
                            </td>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>杭州银行</strong>&nbsp;学院路支行 </li>
                                    <li>户 名：杭州金奥国际旅行社有限公司</li>
                                    <li>账 号：7421 8100 351 087</li>
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="2" align="center" valign="middle">
                                个<br />
                                人<br />
                                账<br />
                                户
                            </th>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>工商银行</strong>&nbsp;杭州城西支行</li>
                                    <li>户 名：刘 钊 （法人代表）</li>
                                    <li>账 号：6222 0812 0200 7765413</li>
                                </ul>
                            </td>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>农业银行</strong>&nbsp;杭州艮山支行</li>
                                    <li>户 名：刘 钊 （法人代表）</li>
                                    <li>账 号：62284 8032 13342 12214</li>
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>建设银行</strong>&nbsp;浙江杭州华星支行</li>
                                    <li>户 名：刘 钊 （法人代表）</li>
                                    <li>账 号：6236 6815 4000 0789 276</li>
                                </ul>
                            </td>
                            <td valign="top">
                                <ul>
                                    <li class="fontblue">开户行：<strong>支付宝</strong></li>
                                    <li>户 名：刘 钊 （法人代表）</li>
                                    <li>账 号：139 571 40211</li>
                                    <li>绑定邮箱：289063740@qq.com</li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="fukuan-ok" style="display: none;">
                <p style="font-size: 22px; border-bottom: #c6c6c6 solid 1px;">
                    <img src="images/ok.gif" />
                    支付成功！</p>
                <p class="font16">
                    您可以在<a href="#" class="zf-blue">我的订单</a>里面查看详细订单情况</p>
            </div>
        </div>
    </div>
    <input id="UseMyMoney" type="hidden" name="UseMyMoney" value="0" />
    <div style="padding-top: 20px; text-align: center;">
    </div>
    </body>

    <script type="text/javascript">
        var PageInfo = {
            urlLocation: '<%= EyouSoft.Common.Utils.GetQueryStringValue("Classid")%>',
            yeparam: { Pay: '<%= EyouSoft.Common.Utils.GetQueryStringValue("Pay")%>', Classid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("Classid")%>', id: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id")%>', token: '<%= EyouSoft.Common.Utils.GetQueryStringValue("token")%>' },
            wypara: { orderid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id")%>', type: '<%= EyouSoft.Common.Utils.GetQueryStringValue("type")%>', token: '<%= EyouSoft.Common.Utils.GetQueryStringValue("token")%>' },
            Sava: function() {

                if ($("#UseMyMoney").val() == "0") {
                    if (!PageInfo.CheckForm()) {
                        return false;
                    }
                    var sy = tableToolbar.getFloat('<%=ShengYuJinE %>');
                    var dd = tableToolbar.getFloat('<%=ZhiFuJinE %>');
                    if (dd < sy) {
                        var url = '/Member/PayMoney.aspx?zhifu=1&' + $.param(PageInfo.yeparam);
                        PageInfo.GoAjax(url);
                    }
                    else {
                        $("#noMeney").html("余额不足，你可以选择使用网银支付！");
                        //                    { top.window.open('/99bill/send.aspx?' + $.param(PageInfo.wypara)) }
                    }
                }
                else {
                    if (window.confirm("使用网银支付？"))
                    { top.window.open('/99bill/send.aspx?' + $.param(PageInfo.wypara)) }
                }


            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "alert");
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                                if (PageInfo.urlLocation == "1") { location.href = "/Member/ChangXianOrder.aspx"; return false; }
                                else if (PageInfo.urlLocation == "2") { location.href = "/Member/HotelOrderList.aspx"; return false; }
                                else if (PageInfo.urlLocation == "3") { location.href = "/Member/ScenicList.aspx"; return false; }
                                else if (PageInfo.urlLocation == "4") { location.href = "/Member/ZuCheOrderList.aspx"; return false; }
                                else if (PageInfo.urlLocation == "5") { location.href = "/Member/SCOrderList.aspx"; return false; }
                                else if (PageInfo.urlLocation == "6") { location.href = "/Member/TuanGouDingDan.aspx"; return false; }
                                else if (PageInfo.urlLocation == "7") { location.href = "/Member/VisaOrderList.aspx"; return false; }
                                else if (PageInfo.urlLocation == "8") { location.href = "/Member/ChuJingOrder.aspx"; return false; }
                                else if (PageInfo.urlLocation == "9") { location.href = "/Member/DuanXianOrder.aspx"; return false; }
                                else if (PageInfo.urlLocation == "10") { location.href = "/Member/ZuTuanOrderList.aspx"; return false; }
                                else {
                                    location.href = "/Member/ChangXianOrder.aspx"; return false;
                                }
                            });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            },
            //获取余额支付验证码
            getYuEZhiFuYanZhengMa: function(obj) {
                if (!$("#UseMyMoney").val() == '1') {
                    $("#noMeney").html("使用网银支付不能获取验证码！");
                    return false;
                }
                $(obj).unbind("click");
                var _data = { txtZhiFuJinE: "<%=ZhiFuJinE %>" };
                var _v = false;
                $.ajax({ type: "POST", url: "/ashx/handler.ashx?dotype=getyuezhifuyanzhengma", cache: false, async: false, dataType: "json", data: _data,
                    success: function(response) {
                        if (response.result == 1) {
                            _v = true;
                        } else {
                            alert(response.msg);
                        }
                    }
                });

                if (!_v) {
                    $(obj).click(function() { PageInfo.getYuEZhiFuYanZhengMa(obj); }); return;
                }

                $(obj).css({ color: "#dadada" }).text("验证码已发送");
                setTimeout(function() { $(obj).css({ color: "#fe6600" }).text("获取验证码").click(function() { PageInfo.getYuEZhiFuYanZhengMa(obj); }); }, 30000);
            },
            _bindTab: function() {
                $("#liX").bind("click", function() {
                    $("#zhifu").removeAttr("class");
                    $("#liY").removeAttr("class");
                    $("#liM").removeAttr("class");
                    $(this).attr("class", "active");
                    $("#yinhang").attr("class", "none");
                    $("#huikuan").attr("class", "none");
                    $("#UseMyMoney").val("0");
                });
                $("#liY").bind("click", function() {
                    $("#liX").removeAttr("class");
                    $("#liM").removeAttr("class");
                    $("#yinhang").removeAttr("class");
                    $(this).attr("class", "active")
                    $("#zhifu").attr("class", "none");
                    $("#huikuan").attr("class", "none");
                    $("#UseMyMoney").val("1");
                });
                $("#liM").bind("click", function() {
                    $("#liX").removeAttr("class");
                    $("#liY").removeAttr("class");
                    $("#huikuan").removeAttr("class");
                    $(this).attr("class", "active")
                    $("#zhifu").attr("class", "none");
                    $("#yinhang").attr("class", "none");
                });
            },
            initClick: function() {
                $("#toPay").click(function() {
                    PageInfo._bindTab();
                    $("#xieyi").attr("class", "none");
                    $("#n4Tab8").css("display","block");
                    $("#zhifu").removeAttr("class");
                    $(".btn").bind("click", function() { PageInfo.Sava(); });
                    $(this).parent("div").hide();
                })
            }
        };
        $(function() {
            PageInfo.initClick();
            //$("#ChongZhi").click(function() { location.href = "/Member/MyChongzhi.aspx?tp=1"; });
            $("#Chongzhi1").click(function() { location.href = "/Member/MyChongzhi.aspx?tp=1"; });
            //  $("#btn").click(function() { PageInfo.Sava(); return false; });
            $("#i_a_huoquyuezhifuyanzhengma").click(function() { PageInfo.getYuEZhiFuYanZhengMa(this) });
        });
    </script>

</asp:Content>
