<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="joinus.aspx.cs" Inherits="EyouSoft.Web.joinus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="n_title">> 加入我们</div>
    
      <div class="about_box margin_T10">
         <dl>
            <dt><img src="images/join_01.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="FenXiao" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_02.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="GuiBing" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_03.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="PuTong" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_04.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="YingPing" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         <dl>
            <dt><img src="images/join_05.gif" /></dt>
            <dd>
               <p>
                   <asp:Literal ID="Gongying" runat="server"></asp:Literal></p>
            </dd>
         </dl>
         
         
      </div>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="Adv">
</asp:Content>
