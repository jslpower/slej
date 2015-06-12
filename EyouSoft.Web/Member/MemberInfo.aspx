<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="MemberInfo.aspx.cs" Inherits="EyouSoft.Web.Member.MemberInfo" %>
<%@ Register src="/UserControl/UserLeft.ascx" tagname="UserLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/Js/menu_min.js"></script>
<script type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Left" runat="server">
    <div class="user_left">
        <h5>
            会员中心</h5>
        <div class="left_menu">
            <ul id="navigation">
                <li><a class="active" href="#">个人资料</a>
                    <ul>
                        <li><a href="/Member/UpdateMember.aspx">修改资料</a></li>
                        <li><a href="/Member/UpdatePassWord.aspx">修改密码</a></li>
                    </ul>
                </li>
                <li><a class="inactive" href="#">我的订单</a>
                <ul style="display: none;">
                    <li><a href="/Member/XianLuOrderList.aspx">线路订单</a></li>
                    <li><a href="/Member/HotelOrderList.aspx">酒店订单</a></li>
                    <li><a href="/Member/ScenicList.aspx">景区订单</a></li>
                    <li><a href="/Member/ZuCheOrderList.aspx">租车订单</a></li>
                    <li><a href="/Member/SCOrderList.aspx">商城订单</a></li>
                </ul>
                </li>
                <li><a class="inactive" href="user_gg.html">会员公告</a> </li>
                <li><a class="inactive" href="/Member/UserTransaction.aspx">账户余额</a></li>
                <li><a class="inactive" href="#">交易记录</a>
                <ul style="display: none;">
                    <li><a href="/Member/TransactionList.aspx">交易记录</a></li>
                    <li><a href="/Member/ChongzhiList.aspx">充值记录</a></li>
                    <li><a href="/Member/TiXianList.aspx">提现记录</a></li>
                    <li><a href="/Member/FanLiList.aspx">返利记录</a></li>
                </ul>
                </li>
            </ul>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Right" runat="server">
    
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Link">

</asp:Content>
