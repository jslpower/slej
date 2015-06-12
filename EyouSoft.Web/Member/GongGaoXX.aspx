<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="GongGaoXX.aspx.cs" Inherits="EyouSoft.Web.Member.GongGaoXX" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

    <script type="text/javascript">

    </script>

    <script language="javascript" type="text/javascript">

        $(document).ready(function() {
            $(".left_menu ul li").menu();
        }); 
    </script>

    <style type="text/css">
        .companyin
        {
            border: 1px #e5e5e5 solid;
            line-height: 200%;
            padding: 20px;
        }
        .companyin p
        {
            text-indent: 2em;
        }
        .companyin h1
        {
            font-size: 18px;
            color: #000;
            font-weight: bold;
            text-align: center;
            line-height: 200%;
        }
        .companyin h3
        {
            font-size: 12px;
            color: #474747;
            text-align: center;
            border-bottom: #ccc dashed 1px;
            font-weight: normal;
            margin-bottom: 10px;
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
                &gt; 会员公告</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 会员公告</span></div>
        <div class="companyin margin_T10">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
            </h1>
            <h3>
                <asp:Label ID="lblResource" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
            </h3>
            <p>
            
                <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label><br>
                <asp:Literal ID="litFile" runat="server"></asp:Literal>
            </p>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
