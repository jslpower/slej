<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenSiJiaoYi.aspx.cs" Inherits="EyouSoft.Web.Member.FenSiJiaoYi"
    MasterPageFile="~/MasterPage/Front3.Master" Title="粉丝交易-我的粉丝-会员中心" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 粉丝交易</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 粉丝交易</span></div>
        <div class="user_Rbox margin_T10">
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="chzh_t">
                <tr>
                    <th style="width:80px;">
                        订单类型
                    </th>
                    <th>
                        产品名称
                    </th>
                    <th style="width: 80px;">
                        交易时间
                    </th>
                    <th style="width: 80px; text-align:right;">
                        交易金额
                    </th>
                    <th style="width: 80px; text-align:right;">
                        佣金
                    </th>
                    <th style="width: 80px;">
                        操作人
                    </th>
                    <th style="width: 80px;">
                        客人信息
                    </th>
                    <th style="width: 100px;">
                        订单状态
                    </th>
                </tr>                    
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("DingDanLeiXing") %>
                            </td>
                            <td align="left" title="<%#EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()) %>">
                                <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()), 30, true)%>
                            </td>
                            <td align="center">
                                <%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %>
                            </td>
                            <td align="right">
                                <font class="fontred"><%#Eval("DingDanJinE","{0:F2}") %></font>
                            </td>
                            <td align="right">
                                <font class="fontgreen">
                                    <%#Eval("YongJinJinE", "{0:F2}")%></font>
                            </td>
                            <td align="center">
                                <%#Eval("XiaDanRenName") %>
                            </td>
                            <td align="center">
                                <%#Eval("KeRenName") %>
                            </td>
                            <td align="center">
                                <%#GetDingDanStatus(Eval("DingDanStatus"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr>
                        <td colspan="8">
                            暂无粉丝交易信息
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
