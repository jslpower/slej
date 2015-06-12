<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Webmaster.Master" AutoEventWireup="true" CodeBehind="DingDanEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.QianZheng.DingDanEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
        <link href="../../Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <table width="100%" border="0">
            <tr class="odd">
                <td style=" width:20%; height:30px;" align="right">
                    订单号:
                </td>
                <td style="width:30%; background-color:#E3F1FC;"  class="style1">
                    
             <%=DingDanInfo.DingDanHao%>
                </td>
                <td style=" width:20%; height:30px;"  align="right">下单时间：</td>
                <td style="width:30%; background-color:#E3F1FC;"   class="style1">  <%=DingDanInfo.IssueTime %></td>
            </tr>
            <tr class="odd">
                <td  style=" width:20%; height:30px;" align="right">
                    签证名称：
                </td>
                <td style="width:30%; background-color:#E3F1FC;"  >
                    <%=DingDanInfo.QianZhengName %>
                </td>
                <td  style=" width:20%; height:30px;"  align="right">签证国家：</td>
                <td style="width:30%; background-color:#E3F1FC;"  class="style1"> <%=GetGuoJiaName(DingDanInfo.QianZhengGuoJiaId)%></td>
            </tr>
            
            <tr class="odd">
                
                <td  style=" width:20%; height:30px;" align="right">
                     预订数量:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC">
                    <asp:Literal ID="txtYuDinShuLiang" runat="server"></asp:Literal>
                </td>
                <td  style=" width:20%; height:30px;" align="right">
                    预订单价:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC" class="style1">
                    <asp:Literal ID="txtYuDinDanjia" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
             <td  style=" width:20%; height:30px;" align="right">
                    结算费用:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC">
                    <span id="i_JinE">
                        <asp:Literal ID="zongjine" runat="server"></asp:Literal></span>
                </td>
               <td  style=" width:20%; height:30px;" align="right">
                    订单状态:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC" class="style1">
                    <asp:Literal ID="DingDanStatus" runat="server"></asp:Literal>
                </td>
            </tr>
            
            <%--<tr class="odd">
                <td  style=" width:20%; height:30px;" align="right">
                     付款状态:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC">
                    <%=DingDanInfo.FuKuanStatus %>
                </td>
                <td   style=" width:20%; height:30px;" align="right">付款时间： </td>
                <td style="width:30%;" ><%=fukuantime %></td>
            </tr>--%>
            <tr class="odd">
                <td  style=" width:20%; height:30px;" align="right">
                    联系人姓名:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC" class="style1">
                    <asp:Literal ID="txtLxrName" runat="server"></asp:Literal>
                </td>
                <td  style=" width:20%; height:30px;" align="right">
                    联系人电话:
                </td>
                <td style="width:30%;" bgcolor="#E3F1FC">
                    <asp:Literal ID="txtLxrDianHua" runat="server"></asp:Literal>
                </td>
            </tr>
             <tr class="odd">
                <td  style=" width:20%; height:30px;" align="right">
                    联系人地址:
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC">
                    <asp:Literal ID="txtLxrdizhi" runat="server"></asp:Literal>
                </td>
                <td  style=" width:20%; height:30px;" align="right">
                </td>
                <td style="width:30%;"  bgcolor="#E3F1FC" class="style1">
                </td>
            </tr>
            
            <tr class="odd">
                <td  style="width:20%;" align="right">
                    备注：
                </td>
                <td colspan="3">
                    <asp:Literal ID="txtbeizhu" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        
        <table >
            <tbody>
                
                
            </tbody>
            
        </table>
        <div style="float:right; padding-top:30px; padding-right:60px;"><a href="javascript:history.go(-1);" style="color:Blue">返回订单列表</a></div>
        <%--<table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="40" bgcolor="#E3F1FC" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td align="center" style="padding-right: 50px;" class="tjbtn02">
                                        <asp:Button ID="Button1" runat="server" Visible="false" Text="保存" onclick="Button1_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>--%>
        </form>
          <%--<script type="text/javascript">
              var iPage = {
                  //计算金额
                  heJi: function() {
                      var _danj = tableToolbar.getFloat($("#<%=txtYuDinDanjia.ClientID %>").val());
                      var _rens = tableToolbar.getInt($("#<%=txtYuDinShuLiang.ClientID %>").val());
                      var zongjia = tableToolbar.calculate(_danj, _rens, "*");
                      $("#i_JinE").html(zongjia);
                  }
              };
              $(document).ready(function() {
                  $("#<% =txtYuDinShuLiang.ClientID%>").change(function() { iPage.heJi(); });
                  iPage.heJi();
                  $("#<%=DropDownListDingDanStatus.ClientID %>").val("<%=(int)DingDanInfo.DingDanStatus %>");
              });
          </script>--%>
</asp:Content>
