using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model.ScenicStructure.WebModel;

namespace EyouSoft.IDAL.ScenicStructure
{
   public interface IScenicTickets
   {
      /// <summary>
      /// 验证门票名称是否存在
      /// </summary>
      /// <param name="typeName">门票名称</param>
      /// <param name="ticketId">要排除的门票Id</param>
      /// <param name="scenicId">景区编号</param>
      /// <returns></returns>
      bool ExistsTypeName(string typeName, string ticketId, string scenicId);

      /// <summary>
      /// 增加一条数据
      /// </summary>
      int Add(EyouSoft.Model.ScenicStructure.MScenicTickets model);
      /// <summary>
      /// 更新一条数据
      /// </summary>
      int Update(EyouSoft.Model.ScenicStructure.MScenicTickets model);
      ///// <summary>
      ///// 批量删除
      ///// </summary>
      ///// <param name="TicketsIds"></param>
      ///// <returns></returns>
      //bool Delete(params string[] TicketsIds);

      /// <summary>
      /// 删除门票信息
      /// </summary>
      /// <param name="menPiaoId">门票编号</param>
      /// <returns></returns>
      int DeleteMenPiao(string menPiaoId);

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      EyouSoft.Model.ScenicStructure.MScenicTickets GetModel(string TicketsId);
      /// <summary>
      /// 分页获得数据列表
      /// </summary>
      /// <param name="PageSize"></param>
      /// <param name="PageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <param name="Search"></param>
      /// <returns></returns>
      IList<EyouSoft.Model.ScenicStructure.MScenicTickets> GetList(int PageSize, int PageIndex, ref int RecordCount, MScenicTicketsSearchModel Search);
      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="Search"></param>
      /// <returns></returns>
      IList<EyouSoft.Model.ScenicStructure.MScenicTickets> GetTopList(int Top, MScenicTicketsSearchModel Search);
      /// <summary>
      /// 修改状态（上架，下架）
      /// </summary>
      /// <param name="Status">状态</param>
      /// <param name="ids"></param>
      /// <returns></returns>
      bool SetStatus(Model.Enum.ScenicStructure.ScenicTicketsStatus Status, params string[] TicketsIds);
   }

   public interface IDScenicTickets2 : Linq.Respository.IRepository<MScenicTickets>
   {

   }
}
