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
        /// 代理商，员工，免费代理修改信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateDaiLiMemberInfo(MMember2 model)
        {
            if (string.IsNullOrEmpty(model.MemberID)) return false;

            int count = dal.UpdateDaiLiMemberInfo(model);
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
        /// 代理商，员工，免费代理修改代理信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateDaiLiSellerInfo(EyouSoft.Model.AccountStructure.MSellers model)
        {
            if (string.IsNullOrEmpty(model.ID)) return false;

            int count = dal.UpdateDaiLiSellerInfo(model);
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
        /// <summary>
        /// 获取代理我商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyDaiLi(string GYSId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(GYSId)) return null;
            return dal.GetMyDaiLi(GYSId,PageIndex,PageSize, sermodel);
        }
        /// <summary>
        /// 获取选择我的商品的代理总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int GetMyDaiLiNum(string GYSId, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(GYSId)) return 0;
            return dal.GetMyDaiLiNum(GYSId, sermodel);
        }
        /// <summary>
        /// 判断该代理商是否为我的下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int JudgeDaiLi(string GYSId, string DaiLiId)
        {
            if (string.IsNullOrEmpty(GYSId) || string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.JudgeDaiLi(GYSId,DaiLiId);
        }
        /// <summary>
        /// 添加我的下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int AddDaiLi(string GYSId, string DaiLiId)
        {
            if (string.IsNullOrEmpty(GYSId) || string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.AddDaiLi(GYSId, DaiLiId);
        }
        /// <summary>
        /// 删除我的下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int DelDaiLi(string GYSId, string DaiLiId)
        {
            if (string.IsNullOrEmpty(GYSId) || string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.DelDaiLi(GYSId, DaiLiId);
        }
        /// <summary>
        /// 获取代理我团购商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyTGDaiLi(string GYSId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(GYSId)) return null;
            return dal.GetMyTGDaiLi(GYSId, PageIndex, PageSize, sermodel);
        }
        /// <summary>
        /// 获取选择我的团购商品的代理总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int GetMyTGDaiLiNum(string GYSId, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(GYSId)) return 0;
            return dal.GetMyTGDaiLiNum(GYSId, sermodel);
        }
        /// <summary>
        /// 判断该代理商是否为我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int JudgeTGDaiLi(string GYSId, string DaiLiId)
        {
            if (string.IsNullOrEmpty(GYSId) || string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.JudgeTGDaiLi(GYSId, DaiLiId);
        }
        /// <summary>
        /// 添加我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int AddTGDaiLi(string GYSId, string DaiLiId)
        {
            if (string.IsNullOrEmpty(GYSId) || string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.AddTGDaiLi(GYSId, DaiLiId);
        }
        /// <summary>
        /// 删除我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int DelTGDaiLi(string GYSId, string DaiLiId)
        {
            if (string.IsNullOrEmpty(GYSId) || string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.DelTGDaiLi(GYSId, DaiLiId);
        }

        /// <summary>
        /// 获取代理商城商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyGYS(string DaiLiId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(DaiLiId)) return null;
            return dal.GetMyGYS(DaiLiId, PageIndex, PageSize, sermodel);
        }
        /// <summary>
        ///  获取代理商城商品的代理商总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int GetMyGYSNum(string DaiLiId, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.GetMyGYSNum(DaiLiId, sermodel);
        }
        /// <summary>
        /// 获取代理团购商品的供应商列表
        /// </summary>
        /// <param name="DaiLiId">代理商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyTGGYS(string DaiLiId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(DaiLiId)) return null;
            return dal.GetMyTGGYS(DaiLiId, PageIndex, PageSize, sermodel);
        }
        /// <summary>
        ///  获取代理团购商品的供应商总数
        /// </summary>
        /// <param name="DaiLiId"></param>
        /// <returns></returns>
        public int GetMyTGGYSNum(string DaiLiId, MTeYueSer sermodel)
        {
            if (string.IsNullOrEmpty(DaiLiId)) return 0;
            return dal.GetMyTGGYSNum(DaiLiId, sermodel);
        }
        /// <summary>
        /// 获取我的特约代理
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <param name="LeiBie">商城-0，团购-1</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyTY(string GYSId, int LeiBie)
        {
            if (string.IsNullOrEmpty(GYSId)) return null;
            return dal.GetMyTY(GYSId, LeiBie);
        }

        /// <summary>
        /// 获取域名（按邀请码）
        /// </summary>
        /// <param name="yaQingMa"></param>
        /// <returns></returns>
        public string GetYuMing_YaoQingMa(string yaQingMa)
        {
            if (string.IsNullOrEmpty(yaQingMa)) return string.Empty;
            return dal.GetYuMing_YaoQingMa(yaQingMa);
        }
    }
}
