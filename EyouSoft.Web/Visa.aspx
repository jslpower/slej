<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="Visa.aspx.cs" Inherits="EyouSoft.Web.Visa" %>
<%@ Register Src="UserControl/XianLu.ascx" TagName="XianLu" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TravelTools.ascx" TagName="TravelTools" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/icore.css" rel="stylesheet" type="text/css" />
    <script src="JS/qianzheng.core.js" type="text/javascript"></script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

<div class="mainbox fixed">
    
       <div class="leftbox">
         <!------searchbox-------->
         <uc1:Search runat="server" ID="Search1" />
          
          <!------L_side01-------->
         <div class="L_side01 margin_T10">
            <!------促销-------->
            <uc1:TuanGou runat="server" ID="TuanGou1" />
            
            
         </div>
          
        <!------tool-------->
         <uc1:TravelTools runat="server" ID="TravelTools2" />

          
          
          <!------L_list-------->

                  <uc1:XianLu runat="server" ID="XianLu1" />
 
          
          
          
      </div>
    
       
      <div class="rightbox">

          <!------n_banner-------->
          <div class="banner n_banner" id="newsSlider">
    
            <div class="piclist">
                 <ul class="slides"> 
                   <%= toplist%>
                 </ul>
                      
                 <div class=validate_Slider></div>
                 <ul class=pagination>
                   <%= dianlist%>
                 </ul>
           </div>
         </div>

          <div class="qzh-search margin_T10">
            国家或地区：<input type="text" class="formsize140 input-style" id="txtGuoJiaName" name="txtGuoJiaName"/> 
            <input type="hidden" id="txtGuoJiaId" name="txtGuoJiaId" value='' />  
            
            签证类型：<select id="txtQianZhengLeiXing" name="txtQianZhengLeiXing" class="formsize100 input-style">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)),"","","请选择") %>
                        </select>
            <input type="button" value="搜索 >>" class="line-s-btn" id="linbtn" />
          </div>

          
          <div class="qzh_box margin_T10">
             <div class="qzh_area">亚洲签证</div>  
             <ul>
                 <asp:Repeater ID="YaZhou" runat="server">
                 <ItemTemplate>
                 <li><a href="VisaList.aspx?Guojiaid=<%# Eval("IdentityId")%>">
                 <img src="<%# Eval("FilePath")%>" />
                 <p><%# Eval("Name1")%></p></a></li>
                 </ItemTemplate>
                 </asp:Repeater>
             </ul>
             <div class="clear"></div>
          </div>
          
          <div class="qzh_box margin_T10">
             <div class="qzh_area">欧洲签证</div>  
             <ul>
                <asp:Repeater ID="OuZhou" runat="server">
                 <ItemTemplate>
                 <li><a href="VisaList.aspx?Guojiaid=<%# Eval("IdentityId")%>">
                 <img src="<%# Eval("FilePath")%>" />
                 <p><%# Eval("Name1")%></p></a></li>
                 </ItemTemplate>
                 </asp:Repeater>
             </ul>
             <div class="clear"></div>
          </div>
          
          <div class="qzh_box margin_T10">
             <div class="qzh_area">美洲签证</div>  
             <ul>
                <asp:Repeater ID="MeiZhou" runat="server">
                 <ItemTemplate>
                 <li><a href="VisaList.aspx?Guojiaid=<%# Eval("IdentityId")%>">
                 <img src="<%# Eval("FilePath")%>" />
                 <p><%# Eval("Name1")%></p></a></li>
                 </ItemTemplate>
                 </asp:Repeater>
             </ul>
             <div class="clear"></div>
          </div>
          
          <div class="qzh_box margin_T10">
             <div class="qzh_area">大洋洲签证</div>  
             <ul>
                <asp:Repeater ID="DaYang" runat="server">
                 <ItemTemplate>
                 <li><a href="VisaList.aspx?Guojiaid=<%# Eval("IdentityId")%>">
                 <img src="<%# Eval("FilePath")%>" />
                 <p><%# Eval("Name1")%></p></a></li>
                 </ItemTemplate>
                 </asp:Repeater>
             </ul>
             <div class="clear"></div>
          </div>
          
          <div class="qzh_box margin_T10">
             <div class="qzh_area">非洲签证</div>  
             <ul>
                <asp:Repeater ID="FeiZhou" runat="server">
                 <ItemTemplate>
                 <li><a href="VisaList.aspx?Guojiaid=<%# Eval("IdentityId")%>">
                 <img src="<%# Eval("FilePath")%>" />
                 <p><%# Eval("Name1")%></p></a></li>
                 </ItemTemplate>
                 </asp:Repeater>
             </ul>
             <div class="clear"></div>
          </div>

          
       </div><%--<div id="i_div_qianzhengguojia"></div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            }
        };
        $(document).ready(function() {
            qianZhengGuoJia.init({ txtName: 'txtGuoJiaName', txtId: 'txtGuoJiaId', left: 0, top: 4 });
        });

        $(function() {
            $("#linbtn").click(function() {
                var guojiaid = $("#txtGuoJiaId").val();
                var visacate = $("#txtQianZhengLeiXing").val();
                window.location.href = "/VisaList.aspx?Guojiaid="+guojiaid+"&visacate="+visacate;
                //                window.location.href = "/XianLu.aspx?" + $.param(data);
            })
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
