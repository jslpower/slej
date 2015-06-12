//返联盟推广信息相关BLL 汪奇志 2014-11-04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 返联盟推广信息相关BLL
    /// </summary>
    public class BTuiGuang
    {
        readonly EyouSoft.IDAL.OtherStructure.ITuiGuang dal = new EyouSoft.DAL.OtherStructure.DTuiGuang();
        /// <summary>
        /// 返联盟推广推广编号cookie
        /// </summary>
        const string FanLianMengTuiGuangCookieTuiGuangId = "FLMTG";
        /// <summary>
        /// 返联盟推广推广编号查询key
        /// </summary>
        const string FanLianMengTuiGuangTuiGuangIdChaXunKey = "flmtg";

        /// <summary>
        /// default constructor
        /// </summary>
        public BTuiGuang() { }


        #region private members
        /// <summary>
        /// 获取Cookie信息
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <returns></returns>
        string GetCookie(string name)
        {
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;

            if (request.Cookies[name] == null)
            {
                return string.Empty;
            }

            return System.Web.HttpContext.Current.Server.UrlDecode(request.Cookies[name].Value);
        }

        /// <summary>
        /// 获取返联盟推广编号
        /// </summary>
        /// <returns></returns>
        string GetFanLianMengTuiGuangId()
        {
            string s = string.Empty;

            s = System.Web.HttpContext.Current.Request.QueryString[FanLianMengTuiGuangTuiGuangIdChaXunKey];

            if (!string.IsNullOrEmpty(s)) return s;

            s = GetCookie(FanLianMengTuiGuangCookieTuiGuangId);

            return s;
        }

        /// <summary>
        /// 写入返联盟推广来源信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int TuiGuangLaiYuan_C(EyouSoft.Model.OtherStructure.MTuiGuangLaiYuanInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.TuiGuangId)) return 0;

            info.IssueTime = DateTime.Now;
            info.XinXiId = Guid.NewGuid().ToString();

            int dalRetCode = dal.TuiGuangLaiYuan_C(info);
            return dalRetCode;
        }

        /// <summary>
        /// 获取推广返利信息
        /// </summary>
        /// <param name="fanLiId">返利编号</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo GetTuiGuangFanLiInfo(string fanLiId)
        {
            if (string.IsNullOrEmpty(fanLiId)) return null;
            return dal.GetTuiGuangFanLiInfo(fanLiId);
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入返联盟推广来源信息，返回1成功，其它失败
        /// </summary>
        /// <returns></returns>
        public int TuiGuangLaiYuan_C()
        {
            var info = new EyouSoft.Model.OtherStructure.MTuiGuangLaiYuanInfo();

            info.IssueTime = DateTime.Now;
            info.XinXiId = Guid.NewGuid().ToString();
            info.TuiGuangId = GetFanLianMengTuiGuangId();
            info.LaiYuan = EyouSoft.Toolkit.Utils.GetReferer();

            if (string.IsNullOrEmpty(info.TuiGuangId)) return 0;


            return TuiGuangLaiYuan_C(info);
        }

        /// <summary>
        /// 写入返联盟推广返利信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int TuiGuangFanLi_C(EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo info)
        {
            if (info == null 
                || string.IsNullOrEmpty(info.DingDanId)
                || string.IsNullOrEmpty(info.XiaDanRenId)) return 0;

            info.TuiGuangId = GetFanLianMengTuiGuangId();
            if (string.IsNullOrEmpty(info.TuiGuangId)) return 0;

            info.IssueTime = DateTime.Now;
            info.FanLiId = Guid.NewGuid().ToString();

            int dalRetCode = dal.TuiGuangFanLi_C(info);

            return dalRetCode;
        }

        /// <summary>
        /// 设置返联盟推广返利比例，返回1成功，其它失败
        /// </summary>
        /// <param name="items">集合</param>
        /// <returns></returns>
        public int SheZhiTuiGuangFanLiBiLi(IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> items)
        {
            if (items == null || items.Count == 0) return 0;

            bool shiFouChongFu = false;
            for (var i = 0; i < items.Count; i++)
            {
                for (var j = 0; j < items.Count; j++)
                {
                    if (i == j) continue;
                    if (items[j].JinE == items[i].JinE) shiFouChongFu = true;
                }
            }

            if (shiFouChongFu) return -1;

            bool shiFouBaoHan0 = false;
            foreach (var item in items)
            {
                if (item.JinE == 0) { shiFouBaoHan0 = true; break; }
            }

            if (!shiFouBaoHan0) return -2;

            int dalRetCode = dal.SheZhiTuiGuangFanLiBiLi(items);

            return dalRetCode;
        }

        /// <summary>
        /// 获取返联盟推广返利比例集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> GetTuiGuangFanLiBiLis()
        {
            return dal.GetTuiGuangFanLiBiLis();
        }

        /// <summary>
        /// 获取会员推广信息业务实体
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MHuiYuanTuiGuangInfo GetHuiYuanTuiGuangInfo(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return null;

            return dal.GetHuiYuanTuiGuangInfo(huiYuanId);
        }

        /// <summary>
        /// 获取返联盟推广返利信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo> GetTuiGuangFanLis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MTuiGuangFanLiChaXunInfo chaXun)
        {
            return dal.GetTuiGuangFanLis(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置返联盟推广返利状态为已返利，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <returns></returns>
        public int SheZhiTuiGuangYiFanLi(string dingDanId, EyouSoft.Model.OtherStructure.DingDanType dingDanLeiXing)
        {
            string fanLiId = string.Empty;
            if (string.IsNullOrEmpty(dingDanId)) return 0;

            int dalRetCode = dal.SheZhiTuiGuangFanLiStatus(dingDanId, dingDanLeiXing, EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus.已返, DateTime.Now, out fanLiId);

            if (dalRetCode == 1 && !string.IsNullOrEmpty(fanLiId))
            {
                var fanLiInfo = GetTuiGuangFanLiInfo(fanLiId);

                var zhiFuMingXiInfo = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
                zhiFuMingXiInfo.ApiJiaoYiHao = string.Empty; ;
                zhiFuMingXiInfo.DingDanId = fanLiInfo.FanLiId;
                zhiFuMingXiInfo.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.返联盟推广返利;
                zhiFuMingXiInfo.HuiYuanId = fanLiInfo.TuiGuangRenHuiYuanId;
                zhiFuMingXiInfo.JiaoYiHao = fanLiInfo.FanLiJiaoYiHao;
                zhiFuMingXiInfo.JiaoYiJinE = fanLiInfo.FanLiJinE;
                zhiFuMingXiInfo.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.返联盟推广返利;
                zhiFuMingXiInfo.JiaoYiMiaoShu = string.Empty;
                zhiFuMingXiInfo.JiaoYiShiJian = DateTime.Now;
                zhiFuMingXiInfo.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
                zhiFuMingXiInfo.MingXiId = string.Empty;
                zhiFuMingXiInfo.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.E额宝;

                new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(zhiFuMingXiInfo);
            }

            return dalRetCode;
        }
        #endregion


        /// <summary>
        /// 写入返联盟推广来源信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int FenXiaoJiangli_C(EyouSoft.Model.OtherStructure.MJiangJiBi info)
        {
            if (info == null || string.IsNullOrEmpty(info.DingDanId)) return 0;

            int dalRetCode = dal.FenXiaoJiangli_C(info);
            return dalRetCode;
        }
    }
}
