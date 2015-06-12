using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.JinRiApi
{
    /// <summary>
    /// 今日天下通API-异步通知接收网关
    /// </summary>
    public partial class JinRi_Notify : System.Web.UI.Page
    {
        string JinRi_Api_Notify_AnQuanJianYanMa = "6c44103d0a1b47af9c09a0aa520323c0";

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.Url.ToString();

            EyouSoft.Toolkit.Utils.WLog("通知请求URL:" + url, "/jinrilog/notify.log");

            string service = Request["service"];
            int handlerRetCode = 0;

            switch (service)
            {
                case "order_issue_notify": handlerRetCode = order_issue_notify(); break;
                default: break;
            }

            if (handlerRetCode == 1)
            {
                EyouSoft.Toolkit.Utils.WLog("通知处理结果:" + "success", "/jinrilog/notify.log");
                Utils.RCWE("success");
            }
            else
            {
                EyouSoft.Toolkit.Utils.WLog("通知处理结果:" + "fail:" + handlerRetCode, "/jinrilog/notify.log");
                Utils.RCWE("fail");
            }
            
        }

        #region private members
        /// <summary>
        /// 出票通知处理，返回1成功，其它失败
        /// </summary>
        int order_issue_notify()
        {
            string order_no = Request["order_no"];
            string status = Request["status"];
            string remark = Request["remark"];
            string passenger = Request["passenger"];
            string card_no = Request["card_no"];
            string ticket_no = Request["ticket_no"];
            string sign = Request["sign"];

            var chuPiaoNotifyInfo = new EyouSoft.Model.JPStructure.MChuPiaoNotifyInfo();
            chuPiaoNotifyInfo.ApiDingDanId = order_no;
            chuPiaoNotifyInfo.BeiZhu = remark;
            chuPiaoNotifyInfo.ChengJiRenName = passenger;
            chuPiaoNotifyInfo.ChengJiRenZhengJianHao = card_no;
            chuPiaoNotifyInfo.ChuPiaoStatus = status;
            chuPiaoNotifyInfo.DingDanId = string.Empty;
            chuPiaoNotifyInfo.HandlerRetCode = "0";           
            chuPiaoNotifyInfo.NotifyTime = DateTime.Now;
            chuPiaoNotifyInfo.PiaoHao = ticket_no;
            chuPiaoNotifyInfo.QianMing = sign;
            chuPiaoNotifyInfo.URL = Request.Url.ToString();

            var dingDanInfo = new EyouSoft.BLL.JPStructure.BDingDan().GetInfoByApiDingDanId(order_no);

            if (dingDanInfo == null)
            {
                chuPiaoNotifyInfo.HandlerRetCode = "-1";
                //写出票通知信息
                new EyouSoft.BLL.JPStructure.BJiPiao().ChuPiaoNotify_C(chuPiaoNotifyInfo);

                return -1;
            }

            chuPiaoNotifyInfo.DingDanId = dingDanInfo.DingDanId;

            var yanZhengQianMingRetCode = YanZhengChuPiaoNotifyQianMing(chuPiaoNotifyInfo);
            if (yanZhengQianMingRetCode != 1)//验证签名失败
            {
                chuPiaoNotifyInfo.HandlerRetCode = "-2";
                //写出票通知信息
                new EyouSoft.BLL.JPStructure.BJiPiao().ChuPiaoNotify_C(chuPiaoNotifyInfo);

                return -2;
            }

            if (new EyouSoft.BLL.JPStructure.BJiPiao().ChuPiaoNotify_ShiFouChuLi(dingDanInfo.DingDanId))//出票通知已成功处理
            {
                chuPiaoNotifyInfo.HandlerRetCode = "1";
                //写出票通知信息
                new EyouSoft.BLL.JPStructure.BJiPiao().ChuPiaoNotify_C(chuPiaoNotifyInfo);

                return 1;
            }

            //变更订单状态
            var dingDanStatus = EyouSoft.Model.JPStructure.DingDanStatus.出票成功;

            if (chuPiaoNotifyInfo.ChuPiaoStatus == "T")
            {
                dingDanStatus = EyouSoft.Model.JPStructure.DingDanStatus.出票成功;
            }
            else
            {
                dingDanStatus = EyouSoft.Model.JPStructure.DingDanStatus.暂不能出票;
            }

            int sheDingDingDanStatusRetCode = new EyouSoft.BLL.JPStructure.BDingDan().SheZhiDingDanStatus(dingDanInfo.DingDanId, dingDanInfo.HuiYuanId, dingDanStatus);

            if (sheDingDingDanStatusRetCode != 1)
            {
                chuPiaoNotifyInfo.HandlerRetCode = "-3";
                //写出票通知信息
                new EyouSoft.BLL.JPStructure.BJiPiao().ChuPiaoNotify_C(chuPiaoNotifyInfo);

                return -3;
            }

            //写出票通知信息
            chuPiaoNotifyInfo.HandlerRetCode = "1";
            new EyouSoft.BLL.JPStructure.BJiPiao().ChuPiaoNotify_C(chuPiaoNotifyInfo);            

            return 1;
        }

        /// <summary>
        /// 验证出票通知签证，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int YanZhengChuPiaoNotifyQianMing(EyouSoft.Model.JPStructure.MChuPiaoNotifyInfo info)
        {
            string[] items = { "service=order_issue_notify", "order_no=" + info.ApiDingDanId, "status=" + info.ChuPiaoStatus, "remark=" + info.BeiZhu, "passenger=" + info.ChengJiRenName, "card_no=" + info.ChengJiRenZhengJianHao, "ticket_no=" + info.PiaoHao };
            Array.Sort(items);
            string s = string.Join("&", items);
            s += JinRi_Api_Notify_AnQuanJianYanMa;

            var md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var encoding = System.Text.Encoding.GetEncoding("gb2312");

            byte[] bytes = encoding.GetBytes(s);
            byte[] hash = md5CSP.ComputeHash(bytes);

            StringBuilder md5 = new StringBuilder();

            foreach (byte i in hash)
            {
                md5.Append(i.ToString("X2"));
            }

            if (md5.ToString().ToLower() != info.QianMing.ToLower()) return -1;
            return 1;

            /*string md5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5");

            if (md5.ToLower() != info.QianMing.ToLower()) return -1;

            return 1;*/
        }
        #endregion
    }
}
