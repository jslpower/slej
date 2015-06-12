using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.IDAL
{
    public interface IWebmaster
    {
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="un">用户名</param>
        /// <param name="id">要排除的用户编号</param>
        /// <returns></returns>
        bool ExistsUserName(string un, int id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(EyouSoft.Model.MWebmaster model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(EyouSoft.Model.MWebmaster model);
        /// <summary>
        /// 权限设置
        /// </summary>
        bool UpdatePrivs(string privs, int Id);
        /// <summary>
        /// 删除数据
        /// </summary>
        bool Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MWebmaster GetModel(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MWebmaster GetModel(string Username);
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        IList<EyouSoft.Model.MWebmaster> GetList(int PageSize, int PageIndex, ref int RecordCount, MWebmasterSearchModel Search);

        /// <summary>
        /// 设置用户是否可用
        /// </summary>
        /// <param name="uid">用户编号</param>
        /// <param name="isEnable">是否可用</param>
        /// <returns></returns>
        int SetUserSatae(int uid, bool isEnable);
        /// <summary>
        /// 获取供应商用户信息
        /// </summary>
        EyouSoft.Model.MWebmaster GetGysUserInfo(string gysId);
    }
}
