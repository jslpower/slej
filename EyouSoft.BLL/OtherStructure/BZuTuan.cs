using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;


namespace EyouSoft.BLL.OtherStructure
{
    public class BZuTuan 
    {
        private readonly EyouSoft.IDAL.OtherStructure.IZuTuan dal = new EyouSoft.DAL.OtherStructure.DZuTuan();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MZuTuan model)
        {
            return dal.Add(model) == 0 ? false : true;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(MZuTuan model)
        {
            if (model == null) return false;
            return dal.Update(model) == 0 ? false : true;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MZuTuan GetModel()
        {
            return dal.GetModel();
        }
    }
}
