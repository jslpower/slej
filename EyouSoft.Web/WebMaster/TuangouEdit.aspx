<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuangouEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.TuangouEdit" %>

<%@ Register Src="UserControl/SelectRoute.ascx" TagName="SelectRoute" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团购新增/修改</title>
    <link href="../Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="../Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <script src="../JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="../JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="../JS/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script src="../JS/swfupload/swfupload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>团购名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txttuangouname" runat="server" CssClass="inputtext formsize120"
                        valid="required" errmsg="请输入团购名称!"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>产品信息：
                </th>
                <td bgcolor="#E3F1FC">
                    <uc1:SelectRoute ID="SelectRoute1" runat="server" IsMust="true" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    团购图片：
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="UploadControl1" runat="server" IsUploadMore="false" IsUploadSelf="true" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp" />
                    <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    市场价:
                </th>
                <td bgcolor="#E3F1FC">
                    成人：<asp:TextBox runat="server" ID="txtSCCRPrice" CssClass="inputtext formsize120"></asp:TextBox>
                    儿童：<asp:TextBox runat="server" ID="txtSCETPrice" CssClass="inputtext formsize120"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    结算价:
                </th>
                <td bgcolor="#E3F1FC">
                    成人：<asp:TextBox runat="server" ID="txtJSCRPrice" CssClass="inputtext formsize120"></asp:TextBox>
                    儿童：<asp:TextBox runat="server" ID="txtJSETPrice" CssClass="inputtext formsize120"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    开始时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtStartTime" onfocus="WdatePicker()" CssClass="inputtext formsize120"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    结束时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtEndTime" onfocus="WdatePicker()" CssClass="inputtext formsize120"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    简要描述：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtDesc" TextMode="MultiLine" Height="90px" CssClass="inputtext formsize450"
                        runat="server"></asp:TextBox>
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
                                        <a id="btnsave" class="save" href="javascript:;">保存</a>
                                    </td>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnback" class="back" href="javascript:;">返回</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
$(function(){
    TuanGou.PageInit();
})
var TuanGou={
    PageInit:function(){
        $("#btnsave").click(function(){
             if (!TuanGou.CheckForm()) {
                  return false;
             }
             $(this).html("提交中");
              TuanGou.GoAjax('/WebMaster/TuanGouEdit.aspx?type=save&dotype='+'<%=Request.QueryString["dotype"] %>'+"&id="+'<%=Request.QueryString["id"] %>',$(this));
              return false;
        })
        $("#btnback").click(function(){
            location.href="/WebMaster/TuangouList.aspx";
            return false;
        })
    },
    GoAjax: function(url,obj) {
                $(obj).unbind("click");
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { parent.location.href = "/WebMaster/TuangouList.aspx"; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
       },
       CheckForm: function() {
            return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "alert");
       },
       DelFile: function(obj) {
            $(obj).parent().remove();
       },
       DelImg:function(obj){
         $(obj).parent().prev("img").remove();
         $(obj).parent().remove();
       }
}
</script>


