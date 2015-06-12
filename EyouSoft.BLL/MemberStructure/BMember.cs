using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;

namespace EyouSoft.BLL.MemberStructure
{
    public class BMember
    {
        EyouSoft.IDAL.MemberStructure.IDMemInfo dal = new EyouSoft.DAL.MemberStructure.DMember();

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMemberInfo(MMember2 model)
        {
            if (string.IsNullOrEmpty(model.MemberID) || string.IsNullOrEmpty(model.MemberName)) return false;

            int count = dal.UpdateMemberInfo(model);
            if (count > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
        /// <summary>
        /// 更新会员支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMemberZhifu(MMember2 model)
        {
            if (string.IsNullOrEmpty(model.ZhiFuPassword) || string.IsNullOrEmpty(model.MemberID)) return false;

            int count = dal.UpdateMemberZhifu(model);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 更新会员状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMemberState(string MemberID, int States)
        {
            if (string.IsNullOrEmpty(MemberID)) return false;

            int count = dal.UpdateMemberState(MemberID,States);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新会员密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMemberPass(MMember2 model)
        {
            if (string.IsNullOrEmpty(model.PassWord) || string.IsNullOrEmpty(model.MemberID)) return false;
            model.MD5Password = new PassWord(model.PassWord).MD5Password;
            int count = dal.UpdateMemberPass(model);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 更新会员余额
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="money">余额</param>
        /// <returns></returns>
        public int UpdateMoney(string userId, decimal money)
        {
            if (string.IsNullOrEmpty(userId) || money == null) return 0;

            return dal.UpdateMoney(userId, money);

        }

        /// <summary>
        /// 判断用户名是否存在，返回1存在，返回0不存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public int IsExistsUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return 1;

            return dal.IsExistsUsername(username);
        }

        /// <summary>
        /// 更改申请分销商是否显示
        /// </summary>
        /// <param name="showhidden">是否显示</param>
        /// <param name="userId">会员id</param>
        /// <returns></returns>
        public int UpdateShowOrHidden(EyouSoft.Model.Enum.ShowHidden showhidden,EyouSoft.Model.Enum.NavNum num , string userId)
        {
            if (string.IsNullOrEmpty(userId)) return 0;

            return dal.UpdateShowOrHidden(showhidden,num,userId);
        }

        /*/// <summary>
        /// 获取总账户金额
        /// </summary>
        /// <returns></returns>
        public decimal GetSumJInE()
        {
            return dal.GetSumJInE();
        }*/

        /// <summary>
        /// 获取分销商的公司介绍
        /// </summary>
        /// <param name="MemberId">会员id</param>
        /// <returns></returns>
        public string GetContent(string MemberId)
        {
            if (string.IsNullOrEmpty(MemberId)) return "";
            return dal.GetContent(MemberId);
        }
        /// <summary>
        /// 修改分销商公司介绍
        /// </summary>
        /// <param name="CompanyCon">公司介绍</param>
        /// <param name="MemberId">会员Id</param>
        /// <returns></returns>
        public int UpdateSellerContent(string CompanyCon, string MemberId)
        {
            if (string.IsNullOrEmpty(MemberId)) return 0;
            return dal.UpdateSellerContent(CompanyCon, MemberId);
        }
        /// <summary>
        /// 获取订单支付方式
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        public string GetZhiFuWay(string OrderId)
        {
            if (string.IsNullOrEmpty(OrderId)) return "暂未付款";
            return dal.GetZhiFuWay(OrderId);
        }
    }
}
