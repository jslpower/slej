using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
namespace EyouSoft.BLL.OtherStructure
{
    public class BSystemLandMark
    {
        private readonly EyouSoft.IDAL.OtherStructure.ISystemLandMark dal = new EyouSoft.DAL.OtherStructure.DSystemLandMark();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.OtherStructure.MSystemLandMark model)
        {
            if (string.IsNullOrEmpty(model.Por) || model.CityId <= 0 || string.IsNullOrEmpty(model.CityCode))
                return false;
            return dal.Add(model) == 0 ? false : true;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.OtherStructure.MSystemLandMark model)
        {
            if (model.Id <= 0 || string.IsNullOrEmpty(model.Por) || model.CityId <= 0 || string.IsNullOrEmpty(model.CityCode))
                return false;
            return dal.Update(model) == 0 ? false : true;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool Delete(params string[] Ids)
        {
            if (Ids.Length > 0)
                return dal.Delete(Ids);
            else
                return false;
        }

        /// <summary>
        ///  得到一个对象实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MSystemLandMark GetModel(int Id)
        {
            if (Id <= 0) return null;
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MSystemLandMark> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MSystemLandMark Search)
        {
            if (!Utils.ValidPaging(PageSize, PageIndex))
                return null;
            return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MSystemLandMark> GetTopList(int Top, EyouSoft.Model.OtherStructure.MSystemLandMark Search)
        {
            return dal.GetTopList((Top < 0 ? 0 : Top), Search);
        }
    }
}
