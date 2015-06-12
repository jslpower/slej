<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectCustomer.ascx.cs" Inherits="EyouSoft.Web.WebMaster.UserControl.SelectCustomer" %>
<input type="text" id="<%=ClientText %>" class="inputtext formsize120" name="<%=ClientText %>" value="<%=this.Name %>"
    <%if(IsMust){ %><%=NoticeHTML %><%} %> />
<input type="hidden" id="<%=ClientValue %>" name="<%=ClientValue %>" value="<%=this.HideID %>" />
<a id="<%=btnID %>" class="Offers xuanyong" href="javascript:void(0);" <%=IsEnable?"":"style='display:none'" %>></a>


<script type="text/javascript">
    $(function() {
        $("#<%=btnID %>").click(function() {
            var url = "/WebMaster/SelectCustomer.aspx?";
            var hideObj = $("#<%=ClientValue %>");
            var showObj = $("#<%=ClientValue %>").attr("id");
            url += $.param({ callBack: "<%=CallBack %>", hideID:$("#"+showObj).val(),pIframeID: "<%=IframeID %>",routeid:"<%=RouteId %>" })
           parent.Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "选择游客",
                    modal: true,
                    width: "500",
                    height: "400"
                });
        })
        var isenable='<%=IsEnable %>';
        isenable= isenable.toLocaleLowerCase();
        if(isenable=="false"){
            $("#<%=btnID %>,#<%=ClientText %>").unbind("click");
        }
    });
    window["<%=ClientID %>"] = {
        _callBack: function(_data) {
            if (_data) {
                $("#<%=ClientText %>").val(_data.name);
                $("#<%=ClientValue %>").val(_data.id);
            }
        }
    };
</script>
