<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.RouteEdit"
    ValidateRequest="false" %>

<%@ Register Src="UserControl/Journey.ascx" TagName="Journey" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增/修改线路</title>
    <link href="../Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="../Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <script src="../JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="../JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="../JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="../JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="../JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>线路名称
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtRouteName" MaxLength="40" name="txtRouteName" runat="server"
                        class="inputtext formsize180" valid="required" errmsg="请输入路线名称!"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>线路区域:
                </th>
                <td bgcolor="#E3F1FC">
                    <select class="inputselect" id="sltarea" name="sltarea">
                        <%=RouteArea %>
                    </select>
                    <input type="hidden" value="0" runat="server" id="hidroutearea" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    联系人:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    姓名:
                    <asp:TextBox ID="txtContactName" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                    &nbsp;电话:
                    <asp:TextBox ID="txtContactTel" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                    &nbsp;手机:
                    <asp:TextBox ID="txtContactMobile" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                    &nbsp;QQ:
                    <asp:TextBox ID="txtContactQQ" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                </td>
            </tr>
            <!--
            <tr class="odd">
                <th width="90" height="30" align="center">
                    线路状态:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <%=routeStatus %>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    线路主题:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <%=themeStr %>
                </td>
            </tr>-->
            <tr class="odd">
                <th width="90" height="30" align="center">
                    出发地:
                </th>
                <td bgcolor="#E3F1FC">
                    省份:
                    <select id="ddlleaveprovince" class="inputselect proandcity">
                    </select>
                    <input runat="server" id="hidleaveproid" type="hidden" value="0" />
                    城市:
                    <select id="ddlleavecity" class="inputselect proandcity">
                    </select>
                    <input runat="server" id="hidleavecityid" type="hidden" value="0" />
                </td>
                <th width="90" height="30" align="center">
                    目的地:
                </th>
                <td bgcolor="#E3F1FC">
                    省份:
                    <select id="ddlendprovince" class="inputselect proandcity">
                    </select>
                    <input runat="server" id="hidendproid" type="hidden" value="0" />
                    城市:
                    <select id="ddlendcity" class="inputselect proandcity">
                    </select>
                    <input runat="server" id="hidendcityid" type="hidden" value="0" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>发班日期:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Label ID="lblLeaveDate" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hideLeaveDate" runat="server" />
                    <asp:PlaceHolder ID="phdSelectDate" runat="server"><a style="font-weight: bold; color: #fff;
                        background-color: #ff6600; display: block; width: 80px; text-align: center; padding-top: 5px;"
                        id="a_SelectData" href="javascript:void(0);">请选择日期</a></asp:PlaceHolder>
                </td>
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>天数:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtdays" errmsg="请输入天数!|请输入正确的天数!|天数必须大于0!" valid="required|isInt|range"
                        min="1" max="99" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                        CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    市场价:
                </th>
                <td bgcolor="#E3F1FC">
                    成人:
                    <asp:TextBox ID="txtShiadultprice" valid="isMoney" errmsg="价格格式有误" CssClass="inputtext formsize120"
                        runat="server"></asp:TextBox>&nbsp; 儿童:
                    <asp:TextBox ID="txtShichildprice" valid="isMoney" errmsg="价格格式有误" CssClass="inputtext formsize120"
                        runat="server"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    结算价:
                </th>
                <td bgcolor="#E3F1FC">
                    成人:
                    <asp:TextBox ID="txtJieadultprice" valid="isMoney" errmsg="价格格式有误" CssClass="inputtext formsize120"
                        runat="server"></asp:TextBox>&nbsp; 儿童:
                    <asp:TextBox ID="txtJiechlidprice" valid="isMoney" errmsg="价格格式有误" CssClass="inputtext formsize120"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    提前报名天数:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtTiqiandays" errmsg="必须是数字!" valid="isNumber" onkeyup="this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')" CssClass="inputtext formsize50"
                        runat="server"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    计划人数:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtPlanCount" errmsg="必须是数字!" valid="isNumber" onkeyup="this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')" CssClass="inputtext formsize50"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    出发交通:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtleavetraffic" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    返程交通:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtendtraffic" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="PHchujing" Visible="false">
                <tr class="odd">
                    <th width="90" height="30" align="center">
                        途径国家:
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtTujing" CssClass="inputtext formsize180" runat="server"></asp:TextBox>
                    </td>
                    <th width="90" height="30" align="center">
                        签证资料:
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <uc2:UploadControl ID="Uploadqianzheng" IsUploadMore="false" IsUploadSelf="true"
                            runat="server" />
                        <asp:Label runat="server" ID="lbqianzheng" class="labelFiles"></asp:Label>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    特色描述:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtRouteDesc" name="txtRouteDesc" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    特色图片:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <uc2:UploadControl ID="UploadControl1" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    集合方式:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtcollecttype" Height="60" name="txtcollecttype"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    行程
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <uc1:Journey ID="Journey1" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    服务标准:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtserver" Height="80" name="txtcollecttype"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    不含项目:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtNoproject" Height="80" name="txtcollecttype"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    购物安排:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtshopping" Height="80" name="txtshopping"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    儿童安排:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtchildplan" Height="80" name="txtchildplan"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    自费项目:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtselfproject" Height="80" name="txtselfproject"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    注意事项:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtnotice" Height="80" name="txtnotice" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    温馨提醒:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txttip" Height="80" name="txttip" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    报名须知:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtxuzhi" Height="80" name="txtxuzhi" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    赠送项目:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtzengsong" Height="80" name="txtzengsong" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    其他事项:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtqita" Height="80" name="txtqita" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <%--<tr class="odd">
                <th width="90" height="30" align="center">
                    关注度:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtguanzhudu" Height="80" name="txtguanzhudu"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>--%>
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
                                        <a id="btnback" class="back" href="javascript:;">返回</a>
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
</body>
</html>

