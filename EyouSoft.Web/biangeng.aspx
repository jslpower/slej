<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="biangeng.aspx.cs" Inherits="EyouSoft.Web.biangeng" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="/css/style.css" rel="stylesheet" type="text/css" />

<script src="/js/jquery-1.4.2.min.js"></script>

<script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

<script src="/JS/table-toolbar.js" type="text/javascript"></script>

<script src="/JS/jquery.boxy.js" type="text/javascript"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="hangban_box">
        <ul>
            <asp:Repeater ID="rptlist" runat="server">
                <ItemTemplate>
                    <li>
                        <input class="traffid" name="traffid" type="radio" value="<%# Eval("TrafficId") %>" />
                        <span class="hangban_txt">
                            <p>
                                <strong class="fontyellow">往：</strong>
                                <%# Eval("Traffic_01")%></p>
                            <p>
                                <strong style="color: #474747;">返：</strong>
                                <%# Eval("Traffic_02")%>
                            </p>
                        </span></li>
                </ItemTemplate>
            </asp:Repeater>
            <li style="text-align: center; padding-top: 10px;"><a id="aidSelect" href="javascript:;"
                class="hb-btn">确认</a></li>
        </ul>
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            $("#aidSelect").click(function() {
                if ($(".traffid:checked").length < 1) { alert("请选择航班"); return false; }
                //$(parent.window["hidhangban"]).val($(".traffid:checked").val());
                if ($(".traffid:checked").length == 1) {
                    parent.window.location.href = '/xianluyuding.aspx?id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>&type=' + '<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>&hangban=' + $(".traffid:checked").val();
                }
                parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
            })
        })
    </script>

</body>
</html>
