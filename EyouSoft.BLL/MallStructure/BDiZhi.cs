using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.MemberStructure;

namespace EyouSoft.BLL.MallStructure
{
    public class BDiZhi : BLLBase
    {
        private readonly EyouSoft.IDAL.MallStructure.IDiZhi dal = new EyouSoft.DAL.MallStructure.DDiZhi();
        /// <summary>
        /// 写入地址表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MDiZhi info)
        {
            info.IssueTime = DateTime.Now;
            info.IsDelete = false;
            return dal.Insert(info);
        }
        /// <summary>
        /// 修改地址表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MDiZhi info)
        {
            if (info.AddressID == 0) return 0;
            return dal.Update(info);

        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>1：成功 其他返回值：失败</returns>
        public int Delete(string dizhi)
        {
            if (string.IsNullOrEmpty(dizhi)) return 0;
            return dal.Delete(dizhi);
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="id">地址编号</param>
        /// <returns></returns>
        public MDiZhi GetModel(int id)
        {
            if (id == 0) return null;
            return dal.GetModel(id);

        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public IList<MDiZhi> GetList(MDiZhiSer sermodel)
        {
            return dal.GetList(sermodel);
        }

    }
}
