<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanLianMengTuiGuangFanLi.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.FanLianMengTuiGuangFanLi" MasterPageFile="~/WebMaster/default.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist" style="margin: 0px auto; margin-top: 10px;">
        <div style="width: 100%; height: 30px; text-align: left; font-size: 24px;">
            返联盟推广返利信息</div>
            
        <div style="border: 1px solid #c1def0; height: 30px; line-height: 30px; width: 100%;
            background: #EDF8FF; margin-bottom:10px; margin-top:10px;">
            <form method="get" id="form_chaxun">
            &nbsp;<b>交易时间：</b>
            <input type="text" onfocus="WdatePicker()" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaDanShiJian1") %>"
                name="txtXiaDanShiJian1" class="inputtext" style="width: 80px;">
            -
            <input type="text" onfocus="WdatePicker()" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaDanShiJian2") %>"
                name="txtXiaDanShiJian2" class="inputtext" style="width: 80px;">
            <b>返利状态：</b>
            <select id="txtStatus" name="txtStatus" class="inputselect">
                <option value="">全部</option>
                <option value="0">未返</option>
                <option value="1">已返</option>
            </select>
            <input type="submit" name="btnChaXun" value="搜索" class="line-s-btn s_btn">
            </form>
        </div>
        
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tr>
                <th style="width:50px; height:30px;">序号</th>
                <th style="width: 90px;">
                    交易时间
                </th>
                <th style="width: 90px; text-align: left;">
                    下单人姓名
                </th>
                <th style="width: 90px; text-align: left;">
                    推广人姓名
                </th>
                <th style="width: 90px; text-align: left;">
                    分销站点名称
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
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                        <td align="center" style="height: 30px;">
                            <%# Container.ItemIndex + 1+( this.PageIndex - 1) * this.PageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %>
                        </td>
                        <td style="text-align: left;">
                            <%#Eval("XiaDanRenName") %>
                        </td>
                        <td style="text-align: left;">
                            <%#Eval("TuiGuangRenName")%>
                        </td>
                        <td style="text-align: left;">
                            <%#Eval("DingDanDaiLiShangWangZhanName")%>
                        </td>
                        <td align="center" style="text-align: left;">
                            <%# EyouSoft.Common.Utils.GetText2(EyouSoft.Common.Utils.ConverToStringByHtml(Eval("CPName").ToString()), 30, true)%>
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
                <tr class="even">
                    <td colspan="10">
                        暂无返联盟推广返利信息
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="320" border="0" align="center">
            <tr>
                <td height="40" align="center" class="tjbtn02" style="padding-left: 25%;">
                    <a href="javascript:history.go(-1);">返回</a>
                </td>
            </tr>
        </table>
    </div>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#txtStatus").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStatus") %>');
        });
    </script>
</asp:Content>
