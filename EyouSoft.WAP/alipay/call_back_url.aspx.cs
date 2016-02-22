using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Collections.Generic;
using EyouSoft.Common;
using System.Drawing;
using System.IO;
using Eyousoft_yhq.AlipayLibrary;
using EyouSoft.Common;
using EyouSoft.BLL.ScenicStructure;

namespace Eyousoft_yhq.Web.Alipay
{
    public partial class call_back_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.VerifyReturn(sPara, Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表

                    //商户订单号
                    string out_trade_no = Request.QueryString["out_trade_no"];

                    //支付宝交易号
                    string trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    string result = Request.QueryString["result"];

                    string payAmount = Request.QueryString["total_fee"];

                    string ext2 = Request.QueryString["agent_id"];



                    decimal payAccount = Convert.ToDecimal(payAmount)*100;


                    //int isZhiFuRetCode = new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().IsZhiFu(DingDanId, DingDanLeiXing);
                    BScenicArea2 bll = new BScenicArea2();
                    EyouSoft.Model.Enum.DingDanLeiBie DingDanLeiXing;
                    EyouSoft.Model.OtherStructure.DingDanType OrderType;
                    string DingDanId;
                    if (out_trade_no.StartsWith("CZ"))
                    {
                        var info = new EyouSoft.BLL.OtherStructure.BChongZhi().GetInfoByCode(out_trade_no);
                        if (info == null) Utils.RCWE("参数异常");
                        DingDanId = info.DingDanId;
                        DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.充值订单; //订单类型
                        OrderType = EyouSoft.Model.OtherStructure.DingDanType.充值订单;
                    }
                    else
                    {

                        var info = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrderByCodeOrID(new EyouSoft.Model.OtherStructure.MSearchDingDan() { DingDanBianHao = out_trade_no });
                        if (info == null) Utils.RCWE("参数异常");
                        DingDanId = info.OrderId;
                        DingDanLeiXing = UtilsCommons.ConvterOrderType(info.OrderType); //订单类型
                        OrderType = info.OrderType;
                    }

                    string res = string.Empty;
                    if (result == "success")
                    {



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
                                    new EyouSoft.BLL.OtherStructure.BChongZhi().SheZhiYiZhiFu(DingDanId, EyouSoft.Model.Enum.ZhiFuFangShi.支付宝);
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
                    }

                    switch (OrderType)
                    {
                        case EyouSoft.Model.OtherStructure.DingDanType.长线订单:
                            Response.Redirect("Member/XianLuOrderList.aspx?type=1");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.出境订单:
                            Response.Redirect("/Member/XianLuOrderList.aspx?type=2");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.短线订单:
                            Response.Redirect("/Member/XianLuOrderList.aspx?type=3");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.单团订单:
                            Response.Redirect("/Member/DingDanList.aspx?OrderType=9");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.机票订单:
                            Response.Redirect("/Member/JpOrderList.aspx");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.酒店订单:
                            Response.Redirect("/Member/DingDanList.aspx?OrderType=5");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.门票订单:
                            Response.Redirect("/Member/DingDanList.aspx?OrderType=4");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.商城订单:
                            Response.Redirect("/Member/DingDanList.aspx?OrderType=3");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.团购订单:
                            Response.Redirect("/Member/DingDanList.aspx?OrderType=7");
                            break;
                        case EyouSoft.Model.OtherStructure.DingDanType.租车订单:
                            Response.Redirect("/Member/DingDanList.aspx?OrderType=8");
                            break;
                    }


                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("验证失败");
                }
            }
            else
            {
                Response.Write("无返回参数");
            }
        }
        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public Dictionary<string, string> GetRequestGet()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
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
            info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.支付宝;

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
                var JIPIAO = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(orderid);
                if (JIPIAO != null)
                {
                    info.JiaoYiHao = JIPIAO.JiaoYiHao;
                    info.HuiYuanId = JIPIAO.HuiYuanId;
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
}
