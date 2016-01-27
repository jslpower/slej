<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FenXiang.ascx.cs" Inherits="EyouSoft.Web.WebMaster.UserControl.FenXiang" %>

<script type="text/javascript">
    var Journey = {
        //创建编辑器
        CreateEdit: function(obj) {
            var _self = $(obj);
            //_self.css("display", "none");
            if (_self.attr("id") == "") {
                _self.attr("id", "txtRemark" + parseInt(Math.random() * 1000));
            }
            KEditer.remove(_self.attr("id"));
            //            KEditer.init(_self.attr("id"), {
            //                resizeMode: 0, items: keSimple, height: "200px", width: "97%"
            //            });
        },
        //删除附件
        RemoveFile: function(obj) {
            $(obj).closest("td").find("input[name='hide_Journey_file']").val("");
            $(obj).closest("div[class='upload_filename']").remove();
            $(obj).closest("div[data-class='Journey_upload']").find("img").remove();
            return false;
        },
        CreateFlashUpload: function(flashUpload, idNo) {
            flashUpload = new SWFUpload({
                upload_url: "/CommonPage/upload.aspx",
                file_post_name: "Filedata",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                file_size_limit: "2 MB",
                file_types: "*.bmp;*.jpg;*.gif;*.jpeg;*.png;",
                file_types_description: "附件上传",
                file_upload_limit: 1,
                swfupload_loaded_handler: function() { },
                file_dialog_start_handler: uploadStart,
                upload_start_handler: uploadStart,
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,
                // Button settings
                button_placeholder_id: "spanButtonPlaceholder_" + idNo,
                button_image_url: "/Images/swfupload/XPButtonNoText_178_34.gif",
                button_width: 178,
                button_height: 34,
                button_text: '<span ></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,
                button_cursor: SWFUpload.CURSOR.HAND,
                flash_url: "/JS/swfupload/swfupload.swf",
                custom_settings: {
                    upload_target: "divFileProgressContainer_" + idNo,
                    HidFileNameId: "hide_Journey_file_" + idNo,
                    HidFileName: "hide_Journey_file_Old",
                    ErrMsgId: "errMsg_" + idNo,
                    UploadSucessCallback: function() { Journey.UploadOverCallBack(idNo); }
                },
                debug: false,
                minimum_flash_version: "9.0.28",
                swfupload_pre_load_handler: swfUploadPreLoad,
                swfupload_load_failed_handler: swfUploadLoadFailed
            });
        },
        UploadArgsList: [],
        InitSwfUpload: function(tr, no) {
            var $box = tr || $("#tbl_Journey_AutoAdd");
            $box.find("div[data-class='Journey_upload_swfbox']").each(function() {
                var idNo = no || parseInt(Math.random() * 100000);

                $(this).find("[data-class='Journey_upload']").each(function() {
                    if ($(this).attr("id") == "") {
                        $(this).attr("id", $(this).attr("data-id") + "_" + idNo);
                    }
                })
                var swf = null;
                Journey.CreateFlashUpload(swf, idNo);
                if (swf) {
                    Journey.UploadArgsList.push(swf);

                }
            })

        },
        AddRowCallBack: function(tr) {
            var $tr = tr;
            $tr.find("div[data-class='Journey_upload_swfbox']").html($("#divJourneyUploadTemp").html());
            $tr.find("span[class='errmsg']").html("");
            $tr.find("span[data-class='fontblue']").html("");
            $tr.find("div[data-class='span_journey_file']").remove();
            tr.find("textarea[name='txtContent']").show();
            Journey.InitSwfUpload($tr);
        },
        MoveRowCallBack: function(tr) {
            var txt = tr.find("textarea[name='txtContent']");
            KEditer.sync(txt.attr("id"));
            Journey.CreateEdit(txt);
            var eqFrist = tr.find("div[data-class='Journey_upload']").eq(0);
            try {
                //处理IE 9 下移除FLASH 异常
                tr.find("object").remove();
            } catch (e) {
                eqFrist.prev().html('<input type="hidden" data-class="Journey_upload" data-id="hide_Journey_file" name="hide_Journey_file" /><span data-class="Journey_upload" data-id="errMsg" class="errmsg"></span>');
            }
            var no = eqFrist.attr("id").split('_')[1];
            eqFrist.prev().append('<span data-class="Journey_upload" data-id="spanButtonPlaceholder"></span>');
            Journey.InitSwfUpload(tr, no);
        },
        UploadOverCallBack: function(idNo) {
            var $div = $("#divFileProgressContainer_" + idNo);
            if ($div.length > 0) {
                if ($div.find("div[class='progressWrapper']").length > 1) {
                    $div.find("div[class='progressWrapper']").eq(0).remove();
                }
                var imgStr = $.trim($div.find("input[name='hide_Journey_file_Old']").val()).toString();
                var imgsrc = "";
                if (imgStr != "") {
                    if (imgStr.split('|').length > 1) {
                        imgsrc = imgStr.split('|')[1];
                    }
                }
                $div.append("<img src='" + imgsrc + "' alt='' height='120px' width='150px' />");
                if ($div.closest("td").find("div[class='upload_filename']")) {
                    $div.closest("td").find("div[class='upload_filename']").remove();
                }
            }
        }

    }

    function JourneyCallBackFun(args) {
        if (args.spotid) {
            if (args.spotid.split(',').length > 1) {
                var spotList = args.spotid.split(',');
                var spotNameList = args.spotname.split(',');
                for (var i = 0; i < spotList.length; i++) {
                    Journey.CreateSince({ spotid: spotList[i], spotname: spotNameList[i], aid: args.aid });
                }
            } else {
                Journey.CreateSince(args);
            }
        }
    }

    $(function() {
        $("#tbl_Journey_AutoAdd").find("textarea[name='txtContent']").each(function() {
            var _self = $(this);
            _self.unbind().click(function() {
                Journey.CreateEdit(this);
            })
            if ($.trim(_self.val()) != "") {
                $(this).click();
            }
        })

        Journey.InitSwfUpload(null, null);
    })
