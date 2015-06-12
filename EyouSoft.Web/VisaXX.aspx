<%@ Page Title="签证详情页" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="VisaXX.aspx.cs" Inherits="EyouSoft.Web.VisaXX" %>

<%@ Register Src="UserControl/ZhuCe.ascx" TagName="ZhuCe" TagPrefix="uc1" %>
<%@ Register Src="UserControl/XianLu.ascx" TagName="XianLu" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <style>
        .car_price li
        {
            width: 273px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox fixed">
        <div class="leftbox">
            <!------searchbox-------->
            <uc1:Search runat="server" ID="Search1" />
            <!------L_list-------->
            <uc1:XianLu runat="server" ID="XianLu1" />
        </div>
        <div class="rightbox">
            <div class="n_title">
                > 出国签证</div>
            <div class="qzh_sider01 margin_T10">
                <div class="T">
                    代办<asp:Literal ID="VisaName" runat="server"></asp:Literal></div>
                <div class="qzh_MImg fixed">
                    <p class="leftimg">
                        <img src="<%= imgurl%>" /></p>
                    <div class="rightTxt">
                        <dl>
                            <dt>
                                <asp:Literal ID="QianZhengName" runat="server"></asp:Literal></dt>
                            <asp:Literal ID="JiaGeList" runat="server"></asp:Literal>
                            <dd>
                                办理时间：<asp:Literal ID="BanLiShiJian" runat="server"></asp:Literal>个工作日&nbsp;&nbsp;&nbsp;有效期：<asp:Literal
                                    ID="YouXiaoQi" runat="server"></asp:Literal>天&nbsp;&nbsp;&nbsp;最多停留：<asp:Literal
                                        ID="TingLiu" runat="server"></asp:Literal>天</dd>
                            <dd>
                                签证面试：<asp:Literal ID="MianShi" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;邀请函：<asp:Literal
                                    ID="YaoQing" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;所属领区：<asp:Literal ID="LingQu"
                                        runat="server"></asp:Literal></dd>
                            <dd>
                                受理范围：<asp:Literal ID="FanWei" runat="server"></asp:Literal></dd>
                        </dl>
                     
                    </div>
                </div>   
                <form  id="form1"  runat="server">
                  <div id="istijiao" class="yuding_msg fixed">
                  <ul>
                    <li><strong>价格类型：<asp:Literal ID="LeiXing" runat="server"></asp:Literal></strong></li>
                    <li class="width50">
                      <label>预订日期：</label>
                      <span class="date_style formsize140"><input type="text" name="yudingtime" onfocus="WdatePicker()" id="yudingtime" />
                                        <a href="javascript:;" class="rili">
                                            <img src="images/rili.gif" /></a></span></li>
                    <li class="width50">
                      <label>签证数量：</label><input name="visanum" type="text" value="1" id="visanum" class="inputbk formsize60" valid="required|isNumber" errmsg="签证数量不能为空|签证数量必须为数字!"/>
                    </li>
                    <li class="width50">
                        <asp:Literal ID="FenxiaoJiaGe" runat="server"></asp:Literal>
                      <label>单价：</label><span class="font18 fontred">¥<em id="DanJiaGe"><asp:Literal ID="DanJia" runat="server"></asp:Literal></em></span>
                    </li>
                    <li class="width50">
                      <label>总价：</label><span class="font18 fontgreen">¥<em id="ZongjiaGe"><asp:Literal ID="Zongjia" runat="server"></asp:Literal></em></span>
                    </li>
                    <li class="width50">
                      <label>联系人：</label><input id="lxrname" name="lxrname" class="inputbk formsize140" type="text"  valid="required|isName"
                        errmsg="姓名不能为空|请正确填写姓名!"/>
                    </li>
                    <li class="width50">
                      <label>联系人手机：</label><input id="lxrmobile" name="lxrmobile" class="inputbk formsize140" type="text"  valid="required|isMobile" errmsg="请输入手机号码!|请输入正确的手机号码"/>
                    </li>
                    <li>
                      <label>备注：</label>
                      <textarea id="beizhu" name="beizhu" cols="20" rows="4" class="inputbk" style="width:513px;height:80px;"></textarea>
                    </li>
                    <li class="yd_btn">
                    <em style="padding-right:35px;" id="denglu"><a id="gotologin" class="btn02_yellow"><span>立即登录</span></a></em>
        <em style="padding-right:35px">
                    <a href="javascript:;" class="yudin_btn02" id="link01" data-id="1" ><span>确认预订</span></a></em><a href="javascript:;"  id="btnQuXiao" class="yudin_btn02" style="display:none"><span>返回编辑</span></a>
          <a href="/Lg.aspx" class="btn02_blue" id="zhuce"><span>立即注册</span></a>    <a href="#" style="text-decoration:underline; color:blue;margin-left:15px;">下载附件</a></li>
                  </ul>
                </div></form>
            </div>
            <% %>
            <div class="car_price margin_T10" id="visapricelist">
                <ul>
                    <li class="mar5">
                        <div class="tixing">
                            <b>会员价总金额：</b><br />
                            <font class="fontyellow"><b class="font14">
                                <%= huiyjia%></b>元/人 x <b class="font14">1</b>人 = </font><font class="fontblue"><b
                                    class="font14">
                                    <%= huiyjia%></b>元</font>
                        </div>
                    </li>
                    <li class="mar5">
                        <div class="tixing">
                            <b>
                                <asp:Literal ID="guibinname" runat="server"></asp:Literal>：</b><br />
                            <font class="fontyellow"><b class="font14">
                                <%= guibjia%></b>元/人 x <b class="font14">1</b>人 = </font><font class="fontblue"><b
                                    class="font14">
                                    <%= guibjia%></b>元</font>&nbsp;&nbsp;&nbsp;&nbsp;<%= guibinurl%><br />
                        </div>
                    </li>
                    <li>
                        <div class="tixing">
                            <b>
                                <asp:Literal ID="dailiname" runat="server"></asp:Literal>：</b><br />
                            <font class="fontyellow"><b class="font14">
                                <%= fenxjia%></b>元/人 x <b class="font14">1</b>人 = </font><font class="fontblue"><b
                                    class="font14">
                                    <%= fenxjia%></b>元</font>&nbsp;&nbsp;&nbsp;&nbsp; <%= dailiurl%><br />
                           </div>
                    </li>
                </ul>
            </div>
            <!------qzh_xxtab-------->
            <div class="xingchen qzh_xxtab">
                <div class="B_TabTitle">
                    <ul>
                        <li class="tab_on"><a href="javascript:;">所需材料</a></li>
                        <li><a href="#a1">特别提示</a></li>
                        <li><a href="#a2">注意事项</a></li>
                    </ul>
                    <%--<div class="timeTxt">
                        最后更新：2013-11-19</div>--%>
                </div>
                <div class="qzh_xxbox">
                    <!------qzh_basic-------->
                    <div class="qzh_basic">
                        <p>
                            <asp:Literal ID="Cailiao" runat="server"></asp:Literal></p>
                    </div>
                    <div class="qzh_basic">
                        <h4>
                            <a href="javascript:;" name="a1">特别提示</a></h4>
                        <p>
                            <asp:Literal ID="TiShi" runat="server"></asp:Literal></p>
                    </div>
                    <div class="qzh_basic">
                        <h4>
                            <a href="javascript:;" name="a2">注意事项</a></h4>
                        <p>
                            <asp:Literal ID="ZhuYi" runat="server"></asp:Literal></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc1:ZhuCe ID="ZhuCe1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<script type="text/javascript">

    $(function() {
    $("#visanum").blur(function() {
            if ($('#visanum').val() != "" && (/^(\+|-)?\d+$/.test($('#visanum').val()))) {
                var danjia = $('#DanJiaGe').html();
                var visanum = $('#visanum').val();
                $('#ZongjiaGe').html(danjia * visanum);
            }
            else {
                var danjia = $('#DanJiaGe').html();
                $('#visanum').val("1");
                $('#ZongjiaGe').html(danjia);
             }
        });
    });
</script>
    <script type="text/javascript">
var hyjia =<%= huiyjia%>;
var gbjia =<%= guibjia%>;
var fxjia =<%= fenxjia%>;
var inputdata = null;
var fanhuibianji = null;
var beizhuxinxi = null;
    var PageOrder = {
        CheckForm: function() {
            return ValiDatorForm.validator($("#link01").closest("form").get(0), "alert")
        },
        chengche: function(data) {
            if (PageOrder.CheckForm()) { PageOrder.subit(); }
        },
        Init: function() {
            var _m = iLogin.getM();
            if (!_m.isLogin) {
                $("#link01").click(function() {
                window.location.href = '/lg.aspx?rurl=' + encodeURIComponent(window.location.href);
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
        if ($('#link01').attr("data-id") == 1) {
                        inputdata = $("#link01").closest("form").serialize();
                        fanhuibianji = $("#istijiao").clone(true);
                        beizhuxinxi = $("#beizhu").val();
                        var elements = $("#link01").closest("form").find('input[type=text]');
                        PageOrder.RemoveControl(elements);
                        //textarea控件
                        elements = $("#link01").closest("form").find('textarea');
                        PageOrder.RemoveControl(elements);
                        $('span[class=date_style formsize140]').removeAttr("class");
                        $('a[class=rili]').remove();
                        $("#btnQuXiao").css('display', '');
                        $('#link01').attr("data-id", 2);
                    }
                    else {
         var url = '/VisaXX.aspx?visaid=<%= EyouSoft.Common.Utils.GetQueryStringValue("visaid")%>&dotype=save';
         $.newAjax({
                                   type: "post",
                                   cache: false,
                                   url: url,
                                   dataType: "json",
                                   data:inputdata,
                                   success: function(ret) {
                                       if (ret.result == "1") {
                                           tableToolbar._showMsg(ret.msg, function() { location.href = '/Member/VisaOrderList.aspx'; });
                                       }
                                       else {
                                           tableToolbar._showMsg(ret.msg);
                                       }
                                   },
                                   error: function() {
                                       tableToolbar._showMsg(tableToolbar.errorMsg);
                                   }
                               });
                               }
            },
            RemoveControl: function(elements) {
                var arrObj = new Array();
                var count = elements.length;
                for (var i = 0; i < count; i++) {
                    if (elements[i] == undefined)
                        continue;

                    var obj = document.createElement('span');
                    switch (elements[i].type) {
                        case "text":
                            obj.style.width = elements[i].style.width;
                            obj.className = "word_warpbreak";
                            obj.innerHTML = elements[i].value;
                            break;
                        case "textarea":
                            obj.style.width = elements[i].style.width;
                            obj.className = "word_warpbreak";
                            obj.innerHTML = elements[i].value;
                            break;
                        default:
                            for (var j = 0; j < elements[i].length; j++) {
                                if (elements[i][j].selected) {
                                    obj.style.width = elements[i].style.width;
                                    obj.className = "word_warpbreak";
                                    obj.innerHTML = elements[i][j].text;
                                    break;
                                }
                            }
                            elements[i].options.length = 0;
                            break;
                    }
                    elements[i].parentNode.appendChild(obj);
                    //删除表单控件
                    $("#" + elements[i].id + "").remove();
                }
            },
        Bind: function() {
        $("#btnQuXiao").click(function() { $("#<%=form1.ClientID %>").html(fanhuibianji); $("#beizhu").val(beizhuxinxi); })
            PageOrder.Init();
        },
        boxClick: function() { if (PageOrder.CheckForm()) { PageOrder.subit(); } }
    };
        $(function() {
            PageOrder.Bind();
        })

        function login(data) {
            $("#link01").click(function() {if (PageOrder.CheckForm()) { PageOrder.subit(); } });
        }
        
        
         $(function() {
        $("#visanum").blur(function() {
        var visacount = $("#visanum").val();
            var html ="<ul><li class=\"mar5\"><div class=\"tixing\"><b>会员价总金额：</b><br /><font class=\"fontyellow\"><b class=\"font14\">"+ hyjia+"</b>元/人 x <b class=\"font14\">"+visacount+"</b>人 = </font> <font class=\"fontblue\"><b class=\"font14\">"+ (hyjia*visacount) +"</b>元</font></div> </li><li class=\"mar5\"><div class=\"tixing\"><b>申请贵宾身份：</b><br /><font class=\"fontyellow\"><b class=\"font14\">"+gbjia+"</b>元/人 x <b class=\"font14\">"+visacount+"</b>人 = </font><font class=\"fontblue\"><b class=\"font14\">"+ (gbjia*visacount) +"</b>元</font>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"http://www.slej.cn/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">立省"+((hyjia-gbjia)*visacount)+"元</b> </div> </li><li><div class=\"tixing\"><b>申请代理身份：</b><br /><font class=\"fontyellow\"><b class=\"font14\">"+ fxjia+"</b>元/人 x <b class=\"font14\">"+visacount+"</b>人 = </font><font class=\"fontblue\"><b class=\"font14\">"+ (fxjia*visacount) +"</b>元</font>&nbsp;&nbsp;&nbsp;&nbsp; <a href=\"http://www.slej.cn/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\"><span>马上申请</span></a><br /><b class=\"fontblue\">"+((hyjia-fxjia)*visacount)+"元</b></div> </li></ul>";
            $("#visapricelist").html(html);
        });
    });
        
    </script>
    <script type="text/javascript">
        var pageBox = {
            CreatBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.url,
                    title: data.title,
                    modal: true,
                    width: '500px',
                    height: '300px'
                });
            }
        };
</script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
