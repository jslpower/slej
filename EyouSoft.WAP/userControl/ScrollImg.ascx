<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScrollImg.ascx.cs" Inherits="EyouSoft.WAP.userControl.ScrollImg" %>
<link rel="stylesheet" type="text/css" href="/css/slider.css" media="screen" />


<script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/js/jquery.event.drag-1.5.min.js"></script>
<script type="text/javascript" src="/js/jquery.touchSlider.js"></script>
<script type="text/javascript">
    $(function() {
        var winwid = $(window).width();
        var imgwid = "<%= ImgWid%>";
        var imghei = "<%= ImgGth%>";
        var winhei = Number(winwid) / Number(imgwid) * Number(imghei);
        $('.main_visual').css("height", winhei + "px");
    })
    $(document).ready(function() {


        $(".main_image").touchSlider({
            flexible: true,
            speed: 200,
            btn_prev: $("#btn_prev"),
            btn_next: $("#btn_next"),
            paging: $(".flicking_con a"),
            counter: function(e) {
                $(".flicking_con a").removeClass("on").eq(e.current - 1).addClass("on");
            }
        });


        mytimer = setInterval(function() {
            $("#btn_next").click();
        }, 4000);

        $(".main_visual").hover(function() {
        clearInterval(mytimer);
        }, function() {
        mytimer = setInterval(function() {
                $("#btn_next").click();
            }, 4000);
        });

        $(".main_image").bind("touchstart", function() {
        clearInterval(mytimer);
        }).bind("touchend", function() {
        mytimer = setInterval(function() {
                $("#btn_next").click();
            }, 4000);
        });

    });
</script>
<div class="main_visual" style="height:156px;">
            <div class="flicking_con">
                <%=strImgNum%>
            </div>
            <div class="main_image">
                <ul>
                    <%=strImgStr%>
                </ul>
                <a href="javascript:;" id="btn_prev"></a>
                <a href="javascript:;" id="btn_next"></a>
            </div>
        </div>
<!--baner------------end-->
