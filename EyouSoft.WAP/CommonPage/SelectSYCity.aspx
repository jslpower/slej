<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSYCity.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.SelectSYCity" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
   <title>选择城市</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/jipiao.sanzima.js" type="text/javascript"></script>




</head>
<body>
    <form id="form1" runat="server">
      <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="选择城市" />
   <div class="warp">
        <div class="jq_search" style="background: #fff;">
            <div class="search ">
                <div class="search_form clearfix">
                    <input type="text" placeholder="请输入城市" class="input_txt floatL" value="" id="citySeachBox" />
                    <input name="" id="butSelCity" type="button" class="icon_search_i floatR">
                </div>
            </div>
        </div>
        <div id="slider" class="city_list" style="padding-top: 56px;">
            <div class="slider-content">
                <ul>
                    <li class="city_li">
                        <div class="city_group_title">
                            出发城市</div>
                        <ul id="remen" class="city_group_box">
                        <li class="ckLi"><a href="/../default.aspx?CityId=-1">全国</a></li>
                        <%=strChuFa.ToString()%>
                        </ul>
                    </li>
                 
                </ul>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(function() {
            $("#butSelCity").click(function() {
                var cityname = $("#citySeachBox").val();
                location.href = "SelectSYCity.aspx?CityName=" + cityname;
            });
        });
    </script>
</body>
</html>
