//签证供应商 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.QianZhengStructure
{
    public class BQianZhengGys
    {
        private readonly EyouSoft.IDAL.QianZhengStructure.IQianZhengGys dal = new EyouSoft.DAL.QianZhengStructure.DQianZhengGys();

        #region static constants
        //static constants
        #endregion

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BQianZhengGys() { }
        #endregion

        #region private members
        /// <summary>
        /// 获取签证数量
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        int GetQianZhengShu(string gysId)
        {
            if (string.IsNullOrEmpty(gysId)) return 1;

            return dal.GetQianZhengShu(gysId);
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.GysName) 
                || info.OperatorId < 1) return 0;

            info.GysId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            return dalRetCode;
        }

        /// <summary>
        /// 更新签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.GysName)
                || info.OperatorId < 1
                || string.IsNullOrEmpty(info.GysId)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            return dalRetCode;
        }

        /// <summary>
        /// 删除签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public int Delete(string gysId)
        {
            if (string.IsNullOrEmpty(gysId)) return 0;
            if (GetQianZhengShu(gysId) > 0) return -1;

            int dalRetCode = dal.Delete(gysId);

            return dalRetCode;
        }

        /// <summary>
        /// 获取签证供应商信息业务实体
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo GetInfo(string gysId)
        {
            if (string.IsNullOrEmpty(gysId)) return null;
            var info= dal.GetInfo(gysId);
            if (info != null)
            {
                var bll = new EyouSoft.BLL.OtherStructure.BWebmaster();
                var uinfo = bll.GetGysUserInfo(info.GysId);

                if (uinfo != null)
                {
                    info.UserId = uinfo.Id;
                    info.Username = uinfo.Username;
                }
                bll = null;
            }
            return info;
        }

        /// <summary>
        /// 获取签证供应商信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo> GetGyss(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengGysChaXunInfo chaXun)
        {
            if (!EyouSoft.Toolkit.Utils.ValidPaging(pageSize, pageIndex)) return null;

            var items= dal.GetGyss(pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                var bll = new EyouSoft.BLL.OtherStructure.BWebmaster();
                foreach (var item in items)
                {
                    var uinfo = bll.GetGysUserInfo(item.GysId);

                    if (uinfo != null)
                    {
                        item.UserId = uinfo.Id;
                        item.Username = uinfo.Username;
                    }
                }
                bll = null;
            }

            return items;
        }
        #endregion
    }
}
