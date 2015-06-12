using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IMember
    {
        /// <summary>
        /// 验证会员账号是否存在
        /// </summary>
        /// <param name="Account">会员账号</param>
        /// <param name="MemberID">要排除的会员编号</param>
        /// <returns></returns>
        bool ExistsUserName(string Account, string MemberID);
        /// <summary>
        /// 验证用证件号码是否存在
        /// </summary>
        /// <param name="CardType">证件类型</param>
        /// <param name="CardNo">证件号</param>
        /// <param name="MemberID">要排除的用户编号</param>
        /// <returns></returns>
        bool ExistsUserName(EyouSoft.Model.Enum.CardType CardType, string CardNo, string MemberID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.MMember model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MMember model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string MemberID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MMember GetModel(string MemberID);
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        IList<EyouSoft.Model.MMember> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchMember Search);

        /// <summary>
        /// 前台会员修改密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="oldPassWord">旧的明文密码</param>
        /// <param name="newPassWord">新的密码</param>
        /// <returns></returns>
        int UpdatePassWord(string userId, string oldPassWord, Model.CompanyStructure.PassWord newPassWord);
        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="MemberState">会员状态</param>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool SetMemberState(EyouSoft.Model.Enum.UserStatus MemberState, params string[] Ids);

        /// <summary>
        /// 根据会员编号获取指定会员的上级代理商信息
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <returns></returns>
        EyouSoft.Model.MShangJiDaiLiShangInfo GetShangJiDaiLiShangInfoByHuiYuanId(string huiYuanId);

        /// <summary>
       /// 获取粉丝信息集合
       /// </summary>
       /// <param name="huiYuanId">会员编号</param>
       /// <param name="pageSize">页记录数</param>
       /// <param name="pageIndex">页序号</param>
       /// <param name="recordCount">总记录数</param>
       /// <param name="chaXun">查询</param>
       /// <returns></returns>
        IList<EyouSoft.Model.MFenSiInfo> GetFenSis(string huiYuanId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MFenSiChaXunInfo chaXun);

        /// <summary>
       /// 获取粉丝交易信息集合
       /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <param name="pageSize">页记录数</param>
      /// <param name="pageIndex">页序号</param>
      /// <param name="recordCount">总记录数</param>
      /// <param name="chaXun">查询</param>
       /// <returns></returns>
        IList<EyouSoft.Model.MFenSiJiaoYiInfo> GetFenSiJiaoYis(string huiYuanId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MFenSiJiaoYiChaXunInfo chaXun);
        /// <summary>
       /// 设置上级代理商，返回1成功，其它失败
       /// </summary>
       /// <param name="huiYuanId">会员编号（需要设定上级代理商的会员编号）</param>
       /// <param name="shangJiDaiLiShangId">上级代理商编号</param>
       /// <returns></returns>
        int SheZhiShangJiDaiLiShang(string huiYuanId, string shangJiDaiLiShangId);

        /// <summary>
       /// 获取下级代理数量
       /// </summary>
       /// <param name="huiYuanId">会员编号</param>
       /// <returns></returns>
        int GetXiaJiDaiLiShuLiang(string huiYuanId);

        /// <summary>
       /// 获取会员代理商信息
       /// </summary>
       /// <param name="huiYuanId">会员编号</param>
       /// <returns></returns>
        EyouSoft.Model.MHuiYuanDaiLiShangInfo GetHuiYuanDaiLiShangInfoByHuiYuanId(string huiYuanId);

        /// <summary>
      /// 获取会员代理商信息
      /// </summary>
      /// <param name="daiLiShangId">代理商编号</param>
      /// <returns></returns>
        EyouSoft.Model.MHuiYuanDaiLiShangInfo GetHuiYuanDaiLiShangInfoByDaiLiShangId(string daiLiShangId);
    }
}
