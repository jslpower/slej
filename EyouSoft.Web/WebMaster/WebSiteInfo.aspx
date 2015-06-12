<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSiteInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.WebSiteInfo"
    ValidateRequest="false" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站基本信息</title>
    <link href="/Css/webmaster/manager.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor-min.js"></script>

    <script type="text/javascript" src="/js/swfupload/swfupload.js"></script>

</head>
<body>
    <form id="form1" runat="server" action="/WebMaster/WebSiteInfo.aspx?action=update">
    <table width="98%" border="1" align="center" cellpadding="3" cellspacing="0" bordercolor="#CCCCCC"
        id="tableInfo">
        <tr class="lr_hangbg">
            <td align="right" style="width: 15%">
                描述：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtDescription" class="editText" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                关键词：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtKeywords" class="editText" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                标题：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtTitle" class="editText" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                logo：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <uc1:UploadControl runat="server" ID="upload1" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp" />
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                火车查询：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Train" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                公交查询：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Transit" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                天气查询：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Weather" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                航班查询：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Flight" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                手机查询：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Mobile" class="editText"  Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                火车旅游常识：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="TravelTips" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                旅游地图：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Map" class="editText"  Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                在线翻译：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="Online" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                邮编区号：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="ZipNumber" class="editText" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                热门搜索关键字：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="MenPiaoLinks" class="editText" Width="500px"></asp:TextBox>(关键字用空格分隔)
            </td>
        </tr>
        <!--
        <tr class="lr_hangbg">
            <td align="right">
                线路订单积分兑换：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtRouteTatol" Text="0" class="editText" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"> 
</asp:TextBox>元=1积分
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                景点订单积分兑换：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtScenicTatol" Text="0" class="editText" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"> 
</asp:TextBox>元=1积分
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                酒店订单积分兑换：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtHotelTatol" Text="0" class="editText" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"> 
</asp:TextBox>元=1积分
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                签证订单积分兑换：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtQianZhengDingDanJiFenPeiZhi" Text="0" class="editText"
                    Width="50px" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"> 
</asp:TextBox>元=1积分
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                机票订单积分兑换：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtJiPiaoDingDanJiFenPeiZhi" Text="0" class="editText"
                    Width="50px" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"> 
                </asp:TextBox>元=1积分
            </td>
        </tr>-->
        <tr>
            <td height="35" colspan="2" align="center" bgcolor="#FFFFFF">
                <table cellspacing="0" cellpadding="0" border="0" align="center">
                    <tbody>
                        <tr>
                            <td height="20" align="center" class="tjbtn02">
                                <asp:LinkButton runat="server" ID="btnSave">保存</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table><br /><br />
    </form>

    <script type="text/javascript">
        var WebSiteInfo = {
            isSubmit: false,
            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        resizeMode: 0,
                        items: keSimple,
                        height: $(this).attr("data-height") == undefined ? "200px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "680px" : $(this).attr("data-width")
                    });
                });
            },
            CheckForm: function() {
                KEditer.sync();

                return true;
            },
            DoSubmit: function() {
                WebSiteInfo.isSubmit = true;
                WebSiteInfo.FormSubmit();
            },
            FormSubmit: function() {
                $("#<%= btnSave.ClientID %>").closest("form").submit();
            }
        };

        $(document).ready(function() {

            //WebSiteInfo.InitEdit();

            swfUploadHandler.init({
                movies: [window["<%=upload1.ClientID %>"]],
                startFn: function() { $("#<%= btnSave.ClientID %>").unbind("click").html("正在提交").css({ "color": "#999999" }) /*开始上传事件*/ },
                completeFn: function() { WebSiteInfo.FormSubmit(); /*完成上传事件*/ }
            });

            $("#<%= btnSave.ClientID %>").click(function() {
                if (!WebSiteInfo.CheckForm()) {
                    return false;
                }

                var swfFile = window["<%=upload1.ClientID %>"];
                if (swfFile != null && swfFile.getStats().files_queued > 0) {
                    swfFile.startUpload();

                    return false;
                }
                return true;
            });
        });
    </script>

</body>
</html>
