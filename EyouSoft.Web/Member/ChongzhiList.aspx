<%@ Page Title="充值记录明细" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="ChongzhiList.aspx.cs" Inherits="EyouSoft.Web.Member.ChongzhiList" %>
<%@ Register src="/UserControl/UserLeft.ascx" tagname="UserLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>
<script src="/Js/menu_min.js"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
<uc1:UserLeft runat="server" ID="UserLeft1" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <form id="form1" runat="server">
<div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; E额宝充值明细</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > E额宝充值明细</span></div>
        <div class="user_Rbox margin_T10">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="chzh_t">
                <tbody>
                    <tr>
                        <th>
                            创建时间
                        </th>
                        <th>
                            交易号
                        </th>
                        <th>
                            支付方式
                        </th>
                        <th>
                            金额
                        </th>
                        <th>
                            状态
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("Issuetime","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# Eval("JiaoYiHao")%>
                        </td>
                        <td align="center">
                            <%# Eval("ZhiFuFangShi")%>
                        </td>
                        <td align="center">
                            <font class="fontred"><%# Eval("JinE","{0:F2}")%></font>
                        </td>
                        <td align="center">
                            <font class="fontgreen"><%# Eval("ZhiFuStatus")%></font>
                        </td>
                    </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot><tr><td colspan="5"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr></tfoot>
            </table>
            <div class="page" id="page">
                
            </div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
<script type="text/javascript">
        var pagingConfig = { pageSize: 20, pageIndex:<%=PageIndex %> , recordCount: <%=RecordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
