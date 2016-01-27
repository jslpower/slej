<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShangCheng.ProductEdit"
    ValidateRequest="false" %>

<%@ Register Src="/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>产品名称
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtChanPinMingCheng" MaxLength="40" name="txtChanPinMingCheng" runat="server"
                        class="inputtext formsize180" valid="required" errmsg="请输入产品名称!"></asp:TextBox>(<span class="fred">最多20个字</span>)
                </td>
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>产品生产日期:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtShengChanRiQi" name="txtShengChanRiQi" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入生产日期!" OnClick="javascript:;WdatePicker()"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>上架到期时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtYouXiaoQi" name="txtYouXiaoQi" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入有效期!" OnClick="javascript:;WdatePicker()"></asp:TextBox>
                </td>
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>保质期:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtBaoZhiQi" name="txtBaoZhiQi" runat="server" class="inputtext formsize180" valid="required|isNumber" errmsg="请输入保质期!|请输入正确的保质期!"></asp:TextBox>天
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>类别:
                </th>
                <td bgcolor="#E3F1FC">
                    <select name="ddlLeiBie1" id="ddlLeiBie1" class="inputselect" valid="required" errmsg="请选择类别1!">
                        <option value="">请选择</option>
                    </select>
                    &nbsp;
                    <select name="ddlLeiBie2" id="ddlLeiBie2" valid="required" errmsg="请选择类别2!" class="inputselect">
                        <option value="-1">请选择</option>
                    </select>
                </td>
                <th width="110" height="30" align="center">
                    款式:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtKuanShi" name="txtKuanShi" runat="server" class="inputtext formsize180"></asp:TextBox><br />
                    [款式中间用逗号分隔,例如:款式1,款式2]
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                   型号:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtXingHao" name="txtYouXiaoQi" runat="server" class="inputtext formsize180" ></asp:TextBox><br />
                    [型号中间用逗号分隔,例如:型号1,型号2]
                </td>
                <th width="110" height="30" align="center">
                    颜色:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtYanSe" name="txtBaoZhiQi" runat="server" class="inputtext formsize180"></asp:TextBox><br />
                    [颜色中间用逗号分隔,例如:黑色,白色]
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>门市价:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtMenShiJia" name="txtMenShiJia" runat="server" class="inputtext formsize180" valid="required" errmsg="请输入门市价!"></asp:TextBox>元（如：<span class="fred">12或者12.5或者12.56</span>）
                    <br />
                   <%-- [会员价:<span id="hyj">0</span> &nbsp;贵宾价:<span id="gbj">0</span> &nbsp;代理价:<span id="dlj">0</span>]--%>
                </td>
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>供应价:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtYouHuiJia" name="txtYouHuiJia" runat="server" class="inputtext formsize180" valid="required" errmsg="请输入成本价!"></asp:TextBox>元（如：<span class="fred">12或者12.5或者12.56，注：给平台供应的结算价</span>）
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>数量:
                </th>
                <td bgcolor="#E3F1FC"  >
                    <asp:TextBox ID="txtShuLiang" name="txtMenShiJia" runat="server" class="inputtext formsize180" valid="required|isNumber" errmsg="请输入数量!|请输入正确的数量！"></asp:TextBox>件(个,吨等单位)
                </td>
                <th width="110" height="30" align="center">
                    单位:
                </th>
                <td bgcolor="#E3F1FC"  >
                    <asp:TextBox ID="txtDanWei" name="txtDanWei" runat="server" class="inputtext formsize180"></asp:TextBox>（如：<span class="fred">件</span>或<span class="fred">个</span>或<span class="fred">吨</span>等）
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>产品图片:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="UploadControl1" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="true" runat="server"  valid="required" errmsg="请上传图片!"/>（<span class="fred">可上传多张</span>）
                    <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    产品简介:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtChanPinJieShao" Height="60" name="txtChanPinJieShao"
                        runat="server" CssClass="inputtext formsize600 kingbox" MaxLength="100"></asp:TextBox>(<span class="fred">请使用40-60字简要描述</span>)
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    包括服务内容:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtBaoHanFW" Height="60" name="txtChanPinJieShao"
                        runat="server" CssClass="inputtext formsize600 kingbox"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    不包括服务内容:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtBuBaoHanFW" Height="60" name="txtBuBaoHanFW"
                        runat="server" CssClass="inputtext formsize600 kingbox"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    使用方法:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtShiYong" Height="60" name="txtShiYong" runat="server"
                        CssClass="inputtext formsize600 kingbox"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    注意事项:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtZhuYi" Height="60" name="txtShiYong" runat="server"
                        CssClass="inputtext formsize600 kingbox"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="110" height="30" align="center">
                    邮寄办法:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtYouJi" Height="60" name="txtShiYong" runat="server"
                        CssClass="inputtext formsize600 kingbox"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="4">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="right" class="tjbtn02">
                                    <a href="javascript:;" id="btn" align="center" hidefocus="true" style="text-align:center">保存</a>
                                </td>
                                <td width="96" height="40" align="left" class="tjbtn02" style="padding-left: 50px;">
                                    <a href="javascript:history.go(-1);" align="center" style="text-align:center">返回</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var pageData = {
            typeValue: '<%=SelctType %>',
            parm: { dotype: '<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>', id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>' },
            CheckForm: function() {
                return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            pageSave: function() {
                KEditer.sync();
                $.newAjax({
                    type: "post",
                    url: "ProductEdit.aspx?save=save&" + $.param(pageData.parm),
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/ShangCheng/ProductList.aspx'; });
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
            initType: function() {
                var getPid = '';
                $(selectChild).each(function() {
                    if ($(this).attr("tid") == pageData.typeValue) {
                        getPid = $(this).attr("pid");
                    }
                    if ($(this).attr("pid") == "0") {
                        $("#ddlLeiBie1").append("<option value='" + $(this).attr("tid") + "' data-pid='" + $(this).attr("pid") + "'>" + $(this).attr("tname") + "</option>");
                    }
                })//
                $("#ddlLeiBie1").change(function() {
                    var that = $(this);
                    $("#ddlLeiBie2").html("<option>请选择</option>");
                    $(selectChild).each(function() {
                        if ($(this).attr("pid") == that.val()) {
                            $("#ddlLeiBie2").append("<option value='" + $(this).attr("tid") + "' data-pid='" + that.val() + "'>" + $(this).attr("tname") + "</option>");
                        }
                    })//
                })//*
                if (pageData.typeValue != '') {
                    $("#ddlLeiBie1").find("[value=" + getPid + "]").attr("selected", true);
                    $(selectChild).each(function() {
                        if ($(this).attr("pid") == getPid) {
                            $("#ddlLeiBie2").append("<option value='" + $(this).attr("tid") + "' data-pid='" + getPid + "'>" + $(this).attr("tname") + "</option>");
                        }
                    });
                    $("#ddlLeiBie2").find("[value=" + pageData.typeValue + "]").attr("selected", true);
                }


            } 
        }
        $(function() {

            KEditer.init("<%=txtBaoHanFW.ClientID %>", { height: "280px", items: keSimple_HaveImage });
            KEditer.init("<%=txtBuBaoHanFW.ClientID %>", { height: "280px", items: keSimple_HaveImage });
            KEditer.init("<%=txtShiYong.ClientID %>", { height: "280px", items: keSimple_HaveImage });
            KEditer.init("<%=txtZhuYi.ClientID %>", { height: "280px", items: keSimple_HaveImage });
            KEditer.init("<%=txtYouJi.ClientID %>", { height: "280px", items: keSimple_HaveImage });

            pageData.initType();
            $("#btn").click(function() { if (pageData.CheckForm()) { pageData.pageSave() } })
 
        })
    </script>

</body>
</html>
