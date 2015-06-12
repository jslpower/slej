<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuiGuangDaiMa.aspx.cs"
    Inherits="EyouSoft.Web.Member.TuiGuangDaiMa" MasterPageFile="~/MasterPage/Front3.Master"
    Title="推广链接-返联盟推广-会员中心" %>

<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 推广链接</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> &gt; 推广链接</span></div>
        <div class="user_Rbox margin_T10">
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="chzh_t">
                <tr>
                    <td align="center" class="noborder" colspan="7">
                        <textarea class="user-text" rows="5" cols="45" id="txtTuiGuangLianJie" name="txtTuiGuangLianJie"><%=TuiGuangLianJie %></textarea>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" class="noborder" colspan="7">
                        <a class="copy" href="javascript:void(0)" id="i_a_copy">复制代码</a>
                    </td>
                </tr>
                <tr>
                    <td class="noborder" colspan="7">
                        <font class="font14 fontblue">最新推广返利记录</font>
                    </td>
                </tr>
                <tr>
                    <th style="width:90px;">
                        交易时间
                    </th>
                    <th style="width: 90px; text-align:left;">
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
                <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %>
                    </td>
                    <td style="text-align:left;">
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
    <script src="/Js/jquery.zclip.js" type="text/javascript"></script>

    <script type="text/javascript">
        var fenYe = { pageSize: 10, pageIndex:1 , recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };

        $(document).ready(function() {
            $(".left_menu ul li").menu();
            //if (fenYe.recordCount > 0) AjaxPageControls.replace("div_fenye", fenYe);
            $('#txtTuiGuangLianJie').focus(function() { $(this).select(); });
            $('#txtTuiGuangLianJie').click(function() { $(this).select(); });
            $("#i_a_copy").zclip({
                path: "/js/ZeroClipboard.swf",
                copy: function() {
                    return $("#txtTuiGuangLianJie").val();
                },
                afterCopy: function() {
                    alert("复制成功")
                }
            });
        }); 
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
