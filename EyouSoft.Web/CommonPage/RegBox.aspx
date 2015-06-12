<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegBox.aspx.cs" Inherits="EyouSoft.Web.CommonPage.RegBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Css/style.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/slogin.js"></script>

    <style>
        .tc_inputbk
        {
            height: 23px;
            line-height: 23px;
        }
    </style>
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.boxy.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $("#link01").click(function() {
                var url = "jinqu_boxy.html";
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "预订",
                    modal: true,
                    width: "930px",
                    height: "650px"
                });
                return false;
            });
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="520" border="0" align="center" cellpadding="0" cellspacing="0" class="font14"
        style="margin: 15px auto;">
        <tr>
            <th height="40" colspan="2" align="left" class="boder_bot">
                请填写预订人信息：
            </th>
        </tr>
        <tr>
            <td height="40" colspan="2" align="right">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="210" height="40" align="right">
                预订人姓名：
            </td>
            <td>
                <input name="txtYuDName" type="text" id="txtYuDName" size="15" class="tc_inputbk formsize180"
                    valid="required|isName" errmsg="预定人姓名不能为空!|请填写正确的姓名,不能有数字!" />
            </td>
        </tr>
        <tr>
            <td height="40" align="right">
                预订人手机：
            </td>
            <td>
                <input name="txtYuDTel" type="text" id="txtYuDTel" size="15" class="tc_inputbk formsize180"
                    valid="required|isMobile" errmsg="请输入手机号码!|手机号码有误" />
            </td>
        </tr>
        <tr>
            <td height="40" align="right">
                输入验证码：
            </td>
            <td>
                <input name="txtCode" type="text" id="txtCode" size="15" class="tc_inputbk formsize80" />
                <a id="i_a_huoquyanzhengma" href="javascript:void(0);" class="code">获取验证码</a>
            </td>
        </tr>
        <tr>
            <td height="40" colspan="2" class="boder_bot">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="90%" border="0" style="margin: 15px auto;">
        <tr>
            <td align="center" class="tjbtn02">
                <a href="javascript:void(0);" id="i_a_xiayibu">下一步 >></a>
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">
        var Register = {
            close: function() {
                top.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            callFunc: function() {
                var data = { id: '<%=Request.QueryString["id"] %>', crs: '<%=Request.QueryString["crs"] %>', ets: '<%=Request.QueryString["ets"] %>', riqi: '<%=Request.QueryString["riqi"] %>', tourid: '<%=Request.QueryString["tourid"] %>', type: '<%=Request.QueryString["type"] %>', regboxid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>', hangban: '<%=EyouSoft.Common.Utils.GetQueryStringValue("hangban") %>' };
                var parentWindow = parent.window;
                var callBackFun = '<%=Request.QueryString["callback"] %>'
                if (callBackFun.indexOf('.') == -1) {
                    parentWindow[callBackFun](data);
                } else {
                    parentWindow[callBackFun.split('.')[0]][callBackFun.split('.')[1]](data);
                }
                this.close();
            },
            getYanZhengMa: function(obj) {
                $(obj).unbind("click");
                var _data = { shouJi: $.trim($("#txtYuDTel").val()) };
                var _getYanZhengMaResult = iLogin.getZhuCeYanZhengMa(_data);

                if (!_getYanZhengMaResult.success) {
                    if (_getYanZhengMaResult.code == "-1") {
                        parent.window.location.href = "/#login";
                        return;
                    }
                    $(obj).click(function() { Register.getYanZhengMa(obj); }); return;
                }

                $(obj).css({ color: "#dadada" }).text("验证码已发送");
                setTimeout(function() { $(obj).css({ color: "#fe6600" }).text("获取验证码").click(function() { Register.getYanZhengMa(obj); }); }, 30000);
            },
            zhuCe: function(obj) {
                $(obj).unbind("click");
                var _data = { shouJi: $.trim($("#txtYuDTel").val()), xingMing: $.trim($("#txtYuDName").val()), yanZhengMa: $.trim($("#txtCode").val()) };
                var _zhuCeResult = iLogin.zhuCe(_data);

                if (!_zhuCeResult.success) {
                    if (_zhuCeResult.code == "-3") {
                        parent.window.location.href = "/#login";
                        return;
                    }

                    $(obj).click(function() { Register.zhuCe(obj); });
                    return;
                }

                if ('<%=EyouSoft.Common.Utils.GetQueryStringValue("callback") %>' != "") {
                    Register.callFunc();
                } else {
                    parent.location.href = parent.location.href;
                }

                return false;
            }
        }

        $(function() {
            $("#i_a_huoquyanzhengma").click(function() { Register.getYanZhengMa(this) });
            $("#i_a_xiayibu").click(function() { Register.zhuCe(this) });

            if (iLogin.getM().isLogin) {
                if ('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' == "") {
                    window.location.href = "/";
                    return;
                }

                if ('<%=EyouSoft.Common.Utils.GetQueryStringValue("callback") %>' != "") {
                    Register.callFunc();
                } else {
                    parent.location.href = parent.location.href;
                }
            }
        });
 
    </script>

</body>
</html>
