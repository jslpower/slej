<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="FenXiangEdit.aspx.cs" Inherits="EyouSoft.Web.Member.FenXiangEdit" %>

<%@ Register Src="../WebMaster/UserControl/FenXiang.ascx" TagName="FenXiang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $(".left_menu ul li").menu();
        }); 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <div class="mainbox">
        <div class="title_bar">
            <h4>
                &gt; 我的订单</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 我的订单</span></div>
        <div class="mt10" style="padding-bottom: 10px;">
            <table width="100%" border="0" class="tableList margin_T10">
                <tbody>
                    <tr>
                        <td width="120" height="30" align="right" bgcolor="#EDF8FF">
                            <strong style="color: #474747;">分享标题：</strong>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTitle" runat="server" valid="required" errmsg="标题不可为空!" CssClass="inputbk formsize400"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="right" bgcolor="#EDF8FF">
                            <strong style="color: #474747;">链接地址：</strong>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLink" runat="server" CssClass="inputbk formsize400" name="txtAdvLink"
                                valid="isUrl" errmsg="链接格式错误!"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <uc1:FenXiang ID="FenXiang1" runat="server" />
            <div class="u-btn tjbtn02 mt10" style="text-align: center;">
                <a id="save" href="javascript:;">保存 &gt;&gt;</a> <a href="FenXiang.aspx">返回 &gt;&gt;</a>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">

    <script type="text/javascript">
        var pageOpt = {
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
                            tableToolbar._showMsg(ret.msg, function() { location.href = "FenXiang.aspx"; });
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
                return ValiDatorForm.validator($("#save").closest("form").get(0), "alert");
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DelImg: function(obj) {
                $(obj).parent().prev("img").remove();
                $(obj).parent().remove();
            }
        };
        $(function() {

            $("#tbl_Journey_AutoAdd").autoAdd({ addCallBack: Journey.AddRowCallBack, upCallBack: Journey.MoveRowCallBack, downCallBack: Journey.MoveRowCallBack });
            $("#save").click(function() {
                if (pageOpt.CheckForm()) {
                    $(this).html("提交中");
                    pageOpt.GoAjax('FenXiangEdit.aspx?type=save&dotype=<%=Request.QueryString["dotype"] %>&youjid=<%=Request.QueryString["youjid"] %>', $(this));
                }
            })

        })
       
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
