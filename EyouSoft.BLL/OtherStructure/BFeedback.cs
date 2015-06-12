using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
   public class BFeedback
   {
       private readonly EyouSoft.IDAL.OtherStructure.IFeedback dal = new EyouSoft.DAL.OtherStructure.DFeedback();


       /// <summary>
       /// 增加一条数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool Add(EyouSoft.Model.OtherStructure.MFeedback model)
       {
           
           if (string.IsNullOrEmpty(model.MessageType)
               || string.IsNullOrEmpty(model.MessageType))
               return false;

           return dal.add(model) == 0 ? false : true;

       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool Update(EyouSoft.Model.OtherStructure.MFeedback model)
       {
           if (string.IsNullOrEmpty(model.ID.ToString()))
               return false;
           return dal.update(model) == 0 ? false : true;
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
       public EyouSoft.Model.OtherStructure.MFeedback GetModel(string MemberID)
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
       public IList<EyouSoft.Model.OtherStructure.MFeedback> GetList(int PageSize, int PageIndex, ref int RecordCount,EyouSoft.Model.OtherStructure.MSearchFeedback Search)
       {

           return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
       }

   }
}
