<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChongZhiList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MoneyManagement.ChongZhiList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1">
                    <div class="searchbox">                        
                        <label>
                            充值金额：</label>
                        <input id="txtJinE1" name="txtJinE1" type="text" class="inputtext formsize50" value="<%=Request.QueryString["txtJinE1"] %>" />-<input
                            id="txtJinE2" name="txtJinE2" type="text" class="inputtext formsize50" value="<%=Request.QueryString["txtJinE2"] %>" />
                        <label>
                            充值日期：</label>
                            <input id="txtChongZhiShiJian1" name="txtChongZhiShiJian1" class="inputtext formsize120"
                                onfocus="WdatePicker()" type="text" value="<%=Request.QueryString["txtChongZhiShiJian1"] %>" />-<input
                                    id="txtChongZhiShiJian2" name="txtChongZhiShiJian2" class="inputtext formsize120"
                                    onfocus="WdatePicker()" type="text" value="<%=Request.QueryString["txtChongZhiShiJian2"] %>" />
                        <input type="submit" class="search-btn" value="" />
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
    <div style="text-align:center; font-size:16px; color:Red; font-weight:bolder;">总账户金额：<asp:Literal ID="Literal2" runat="server"></asp:Literal>元</div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        充值用户
                    </th>
                    <th align="center">
                        充值金额
                    </th>
                    <%--<th align="center">
                        剩余金额
                    </th>--%>
                    <th align="center">
                        时间
                    </th>
                    <th align="center">
                        支付方式
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <%--<th align="center">
                        描述
                    </th>--%>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <%--<td height="30" align="center">
                                <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>">
                            </td>--%>
                            <td align="center">
                                会员姓名：<%#Eval("HuiYuanName") %><br />
                                会员帐号：<%#Eval("HuiYuanYongHuMing") %>
                            </td>
                            <td align="center">
                                <%#Eval("JinE","{0:F2}")%>
                            </td>
                            <%--<td align="center">
                                
                            </td>--%>
                            <td align="center">
                                <%#Eval("Issuetime","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td align="center">
                                <%#Eval("ZhiFuFangShi") %>
                            </td>
                            <td align="center">
                                <%# Eval("ZhiFuStatus")%>
                            </td>
                            <%--<td align="center">
                                
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot><tr><td colspan="8"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td></tr>
             <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        充值用户
                    </th>
                    <th align="center">
                        充值金额
                    </th>
                    <%--<th align="center">
                        剩余金额
                    </th>--%>
                    <th align="center">
                        时间
                    </th>
                    <th align="center">
                        充值方式
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <%--<th align="center">
                        描述
                    </th>--%>
                </tr>
            </tfoot>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
<br /><br />
    <script type="text/javascript">
       
    </script>

</body>

<script type="text/javascript">
//    var intance = new InitialPageInputTagValue();
//    intance.Init();
</script>

</html>
