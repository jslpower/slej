<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uploadFile.ascx.cs"
    Inherits="EyouSoft.Web.UserControl.uploadFile" %>

<script src="/js/jquery.form.js" type="text/javascript"></script>

<style type="text/css">
    .file_a
    {
        background: #00aee7;
        border: #008dce solid 1px;
        border-radius: 4px;
        color: #fff;
        cursor: pointer;
        display: inline-block;
        width: 120px;
        height: 26px;
        line-height: 26px;
        overflow: hidden;
        text-align: center;
        text-decoration: none;
        position: relative;
        zoom: 1;
    }
    .file_a input
    {
        filter: alpha(opacity=0);
        filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=0);
        opacity: 0;
        position: absolute;
        right: 0;
        top: 0;
        cursor: pointer;
        outline: none;
        height: 100%;
        width: 200%;
    }
</style>
<a class="file_a" href="javascript:;">选择图片<input type="file" name="uploadInput" id="uploadInput"
    accept="image/*" /></a><span id="errMsg_uploadFile" class="errmsg"></span>
<input type="hidden" id="<%=ClientHideID %>" name="<%=ClientHideID %>" value="" />

<script type="text/javascript">

    var contrlLoadFile = {
        viaFile: function() {
            if ($("#uploadInput").val() != "" && $("#uploadInput").val() != null && $("#uploadInput").val() != 'undefined') {
                var hideForm = $("#uploadInput").closest("form");
                var options = {
                    url: '/CommonPage/uploadFile.aspx',
                    dataType: "json",
                    beforeSubmit: function() {
                        $("#<%=ClientHideID %>").val("正在上传");
                        $("#errMsg_uploadFile").html("");
                    },
                    success: function(ret) {
                        if (ret.result == "1") {
                            $("#<%=ClientHideID %>").val(ret.obj);
                        } else {
                            $("#errMsg_uploadFile").html(ret.msg);
                        }
                    },
                    error: function(ret) {
                        $("#errMsg_uploadFile").html("文件过大");
                    }
                };
                hideForm.ajaxSubmit(options);
            }
        },
        uploadFile: function() {
            var element = document.getElementById("uploadInput");
            if (window.addEventListener) {
                element.addEventListener("change", contrlLoadFile.viaFile, false);
            } else if (window.attachEvent) {
                element.onpropertychange = contrlLoadFile.viaFile;
            }
        }

    };
    $(function() {
        contrlLoadFile.uploadFile();
    })
</script>

