<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.AreaEdit" %>
<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>线路区域编辑</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    
    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>
  <script src="../JS/swfupload/swfupload.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="520" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="16%" height="30" align="right">
                    <font color="red">*</font>区域名称：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox CssClass="inputtext formsize100" ID="txtAreaName" runat="server"></asp:TextBox>
                    <span id="tip" class="errmsg" style="display: none"><font color="red">请填写区域名称</font></span>
                </td>
            </tr>
            <tr class="odd">
                <th width="16%" height="30" align="right">
                    类别：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:DropDownList runat="server" ID="ddlType">
                    </asp:DropDownList>
                </td>
            </tr>
              <tr class="odd">
                <th width="16%" height="30" align="right">
                    营销链接：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox CssClass="inputtext formsize100" ID="txtYinXiaoLJ" runat="server"></asp:TextBox>
           
                </td>
            </tr>
              <tr class="odd">
                <th width="16%" height="30" align="right">
                    营销文字：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox CssClass="inputtext formsize180" ID="txtYinXiaoWZ" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
              <tr class="odd">
                <th width="16%" height="30" align="right">
                    营销图片：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                        <uc2:UploadControl ID="UploadControl1" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                 
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="248" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn" hidefocus="true" runat="server">保存</a>
                                </td>
                                <td width="96" height="40" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a href="javascript:history.go(-1);">返回</a>
                                    </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>

    <script type="text/javascript">
       
        var LineAdd = {
            GoAjax: function(url) {
                $("#<%=btn.ClientID %>").html("提交中...");
                $("#<%=btn.ClientID %>").unbind("click");
                $("#<%=btn.ClientID %>").css({ "color": "#999999" });
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/AreaList.aspx'; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { LineAdd.BindBtn() });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg, function() { LineAdd.BindBtn() });
                    }
                });
            },
            BindBtn: function() {
                //绑定Add事件
                $("#<%=btn.ClientID %>").click(function() {
                    if ($("#<%=txtAreaName.ClientID %>").val() == "") {
                        $("#tip").show();
                        return false;
                    }
                    var data = {
                        save: "1",
                        action: '<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>',
                        areaid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("areaid") %>'
                    };
                    var ajaxUrl = "/WebMaster/AreaEdit.aspx?" + $.param(data);
                    LineAdd.GoAjax(ajaxUrl);
                    return false;
                })
                $("#<%=txtAreaName.ClientID %>").focus(function() {
                    $("#tip").hide();
                })
                $("#<%=btn.ClientID %>").html("保存").css({ "color": "" });
            },
            DelImg: function(obj) {
                $(obj).parent().prev("img").remove();
                $(obj).parent().remove();
            }
        }

        $(function() {
            LineAdd.BindBtn();
        })
   
    </script>

</body>
</html>
