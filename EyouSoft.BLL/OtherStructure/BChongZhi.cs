using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BChongZhi
    {
        private readonly EyouSoft.IDAL.OtherStructure.IChongZhi dal = new EyouSoft.DAL.OtherStructure.DChongZhi();

        /// <summary>
        /// 写入充值信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.OtherStructure.MChongZhi model)
        {
            if (model == null || string.IsNullOrEmpty(model.HuiYuanId) || model.JinE <= 0) return 0;

            model.Issuetime = DateTime.Now;
            model.DingDanId = Guid.NewGuid().ToString();
            model.ZhiFuStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;

            int dalRetCode = dal.Add(model);
            return dalRetCode;
        }

        /// <summary>
        /// 获取充值信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MChongZhi GetInfo(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;

            return dal.GetInfo(dingDanId);
        }

        /// <summary>
        /// 设置支付状态为已支付，返回1成功，其它失败
        /// </summary>
        /// <param name="DingDanId">订单编号</param>
        /// <param name="zhiFuStatus">支付状态</param>
        /// <param name="zhiFuFangShi">支付方式</param>
        /// <returns></returns>
        public int SheZhiYiZhiFu(string DingDanId, EyouSoft.Model.Enum.ZhiFuFangShi zhiFuFangShi)
        {
            if (string.IsNullOrEmpty(DingDanId)) return 0;
            int dalRetCode = dal.SheZhiZhiFuStatus(DingDanId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, zhiFuFangShi);
            return dalRetCode;
        }

        /// <summary>
        /// 获取充值信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MChongZhi> GetChongZhis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MChongZhiChaXunInfo chaXun)
        {
            return dal.GetChongZhis(pageSize, pageIndex, ref recordCount, chaXun);
        }
    }
}
