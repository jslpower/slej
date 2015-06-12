<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaJiJiangLiJieSuan.aspx.cs"
    Inherits="EyouSoft.Web.Member.XiaJiJiangLiJieSuan" MasterPageFile="~/MasterPage/Front3.Master"
    Title="下级分销奖励结算申请-我的粉丝-会员中心" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">


<form id="form1" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 下级分销奖励结算申请</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> &gt; 下级分销奖励结算申请</span></div>
        <div class="user_Rbox margin_T10" style="padding-top: 10px;">
            <div class="R_title" style="margin-bottom: 10px; border-bottom: 0px;">
                <asp:Literal runat="server" ID="ltrJinEXinXi"></asp:Literal>
            </div>
            <table width="100%" border="0" style="padding-top: 50px;" class="tableList margin_T10">
                <tr style="height: 40px;">
                    <td width="25%" align="right">
                        结算下级分销奖励佣金金额：
                    </td>
                    <td width="75%">
                        <input type="text" class="inputbk formsize180" id="txtYongJinJinE"  runat="server" />
                    </td>
                </tr>
                <asp:HiddenField ID="KeTiQuJinE" runat="server" />
                <%--<tr style="height: 40px;">
                    <td align="right">
                        当前下级分销奖励结算比例：
                    </td>
                    <td width="75%">
                        <asp:Literal runat="server" ID="ltrBiLi"></asp:Literal>
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td align="right">
                        结算金额：
                    </td>
                    <td width="75%">
                        <span id="i_sapn_jine">0.00</span>
                    </td>
                </tr>--%>
            </table>
            
            <%--<div style="padding-top: 15px; padding-left: 300px;" class="u-btn tjbtn02">
                <a id="i_a_jiesuan" href="javascript:void(0)">申请结算 &gt;&gt;</a>
            </div>--%>
            <div class="u-btn" style="margin-bottom: 20px; padding-top: 10px; text-align:center;">
                <a class="u-01" href="javascript:void(0)" id="i_a_jiesuan">申请结算 &gt;&gt;</a>
                <a class="u-01" href="javascript:void(0)" id="i_a_fanhui">返回 &gt;&gt;</a>
            </div>
            
        </div>
    </div>
</form>

    <script src="/Js/menu_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            fanHui: function() {
            window.location.href = "FenSiJiangLi.aspx"; return false;
            },
            jieSuan: function(obj) {
                if (!this.yanZhengForm()) return false;
                var _data = { txtYongJinJinE: tableToolbar.getFloat($.trim($("#<%=txtYongJinJinE.ClientID %>").val()))};
                $(obj).unbind("click").css({ "color": "#999999" });

                $.ajax({
                    type: "POST", url: "XiaJiJiangLiJieSuan.aspx?&doType=jiesuan", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.fanHui();
                        } else {
                            $(obj).bind("click", function() { iPage.jieSuan(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.jieSuan(obj); }).css({ "color": "" });
                    }
                });
            },
            yanZhengForm: function() {
                var _yongJinJinE = tableToolbar.getFloat($.trim($("#<%=txtYongJinJinE.ClientID %>").val()));
                if (_yongJinJinE <= 0) { alert("请输入正确的结算下级分销奖励佣金金额"); return false; }
                var _weiJieSuanYongJinJinE = tableToolbar.getFloat($.trim($("#<%=KeTiQuJinE.ClientID %>").val())); ;
                if (typeof _weiJieSuanYongJinJinE == "undefined" || _weiJieSuanYongJinJinE =="") _weiJieSuanYongJinJinE = 0;
                if (_yongJinJinE > _weiJieSuanYongJinJinE) { alert("申请结算的下级分销奖励佣金金额(" + _yongJinJinE.toFixed(2) + ")不能大于未结算的下级分销奖励佣金金额(" + _weiJieSuanYongJinJinE.toFixed(2) + ")"); return false; }
                if (_yongJinJinE % 10 != 0) { alert("申请结算的下级分销奖励佣金金额只能是10的倍数"); return false; }

                return true;
            }
        };

        $(document).ready(function() {
            $(".left_menu ul li").menu();
            $("#i_a_jiesuan").click(function() { iPage.jieSuan(this); });
            $("#i_a_fanhui").click(function() { iPage.fanHui(this); });
        }); 
    </script>
</asp:Content>
