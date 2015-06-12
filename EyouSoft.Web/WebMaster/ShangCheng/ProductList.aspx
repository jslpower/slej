<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShangCheng.ProductList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

</head>
<body>
    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="from1" action="ProductList.aspx">
                    <div class="searchbox">
                        <label>
                            产品名称：</label>
                        <input type="text" class="inputtext" name="CName" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("CName") %>" />
                        <label>
                            <label>
                                分类：</label>
                            <select name="ddlType" id="ddlType" class="inputselect">
                                <%=this.initDDL(EyouSoft.Common.Utils.GetQueryStringValue("ddlType"))%>
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
    <%if (UserInfo.LeiXing != WebmasterUserType.代理商用户)
      { %>
    <div class="btnbox btnboxme">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a class="table_add" href="javascript:;">新 增</a>
                </td>
            </tr>
        </table>
    </div>
    <%} %>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th align="center">
                        产品名称
                    </th>
                    <th align="center">
                        分类
                    </th>
                    <th align="center">
                        库存
                    </th>
                    <th align="center">
                        门市价
                    </th>
                     <% if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
                        {%>
                        <th align="center">
                        代理价
                    </th>
                     <%} else{ %>
                    <th align="center">
                        成本价
                    </th>
                    <%} %>
                    <th align="center">
                        有效期
                    </th>
                       <th align="center">
                        供应商名称
                    </th>
                    
                    <th align="center">
                        操作
                    </th>
                       
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td align="left">
                                <em style="padding-left:10px;"></em><%#Eval("ProductName")%>
                            </td>
                            <td align="center">
                                <%#Eval("TypeName")%>
                            </td>
                            <td align="center">
                                <%#Eval("StockNum")%>
                            </td>
                            <td align="center">
                                <%# Eval("MarketPrice", "{0:C2}")%>
                            </td>
                             <% if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户){%>
                                <td align="center">
                                <%# UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, Convert.ToDecimal(Eval("SalePrice")), Convert.ToDecimal(Eval("MarketPrice")), EyouSoft.Model.Enum.MemberTypes.代理).ToString("f2")%>
                                </td>
                            <%}else{ %>
                            <td align="center">
                                <%# Eval("SalePrice", "{0:C2}")%>
                            </td>
                            <%} %>
                            <td align="center">
                                <%#Eval("EffectDate", "{0:yyyy-MM-dd}")%>
                            </td>
                             <td align="center">
                                <%# Eval("SupplierName")%>
                            </td>
                            <% if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户){%>
                               <td align="center"><%# GetDaiLiPro(Eval("IsTrue"), Eval("EffectDate"), Eval("ProductID"))%> </td>
                            <%}else{ %>
                                 <td align="center"><%# GetIsTrue(Eval("IsTrue"), Eval("EffectDate"), Eval("ProductID"))%> 
                                    <a class="table_update" href="javascript:;" data-id="<%#Eval("ProductID") %>">修改</a>
                                    <a class="table_del" href="javascript:;" data-id="<%#Eval("ProductID") %>">删除</a> <a data-class="paixu" href="javascript:;" data-id="<%#Eval("ProductID")%>">排序</a>
                                 </td>
                            <%} %>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litNoMsg" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        var pageData = {
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            EnIndex: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var url = "/WebMaster/ShangCheng/ProductList.aspx?dotype=isindex&id=" + id + "&state=" + state;
            pageData.GoAjax(url);
        },
        SheZhiStatus: function(obj) {
            var id = $(obj).attr("data-id");
            var state = $(obj).attr("data-state");
            var probool = $(obj).attr("data-bool");
            var url = "/WebMaster/ShangCheng/ProductList.aspx?dotype=isdaili&id=" + id + "&state=" + state + "&probool=" + probool;
            pageData.GoAjax(url);
        },
        openwindow: function(url, title, width, height) {
            url = url;
            Boxy.iframeDialog({
                iframeUrl: url,
                title: title,
                modal: true,
                width: width,
                height: height,
                afterHide: function() { location.reload(); }
            });
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
            }
        };
        $(function() {
        $("a[data-class=paixu]").click(function() {
            var orderid = $(this).attr("data-id");
            pageData.openwindow("/WebMaster/PaiXu.aspx?id=" + orderid + "&type=shangcheng&dotype=paixu", "排序修改", 400, 200);
        });
        $("a.table_add").click(function() {
        window.location.href = "/WebMaster/shangcheng/ProductEdit.aspx?dotype=add";
//        pageData.ShowBoxy({ iframeUrl: "/WebMaster/shangcheng/ProductEdit.aspx?dotype=add", title: "新增", width: "800px", height: "650px" })
             });
             $("a.table_update").click(function() {
             window.location.href = "/WebMaster/shangcheng/ProductEdit.aspx?dotype=update&id=" + $(this).attr("data-id");
//             pageData.ShowBoxy({ iframeUrl: "/WebMaster/shangcheng/ProductEdit.aspx?dotype=update&id=" + $(this).attr("data-id"), title: "修改", width: "800px", height: "650px" })
         });

            $("a.table_del").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("您确定要删除此条记录吗？", function() {
                    $.ajax({
                        url: "/WebMaster/ShangCheng/ProductList.aspx?del=1&id=" + id,
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
                    });


                });
            });
            $("a.table_up").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("您确定要上架该商品吗？", function() {
                    $.ajax({
                        url: "/WebMaster/ShangCheng/ProductList.aspx?up=0&pid=" + id,
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
                    });


                });
            });
            $("a.table_dwon").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("您确定要下架该商品吗？", function() {
                    $.ajax({
                        url: "/WebMaster/ShangCheng/ProductList.aspx?up=1&pid=" + id,
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
                    });


                });
            });


        })
    </script>

</body>
</html>
