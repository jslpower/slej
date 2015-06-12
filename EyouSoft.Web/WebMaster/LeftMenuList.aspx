<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftMenuList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.LeftMenuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="EyouSoft.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>运营后台左侧菜单</title>
    <link href="/Css/webmaster/manager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hide
        {
            display: none;
        }
    </style>

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script language="JavaScript" type="">
        function setMenuTitle(spanId, imgId) {
            //$("#" + spanId).toggle();
            document.getElementById(spanId).style.display = (document.getElementById(spanId).style.display == 'none') ? '' : 'none';
            var $objImg = $("#" + imgId);
            if ($objImg.attr("src") == "/images/webmaster/button_up.gif") {
                $objImg.attr("src", "/images/webmaster/button_down.gif");
            }
            else if ($objImg.attr("src") == "/images/webmaster/button_down.gif") {
                $objImg.attr("src", "/images/webmaster/button_up.gif");
            }
        }

        function setAcss(id_num, cap) {

            setvalue("当前操作：" + cap);
        }

        var strColumns_Current = "20,*";
        //菜单隐藏rows="20,*"
        function hidetoc() {
            strColumns_Current = top.contset.rows
            top.contset.rows = "1,*";
        }
        //菜单显示
        function showtoc() {
            top.contset.rows = strColumns_Current;
        }

        function mouseovertoc() {
            //      window.status = "隐藏菜单";
            document.all.hidemenu.src = "/images/webmaster/hidetoc2.gif";
        }

        function mouseouttoc() {
            document.all.hidemenu.src = "/images/webmaster/hidetoc1.gif";
        }
        //设置单项选中样式
        function setMenuClass(obj) {
            $("a").each(function() {
                $(this).attr("class", "");
            })
            $(obj).attr("class", "menuon");
        }
        $(function() {
            $("a").click(function() {
                setMenuClass(this);
            });
        });
    </script>

    <style type="text/css">
        body
        {
            background-color: #E6EDF2;
            overflow-x: hidden;
        }
        HTML
        {
            overflow-x: hidden;
            overflow-y: auto;
        }
    </style>
