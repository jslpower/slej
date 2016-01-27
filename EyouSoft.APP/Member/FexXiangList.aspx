<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FexXiangList.aspx.cs" Inherits="EyouSoft.WAP.Member.FexXiangList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html >
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>E家分享</title>
    <link href="/css/fenxiang.css" rel="stylesheet" type="text/css" />
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="E家分享" />
    <div class="warp">
        <div class="fenxiang_list">
            <ul>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="title">
                                <%# EyouSoft.Common.Utils.GetText( Eval("YouJiTitle").ToString(),15,true)%></a>
                            </div>
                            <div class="name">
                                <%#Eval("HuiYuanName")%></div>
                            <div class="time" data-id="<%# Eval("YouJiid") %>"">
                                <%#Eval("IssueTime","{0:yyyy-MM-dd}")%><a href="javascript:;" class="btn toolbar_delete">删除</a><a
                                    href="javascript:;" class="btn2 toolbar_update">编辑</a></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="ltrNoMsg" runat="server" Visible="false"><li style="text-align:center">暂无数据</li></asp:Literal>
            </ul>
        </div>
    </div>
    <div class="pay">
        <div class="pay_box">
            <a class="add_fx" href="FenXiangFaBu.aspx">
                <div data-text="+" class="ico">
                </div>
                新增发布</a>
        </div>
    </div>

    <script type="text/javascript">
        $(function() {
            $(".toolbar_add").click(function() { location.href = "FenXiangFaBu.aspx?dotype=add" })//
            $(".toolbar_delete").click(function() {
                var ajaxurl = "FexXiangList.aspx?dotype=DelYouJi&youjid=" + $(this).parent().attr("data-id");
                if (confirm("确认删除操作？")) {
                    $.ajax({ url: ajaxurl, dataType: "json", async: false,
                        success: function(ret) {
                            alert(ret.msg);
                            location.href = location.href;
                        },
                        error: function() {
                            alert("未知错误");
                        }
                    });
                }
            })//
            $(".toolbar_update").click(function() {
                var ajaxurl = "FenXiangFaBu.aspx?youjid=" + $(this).parent().attr("data-id");
                location.href = ajaxurl;
            })//

        })
   
    </script>

</body>
</html>
