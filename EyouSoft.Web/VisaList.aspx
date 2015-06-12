<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="VisaList.aspx.cs" Inherits="EyouSoft.Web.VisaList" %>
<%@ Register Src="UserControl/XianLu.ascx" TagName="XianLu" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="JS/ajaxpagecontrols.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="mainbox fixed">
    
       <div class="leftbox">
         <!------searchbox-------->
         <uc1:Search runat="server" ID="Search1" />
          
          
          <!------L_list-------->
          <div class="L_list line_list margin_T10">

                 <uc1:XianLu runat="server" ID="XianLu1" />
          </div>
          
          
          
      </div>
    
       
      <div class="rightbox">
          <div class="n_title">> 出国签证</div>
          
          <div class="qzh_listbox margin_T10">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <th>&nbsp;</th>
                <th width="95" align="right">门市价</th>
                <th width="95" align="right">会员价</th>
                <th width="128">&nbsp;</th>
              </tr>
          </table>

          <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="tr_bg">
              <asp:Repeater ID="QianZheng" runat="server">
              <ItemTemplate>
              <tr>
                <td><a href="VisaXX.aspx?visaid=<%# Eval("QianZhengId")%>" class="biaoti"><%# Eval("Name")%></a></td>
                <td width="95" align="right"><span class="font18 fontblue">¥<%# Convert.ToInt32(Eval("JiaGeMenShi"))%></span></td>
                <td width="95" align="right"><span class="font18 font_yellow">¥<%# getPuTongJia(Eval("JiaGe"), Eval("JiaGeMenShi"))%></span></td>
                <td width="120" align="center"><a href="VisaXX.aspx?visaid=<%# Eval("QianZhengId")%>" class="yudin_btn"><span>立即预订</span></a></td>
            </tr>
              </ItemTemplate>
              </asp:Repeater>
              <asp:Literal ID="TiShi" runat="server"></asp:Literal>
          </table>

          </div>
          
          <div class="page" id="page"></div>      
          
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
 <script type="text/javascript">
        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%= recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
        </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
