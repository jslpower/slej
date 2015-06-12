/*//机票订单相关接口 汪奇志 2013-12-03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.JiPiaoStructure
{
    /// <summary>
    /// 机票订单接口
    /// </summary>
    public interface IJiPiaoDingDan
    {
        /// <summary>
        /// 写入机票航班信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertHangBan(EyouSoft.Model.JiPiaoStructure.MHangBanInfo info);
        /// <summary>
        /// 写入机票订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo info);
        /// <summary>
        /// 更新机票订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo info);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <returns></returns>
        int SheZhiDingDanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus dingDanStatus);
        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <returns></returns>
        int SheZhiFuKuanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus);
        /// <summary>
        /// 设置出票状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="chuPiaoStatus">出票状态</param>
        /// <returns></returns>
        int SheZhiChuPiaoStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus chuPiaoStatus);
        /// <summary>
        /// 获取订单信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo GetInfo(string dingDanId);
        /// <summary>
        /// 获取航班信息业务实体
        /// </summary>
        /// <param name="hangBanId">航班编号</param>
        /// <returns></returns>
        EyouSoft.Model.JiPiaoStructure.MHangBanInfo GetHangBanInfo(string hangBanId);
        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo> GetDingDans(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanChaXunInfo chaXun);
    }
}
*/