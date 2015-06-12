<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="InterfaceDataList.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.InterfaceDataList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>景区管理</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/bt.min.js" type="text/javascript"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="left">
        <tbody>
            <tr>
                <td width="300" align="center">
                    <span style="display:inline-block; vertical-align:middle;">更新景区：</span><input type="checkbox" name="UpdateJQ" id="UpdateJQ" />  
                    &nbsp;<span style="display:inline-block;vertical-align:middle;">更新票：</span><input type="checkbox" name="UpdateP" id="UpdateP" />
                    &nbsp;&nbsp;&nbsp;<input type="button" onclick="instance.SaveToDB(this);" value="更新" />
                </td>
            </tr>
        </tbody>
    </table>
</body>

<script type="text/javascript">
    var instance = new PageSubmitForm();
    instance.SaveToDB = function(btn) {
        instance.SetButtonUnableClick(btn, '请稍候...');
        $.newAjax({
            type: "post",
            cache: false,
            url: '/webmaster/ScenicAndTicketManage/InterfaceDataList.aspx?submit=1',
            data: { UpdateJQ: $('#UpdateJQ').attr('checked'), UpdateP: $('#UpdateP').attr('checked') },
            async: true,
            dataType: "json",
            success: function(ret) {
                if (ret.result == "1") {
                    tableToolbar._showMsg(ret.msg, function() { parent.location.reload(); });
                }
                else {
                    tableToolbar._showMsg(ret.msg, function() { });
                }
                instance.SetButtonEnableClick(btn);
            },
            error: function() {
                tableToolbar._showMsg(tableToolbar.errorMsg);
            }
        });
    };
</script>

</html>
