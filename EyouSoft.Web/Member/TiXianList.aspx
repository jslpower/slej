<%@ Page Title="提现记录明细" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="TiXianList.aspx.cs" Inherits="EyouSoft.Web.Member.TiXianList" %>
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
                &gt; E额宝提现明细</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > E额宝提现明细</span></div>
        <div class="user_Rbox margin_T10">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="chzh_t">
              <%--<tr>
                <td colspan="6" class="noborder"><font class="font14 fontblue">账号提现记录</font></td>
              </tr>--%>
              <tr>
                <th width="90" align="center" >创建时间</th>
                <th width="110" align="center" >交易号</th>
                <th width="50" align="center" >提现金额</th>
                <th width="90" align="center" >开户银行</th>
                <th width="60" align="center" >开户姓名</th>
                <th width="110" align="center" >银行帐号</th>
                <th width="60" align="center" >提现状态</th>
                <th width="60" align="center" >审核状态</th>
                <th align="center" >提现备注</th>
                <th align="center" >审核备注</th>
              </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                <tr>
                <td align="center"><%# Convert.ToDateTime(Eval("TiXianTime")).ToString("yyyy-MM-dd")%></td>
                <td align="center"><%# Eval("TransactionID")%></td>
                <td align="center"><font class="fontred"><%# Eval("JinE","{0:f2}")%></font></td>
                <td align="center"><%# Eval("KaiHuBank")%></td>
                <td align="center"><%# Eval("KaiHuName")%></td>
                <td align="center"><%# Eval("BankNum")%></td>
                <td align="center"><%# Eval("TiXianStatus")%></td>
                <td align="center"><%# Eval("ApplyStatus")%></td>
                <td align="center" title="<%# Eval("BeiZhu")%>"><font class="fontred"><%# Eval("BeiZhu").ToString().Length > 8 ? EyouSoft.Common.Utils.GetText2(Eval("BeiZhu").ToString(), 8, true) : Eval("BeiZhu")%></font></td>
                <td align="center" title="<%# Eval("ShenHeBeiZhu")%>"><font class="fontgreen"><%# Eval("ShenHeBeiZhu").ToString().Length > 8 ? EyouSoft.Common.Utils.GetText2(Eval("ShenHeBeiZhu").ToString(), 8, true) : Eval("ShenHeBeiZhu")%></font></td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
                <tfoot><tr><td colspan="10" align="center"><asp:Literal ID="XianShi" runat="server"></asp:Literal></td></tr></tfoot>
          </table>
            <div class="page" id="page">
                
            </div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
<script type="text/javascript">
        var pagingConfig = { pageSize: <%=pageSize %>, pageIndex:<%=pageIndex %> , recordCount: <%= recordCount%>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
