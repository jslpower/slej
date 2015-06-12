<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderEdit1.aspx.cs" Inherits="EyouSoft.Web.WebMaster.OrderEdit1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

</head>
<body style="background: #fff;">
    <form id="form1" runat="server">
    <div style="width: 800px; margin: 0px auto;" id="i_div_form">
        <table border="0" class="tchuang" style="width: 100%">
            <tr class="odd">
                <th height="25" align="right">
                    发团日期：
                </th>
                <td colspan="6" align="left" bgcolor="#E3F1FC">
                    <select id="txtFaBan" name="txtFaBan">
                        <asp:Literal ID="ltrFaBanOptions" runat="server"><option value="">暂无任何发班信息</option></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    成人数：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <input type="hidden" id="hidMemberId" name="hidMemberId" runat="server" />
                    <input name="txtChengRenShu" type="text" id="txtChengRenShu" runat="server" maxlength="3"
                        class="txt" style="width: 80px;" />
                    人
                </td>
                <th colspan="2" align="right">
                    儿童数：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <input name="txtErTongShu" type="text" id="txtErTongShu" runat="server" maxlength="3"
                        class="txt" style="width: 80px;" />
                    人
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                     <span class="fontred">*</span>联系人：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <input name="txtContact" runat="server" type="text" id="txtContact" value="" maxlength="10"
                        class="txt" style="width: 80px;" />
                </td>
                <th colspan="2" align="right">
                     <span class="fontred">*</span>联系手机：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <input name="txtContactTel" runat="server" type="text" id="txtContactTel" value=""
                        maxlength="15" class="txt" style="width: 80px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    合计金额：
                </th>
                <td colspan="6" align="left" bgcolor="#E3F1FC">
                    <span id="i_JinE"></span>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="center">
                    订单状态
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <select class="inputselect select" id="orderstatus" name="orderstatus">
                        <%=StrOrderStatus %>
                    </select>
                </td>
                <th colspan="2" align="right">
                    付款状态：
                </th>
                <td align="left" bgcolor="#E3F1FC">
                    <select class="inputselect select" id="sel_PayState" name="sel_PayState">
                        <%=StrPayState%>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="25" align="right">
                    备注：
                </th>
                <td colspan="6" align="left" bgcolor="#E3F1FC">
                    <textarea name="txtBeiZhu" id="txtBeiZhu" cols="65" rows="5" runat="server"></textarea>
                </td>
            </tr>
        </table>
        <div style="width: 100%; margin: 0px auto; height: 25px; margin-top: 20px;" class="odd">
            请填写游客信息：
        </div>
        <table border="0" class="tchuang" style="width: 100%; margin-top: 0px;" id="i_table_youke">
            <tr class="odd">
                <th height="25" align="center">
                    序号
                </th>
                <th align="center">
                    姓名
                </th>
                <th align="center">
                    性别
                </th>
                <th align="center">
                    类型
                </th>
                <th align="center">
                    证件类别
                </th>
                <th align="center">
                    证件号码
                </th>
                <th align="center">
                    联系方式
                </th>
                <th>
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rptYouKes">
                <ItemTemplate>
                    <tr class="tempRow odd">
                        <td height="25" align="center" class="index">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <input name="txtYouKeName" type="text" size="8" class="txt" value="<%#Eval("Name") %>" />
                        </td>
                        <td align="center">
                            <select name="txtYouKeGender">
                                <%#EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Gender), new string[] { "2" }), ((int)Eval("Gender")).ToString(), "", "请选择")%>
                            </select>
                        </td>
                        <td align="center">
                            <select name="txtYouKeLeiXing">
                                <%#EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.YouKeType)), ((int)Eval("LeiXing")).ToString(), "", "请选择")%>
                            </select>
                        </td>
                        <td align="center">
                            <select name="txtYouKeZhengJianLeiXing">
                                <%#EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.CardType), new string[] { "0" }), ((int)Eval("ZhengJianType")).ToString(), "", "请选择")%>
                            </select>
                        </td>
                        <td align="center">
                            <input type="text" name="txtYouKeZhengJianHao" class="txt" value="<%#Eval("ZhengJianCode") %>" />
                        </td>
                        <td align="center">
                            <input type="text" name="txtYouKeTelephone" class="txt" value="<%#Eval("Telephone") %>" />
                        </td>
                        <td>
                            <a href="javascript:void(0)" class="addbtn">添加</a> <a href="javascript:void(0)" class="delbtn">
                                删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmptyYouKe">
                <tr class="tempRow">
                    <td height="25" align="center" class="index">
                        1
                    </td>
                    <td align="center">
                        <input name="txtYouKeName" type="text" size="8" class="txt" />
                    </td>
                    <td align="center">
                        <select name="txtYouKeGender">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Gender),new string[]{"2"}),"","","请选择") %>
                        </select>
                    </td>
                    <td align="center">
                        <select name="txtYouKeLeiXing">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.YouKeType)), "", "", "请选择")%>
                        </select>
                    </td>
                    <td align="center">
                        <select name="txtYouKeZhengJianLeiXing">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.CardType),new string[]{"0"}), "", "", "请选择")%>
                        </select>
                    </td>
                    <td align="center">
                        <input type="text" name="txtYouKeZhengJianHao" class="txt" />
                    </td>
                    <td align="center">
                        <input type="text" name="txtYouKeTelephone" class="txt" />
                    </td>
                    <td>
                        <a href="javascript:void(0)" class="addbtn">添加</a> <a href="javascript:void(0)" class="delbtn">
                            删除</a>
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <table border="0" class="tchuang" style="width: 100%">
            <tr>
                <td height="35" colspan="7" align="center" class="tjbtn02">
                    <asp:Literal runat="server" ID="ltrOperatorHTML"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = parent;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            //计算金额
            heJi: function() {
                var _$option = $("#txtFaBan option:selected");
                var _crj = tableToolbar.getFloat(_$option.attr("i_crj"));
                var _etj = tableToolbar.getFloat(_$option.attr("i_etj"));
                var _crs = tableToolbar.getInt($("#<%=txtChengRenShu.ClientID %>").val());
                var _ets = tableToolbar.getInt($("#<%=txtErTongShu.ClientID %>").val());
                var _crJinE = tableToolbar.calculate(_crj, _crs, "*");
                var _etJinE = tableToolbar.calculate(_etj, _ets, "*");

                var _jinE = tableToolbar.calculate(_crJinE, _etJinE, "+");

                $("#i_JinE").html(_jinE);
            },
            //提交取消
            tiJiaoQuXiao: function(obj) {
                var _data = {
                    txtXianLuId: "<%=XianLuId %>",
                    hidMemberId: $.trim($("#<%=hidMemberId.ClientID %>").val())
                };
                if (!confirm("你确定要取消订单吗？")) return;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.ajax({
                    type: "POST", url: window.location.href + "&dotype=quxiao", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            parent.tableToolbar._showMsg(response.msg, function() { parent.location.href = parent.location.href });
                        } else {
                            parent.tableToolbar._showMsg(response.msg);
                            $(obj).bind("click", function() { iPage.tiJiaoQuXiao(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.tiJiaoQuXiao(obj); }).css({ "color": "" });
                    }
                });
            },
            //提交修改信息
            tiJiaoXiuGai: function(obj) {
                var _$option = $("#txtFaBan option:selected");
                var _crj = tableToolbar.getFloat(_$option.attr("i_crj"));
                var _etj = tableToolbar.getFloat(_$option.attr("i_etj"));
                var _crs = tableToolbar.getInt($("#<%=txtChengRenShu.ClientID %>").val());
                var _ets = tableToolbar.getInt($("#<%=txtErTongShu.ClientID %>").val());
                var _crJinE = tableToolbar.calculate(_crj, _crs, "*");
                var _etJinE = tableToolbar.calculate(_etj, _ets, "*");
                var orderstatus = tableToolbar.getInt($("#orderstatus").val());
                var sel_PayState = tableToolbar.getInt($("#sel_PayState").val());
                var _jinE = tableToolbar.calculate(_crJinE, _etJinE, "+");

                var _data = { txtCRS: _crs
                    , txtETS: _ets
                    , txtCRJ: _crj
                    , txtETJ: _etj
                    , txtJinE: _jinE
                    , txtTourId: _$option.val()
                    , txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID %>").val())
                    , txtContact: $.trim($("#<%=txtContact.ClientID %>").val())
                    , txtContactTel: $.trim($("#<%=txtContactTel.ClientID %>").val())
                    , txtYouKeName: []
                    , txtYouKeGender: []
                    , txtYouKeLeiXing: []
                    , txtYouKeZhengJianLeiXing: []
                    , txtYouKeZhengJianHao: []
                    , txtYouKeTelephone: []
                    , txtXianLuId: "<%=XianLuId %>"
                    , orderstatus: orderstatus
                    , sel_PayState: sel_PayState
                    , txtMem: $.trim($("#<%=hidMemberId.ClientID %>").val())
                };

                if (_data.txtCRS + _data.txtETS < 1) { alert("请填写正确的预订人数！"); return; }
                if (_data.txtBeiZhu.length > 255) { alert("备注内容不能超过255个字符！"); return; }
                if (_data.txtContact.length == 0) { alert("请填写联系人"); return false; }
                if (_data.txtContactTel.length == 0) { alert("请填写联系手机"); return false; }

                $("input[name='txtYouKeName']").each(function() { _data.txtYouKeName.push($.trim($(this).val())); });
                $("select[name='txtYouKeGender']").each(function() { _data.txtYouKeGender.push($.trim($(this).val())); });
                $("select[name='txtYouKeLeiXing']").each(function() { _data.txtYouKeLeiXing.push($.trim($(this).val())); });
                $("select[name='txtYouKeZhengJianLeiXing']").each(function() { _data.txtYouKeZhengJianLeiXing.push($.trim($(this).val())); });
                $("input[name='txtYouKeZhengJianHao']").each(function() { _data.txtYouKeZhengJianHao.push($.trim($(this).val())); });
                $("input[name='txtYouKeTelephone']").each(function() { _data.txtYouKeTelephone.push($.trim($(this).val())); });

                if (!confirm("你确定要提交修改吗？")) return;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.ajax({
                    type: "POST", url: window.location.href + "&dotype=xiugai", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            parent.tableToolbar._showMsg(response.msg, function() { parent.location.href = parent.location.href });
                        } else {
                            parent.tableToolbar._showMsg(response.msg);
                            $(obj).bind("click", function() { iPage.tiJiaoXiuGai(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.tiJiaoXiuGai(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#txtFaBan").change(function() { iPage.heJi(); });
            $("#txtChengRenShu").change(function() { iPage.heJi(); });
            $("#txtErTongShu").change(function() { iPage.heJi(); });
            $("#i_table_youke").autoAdd();

            $("#i_a_xiugai").click(function() { iPage.tiJiaoXiuGai(this) });
            $("#i_a_quxiao").click(function() { iPage.tiJiaoQuXiao(this) });
            iPage.heJi();
        });
    </script>

</body>
</html>
