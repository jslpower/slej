<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuangouList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.TuangouList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团购产品</title>

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

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
                        团购名称:<input type="text" id="txttuanname" name="txttuanname" maxlength="30" size="28"
                            class="inputtext" value='<%=Request.QueryString["txttuanname"] %>' />
                        产品名称：
                        <input type="text" id="txtrouteName" name="txtrouteName" class="inputtext" maxlength="30"
                            size="28" value='<%=Request.QueryString["txtrouteName"] %>' />
                        团购时间：
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" id="txtStartTime"
                            size="10" class="inputtext" value='<%=Request.QueryString["txtStartTime"] %>' />-<input
                                type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})" class="inputtext"
                                name="txtEndTime" id="txtEndTime" size="10" value='<%=Request.QueryString["txtEndTime"] %>' />
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
                        <a class="toolbar_add" href="javascript:;">新增</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_update" href="javascript:;">修改</a>
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
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>
                    <th align="center">
                        团购名称
                    </th>
                    <th align="center">
                        产品信息
                    </th>
                    <th align="center">
                        开始时间
                    </th>
                    <th align="center">
                        结束时间
                    </th>
                    <th align="center">
                        订单数量
                    </th>
                    <th align="center">
                        成团人数
                    </th>
                    <th align="center">
                        实收人数
                    </th>
                    <th align="center">
                        已收人数
                    </th>
                    <th align="center" width="30%">
                        简要描述
                    </th>
                    <th align="center">
                        预定信息
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                         <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <input type="checkbox" name="checkbox" value='<%#Eval("TuanGouId") %>'>
                            </td>
                            <td align="center">
                                <%#Eval("TuanName")%>
                            </td>
                            <td align="center">
                                <%#Eval("RouteName")%>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.Utils.GetDateString(Eval("STime"),"yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.Utils.GetDateString(Eval("ETime"),"yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#Eval("DingDanShu")%>
                            </td>
                            <td align="center">
                                <%#Eval("RenShu")%>
                            </td>
                            <td align="center">
                                <%#Eval("ShiShouRenShu")%>
                            </td>
                            <td align="center">
                                <%#Eval("YiShouRenShu")%>
                            </td>
                            <td align="center" width="30%">
                                <%#Eval("JianYaoMiaoShu")%>
                            </td>
                            <td align="center">
                                <a class="orderinfo" data-id='<%#Eval("TuanGouId") %>' href="javascript:;">预定详情</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
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
</body>

<script type="text/javascript">
        $(function() {
            TuangouList.BindBtn();
        });
        var TuangouList = {
        reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //ajax执行文件路径,默认为本页面
            ajaxurl: "/WebMaster/TuangouList.aspx",
            //添加
            Add: function() {
                 TuangouList.ShowBoxy({ iframeUrl: "/WebMaster/TuangouEdit.aspx?dotype=add&id=", title: "新增", width: "600px", height: "500px" });
            },
            //修改
            Update: function(ObjsArr) {
                TuangouList.ShowBoxy({ iframeUrl: "/WebMaster/TuangouEdit.aspx?dotype=update&id=" + ObjsArr[0].find("input[type='checkbox']").val(), title: "修改", width: "600px", height: "500px" });
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
                if (objArr.length == 1) {
                    //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                    TuangouList.ajaxurl = "/WebMaster/Tuangoulist.aspx?dotype=delete&id=" + TuangouList.GetCheckBox(objArr);
                    //执行/ajax
                    TuangouList.GoAjax(TuangouList.ajaxurl);
                    return false;
                }
                else {
                    tableToolbar._showMsg("只能选择一行进行删除!");
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
            BindBtn: function() {
                 
                //绑定Add事件
                $(".toolbar_add").click(function() {
                    TuangouList.Add();
                    return false;
                });
                $(".orderinfo").click(function(){
                    var tuangouid= $(this).attr("data-id");
                    location.href="/WebMaster/OrderList.aspx?tuangouid="+tuangouid;
                })
                
                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行",
                    updateCallBack: function(objsArr) {
                        //修改
                        TuangouList.Update(objsArr);
                        return false;
                    },
                    deleteCallBack: function(objsArr) {
                        //删除(批量)
                        TuangouList.DelAll(objsArr);
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
                    afterHide: function() { TuangouList.reload(); }
                });
            }
        };
</script>

</html>
