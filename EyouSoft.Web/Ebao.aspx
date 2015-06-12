<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="Ebao.aspx.cs" Inherits="EyouSoft.Web.Ebao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="n_title">> 关于E额宝</div>
    
      <div class="about_box margin_T10">
         <dl>
           
            <dd>
               <p>
                   <asp:Literal ID="LinkList" runat="server"></asp:Literal>
                   <asp:Literal ID="txtEbao" runat="server"></asp:Literal></p>
            </dd>
            <div style="text-align:center; padding-top:20px;">
                <asp:Literal ID="gotourl" runat="server"></asp:Literal></div>
         </dl>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
