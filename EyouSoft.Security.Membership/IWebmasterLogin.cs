//2011-09-23 汪奇志
using System;
using EyouSoft.Model.SSOStructure;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// webmaster登录数据访问类接口
    /// </summary>
    internal interface IWebmasterLogin
    {
        /// <summary>
        /// webmaster登录，根据用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        MWebmasterInfo Login(string username, Model.CompanyStructure.PassWord pwd);
        /// <summary>
        /// 用户登录，根据用户编号获取用户信息
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        MWebmasterInfo LoginById(string userid);
        /// <summary>
        /// 用户登录，根据系统公司编号、用户名获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <returns></returns>
        MWebmasterInfo LoginByName(string username);
    }
}
