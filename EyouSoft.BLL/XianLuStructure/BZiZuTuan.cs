using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.BLL.XianLuStructure
{
    public class BZiZuTuan
    {
        private readonly EyouSoft.IDAL.XianLuStructure.IZiZuTuan dal = new EyouSoft.DAL.XianLuStructure.DZiZuTuan();
        /// <summary>
        /// 增加自组团
        /// </summary>
        /// <param name="model">数据集</param>
        /// <returns></returns>
        public int Add(MZiZuTuan model)
        {
            if (model == null) return 0;
            
           int dalcode = dal.Add(model);
            if(dalcode==1)
            {
                 //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                jianglibi.DingDanId = model.ZuTuanId;
                jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.单团订单;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);
            }
            return dalcode;
        }
        /// <summary>
        /// 增加自组团租车行程
        /// </summary>
        /// <param name="model">数据集</param>
        /// <returns></returns>
        public void AddXC(MZiZuTuanXingCheng model)
        {
            if (model != null)
            {
                dal.AddXC(model);
            }
        }
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.XianLuStructure.MZiZuTuan> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount,EyouSoft.Model.XianLuStructure.MZiZuTuanSer model)
        {
            return dal.GetList(PageSize, PageIndex, OrderBy, ref RecordCount,model);
        }
         /// <summary>
        /// 获取提现信息业务实体
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <returns></returns>
        public MZiZuTuan GetInfo(string OrderId)
        {
            if (string.IsNullOrEmpty(OrderId)) return null;
            return dal.GetInfo(OrderId);
        }
        /// <summary>
        /// 获取自组团租车行程
        /// </summary>
        /// <param name="orderid">自组团id</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng> GetXCList(string orderid)
        {
            if (string.IsNullOrEmpty(orderid)) return null;
            return dal.GetXCList(orderid);
        }
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status)
        {
            if (string.IsNullOrEmpty(orderId)) return 0;

            int dalRetCode = dal.SheZhiOrderStatus(orderId, status);

            return dalRetCode;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MZiZuTuan info)
        {
            if (string.IsNullOrEmpty(info.ZuTuanId)) return 0;
            return dal.SheZhiZhiFus(info);
        }
    }
}
