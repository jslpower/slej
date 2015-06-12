<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StrategyEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Strategy.StrategyEdit" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单管理</title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="850" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
            <tbody>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>攻略名称:
                        <input type="hidden" id="hidOpLX" runat="server" />
                        <input type="hidden" id="hidOp" runat="server" />
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txt_gonglue" runat="server" valid="required" errmsg="攻略名称不能为空"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        目的地:
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txt_mudidi" runat="server"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        旅行时间:
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txt_lvxingshijian" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        旅行花费:
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txt_lvxinghuafei" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>主题：
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:DropDownList ID="ddlThemeID" runat="server" CssClass="inputselect" valid="required"
                            errmsg="请选择主题">
                        </asp:DropDownList>
                    </td>
                    <th width="10%" height="30" align="right">
                        首页显示:&nbsp;
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:CheckBox ID="chk_xianshi" runat="server" />是
                    </td>
                    <th width="10%" height="30" align="right">
                        是否头条
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:CheckBox ID="chk_toutiao" runat="server" />是
                    </td>
                    <th width="10%" height="30" align="right">
                        是否审核
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:CheckBox ID="chk_shenhe" runat="server" Checked="true" />是
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        图片:
                    </th>
                    <td width="15%" bgcolor="#E3F1FC" colspan="5">
                        &nbsp;<uc1:UploadControl runat="server" ID="upload1" />
                    </td>
                    <th align="right">
                        排序:
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:DropDownList runat="server" ID="ddlSort" CssClass="inputselect">
                            <asp:ListItem Text="-请选择-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="低" Value="1"></asp:ListItem>
                            <asp:ListItem Text="常规" Value="2" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="高" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="70" align="right">
                        旅行建议:
                    </th>
                    <td width="15%" bgcolor="#E3F1FC" colspan="7">
                        &nbsp;<asp:TextBox ID="txt_jianyi" runat="server" TextMode="MultiLine" Height="50px"
                            Width="700px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="110" align="right">
                        旅行内容:
                    </th>
                    <td width="15%" bgcolor="#E3F1FC" colspan="7">
                        &nbsp;<asp:TextBox ID="txt_neirong" runat="server" TextMode="MultiLine" Height="100px"
                            Width="700px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="center" colspan="8">
                        <table width="304" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="158" height="40" align="center" class="tjbtn02">
                                        <a id="btn_save" href="javascript:;" runat="server">保存</a>
                                    </td>
                                    <td width="158" height="40" align="center">
                                        <span class="tjbtn02"><a onclick="window.parent.Boxy.getIframeDialog('iframe57').hide();return false;"
                                            href="javascipt:;">关闭</a></span>
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

    <script type="text/javascript">

        var Strategy = {
            PageInit: function() {

                //初始化上传控件
                swfUploadHandler.init({
                    movies: [window["<%=upload1.ClientID %>"]],
                    startFn: function() { },
                    completeFn: function() {
                        var url = "/WebMaster/Strategy/StrategyEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                        Strategy.GoAjax(url);
                    }
                });


                $("#<%=btn_save.ClientID %>").click(function() {
                    if (!Strategy.CheckForm()) {
                        return false;
                    }

                    //上传控件
                    var swfFile = window["<%=upload1.ClientID %>"];
                    if (swfFile != null && swfFile.getStats().files_queued > 0) {
                        swfFile.startUpload();
                        return false;
                    }
                    var url = "/WebMaster/Strategy/StrategyEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    Strategy.GoAjax(url);
                });
            },
            GoAjax: function(url) {
                Strategy.UnBind();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn_save.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
                            Strategy.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        Strategy.Bind();
                    }
                });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn_save.ClientID %>").closest("form").get(0), "parent");
            },
            Bind: function() {
                var _selfs = $("#<%=this.btn_save.ClientID %>");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (!Strategy.CheckForm()) {
                        return false;
                    }
                    var url = "/WebMaster/Strategy/StrategyEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    Strategy.GoAjax(url);
                    return false;
                });
            },
            UnBind: function() {
                $("#<%=this.btn_save.ClientID %>").html("提交中...");
                $("#<%=this.btn_save.ClientID %>").unbind("click");
            }
        };

        $(function() {
            Strategy.PageInit();
        });
    
    </script>

</body>
</html>
