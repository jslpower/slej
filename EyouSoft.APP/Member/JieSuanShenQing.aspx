<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieSuanShenQing.aspx.cs"
    Inherits="EyouSoft.WAP.Member.JieSuanShenQing" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>结算申请</title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <style>
        .user_form li
        {
            padding-left: 115px;
        }
    </style>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="结算申请" />
    <form runat="server" id="form1">
    <div class="warp">
        <div class="paddL paddT">
            结算申请</div>
        <div class="jq_tab zhifu_tab mt10" id="n4Tab">
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                    <div class="user_form">
                        <ul>
                            <li style="padding-left: 10px;" class="font_yellow font14">您已结算<asp:Literal ID="YiJieSuan"
                                runat="server"></asp:Literal>元</li>
                            <li style="padding-left: 10px;" class="font_yellow font14">您还有<asp:Literal ID="DongJie"
                                runat="server"></asp:Literal>元正在审核</li>
                            <li style="padding-left: 10px;" class="font_yellow font14">您还可结算<asp:Literal ID="KeJieSuan"
                                runat="server"></asp:Literal>元<asp:HiddenField ID="KeTiQuJinE" runat="server" />
                            </li>
                            <li><span class="label_name">结算金额</span>
                                <input name="txtYongJinJinE" type="text" class="u-input" id="txtYongJinJinE" />
                            </li>
                        </ul>
                    </div>
                    <div class="padd cent">
                        <input name="" type="button" class="y_btn" value="确认结算" id="btn" /></div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var PageInfo = {
            Sava: function() {
                if (!PageInfo.CheckForm()) {
                    return false;
                }
                var url = '/Member/JieSuanShenQing.aspx?type=jiesuan';
                PageInfo.GoAjax(url);
            },
            CheckForm: function() {
                if ($("#txtYongJinJinE").val() == "") {
                    alert("结算金额不能为空！");
                    $("#txtYongJinJinE").focus();
                    return false;
                }
                else {
                    if (!/^\d+(\.\d+)?$/.test($("#txtYongJinJinE").val())) {
                        alert('请填写正确的结算金额');
                        $("#txtYongJinJinE").focus();
                        return false;
                    }
                    else {
                        var jifentop = $("#<%= KeTiQuJinE.ClientID%>").val();
                        if (parseFloat(jifentop) < parseFloat($("#txtYongJinJinE").val())) {
                            alert('您输入的结算金额超过您的可结算金额');
                            $("#txtYongJinJinE").focus();
                            return false;
                        }
                        if (parseInt($("#txtYongJinJinE").val()) % 10 != 0) {
                            alert("申请结算的金额只能是10的倍数");
                            return false;
                        }
                    }
                }
                return true;
            },
            GoAjax: function(url) {
                //KEditer.sync();
                $.ajax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg)
                            parent.location.href = "/member/ZengZhi.aspx";
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("申请失败，请重试！");
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

</body>
</html>
