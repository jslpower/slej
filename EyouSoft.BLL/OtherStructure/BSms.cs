using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.ConfigHelper;

namespace EyouSoft.BLL.OtherStructure
{
    public class BSms
    {
        /*
        private readonly EyouSoft.IDAL.OtherStructure.ISms dal = new EyouSoft.DAL.OtherStructure.DSms();
        /// <summary>
        /// send message enterprise id
        /// </summary>
        private string _enterpriseId = string.Empty;
        /// <summary>
        /// 发送短信超时时异常编号
        /// </summary>
        private readonly int SendTimeOutEventCode = -2147483646;

        #region private members
        /// <summary>
        /// 写入发送的短信信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.OtherStructure.MSmsInfo info)
        {
            info.IssueTime = DateTime.Now;

            return dal.Insert(info);
        }

        /// <summary>
        /// 短信发送，返回1009成功
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int FaSong(EyouSoft.Model.OtherStructure.MFaSongSmsInfo info)
        {
            if (info == null) return -2000;
            if (string.IsNullOrEmpty(info.HaoMa)) return -2001;
            if (string.IsNullOrEmpty(info.NeiRong)) return -2002;

            string _un = ConfigClass.GetConfigString("SMS_Username");
            string _pwd = ConfigClass.GetConfigString("SMS_Pwd");

            int sendResult = 0;

            try
            {
                var api = new EyouSoft.BLL.VoSmsApi.Service();
                api.Timeout = 1000;
                //发送短信返回0成功
                sendResult = api.SendSms(_enterpriseId, info.HaoMa, info.NeiRong, _un, _pwd);
            }
            catch
            {
                sendResult = SendTimeOutEventCode;
            }

            if (sendResult == 0) return 1009;

            return sendResult;
        }

        /// <summary>
        /// 根据订单类型、编号获取将要发送的短信信息集合
        /// </summary>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MDingDanDuanXinInfo> GetDingDanDuanXins(int dingDanLeiXing, string dingDanId)
        {
            if (dingDanLeiXing < 1 || dingDanLeiXing > 3 || string.IsNullOrEmpty(dingDanId)) return null;

            return dal.GetDingDanDuanXins(dingDanLeiXing, dingDanId);
        }

        /// <summary>
        /// 发送线路订单短信
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="faSongLeiXing"></param>
        void FaSongDingDanDuanXin1(string dingDanId, EyouSoft.Model.Enum.SmsFaSongLeiXing faSongLeiXing)
        {
            var items = GetDingDanDuanXins(1, dingDanId);
            if (items == null || items.Count == 0) return;

            foreach (var item in items)
            {
                var faSongSmsInfo = new EyouSoft.Model.OtherStructure.MFaSongSmsInfo();
                faSongSmsInfo.HaoMa = item.HaoMa;

                if (faSongLeiXing == EyouSoft.Model.Enum.SmsFaSongLeiXing.下单)
                {
                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.系统)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统有新的线路订单，订单号：" + item.DingDanHao + "，请及时登录系统处理订单信息。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.游客)
                    {
                        faSongSmsInfo.NeiRong = "您好，你已成功下单，订单号：" + item.DingDanHao + "，请根据订单状态及时支付。[中铁旅游]";
                    }
                }

                if (faSongLeiXing == EyouSoft.Model.Enum.SmsFaSongLeiXing.自动确认)
                {
                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.系统)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统线路订单(" + item.DingDanHao + ")状态已自动变更成待付款，请及时登录系统处理订单信息。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.游客)
                    {
                        faSongSmsInfo.NeiRong = "您好，您的订单(" + item.DingDanHao + ")状态已变更成待付款，请及时支付订单款。[中铁旅游]";
                    }
                }

                int faSongResult = FaSong(faSongSmsInfo);

                var smsInfo = new EyouSoft.Model.OtherStructure.MSmsInfo();
                smsInfo.DingDanId = dingDanId;
                smsInfo.DingDanLeiXing = 1;
                smsInfo.FaSongLeiXing = faSongLeiXing;
                smsInfo.FaSongStatus = faSongResult;
                smsInfo.HaoMa = item.HaoMa;
                smsInfo.IssueTime = DateTime.Now;
                smsInfo.JieShouRenLeiXing = item.JieShouRenLeiXing;
                smsInfo.NeiRong = faSongSmsInfo.NeiRong;

                Insert(smsInfo);
            }
        }

        /// <summary>
        /// 发送酒店订单短信
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="faSongLeiXing"></param>
        void FaSongDingDanDuanXin2(string dingDanId, EyouSoft.Model.Enum.SmsFaSongLeiXing faSongLeiXing)
        {
            var items = GetDingDanDuanXins(2, dingDanId);
            if (items == null || items.Count == 0) return;

            foreach (var item in items)
            {
                var faSongSmsInfo = new EyouSoft.Model.OtherStructure.MFaSongSmsInfo();
                faSongSmsInfo.HaoMa = item.HaoMa;

                if (faSongLeiXing == EyouSoft.Model.Enum.SmsFaSongLeiXing.下单)
                {
                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.系统)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统有新的酒店订单，订单号：" + item.DingDanHao + "，请及时登录系统处理订单信息。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.游客)
                    {
                        faSongSmsInfo.NeiRong = "您好，您已成功下单，订单号：" + item.DingDanHao + "，请根据订单状态及时支付。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.供应商)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统有新的酒店订单，订单号：" + item.DingDanHao + "，请及时登录系统处理订单信息。[中铁旅游]";
                    }
                }

                if (faSongLeiXing == EyouSoft.Model.Enum.SmsFaSongLeiXing.自动确认)
                {
                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.系统)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统酒店订单(" + item.DingDanHao + ")状态已自动变更成待付款，请及时登录系统处理订单信息。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.游客)
                    {
                        faSongSmsInfo.NeiRong = "您好，您的订单(" + item.DingDanHao + ")状态已变更成待付款，请及时支付订单款。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.供应商)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统酒店订单(" + item.DingDanHao + ")状态已自动变更成待付款，请及时登录系统处理订单信息。[中铁旅游]";
                    }
                }

                int faSongResult = FaSong(faSongSmsInfo);

                var smsInfo = new EyouSoft.Model.OtherStructure.MSmsInfo();
                smsInfo.DingDanId = dingDanId;
                smsInfo.DingDanLeiXing = 2;
                smsInfo.FaSongLeiXing = faSongLeiXing;
                smsInfo.FaSongStatus = faSongResult;
                smsInfo.HaoMa = item.HaoMa;
                smsInfo.IssueTime = DateTime.Now;
                smsInfo.JieShouRenLeiXing = item.JieShouRenLeiXing;
                smsInfo.NeiRong = faSongSmsInfo.NeiRong;

                Insert(smsInfo);
            }
        }

        /// <summary>
        /// 发送门票订单短信
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="faSongLeiXing"></param>
        void FaSongDingDanDuanXin3(string dingDanId, EyouSoft.Model.Enum.SmsFaSongLeiXing faSongLeiXing)
        {
            var items = GetDingDanDuanXins(3, dingDanId);
            if (items == null || items.Count == 0) return;

            foreach (var item in items)
            {
                var faSongSmsInfo = new EyouSoft.Model.OtherStructure.MFaSongSmsInfo();
                faSongSmsInfo.HaoMa = item.HaoMa;

                if (faSongLeiXing == EyouSoft.Model.Enum.SmsFaSongLeiXing.下单)
                {
                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.系统)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统有新的门票订单，订单号：" + item.DingDanHao + "，请及时登录系统处理订单信息。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.游客)
                    {
                        faSongSmsInfo.NeiRong = "您好，您已成功下单，订单号：" + item.DingDanHao + "，请根据订单状态及时支付。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.供应商)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统有新的门票订单，订单号：" + item.DingDanHao + "，请及时登录系统处理订单信息。[中铁旅游]";
                    }
                }

                if (faSongLeiXing == EyouSoft.Model.Enum.SmsFaSongLeiXing.自动确认)
                {
                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.系统)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统门票订单(" + item.DingDanHao + ")状态已自动变更成待付款，请及时登录系统处理订单信息。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.游客)
                    {
                        faSongSmsInfo.NeiRong = "您好，您的订单(" + item.DingDanHao + ")状态已变更成待付款，请及时支付订单款。[中铁旅游]";
                    }

                    if (item.JieShouRenLeiXing == EyouSoft.Model.Enum.SmsJieShouRenLeiXing.供应商)
                    {
                        faSongSmsInfo.NeiRong = "您好，系统门票订单(" + item.DingDanHao + ")状态已自动变更成待付款，请及时登录系统处理订单信息。[中铁旅游]";
                    }
                }

                int faSongResult = FaSong(faSongSmsInfo);

                var smsInfo = new EyouSoft.Model.OtherStructure.MSmsInfo();
                smsInfo.DingDanId = dingDanId;
                smsInfo.DingDanLeiXing = 3;
                smsInfo.FaSongLeiXing = faSongLeiXing;
                smsInfo.FaSongStatus = faSongResult;
                smsInfo.HaoMa = item.HaoMa;
                smsInfo.IssueTime = DateTime.Now;
                smsInfo.JieShouRenLeiXing = item.JieShouRenLeiXing;
                smsInfo.NeiRong = faSongSmsInfo.NeiRong;

                Insert(smsInfo);
            }
        }
        #endregion

        #region public members
        /// <summary>
        /// 发送订单短信
        /// </summary>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        public void FaSongDingDanDuanXin(int dingDanLeiXing, string dingDanId, EyouSoft.Model.Enum.SmsFaSongLeiXing faSongLeiXing)
        {
            if (dingDanLeiXing == 1) FaSongDingDanDuanXin1(dingDanId, faSongLeiXing);
            if (dingDanLeiXing == 2) FaSongDingDanDuanXin2(dingDanId, faSongLeiXing);
            if (dingDanLeiXing == 3) FaSongDingDanDuanXin3(dingDanId, faSongLeiXing);
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="status">订单状态</param>
        /// <param name="leiXing">设置类型</param>
        /// <returns></returns>
        public int SetDingDanStatus(int dingDanLeiXing, string dingDanId, int status, EyouSoft.Model.Enum.SetDingDanStatusLeiXing leiXing)
        {
            return dal.SetDingDanStatus(dingDanLeiXing, dingDanId, status, leiXing);
        }
        #endregion
        */
    }
}
