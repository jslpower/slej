<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.RoomEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增/修改房价</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0">
        <tr class="odd">
            <td bgcolor="#E3F1FC" height="30" colspan="2" style="text-align: center; font-weight: bold">
                <asp:Label ID="lbHotelName" runat="server" Text="酒店名称"></asp:Label>
            </td>
        </tr>
        <tr class="odd">
            <th width="90" height="30" align="center">
                <span class="fred">*</span>房型:
            </th>
            <td bgcolor="#E3F1FC">
                <asp:DropDownList runat="server" ID="ddlRoomType" CssClass="inputselect" valid="required"
                    errmsg="请选择房型">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="odd">
            <th width="90" height="30" align="center">
                <span class="fred">*</span>时间段:
            </th>
            <td colspan="3" bgcolor="#E3F1FC">
                <asp:TextBox ID="txtstartdate" CssClass="inputtext formsize120" onfocus="WdatePicker()"
                    valid="required" errmsg="请选择开始时间" runat="server"></asp:TextBox>-<asp:TextBox ID="txtenddate"
                        CssClass="inputtext formsize120" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtstartdate\')}'})"
                        runat="server" valid="required" errmsg="请选择结束时间"></asp:TextBox>
            </td>
        </tr>
        <tr class="odd">
            <th width="90" height="30" align="center">
                <span class="fred">*</span>价格:
            </th>
            <td bgcolor="#E3F1FC">
                门市价：<asp:TextBox runat="server" ID="txtsellprice" CssClass="inputtext formsize50"
                    valid="required|isMoney" errmsg="门市价不能为空！|请填写正确的挂牌价"></asp:TextBox>
                网络价：<asp:TextBox runat="server" ID="txtyouhuipirce" CssClass="inputtext formsize50"
                    valid="required|isMoney" errmsg="网络价不能为空！|请填写正确的同行价"></asp:TextBox>
                结算价：<asp:TextBox runat="server" ID="txtjiesuanpirce" CssClass="inputtext formsize50"
                    valid="required|isMoney" errmsg="结算价不能为空！|请填写正确的网络价"></asp:TextBox>
            </td>
        </tr>
        <tr class="odd">
            <th width="90" height="30" align="center">
                <span class="fred">*</span>房间数量:
            </th>
            <td bgcolor="#E3F1FC">
                <asp:TextBox runat="server" ID="txtShuLiang" CssClass="inputtext formsize50" valid="required|RegInteger"
                    errmsg="房间数量不能为空！|请填写正确的房间数量"></asp:TextBox>
            </td>
        </tr>
        <tr class="odd">
            <th width="90" height="30" align="center">
                原因:
            </th>
            <td bgcolor="#E3F1FC">
                <asp:TextBox TextMode="MultiLine" ID="txtreason" Height="80" name="txtRemark" runat="server"
                    CssClass="inputtext formsize260"></asp:TextBox>
            </td>
        </tr>
        <tr class="odd">
            <td bgcolor="#E3F1FC" height="30" class="tjbtn02" align="center" colspan="2">
                <a href="javascript:;" id="btnsave">保存</a>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript">
    $(function() {
        RoomEdit.PageInit();
    })
    var RoomEdit = {
        PageInit: function() {
            $("#btnsave").click(function() {
                if (!RoomEdit.CheckForm()) {
                    return false;
                }
                $(this).html("提交中");
                RoomEdit.GoAjax('/WebMaster/HotelManage/RoomEdit.aspx?type=save&hotelid=<%=Request.QueryString["hotelid"] %>&dotype=<%=Request.QueryString["dotype"] %>' + "&id=" + '<%=Request.QueryString["id"] %>', $(this));
                return false;
            })
        },
        GoAjax: function(url, obj) {
            $(obj).unbind("click");
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = '/WebMaster/HotelManage/RoomShenqing.aspx?hotelid=<%=Request.QueryString["hotelid"] %>'; });
                    }
                    else {
                        parent.tableToolbar._showMsg(ret.msg);
                        RoomEdit.Bind();
                    }
                },
                error: function() {
                    parent.tableToolbar._showMsg(tableToolbar.errorMsg);
                    RoomEdit.Bind();
                }
            });
        },
        CheckForm: function() {
            return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "parent");
        },
        Bind: function() {
            var _selfs = $("#btnsave");
            _selfs.html("保存");
            _selfs.css("cursor", "pointer");
            _selfs.click(function() {
                if (!RoomEdit.CheckForm()) {
                    return false;
                }
                RoomEdit.GoAjax('/WebMaster/HotelManage/RoomEdit.aspx?type=save&hotelid=<%=Request.QueryString["hotelid"] %>&dotype=<%=Request.QueryString["dotype"] %>' + "&id=" + '<%=Request.QueryString["id"] %>', $(this));
                return false;
            });
        }
    }
</script>

