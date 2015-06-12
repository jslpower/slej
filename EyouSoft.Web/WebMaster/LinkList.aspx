<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkList.aspx.cs" Inherits="EyouSoft.Web.WebMaster.LinkList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友情链接</title>

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <script type="text/javascript" src="/js/validatorform.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />
    <style>
        .preview
        {
            margin: 2px;
            border: 1px solid #ccc;
        }
        #preview
        {
            position: absolute;
            border: 1px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
    <div class="btnbox">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a class="toolbar_add" href="javascript:;">新增</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_update" href="javascript:;">修改</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:;" class="toolbar_delete">删除</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>
                    <th align="center">
                        文本
                    </th>
                    <th align="center">
                        图片
                    </th>
                    <th align="center">
                        排序
                    </th>
                    <th align="center">
                        链接
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td height="30" align="center" width="5%">
                                <input type="checkbox" name="checkbox" value='<%#Eval("LinkID") %>' />
                            </td>
                            <td align="center" width="30%">
                                <%#Eval("LinkText")%>
                            </td>
                            <td align="center" width="20%">
                            <%# !string.IsNullOrEmpty(Eval("ImgPath").ToString()) ? "<img class='preview' width='80px' height='50px' src='" + Eval("ImgPath") + "' alt='" + Eval("LinkText") + "' />" : "<img class='preview' width='80px' height='50px' src='../Images/cha.gif' alt='" + Eval("LinkText") + "' />"%>
                                <%--<img class="preview" 
                                <%#!string.IsNullOrEmpty(Eval("ImgPath").ToString()) ? string.Format("src='{0}' width='80px' height='50px' ", Eval("ImgPath")) : "src='../Images/cha.gif'" %>
                                 alt="<%#Eval("LinkText")%>" />--%>
                            </td>
                            <td align="center" width="5%">
                                    <%#Eval("SortRule")%>
                            </td>
                            <td align="center" width="40%">
                                <a target="_blank" href="<%#Eval("LinkAddre")%>">
                                    <%#Eval("LinkAddre")%></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>

<script type="text/javascript">
    $(function() {
        LinkList.BindBtn();
    });
    var LinkList = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
        },
        //ajax执行文件路径,默认为本页面
        ajaxurl: "/WebMaster/LinkList.aspx",
        //添加
        Add: function() {
        window.location.href = "/WebMaster/LinkEdit.aspx?dotype=add&id=";
//            LinkList.ShowBoxy({ iframeUrl: "/WebMaster/LinkEdit.aspx?dotype=add&id=", title: "新增", width: "500px", height: "300px" });
        },
        //修改
        Update: function(objArr) {
        window.location.href = "/WebMaster/LinkEdit.aspx?dotype=update&id=" + objArr[0].find("input[type='checkbox']").val();
//            LinkList.ShowBoxy({ iframeUrl: "/WebMaster/LinkEdit.aspx?dotype=update&id=" + objArr[0].find("input[type='checkbox']").val(), title: "修改", width: "500px", height: "300px" });
        },
        GetCheckBox: function(objArr) {
            //定义数组对象
            var list = new Array();
            //遍历按钮返回数组对象
            for (var i = 0; i < objArr.length; i++) {
                //从数组对象中找到数据所在，并保存到数组对象中
                if (objArr[i].find("input[type='checkbox']").val() != "on") {
                    list.push(objArr[i].find("input[type='checkbox']").val());
                }
            }
            return list.join(',');
        },
        //删除(可多行)
        DelAll: function(objArr) {
            if (objArr.length > 0) {
                //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                LinkList.ajaxurl = "/WebMaster/LinkList.aspx?dotype=delete&id=" + LinkList.GetCheckBox(objArr);
                //执行/ajax
                LinkList.GoAjax(LinkList.ajaxurl);
                return false;
            }
            else {
                tableToolbar._showMsg("只能选择一行进行删除!");
                return false;
            }
        },
        //Ajax请求
        GoAjax: function(url) {
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                async: false,
                dataType: "json",
                success: function(ret) {
                    if (ret.result == "1") {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    }
                    else {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    }
                },
                error: function() {
                    tableToolbar._showMsg(tableToolbar.errorMsg);
                }
            });
        },
        //显示弹窗
        ShowBoxy: function(data) {
            Boxy.iframeDialog({
                iframeUrl: data.iframeUrl,
                title: data.title,
                modal: true,
                width: data.width,
                height: data.height,
                afterHide: function() { LinkList.reload(); }
            });
        },
        BindBtn: function() {

            //绑定Add事件
            $(".toolbar_add").click(function() {
                LinkList.Add();
                return false;
            });
            tableToolbar.init({
                tableContainerSelector: "#liststyle", //表格选择器
                objectName: "行",

                ////修改-删除-取消-复制 为默认按钮，按钮class对应  toolbar_update  toolbar_delete  toolbar_cancel  toolbar_copy即可
                updateCallBack: function(objsArr) {
                    //修改
                    LinkList.Update(objsArr);
                    return false;
                },
                deleteCallBack: function(objsArr) {
                    //删除(批量)
                    LinkList.DelAll(objsArr);
                }
            });
        }
    };

    this.imagePreview = function() {
        /* CONFIG */
        xOffset = 10;
        yOffset = 30;
        /* END CONFIG */
        $("img.preview").hover(function(e) {
            this.t = this.title;
            this.title = "";
            var c = (this.t != "") ? "<br/>" + this.t : "";

            var image = new Image();
            image.src = this.src;
            var width_img = image.width;
            var height_img = image.height;
            var width = 400;  //预定义宽，图片的宽度了
            var height = 300;
            var ratW;        //宽的缩小比例    
            var ratH;        //高的缩小比例    
            var rat;        //实际使用的缩小比例
            if (width_img > width || height_img > height) {
                ratH = height / height_img;
                ratW = width / width_img;
                if (ratH < ratW)      //选择最小的作为实际的缩小比例    
                    rat = ratH;
                else
                    rat = ratW;
                width_img = width_img * rat;
                height_img = height_img * rat;
            }

            $("body").append("<div id='preview'><img src='" + this.src + "' alt='Image preview' height='" + height_img + "' width='" + width_img + "' />" + c + "</div>");
            $("#preview")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("slow");
        },
	function() {
	    this.title = this.t;
	    $("#preview").remove();
	});
        $("img.preview").mousemove(function(e) {
            $("#preview")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
        });
    };

    $(document).ready(function() {
        imagePreview();
    });
</script>

</html>
