using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 旅游攻略
    /// </summary>
    public class BTravelStrategy
    {
        private readonly EyouSoft.IDAL.ITravelStrategy dal = new EyouSoft.DAL.DTravelStrategy();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BTravelStrategy() { }
        #endregion

        #region public members
        /// <summary>
        /// 增加一条数据(操作人类型:OperatorLeiXing:会员 = 0,管理=1)
        /// </summary>
        public bool Add(EyouSoft.Model.MTravelStrategy model)
        {

            if (model != null && !string.IsNullOrEmpty(model.TravelName) && !string.IsNullOrEmpty(model.OperatorId))
            {
                model.TravelID = Guid.NewGuid().ToString();
                return dal.Add(model);
            }
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据(操作人类型:OperatorLeiXing:会员 = 0,管理=1)
        /// </summary>
        public bool Update(EyouSoft.Model.MTravelStrategy model)
        {
            if (model != null && !string.IsNullOrEmpty(model.TravelID) && !string.IsNullOrEmpty(model.TravelName) && !string.IsNullOrEmpty(model.OperatorId))
                return dal.Update(model);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(string TravelID)
        {
            if (!string.IsNullOrEmpty(TravelID))
                return dal.Delete(TravelID);
            else
                return false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params string[] ids)
        {
            if (ids == null && ids.Length == 0) return false;
            return dal.Delete(ids);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MTravelStrategy GetModel(string TravelID)
        {
            if (!string.IsNullOrEmpty(TravelID))
                return dal.GetModel(TravelID);
            else
                return null;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategy> GetList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MTravelStrategyCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun, FiledOrder);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategy> GetTopList(int Top, EyouSoft.Model.MTravelStrategyCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            return dal.GetTopList((Top < 0 ? 0 : Top), chaXun, FiledOrder);
        }

        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="Id"></param>
        public bool SetClick(string TravelID)
        {
            if (!string.IsNullOrEmpty(TravelID))
                return dal.SetClick(TravelID);
            else
                return false;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id">编号</param>
        /// <param name="flag">状态</param>
        public bool SetCheck(bool flag, string TravelID)
        {
            if (!string.IsNullOrEmpty(TravelID))
                return dal.SetCheck(flag, TravelID);
            else
                return false;
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="flag">状态</param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool SetCheck(bool flag, params string[] Ids)
        {
            if (Ids.Length > 0)
                return dal.SetCheck(flag, Ids);
            else
                return false;
        }
        #endregion
    }
}
