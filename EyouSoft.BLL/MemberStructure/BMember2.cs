using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;
using Linq.Respository;
using Linq.DAL;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.MemberStructure.WebModel;
using Linq.Expressions;
using EyouSoft.Model.Enum;
using Linq.Expressions.Extensions;
using EyouSoft.Model.AccountStructure;
using System.Configuration;

namespace EyouSoft.IDAL.MemberStructure
{
    public class BMember2 : BLLBase
    {
        IDMember2 dal = new DMember2();
        IDAL.AccountStructure.ISellers sedal = new DAL.AccountStructure.DSellers();
        public bool Add(MMember2 model)
        {
            if (model == null)
            {
                return false;
            }
            model.MD5Password = new PassWord(model.PassWord).MD5Password;
            try
            {
                if (dal.Insert(model) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Add(MMember2 model, MSellers mseller)
        {
            if (model == null)
            {
                return false;
            }
            try
            {
                using (dal.BeginTransaction())
                {
                    if (dal.Insert(model) == 1 && sedal.Insert(mseller) == 1)
                    {
                        int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                        int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                        sedal.AddWebDomain(mseller.Website, siteId);
                        sedal.AddWebDomain("m." + mseller.Website, WapsiteId);


                        int appSiteId = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
                        sedal.AddWebDomain("p." + mseller.Website, appSiteId);
                        dal.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Exists(string mobile)
        {
            if (mobile == null)
            {
                return false;
            }
            return dal.Exists(x => x.Mobile == mobile);
        }

        public MMember2 Get(string memberId)
        {
            if (memberId == null)
            {
                return null;
            }
            return dal.Get(memberId);
        }
        /// <summary>
        /// 判断域名是否已存在
        /// </summary>
        /// <param name="website"></param>
        /// <returns></returns>
        public MSellers Existswebsite(string website)
        {
            if (website == null)
            {
                return null;
            }
            website = website.ToLower();
            return sedal.Get(x => x.Website == website);
        }
        public MMember2 GetByAccount(string account)
        {
            if (account == null)
            {
                return null;
            }
            return dal.Get(x => x.Account == account);
        }

        public MMember2 Get(string username, PassWord password)
        {
            return dal.Get(x => x.Account == username && x.MD5Password == password.MD5Password);
        }

        public bool Update(MMember2 model)
        {
            if (model == null)
            {
                return false;
            }
            model.MD5Password = new PassWord(model.PassWord).MD5Password;
            return dal.Update_ButExcept(model, x => new { x.LoginIP, x.LoginTime, x.LoginNum, x.RegisterTime }) == 1;
        }
        //public bool UpdateZhiFuPass(MMember2 model)
        //{
        //    if (model == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    return dal.Update_ButExcept(model
        //}
        public bool Update(MMember2 model, MSellers mseller)
        {
            if (model == null)
            {
                return false;
            }
            try
            {
                model.MD5Password = new PassWord(model.PassWord).MD5Password;
                if ((int)model.UserType == 3 || (int)model.UserType == 4 || (int)model.UserType == 5)
                {
                    MSellers msell = sedal.Get(x => x.MemberID == model.MemberID);
                    if (msell != null)
                    {
                        //更新
                        mseller.ID = msell.ID;
                        sedal.Update(mseller);
                        sedal.UpdateWebDomain(msell.Website, mseller.Website);
                    }
                    else
                    {
                        mseller.ID = Guid.NewGuid().ToString();
                        sedal.Insert(mseller);
                        int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                        int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                        sedal.AddWebDomain(mseller.Website, siteId);
                        sedal.AddWebDomain("m." + mseller.Website, WapsiteId);

                        int appSiteId = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
                        sedal.AddWebDomain("p." + mseller.Website, appSiteId);
                    }
                }
                else
                {
                    MSellers msell = sedal.Get(x => x.MemberID == model.MemberID);
                    if (msell != null)
                    {
                        //删除
                        sedal.Delete(msell.ID);
                        int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                        int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                        sedal.RemoveWebDomain(msell.Website, siteId);
                        sedal.RemoveWebDomain("m." + msell.Website, WapsiteId);

                        int appSiteId = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
                        sedal.RemoveWebDomain("p." + mseller.Website, appSiteId);
                    }
                }
                int count = dal.Update(model);
                //dal.Complete();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(MMember2 model)
        {
            if (model == null || string.IsNullOrEmpty(model.MemberID))
            {
                return false;
            }
            MSellers msell = sedal.Get(x => x.MemberID == model.MemberID);
            if (msell != null)
            {
                //删除
                sedal.Delete(msell.ID);
                int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                sedal.RemoveWebDomain(msell.Website, siteId);
                sedal.RemoveWebDomain("m." + msell.Website, WapsiteId);

                int appSiteId = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
                sedal.RemoveWebDomain("p." + msell.Website, appSiteId);
            }
            return dal.Delete(model.MemberID) == 1;
        }
        public IList<MMemberAndSeller> GetMemberList(MMember2SearchModel searchModel)
        {
            return GetMemberList(searchModel, null);
        }
        public IList<MMemberAndSeller> GetMemberList(MMember2SearchModel searchModel, MemberTypes[] SearchMemberTypes)
        {
            QueryExpressionBuilder<MMember2> query = new QueryExpressionBuilder<MMember2>();
            if (searchModel.GetSellerInfo)
            {

                if (!string.IsNullOrEmpty(searchModel.WebsiteName))
                {
                    query.LeftOuterJoin<MSellers>().On((x, y) => x.MemberID == y.MemberID)
                       .Where((x, y) => y.WebsiteName.IndexOf(searchModel.WebsiteName) > -1).SelectAll();
                }
                else
                {
                    query.LeftOuterJoin<MSellers>().On((x, y) => x.MemberID == y.MemberID).SelectAll();
                }
            }

            query.SearchInfo = searchModel.SearchInfo;
            //用户名：  姓名：  手机：  Email:  昵称:  联系电话:
            //10天内即将过期的会员信息
            if (!string.IsNullOrEmpty(searchModel.ValidDate.ToString()))
            {
                query.Where(x => x.ValidDate >= DateTime.Now && x.ValidDate <= DateTime.Now.AddDays(10));
                query.OrderByDescending(x => x.ValidDate);
            }
            else
            {
                query.OrderByDescending(x => x.RegisterTime);
            }
            if (!string.IsNullOrEmpty(searchModel.Account))
            {
                query.Where(x => x.Account.IndexOf(searchModel.Account) > -1);
            }
            //if (searchModel.UserType.HasValue)
            //{
            //    query.Where(x => x.UserType == searchModel.UserType);
            //}
            if (!string.IsNullOrEmpty(searchModel.MemberName))
            {
                query.Where(x => x.MemberName.IndexOf(searchModel.MemberName) > -1);
            }
            if (!string.IsNullOrEmpty(searchModel.Mobile))
            {
                query.Where(x => x.Mobile.IndexOf(searchModel.Mobile) > -1);
            }
            if (!string.IsNullOrEmpty(searchModel.Email))
            {
                query.Where(x => x.Email.IndexOf(searchModel.Email) > -1);
            }
            if (!string.IsNullOrEmpty(searchModel.NickName))
            {
                query.Where(x => x.NickName.IndexOf(searchModel.NickName) > -1);
            }
            if (!string.IsNullOrEmpty(searchModel.Contact))
            {
                query.Where(x => x.Contact.IndexOf(searchModel.Contact) > -1);
            }
            if (SearchMemberTypes != null)
            {
                query.Where(x => x.UserType.In(SearchMemberTypes));
            }
            if (searchModel.IsPage)
            {
                return dal.SelectPagedList<MMemberAndSeller>(query);
            }
            else
            {
                return dal.Select<MMemberAndSeller>(query);
            }
        }
    }
}
