<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackManage.aspx.cs" Inherits="EyouSoft.Web.WebMaster.FeedbackManage" %>
<%@ Register TagPrefix="cc1" Namespace="Adpost.Common.ExporPage" Assembly="ControlLibrary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>反馈管理</title>

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
     <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>

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
        .style1
        {
            width: 279px;
        }
        .style2
        {
            width: 238px;
        }
        .style3
        {
            width: 192px;
        }
    </style>
</head>
<body>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" action="FeedbackManage.aspx" method="get">
                    <div class="searchbox">
                        <label>
                            反馈类型：</label>
                        <select id="MessageType" name="MessageType" class="inputselect" >
                             <%=BindArticleClass(EyouSoft.Common.Utils.GetQueryStringValue("MessageType"))%>
                        </select>
                         <label>
                        反馈内容：</label>
                        <input type="text" class="inputtext" name="txtContext" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtContext") %>" />
                        <label>
                            姓名：</label>
                        <input type="text" class="inputtext" name="txtName" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtName") %>" />
                        <label>
                            提交日期：</label>
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" id="txtStartTime"
                            size="10" class="inputtext" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStartTime") %>" />-<input
                                type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})" class="inputtext"
                                name="txtEndTime" id="txtEndTime" size="10" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtEndTime") %>" />

                        <input type="submit" class="search-btn" value="" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
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
                        反馈类型
                    </th>
                    <th align="center">
                        反馈内容
                    </th>
                    <th align="center">
                        姓名
                    </th>
                    <th align="center">
                        E-mail
                    </th>
                    <th align="center">
                        联系方式
                    </th>
                    <th align="center">
                        提交时间
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td height="30" align="center" width="5%">
                                <input type="checkbox" name="checkbox" value='<%#Eval("ID") %>' />
                            </td>
                            <td align="center" width="25%">
                                <%#Eval("MessageType")%>
                            </td>
                            <td align="center" width="30%">
                                <%#Eval("MsgContent")%>
                            </td>
                            <td align="center" width="10%">
                                    <%#Eval("Name")%>
                            </td>
                            <td align="center" width="10%">
                                <%#Eval("Email")%>
                            </td>
                             <td align="center" width="10%">
                                <%#Eval("Tel")%>
                            </td>
                             <td align="center" width="10%">
                                <%#Eval("submittime")%>
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
        ajaxurl: "/WebMaster/FeedbackManage.aspx",
        //添加
        Add: function() {
        LinkList.ShowBoxy({ iframeUrl: "/WebMaster/FeedbackEdit.aspx?dotype=add&id=", title: "新增", width: "500px", height: "300px" });
        },
        //修改
        Update: function(objArr) {
        LinkList.ShowBoxy({ iframeUrl: "/WebMaster/FeedbackEdit.aspx?dotype=update&id=" + objArr[0].find("input[type='checkbox']").val(), title: "修改", width: "500px", height: "300px" });
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
                LinkList.ajaxurl = "/WebMaster/FeedbackManage.aspx?dotype=delete&id=" + LinkList.GetCheckBox(objArr);
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
