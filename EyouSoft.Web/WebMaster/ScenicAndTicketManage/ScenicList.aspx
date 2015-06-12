<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScenicList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ScenicAndTicketManage.ScenicList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>景区管理</title>

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

    <script src="/JS/bt.min.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" method="get">
                    <div class="searchbox">
                        景区名称：
                        <input type="text" name="txtScenicName" class="inputtext" maxlength="30" size="28"
                            value='<%=Request.QueryString["txtScenicName"] %>' />
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
    <div class="btnbox">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a class="toolbar_add" href="javascript:;" onclick="Sceniclist.Add();">添加</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_update" href="javascript:;" onclick="Sceniclist.Update();">修改</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="toolbar_delete" onclick="Sceniclist.Delete();">删除</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="toolbar_interface" onclick="Sceniclist.GetInterfaceData();">
                            读取接口</a>
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
                    <th width="60" height="30" align="center">
                       <%-- <input type="checkbox" id="checkbox3" name="checkbox3">全选--%>
                    </th>
                    <th align="center">
                        景区名称
                    </th>
                    <th align="center">
                        是否推荐
                    </th>
                    <th align="center">
                        联系人
                    </th>
                    <th align="center">
                        联系电话
                    </th>
                    <th align="center">
                        联系传真
                    </th>
                    <th align="center">
                        门票管理
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <input type="checkbox" name="checkbox" value='<%#Eval("ScenicId")%>' interfaceid='<%#Eval("InterfaceID") %>'>
                            </td>
                            <td align="left">
                                <%#Eval("ScenicName")%>
                            </td>
                            <td align="center">
                                <%#Convert.ToBoolean(Eval("IsRecommend"))?"是":"否"%>
                            </td>
                            <td align="center">
                                <%#Eval("Contact")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactTel")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactFax")%>
                            </td>
                            <td align="center">
                                <a href="/WebMaster/ScenicAndTicketManage/Ticket.aspx?scenicId=<%#Eval("ScenicId") %>"
                                    style="cursor: pointer">门票管理</a>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="scenicImg" onclick="Sceniclist.EditPic('<%#Eval("ScenicName") %>','<%#Eval("ScenicId")%>')"
                                    style="cursor: pointer">照片</a>
                                <%#CheIsIndex(Eval("IsIndex"), Eval("ScenicId"))%> <a data-class="paixu" href="javascript:;" data-id="<%#Eval("ScenicId")%>">排序</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
            <tr>
                    <th width="60" height="30" align="center">
                       <%-- <input type="checkbox" id="checkbox3" name="checkbox3">全选--%>
                    </th>
                    <th align="center">
                        景区名称
                    </th>
                    <th align="center">
                        是否推荐
                    </th>
                    <th align="center">
                        联系人
                    </th>
                    <th align="center">
                        联系电话
                    </th>
                    <th align="center">
                        联系传真
                    </th>
                    <th align="center">
                        门票管理
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br /><br />
</body>

<script type="text/javascript">
    var Sceniclist = {
        GetCheckedItems: function() {
            var list = [];
            $('#liststyle :checkbox[value!=on][checked]').each(function() {
                list.push({ id: this.value, interfaceid: $(this).attr('interfaceid') });
            });
            return list;
        },
        openwindow: function(url, title, width, height) {
            url = url;
            Boxy.iframeDialog({
                iframeUrl: url,
                title: title,
                modal: true,
                width: width,
                height: height,
                afterHide: function() { location.reload(); }
            });
        },
        Add: function() {
            location.href = "/WebMaster/ScenicAndTicketManage/ScenicEdit.aspx?dotype=add";
        },
        Update: function() {
            var items = Sceniclist.GetCheckedItems();
            if (items.length == 0) {
                tableToolbar._showMsg("未选中任何项!");
            }
            else if (items.length > 1) {
                tableToolbar._showMsg("只能选择一行进行编辑!");
            }
            else {
                if (items[0].interfaceid == '') {
                    location.href = "/WebMaster/ScenicAndTicketManage/ScenicEdit.aspx?dotype=update&id=" + items[0].id;
                }
                else {
                    tableToolbar._showMsg("该景区数据从接口而来，不能更改!");
                }
            }
        },
        EnIndex: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var url = "/WebMaster/ScenicAndTicketManage/ScenicList.aspx?dotype=isindex&id=" + id + "&state=" + state;
            Sceniclist.GoAjax(url);
        },
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
        Delete: function() {
            var items = Sceniclist.GetCheckedItems();
            if (items.length == 0) {
                tableToolbar._showMsg("未选中任何项!");
            }
            else if (items.length > 1) {
                tableToolbar._showMsg("只能选择一行进行删除!");
            }
            else if (items[0].interfaceid != '') {
            tableToolbar._showMsg("该景区数据从接口而来，不能删除!");
            }
            else {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/WebMaster/ScenicAndTicketManage/Sceniclist.aspx?dotype=delete&id=" + items[0].id,
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
            }
        },
        GetInterfaceData: function() {
            Boxy.iframeDialog({ title: '接口景区数据', iframeUrl: '/WebMaster/ScenicAndTicketManage/InterfaceDataList.aspx', height: 60, width: 300, draggable: true })
        },
        EditPic: function(name, scenicid) {
            Boxy.iframeDialog({ title: '编辑景区图片', iframeUrl: ("/WebMaster/ScenicAndTicketManage/SetScenicImg.aspx?name=" + name + '&scenicid=' + scenicid), height: 800, width: 800, draggable: false })
        }
    };
    $(function() {
        $("a[data-class=paixu]").click(function() {
            var orderid = $(this).attr("data-id");
            Sceniclist.openwindow("/WebMaster/PaiXu.aspx?id=" + orderid + "&type=jingqu&dotype=paixu", "排序修改", 400, 200);
        });
    });
</script>

</html>
