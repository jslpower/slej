<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinXinBind.aspx.cs" Inherits="EyouSoft.WAP.WinXinBind" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>微店绑定</title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>


</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="微店绑定" />
    <form id="form1">
    <div class="warp">
        <div class="user_form">
            <ul>
                <li><span class="label_name">用户名</span>
                    <input id="u-Name" name="u-Name" type="text" class="u-input" value="" placeholder="用户名/手机号">
                </li>
                <li><span class="label_name">密 码</span>
                    <input id="u-Pwd" name="u-Pwd" type="password" class="u-input" value="" placeholder="6-20位字母、数字和字符">
                </li>
            </ul>
        </div>
        <div class="mt10 paddR right_txt">
        </div>
        <div class="padd cent">
            <input type="button" class="y_btn" value="确定" /></div>
    </div>
    <input type="hidden" name="openid" id="openid" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("openid") %>" />
    </form>

    <script type="text/javascript">
        var pageOpt = {
            save: function() {
                $(".y_btn").unbind("click");
                $.ajax({
                    type: "post",
                    url: "WinXinBind.aspx?save=save&",
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert("绑定成功，请等待审核!");
                            location.href = ret.obj; //'/Member/DingDanList.aspx?ordertype=3';
                        } else {
                            alert(ret.msg);
                        }

                    },
                    error: function() {
                        alert("数据丢失！");
                    }
                });
                $(".y_btn").bind("click", function() { pageOpt.save(); });
            }
        }
        $(function() {
            $(".y_btn").click(function() {
                var msg = "";
                if (!/^(13|15|18|14)\d{9}$/.test($("#u-Name").val())) {
                    alert("账号格式错误");
                    return false;
                }
                pageOpt.save();

            })
        })
    </script>

</body>
</html>
