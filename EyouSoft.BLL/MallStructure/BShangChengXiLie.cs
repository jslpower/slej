using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.BLL.MallStructure
{
    public class BShangChengXiLie : BLLBase
    {
        private readonly EyouSoft.IDAL.MallStructure.IShangChengXiLie dal = new EyouSoft.DAL.MallStructure.DShangChengXiLie();
        /// <summary>
        /// 判断系列名是否存在
        /// </summary>
        /// <param name="XiLieMingCheng">系列名称</param>
        /// <returns></returns>
        public bool ExistsXLName(string XiLieMingCheng)
        {
            if (string.IsNullOrEmpty(XiLieMingCheng)) return false;
            return dal.ExistsXLName(XiLieMingCheng);
        }
        /// <summary>
        /// 写入商品类型表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShangChengLeiBie info)
        {
            info.IsDelete = false;
            info.IssueTime = DateTime.Now;
            if (ExistsXLName(info.TypeName)) return 0;
            return dal.Insert(info);
        }
        /// <summary>
        /// 删除商品类型
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：类型下有产品 1：成功 其他返回值：失败</returns>
        public int Delete(string LeiXingBianHao)
        {
            if (string.IsNullOrEmpty(LeiXingBianHao) || int.Parse(LeiXingBianHao) == 0) return 0;
            return dal.Delete(LeiXingBianHao);
        }
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="LeiBieID">类型编号</param>
        /// <returns></returns>
        public MShangChengLeiBie GetModel(int LeiBieID)
        {
            if (LeiBieID == 0) return null;
            return dal.GetModel(LeiBieID);
        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MShangChengLeiBie info)
        {
            if (info.TypeID == 0) return 0;
            return dal.Update(info);
        }
        /// <summary>
        /// 获取商品类型集合
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <param name="ShiFouDingJi">是否只获取顶级分类</param>
        /// <returns></returns>
        public IList<MShangChengLeiBie> GetList(MShangChengLeiBieSer chaXun, bool ShiFouDingJi)
        {
            return dal.GetList(chaXun, ShiFouDingJi);
        }
        /// <summary>
        /// 获取商品类型集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengLeiBie> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengLeiBieSer chaXun)
        {
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun);
        }
    }
}
