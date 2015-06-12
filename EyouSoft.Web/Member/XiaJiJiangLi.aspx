<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaJiJiangLi.aspx.cs" Inherits="EyouSoft.Web.Member.XiaJiJiangLi"
    MasterPageFile="~/MasterPage/Front3.Master" Title="下级分销奖励-我的粉丝-会员中心" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 下级分销奖励</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> &gt; 下级分销奖励</span></div>
        <div class="user_Rbox margin_T10" style="padding-top:10px;">
            <div class="R_title" style=" margin-bottom:10px; border-bottom:0px;">
                <asp:Literal runat="server" ID="ltrJinEXinXi"></asp:Literal>
            </div>
            <div class="u-btn" style="margin-bottom:20px; padding-top:10px;">
          
            <a class="u-01" href="fensi.aspx">粉丝信息 &gt;&gt;</a>
            &nbsp;&nbsp;
            
                <a class="u-01" href="fensijiaoyi.aspx">粉丝交易 &gt;&gt;</a>
                 &nbsp;&nbsp;<a class="u-01" href="xiajijianglijiesuan.aspx">奖金结算 &gt;&gt;</a>
            </div>
        
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="chzh_t">
                <tr>
                    <th>
                        序号
                    </th>
                    <th>
                        结算时间
                    </th>
                    <th>
                        结算佣金
                    </th>
                    <th>
                        结算比例
                    </th>
                    <th>
                        结算金额
                    </th>
                    <th>
                        结算状态
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%# Container.ItemIndex + 1+( this.PageIndex - 1) * this.PageSize%>
                            </td>
                            <td align="center">
                                <%#Eval("ShiJian","{0:yyyy-MM-dd}") %>
                            </td>
                            <td align="center">
                                <%#Eval("YongJinJinE","{0:F2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("BiLiBaiFenBi")%>
                            </td>
                            <td align="center">
                                <%#Eval("JinE", "{0:F2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("Status") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr>
                        <td colspan="3">
                            暂无下级分销奖励结算信息
                        </td>
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

            if (fenYe.recordCount > 0) AjaxPageControls.replace("div_fenye", fenYe); ;
        }); 
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