</script>

<style type="text/css">
    #tbl_Journey_AutoAdd .progressWrapper
    {
        overflow: hidden;
        width: 200px;
    }
    #tbl_Journey_AutoAdd .progressContainer
    {
        width: 195px;
        padding: 1px;
        margin: 0;
        margin-top: 3px;
    }
    #tbl_Journey_AutoAdd .progressBarComplete, .progressBarStatus
    {
        width: 190px;
        margin: 1px;
    }
    #tbl_Journey_AutoAdd .progressName
    {
        overflow: hidden;
        width: 150px;
    }
</style>
<table id="tbl_Journey_AutoAdd" width="100%" class="journey tableList margin_T10">
    <tr class="addcontentT">
        <th width="5%" valign="middle" class="th-line">
            序号
        </th>
        <th valign="middle" class="th-line" colspan="3">
            描述
        </th>
        <th width="250px" valign="middle" class="th-line">
            图片
        </th>
        <th width="130px" valign="middle" class="th-line">
            操作
            <div style="width: 150px; height: 1px;">
            </div>
        </th>
    </tr>
    <asp:PlaceHolder runat="server" ID="phdefaultTr">
        <tbody class="tempRow">
            <tr>
                <td align="center">
                    <b class="index">1</b>
                </td>
                <td align="left" colspan="3" class="noboder">
                    <textarea name="txtContent" class="richText inputtext" style="width: 97%; height: 200px;"></textarea>
                </td>
                <td valign="middle" align="center">
                    <div style="margin: 0px 10px;" data-class="Journey_upload_swfbox">
                        <div>
                            <input type="hidden" data-class="Journey_upload" data-id="hide_Journey_file" name="hide_Journey_file" />
                            <span data-class="Journey_upload" data-id="spanButtonPlaceholder"></span><span data-class="Journey_upload"
                                data-id="errMsg" class="errmsg"></span>
                        </div>
                        <div data-class="Journey_upload" data-id="divFileProgressContainer">
                        </div>
                        <div data-class="Journey_upload" data-id="thumbnails">
                        </div>
                    </div>
                </td>
                <td align="center">
                    <a href="javascript:void(0)">
                        <img src="/images/webmaster/charuimg.gif" class="addbtn" height="20" width="48"></a>&nbsp;
                    <a href="javascript:void(0)">
                        <img src="/images/webmaster/delimg.gif" class="delbtn" height="20" width="48"></a>
                </td>
            </tr>
        </tbody>
    </asp:PlaceHolder>
    <asp:Repeater ID="rptJourney" runat="server">
        <ItemTemplate>
            <tbody class="tempRow">
                <tr>
                    <td align="center">
                        <b class="index">
                            <%# Container.ItemIndex +1%></b>
                    </td>
                    <td align="left" colspan="3" class="noboder">
                        <textarea name="txtContent" class="richText inputtext" style="width: 97%; height: 200px;"><%#Eval("XingChengContent")%></textarea>
                    </td>
                    <td valign="middle" align="center">
                        <div style="margin: 0px 10px;" data-class="Journey_upload_swfbox">
                            <div>
                                <input type="hidden" data-class="Journey_upload" data-id="hide_Journey_file" name="hide_Journey_file"
                                    value="|<%#Eval("ImgFile") %>" />
                                <span data-class="Journey_upload" data-id="spanButtonPlaceholder"></span><span data-class="Journey_upload"
                                    data-id="errMsg" class="errmsg"></span>
                            </div>
                            <div data-class="Journey_upload" data-id="divFileProgressContainer">
                            </div>
                            <div data-class="Journey_upload" data-id="thumbnails">
                            </div>
                        </div>
                        <%# getImg(Eval("ImgFile")) != "" ? "<div data-class='span_journey_file' class='upload_filename'><a target='_blank' href='" + getImg(Eval("ImgFile")) + "'><img height='100' width='160' alt='' class='addpic img' style='vertical-align:bottom' src='" + getImg(Eval("ImgFile")) + "' /></a><a href='javascript:void(0);' title='删除附件' onclick='Journey.RemoveFile(this);'><img src='/images/webmaster/cha.gif' border='0'></a> </div>" : ""%>
                    </td>
                    <td align="center">
                        <a href="javascript:void(0)">
                            <img src="/images/webmaster/charuimg.gif" class="addbtn" height="20" width="48"></a>&nbsp;
                        <a href="javascript:void(0)">
                            <img src="/images/webmaster/delimg.gif" class="delbtn" height="20" width="48"></a>
                    </td>
                </tr>
            </tbody>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div style="margin: 0px 10px; display: none;" id="divJourneyUploadTemp">
    <div>
        <input type="hidden" data-class="Journey_upload" data-id="hide_Journey_file" name="hide_Journey_file" />
        <span data-class="Journey_upload" data-id="spanButtonPlaceholder"></span><span data-class="Journey_upload"
            data-id="errMsg" class="errmsg"></span>
    </div>
    <div data-class="Journey_upload" data-id="divFileProgressContainer">
    </div>
    <div data-class="Journey_upload" data-id="thumbnails">
    </div>
</div>
