<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zuchelist.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ZuChe.zuchelist" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>租车管理</title>

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
                        汽车名称：
                        <input type="text" name="txtPathName" class="inputtext" maxlength="30" size="28"
                            value='<%=Request.QueryString["txtPathName"] %>' />
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
        <table  cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a class="toolbar_add" href="javascript:;">新增</a>
                    </td>
                    <%--<td width="90" align="center">
                        <a class="toolbar_update" href="javascript:;">修改</a>
                    </td>--%>
                    <%--<td width="90" align="center">
                        <a href="javascript:;" class="toolbar_delete">删除</a>
                    </td>--%>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3" style="display:none">
                    </th>
                    <th align="center">
                        车辆名称
                    </th>
                    <th align="center">
                        限乘人数
                    </th>
                    <th align="center">
                        租车基础费用
                    </th>
                    <th align="center">
                        超时费用
                    </th>
                    <th align="center">
                        超程费用
                    </th>
                    <th>基础公里数</th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <%--<input type="checkbox" name="checkbox" value='<%#Eval("ZuCheID") %>'>--%>
                            </td>
                            <td align="center">
                                <%#(Eval("CarName"))%>
                            </td>
                            <td align="center">
                                <%#Eval("XianZuoRenShu")%>
                            </td>
                            <td align="center">
                                含司机包车门市价：
                                <%# Convert.ToDecimal(Eval("MenShiJia")).ToString("C2")%><br />
                                含司机包车成本价：
                                <%# Convert.ToDecimal(Eval("MenShiJiaGeDanCheng")).ToString("C2")%><br />
                                单接或单送门市价：<%# Convert.ToDecimal(Eval("YouHuiJia")).ToString("C2")%><br />
                                单接或单送成本价：<%# Convert.ToDecimal(Eval("YouHuiJiaGeDanCheng")).ToString("C2")%><br />
                            </td>
                            <td align="center">
                                含司机包车门市价：
                                <%# Convert.ToDecimal(Eval("MenShiChaoShi")).ToString("C2")%><br />
                                含司机包车成本价：
                                <%# Convert.ToDecimal(Eval("MenShiJiaGeChaoShi")).ToString("C2")%><br />
                                单接或单送门市价：
                                <%# Convert.ToDecimal(Eval("YouHuiChaoShi")).ToString("C2")%><br />
                                单接或单送成本价：
                                <%# Convert.ToDecimal(Eval("YouHuiJiaGeChaoShi")).ToString("C2")%><br />
                            </td>
                            <td align="center">
                                含司机包车门市价：
                                <%# Convert.ToDecimal(Eval("MenShiChaoCheng")).ToString("C2")%><br />
                                含司机包车成本价：
                                <%# Convert.ToDecimal(Eval("MenShiJiaGeChaoCheng")).ToString("C2")%><br />
                                单接或单送门市价：
                                <%# Convert.ToDecimal(Eval("YouHuiChaoCheng")).ToString("C2")%><br />
                                单接或单送成本价：<%# Convert.ToDecimal(Eval("YouHuiJiaGeChaoCheng")).ToString("C2")%><br />
                            </td>
                            <td align="center">
                                含司机包车基础公里数：
                                <%# Convert.ToDecimal(Eval("MenShiJiaGeZuChe")).ToString("F2")%>&nbsp;公里<br />
                                单接或单送基础公里数：
                                <%# Convert.ToDecimal(Eval("YouHuiJiaGeZuChe")).ToString("F2")%>&nbsp;公里<br />
                            </td>
                            <td align="center">
                                <%#StateName(Eval("State"), Eval("ZuCheID"))%><br />
                                <%#CheIsIndex(Eval("State"), Eval("IsIndex"), Eval("ZuCheID"))%><br />
                                <a href="/WebMaster/ZuChe/ZucheEdit.aspx?type=update&id=<%#Eval("ZuCheID") %>">修改</a>  &nbsp;<a href="/WebMaster/ZuChe/zuchelist.aspx?dotype=del&id=<%# Eval("ZuCheID")%>" onclick="return confirm('您确实要删除本条记录吗？');">删除</a><br /><a data-class="paixu" href="javascript:;" data-id="<%#Eval("ZuCheID")%>">排序</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
            <tr>
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox1" name="checkbox3" style="display:none">
                    </th>
                    <th align="center">
                        车辆名称
                    </th>
                    <th align="center">
                        限乘人数
                    </th>
                    <th align="center">
                        租车基础费用
                    </th>
                    <th align="center">
                        超时费用
                    </th>
                    <th align="center">
                        超程费用
                    </th>
                    <th>基础公里数</th>
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
    <script type="text/javascript">
        var PageInfo = {
            Add: function() {
                window.location.href = "/WebMaster/ZuChe/ZucheEdit.aspx?type=add";
//                Boxy.iframeDialog({ title: "添加", iframeUrl: "/WebMaster/ZuChe/ZucheEdit.aspx?type=add", height: 700, width: 800, draggable: false });
//                return false;
            },
            Update: function(objArr) {
                var url = "/WebMaster/ZuChe/ZucheEdit.aspx?type=update&id=" + objArr[0].find("input[type='checkbox']").val();
                Boxy.iframeDialog({ title: "添加", iframeUrl: url, height: 700, width: 800, draggable: false });
            },
            dele: function(objArr) {
                if (objArr.length == 1) {

                    var url = "/WebMaster/ZuChe/zuchelist.aspx?dotype=del&id=" + PageInfo.GetCheckBox(objArr);

                    PageInfo.GoAjax(url);
                    return false;
                }
                else {
                    tableToolbar._showMsg("只能选择一行进行删除!");
                    return false;
                }
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
            EnState: function(obj) {
                var id = $(obj).attr("data-id");
                var en = $(obj).attr("data-en");
                var url = "/WebMaster/ZuChe/zuchelist.aspx?dotype=enb&id=" + id + "&en=" + en;
                PageInfo.GoAjax(url);
            },
            EnIndex: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var url = "/WebMaster/ZuChe/zuchelist.aspx?dotype=isindex&id=" + id + "&state=" + state;
                PageInfo.GoAjax(url);
            },
            BindBth: function() {
                $(".toolbar_add").click(function() {
                    PageInfo.Add();
                    return false;
                });
                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行",
                    updateCallBack: function(objsArr) {
                        //修改
                        PageInfo.Update(objsArr);
                        return false;
                    },
                    deleteCallBack: function(objsArr) {
                        //删除
                        PageInfo.dele(objsArr);
                    }
                });
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
            reload: function() {
                window.location.href = window.location.href;
            }
        };
        $(function() {
            PageInfo.BindBth();
            $("a[data-class=paixu]").click(function() {
                var orderid = $(this).attr("data-id");
                PageInfo.openwindow("/WebMaster/PaiXu.aspx?id=" + orderid + "&type=zuche&dotype=paixu", "排序修改", 400, 200);
            });
        });
    </script>

</body>
</html>
