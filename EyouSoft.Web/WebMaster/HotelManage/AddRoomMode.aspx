<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRoomMode.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.AddRoomMode" %>

<%@ Register Src="../../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增/修改房型</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <asp:PlaceHolder runat="server" ID="ph_0_0">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>所属酒店：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <select class="inputselect" id="sltHotel" name="sltHotel"  valid="required" errmsg="请选择酒店!">
                        <%=StrHotel %>
                    </select>
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>房型名称：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtRoomMode" CssClass="inputtext formsize120" valid="required" errmsg="请输入房型名称!"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    <span class="fred">*</span>数量：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtcount" errmsg="请输入数量!|请输入正确的数量!|数量必须大于0且小于等于1000!" valid="required|isInt|range"
                        min="1" max="999" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                        CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    间
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    图片：
                </th>
                <td colspan="3" bgcolor="#E3F1FC" align="left">
                    <ul class="uploadul">
                        <li>图片1<uc1:UploadControl ID="UploadControl1" runat="server" />
                            <input type="hidden" value="" id="hidimg1" runat="server" />
                            &nbsp; 图片1说明
                            <asp:TextBox ID="txtdesc1" CssClass="inputtext formsize120" runat="server"></asp:TextBox></li>
                        <li>图片2<uc1:UploadControl ID="UploadControl2" runat="server" />
                            <input type="hidden" value="" id="hidimg2" runat="server" />
                            &nbsp; 图片2说明
                            <asp:TextBox ID="txtdesc2" CssClass="inputtext formsize120" runat="server"></asp:TextBox></li>
                        <li>图片3<uc1:UploadControl ID="UploadControl3" runat="server" />
                            <input type="hidden" value="" id="hidimg3" runat="server" />
                            &nbsp; 图片3说明
                            <asp:TextBox ID="txtdesc3" CssClass="inputtext formsize120" runat="server"></asp:TextBox></li>
                    </ul>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    房间类型：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <%=StrRoomType %>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    住房面积：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtSquare" CssClass="inputtext formsize120" runat="server"></asp:TextBox>
                    平方
                </td>
                <th width="90" height="30" align="center">
                    楼层数：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtFloorCount" errmsg="请输入正确的楼层数!|楼层数必须大于0!" valid="isInt|range"
                        min="1" max="99" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                        CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    层
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    床型：
                </th>
                <td bgcolor="#E3F1FC">
                    <%=StrBedType %>
                </td>
                <th width="90" height="30" align="center">
                    床面积：
                </th>
                <td bgcolor="#E3F1FC">
                    长
                    <asp:TextBox ID="txtbedC" CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    米*宽
                    <asp:TextBox ID="txtbedK" CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    米
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    可入住人数：
                </th>
                <td width="36%" bgcolor="#E3F1FC">
                    <select id="sltpeoplecount" name="sltpeoplecount" class="inputselect">
                        <option>1</option>
                        <option selected="selected">2</option>
                        <option>3</option>
                        <option>多人</option>
                    </select>
                </td>
                <th width="90" height="30" align="center">
                    配置：
                </th>
                <td width="32%" bgcolor="#E3F1FC">
                    <label>
                        <input type="checkbox" id="issmoke" name="issmoke" runat="server">
                        无烟房</label>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    宽带：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtlanmoney" CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    元/天
                    <%=StrInternet %>
                </td>
                <th width="90" height="30" align="center">
                    朝向：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="chaoxiang" name="chaoxiang" class="inputselect">
                        <%=StrChaoxiang %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    早餐：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtbreakfastprice" CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                    元/份
                    <%=StrBreakfast %>
                </td>
                <th width="90" height="30" align="center">
                    开窗：
                </th>
                <td bgcolor="#E3F1FC">
                    <%=StrWindow %>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    支付方式：
                </th>
                <td bgcolor="#E3F1FC">
                    <%=StrPayType%>
                </td>
                <th width="90" height="30" align="center">
                    能否加床：
                </th>
                <td bgcolor="#E3F1FC">
                    <%=StrIsAddbed %>
                    <asp:TextBox runat="server" ID="txtbedmoney" CssClass="inputtext formsize50"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    房型备注：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <p>
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" CssClass="inputtext formsize450"
                            Height="100px" runat="server"></asp:TextBox>
                    </p>
                </td>
            </tr>
            <tr class="odd">
                <th width="90" height="30" align="center">
                    是否同行分销：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <input type="checkbox" id="txtIsFenXiao" name="txtIsFenXiao" value="1" />
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="ph_0_1">
            <tr class="odd">
                <th width="90" height="30" align="center">
                    房型排序：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <label for="checkbox16">
                        <asp:TextBox ID="txtorderby" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                            CssClass="inputtext formsize50" runat="server"></asp:TextBox>
                        按照1，2，3顺序排列，前3位在列表时显示更突出</label>
                </td>
            </tr>
            </asp:PlaceHolder>
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
    </form>
