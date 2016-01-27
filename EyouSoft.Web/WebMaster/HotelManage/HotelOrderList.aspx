<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrderList.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.HotelOrderList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>


    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/bt.min.js" type="text/javascript"></script>
    <style type="text/css">
    .pnone{display:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <div class="searchbox">
                            搜索订单:酒店名称
                            <input name="hotelName" id="hotelName" value="" size="15" class="inputtext" />
                            <input name="checkType" type="radio" id="rzTime" value="1" checked="checked" />
                            <label for="rzTime">
                                入住时间:</label>
                            <input name="checkType" type="radio" id="ydTime" value="2" />
                            <label for="ydTime">
                                预定时间:</label>
                            <input name="txtOrderStartTime" id="txtOrderStartTime" value="" size="15" class="inputtext"
                                onfocus="WdatePicker()" />
                            -
                            <input name="txtOrderEndTime" id="txtOrderEndTime" value="" size="15" class="inputtext"
                                onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtOrderStartTime\')}'})" />&nbsp;
                            订单来源:<select name="sltsource" id="sltsource" class="inputselect">
                                <%=SourceStr %>
                            </select>
                            <br />
                            单位名称:<input name="txtcompanyName" id="txtcompanyName" size="20" class="inputtext" />
                            下单渠道：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
                        <option value="-1">请选择</option>
                            <%=GetSellersHtml()%>
                        </select>
                            <input type="button" name="serch" id="serch" class="search-btn" />
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/Images/webmaster/yuanright.gif" alt="" />
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="99%"cellspacing="1" cellpadding="0" border="0" align="center" id="liststyle">
            <tr>
                <th width="30" height="30" nowrap="nowrap">
                    序号<br />
                </th>
                <th height="30" nowrap="nowrap">
                    订单内容<br />
                </th>
                <th width="135" nowrap="nowrap">
                    渠道
                </th>
                <th width="70" align="center" nowrap="nowrap">
                    入住时间
                </th>
                <th width="70" nowrap="nowrap">
                    离开时间
                </th>
                <th width="80" nowrap="nowrap">
                    联系人
                </th>
                <th width="90" nowrap="nowrap">
                    操作人
                </th>
                <th width="115" align="center" nowrap="nowrap">
                    交易金额
                </th>
                <th width="115" align="center" nowrap="nowrap">
                    分销金额
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    分销利润
                </th>
                <th width="70" align="center" nowrap="nowrap">
                    下单时间
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    订单付款方式
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    客户付款方式
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rpt_list" runat="server">
                <ItemTemplate>
                    <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                        <td height="30" align="center">
                            <%#Container.ItemIndex+1%>
                        </td>
                        <td height="30" align="left">
                            订单号：<a href="HotelOrderEdit.aspx?id=<%#Eval("OrderId") %>&dotype=show"><%#Eval("OrderCode")%></a><br />
                            <%#Eval("HotelName")%><br /><span style="color:Red"><%# Eval("PaymentType")%></span>
                        </td>
                        <td height="30" align="center">
                            <%# GetWangDianByID(Eval("SellerID"))%>
                        </td>
                        <td height="30" align="center" nowrap="nowrap">
                            <%# this.ToDateTimeString( Eval("CheckInDate"))%>
                        </td>
                        <td height="30" align="center">
                            <%# this.ToDateTimeString(Eval("CheckOutDate"))%>
                        </td>
                        <td height="30" align="left" nowrap="nowrap">
                        <%# Eval("ContactName")%><br />
                     <%# Eval("ContactMobile")%>
                        </td>
                        <td height="30" align="left" nowrap="nowrap">
                            <span style="color:Red"><%# Eval("UserType")%></span><br /><%# Eval("OperatorName")%> <br />
                     <%# Eval("OperatorMobile")%>
                        </td>
                        <td height="30" align="left" nowrap="nowrap">
                            <span style="display: none;"><%# GetJinEList(Eval("HotelXC"), Eval("RoomCount"))%></span>
                            房间数：<%# Eval("RoomCount")%> 间<br />
                     单价：<%#  (Convert.ToDouble(Eval("TotalAmount"))/Convert.ToDouble(Eval("RoomCount"))).ToString("f2")%> 元/间<br />
                     <tm class="jymoney">金额：<%#  Convert.ToDouble(Eval("TotalAmount")).ToString("f2")%> 元
                          </tm>
                        </td>
                        <td align="left" nowrap="nowrap" class="<%#Eval("SellerID").ToString().Trim().Length > 20?"":"pnone"%>">
                            房间数：<%# Eval("RoomCount")%> 间<br />
                     单价：<%#  (Convert.ToDouble(Eval("AgencyJinE")) / Convert.ToDouble(Eval("RoomCount"))).ToString("f2")%> 元/间<br />
                     金额：<%# Eval("SellerID").ToString().Trim().Length > 20 ? Convert.ToDouble(Eval("AgencyJinE")).ToString("f2") : "0"%> 元
                        </td>
                        <td align="left" nowrap="nowrap" class="<%#Eval("SellerID").ToString().Trim().Length > 20?"pnone":""%>">
                            总站交易
                        </td>
                        <td height="30" align="center" nowrap="nowrap" class="red">
                            <%# Eval("SellerID").ToString().Trim().Length > 20 ? (Convert.ToDouble(Eval("TotalAmount")) - (Convert.ToDouble(Eval("AgencyJinE")))).ToString("f2") : "0"%>元
                        </td>
                        <td height="30" align="center" nowrap="nowrap">
                            <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td><%# Eval("PaymentType")%></td>
                        <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("OrderId"), Eval("OrderState"))%></td>
                        <td height="30" align="center" nowrap="nowrap">
                        <%# setOptClick(Eval("OrderId").ToString(), Eval("OrderState"), Eval("SellerID"))%><br />
                        <%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("OrderState"))%>
                        <%--<%# DeleteUserOrder(Eval("OrderId").ToString(), Eval("Status"))%>--%>
                            <%--<div align="center">
                                <p>
                                    <a href="HotelOrderEdit.aspx?id=<%#Eval("OrderId")%>">查看 </a>
                                </p>
                            </div>--%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tfoot>
            <tr class="<%= RecordCount % 2 == 0 ?  "even" : "odd"%>">
                <td colspan="6"></td>
                <td align="center">合计金额：</td>
                <td align="center">￥<%=SumMoney.ToString("f2") %></td>
                <td align="center">￥<%=SumAMoney.ToString("f2")%></td>
                <td align="center">￥<%=SumLiRun.ToString("f2")%></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <th width="30" height="30" nowrap="nowrap">
                    序号<br />
                </th>
                <th height="30" nowrap="nowrap">
                    订单内容<br />
                </th>
                <th width="135" nowrap="nowrap">
                    渠道
                </th>
                <th width="70" align="center" nowrap="nowrap">
                    入住时间
                </th>
                <th width="70" nowrap="nowrap">
                    离开时间
                </th>
                <th width="80" nowrap="nowrap">
                    联系人
                </th>
                <th width="90" nowrap="nowrap">
                    操作人
                </th>
                <th width="115" align="center" nowrap="nowrap">
                    交易金额
                </th>
                <th width="115" align="center" nowrap="nowrap">
                    分销金额
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    分销利润
                </th>
                <th width="70" align="center" nowrap="nowrap">
                    下单时间
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    订单付款方式
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    客户付款方式
                </th>
                <th width="60" align="center" nowrap="nowrap">
                    操作
                </th>
            </tr>
            </tfoot>
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
    </div><br /><br />
    </form>

    <script type="text/javascript">
    
    $(function() {
        $('.jymoney').bt({
            contentSelector: function() {
                return $(this).parent().find("span").html();
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
        });
    
    
    
    
    
        function test(oid, state)
        { alert(oid + state) }
        var OrderList = {
            setOrder: function(oid, state) {
                if (window.confirm("请确认操作")) {
                    $.ajax({
                        url: "/WebMaster/HotelManage/HotelOrderList.aspx?setState=1&id=" + oid + "&state=" + state,
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg);
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                        }
                    })
                }
            },
            DeleteOrder: function(oid) {
        if (window.confirm("请确认操作")) {
            $.ajax({
                url: "/WebMaster/HotelManage/HotelOrderList.aspx?setState=2&id=" + oid,
                dataType: "json",
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg);
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            })
        }
    }
        };
        var pageOpt = {
            hotelName: '<%=Request.QueryString["hotelName"] %>',
            ischk: '<%=Request.QueryString["checkType"] %>',
            stime: '<%=Request.QueryString["startTime"] %>',
            etime: '<%=Request.QueryString["endTime"] %>',
            sltsource: '<%=Request.QueryString["sltsource"] %>',
            qudaolist: '<%=Request.QueryString["qudaolist"] %>',
            companyname: '<%=Request.QueryString["companyname"] %>'
        };

        $(function() {
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行"
            });
            $("#serch").click(function() {
                var serchModel = {
                    hotelName: $("#hotelName").val(),
                    checkType: $("input[name=checkType]:checked").val(),
                    startTime: $("#txtOrderStartTime").val(),
                    endTime: $("#txtOrderEndTime").val(),
                    sltsource: $("#sltsource").val(),
                    qudaolist: $("#qudaolist").val(),
                    companyname: $("#txtcompanyName").val()
                };
                window.location.href = "HotelOrderList.aspx?" + $.param(serchModel);
            });
            $("#hotelName").val(pageOpt.hotelName);
            $("#txtOrderStartTime").val(pageOpt.stime);
            $("#txtOrderEndTime").val(pageOpt.etime);
            $("#txtcompanyName").val(pageOpt.companyname);
            pageOpt.ischk == "1" ? $("#rzTime").attr("checked", true) : $("#ydTime").attr("checked", true)
        })
    </script>

</body>
</html>
