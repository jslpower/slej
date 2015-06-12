<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setRouteState.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.setRouteState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增</title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4"
            align="center">
            <tbody>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc" width="40%">
                        <span style="color: Red; font-size: 12px;">*</span><strong>设置线路状态：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <select name="selectZT" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.XianLuZT)), "")%>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4"
            align="center">
            <tr>
                <td height="30" align="center">
                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn_save">保存</a>
                                </td>
                                <td height="40" align="center" class="tjbtn02">
                                    <a href="javascript:window.history.go(-1);">返回</a>
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
            ids: '<%=EyouSoft.Common.Utils.GetQueryStringValue("ids") %>'
        }
        $("#btn_save").click(function() {
            $.ajax({
                type: "post",
                url: "/WebMaster/setRouteState.aspx?save=save&ids=" + pageData.ids,
                dataType: "json",
                data: $(this).closest("form").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.href = "/WebMaster/Routelist.aspx" });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg);
                    }

                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
        })
    </script>

</body>
</html>
