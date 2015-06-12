<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiXianEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MoneyManagement.TiXianEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <form id="form1">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">交易号：</td><td style="padding-left:10px">
        <asp:Literal ID="JiaoYiHao" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">提现用户：</td><td style="padding-left:10px">
        <asp:Literal ID="TiXianYongHu" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">提现金额：</td><td style="padding-left:10px">
        <asp:Literal ID="TiXianJinE" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">开户银行：</td><td style="padding-left:10px">
        <asp:Literal ID="KaiHuYinHang" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">开户姓名：</td><td style="padding-left:10px">
        <asp:Literal ID="KaiHuXingMing" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">银行卡号：</td><td style="padding-left:10px">
        <asp:Literal ID="YinHangKaHao" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">提现状态：</td><td style="padding-left:10px">
        <asp:Literal ID="TiXianZhuangTai" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">审核状态：</td><td style="padding-left:10px">
        <asp:Literal ID="ShenHeZhuangTai" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">提现时间：</td><td style="padding-left:10px">
        <asp:Literal ID="TiXianShiJian" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">提现备注：</td><td style="padding-left:10px">
        <asp:Literal ID="TiXianBeiZhu" runat="server"></asp:Literal></td></tr>
    <tr class="odd"><td width="15%" align="right" style="font-weight:bolder">审核备注：</td><td style="padding-left:10px">
    <textarea name="ShenHeBeiZhu" rows="4" cols="45" id="ShenHeBeiZhu" class="inputarea formsize600"></textarea></td></tr>
    </table>
    
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center">
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:;" id="btn" runat="server">保存</a>
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a id="linkCancel" href="javascript:history.go(-1);">返回</a>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <script type="text/javascript">
        $(function() {
            $("#btn").click(function() { AdvEdit.GoAjax(); });
        })
        var AdvEdit = {
        GoAjax: function() {
        var setState = '<%=Request.QueryString["setState"] %>';
        var tixianid = '<%=Request.QueryString["tixianid"] %>';
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/WebMaster/MoneyManagement/TiXianEdit.aspx?type=save&setState=" + setState+"&shenheid="+tixianid,
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/MoneyManagement/TiXianList.aspx'; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        }
    </script>
</body>
</html>
