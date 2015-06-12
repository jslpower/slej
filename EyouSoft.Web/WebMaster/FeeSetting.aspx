<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebMaster/Ref.Master"
    CodeBehind="FeeSetting.aspx.cs" Inherits="EyouSoft.Web.FeeSetting" %>

<asp:Content runat="server" ContentPlaceHolderID="title">
    <title>费用提价设置</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .button2
        {
            background-image: url(/Images/SK_B_02[1].gif);
            border-bottom: 0px;
            text-align: center;
            border-left: 0px;
            background-color: #cfe7fd;
            width: 79px;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            height: 22px;
            color: #fff;
            font-size: 11px;
            border-top: 0px;
            border-right: 0px;
            padding-top: 2px;
            cursor: hand;
        }
        .button2_1
        {
            background-image: url(/Images/SK_B_02_2[1].gif);
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="content">
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="900" cellspacing="1" border="0" bgcolor="#BDDCF4" align="center">
            <tr>
                <td align="center">
                    <%foreach (var type in Enum.GetValues(typeof(FeeTypes)))
                      {
                           %>
                    <input class="button2<%=((FeeTypes)type==Model.LeiBie? " button2_1":"")%>" value="<%=type %>"
                        onclick="instance.SwitchType('<%=type %>')" type="button" />
                    <%
                      } %>
                </td>
            </tr>
        </table>
        <%=Html.HiddenFor(x=>x.LeiBie) %>
                        <%=Html.HiddenFor(x => x.ID)%>
        <table width="900" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
            <tbody>
                <tr>
                    <td height="35"  width="30%" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>普通会员提升比：</strong>
                    </td> 
                    <td height="35"  width="70%"  align="left" bgcolor="#FAFDFF" class="pandl3">
                        <%=Html.TextBoxFor(x => x.PuTongHuiYuanJia, new { size = 16, @class = "inputtext", valid = "required", errmsg = "普通会员价提升比必填项" })%>%
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>免费分销价提升比：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <%=Html.TextBoxFor(x => x.FreeFenXiaoJia, new { size = 16, @class = "inputtext", valid = "required", errmsg = "协议价提升比必填项" })%>%
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>贵宾会员提升比：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <%=Html.TextBoxFor(x => x.GuiBinJia, new { size = 16, @class = "inputtext", valid = "required", errmsg = "贵宾价提升比必填项" })%>%
                    </td>
                </tr>
                                
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>分销价提升比：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <%=Html.TextBoxFor(x => x.FenXiaoJia, new { size = 16, @class = "inputtext", valid = "required", errmsg = "协议价提升比必填项" })%>%
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>员工提价比：</strong>
                    </td>
                    <td height="35" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <%=Html.TextBoxFor(x => x.YuanGongJia, new { size = 16, @class = "inputtext", valid = "required", errmsg = "成本价提升比必填项" })%>%
                    </td>
                </tr>
                <tr>
                    <td height="40" align="center" colspan="2" class="tjbtn02">
                        <input class="button2" onclick="instance.Save(this);" value="保 存" type="button" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="foot">

    <script type="text/javascript">
        var instance2 = new InitialPageInputTagValue();
    
        var instance = new PageSubmitForm();

        instance.SwitchType = function(name) {
            instance2.Search({ LeiBie: name, 'searchinfo.showmode': 'update' });
        };

        instance.Save = function(btn) {
            if (!instance.Validate()) {
                return;
            }
            instance.SetButtonUnableClick(btn, '提交中...');
            $.newAjax({
                type: "post",
                cache: false,
                url: "/WebMaster/FeeSetting.aspx",
                dataType: "json",
                data: $('form').serialize() + '&searchinfo.editmode=update',
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() {
                            instance.SetButtonEnableClick(btn);
                        });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg, function() { });
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg, function() { });
                }
            });
        };
    </script>

</asp:Content>
