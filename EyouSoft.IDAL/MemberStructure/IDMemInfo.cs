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
        /// 代理商，员工，免费代理修改信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateDaiLiMemberInfo(MMember2 model);
        /// <summary>
        /// 代理商，员工，免费代理修改代理信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateDaiLiSellerInfo(EyouSoft.Model.AccountStructure.MSellers model);
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
        /// <summary>
        /// 获取代理我商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        IList<MTeYue> GetMyDaiLi(string GYSId, int PageIndex, int PageSize, MTeYueSer sermodel);
        /// <summary>
        /// 获取选择我的商品的代理总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int GetMyDaiLiNum(string GYSId, MTeYueSer sermodel);
        /// <summary>
        /// 判断该代理商是否为我的下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int JudgeDaiLi(string GYSId, string DaiLiId);
        /// <summary>
        /// 添加我的下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int AddDaiLi(string GYSId, string DaiLiId);
        /// <summary>
        /// 删除我的下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int DelDaiLi(string GYSId, string DaiLiId);
        /// <summary>
        /// 获取代理我团购商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        IList<MTeYue> GetMyTGDaiLi(string GYSId, int PageIndex, int PageSize, MTeYueSer sermodel);
        /// <summary>
        /// 获取选择我的团购商品的代理总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int GetMyTGDaiLiNum(string GYSId, MTeYueSer sermodel);
        /// <summary>
        /// 判断该代理商是否为我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int JudgeTGDaiLi(string GYSId, string DaiLiId);
        /// <summary>
        /// 添加我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int AddTGDaiLi(string GYSId, string DaiLiId);
        /// <summary>
        /// 删除我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int DelTGDaiLi(string GYSId, string DaiLiId);
        /// <summary>
        /// 获取代理商城商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        IList<MTeYue> GetMyGYS(string DaiLiId, int PageIndex, int PageSize, MTeYueSer sermodel);
        /// <summary>
        ///  获取代理商城商品的代理商总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        int GetMyGYSNum(string DaiLiId, MTeYueSer sermodel);
        /// <summary>
        /// 获取代理团购商品的供应商列表
        /// </summary>
        /// <param name="DaiLiId">代理商id</param>
        /// <returns></returns>
        IList<MTeYue> GetMyTGGYS(string DaiLiId, int PageIndex, int PageSize, MTeYueSer sermodel);
        /// <summary>
        ///  获取代理团购商品的供应商总数
        /// </summary>
        /// <param name="DaiLiId"></param>
        /// <returns></returns>
        int GetMyTGGYSNum(string DaiLiId, MTeYueSer sermodel);
        /// <summary>
        /// 获取我的特约代理
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <param name="LeiBie">商城-0，团购-1</param>
        /// <returns></returns>
        IList<MTeYue> GetMyTY(string GYSId, int LeiBie);
        /// <summary>
        /// 获取域名（按邀请码）
        /// </summary>
        /// <param name="yaQingMa"></param>
        /// <returns></returns>
        string GetYuMing_YaoQingMa(string yaQingMa);
    }
}
