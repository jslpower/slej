<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NavNum.aspx.cs" Inherits="EyouSoft.Web.WebMaster.NavNum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
        <tr class="odd"><td colspan="2" style="font-size:24px; height:70px; font-weight:bolder;" align="center">网站导航选择</td></tr>
            <tr class="odd">
                <th width="20%" height="30" align="right">
                    <input type="radio" name="radio" id="radio1" value="0" />统一网站导航：
                </th>
                <td width="80%" bgcolor="#E3F1FC" class="pandl3">
                    网站（包括手机、电脑和微信三个版本）首页、导航栏、促销秒杀和首页轮换广告，均显示旅游线路、门票、机票、酒店、租车和会员商城、E额宝等栏目产品， 例如——<a href="http://www.slej.cn/" target="_blank">http://www.slej.cn</a>  和 <a href="http://6148.slej.cn/" target="_blank">http://6148.slej.cn</a></span>
                </td>
            </tr>
            <tr class="odd">
                <th width="20%" height="30" align="right">
                   <input type="radio" name="radio" id="radio2" value="1" />自家网站导航：
                </th>
                <td width="80%" bgcolor="#E3F1FC" class="pandl3">
                   网站（包括手机、电脑和微信三个版本）首页、导航栏、促销秒杀和首页轮换广告，显示的内容都是我自己上传的产品内容，该网站就是我的专属智能网站，是完全属于我（单位）自己的智能专卖店，例如——<a href="http://8568.slej.cn/" target="_blank">http://8568.slej.cn</a>  和  <a href="http://4768.slej.cn/" target="_blank">http://4768.slej.cn</a>
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
                 url: "/WebMaster/NavNum.aspx?type=update",
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
