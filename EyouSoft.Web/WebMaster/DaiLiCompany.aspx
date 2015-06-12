<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaiLiCompany.aspx.cs" Inherits="EyouSoft.Web.WebMaster.DaiLiCompany" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
        <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    
    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>
    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="tableInfo" width="90%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
        <tr class="odd"><td colspan="2" style="font-size:24px; height:70px; font-weight:bolder;" align="center">我的店铺介绍 </td></tr>
            <tr class="odd">
                <th width="15%" height="30" align="right">
                    <span style="font-size:14px">我的店铺介绍:</span><%--<br /><span style="font-size:12px; color:Red;">(可上传图文并茂的店铺或单位介绍)</span>--%>
                </th>
                <td width="85%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="editText"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                            <td width="25%"> &nbsp;</td>
                                <td width="25%" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn" hidefocus="true" runat="server" >保存</a>
                                </td>
                                <td  width="25%" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:history.go(-1);">返回</a>
                                    </td>
                                    <td width="25%"> &nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <script type="text/javascript">
        $(document).ready(function() {
        $("#tableInfo").find(".editText").each(function() {
            KEditer.init($(this).attr("id"), {
            items: keSimple_HaveImage,
                height: $(this).attr("data-height") == undefined ? "400px" : $(this).attr("data-height"),
                width: $(this).attr("data-width") == undefined ? "640px" : $(this).attr("data-width")
            });
        });
         });
         $("#btn").click(function() {
         KEditer.sync();
             $.ajax({
                 type: "post",
                 cache: false,
                 url: "/WebMaster/DaiLiCompany.aspx?type=update",
                 dataType: "json",
                 data: $("#<%=form1.ClientID %>").serialize(), 
                 success: function(ret) {
                     if (ret.result == "1") {
                         alert(ret.msg);
                         parent.location.href = parent.location.href;
                     }
                     else {
                         alert(ret.msg);
                         parent.location.href = parent.location.href;
                     }
                 },
                 error: function() {
                     alert("保存失败，请重试！");
                     parent.location.href = parent.location.href;
                 }
             });
         });
    </script>
</body>
</html>
