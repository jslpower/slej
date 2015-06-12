<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/FrontFixed.Master" AutoEventWireup="true"
    CodeBehind="ShangChengXiangQing.aspx.cs" Inherits="EyouSoft.Web.ShangChengXiangQing" %>

<%@ Register Src="UserControl/ZhuCe.ascx" TagName="ZhuCe" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.switchable[all].min.js"></script>

    <script type="text/javascript">
        var pageData = {
            CreateBox: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.url,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },    //
            initClick: function() {
                $(".jisuan").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    if ($(this).html() == "+") {
                        getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                    }
                    else {
                        if (tableToolbar.getInt(getNum.val()) > 1) {
                            getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                        } else {
                            getNum.val(1);
                        }
                    }
                    pageData.initJs();
                })
            }, //切换
            initJs: function() {
                var num = tableToolbar.getInt($("#shuliang").val());
                var sphyj = tableToolbar.getInt($("#hydj").html());
                var spgbj = tableToolbar.getInt($("#gbdj").html());
                var spdlj = tableToolbar.getInt($("#dldj").html());
                $("span.ts").html(num);
                $("#hyzj").html(num * sphyj);
                $("#gbzj").html(num * spgbj);
                $("#gbjs").html(num * sphyj - num * spgbj)
                $("#dlzj").html(num * spdlj);
                $("#dljs").html(num * sphyj - num * spdlj)

            },
            ConvImg: function() {
                $("[name=smallA]").click(function() {
                    $(".big_img").find("img").attr("src", $(this).attr("src"));
                    $(".small_img").find("a").removeAttr("class");
                    $(this).parent().attr("class", "on");
                })
            }, //
            GoURL: function() {
                $.ajax({
                    type: "post",
                    url: "ShangChengXiangQing.aspx?url=1",
                    dataType: "json",
                    data: $("#GO").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            window.location.href = '/TiJiaoXX.aspx?id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>&num=' + $("#shuliang").val();
                        } else {

                            window.location.href = "/YuDing.aspx?rurl=" + encodeURIComponent(window.location.href);

                        }
                    }
                });
            }, //
            callFunc: function(parm) {
                window.location.href = window.location.href;
            }
        }
        $(function() {
            pageData.initClick();
            $("#shuliang").change(function() {
                pageData.initJs();
            })
            pageData.ConvImg();
            $("#GO").click(function() {
                pageData.GoURL();
            })
            if ('<%=isDisplay %>' != 'True') {
                $("#div_tx").remove();
            }
            $("#login_n,#login_m").click(function() { window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href) });
        })
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox">
        <div class="n_title">
            > 会员商城</div>
        <div class="mall_xxbox margin_T10 fixed">
            <div class="mall_xxL">
                <div class="big_img" id="SwitchBigPic" style="overflow: hidden;">
                    <asp:Literal ID="lblZhuTu" runat="server" Text=""></asp:Literal></div>
                <div class="small_img">
                    <div class="mall_jtL">
                        <a id="a_le" href="javascript:;">
                            <img src="images/l_jiantou.gif" /></a></div>
                    <div class="mall_jtR">
                        <a id="a_ri" href="javascript:;">
                            <img src="images/r_jiantou.gif" /></a></div>
                    <div class="mall_img">
                        <ul id="SwitchNav" style="position: relative;">
                            <asp:Literal ID="litFuTu" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
            </div>
            <input type="hidden" name="cname" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>" />
            <div class="mall_xxR">
                <div class="page_code" style="bottom: 290px; right: 10px;">
                    <div class="code_box">
                        <div class="code_small">
                            <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                        <div class="code_big" style="display: none;">
                            <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                    </div>
                    <p class="font_yellow">
                        扫描二维码，分享手机版</p>
                </div>
                <dl>
                    <dt>
                        <asp:Label ID="lblChanPinMingCheng" runat="server" Text=""></asp:Label></dt>
                    <dd>
                        <strong>已经销售：</strong><font class="fontblue"><asp:Label ID="lblXiaoShou" runat="server"
                            Text=""></asp:Label>件</font>&nbsp;&nbsp;&nbsp;<strong>上架时间：</strong><asp:Label ID="lblShangJia"
                                runat="server" Text=""></asp:Label></dd>
                    <dd>
                        <strong>生产日期：</strong><asp:Label ID="lblShengChanRiQi" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<strong>保质期：</strong><asp:Label
                            ID="lblBaoZhiQi" runat="server" Text=""></asp:Label>天</dd>
                    <%if (xhisbool == true)
                      { %>
                    <dd>
                        <strong>产品型号：</strong><asp:Label ID="lblXingHao" runat="server" Text=""></asp:Label></dd><%} %>
                    <%if (ysisbool == true)
                      { %>
                    <dd style="padding-left: 70px;">
                        <strong style="margin-left: -70px;">产品颜色：</strong>
                        <asp:Label ID="lblYanSe" runat="server" Text=""></asp:Label>
                    </dd>
                    <%} %>
                    <%if (ksisbool == true)
                      { %>
                    <dd>
                        <strong>产品款式：</strong><asp:Label ID="lblKuanShi" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;</dd><%} %>
                    <dd style="padding-bottom: 8px;">
                        <strong>类型：</strong><asp:Label ID="lblLeiXing" runat="server" Text=""></asp:Label></dd>
                    <dd style="padding-bottom: 8px;">
                        <strong>联系卖家：</strong><asp:Label ID="lblGYSNAME" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<strong>电话：</strong><asp:Label
                            ID="lblLXFS" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<strong>QQ：</strong><asp:Label
                                ID="lblQQ" runat="server" Text=""></asp:Label>
                    </dd>
                    <dd style="padding-top: 8px; border-top: #ccc dotted 1px; font-weight: bold;">
                        <img src="images/icon_h.gif" />
                        门市价：<asp:Label ID="lblMenShiJia" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <img src="/images/icon_y.gif" />
                        <font class="fontred">会员价：<asp:Label ID="lblHuiYuanJia" runat="server" Text=""></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:PlaceHolder ID="pla_ejdl" runat="server" Visible="false">
                            <img src="/images/icon_y.gif" />
                            <font class="fontred">代销价：<asp:Label ID="lblMFDL" runat="server" Text=""></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pla_gb" runat="server" Visible="false">
                            <img src="/images/icon_y.gif" />
                            <font class="fontred">贵宾价：<asp:Label ID="lblGuiBinJia" runat="server" Text=""></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pla_dl" runat="server" Visible="false">
                            <img src="/images/icon_y.gif" />
                            <font class="fontred">代理价：<asp:Label ID="lblDaiLiJia" runat="server" Text=""></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pla_yg" runat="server" Visible="false">
                            <img src="/images/icon_y.gif" />
                            <font class="fontred">员工价：<asp:Label ID="lblYuanGongJia" runat="server" Text=""></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                        </asp:PlaceHolder>
                    </dd>
                    <dd class="shopbox">
                        我要购买：<span class="dindan_num"><a class="jisuan" href="javascript:;">-</a><input type="text"
                            value="1" name="shuliang" id="shuliang" /><a class="jisuan" href="javascript:;">+</a></span>
                        库存数量：<asp:Label ID="lblKuCun" runat="server" Text=""></asp:Label></dd>
                    <dd class="margin_T10">
                        <table width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:PlaceHolder ID="planologin" runat="server"><strong class="font14">已是会员/贵宾/代理：</strong><a
                                            id="login_n" class="btn02_yellow" href="javascript:;">立即登录</a> </asp:PlaceHolder>
                                    </td>
                                    <td>
                                        <strong class="font14" id="stro" runat="server">非会员：</strong><a class="btn02_blue"
                                            href="javascript:;" id="GO">直接预订</a>
                                    </td>
                                    <td align="right">
                                        <asp:PlaceHolder ID="planologin1" runat="server"><a id="login_m" class="btn02_blue"
                                            href="javascript:;">立即注册</a> </asp:PlaceHolder>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </dd>
                </dl>
            </div>
        </div>
        <div id="div_tx" class="car_price mall_price margin_T10">
            <ul>
                <li class="mar5">
                    <asp:Literal ID="lit_hy" runat="server"></asp:Literal>
                </li>
                <li class="mar5">
                    <asp:Literal ID="lit_gb" runat="server"></asp:Literal>
                </li>
                <li>
                    <asp:Literal ID="lit_dl" runat="server"></asp:Literal>
                </li>
            </ul>
        </div>
        <div class="B_TabTitle margin_T10">
            <ul>
                <li class="tab_on"><a>产品介绍</a></li>
                <li><a href="#baohan">包括服务内容</a></li>
                <li><a href="#buhan">不含服务内容</a></li>
                <li><a href="#shiyong">使用方法</a></li>
                <li><a href="#zhuyi">注意事项</a></li>
                <li><a href="#youji">邮寄办法</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="mall_cont ">
            <div class="basiclist">
                <p>
                    <asp:Literal ID="litJieShao" runat="server"></asp:Literal></p>
            </div>
            <a name="baohan"></a>
            <div class="basiclist">
                <h4>
                    包括服务内容</h4>
                <p>
                    <asp:Literal ID="litBaoHan" runat="server"></asp:Literal></p>
            </div>
            <a name="buhan"></a>
            <div class="basiclist">
                <h4>
                    不含服务内容</h4>
                <p>
                    <asp:Literal ID="litBuBaoHan" runat="server"></asp:Literal></p>
            </div>
            <a name="shiyong"></a>
            <div class="basiclist">
                <h4>
                    使用方法</h4>
                <p>
                    <asp:Literal ID="litShiYong" runat="server"></asp:Literal></p>
            </div>
            <a name="zhuyi"></a>
            <div class="basiclist">
                <h4>
                    注意事项</h4>
                <p>
                    <asp:Literal ID="litZhuYi" runat="server"></asp:Literal></p>
            </div>
            <a name="youji"></a>
            <div class="basiclist">
                <h4>
                    邮寄办法</h4>
                <p>
                    <asp:Literal ID="litYouJi" runat="server"></asp:Literal></p>
            </div>
        </div>
        <uc1:ZhuCe ID="ZhuCe1" runat="server" />
        <!------guide-------->
    </div>

    <script type="text/javascript">
        $(function() {


            var api2 = $('#SwitchNav').switchable('#SwitchBigPic > a', { currentCls: 'on', circular: true, beforeSwitch: function(i, o) { if (o == 0) { $("#a_le").click(); } else if (o == oPic.find('li').length - 1) { $("#a_ri").click(); } } }).autoplay(3);

            var oPic = $('#SwitchNav');
            var oImg = oPic.find('li');
            var oLen = oImg.length;
            var oLi = oImg.width();
            var prev = $("#a_le");
            var next = $("#a_ri");

            oPic.width(oLen * 64); //计算总长度
            var iNow = 0;
            var iTimer = null;
            prev.click(function() {
                if (iNow > 0) {
                    iNow--;

                }
                ClickScroll();
            })
            next.click(function() {
                if (iNow < oLen - 5) {
                    iNow++
                }
                ClickScroll();
            })

            function ClickScroll() {

                oPic.animate({ left: -iNow * 64 })
            }

        })

        
 
      
 
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
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
