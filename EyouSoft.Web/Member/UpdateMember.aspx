<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true"
    CodeBehind="UpdateMember.aspx.cs" Inherits="EyouSoft.Web.Member.UpdateMember" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<%@ Register Src="/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
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
                    用户名：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtaccount" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"></asp:TextBox>
                </td>
            </tr>
            <%if (IsFenXiao == 1)
              {%>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    公司名称：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtComanyName" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    公司简称：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtCompanyJC" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"></asp:TextBox>
                </td>
            </tr>
            <%} %>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    会员身份：
                </td>
                <td width="75%">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    <span style="color: Red;">*</span>姓名：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtmember" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"
                        valid="required|isName" errmsg="姓名不能为空|请填写正确的姓名!"></asp:TextBox>
                </td>
            </tr>
            <%--<tr style="height: 40px;">
                <td width="25%" align="right">
                    昵称：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtnickname" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"></asp:TextBox>
                </td>
            </tr>--%>
            <%if (IsFenXiao == 1)
              {%>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    头像：
                </td>
                <td width="75%">
                    <uc2:UploadControl ID="UploadControl1" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                        IsUploadMore="false" runat="server" />
                    <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                </td>
            </tr>
            <%} %>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    性别：
                </td>
                <td width="75%">
                    <asp:RadioButtonList ID="Gender" runat="server" RepeatColumns="2" Width="200px">
                        <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    出生日期：
                </td>
                <td width="75%">
                    <input id="txtBirthDate" runat="server" onfocus="WdatePicker()" type="text" style="width: 400px;
                        height: 30px;" class="input_bluebk" valid="isDate" errmsg="请正确填写生日!" />
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    电话：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtContact" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"
                        valid="isTel" errmsg="请正确填写电话号码!"></asp:TextBox>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    <span style="color: Red;">*</span>手机：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtmoblie" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"
                        valid="required|isMobile" errmsg="手机不能为空!|请正确填写手机号码!"></asp:TextBox>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    QQ：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtqq" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"
                        valid="isQQ" errmsg="请正确填写QQ号码!"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    E-Mail：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtEmail" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"
                        valid="isEmail" errmsg="请正确填写Email!"></asp:TextBox>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    地址：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtAddress" runat="server" Width="400px" Height="30px" CssClass="input_bluebk"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    有效日期：
                </td>
                <td width="75%">
                    <asp:Label ID="lbl_validDate" runat="server" Text=""></asp:Label><asp:Literal ID="litNoticeMsg"
                        runat="server"></asp:Literal>
                </td>
            </tr>
            <%--<tr style="height: 40px;" id="FenShow" runat="server">
                <td width="25%" align="right">
                    是否显示代理申请：
                </td>
                <td width="75%">
                    <asp:RadioButtonList ID="ShowHidden" runat="server" RepeatColumns="2" Width="200px">
                        <asp:ListItem Value="0" Selected="True">显示</asp:ListItem>
                        <asp:ListItem Value="1">隐藏</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <%if (IsFenXiao == 1)
              {%>
            <tr style="height: 40px;">
                <td width="25%" align="right">
                    选择首页模版：
                </td>
                <td width="75%">
                       <select id="ddlNav" name="ddlNav" class="inputselect">
                            <%=BindNav(DaiLiNavNum.ToString())%>
                        </select>
                </td>
            </tr>
            <tr style="height: 40px;" id="Tr1" runat="server">
                <td width="25%" align="right">
                    公司介绍：
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="editText"></asp:TextBox>
                </td>
            </tr>
            <%} %>--%>
        </table>
        <div class="u-btn tjbtn02" style="padding-top: 15px; padding-left: 300px;">
            <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" >保存 >></asp:LinkButton>--%>
            <a href="javascript:;" id="btn">保存 >></a>
            <%--<a href="#" onclick="">保存 >></a>--%>
            <%--<a href="#">返回 >></a>--%>
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
                var url = '/Member/UpdateMember.aspx?type=update';
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
                                parent.location.href = parent.location.href;
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
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DelImg: function(obj) {
                $(obj).parent().prev("img").remove();
                $(obj).parent().remove();
            },
            BindBth: function() {
                $("#btn").click(function() {
                    PageInfo.Sava(); return false;
                });
            },
            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        items: keSimple,
                        height: $(this).attr("data-height") == undefined ? "360px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "580px" : $(this).attr("data-width")
                    });
                });
            }
        };
        $(function() {
            //PageInfo.InitEdit();
            PageInfo.BindBth();
        });
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
