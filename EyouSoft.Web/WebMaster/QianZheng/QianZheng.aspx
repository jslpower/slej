<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QianZheng.aspx.cs" Inherits="EyouSoft.Web.WebMaster.QianZheng.QianZheng"
    MasterPageFile="~/MasterPage/Webmaster.Master" Title="签证信息列表" %>

<%@ Register TagPrefix="cc1" Namespace="Adpost.Common.ExporPage" Assembly="ControlLibrary" %>
<asp:Content ContentPlaceHolderID="PageBody" runat="server" ID="PageBody1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="i_form" method="get">
                    <div class="searchbox">
                        签证类型：<select id="txtQianZhengLeiXing" name="txtQianZhengLeiXing" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)),"","","请选择") %>
                        </select>
                        签证名称:<input type="text" name="txtQianZhengName" class="inputtext formsize100" maxlength="30"
                            size="28" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtQianZhengName") %>' />
                        国家：
                        <input type="text" maxlength="30" id="txtGuoJiaName" name="txtGuoJiaName" class="inputtext formsize100"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtGuoJiaName") %>' />
                        <input type="hidden" id="txtGuoJiaId" name="txtGuoJiaId" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtGuoJiaId") %>' />
                        所属领区：<input type="text" name="txtSuoShuLingQu" class="inputtext formsize100" maxlength="30" size="28"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtSuoShuLingQu") %>' />                        
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
    <div class="btnbox">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a class="toolbar_add" href="javascript:void(0)" id="i_insert">新增</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_update" href="javascript:void(0)" id="i_update">修改</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" class="toolbar_delete" id="i_delete">删除</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        <%--<input type="checkbox" id="chkQuanXun" name="chkQuanXun">全选--%>
                    </th>
                    <th align="center">
                        名称
                    </th>
                    <th align="center">
                        国家
                    </th>
                    <th align="center">
                        价格
                    </th>
                    <th align="center">
                        门市价
                    </th>
                    <th align="center">
                        办理时间
                    </th>
                    <th align="center">
                        有效时间（天）
                    </th>
                    <th align="center">
                        停留时间（天）
                    </th>
                    <th align="center">
                        签证面试
                    </th>
                    <th align="center">
                        邀请函
                    </th>
                    <th align="center">
                        所属区域
                    </th>
                    <th align="center">
                        签证类型
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' i_qianzhengid="<%#Eval("QianZhengId") %>" i_faburenid="<%#Eval("FaBuRenId") %>">
                            <td height="30" align="center">
                                <%#Container.ItemIndex+1%>
                                <input type="checkbox" name="chkItem">
                            </td>
                            <td align="center">
                                <%#Eval("Name")%>
                            </td>
                            <td align="center">
                                <%#GetGuojiaName(int.Parse(Eval("GuoJiaId").ToString()))%>
                            </td>
                            <td align="center">
                                <%#Eval("JiaGe","{0:C2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("JiaGeMenShi","{0:C2}")%>
                            </td>
                            <td align="center">
                                <%#Eval("BanLiShiJian")%>
                            </td>
                            <td align="center">
                                <%#Eval("YouXiaoQi")%>
                            </td>
                            <td align="center">
                                <%#Eval("TingLiuShiJian")%>
                            </td>
                            <td align="center">
                                <%#Eval("MianShi")%>
                            </td>
                            <td align="center">
                                <%#Eval("YaoQingHan")%>
                            </td>
                            <td align="center">
                                <%#Eval("SuoShuLingQu")%>
                            </td>
                            <td align="center">
                                <%#Eval("QianZhengLeiXing")%>
                            </td>
                            <td align="center"> 
                            <%#CheIsIndex(Eval("IsIndex"), Eval("QianZhengId"))%>  
                                <a href="QianZhengEdit.aspx?qianzhengid=<%#Eval("QianZhengId") %>">管理</a></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr>
                        <td colspan="10" style="height: 24px;">
                            暂无任何签证信息
                        </td>
                    </tr>
                </asp:PlaceHolder>
            </tbody>
            <tr>
                    <th width="60" height="30" align="center">
                        <%--<input type="checkbox" id="chkQuanXun" name="chkQuanXun">全选--%>
                    </th>
                    <th align="center">
                        名称
                    </th>
                    <th align="center">
                        国家
                    </th>
                    <th align="center">
                        价格
                    </th>
                    <th align="center">
                        门市价
                    </th>
                    <th align="center">
                        办理时间
                    </th>
                    <th align="center">
                        有效时间（天）
                    </th>
                    <th align="center">
                        停留时间（天）
                    </th>
                    <th align="center">
                        签证面试
                    </th>
                    <th align="center">
                        邀请函
                    </th>
                    <th align="center">
                        所属区域
                    </th>
                    <th align="center">
                        签证类型
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
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
    <div id="i_div_qianzhengguojia">
    </div>
<br /><br />
    <script type="text/javascript" src="/js/qianzheng.core.js"></script>
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            quanXuan: function(obj) {
                if ($(obj).attr("checked")) $("input[name='chkItem']").attr("checked", "checked");
                else $("input[name='chkItem']").removeAttr("checked");
            },
            insert: function() {
                window.location.href = "/webmaster/qianzheng/QianZhengEdit.aspx";
            },
            update: function() {
                var _$chks = $('input[name="chkItem"]:checked');
                if (_$chks.length < 1) { alert("请选择要修改的签证信息"); return; }
                if (_$chks.length > 1) { alert("一次只能修改一个签证信息"); return; }
                var _$tr = _$chks.closest("tr")
                window.location.href = "/webmaster/qianzheng/qianzhengedit.aspx?qianzhengid=" + _$tr.attr("i_qianzhengid");
            },
            EnIndex: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var url = "/WebMaster/QianZheng/QianZheng.aspx?dotype=isindex&id=" + id + "&state=" + state;
            iPage.GoAjax(url);
        },
        GoAjax: function(url) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                async: false,
                dataType: "json",
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
        },
            del: function() {
                var _$chks = $('input[name="chkItem"]:checked');
                if (_$chks.length < 1) { alert("请选择要删除的签证信息"); return; }
                if (_$chks.length > 1) { alert("一次只能删除一个签证信息"); return; }

                if (!confirm("签证信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = _$chks.closest("tr");
                var _data = { txtQianZhengId: _$tr.attr("i_qianzhengid"), txtFaBuRenId: _$tr.attr("i_faburenid") };
                $.ajax({
                    type: "POST", url: "qianzheng.aspx?dotype=delete", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);

                        iPage.reload();
                    }
                });
            }
        };

        $(document).ready(function() {

            $("#i_insert").click(function() { iPage.insert(this); });
            $("#i_update").click(function() { iPage.update(this); });
            $("#i_delete").click(function() { iPage.del(this); });

            $("#txtQianZhengLeiXing").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtQianZhengLeiXing") %>')

            $("#chkQuanXun").click(function() { iPage.quanXuan(this); });

            qianZhengGuoJia.init({ txtName: 'txtGuoJiaName', txtId: 'txtGuoJiaId', left: 0, top: 4 });
        });
    </script>
</asp:Content>
