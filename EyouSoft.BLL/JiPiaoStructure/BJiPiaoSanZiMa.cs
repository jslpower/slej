/*//机票-城市三字码信息 汪奇志 2013-11-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EyouSoft.BLL.JiPiaoStructure
{
    /// <summary>
    /// 机票-城市三字码信息
    /// </summary>
    public class BJiPiaoSanZiMa
    {
        private readonly EyouSoft.IDAL.JiPiaoStructure.IJiPiaoSanZiMa dal = new EyouSoft.DAL.JiPiaoStructure.DJiPiaoSanZiMa();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiPiaoSanZiMa() { }
        #endregion

        #region public members
        /// <summary>
        /// 获取三字码信息集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo> GetSanZiMas()
        {
            //return dal.GetSanZiMas();
            var items = (IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo>)HttpRuntime.Cache.Get("JiPiaoSanZiMas");

            if (items == null)
            {
                items = dal.GetSanZiMas();
                HttpRuntime.Cache.Insert("JiPiaoSanZiMas", items);
            }

            return items;
        }

        /// <summary>
        /// 获取三字码信息业务实体
        /// </summary>
        /// <param name="code">三字码</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo GetSanZiMaInfo(string code)
        {
            //return dal.GetSanZiMaInfo(code);
            EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo info = null;

            var items = GetSanZiMas();

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Code == code)
                    {
                        info = item;
                        break;
                    }
                }
            }

            return info;
        }
        #endregion
    }
}
*/