<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.OrderEdit" %>

<%@ Register Src="UserControl/OrderCustomer.ascx" TagName="OrderCustomer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增/修改订单</title>
    <link href="../Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <script src="../JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="../JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="../JS/ValiDatorForm.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    订单号:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbordercode" runat="server" Text=""></asp:Label>
                </td>
                <th width="90" height="30px" align="center">
                    下单时间:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lborderdate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    出发日期:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtleavedate" CssClass="inputtext formsize120" onfocus="WdatePicker()"
                        runat="server"></asp:TextBox>
                </td>
                <th width="90" height="30px" align="center">
                    人数:
                </th>
                <td bgcolor="#E3F1FC">
                    成人:
                    <asp:TextBox ID="txtadultcount" CssClass="inputtext formsize80" errmsg="必须是数字!|人数不能为空"
                        valid="isNumber|required" runat="server"></asp:TextBox>&nbsp; 儿童:<asp:TextBox ID="txtchildcount"
                            CssClass="inputtext formsize80" errmsg="必须是数字!|人数不能为空" valid="isNumber|required"
                            runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    联系人:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    姓名:<asp:TextBox ID="txtContactName" CssClass="inputtext formsize80" runat="server"></asp:TextBox>&nbsp;
                    性别:<select class="inputselect select" id="sltsex"><%=Strsex %>
                    </select><input type="hidden" id="hidsex" runat="server" value="0" />&nbsp; 手机:<asp:TextBox ID="txtContactMobile" CssClass="inputtext formsize80"
                        runat="server"></asp:TextBox>&nbsp; 证件类型:<select class="inputselect select" id="sltzhengjiantype"><%=Strzhengjiantype%>
                        </select><input type="hidden" id="hidcardtype" runat="server" value="0" />&nbsp; 证件号码:<asp:TextBox ID="txtZhengjiancode" CssClass="inputtext formsize120"
                            runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    价格:
                </th>
                <td bgcolor="#E3F1FC">
                    成人:
                    <asp:TextBox ID="txtadultprice" CssClass="inputtext formsize80" errmsg="价格格式不正确!|人数不能为空"
                        valid="isMoney|required" runat="server"></asp:TextBox>&nbsp; 儿童:<asp:TextBox ID="txtchildprice"
                            CssClass="inputtext formsize80" errmsg="价格格式不正确!|人数不能为空" valid="isMoney|required"
                            runat="server"></asp:TextBox>
                </td>
                <th width="90" height="30px" align="center">
                    合同金额:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtHetongMoney" CssClass="inputtext formsize80" errmsg="金额格式不正确!"
                        valid="isMoney" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    订单状态:
                </th>
                <td bgcolor="#E3F1FC">
                    <select class="inputselect select" id="sltorderstatus">
                        <%=StrOrderStatus %>
                    </select>
                    <input type="hidden" id="hidorderstatus" runat="server" value="0" />
                </td>
                <th width="90" height="30px" align="center">
                    付款状态:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lbpaystatus" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    下单备注:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox ID="txtorderremark" runat="server" TextMode="MultiLine" Height="60"
                        CssClass="inputtext formsize600"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30px" align="center">
                    其他要求:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <div style="width: 90%">
                        <uc1:OrderCustomer ID="OrderCustomer1" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="40" bgcolor="#E3F1FC" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnsave" class="save" href="javascript:;">保存</a>
                                    </td>
                                    <td width="80" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a id="btnback" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide()" class="cencer" href="javascript:;">取消</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
$(function(){
    OrderEdit.PageInit();
})
var OrderEdit={
    PageInit:function(){
        $(".select").change(function(){
            var self=$(this);
            self.next("input[type='hidden']").val(self.val());
        })
        $("#btnsave").click(function(){             
             if (!OrderEdit.CheckForm()) {
                  return false;
             }
             $(this).html("提交中");
              OrderEdit.GoAjax('/WebMaster/OrderEdit.aspx?type=save&dotype=update'+"&id="+'<%=Request.QueryString["id"] %>',$(this));
              return false;
        })
    },
    GoAjax: function(url,obj) {
                $(obj).unbind("click");
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { location.href = "/WebMaster/OrderList.aspx"; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
       },
       CheckForm: function() {
            return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "alert");
       }
}
</script>

