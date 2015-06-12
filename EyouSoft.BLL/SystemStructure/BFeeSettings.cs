using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using EyouSoft.Model.Enum;
using EyouSoft.Toolkit.BLL;
using EyouSoft.DAL.SystemStructure;
using Linq.Expressions;
using EyouSoft.Model.SystemStructure;
using EyouSoft.IDAL.SystemStructure;

namespace EyouSoft.BLL.SystemStructure
{
   public class BFeeSettings : BLLBase
   {
      IDFeeSettings dal = new DFeeSettings();

      public IList<MFeeSettings> GetList()
      {
         QueryExpressionBuilder<MFeeSettings> builder = new QueryExpressionBuilder<MFeeSettings>();
         return dal.Select(builder);
      }

      public MFeeSettings GetByType(FeeTypes type)
      {
         return dal.Get(x => x.LeiBie == type);
      }

      public bool Update(MFeeSettings model)
      {
         try
         {
            using (dal.BeginTransaction())
            {
               MFeeSettings model2 = dal.Get(x => x.LeiBie == model.LeiBie);
               if (model2 == null)
               {
                  if (dal.Insert(model) !=1 )
                  {
                     return false;
                  }
               }
               else
               {
                  if (dal.Update(model) != 1)
                  {
                     return false;
                  }
               }
               dal.Complete();
               return true;
            }
         }
         catch (Exception ex)
         {
#if DEBUG
            throw ex;
#endif
            RecordError(ex);
            return false;
         }
      }
   }
}
