<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Supplier.SupplierEdit" %>

<%@ Register Src="/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="110" height="30" align="center">
                    <span class="fred">*</span>单位名称
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtDanWeiMingCheng" MaxLength="40" name="txtDanWeiMingCheng" runat="server"
                        class="inputtext formsize180" valid="required" errmsg="请输入单位名称!"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    单位简称:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtJC" name="txtJC" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    联系人:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtLianXiRen" name="txtLianXiRen" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    电话:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtDianHua" name="txtDianHua" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    手机:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtShouJi" name="txtShouJi" runat="server" class="inputtext formsize180"
                        valid="isMobile" errmsg="手机号码错误!"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    QQ:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtQQ" name="txtQQ" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    资质:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtZiZhi" name="txtZiZhi" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    邮箱:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtYouXiang" name="txtYouXiang" runat="server" class="inputtext formsize180"
                        valid="isEmail" errmsg="邮箱格式错误!"></asp:TextBox>
                </td>
                
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    地址:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtDiZhi" name="txtDiZhi" runat="server" class="inputtext formsize260"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    地图位置:
                </th>
                <td bgcolor="#E3F1FC">
                    <a href="javascript:;" class="aselectAddress">设置地址</a> (<label id="X" runat="server"></label>,<label
                        id="Y" runat="server"></label>)
                    <asp:HiddenField runat="server" ID="jingdu" />
                    <asp:HiddenField runat="server" ID="weidu" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    供应商类型:
                </th>
                <td bgcolor="#E3F1FC">
                    <select class="inputselect" id="ddlGYSType" name="ddlGYSType">
                        <%=strGYSType%>
                    </select>
                </td>
                <th width="90" height="30" align="center">
                    营业执照<br />
                    (身份证):
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upShenFenZheng" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litShenFenZheng" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    经营许可证<br />
                    (户口簿):
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upHuKouBu" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litHuKouBu" runat="server"></asp:Literal>
                </td>
                <th width="90" height="30" align="center">
                    税务登记证<br />
                    (工作名片):
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upMingPian" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litMingPian" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    代码证<br />
                    (其他证件):
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upQiTaZhengJian" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litQiTaZhengJian" runat="server"></asp:Literal>
                </td>
                <th width="90" height="30" align="center">
                    表格资料:
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upBiaoGe" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litBiaoGe" runat="server"></asp:Literal>
                </td>
            </tr>
             <tr class="odd">
                <th width="90" height="30" align="center">
                    电脑端LOGO：(141*87)
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upDnLogo" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litdnlogo" runat="server"></asp:Literal>
                </td>
                <th width="90" height="30" align="center">
                    移动端LOGO:(60*37)
                </th>
                <td bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="upYdLogo" FileTypes="*.jpg;" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="litydlogo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="4">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="right" class="tjbtn02">
                                    <a href="javascript:;" id="btn" align="center" hidefocus="true" style="text-align: center">
                                        保存</a>
                                </td>
                                <td width="96" height="40" align="left" class="tjbtn02" style="padding-left: 50px;">
                                    <a href="javascript:history.go(-1);" align="center" style="text-align: center">返回</a>
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
        var pageData = {
            CheckForm: function() {
                return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            pageSave: function() {
                $.newAjax({
                    type: "post",
                    url: "SupplierEdit.aspx?save=save",
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
                    success: function(ret) {
                    if (ret.result == "1") {
                    
                        tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/Supplier/SupplierEdit.aspx'; });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg);
                    }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }, //
            SetMapInfo: function() {
                //设置公司经纬度
                $(".aselectAddress").click(function() {
                    var data = { weidu: $("#<%=weidu.ClientID %>").val(), jindu: $("#<%=jingdu.ClientID %>").val() };
                    var url = "/WebMaster/ScenicAndTicketManage/SetGoogleMap.aspx?" + $.param(data);
                    var title = "设置地图";
                    Boxy.iframeDialog({ title: title, iframeUrl: url, height: 800, width: 900,
                        draggable: false
                    })
                    return false;
                });
            }
        }
        $(function() {
            $("#btn").click(function() { if (pageData.CheckForm()) { pageData.pageSave() } })
            pageData.SetMapInfo();
        })
    </script>

</body>
</html>
