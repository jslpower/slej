using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.MemberStructure
{
    public interface IDMemInfo
    {
        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int UpdateMemberInfo(MMember2 info);
        /// <summary>
        /// 更新会员支付密码
        /// </summary>
        /// <param name="zhifupass"></param>
        /// <returns></returns>
        int UpdateMemberZhifu(MMember2 info);
        /// <summary>
        /// 更新会员状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateMemberState(string MemberID, int States);
        /// <summary>
        /// 更新会员密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        int UpdateMemberPass(MMember2 info);
        /// <summary>
        /// 判断用户名是否存在，返回1存在，返回0不存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        int IsExistsUsername(string username);
        /// <summary>
        /// 修改会员资金
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="money">余额</param>
        /// <returns></returns>
        int UpdateMoney(string userId, decimal money);
        /// <summary>
        /// 更改申请分销商是否显示
        /// </summary>
        /// <param name="showhidden">是否显示</param>
        /// <param name="userId">会员id</param>
        /// <returns></returns>
        int UpdateShowOrHidden(EyouSoft.Model.Enum.ShowHidden showhidden, EyouSoft.Model.Enum.NavNum num, string userId);
        
        /*/// <summary>
        /// 获取总账户金额
        /// </summary>
        /// <returns></returns>
        decimal GetSumJInE();*/

        /// <summary>
        /// 获取分销商的公司介绍
        /// </summary>
        /// <param name="MemberId">会员id</param>
        /// <returns></returns>
        string GetContent(string MemberId);
        /// <summary>
        /// 修改分销商公司介绍
        /// </summary>
        /// <param name="CompanyCon">公司介绍</param>
        /// <param name="MemberId">会员Id</param>
        /// <returns></returns>
        int UpdateSellerContent(string CompanyCon, string MemberId);
        /// <summary>
        /// 获取订单支付方式
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        string GetZhiFuWay(string OrderId);
    }
}
