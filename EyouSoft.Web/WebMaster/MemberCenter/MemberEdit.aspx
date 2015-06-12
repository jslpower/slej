<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="MemberEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.MemberCenter.MemberEdit" %>

<%@ Import Namespace="Linq.Web" %>
<%@ Register Src="/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor.js"></script>

    <script type="text/javascript">
        function Isfen() {
            var type = $("#UserType").val();
            if (type == 3 || type == 4 || type == 5) {
                $("#isbool1").css('display', '');
                $("#isbool2").css('display', '');
                $("#isbool3").css('display', '');
                $("#isbool4").css('display', '');
                $("#isbool5").css('display', '');
                $("#isbool7").show();
                $("#isbool6").show();
            }
            else {
                $("#isbool1").css('display', 'none');
                $("#isbool2").css('display', 'none');
                $("#isbool3").css('display', 'none');
                $("#isbool4").css('display', 'none');
                $("#isbool5").css('display', 'none');
                $("#isbool6").hide();
                $("#isbool7").hide();
            }
            $("#UserTypeH").val(type);
         }
         window.onload = function(){
         var isadd = <%= isAdd%>;//是否为新增
         if(isadd==0)
         {
         $("#UserType").val(4);
         Isfen();
         }
         var issee = <%= IsSee%>;//是否为查看
         var istype = <%= istype%>;//是否为分销商 1-分销商
         if(issee==1)
         {
           if(istype==1)
           {
                $("#isbool1").css('display', '');
                $("#isbool2").css('display', '');
                $("#isbool3").css('display', '');
                $("#isbool4").css('display', '');
                $("#isbool5").css('display', '');
                $("#isbool6").show();
                $("#isbool7").show();
           }
           document.getElementById("Remark").disabled = "disabled";
           document.getElementById("UserType").options[<%= usertype%>-1].selected = true;  
         }
         else if(issee==2)
         {
           if(istype==1)
           {
                $("#isbool1").css('display', '');
                $("#isbool2").css('display', '');
                $("#isbool3").css('display', '');
                $("#isbool4").css('display', '');
                $("#isbool5").css('display', '');
                 $("#isbool6").show();
                 $("#isbool7").show();
           }
           document.getElementById("UserType").options[<%= usertype%>-1].selected = true;  
         }
         }
    </script>

    <script type="text/javascript">
        $(function() {
            $('#Account').blur(function() {
                var str = $(this).val();
                if (str != '') {
                    $('#Mobile').val(str);
                }
                if (str != '' && str.length > 6) {
                    var website1 = $('#WebSite').val();
                    if (website1 == '') {
                        $('#WebSite').val(str.substr(str.length - 4));
                    }
                }
            });
            $('#Mobile').blur(function() {
                var str = $(this).val();
                if (str != '' && str.length > 6) {
                    var website1 = $('#WebSite').val();
                    if (website1 == '') {
                        $('#WebSite').val(str.substr(str.length - 4));
                    }
                }
            });
        }) 
    </script>

