<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FenXiangFaBu.aspx.cs" Inherits="EyouSoft.WAP.Member.FenXiangFaBu" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>E家分享</title>
    <link href="/css/fenxiang.css" rel="stylesheet" type="text/css" />
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

</head>
<body>
    <uc1:wapheader runat="server" id="WapHeader1" headtext="E家分享" />
    <form id="form1" runat="server" enctype="multipart/form-data" action="FenXiangFaBu.aspx"
    method="post">
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
                                value="<%# Eval("ImgFile") %>" />
                            <li>图片：<a href="javascript:;" class="uplode_img">上传图片<input type="file" name="file_img"
                                onchange="javascript:showImg(this)" /></a></li>
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
                        <input type="hidden" name="txtTuXiangMediaId" value="" />
                        <li>图片：<a href="javascript:;" class="uplode_img">上传图片<input type="file" name="file_img"
                            onchange="javascript:showImg(this)" /></a> </li>
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
                if (iPage.yanZhengForm()) {
                    $(".y_btn").click($("#form1").submit());
                }
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
            $(".cent").click(function() {
                var html = $("div[class=fenxiang_fabu_box]").eq(0).clone(true);
                html.find("input[name=txtTuXiangMediaId]").val("");
                html.find("textarea[name=MiaoShu]").val("");
                html.find("input[name=file_img]").val("");
                html.find(".demoImg").remove();
                html.find("img").remove();
                $(this).closest(".cent").before(html);
            }); //
            $(".fx_del_icon").click(function() {
                var tempCount = +$(".fenxiang_fabu_box").length;
                if (tempCount > 1) {
                    $(this).closest(".fenxiang_fabu_box").remove();
                }
            })

        });


        function showImg(obj) {
            var fs = $(obj).get(0).files
            for (var i = 0; i < fs.length; i++) {

                var fr = new FileReader();

                if (fs[i].type.indexOf('image') != -1) {

                    fr.readAsDataURL(fs[i]);

                    fr.onload = function() {
                        $(obj).parent().parent().find(".yulan").remove();
                        $(obj).parent().parent().append("<img class=\"yulan\" style=\"width:80px;height:60px;\" src=" + this.result + " />");
                    };
                }
                else {
                    alert('亲,请拖拽图片格式');
                }

            }
        }
    </script>

</body>
</html>
