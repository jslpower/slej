<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChongZhi.aspx.cs" Inherits="EyouSoft.WAP.Member.ChongZhi" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>账户充值</title>
    <link rel="stylesheet" href="/css/zhifu.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1">
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="账户充值" />
    <div class="warp">
        <div class="paddL paddT">
            账户充值</div>
        <div class="jq_tab zhifu_tab mt10" id="n4Tab">
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                    <div class="user_form">
                        <ul>
                            <li><span class="label_name"></span><span class="font18 font_yellow">
                                <asp:Literal ID="MyMoney" runat="server"></asp:Literal></span> </li>
                            <li><span class="label_name">充值金额</span>
                                <input name="txtjine" type="text" class="u-input" id="txtjine" />
                            </li>
                        </ul>
                    </div>
                    <div class="padd cent">
                        <input name="" type="button" class="y_btn" value="充值" id="epay" /></div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">

        $(function() {

            $("#epay").click(function() {
                var $jine = $("#txtjine").val();
                if ($jine == null || $jine == 'undefined' || $jine == "" || parseInt($jine) <= 0 || isNaN(parseInt($jine)))
                { alert("请核查充值金额"); return false; }
                $.ajax({
                    type: "post",
                    cache: false,
                    url: '/Member/ChongZhi.aspx?chongzhi=1',
                    dataType: "json",
                    data: $("#epay").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result != "0") {
                            if (confirm("确认充值金额[" + ret.result + "]"))
                            { location.href = "/alipay/default.aspx?orderid=" + ret.obj + "&type=11&token=" + ret.msg }
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("数据错误");
                    }
                })
            })
        })
    </script>

</body>
</html>
