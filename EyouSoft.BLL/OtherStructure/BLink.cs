using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BLink
    {
        private readonly EyouSoft.IDAL.OtherStructure.ILink dal = new EyouSoft.DAL.OtherStructure.DLink();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(EyouSoft.Model.MLink model)
        {
            model.LinkID = Guid.NewGuid().ToString();
            return dal.Add(model) == 0 ? false : true;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.MLink model)
        {
            if (string.IsNullOrEmpty(model.LinkID)) return false;
            return dal.Update(model) == 0 ? false : true;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public bool Delete(string LinkID)
        {
            if (string.IsNullOrEmpty(LinkID)) return false;
            return dal.Delete(LinkID) == 0 ? false : true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MLink GetModel(string LinkID)
        {
            if (string.IsNullOrEmpty(LinkID)) return null;
            return dal.GetModel(LinkID);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MLink> GetList()
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
        public IList<EyouSoft.Model.MLink> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<EyouSoft.Model.MLink> GetList(int Top)
        {
            return dal.GetList(Top);
        }

    }
}
