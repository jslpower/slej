<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDate.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.SelectDate" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/jipiao.sanzima.js" type="text/javascript"></script>

</head>
<body>
    <form id="myform" method="post">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="选择日期" />
    <div class="warp paddB">
        <asp:Literal ID="litMonth" runat="server"></asp:Literal>
    </div>
    <input type="hidden" name="rili" id="rili" value="<%= EyouSoft.Common.Utils.GetFormValue("rili") %>" />
    <input type="hidden" name="startcity" id="startcity" value="<%= EyouSoft.Common.Utils.GetFormValue("startcity") %>" />
    <input type="hidden" name="endcity" id="endcity" value="<%= EyouSoft.Common.Utils.GetFormValue("endcity") %>" />
    </form>

    <script type="text/javascript">
        var pageOpt = {
            url: '<%= HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString()  %>'
        }
        $(function() {
            $(".riqi_day_select").click(function() {
                $("#rili").val($(this).attr("data-date"));
                document.getElementById("myform").submit();
            })
            if (pageOpt.url != "" && pageOpt.url != "undefined") {
                document.getElementById("myform").action = pageOpt.url;
            }
        })
    </script>

</body>
</html>
