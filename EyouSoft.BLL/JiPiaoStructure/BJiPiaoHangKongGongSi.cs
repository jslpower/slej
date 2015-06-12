/*//机票-航空公司信息 汪奇志 2013-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EyouSoft.BLL.JiPiaoStructure
{
    /// <summary>
    /// 机票-航空公司信息
    /// </summary>
    public class BJiPiaoHangKongGongSi
    {
        private readonly EyouSoft.IDAL.JiPiaoStructure.IJiPiaoHangKongGongSi dal = new EyouSoft.DAL.JiPiaoStructure.DJiPiaoHangKongGongSi();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiPiaoHangKongGongSi() { }
        #endregion

        #region public members
        /// <summary>
        /// 获取航空公司信息集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo> GetHangKongGongSis()
        {
            //return dal.GetHangKongGongSis();
            var items = (IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo>)HttpRuntime.Cache.Get("JiPiaoHangKongGongSis");

            if (items == null)
            {
                items = dal.GetHangKongGongSis();
                HttpRuntime.Cache.Insert("JiPiaoHangKongGongSis", items);
            }

            return items;
        }

        /// <summary>
        /// 获取航空公司信息业务实体
        /// </summary>
        /// <param name="code">航空公司代码</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo GetHangKongGongSiInfo(string code)
        {
            //return dal.GetHangKongGongSiInfo(code);
            EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo info = null;
            var items = GetHangKongGongSis();

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