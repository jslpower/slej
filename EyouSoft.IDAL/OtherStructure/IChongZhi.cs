using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IChongZhi
    {
        /// <summary>
        /// 写入充值信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        int Add(EyouSoft.Model.OtherStructure.MChongZhi model);
        /// <summary>
        /// 获取充值信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MChongZhi GetInfo(string dingDanId);
        /// <summary>
        /// 设置支付状态，返回1成功，其它失败
        /// </summary>
        /// <param name="DingDanId">订单编号</param>
        /// <param name="zhiFuStatus">支付状态</param>
        /// <param name="zhiFuFangShi">支付方式</param>
        /// <returns></returns>
        int SheZhiZhiFuStatus(string DingDanId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus zhiFuStatus, EyouSoft.Model.Enum.ZhiFuFangShi zhiFuFangShi);
        /// <summary>
        /// 获取充值信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MChongZhi> GetChongZhis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MChongZhiChaXunInfo chaXun);
    }
}