</head>
<body>
    <asp:PlaceHolder runat="server" ID="WebmasterModule" Visible="false">
        <!--线路-->
        <div class="leftmenu" id="divRouteManage" runat="server">
            <span class="linkcsstitle" id="main0" onclick="javascript: setMenuTitle('spanRouteManage','RouteManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="36" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">线路产品</strong></font>
                        </td>
                        <td width="22">
                            <img id="RouteManage" src="/images/webmaster/button_up.gif" name="menutitle0" alt="" />
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanRouteManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trRoute" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder0" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="RouteList.aspx" target="mainFrame" style="font-size: 14px">线路管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trArea" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder14" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/AreaList.aspx" target="mainFrame" style="font-size: 14px">线路区域</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="trOrder" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="OrderList.aspx" target="mainFrame">订单管理</a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                    <tr id="trTuanGou" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder2" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="TuangouList.aspx" target="mainFrame" style="font-size: 14px">团购产品</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr35" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder54" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="DanDuZuTuan.aspx" target="mainFrame" style="font-size: 14px">组团费用</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <!--签证管理-->
        <div class="leftmenu" id="div5" runat="server">
            <span class="linkcsstitle" id="Span3" onclick="javascript: setMenuTitle('span_qianzheng','img_qianzheng');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">签证管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="img_qianzheng" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span_qianzheng" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr24" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder40" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/QianZheng/QianZheng.aspx" target="mainFrame" style="font-size: 14px">
                                    签证信息管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="tr25" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder41" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/QianZheng/DingDan.aspx" target="mainFrame">签证订单管理</a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                </table>
            </span>
        </div>
        <!--景区-->
        <div class="leftmenu" id="div1" runat="server">
            <span class="linkcsstitle" id="main5" onclick="javascript: setMenuTitle('spanScenicAndTicket','ScenicAndTicket');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">景区门票</strong></font>
                        </td>
                        <td width="22">
                            <img id="ScenicAndTicket" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanScenicAndTicket" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr6" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder4" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/ScenicAndTicketManage/ScenicList.aspx" target="mainFrame" style="font-size: 14px">
                                    景区管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trScenicTicket" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder5" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/ScenicAndTicketManage/Ticket.aspx" target="mainFrame" style="font-size: 14px">
                                    景区门票管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="trScenicOrder" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder7" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/ScenicAndTicketManage/ScenicOrderList.aspx" target="mainFrame">景区订单管理</a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                </table>
            </span>
        </div>
        <!--酒店-->
        <div class="leftmenu" id="div2" runat="server">
            <span class="linkcsstitle" id="Span1" onclick="javascript: setMenuTitle('spanScenicAndHotel','spanScenicAndHotel');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">酒店产品</strong></font>
                        </td>
                        <td width="22">
                            <img id="Img1" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanScenicAndHotel" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr8" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder8" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/HotelManage/HotelList.aspx" target="mainFrame" style="font-size: 14px">
                                    酒店管理 </a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="tr10" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder9" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/HotelManage/RoomModeList.aspx" target="mainFrame" style="font-size: 14px">
                                    酒店房型管理 </a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                    <%--<tr id="tr9" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder10" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/HotelManage/HotelOrderList.aspx" target="mainFrame">酒店订单管理 </a>
                            </asp:PlaceHolder>
                        </td>
                    </tr>--%>
                    <%--                <tr id="tr7" runat="server">
                    <td>
                        <img src="/images/webmaster/func_default.gif" />
                        <a href="/WebMaster/HotelManage/TourOrderList.aspx" target="mainFrame">团队订单查询</a>
                    </td>
                </tr>--%>
                </table>
            </span>
        </div>
        <!--租车-->
        <div class="leftmenu" id="div8" runat="server">
            <span class="linkcsstitle" id="Span5" onclick="javascript: setMenuTitle('spanZuCheManage','ZucheManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">租车产品</strong></font>
                        </td>
                        <td width="22">
                            <img id="ZucheManage" src="/images/webmaster/button_up.gif" name="menutitle0" alt="" />
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanZuCheManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr32" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder43" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="ZuChe/zuchelist.aspx" target="mainFrame" style="font-size: 14px">租车管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="tr7" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder3" runat="server">
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="ZuChe/ZuCheOrderList.aspx" target="mainFrame">租车订单管理</a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                </table>
            </span>
        </div>
        <!--团购管理-->
        <div class="leftmenu" id="div6" runat="server">
            <span class="linkcsstitle" onclick="javascript: setMenuTitle('spanTuangou','imgTuangou');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">促销秒杀</strong></font>
                        </td>
                        <td width="22">
                            <img id="imgTuangou" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanTuangou" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder6" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/TuanGou/TuanGouList.aspx" target="mainFrame" style="font-size: 14px">
                                    产品管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <%--<tr>
                <td>
                <asp:PlaceHolder ID="PlaceHolder47" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/TuanGou/TuanGouDingDans.aspx" target="mainFrame">订单管理</a>
                </asp:PlaceHolder>
                </td>
                </tr>--%>
                </table>
            </span>
        </div>
        <!--订单中心-->
        <div class="leftmenu" id="div7" runat="server">
            <span class="linkcsstitle" id="Span4" onclick="javascript: setMenuTitle('span7','span7');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">订单中心</strong></font>
                        </td>
                        <td width="22">
                            <img id="Img3" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span7" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr28" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder20" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/DingDanList.aspx" target="mainFrame" style="font-size: 14px">交易统计</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr13" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder29" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/OrderList.aspx?type=3" target="mainFrame" style="font-size: 14px">
                                    短线订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr7" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/OrderList.aspx?type=1" target="mainFrame" style="font-size: 14px">
                                    长线订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr9" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder3" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/OrderList.aspx?type=2" target="mainFrame" style="font-size: 14px">
                                    出境订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr25" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder10" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/ZiZuTuanList.aspx" target="mainFrame" style="font-size: 14px">单团订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr14" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder30" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/ScenicAndTicketManage/ScenicOrderList.aspx" target="mainFrame"
                                    style="font-size: 14px">门票订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr15" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder31" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/HotelManage/HotelOrderList.aspx" target="mainFrame" style="font-size: 14px">
                                    酒店订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr16" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder32" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/ZuChe/ZuCheOrderList.aspx" target="mainFrame" style="font-size: 14px">
                                    租车订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr17" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder33" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/QianZheng/DingDan.aspx" target="mainFrame" style="font-size: 14px">
                                    签证订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr18" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder34" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/OrderList.aspx" target="mainFrame" style="font-size: 14px">
                                    商城订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr26" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder42" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/TuanGou/TuanGouDingDans.aspx" target="mainFrame" style="font-size: 14px">
                                    团购订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr38" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder58" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/JiPiaoOrderList.aspx" target="mainFrame" style="font-size: 14px">
                                    机票订单</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <!--财务管理-->
        <div class="leftmenu" id="div4" runat="server">
            <span class="linkcsstitle" id="Span2" onclick="javascript: setMenuTitle('spanTatolProduct','TatolProduct');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">财务管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="TatolProduct" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanTatolProduct" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr19" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder35" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/ChongZhiList.aspx" target="mainFrame" style="font-size: 14px">
                                    充值管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr20" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder36" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/TiXianList.aspx" target="mainFrame" style="font-size: 14px">
                                    提现管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr21" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder37" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/FanLiList.aspx" target="mainFrame" style="font-size: 14px">
                                    返利管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="tr25" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder10" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/JiaoYiList.aspx" target="mainFrame" style="font-size: 14px">
                                    交易管理</a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                    <tr id="tr27" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder41" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/ZhangHuMingXi.aspx" target="mainFrame" style="font-size: 14px">
                                    账户明细</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr29" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder28" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/InterestrateSet.aspx" target="mainFrame" style="font-size: 14px">
                                    E额宝积分比例</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr30" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder50" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MoneyManagement/PayMentRecord.aspx" target="mainFrame" style="font-size: 14px">
                                    E额宝积分报表</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr39" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder59" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="JiFenDuiHuan.aspx" target="mainFrame" style="font-size: 14px">
                                    积分兑换审核</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr31" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder51" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/XiaJiJiangLiBiLi.aspx" target="mainFrame" style="font-size: 14px">
                                    下级分销奖励比例</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr33" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder52" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/XiaJiJiangLi.aspx" target="mainFrame" style="font-size: 14px">下级分销奖励申请</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr34" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder53" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/FanLianMengTuiGuangBiLi.aspx" target="mainFrame" style="font-size: 14px">
                                    返联盟比例管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr36" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder55" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/FanLianMengTuiGuangFanLi.aspx" target="mainFrame" style="font-size: 14px">
                                    返联盟返利管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div9" runat="server">
            <!--系统设置-->
            <span class="linkcsstitle" id="divSys" onclick="javascript: setMenuTitle('span6','Img2');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">系统设置</strong></font>
                        </td>
                        <td width="22">
                            <img id="Img2" src="/images/webmaster/button_up.gif" name="menutitle2">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span6" style="display: none">
                <table>
                    <tr id="tr12" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder26" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/FeeSetting.aspx?searchinfo.showmode=update" target="mainFrame"
                                    style="font-size: 14px">费用相关</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <!--基础信息-->
        <div class="leftmenu" id="divBasicManage" runat="server">
            <span class="linkcsstitle" id="main2" onclick="javascript: setMenuTitle('spanBasicManage','BasicManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">基础信息</strong></font>
                        </td>
                        <td width="22">
                            <img id="BasicManage" src="/images/webmaster/button_up.gif" name="menutitle2">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanBasicManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trCompany" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder12" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/CompanyInfo.aspx" target="mainFrame" style="font-size: 14px">公司信息</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr37" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder57" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/XieYi.aspx" target="mainFrame" style="font-size: 14px">网站协议</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trWebSite" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder13" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/WebSiteInfo.aspx" target="mainFrame" style="font-size: 14px">网站基本信息</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trCity" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder15" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/CityManage.aspx" target="mainFrame" style="font-size: 14px">城市信息</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trRouteKeyWord" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder16" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/RouteTheme.aspx" target="mainFrame" style="font-size: 14px">线路主题</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder17" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/TravelArticleClass.aspx" target="mainFrame" style="font-size: 14px">
                                    旅游资讯类别</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trTravelArticleList" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder18" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/TravelArticleList.aspx" target="mainFrame" style="font-size: 14px">
                                    旅游资讯</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder19" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/AdvList.aspx" target="mainFrame" style="font-size: 14px">站点广告</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder56" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/EBaoInfo.aspx" target="mainFrame" style="font-size: 14px">E额宝介绍</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr5" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder21" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/Strategy/StrategyThemeList.aspx" target="mainFrame" style="font-size: 14px">
                                    旅游攻略主题</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder22" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/Strategy/StrategyList.aspx" target="mainFrame" style="font-size: 14px">
                                    旅游攻略</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr22" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder38" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/DiBiao.aspx" target="mainFrame" style="font-size: 14px">地标管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr23" runat="server" visible="false">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder39" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/FeedbackManage.aspx" target="mainFrame" style="font-size: 14px">
                                    反馈信息管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <!--会员管理-->
        <div class="leftmenu" id="divUserManage" runat="server">
            <span class="linkcsstitle" id="main1" onclick="javascript: setMenuTitle('spanUserManage','UserManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">会员管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="UserManage" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanUserManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trUser" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder11" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MemberCenter/MemberList.aspx" target="mainFrame" style="font-size: 14px">会员管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%--<tr id="TrUserList" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder28" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="MemberCenter/ApplyUserList.aspx" target="mainFrame" style="font-size: 14px">
                                    会员申请管理</a></asp:PlaceHolder>
                        </td>
                    </tr>--%>
                </table>
            </span>
        </div>
        <!--后台用户管理-->
        <div class="leftmenu" id="divMasterUserManage" runat="server">
            <span class="linkcsstitle" id="main4" onclick="javascript: setMenuTitle('spanMasterUserManage','MasterUserManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">后台用户</strong></font>
                        </td>
                        <td width="22">
                            <img id="MasterUserManage" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanMasterUserManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trMasterUserInfo" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder23" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/UserInfo.aspx" target="mainFrame" style="font-size: 14px">总账户信息</a>
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trMasterUserList" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder24" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/UserList.aspx" target="mainFrame" style="font-size: 14px">后台用户管理</a>
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trMasterProviders" runat="server">
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="/WebMaster/Supplier/SupplierList.aspx" target="mainFrame" style="font-size: 14px">
                                供应商用户管理</a>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="ProvidersModule">
        <div class="leftmenu" id="div3" runat="server">
            <span class="linkcsstitle" onclick="javascript: setMenuTitle('span_qianzheng_01','img_qianzheng_01');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">商城联盟</strong></font>
                        </td>
                        <td width="22">
                            <img id="img_qianzheng_01" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span_qianzheng_01" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <asp:PlaceHolder ID="PlaceHolder44" runat="server">
                        <%--<tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/Supplier/SupplierEdit.aspx?type=left" target="mainFrame" style="font-size: 14px">
                                    账号管理</a>
                            </td>
                        </tr>--%>
                        <tr id="tr2" runat="server">
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/OrderList.aspx" target="mainFrame" style="font-size: 14px">
                                    商城订单</a>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder25" runat="server">
                        <tr id="tr11" runat="server">
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/WebMaster/shangcheng/typelist.aspx" target="mainFrame" style="font-size: 14px">
                                    会员供销商城类别</a>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder46" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/productlist.aspx" target="mainFrame" style="font-size: 14px">
                                    会员供销商城</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder7" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/LianMengLBs.aspx?mt=<%= (int)EyouSoft.Model.Enum.ModelTypes.购物广场联盟 %>"
                                    target="mainFrame" style="font-size: 14px">购物广场联盟类别</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder27" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/LianMengs.aspx?mt=<%= (int)EyouSoft.Model.Enum.ModelTypes.购物广场联盟 %>"
                                    target="mainFrame" style="font-size: 14px">购物广场联盟</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder47" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/LianMengLBs.aspx?mt=<%= (int)EyouSoft.Model.Enum.ModelTypes.休闲娱乐会所 %>"
                                    target="mainFrame" style="font-size: 14px">休闲娱乐会所类别</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder45" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/LianMengs.aspx?mt=<%= (int)EyouSoft.Model.Enum.ModelTypes.休闲娱乐会所 %>"
                                    target="mainFrame" style="font-size: 14px">休闲娱乐会所</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder49" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/LianMengLBs.aspx?mt=<%= (int)EyouSoft.Model.Enum.ModelTypes.天下商旅E家 %>"
                                    target="mainFrame" style="font-size: 14px">天下商旅E家类别</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder48" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="/webmaster/shangcheng/LianMengs.aspx?mt=<%= (int)EyouSoft.Model.Enum.ModelTypes.天下商旅E家 %>"
                                    target="mainFrame" style="font-size: 14px">天下商旅E家</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
    </asp:PlaceHolder>
    <!--代理商身份-->
    <asp:PlaceHolder runat="server" ID="DaiLi" Visible="false">
        <!--商城-->
        <div class="leftmenu" id="div10" runat="server">
            <span class="linkcsstitle" onclick="javascript: setMenuTitle('span_qianzheng_01','img_qianzheng_01');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·<strong style="font-size: 16px">网站设置</strong></font>
                        </td>
                        <td width="22">
                            <img id="img4" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span8">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=s&url=/webmaster/shangcheng/productlist.aspx" target="mainFrame" style="font-size: 14px">
                                商城产品选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=s&url=/webmaster/TuanGou/TuanGouList.aspx" target="mainFrame" style="font-size: 14px">
                                促销秒杀管理</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=s&url=/WebMaster/AdvList.aspx" target="mainFrame" style="font-size: 14px">首页广告设置</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=g&url=/WebMaster/Supplier/SupplierEdit.aspx?type=left" target="mainFrame" style="font-size: 14px">
                                供应信息管理</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=g&url=/webmaster/shangcheng/productlist.aspx" target="mainFrame" style="font-size: 14px">
                                供应商品管理</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=g&url=/webmaster/shangcheng/OrderList.aspx" target="mainFrame" style="font-size: 14px">
                                供应订单管理</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=s&url=/webmaster/ShowHidden.aspx" target="mainFrame" style="font-size: 14px">
                                发展下级代理</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=s&url=/webmaster/NavNum.aspx" target="mainFrame" style="font-size: 14px">
                                网站导航选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img src="/images/webmaster/func_default.gif" />
                            <a href="login.aspx?type=s&url=/webmaster/DaiLiCompany.aspx" target="mainFrame" style="font-size: 14px">
                                我的店铺介绍</a>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
    </asp:PlaceHolder>

    <script type="text/javascript">
        $(document).ready(function() { setMenuTitle('span_qianzheng_01', 'img_jingdian_01'); });
    </script>

    <div style="height: 30px;">
    </div>
</body>
</html>
