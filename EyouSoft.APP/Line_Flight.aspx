<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line_Flight.aspx.cs" Inherits="EyouSoft.WAP.Line_Flight" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="航班选择" />
    <div class="warp">
        <div class="hangban_box">
            <ul>
                <asp:Repeater ID="rptFlights" runat="server">
                    <ItemTemplate>
                        <li class="flightLi" data-no="<%# Eval("TrafficId") %>"><span class="hangban_txt">
                            <p>
                                <i class="font_yellow">往：</i><%# Eval("Traffic_01")%></p>
                            <p>
                                返：<%# Eval("Traffic_02")%></p>
                        </span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            $("li").click(function() {
                window.location.href = "/Line_Tours.aspx?" + $.param({ xianluid: '<%= EyouSoft.Common. Utils.GetQueryStringValue("xianluid") %>', hasFlightNO: $(this).attr("data-NO"), type: '<%= EyouSoft.Common. Utils.GetQueryStringValue("type") %>' })
            })

        })
    </script>

</body>
</html>
