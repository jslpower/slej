using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.WeiXin;

namespace EyouSoft.BLL.OtherStructure
{
    public class BYouJi
    {
        private readonly EyouSoft.IDAL.OtherStructure.IDYouJi dal = new EyouSoft.DAL.OtherStructure.DYouJi();
        // private readonly EyouSoft.IDAL.OtherStructure.IDYouJi dal = new EyouSoft.DAL.OtherStructure.DYouJi();
        public BYouJi()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MYouJi model)
        {
            if (string.IsNullOrEmpty(model.HuiYuanId)) return false;
            model.YouJiId = Guid.NewGuid().ToString();
            model.IssueTime = DateTime.Now;
            bool result = dal.Add(model);
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string YouJiId)
        {
            if (string.IsNullOrEmpty(YouJiId)) return false;
            return dal.Delete(YouJiId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MYouJi GetModel(string YouJiId)
        {
            if (string.IsNullOrEmpty(YouJiId)) return null;
            return dal.GetModel(YouJiId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MYouJi GetPrevModel(MYouJi model)
        {
            if (model == null) return null;
            return dal.GetPrevOrNextModel(model, -1);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MYouJi GetNextModel(MYouJi model)
        {
            if (model == null) return null;
            return dal.GetPrevOrNextModel(model, 1);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<MYouJi> GetList(int PageSize, int PageIndex, ref int RecordCount, MYouJiSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }


        /// <summary>
        /// 修改游记内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateModel(MYouJi model)
        {
            if (string.IsNullOrEmpty(model.YouJiId)) return false;
            return dal.UpdateModel(model);
        }
    }
}
