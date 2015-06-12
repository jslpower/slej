//交易明细信息相关interface 汪奇志 2014-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IJiaoYiMingXi
    {
        /// <summary>
        /// 写入交易明细信息业务实体，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int JiaoYiMingXi_C(EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo info);
        /// <summary>
        /// 获取交易明细信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo> GetJiaoYiMingXis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MJiaoYiMingXiChaXunInfo chaXun);
        /// <summary>
        /// 获取系统余额信息业务实体
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MYuEInfo GetYuEInfo();
        /// <summary>
        /// 设置明细状态，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="dingDanId">交易订单编号</param>
        /// <param name="dingDanLeiXing">交易订单类型</param>
        /// <param name="jiaoYiLeiBie">交易类别</param>
        /// <param name="zhiFuFangShi">交易支付方式</param>
        /// <param name="jiaoYiStatus">交易状态</param>
        /// <returns></returns>
        int SheZhiMingXiStatus(string huiYuanId, string dingDanId, EyouSoft.Model.Enum.DingDanLeiBie dingDanLeiXing, EyouSoft.Model.Enum.JiaoYiLeiBie jiaoYiLeiBie, EyouSoft.Model.Enum.ZhiFuFangShi zhiFuFangShi, EyouSoft.Model.Enum.JiaoYiStatus jiaoYiStatus);

        /// <summary>
        /// 是否支付，返回1已支付，返回0未支付，其它为异常
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <returns></returns>
        int IsZhiFu(string dingDanId, EyouSoft.Model.Enum.DingDanLeiBie dingDanLeiXing);
    }
}
