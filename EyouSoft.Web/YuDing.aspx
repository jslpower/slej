<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="YuDing.aspx.cs" Inherits="EyouSoft.Web.YuDing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tc_inputbk
        {
            height: 23px;
            line-height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="line_xx_box">
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
    </div>

    <script type="text/javascript">
        var Register = {
            rurl: decodeURIComponent('<%=EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>'),
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
                        if (Register.rurl != null) {
                            window.location.href = "/Lg.aspx?rurl=" + encodeURIComponent(Register.rurl);
                        }
                        else {
                            window.location.href = "/Lg.aspx";
                        }
                        return false;
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
                        if (Register.rurl != null) {
                            window.location.href = "/Lg.aspx?rurl=" + encodeURIComponent(Register.rurl);
                        }
                        else {
                            window.location.href = "/Lg.aspx";
                        }
                        return false;

                    }

                    $(obj).click(function() { Register.zhuCe(obj); });
                    return;
                }

                if ('<%=EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>' != "") {
                    location.href = '<%=EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>';
                } else {
                    location.href = location.href;
                }

                return false;
            }
        }

        $(function() {
            $("#i_a_huoquyanzhengma").click(function() { Register.getYanZhengMa(this) });
            $("#i_a_xiayibu").click(function() { Register.zhuCe(this) });
        });
 
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
