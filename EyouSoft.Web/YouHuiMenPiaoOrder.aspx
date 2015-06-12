<%@ Page Title="景区门票订单" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="YouHuiMenPiaoOrder.aspx.cs" Inherits="EyouSoft.Web.YouHuiMenPiaoOrder" %>

<%@ Import Namespace="EyouSoft.Web" %>
<%@ Import Namespace="EyouSoft.BLL.HotelStructure" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .tixing { line-height: 30px; }
        .style1 { height: 523px; }
        .style2 { height: 47px; }
        .style3 { height: 139px; }
    </style>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox">
    <form method="post" id="menpiaoorderform">
        <div id="istijiao"  class="line_xx_box">
            <table width="908" border="0" class="tchuang">
                <tr class="tb_even">
                    <th width="120px" align="right">
                        景区名称&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td width="780px" colspan="5" align="left">
                        <%=Model.AreaInfo.ScenicName %>
                        <%=Html.HiddenFor(x=>x.TicketsId) %>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        门票类型&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td colspan="5" align="left">
                        <%=Model.TicketInfo.TypeName %>
                    </td>
                </tr>
                <tr class="tb_even">
                    <th align="right">
                        相关价格&nbsp;&nbsp;&nbsp;&nbsp;：
                    </th>
                    <td colspan="5" align="left">
                        &nbsp;¥<%=Model.CurrentPrice.ToString("0") %>
                    </td>
                </tr>
                <tr class="jiage">
                    <td colspan="6" align="center">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="price_table">
                            <tr>
                                <th class="Rline">
                                    &nbsp;
                                </th>
                                <th class="Rline">
                                    挂牌价
                                </th>
                                <th class="Rline">
                                    网络零售价
                                </th>
                                <%if (IsShowHuiYuan())
                                  { %>
                                <th class="Rline">
                                    会员价
                                </th>
                                <%} %>
                                 <%if (IsShowErJiDaiLi())
                                  { %>
                                <th class="Rline">
                                    代销价
                                </th>
                                <%} %>
                                <%if (IsShowGuiBin())
                                  { 
                                %>
                                <th class="Rline">
                                    贵宾价
                                </th>
                                <%} %>
                                <%if (IsShowDaiLi())
                                  { %>
                                <th class="Rline">
                                    代理价
                                </th>
                                <%} %>
                                <%if (IsShowYuanGong())
                                  { %>
                                <th>
                                    员工价
                                </th>
                                <%} %>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <b class="fontblue">¥<strike><%=Model.TicketInfo.RetailPrice.ToString("0")%></strike></b>
                                </td>
                                <td>
                                    <b class="fontblue">¥<strike><%=Model.TicketInfo.WebsitePrices.ToString("0")%></strike></b>
                                </td>
                                <%if (IsShowHuiYuan())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.普通会员, Model.FeeSetting, FeeTypes.门票).ToString("0")%></b>
                                </td>
                                <%} %>
                                <%if (IsShowErJiDaiLi())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.免费代理, Model.FeeSetting, FeeTypes.门票).ToString("0")%></b>
                                </td>
                                <%} %>
                                <%if (IsShowGuiBin())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.门票)).ToString("0")%></b>
                                </td>
                                <%} %>
                                <%if (IsShowDaiLi())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.代理, Model.FeeSetting, FeeTypes.门票).ToString("0")%></b>
                                </td>
                                <%} %>
                                <%if (IsShowYuanGong())
                                  { %>
                                <td>
                                    <b class="fontblue">¥<%=BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.员工, Model.FeeSetting, FeeTypes.门票).ToString("0")%></b>
                                </td>
                                <%} %>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="tb_even">
                    <th align="right" class="style3">
                        <span class="fontred">*</span>&nbsp;取票人姓名：
                    </th>
                    <td colspan="3" align="left" class="style3">
                        <%=Html.TextBoxFor(x => x.ContactName , new { size = "15", @class = "tc_inputbk formsize100", valid = "required", errmsg = "取票人姓名不能为空" })%>
                    </td>
                    <th align="right" class="style3">
                        <span class="fontred">*</span>&nbsp;取票人手机：
                    </th>
                    <td align="left" class="style3">
                        <%=Html.TextBoxFor(x => x.ContactTel, new { size = "15", @class = "tc_inputbk formsize100", valid = "required", errmsg = "取票人手机号不能为空" })%>
                    </td>
                </tr>
                <tr>
                    <th align="right" class="style1">
                        预定人姓名：
                    </th>
                    <td align="left" class="style1">
                        <%=Model.OperatorName %>
                        <%=Html.HiddenFor(x => x.OperatorName)%>
                        <%=Html.HiddenFor(x=>x.OperatorId) %>
                        <%=Html.HiddenFor(x=>x.CurrentPrice) %>
                        <%=Html.HiddenFor(x=>x.Price) %>
                    </td>
                    <th align="right" class="style1">
                        预定人身份：
                    </th>
                    <td align="left" class="style1">
                        <%=CurrentUser.UserType %>
                    </td>
                    <th align="right" class="style1">
                        预定人手机：
                    </th>
                    <td align="left" class="style1">
                        <%=Html.TextBoxFor(x => x.OperatorMobile, new { size = "15", @class = "tc_inputbk formsize100", valid = "required", errmsg = "预订人手机不能为空" })%>
                    </td>
                </tr>
                <tr class="tb_even">
                    <th align="right">
                        <span class="fontred">*</span> 数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量：
                    </th>
                    <td colspan="3" align="left">
                        <%=Html.TextBoxFor(x => x.Num, new { size = "15", @class = "tc_inputbk formsize100", onkeyup = "if(isNaN(this.value)){this.value='1';return false;}", onblur = "instance.calculate()", valid = "required", errmsg = "票数量不能为空" })%>
                    </td>
                    <th align="right">
                        <span class="fontred">*</span> 出 发 日 期&nbsp;：
                    </th>
                    <td align="left">
                        <%=Html.TextBoxFor(x => x.ChuFaRiQi, new { size = "15", @class = "tc_inputbk formsize100", onfocus = "WdatePicker({readOnly:true,minDate:'"+ Model.ChuFaRiQi.ToString("yyyy-MM-dd") +"'})", valid = "required", errmsg = "出发日期不能为空" })%>
                    </td>
                </tr>
                <tr>
                    <th align="right" class="style2">
                        交易总金额：
                    </th>
                    <td colspan="5" align="left" class="style2">
                        <font class="fontred"><b class="font14" id="danPrice">
                            <%= Model.CurrentPrice.ToString("0")%></b>元/人 x <b class="font14" id="num2">
                                <%=Model.Num %></b>人 = </font><font class="fontblue"><b class="font14" id="totalmoney">
                                    <%=(Model.CurrentPrice * Model.Num).ToString("0")%></b>元</font>
                    </td>
                </tr>
                <% if (IsShowShengQingGuiBin() || IsShowShengQingDaiLi() || CurrentUser.UserType == MemberTypes.贵宾会员)
                   { %>
                <tr class="tb_even">
                    <td id="caltd" colspan="6" align="left">
                        <div class="tixing">
                            <% if (CurrentUser.UserType == MemberTypes.贵宾会员)
                               {
                                   decimal price2 = BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.门票);
                            %>
                            <div>
                                <b>贵&nbsp;&nbsp;&nbsp;宾&nbsp;&nbsp;&nbsp;价&nbsp;&nbsp;总&nbsp;&nbsp;金&nbsp;&nbsp;额：</b><font
                                    class="fontred"><b class="font14 danPrice"><%=price2.ToString("0")%></b>元/人 x <b
                                        class="font14 num">
                                        <%=Model.Num%></b>人= </font><font class="fontblue"><b class="font14 totalmoney">
                                            <%=(price2 * Model.Num).ToString("0")%></b> 元</font></div>
                            <%} %>
                            <%if (IsShowShengQingGuiBin())
                              {
                                  decimal price2 = BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.门票);
                            %>
                            <div>
                                <b>申&nbsp; 请&nbsp; 贵&nbsp;&nbsp; 宾&nbsp;&nbsp;身&nbsp;&nbsp; 份：</b><font class="fontred"><b
                                    class="font14 danPrice"><%=price2.ToString("0")%></b>元/人 x <b class="font14 num">
                                        <%=Model.Num%></b>人= </font><font class="fontblue"><b class="font14 totalmoney">
                                            <%=(price2 * Model.Num).ToString("0")%></b> 元，</font><b class="fontblue">立省<span
                                                class="lisheng"><%=((Model.CurrentPrice - price2) * Model.Num).ToString("0")%></span>元</b>
                                <a href="javascript:;" <%=HotelXiangQing.ShowLink(EyouSoft.Model.Enum.MemberTypes.贵宾会员) %>
                                    class="btn001"><span>马上申请</span></a></div>
                            <%} %>
                            <%if (IsShowShengQingDaiLi())
                              {
                                  decimal price3 = BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.代理, Model.FeeSetting, FeeTypes.门票);
                            %>
                            <div>
                                <b>申&nbsp;&nbsp; 请&nbsp; 代&nbsp; 理&nbsp; 身&nbsp;&nbsp; 份：</b><font class="fontred"><b
                                    class="font14 danPrice"><%=price3.ToString("0")%></b>元/人 x <b class="font14 num">
                                        <%=Model.Num%></b>人= </font><font class="fontblue"><b class="font14 totalmoney">
                                            <%=(price3 * Model.Num).ToString("0")%></b> 元，</font><b class="fontblue">立省<span
                                                class="lisheng"><%=((Model.CurrentPrice - price3) * Model.Num).ToString("0")%></span>元</b>
                                <a href="javascript:;" <%=HotelXiangQing.ShowLink(EyouSoft.Model.Enum.MemberTypes.代理) %>
                                    class="btn001"><span>马上申请</span></a></div>
                            <%} %>
                        </div>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <th align="right">
                        备&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 注：
                    </th>
                    <td colspan="5" align="left">
                        <%=Html.TextAreaFor(x => x.Remark, new { @class="tc_inputbk", style="width:700px;height:100px;" })%>
                    </td>
                </tr>
            </table>
            <table width="90%" border="0" style="margin: 15px auto;">
                <tr>
                    <td align="center" class="tjbtn02">
                        <a href="javascript:;" data-id="1" id="btnSave" onclick="instance.tiJiao(this);">提 交 &gt;&gt;</a> <a href="javascript:;"
                            onclick="instance.QuXiao()" id="QuXiao" style="display:none;">返回编辑</a><a href="javascript:;"
                            onclick="history.back();" id="Fanhui">取消 &gt;&gt;</a>
                    </td>
                </tr>
            </table>
           
        </div>
    </form>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">

    <script type="text/javascript">
        var instance = new PageSubmitForm();
        var inputdata = null;
        var fanhuibianji = null;
        var beizhuxinxi = null;
        instance.QuXiao = function() { $("#menpiaoorderform").html(fanhuibianji); $("#Remark").val(beizhuxinxi); $("#btnSave").html("提交"); };
        instance.calculate = function() {
            var num = parseInt($('#Num').val());
            var price = parseInt($('#danPrice').html());
            var totalMoney = (price * num).toFixed(0);
            $('#totalmoney').html(totalMoney);
            $('#Price').val(totalMoney);
            $('#num2').html(num);
            $('.totalmoney').val(function() {
                var price2 = parseInt($(this).parents('div:first').find('.danPrice').html());
                var totalMoney2 = (price2 * num).toFixed(0);
                $(this).html(totalMoney2);
                $(this).parents('div:first').find('.num').html(num);
                $(this).parents('div:first').find('.lisheng').html(totalMoney - totalMoney2);
            });
        };

        instance.tiJiao = function(btn) {
            if (!instance.Validate($('#menpiaoorderform'))) {
                return;
            }
            if ($('#btnSave').attr("data-id") == 1) {
                inputdata = $("#btnSave").closest("form").serialize();
                fanhuibianji = $("#istijiao").clone(true);
                beizhuxinxi = $("#Remark").val();
                $("#btnSave").html("确认提交");
                var elements = $("#btnSave").closest("form").find('input[type=text]');
                instance.RemoveControl(elements);
                //textarea控件
                elements = $("#btnSave").closest("form").find('textarea');
                instance.RemoveControl(elements);

                $('.tixing').remove();
                $('.jiage').remove();
                $('span[class=dindan_num]').removeAttr("class");
                $("#QuXiao").css('display', '');
                $("#Fanhui").css('display', 'none');
                $('#btnSave').attr("data-id", 2);
            }
            else {
                instance.SetButtonUnableClick(btn, { color: '#fff', background: 'url(/images/tc_btn.gif) no-repeat left 50%' });
                $.get('/YouHuiMenPiaoOrder.aspx?submit=1', inputdata, function(ret) {
                    tableToolbar._showMsg(ret.msg, function() {
                        if (ret.result == '1') {
                            location = '/Member/ScenicList.aspx';
                        }
                        instance.SetButtonEnableClick(btn);
                    });
                }, 'json');
            }
        };
        instance.RemoveControl = function(elements) {
            var arrObj = new Array();
            var count = elements.length;
            for (var i = 0; i < count; i++) {
                if (elements[i] == undefined)
                    continue;

                var obj = document.createElement('span');
                switch (elements[i].type) {
                    case "text":
                        obj.style.width = elements[i].style.width;
                        obj.className = "word_warpbreak";
                        obj.innerHTML = elements[i].value;
                        break;
                    case "textarea":
                        obj.style.width = elements[i].style.width;
                        obj.className = "word_warpbreak";
                        obj.innerHTML = elements[i].value;
                        break;
                    default:
                        for (var j = 0; j < elements[i].length; j++) {
                            if (elements[i][j].selected) {
                                obj.style.width = elements[i].style.width;
                                obj.className = "word_warpbreak";
                                obj.innerHTML = elements[i][j].text;
                                break;
                            }
                        }
                        elements[i].options.length = 0;
                        break;
                }
                elements[i].parentNode.appendChild(obj);
                //删除表单控件
                $("#" + elements[i].id + "").remove();
            }
        };
        instance.shenqing = function(userType, userTypeName) {
            if (userType == '<%=(int)MemberTypes.贵宾会员 %>') {
                location = '/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767';
            }
            if (userType == '<%=(int)MemberTypes.代理 %>') {
                location = '/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652';
            }
        };
    </script>

</asp:Content>
