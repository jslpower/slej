<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuanGouEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.TuanGou.TuanGouEdit"
    ValidateRequest="false" %>

<%@ Register Src="../../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="120" height="30" align="center">
                    <span class="fred">*</span>产品名称:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtChanPinMingCheng" MaxLength="40" name="txtChanPinMingCheng" runat="server"
                        class="inputtext formsize180" valid="required" errmsg="请输入产品名称!"></asp:TextBox>(<span class="fred">最多20个字</span>)
                </td>
                <th width="120" height="30" align="center">
                    <span class="fred">*</span>促销类型:
                </th>
                <td bgcolor="#E3F1FC">
                    <select class="inputselect" name="ddlCxType" valid="required" errmsg="请选择促销类型!" style=" width:180px">
                        <%=EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.CuXiaoLeiXing)), CxType, true, "", "请选择")%>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>产品类型
                </th>
                <td bgcolor="#E3F1FC">
                    <select class="inputselect" name="ddlCpType" valid="required" errmsg="请选择产品!" style=" width:180px">
                        <%=EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.ChanPinLeiXing)), CpType, true, "", "请选择")%>
                    </select>
                </td>
                <th width="90" height="30" align="center">
                    <span class="fred">*</span> 数量:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtShuLiang" name="txtShuLiang" runat="server" class="inputtext formsize180"
                        valid="required|isInt" errmsg="请填写数量!|数量填写不正确！"></asp:TextBox>件(个,吨等单位)
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>市场价:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtShiChangJia" name="txtShiChangJia" runat="server" class="inputtext formsize180"
                        valid="required|isMoney" errmsg="请填写数量!|市场价格不正确不正确！"></asp:TextBox>（如：<span class="fred">12或者12.5或者12.56</span>）
                </td>
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>促销价(团购价):
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtCuXiaoJia" name="txtCuXiaoJia" runat="server" class="inputtext formsize180"
                        valid="required|isMoney" errmsg="请填写数量!|促销价格不正确！"></asp:TextBox>（如：<span class="fred">12或者12.5或者12.56</span>）
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    上架到期时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtYouXiaoQi" name="txtYouXiaoQi" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请填写有效期!" onclick="WdatePicker()"></asp:TextBox>（如：<span class="fred">2015-5-10</span>）
                </td>
                <th width="90" height="30" align="center">
                    产品图片:
                </th>
                <td bgcolor="#E3F1FC">
                    <uc1:UploadControl ID="upImg" runat="server" IsUploadMore="false" IsUploadSelf="true" />（<span class="fred">可上传多张</span>）
                    <asp:Label ID="lblFiles" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <%if (UserInfo.LeiXing != WebmasterUserType.代理商用户)
              { %>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>显示位置
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <select class="inputselect" name="ddlweizhi" valid="required" errmsg="请选择显示位置!">
                        <%=EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianShiWeiZhi)), CpWeiZhi, true, "", "请选择")%>
                    </select>
                </td>
            </tr>
            <%} %>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    产品排序
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox ID="txtSort" name="txtSort" runat="server" class="inputtext formsize180"
                        valid="isInt" errmsg="请填写正确的序号！"></asp:TextBox><span style=" color:Red;">(大于等于0)</span>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    简介:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtJieShao" Height="60" name="txtJieShao" runat="server"
                        CssClass="inputtext" Width="660px"></asp:TextBox>(<span class="fred">请使用40-60字简要描述</span>)
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    详细介绍:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtJieShaoXX" Height="250" name="txtJieShaoXX"
                        runat="server" CssClass="inputtext" Width="660px"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="4">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                        <tr>
                                    <td width="80" align="right" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btn" class="save" href="javascript:;" align="center" style="text-align:center">保存</a>
                                    </td>
                                    <td width="80" align="left" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnback"
                                            class="back" href="javascript:history.go(-1);" align="center"style="text-align:center">返回</a>
                                    </td>
                                </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <a target="_blank"></a>

    <script type="text/javascript">
        var pageData = {
            parm: { dotype: '<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>', id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>' },
            CheckForm: function() {
                return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
            },
            DelImg: function(obj) {
                $(obj).parent().remove();
            },
            pageSave: function() {
                KEditer.sync();
                $.newAjax({
                    type: "post",
                    url: "TuanGouEdit.aspx?save=save&" + $.param(pageData.parm),
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { window.parent.frames.mainFrame.location.href = '/WebMaster/TuanGou/TuanGouList.aspx?type=<%=EyouSoft.Common.Utils.GetQueryStringValue("otype") %>'; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }  //

        }
        $(function() {
            KEditer.init("<%=txtJieShaoXX.ClientID %>",{items: keSimple_HaveImage});
            $("#btn").click(function() { if (pageData.CheckForm()) { pageData.pageSave() } })

        })
    </script>

</body>
</html>
