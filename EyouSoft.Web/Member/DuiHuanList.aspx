<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="DuiHuanList.aspx.cs" Inherits="EyouSoft.Web.Member.DuiHuanList" %>
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
                &gt; 积分兑换记录</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 积分兑换记录</span></div>
            <div style="margin-top:10px; margin-left:10px;"><p style="font-size:14px; font-weight:bolder; color:red;">您的E额宝余额每天都会按照一定比例进行积分增值， 凭您的积分领取积分卡可以兑换旅游现金券</p></div>
        <div class="user_Rbox margin_T10">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="chzh_t">
                <tbody>
                    <tr>
                        <th width="30" height="30" align="center">
                            序号
                        </th>
                        <th>
                            创建时间
                        </th>
                        <th>
                            兑换额度
                        </th>
                        <th>
                            剩余积分
                        </th>
                        <th>
                            状态
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                    <tr>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="center">
                            <%# Eval("IssueTime")%>
                            </td>
                            <td align="center">
                            <%# Eval("DuiHuanJinE")%>
                            </td>
                            <td align="center">
                            <%# Eval("ShengYuJinE")%>
                            </td>
                            <td align="center">
                            <%# Eval("DuiHuanStatus")%>
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
