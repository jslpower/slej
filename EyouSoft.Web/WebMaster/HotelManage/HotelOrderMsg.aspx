<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrderMsg.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.HotelManage.HotelOrderMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" border="0" align="center" width="95%" style="margin-top: 20px;">
            <tbody>
                <tr>
                    <td align="center">
                        【<strong>添加回复</strong>】
                    </td>
                </tr>
            </tbody>
        </table>
        <table cellspacing="1" cellpadding="4" border="0" bgcolor="#B7D2F7" align="center"
            width="95%">
            <tbody>
                <tr class="odd">
                    <th width="80px" height="30" align="right">
                        <strong>联系人：</strong>
                    </th>
                    <td bgcolor="#FFFFFF" height="24">
                        <input type="text" value="" readonly="readonly" runat="server" id="txtLinkPerson"
                            name="txtLinkPerson">
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <strong>时间：</strong>
                    </th>
                    <td bgcolor="#FFFFFF" height="24">
                        <asp:TextBox ID="txtDate" runat="server" value="" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <strong>回复内容：</strong>
                    </th>
                    <td bgcolor="#FFFFFF" height="24">
                        <textarea rows="8" cols="40" id="txtContent" runat="server" name="txaContent" valid="required"
                            errmsg="回复内容不能为空"></textarea>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="95%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td height="10" align="center">
                    </td>
                </tr>
                <tr>
                    <td height="40" align="center">
                        <span class="tjbtn02"><a id="btn_save" href="javascript:;" runat="server">保存</a></span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            GoAjax: function(url) {
                pageOpt.UnBind();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn_save.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
                            pageOpt.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        pageOpt.Bind();
                    }
                });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn_save.ClientID %>").closest("form").get(0), "parent");
            },
            Bind: function() {
                var _selfs = $("#<%=this.btn_save.ClientID %>");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (!pageOpt.CheckForm()) {
                        return false;
                    }
                    var url = "/WebMaster/HotelManage/HotelOrderMsg.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    pageOpt.GoAjax(url);
                    return false;
                });
            },
            UnBind: function() {
                $("#<%=this.btn_save.ClientID %>").html("提交中...");
                $("#<%=this.btn_save.ClientID %>").unbind("click");
            }
        };

        $(function() {
            pageOpt.Bind();
        });
    
    </script>

</body>
</html>
