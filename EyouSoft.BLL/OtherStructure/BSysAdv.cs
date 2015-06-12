using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BSysAdv
    {
        private readonly EyouSoft.IDAL.OtherStructure.ISysAdv dal = new EyouSoft.DAL.OtherStructure.DSysAdv();


        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.MSysAdv model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.MSysAdv model)
        {
            if (model.AdvID == 0) return false;
            return dal.Update(model) == 0 ? false : true;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="AdvID"></param>
        /// <returns></returns>
        public bool Delete(string AdvID)
        {
            if (string.IsNullOrEmpty(AdvID)) return false;
            return dal.Delete(AdvID) == 0 ? false : true;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="AdvID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MSysAdv GetModel(int AdvID)
        {
            if (AdvID == 0) return null;
            return dal.GetModel(AdvID);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysAdv> GetList(EyouSoft.Model.MSearchSysAdv Search)
        {
            return dal.GetList(Search);
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysAdv> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchSysAdv Search)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
        }

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        public EyouSoft.Model.MSysAdv GetModel(Model.Enum.AdvArea advArea)
        {
            return dal.GetModel(advArea);
        }

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="top">广告数量</param>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysAdv> GetList(int top, Model.Enum.AdvArea advArea, string AgencyId)
        {
            return dal.GetList(top, advArea, AgencyId);
        }

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="top">广告数量</param>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysAdv> GetList(int top, Model.Enum.AdvArea advArea)
        {
           return GetList(top, advArea,null);
        }

        /// <summary>
        /// 获取首页所有广告信息
        /// </summary>
        /// <returns></returns>
        public IList<Model.MSysAdv> GetHeadAdvList()
        {
            return dal.GetHeadAdvList();
        }

    }
}
