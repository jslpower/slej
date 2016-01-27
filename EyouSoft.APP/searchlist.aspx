<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchlist.aspx.cs" Inherits="EyouSoft.WAP.searchlist" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

   
    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

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
                var searchword = "";
                var cityid = $("#hidcityid").val();
                if ($("#routeName").val() != "目的地或关键词") { searchword = $("#routeName").val(); }
                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxXianLuList.aspx?pageindex=" + $("#pageindex").val() + "&keyword=" + searchword + "&cityid=" + cityid,
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
    <form id="form1" runat="server">
    <input type="hidden" value="" id="hidcityid" runat="server" />
    <uc1:WapHeader ID="WapHeader1" runat="server" />
    <div class="warp">
        <div class="jq_search" style="top: 42px;">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="text" class="input_txt floatL" value="<%=EyouSoft.Common. Utils.GetQueryStringValue("keyword")==""?"目的地或关键词": EyouSoft.Common. Utils.GetQueryStringValue("keyword")%>"
                        name="routeName" id="routeName" onfocus="javascript:if(this.value=='目的地或关键词')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='目的地或关键词';" />
                    <input name="serchBtn" id="serchBtn" type="button" class="icon_search_i floatR" />
                </div>
            </div>
        </div>
        <div class="jq_list line_list" style="padding-top: 91px;">
            <div id="wrapper">
                <div id="scroller">
                    <div id="a1">
                        <ul id="linelist">
                            <asp:Repeater ID="rptlist" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="jq_img">
                                            <img src="<%# getImgSrc(Eval("TeSeFilePath"))%>">
                                            <div class="line_txt">
                                                <%# getCityName(Eval("DepCityId"))%></div>
                                        </div>
                                        <dl>
                                            <dt><a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                                class="fontblue">
                                                <%# EyouSoft.Common.Utils.ConverToStringByHtml(Eval("RouteName").ToString())%></a></dt>
                                            <dd>
                                                <a href="/Line_Info.aspx?id=<%# Eval("XianLuId") %>&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>"
                                                    class="floatR font_yellow">更多</a>团期：
                                                <%# getLastDate(Eval("Tours"))%></dd>
                                            <dd class="wid font_gray">
                                                门市价：<i class="line_x"><%# getHYJ("门市",EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%></i></dd>
                                            <dd class="wid R">
                                                会员价：<span class="font_yellow">
                                                    <%# getHYJ("会员", EyouSoft.Common.Utils.GetQueryStringValue("type"), Eval("Tours"))%>
                                                </span>
                                            </dd>
                                        </dl>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <div id="pullUp">
                            <span class="pullUpIcon"></span><span class="pullUpLabel"></span>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    
    <input id="pageindex" type="hidden" value="1" />
    </form>

    <script type="text/javascript">

        $(function() {
        $("#wrapper").css("top", "100px");
            $("#serchBtn").click(function() {
            window.location.href = "/searchlist.aspx?keyword=" + $("#routeName").val();
            })
        })
    </script>

</body>
</html>
