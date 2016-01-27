<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/FrontFixed.Master" AutoEventWireup="true"
    CodeBehind="TiJiaoXX.aspx.cs" Inherits="EyouSoft.Web.TiJiaoXX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript">
        var pageData = {
            CheckForm: function() {
                return ValiDatorForm.validator($("#tijiao").closest("form").get(0), "alert");
            },
            pageSave: function() {
                if (!pageData.CheckForm()) {

                    return false;
                }
                $.ajax({
                    type: "post",
                    url: "TiJiaoXX.aspx?save=save&",
                    dataType: "json",
                    data: $("#tijiao").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg("下单成功，请等待审核!");
                            location.href = '/Member/SCOrderList.aspx';
                        } else {
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
            }, //保存数据
            initJs: function() {
                var danjia = tableToolbar.getFloat($("#<%=hidChanPinJiaGe.ClientID %>").val());
                var shuliang = tableToolbar.getInt($("#shuliang").val());
                var zongjia = tableToolbar.getFloat(danjia * shuliang);
                $("#txtZJ").val(tableToolbar.getFloat(zongjia))
                $("#<%=lblDingDanZongJia.ClientID %>").html(zongjia);
            },
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
            }
        }
        $(function() {
            pageData.initClick();
            pageData.initDDL();
            $("#tijiao").click(function() {

                if ($("#<%=txtShouJi.ClientID %>").val() == "" && $("#<%=txtDianHua.ClientID %>").val() == "") {
                    alert("手机和电话必须填写一项");
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <div class="mainbox">
        <div class="n_title">
            > 会员商城</div>
        <div class="line_xx_box margin_T10">
            <div class="zhifu_box">
                <h3>
                    客户信息</h3>
                <ul class="fixed">
                    <li><span><font class="fontred">*</font>&nbsp;客户联系人：</span>
                        <asp:TextBox ID="txtShouHuoRen" runat="server" CssClass="input_bluebk formsize180"
                            valid="required" errmsg="请输入收货人!"></asp:TextBox>
                    </li>
                    <li><span><font class="fontred">*</font>&nbsp;手机：</span>
                        <asp:TextBox ID="txtShouJi" runat="server" CssClass="input_bluebk formsize180" valid="isMobile"
                            errmsg="手机号码错误!"></asp:TextBox></li>
                    <li><span>&nbsp;电话：</span>
                        <asp:TextBox ID="txtDianHua" runat="server" CssClass="input_bluebk formsize180" valid="isPhone"
                            errmsg="电话格式错误!"></asp:TextBox></li>
                    <li><span><font class="fontred">*</font>&nbsp;地址：</span>
                        <select id="ddprovince" name="ddprovince" valid="required" errmsg="请选择省份!">
                        </select>
                        <select id="ddlcity" name="ddlcity" valid="required" errmsg="请选择市区!">
                        </select>
                        <select id="ddlqu" name="ddlqu" valid="required" errmsg="请选择县区!">
                        </select>
                        <asp:TextBox ID="txtDiZhi" runat="server" CssClass="input_bluebk formsize180"></asp:TextBox></li>
                    <li><span>&nbsp;</span><label><input name="chkmr" type="checkbox" value="1" />
                        设置成默认收货地址</label></li>
                    <asp:HiddenField ID="hidaddid" runat="server" />
                </ul>
                <asp:HiddenField ID="hidpid" runat="server" />
                <asp:HiddenField ID="hidjsj" runat="server" />
                <asp:HiddenField ID="hidmsj" runat="server" />
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
                            <span class="dindan_num"><a class="jisuan" href="javascript:;">-</a><input type="text"
                                value="<%= EyouSoft.Common.Utils.GetQueryStringValue("num")%>" name="shuliang"
                                id="shuliang" /><a class="jisuan" href="javascript:;">+</a></span>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDingDanZongJia" runat="server" Text=""></asp:Label>
                            <input name="txtZJ" id="txtZJ" type="hidden" value="<%=lblDingDanZongJia.Text %>" />
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

    <script type="text/javascript">
    
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
