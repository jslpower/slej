<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TourOrderList.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.HotelManage.TourOrderList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script src="/JS/bt.min.js" type="text/javascript"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <div class="searchbox" align="center">
                        <h1>
                            团队订单列表</h1>
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th align="center" width="7%" valign="middle" height="23">
                        采购用户名
                    </th>
                    <th align="center" width="6%" valign="middle">
                        入住时间
                    </th>
                    <th align="center" width="7%" valign="middle">
                        离店时间
                    </th>
                    <th align="center" width="8%" valign="middle">
                        地址位置要求
                    </th>
                    <th align="center" width="9%" valign="middle">
                        是否有指定酒店
                    </th>
                    <th align="center" width="6%" valign="middle">
                        星级
                    </th>
                    <th align="center" width="6%" valign="middle">
                        房间要求
                    </th>
                    <th align="center" width="5%" valign="middle">
                        房间数
                    </th>
                    <th align="center" width="3%" valign="middle">
                        人数
                    </th>
                    <th align="center" width="6%" valign="middle">
                        团房预算
                    </th>
                    <th align="center" width="6%" valign="middle">
                        宾客类型
                    </th>
                    <th align="center" width="6%" valign="middle">
                        团队类型
                    </th>
                    <th align="center" width="7%" valign="middle">
                        提交时间
                    </th>
                    <th align="center" width="11%" valign="middle">
                        备注要求
                    </th>
                    <th align="center" valign="middle" colspan="2">
                        回复记录
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td height="25" align="center">
                                <span style="display: none; width:300px;">
                                    联系人姓名:<%#Eval("ContacterName")%><br />
                                    联系人手机:<%#Eval("ContacterMobile")%><br />
                                    联系人电话:<%#Eval("ContacterTelephone")%><br />
                                </span>
                                <a class="paopao" href="javascript:void(0);"><%#Eval("UserName")%></a>
                            </td>
                            <td align="center">
                                <%#Eval("LiveStartDate")!=null? EyouSoft.Common.Utils.GetDateTime(Eval("LiveStartDate").ToString()).ToString("yyyy-MM-dd"):"" %>
                            </td>
                            <td align="center">
                                <%#Eval("LiveEndDate") != null ? EyouSoft.Common.Utils.GetDateTime(Eval("LiveEndDate").ToString()).ToString("yyyy-MM-dd") : ""%>
                            </td>
                            <td align="center">
                                <%#Eval("LocationAsk")%>
                            </td>
                            <td align="center">
                                <%#Eval("HotelName")%>
                            </td>
                            <td align="center">
                                <%#Eval("HotelStar")%>
                            </td>
                            <td align="center">
                                <%#Eval("RoomAsk")%>
                            </td>
                            <td align="center">
                                <%#Eval("RoomCount")%>
                            </td>
                            <td align="center">
                                <%#Eval("PeopleCount")%>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.Utils.GetDecimal(Eval("BudgetMin").ToString()).ToString("F2")%>-<%#EyouSoft.Common.Utils.GetDecimal(Eval("BudgetMax").ToString()).ToString("F2")%>
                            </td>
                            <td align="center">
                                <%#Eval("GuestType").ToString() != "0" ? Eval("GuestType") : ""%>
                            </td>
                            <td align="center">
                                <%#Eval("TourType").ToString() != "0" ? Eval("TourType") : ""%>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.Utils.GetDateTime(Eval("IssueTime").ToString()).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#Eval("OtherRemark")%>
                            </td>
                            <td width="4%" align="center">
                                <a href="javascript:void(0)">
                                    <div onclick="pageOpt.ShowReverList(this,'<%#Eval("Id")%>')">
                                        ▼显示</div>
                                </a>
                            </td>
                            <td width="3%" align="center">
                                <a href="javascript:void(0)" class="AddRever" data-id="<%#Eval("Id")%>">添加</a>
                            </td>
                        </tr>
                        <tr remarkone="<%#Eval("Id")%>" style="display: none;">
                            <td colspan="16" align="center">
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                <tr>
                    <th align="center" width="7%" valign="middle" height="23">
                        采购用户名
                    </th>
                    <th align="center" width="6%" valign="middle">
                        入住时间
                    </th>
                    <th align="center" width="7%" valign="middle">
                        离店时间
                    </th>
                    <th align="center" width="8%" valign="middle">
                        地址位置要求
                    </th>
                    <th align="center" width="9%" valign="middle">
                        是否有指定酒店
                    </th>
                    <th align="center" width="6%" valign="middle">
                        星级
                    </th>
                    <th align="center" width="6%" valign="middle">
                        房间要求
                    </th>
                    <th align="center" width="5%" valign="middle">
                        房间数
                    </th>
                    <th align="center" width="3%" valign="middle">
                        人数
                    </th>
                    <th align="center" width="6%" valign="middle">
                        团房预算
                    </th>
                    <th align="center" width="6%" valign="middle">
                        宾客类型
                    </th>
                    <th align="center" width="6%" valign="middle">
                        团队类型
                    </th>
                    <th align="center" width="7%" valign="middle">
                        提交时间
                    </th>
                    <th align="center" width="11%" valign="middle">
                        备注要求
                    </th>
                    <th align="center" valign="middle" colspan="2">
                        回复记录
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
    </form>
