<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EyouSoft.WebApp.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="/cordova.js"></script>
    <script type="text/javascript" src="/js/enow.core.js"></script>
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
</head>
<body style="margin:0;padding:0;">
<img src=/images/splash.png width=100% height=100%  style="z-index:-100;position:absolute;left:0;top:0"/>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    
    <script type="text/javascript">
        function huoQuYuMing(yaoQingMa) {
            if (yaoQingMa.length == 0) return "";

            var _yuMing = "";
            $.ajax({ type: "POST", url:"/ashx/handler.ashx?doType=huoquyuming_yaoqingma", data: { txt: yaoQingMa },
                cache: false, dataType: "json", async: false,
                success: function(response) {
                    if (response.result == "1") _yuMing = response.obj.YuMing;
                }
            });

            return _yuMing;
        }

        function sheZhiLocalUrl(url) {
            var _options = { s: url, directory: 'slejapp', fileName: 'url.txt', onwrite: function(evt) { window.location.href = url; }, onFail: function() { window.location.href = url; } };
            window.eNow.file.writeFile(_options);
        }
        
        function huoQuYaoQingMa_callback(yaoQingMa) {
            var _url = "/default.aspx";
            var _yuMing = huoQuYuMing(yaoQingMa);
            if (_yuMing.length > 0) {
                _url = "http://" + _yuMing + "/default.aspx";
                sheZhiLocalUrl(_url);
            }
            else {
                window.location.href = _url;
            }
        }
        
        function huoQuYaoQingMa() {
            var _onSuccess = function(result) {
                huoQuYaoQingMa_callback(result.neirong);
            };

            var _onFail = function(message) { huoQuYaoQingMa_callback("") };

            var _options = {};

            window.eNow.jianTieBan.huoQu(_onSuccess, _onFail, _options);
        }
        
        function huoQuLocalUrl_callback(localUrl) {
            if (typeof (localUrl) != "undefined" && localUrl.length > 0 && localUrl.indexOf("http://") > -1) {
                window.location.href = localUrl; return;
            }

            huoQuYaoQingMa();
        }
        
        function huoQuLocalUrl() {
            var _options = { directory: 'slejapp', fileName: 'url.txt', onloadend: function(text) { huoQuLocalUrl_callback(text); }, onFail: function() { huoQuLocalUrl_callback(""); } };
            window.eNow.file.readFile(_options);
        }

        function init() {
            huoQuLocalUrl();
        }

        $(document).ready(function() {
            window.eNow.ready({ fn: function() { init(); } });
        });
    </script>
    
</body>
</html>
