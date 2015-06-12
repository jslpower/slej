<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiBiaoEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.DiBiaoEdit" %>

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

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
</head>
<body>   
    <form id="form1" runat="server">
    <table width="480" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="30%" height="30" align="right">
                    <font color="red">*</font>省份：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="txtProvinceId" class="inputselect" name="txtProvinceId" valid="required"
                        errmsg="请选择省份!">
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <font color="red">*</font>城市：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="txtCityId" class="inputselect" name="txtCityId" valid="required" errmsg="请选择城市!">
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    县区：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="txtDistrictId" class="inputselect" name="txtDistrictId" <%--valid="required"
                        errmsg="请选择县区!"--%>>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="18%" height="30" align="right">
                    <font color="red">*</font>名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" name="txtName" id="txtName" class="inputtext" value="<%=Name %>" valid="required"
                        errmsg="请输入名称!" />
                </td>
            </tr>            
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="i_a_submit">保存</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    
    <script type="text/javascript">
        var iPage = {
            close: function() {
                parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
            },
            submit: function() {
                var _vF = ValiDatorForm.validator($("#i_a_submit").closest("form").get(0), "alert");
                if (!_vF) return false;
                var _data = $("#<%=form1.ClientID %>").serialize();

                $.ajax({
                    type: "POST", url: "dibiaoedit.aspx?dotype=submit&id=<%=DiBiaoId %>", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
                            iPage.reload();
                        }
                    }
                });
            }
        };

        $(document).ready(function() {
            pcToobar.init({ pID: "#txtProvinceId", cID: "#txtCityId", xID: "#txtDistrictId", pSelect: '<%=ProvinceId %>', cSelect: '<%=CityId %>', xSelect: '<%=DistrictId %>', comID: '1' });

            $("#i_a_submit").click(function() { iPage.submit(); });
        });
    </script>

</body>
</html>
