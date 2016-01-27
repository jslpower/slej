<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingQuList.aspx.cs" Inherits="EyouSoft.WAP.JingQuList" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>
        <%=FenXiangBiaoTi %></title>

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <script src="/js/jingqu.city.js" type="text/javascript"></script>

    <link href="css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="js/table-toolbar.js" type="text/javascript"></script>

    <script src="js/jipiao.sanzima.js" type="text/javascript"></script>

    <script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>

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
                var cityid = "<%=cityid %>";
                var provinceid = "<%= proinceid%>";
                var para = { SearchName: $("[name=SearchName]").val(), pageindex: $("#pageindex").val(), CityId: cityid, ProvinceId: provinceid };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxJingQu.aspx?" + $.param(para),
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
        <div class="jq_search city_s">
            <form>
            <div class="search">
                <div class="search_form clearfix">
                    <span class="city_name">
                        <%= EyouSoft.Common.Utils.GetQueryStringValue("CityName")%></span>
                    <input id="SearchName" name="SearchName" type="text" class="input_txt floatL" value="<%=SearchName %>"
                        onfocus="javascript:if(this.value=='景区名称')this.value='';" onblur="javascript:if(this.value=='')this.value='景区名称';"
                        forecolor="#999999" />
                    <input type="button" class="icon_search_i floatR" id="SearchBnt" />
                </div>
            </div>
            </form>
        </div>
        <div class="jq_tab mt10" id="n4Tab">
            <input id="pageindex" type="hidden" value="1" />
            <div class="jq_TabContent">
                <div id="wrapper">
                    <div id="scroller">
                        <div id="a1">
                            <div class="jq_list mt10">
                                <ul class="linelist" id="linelist">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li><a href="/JingQuXX.aspx?ScenicId=<%#Eval("ScenicId")%>&TicketsId=<%#Eval("TicketFirst.TicketsId") %>">
                                                <div class="jq_img">
                                                    <img src="<%# EyouSoft.Common.TuPian.F1(Eval("ImgFirst.Address").ToString(), 320, 240) %>" /></div>
                                                <dl>
                                                    <dt>
                                                        <%# Eval("ScenicName")%></dt>
                                                    <dd class="wid">
                                                        <%# Eval("ScenicLevel")%></dd>
                                                    <dd class="wid R">
                                                        挂牌：¥<strike><%# ((decimal)Eval("TicketFirst.RetailPrice")).ToString("0")%></strike>起</dd>
                                                    <dd class="wid">
                                                        零售：¥<strike><%# ((decimal)Eval("TicketFirst.WebsitePrices")).ToString("0")%></strike>起</dd>
                                                    <dd class="wid R">
                                                        优惠：<span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("TicketFirst.DistributionPrice"), (decimal)Eval("TicketFirst.WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("TicketFirst.FeeSetting"), EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%></i></span>起</dd>
                                                </dl>
                                            </a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                <div id="pullUp" style="text-align: center;">
                                    <span class="pullUpIcon"></span><span class="pullUpLabel">
                                        <asp:Literal ID="XianShi" runat="server"></asp:Literal></span>
                                </div>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="user-mask" style="display: none;">
        <div class="user-mask-i" style="position: fixed; top: 44px; left: 0; margin: 0; width: 100%;
            box-sizing: border-box; height: 140px;">
            <div class="paddL paddR">
                省份：<select id="ddprovince" name="ddprovince" valid="required" errmsg="请选择省份!">
                </select></div>
            <div class="paddL paddT paddR">
                城市：<select id="ddlcity" name="ddlcity" valid="required" errmsg="请选择市区!">
                </select></div>
            <div class="cent mt10">
                <a class="y_btn">确定</a></div>
        </div>
    </div>
</body>

<script type="text/javascript">
    $(function() {
        $(".city_name").click(function() {
            $(".user-mask").toggle();
        });
        $(".y_btn").click(function() {
            var province = document.getElementById('ddprovince')[document.getElementById('ddprovince').selectedIndex].text;
            var city = document.getElementById('ddlcity')[document.getElementById('ddlcity').selectedIndex].text;
            var cityname = province;
            if ($("#ddlcity").val() != "") {
                cityname = city;
            }
            if ($("#SearchName").val() != "" && $("#SearchName").val() != "景区名称") {
                window.location = "/JingQuList.aspx?ProvinceId=" + $("#ddprovince").val() + "&CityId=" + $("#ddlcity").val() + "&SearchName=" + $("#SearchName").val() + "&CityName=" + cityname;
            }
            else {
                window.location = "/JingQuList.aspx?ProvinceId=" + $("#ddprovince").val() + "&CityId=" + $("#ddlcity").val() + "&SearchName=&CityName=" + cityname;
            }
        })
        var SearchName = '<%=Request.QueryString["SearchName"] %>';
        if (SearchName != "" && SearchName != null) { $("#SearchName").val(SearchName); }
        $("#SearchBnt").click(function() {
            var province = document.getElementById('ddprovince')[document.getElementById('ddprovince').selectedIndex].text;
            var city = document.getElementById('ddlcity')[document.getElementById('ddlcity').selectedIndex].text;
            var cityname = province;
            if ($("#ddlcity").val() != "") {
                cityname = city;
            }
            if ($("#SearchName").val() != "" && $("#SearchName").val() != "景区名称") {
                window.location = "/JingQuList.aspx?ProvinceId=" + $("#ddprovince").val() + "&CityId=" + $("#ddlcity").val() + "&SearchName=" + $("#SearchName").val() + "&CityName=" + cityname;
            }
            else {
                window.location = "/JingQuList.aspx?ProvinceId=" + $("#ddprovince").val() + "&CityId=" + $("#ddlcity").val() + "&SearchName=&CityName=" + cityname;
            }
        });
        $("#wrapper").css("top", "100px");
    })
    
</script>

<script type="text/javascript">
    $(function() {
        pcToobar.init({
            pID: "#ddprovince",
            cID: "#ddlcity",
            pSelect: "<%= proinceid%>",
            cSelect: "<%= cityid%>",
            comID: '1'
        });
    })
</script>

<script type="text/javascript">

    var myScroll;

    function loaded() {

        myScroll = new iScroll('wapper', { checkDOMChanges: true });
    }

    document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
    document.addEventListener('DOMContentLoaded', loaded, false);

</script>



</html>
