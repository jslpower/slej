<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenSi.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MemberCenter.FenSi"
    MasterPageFile="~/WebMaster/default.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist" style="margin:0px auto;margin-top:10px;">
        <div style="width: 100%; height: 30px; text-align: left; font-size: 24px;">会员[<%=HuiYuanXinXi%>]的粉丝信息</div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tr>
                <th align="center" style="width:50px; height:30px;">
                    序号
                </th>
                <th align="center">
                    姓名
                </th>
                <th align="center">
                    用户名
                </th>
                <th align="center">
                    手机
                </th>
                <th align="center">
                    网站名称
                </th>
                <th align="center">
                    注册时间
                </th>
                <th align="center">
                    到期时间
                </th>
                <th align="center">
                    交易记录
                </th>
            </tr>
            
            <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
            <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                <td align="center" style="height:30px;">
                    <%# Container.ItemIndex + 1+( this.PageIndex - 1) * this.PageSize%>
                </td>
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
                    <a href="fensijiaoyi.aspx?huiyuanid=<%#HuiYuanId %>&fensiid=<%#Eval("HuiYuanId") %>">查看交易</a>
                </td>
            </tr>
            </ItemTemplate></asp:Repeater>
            
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
            <tr class="even">
                <td colspan="3">
                    暂无粉丝信息
                </td>
            </tr>
            </asp:PlaceHolder>
        </table>
        
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                </td>
            </tr>
        </table>
        
        <table cellspacing="0" cellpadding="0" width="320" border="0" align="center">
            <tr>
                <td height="40" align="center" class="tjbtn02" style="padding-left: 25%;">
                    <a href="javascript:history.go(-1);">返回</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
