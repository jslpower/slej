<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="TuanGouXX.aspx.cs" Inherits="EyouSoft.Web.TuanGouXX" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
//var intDiff = parseInt(5);//倒计时总秒数量
function timer1(intDiff) {
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
        else {
            $('#QGimg').removeClass().addClass("tg_ydbtn tg_ydbtn01");  
            $('#QGimg').html("<a>已结束</a>");
         }
        if (minute <= 9) minute = '0' + minute;
        if (second <= 9) second = '0' + second;
        $('#day_show').html(day);
        $('#hour_show').html('<s id="h"></s>' + hour);
        $('#minute_show').html('<s></s>' + minute);
        $('#second_show').html('<s></s>' + second);
        intDiff--;
    }, 1000);
}
$(function() {
var intDiff = parseInt(<%= TotalSeconds%>);//倒计时总秒数量
    timer1(intDiff);
}); 
    </script>

    <script type="text/javascript" src="/js/slogin.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
      <div class="mainbox">
            <div class="n_title">
                > 团购
            </div>
            <!------tg_side01-------->
            <div class="tg_side01 margin_T10"  style="position:relative;">
            
            <div class="page_code" style="bottom:84px; right:20px;">
                        <div class="code_box">
                            <div class="code_small">
                                <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                            <div class="code_big" style="display: none;">
                                <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                        </div>
                        <p class="font_yellow">
                            扫描二维码，分享手机版</p>
               </div>
            
                <asp:Literal ID="ProductImg" runat="server"></asp:Literal>
                <dl>
                    <dt>
                        <asp:Literal ID="ProductName" runat="server"></asp:Literal></dt>
                    <dd class="cont">
                        <asp:Literal ID="jianjie" runat="server"></asp:Literal></dd>
                    <dd class="btn">
                        <span class="tg_pricebtn"><s>¥
                            <asp:Literal ID="yuanjia" runat="server"></asp:Literal></s> <em><i>¥ </i>
                                <asp:Literal ID="qianggoujia" runat="server"></asp:Literal></em></span>
                        <asp:Literal ID="ydbtn" runat="server"></asp:Literal>
                    </dd>
                    <dd style="text-align: center;">
                        <asp:Literal ID="goumaishu" runat="server"></asp:Literal>
                        剩余 <b class="fontgreen font16">
                            <asp:Literal ID="shengyushu" runat="server"></asp:Literal></b></dd>
                    <dd style="text-align: center;">
                        剩余时间：<b class="fontblue font16" id="day_show">0</b> 天 <b class="fontblue font16"
                            id="hour_show">0</b> 时 <b class="fontblue font16" id="minute_show">00</b> 分
                        <b class="fontblue font16" id="second_show">00</b> 秒</dd>
                </dl>
            </div>
            <div class="tg_paixu margin_T10">
                使用有效期： 即日起 到
                <asp:Literal ID="ProductTime" runat="server"></asp:Literal></div>
            <div class="tg_cont margin_T10">
                <div class="tg_xxt">
                    <span>产品介绍</span></div>
                <div class="tg_txt">
                    <p>
                        <asp:Literal ID="jieshao" runat="server"></asp:Literal></p>
                </div>
            </div>
        <%--<div class="n_rightbox">
            <!------L_side01-------->
            <div class="L_side01">
                <uc1:TuanGou runat="server" ID="TuanGou1" />
            </div>
        </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">

    <script type="text/javascript">
        var PageOrder = {
            Init: function() {
                var _m = iLogin.getM();
                if (!_m.isLogin) {
                    $("#QGbtn").click(function() {
                    window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href);
//                        var url = "/CommonPage/RegBox.aspx?callback=PageOrder.subit";
//                        Boxy.iframeDialog({
//                            iframeUrl: url,
//                            title: "预订",
//                            modal: true,
//                            width: "680px",
//                            height: "380px"
//                        }); return false;
                    });
                }
                else {
                    $("#QGbtn").click(function() {
                        PageOrder.subit();
                    });
                }
            },
            subit: function() {
            window.location.href = '/TuanGouTJ.aspx?id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>';
//                var url = '/TuanGouXX.aspx?dotype=gotourl&id=<%= EyouSoft.Common.Utils.GetQueryStringValue("id")%>';
//                $.newAjax({
//                    type: "post",
//                    cache: false,
//                    url: url,
//                    dataType: "json",
//                    success: function(ret) {
//                    if (ret.result == "1") {
//                        window.location.href = '/TuanGouTJ.aspx?id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>';
////                            tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
//                        }
//                        else {
//                            window.location.href = "/lg.aspx?rurl=" + window.location.href;
////                            tableToolbar._showMsg(ret.msg);
//                        }
//                    },
//                    error: function() {
//                        tableToolbar._showMsg(tableToolbar.errorMsg);
//                    }
//                });
            },
            Bind: function() {
                PageOrder.Init();
            },
            boxClick: function() { PageOrder.subit(); }
        };




        $(function() {
            PageOrder.Bind();
        })

        function login(data) {
            $("#QGbtn").click(function() { PageOrder.subit(); });
        }
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