<style type="text/css">
.file_a{ background:#00aee7; border:#008dce solid 1px; border-radius:4px; color:#fff; cursor:pointer; display:inline-block; width:120px;height:26px; line-height:26px; overflow:hidden; text-align:center; text-decoration:none; position:relative; zoom:1;}
.file_a input{ 	filter:alpha(opacity=0);filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=0);opacity: 0;position: absolute;right: 0;top:0;cursor: pointer;outline:none;height:100%;width: 200%;}
</style>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div>
        <table width="99%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
            <tbody>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>账号：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="Account" runat="server" CssClass="inputtext" value="请输入手机号" onfocus="javascript:if(this.value=='请输入手机号')this.value='';"
                            onblur="javascript:if(this.value=='')this.value='请输入手机号';" ForeColor="#999999"
                            valid="required|isMobile" errmsg="帐号不能为空!|帐号必须为手机号码!"></asp:TextBox>
                        <%--<%=Html.TextBoxFor(x=>x.Account) %>--%>
                        <%=Html.HiddenFor(x=>x.MemberID) %>
                    </td>
                    <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>姓名：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="UMemberName" runat="server" CssClass="inputtext" valid="required|isName"
                            errmsg="姓名不能为空|请填写正确的姓名,不能有数字!"></asp:TextBox>
                        <%--<%=Html.TextBoxFor(x=>x.MemberName) %>--%>
                    </td>
                    <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>密码：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="UPassWord" runat="server" CssClass="inputtext"></asp:TextBox>
                        <%--<%=Html.TextBoxFor(x=>x.PassWord) %>--%>
                    </td>
                    <th width="10%" height="30" align="right">
                        E额宝支付密码：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="ZhiFuPassword" runat="server" CssClass="inputtext"></asp:TextBox>
                        <%--<%=Html.TextBoxFor(x => x.ZhiFuPassword, new { valid = "required", errmsg = "支付密码不能为空" })%>--%>
                    </td>
                </tr>
                <tr class="odd">
                <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>状态：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:DropDownList ID="MemberState" runat="server" CssClass="inputselect">
                            <asp:ListItem Value="1">启用</asp:ListItem>
                            <asp:ListItem Value="2">黑名单</asp:ListItem>
                            <asp:ListItem Value="3">已停用</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <th width="10%" align="right">
                        <span style="color: red">*</span>用户类型：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select id="UserType" name="UserType" onchange="Isfen()" class="inputselect">
                            <option value="1">普通用户</option>
                            <option value="2">贵宾用户</option>
                            <option value="3">免费代理</option>
                            <option value="4">代理</option>
                            <option value="5">员工</option>
                        </select>
                        <input id="UserTypeH" runat="server" type="hidden" value="4" />
                    </td>
                    <th width="10%" align="right">
                        有效日期：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txt_validDate" onfocus="WdatePicker()" runat="server" CssClass="inputtext"
                            valid="isDate" errmsg="请正确填写生日!"></asp:TextBox>
                    </td>
                    <th width="10%" align="right">
                        账户金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="TotalMoney" runat="server" CssClass="inputtext" Text="0"></asp:TextBox>
                    </td>
                   
                   
                </tr>
                <tr class="odd">
                    <th width="10%" align="right">
                        性别：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:RadioButtonList ID="Gender" runat="server" RepeatColumns="3" Width="120px">
                            <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                            <asp:ListItem Value="1">女</asp:ListItem>
                        </asp:RadioButtonList>
                        <%-- <%=Html.DropDownListFor(x => x.Gender, new SelectListItem { Text="请选择",  })%>--%>
                    </td>
                    
                    <th width="10%" align="right">
                        生日：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="BirthDate" onfocus="WdatePicker()" runat="server" CssClass="inputtext"
                            valid="isDate" errmsg="请正确填写生日!" Text="1910-01-01"></asp:TextBox>
                    </td>
                    <th width="10%" align="right">
                        证件类型：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:DropDownList ID="CardType" runat="server" CssClass="inputselect">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">身份证</asp:ListItem>
                            <asp:ListItem Value="2">护照</asp:ListItem>
                            <asp:ListItem Value="3">军官证</asp:ListItem>
                            <asp:ListItem Value="4">台胞证</asp:ListItem>
                            <asp:ListItem Value="5">港澳通行证</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <th width="10%" height="30" align="right">
                        证件号：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:TextBox ID="CardNo" runat="server" CssClass="inputtext"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" align="right">
                        <span style="color: red">*</span>手机：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="Mobile" runat="server" CssClass="inputtext" valid="required|isMobile"
                            errmsg="手机不能为空!|请正确填写手机号码!"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        电话：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:TextBox ID="Contact" runat="server" CssClass="inputtext" valid="isTel" errmsg="请正确填写电话号码!"></asp:TextBox>
                    </td>
                    <th width="10%" align="right">
                        qq：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="qq" runat="server" CssClass="inputtext" valid="isQQ" errmsg="请正确填写QQ号码!"></asp:TextBox>
                    </td>
                    <th width="10%" align="right">
                        微信号：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="WeiXin" CssClass="inputtext" MaxLength="15" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        Email：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:TextBox ID="Email" runat="server" CssClass="inputtext" valid="isEmail" errmsg="请正确填写Email!"></asp:TextBox>
                    </td>
                    <th width="10%" align="right">
                        Fax：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="Fax" runat="server" CssClass="inputtext" valid="isTel" errmsg="请正确填写Fax号码!"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        注册时间：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:Label ID="RegisterTime" runat="server"></asp:Label>
                    </td>
                     <th width="10%" height="30" align="right"></th>
                    <td width="15%" bgcolor="#E3F1FC" id="Td_ChbLankId">  </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        头像：
                    </th>
                    <td colspan="3" height="30" bgcolor="#E3F1FC">
                        <uc2:UploadControl ID="UploadControl1" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true" IsUploadMore="false" runat="server" />
                        <asp:Literal ID="lbUploadInfo" runat="server"></asp:Literal>
                    </td>
                    <th width="10%" height="30" align="right">
                        <span style="color: red">*</span>地址：
                    </th>
                    <td colspan="3" bgcolor="#E3F1FC" align="left">
                        <asp:TextBox ID="Address" runat="server" MaxLength="80" Width="450px" CssClass="inputtext"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="10%" height="30" align="right">
                        备注信息：
                    </th>
                    <td colspan="7" height="30" bgcolor="#E3F1FC">
                        <textarea id="Remark" cols="50" rows="3" style="width: 600px; height: 40px" runat="server"
                            class="inputtext"></textarea>
                    </td>
                </tr>
                <tr id="isbool1" style="display: none" class="odd">
                    <th width="10%" height="30" align="right">
                        网点名称：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:TextBox ID="WebSiteName" runat="server" CssClass="inputtext"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        网点域名：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:TextBox ID="WebSite" runat="server" Width="100px" ToolTip="不填写则为手机后四位" CssClass="inputtext"></asp:TextBox>.slej.cn
                    </td>
                    <th width="10%" height="30" align="right">
                        许可证号：
                    </th>
                    <td height="30" bgcolor="#E3F1FC">
                        <asp:TextBox ID="XuKeZhengHao" runat="server" CssClass="inputtext"></asp:TextBox>
                    </td>
                    <th height="30" align="right">
                        地图信息：
                    </th>
                    <td bgcolor="#E3F1FC" align="left">
                        <a id="Setmap" href="javascript:;">地图信息</a> (<label id="X" runat="server"></label>,<label
                            id="Y" runat="server"></label>)
                        <asp:HiddenField runat="server" ID="jingdu" />
                        <asp:HiddenField runat="server" ID="weidu" />
                    </td>
                </tr>
                <tr id="isbool2" style="display: none" class="odd">
                    <th width="10%" height="30" align="right">
                        拥有权限：
                    </th>
                    <td colspan="7" height="30" bgcolor="#E3F1FC">
                        <asp:CheckBoxList ID="QuanXian" runat="server" RepeatColumns="5" Width="650px">
                            <asp:ListItem Value="1">周边短线</asp:ListItem>
                            <asp:ListItem Value="2">国内长线</asp:ListItem>
                            <asp:ListItem Value="3">国际长线</asp:ListItem>
                            <asp:ListItem Value="4">酒店预定</asp:ListItem>
                            <asp:ListItem Value="5">优惠门票</asp:ListItem>
                            <asp:ListItem Value="6">机票预订</asp:ListItem>
                            <asp:ListItem Value="7">汽车包租</asp:ListItem>
                            <asp:ListItem Value="8">会员商城</asp:ListItem>
                            <asp:ListItem Value="9">自传签证(<span style=" color:Red;">如未打勾则为佰程签证</span>)</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="isbool3" style="display: none" class="odd">
                    <th width="10%" height="30" align="right">
                        客服姓名：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="SLName" runat="server" CssClass="inputtext"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        客服电话：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="SLTel" runat="server" CssClass="inputtext"></asp:TextBox>
                        <%--<%=Html.TextBoxFor(x=>x.MemberName) %>--%>
                    </td>
                    <th width="10%" height="30" align="right">
                        客服手机：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="SLMOblie" runat="server" CssClass="inputtext"></asp:TextBox>
                        <%--<%=Html.TextBoxFor(x=>x.PassWord) %>--%>
                    </td>
                    <th width="10%" height="30" align="right">
                        客服微信：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="SLWeiXin" runat="server" MaxLength="15" CssClass="inputtext"></asp:TextBox>
                    </td>
                </tr>
                <tr id="isbool4" style="display: none" class="odd">
                    <th width="10%" height="30" align="right">
                        客服QQ：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="SLQQ" runat="server" CssClass="inputtext"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right">
                        客服头像：
                    </th>
                    <td width="65%" bgcolor="#E3F1FC" colspan="5">
                        <uc2:UploadControl ID="UploadControl2" FileTypes="*.jpg;*.gif;*.jpeg;*.png" IsUploadSelf="true"
                            IsUploadMore="false" runat="server" />
                        <asp:Literal ID="lbjinao" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr id="isbool5" style="display: none" class="odd">
                    <th width="10%" height="30" align="right">
                        公司全称：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC">
                        <asp:TextBox ID="CompanyName" runat="server" CssClass="inputtext"></asp:TextBox>
                        <asp:HiddenField ID="NavNum" runat="server" />
                    </td>
                    <th width="10%" height="30" align="right">
                        公司简称：
                    </th>
                    <td width="15%" bgcolor="#E3F1FC" colspan="5">
                        <asp:TextBox ID="CompanyJC" runat="server" CssClass="inputtext"></asp:TextBox>
                    </td>
                    <th width="10%" height="30" align="right"></th>
                    <td width="15%" bgcolor="#E3F1FC" colspan="5"></td>
                    <th width="10%" height="30" align="right"></th>
                    <td width="15%" bgcolor="#E3F1FC" colspan="5"></td>
                </tr>
                <tr id="isbool7" style="display: none" class="odd">
                    <th height="30" align="right"width="10%">
                        公司介绍：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="7">
                        <asp:TextBox runat="server" ID="txtContent" class="editText"></asp:TextBox>
                    </td>
                </tr>
                <tr id="isbool6" style="display: none" class="odd">
                    <th height="30" align="right">
                        上级代理商：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:Literal runat="server" ID="ltrShangJiDaiLiShangName">无</asp:Literal>
                    </td>
                    <th align="right">
                        他的粉丝：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:Literal runat="server" ID="ltrFenSi">暂无下级代理</asp:Literal>
                    </td>
                </tr>
    </div>
    </tbody> </table>
    <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <% if (Model.SearchInfo.ShowMode != Linq.Bussiness.ShowMode.Show)
               { %>
            <td height="40" style="padding-left: 25%;" align="center" class="tjbtn02">
                <%=Html.HiddenFor(x=>x.SearchInfo.EditMode) %>
                <a href="javascript:;" onclick="instance.save();">保存</a>
            </td>
            <%} %>
            <td height="40" style="padding-left: 25%;" align="center" class="tjbtn02">
                <a href="javascript:history.go(-1);">返回</a>
            </td>
        </tr>
    </table>
    </div>
    <br /><br />
    </form>

    <script type="text/javascript">

        var instance = new PageSubmitForm();

        instance.save = function() {
            if (!instance.Validate()) {
                return;
            }
            KEditer.sync();

            $.newAjax({
                type: "post",
                cache: false,
                url: '/webmaster/MemberCenter/MemberEdit.aspx?memberid='+$("input[name=MemberID]").val(),
                dataType: "json",
                data: $('form').serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() {
                        window.parent.frames.mainFrame.location.href = '/WebMaster/MemberCenter/MemberList.aspx'
                        });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg);
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
            
            
            
            
            
//            $.get('/webmaster/MemberCenter/MemberEdit.aspx', $('form').serialize(), function(ret) {
//            if (ret.result == "1") {
//                tableToolbar._showMsg(ret.msg, function() { window.parent.frames.mainFrame.location.href = '/WebMaster/MemberCenter/MemberList.aspx' });
//                }
//                else {
//                    tableToolbar._showMsg(ret.msg);
//                }
//            }, 'json');
        };


        var iPage = {
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DelImg: function(obj) {
                $(obj).parent().prev("img").remove();
                $(obj).parent().remove();
            },
            InitEdit: function() {
                $("#isbool7").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        items: keSimple_HaveImage,
                        height: $(this).attr("data-height") == undefined ? "360px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "680px" : $(this).attr("data-width")
                    });
                });
            }
        }
        $(document).ready(function() {
        iPage.InitEdit();
        });
    </script>

    <script type="text/javascript">
        //设置公司经纬度
        $("#Setmap").click(function() {

            var data = { weidu: $("#weidu").val(), jindu: $("#jingdu").val() };
            var url = "/WebMaster/ScenicAndTicketManage/SetGoogleMap.aspx?" + $.param(data);
            var title = "设置地图";
            Boxy.iframeDialog({ title: title, iframeUrl: url, height: 480, width: 800, modal: true,
                draggable: false
            });
            return false;
        });
    </script>

</body>
</html>