</body>

<script type="text/javascript">
    $(function() {
        $('.paopao').bt({
            contentSelector: function() {
                //return "<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'><tr class='pp-table-title'><th>房型</th><th>结算价</th><th>优惠价</th><th>早餐</th><th>床型</th><th>宽带</th><th>支付</th><th>数量</th><th>状态</th><th>管理</th></tr></table>";
                return $(this).prev("span").html();
            },
            positions: ['bottom'],
            fill: '#effaff',
            strokeStyle: '#2a9cd4',
            noShadowOpts: { strokeStyle: "#2a9cd4" },
            spikeLength: 5,
            spikeGirth: 15,
            //width: 860,
            overlap: 0,
            centerPointY: 4,
            cornerRadius: 4,
            shadow: true,
            shadowColor: 'rgba(0,0,0,.5)',
            cssStyles: { color: '#1351a0', 'line-height': '200%' }
        });
    });
    $(function() {
        pageOpt.BindBtn();
    });
    var pageOpt = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
        },
        //ajax执行文件路径,默认为本页面
        ajaxurl: "/WebMaster/HotelManage/TourOrderList.aspx",
        //添加留言回复
        AddRever: function(id) {
            pageOpt.ShowBoxy({ iframeUrl: "/WebMaster/HotelManage/HotelOrderMsg.aspx?dotype=Add&tid=" + id, title: "留言回复", width: "400px", height: "350px" });
        },
        //获取订单回复列表
        ShowReverList: function(obj, id) {
            var showstr = "▼显示";
            var hiddenstr = "▲隐藏";
            var currentstr = $(obj).html();
            if (currentstr == hiddenstr) {
                $(obj).html(showstr);
            } else {
                $(obj).html(hiddenstr);
            }
            var tr = $(obj).parent().parent();
            if (currentstr == hiddenstr) {
                $("#liststyle tr[remarkOne]").each(function() {
                    if ($(this).attr("remarkOne") == id)
                        $(this).hide();

                });
            } else {
                $.newAjax({
                    type: "get",
                    dataType: 'html',
                    url: "TourOrderList.aspx?dotype=ShowRever&id=" + id,
                    cache: false,
                    async: false,
                    success: function(html) {
                        $("#liststyle tr[remarkOne]").each(function() {
                            if ($(this).attr("remarkOne") == id) {
                                $(this).children().html(html);
                                $(this).show();
                            }
                        });
                        //  tr.after("<tr remarkOne='"+id+"'><td colspan='16'>"+ html+"</td></tr>");
                    },
                    error: function() {
                        //tr.after("<tr remarkOne='"+id+"'><td colspan='16'>未能成功获取响应结果</td></tr>");
                        $("#tbList tr[remarkOne]").each(function() {
                            if ($(this).attr("remarkOne") == id) {
                                $(this).children().html("未能成功获取响应结果");
                            }
                        });
                    }
                });
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
                afterHide: function() { pageOpt.reload(); }
            });
        },
        BindBtn: function() {
            $(".AddRever").click(function() {
                var id = $(this).attr("data-id");
                if (id) {
                    pageOpt.AddRever(id);
                    return false;
                }
            });
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行"
            });
        }
    };
</script>

</html>