</body>
</html>

<script type="text/javascript">
    $(function() {
        AddRoomMode.PageInit();
        if ("<%=IsFenXiao %>" == "1") $("#txtIsFenXiao").attr("checked", "checked");
    })
    var AddRoomMode = {
        PageInit: function() {
            //初始化上传控件
            swfUploadHandler.init({
                movies: [window["<%=UploadControl1.ClientID %>"], window["<%=UploadControl2.ClientID %>"], window["<%=UploadControl3.ClientID %>"]],
                startFn: function() { },
                completeFn: function() {
                    var url = '/WebMaster/HotelManage/AddRoomMode.aspx?type=save&hotelid=' + '<%=Request.QueryString["hotelid"] %>' + '&dotype=' + '<%=Request.QueryString["dotype"] %>' + "&roomid=" + '<%=Request.QueryString["roomid"] %>';
                    AddRoomMode.GoAjax(url);
                }, completeIsSubmit: true
            });
            $("#btnsave").click(function() {
                KEditer.sync();
                if (!AddRoomMode.CheckForm()) {
                    return false;
                }
                $("#btnsave").html("提交中...").unbind("click").css({ "color": "#999999" });

                //上传控件
                var swfFile1 = window["<%=UploadControl1.ClientID %>"];
                swfFile1.startUpload();
                //上传控件
                var swfFile2 = window["<%=UploadControl2.ClientID %>"];
                swfFile2.startUpload();
                //上传控件
                var swfFile3 = window["<%=UploadControl3.ClientID %>"];
                swfFile3.startUpload();
                return false;
            })
            $("#btnsave").html("保存").css({ "color": "" });
            $("#btnback").click(function() {
                location.href = "/WebMaster/HotelManage/RoomModeList.aspx?hotelid=" + '<%=Request.QueryString["hotelid"] %>';
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
                        tableToolbar._showMsg(ret.msg, function() { location.href = "/WebMaster/HotelManage/RoomModeList.aspx?hotelid=" + '<%=Request.QueryString["hotelid"] %>'; });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg, function() { AddRoomMode.PageInit(); });
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg, function() { AddRoomMode.PageInit(); });
                }
            });
        },
        CheckForm: function() {
            return ValiDatorForm.validator($("#btnsave").closest("form").get(0), "alert");
        }
    }
</script>

<style type="text/css">
    .upload_y_ul
    {
        list-style: none;
        float: left;
        margin-left: 5px;
        height: 40px;
        line-height: 40px;
        width: 60px;
    }
    .upload_y_ul li
    {
        list-style: none;
        float: left;
        margin-left: 8px;
        line-height: 40px;
    }
    .upload_y_ul li.file
    {
    }
    .upload_y_ul li span
    {
        padding-left: 2px;
    }
    .upload_y_ul li img
    {
        margin-top: -3px;
    }
</style>
