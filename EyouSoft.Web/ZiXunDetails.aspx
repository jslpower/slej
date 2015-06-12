<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ZiXunDetails.aspx.cs" Inherits="EyouSoft.Web.ZiXunDetails" %>
<%@ Register Src="~/UserControl/TuanGou.ascx" TagName="TuanGou" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Left" runat="server">
    <div class="leftbox">
        <!------L_side01-------->
        <div class="L_side01">
            <!------促销-------->
            <uc1:TuanGou runat="server" ID="TuanGou1" />
        </div>
        <!------searchbox-------->
        <div id="n4Tab" class="searchbox margin_T10">
            <div class="TabTitle">
                <ul>
                    <li class="active" onclick="nTabs('n4Tab',this);" id="n4Tab_Title0"><a href="javascript:void(0);">
                        <s class="hotel"></s><span>酒店</span></a></li>
                    <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title1"><a href="javascript:void(0);"><s
                        class="jipiao"></s><span>机票</span></a></li>
                    <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title2"><a href="javascript:void(0);"><s
                        class="menpiao"></s><span>门票</span></a></li>
                    <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title3"><a href="javascript:void(0);"><s
                        class="zuche"></s><span>租车</span></a></li>
                    <li style="border-right: 0;" onclick="nTabs('n4Tab',this);" id="n4Tab_Title4"><a
                        href="javascript:void(0);"><s class="qianzhen"></s><span>签证</span></a></li>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="TabContent">
                <div id="n4Tab_Content0">
                    <div id="n4Tab1" class="S_line_n4Tab">
                        <div class="S-line-TabTitle">
                            <ul>
                                <li class="active" onclick="nTabs('n4Tab1',this);" id="n4Tab1_Title0"><a href="javascript:void(1);">
                                    国内酒店</a></li>
                                <li onclick="nTabs('n4Tab1',this);" id="n4Tab1_Title1"><a href="javascript:void(1);">
                                    海外酒店</a></li>
                            </ul>
                        </div>
                        <div class="S-line-TabContent">
                            <div id="n4Tab1_Content0">
                                <div class="userbox">
                                    <ul>
                                        <li><span class="user-txt">目的地：</span><input type="text" value="城市/地区" class="inputbk formsize140"></li>
                                        <li><span class="user-txt">入住日期：</span><span class="date_style formsize140"><input
                                            type="text">
                                            <a href="#">
                                                <img src="images/rili.gif"></a></span></li>
                                        <li><span class="user-txt">退房日期：</span><span class="date_style formsize140"><input
                                            type="text">
                                            <a href="#">
                                                <img src="images/rili.gif"></a></span></li>
                                        <li><span class="user-txt">关键词：</span><input type="text" value="关键词" class="inputbk formsize140"></li>
                                        <li class="padd">
                                            <input type="button" class="s-btn" value="搜索&gt;&gt;"></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="none" id="n4Tab1_Content1">
                                海外酒店
                            </div>
                        </div>
                    </div>
                </div>
                <div class="none" id="n4Tab_Content1">
                    机票</div>
                <div class="none" id="n4Tab_Content2">
                    门票</div>
                <div class="none" id="n4Tab_Content3">
                    租车</div>
                <div class="none" id="n4Tab_Content4">
                    签证</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="server">
    <div class="rightbox">
        <div class="n_title">
            &gt; <asp:Literal ID="litzixuntype" runat="server"></asp:Literal></div>
        <div class="companyin">
            <h3>
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h3>
            <h5>
                发布时间：<asp:Label ID="lblTime" runat="server" Text=""></asp:Label></h5>
            <p>
                <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Literal ID="litFile" runat="server"></asp:Literal>
            </p>
        </div>
    </div>
</asp:Content>
