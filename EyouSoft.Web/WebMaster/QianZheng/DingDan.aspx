<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDan.aspx.cs" Inherits="EyouSoft.Web.WebMaster.QianZheng.DingDan"
    MasterPageFile="~/MasterPage/Webmaster.Master" Title="签证订单信息列表" %>

<%@ Register TagPrefix="cc1" Namespace="Adpost.Common.ExporPage" Assembly="ControlLibrary" %>
<%@ Import Namespace="EyouSoft.Model.Enum" %>
<asp:Content ContentPlaceHolderID="PageBody" runat="server" ID="PageBody1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" method="get">
                    <div class="searchbox">
                        订单号：<input type="text" name="txtDingDanHao" class="inputtext formsize100" maxlength="30"
                            size="28" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtDingDanHao") %>' />
                        联系人姓名：<input type="text" name="txtLxrXingMing" class="inputtext formsize100" maxlength="30"
                            size="28" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtLxrXingMing") %>' />
                        下单时间：<input type="text" onfocus="WdatePicker()" name="txtXiaDanSTime" size="10" class="inputtext formsize80"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaDanSTime") %>' />-<input
                                type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtXiaDanSTime\')}'})" class="inputtext formsize80" name="txtXiaDanETime"
                                size="10" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaDanETime") %>' />                                
                        订单状态：<select class="inputselect" name="txtDingDanStatus">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), EyouSoft.Common.Utils.GetQueryStringValue("txtDingDanStatus"), "", "请选择")%>
                        </select>
                        付款状态：<select class="inputselect" name="txtFuKuanStatus">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)), EyouSoft.Common.Utils.GetQueryStringValue("txtFuKuanStatus"), "", "请选择")%>
                        </select>  
                        <br />下单渠道：<select name="qudaolist" id="qudaolist" class="inputselect" style="width:140px;">
                        <option value="-1">请选择</option>
                            <%=GetSellersHtml(EyouSoft.Common.Utils.GetQueryStringValue("qudaolist"))%>
                        </select>     
                        <input type="submit" class="search-btn" value="" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
