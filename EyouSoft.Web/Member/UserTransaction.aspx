<%@ Page Title="账户余额" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="UserTransaction.aspx.cs" Inherits="EyouSoft.Web.Member.UserTransaction" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />

    <script src="/Js/menu_min.js"></script>

    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $(".left_menu ul li").menu();
        }); 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:UserLeft runat="server" ID="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <form id="form1" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; E额宝余额管理</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > E额宝余额管理</span></div>
        <div class="user_Rbox margin_T10">
            <div class="R_title">
                资金账户</div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="zh_t">
                <tr>
                    <th>
                        您的剩余金额
                    </th>
                    <th>
                        冻结金额
                    </th>
                    <th>
                        可用金额
                    </th>
                </tr>
                <tr>
                    <td class="fontgreen">
                        ¥
                        <%= mymoney.ToString("F2")%>
                    </td>
                    <td class="fontgreen">
                        ¥
                        <asp:Literal ID="DongjieJinE" runat="server"></asp:Literal>
                    </td>
                    <td class="fontgreen">
                   <%= mymoney.ToString("F2")%>
                    </td>
                </tr>
            </table>
            <div class="u-btn">
                <a href="/Member/MyChongzhi.aspx?tp=1" class="u-01">充值 >></a> <a href="/Member/MyTiXian.aspx"
                    class="u-02">提现 >></a> <a href="SetPassWord.aspx" class="u-03">设置支付密码</a>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
