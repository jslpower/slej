<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MemberCenter.MemberList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <form id="form1">
                        <div class="searchbox">
                            用户名：
                            <%=Html.TextBoxFor(x => x.Account, new {  @class="inputtext", maxlength="30", size="28" })%>
                            姓名：
                            <%=Html.TextBoxFor(x => x.MemberName, new {  @class="inputtext", size="10" })%>
                            手机：
                            <%=Html.TextBoxFor(x => x.Mobile, new { @class = "inputtext", size = "11" })%>
                            Email:
                            <%=Html.TextBoxFor(x => x.Email, new { @class = "inputtext", size = "10" })%>
                            
                            联系电话:
                            <%=Html.TextBoxFor(x => x.Contact, new { @class = "inputtext" })%>
                            <br />
                            会员类型:
                            <select id="UserType" name="UserType" class="inputselect" style="width: 120px">
                                <%=BindMemberType(EyouSoft.Common.Utils.GetQueryStringValue("UserType"))%>
                            </select>
                            <input type="button" class="search-btn" onclick="instance2.Search();" />
                        </div>
                        </form>
                    </td>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanright.gif" alt="" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="btnbox btnboxme" style="height: auto;">
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:;" onclick="instance.add();">新 增</a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="60" height="30" align="center">
                            序号
                        </th>
                        <th align="center">
                            姓名
                        </th>
                        <th align="center">
                            用户名
                        </th>
                        <th align="center">
                            会员类型
                        </th>
                        <th align="center">
                            手机
                        </th>
                        <th align="center">
                            QQ
                        </th>
                        <th align="center">
                            注册日期
                        </th>
                        <th align="center">
                            有效日期
                        </th>
                        <th align="center">
                            登录次数
                        </th>
                        <th align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr <%#Container.ItemIndex%2==0?" class=\"odd\" ":" class=\"even\" "  %> id="index<%#Container.ItemIndex %>">
                                <td height="30" align="center">
                                    <%# Container.ItemIndex + 1 + (PageInfo.PageIndex - 1) * PageInfo.PageSize%>
                                </td>
                                <td align="center">
                                    <a href="javascript:;" onclick="instance.show('<%#Eval("MemberID")%>')" class="info">
                                        <%#Eval("MemberName")%></a>
                                </td>
                                <td align="center">
                                    <%#Eval("Account")%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserType")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Mobile")%>
                                </td>
                                <td align="center">
                                    <%#Eval("qq")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDateTime(Eval("RegisterTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td align="center">
                                      <%#Convert.ToDateTime(Eval("validDate")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td align="center">
                                    <%#Eval("LoginNum") %>
                                </td>
                                <td align="center">
                                <input type="hidden" class="hid_state" value="<%#(int)Enum.Parse(typeof(EyouSoft.Model.Enum.UserStatus), Eval("MemberState").ToString())  %>" />
                                    <a class="info" href="javascript:;" onclick="instance.show('<%#Eval("MemberID")%>')">
                                        查看</a>&nbsp;|&nbsp; <a onclick="instance.update('<%#Eval("MemberID")%>')" href="javascript:;">
                                            编辑</a>|&nbsp;<%#StateName(Eval("MemberState"), Eval("MemberID"))%><br /><%-- <a href="javascript:;" onclick="instance.del(this,'<%#Eval("MemberID")%>',<%#Container.ItemIndex %>)">
                                                删除</a>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr>
                        <th width="60" height="30" align="center">
                            序号
                        </th>
                        <th align="center">
                            姓名
                        </th>
                        <th align="center">
                            用户名
                        </th>
                        <th align="center">
                            会员类型
                        </th>
                        <th align="center">
                            手机
                        </th>
                        <th align="center">
                            QQ
                        </th>
                        <th align="center">
                            注册日期
                        </th>
                        <th align="center">
                            有效日期
                        </th>
                        <th align="center">
                            登录次数
                        </th>
                        <th align="center">
                            操作
                        </th>
                    </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" align="right" class="pageup" colspan="13">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
<br /><br />
    <script type="text/javascript">
        var instance = new PageSubmitForm();
        var instance2 = new InitialPageInputTagValue();
        instance2.Init();
        instance.show = function(id) {
        window.location.href = "/Webmaster/MemberCenter/MemberEdit.aspx?searchInfo.showmode=show&memberid=" + id;
//            Boxy.iframeDialog({
//                iframeUrl: '/Webmaster/MemberCenter/MemberEdit.aspx',
//                iframeId: 'ddd',
//                data: { memberid: id, 'searchInfo.showmode': 'show' },
//                title: '查看会员信息',
//                modal: true,
//                width: '850px',
//                height: '540px'
//            });
        };
        instance.add = function() {
        window.location.href = "/Webmaster/MemberCenter/MemberEdit.aspx?searchInfo.showmode=add";
//            Boxy.iframeDialog({
//                iframeUrl: '/Webmaster/MemberCenter/MemberEdit.aspx',
//                data: { 'searchInfo.showmode': 'add' },
//                iframeId: 'ddd',
//                title: '新增会员',
//                modal: true,
//                width: '850px',
//                height: '540px'
//            });
        };
        instance.update = function(id) {
        window.location.href = "/Webmaster/MemberCenter/MemberEdit.aspx?searchInfo.showmode=update&memberid=" + id;
//            Boxy.iframeDialog({
//                iframeUrl: '/Webmaster/MemberCenter/MemberEdit.aspx',
//                iframeId: 'ddd',
//                data: { memberid: id, 'searchInfo.showmode': 'update' },
//                title: '编辑会员信息',
//                modal: true,
//                width: '850px',
//                height: '540px'
//            });
    };
     instance.EnState = function(obj) {
                var id = $(obj).attr("data-id");
                var en = $(obj).attr("data-en");
                var url = "/WebMaster/MemberCenter/MemberList.aspx?dotype=enb&id=" + id + "&en=" + en;
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    async: false,
                    dataType: "json",
                    success: function(ret) {
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
            };
    instance.Company = function(id) {
    window.location.href = "/Webmaster/MemberCenter/CompanyContent.aspx?MemberId=" + id;
    };

        instance.del = function(btn, id, num) {
            if (confirm('真的删除该用户吗?')) {
                instance.SetButtonUnableClick(btn);
                $.get('/Webmaster/MemberCenter/MemberEdit.aspx', { memberid: id, 'searchinfo.editmode': 'delete' }, function(ret) {
                tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                    instance.SetButtonEnableClick(btn);
                }, 'json');
            }
        };
    </script>

</body>
</html>
