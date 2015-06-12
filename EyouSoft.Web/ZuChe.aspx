<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="ZuChe.aspx.cs" Inherits="EyouSoft.Web.ZuChe" %>

<%@ Register Src="UserControl/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ZuCheOrder2.ascx" TagName="ZuCheOrder" TagPrefix="uc1" %>
<%@ Register Src="UserControl/ZhuCe.ascx" TagName="ZhuCe" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/js/slogin.js"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
<script src="JS/ajaxpagecontrols.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <form id="form2" runat="server">
    <div class="n_title">
        > 汽车包租</div>
    <div class="line_xx_box car_box margin_T10"  style="background:#fff;">
        <uc1:ZuCheOrder ID="ZuCheOrder1" runat="server" />
        <div class="yd_btn">
        <em style="padding-right:35px;" id="denglu"><a id="gotologin" class="btn02_yellow"><span>立即登录</span></a></em>
        <em style="padding-right:35px"><a id="link01" class="yudin_btn02" href="javascript:void(0);"><span id="sp_Islogin">
                非会员直接预订 >></span></a></em>
          <a href="/Lg.aspx" class="btn02_blue" id="zhuce"><span>立即注册</span></a>      
                </div>
    </div>
    <uc1:ZhuCe ID="ZhuCe1" runat="server" />
    <div class="car_piclist margin_T10">
        <ul>
            <asp:Repeater ID="rpt_ZuChe" runat="server">
                <ItemTemplate>
                    <li><a href="/ZuCheXX.aspx?id=<%# Eval("ZuCheID") %>">
                        <%--<img src='<%# Eval("FilePath") %>' alt='<%# Eval("CarName") %>'>--%>
                        <%#IMGhtml(Eval("ZucheInfoImg"), Eval("CarName"))%>
                        <dl>
                            <dt>
                                <div class="car_tL">
                                    <p class="car_title">
                                        <%# Eval("CarName")%></p>
                                    <p>
                                        限坐人数：<b class="fontblue"><%# Eval("XianZuoRenShu")%></b>人</p>
                                </div>
                                <div class="car_tR font_yellow">
                                    1分钟计算<br />
                                    <em>租车费用</em></div>
                            </dt>
                            <dd class="car_cont">
                                <strong>相关介绍：</strong><%#  EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("Remark").ToString()), 60, true)%></dd>
                            <dd class="car_btn">
                                <span class="chakan_btn">查看>></span></dd>
                        </dl></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="page" id="page"></div>
    </form>
    
       <%-- <span>每页显示40条 共5322条信息，共200页</span><span class="disabled"> 上一页 </span><span class="current">
            1</span><a href="#?page=2">2</a><a href="#?page=3">3</a><a href="#?page=4">4</a><a
                href="#?page=5">5</a><a href="#?page=6">6</a><a href="#?page=7">7</a>...<a href="#?page=199">199</a><a
                    href="#?page=200">200</a><a href="#?page=2"> 下一页 </a>--%>
    
<script type="text/javascript">
        var pagingConfig = { pageSize: 10, pageIndex:<%=_pageIndex %> , recordCount: <%=_recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
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
            //                $("#txtChengCheTel").val($(data)[0].textfield1);
            //                $("#txtBeiZhu").val($(data)[0].textfield2);
            //                if (PageOrder.CheckForm()) { PageOrder.subit(); }
            //            },
            Init: function() {
                var _m = iLogin.getM();
                if (!_m.isLogin) {
                    $("#link01").click(function() {
                        window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href);
                        //                        var url = "/CommonPage/RegBox.aspx?callback=PageOrder.login";
                        //                        Boxy.iframeDialog({
                        //                            iframeUrl: url,
                        //                            title: "预订",
                        //                            modal: true,
                        //                            width: "680px",
                        //                            height: "380px"
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
                        //                        var url = "/ZuCheBox.aspx?callback=PageOrder.chengche";
                        //                        Boxy.iframeDialog({
                        //                            iframeUrl: url,
                        //                            title: "填写乘车人信息",
                        //                            modal: true,
                        //                            width: "680px",
                        //                            height: "250px"
                        //                        }); return false;
                        //                        if (PageOrder.CheckForm()) { PageOrder.subit(); }
                    });
                }
            },
            subit: function() {
                var mudicount = $(".tr-number").length;
                var zongdian;
                for (var zongnum = 0; zongnum < mudicount; zongnum++) {
                    zongdian = $("td[name=td-gongli]").find("input[name=txtlastPlace]").eq(zongnum).val();
                    if (zongdian != "请详细正确填写市县区和道路名称" && zongdian != "") {
                        if ($("td[name=td-gongli]").find("input[name=txtGongli]").eq(zongnum).val() == "0" || $("td[name=td-gongli]").find("input[name=txtGongli]").eq(zongnum).val()=="") {
                            tableToolbar._showMsg("第" + (zongnum + 1) + "目的地地址无法计算出两地距离，请重新选择地址");
                            return false;
                        }
                    }
                }

                $("#sp_Islogin").html("正在提交");
                $("#link01").unbind("click");
                var url = "/ZuChe.aspx?dotype=save";
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#link01").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = "/Member/ZuCheOrderList.aspx"; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                            $("#link01").bind("click");
                        }
                    },
                    error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                    $("#link01").bind("click");
                    }
                });
            },
            Bind: function() {
                PageOrder.Init();
            },
            boxClick: function() { if (PageOrder.CheckForm()) { PageOrder.subit(); } }
        };




        $(function() {
            PageOrder.Bind();
        })

        function login(data) {
            $("#sp_Islogin").html("直接预订");
            $("#link01").click(function() {
                if (PageOrder.CheckForm()) { PageOrder.subit(); }

            });
        }
    </script>

</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Adv">
</asp:Content>
