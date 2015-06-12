<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="JiPiao.aspx.cs" Inherits="EyouSoft.Web.JiPiao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="Access-Control-Allow-Origin" content="*">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<form method="post" action="http://jipiao.slej.cn/Login.aspx" onsubmit="return doCheck()">
  <div class="mainbox">
    
      <div class="loginbox">
         <div class="loginbar">
            <h3>用户登录</h3>
            
            <div class="login_side">
                <ul class="login_form">
                     <li><label>用户名：</label><input id="Uname" name="Uname" class="formsize180 input-style" value="请输入手机号" /></li>
                     <li><label>密&nbsp;&nbsp;&nbsp;码：</label><input id="Passwd" name="Passwd" type="password" class="formsize180 input-style" /></li>
                     <li><label>验证码：</label><input id="CheckCode" name="CheckCode" class="formsize100 input-style" /> <img border="0" src="http://jipiao.slej.cn/ValidateCode.aspx" width="70" height="23" /></li>
                     <li style="padding-left:9px;">公众号：988988   密码：988988</li>
                     <li style="padding-left:65px;">
                     <input name="image3" type="submit" class="loginbtn" value="登录" style=" border:0px; cursor:pointer;" />
                     <a id="zhuce" class="login_basicbtn" href="javascript:void(0)"><span>非会员点这里</span></a></li>
                </ul>
                <div class="login_table">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="29%" height="35">申请<span class="font_yellow">贵宾身份</span></td>
                    <td width="4%" rowspan="4" style="border-right:#ddd solid 1px;">&nbsp;</td>
                    <td align="center">申请<span class="font_yellow">代理身份</span>，赚高返点利润</td>
                  </tr>
                  <tr>
                    <td>享受更低折扣</td>
                    <td align="center">拥有独立个人网站和手机微店</td>
                  </tr>
                  <tr>
                    <td height="15" align="center"><img src="images/jt_grayb.gif" width="6" height="5" /></td>
                    <td align="center"><img src="images/jt_grayb.gif" width="6" height="5" /></td>
                  </tr>
                  <tr>
                    <td align="center"><a class="login_basicbtn" href="/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767"><span>立即申请</span></a></td>
                    <td align="center"><a class="login_basicbtn" href="/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652"><span>立即申请</span></a></td>
                  </tr>
                </table>
                
                </div>        
           </div>
            
         </div>
      </div>
      
      
      <div class="login_list mt10">
         <h3><img src="images/login_listT.gif" /></h3>
         
         <div class="login_listbox fixed">
             <ul style="border-right:#c2c2c2 solid 1px;">
                <li><strong>01.系统登录：</strong>机票栏目自成体系，高返点（返3-20%）机票需通过手机号登录后方可预订。</li>
                <li><strong>02.查询预订：</strong>登录后输入起止城市名称和出发日期查询所需航班及返点比例后预订提交。</li>
                <li><strong>03.费用支付：</strong>通过网银或信用卡按返点后的折后折价格在半小时内完成费用支付。</li>
                <li><strong>04.票面价格：</strong>纸质机票（行程单）的票面价为返点前的价格。返点部份即为您的劳务费。</li>
                <li><strong>05.出票进度：</strong>在“我的订单管理”中可查看机票预订和出票进度。</li>
                <li><strong>06.登机办理：</strong>凭身份证（婴童凭户口本）到办票柜台即可办理，无须纸质机票（行程单）。</li>
             </ul>
             
             <ul>
                <li><strong>07.取票方法：</strong>凭身份证到机场自行打印纸质机票，也可在一周内致电0571-85095701取票。</li>
                <li><strong>08.机票验真：</strong>登录<a href="http://www.travelsky.com" target="_blank" class="font_yellow">www.travelsky.com</a>输入姓名或致电<span class="font_yellow">400-815-8888</span>进行机票验真核实。</li>
                <li><strong>09.婴童机票：</strong>在“创建婴童票”中输入同行成人机票编码和婴童姓名完成婴童机票操作。</li>
                <li><strong>10.改签退票：</strong>点击“改签”、“升舱“或“退票”按钮了解相应费用政策后确订相应操作。</li>
                <li><strong>11.航空保险：</strong>可在 “采购管理“中购买航空意外电子保险，一般只需6-10元/人/程。</li>
                <li><strong>12.综合查询：</strong>更多机票问题，请致电<span class="font_yellow">400-6588-180</span>进行咨询。</li>
             </ul>
             
         </div>
         
      </div>
    
  </div>

</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<%--<script type="text/javascript">
    function abc() {
        $.ajax({
            type: "POST",
            url: "http://jipiao.hzjaly.com/Login.aspx",
            data: $("#bnt").closest("form").serialize(), "image3.x": 33, "image3.y": 10
        });
    }
</script>--%>
<script type="text/javascript">
    $(function() {
        $("#zhuce").click(function() {
            window.location.href = '/YuDing.aspx?rurl=' + encodeURIComponent(window.location.href);
        });
        $("#Uname").focus(function() {
        if ($('#Uname').val() == "请输入手机号") { $('#Uname').val(""); }
        });
        $("#Uname").blur(function() {
        if ($('#Uname').val() == "") { $('#Uname').val("请输入手机号"); }
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
