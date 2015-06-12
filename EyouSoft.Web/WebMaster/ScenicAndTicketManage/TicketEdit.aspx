<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.TicketEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理编辑景区主题</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>
    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
 
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <asp:PlaceHolder runat="server" ID="ph_0_0">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>所属景区：
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:DropDownList runat="server" ID="ddlScenic" valid="isNo" noValue="0" errmsg="请选择所属景区"
                        class="inputselect">
                    </asp:DropDownList>
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>门票名称：
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox runat="server" ID="txtTypeName" MaxLength="30" class="inputtext formsize180"
                        valid="required" errmsg="请填写门票名称"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    门票英文名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtEnName" MaxLength="30" name="txtEnName" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>门市价：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtMenShiPrice" name="txtMenShiPrice" runat="server" class="inputtext formsize180"
                        valid="required|isMoney" errmsg="请填写门市价|门市价格式错误"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>网站优惠价：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtWebSitePrice" name="txtWebSitePrice" runat="server" class="inputtext formsize180"
                        valid="required|isMoney" errmsg="请填写网站优惠价!|网站优惠价格式错误"></asp:TextBox>
                </td>
            </tr>
          
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>结算价：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtSettlementPrice" name="txtTongHangPrice" runat="server" class="inputtext formsize180"
                        valid="isMoney" errmsg="格式错误"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    最少限制：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtMin" name="txtMin" runat="server" class="inputtext formsize180"
                        valid="RegInteger" errmsg="最少限制格式错误"></asp:TextBox>（张/套）
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    门票数量：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtNumber" name="txtNumber" runat="server" class="inputtext formsize180"
                        valid="RegInteger" errmsg="门票数量格式错误"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    票价有效时间段：
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" id="txtStartDate" name="txtStartDate" class="inputtext formsize180"
                        onfocus="WdatePicker()" value="<%= StrStartDate %>" />
                    至
                    <input type="text" id="txtEndDate" name="txtEndDate" class="inputtext formsize180"
                        onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartDate\')}'})" value="<%= StrEndDate %>" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    门票说明：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea name="txtDescription" id="txtDescription" cols="50" rows="3" runat="server"
                        class="inputarea"></textarea>
                </td>
            </tr>
            <%if (1 == 0) %>
            <%{ %>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    同业销售须知：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea name="txtSaleDescription" id="txtSaleDescription" cols="50" rows="3" runat="server"
                        class="inputarea"></textarea>
                    （只有同业分销商能看到）
                </td>
            </tr>
            <%} %>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    状态：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:DropDownList runat="server" ID="ddlState" class="inputselect">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    是否同行分销：
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="checkbox" id="txtIsFenXiao" name="txtIsFenXiao" value="1" />
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="ph_0_1">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    排序：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtIndex" type="text" id="txtIndex" size="10" valid="RegInteger" errmsg="门票类型排序只能为整型"
                        runat="server" class="inputtext formsize180" />值越大，越靠前
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="248" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btnSave" hidefocus="true" runat="server">保存</a>
                                </td>
                                <td width="96" height="40" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a href="javascript:history.go(-1);">返回</a>
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

        var TicketEdit = {
            GoAjax: function(url) {
                $("#<%=btnSave.ClientID %>").html("提交中");
                $("#<%=btnSave.ClientID %>").unbind("click");
                $("#<%=btnSave.ClientID %>").css({ "color": "#999999" });
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btnSave.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/ScenicAndTicketManage/Ticket.aspx'; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { TicketEdit.BindBtn() });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(parent.tableToolbar.errorMsg, function() { TicketEdit.BindBtn() });
                    }
                });
            },
            BindBtn: function() {
                //绑定Add事件
                $("#<%=btnSave.ClientID %>").click(function() {
                    if (!ValiDatorForm.validator($("#<%=btnSave.ClientID %>").closest("form").get(0), "alert")) {
                        return false;
                    }
                    var data = {
                        save: "1",
                        action: '<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>',
                        id: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id") %>'
                    };
                    var ajaxUrl = "/WebMaster/ScenicAndTicketManage/TicketEdit.aspx?" + $.param(data);
                    TicketEdit.GoAjax(ajaxUrl);
                    return false;
                })
                $("#<%=btnSave.ClientID %>").html("保存").css({ "color": "" });
            }

        }

        $(function() {
            TicketEdit.BindBtn();
            if ("<%=IsFenXiao %>" == "1") $("#txtIsFenXiao").attr("checked", "checked");
        })
   
    </script>

</body>
</html>
