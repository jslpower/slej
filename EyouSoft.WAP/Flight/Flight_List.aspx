<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flight_List.aspx.cs" Inherits="EyouSoft.WAP.Flight.Flight_List" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title><%=FenXiangBiaoTi %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="航班选择" />
    <div class="warp">
        <div class="flight_date">
            <ul>
                <li class="yesterday L_jiantou<%=cssDisable %>">前一天</li>
                <li class="today"><span class="title">
                    <asp:Literal ID="litQuJian" runat="server">杭州 - 长沙</asp:Literal></span>
                    <p>
                        <asp:Literal ID="litCount" runat="server">1月1日 共1条</asp:Literal></p>
                </li>
                <li class="tomorrow R_jiantou">后一天</li>
            </ul>
        </div>
        <div class="flight_box">
            <asp:Repeater ID="rptlist" runat="server" OnItemDataBound="rptlist_ItemDataBound">
                <ItemTemplate>
                    <div class="flight_list">
                        <div class="flight_item">
                            <ul>
                                <li class="start">
                                    <div class="flight_jt">
                                        <span class="start_time">
                                            <%# Eval("QiFeiShiJian")%></span> <span class="flight_fx"><i class="flight_fx_ico"></i>
                                            </span>
                                    </div>
                                    <div>
                                        <%#Eval("ChuFaHangZhanLou")%>航站楼</div>
                                    <div>
                                        (<%# EyouSoft.Common.Utils.getCompanyName(Eval("HangKongGongSiErZiMa")) %>)<%#Eval("HangBanHao")%></div>
                                </li>
                                <li>
                                    <div>
                                        <span class="floatR"><em class="font_yellow">¥<%# getMinPrice(Eval("CangWeis"))%>起</em>+机/油：¥<%# getRJ( Eval("ranyoujine"),Eval("jijianjine")) %></span><%# Eval("DaoDaShiJian")%></div>
                                    <div>
                                        <span class="zhe floatR">
                                            <%# getMinZK(Eval("CangWeis"))%>折</span><%#Eval("DaoDaHangZhanLou")%>航站楼</div>
                                    <div>
                                        机型：<%#Eval("JiXing")%></div>
                                </li>
                            </ul>
                        </div>
                        <div class="down_jiantou">
                        </div>
                        <!----点击后down_jiantou-------->
                        <div class="flight_more" style="display: none;">
                            <asp:Literal ID="litJsonHB" runat="server"></asp:Literal>
                            <asp:Repeater ID="rptJiCang" runat="server">
                                <ItemTemplate>
                                    <div class="flight_detail">
                                        <ul>
                                            <li class="t1"><%# Eval("CangWeiTitle")%><%# Eval("CangWei")%>
                                                <span class="font_yellow">
                                                    <%# getZK(Eval("ZheKouLv"))%></span></li>
                                            <li><span class="floatR"><em class="font_yellow">¥<%# Eval("PiaoMianJiaGe","{0:f0}")%></em>+机/油：¥<%#Eval("FuJiaFei","{0:F0}")%></span>剩：<%#    Eval("CangWeiShu").ToString()=="A" ? "≥9" : Eval("CangWeiShu")%></li>
                                        </ul>
                                    </div>
                                    <%# Eval("YouHuiXinXi")%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
    <form id="form99" action="Flight_Buy.aspx" method="post" name="form99" visible="false">
    <input type="hidden" id="HBbox" name="HBbox" />
    <input type="hidden" id="JCbox" name="JCbox" />
    </form>

    <script type="text/javascript">
        var pageOpt = {
            dataPra: {
                s: '<%= EyouSoft.Common.Utils.GetQueryStringValue("s") %>',
                e: '<%= EyouSoft.Common.Utils.GetQueryStringValue("e") %>',
                st: '<%=st %>',
                et: '<%=et %>'
            },
            pageShow: function(obj) {
                $(obj).next().next().show();
                $(obj).next().attr("class", "up_jiantou")
                $(obj).bind("click", function() { pageOpt.pageHide(this) });
            },
            pageHide: function(obj) {
                var boolHide = $(obj).next(".flight_more").is(":hidden")
                $(obj).next().next().hide();
                $(obj).next().attr("class", "down_jiantou")
                $(obj).bind("click", function() { pageOpt.pageShow(this) });
            }
        }
        $(function() {
            $(".BtnLogin").click(function() { window.location.href = '/HuiYuanReg.aspx?rurl=' + encodeURIComponent(window.location.href); });
            //            $(".y_btn").click(function() {
            //                window.location.href = '/RegisterStep1.aspx?rurl=' + encodeURIComponent(window.location.href);
            //            });
            $(".flight_item").bind("click", function() { pageOpt.pageHide(this) })
            $(".flight_item").bind("click", function() { pageOpt.pageShow(this) })
            $(".yudingbtn").click(function() {
                if (!iLogin.getM().isLogin) {
                    window.location.href = "/Login.aspx?rurl=" + encodeURIComponent(location.href);
                    return false;
                }
                $("#HBbox").val($(this).parent().parent().find("span").eq(0).html());
                $("#JCbox").val($(this).attr("data-identity"));
                $("#form99").submit();
            })

            $(".tomorrow").click(function() {
                window.location.href = "/Flight/Flight_List.aspx?q=HuoQuHangBans&" + $.param({ s: pageOpt.dataPra.s, e: pageOpt.dataPra.e, t: pageOpt.dataPra.et });
            })
            $(".yesterday ").click(function() {
                window.location.href = "/Flight/Flight_List.aspx?q=HuoQuHangBans&" + $.param({ s: pageOpt.dataPra.s, e: pageOpt.dataPra.e, t: pageOpt.dataPra.st });
            })

        })
    </script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>

</body>
</html>
