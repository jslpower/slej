<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.UserList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理用户列表</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <link rel="stylesheet" type="text/css" href="/css/webmaster/boxy.css" />
</head>
<body>
    <form id="form1" method="get">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="30">
                    姓名：
                    <input type="text" id="cn" class="searchinput inputtext" name="cn" style="width: 150px;"
                        value="<%= EyouSoft.Common.Utils.GetQueryStringValue("cn") %>" />
                    用户名：
                    <input type="text" id="un" class="searchinput inputtext" name="un" style="width: 150px;"
                        value="<%= EyouSoft.Common.Utils.GetQueryStringValue("un") %>" />
                    用户类型：
                    <select class="inputselect" name="txtLeiXing">
                        <%=UtilsCommons.GetEnumDDL(EnumObj.GetList(typeof(WebmasterUserType)), EyouSoft.Common.Utils.GetQueryStringValue("txtLeiXing"), "", "请选择")%>
                    </select>
                    <input type="submit" value="" class="search-btn" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <div class="btnbox">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:;" id="btnAdd">新 增</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
            <tr>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    姓名
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    用户名
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    电话
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    手机
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    QQ
                </th>
                <th width="8%" align="center" bgcolor="#bddcf4">
                    状态
                </th>
                <th width="8%" align="center" bgcolor="#bddcf4">
                    类型
                </th>
                <th align="center" bgcolor="#bddcf4">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptEmployee" runat="server">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" data-id="<%# Eval("Id") %>"
                        data-isenable="<%# Eval("IsEnable").ToString() %>">
                        <td height="35" align="center">
                            <%# Eval("Realname")%>
                        </td>
                        <td height="35" align="center">
                            <%#Eval("Username")%>
                        </td>
                        <td height="35" align="center">
                            <%#Eval("Telephone")%>
                        </td>
                        <td align="center">
                            <%#Eval("Mobile")%>
                        </td>
                        <td align="center">
                            <%#Eval("Fax")%>
                        </td>
                        <td align="center">
                            <a href="javascript:;" class="setState" title="点击设置用户状态，×状态的用户不能登录">
                                <%#((Is)Eval("IsEnable")== Is.是) ? "√" : "×"%></a>
                        </td>
                        <td align="center">
                            <%# (WebmasterUserType)Eval("LeiXing")%>
                        </td>
                        <td align="center">
                            <%# (int)Eval("LeiXing") == 0 ? ("<a href='javascript:;' onclick='UserList.perUser("+Eval("ID")+")' class='perUser'>权限</a> &nbsp;&nbsp;") : ""%>
                            <a href='javascript:;' onclick="UserList.editUser('<%#Eval("ID")%>','<%#Eval("GysId")%>')">
                                修改</a>&nbsp;&nbsp; <a href='javascript:;' onclick='UserList.delUser("<%#Eval("ID")%>")'
                                    class='delUser'>删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
             <tr>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    姓名
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    用户名
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    电话
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    手机
                </th>
                <th width="15%" align="center" bgcolor="#bddcf4">
                    QQ
                </th>
                <th width="8%" align="center" bgcolor="#bddcf4">
                    状态
                </th>
                <th width="8%" align="center" bgcolor="#bddcf4">
                    类型
                </th>
                <th align="center" bgcolor="#bddcf4">
                    操作
                </th>
            </tr>
            <tr>
                <td height="30" colspan="10" align="right" class="pageup">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
<br /><br />
    <script type="text/javascript">
        var UserList = {
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            addUser: function() {
            window.location.href = "/WebMaster/UserEdit.aspx?action=add";
//                UserList.ShowBoxy({ iframeUrl: "/WebMaster/UserEdit.aspx?action=add", title: "新增管理用户", width: "580px", height: "350px" });
//                return false;
            },
            editUser: function(id, GysId) {
                if (id == null || typeof (id) == "undefined" || id == "" || parseInt(id) <= 0) return false;
                window.location.href = "/WebMaster/UserEdit.aspx?action=edit&id=" + id + "&GysId=" + GysId;
//                UserList.ShowBoxy({ iframeUrl: "/WebMaster/UserEdit.aspx?action=edit&id=" + id + "&GysId=" + GysId, title: "修改管理用户", width: "580px", height: "350px" });
//                return false;
            },
            perUser: function(id) {
                if (id == null || typeof (id) == "undefined" || id == "" || parseInt(id) <= 0) return false;
                window.location.href = "/WebMaster/UserPer.aspx?id=" + id;
//                UserList.ShowBoxy({ iframeUrl: "/WebMaster/UserPer.aspx?id=" + id, title: "权限管理", width: "750px", height: "650px" });
//                return false;
            },
            delUser: function(id) {
                tableToolbar.ShowConfirmMsg("您确定要删除此用户吗？", function() {
                    if (id == null || typeof (id) == "undefined" || id == "" || parseInt(id) <= 0) return false;

                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/WebMaster/UserList.aspx?action=del&id=" + id,
                        dataType: "json",
                        async: false,
                        success: function(ret) {
                            //ajax回发提示
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                        }
                    });
                });
            },
            setState: function(id, isEnable) {
                if (id == null || typeof (id) == "undefined" || id == "" || parseInt(id) <= 0 || (isEnable != "1" && isEnable != "0"))
                    return false;

                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/WebMaster/UserList.aspx?action=set&id=" + id + "&st=" + isEnable,
                    dataType: "json",
                    async: false,
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        };

        $(document).ready(function() {

            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行"
            });

            $("#btnAdd").click(function() {
                UserList.addUser();
                return false;
            });

            $("#liststyle").find(".setState").each(function() {
                var id = $(this).closest("tr").attr("data-id");
                var st = $(this).closest("tr").attr("data-isenable");
                $(this).click(function() {
                    UserList.setState(id, st);
                    return false;
                });
            });
        });
    </script>

</body>
</html>
