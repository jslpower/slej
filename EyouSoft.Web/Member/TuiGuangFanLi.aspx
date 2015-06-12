<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuiGuangFanLi.aspx.cs"
    Inherits="EyouSoft.Web.Member.TuiGuangFanLi" MasterPageFile="~/MasterPage/Front3.Master"
    Title="推广返利-返联盟推广-会员中心" %>


<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 返利记录</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> &gt; 返利记录</span></div>
        <div class="user_Rbox margin_T10">
            <div class="R_title">
                所有返利记录</div>
            <div class="user-s margin_T10">
                <form id="form_chaxun" method="get">
                <b>交易时间：</b>
                <input type="text" style="width: 80px;" class="inputbk" name="txtXiaDanShiJian1" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaDanShiJian1") %>"
                    onfocus="WdatePicker()" /> - 
                
                <input type="text" style="width: 80px;" class="inputbk" name="txtXiaDanShiJian2" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaDanShiJian2") %>"
                        onfocus="WdatePicker()" />
                <b>返利状态：</b>
                <select name="txtStatus" id="txtStatus">
                    <option value="">全部</option>
                    <option value="0">未返</option>
                    <option value="1">已返</option>
                </select>
                <input type="submit" class="line-s-btn s_btn" value="搜索" name="btnChaXun">
                </form>
            </div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="chzh_t margin_T10">                
                <tr>
                    <th style="width: 90px;">
                        交易时间
                    </th>
                    <th style="width: 90px;text-align: left;">
                        交易人
                    </th>
                    <th style="text-align: left;">
                        产品名称
                    </th>
                    <th style="text-align: right;width: 90px;">
                        交易金额
                    </th>
                    <th style="text-align: right;width: 90px;">
                        返利比例
                    </th>
                    <th style="text-align: right;width: 90px;">
                        返利金额
                    </th>
                    <th style="width: 90px;">
                        返利状态
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %>
                            </td>
                            <td style="text-align: left;">
                                <%#Eval("XiaDanRenName") %>
                            </td>
                            <td align="center" style="text-align: left;">
                                <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()), 15, true)%>
                            </td>
                            <td style="text-align: right;">
                                <font class="fontred">
                                    <%#Eval("DingDanJinE","{0:F2}") %></font>
                            </td>
                            <td style="text-align: right;">
                                <%#Eval("FanLiBiLiBaiFenBi")%>
                            </td>
                            <td style="text-align: right;">
                                <font class="fontred">
                                    <%#Eval("FanLiJinE","{0:F2}") %></font>
                            </td>
                            <td align="center">
                                <%#Eval("FanLiStatus") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr>
                        <td colspan="7">
                            暂无推广返利信息
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
            if (fenYe.recordCount > 0) AjaxPageControls.replace("div_fenye", fenYe);
            $("#txtStatus").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStatus") %>');
        }); 
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
