using EyouSoft.Model.AccountStructure;
using EyouSoft.DAL;
using Linq.Expressions;
using System.Collections.Generic;
using System;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Toolkit.BLL;

namespace EyouSoft.BLL.AccountStructure
{
   public class BProvider : BLLBase
   {

      IDAL.AccountStructure.IDProvider dal = new DAL.AccountStructure.DProvider();
      IDAL.IWebmaster dalWebmaster = new DAL.DWebmaster();

      public MProvidersSearchModel GetProvider(string id)
      {
         QueryExpressionBuilder<MProviders> builder = new QueryExpressionBuilder<MProviders>();
         builder.InnerJoin<MWebmaster>().On((m1, m2) => m1.ID == m2.GysId)
            .Select((m1, m2) => new { m1, Account = m2.Username, Password = m2.Password })
            .Where(m1 => m1.ID == id);
         return dal.Get<MProvidersSearchModel>(builder);
      }

      public IList<MProviders> GetProviderList(MProvidersSearchModel searchModel)
      {
         QueryExpressionBuilder<MProviders> builder = new QueryExpressionBuilder<MProviders>();

         builder.SearchInfo = searchModel.SearchInfo;
         builder.OrderBy(x => x.ID);
         if (!string.IsNullOrEmpty(searchModel.LianXiRen))
         {
            builder.Where(x => x.LianXiRen.IndexOf(searchModel.LianXiRen) > -1);
         }

         builder.SelectAll();

         return dal.Select(builder);
      }

      public bool UpdateProvider(MProvidersSearchModel model)
      {
         using (dal.BeginTransaction())
         {
            try
            {
               if (dal.Update(model) != 1)
               {
                  return false;
               }

               MWebmaster webmaster = dalWebmaster.GetGysUserInfo(model.ID);
               if (webmaster == null)
               {
                  return false;
               }
               webmaster.Password = model.Password;
               webmaster.MD5Password = new PassWord(model.Password).MD5Password;
               webmaster.Mobile = model.LianXiDianHua;
               webmaster.Telephone = model.LianXiDianHua;
               webmaster.Realname = model.LianXiRen;
               webmaster.Username = model.Account;
               if (!dalWebmaster.Update(webmaster))
               {
                  return false;
               }
               dal.Complete();
               return true;
            }
            catch (Exception ex)
            {
               RecordError(ex);
               return false;
            }
         }

      }

      public bool DeleteProvider(string id)
      {
         using (dal.BeginTransaction())
         {
            try
            {
               if (dal.Delete(id) != 1)
               {
                  return false;
               }

               MWebmaster webmaster = dalWebmaster.GetGysUserInfo(id);
               if (webmaster == null)
               {
                  return false;
               }

               if (!dalWebmaster.Delete(webmaster.Id))
               {
                  return false;
               }

               dal.Complete();
               return true;
            }
            catch
            {
               return false;
            }
         }
      }

      public bool AddProvider(MProvidersSearchModel model)
      {
         using (dal.BeginTransaction())
         {
            try
            {
               model.ID = Guid.NewGuid().ToString();
               if (dal.Insert(model) != 1)
               {
                  return false;
               }
               MWebmaster webmaster = new MWebmaster();
               webmaster.CreateTime = DateTime.Now;
               webmaster.Fax = null;
               webmaster.GysId = model.ID;
               webmaster.IsAdmin = 1;
               webmaster.IsEnable = 1;
               webmaster.LeiXing = (int)WebmasterUserType.供应商用户;
               webmaster.MD5Password = new PassWord(model.Password).MD5Password;
               webmaster.Mobile = model.LianXiDianHua;
               webmaster.Password = model.Password;
               webmaster.Permissions = null;
               webmaster.Realname = model.LianXiRen;
               webmaster.Telephone = model.LianXiDianHua;
               webmaster.Username = model.Account;
               if (!dalWebmaster.Add(webmaster))
               {
                  return false;
               }
               dal.Complete();
               return true;
            }
            catch (Exception ex)
            {
               RecordError(ex);
               return false;
            }
         }
      }
   }
}
