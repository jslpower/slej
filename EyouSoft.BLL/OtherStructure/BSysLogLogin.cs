using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BSysLogLogin
    {
        private EyouSoft.IDAL.OtherStructure.ISysLogLogin dal = new EyouSoft.DAL.OtherStructure.DSysLogLogin();

        #region ISysLogLogin 成员
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.MSysLogLogin model)
        {
            model.Id = Guid.NewGuid().ToString();
            return dal.Add(model) == 0 ? false : true;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.MSysLogLogin model)
        {
            if (string.IsNullOrEmpty(model.Id)
                || string.IsNullOrEmpty(model.OperatorId)) return false;
            return dal.Update(model) == 0 ? false : true;

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return false;
            return dal.Delete(Id) == 0 ? false : true;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.MSysLogLogin GetModel(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            return dal.GetModel(Id);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysLogLogin> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchSysLogLogin Search)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
        }

        #endregion
    }
}
