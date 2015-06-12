<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDanList.aspx.cs" Inherits="EyouSoft.WAP.Member.DingDanList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>订单列表</title>
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;

        function pullDownAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                for (i = 0; i < 12; i++) {
                    $(el).append("<li>Generated row " + (++generatedCount) + "</li>")
                }

                myScroll.refresh();
            }, 1000);
        }

        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                var para = { OrderType: <%= orderleibie %>, pageindex: $("#pageindex").val() };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxDingDan.aspx?" + $.param(para),
                    cache: false,
                    success: function(result) {
                        if (result != "" && result.length > 2) {
                            $(el).append(result);
                        }
                        else {
                            pullUpEl.querySelector('.pullUpLabel').innerHTML = '已加载至最后';
                        }
                    }
                });
                myScroll.refresh();
            }, 1000);
        }

        function loaded() {

            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight

            myScroll = new iScroll('wrapper', {
                mouseWheel: true,
                click: true,
                checkDOMChanges: true,
                onRefresh: function() {
                    if (pullUpEl.className.match('loading')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                    }
                },
                onScrollMove: function() {
                    if (this.y < (this.maxScrollY - 5) && !pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'flip';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '放开刷新..';
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.className.match('flip')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                        this.maxScrollY = pullUpOffset;
                    }
                },
                onScrollEnd: function() {
                    if (pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'loading';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '正在加载...';
                        pullUpAction();
                    }
                }
            });
        }

        document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
        document.addEventListener('DOMContentLoaded', loaded, false);

        function change(i) {
            if (i == 1) {
                $("#a1").show();
                $("#a2").hide();

            }
            else {
                $("#a2").show();
                $("#a1").hide();
            }

            myScroll.scrollToPage(0, 0, 100);


        }


    </script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div id="wrapper">
            <div id="scroller">
                <div id="a1">
                    <em id="linelist">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="user_dindan font16 mt10">
                                    <ul>
                                        <li class="producturl" data-id="<%#Eval("ProductID") %>">
                                            <%# Eval("OrderName")%></li>
                                        <li class="orderurl" data-orderid="<%# Eval("OrderId")%>">订单号：<%# Eval("OrderCode")%></li>
                                        <li>下单日期：<%# Eval("IssueTime")%></li>
                                        <%if(orderleibie==8){ %><li>租车时间：<%# Eval("ChuFaShiJian")%>
                                        <%}else if(orderleibie==4){%><li>游玩时间：<%# Eval("ChuFaShiJian")%>
                                        <%}else if(orderleibie==5){%><li>入住时间：<%# Eval("ChuFaShiJian")%>
                                        <%}else if(orderleibie==9){%><li>出发时间：<%# Eval("ChuFaShiJian")%>
                                        <%}%></li>
                                        <li>订单金额：¥ <i class="font22 font_yellow">
                                            <%#((decimal)Eval("JinE")).ToString("f2")%></i></li>
                                        <li>订单状态：<%# getHuiYuanState(Eval("OrderStatus"))%></li>
                                        <li>操作：
                                            <%# getZhiFuURL(Eval("OrderId").ToString(), Eval("OrderStatus"), Eval("AgencyId"), orderleibie, Eval("XDRId"))%> <a href='/Default.aspx'><span class="bg_yellow">继续采购</span></a>
                                        </li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </em>
                </div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <div id="pullUp" style="text-align:center">
                        <span class="pullUpIcon"></span><span class="pullUpLabel"><asp:Literal ID="XianShi" runat="server"></asp:Literal></span>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
        
    </div>
    <input id="pageindex" type="hidden" value="1" />
</body>

<script type="text/javascript">
    $(".orderurl").click(function() {
        var ordertype = "<%= orderleibie%>";
        var orderid = $(this).attr("data-orderid");
        if (ordertype == "8") {
            window.location.href = "/Member/ZuCheOrderXX.aspx?orderid=" + orderid;
        }
        else if (ordertype == "3") {
            window.location.href = "/Member/ScOrderXX.aspx?orderid=" + orderid;
        }
        else if (ordertype == "4") {
            window.location.href = "/Member/MenPiaoOrderXX.aspx?orderid=" + orderid;
        }
        else if (ordertype == "5") {
            window.location.href = "/Member/HotelOrderXX.aspx?orderid=" + orderid;
        }
        else if (ordertype == "7") {
            window.location.href = "/Member/TuanGouOrderXX.aspx?orderid=" + orderid;
        }
        else if (ordertype == "9") {
            window.location.href = "/Member/ZiZuTuanOrderXX.aspx?orderid=" + orderid;
        }
    });
    $(".producturl").click(function() {
        var ordertype = "<%= orderleibie%>";
        var Pid = $(this).attr("data-id");
        if (ordertype == "8") {
            window.location.href = "/Car.aspx?id=" + Pid;
        }
        else if (ordertype == "3") {
        window.location.href = "/Mall/MoDetail.aspx?ID=" + Pid;
        }
        else if (ordertype == "4") {
        window.location.href = "/JingQuXX.aspx?ScenicId=" + Pid;
        }
        else if (ordertype == "5") {
        window.location.href = "/HotelXX.aspx?HotelId=" + Pid;
        }
        else if (ordertype == "7") {
        window.location.href = "/TuanGouXX.aspx?id=" + Pid;
        }
        else if (ordertype == "9") {
        window.location.href = "/ZiZuTuan.aspx?id=" + Pid;
        }
    });
    var pageData = {
        Pay: function(id, type, token) {
            var classid;
            //        if (type == '3') { classid = 9 }
            //        if (type == '1') { classid = 1 }
            //        if (type == '2') { classid = 8 }
            if (type == '5') { classid = 2 }
            if (type == '4') { classid = 3 }
            if (type == '8') { classid = 4 }
            if (type == '3') { classid = 5 }
            if (type == '7') { classid = 6 }
            if (type == '9') { classid =10 }
            window.location.href = "/Member/XieYi.aspx?pay=1&id=" + id + "&type=" + type + "&token=" + token + "&classid=" + classid;
        },
        DeleteOrder: function(oid) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=2&ordertype=<%= orderleibie%>&id=" + oid,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                        else {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                        window.location.href = window.location.href;
                    }
                })
            }
        },
        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=1&ordertype=<%= orderleibie%>&id=" + oid + "&state=" + state,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                        else {
                            alert(ret.msg);
                            window.location.href = window.location.href;
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                        window.location.href = window.location.href;
                    }
                })
            }
        }
    };
    $(function() {
        $("#wrapper").css("top", "40px");
    });
</script>

</html>
