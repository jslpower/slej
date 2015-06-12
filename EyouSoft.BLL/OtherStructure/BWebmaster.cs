using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using EyouSoft.Model;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 管理员信息
    /// </summary>
    public class BWebmaster
    {
        private readonly EyouSoft.IDAL.IWebmaster dal = new EyouSoft.DAL.DWebmaster();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BWebmaster() { }
        #endregion

        #region public members
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EyouSoft.Model.MWebmaster model)
        {

            if (model != null && model.Password != null && !string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
            {
                return dal.Add(model);
            }
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EyouSoft.Model.MWebmaster model)
        {
            if (model != null && model.Id > 0)
                return dal.Update(model);
            else
                return false;
        }

        /// <summary>
        /// 权限设置
        /// </summary>
        public bool UpdatePrivs(string privs, int Id)
        {
            if (!string.IsNullOrEmpty(privs) && Id > 0)
                return dal.UpdatePrivs(privs, Id);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int Id)
        {
            if (Id > 0)
                return dal.Delete(Id);
            else
                return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MWebmaster GetModel(int Id)
        {
            if (Id > 0)
                return dal.GetModel(Id);
            else
                return null;
        }

        /// <summary>
        /// 得到一个对象实体(供应商id，代理商id)
        /// </summary>
        public EyouSoft.Model.MWebmaster GetModel(string Username)
        {
            if (!string.IsNullOrEmpty(Username))
                return dal.GetModel(Username);
            else
                return null;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MWebmaster> GetList(int pageSize, int pageIndex, ref int recordCount, MWebmasterSearchModel chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置用户是否可用
        /// </summary>
        /// <param name="uid">用户编号</param>
        /// <param name="isEnable">是否可用</param>
        /// <returns></returns>
        public int SetUserSatae(int uid, bool isEnable)
        {
            if (uid <= 0) return 0;

            return dal.SetUserSatae(uid, isEnable);
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="un">用户名</param>
        /// <param name="id">要排除的用户编号</param>
        /// <returns></returns>
        public bool ExistsUserName(string un, int id)
        {
            if (string.IsNullOrEmpty(un)) return false;

            return dal.ExistsUserName(un, id);
        }

        /// <summary>
        /// 获取供应商用户信息
        /// </summary>
        public EyouSoft.Model.MWebmaster GetGysUserInfo(string gysId)
        {
            if (string.IsNullOrEmpty(gysId)) return null;
            return dal.GetGysUserInfo(gysId);
        }
        #endregion
    }
}
