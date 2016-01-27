<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="FenXiang.aspx.cs" Inherits="EyouSoft.Web.Member.FenXiang" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />

    <script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

    <script type="text/javascript">

    </script>

    <script language="javascript" type="text/javascript">
        pagingConfig = { pageSize: 10, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };

        $(document).ready(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
            $(".left_menu ul li").menu();
        }); 
    </script>

    <style type="text/css">
        .newslist
        {
            padding: 3px;
            border: #ccc solid 1px;
        }
        .newslist ul
        {
            line-height: 30px;
            width: 96%;
            margin: 0 auto;
        }
        .newslist li
        {
            border-bottom: 1px #999999 dotted;
            height: 30px;
            text-indent: 20px;
            position: relative;
            background: url(/images/newlistpic.gif) no-repeat left center;
        }
        .newslist li a
        {
            font-size: 14px;
        }
        .newslist li a:hover
        {
            color: #f60;
        }
        .newslist li em
        {
            position: absolute;
            right: 5px;
            top: 0;
            color: #999999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; E家分享</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > E家分享</span></div>
        <div class="user_Rbox margin_T10">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="chzh_t">
                <tbody>
                    <tr>
                        <td colspan="4" class="noborder" style="padding-bottom: 10px;">
                            <a href="javascript:;" class="u-01 toolbar_add">新增</a>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            标题
                        </th>
                        <th>
                            发布时间
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rptlist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# Container.ItemIndex+1 %>
                                </td>
                                <td align="center">
                                    <%#  Eval("YouJiTitle") %>
                                </td>
                                <td align="center">
                                    <%# Eval("IssueTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td align="center" data-id="<%# Eval("YouJiid") %>">
                                    <a href="javascript:;" class="fontgreen toolbar_update">编辑</a> | <a href="javascript:;"
                                        class="fontred toolbar_delete">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="ltrNoMsg" runat="server" Visible="false"><tr><td align="center" colspan="4">暂无数据</td></tr></asp:Literal>
                </tbody>
            </table>
            <div class="page" id="page">
            </div>
        </div>
        <div class="newslist margin_T10">
            <ul>
            </ul>
        </div>
    </div>
    <form id="form1" runat="server">
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">

    <script type="text/javascript">
        $(function() {
            $(".toolbar_add").click(function() { location.href = "FenXiangEdit.aspx?dotype=add" })//
            $(".toolbar_delete").click(function() {
                var ajaxurl = "FenXiang.aspx?dotype=DelYouJi&youjid=" + $(this).parent().attr("data-id");
                if (confirm("确认删除操作？")) {
                    $.ajax({ url: ajaxurl, dataType: "json", async: false,
                        success: function(ret) {
                            alert(ret.msg);
                            location.href = location.href;
                        },
                        error: function() {
                            alert("未知错误");
                        }
                    });
                }
            })//
            $(".toolbar_update").click(function() {
                var ajaxurl = "FenXiangEdit.aspx?youjid=" + $(this).parent().attr("data-id");
                location.href = ajaxurl;
            })//

        })
   
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