<%--    <div class="btnbox">
    </div>--%>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="30" height="30" align="center">
                        <%--<input type="checkbox" id="chkQuanXuan" name="chkQuanXuan" />全选--%>
                    </th>
                    <th align="center">
                        订单内容
                    </th>
                    <th width="130" align="center">
                        渠道
                    </th>
                    <th width="70" align="center">
                        预订时间
                    </th>
                    <th width="90" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        客人信息
                    </th>
                    <th width="130" align="center">
                        交易金额
                    </th>
                    <th width="130" align="center">
                        分销金额
                    </th>
                    <th width="60" align="center">
                        分销利润
                    </th>
                    <th width="70" align="center">
                        下单时间
                    </th>
                    <%--<th align="center">
                        订单状态
                    </th>--%>
                    <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="60" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' i_dingdanid='<%#Eval("DingDanId") %>'  i_uid='<%#Eval("DingDanHao")%>'>
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <%--<input type="checkbox" name="chkItem">--%>
                            </td>
                            <td align="left">
                            订单号：<a href="javascript:;" class="info">
                                    <%#Eval("DingDanHao")%></a><br />
                               <%# Eval("QianZhengName")%>   
                            </td>
                            <td align="center">
                                <%# GetWangDianByID(Eval("AgencyId"))%>
                            </td>
                            <td align="center">
                                <%#Eval("YuDingShiJian","{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="left">
                                <%# GetMemberNameByID(Eval("XiaDanRenId"))%>
                            </td>
                            <td align="left">
                                <%# Eval("LxrXingMing")%><br />
                                <%# Eval("LxrDianHua")%>
                            </td>
                            <td align="left">
                                签证数：<%# Eval("YuDingShuLiang")%>
                                份<br />
                                单价：<%#  (Convert.ToDouble(Eval("JinE")) / Convert.ToDouble(Eval("YuDingShuLiang"))).ToString("f2")%>
                                元/张<br />
                                金额：<%#  Convert.ToDouble(Eval("JinE")).ToString("f2")%>
                                元
                            </td>
                            <td align="left">
                                签证数：<%# Eval("YuDingShuLiang")%>
                                份<br />
                                单价：<%#  (Convert.ToDouble(Eval("AgencyJinE")) / Convert.ToDouble(Eval("YuDingShuLiang"))).ToString("f2")%>
                                元/张<br />
                                金额：<%# Eval("AgencyId").ToString().Trim().Length > 20 ? Convert.ToDouble(Eval("AgencyJinE")).ToString("f2") : "0"%> 元
                            </td>
                             <td align="center">
                             <%# Eval("AgencyId").ToString().Trim().Length > 20 ? (Convert.ToDouble(Eval("JinE")) - Convert.ToDouble(Eval("AgencyJinE"))).ToString("f2") : "0"%>
                            </td>                            
                            <td align="center">
                                <%#Eval("IssueTime")%>
                            </td>
                            <%--<td align="center">
                                <%#Eval("DingDanStatus")%>
                            </td>--%>
                            <td height="30" align="center" nowrap="nowrap"><%# GetFuKuangCate(Eval("DingDanId"), Eval("DingDanStatus"))%></td>
                            <td align="center">                                 
                                  <%# setOptClick(Eval("DingDanId").ToString(), Eval("DingDanStatus"), Eval("AgencyId"))%><br />
                                  <%# DeleteUserOrder(Eval("DingDanId").ToString(), Eval("DingDanStatus"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr>
                        <td colspan="10" style="height: 24px;">
                            暂无任何签证订单信息
                        </td>
                    </tr>
                </asp:PlaceHolder>
            </tbody>
            <tfoot>
            <tr class="<%= this.FenYe.intRecordCount % 2 == 0 ?  "even" : "odd"%>"><td colspan="6" align="right">合计金额：</td><td align="center"><%= SumMoney.ToString("f2")%></td><td align="center"><%= SumAMoney.ToString("f2")%></td><td align="center"><%= SumLiRun.ToString("f2")%></td><td colspan="3"></td></tr>
            <tr>
                    <th width="30" height="30" align="center">
                        <%--<input type="checkbox" id="chkQuanXuan" name="chkQuanXuan" />全选--%>
                    </th>
                    <th align="center">
                        订单内容
                    </th>
                    <th width="130" align="center">
                        渠道
                    </th>
                    <th width="70" align="center">
                        预订时间
                    </th>
                    <th width="90" align="center">
                        操作人
                    </th>
                    <th width="90" align="center">
                        客人信息
                    </th>
                    <th width="130" align="center">
                        交易金额
                    </th>
                    <th width="130" align="center">
                        分销金额
                    </th>
                    <th width="60" align="center">
                        分销利润
                    </th>
                    <th width="70" align="center">
                        下单时间
                    </th>
                    <%--<th align="center">
                        订单状态
                    </th>--%>
                    <th width="60" align="center" nowrap="nowrap">
                    付款方式
                </th>
                    <th width="60" align="center">
                        操作
                    </th>
                </tr>
            </tfoot>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
<br /><br />
    <script type="text/javascript">
    function test(oid, state)
    { alert(oid + state) }

    var OrderList = {

        setOrder: function(oid, state) {
            if (window.confirm("请确认操作")) {
                $.ajax({
                url: "/WebMaster/QianZheng/DingDan.aspx?setState=1&id=" + oid + "&state=" + state,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = location.href; });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })
            }
        },
        BindBtn: function() {
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行"
            });
        },
        openXLwindow: function(url, title, width, height) {
            url = url;
            Boxy.iframeDialog({
                iframeUrl: url,
                title: title,
                modal: true,
                width: width,
                height: height,
                afterHide: function() { OrderList.reload(); }
            });
        },
        reload: function() {
            window.location.href = window.location.href;
        }
    };

    $(function() {
        OrderList.BindBtn();
        $("#liststyle .info").click(function() {
        var id = $(this).closest("tr").attr("i_dingdanid");
        window.location.href = "DingDanEdit.aspx?id=" + id + "&type=show";
            //OrderList.openXLwindow("DingDanEdit.aspx?id=" + id + "&type=show", "查看订单", 800, 500);
        });
        $("#liststyle .update").click(function() {
            var orderid = $(this).closest("tr").attr("i_dingdanid");
            OrderList.openXLwindow("DingDanEdit.aspx?id=" + orderid + "&type=update", "订单修改", 800, 500);
        });
    });

    </script>

</asp:Content>
