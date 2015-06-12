<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomPriceAll.aspx.cs" Inherits="EyouSoft.Web.WebMaster.HotelManage.RoomPriceAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/slogin.js"></script>

    <link href="/css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/Loading.js" type="text/javascript"></script>

    <script src="/JS/Rili.js" type="text/javascript"></script>

    <style type="text/css">
        body
        {
            font-family: "宋体" ,Verdana, Geneva, sans-serif;
            font-size: 12px;
        }
        .sizdate
        {
            font-size: 12px;
        }
        table
        {
            border-collapse: collapse;
        }
        a
        {
            text-decoration: none;
            cursor: pointer;
            color: #474747;
        }
        a:hover
        {
            color: #f60;
        }
        a:focus
        {
            text-decoration: none;
        }
        .fontgreen
        {
            color: #03a62d;
        }
        .fontred
        {
            color: #ff2a00;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; width: 100%;">
        注:绿色为挂牌价，红色为网络价</div>
    <div class="biaoge" id="divAllTourList">
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
        <%=strScript %>
</script>

<script type="text/javascript">
    $(function() {
        iPage.BinRiLi();
        iPage.SetDateInfo();
    })
    var iPage = {
        MaxMonth: <%=AddMonth %>,
        BinRiLi: function() {
            LoadingImg.ShowLoading("divAllTourList");

            QGD.initCalendar({
                containerId: "divAllTourList", //放日历容器ID
                currentDate: new Date(Date.parse('<%=string.Format("{0:yyyy\\/MM\\/dd}",startMonth) %>')), //当前月
                firstMonthDate: new Date(Date.parse('<%=string.Format("{0:yyyy\\/MM\\/dd}",startMonth) %>')), //当前月
                nextMonthDate: new Date(Date.parse('<%=string.Format("{0:yyyy\\/MM\\/dd}",startMonth.AddMonths(1)) %>')), //下一个月
                maxMonth: iPage.MaxMonth//配置日历追加几个月份(显示月份数量=maxMonth+1)
            });
        },
        SetDateInfo: function() {
            var pricelist = PriceList;
            for (var i = 0; i < pricelist.length; i++) {
                var objdiv = $("#" + pricelist[i].StartDate);
                objdiv.append("<br /><span class='fontgreen' title='' >" + pricelist[i].AmountPrice + "</span><br /><span class='fontred'>" + pricelist[i].SettlementPrice + "</span>");

            }
        }
    }
</script>

