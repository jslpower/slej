<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ZiXun.aspx.cs" Inherits="EyouSoft.Web.ZiXun" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
function nTabs(tabObj,obj){
	var tabList = document.getElementById(tabObj).getElementsByTagName("li");
	for(i=0; i <tabList.length; i++)
	{
		if (tabList[i].id == obj.id)
		{
			document.getElementById(tabObj+"_Title"+i).className = "active"; 
    		document.getElementById(tabObj+"_Content"+i).style.display = "block";
		}else{
			document.getElementById(tabObj+"_Title"+i).className = "normal"; 
			document.getElementById(tabObj+"_Content"+i).style.display = "none";
		}
	} 
}
    </script>
<script src="JS/ajaxpagecontrols.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <div class="leftbox">
        <!------L_side01-------->
        <div class="L_side01">
            <!------促销-------->
            <uc1:TuanGou runat="server" ID="TuanGou1" />
        </div>
        <!------searchbox-------->
        <uc1:Search ID="Search1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="rightbox">
        <div class="n_title">
            &gt; <%= ClassName%></div>
        <div class="zixun_mbox">
            <ul>
                <asp:Repeater ID="ZiXunList" runat="server">
                <ItemTemplate>
                <li><a href="ZiXunDetails.aspx?id=<%# Eval("ArticleID") %>"><span><%# Eval("IssueTime","{0:yyyy-MM-dd}")%></span><%# Eval("ArticleTitle")%></a></li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="page" id="page"></div>
        <script type="text/javascript">
        var pagingConfig = { pageSize: 40, pageIndex:<%=pageIndex %> , recordCount: <%= recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
        </script>
    </div>
</asp:Content>
