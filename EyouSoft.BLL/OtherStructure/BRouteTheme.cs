using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BRouteTheme
    {

        private readonly EyouSoft.IDAL.OtherStructure.IRouteTheme dal = new EyouSoft.DAL.OtherStructure.DRouteTheme();


        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.MRouteTheme model)
        {
            if (string.IsNullOrEmpty(model.Name)) return false;
            return dal.Add(model) == 0 ? false : true;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.MRouteTheme model)
        {
            if (model.ID == 0) return false;
            return dal.Update(model) == 0 ? false : true;

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            if (ID == 0) return false;
            return dal.Delete(ID) == 0 ? false : true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MRouteTheme GetModel(int ID)
        {
            if (ID == 0) return null;
            return dal.GetModel(ID);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MRouteTheme> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MRouteTheme> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {

            return dal.GetList(PageSize, PageIndex, ref RecordCount);
        }


    }
}
