//签证国家信息 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.QianZhengStructure
{
    /// <summary>
    /// 签证国家信息
    /// </summary>
    public class BQianZhengGuoJia
    {
        private readonly EyouSoft.IDAL.QianZhengStructure.IQianZhengGuoJia dal = new EyouSoft.DAL.QianZhengStructure.DQianZhengGuoJia();

        #region static constants
        //static constants
        #endregion

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BQianZhengGuoJia() { }
        #endregion

        #region private members

        #endregion

        #region public members
        /// <summary>
        /// 获取签证国家信息集合
        /// </summary>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo> GetGuoJias(EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaChaXunInfo chaXun)
        {
            return dal.GetGuoJias(chaXun);
        }

        /// <summary>
        /// 获取签证国家信息实体
        /// </summary>
        /// <param name="guoJiaId">国家编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo GetInfo(int guoJiaId)
        {
            return dal.GetInfo(guoJiaId);
        }
        #endregion
    }
}
