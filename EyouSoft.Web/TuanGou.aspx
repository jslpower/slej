<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="TuanGou.aspx.cs" Inherits="EyouSoft.Web.TuanGou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<form runat="server">
<%--<div class="mainbox fixed">
    
       <div class="leftbox">
       
         <!------分类-------->
         <div class="tg_type">
            <h2>全部团购分类</h2>
            <ul>
              <li><a href="#"><s class="line_icon"></s>线路产品</a></li>
              <li class="bg"><a href="#" class="curr"><s class="jinqu_icon"></s>景区门票</a></li>
              <li><a href="#"><s class="hotel_icon"></s>酒店预订</a></li>
              <li class="bg"><a href="#"><s class="car_icon"></s>汽车包租</a></li>
              <li><a href="#"><s class="mall_icon"></s>商城产品</a></li>
           </ul>
         </div>
          
      </div>
    
       
      <div class="rightbox">

          <!------n_banner-------->
          <div class="banner n_banner" id="newsSlider">
    
            <div class="piclist">
                 <ul class="slides"> 
                   <li><a href="#" target="_blank"><img src="images/tg_banner.jpg" /></a></li>
                   <li><a href="#" target="_blank"><img src="images/tg_banner.jpg" /></a></li>
                   <li><a href="#" target="_blank"><img src="images/tg_banner.jpg" /></a></li>
                   <li><a href="#" target="_blank"><img src="images/tg_banner.jpg" /></a></li>
                   <li><a href="#" target="_blank"><img src="images/tg_banner.jpg" /></a></li>
                 </ul>
                      
                 <div class=validate_Slider></div>
                 <ul class=pagination>
                   <li><a href="#">1</a></li>
                   <li><a href="#">2</a></li>
                   <li><a href="#">3</a></li>
                   <li><a href="#">4</a></li>
                   <li><a href="#">5</a></li>
                 </ul>
           </div>
         </div>
         


        <!------mall-search-------->
      </div>
       
       
       
       
    </div>--%>
    
    <div class="tg_paixu fixed">
        <div class="floatL paixu-list"><span>默认排序：</span><a id="rexiao" href="/TuanGou.aspx?classid=1&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>" class="on">销量</a><a id="zuixin" href="/TuanGou.aspx?classid=2&type=<%=EyouSoft.Common.Utils.GetQueryStringValue("type") %>">最新</a></div>
        <div class="tg_searchbar">
           <input type="text" class="search_input" runat="server" value="" id="CpName" name="CpName"/> 
            <asp:Button ID="Button1" runat="server" CssClass="search_btn" 
                onclick="Button1_Click" /><%--<input type="submit" class="search_btn" value="" />--%>
        </div>
    </div>
  
    <div class="tg_piclist">
           <ul>
               <asp:Repeater ID="rptList" runat="server">
               <ItemTemplate>
               <li>
                    <a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>"><img src="<%# Eval("ProductImg")%>" /></a>
                    <div class="cont">
                        <div class="tg_listT"><a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>"><%# Eval("ProductName")%></a></div>
                        <div class="tg_price">
                           <span class="tg_num"><strong class="fontblue"><%# Eval("Salevolume")%></strong>人已购买</span>
                           <span class="rain-price"><s>¥ <%# Convert.ToInt32(Eval("MarketPrice"))%></s> <em><i>¥</i><%# Convert.ToInt32(Eval("GroupPrice"))%></em> </span>
                        </div>
                    </div>
                </li>
               </ItemTemplate>
               </asp:Repeater>
                <asp:Literal ID="litNoMsg" runat="server"></asp:Literal>
           </ul>
           <div class="clear"></div>
    </div>
 </form>
    <div class="page" id="page"></div>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<script type="text/javascript">
var classid = <%=EyouSoft.Common.Utils.GetQueryStringValue("classid") %>;
if(classid !=1)
{
$('#rexiao').removeClass();
$('#zuixin').addClass("on"); 
} 
        var pagingConfig = { pageSize: <%= PageSize %>, pageIndex:<%= PageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
