<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="ZuCheXX.aspx.cs" Inherits="EyouSoft.Web.ZuCheXX" %>
<%@ Register Src="UserControl/ZuCheOrder2.ascx" TagName="ZuCheOrder" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/js/slogin.js"></script>
        <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <form id="from1">
    <div class="n_title">
        > 汽车包租</div>
    <div class="line_xx_box car_box margin_T10 fixed"   style="position:relative;">
    
    <div class="page_code" style="bottom:81px; right:10px;">
               <div class="code_box">
                     <div class="code_small">
                                <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
                            <div class="code_big" style="display: none;">
                                <img src="/ErWeiMa.aspx?codeurl=<%=thisurl %>" /></div>
               </div>
               <p class="font_yellow">扫描二维码，分享手机版</p>
         </div>
        <div class="car_side">
            <div class="title">
                车辆品牌：<b class="font14 fontblue"><asp:Literal ID="ltrCarName" runat="server"></asp:Literal></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限座人数：<b
                    class="font14 fontblue"><asp:Literal ID="ltrXianZuo" runat="server"></asp:Literal>
                    座</b></div>
            <div class="car_xxbox">
                <div class="car_xxbox_img">
                    <asp:Literal ID="ltrImage" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <div class="car_xxbox">
            <div class="car_jishao">
                <b class="fontblue">车辆介绍：</b><asp:Literal ID="ltrRem" runat="server"></asp:Literal></div>
        </div>
        <uc1:ZuCheOrder ID="ZuCheOrder1" runat="server" />
        <%--<input id="txtChengCheName" type="hidden"  name="txtChengCheName"/>
        <input id="txtChengCheTel" type="hidden"  name="txtChengCheTel"/>
        <input id="txtBeiZhu" type="hidden"  name="txtBeiZhu"/>--%>
        <div class="yd_btn">
            <em style="padding-right:35px;" id="denglu"><a id="gotologin" class="btn02_yellow"><span>立即登录</span></a></em>
        <em style="padding-right:35px"><a id="link01" class="yudin_btn02" href="javascript:void(0);"><span id="sp_Islogin">
                非会员直接预订 >></span></a></em>
          <a href="/Lg.aspx" class="btn02_blue" id="zhuce"><span>立即注册</span></a>    
          </div>
    </div>
    </form>

    <script type="text/javascript">

        var PageOrder = {
        CheckForm: function() {
                return ValiDatorForm.validator($("#link01").closest("form").get(0), "alert")
            },
//            login: function() {
//                var url = "/ZuCheBox.aspx?callback=PageOrder.chengche";
//                Boxy.iframeDialog({
//                    iframeUrl: url,
//                    title: "填写乘车人信息",
//                    modal: true,
//                    width: "680px",
//                    height: "380px"
//                }); return false;
//            },
//            chengche: function(data) {
//                $("#txtChengCheName").val($(data)[0].textfield);
//                $("#txtChengCheTel").val($(data)[0].textfield);
//                $("#txtBeiZhu").val($(data)[0].textfield);
//                if (PageOrder.CheckForm()) { PageOrder.subit(); }
//            },
            Init: function() {
                var _m = iLogin.getM();
                if (!_m.isLogin) {
                    $("#link01").click(function() {
                    window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href);
//                        var url = "/CommonPage/RegBox.aspx?callback=login";
//                        Boxy.iframeDialog({
//                            iframeUrl: url,
//                            title: "预订",
//                            modal: true,
//                            width: "680px",
//                            height: "380px",
//                        }); return false;
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
//                    $("#sp_Islogin").html("直接预订");
//                    $("#link01").click(function() {
//                        var url = "/ZuCheBox.aspx?callback=PageOrder.chengche";
//                        Boxy.iframeDialog({
//                            iframeUrl: url,
//                            title: "填写乘车人信息",
//                            modal: true,
//                            width: "680px",
//                            height: "250px"
//                        }); return false;
//                        //                        if (PageOrder.CheckForm()) { PageOrder.subit(); }
//                    });
                }
            },
            subit: function() {
                var url = "/ZuCheXX.aspx?dotype=save&id=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>';
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#link01").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
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
            Bind: function() {
                PageOrder.Init();
            },
            boxClick: function() { if (PageOrder.CheckForm()) { PageOrder.subit(); } }
        };




        $(function() {
        $(".mainbox").css("overflow", "visible");
            PageOrder.Bind();
        })

        function login(data) {
            $("#sp_Islogin").html("直接预订");
            $("#link01").click(function() {
                if (PageOrder.CheckForm()) { PageOrder.subit(); }

            });
        }
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
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Adv">
</asp:Content>
