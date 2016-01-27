<%@ Page Language="C#" MasterPageFile="~/WebMaster/default.Master" AutoEventWireup="true" CodeBehind="JiaoYiFeiLv.aspx.cs" Inherits="EyouSoft.Web.WebMaster.JiaoYiFeiLv" Title="无标题页" %>
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tr>
                <td height="35" align="right" bgcolor="#e3f1fc" style="width:40%;">
                    <span style="color: Red; font-size: 12px;">*</span><b>平台交易费率设置：</b>
                </td>
                <td  bgcolor="#FAFDFF">
                    <input type="text" id="txtJiaoYiFeiLv" runat="server" class="inputtext" maxlength="8" /><b>%</b>
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
                var _data = { txtJiaoYiFeiLv: parseFloat($.trim($("#<%=txtJiaoYiFeiLv.ClientID %>").val())) };
                if (isNaN(_data.txtJiaoYiFeiLv)) { alert("请填写正确的平台交易费率"); return false; }
                if (_data.txtJiaoYiFeiLv <= 0) { alert("请填写正确的平台交易费率"); return false; }
                if (_data.txtJiaoYiFeiLv >= 100) { alert("请填写正确的平台交易费率"); return false; }

                var txtJiaoYiFeiLv = $.trim($("#<%=txtJiaoYiFeiLv.ClientID %>").val())
                if (txtJiaoYiFeiLv.indexOf(".") > -1 && txtJiaoYiFeiLv.split(".")[1].length > 2) { alert("请填写正确的平台交易费率(最多保留两位小数)"); return false; }
                $(obj).unbind("click").css({ "color": "#999999" });
                $.ajax({
                    type: "POST", url: "JiaoYiFeiLv.aspx?&doType=baocun", data: _data, cache: false, dataType: "json", async: false,
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
