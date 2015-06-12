//返联盟推广信息相关interface 汪奇志 2014-11-04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    /// <summary>
    /// 返联盟推广信息相关interface
    /// </summary>
    public interface ITuiGuang
    {
        /// <summary>
        /// 写入返联盟推广来源信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int TuiGuangLaiYuan_C(EyouSoft.Model.OtherStructure.MTuiGuangLaiYuanInfo info);
        /// <summary>
        /// 写入返联盟推广返利信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int TuiGuangFanLi_C(EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo info);
        /// <summary>
        /// 设置返联盟推广返利比例，返回1成功，其它失败
        /// </summary>
        /// <param name="items">集合</param>
        /// <returns></returns>
        int SheZhiTuiGuangFanLiBiLi(IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> items);
        /// <summary>
        /// 获取返联盟推广返利比例集合
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> GetTuiGuangFanLiBiLis();
        /// <summary>
        /// 获取会员推广信息业务实体
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MHuiYuanTuiGuangInfo GetHuiYuanTuiGuangInfo(string huiYuanId);
        /// <summary>
        /// 获取返联盟推广返利信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo> GetTuiGuangFanLis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MTuiGuangFanLiChaXunInfo chaXun);

        /// <summary>
        /// 设置返联盟推广返利状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="fanLiSatus">返利状态</param>
        /// <param name="shiJian">操作时间</param>
        /// <param name="fanLiId">返利编号（OUTPUT）</param>
        /// <returns></returns>
        int SheZhiTuiGuangFanLiStatus(string dingDanId, EyouSoft.Model.OtherStructure.DingDanType dingDanLeiXing, EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus fanLiSatus, DateTime shiJian, out string fanLiId);

        /// <summary>
        /// 获取推广返利信息
        /// </summary>
        /// <param name="fanLiId">返利编号</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo GetTuiGuangFanLiInfo(string fanLiId);
        /// <summary>
        /// 写入分销奖励比，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int FenXiaoJiangli_C(EyouSoft.Model.OtherStructure.MJiangJiBi info);
    }
}
