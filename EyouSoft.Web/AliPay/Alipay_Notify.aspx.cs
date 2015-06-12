/*using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Net;
using Adpost.Common;

namespace WEB.AliPay
{
    /// <summary>
    /// 支付宝返回后的结果处理程序
    /// </summary>
    public partial class Alipay_Notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PayAPI.Model.Ali.AliPayTradeNotify notify = PayAPI.Ali.Alipay.Create.GetNotifyAsync();//支付宝的返回通知实体
            if (notify.IsTradeSuccess)
            {
                var model = new EyouSoft.Model.OnLinePayRecord();//在线支付实体
                var onlinepay = new EyouSoft.BLL.OtherStructure.BOnLinePay();//在线支付BLL
                foreach (var item in notify.OrderInfo.OrderID)
                {
                    model.OrderId = item;//订单ID
                    model.OrderType = (EyouSoft.Model.OrderType)Convert.ToInt32(notify.AttachList["OrderType"].Value);//订单类型
                    bool ispay = onlinepay.IsPaySuccess(model.OrderId, model.OrderType);//获取订单支付状态（成功/失败）
                    if (ispay == false)
                    {
                        model.OutTradeNo = notify.OutTradeNo;//流水号
                        model.TradeNo = notify.TradeNo;//支付流水号
                        model.Totalfee = notify.Totalfee;//支付金额
                        model.PayType = EyouSoft.Model.PayType.Alipay;//支付方式
                        model.IsPay = true;//是否已支付
                        model.SuccessTime = DateTime.Now;//支付时间
                        bool isAdd = onlinepay.Add(model);//添加支付记录
                        if (isAdd)
                        {
                            //实现其它操作处理 
                            switch (model.OrderType)
                            {
                                case EyouSoft.Model.OrderType.Tour:
                                    this.HandleXianluDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.Spot:
                                    this.HandleJingDianDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.Hotel:
                                    this.HandleJiuDianDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.QianZheng:
                                    this.HandleQianZhengDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.JiPiao:
                                    this.HandleJiPiaoDingDan(model.OrderId);
                                    break;
                            }
                        }
                    }
                }
                onlinepay = null; model = null;
            }
            //支付接口回调通知
            Response.Write(notify.PayAPICallBackMsg);
            Response.End();
        }

        /// <summary>
        /// 处理酒店订单信息
        /// </summary>
        /// <param name="orderId"></param>
        private void HandleJiuDianDingDan(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            var info = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(orderId);

            if (info == null) return;

            new EyouSoft.BLL.HotelStructure.BHotelOrder().UpdatePaymentState(
                EyouSoft.Model.Enum.PaymentState.已支付, orderId);

            SaveTotal(info.TotalAmount, info.OperatorId, info.OrderId, EyouSoft.Model.Enum.OrderClass.酒店);
        }

        /// <summary>
        /// 处理景区订单信息
        /// </summary>
        /// <param name="orderId"></param>
        private void HandleJingDianDingDan(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            var info = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(orderId);

            if (info == null) return;

            new EyouSoft.BLL.ScenicStructure.BScenicArea().SheZhiFuKuanStatus(
                orderId, info.OperatorId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款);

            SaveTotal(info.Price, info.OperatorId, info.OrderId, EyouSoft.Model.Enum.OrderClass.门票);
        }

        /// <summary>
        /// 处理线路订单信息
        /// </summary>
        /// <param name="orderId"></param>
        private void HandleXianluDingDan(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            EyouSoft.Model.XianLuStructure.MOrderInfo info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(orderId);
            if (info != null)
            {
                var history = new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo
                    {
                        BeiZhu = string.Empty,
                        LeiXing = EyouSoft.Model.Enum.XianLuStructure.OrderHistoryLeiXing.设置付款状态,
                        OperatorLeiXing = EyouSoft.Model.Enum.OperatorLeiXing.会员,
                        OrderId = orderId,
                        Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款
                    };

                int result=new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiFuKuanStatus(orderId, info.OperatorId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, history);

                if (result == 1)
                {
                    new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiOrderStatus(orderId,  EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, history);
                }

                SaveTotal(info.JinE, info.OperatorId, info.OrderId, EyouSoft.Model.Enum.OrderClass.线路);
            }
        }

        /// <summary>
        /// 处理签证订单
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        void HandleQianZhengDingDan(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return;
            var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(dingDanId);
            if (info == null) return;

            new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiFuKuanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款);
            new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiDingDanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货);

            SaveTotal(info.JinE, info.XiaDanRenId, info.DingDanId, EyouSoft.Model.Enum.OrderClass.签证);
        }

        /// <summary>
        /// 处理机票订单
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        void HandleJiPiaoDingDan(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return;
            var info = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().GetInfo(dingDanId);
            if (info == null) return;

            new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().SheZhiFuKuanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款);
            new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().SheZhiDingDanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货);

            SaveTotal(info.JinE, info.XiaDanRenId, info.DingDanId, EyouSoft.Model.Enum.OrderClass.机票);
        }

        /// <summary>
        /// 订单获取积分
        /// </summary>
        bool SaveTotal(decimal money, string OperatorId, string OrderId, EyouSoft.Model.Enum.OrderClass orderClass)
        {
            if (!(new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(OrderId, OperatorId)))
            {
                var model = new EyouSoft.BLL.OtherStructure.BKV().GetCompanySetting();
                int tatol = 0;
                if (model == null)
                    tatol = Convert.ToInt32(Math.Round(money));
                else
                {
                    int jf = 0;

                    if (orderClass == EyouSoft.Model.Enum.OrderClass.酒店)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.HotelTatol.Trim());
                    if (orderClass == EyouSoft.Model.Enum.OrderClass.门票)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.ScenicTatol.Trim());
                    if (orderClass == EyouSoft.Model.Enum.OrderClass.线路)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.RouteTatol.Trim());
                    if(orderClass== EyouSoft.Model.Enum.OrderClass.签证)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.QianZhengDingDanJiFenPeiZhi.Trim());
                    if(orderClass== EyouSoft.Model.Enum.OrderClass.机票)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.JiPiaoDingDanJiFenPeiZhi.Trim());

                    tatol = Convert.ToInt32(Math.Round(money / (jf == 0 ? 1 : jf)));
                }
                if (tatol > 0)
                {
                    EyouSoft.Model.OtherStructure.MMemberTotal addTotal = new EyouSoft.Model.OtherStructure.MMemberTotal();
                    addTotal.MemberID = OperatorId;
                    addTotal.OrderId = OrderId;
                    addTotal.OrderType = orderClass;
                    addTotal.Total = tatol;
                    return new EyouSoft.BLL.OtherStructure.BTatolProduct().AddMemberTotal(addTotal);
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
*/