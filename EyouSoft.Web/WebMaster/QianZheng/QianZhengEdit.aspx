<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QianZhengEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.QianZheng.QianZhengEdit" MasterPageFile="~/MasterPage/Webmaster.Master"
    Title="签证信息编辑" ValidateRequest="false" %>
<%@ Register Src="/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<asp:Content ContentPlaceHolderID="PageBody" runat="server" ID="PageBody1">
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th height="30" align="right" style="width: 90px">
                    <span class="fred">*</span>签证国家:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <input type="text" maxlength="30" id="txtGuoJiaName" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入签证国家!" />
                    <input type="hidden" id="txtGuoJiaId" runat="server" valid="required" errmsg="请输入签证国家!" />
                </td>
                <th align="right" style="width: 90px">
                    <span class="fred">*</span>签证名称:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtQianZhengName" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入签证名称!" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span class="fred">*</span>价格:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtJiaGe" runat="server" class="inputtext formsize180"
                        valid="required|isNumber" errmsg="请输入价格!|请输入正确的价格" />
                </td>
                <th align="right">
                    <span class="fred">*</span>门市价格:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtJiaGeMenShi" runat="server" class="inputtext formsize180"
                        valid="required|isNumber" errmsg="请输入门市价格!|请输入正确的门市价格" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span class="fred">*</span>办理时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtBanLiShiJian" runat="server" class="inputtext formsize180"
                        valid="required|RegInteger" errmsg="请输入办理时间!|请输入正确的办理时间!" />个工作日
                </td>
                <th align="right">
                    <span class="fred">*</span>有效期:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtYouXiaoQi" runat="server" class="inputtext formsize180"
                        valid="required|RegInteger" errmsg="请输入有效期!|请输入正确的有效期!" />天
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span class="fred">*</span>最多停留:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtTingLiuShiJian" runat="server" class="inputtext formsize180"
                        valid="required|RegInteger" errmsg="请输入最多停留天数!|请输入正确的最多停留天数!" />天
                </td>
                <th align="right">
                    <span class="fred">*</span>签证面试:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtMianShi" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入签证面试!" value="不需要" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span class="fred">*</span>邀请函:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtYaoQingHan" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入邀请函!" value="不需要" />
                </td>
                <th align="right">
                    <span class="fred">*</span>所属领区:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtSuoShuLingQu" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入所属领区!" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    受理范围:
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" maxlength="30" id="txtShouLiFanWei" runat="server" class="inputtext formsize180" />
                </td>
                <th align="right">
                    <span class="fred">*</span>签证类型:
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="txtQianZhengLeiXing" name="txtQianZhengLeiXing" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)),"","","请选择") %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    签证附件材料：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                <uc2:UploadControl ID="UploadControl1" FileTypes="*.txt;*.doc" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    所需材料：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtSuoXuCaiLiao" Height="150" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    特别提示：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtTeBieTiShi" Height="150" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    注意事项：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtZhuYiShiXiang" Height="150" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="40" bgcolor="#E3F1FC" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="i_a_submit" class="save" href="javascript:void(0)">保存</a>
                                    </td>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnback"
                                            class="back" href="javascript:history.go(-1);">返回</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="i_div_qianzhengguojia">
    </div>
    
    <br /><br />
    </form>

    <script type="text/javascript" src="/js/qianzheng.core.js"></script>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            redirect: function(url) {
                window.location.href = url;
                return false;
            },
            DelFile: function(obj) {
            $(obj).parent().remove();
        },
        DelImg: function(obj) {
            $(obj).parent().prev("img").remove();
            $(obj).parent().remove();
        },
            submit: function(obj) {
                KEditer.sync();
                var _vr = ValiDatorForm.validator($("#i_a_submit").closest("form").get(0), "alert");
                if (!_vr) return;
                $(obj).unbind("click");

                $.ajax({
                    type: "POST", url: "qianzhengedit.aspx?dotype=submit&qianzhengid=<%=QianZhengId %>", data: $("#<%=form1.ClientID %>").serialize(), cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.redirect("/webmaster/qianzheng/qianzheng.aspx");
                            return;
                        } else {
                            alert(response.msg);
                        }
                        iPage.reload();
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#txtQianZhengLeiXing").val("<%=QianZhengLeiXing %>");
            if ("<%=IsFenXiao %>" == "1") $("#txtIsFenXiao").attr("checked", "checked");

            $("#i_a_submit").click(function() { iPage.submit(this); });
            KEditer.init("<%=txtSuoXuCaiLiao.ClientID %>", { height: "280px", items: keSimple_HaveImage });
            KEditer.init("<%=txtTeBieTiShi.ClientID %>", { height: "280px", items: keSimple_HaveImage });
            KEditer.init("<%=txtZhuYiShiXiang.ClientID %>", { height: "280px", items: keSimple_HaveImage });

            qianZhengGuoJia.init({ txtName: '<%=txtGuoJiaName.ClientID %>', txtId: '<%=txtGuoJiaId.ClientID %>', left: 0, top: 4 });
        });
    </script>

</asp:Content>
