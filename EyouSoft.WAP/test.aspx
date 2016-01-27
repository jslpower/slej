<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="EyouSoft.WAP.test" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>E家分享</title>
    <link href="/css/fenxiang.css" rel="stylesheet" type="text/css" />
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

</head>
<body>
    <uc1:wapheader runat="server" id="WapHeader1" headtext="E家分享" />
    <form id="form1">
    <input type="hidden" name="hidyid" id="hidyid" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("youjid") %>" />
    <div class="warp">
        <div class="fenxiang_main">
            <div class="fenxiang_fabu_title">
                <span>标题：</span><input id="txtTitle" type="text" class="u-input" value="<%=yjTitle %>"
                    name="txtTitle"></div>
            <asp:Repeater ID="rptYouJis" runat="server">
                <ItemTemplate>
                    <div class="fenxiang_fabu_box">
                        <div class="fx_del_icon">
                        </div>
                        <ul>
                            <img class="demoImg" width="80px" src="<%# Eval("ImgFile") %>" />
                            <input type="hidden" id="txtTuXiangMediaId<%# Container.ItemIndex+1 %>" name="txtTuXiangMediaId"
                                value="<%# getImgSrc( Eval("ImgFile"),  youjiid )%>" />
                            <li>图片：<a href="javascript:;" class="uplode_img">上传图片</a><em class="icon_em"></em></li>
                            <li class="txt box"><span>文字：</span>
                                <textarea name="MiaoShu" class="u-input"><%# Eval("XingChengContent")%></textarea>
                            </li>
                        </ul>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder ID="isAdd" runat="server" Visible="false">
                <div class="fenxiang_fabu_box">
                    <div class="fx_del_icon">
                    </div>
                    <ul>
                        <input type="hidden" id="txtTuXiangMediaId" name="txtTuXiangMediaId" value="" />
                        <li>图片：<a href="javascript:;" class="uplode_img">上传图片</a><em class="ok"></em></li>
                        <li class="txt box"><span>文字：</span>
                            <textarea name="MiaoShu" class="u-input"></textarea>
                        </li>
                    </ul>
                </div>
            </asp:PlaceHolder>
            <div class="cent add_more mt10">
                <span><i class="add_icon"></i>添加一组</span></div>
        </div>
    </div>
    <input id="TuPianId" type="hidden" />
    <input id="TuPianTiShiId" type="hidden" />
    <div class="bot">
        <div class="bot_box">
            <a href="javascript:void(0)" class="y_btn">分享 我为自己代言</a>
        </div>
    </div>
    </form>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            redirectWoDeMingPian: function() {
                window.location.href = "FexXiangList.aspx";
                return false;
            },
            yanZhengForm: function() {
                if ($("#txtTitle").val() == "") {
                    alert("请填写游记标题！");
                    return false;
                }
                return true;
            },
            bcF3: function(obj) {
                if (!this.yanZhengForm()) return false;
                var _self = this;
                _self.bcF1();
                var _self = this;

                function __callback(response) {
                    alert(response.msg);
                    _self.redirectWoDeMingPian();
                }

                $.ajax({ type: "POST", url: "test.aspx?doType=baocun", data: $("#form1").serialize(), cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() {
                        _self.bcF2();
                    }
                });
            },
            wxReady: function() {
                var _self = this;
                _self.sctxF3();
            },
            sctxF0: function() {
                this.sctxF2();
                alert("您当前的微信客户端不能使用该功能，请升级微信客户端后再操作。");
            },
            //上传图像-事件-初始化
            sctxF1: function() {
                $(".uplode_img").unbind("click").click(function() { alert("请稍候，正在检查您的微信客户端版本。") });
            },
            //上传图像-事件-微信版本过低提示
            sctxF2: function() {
                $(".uplode_img").unbind("click").click(function() { alert("您当前的微信客户端不能使用该功能，请升级微信客户端后再操作。") }); ;
            },
            //上传图像-事件-选择图片
            sctxF3: function() {
                $(".uplode_img").unbind("click").click(function() {
                    var tupianid = $(this).closest(".fenxiang_fabu_box").find("input[name=txtTuXiangMediaId]").attr("id");
                    //var tupiantsid = $(this).closest(".youji_fabu_box").find("em").attr("id");
                    $("#TuPianId").val(tupianid);
                    //$("#TuPianTiShiId").val(tupiantsid);
                    iPage.sctxF4();
                });
            },
            //上传图像-选择图片
            sctxF4: function() {
                var _self = this;
                wx.chooseImage({
                    success: function(res) {
                        var localIds = res.localIds;
                        if (localIds.length > 1) { alert("只能选择一张图像"); return false; }
                        _self.sctxF3();
                        setTimeout(function() { _self.sctxF5(localIds[0]); }, 10);
                    },
                    fail: function() {
                        _self.sctxF0();
                    }
                });
            },
            //上传图像-上传图片
            sctxF5: function(localIds) {
                //alert("F5")
                var _self = this;
                _self.bcF1();
                wx.uploadImage({
                    localId: localIds,
                    isShowProgressTips: 1,
                    success: function(res) {
                        var serverId = res.serverId;
                        var tupianid = $("#TuPianId").val();
                        //var tupiantsid = $("#TuPianTiShiId").val();
                        $("#" + tupianid).val(serverId);
                        $("#" + tupianid).parent().find(".icon_em").addClass("ok");
                        _self.bcF2();
                        //setTimeout(function() { _self.sctxF6(serverId); }, 10);
                    },
                    fail: function(res) {
                        alert("上传图像失败，请重新操作");
                        _self.bcF2();
                    }
                });
            },
            //上传图像-保存图片
            sctxF6: function(serverId) {
                //alert("F6")
                var _data = { media_id: serverId };
                var _self = this;
                $.ajax({ type: "POST", url: "/weixin/get_media.aspx", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            var tupianid = $("#TuPianId").val();
                            $("#" + tupianid).val(response.obj);


                            //alert("上传图像成功");
                        } else {
                            alert("上传图像失败，请重新操作");
                        }
                        _self.bcF2();
                    },
                    error: function() {
                        alert("上传图像失败，请重新操作");
                        _self.bcF2();
                    }
                });
            },
            //保存按钮停用
            bcF1: function() {
                $(".y_btn").unbind("click").css({ "color": "#999999" });
            },
            //保存按钮启用
            bcF2: function() {
                $(".y_btn").bind("click", function() { iPage.bcF3(this); }).css({ "color": "" });
            }
        };

        $(document).ready(function() {
            iPage.bcF2();
            iPage.sctxF1();
            $(".cent").click(function() {
                var html = $("div[class=fenxiang_fabu_box]").eq(0).clone(true);
                var mudicount = $(".fenxiang_fabu_box").length + 1;
                html.find("input[name=txtTuXiangMediaId]").attr("id", "txtTuXiangMediaId" + mudicount);
                html.find("em").attr("id", "TuPianTiShi" + mudicount);
                html.find("input[name=txtTuXiangMediaId]").val("");
                html.find("textarea[name=MiaoShu]").val("");
                html.find(".demoImg").remove();
                $(this).closest(".cent").before(html);
            }); //
            $(".fx_del_icon").click(function() {
                var tempCount = +$(".fenxiang_fabu_box").length;
                if (tempCount > 1) {
                    $(this).closest(".fenxiang_fabu_box").remove();
                }
            })

        });

        wx.ready(function() {
            iPage.wxReady();
        });

        wx.error(function(res) {

        });
    </script>

</body>
</html>
