<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZucheEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ZuChe.ZucheEdit" ValidateRequest="false" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>租车编辑</title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/swfupload/swfupload.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor-min.js"></script>
    <style type="text/css">
        .style1
        {
            height: 4px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0" id="tableInfo">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>车辆名称
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtName" MaxLength="40" name="txtName" runat="server" class="inputtext formsize180"
                        valid="required" errmsg="请输入车辆名称!"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>乘坐几人
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtChengZuo" MaxLength="40" name="txtChengZuo" runat="server" class="inputtext formsize180"
                        valid="required|isInt|range" errmsg="请输入乘坐几人!|请输入正确的乘坐人数!|人数必须大于0!"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>同城往返:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                <table width=100%>
                <tr>
                <td align="right" class="style1">门市价格：</td>
                <td class="style1"> <asp:TextBox ID="txtMenShiJia" valid="required|isMoney" errmsg="门市价格不能为空|门市价格格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right" class="style1">超出天数门市费用：</td>
                <td class="style1"><asp:TextBox ID="txtTianShuMenShi" valid="required|isMoney" errmsg="超出天数门市费用不能为空|超出天数门市费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right" class="style1">超程门市费用：</td><td class="style1"><asp:TextBox ID="txtChaoCMenShi" valid="required|isMoney" errmsg="超程门市费用不能为空|超程门市费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                <td align="right">成本价格：</td>
                <td><asp:TextBox ID="txtMenShiDanCheng" valid="required|isMoney" errmsg="基础费用不能为空|基础费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right">超出天数成本费用：</td>
                <td><asp:TextBox ID="txtMenShiJiaGeChaoShi" valid="required|isMoney" errmsg="超出天数费用不能为空|超出天数费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right">超程成本费用：</td>
                <td><asp:TextBox ID="txtMenShiJiaGeChaoCheng" valid="required|isMoney" errmsg="超程费用不能为空|超程费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                <td align="right">公里数：</td>
                <td colspan="5"><asp:TextBox ID="txtMenShiJiaGeZuChe" valid="required|isMoney" errmsg="公里数不能为空|公里数格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                </tr>
                </table>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>单接单送:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                <table width=100%>
                <tr>
                <td align="right">门市价格：</td>
                <td><asp:TextBox ID="txtYouHuiJia" valid="required|isMoney" errmsg="门市价格不能为空|门市价格格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right">超出天数门市费用：</td>
                <td><asp:TextBox ID="txtYouHuiChaoShiMenShi" valid="required|isMoney" errmsg="超出天数门市费用不能为空|超出天数门市费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right">超程门市费用：</td>
                <td><asp:TextBox ID="txtYouHuiChaoCMenShi" valid="required|isMoney" errmsg="超程门市费用不能为空|超程门市费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                
                </tr>
                <tr>
                <td align="right">成本价格：</td>
                <td><asp:TextBox ID="txtYouHuiDanCheng" valid="required|isMoney" errmsg="基础费用不能为空|基础费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right">超出天数成本费用：</td>
                <td><asp:TextBox ID="txtYouHuiChaoShi" valid="required|isMoney" errmsg="超出天数费用不能为空|超出天数费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                <td align="right">超程成本费用：</td>
                <td><asp:TextBox ID="txtYouHuiJiaGeChaoCheng" valid="required|isMoney" errmsg="超程费用不能为空|超程费用格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                <td align="right">公里数：</td>
                <td colspan="5"><asp:TextBox ID="txtYouHuiJiaGeZuChe" valid="required|isMoney" errmsg="单程公里数不能为空|单程公里数格式错误！" CssClass="inputtext formsize120" runat="server"></asp:TextBox></td>
                </tr>
                </table>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    图片:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    
                    <uc2:UploadControl ID="UploadFile" IsUploadMore="false" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                        IsUploadSelf="true" runat="server" />
                    <asp:Label runat="server" ID="Label1" class="labelFiles"></asp:Label>
                    （第一张图）
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    图片:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                   
                    <uc2:UploadControl ID="UploadControl4" IsUploadMore="false" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                        IsUploadSelf="true" runat="server" />
                    <asp:Label runat="server" ID="Label5" class="labelFiles"></asp:Label>
                    （第二张图）
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    图片:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    
                    <uc2:UploadControl ID="UploadControl8" IsUploadMore="false" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                        IsUploadSelf="true" runat="server" />
                    <asp:Label runat="server" ID="Label9" class="labelFiles"></asp:Label>
                    （第三张图）
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    相关说明:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtShuoMing" runat="server" class="editText" name="txtcollecttype"></asp:TextBox>
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
                                        <a id="btnback"
                                            class="back" href="javascript:history.go(-1);">返回</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br /><br />
    </form>

    <script type="text/javascript">
        var PageInfo = {

            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        resizeMode: 0,
                        items: keSimple_HaveImage,
                        height: $(this).attr("data-height") == undefined ? "360px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "900px" : $(this).attr("data-width")
                    });
                });
            },
            Sava: function() {
                if (!PageInfo.CheckForm()) {
                    return false;
                }
                var dotype = '<%=Request.QueryString["type"] %>';
                var id = '<%=Request.QueryString["id"] %>';
                var url = '/WebMaster/ZuChe/ZucheEdit.aspx?dotype=sava&type=' + dotype + '&id=' + id;
                PageInfo.GoAjax(url);
            },
            CheckForm: function() {
            KEditer.sync();
                return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "alert");
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                            window.parent.frames.mainFrame.location.href = '/WebMaster/ZuChe/zuchelist.aspx'
                            //parent.location.href = "/WebMaster/ZuChe/zuchelist.aspx";
                            });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            },
            BindBth: function() {
                $(".save").click(function() {
                    PageInfo.Sava(); return false;
                });
            }
        };
        $(function() {
            PageInfo.BindBth();
        });
        $(document).ready(function() {

        PageInfo.InitEdit();
        });
    </script>

</body>
</html>
