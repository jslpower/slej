//机票订单信息相关interface 汪奇志 2014-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.JPStructure
{
    /// <summary>
    /// 机票订单信息相关interface
    /// </summary>
    public interface IDingDan
    {
        /// <summary>
        /// 创建订单，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int DingDan_C(EyouSoft.Model.JPStructure.MDingDanInfo info);
        /// <summary>
        /// 删除订单，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        int DingDan_D(string dingDanId);
        /// <summary>
        /// 获取订单信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MDingDanInfo GetInfo(string dingDanId);
        /// <summary>
        /// 写入订单相关信息，返回1成功，其它失败
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        int DingDanXiangGuan_C(IList<EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo> items);
        /// <summary>
        /// 设置订单付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="huiYuanId">下单人会员编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <param name="fuKuanShiJian">付款时间</param>
        /// <param name="dingDanStatus">订单状态 null时订单状态原值不变</param>
        /// <returns></returns>
        int SheZhiDingDanFuKuanStatus(string dingDanId, string huiYuanId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus, DateTime fuKuanShiJian, EyouSoft.Model.JPStructure.DingDanStatus? dingDanStatus);
        /// <summary>
        /// 设置订单向API付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiangApiFuKuanStatus">向API付款状态</param>
        /// <param name="xiangApiFuKuanShiJian">向API付款时间</param>
        /// <param name="dingDanStatus">订单状态 null时订单状态原值不变</param>
        /// <returns></returns>
        int SheZhiDingDanXiangApiFuKuanStatus(string dingDanId, EyouSoft.Model.JPStructure.XiangApiFuKuanStatus xiangApiFuKuanStatus, DateTime xiangApiFuKuanShiJian, EyouSoft.Model.JPStructure.DingDanStatus? dingDanStatus);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <returns></returns>
        int SheZhiDingDanStatus(string dingDanId, string huiYuanId, EyouSoft.Model.JPStructure.DingDanStatus dingDanStatus);
        /// <summary>
        /// 获取订单信息业务实体-根据API订单编号
        /// </summary>
        /// <param name="apiDingDanId">API订单编号</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MDingDanInfo GetInfoByApiDingDanId(string apiDingDanId);
    }
}
