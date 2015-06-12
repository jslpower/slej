<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="MyChongzhi.aspx.cs" Inherits="EyouSoft.Web.Member.MyChongzhi" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/style.css" rel="stylesheet" />

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <link href="/Css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

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
                &gt; 账户充值</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 账户充值</span></div>
        <table width="100%" border="0" class="tableList margin_T10" style="padding-top: 50px;">
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    充值金额：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtjine" runat="server" CssClass="inputbk formsize180" valid="required|isMoney"
                        errmsg="请填写充值金额!|请填写正确的充值金额！"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="u-btn tjbtn02" style="padding-top: 15px; padding-left: 300px;">
            <a href="javascript:;" id="btn">提交>></a>
        </div>
        <a id="aaa" target="_blank"></a>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">

    <script type="text/javascript">

        $(function() {

            $("#btn").click(function() {
                if (!ValiDatorForm.validator($("#btn").closest("form").get(0), "alert"))
                { return false; }
                $.ajax({
                    type: "post",
                    cache: false,
                    url: '/Member/MyChongzhi.aspx?chongzhi=1',
                    dataType: "json",
                    data: $("#btn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            Boxy.iframeDialog({ iframeUrl: '/Member/QueRenCz.aspx?id=' + ret.obj, title: '确认充值金额', modal: true, width: 300, height: 130 });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })
            })
        })
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
