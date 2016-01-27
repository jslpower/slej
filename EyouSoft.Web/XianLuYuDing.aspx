<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="XianLuYuDing.aspx.cs" Inherits="EyouSoft.Web.XianLuYuDing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/Loading.js" type="text/javascript"></script>

    <script src="/JS/_tourDate.js" type="text/javascript"></script>

    <script type="text/javascript">
        var pageFunc = {
            CreateBox: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.url,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            }, //end
            callFunc: function(parm) {
                var data = { url: "/XianLuBox.aspx?" + $.param(parm), title: "预定", width: "930", height: "680" };
                pageFunc.CreateBox(data);
            }
        };
        $(function() {
            $("#Zutuan").click(function() {
                location.href = "/ZiZhuTuan.aspx" + location.search;
            });
            $("#login_a_buy").click(function() {
                var hbid = "";
                if ($("#hangban").length > 0) {
                    hbid = $("#hangban").val()
                }
                if ($("#GDhid").length > 0) {
                    hbid = $("#GDhid").val()
                }
                var par = { id: '<%=Request.QueryString["id"] %>', crs: $("#input_cr").val(), ets: $("#input_et").val(), tourid: $("#txtFaBan").val(), type: '<%=routeType%>', hangban: hbid };
                if (par.tourid == '' || par.tourid == 'undefined') {
                    alert('请选择发团日期');
                    return false;
                }
                $.ajax({
                    url: "/XianLuYuDing.aspx?islogin=1",
                    dataType: "json",
                    success: function(ret) {
                        if (ret.msg == "login") {
                            window.location.href = "/XianLuBox.aspx?" + $.param(par);
                        }
                        else {
                            window.location.href = "/YuDing.apsx?rurl=" + encodeURIComponent("/XianLuBox.aspx?" + $.param(par));
                        }
                    },
                    error: function() {
                        alert("数据错误！请刷新页面")
                        return false;
                    }
                })
            });
        })
    </script>

    <style type="text/css">
        .rilihead
        {
            height: 20px;
        }
        .fontgreen
        {
            color: #0e9500;
        }
        .font_yellow
        {
            color: #fe6600;
        }
        .fontblue
        {
            color: #2064c8;
        }
        .neiul dt
        {
            clear: both;
            line-height: 14px;
            width: 79px;
            margin: 0px;
            padding: 0px;
        }
        .txtr
        {
            text-align: right;
        }
        .hline
        {
            text-decoration: line-through;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="n_title">
        >
        <asp:Label ID="lblRouteType" runat="server" Text=""></asp:Label></div>
    <div class="line_xx_box margin_T10">
        <div class="line_xx_tit">
            <h1>
                <asp:Label ID="lblXLMC" runat="server" Text=""></asp:Label></h1>
            <div class="fenxiang">
                <!-- JiaThis Button BEGIN -->
                <div class="jiathis_style">
                    <a class="jiathis_button_qzone"></a><a class="jiathis_button_tsina"></a><a class="jiathis_button_tqq">
                    </a><a class="jiathis_button_weixin"></a><a class="jiathis_button_renren"></a><a
                        class="jiathis_button_xiaoyou"></a><a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis"
                            target="_blank"></a>
                </div>

                <script type="text/javascript" src="http://v3.jiathis.com/code_mini/jia.js" charset="utf-8"></script>

                <!-- JiaThis Button END -->
            </div>
        </div>
        <div class="line_xx_cont fixed">
            <div class="line_xx_left">
                <div class="line_xx_img">
                    <asp:Literal ID="litIMG" runat="server"></asp:Literal></div>
            </div>
            <div class="line_xx_right">
                <ul class="imgtext">
                    <li style="text-align: center;"><span class="zt-btn">参团价格</span><a href="javascript:;"
                        id="Zutuan" class="btn02_blue">单独组团报价</a></li>
                    <asp:Literal ID="litJGlevel" runat="server"></asp:Literal>
                    <li style="padding-left: 71px;"><strong style="margin-left: -71px; vertical-align: top;">
                        出发地： </strong>
                        <asp:Label ID="cfd" runat="server" Text=""></asp:Label></li>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                        <li><strong>
                            <asp:Literal ID="lit_Line" runat="server">航班/舱位：</asp:Literal></strong><select id="hangban"
                                name="hangban" style="width: 247px;">
                                <asp:Literal ID="litHangBan" runat="server"><option value="">暂无航班信息</option></asp:Literal>
                            </select>&nbsp;<font class="fontred">*</font></li>
                        <li style="padding-left: 71px;"><strong style="margin-left: -71px; vertical-align: top;">
                            当前选择：</strong><span class="hanban_txt"><asp:Literal ID="litSelectHB" runat="server"></asp:Literal></span></li>
                    </asp:PlaceHolder>
                    <li><strong>游玩日期：</strong>
                        <select id="txtFaBan" name="txtFaBan" style="width: 247px">
                            <asp:Literal ID="ltrFaBanOptions" runat="server"><option value="">暂无发班信息</option></asp:Literal>
                        </select>&nbsp;<font class="fontred">*</font></li>
                    <li><strong>送&nbsp;&nbsp;团&nbsp;&nbsp;人：</strong><asp:Label ID="lblsongtuan" runat="server"
                        Text=""></asp:Label></li>
                    <li><strong>集合地点：</strong><asp:Label ID="lbljihedi" runat="server" Text=""></asp:Label></li>
                    <li><strong>预定数量：</strong>成人<span class="dindan_num"><a class="js_min" href="javascript:;">-</a><input
                        id="input_cr" class="input_cr" type="text" value="1" /><a class="js_max" href="javascript:;">+</a></span>儿童<span
                            class="dindan_num"><a class="js_min" href="javascript:;">-</a><input id="input_et"
                                class="input_et" type="text" value="0" /><a class="js_max" href="javascript:;">+</a></span>&nbsp;<font
                                    class="fontred">*</font></li>
                    <asp:PlaceHolder ID="noLogin" runat="server">
                        <li class="paddR"><strong class="font14">已是会员/贵宾/代理：</strong><a id="login_a" href="javascript:;"
                            class="btn02_yellow">立即登录</a></li>
                        <li class="paddR"><strong class="font14">非会员：</strong><a id="buy_a" href="javascript:;"
                            class="btn02_blue">直接预订</a></li>
                        <li class="paddR"><a id="reg_a" href="javascript:;" class="btn02_blue">立即注册</a></li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="Login" runat="server">
                        <li class="paddR"><a id="login_a_buy" href="javascript:;" class="btn02_blue link01">
                            直接预订</a></li>
                    </asp:PlaceHolder>
                </ul>
                <div class="page_code" class="page_code" style="bottom: 6px; left: 10px;">
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
        <div class="line_xx_cont">
            <asp:PlaceHolder ID="pla_none" runat="server">
                <div class="car_price">
                    <ul>
                        <asp:Literal ID="litHuiYuan" runat="server"></asp:Literal>
                        <asp:Literal ID="litGuiBin" runat="server"></asp:Literal>
                        <asp:Literal ID="litDaiLi" runat="server"></asp:Literal>
                    </ul>
                </div>
            </asp:PlaceHolder>
        </div>
        <div class="line_xx_cont">
            <div class="calendar" id="calendar">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <th width="120">
                                出行日价格表
                            </th>
                            <th>
                                <span id="month"></span>月
                            </th>
                            <th width="10">
                            </th>
                            <th>
                                <span id="nextmonth"></span>月
                            </th>
                            <th width="200">
                                <a id="prev_month" href="javascript:;" class="jiantou_l"><em></em>上个月</a> <a id="next_month"
                                    href="javascript:;" class="jiantou_r"><em></em>下个月</a>
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="calendar_bar" id="rilil">
                                </div>
                            </td>
                            <td width="16">
                            </td>
                            <td colspan="2">
                                <div class="calendar_bar" id="rilir">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!------xingchen-------->
    <div class="xingchen">
        <div class="B_TabTitle">
            <ul>
                <li class="tab_on"><a href="javascript:;">行程详情</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="xingchenbox fixed">
            <ul>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="xingchenpic">
                                <img width="300" height="200" src="<%# Eval("FilePath")==null ? "/images/xingchen01.jpg" : Eval("FilePath")%>" />
                            </div>
                            <dl>
                                <dt>
                                    <img src="/images/xinchenl.jpg" />
                                    第<%# Container.ItemIndex+1 %>天
                                    <%# Eval("QuJian")%>
                                    <%--   <img src="/images/fj.jpg" />--%>
                                    <%# Eval("JiaoTong") %>
                                    住：<%# Eval("ZhuSu")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;餐：<%# Eval("YongCan") %></dt>
                                <dd>
                                    <%# getXcStr(lineSource, Eval("XingCheng"))%></dd>
                            </dl>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="xingchen">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="line_table">
            <tbody>
                <tr>
                    <th>
                        产品说明
                    </th>
                    <td>
                        <asp:Literal ID="litShuoMing" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="baoming"></a>报名须知
                    </th>
                    <td>
                        <asp:Literal ID="litBaoMing" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="baohan"></a>费用包含
                    </th>
                    <td>
                        <asp:Literal ID="litFeiYong" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="bubaohan"></a>费用不含
                    </th>
                    <td>
                        <asp:Literal ID="litBuBaoHan" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="etanpai"></a>儿童安排
                    </th>
                    <td>
                        <asp:Literal ID="litErTong" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th width="165">
                        <a id="gouwu"></a>购物站信息
                    </th>
                    <td>
                        <asp:Literal ID="litGouwu" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="zifei"></a>自费项目
                    </th>
                    <td>
                        <asp:Literal ID="litZiFei" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="wenxin"></a>温馨提示
                    </th>
                    <td>
                        <asp:Literal ID="litTiShi" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="zhuyi"></a>注意事项
                    </th>
                    <td>
                        <asp:Literal ID="litZhuYi" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="zengsong"></a>赠送项目
                    </th>
                    <td>
                        <asp:Literal ID="litZengSong" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a id="qitashi"></a>其他事项
                    </th>
                    <td>
                        <asp:Literal ID="litQiTa" runat="server"></asp:Literal>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="margin_T10" style="text-align: center;">
        <a target="_blank" href="/print/xingchengdan.aspx?routeid=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>"
            class="print_xc_btn">打印行程单 >></a>
    </div>
    <!------L_list-------->
    <div class="L_list line_list margin_T10 fixed">
        <div class="list_T">
            <h3>
                推荐线路</h3>
        </div>
        <div class="line_xx_list biank">
            <ul>
                <asp:Repeater ID="rptLeftList" runat="server">
                    <ItemTemplate>
                        <%# Container.ItemIndex % 2 == 0 ? string.Format("<li><a href='XianLuYuDing.aspx?id={0}&type={3}'>{1}</a><span class='price'><em>{2}</em>起</span></li>", Eval("XianLuId"), EyouSoft.Common.Utils.GetText(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString()), 20, true), Eval("SCJCR", "{0:F0}"), routeType) : ""%>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="line_xx_list">
            <ul>
                <asp:Repeater ID="rptRightList" runat="server">
                    <ItemTemplate>
                        <%# Container.ItemIndex % 2 != 0 ? string.Format("<li><a href='XianLuYuDing.aspx?id={0}&type={3}'>{1}</a><span class='price'><em>{2}</em>起</span></li>", Eval("XianLuId"), EyouSoft.Common.Utils.GetText(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString()), 20, true), Eval("SCJCR", "{0:F0}"), routeType) : ""%>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <asp:Label ID="GDSelect" runat="server" Text=""></asp:Label>
    <form id="form1" runat="server">
    </form>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Adv">

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

                $(".js_min").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    if (tableToolbar.getInt(getNum.val()) > 1) {
                        getNum.val(tableToolbar.getInt(getNum.val()) - 1);
                    } else {
                        getNum.val(0);
                    }
                    pageData.jiesuan();
                })
                $(".js_max").click(function() {
                    var getNum = $(this).parent().find("input").eq(0);
                    getNum.val(tableToolbar.getInt(getNum.val()) + 1);
                    pageData.jiesuan();
                })

            }, //end
            jiesuan: function() {
                var crs = tableToolbar.getInt($("#input_cr").val());
                var ets = tableToolbar.getInt($("#input_et").val());
                var crj = tableToolbar.getFloat($("#s_hycrj").html());
                var etj = tableToolbar.getFloat($("#s_hyetj").html());
                var scj = crs * crj + ets * etj;
                $("#hycrs,#gbcrs,#dlcrs").html(crs);
                $("#hyets,#gbets,#dlets").html(ets);
                var huiyuan = tableToolbar.getFloat($("#hycrj").html()) * crs + tableToolbar.getFloat($("#hyetj").html()) * ets;
                $("#hyzj").html(huiyuan)
                $("#hyyhj").html(scj - huiyuan);
                var guibin = tableToolbar.getFloat($("#gbcrj").html()) * crs + tableToolbar.getFloat($("#gbetj").html()) * ets;
                $("#gbzj").html(guibin)
                $("#gbyhj").html(scj - guibin);
                var daili = tableToolbar.getFloat($("#dlcrj").html()) * crs + tableToolbar.getFloat($("#dletj").html()) * ets;
                $("#dlzj").html(daili);
                $("#dlyhj").html(scj - daili);

            }, //end

            initRiLiUl: function() {
                for (var i = 0; i < dataBox.length; i++) {
                    $("#" + dataBox[i].ldate).attr("data-tid", dataBox[i].tid).find(".calendar_box").append("<span class='fontblue'>门市：" + dataBox[i].msj + "</span><span class='font_yellow'>会员：" + dataBox[i].hyj + "</span><span class='fontgreen'>余位：" + dataBox[i].yw + "</span>");
                }
            }, //end
            clickFunc: function(obj) {
                $(".print_xc_btn").attr("href", '/print/xingchengdan.aspx?routeid=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>&tourid=' + $(obj).find("dl").attr("data-tid"));


                var url = window.location.pathname;
                var urlParms = tableToolbar.getUrlParms(["tid"]);
                urlParms["tid"] = $(obj).attr("data-tid");
                if (urlParms["tid"] == undefined)
                { return false; }
                window.location.href = tableToolbar.createUrl(url, urlParms);

                // $("#txtFaBan").find("option[value=" + $(obj).attr("data-tid") + "]").attr("selected", true);
            },
            initRLHTML: function() {
                if ('<%=EyouSoft.Common.Utils.GetQueryStringValue("tid") %>' != '') {
                    var riqi = $("#txtFaBan").find("option[value=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("tid") %>' + "]").attr("data-riqi");
                    tourdate.init(riqi);
                }
                else {
                    tourdate.init();
                }
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
            pageData.initRLHTML();
            pageData.initRiLiUl();
            pageData.initClick();
            pageData.jiesuan();
            $("#input_cr,#input_et").change(function() { pageData.jiesuan() });
            $("#login_a,#reg_a").click(function() { window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href) });
            $("#buy_a").click(function() {
                $.ajax({
                    url: "/XianLuYuDing.aspx?islogin=1",
                    dataType: "json",
                    success: function(ret) {
                        if (ret.msg == "1") {
                            window.location.href = window.location.href;
                        }
                        else {
                            window.location.href = '/YuDing.aspx?rurl=' + window.location.href;
                        }
                    }


                });

            });
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
