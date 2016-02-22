using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using EyouSoft.Common;
using EyouSoft.BLL.ScenicStructure;

public partial class receive : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        EyouSoft.Toolkit.Utils.WLog("RECEIVE PAGELOAD", "/log/99bill.log");

        //人民币网关账号，该账号为11位人民币网关商户编号+01,该值与提交时相同。
        string merchantAcctId = Request.QueryString["merchantAcctId"].ToString();
        //网关版本，固定值：v2.0,该值与提交时相同。
        string version = Request.QueryString["version"].ToString();
        //语言种类，1代表中文显示，2代表英文显示。默认为1,该值与提交时相同。
        string language = Request.QueryString["language"].ToString();
        //签名类型,该值为4，代表PKI加密方式,该值与提交时相同。
        string signType = Request.QueryString["signType"].ToString();
        //支付方式，一般为00，代表所有的支付方式。如果是银行直连商户，该值为10,该值与提交时相同。
        string payType = Request.QueryString["payType"].ToString();
        //银行代码，如果payType为00，该值为空；如果payType为10,该值与提交时相同。
        string bankId = Request.QueryString["bankId"].ToString();
        //商户订单号，,该值与提交时相同。
        string orderId = Request.QueryString["orderId"].ToString();
        //订单提交时间，格式：yyyyMMddHHmmss，如：20071117020101,该值与提交时相同。
        string orderTime = Request.QueryString["orderTime"].ToString();
        //订单金额，金额以“分”为单位，商户测试以1分测试即可，切勿以大金额测试,该值与支付时相同。
        string orderAmount = Request.QueryString["orderAmount"].ToString();
        // 快钱交易号，商户每一笔交易都会在快钱生成一个交易号。
        string dealId = Request.QueryString["dealId"].ToString();
        //银行交易号 ，快钱交易在银行支付时对应的交易号，如果不是通过银行卡支付，则为空
        string bankDealId = Request.QueryString["bankDealId"].ToString();
        //快钱交易时间，快钱对交易进行处理的时间,格式：yyyyMMddHHmmss，如：20071117020101
        string dealTime = Request.QueryString["dealTime"].ToString();
        //商户实际支付金额 以分为单位。比方10元，提交时金额应为1000。该金额代表商户快钱账户最终收到的金额。
        string payAmount = Request.QueryString["payAmount"].ToString();
        //费用，快钱收取商户的手续费，单位为分。
        string fee = Request.QueryString["fee"].ToString();
        //扩展字段1，该值与提交时相同。
        string ext1 = Request.QueryString["ext1"].ToString();
        //扩展字段2，该值与提交时相同。
        string ext2 = Request.QueryString["ext2"].ToString();
        //处理结果， 10支付成功，11 支付失败，00订单申请成功，01 订单申请失败
        string payResult = Request.QueryString["payResult"].ToString();
        //错误代码 ，请参照《人民币网关接口文档》最后部分的详细解释。
        string errCode = Request.QueryString["errCode"].ToString();
        //签名字符串 
        string signMsg = Request.QueryString["signMsg"].ToString();

        var bindCard = Request.QueryString["bindCard"];
        var bindMobile = Request.QueryString["bindMobile"];



        string signMsgVal = "";
        signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId);
        signMsgVal = appendParam(signMsgVal, "version", version);
        signMsgVal = appendParam(signMsgVal, "language", language);
        signMsgVal = appendParam(signMsgVal, "signType", signType);
        signMsgVal = appendParam(signMsgVal, "payType", payType);
        signMsgVal = appendParam(signMsgVal, "bankId", bankId);
        signMsgVal = appendParam(signMsgVal, "orderId", orderId);
        signMsgVal = appendParam(signMsgVal, "orderTime", orderTime);
        signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount);
        signMsgVal = appendParam(signMsgVal, "dealId", dealId);
        signMsgVal = appendParam(signMsgVal, "bankDealId", bankDealId);
        signMsgVal = appendParam(signMsgVal, "dealTime", dealTime);
        signMsgVal = appendParam(signMsgVal, "payAmount", payAmount);
        signMsgVal = appendParam(signMsgVal, "fee", fee);
        signMsgVal = appendParam(signMsgVal, "ext1", ext1);
        signMsgVal = appendParam(signMsgVal, "ext2", ext2);
        signMsgVal = appendParam(signMsgVal, "payResult", payResult);
        signMsgVal = appendParam(signMsgVal, "errCode", errCode);

        EyouSoft.Toolkit.Utils.WLog(string.Format("RECEIVE signMsgVal:{0}", signMsgVal), "/log/99bill.log");

        ///UTF-8编码  GB2312编码  用户可以根据自己网站的编码格式来选择加密的编码方式
        ///byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(signMsgVal);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(signMsgVal);
        byte[] SignatureByte = Convert.FromBase64String(signMsg);
        X509Certificate2 cert = new X509Certificate2(Server.MapPath("99bill.cert.rsa.20340630.cer"), "");
        //X509Certificate2 cert = new X509Certificate2(Server.MapPath("99bill[1].cert.rsa.20140803.cer"), "");
        RSACryptoServiceProvider rsapri = (RSACryptoServiceProvider)cert.PublicKey.Key;
        rsapri.ImportCspBlob(rsapri.ExportCspBlob(false));
        RSAPKCS1SignatureDeformatter f = new RSAPKCS1SignatureDeformatter(rsapri);
        byte[] result;
        f.SetHashAlgorithm("SHA1");
        SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
        result = sha.ComputeHash(bytes);
        BScenicArea2 bll = new BScenicArea2();

        if (f.VerifySignature(result, SignatureByte))
        {
            EyouSoft.Toolkit.Utils.WLog("RECEIVE V:TRUE", "/log/99bill.log");

            string rurl = string.Empty;
            //var YuMingInfo = EyouSoft.Common.Page.HuiYuanPageBase.GetYuMingInfo(); ;
            rurl = "http://" + Request.Url.Host ;

            //string DingDanId = ext1;//订单ID
            decimal payAccount = Convert.ToDecimal(payAmount);
            //EyouSoft.Model.Enum.DingDanLeiBie DingDanLeiXing = (EyouSoft.Model.Enum.DingDanLeiBie)Convert.ToInt32(ext2);//订单类型

            var trade_no = dealId;
            var out_trade_no = orderId;

            //逻辑处理  写入数据库
            if (payResult == "10")
            {


                var info = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrderByCodeOrID(new EyouSoft.Model.OtherStructure.MSearchDingDan() { DingDanBianHao = out_trade_no });
                EyouSoft.Model.OtherStructure.MChongZhi chongzhi = null;
                if (info == null || string.IsNullOrEmpty(info.OrderId) || string.IsNullOrEmpty(info.OrderCode))
                {
                    chongzhi = new EyouSoft.BLL.OtherStructure.BChongZhi().GetInfoByCode(out_trade_no);
                }
                else
                {
                }
                if (info == null && chongzhi == null) Utils.RCWE("参数异常");
                string DingDanId = string.Empty;
                if (info == null || string.IsNullOrEmpty(info.OrderId) || string.IsNullOrEmpty(info.OrderCode))
                {
                    DingDanId = chongzhi.DingDanId;
                }
                else
                {
                    DingDanId = info.OrderId;
                }
                EyouSoft.Model.Enum.DingDanLeiBie DingDanLeiXing;
                if (info == null || string.IsNullOrEmpty(info.OrderId) || string.IsNullOrEmpty(info.OrderCode))
                {
                    DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.充值订单;
                }
                else
                {

                    DingDanLeiXing = UtilsCommons.ConvterOrderType(info.OrderType);
                }
















                bool addResult = false;
                if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.商城订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.商城订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.线路订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.酒店订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.门票订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.门票订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.租车订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.团购订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.团购订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.充值订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.充值订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.签证订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.签证订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.自组团订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.自组团订单, payAccount, trade_no); }
                else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.机票订单)
                { addResult = insertDetial(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.机票订单, payAccount, trade_no); }

                if (addResult)
                {
                    switch (DingDanLeiXing)
                    {
                        case EyouSoft.Model.Enum.DingDanLeiBie.线路订单:
                            new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiZhiFus(new EyouSoft.Model.XianLuStructure.MOrderInfo() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.长线订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.商城订单:
                            new EyouSoft.BLL.MallStructure.BShangChengDingDan().SheZhiZhiFus(new EyouSoft.Model.MallStructure.MShangChengDingDan() { PayState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderID = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.商城订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiShangJiDaiLiShang(DingDanId);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.商城订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.门票订单:
                            new EyouSoft.BLL.ScenicStructure.BScenicArea().SheZhiZhiFus(new EyouSoft.Model.ScenicStructure.MScenicAreaOrder() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.门票订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            //门票出票接口????
                            bll.SubmitTicketsInterface(DingDanId);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.门票订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.酒店订单:
                            new EyouSoft.BLL.HotelStructure.BHotelOrder().SheZhiZhiFus(new EyouSoft.Model.HotelStructure.MHotelOrder() { PaymentState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.OrderState.订单出货, OrderId = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.酒店订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.租车订单:
                            new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().SheZhiZhiFus(new EyouSoft.Model.ZuCheStructure.MZuCheOrder() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.租车订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.团购订单:
                            new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().SheZhiZhiFus(new EyouSoft.Model.OtherStructure.MTuanGouDingDan() { PayState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderID = int.Parse(DingDanId) });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.团购订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.团购订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.充值订单:
                            new EyouSoft.BLL.OtherStructure.BChongZhi().SheZhiYiZhiFu(DingDanId, EyouSoft.Model.Enum.ZhiFuFangShi.快钱);
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.充值订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.充值);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.签证订单:
                            new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiZhiFus(new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, DingDanStatus = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, DingDanId = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.签证订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.签证订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.自组团订单:
                            new EyouSoft.BLL.XianLuStructure.BZiZuTuan().SheZhiZhiFus(new EyouSoft.Model.XianLuStructure.MZiZuTuan() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, ZuTuanId = DingDanId });
                            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.自组团订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                            SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.单团订单);
                            break;
                        case EyouSoft.Model.Enum.DingDanLeiBie.机票订单:
                            var OrderOptID = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(DingDanId);
                            if (OrderOptID != null)
                            {
                                new EyouSoft.BLL.JPStructure.BDingDan().SheZhiDingDanYiZhiFu(DingDanId, OrderOptID.HuiYuanId);
                                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.机票订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                                SheZhiTuiGuangYiFanLi(DingDanId, EyouSoft.Model.OtherStructure.DingDanType.机票订单);
                            }
                            break;
                        default:
                            break;
                    }
                }
                // }


                if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.充值订单)
                {
                    rurl += "/Member/UserCenter.aspx";
                }



                switch (info.OrderType)
                {
                    case EyouSoft.Model.OtherStructure.DingDanType.长线订单:
                        rurl += "/Member/XianLuOrderList.aspx?type=1";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.出境订单:
                        rurl += "/Member/XianLuOrderList.aspx?type=2";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.短线订单:
                        rurl += "/Member/XianLuOrderList.aspx?type=3";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.单团订单:
                        rurl += "/Member/DingDanList.aspx?OrderType=9";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.机票订单:
                        rurl += "/Member/JpOrderList.aspx";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.酒店订单:
                        rurl += "/Member/DingDanList.aspx?OrderType=5";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.门票订单:
                        rurl += "/Member/DingDanList.aspx?OrderType=4";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.商城订单:
                        rurl += "/Member/DingDanList.aspx?OrderType=3";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.团购订单:
                        rurl += "/Member/DingDanList.aspx?OrderType=7";
                        break;
                    case EyouSoft.Model.OtherStructure.DingDanType.租车订单:
                        rurl += "/Member/DingDanList.aspx?OrderType=8";
                        break;
                }

                Response.Write("<result>1</result>" + "<redirecturl>" + rurl + "</redirecturl>");
            }
            else
            {
                //以下是我们快钱设置的show页面，商户需要自己定义该页面。
                //Response.Write("<result>1</result>" + "<redirecturl>" + rurl + "</redirecturl>");
                Response.Write("signMsgVal=" + "(" + signMsgVal + ")");
                Response.Write("</br>" + "signMsg =" + signMsg);
                Response.Write("</br>" + "错误");
            }
        }
        else
        {
            EyouSoft.Toolkit.Utils.WLog("RECEIVE V:FALSE", "/log/99bill.log");

            Response.Write("signMsgVal=" + "(" + signMsgVal + ")");
            Response.Write("</br>" + "signMsg =" + signMsg);
            Response.Write("</br>" + "错误");
        }
    }
    //功能函数。将变量值不为空的参数组成字符串
    String appendParam(String returnStr, String paramId, String paramValue)
    {

        if (returnStr != "")
        {

            if (paramValue != "")
            {

                returnStr += "&" + paramId + "=" + paramValue;
            }

        }
        else
        {

            if (paramValue != "")
            {
                returnStr = paramId + "=" + paramValue;
            }
        }

        return returnStr;
    }

    #region 写入交易记录
    /// <summary>
    /// 写入交易记录
    /// </summary>
    /// <param name="orderid">订单编号</param>
    /// <param name="dingdanleixing">订单类型</param>
    /// <param name="jiaoyi"></param>
    bool insertDetial(string orderid, EyouSoft.Model.Enum.DingDanLeiBie DingDanLeiXing, decimal jiaoyi, string jiaoyihao)
    {
        var info = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
        info.ApiJiaoYiHao = jiaoyihao;
        info.DingDanId = orderid;
        info.DingDanLeiXing = DingDanLeiXing;
        info.HuiYuanId = string.Empty;
        info.JiaoYiHao = string.Empty;
        info.JiaoYiJinE = jiaoyi / 100M;
        info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
        info.JiaoYiMiaoShu = string.Empty;
        info.JiaoYiShiJian = DateTime.Now;
        info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
        info.MingXiId = string.Empty;
        info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.快钱;

        if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.商城订单)
        {
            var shangcheng = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(orderid);
            if (shangcheng != null)
            {
                info.JiaoYiHao = shangcheng.OrderCode;
                info.HuiYuanId = shangcheng.ContactID;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.线路订单)
        {
            var xianlu = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(orderid);
            if (xianlu != null)
            {
                info.JiaoYiHao = xianlu.OrderCode;
                info.HuiYuanId = xianlu.OperatorId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.酒店订单)
        {
            var jiudian = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(orderid);
            if (jiudian != null)
            {
                info.JiaoYiHao = jiudian.OrderCode;
                info.HuiYuanId = jiudian.OperatorId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.门票订单)
        {
            var menpiao = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(orderid);
            if (menpiao != null)
            {
                info.JiaoYiHao = menpiao.OrderCode;
                info.HuiYuanId = menpiao.OperatorId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.租车订单)
        {
            var zuche = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(orderid);
            if (zuche != null)
            {
                info.JiaoYiHao = zuche.OrderCode;
                info.HuiYuanId = zuche.OperatorId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.团购订单)
        {
            var tuangou = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetModel(int.Parse(orderid));
            if (tuangou != null)
            {
                info.JiaoYiHao = tuangou.OrderCode;
                info.HuiYuanId = tuangou.PeopleID;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.签证订单)
        {
            var qianzheng = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(orderid);
            if (qianzheng != null)
            {
                info.JiaoYiHao = qianzheng.DingDanHao;
                info.HuiYuanId = qianzheng.XiaDanRenId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.自组团订单)
        {
            var zizutuan = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().GetInfo(orderid);
            if (zizutuan != null)
            {
                info.JiaoYiHao = zizutuan.OrderCode;
                info.HuiYuanId = zizutuan.XDRId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.充值订单)
        {
            info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.充值;
            var chongzhi = new EyouSoft.BLL.OtherStructure.BChongZhi().GetInfo(orderid);
            if (chongzhi != null)
            {
                info.JiaoYiHao = chongzhi.JiaoYiHao;
                info.HuiYuanId = chongzhi.HuiYuanId;
            }
        }
        else if (DingDanLeiXing == EyouSoft.Model.Enum.DingDanLeiBie.机票订单)
        {
            var jpinfo = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(orderid);
            if (jpinfo != null)
            {
                info.JiaoYiHao = jpinfo.JiaoYiHao;
                info.HuiYuanId = jpinfo.HuiYuanId;
            }
        }

        return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
    }

    /// <summary>
    /// 设置上级代理商信息
    /// </summary>
    /// <param name="dingDanId">商城订单编号</param>
    void SheZhiShangJiDaiLiShang(string dingDanId)
    {
        if (string.IsNullOrEmpty(dingDanId)) return;
        var info = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(dingDanId);
        if (info == null) return;
        if (string.IsNullOrEmpty(info.ProductID) || string.IsNullOrEmpty(info.ProductID.Trim())) return;
        if (string.IsNullOrEmpty(info.SupplierID) || string.IsNullOrEmpty(info.SupplierID.Trim())) return;
        if (string.IsNullOrEmpty(info.ContactID) || string.IsNullOrEmpty(info.ContactID.Trim())) return;

        var daiLiKaiDianShangPinId = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("DaiLiKaiDianShangPinId");
        if (string.IsNullOrEmpty(daiLiKaiDianShangPinId)) return;

        if (info.ProductID != daiLiKaiDianShangPinId) return;

        new EyouSoft.BLL.OtherStructure.BMember().SheZhiShangJiDaiLiShang(info.ContactID, info.SupplierID);
    }

    /// <summary>
    /// 设置返联盟推广返利状态为已返利，返回1成功，其它失败
    /// </summary>
    /// <param name="dingDanId">订单编号</param>
    /// <param name="dingDanLeiXing">订单类型</param>
    /// <returns></returns>
    int SheZhiTuiGuangYiFanLi(string dingDanId, EyouSoft.Model.OtherStructure.DingDanType dingDanLeiXing)
    {
        return new EyouSoft.BLL.OtherStructure.BTuiGuang().SheZhiTuiGuangYiFanLi(dingDanId, dingDanLeiXing);
    }
    #endregion
}
