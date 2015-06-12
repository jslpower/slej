<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.HotelList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>酒店管理</title>

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
                        酒店名称：
                        <input type="text" name="hotelname" class="inputtext" maxlength="30" size="28" value='<%=Request.QueryString["hotelname"] %>' />
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
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3" style="display: none">
                    </th>
                    <th align="center">
                        酒店名称
                    </th>
                    <th align="center">
                        酒店星级
                    </th>
                    <th align="center">
                        房型
                    </th>
                    <th align="center">
                        订单
                    </th>
                    <th align="center">
                        照片
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' i_gysid="<%#Eval("HotelId") %>"
                            i_uid="<%#Eval("UserId") %>">
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <input type="checkbox" name="checkbox" value='<%#Eval("HotelId") %>' interfaceid="<%#Eval("InterfaceId")%>">
                            </td>
                            <td align="left">
                                <a href="javascript:;" class="hotelinfo">
                                    <%#Eval("HotelName")%></a>
                            </td>
                            <td align="center">
                                <%#Eval("Star")%>
                            </td>
                            <td align="center">
                                <span style="display: none;">
                                    <%#GetRoomMode(Eval("RoomTypeList"))%></span><a class="paopao" data-room="room" href="javascript:;">
                                        房型</a>
                            </td>
                            <td align="center">
                                <a class="order" href="javascript:;" style="cursor: pointer">订单</a>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="hotelImg" data-name='<%#Eval("HotelName") %>' style="cursor: pointer">
                                    照片</a>
                            </td>
                            <td align="center">
                                <%#Eval("Status")%>
                            </td>
                            <td align="center">
                                <%#CheIsIndex(Eval("IsIndex"), Eval("HotelId"))%> <a data-class="paixu" href="javascript:;" data-id="<%#Eval("HotelId")%>">排序</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                <tr>
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox1" name="checkbox3" style="display: none">
                    </th>
                    <th align="center">
                        酒店名称
                    </th>
                    <th align="center">
                        酒店星级
                    </th>
                    <th align="center">
                        房型
                    </th>
                    <th align="center">
                        订单
                    </th>
                    <th align="center">
                        照片
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
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
    <br /><br />
</body>

<script type="text/javascript">
    $(function() {
        $('.paopao').bt({
            contentSelector: function() {
                return $(this).prev("span").html();
            },
            positions: ['bottom'],
            fill: '#effaff',
            strokeStyle: '#2a9cd4',
            noShadowOpts: { strokeStyle: "#2a9cd4" },
            spikeLength: 5,
            spikeGirth: 15,
            width: 860,
            overlap: 0,
            centerPointY: 4,
            cornerRadius: 4,
            shadow: true,
            shadowColor: 'rgba(0,0,0,.5)',
            cssStyles: { color: '#1351a0', 'line-height': '200%' }
        });
        $("a[data-class=paixu]").click(function() {
            var orderid = $(this).attr("data-id");
            HotelList.openwindow("/WebMaster/PaiXu.aspx?id=" + orderid + "&type=jiudian&dotype=paixu", "排序修改", 400, 200);
        });
        HotelList.BindBtn();

        $(".i_fenpei").click(function() { HotelList.fenPei(this); });
        $(".i_fenpei_1").click(function() { HotelList.fenPei1(this); });
    });
    var HotelList = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
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
        //ajax执行文件路径,默认为本页面
        ajaxurl: "/WebMaster/HotelManage/HotelList.aspx",
        //添加
        Add: function() {
            location.href = "/WebMaster/HotelManage/HotelEdit.aspx?dotype=add";
        },
        GetCheckBox: function() {
            return $('#liststyle :checkbox[val!=on][checked]:visible');
        },
        //修改
        Update: function(objArr) {
            var arr = HotelList.GetCheckBox();
            if (arr.length == 0) {
                tableToolbar._showMsg("未选中任何数据!");
                return false;
            }
            else if (arr.length != 1) {
                tableToolbar._showMsg("只能选择一行进行编辑!");
                return false;
            }
            else if (arr.length == 1) {
                if (arr.attr('InterfaceId')) {
                    tableToolbar._showMsg('从接口而来的数据无法修改', function() { });
                }
                else {
                    location.href = "/WebMaster/HotelManage/HotelEdit.aspx?dotype=update&id=" + arr.val();
                }
            }
        },
        EnIndex: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var url = "/WebMaster/HotelManage/HotelList.aspx?dotype=isindex&id=" + id + "&state=" + state;
            HotelList.GoAjax(url);
        },
        //删除(可多行)
        DelAll: function(objArr) {
            var arr = HotelList.GetCheckBox();
            if (arr.length == 0) {
                tableToolbar._showMsg("未选中任何数据!");
                return false;
            }
            else if (arr.length != 1) {
                tableToolbar._showMsg("只能选择一行进行删除!");
                return false;
            }
            else if (arr.length == 1) {
                if (arr.attr('InterfaceId')) {
                    tableToolbar._showMsg('从接口而来的数据无法删除', function() { });
                }
                else {
                    HotelList.ajaxurl = "/WebMaster/HotelManage/HotelList.aspx?dotype=delete&id=" + arr.val();
                    //执行/ajax
                    HotelList.GoAjax(HotelList.ajaxurl);
                    return false;
                }
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
                HotelList.Add();
                return false;
            });
            $("#liststyle .hotelinfo").click(function() {
                var hotelid = $(this).closest("tr").find("input[type='checkbox']").val();
                location.href = "HotelInfo.aspx?hotelid=" + hotelid;
            })
            $("#liststyle .paopao").click(function() {
                var hotelid = $(this).closest("tr").find("input[type='checkbox']").val();
                var url = "RoomModeList.aspx?hotelid=" + hotelid;
                location.href = url;
                return false;
            })
            $(".order").click(function() {
                var hotelid = $(this).closest("tr").find("input[type='checkbox']").val();
                location.href = "/WebMaster/HotelManage/HotelOrderList.aspx?hotelid=" + hotelid;
                return false;
            })
            $("#liststyle .hotelImg").click(function() {
                var hotelid = $(this).closest("tr").find("input[type='checkbox']").val();
                var hotelname = { name: $(this).attr("data-name") };
                var title = "编辑酒店图片";
                var url = "SetHotelImg.aspx?hotelid=" + hotelid + "&" + $.param(hotelname);
                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 800, width: 800, draggable: false })
                return false;
            })
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行",
                updateCallBack: function(objsArr) {
                    //修改
                    HotelList.Update(objsArr);
                    return false;
                },
                deleteCallBack: function(objsArr) {
                    //删除(批量)
                    HotelList.DelAll(objsArr);
                }
            });
        },
        fenPei: function(obj) {
            var _$tr = $(obj).closest("tr");
            var _data = { leixing: 1, gysid: _$tr.attr("i_gysid") };

            Boxy.iframeDialog({ title: "分配账号", iframeUrl: '/WebMaster/UserEdit.aspx', height: "350px", width: "580px", modal: true, data: _data });
        },
        fenPei1: function(obj) {
            var _$tr = $(obj).closest("tr");
            var _data = { leixing: 1, gysid: _$tr.attr("i_gysid"), id: _$tr.attr("i_uid"), action: "edit" };

            Boxy.iframeDialog({ title: "账号管理", iframeUrl: '/WebMaster/UserEdit.aspx', height: "350px", width: "580px", modal: true, data: _data });
        }
    };
</script>

</html>
