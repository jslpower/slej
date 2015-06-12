<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelArticleLYList.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TravelArticleLYList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言管理</title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <div class="searchbox">
                            留言时间：
                            <input type="text" onfocus="WdatePicker()" name="txtStartTime" id="txtStartTime"
                                size="10" class="inputtext" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStartTime") %>" />-<input
                                    type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})" class="inputtext"
                                    name="txtEndTime" id="txtEndTime" size="10" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtEndTime") %>" />
                            是否审核：
                            <select id="ddlIsCheck" name="ddlIsCheck">
                                <option value="">-请选择-</option>
                                <option value="1" <%=EyouSoft.Common.Utils.GetQueryStringValue("ddlIsCheck")=="1"?"selected='selected'":"" %>>
                                    是</option>
                                <option value="0" <%=EyouSoft.Common.Utils.GetQueryStringValue("ddlIsCheck")=="0"?"selected='selected'":"" %>>
                                    否</option>
                            </select>
                            <input type="button" class="search-btn" value="" />
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanright.gif" alt="" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a class="toolbar_update" href="javascript:;">回复</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:;" class="toolbar_sh">审核</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:;" class="toolbar_qxsh">取消审核</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:;" class="toolbar_delete">删除</a>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="8%" height="30" align="center">
                            <input type="checkbox" id="checkbox3" name="checkbox3">全选
                        </th>
                        <th align="center" width="10%">
                            标题
                        </th>
                        <th align="center" width="8%">
                            留言人
                        </th>
                        <th align="center" width="25%">
                            留言内容
                        </th>
                        <th align="center" width="8%">
                            留言时间
                        </th>
                        <th align="center" width="8%">
                            回复人
                        </th>
                        <th align="center" width="25%">
                            回复内容
                        </th>
                        <th align="center" width="8%">
                            回复时间
                        </th>
                        <th align="center" width="6%">
                            状态
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_List" runat="server">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                                <td height="30" align="center">
                                    <input type="checkbox" name="checkbox" value='<%#Eval("LiuYanId") %>' /><%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                                </td>
                                <td align="center">
                                    <a class="show" href="javascript:void(0);" data-id="<%#Eval("ArticleID") %>">
                                        <%#Eval("ArticleTitle")%></a>
                                </td>
                                <td align="center">
                                    <%# Eval("Account")%>
                                </td>
                                <td align="center">
                                    <%# Eval("LiuYanContet")%>
                                </td>
                                <td align="center">
                                    <%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("LiuYanShiJian"), "yyyy-MM-dd")%>
                                </td>
                                <td align="center">
                                    <%# Eval("Username")%>
                                </td>
                                <td align="center">
                                    <%# Eval("HuiFuContet")%>
                                </td>
                                <td align="center">
                                    <%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("IssueTime"), "yyyy-MM-dd")%>
                                </td>
                                <td align="center">
                                    <%# (bool)Eval("IsCheck") ? "<font style='color:Green;'>已审</font>" : "<font style='color:Red;'>未审</font>"%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
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
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            ObjPage.BindBtn();
        });
        var ObjPage = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //ajax执行文件路径,默认为本页面
            ajaxurl: '/WebMaster/TravelArticleLYList.aspx?aid=<%=EyouSoft.Common.Utils.GetQueryStringValue("aid") %>',
            //查询
            Search: function() {
                var txtStartTime = $("#txtStartTime").val();
                var txtEndTime = $("#txtEndTime").val();
                var ddlIsCheck = $("#ddlIsCheck").val();
                window.location.href = "TravelArticleLYList.aspx?txtStartTime=" + txtStartTime + "&txtEndTime=" + txtEndTime + "&ddlIsCheck=" + ddlIsCheck + '&aid=<%=EyouSoft.Common.Utils.GetQueryStringValue("aid") %>';
            },
            //修改
            Update: function(objArr) {
                ObjPage.ShowBoxy({ iframeUrl: "/WebMaster/TravelArticleLYEdit.aspx?dotype=update&tid=" + objArr[0].find("input[type='checkbox']").val(), title: "修改", width: "750px", height: "350px" });
            },
            GetCheckBox: function(objArr) {
                //定义数组对象
                var list = new Array();
                //遍历按钮返回数组对象
                for (var i = 0; i < objArr.length; i++) {
                    //从数组对象中找到数据所在，并保存到数组对象中
                    if (objArr[i].find("input[type='checkbox']").val() != "on") {
                        list.push(objArr[i].find("input[type='checkbox']").val());
                    }
                }
                return list.join(',');
            },
            //删除(可多行)
            DelAll: function(objArr) {
                if (objArr.length > 0) {
                    //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                    ObjPage.ajaxurl = "/WebMaster/TravelArticleLYList.aspx?dotype=delete&id=" + ObjPage.GetCheckBox(objArr);
                    //执行/ajax
                    ObjPage.GoAjax(ObjPage.ajaxurl);
                    return false;
                }
                else {
                    tableToolbar._showMsg("只能选择一行进行删除!");
                    return false;
                }
            },
            //审核(可多行)
            ShAll: function(objArr) {
                if (objArr.length > 0) {
                    //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                    ObjPage.ajaxurl = "/WebMaster/TravelArticleLYList.aspx?dotype=sh&id=" + ObjPage.GetCheckBox(objArr);
                    //执行/ajax
                    ObjPage.GoAjax(ObjPage.ajaxurl);
                    return false;
                }
                else {
                    tableToolbar._showMsg("只能选择一行进行审核!");
                    return false;
                }
            },
            //取消审核(可多行)
            QxShAll: function(objArr) {
                if (objArr.length > 0) {
                    //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                    ObjPage.ajaxurl = "/WebMaster/TravelArticleLYList.aspx?dotype=qxsh&id=" + ObjPage.GetCheckBox(objArr);
                    //执行/ajax
                    ObjPage.GoAjax(ObjPage.ajaxurl);
                    return false;
                }
                else {
                    tableToolbar._showMsg("只能选择一行进行审核!");
                    return false;
                }
            },
            //Ajax请求
            GoAjax: function(url) {
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
            },
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height,
                    afterHide: function() { ObjPage.reload(); }
                });
            },
            Show: function(id) {
                ObjPage.ShowBoxy({ iframeUrl: "/WebMaster/TravelArticleEdit.aspx?dotype=show&tid=" + id, title: "查看", width: "970px", height: "650px" });
            },
            BindBtn: function() {
                //绑定search事件
                $(".search-btn").click(function() {
                    ObjPage.Search();
                    return false;
                });
                $(".show").click(function() {
                    var id = $(this).attr("data-id");
                    if (id) {
                        ObjPage.Show(id);
                        return false;
                    }
                });
                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行",

                    ////修改-删除-取消-复制 为默认按钮，按钮class对应  toolbar_update  toolbar_delete  toolbar_cancel  toolbar_copy即可
                    updateCallBack: function(objsArr) {
                        //修改
                        ObjPage.Update(objsArr);
                        return false;
                    },
                    deleteCallBack: function(objsArr) {
                        //删除(批量)
                        ObjPage.DelAll(objsArr);
                    },
                    otherButtons: [
	                    {
	                        button_selector: '.toolbar_sh',
	                        sucessRulr: 2,
	                        msg: '未选中任何信息 ',
	                        buttonCallBack: function(objArr) {
	                            tableToolbar.ShowConfirmMsg("是否将审核状态改为【已审】", function() {
	                                ObjPage.ShAll(objArr);
	                            });

	                        }
	                    },
	                    {
	                        button_selector: '.toolbar_qxsh',
	                        sucessRulr: 2,
	                        msg: '未选中任何信息 ',
	                        buttonCallBack: function(objArr) {
	                            tableToolbar.ShowConfirmMsg("是否将审核状态改为【未审】", function() {
	                                ObjPage.QxShAll(objArr);
	                            });

	                        }
}]
                });

            }
        };
    </script>

</body>
</html>
