<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityManage.aspx.cs" Inherits="EyouSoft.Web.WebMaster.CityManage" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>城市管理</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <link rel="stylesheet" type="text/css" href="/css/webmaster/boxy.css" />
</head>
<body>
    <div class="btnbox-xt">
        <table cellspacing="0" cellpadding="0" border="0" align="left" style="margin-left: 8px;">
            <tbody>
                <tr>
                    <td width="91">
                        <a href="javascript:;" onclick="return CityManage.openDialog('ProvinceEdit.aspx?action=add','添加省份');">
                            添加省份</a>
                    </td>
                    <td width="91">
                        <a href="javascript:;" onclick="return CityManage.openDialog('CityEdit.aspx?action=add','添加省份');">
                            添加城市</a>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="left" colspan="3">
                        <font color="#FF0000"><strong>注：点击地区名称可进行修改</strong></font>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <table width="99%" cellspacing="1" cellpadding="0" border="0" align="left">
        <tbody>
            <tr>
                <td width="36" height="30" bgcolor="#BDDCF4" align="center">
                    <strong>编号</strong>
                </td>
                <td bgcolor="#BDDCF4" align="center">
                    <strong>省份名称</strong>
                </td>
                <td width="20%" bgcolor="#BDDCF4" align="center">
                    <strong>城市名称</strong>
                </td>
                <td width="20%" bgcolor="#BDDCF4" align="center">
                    <strong>操作</strong>
                </td>
            </tr>
            <%=proAndCityHtml%>
            <tr>
                <td valign="middle" height="30" bgcolor="#FFFFFF" align="center" class="pageup" colspan="5">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        var CityManage = {
            //打开弹窗
            openDialog: function(p_url, p_title, p_height) {
                Boxy.iframeDialog({ title: p_title, iframeUrl: p_url, width: "550px", height: p_height });
            },
            updateCity: function(cId) {
                CityManage.openDialog("/WebMaster/CityEdit.aspx?action=edit&cId=" + cId, "修改城市", "150px");
                return false;
            },
            updatePro: function(pId) {
                CityManage.openDialog("/WebMaster/ProvinceEdit.aspx?action=edit&pId=" + pId, "修改省份", "120px");
                return false;
            },
            //删除城市
            delCity: function(cityId, tar) {
                tableToolbar.ShowConfirmMsg("你是否确认要删除该城市？", function() {
                    CityManage.doAjax("delCity", cityId);
                });

            },
            //删除省份
            delPro: function(proId, tar) {
                tableToolbar.ShowConfirmMsg("删除省份将会删除该省份下的所有城市，是否确认删除？", function() {
                    CityManage.doAjax("delPro", proId);
                });

            },
            //设置为常用城市
            setCity: function(cId, tar) {
                var cityObj = $(tar);
                var ischecked = cityObj.attr("checked");
                var mess = ischecked ? "你是否要设置该城市为常用城市？" : "你是否要取消该城市为常用城市？";
                if (!confirm(mess)) {
                    cityObj.attr("checked", !ischecked);
                    return false;
                }
                CityManage.doAjax(cityObj.attr("isFav"), cId, cityObj);
            },
            //统一Ajax调用
            doAjax: function(doType, cid, tarp) {
                $.newAjax({
                    url: "/WebMaster/CityManage.aspx",
                    data: { method: doType, id: cid },
                    dataType: "json",
                    cache: false,
                    type: "get",
                    success: function(result) {
                        if (result.success == '1') {
                            if (doType == "True" || doType == "False") {
                                if (doType == "False") { tarp.attr("isFav", "True"); tableToolbar._showMsg("已取消常用城市！"); }
                                else { tarp.attr("isFav", "False"); tableToolbar._showMsg("已设置为常用城市！"); }
                            }
                            else {
                                if (doType == "delCity" || doType == "delPro") {
                                    tableToolbar._showMsg("删除成功！", function() { window.location = "CityManage.aspx"; });
                                }
                            }
                        }
                        else {
                            tableToolbar._showMsg(result.message);
                        }
                    }
                });
            }
        }
    </script>

</body>
</html>
