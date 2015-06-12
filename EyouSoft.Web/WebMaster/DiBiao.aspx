<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiBiao.aspx.cs" Inherits="EyouSoft.Web.WebMaster.DiBiao" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>地标管理</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="/js/jquery.boxy.js"></script>
    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/webmaster/boxy.css" />
</head>
<body>
    <table width="99%" border="0" align="center" cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img alt="" src="/Images/webmaster/yuanleft.gif">
                </td>
                <td>
                    <form method="get" id="form1">
                    <div class="searchbox">
                    省份:
                    <select id="txtProvinceId" class="inputselect" name="txtProvinceId">
                    </select>
                    城市:
                    <select id="txtCityId" class="inputselect" name="txtCityId">
                    </select>
                    县区：
                    <select id="txtDistrictId" class="inputselect" name="txtDistrictId">
                    </select>
                    地标：<input type="text" name="txtName" id="txtName" class="inputtext" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtName") %>" />
                    
                    <input type="submit" class="search-btn" value="" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img alt="" src="/Images/webmaster/yuanright.gif">
                </td>
            </tr>
        </tbody>
    </table>

    <div class="btnbox">
        <table cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" id="i_a_insert">新 增</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <th width="36" bgcolor="#BDDCF4" align="center">
                        序号
                    </th>
                    <th bgcolor="#BDDCF4" align="center">
                        所在地
                    </th>
                    <th bgcolor="#BDDCF4" align="center">
                        地标名称
                    </th>
                    <th width="17%" bgcolor="#bddcf4" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" i_id="<%#Eval("Id") %>">
                            <td align="center">
                                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <%#Eval("ProvinceName")%>-<%#Eval("CityName")%>-<%#Eval("DistrictName")%>
                            </td>
                            <td align="center">
                                <%#Eval("Name")%>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" class="i_update">修改 </a>|<a href="javascript:void(0)"
                                    class="i_delete"> 删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr>
                    <td colspan="20">暂无信息</td>
                </tr>
                </asp:PlaceHolder>
                <tr>
                    <td height="30" align="right" class="pageup" colspan="4">
                        <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            insert: function() {
                var _data = {};
                Boxy.iframeDialog({ title: "新增地标", iframeUrl: '/WebMaster/DiBiaoEdit.aspx', height: "400px", width: "480px", modal: true, data: _data, afterHide: function() { iPage.reload(); } });
            },
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { id: _$tr.attr("i_id") };

                Boxy.iframeDialog({ title: "修改地标", iframeUrl: '/WebMaster/DiBiaoEdit.aspx', height: "400px", width: "480px", modal: true, data: _data, afterHide: function() { iPage.reload(); } });
            },
            del: function(obj) {
                if (!confirm("地标信息删除后不可恢复，你确定要删除吗？")) return;

                var _$tr = $(obj).closest("tr");
                var _data = { txtid: _$tr.attr("i_id") };
                $.ajax({
                    type: "POST", url: "dibiao.aspx?dotype=delete", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                        }
                    }
                });
            }
        };

        $(document).ready(function() {
            pcToobar.init({ pID: "#txtProvinceId", cID: "#txtCityId", xID: "#txtDistrictId", pSelect: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtProvinceId") %>', cSelect: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtCityId") %>', xSelect: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtDistrictId") %>', comID: '1' });

            $("#i_a_insert").click(function() { iPage.insert(); });
            $(".i_update").click(function() { iPage.update(this); });
            $(".i_delete").click(function() { iPage.del(this); });
        });
    </script>
</body>
</html>
