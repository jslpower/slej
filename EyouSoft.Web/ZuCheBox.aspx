<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZuCheBox.aspx.cs" Inherits="EyouSoft.Web.ZuCheBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/foucs.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>
    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $(".tchuang tr:even").addClass("tb_even");
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="95%" border="0" class="tchuang">
        <tr>
            <th width="150" align="right">
                <font class="fontred">*</font>&nbsp;乘车联系人姓名：
            </th>
            <td align="left">
                <input name="textfield" type="text" id="textfield" size="15" class="tc_inputbk formsize140"  valid="required|isName" errmsg="乘车联系人姓名不能为空!|请填写正确的乘车人姓名,不能有数字!"/>
            </td>
        </tr>
        <tr>
            <th align="right">
                <font class="fontred">*</font>&nbsp;乘车联系人手机：
            </th>
            <td align="left">
                <input name="textfield2" type="text" id="textfield2" size="15" class="tc_inputbk formsize140" valid="required|isMobile" errmsg="乘车联系人手机不能为空!|请填写正确乘车联系人手机!"/>
            </td>
        </tr>
        <%--<tr>
            <th align="right">
                <span class="fontred">*</span>&nbsp;预订人姓名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：
            </th>
            <td align="left">
                <input name="textfield3" type="text" id="textfield3" size="15" class="tc_inputbk formsize140" />
            </td>
        </tr>
        <tr>
            <th align="right">
                <span class="fontred">*</span> 预订人手机&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：
            </th>
            <td align="left">
                <input name="textfield4" type="text" id="textfield4" size="15" class="tc_inputbk formsize140" />
            </td>
        </tr>--%>
        <tr>
            <th align="right">
                备注与说明&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：
            </th>
            <td align="left">
                <textarea name="textfield8" class="tc_inputbk" id="textfield8" style="width: 400px;
                    height: 100px;"></textarea>
            </td>
        </tr>
    </table>
    <table width="95%" border="0" style="margin: 15px auto;">
        <tr>
            <td align="center" class="tjbtn02">
                <a id="post" href="#">预 订 >></a><a onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();" href="javascript:;">取 消 >></a>
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">
    function  checkform() {
        return ValiDatorForm.validator($("#post").closest("form").get(0), "alert")
            }
            $(function() {
                $("#post").click(function() {
                    if (checkform()) {
                        var ccren = $("#textfield").val();
                        var ccrlianxi = $("#textfield2").val();
                        var beizhu = $("#textfield8").val();
                        var _data = { textfield: ccren, textfield1: ccrlianxi, textfield2: beizhu };
                        var parentWindow = parent.window;
                        var callBackFun = '<%=Request.QueryString["callback"] %>'
                        if (callBackFun.indexOf('.') == -1) {
                            parentWindow[callBackFun](_data);
                        } else {
                            parentWindow[callBackFun.split('.')[0]][callBackFun.split('.')[1]](_data);
                        }
                    }
                    //                var data = { txt: 11111111 };
                    //                _$['<%=EyouSoft.Common.Utils.GetQueryStringValue("callback") %>'](data);
                });

            });
        
    </script>

</body>
</html>
