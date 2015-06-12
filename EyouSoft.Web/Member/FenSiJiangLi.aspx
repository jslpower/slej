<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front3.Master" AutoEventWireup="true" CodeBehind="FenSiJiangLi.aspx.cs" Inherits="EyouSoft.Web.Member.FenSiJiangLi" %>
<%@ Register Src="/UserControl/UserLeft.ascx" TagName="UserLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
<uc1:userleft runat="server" id="UserLeft1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
<div class="user_right">
        <div class="title_bar">
            <h4>
                &gt; 下级分销奖励</h4>
            <span>您的位置：<a href="/Default.aspx">首页</a> > <a href="UpdateMember.aspx">会员中心</a> > 下级分销奖励</span></div>
        <div class="user_Rbox margin_T10">
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="chzh_t">
                <tr>
                    <th style="width:80px;">
                        序号
                    </th>
                    <th style="width:80px;">
                        下级网站
                    </th>
                    <th style="width:80px;">
                        下级名称
                    </th>
                    <th style="width: 80px;">
                        交易时间
                    </th>
                    <th style="width: 80px; text-align:right;">
                        下级佣金
                    </th>
                    <th style="width: 80px; text-align:right;">
                        奖金比例
                    </th>
                    <th style="width: 80px;">
                        奖金额
                    </th>
                    <th style="width: 80px;">
                        消费状态
                    </th>
                    <th style="width: 100px;">
                        可结算额
                    </th>
                    <th style="width: 100px;">
                        操作
                    </th>
                </tr>                    
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%# Container.ItemIndex + 1+( PageIndex - 1) * this.PageSize%>
                            </td>
                            <td align="left">
                                <%# GetWebSite(Eval("DaiLiShangId"))%>
                            </td>
                            <td align="center">
                                <a href="FenSi.aspx?fensiid= <%#Eval("DaiLiShangHuiYuanId") %>"><%# GetMember(Eval("DaiLiShangHuiYuanId"))%></a>
                            </td>
                            <td align="right">
                            <%#Eval("XiaDanShiJian", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="right">
                            <font class="fontred"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Eval("YongJinJinE", "{0:F2}")%></font>
                            </td>
                            <td align="center">
                                <%# Convert.ToDecimal(Convert.ToDecimal(Eval("JiangLiBi"))*100).ToString("f2")%>%
                            </td>
                            <td align="center">
                            <font class="fontgreen">
                            <%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Convert.ToDecimal(Convert.ToDecimal(Eval("YongJinJinE")) * Convert.ToDecimal(Eval("JiangLiBi"))).ToString("f2")%>
                            </font>
                            </td>
                            <td align="center">
                                <%#GetDingDanStatus(Eval("DingDanStatus"))%>
                            </td>
                            <td align="center">
                                <font class="fontgreen"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : (GetIsXiaoFei(Eval("DingDanStatus")) == "0" ? "0.00" : Convert.ToDecimal(Convert.ToDecimal(Eval("YongJinJinE")) * Convert.ToDecimal(Eval("JiangLiBi"))).ToString("f2"))%></font>
                            </td>
                            <td align="center">
                                <a href="DingDanList.aspx?dingdanid=<%# Eval("DingDanId")%>">查看明细</a>
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
               <tfoot>
               <tr>
               <td colspan="4" align="center">总计</td>
               <td align="right"><%= XiaJiYongJinZong.ToString("f2")%></td>
               <td align="center">&nbsp;</td>
               <td align="center"><%= JiangJinZong.ToString("f2")%></td>
               <td align="center">——</td>
               <td align="center"><%= KeJieSuanZong.ToString("f2")%></td>
               <td align="center">——</td>
               </tr>
               <tr>
               <td align="center">已结算额</td>
               <td align="center">
                   <asp:Literal ID="YiJieSuan" runat="server"></asp:Literal></td>
               <td align="center">未结算额</td>
               <td align="center">
                   <asp:Literal ID="WeiJieSuan" runat="server"></asp:Literal></td>
               <td colspan="4" align="center">可申请结算额（未结算额的十位以上整数）</td>
               <td align="center">
                   <asp:Literal ID="KeShenQing" runat="server"></asp:Literal></td>
               <td  align="center"><a href="xiajijianglijiesuan.aspx" style="color:Red">申请结算</a></td>
               </tr>
               </tfoot>
            </table>
            <div class="page" id="div_fenye">
            </div>
        </div>
        <div>
        <p>注：</p>
 <p>(1) <span style=" color:red">什么是下级分销</span>——您的用户如果在您的网站上也购买了一个代理帐号（这个功能您可以屏蔽），他也成为跟您一样的代理商，这个代理商就永远都是您的下级代理，他也可以跟您一样销售系统中所有产品并且获取销售佣金。</p>
<p>(2) <span style=" color:red">什么是下级分销奖</span>——商旅E家公司会按您的粉丝代理的佣金的一定比例，从公司额外给您进行奖励，该奖励不是从粉丝代理佣金中扣除，而是公司给您额外奖励给您的。试想一下，如果您有100个粉丝代理，他们每人每月产生10000元代理佣金，100个人就是100万，您的下级分销奖就是100万*（奖励率比如为10%） = 10万元。</p>
<p>(3) <span style=" color:red">了解粉丝经营情况</span>——您可以通过后台查看您的粉丝销售和佣金明细，并计算出您的粉丝分销奖金！您可以帮助您的粉丝提升销售业绩，您的奖励就增加。</p>
<p>(4) <span style=" color:red">奖金结算</span>——您可以直接提交粉丝分销奖的结算申请，系统收到申请后会及时将奖金划入您的E额宝帐户。</p>
<p>(5) <span style=" color:red">特别说明</span>——您的下级的下级就不是您自己的下级了，否则就变传销了！同样，如果您自己也是从别的网站上购买的代理帐号，那么您也是那家网站的下级，他们也会帮助你提升销售以获取奖金！  （注：只推广一级，奖金是从总部获得，网站有丰富的产品，不属于传销！）</p></div>
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
<asp:Content ID="Content4" ContentPlaceHolderID="Link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
