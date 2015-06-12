<%@ Page Title="Excel导入游客页" Language="C#" AutoEventWireup="true" CodeBehind="LoadVisitors.aspx.cs"
    Inherits="Web.CommonPage.LoadVisitors" %>


<%@ Register src="../WebMaster/UserControl/ExcelFileUploadControl.ascx" tagname="ExcelFileUploadControl" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/js/loadExcel.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--上传控件开始--%>
         <uc1:ExcelFileUploadControl ID="FileUpload1" runat="server" UploadSuccessJavaScriptFunCallBack="loadexcel" />
        <%--上传控件结束--%>
       
        <br />
        <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
            <tr>
                <td>
                    <fieldset>
                        <legend>源数据预览&nbsp;&nbsp;&nbsp;&nbsp;</legend>
                        <table height="30" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
                            <tr>
                                <td>
                                    <div id="tablelist">
                                    </div>
                                    <input type="button" id="selectall" value="全选" />
                                    <input type="button" id="reset" value="清空">
                                    <input type="button" id="selectback" value="反选" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
            <tbody>
                <tr>
                    <td style="padding-top: 15px;">
                        <fieldset>
                            <legend>请设置对应字段</legend>
                            <table cellspacing="0" id="tbl_Cell" cellpadding="5" width="98%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label>
                                                姓名：</label>
                                            <select alt="姓名" id="lstVisitorName" name="lstVisitorName" class="s1">
                                            </select>
                                        </td>
                                        <td>
                                            <label>
                                                证件类型：</label>
                                            <select alt="证件类型" id="lstCardName" name="lstCardName" class="s1">
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                证件号码：</label>
                                            <select alt="证件号码" id="lstCardNo" name="lstCardNo" class="s1">
                                            </select>
                                        </td>
                                        <td>
                                            <label>
                                                性别：</label>
                                            <select alt="性别" id="lstSex" name="lstSex" class="s1">
                                            </select>
                                        </td>
                                        <td>
                                            <label>
                                                联系电话：</label>
                                            <select alt="联系电话" id="lstTel" name="lstTel" class="s1">
                                            </select>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="shenghui" align="center">
                                        &nbsp;<%--<asp:Button ID="btn_ImportInfo" OnClientClick="return inff.checkVisitorsInfo();"
                                            Text="确定" runat="server"></asp:Button>--%>
                                        <input id="ok" type="button" value="确定" />
                                        &nbsp;<input name="Canseled" type="button" value="关闭" onclick="window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide()" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>

<script type="text/javascript">

        function createVisitorsList(arr) {
            var topID = '<%= EyouSoft.Common.Utils.GetQueryStringValue("topID") %>';
            var win = topID ? window.parent.Boxy.getIframeWindow(topID) : window.parent;
            //从excel导入游客后，保留原来的游客行
            //win.OrderCustomerControl.clearTr();
            for (var i = 0; i < arr.length; i++) {
                win.OrderCustomerControl.addCustomer(arr[i]);
            }
        }

        function loadexcel(array) {
            loadXls.init(array, "#tablelist", ".s1");
            $("#selectall").bind("click", function() {
                loadXls.selectAll(true);
            });
            $("#reset").bind("click", function() {
                loadXls.selectAll(false);
            });
            $("#selectback").bind("click", function() {
                loadXls.selectback();
            });
            $("#ok").bind("click", function() {
                var iframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
                var type = '<%= EyouSoft.Common.Utils.GetQueryStringValue("type") %>';
                var win = iframeId ? window.parent.Boxy.getIframeDialog(iframeId) : window.parent;
                var arr = loadXls.bindIndex([$("#lstVisitorName").val(), $("#lstVisitorType").val(), $("#lstCardName").val(),
                                     $("#lstCardNo").val(), $("#lstSex").val(), $("#lstTel").val()]);
                if (arr.length == 0) {
                    alert("请在源数据中选择数据导入");
                    return false;
                }

                if (type == "customerLoad") {
                    createVisitorsList(arr);
                }

                win.hide();
            });
        }

</script>

</html>
