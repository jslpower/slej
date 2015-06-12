<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="EyouSoft.Web.UserControl.UserNav" %>
<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc2" %>
<style>
.nav_on{
	cursor:pointer;
	float:left;
	height:auto;
	margin-top:120px;
	width:24px;
	}
.nav_on a {
    background:url(/Images/navon.png) no-repeat;
    background-position: 0 0;
    float: left;
    height: 76px;
    width: 24px;
}
.nav_min a {
    background-position: 0 -76px;
}
.leftNav_hot {
    background:url(navon.png) no-repeat;
    background-position: 0 -152px;
    display: inline;
    float: left;
    height: 9px;
    margin-left: 5px;
    margin-top: 3px;
    width: 9px;
}

#bbs_bar{position:fixed !important; position:absolute;left:-245px;top:185px;}


#bbs_cat_bar{float:left;overflow:hidden;}

.leftNav{float:left;width:245px; background:#fff;}

.Parenting_snav{float:left;width:245px;}
.Parenting_snav ul{width:245px;float:left;}
.Parenting_snav li{float:left;width:100px;height:25px;line-height:25px;text-align:center;}
.Parenting_snav dt a{font-size:14px;color:#64b434;height:25px;float:left;line-height:25px;font-weight:bold;padding-left:0px;}.Parenting_snav li a{color:#666666;text-align:center;}
.Parenting_snav li a:hover{color:#333333;text-align:center;text-decoration:underline;}
.Parenting_snav dd{float:left;}


</style>

<div id="bbs_bar" style="z-index:9999">

  <div id="bbs_cat_bar">
    <div class="leftNav">
     <uc2:UserLeft runat="server" ID="UserLeft1" />
      
    </div>
  </div>
  
  <div class="nav_on"><a id="bbs_cat_bar_btn"></a></div> 
   
</div>

<script type="text/javascript">
function bbs_bar_max(){
  $('#bbs_bar').stop(true, true).delay(150).animate({left:0},300,"linear",bbs_bar_max_status);
}
function bbs_bar_min(){
  $('#bbs_bar').stop(true, true).delay(150).animate({left:-245},300,"linear",bbs_bar_min_status);
}
function bbs_bar_min_status(){
  $(".nav_on").removeClass("nav_min");
}
function bbs_bar_max_status(){
  $(".nav_on").addClass("nav_min");
}
$(".nav_on,#bbs_cat_bar").bind("mouseenter",bbs_bar_max);
$("#bbs_bar").bind("mouseleave",bbs_bar_min);

</script>