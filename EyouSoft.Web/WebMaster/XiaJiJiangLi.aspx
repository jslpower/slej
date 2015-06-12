<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaJiJiangLi.aspx.cs" Inherits="EyouSoft.Web.WebMaster.XiaJiJiangLi"
    MasterPageFile="~/WebMaster/default.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody1" runat="server">
    <div class="tablelist" style="margin: 0px auto; margin-top: 10px;">
        <div style="width: 100%; height: 30px; text-align: left; font-size: 24px;">分销奖励申请信息</div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tr>
                <th align="center" style="width: 50px; height: 30px;">
                    序号
                </th>
                <th align="center">
                    用户名
                </th>
                <th align="center">
                    会员姓名
                </th>
                <th align="center">
                    申请时间
                </th>
                <th align="center">
                    申请结算佣金
                </th>
                <th align="center">
                    申请结算比例
                </th>
                <th align="center">
                    申请结算金额
                </th>
                <th align="center">
                    申请结算状态
                </th>
                <th align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-tichengid="<%#Eval("TiChengId") %>">
                        <td align="center" style="height: 30px;">
                            <%# Container.ItemIndex + 1+( this.PageIndex - 1) * this.PageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("HuiYuanYongHuMing")%>
                        </td>
                        <td align="center">
                            <%#Eval("HuiYuanXingMing")%>
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
                        <th align="center">
                            <%#GetCaoZuoHtml(Eval("Status")) %>
                        </th>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr class="even">
                    <td colspan="8">
                        暂无分销奖励申请信息
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
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            shenHeTongGuo: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtTiChengId: _$tr.attr("data-tichengid") };
                if (!confirm("你确定要审核通过该申请吗？")) return false;
                $(obj).unbind("click").css({ "color": "#999" })
                $.ajax({
                    type: "POST", url: "xiajijiangli.aspx?&doType=shenhetongguo", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.reload();
                        } else {
                            $(obj).bind("click", function() { iPage.shenHeTongGuo(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shenHeTongGuo(obj); }).css({ "color": "" });
                    }
                });

            }
        };

        $(document).ready(function() {
            $(".shenhetongguo").click(function() { iPage.shenHeTongGuo(this); });
        });
    
    </script>
</asp:Content>
