<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScenicEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.ScenicEdit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增/修改 景区</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>景区名称:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txtscenicname" name="txtscenicname" class="inputtext formsize180"
                        valid="required" errmsg="请输入景区名称!" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    英文名称:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtEnName" MaxLength="30" name="txtEnName" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    是否推荐:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:CheckBox ID="cktuijian" runat="server" Text="是否推荐" />
                </td>
                <th width="90" height="30" align="center">
                    地图信息:
                </th>
                <td bgcolor="#E3F1FC">
                    <a id="Setmap" href="javascript:;">地图信息</a> (<label id="X" runat="server"></label>,<label
                        id="Y" runat="server"></label>)
                    <asp:HiddenField runat="server" ID="jingdu" />
                    <asp:HiddenField runat="server" ID="weidu" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    客服电话:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txtKefuTel" MaxLength="30" name="txtKefuTel" runat="server" class="inputtext formsize180"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    联系人:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtcontactname" MaxLength="30" name="txtcontactname" runat="server"
                        class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    联系电话:
                </th>
                <td bgcolor="#E3F1FC" width="400px">
                    <asp:TextBox ID="txtContactTel" MaxLength="30" name="txtContactTel" runat="server"
                        class="inputtext formsize180"></asp:TextBox>
                </td>
                <th width="90" height="30" align="center">
                    手机号码:
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtcontactmobile" MaxLength="30" name="txtcontactmobile" runat="server"
                        class="inputtext formsize180"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    联系传真:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox ID="txtcontactfax" name="txtcontactfax" CssClass="inputtext formsize180"
                        MaxLength="30" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    国家代码:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <span class="fred">*</span>省份:
                    <select id="ddlprovince" class="inputselect proandcity" valid="required" errmsg="请选择省份!">
                    </select>
                    <input runat="server" id="hidproid" type="hidden" value="0" />
                    <span class="fred">*</span>城市:
                    <select id="ddlcity" class="inputselect proandcity" valid="required" errmsg="请选择城市!">
                    </select>
                    <input runat="server" id="hidcityid" type="hidden" value="0" />
                    县区
                    <select id="ddlarea" class="inputselect proandcity">
                    </select>
                    <input runat="server" id="hidareaid" type="hidden" value="0" />
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    结算方式:
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                   <label> <input runat="server" type="radio" id="radxianjie" name="jiesuan" checked  />现结</label> &nbsp;<label><input runat="server" type="radio" id="radyuejie" name="jiesuan"  />月结 </label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    地标区域:
                </th>
                <td bgcolor="#E3F1FC" colspan="3" id="Td_ChbLankId">
                    <asp:Repeater ID="ChbLankId" runat="server">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    中文地址:
                </th>
                <td bgcolor="#E3F1FC" width="400px" colspan=3>
                    <asp:TextBox ID="txtaddress" CssClass="inputtext formsize260" runat="server"></asp:TextBox>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="PHchujing">
                <tr class="odd">
                    <th width="90" height="30" align="center">
                        景区等级:
                    </th>
                    <td bgcolor="#E3F1FC" width="400px">
                        <select class="inputselect" id="sceniclv" name="sceniclv">
                            <%=ScenicLv %>
                        </select>
                    </td>
                    <th width="90" height="30" align="center">
                        成立年份:
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtYear" errmsg="必须是数字!" valid="isNumber" onkeyup="this.value=this.value.replace(/\D/g,'')"
                            onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="4" CssClass="inputtext formsize80"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    网址:
                </th>
                <td bgcolor="#E3F1FC" width="400px" colspan=3>
                    <asp:TextBox ID="NetAddress" CssClass="inputtext formsize260" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>景区详细介绍:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtscenicdesc" valid="required" errmsg="请填写景区介绍!"
                        Height="60" name="txtscenicdesc" runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    日常开放时间:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtKaifangTime" Height="80" name="txtKaifangTime"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    交通说明:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txttraffic" Height="80" name="txttraffic" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    周边设施
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox TextMode="MultiLine" ID="txtZhoubian" Height="80" name="txtZhoubian"
                        runat="server" CssClass="inputtext formsize800"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    备注:
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox TextMode="MultiLine" ID="txtRemark" Height="80" name="txtRemark" runat="server"
                        CssClass="inputtext formsize800"></asp:TextBox>
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
        ScenicEdit.PageInit();
    })
    var ScenicEdit = {
        PageInit: function() {
            ScenicEdit.SetMapInfo();
            pcToobar.init({
                pID: "#ddlprovince",
                cID: "#ddlcity",
                xID: "#ddlarea",
                pSelect: "<%=this.ProvinceId %>",
                cSelect: "<%=this.CityId %>",
                xSelect: "<%=this.AreaId %>",
                comID: '1'
            });
            $(".proandcity").change(function() {
                $(this).next("input[type='hidden']").val($(this).val());
            })
            KEditer.init("<%=txtscenicdesc.ClientID %>");
            KEditer.init("<%=txtZhoubian.ClientID %>");
            $("#btnsave").click(function() {
                KEditer.sync();
                if (!ScenicEdit.CheckForm()) {
                    return false;
                }
                ScenicEdit.GoAjax('/WebMaster/ScenicAndTicketManage/ScenicEdit.aspx?type=save&dotype=' + '<%=Request.QueryString["dotype"] %>' + "&id=" + '<%=Request.QueryString["id"] %>', $(this));
                return false;
            })
            $("#btnback").click(function() {
                location.href = "/WebMaster/ScenicAndTicketManage/ScenicList.aspx";
                return false;
            })

            $(".theme").click(function() {
                var self = $(this);
                if (this.checked) {
                    self.attr("name", "themeId");
                } else {
                    self.attr("name", "");
                }
            })
            $("#ddlcity").change(function() {
                ScenicEdit.BindArea($(this).val());
            })

        },
        GoAjax: function(url, obj) {
            $("#btnsave").unbind("click");
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.href = "/WebMaster/ScenicAndTicketManage/ScenicList.aspx"; });
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
        SetMapInfo: function() {
            //设置公司经纬度
            $("#Setmap").click(function() {
                var data = { weidu: $("#weidu").val(), jindu: $("#jingdu").val() };
                if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype").ToLower() %>' == "add") {
                    $("#ddlcity").find("option").each(function() {
                        if ($(this).val() == $("#ddlcity").val() && $(this).val() != "" && $(this).val() != "0") {
                            data.cName = $(this).text();
                        }
                    });
                }
                var url = "SetGoogleMap.aspx?" + $.param(data);
                var title = "设置地图";
                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 480, width: 800, draggable: false })
                return false;
            });
        },
        BindArea: function(cityid) {
            $("#Td_ChbLankId").html("");
            $.ajax({
                url: "ScenicEdit.aspx?type=BinLankId&arg=" + cityid,
                cache: false,
                type: "post",
                success: function(result) {
                    var list = eval(result);
                    for (var i = 0; i < list.length; i++) {
                        $("#Td_ChbLankId").append("<input type=\"checkbox\" name=\"chkboxLankid\" value=\"" + list[i].Id + "\" id=\"cbxl_" + i + "\" /><label for=\"cbxl_" + i + "\">" + list[i].Por + "</label>");
                        if (i % 7 == 0 && i > 0) {
                            $("#Td_ChbLankId").append("<br>");
                        }
                    }
                },
                error: function() {
                    tableToolbar._showMsg("操作失败!");
                }
            });
        }
    }
</script>

