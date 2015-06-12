//机票公共信息相关BLL 汪奇志 2014-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.JPStructure
{
    /// <summary>
    /// 机票公共信息相关BLL
    /// </summary>
    public class BJiPiao
    {
        #region static constants
       
        #endregion

        readonly EyouSoft.IDAL.JPStructure.IJiPiao dal = new EyouSoft.DAL.JPStructure.DJiPiao();

        #region private members
        /// <summary>
        /// 写入通知信息业务实体，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Notify_C(EyouSoft.Model.JPStructure.MNotifyInfo info)
        {
            if (info == null) return 0;
            info.NotifyId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Notify_C(info);

            return dalRetCode;
        }

        /// <summary>
        /// 获取通知处理成功次数
        /// </summary>
        /// <param name="leiXing">通知类型</param>
        /// <param name="guanLianLeiXing">关联类型</param>
        /// <param name="guanLianId">关联编号</param>
        /// <returns></returns>
        int Notify_GetChuLiCiShu(string leiXing, string guanLianLeiXing, string guanLianId)
        {
            if (string.IsNullOrEmpty(leiXing) || string.IsNullOrEmpty(guanLianLeiXing) || string.IsNullOrEmpty(guanLianId)) return 0;

            int chuLiCiShu = dal.Notify_GetChuLiCiShu(leiXing, guanLianLeiXing, guanLianId);
            return chuLiCiShu;
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入出票通知信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int ChuPiaoNotify_C(EyouSoft.Model.JPStructure.MChuPiaoNotifyInfo info)
        {
            var notifyInfo = new EyouSoft.Model.JPStructure.MNotifyInfo();

            notifyInfo.GuanLianLeiXing = "DINGDAN";
            notifyInfo.IssueTime = DateTime.Now;
            notifyInfo.LeiXing = "CHUPIAO";
            notifyInfo.NotifyId = Guid.NewGuid().ToString();
            notifyInfo.HandlerRetCode = "0";

            if (info != null)
            {
                notifyInfo.GuanLianId = info.DingDanId;                
                notifyInfo.JSON = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                notifyInfo.URL = info.URL;
                notifyInfo.HandlerRetCode = info.HandlerRetCode;
            }

            int dalRetCode = Notify_C(notifyInfo);

            return dalRetCode;
        }

        /// <summary>
        /// 出票通知是否成功处理，返回true已成功处理，返回false未处理或处理失败
        /// </summary>
        /// <param name="dingDanId">订单编号（系统）</param>
        /// <returns></returns>
        public bool ChuPiaoNotify_ShiFouChuLi(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return false;

            int chuLiCiShu = Notify_GetChuLiCiShu("CHUPIAO", "DINGDAN", dingDanId);

            if (chuLiCiShu > 0) return true;

            return false;
        }
        #endregion
    }
}
