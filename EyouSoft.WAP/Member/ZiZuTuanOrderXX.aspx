<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiZuTuanOrderXX.aspx.cs" Inherits="EyouSoft.WAP.Member.ZiZuTuanOrderXX" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>单团报价订单</title>
    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">

     <div class="add_box add_box_no u-list mt10">
            <ul>
               <li>
                  <span class="label_name">线路名称</span>
                  <span class="font_gray"><asp:Literal ID="XianLuName" runat="server"></asp:Literal></span>
               </li>
               
               <li>
                  <span class="label_name">订单号</span>
                  <span class="font_gray"><asp:Literal ID="OrderCode" runat="server"></asp:Literal></span>
               </li>
               
               <li>
                  <span class="label_name">出发城市</span>
                  <span class="font_gray"><asp:Literal ID="Chengshi" runat="server"></asp:Literal></span>
               </li>

               <li>
                  <span class="label_name">出发日期</span>
                  <span class="font_gray"><asp:Literal ID="ChufaTime" runat="server"></asp:Literal></span>
               </li>

               <li>
                  <span class="label_name">成团人数</span>
                  <span class="font_gray"><asp:Literal ID="RenShu" runat="server"></asp:Literal></span>
               </li>

               <li>
                  <span class="label_name">人均车费</span>
                  <span class="font_gray"> <asp:Literal ID="CarMoney" runat="server"></asp:Literal>元</span>
               </li>

               <li>
                  <span class="label_name">导游</span>
                  <span class="font_gray">需要<asp:Literal ID="DaoYouNum" runat="server"></asp:Literal>
                    名全陪导游，人均<asp:Literal ID="DaoYouFei" runat="server"></asp:Literal>元，<asp:Literal ID="DiPeiDaoYouNum" runat="server"></asp:Literal>
                    名地陪导游，人均<asp:Literal ID="DiPeiFei" runat="server"></asp:Literal>元</span>
               </li>

            </ul>
     </div>

       
       
     <div class="mt10 user_T font16">航班</div>

     <div class="user_dindan">
          <ul>
          <asp:Literal ID="HangBan" runat="server"></asp:Literal>
          </ul>
     </div>

     <div class="mt10 user_T font16">餐务标准</div>

     <div class="user_dindan">
          <ul>
             <li>增加早餐<asp:Literal ID="ZaoCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="ZaoCanMoney" runat="server"></asp:Literal>元</li>
             <li>增加午餐<asp:Literal ID="WuCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="WuCanMoney" runat="server"></asp:Literal>元</li>
             <li>增加晚餐<asp:Literal ID="WanCanNum" runat="server"></asp:Literal>餐，每餐人均<asp:Literal ID="WanCanMoney" runat="server"></asp:Literal>元</li>
             <li>总共人均<span class="font_red"><asp:Literal ID="CanWuFei" runat="server"></asp:Literal>元</span></li>
          </ul>
     </div>


     <div class="mt10 user_T font16">保险</div>

     <div class="user_dindan">
          <ul>
             <li style="border:none 0;">
             
                <p><asp:Literal ID="BaoXian" runat="server"></asp:Literal></p>
             </li>
          </ul>
     </div>

 
     <div class="mt10 user_T font16">租车</div>

     <div class="add_box add_box_no u-list">
     <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <ul>
               <li>
                  <span class="label_name">起点</span>
                  <span class="font_gray"><%# Eval("QiDian")%></span>
               </li>
               
               <li>
                  <span class="label_name">终点</span>
                  <span class="font_gray"><%# Eval("ZhongDian")%></span>
               </li>
               
               <li>
                  <span class="label_name">车型</span>
                  <span class="font_gray"><%# GetCheName(Eval("ZucheId"))%></span>
               </li>

               <li>
                  <span class="label_name">数量</span>
                  <span class="font_gray"><%# Eval("CheNum")%>辆</span>
               </li>

               <li>
                  <span class="label_name">公里数</span>
                  <span class="font_gray"><%# Eval("GongLiShu")%>公里</span>
               </li>

               <li>
                  <span class="label_name">价格</span>
                  <span class="font_gray"><%# Eval("FeiYong")%>元</span>
               </li>

            </ul>
                        </ItemTemplate>
                        </asp:Repeater>
            
            
            
            <ul>
                <li><span class="label_name">人均</span> <span class="font_red"><asp:Literal ID="ZuCheFei" runat="server"></asp:Literal>元</span> </li>
            </ul>
        </div>
        <div class="mt10 user_T font16 cent">
            自组团增加总价：<span class="font_red"><asp:Literal ID="ZongMoney" runat="server"></asp:Literal>元</span></div>
        <div class="user_T font16 mt10">
            操作人</div>
        <div class="user_dindan">
            <ul>
                <li style="border: none 0;">
                    <p>
                        <asp:Literal ID="CaoZuoRen" runat="server"></asp:Literal></p>
                </li>
            </ul>
        </div>
        <div class="user_T font16 mt10">
            价格</div>
        <div class="user_dindan">
            <ul>
                <li style="border: none 0;">
                    <p>
                        成人价：<asp:Literal ID="ChengRenJia" runat="server"></asp:Literal>元</p>
                    <p>
                        儿童价：<asp:Literal ID="ETJia" runat="server"></asp:Literal>元</p>
                    <p>
                        总计：<asp:Literal ID="ZongJia" runat="server"></asp:Literal>
                        <%--成人单价<span class="font_red">2673.23</span>元*成人人数<span class="font_red">8</span>人+儿童单价<spanclass="font_red">1109.25</span>元*儿童人数<span class="font_red">0</span>人=<span class="font_red">21386.00</span>元--%>
                        </p>
                        <%if(isAgency==true){ %>
                    <p>分销金额：<asp:Literal ID="AgencyJinE" runat="server"></asp:Literal></p>   
                    <p>分销利润：<asp:Literal ID="AgencyLiRui" runat="server"></asp:Literal></p>     
                    <%} %>             
                </li>
            </ul>
        </div>
        <div class="pay mt10">
            <div class="pay_box">
                <asp:Literal ID="AnNiu" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</body>
<script type="text/javascript">
    var pageData = {
        Pay: function(id, type, token) {
            window.location.href = "/Member/XieYi.aspx?classid=10&pay=1&id=" + id + "&type=" + type + "&token=" + token;
        },
        DeleteOrder: function(oid) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=2&ordertype=9&id=" + oid,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                    }
                })
            }
        },
        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                    url: "/Member/DingDanList.aspx?setState=1&ordertype=9&id=" + oid + "&state=" + state,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("连接服务器出错，请重试");
                    }
                })
            }
        }
    };
</script>
</html>
