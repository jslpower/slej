<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.TatolProduct.ProductEdit"
    ValidateRequest="false" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品信息</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" runat="server">
    <table width="770" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;">
        <tr class="odd">
            <th width="120" height="45" align="right">
                <span style="color: red">*</span>产品名称：
            </th>
            <td width="280" align="left">
                <asp:TextBox ID="txtProductName" runat="server" Width="250px" CssClass="inputtext"
                    valid="required" errmsg="产品名称不能为空"></asp:TextBox>
            </td>
            <th width="50" align="center" rowspan="4">
                图片：<br />
                <br />
                最多<br />
                允许<br />
                上传<br />
                5 张
            </th>
            <td align="left" width="220" rowspan="4" valign="top">
                <uc1:UploadControl runat="server" ID="upload1" IsUploadMore="true" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp" />
            </td>
        </tr>
        <tr class="even">
            <th align="right" height="45">
                <span style="color: red">*</span>产品数量：
            </th>
            <td align="left">
                <asp:TextBox ID="txtNum" runat="server" CssClass="inputtext formsize50" valid="required|RegInteger"
                    errmsg="产品数量不能为空|请输入有效产品数量"></asp:TextBox>
                <asp:PlaceHolder runat="server" ID="plhExchangeNum" Visible="false">兑换数量：<asp:Literal
                    runat="server" ID="litExchangeNum"></asp:Literal></asp:PlaceHolder>
            </td>
        </tr>
        <tr class="odd">
            <th height="45" align="right">
                <span style="color: red">*</span>兑换积分：
            </th>
            <td align="left">
                <asp:TextBox ID="txtTotal" runat="server" CssClass="inputtext formsize50" valid="required|RegInteger"
                    errmsg="产品兑换积分不能为空|请输入有效产品兑换积分"></asp:TextBox>
            </td>
        </tr>
        <tr class="even">
            <th height="45" align="right">
                <span style="color: red">*</span>市场价：
            </th>
            <td align="left">
                <asp:TextBox ID="txtPrice" runat="server" CssClass="inputtext formsize50" valid="required|IsDecimalTwo"
                    errmsg="产品市场价不能为空|请输入有效产品市场价"></asp:TextBox>
            </td>
        </tr>
        <tr class="odd">
            <th align="center">
                内容：
            </th>
            <td colspan="3">
                <asp:TextBox ID="txtProductInfo" runat="server" TextMode="MultiLine" Columns="45"
                    Rows="6" CssClass="inputarea formsize600"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
            </td>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" class="save" id="btn" runat="server">保存</a>
            </td>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">
                    关闭</a>
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">

        var ObjPage = {
            PageInit: function() {
                //初始化编辑器
                KEditer.init("<%=this.txtProductInfo.ClientID%>", {
                    resizeMode: 0,
                    items: keSimple,
                    height: "200px",
                    width: "680px"
                });

                //初始化上传控件
                swfUploadHandler.init({
                    movies: [window["<%=upload1.ClientID %>"]],
                    startFn: function() { },
                    completeFn: function() {
                        var url = "/WebMaster/TatolProduct/ProductEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                        ObjPage.GoAjax(url);
                    }
                });


                $("#<%=btn.ClientID %>").click(function() {
                    if (!ObjPage.CheckForm()) {
                        return false;
                    }
                    //编辑器
                    KEditer.sync();

                    //上传控件
                    var swfFile = window["<%=upload1.ClientID %>"];
                    if (swfFile != null && swfFile.getStats().files_queued > 0) {
                        swfFile.startUpload();
                        return false;
                    }
                    var url = "/WebMaster/TatolProduct/ProductEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    ObjPage.GoAjax(url);
                });
            },
            GoAjax: function(url) {
                ObjPage.UnBind();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
                            ObjPage.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        ObjPage.Bind();
                    }
                });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "parent");
            },
            Bind: function() {
                var _selfs = $("#<%=this.btn.ClientID %>");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (!ObjPage.CheckForm()) {
                        return false;
                    }
                    var url = "/WebMaster/TatolProduct/ProductEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    ObjPage.GoAjax(url);
                    return false;
                });
            },
            UnBind: function() {
                $("#<%=this.btn.ClientID %>").html("提交中...");
                $("#<%=this.btn.ClientID %>").unbind("click");
            }
        };

        $(function() {
            ObjPage.PageInit();
            $(".upload_y_ul").css("width","200px");
        });
    
    </script>

</body>
</html>
