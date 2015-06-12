<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.FeedbackEdit" %>
<%@ Register TagPrefix="uc1" TagName="UploadControl" Src="~/UserControl/UploadControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增</title>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/swfupload/swfupload.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="95%" border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <th width="140" height="50"><span class="f00">*</span> 留言类型：</th>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>建议与意见</asp:ListItem>
                        <asp:ListItem>内容纠错</asp:ListItem>
                        <asp:ListItem>商务合作</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:RadioButtonList>
                  </td>
                  
              </tr>
              <tr>
                <th rowspan="2" valign="top"><span class="f00">*</span> 留言内容：                </th>
                <td height="100" valign="top">
                    <asp:TextBox ID="textarea" runat="server" Height="96px" TextMode="MultiLine" 
                        Width="368px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td height="22" style="color:#b0afaf;">(请详细描述您在使用时遇到的问题，以便我们及时处理。500汉字以内)</td>
              </tr>
              <tr>
                <th height="35">&nbsp;</th>
                <td style="color:#ff6600;">请输入有效的联系方式，以便尽快给您回复！</td>
              </tr>
              <tr>
                <th height="35">姓名：</th>
                <td><asp:TextBox 
                        ID="textfield" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <th height="35">邮箱：</th>
                <td><asp:TextBox 
                        ID="textfield2" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <th height="35">手机：</th>
                <td><asp:TextBox 
                        ID="textfield3" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <th height="35">&nbsp;</th>
                  <td>   <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center" class="style1">
                    <asp:Button ID="Button1" runat="server" Height="31px" Text="保存" Width="108px" 
                        onclick="Button1_Click" />
                </td>
                <td height="40" align="center" class="tjbtn02">
                  
                    <asp:Button ID="Button2" runat="server" Height="27px" Text="关闭" Width="109px" 
                        onclick="Button2_Click" />
                  
                </td>
                <td height="40" align="center" class="tjbtn02">
                    
                </td>
            </tr>
        </tbody>
    </table>
                  </td>
              </tr>
            </table>

    </form>
</body>
</html>
