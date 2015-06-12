//下级分销提成信息相关interface 汪奇志 2014-10-30
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    /// <summary>
    /// 下级分销提成信息相关interface
    /// </summary>
    public interface IXiaJiFenXiaoTiCheng
    {
        /// <summary>
        /// 下级分销提成申请，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int XiaJiFenXiaoTiCheng_C(EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo info);
        /// <summary>
        /// 获取下级分销提成实体
        /// </summary>
        /// <param name="tiChengId">提成编号</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo GetInfo(string tiChengId);
        /// <summary>
        /// 获取下级分销提成集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo> GetTiChengs(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengChaXunInfo chaXun);
        /// <summary>
        /// 设置下级分销提成状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiChengId">提成编号</param>
        /// <param name="status">状态</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <returns></returns>
        int SheZhiTiChengStatus(string tiChengId, EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus status, string caoZuoRenId);
        /// <summary>
        /// 获取会员下级分销提成金额信息
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengJinEInfo GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(string huiYuanId);
    }
}
