<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="send.aspx.cs" Inherits="Send" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
</head>
<body>
    <div align="center">
        正在跳转到快钱支付。。。
    </div>
    <div align="center" style="font-weight: bold;">
        <form name="kqPay" action="https://www.99bill.com/mobilegateway/recvMerchantInfoAction.htm "
        method="post">
        <input type="hidden" name="inputCharset" value="<%=inputCharset%>" />
        <input type="hidden" name="pageUrl" value="<%=pageUrl%>" />
        <input type="hidden" name="bgUrl" value="<%=bgUrl%>" />
        <input type="hidden" name="version" value="<%=version%>" />
        <input type="hidden" name="language" value="<%=language%>" />
        <input type="hidden" name="signType" value="<%=signType%>" />
        <input type="hidden" name="signMsg" value="<%=signMsg%>" />
        <input type="hidden" name="merchantAcctId" value="<%=merchantAcctId%>" />
        <input type="hidden" name="payerName" value="<%=payerName%>" />
        <input type="hidden" name="payerContactType" value="<%=payerContactType%>" />
        <input type="hidden" name="payerContact" value="<%=payerContact%>" />
        <input type="hidden" name="orderId" value="<%=orderId%>" />
        <input type="hidden" name="orderAmount" value="<%=orderAmount%>" />
        <input type="hidden" name="orderTime" value="<%=orderTime%>" />
        <input type="hidden" name="productName" value="<%=productName%>" />
        <input type="hidden" name="productNum" value="<%=productNum%>" />
        <input type="hidden" name="productId" value="<%=productId%>" />
        <input type="hidden" name="productDesc" value="<%=productDesc%>" />
        <input type="hidden" name="ext1" value="<%=ext1%>" />
        <input type="hidden" name="ext2" value="<%=ext2%>" />
        <input type="hidden" name="payType" value="<%=payType%>" />
        <input type="hidden" name="bankId" value="<%=bankId%>" />
        <input type="hidden" name="redoFlag" value="<%=redoFlag%>" />
        <input type="hidden" name="pid" value="<%=pid%>" />
        </form>

        <script type="text/javascript">
            document.forms[0].submit();
        </script>

    </div>
</body>
</html>
