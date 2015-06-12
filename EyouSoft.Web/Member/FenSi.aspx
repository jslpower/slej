<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenSi.aspx.cs" Inherits="EyouSoft.Web.Member.FenSi"
    MasterPageFile="~/MasterPage/Front3.Master" Title="粉丝信息-我的粉丝-会员中心" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 粉丝信息</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 粉丝信息</span></div>
        <div class="user_Rbox margin_T10">
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="chzh_t">
                <tr>
                    <th>
                        姓名
                    </th>
                    <th>
                        用户名
                    </th>
                    <th>
                        手机
                    </th>
                    <th>
                        网站名称
                    </th>
                    <th>
                        注册时间
                    </th>
                    <th>
                        到期时间
                    </th>
                    <th>
                        交易记录
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
                <tr data-fensiid="<%#Eval("HuiYuanId") %>" data-fensidailishangid="<%#Eval("HuiYuanDaiLiShangId") %>">
                        <td align="center">
                            <%#Eval("HuiYuanXingMing")%>
                        </td>
                        <td align="center">
                            <%#Eval("HuiYuanYongHuMing")%>
                        </td>
                        <td align="center">
                            <%#Eval("HuiYuanShouJi")%>
                        </td>
                        <td align="center">
                            <%#Eval("HuiYuanWangZhanName") %>
                        </td>
                        <td align="center">
                            <%#Eval("ZhuCeShiJian","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%#Eval("DaoQiShiJian","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <a class="fans_a" href="fensijiaoyi.aspx?fensiid=<%#Eval("HuiYuanId") %>">查看交易</a>                            
                        </td>
                    </tr>
                 </ItemTemplate></asp:Repeater>
                 
                 <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                 <tr>
                    <td colspan="3">暂无粉丝信息</td>
                 </tr>
                 </asp:PlaceHolder>
            </table>
            <div class="page" id="div_fenye">
                
            </div>
        </div>
    </div>
    

    <script src="/js/ajaxpagecontrols.js" type="text/javascript"></script>
    <script src="/Js/menu_min.js" type="text/javascript"></script>       

    <script type="text/javascript">
        var fenYe = { pageSize: 10, pageIndex:1 , recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };

        $(document).ready(function() {
            $(".left_menu ul li").menu();

            if (fenYe.recordCount > 0) AjaxPageControls.replace("div_fenye", fenYe);
        }); 
    </script>
    
    <form id="form1" runat="server"></form>
</asp:Content>
