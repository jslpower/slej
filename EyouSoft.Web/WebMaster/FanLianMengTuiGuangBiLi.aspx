<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanLianMengTuiGuangBiLi.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.FanLianMengTuiGuangBiLi" MasterPageFile="~/WebMaster/default.Master" %>

<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist">
        <form id="form1" runat="server">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="table_fanlibili">
            <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
            <tr class="fanlibili_item">
                <td height="35" align="right" bgcolor="#e3f1fc" style="width: 200px;">
                    <b>返联盟推广返利比例档<span class="fanlibili_item_index" ><%#Container.ItemIndex + 1%></span>：</b>
                </td>
                <td bgcolor="#FAFDFF">
                    销售金额大于<input type="text" class="inputtext" maxlength="8" name="txtJinE" value="<%#Eval("JinE","{0:F2}") %>" />
                    返利比例为<input type="text" name="txtBiLi" class="inputtext" maxlength="8" value="<%#Eval("BiLi1","{0:F2}") %>" /><b>%</b>
                    
                    <a href="javascript:void(0)" class="i_tianjia">添加</a>
                    <a href="javascript:void(0)" class="i_shanchu">删除</a>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" border="0" align="center">
            <tr>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:void(0)" id="i_a_baocun">保存</a>
                </td>
            </tr>
        </table>
        </form>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            baoCun: function(obj) {
                if (!this.yanZhengForm()) return false;

                $(obj).unbind("click").css({ "color": "#999999" });
                $.ajax({
                    type: "POST", url: "fanlianmengtuiguangbili.aspx?&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(), cache: false, dataType: "json", async: false,
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
            },
            tianJia: function(obj) {
                if ($(".fanlibili_item").length == 4) {
                    alert("最多只能添加4档返利比例"); return false;
                }

                var _$tr = $(".fanlibili_item").eq(0).clone(true);
                _$tr.find("input[name='txtJinE']").val("").removeAttr("readonly").css({ "background": "" });
                _$tr.find("input[name='txtBiLi']").val("");

                $("#table_fanlibili").append(_$tr);
                this.sheZhiIndex();
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");

                if ($(".fanlibili_item").index(_$tr) == 0) { alert("该返联盟推广返利比例不可删除"); return false; }

                $(obj).closest("tr").remove();
                this.sheZhiIndex();
            },
            sheZhiIndex: function() {
                $(".fanlibili_item").each(function(i) {
                    $(this).find(".fanlibili_item_index").html(i + 1);
                });
            },
            yanZhengForm: function() {
                var _v1 = 0;
                $("input[name='txtBiLi']").each(function() {
                    var _txtBiLi = $.trim($(this).val());
                    var _biLi = parseFloat(_txtBiLi);
                    if (isNaN(_biLi)) { _v1 = -1; return false; }
                    if (_biLi <= 0) { _v1 = -2; return false; }
                    if (_biLi >= 100) { _v1 = -3; return false; }
                    if (_txtBiLi.indexOf(".") > -1 && _txtBiLi.split(".")[1].length > 2) { _v1 = -4; return false; }
                });

                if (_v1 == -1 || _v1 == -2 || _v1 == -3) { alert("请填写正确的返联盟推广返利比例(0-100)"); return false; }
                else if (_v1 == -4) { alert("请填写正确的返联盟推广返利比例(最多保留两位小数)"); return false; }

                var _v2 = 0;

                var _jinEItems = [];
                $("input[name='txtJinE']").each(function() {
                    var _txtJinE = $.trim($(this).val());
                    var _jinE = parseFloat(_txtJinE);
                    if (isNaN(_jinE)) { _v2 = -1; return false; }
                    if ($.inArray(_jinE.toFixed(2), _jinEItems) > -1) { _v2 = -2; return false; }

                    _jinEItems.push(_jinE.toFixed(2));
                });
                
                if (_v2 == -1) { alert("请填写正确的销售金额"); return false; }
                else if (_v2 == -2) { alert("销售金额不能有重复值"); return false; }

                return true;
            }
        };

        $(document).ready(function() {
            $("#i_a_baocun").click(function() { iPage.baoCun(this); });

            $(".i_tianjia").click(function() { iPage.tianJia(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });

            $("input[name = 'txtJinE']").eq(0).attr("readonly", "readonly").css({ "background": "#eee" });
        });
    </script>

</asp:Content>
