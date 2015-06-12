<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRoute.aspx.cs" Inherits="EyouSoft.Web.WebMaster.SelectRoute" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选用线路</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <style type="text/css">
        #tblList
        {
            border-collapse: collapse;
        }
        #tblList td
        {
            border: 1px #b8c5ce solid;
            padding: 0 3px;
        }
    </style>
</head>
<body>
    <form id="form1" method="get">
    <div>
        <table width="99%" align="center" cellpadding="0" cellspacing="0" bgcolor="#e9f4f9"
            style="margin: 0 auto">
            <tr>
                <td width="90%" align="left">
                    线路名称：
                    <input name="txtName" type="text" class="inputtext formsize100" id="txtName" value='<%=Request.QueryString["txtName"]%>' />
                    <input type="hidden" name="callback" id="callback" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("callBack") %>" />
                    <input type="hidden" name="iframeid" id="iframeid" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeid") %>" />
                    <input type="hidden" name="pIframeID" id="pIframeID" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("pIframeID") %>" />
                    <input type="hidden" name="hideID" id="hideID" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("hideID") %>" />
                    <input type="hidden" name="aid" id="aid" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("aid") %>" />
                    <input type="submit" id="searchbtn" class="search-btn" value="" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <div style="margin: 0 auto 0 auto; width: 99%;">
        <div id="AjaxDataList" style="width: 100%; padding-top: 10px">
            <table width="100%" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" align="center"
                id="tblList" style="margin: 0 auto" class="tablelist">
                <tr class="">
                    <asp:Repeater runat="server" ID="RptrouteList">
                        <ItemTemplate>
                            <td align="left" height="30px" width="25%">
                                <label>
                                    <input name="1" type="radio" value="<%#Eval("XianLuId") %>" data-show="<%#Eval("RouteName")%>" />
                                    <span>
                                        <%#Eval("RouteName")%></span>
                                </label>
                                <%#EyouSoft.Common.Utils.IsOutTrOrTd(Container.ItemIndex, listcount, 3)%>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal runat="server" ID="lbemptymsg"></asp:Literal>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0" id="div_AjaxPage">
                <tbody>
                    <tr>
                        <td align="right">
                            <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table cellspacing="0" cellpadding="0" border="0" align="center" id="TabBtn">
            <tbody>
                <tr>
                    <td width="76" height="40" align="center" class="tjbtn02">
                        <a href="javascript:;" id="a_btn" runat="server">选用</a>
                    </td>
                    <td width="76" height="40" align="center" class="tjbtn02">
                        <a href="javascript:;" onclick="window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();">
                            关闭</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</body>
</html>

<script type="text/javascript">  
    $(function() {
        $("#a_btn").click(function() {
            if($("#tblList").find("input[type='radio']:checked").length>0){
                SelectRoutePage.SetValue();
                SelectRoutePage.SelectValue();
            }
            else{
                parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
            }
            return false;
        })
//         $("#div_AjaxPage a").click(function() {
//                        var str = $(this).attr("href").match(/&[^&]+$/);
//                        var para = {txtName: $("#txtName").val(), callback: $("#callback").val(), iframeId: $("#iframeid").val(), piframeId: $("#pIframeID").val(), ShowID: $("#ShowID").val(),dianping:'<%=Request.QueryString["dianping"] %>' };
//                        pageIndex = str.toString().replace("&Page=", "");
//                        window.location.href="/WebMaster/SelectRoute.aspx?Page="+pageIndex+$.param(para);
//                        return false;
//                    });
//                    $("#div_AjaxPage select").removeAttr("onchange").change(function() {
//                        var para = {txtName: $("#txtName").val(), callback: $("#callback").val(), iframeId: $("#iframeid").val(), piframeId: $("#pIframeID").val(), ShowID: $("#ShowID").val(),dianping:'<%=Request.QueryString["dianping"] %>' };
//                        pageIndex = $(this).val();
//                        window.location.href="/WebMaster/SelectRoute.aspx?Page="+pageIndex+$.param(para);
//                        return false;
//         });
         var selectval='<%=Request.QueryString["hideID"] %>';
         $("#tblList").find("input[type='radio']").each(function(){
             if($(this).val()==selectval){
                $(this).attr("checked","checked");
             }
         });
    })
    var SelectRoutePage = {
        _dataObj: {},
        selectValue: "",
        selectTxt: "",
        SetNewValue:function(data){
             this.selectValue=data.id;
             this.selectTxt=data.name;
        },
        SetValue: function() {
            var valueArray = [], txtArray = [];
            $("#tblList").find("input[type='radio']:checked").each(function() {
                valueArray.push($(this).val());
                txtArray.push($(this).attr("data-show"));
            })

            this.selectValue = valueArray.join(',');
            this.selectTxt = txtArray.join(',');
        },
        RadioClickFun: function(args) {
            var rdo = $(args);
            var data = rdo.val().split(',');
            this.selectValue = data[0];
            this.selectTxt = data[1];
            this.SelectValue();
        },
        SelectValue: function() {
            var data = {
                callBack: Boxy.queryString("callBack"),
                hideID: Boxy.queryString("hideID"),
                iframeID: Boxy.queryString("iframeId"),
                pIframeID: '<%=Request.QueryString["pIframeID"] %>'
            }

            var args = {
                aid: '<%=Request.QueryString["aid"] %>',
                id: SelectRoutePage.selectValue,
                name: SelectRoutePage.selectTxt
            }
            //根据父级是否为弹窗传值
            if (data.pIframeID != "" && data.pIframeID.length > 0) {
                //定义父级弹窗
                var boxyParent = window.parent.Boxy.getIframeWindow(data.pIframeID) || window.parent.Boxy.getIframeWindowByID(data.pIframeID);
                //判断是否存在回调方法
                if (data.callBack != null && data.callBack.length > 0) {
                    if (data.callBack.indexOf('.') == -1) {
                        boxyParent[data.callBack](args);
                    }
                    else {
                        boxyParent[data.callBack.split('.')[0]][data.callBack.split('.')[1]](args);
                    }
                }
                //定义回调
            }
            else {
                //判断是否存在回调方法
                if (data.callBack != null && data.callBack.length > 0) {
                    if (data.callBack.indexOf('.') == -1) {
                        window.parent[data.callBack](args);
                    }
                    else {
                        window.parent[data.callBack.split('.')[0]][data.callBack.split('.')[1]](args);
                    }
                }
                //定义回调
            }
            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
        }
    }
    

</script>

