<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.RouteList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>线路管理</title>

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

    <script src="/JS/utilsUri.js" type="text/javascript"></script>

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
                        区域类型:<select class="inputselect" id="AreaType" name="AreaType" onchange="GetXianLuQuYu(this.value);">
                            <%=AreaType %>
                        </select>
                        线路区域：<select class="inputselect" id="AreaID" name="AreaID">
                            <%=RouteArea %>
                        </select>
                        线路名称：
                        <input type="text" name="txtPathName" id="txtPathName" class="inputtext" maxlength="30"
                            size="28" value='<%=Request.QueryString["txtPathName"] %>' />
                        天数：
                        <input type="text" errmsg="必须是数字!" valid="isNumber" name="txtDays" class="inputtext"
                            onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                            size="10" value='<%=Request.QueryString["txtDays"] %>' />
                        出团日期：
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
                    <td width="90" align="center">
                        <a href="javascript:;" class="a_interface_self">自有数据</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="a_interface">博客数据</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="a_interface_zl">中旅旅业数据</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="a_interface_gdwx">光大微信数据</a>
                    </td>
                    <td>
                        <a href="javascript:;" class="a_interface_lyq">旅游圈数据</a>
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
                        线路区域
                    </th>
                    <th align="center">
                        线路名称
                    </th>
                    <th align="center">
                        天数
                    </th>
                    <th align="center">
                        <a id="Tdesc" title="点击进行出团日期排序" href="javascript:;">最近出团</a>
                    </th>
                    <th align="center">
                        <a id="Idesc" title="点击进行发布日期排序" href="javascript:;">发布日期</a>
                    </th>
                    <th align="center">
                        设置线路
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <input type="checkbox" name="checkbox" value='<%#Eval("XianLuId") %>'>
                            </td>
                            <td align="center">
                                <%#GetAreaName(Eval("AreaId"))%>
                            </td>
                            <td align="left">
                                <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%>
                            </td>
                            <td align="center">
                                <%#Eval("TianShu") %>
                            </td>
                            <td align="center">
                                <span style="display: none;">
                                    <%#GetLEdate(Eval("Tours"),true,Eval("XianLuId"))%></span> <a class="paopao" href="javascript:;">
                                        <%#GetTourdate(Eval("LatestTour"))%></a>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.Utils.GetDateTime(Eval("IssueTime").ToString()).ToString("yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.Utils.GetSetRoutString(Eval("XianLuZT"))%>
                                <a data-class="paixu" href="javascript:;" data-id="<%#Eval("XianLuId")%>">排序</a>
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
    <br />
    <br />
</body>

