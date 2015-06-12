<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomShenqing.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.RoomShenqing" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>房型申请</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

</head>
<body>
    <div style="width: 99%">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <form id="form1" method="get">
                        <div class="searchbox">
                            <input type="hidden" name="hotelid" value="<%=Request.QueryString["hotelid"] %>" />
                            房型名称：
                            <input type="text" name="txtRoomName" class="inputtext" value="<%=Request.QueryString["txtRoomName"] %>" />
                            房型：
                            <select name="sltroomMode" id="sltroomMode" class="inputselect">
                                <%=BindRoomType(Request.QueryString["sltroomMode"])%>
                            </select>
                            时间：<input type="text" onfocus="WdatePicker()" name="txtStartTime" id="txtStartTime"
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
            <table width="100%" cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a class="toolbar_add" href="javascript:;">添加</a>
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
        <table width="100%" border="0" align="center" id="liststyle">
            <tbody>
                <tr class="odd">
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>
                    <th height="30" align="center">
                        申请时间段
                    </th>
                    <th height="30" align="center">
                        酒店房型
                    </th>
                    <th height="30" align="center">
                        挂牌价
                    </th>
                    <th height="30" align="center">
                        网络优惠价
                    </th>
                    <th height="30" align="center">
                        结算价
                    </th>
                    <th height="30" align="center">
                        申请人
                    </th>
                    <th height="30" align="center">
                        申请时间
                    </th>
                    <th height="30" align="center">
                        数量
                    </th>
                    <th height="30" align="center">
                        剩余
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpHotelPrice">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                <input type="checkbox" name="checkbox" value="<%#Eval("RoomRateId") %>" data-hotelid='<%#Eval("HotelId") %>'
                                    data-startmonth='<%#Eval("StartDate","{0:yyyy-MM-dd}") %>' data-endmonth='<%#Eval("EndDate","{0:yyyy-MM-dd}") %>'
                                    data-roomtypeid='<%#Eval("RoomTypeId") %>'>
                            </td>
                            <td>
                                <a href="javascript:;" class="rili">
                                    <%#Eval("StartDate","{0:yyyy-MM-dd}") %>
                                    ~<%#Eval("EndDate", "{0:yyyy-MM-dd}")%></a>
                            </td>
                            <td align="left">
                                <%#Eval("HotelName")%>&nbsp;<span style="color: Blue;"><%#Eval("RoomName")%></span>
                                &nbsp;<span style="color: Red;"><%#Eval("RoomType") %></span>
                            </td>
                            <td align="center">
                                <%#Eval("AmountPrice", "￥{0:N2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("PreferentialPrice", "￥{0:N2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("SettlementPrice", "￥{0:N2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("OperatorName") %>
                            </td>
                            <td align="center">
                                <%#Eval("IssueTime","{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center">
                                <%#Eval("ShuLiang") %>
                            </td>
                            <td align="center">
                                <%#Eval("ShengYuShuLiang") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
</html>

<script type="text/javascript">
    $(function() {
        RoomPage.BindBtn();
    })
    var RoomPage = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
        },
        //ajax执行文件路径,默认为本页面
        ajaxurl: '/WebMaster/HotelManage/RoomShenqing.aspx?hotelid=<%=Request.QueryString["hotelid"] %>',
        //添加
        Add: function() {
            var url = '/WebMaster/HotelManage/RoomEdit.aspx?dotype=add&hotelid=<%=Request.QueryString["hotelid"] %>';
            Boxy.iframeDialog({ title: "新增房价", iframeUrl: url, height: 300, width: 500, draggable: false });
            return false;
        },
        //修改
        Update: function(objArr) {
            var url = '/WebMaster/HotelManage/RoomEdit.aspx?dotype=update&hotelid=<%=Request.QueryString["hotelid"] %>&id=' + objArr[0].find("input[type='checkbox']").val();
            Boxy.iframeDialog({ title: "修改房价", iframeUrl: url, height: 300, width: 500, draggable: false });
            return false;
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
                RoomPage.ajaxurl = "/WebMaster/HotelManage/RoomShenqing.aspx?dotype=delete&id=" + RoomPage.GetCheckBox(objArr);
                //执行/ajax
                RoomPage.GoAjax(RoomPage.ajaxurl);
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
                RoomPage.Add();
                return false;
            });
            $("#liststyle .rili").click(function() {
                var obj = $(this).closest("tr").find("input[type='checkbox']");
                var roomtypeid = $(obj).attr("data-roomtypeid");
                var hotelid = $(obj).attr("data-hotelid");
                var startMonth = $(obj).attr("data-startmonth");
                var endMonth = $(obj).attr("data-endmonth");
                var roomrateid = $(obj).val();
                var param = {
                    roomtypeid: roomtypeid,
                    hotelid: hotelid,
                    startMonth: startMonth,
                    endMonth: endMonth,
                    roomrateid: roomrateid
                };
                var url = "/WebMaster/HotelManage/RoomPrice.aspx?" + $.param(param);
                Boxy.iframeDialog({ title: "查看房间价格", iframeUrl: url, height: 500, width: 840, draggable: false });
            })
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行",
                updateCallBack: function(objsArr) {
                    //修改
                    RoomPage.Update(objsArr);
                    return false;
                },
                deleteCallBack: function(objsArr) {
                    //删除(批量)
                    RoomPage.DelAll(objsArr);
                }
            });
        }
    }
</script>

