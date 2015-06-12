<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StrategyList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.Strategy.StrategyList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单管理</title>

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
                            名称：
                            <input name="TravelName" id="TravelName" type="text" class="inputtext" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("TravelName") %>'
                                size="10" />
                            主题：
                            <select id="ddlTheme" name="ddlTheme" class="inputselect">
                                <%=BindTheme(EyouSoft.Common.Utils.GetQueryStringValue("ddlTheme"))%>
                            </select>
                            旅行时间：
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
                            是否会员发布：
                            <select id="ddlIsMember" name="ddlIsMember">
                                <option value="">-请选择-</option>
                                <option value="0" <%=EyouSoft.Common.Utils.GetQueryStringValue("ddlIsMember")=="0"?"selected='selected'":"" %>>
                                    是</option>
                                <option value="1" <%=EyouSoft.Common.Utils.GetQueryStringValue("ddlIsMember")=="1"?"selected='selected'":"" %>>
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
                            <a class="toolbar_add" href="javascript:;">新增</a>
                        </td>
                        <td width="90" align="center">
                            <a class="toolbar_update" href="javascript:;">修改</a>
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
                        <th align="center" width="25%">
                            名称
                        </th>
                        <th align="center" width="15%">
                            主题
                        </th>
                        <th align="center" width="8%">
                            旅行时间
                        </th>
                        <th align="center" width="25%">
                            旅行目的地
                        </th>
                        <th align="center" width="6%">
                            状态
                        </th>
                        <th align="center" width="8%">
                            发布时间
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_Strategys" runat="server">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                                <td height="30" align="center">
                                    <input type="checkbox" name="checkbox" value='<%#Eval("TravelID") %>' /><%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                                </td>
                                <td align="center">
                                    <%# Eval("TravelName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("ClassName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("TravelDate") == null ? "" : Convert.ToDateTime(Eval("TravelDate")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td align="center">
                                    <%# Eval("TravelDestination")%>
                                </td>
                                <td align="center">
                                    <%# (bool)Eval("IsCheck") ? "<font style='color:Green;'>已审</font>" : "<font style='color:Red;'>未审</font>"%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDateTime( Eval("IssueTime")).ToString("yyyy-MM-dd")%>
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
            StrategyList.BindBtn();
        });
        var StrategyList = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //ajax执行文件路径,默认为本页面
            ajaxurl: "/WebMaster/Strategy/StrategyList.aspx",
            //添加
            Add: function() {
                StrategyList.ShowBoxy({ iframeUrl: "/WebMaster/Strategy/StrategyEdit.aspx?dotype=add&tid=", title: "新增", width: "850px", height: "450px" });
            },
            //查询
            Search: function() {
                var TravelName = $("#TravelName").val();
                var ddlTheme = $("#ddlTheme").val();
                var txtStartTime = $("#txtStartTime").val();
                var txtEndTime = $("#txtEndTime").val();
                var ddlIsCheck = $("#ddlIsCheck").val();
                var ddlIsMember = $("#ddlIsMember").val();
                window.location.href = "StrategyList.aspx?TravelName=" + TravelName + "&ddlTheme=" + ddlTheme + "&txtStartTime=" + txtStartTime + "&txtEndTime=" + txtEndTime + "&ddlIsCheck=" + ddlIsCheck + "&ddlIsMember=" + ddlIsMember + "";
                //StrategyList.ShowBoxy({ iframeUrl: "/WebMaster/Strategy/StrategyEdit.aspx?dotype=add&tid=", title: "新增", width: "850px", height: "450px" });
            },
            //修改
            Update: function(objArr) {
                StrategyList.ShowBoxy({ iframeUrl: "/WebMaster/Strategy/StrategyEdit.aspx?dotype=update&tid=" + objArr[0].find("input[type='checkbox']").val(), title: "修改", width: "850px", height: "450px" });
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
                    StrategyList.ajaxurl = "/WebMaster/Strategy/StrategyList.aspx?dotype=delete&id=" + StrategyList.GetCheckBox(objArr);
                    //执行/ajax
                    StrategyList.GoAjax(StrategyList.ajaxurl);
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
                    StrategyList.ajaxurl = "/WebMaster/Strategy/StrategyList.aspx?dotype=sh&id=" + StrategyList.GetCheckBox(objArr);
                    //执行/ajax
                    StrategyList.GoAjax(StrategyList.ajaxurl);
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
                    StrategyList.ajaxurl = "/WebMaster/Strategy/StrategyList.aspx?dotype=qxsh&id=" + StrategyList.GetCheckBox(objArr);
                    //执行/ajax
                    StrategyList.GoAjax(StrategyList.ajaxurl);
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
                    afterHide: function() { StrategyList.reload(); }
                });
            },
            BindBtn: function() {

                //绑定Add事件
                $(".toolbar_add").click(function() {
                    StrategyList.Add();
                    return false;
                });
                //绑定search事件
                $(".search-btn").click(function() {
                    StrategyList.Search();
                    return false;
                });
                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行",

                    ////修改-删除-取消-复制 为默认按钮，按钮class对应  toolbar_update  toolbar_delete  toolbar_cancel  toolbar_copy即可
                    updateCallBack: function(objsArr) {
                        //修改
                        StrategyList.Update(objsArr);
                        return false;
                    },
                    deleteCallBack: function(objsArr) {
                        //删除(批量)
                        StrategyList.DelAll(objsArr);
                    },
                    otherButtons: [
		                {
		                    button_selector: '.toolbar_sh',
		                    sucessRulr: 2,
		                    msg: '未选中任何信息 ',
		                    buttonCallBack: function(objArr) {
		                        tableToolbar.ShowConfirmMsg("是否将审核状态改为【已审】", function() {
		                            StrategyList.ShAll(objArr);
		                        });

		                    }
		                },
		                {
		                    button_selector: '.toolbar_qxsh',
		                    sucessRulr: 2,
		                    msg: '未选中任何信息 ',
		                    buttonCallBack: function(objArr) {
		                        tableToolbar.ShowConfirmMsg("是否将审核状态改为【未审】", function() {
		                            StrategyList.QxShAll(objArr);
		                        });

		                    }
		                }
		            ]
                });

            }
        };
    </script>

</body>
</html>
