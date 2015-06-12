<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="EyouSoft.Web.UserControl.Menu" %>
<%@ Register Src="/UserControl/MainNav.ascx" TagName="MainNav" TagPrefix="uc1" %>
<%@ Register Src="/UserControl/DaiLiNav.ascx" TagName="DaiLiNav" TagPrefix="uc1" %>
<div class="head mt10 fixed">
<%if (isfenxiao == 0)
  { %>
  <div class="logo">
  <img src="/images/logo.jpg">
  </div>
    <div class="head_R">
    <div class="h_searchbox">
            <h3>
                旅游有道，请找金奥！杭州金奥国际旅行社欢迎您！</h3>
      <%}
  else
  { %>
   <%if (companyName != "")
     { %>
  <div class="logo_fxs"><%=website%></div>
       <div class="head_R">
                  <div class="head_Rtxt">
                  <%= companyName%>
                  </div>
                  <div class="h_searchbox">
                  <%} else{%>
                  <div class="logo_fxs"><%=website%></div>
       <div class="head_R">
                  <div class="h_searchbox">
                  <h3>
                旅游有道，请找金奥！杭州金奥国际旅行社欢迎您！</h3>
                  <%} %>
<%} %>

            <form id="searh" action="/searchlist.aspx">
            <div class="h_searchbar">
                <input id="keyword" name="keyword" type="text" class="search_input" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("keyword") %>" />
                <input type="submit" value="搜索" class="search_btn">
            </div>
            </form>
            <h3>
                <% foreach (string link in menPiaoLinks)
                   {%><a href="/searchlist.aspx?keyword=<%=Server.UrlEncode(link) %>"><%=link %></a>
                <% } %></h3>
        </div>
        <% if (isfenxiao == 0)
           { %>
        <div class="tel2">
            <img width="204" height="65" src="<%=tel %>"></div>
        <%}
           else
           { %>
           <%if (companyName != "")
             { %>
        <div class="tel">
        <%}
             else
             { %><div class="tel" style="padding-top:20px;"><%} %>
            <ul id="headbox">
                <li>
                    <%if (!string.IsNullOrEmpty(img1))
                      { %><a href="javascript:void(0);" class="headimg">
                          <img src="<%= img1%>" width="13" height="13" />
                          <div class="headimg_b">
                              <img src="<%= img1%>" width="52" height="52" />
                          </div>
                      </a>
                    <%} %>
                    <em>外联：</em><span style="width: 36px;display:inline-block; text-align:left;"><asp:Literal ID="UName" runat="server"></asp:Literal></span>
                    <%if (!string.IsNullOrEmpty(utel))
                      { %>
                    <%= utel%><%} %>
                    &nbsp;
                    <asp:Literal ID="UMoblie" runat="server"></asp:Literal>
                    &nbsp;<%if (!string.IsNullOrEmpty(uweixin))
                            { %><em>微信：</em><span style="text-align:left"><asp:Label ID="Label2" runat="server" Text="Label" Width="80px"></asp:Label></span><%} %>
                    <% if (!string.IsNullOrEmpty(uqq))
                       {%><em style="display: inline"><a target="_blank" rel="nofollow" href="http://wpa.qq.com/msgrd?v=3&uin=<%= uqq%>&site=qq&menu=yes"><img
                           border="0" src="http://wpa.qq.com/pa?p=2:<%= uqq%>:51" title="点击这里给我发消息"></a></em><%} %>
                </li>
                <%if (slname != "")
                  { %>
                <li>
                    <%if (!string.IsNullOrEmpty(img2))
                      { %><a href="javascript:void(0);" class="headimg">
                          <img src="<%= img2%>" width="13" height="13" />
                          <div class="headimg_b">
                              <img src="<%= img2%>" width="52" height="52" />
                          </div>
                      </a>
                    <%} %>
                    <em>客服：</em><span style="width: 36px;display:inline-block; text-align:left;"><%= slname%></span>
                    <asp:Literal ID="SLTel" runat="server"></asp:Literal>
                    &nbsp;
                    <asp:Literal ID="SLMoblie" runat="server"></asp:Literal>
                    &nbsp;<%if (!string.IsNullOrEmpty(slweixin))
                            { %><em>微信：</em><span style="text-align:left"><asp:Label ID="Label1" runat="server" Text="Label" Width="80px"></asp:Label></span><%} %>
                    <% if (!string.IsNullOrEmpty(slqq))
                       {%><em style="display: inline"><a target="_blank" rel="nofollow" href="http://wpa.qq.com/msgrd?v=3&uin=<%= slqq%>&site=qq&menu=yes"><img
                           border="0" src="http://wpa.qq.com/pa?p=2:<%= slqq%>:51" title="点击这里给我发消息"></a></em><%} %>
                </li>
                <%} %>
            </ul>
        </div>
        <%--<div class="tel">
                  
                    <ul id="headbox">
                        <li><a href="javascript:void(0);" class="headimg">
                            <img src="images/head01.gif" width="13" height="13"/>
                            <div class="headimg_b">
                                <img src="images/head01-0.gif" width="52" height="52" />
                            </div>
                        	</a>
                            <em>网点名称：</em><asp:Literal ID="UWebName" runat="server"></asp:Literal>
                        </li>
                        <li><a href="javascript:void(0);" class="headimg">
                            <img src="images/head02.gif" width="13" height="13"/>
                            <div class="headimg_b">
                                <img src="images/head02-0.gif" width="52" height="52" />
                            </div>
                        	</a>
                        	<em>业务联系：</em>
                            
                        </li>
                    </ul>
                  
                  </div>--%>
        <%} %>
    </div>
</div>

<asp:PlaceHolder ID="MainNav" runat="server">
<uc1:MainNav runat="server" ID="MainNav1" />
</asp:PlaceHolder>
<asp:PlaceHolder ID="DaiLiNav" runat="server" Visible="false"><uc1:DaiLiNav runat="server" ID="DaiLiNav1" />
</asp:PlaceHolder>
<script type="text/javascript">

    $(function() {
        $("#headbox").find("a").mouseover(function() {
            $(this).find("div").show();
        });
        $("#headbox").find("div").mouseout(function() {
            $(this).hide();
        });
        $("#div_HeadMenu").find("a").each(function() {

            if ($(this).attr("data-index") == "<%=HeadMenuIndex %>") {
                if ($(this).attr("data-index") == "9") {
                    $(this).parent().attr("class", "gnyicon menu_current");
                } else {
                    $(this).parent().attr("class", "menu_current");
                }
            }
        });
        $("#DaiLiHeadNav").find("a").each(function() {
            var datanum = "<%=HeadMenuIndex %>";
            if (datanum == "2" || datanum == "3" || datanum == "12" || datanum == "6") {
                datanum = 4;
            }
            else if (datanum == "5" || datanum == "7" || datanum == "4" || datanum == "8") {
                datanum = 5;
            }
            if ($(this).attr("data-index") == datanum) {
                $(this).parent().attr("class", "menu_current");
                if ($(this).attr("data-index") == 4) {
                    $(this).parent().attr("class", "menu_current menu_icon");
                }
                if ($(this).attr("data-index") == 5) {
                    $(this).parent().attr("class", "menu_current menu_icon");
                }
            }
        });
    })

</script>

