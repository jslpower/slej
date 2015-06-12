using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MoneyStructure;
using EyouSoft.DAL.MoneyStructure;
using Linq.Expressions.Extensions;
using EyouSoft.Model;
//using EyouSoft.Model.MoneyStructure.WebModel;
using Linq.Expressions;
using EyouSoft.Toolkit.BLL;

namespace EyouSoft.BLL.OtherStructure
{
   public class BMember : BLLBase
   {
      private readonly EyouSoft.IDAL.OtherStructure.IMember dal = new EyouSoft.DAL.OtherStructure.DMember();

      /// <summary>
      /// 验证会员账号是否存在
      /// </summary>
      /// <param name="Account">会员账号</param>
      /// <param name="MemberID">要排除的会员编号</param>
      /// <returns></returns>
      public bool ExistsUserName(string Account, string MemberID)
      {
         if (string.IsNullOrEmpty(Account)) return false;

         return dal.ExistsUserName(Account, MemberID);
      }

      /// <summary>
      /// 验证用证件号码是否存在
      /// </summary>
      /// <param name="CardType">证件类型</param>
      /// <param name="CardNo">证件号</param>
      /// <param name="MemberID">要排除的用户编号</param>
      /// <returns></returns>
      public bool ExistsUserName(EyouSoft.Model.Enum.CardType CardType, string CardNo, string MemberID)
      {
         if ((int)CardType > 0 && !string.IsNullOrEmpty(CardNo)) return dal.ExistsUserName(CardType, CardNo, MemberID);
         return false;
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool Add(EyouSoft.Model.MMember model)
      {
         model.MemberID = Guid.NewGuid().ToString();
         if (string.IsNullOrEmpty(model.Account)
             || string.IsNullOrEmpty(model.PassWord.NoEncryptPassword))
            return false;

         return dal.Add(model) == 0 ? false : true;

      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool Update(EyouSoft.Model.MMember model)
      {
         if (string.IsNullOrEmpty(model.MemberID))
            return false;
         return dal.Update(model) == 0 ? false : true;
      }

      /// <summary>
      /// 删除一条数据
      /// </summary>
      /// <param name="MemberID"></param>
      /// <returns></returns>
      public bool Delete(string MemberID)
      {
         if (string.IsNullOrEmpty(MemberID)) return false;
         return dal.Delete(MemberID) == 0 ? false : true;
      }
      /// <summary>
      /// 获取实体
      /// </summary>
      /// <param name="MemberID"></param>
      /// <returns></returns>
      public EyouSoft.Model.MMember GetModel(string MemberID)
      {
         if (string.IsNullOrEmpty(MemberID)) return null;
         return dal.GetModel(MemberID);
      }


      /// <summary>
      /// 获取分页列表
      /// </summary>
      /// <param name="PageSize"></param>
      /// <param name="PageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <param name="Search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MMember> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchMember Search)
      {

         return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
      }

      /// <summary>
      /// 前台会员修改密码
      /// </summary>
      /// <param name="userId">用户编号</param>
      /// <param name="oldPassWord">旧的明文密码</param>
      /// <param name="newPassWord">新的密码</param>
      /// <returns></returns>
      public int UpdatePassWord(string userId, string oldPassWord, Model.CompanyStructure.PassWord newPassWord)
      {
         if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(oldPassWord) || newPassWord == null
             || string.IsNullOrEmpty(newPassWord.NoEncryptPassword)) return 0;

         return dal.UpdatePassWord(userId, oldPassWord, newPassWord);

      }
      /// <summary>
      /// 修改会员状态
      /// </summary>
      /// <param name="MemberState">会员状态</param>
      /// <param name="ids"></param>
      /// <returns></returns>
      public bool SetMemberState(EyouSoft.Model.Enum.UserStatus MemberState, params string[] Ids)
      {
         if (Ids.Length > 0)
            return dal.SetMemberState(MemberState, Ids);
         else
            return false;
      }

       /*
      public IList<MChongZhiSearchModel> GetChongZhiList(MChongZhiSearchModel searchModel)
      {
         try
         {
            IList<MChongZhiSearchModel> list = new List<MChongZhiSearchModel>();
            if (searchModel == null)
            {
               return list;
            }
            QueryExpressionBuilder<MChongZhi> queryRoot = new QueryExpressionBuilder<MChongZhi>();
            queryRoot.SearchInfo = searchModel.SearchInfo;

            var queryRoot2 = queryRoot.InnerJoin<MMember>().On((chong, meme) => chong.UserID == meme.MemberID)
               .OrderByDescending((ch, me) => ch.ShiJian);
            queryRoot.SelectAll();
            queryRoot2.Select((t, meme) => meme.MemberName);

            if (searchModel.ChongZhiJinE1.HasValue)
            {
               queryRoot.Where(c => c.ChongZhiJinE >= searchModel.ChongZhiJinE1.Value);
            }
            if (searchModel.ChongZhiJinE2.HasValue)
            {
               queryRoot.Where(chong => chong.ChongZhiJinE <= searchModel.ChongZhiJinE2.Value);
            }
            if (searchModel.StartTime.HasValue)
            {
               queryRoot.Where(chong => chong.ShiJian >= searchModel.StartTime.Value);
            }
            if (searchModel.EndTime.HasValue)
            {
               queryRoot.Where(chong => chong.ShiJian <= searchModel.EndTime.Value);
            }
            if (!string.IsNullOrEmpty(searchModel.UserName))
            {
               queryRoot2.Where((x, y) => y.MemberName.IndexOf(searchModel.UserName) > -1);
            }
            if (searchModel.State2.HasValue)
            {
               queryRoot.Where(chong => chong.State == searchModel.State2.Value);
            }

            DChongZhi dal = new DChongZhi();
            list = dal.SelectPagedList<MChongZhiSearchModel>(queryRoot);
            return list;
         }
         catch (Exception ex)
         {
            RecordError(ex);
            return null;
         }
      }*/

       /*
      public IList<MTiXianSearchModel> GetTiXianList(MTiXianSearchModel searchModel)
      {
         IList<MTiXianSearchModel> list = new List<MTiXianSearchModel>();

         if (searchModel != null)
         {
            QueryExpressionBuilder<MTiXian> queryRoot = new QueryExpressionBuilder<MTiXian>();
            queryRoot.SelectAll();
            var select2 = queryRoot.InnerJoin<MMember>().On((tixian, meme) => tixian.UserID == meme.MemberID);
            select2.Select((t, meme) => meme.MemberName);
            select2.OrderBy(tixian => tixian.TiXianShiJian);
            queryRoot.SearchInfo = searchModel.SearchInfo;

            if (searchModel.TiXianJinE1.HasValue)
            {
               queryRoot.Where(tixian => tixian.TiXianJinE >= searchModel.TiXianJinE1.Value);
            }
            if (searchModel.TiXianJinE2.HasValue)
            {
               queryRoot.Where(tixian => tixian.TiXianJinE <= searchModel.TiXianJinE2.Value);
            }
            if (searchModel.BeginTime.HasValue)
            {
               queryRoot.Where(tixian => tixian.TiXianShiJian >= searchModel.BeginTime.Value);
            }
            if (searchModel.EndTime.HasValue)
            {
               queryRoot.Where(tixian => tixian.TiXianShiJian <= searchModel.EndTime.Value);
            }
            if (searchModel.State2.HasValue)
            {
               queryRoot.Where(tixian => tixian.State == searchModel.State2);
            }
            if (!string.IsNullOrEmpty(searchModel.UserName))
            {
               select2.Where((chong, meme) => meme.MemberName.IndexOf(searchModel.UserName) > -1);
            }
            DTiXian dal = new DTiXian();
            list = dal.SelectPagedList<MTiXianSearchModel>(queryRoot);
         }
         return list;
      }*/

       /*
      public IList<MFanLiSearchModel> GetFanLiList(MFanLiSearchModel searchModel)
      {
         IList<MFanLiSearchModel> list = new List<MFanLiSearchModel>();

         if (searchModel != null)
         {
            QueryExpressionBuilder<MFanLi> queryRoot = new QueryExpressionBuilder<MFanLi>();
            queryRoot.SelectAll();
            queryRoot.SearchInfo = searchModel.SearchInfo;

            var select2 = queryRoot.LeftOuterJoin<MMember>().On((fanli, meme) => fanli.UserID == meme.MemberID)
               .OrderBy((fanli, meme) => fanli.ShiJian)
               .Select((fanli, meme) => meme.MemberName);

            if (searchModel.FanLiJinE1.HasValue)
            {
               queryRoot.Where(fanli => fanli.FanLiJinE >= searchModel.FanLiJinE1.Value);
            }
            if (searchModel.FanLiJinE2.HasValue)
            {
               queryRoot.Where(fanli => fanli.FanLiJinE <= searchModel.FanLiJinE2.Value);
            }
            //if (!string.IsNullOrEmpty(searchModel.JiaoYiDuiXiang))
            //{
            //   whereExpression.Where(x => x.j == searchModel.JiaoYiDuiXiang);
            //}
            if (!string.IsNullOrEmpty(searchModel.JiaoYiRen))
            {
               select2.Where((fanli, meme) => meme.MemberName.IndexOf(searchModel.JiaoYiRen) > -1);
            }
            if (searchModel.StartTime.HasValue)
            {
               queryRoot.Where(fanli => fanli.ShiJian >= searchModel.StartTime.Value);
            }
            if (searchModel.EndTime.HasValue)
            {
               queryRoot.Where(fanli => fanli.ShiJian <= searchModel.EndTime.Value);
            }
            DFanLi dal = new DFanLi();

            list = dal.SelectPagedList<MFanLiSearchModel>(queryRoot);
         }
         return list;
      }*/

      /// <summary>
      /// 根据会员编号获取指定会员的上级代理商信息
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <returns></returns>
      public EyouSoft.Model.MShangJiDaiLiShangInfo GetShangJiDaiLiShangInfoByHuiYuanId(string huiYuanId)
      {
          if (string.IsNullOrEmpty(huiYuanId) || string.IsNullOrEmpty(huiYuanId.Trim())) return null;

          return dal.GetShangJiDaiLiShangInfoByHuiYuanId(huiYuanId);
      }

      /// <summary>
      /// 获取粉丝信息集合
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <param name="pageSize">页记录数</param>
      /// <param name="pageIndex">页序号</param>
      /// <param name="recordCount">总记录数</param>
      /// <param name="chaXun">查询</param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MFenSiInfo> GetFenSis(string huiYuanId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MFenSiChaXunInfo chaXun)
      {
          if (string.IsNullOrEmpty(huiYuanId)) return null;

          return dal.GetFenSis(huiYuanId, pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 获取粉丝交易信息集合
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <param name="pageSize">页记录数</param>
      /// <param name="pageIndex">页序号</param>
      /// <param name="recordCount">总记录数</param>
      /// <param name="chaXun">查询</param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MFenSiJiaoYiInfo> GetFenSiJiaoYis(string huiYuanId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MFenSiJiaoYiChaXunInfo chaXun)
      {
          if (string.IsNullOrEmpty(huiYuanId)) return null;

          return dal.GetFenSiJiaoYis(huiYuanId, pageSize, pageIndex, ref recordCount, chaXun);
      }

       /// <summary>
       /// 设置上级代理商，返回1成功，其它失败
       /// </summary>
       /// <param name="huiYuanId">会员编号（需要设定上级代理商的会员编号）</param>
       /// <param name="shangJiDaiLiShangId">上级代理商编号</param>
       /// <returns></returns>
      public int SheZhiShangJiDaiLiShang(string huiYuanId, string shangJiDaiLiShangId)
      {
          if (string.IsNullOrEmpty(huiYuanId) || string.IsNullOrEmpty(shangJiDaiLiShangId)) return 0;

          int dalRetCode = dal.SheZhiShangJiDaiLiShang(huiYuanId, shangJiDaiLiShangId);
          return dalRetCode;
      }

      /// <summary>
      /// 获取下级代理数量
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <returns></returns>
      public int GetXiaJiDaiLiShuLiang(string huiYuanId)
      {
          if (string.IsNullOrEmpty(huiYuanId)) return 0;

          return dal.GetXiaJiDaiLiShuLiang(huiYuanId);
      }

      /// <summary>
      /// 获取会员代理商信息
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <returns></returns>
      public EyouSoft.Model.MHuiYuanDaiLiShangInfo GetHuiYuanDaiLiShangInfoByHuiYuanId(string huiYuanId)
      {
          if (string.IsNullOrEmpty(huiYuanId)) return null;

          return dal.GetHuiYuanDaiLiShangInfoByHuiYuanId(huiYuanId);
      }

      /// <summary>
      /// 获取会员代理商信息
      /// </summary>
      /// <param name="daiLiShangId">代理商编号</param>
      /// <returns></returns>
      public EyouSoft.Model.MHuiYuanDaiLiShangInfo GetHuiYuanDaiLiShangInfoByDaiLiShangId(string daiLiShangId)
      {
          if (string.IsNullOrEmpty(daiLiShangId)) return null;

          return dal.GetHuiYuanDaiLiShangInfoByDaiLiShangId(daiLiShangId);
      }
   }
}