<script type="text/javascript">
    $(function() {
        RouteEdit.PageInit();
    })
    var RouteEdit = {
        PageInit: function() {
            $("#a_SelectData").click(function() {
                Boxy.iframeDialog({
                    iframeUrl: "/WebMaster/SelectChildTourDate.aspx?hide=<%=hideLeaveDate.ClientID %>&show=<%=lblLeaveDate.ClientID %>&old=" + $("#<%=hideLeaveDate.ClientID %>").val(),
                    title: "选择发班周期",
                    modal: true,
                    width: "925px",
                    height: "335px"
                });
            });
            $("#sltarea").change(function() {
                $("#<%=hidroutearea.ClientID %>").val($(this).val());
            })
            pcToobar.init({
                pID: "#ddlleaveprovince",
                cID: "#ddlleavecity",
                pSelect: "<%=this.LeaveProvinceId %>",
                cSelect: "<%=this.LeaveCityId %>",
                comID: '1'
            });
            pcToobar.init({
                pID: "#ddlendprovince",
                cID: "#ddlendcity",
                pSelect: "<%=this.EndProvinceId %>",
                cSelect: "<%=this.EndCityId %>",
                comID: '1'
            });
            $(".proandcity").change(function() {
                $(this).next("input[type='hidden']").val($(this).val());
            })
            KEditer.init("<%=txtRouteDesc.ClientID %>");
            $("#btnsave").click(function() {
                if ($("#<%=hideLeaveDate.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请选择出团日期!");
                    return false;
                }
                if ($("#<%=hidroutearea.ClientID %>").val() == "-1") {
                    tableToolbar._showMsg("请选择选择线路区域!");
                    return false;
                }

                if (!RouteEdit.CheckForm()) {
                    return false;
                }
                if ($("#sltarea").val() == "0") {
                    tableToolbar._showMsg("请选择线路区域!");
                    return false;
                }
                $(this).html("提交中");
                RouteEdit.GoAjax('/WebMaster/RouteEdit.aspx?type=save&dotype=' + '<%=Request.QueryString["dotype"] %>' + "&id=" + '<%=Request.QueryString["id"] %>', $(this));
                return false;
            })
            $("#btnback").click(function() {
                location.href = "/WebMaster/RouteList.aspx";
                return false;
            })
            $("#tbl_Journey_AutoAdd").autoAdd({ changeInput: $("#<%=txtdays.ClientID %>"), addCallBack: Journey.AddRowCallBack, upCallBack: Journey.MoveRowCallBack, downCallBack: Journey.MoveRowCallBack });

            $(".theme").click(function() {
                var self = $(this);
                if (this.checked) {
                    self.attr("name", "themeId");
                } else {
                    self.attr("name", "");
                }
            })
            $(".routestatus").click(function() {
                var self = $(this);
                if (this.checked) {
                    self.attr("name", "routestatus");
                } else {
                    self.attr("name", "");
                }
            })
        },
        GoAjax: function(url, obj) {
            $(obj).unbind("click");
            KEditer.sync();
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.href = "/WebMaster/RouteList.aspx"; });
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
        CheckForm: function() {
            return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "alert");
        },
        DelFile: function(obj) {
            $(obj).parent().remove();
        },
        DelImg: function(obj) {
            $(obj).parent().prev("img").remove();
            $(obj).parent().remove();
        }
    }
</script>

