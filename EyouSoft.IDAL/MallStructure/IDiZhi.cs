using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MemberStructure;

namespace EyouSoft.IDAL.MallStructure
{
    /// <summary>
    /// 地址
    /// </summary>
    public interface IDiZhi
    {
        /// <summary>
        /// 写入地址表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MDiZhi info);
        /// <summary>
        /// 修改地址表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MDiZhi info);
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        int Delete(string dizhi);
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="id">地址编号</param>
        /// <returns></returns>
        MDiZhi GetModel(int id);
        /// <summary>
        /// 获取地址列表
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        IList<MDiZhi> GetList(MDiZhiSer sermodel);
    }
}
