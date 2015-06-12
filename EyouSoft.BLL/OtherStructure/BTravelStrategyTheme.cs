using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 旅游攻略类别
    /// </summary>
    public class BTravelStrategyTheme
    {
        private readonly EyouSoft.IDAL.ITravelStrategyTheme dal = new EyouSoft.DAL.DTravelStrategyTheme();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BTravelStrategyTheme() { }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(EyouSoft.Model.MTravelStrategyTheme model)
        {
            if (!string.IsNullOrEmpty(model.ClassName))
                return dal.Add(model) == 0 ? false : true;
            else
                return false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.MTravelStrategyTheme model)
        {
            if (!string.IsNullOrEmpty(model.ClassName) && model.ThemeID > 0)
                return dal.Update(model) == 0 ? false : true;
            else
                return false;

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public bool Delete(string ThemeID)
        {
            if (string.IsNullOrEmpty(ThemeID)) return false;
            return dal.Delete(ThemeID) == 0 ? false : true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MTravelStrategyTheme GetModel(int ThemeID)
        {
            if (ThemeID == 0) return null;
            return dal.GetModel(ThemeID);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategyTheme> GetList(EyouSoft.Model.MTravelStrategyTheme Search)
        {
            return dal.GetList(Search);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategyTheme> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MTravelStrategyTheme Search)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
        }
    }
}
