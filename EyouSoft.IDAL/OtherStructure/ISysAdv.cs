using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ISysAdv
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.MSysAdv model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MSysAdv model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string AdvID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MSysAdv GetModel(int AdvID);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.MSysAdv> GetList(EyouSoft.Model.MSearchSysAdv Search);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.MSysAdv> GetList(int PageSize,int PageIndex,ref int RecordCount,EyouSoft.Model.MSearchSysAdv Search);

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        EyouSoft.Model.MSysAdv GetModel(Model.Enum.AdvArea advArea);

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="top">广告数量</param>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        IList<EyouSoft.Model.MSysAdv> GetList(int top, Model.Enum.AdvArea advArea, string AgencyId);

        /// <summary>
        /// 获取首页所有广告信息
        /// </summary>
        /// <returns></returns>
        IList<Model.MSysAdv> GetHeadAdvList(); 
    }
}