<script type="text/javascript">
    function GetXianLuQuYu(areaType) {
        $.get('/webmaster/RouteList.aspx?t=' + Math.random(), { dotype: 'getareas', areaid: areaType }, function(txt) {
            $('#AreaID').empty();
            $('#AreaID').append(txt);
        });
    }

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
        RouteList.BindBtn();
        $("a[data-class=paixu]").click(function() {
            var orderid = $(this).attr("data-id");
            RouteList.openwindow("/WebMaster/PaiXu.aspx?id=" + orderid + "&type=xianlu&dotype=paixu", "排序修改", 400, 200);
        });

        //------------------------------------------
        $(".asetState").click(function() {
            if (window.confirm("确认操作？")) {
                var data = { state: $(this).attr("data-state"), id: $(this).closest("tr").find("[name=checkbox]").val() };
                var url = "/WebMaster/RouteList.aspx?opt=set&" + $.param(data);
                $.ajax({
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }

        })//

        $("#Tdesc").click(function() {
            var url = document.location.href;
            var tmparray = getUrlSearch();
            if (tmparray != "") {
                var pairs = url.split("&");
                if (pairs.length > 0) {
                    if (getUrlParams("Sdesc", "Ldesc")) {
                        window.location.href = changeURLPar(url, "Sdesc", "Lasc");
                    }
                    else {
                        window.location.href = changeURLPar(url, "Sdesc", "Ldesc");
                    }
                }
            }
            else {
                window.location.href = url + "?Sdesc=Ldesc";
            }
        })


        $("#Idesc").click(function() {
            var url = document.location.href;
            var tmparray = getUrlSearch();
            if (tmparray != "") {
                var pairs = url.split("&");
                if (pairs.length > 0) {
                    if (getUrlParams("Sdesc", "Idesc")) {
                        window.location.href = changeURLPar(url, "Sdesc", "Iasc");
                    }
                    else {
                        window.location.href = changeURLPar(url, "Sdesc", "Idesc");
                    }
                }
            }
            else {
                window.location.href = url + "?Sdesc=Idesc";
            }
        })

        function getUrlSearch() {
            var search = window.location.search;
            var tmparray = search.substr(1, search.length).split("&");
            return tmparray;
        }

        function changeURLPar(destiny, par, par_value) {
            var pattern = par + '=([^&]*)';
            var replaceText = par + '=' + par_value;
            if (destiny.match(pattern)) {
                var tmp = '/\\' + par + '=[^&]*/';
                tmp = destiny.replace(eval(tmp), replaceText);
                return (tmp);
            }
            else {
                if (destiny.match('[\?]')) {
                    return destiny + '&' + replaceText;
                }
                else {
                    return destiny + '?' + replaceText;
                }
            }
            return destiny + '\n' + par + '\n' + par_value;
        }
        function getUrlParams(name, value) {
            var search = window.location.search;
            var ReValue = false;
            var tmparray = search.substr(1, search.length).split("&");
            if (tmparray != null) {
                for (var i = 0; i < tmparray.length; i++) {
                    var reg = /[=|^==]/;    // 用=进行拆分，但不包括==
                    var set1 = tmparray[i].replace(reg, '&');
                    var tmpStr2 = set1.split('&');
                    if (tmpStr2[0] == name) {
                        if (tmpStr2[1] == value) {
                            ReValue = true;
                        }
                    }
                }
            }
            return ReValue;
        }
    });
    var RouteList = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
        },
        //ajax执行文件路径,默认为本页面
        ajaxurl: "/WebMaster/RouteList.aspx",
        //添加
        Add: function() {
            location.href = "/WebMaster/RouteEdit.aspx?dotype=add";
        },
        //修改
        Update: function(objArr) {
            location.href = "/WebMaster/RouteEdit.aspx?dotype=update&id=" + objArr[0].find("input[type='checkbox']").val();
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
                RouteList.ajaxurl = "/WebMaster/Routelist.aspx?dotype=delete&id=" + RouteList.GetCheckBox(objArr);
                //执行/ajax
                RouteList.GoAjax(RouteList.ajaxurl);
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
                RouteList.Add();
                return false;
            });
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行",
                updateCallBack: function(objsArr) {
                    //修改
                    RouteList.Update(objsArr);
                    return false;
                },
                deleteCallBack: function(objsArr) {
                    //删除(批量)
                    RouteList.DelAll(objsArr);
                }
            });
            $(".a_interface_self").click(function() {

                var _p = utilsUri.getUrlParams("source");
                _p["source"] = "<%=(int)EyouSoft.Model.XianLuStructure.LineSource.系统 %>";
                window.location.href = utilsUri.createUri("/WebMaster/Routelist.aspx", _p);
            });
            $(".a_interface").click(function() {
                //                var url = "RouteInterface.aspx";
                //                var title = "线路接口数据";
                //                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 800, width: 800, draggable: false })
                //                return false;
                var _p = utilsUri.getUrlParams("source");
                _p["source"] = "<%=(int)EyouSoft.Model.XianLuStructure.LineSource.博客 %>";
                window.location.href = utilsUri.createUri("/WebMaster/Routelist.aspx", _p);
            });
            $(".a_interface_zl").click(function() {
                //                var url = "zlRouteInterface.aspx";
                //                var title = "线路接口数据";
                //                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 800, width: 800, draggable: false })
                //                return false;
                var _p = utilsUri.getUrlParams("source");
                _p["source"] = "<%=(int)EyouSoft.Model.XianLuStructure.LineSource.省中旅 %>";
                window.location.href = utilsUri.createUri("/WebMaster/Routelist.aspx", _p);
            });
            $(".a_interface_gdwx").click(function() {
                //                var url = "gswxRouteInterface.aspx";
                //                var title = "线路接口数据";
                //                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 800, width: 800, draggable: false })
                //                return false;
                var _p = utilsUri.getUrlParams("source");
                _p["source"] = "<%=(int)EyouSoft.Model.XianLuStructure.LineSource.光大 %>";
                window.location.href = utilsUri.createUri("/WebMaster/Routelist.aspx", _p);
            });
            $(".a_interface_lyq").click(function() {
                //                var url = "gswxRouteInterface.aspx";
                //                var title = "线路接口数据";
                //                Boxy.iframeDialog({ title: title, iframeUrl: url, height: 800, width: 800, draggable: false })
                //                return false;
                var _p = utilsUri.getUrlParams("source");
                _p["source"] = "<%=(int)EyouSoft.Model.XianLuStructure.LineSource.旅游圈 %>";
                window.location.href = utilsUri.createUri("/WebMaster/Routelist.aspx", _p);
            });
        },
        EditDate: function(obj) {
            var _date = { xianluid: $(obj).attr("data-xianluid"), tourid: $(obj).attr("data-tourid") };
            Boxy.iframeDialog({ title: "修改", iframeUrl: '/WebMaster/EditRouteDate.aspx', height: "280px", width: "480px", modal: true, data: _date });
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
        }
    };
</script>

</html>
