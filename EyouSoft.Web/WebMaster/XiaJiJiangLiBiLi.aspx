<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaJiJiangLiBiLi.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.XiaJiJiangLiBiLi" MasterPageFile="~/WebMaster/default.Master" %>

<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tr>
                <td height="35" align="right" bgcolor="#e3f1fc" style="width:40%;">
                    <span style="color: Red; font-size: 12px;">*</span><b>下级分销奖励佣金结算比例：</b>
                </td>
                <td  bgcolor="#FAFDFF">
                    <input type="text" id="txtJieSuanBiLi" runat="server" class="inputtext" maxlength="8" /><b>%</b>
                </td>
            </tr>
            
            <tr style="display:none">
                <td height="35" align="right" bgcolor="#e3f1fc" style="width:40%;">
                    <span style="color: Red; font-size: 12px;">*</span><b>下级分销奖励最小结算佣金：</b>
                </td>
                <td  bgcolor="#FAFDFF">
                    <input type="text" id="txtZuiXiaoJieSuanYongJinJinE" runat="server" class="inputtext" maxlength="8" />元
                </td>
            </tr>
        </table>
        
        <table cellspacing="0" cellpadding="0" width="100%" border="0" align="center">
            <tr>
                <td height="40" align="center" class="tjbtn02" >
                    <a href="javascript:void(0)" id="i_a_baocun">保存</a>
                </td>
            </tr>
        </table>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            baoCun: function(obj) {
                var _data = { txtJieSuanBiLi: parseFloat($.trim($("#<%=txtJieSuanBiLi.ClientID %>").val())), txtZuiXiaoJieSuanYongJinJinE: parseFloat($.trim($("#<%=txtZuiXiaoJieSuanYongJinJinE.ClientID %>").val())) };
                if (isNaN(_data.txtJieSuanBiLi)) { alert("请填写正确的下级分销奖励佣金结算比例"); return false; }
                if (_data.txtJieSuanBiLi <= 0) { alert("请填写正确的下级分销奖励佣金结算比例"); return false; }
                if (_data.txtJieSuanBiLi >= 100) { alert("请填写正确的下级分销奖励佣金结算比例"); return false; }

                var txtJieSuanBiLi = $.trim($("#<%=txtJieSuanBiLi.ClientID %>").val())
                if (txtJieSuanBiLi.indexOf(".") > -1 && txtJieSuanBiLi.split(".")[1].length > 2) { alert("请填写正确的下级分销奖励佣金结算比例(最多保留两位小数)"); return false; }
                if (isNaN(_data.txtZuiXiaoJieSuanYongJinJinE)) { alert("请填写正确的下级分销奖励最小结算佣金"); return false; }
                if (_data.txtZuiXiaoJieSuanYongJinJinE <= 0) { alert("请填写正确的下级分销奖励最小结算佣金"); return false; }
                if (_data.txtZuiXiaoJieSuanYongJinJinE % 100 != 0) { alert("下级分销奖励最小结算佣金只能是100的倍数"); return false; }
                $(obj).unbind("click").css({ "color": "#999999" });
                $.ajax({
                    type: "POST", url: "xiajijianglibili.aspx?&doType=baocun", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.reload();
                        } else {
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_baocun").click(function() { iPage.baoCun(this); });
        });
    </script>
</asp:Content>
