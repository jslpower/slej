using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using EyouSoft.Model.ScenicStructure;
using Linq.Expressions;
using EyouSoft.Model.SystemStructure;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.DAL.SystemStructure;
using Linq.Bussiness;
using EyouSoft.DAL.ScenicStructure;


namespace EyouSoft.BLL.ScenicStructure
{
   public class BScenicTickets
   {
      private readonly EyouSoft.IDAL.ScenicStructure.IScenicTickets dal = new EyouSoft.DAL.ScenicStructure.DScenicTickets();

      private readonly EyouSoft.IDAL.ScenicStructure.IDScenicTickets2 dal2 = new DScenicTickets2();
      /// <summary>
      /// 验证门票名称是否存在
      /// </summary>
      /// <param name="typeName">门票名称</param>
      /// <param name="ticketId">要排除的门票Id</param>
      /// <param name="scenicId">景区编号</param>
      /// <returns></returns>
      public bool ExistsTypeName(string typeName, string ticketId, string scenicId)
      {
         if (string.IsNullOrEmpty(typeName)) return false;

         return dal.ExistsTypeName(typeName, ticketId, scenicId);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool Add(EyouSoft.Model.ScenicStructure.MScenicTickets model)
      {
         model.TicketsId = Guid.NewGuid().ToString();
         if (string.IsNullOrEmpty(model.TypeName))
            return false;
         return dal.Add(model) == 0 ? false : true;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool Update(EyouSoft.Model.ScenicStructure.MScenicTickets model)
      {
         if (string.IsNullOrEmpty(model.TicketsId) || string.IsNullOrEmpty(model.TypeName))
            return false;
         return dal.Update(model) == 0 ? false : true;
      }

      ///// <summary>
      ///// 删除数据
      ///// </summary>
      ///// <param name="TicketsIds"></param>
      ///// <returns></returns>
      //public bool Delete(params string[] TicketsIds)
      //{
      //    if (TicketsIds.Length > 0)
      //        return dal.Delete(TicketsIds);
      //    else
      //        return false;
      //}

      /// <summary>
      /// 删除门票信息
      /// </summary>
      /// <param name="menPiaoId">门票编号</param>
      /// <returns></returns>
      public int DeleteMenPiao(string menPiaoId)
      {
         if (string.IsNullOrEmpty(menPiaoId)) return 0;

         return dal.DeleteMenPiao(menPiaoId);
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      /// <param name="TicketsId"></param>
      /// <returns></returns>
      public EyouSoft.Model.ScenicStructure.MScenicTickets GetModel(string TicketsId)
      {
         if (string.IsNullOrEmpty(TicketsId)) return null;
         return dal.GetModel(TicketsId);
      }

      /// <summary>
      /// 获得分页数据列表
      /// </summary>
      /// <param name="PageSize"></param>
      /// <param name="PageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <param name="Search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.ScenicStructure.MScenicTickets> GetList(int PageSize, int PageIndex, ref int RecordCount, MScenicTicketsSearchModel Search)
      {
         if (!Utils.ValidPaging(PageSize, PageIndex))
            return null;
         return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
      }



      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="Search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.ScenicStructure.MScenicTickets> GetTopList(int Top, MScenicTicketsSearchModel Search)
      {
         return dal.GetTopList((Top < 0 ? 0 : Top), Search);
      }

      /// <summary>
      /// 修改状态（上架，下架）
      /// </summary>
      /// <param name="Status"></param>
      /// <param name="TicketsIds"></param>
      /// <returns></returns>
      public bool SetStatus(EyouSoft.Model.Enum.ScenicStructure.ScenicTicketsStatus Status, params string[] TicketsIds)
      {
         if (TicketsIds.Length > 0)
            return dal.SetStatus(Status, TicketsIds);
         else
            return false;
      }
   }
}
