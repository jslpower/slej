<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetScenicImg.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.SetScenicImg" %>

<%@ Register Src="../../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑图片</title>
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <style type="text/css">
        #divPicList ul
        {
            width: 100%;
            float: left;
            list-style: none;
            margin: 0;
        }
        #divPicList li
        {
            padding: 3px 0;
            line-height: 25px;
            float: left;
            height: 180px;
        }
        .upload_img
        {
            width: 160px;
            height: 120px;
            padding: 3px;
            border: #999 solid 1px;
            margin: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%">
        <table width="100%" border="0">
            <tr>
                <td align="left" valign="top" colspan="3" bgcolor="#E3F1FC" style="padding-left: 20px">
                    <strong>景区图片上传</strong>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="3" style="padding-left: 20px" bgcolor="#E3F1FC">
                    为了更加直观的把景区呈现给客人，请上传整体外观、景区招牌的图片，其他图片请在“更多图片”选项中上传。
                    <br />
                    图片要求：分辨率需大于800×600（500像素以上相机拍摄），并在2M以内。
                    <br />
                    图片格式必须为jpg格式、请勿提供处理后的效果图、 图片上不要有水印，文本文字等内容。
                </td>
            </tr>
            <tr class="odd">
                <th width="120" height="30" align="center">
                    景区名称:
                </th>
                <td bgcolor="#E3F1FC" colspan="2">
                    <asp:Literal runat="server" ID="ltrJingDianName"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="120" height="130" align="center">
                    景区形象照片:
                </th>
                <td bgcolor="#E3F1FC" width="450px">
                    <uc1:UploadControl ID="upload1" runat="server" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp;" />
                    &nbsp;图片说明:<asp:TextBox ID="txtscenicimgdesc" ReadOnly="true" CssClass="inputtext formsize180"
                        runat="server"></asp:TextBox>
                    <input type="hidden" value="" id="hidxingxiangimgid" runat="server" />
                    <br />
                    本图片作为列表和景区详细展示使用
                    <input type="button" value="上传" id="btnxingxiang" />
                </td>
                <td bgcolor="#E3F1FC" align="center">
                    <asp:Image runat="server" ID="Imgscenic" BorderWidth="1" ImageUrl="/Images/NoPic.jpg"
                        CssClass="upload_img" />
                </td>
            </tr>
            <tr class="odd">
                <th width="120" height="130" align="center">
                    景区导览图:
                </th>
                <td bgcolor="#E3F1FC" width="450px">
                    <uc1:UploadControl ID="UploadControl2" runat="server" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp;" />
                    &nbsp;图片说明:<asp:TextBox ID="txtdaolanimgdesc" ReadOnly="true" CssClass="inputtext formsize180"
                        runat="server"></asp:TextBox>
                    <input type="hidden" value="" id="hiddaolanimgid" runat="server" />
                    <input type="button" value="上传" id="btndaolan" style="margin-left: 5px;" />
                </td>
                <td bgcolor="#E3F1FC" align="center">
                    <asp:Image runat="server" ID="Imgdaolan" BorderWidth="1" ImageUrl="/Images/NoPic.jpg"
                        CssClass="upload_img" />
                    <input runat="server" id="hiddaolan" type="hidden" value="" />
                    <span style="display: block; text-align: center; line-height: 20px;"><a id="deldaolan"
                        href="javascript:void(0)" visible="false" runat="server">删除</a></span>
                </td>
            </tr>
            <tr class="odd">
                <th width="120" height="130" align="center">
                    更多图片:
                </th>
                <td bgcolor="#E3F1FC" width="450px" colspan="2">
                    <table>
                        <tr>
                            <td>
                                <uc1:UploadControl ID="UploadControl3" runat="server" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp;" />
                                &nbsp;图片说明:<asp:TextBox ID="txtmoreimgdesc" CssClass="inputtext formsize180" runat="server"></asp:TextBox>
                                <input type="hidden" value="" id="hidmoreimgid" runat="server" />
                                <input type="button" value="上传" id="btnmore" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divPicList">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptmoreImgList">
                                            <ItemTemplate>
                                                <li id="li<%#Eval("ImgId") %>" title=""><a href='<%#Eval("Address") %>' target="_blank">
                                                    <img src='<%#Eval("Address") %>' alt="" class="upload_img" /></a>
                                                    <input type="hidden" name="hidimgid" value='<%#Eval("ImgId") %>' />
                                                    <span style="display: block; text-align: center; line-height: 20px;">
                                                        <%#EyouSoft.Common.Utils.GetText2(Convert.ToString(Eval("Description")),10,true)%><br />
                                                        <a onclick="SetImg.DeleteImg('<%#Eval("ImgId") %>')" href="javascript:void(0)">删除</a></span>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <li></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" value="" runat="server" id="scenicname" />
    </form>
</body>
</html>

<script type="text/javascript">
    $(function() {
        SetImg.PageInit();
    })
    var SetImg = {
        isSubmit: false,
        DoSubmit: function() {
            WebSiteInfo.isSubmit = true;
            WebSiteInfo.FormSubmit();
        },
        FormSubmit: function() {
            $("#<%= form1.ClientID %>").submit();
        },
        PageInit: function() {
            swfUploadHandler.init({
                movies: [window["<%=upload1.ClientID %>"]],
                startFn: function() { $("#btnxingxiang").unbind("click").val("正在提交").css({ "color": "#999999" }) /*开始上传事件*/ },
                completeFn: function() {
                    var dotype = '<%=Request.QueryString["dotype"] %>';
                    var url = "/WebMaster/ScenicAndTicketManage/SetScenicImg.aspx?type=xingxiang&dotype=save&imgtype=xingxiang&scenicid=" + '<%=Request.QueryString["scenicid"] %>';
                    SetImg.GoAjax(url); /*完成上传事件*/
                }
            });
            swfUploadHandler.init({
                movies: [window["<%=UploadControl2.ClientID %>"]],
                startFn: function() { $("#btndaolan").unbind("click").val("正在提交").css({ "color": "#999999" }) /*开始上传事件*/ },
                completeFn: function() {
                    var dotype = '<%=Request.QueryString["dotype"] %>';
                    var url = "/WebMaster/ScenicAndTicketManage/SetScenicImg.aspx?type=daolan&dotype=save&imgtype=daolan&scenicid=" + '<%=Request.QueryString["scenicid"] %>';
                    SetImg.GoAjax(url); /*完成上传事件*/
                }
            });
            swfUploadHandler.init({
                movies: [window["<%=UploadControl3.ClientID %>"]],
                startFn: function() { $("#btnmore").unbind("click").val("正在提交").css({ "color": "#999999" }) /*开始上传事件*/ },
                completeFn: function() {
                    var dotype = '<%=Request.QueryString["dotype"] %>';
                    var url = "/WebMaster/ScenicAndTicketManage/SetScenicImg.aspx?type=more&dotype=save&imgtype=more&scenicid=" + '<%=Request.QueryString["scenicid"] %>';
                    SetImg.GoAjax(url); /*完成上传事件*/
                }
            });
            $("#btnxingxiang").click(function() {

                var swfFile = window["<%=upload1.ClientID %>"];
                if (swfFile != null && swfFile.getStats().files_queued > 0) {
                    swfFile.startUpload();
                } else {
                    parent.tableToolbar._showMsg("请选择要上传的图片!");
                }
                return true;
            });
            $("#btndaolan").click(function() {

                var swfFile = window["<%=UploadControl2.ClientID %>"];
                if (swfFile != null && swfFile.getStats().files_queued > 0) {
                    swfFile.startUpload();
                } else {
                    parent.tableToolbar._showMsg("请选择要上传的图片!");
                }
                return true;
            });
            $("#btnmore").click(function() {
                var swfFile = window["<%=UploadControl3.ClientID %>"];
                if (swfFile != null && swfFile.getStats().files_queued > 0) {
                    swfFile.startUpload();
                } else {
                    parent.tableToolbar._showMsg("请选择要上传的图片!");
                }
                return true;
            });
            $("#<%=deldaolan.ClientID %>").click(function() {
                var daolanimgid = $("#<%=hiddaolanimgid.ClientID %>").val();
                SetImg.DeleteImg(daolanimgid);
                return false;
            })
        },
        DeleteImg: function(id) {
            parent.tableToolbar.ShowConfirmMsg("确定要删除吗？", function() {
                $.newAjax({
                    url: "SetScenicImg.aspx?dotype=deleteimg&imgid=" + id,
                    type: "post",
                    cache: false,
                    dataType: "json",
                    data: $("#btnxingxiang").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            $("#li" + id).html("");
                            parent.tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                        }
                        else {

                            parent.tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg("操作失败!");
                    }
                });
            });
        },
        GoAjax: function(url) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#btnxingxiang").closest("form").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        parent.tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                    }
                    else {
                        parent.tableToolbar._showMsg(ret.msg);
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
        }
    }
</script>

