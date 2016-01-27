<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateWebSet.aspx.cs" Inherits="EyouSoft.WAP.Member.UpdateWebSet" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>会员中心</title>

    <script src="../js/jq.mobi.min.js" type="text/javascript"></script>

    
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <style>
        .user_form li
        {
            padding-left: 115px;
        }
    </style>
    <form id="form1" runat="server">
    <div class="warp">
        <div class="user_form">
            <ul>
                <li><span class="label_name">选择首页模板</span> <span div-radio="mbnav" class="font_gray">
                    <asp:RadioButtonList ID="ddlNav" runat="server" RepeatColumns="2" Width="200px">
                        <asp:ListItem Value="0">主站模板</asp:ListItem>
                        <asp:ListItem Value="1">代理商模板</asp:ListItem>
                    </asp:RadioButtonList>
                </span></li>
                <li><span class="label_name">显示代理申请</span> <span div-radio="dlshow" class="font_gray">
                    <asp:RadioButtonList ID="ShowHidden" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="0" Selected="True">显示</asp:ListItem>
                        <asp:ListItem Value="1">隐藏</asp:ListItem>
                    </asp:RadioButtonList>
                </span></li>
            </ul>
        </div>
        <div class="padd cent">
            <input type="button" class="y_btn" id="btn" value="保存"></div>
    </div>
    </form>
    
    <div class="user-mask" style="display:none;">
   <div class="user-mask-cnt" style="width:80%; margin-top:150px;">
                      <em id="xssq" data-div="mask" style="display:none">
                      <h3 class="font_yellow font18 cent">显示代理申请</h3>
                      <p style="padding-top:5px;">让客人可见我网站所有产品的贵宾价和代理价，经申请成为代理身份后，永远都是我的下级代理我可以获取发展该代理的佣金，还可以获取该下级代理销售利润一定比例的由总部发放的奖金。下级代理越多，我的发展佣金越多，奖金越高！<span class="font_red">(注：只推广一级，奖金是从总部获得，网站有丰富的产品，不属于传销！)</span></p>
                      </em>
                      <em id="xsyc" data-div="mask" style="display:none">
                      <h3 class="font_yellow font18 cent">隐藏代理申请</h3>
                      <p style="padding-top:5px;">不让客人见到我网站产品的贵宾价和代理价，直接赚取我网站所有产品的代理利润！（包括我供应的商品、别的商家供应的商品和所有旅游产品）。</p>
                      </em>
                      <em id="zzmb" data-div="mask" style="display:none">
                      <h3 class="font_yellow font18 cent">主站模板</h3>
                      <p style="padding-top:5px;">网站（包括手机、电脑和微信三个版本）首页、导航栏、促销秒杀和首页轮换广告，均显示旅游线路、门票、机票、酒店、租车和会员商城、E额宝等栏目产品， 例如——http://m.slej.cn 和 http://m.6148.slej.cn</p>
                      </em>
                      <em id="dlmb" data-div="mask" style="display:none">
                      <h3 class="font_yellow font18 cent">代理商模板</h3>
                      <p style="padding-top:5px;">网站（包括手机、电脑和微信三个版本）首页、导航栏、促销秒杀和首页轮换广告，显示的内容都是我自己上传的产品内容，该网站就是我的专属智能网站，是完全属于我（单位）自己的智能专卖店，例如——http://m.8568.slej.cn 和 http://m.4768.slej.cn</p>
                      </em>
   </div>
   </div>
    
    
</body>

<script type="text/javascript">
    var PageInfo = {
        Sava: function() {
            var url = '/Member/UpdateWebSet.aspx?type=update';
            PageInfo.GoAjax(url);
        },
        GoAjax: function(url) {
            $.ajax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=form1.ClientID %>").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        alert(ret.msg);
                        window.location.href = window.location.href;
                    }
                    else {
                        alert(ret.msg);
                        window.location.href = window.location.href;
                    }
                },
                error: function() {
                    alert("修改失败，请重试！");
                    window.location.href = window.location.href;
                }
            });
        },
        BindBth: function() {
            $("#btn").click(function() {
                PageInfo.Sava(); return false;
            });
        }
    };
    $(function() {
        PageInfo.BindBth();
        $("#ShowHidden").click(function(){
             if($("input[name='ShowHidden']:checked").val()=="0")
             {       
                $(".user-mask").show();
                $("em[data-div=mask]").css("display","none");
                $("#xssq").show();
             }
             else
             {
                $(".user-mask").show();
                $("em[data-div=mask]").css("display","none");
                $("#xsyc").show();
             }
        });
       $("#ddlNav").click(function(){
             if($("input[name='ddlNav']:checked").val()=="0")
             {       
                $(".user-mask").show();
                $("em[data-div=mask]").css("display","none");
                $("#zzmb").show();
             }
             else
             {
                $(".user-mask").show();
                $("em[data-div=mask]").css("display","none");
                $("#dlmb").show();
             }
        });
         $(".user-mask").click(function(){
         $(".user-mask").hide();
         })
    });
</script>

</html>