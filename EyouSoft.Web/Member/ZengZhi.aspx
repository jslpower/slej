<%@ Page Title="E额宝增值管理" Language="C#" MasterPageFile="~/MasterPage/Front3.Master"
    AutoEventWireup="true" CodeBehind="ZengZhi.aspx.cs" Inherits="EyouSoft.Web.Member.ZengZhi" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/ajaxpagecontrols.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

    <script src="/Js/menu_min.js"></script>

    <script type="text/javascript">

    </script>

    <script language="javascript" type="text/javascript">
        pagingConfig = { pageSize: 10, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };

        $(document).ready(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
            $(".left_menu ul li").menu();
        }); 
    </script>

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
                &gt; E额宝增值管理</h4>
            <span>您的位置：首页 &gt; 会员中心 &gt; E额宝增值管理</span></div>
            <div style="margin-top:10px; margin-left:10px;"><p style="font-size:14px; font-weight:bolder; color:red;">您的E额宝余额每天都会按照一定比例进行积分增值， 凭您的积分领取积分卡可以兑换旅游现金券</p></div>
        <div class="user_Rbox margin_T10">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="chzh_t">
                <tbody>
                    <tr>
                        <th align="center">
                            编号
                        </th>
                        <th align="center">
                            积分日期
                        </th>
                        <th align="center">
                            E额宝余额
                        </th>
                        <th align="center">
                            日积分率
                        </th>
                        <th align="center">
                            日积分数
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                                <td align="center">
                                    <%#Container.ItemIndex+1 %>
                                </td>
                                <td align="center">
                                    <%#Eval("DealDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Account") %>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDecimal(Eval("IntersetRate"))/10000M%>
                                </td>
                                <td align="center">
                                    <%#Eval("DayInCome") %>
                                </td>
                                <td align="center">
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="even">
                        <td align="right" colspan="4">
                            累计积分：
                        </td>
                        <td align="center">
                            <%=getSumJF()%>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="7" align="center">
                            <asp:Literal ID="XianShi" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tfoot>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom:20px;">
              <tr>
                <td colspan="2" align="center"><strong class="fontred">已兑换积分：<asp:Literal ID="YiDuiJiFen" runat="server"></asp:Literal></strong></td>
                <td colspan="2" align="center"><strong class="fontred">被冻结积分：<asp:Literal ID="DongJiJiFen" runat="server"></asp:Literal></strong></td>
                <td align="center"><strong class="fontgreen">可用积分：<asp:Literal ID="KeYongJiFen" runat="server"></asp:Literal></strong> </td>
                <td colspan="2" align="center"><a href="JiFenDuiHuan.aspx" class="u-02">积分兑换</a></td>
              </tr>
             </table>
            <div class="page" id="page">
            </div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
