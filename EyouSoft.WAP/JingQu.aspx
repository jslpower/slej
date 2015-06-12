<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingQu.aspx.cs" Inherits="EyouSoft.WAP.JingQu.JingQu" %>

<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>景区</title>


    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <script src="/js/jingqu.city.js" type="text/javascript"></script>

    <link href="css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="js/table-toolbar.js" type="text/javascript"></script>

    <script src="js/jipiao.sanzima.js" type="text/javascript"></script>

</head>
<body id="contain">
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <div class="paddL paddR mt10">
            <form>
            <div class="search city_s">
                <div class="search_form clearfix">
                <span class="city_name">浙江</span>
                    <input id="SearchName" name="SearchName" type="text" class="input_txt floatL" value="景区名称"
                        onfocus="javascript:if(this.value=='景区名称')this.value='';" onblur="javascript:if(this.value=='')this.value='景区名称';"
                        forecolor="#999999" />
                    <input type="button" class="icon_search_i floatR" id="SearchBnt" />
                </div>
            </div>
            </form>
        </div>
        <div class="jq_tab mt10" id="n4Tab">
            <input id="pageindex" type="hidden" value="1" />
            <div class="jq_TabTitle">
                <ul class="clearfix">
                    <li class="active" style="width: 100%; border-right: 0;"><a href="javascript:void(0);">
                        热销景点</a></li>
                </ul>
            </div>
            <div class="jq_TabContent">
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
                                            挂牌：¥<strike><%# ((decimal)Eval("TicketFirst.RetailPrice")).ToString("0")%></strike>
                                            起</dd>
                                        <dd class="wid">
                                            零售：¥<strike><%# ((decimal)Eval("TicketFirst.WebsitePrices")).ToString("0")%></strike>
                                            起</dd>
                                        <dd class="wid R">
                                            会员：<span class="font_yellow">¥<i class="font18"><%# EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee((decimal)Eval("TicketFirst.DistributionPrice"), (decimal)Eval("TicketFirst.WebsitePrices"), EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)Eval("TicketFirst.FeeSetting"), EyouSoft.Model.Enum.FeeTypes.门票).ToString("0")%></i></span>起</dd>
                                    </dl>
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
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
            if ($("#SearchName").val() != "") {
                var rawUrl = location.href;
                if (rawUrl.indexOf('?') > -1) {
                    window.location = rawUrl;
                }
                else {
                    var city = document.getElementById('ddlcity')[document.getElementById('ddlcity').selectedIndex].text;
                    window.location = "/JingQuList.aspx?ProvinceId=11&CityId=&SearchName=" + $("#SearchName").val() + "&CityName=浙江";
                }
            }
        });
    })
    
</script>

<script type="text/javascript">
     $(function() {
         pcToobar.init({
             pID: "#ddprovince",
             cID: "#ddlcity",
             pSelect: "<%= pSelect%>",
             cSelect: "<%= cSelect%>",
             comID: '1'
         });
      })
</script>
<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>
</html>
