<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="UpCompanyJieShao.aspx.cs" Inherits="EyouSoft.Web.Member.UpCompanyJieShao" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor.js"></script>

    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $(".left_menu ul li").menu();
        }); 
    </script>

    <style type="text/css">
        .doti
        {
            background-color: #c1def0;
            border: #c1def0 solid 1px;
            text-align: right;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <form id="form1" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 修改资料</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 修改资料</span></div>
        <table width="100%" border="0" class="tableList margin_T10" id="tableInfo">
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    公司介绍：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="editText"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="u-btn tjbtn02" style="padding-top: 15px; padding-left: 300px;">
            <a href="javascript:;" id="btn">保存 >></a>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">

    <script type="text/javascript">


        var PageInfo = {
            Sava: function() {
                var url = '/Member/UpCompanyJieShao.aspx?type=update';
                PageInfo.GoAjax(url);
            },
            GoAjax: function(url) {
                KEditer.sync();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                                location.href = location.href;
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
                $("#btn").click(function() {
                    PageInfo.Sava(); return false;
                });
            },
            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        items: keSimple_HaveImage,
                        height: $(this).attr("data-height") == undefined ? "360px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "680px" : $(this).attr("data-width")
                    });
                });
            }
        };
        $(document).ready(function() {
            PageInfo.InitEdit();
            PageInfo.BindBth();
        });
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
