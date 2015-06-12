<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowHidden.aspx.cs" Inherits="EyouSoft.Web.WebMaster.ShowHidden" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
        <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    
    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>

</head>
<body>
    <form id="form1">
    <table width="90%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
        <tr class="odd"><td colspan="2" style="font-size:24px; height:70px; font-weight:bolder;" align="center">发展下级分销</td></tr>
            <tr class="odd">
                <th width="20%" height="30" align="right">
                    <input type="radio" name="radio" id="radio1" value="0" />显示代理申请：
                </th>
                <td width="80%" bgcolor="#E3F1FC" class="pandl3">
                    让客人可见我网站所有产品的贵宾价和代理价，经申请成为代理身份后，永远都是我的下级代理，我可以获取发展该代理的佣金，还可以获取该下级代理销售利润一定比例的由总部发放的奖金。下级代理越多，我的发展佣金越多，奖金越高！<span style="color:Red">(注：只推广一级，奖金是从总部获得，网站有丰富的产品，不属于传销！)</span>
                </td>
            </tr>
            <tr class="odd">
                <th width="20%" height="30" align="right">
                   <input type="radio" name="radio" id="radio2" value="1" />隐藏代理申请：
                </th>
                <td width="80%" bgcolor="#E3F1FC" class="pandl3">
                   不让客人见到我网站产品的贵宾价和代理价，直接赚取我网站所有产品的代理利润！（包括我供应的商品、别的商家供应的商品和所有旅游产品） 
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn" hidefocus="true" runat="server">保存</a>
                                </td>
                                <td width="96" height="40" align="center" class="tjbtn02" style="padding-right: 50px;">
                                        <a href="javascript:history.go(-1);">返回</a>
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
        $(document).ready(function() {
            var show = "<%=show %>";
            if (show == "0") {
                $("#radio1").attr("checked", 'checked');
            }
            else {
                $("#radio2").attr("checked", 'checked');
             }
         });
         $("#btn").click(function() {
             $.ajax({
                 type: "post",
                 cache: false,
                 url: "/WebMaster/ShowHidden.aspx?type=update",
                 dataType: "json",
                 data: $("#form1").serialize(),
                 success: function(ret) {
                     if (ret.result == "1") {
                         alert(ret.msg);
                         parent.location.href = parent.location.href;
                     }
                     else {
                         alert(ret.msg);
                         parent.location.href = parent.location.href;
                     }
                 },
                 error: function() {
                     alert("保存失败，请重试！");
                     parent.location.href = parent.location.href;
                 }
             });
         });
    </script>
</body>
</html>
