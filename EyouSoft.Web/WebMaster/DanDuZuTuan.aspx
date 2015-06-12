<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DanDuZuTuan.aspx.cs" Inherits="EyouSoft.Web.WebMaster.DanDuZuTuan" %>

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
    <form id="form1" runat="server">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
           <tr class="odd">
                <th width="160" height="30" align="right">
                    <font class="fred">*</font>早餐费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="ZaoCan" valid="required" errmsg="早餐费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="ZaoCan" />元/人餐<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
                <td align="left">
                    门市价：<input type="text" id="ZaoCanMS" valid="required" errmsg="早餐费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="ZaoCan" />元/人餐<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>午餐费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="WuCan" valid="required" errmsg="午餐成本价必须填写!" class="formsize260 inputtext" runat="server" name="WuCan" />元/人餐<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
                <td align="left">
                    门市价：<input type="text" id="WuCanMS" valid="required" errmsg="午餐门市价必须填写!" class="formsize260 inputtext" runat="server" name="WuCan" />元/人餐<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>晚餐费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="WanCan" valid="required" errmsg="晚餐成本价必须填写!" class="formsize260 inputtext" runat="server" name="WanCan" />元/人餐<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
                <td align="left">
                    门市价：<input type="text" id="WanCanMS" valid="required" errmsg="晚餐门市价必须填写!" class="formsize260 inputtext" runat="server" name="WanCan" />元/人餐<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>人身意外险：
                </th>
                <td align="left">
                    成本价：<input type="text" id="RenShen" valid="required" errmsg="人身意外险成本价必须填写!" class="formsize260 inputtext" runat="server" name="RenShen" />元/人/天<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
                <td align="left">
                    门市价：<input type="text" id="RenShenMS" valid="required" errmsg="人身意外险门市价必须填写!" class="formsize260 inputtext" runat="server" name="RenShen" />元/人/天<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>交通意外险：
                </th>
                <td align="left">
                    成本价：<input type="text" id="JiaoTong" valid="required" errmsg="交通意外险成本价必须填写!" class="formsize260 inputtext" runat="server" name="JiaoTong" />元/人/天<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
                <td align="left">
                    门市价：<input type="text" id="JiaoTongMS" valid="required" errmsg="交通意外险门市价必须填写!" class="formsize260 inputtext" runat="server" name="JiaoTong" />元/人/天<br />(<span style="color:Red">多个价格请用英文逗号隔开</span>)
                </td>
            </tr>
             <tr class="odd">
                <th width="160" height="30" align="right">
                    <font class="fred">*</font>增加目的地汽车费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="CarMoney" valid="required" errmsg="人均汽车费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="CarMoney" />元/人/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="CarMSJia" valid="required" errmsg="人均汽车费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="CarMoney" />元/人/天
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>短线标准成团人数：
                </th>
                <td align="left" colspan="3">
                    <input type="text" id="DuanXianRS" valid="required" errmsg="短线成团人数必须填写!" class="formsize260 inputtext" runat="server" name="DuanXianRS" />人
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>长线标准成团人数：
                </th>
                <td align="left" colspan="3">
                    <input type="text" id="ChangXianRS" valid="required" errmsg="长线成团人数必须填写!" class="formsize260 inputtext" runat="server" name="ChangXianRS" />人
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>出境标准成团人数：
                </th>
                <td align="left" colspan="3">
                    <input type="text" id="GuojiRS" valid="required" errmsg="出境成团人数必须填写!" class="formsize260 inputtext" runat="server" name="GuojiRS" />人
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>长线全陪导游费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="DaoYou" valid="required" errmsg="长线全陪导游费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="DaoYou" />元/名/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="DaoYouMS" valid="required" errmsg="长线全陪导游费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="DaoYou" />元/名/天
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>长线地陪导游费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="DiPei" valid="required" errmsg="长线地陪导游费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="DiPei" />元/名/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="DiPeiMS" valid="required" errmsg="长线地陪导游费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="DiPeiMS" />元/名/天
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>短线全陪导游费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="DXDaoYou" valid="required" errmsg="短线全陪导游费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="DXDaoYou" />元/名/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="DXDaoYouMS" valid="required" errmsg="短线全陪导游费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="DXDaoYouMS" />元/名/天
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>短线地陪导游费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="DXDiPei" valid="required" errmsg="短线地陪导游费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="DXDiPei" />元/名/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="DXDiPeiMS" valid="required" errmsg="短线地陪导游费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="DXDiPeiMS" />元/名/天
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>出境全陪导游费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="CJDaoYou" valid="required" errmsg="出境全陪导游费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="CJDaoYou" />元/名/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="CJDaoYouMS" valid="required" errmsg="出境全陪导游费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="CJDaoYouMS" />元/名/天
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    <font class="fred">*</font>出境地陪导游费用：
                </th>
                <td align="left">
                    成本价：<input type="text" id="CJDiPei" valid="required" errmsg="出境地陪导游费用成本价必须填写!" class="formsize260 inputtext" runat="server" name="CJDiPei" />元/名/天
                </td>
                <td align="left">
                    门市价：<input type="text" id="CJDiPeiMS" valid="required" errmsg="出境地陪导游费用门市价必须填写!" class="formsize260 inputtext" runat="server" name="CJDiPeiMS" />元/名/天
                </td>
            </tr>
        </tbody>
    </table>
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:;" id="btn" runat="server">保存</a>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        $(function() {
        ZuTuanEdit.BindBtn();
        })
        var ZuTuanEdit = {
            BindBtn: function() {
                $("#<%=btn.ClientID %>").click(function() {

                    $(this).html("正在保存");

                    if (!ZuTuanEdit.CheckForm()) {
                        $(this).html("保存");
                        return false;
                    }
                    else {
                        var url = "/WebMaster/DanDuZuTuan.aspx?type=save";
                        ZuTuanEdit.GoAjax(url);
                    }

                    return false;
                })
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                        }
                        else {

                            tableToolbar._showMsg(ret.msg);
                            $("#<%=btn.ClientID %>").html("保存");
                            
                            
                        }
                    },
                    error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                    $("#<%=btn.ClientID %>").html("保存");
                    }
                });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "alert");
            }
        }
    </script>

    </form>
</body>
</html>
