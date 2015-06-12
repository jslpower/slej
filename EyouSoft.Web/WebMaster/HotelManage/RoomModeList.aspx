<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomModeList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.RoomModeList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
                        酒店名称:
                        <input type="text" name="txtHotelName" class="inputtext" maxlength="30" size="28"
                            value='<%=Request.QueryString["txtHotelName"] %>' />
                        房型名称:
                        <input type="text" name="txtRoomName" class="inputtext" maxlength="30" size="28"
                            value='<%=Request.QueryString["txtRoomName"] %>' />
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
                    <td width="90" align="center">
                        <a href="javascript:;" class="toolbar_up">上架</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="toolbar_down">下架</a>
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
                        <%--<input type="checkbox" id="checkbox3" name="checkbox3">全选--%>
                    </th>
                    <th align="center">
                        酒店名称
                    </th>
                    <th align="center">
                        房型名称
                    </th>
                    <th align="center">
                        总房间数
                    </th>
                    <th align="center">
                        挂牌价
                    </th>
                    <th align="center">
                        床型
                    </th>
                    <th align="center">
                        面积
                    </th>
                    <th align="center">
                        楼层
                    </th>
                    <th align="center">
                        最大人数
                    </th>
                    <th align="center">
                        房型状态
                    </th>
                    <th align="center">
                        管理
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <input type="checkbox" name="checkbox" value='<%#Eval("RoomTypeId ") %>' data-hotelid='<%#Eval("HotelId") %>'>
                            </td>
                            <td align="center">
                                <%#Eval("HotelName") %>
                            </td>
                            <td align="center">
                                <%#Eval("RoomName") %>
                            </td>
                            <td align="center">
                                <%#Eval("TotalNumber")%>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="showprice">
                                    <%#Convert.ToDecimal(Eval("PreferentialPrice")).ToString("0")%></a>
                            </td>
                            <td align="center">
                                <%# ((int)Eval("BedType"))==0?(Eval("BedTypeDescription")??"").ToString():"" %>
                            </td>
                            <td align="center">
                                <%#Eval("RoomArea")%>
                            </td>
                            <td align="center">
                                <%#Eval("Floor") %>
                            </td>
                            <td align="center">
                                <%#Eval("MaxGuestNum")%>
                            </td>
                            <td align="center">
                                <%#Eval("RoomStatus")%>
                            </td>
                            <td align="center">
                                <%# ((Eval("InterfaceID")==null || Eval("InterfaceID").ToString()=="")? ("<a href=\"RoomShenqing.aspx?hotelid=" + Eval("HotelId") + "\">房型价格计划</a>") :"")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
            <tr>
                    <th width="60" height="30" align="center">
                        <%--<input type="checkbox" id="checkbox3" name="checkbox3">全选--%>
                    </th>
                    <th align="center">
                        酒店名称
                    </th>
                    <th align="center">
                        房型名称
                    </th>
                    <th align="center">
                        总房间数
                    </th>
                    <th align="center">
                        挂牌价
                    </th>
                    <th align="center">
                        床型
                    </th>
                    <th align="center">
                        面积
                    </th>
                    <th align="center">
                        楼层
                    </th>
                    <th align="center">
                        最大人数
                    </th>
                    <th align="center">
                        房型状态
                    </th>
                    <th align="center">
                        管理
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
            width: 400,
            overlap: 0,
            centerPointY: 4,
            cornerRadius: 4,
            shadow: true,
            shadowColor: 'rgba(0,0,0,.5)',
            cssStyles: { color: '#1351a0', 'line-height': '200%' }
        });
        RoomModeList.BindBtn();
    });
    var RoomModeList = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
        },
        //ajax执行文件路径,默认为本页面
        ajaxurl: "/WebMaster/HotelManage/RoomModeList.aspx",
        //添加
        Add: function() {
            location.href = "/WebMaster/HotelManage/AddRoomMode.aspx?dotype=add&hotelid=" + '<%=Request.QueryString["hotelid"] %>';
        },
        //修改
        Update: function(objArr) {
            var obj = objArr[0].find("input[type='checkbox']");
            location.href = "/WebMaster/HotelManage/AddRoomMode.aspx?dotype=update&roomid=" + $(obj).val() + "&hotelid=" + $(obj).attr("data-hotelid");
        },
        Up: function(objArr) {
            if (objArr.length == 1) {
                //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                RoomModeList.ajaxurl = "/WebMaster/HotelManage/RoomModeList.aspx?dotype=up&roomid=" + RoomModeList.GetCheckBox(objArr);
                //执行/ajax
                RoomModeList.GoAjax(RoomModeList.ajaxurl);
                return false;
            }
            else {
                tableToolbar._showMsg("只能选择一行进行操作!");
                return false;
            }

        },
        Down: function(objArr) {
            if (objArr.length == 1) {
                //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                RoomModeList.ajaxurl = "/WebMaster/HotelManage/RoomModeList.aspx?dotype=down&roomid=" + RoomModeList.GetCheckBox(objArr);
                //执行/ajax
                RoomModeList.GoAjax(RoomModeList.ajaxurl);
                return false;
            }
            else {
                tableToolbar._showMsg("只能选择一行进行操作!");
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
        //删除(可多行)
        DelAll: function(objArr) {
            if (objArr.length == 1) {
                //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                RoomModeList.ajaxurl = "/WebMaster/HotelManage/RoomModeList.aspx?dotype=delete&roomid=" + RoomModeList.GetCheckBox(objArr);
                //执行/ajax
                RoomModeList.GoAjax(RoomModeList.ajaxurl);
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
                RoomModeList.Add();
                return false;
            });
            $("#liststyle .showprice").click(function() {
                var obj = $(this).closest("tr").find("input[type='checkbox']");
                var roomtypeid = $(obj).val();
                var hotelid = $(obj).attr("data-hotelid");
                var param = {
                    roomtypeid: roomtypeid,
                    hotelid: hotelid
                };
                var url = "/WebMaster/HotelManage/RoomPriceAll.aspx?" + $.param(param);
                Boxy.iframeDialog({ title: "查看房间价格", iframeUrl: url, height: 500, width: 840, draggable: false });
            })
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行",
                updateCallBack: function(objsArr) {
                    //修改
                    RoomModeList.Update(objsArr);
                    return false;
                },
                deleteCallBack: function(objsArr) {
                    //删除(批量)
                    RoomModeList.DelAll(objsArr);
                },
                otherButtons: [
		{
		    button_selector: '.toolbar_up',
		    sucessRulr: 2,
		    msg: '未选中任何信息 ',
		    buttonCallBack: function(objsArr) {
		        RoomModeList.Up(objsArr);
		    }
		},
		{
		    button_selector: '.toolbar_down',
		    sucessRulr: 2,
		    msg: '未选中任何 信息 ',
		    buttonCallBack: function(objsArr) {
		        RoomModeList.Down(objsArr);
		    }
		}
		]
            });
        }
    };
</script>

</html>
