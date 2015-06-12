<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayMentRecord.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.MoneyManagement.PayMentRecord" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../../JS/datepicker/WdatePicker.js"></script>

</head>
<body>
    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="from1" action="LianMengs.aspx">
                    <div class="searchbox">
                        <label>
                            会员姓名：</label>
                        <input type="text" class="inputtext" name="Mname" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("Mname") %>" />
                        收益日期：
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" value='<%=Request.QueryString["startE"] %>'
                            id="txtStartTime" size="10" class="inputtext" />-<input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})"
                                value='<%=Request.QueryString["endE"] %>' class="inputtext" name="txtEndTime"
                                id="txtEndTime" size="10" />
                        <input type="button" class="search-btn" value="" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th align="center">
                        ID
                    </th>
                    <th align="center">
                        会员姓名
                    </th>
                    <th align="center">
                        E额宝余额
                    </th>
                    <th align="center">
                        日积分率
                    </th>
                    <th align="center">
                        日积分
                    </th>
 
                    <th align="center">
                        积分日期
                    </th>
                </tr>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="center">
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="AgencyId"><%#GetMemberName(Eval("MemID").ToString())%></a>
                            </td>
                            <td align="center">
                                <%#Eval("Account") %>
                            </td>
                            <td align="center">
                                <%#Eval("IntersetRate")%>
                            </td>
                            <td align="center">
                                <%#Eval("DayInCome") %>
                            </td>
           
                            <td align="center">
                                <%#Eval("DealDate", "{0:yyyy-MM-dd}")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litNoMsg" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>

<script language="javascript" type="text/javascript">

    $(".search-btn").click(function() {
        var mname = $("input[name=Mname]").val();

        var startE = $("input[name=txtStartTime]").val();
        var endE = $("input[name=txtEndTime]").val();
        window.location.href = "PayMentRecord.aspx?mname=" + mname + "&startE=" + startE + "&endE=" + endE;
    })
    $(".AgencyId").click(function() {
        var id = $(this).html();
        if (window.location.href.indexOf("?") > 0) {
            if (window.location.href.indexOf("mname") > 0) {
                window.location.href = window.location.href;
            }
            else {
                window.location.href = window.location.href + "&mname=" + id;
            }
        }
        else {
            window.location.href = window.location.href + "?mname=" + id;
        }
    });
</script>

