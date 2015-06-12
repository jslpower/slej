<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisaBox.aspx.cs" Inherits="EyouSoft.Web.VisaBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/foucs.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>
    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $(".tchuang tr:even").addClass("tb_even");
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style=" display:none;">
    <asp:Literal ID="FenxiaoJia" runat="server"></asp:Literal>
        <asp:Literal ID="QianZhengId" runat="server"></asp:Literal>
    </div>
    <table width="100%"  class="tchuang"> 
    <tr>
    <td align="right">
    签证名称：
    </td>
    <td>
        <asp:Literal ID="VisaName" runat="server"></asp:Literal>
    </td>
    <td align="right">
    预定日期：
    </td>
    <td>
        <asp:Literal ID="YudingShiJian" runat="server"></asp:Literal>
    </td>
    </tr>
    <tr>
    <td align="right">
    签证国家：
    </td>
    <td>
        <asp:Literal ID="VisaGuojia" runat="server"></asp:Literal>
    </td>
    <td align="right">
    预定数量：
    </td>
    <td>
        <asp:Literal ID="YuDingShuLiang" runat="server"></asp:Literal>
    </td>
    </tr>
    <tr>
    <td align="right">
    单价：
    </td>
    <td>
        ￥<asp:Literal ID="DanJia" runat="server"></asp:Literal>
    </td>
    <td align="right">
    总价：
    </td>
    <td>
        ￥<asp:Literal ID="ZongJIa" runat="server"></asp:Literal>
    </td>
    </tr>
    <tr>
    <td align="right">
    <span style="color:Red">* </span> 联系人：
    </td>
    <td>
        <input id="lxrname" name="lxrname" class="inputbk" style="width:200px" type="text"  valid="required|isName"
                        errmsg="姓名不能为空|请正确填写姓名!"/>
    </td>
    <td align="right">
    <span style="color:Red">* </span> 联系人手机：
    </td>
    <td>
        <input id="lxrmobile" name="lxrmobile" class="inputbk" style="width:200px" type="text"  valid="required|isMobile" errmsg="请输入手机号码!|请输入正确的手机号码"/>
    </td>
    </tr>
    <tr>
    <td align="right">
    备注：
    </td>
    <td colspan="3">
        <textarea id="beizhu" name="beizhu" cols="20" rows="4" style="width:450px";></textarea>
    </td>
    </tr>
    </table>
    <div style="text-align:center">
    <a href="#" class="loginbtn" id="tijiao">确认提交</a>
        <%--<input id="tijiao" type="button" value="提交"  class="loginbtn"/>--%></div>
    </div>
    </form>
    <script type="text/javascript">
        var PageOrder = {
            CheckForm: function() {
                return ValiDatorForm.validator($("#tijiao").closest("form").get(0), "alert")
            },
            subit: function() {
                               var url = "/VisaBox.aspx?dotype=save";
                               $.newAjax({
                                   type: "post",
                                   cache: false,
                                   url: url,
                                   dataType: "json",
                                   data: $("#tijiao").closest("form").serialize(),
                                   success: function(ret) {
                                       if (ret.result == "1") {
                                           tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                                       }
                                       else {
                                           tableToolbar._showMsg(ret.msg);
                                       }
                                   },
                                   error: function() {
                                       tableToolbar._showMsg(tableToolbar.errorMsg);
                                   }
                               });
            },
        };
    
    
        $("#tijiao").click(function() {
          if (PageOrder.CheckForm()) { PageOrder.subit(); }

        });
    </script>
</body>
</html>
