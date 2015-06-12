<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/FrontFixed.Master" AutoEventWireup="true" CodeBehind="TuanGouTJ.aspx.cs" Inherits="EyouSoft.Web.TuanGouTJ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
<script type="text/javascript">
    var pageData = {
        CheckForm: function() {
            return ValiDatorForm.validator($("#tijiao").closest("form").get(0), "alert");
        },
        pageSave: function() {
            var province = document.getElementById('ddprovince')[document.getElementById('ddprovince').selectedIndex].text;
            var city = document.getElementById('ddlcity')[document.getElementById('ddlcity').selectedIndex].text;
            var qu = document.getElementById('ddlqu')[document.getElementById('ddlqu').selectedIndex].text;
            if (province == "--请选择--" || city == "--请选择--" || qu == "--请选择--") {
                tableToolbar._showMsg("请选择省市区");
                return false;
            }
            $("#<%=UserAddress.ClientID%>").val(province + city + qu);
            $.ajax({
                type: "post",
                url: "TuanGouTJ.aspx?save=save&",
                dataType: "json",
                data: $("#tijiao").closest("form").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        location.href = '/Member/TuanGouDingDan.aspx';
                    }
                    else {
                        tableToolbar._showMsg(ret.msg);
                    }

                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
        }, //
        initDDL: function() {
            pcToobar.init({
                pID: "#ddprovince",
                cID: "#ddlcity",
                xID: "#ddlqu",
                pSelect: "<%= pSelect%>",
                cSelect: "<%= cSelect%>",
                xSelect: "<%= xSelect%>",
                comID: '1'
            });
        } //保存数据
    }
        $(function() {
            pageData.initDDL();
            $("#tijiao").click(function() {

                if ($("#<%=txtShouJi.ClientID %>").val() == "") {
                    alert("手机号码必须填写");
                    return false;
                }
                else {
                    if (pageData.CheckForm) {
                        pageData.pageSave();
                    }
                }
            })
        })
    </script>
    <script type="text/javascript">
        $(function() {
            $("#<%=ChanPinShuLiang.ClientID%>").blur(function() {
                if ($('#<%=ChanPinShuLiang.ClientID%>').val() == "") { $('#<%=ChanPinShuLiang.ClientID%>').val("1"); }
                else {
                    var chanpnum = $('#<%=ChanPinShuLiang.ClientID%>').val();
                    $("#shuliang").html(chanpnum);
                    $("#zongjia").html(<%= jsj%>* chanpnum);
                    
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<form id="form1" runat="server">
    <div class="mainbox">
        <div class="n_title">
            > 促销秒杀</div>
        <div class="line_xx_box margin_T10">
            <div class="zhifu_box">
                <h3>
                    配送信息</h3>
                <ul class="fixed">
                    <li><span><font class="fontred">*</font>&nbsp;客人姓名：</span>
                        <asp:TextBox ID="txtShouHuoRen" runat="server" CssClass="input_bluebk formsize180"
                            valid="required" errmsg="请输入联系人!"></asp:TextBox>
                    </li>
                    <li><span><font class="fontred">*</font>&nbsp;客人手机：</span>
                        <asp:TextBox ID="txtShouJi" runat="server" CssClass="input_bluebk formsize180" valid="required|isMobile"
                            errmsg="请输入联系人手机|联系人手机错误!"></asp:TextBox></li>
                            <li><span><font class="fontred">*</font>&nbsp;数量：</span>
                        <asp:TextBox ID="ChanPinShuLiang" runat="server" Text="1" CssClass="input_bluebk formsize180" valid="isNumber"
                            errmsg="数量输入错误!"></asp:TextBox>最多可购买<asp:Literal ID="shengyushu" runat="server"></asp:Literal>份</li>
                    <li><span><font class="fontred">*</font>&nbsp;地址：</span>
                        <select id="ddprovince" name="ddprovince" valid="required" errmsg="请选择省份!">
                        </select>
                        <select id="ddlcity" name="ddlcity" valid="required" errmsg="请选择市区!">
                        </select>
                        <select id="ddlqu" name="ddlqu" valid="required" errmsg="请选择县区!">
                        </select>
                        <asp:TextBox ID="txtDiZhi" runat="server" CssClass="input_bluebk formsize180"></asp:TextBox></li>
                    <asp:HiddenField ID="hidaddid" runat="server" />
                    <asp:HiddenField ID="UserAddress" runat="server" />
                </ul>
                <asp:HiddenField ID="hidpid" runat="server" />
            </div>
            <div class="zhifu_box stepTable">
                <h3>
                    确认订单</h3>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            项目
                        </th>
                        <th width="120">
                            单价
                        </th>
                        <th width="120">
                            数量
                        </th>
                        <th width="120">
                            总价
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblChanPinMingCheng" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblChanPinJiaGe" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hidChanPinJiaGe" runat="server" />
                        </td>
                        <td align="center">
                         <span id="shuliang">1</span>
                            <input id="chanpinshu" type="hidden" />
                        </td>
                        <td align="center">
                        <span id="zongjia"><%= jsj%></span>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="zhifu_box fixed">
                <a href="javascript:window.history.go(-1);" class="fanhui_btn floatL">返回重新下单</a><a
                    id="tijiao" href="javascript:;" class="tijiao_btn floatR">提交订单 >></a></div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
