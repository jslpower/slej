<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="GongGao.aspx.cs" Inherits="EyouSoft.Web.Member.GongGao" %>

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
            background: url(../images/newlistpic.gif) no-repeat left center;
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
                &gt; 会员公告</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 会员公告</span></div>
        <div class="newslist margin_T10">
            <ul>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li><a href="GongGaoXX.aspx?id=<%# Eval("ArticleID") %>">
                            <%# Eval("ArticleTitle")%></a><em><%# Eval("IssueTime","{0:yyyy-MM-dd}")%></em></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="page" id="page">
        </div>
    </div>
    <form id="form1" runat="server">
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
