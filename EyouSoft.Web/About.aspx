<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="About.aspx.cs" Inherits="EyouSoft.Web.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="n_title"><a href="Baoming.aspx" class="btn001 wd"><span>报名网点</span></a>> 关于商旅e家</div>
    
      <div class="about_box margin_T10">
          <asp:Literal ID="SLEJ" runat="server"></asp:Literal>
      </div>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Adv">
</asp:Content>
