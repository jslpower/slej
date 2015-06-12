<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMember.aspx.cs" Inherits="EyouSoft.WAP.Member.UpdateMember" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>会员中心</title>

    <script src="../js/jq.mobi.min.js" type="text/javascript"></script>

    <style>
        .user_form li
        {
            padding-left: 115px;
        }
    </style>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <form id="form1" runat="server">
    <div class="warp">
        <div class="user_form">
            <ul>
                <li><span class="label_name">姓名</span>
                    <asp:TextBox ID="txtmember" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <%if (IsFenXiao == 1)
                  {%>
                <li><span class="label_name">公司名称</span>
                    <asp:TextBox ID="txtComanyName" Enabled="false" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <li><span class="label_name">公司简称</span>
                    <asp:TextBox ID="txtCompanyJC" Enabled="false" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <%} %>
                <li><span class="label_name">会员身份</span>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </li>
                <li><span class="label_name">性别</span> <span class="font_gray">
                    <asp:RadioButtonList ID="Gender" runat="server" RepeatColumns="2" Width="200px">
                        <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                </span></li>
                <li><span class="label_name">出生日期</span>
                    <asp:TextBox ID="txtBirthDate" Enabled="false" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <li><span class="label_name">电话</span>
                    <asp:TextBox ID="txtContact" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <li><span class="label_name">手机</span>
                    <asp:TextBox ID="txtmoblie" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <li><span class="label_name">QQ</span>
                    <asp:TextBox ID="txtqq" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <li><span class="label_name">E-mail</span>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="u-input"></asp:TextBox>
                </li>
                <li style="line-height: normal;"><span class="label_name">地址</span>
                    <textarea id="txtAddress" runat="server" class="u-input u-txtarea"></textarea>
                </li>
                <li id="FenXiao" runat="server"><span class="label_name">有效日期</span>
                    <asp:Label ID="lbl_validDate" runat="server" Text=""></asp:Label>&nbsp;<asp:Literal ID="litNoticeMsg"
                        runat="server"></asp:Literal>
                </li>
                <%if (IsFenXiao == 1)
                  {%>
                <li><span class="label_name">显示代理申请</span> <span class="font_gray">
                    <asp:RadioButtonList ID="ShowHidden" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="0" Selected="True">显示</asp:ListItem>
                        <asp:ListItem Value="1">隐藏</asp:ListItem>
                    </asp:RadioButtonList>
                    <%--<asp:RadioButtonList ID="ShowHidden" runat="server" RepeatColumns="2">
                        
                    </asp:RadioButtonList>--%>
                </span></li>
                <li><span class="label_name">选择首页模板</span> <span class="font_gray">
                    <asp:RadioButtonList ID="ddlNav" runat="server" RepeatColumns="2" Width="200px">
                        <asp:ListItem Value="0">主站模板</asp:ListItem>
                        <asp:ListItem Value="1">代理商模板</asp:ListItem>
                    </asp:RadioButtonList>
                </span></li>
                <%} %>
            </ul>
        </div>
        <div class="padd cent">
            <input type="button" class="y_btn" id="btn" value="保存"></div>
    </div>
    </form>
</body>

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
            if ($("#<%=txtmember.ClientID %>").val() == "") {
                alert("姓名不能为空！");
                $("#<%=txtmember.ClientID %>").focus();
                return false;
            }
            else {
                if (!/^[\u4e00-\u9fa5a-zA-Z_]+$/.test($("#<%=txtmember.ClientID %>").val())) {
                    alert('请填写您的正确姓名');
                    $("#<%=txtmember.ClientID %>").focus();
                    return false;
                }
            }
            if ($("#<%=txtmoblie.ClientID %>").val() == "") {
                alert("手机号码不能为空！");
                $("#<%=txtmoblie.ClientID %>").focus();
                return false;
            }
            else {
                if (!/^(13|15|18|14)\d{9}$/.test($("#<%=txtmoblie.ClientID %>").val())) {
                    alert('请填写正确的手机号码');
                    $("#<%=txtmoblie.ClientID %>").focus();
                    return false;
                }
            }
            if ($("#<%=txtContact.ClientID %>").val() != "") {
                if (!/^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-?)?[1-9]\d{6,7}(\-\d{1,4})?$|^(13|15|18|14)\d{9}$/.test($("#<%=txtContact.ClientID %>").val())) {
                    alert('请填写正确的电话');
                    $("#<%=txtContact.ClientID %>").focus();
                    return false;
                }
            }
            if ($("#<%=txtqq.ClientID %>").val() != "") {
                if (!/^[1-9]\d{4,10}$/.test($("#<%=txtqq.ClientID %>").val())) {
                    alert('请填写正确的QQ号');
                    $("#<%=txtqq.ClientID %>").focus();
                    return false;
                }
            }
            if ($("#<%=txtEmail.ClientID %>").val() != "") {
                if (!/([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)/.test($("#<%=txtEmail.ClientID %>").val())) {
                    alert('请填写正确的E-Mail');
                    $("#<%=txtEmail.ClientID %>").focus();
                    return false;
                }
            }
            return true;
        },
        GoAjax: function(url) {
            $.ajax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        alert(ret.msg);
                        window.location.href = window.location.href;
                    }
                    else {
                        alert(ret.msg);
                        window.location.href = window.location.href;
                    }
                },
                error: function() {
                alert("修改失败，请重试！");
                window.location.href = window.location.href;
                }
            });
        },
        BindBth: function() {
            $("#btn").click(function() {
                PageInfo.Sava(); return false;
            });
        }
    };
    $(function() {
        PageInfo.BindBth();
    });
</script>

</html>
