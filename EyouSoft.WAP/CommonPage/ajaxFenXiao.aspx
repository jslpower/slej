<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxFenXiao.aspx.cs" Inherits="EyouSoft.WAP.CommonPage.ajaxFenXiao" %>

<asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                  <ul class="clearfix">
                  <li><label>下级网站：</label> <%# GetWebSite(Eval("DaiLiShangId"))%></li>
                  <li><label>奖励比例：</label><%# Convert.ToDecimal(Convert.ToDecimal(Eval("JiangLiBi"))*100).ToString("f2")%>%</li>
                  <li><label>下级名称：</label><a href="FenSi.aspx?fensiid= <%#Eval("DaiLiShangHuiYuanId") %>"><%# GetMember(Eval("DaiLiShangHuiYuanId"))%></a></li>
                  <li><label>下级佣金：</label><span class="font_z"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Eval("YongJinJinE", "{0:F2}")%></span></li>
                  <li><label>交易时间：</label><%#Eval("XiaDanShiJian", "{0:yyyy-MM-dd}")%></li>
                  <li><label>奖金额度：</label><span class="font_yellow"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : Convert.ToDecimal(Convert.ToDecimal(Eval("YongJinJinE")) * Convert.ToDecimal(Eval("JiangLiBi"))).ToString("f2")%></span></li>
                  <li><label>消费状态：</label><span class="font_red"><%#GetDingDanStatus(Eval("DingDanStatus"))%></span></li>
                  <li><label>可结算额：</label><span class="font_green"><%# ((EyouSoft.Model.OtherStructure.DingDanType)(int)(Eval("DingDanLeiXing"))) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0" : (GetIsXiaoFei(Eval("DingDanStatus")) == "0" ? "0.00" : Convert.ToDecimal(Convert.ToDecimal(Eval("YongJinJinE")) * Convert.ToDecimal(Eval("JiangLiBi"))).ToString("f2"))%></span></li>
                  <li><label>操　　作：</label><a class="e_ck radius4" href="">查看明细</a></li>
              </ul>
                    </ItemTemplate>
                </asp:Repeater>