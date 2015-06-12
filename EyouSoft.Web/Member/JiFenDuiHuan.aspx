<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="JiFenDuiHuan.aspx.cs" Inherits="EyouSoft.Web.Member.JiFenDuiHuan" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/JS/jquery.blockUI.js" type="text/javascript"></script>
<script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
<script src="/JS/table-toolbar.js" type="text/javascript"></script>
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
                &gt; E额宝增值管理</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > E额宝增值管理</span></div>
        <div class="user_Rbox margin_T10">
            <div class="R_title">
                积分兑换</div>
            <div class="zhifu_box">
                <ul style="padding-bottom: 0;">
                    <li><span>兑换积分：</span>
                        <input id="JiFenNum" name="JiFenNum" valid="required|isNumber" errmsg="手机不能为空!|积分输入错误!" type="text" class="input_bluebk formsize180" />(您最高可兑换<asp:Literal ID="JiFen" runat="server"></asp:Literal>积分)<asp:HiddenField ID="JiFenTop" runat="server" />
                    </li>
                </ul>
            </div>
            <div class="u-btn tjbtn02">
                <a href="javascript:void(0);" id="btn">确定兑换</a> <a href="ZengZhi.aspx">返回 >></a>
            </div>
        </div>
    </div>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
<script type="text/javascript">
    var PageInfo = {
        Sava: function() {
            if (!PageInfo.CheckForm()) {
                return false;
            }
            var url = '/Member/JiFenDuiHuan.aspx?type=add';
            PageInfo.GoAjax(url);
        },
        CheckForm: function() {
            return ValiDatorForm.validator($("#btn").closest("form").get(0), "alert");
        },
        GoAjax: function(url) {
            //KEditer.sync();
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() {
                        parent.location.href = "/member/ZengZhi.aspx";
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
            $("#JiFenNum").blur(function() {
                if (!/^[-\+]?\d+(\.\d+)?$/.test($("#JiFenNum").val())) {
                    alert('积分数值输入错误');
                    $("#JiFenNum").val("0");
                    $("#JiFenNum").focus();
                    return false;
                }
                else {
                    var jifentop = $("#<%= JiFenTop.ClientID%>").val();
                    if (tableToolbar.getInt(jifentop) < tableToolbar.getInt($("#JiFenNum").val())) {
                        alert('您输入的兑换积分超过您的现有积分');
                        $("#JiFenNum").focus();
                        return false;
                    }
                }
            })
        }
    };
    $(function() {
        PageInfo.BindBth();
    });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
