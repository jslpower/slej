using EyouSoft.Model.AccountStructure;
using EyouSoft.DAL;
using Linq.Expressions;
using System.Collections.Generic;
using System;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Toolkit.BLL;
using System.Configuration;
using EyouSoft.InterfaceLib.Common;

namespace EyouSoft.IDAL.AccountStructure
{
    public class BSellers : BLLBase
    {
        IDAL.AccountStructure.ISellers dal = new DAL.AccountStructure.DSellers();
        public bool Add(MSellers model)
        {
            try
            {
                if (dal.Insert(model) == 1)
                {
                    int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                    int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                    dal.AddWebDomain(model.Website, siteId);
                    dal.AddWebDomain("m." + model.Website, WapsiteId);

                    int appSiteId = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
                    dal.AddWebDomain("p." + model.Website, appSiteId);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                RecordError(ex);
                return false;
            }
        }
        public MSellers Get(string memberId)
        {
            if (memberId == null)
            {
                return null;
            }
            return dal.Get(x => x.MemberID == memberId);
            //return dal.(memberId);
        }
        /// <summary>
        /// 获取所有代理商
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public IList<MSellers> GetAllList()
        {
            QueryExpressionBuilder<MSellers> query = new QueryExpressionBuilder<MSellers>();

            return dal.Select<MSellers>(query);

            //return dal.Get(x => x.MemberID == memberId);
            //return dal.(memberId);
        }

        public MSellers GetWebSiteName(string SellerId)
        {
            if (SellerId == null)
            {
                return null;
            }
            return dal.Get(x => x.ID == SellerId);
            //return dal.(memberId);
        }
        public MSellers GetMSellersByWebSite(string website)
        {
            if (website == null)
            {
                return null;
            }
            website = Utils.getPCDomainUrl(website);
            return dal.Get(x => x.Website == website);
            //return dal.(memberId);
        }
        /// <summary>
        /// 获取分销商网站是否显示申请分销商
        /// </summary>
        /// <param name="website"></param>
        /// <returns></returns>
        public EyouSoft.Model.Enum.ShowHidden WebSiteShowOrHidden(string website)
        {
            if (website == null)
            {
                return EyouSoft.Model.Enum.ShowHidden.显示;
            }
            website = Utils.getPCDomainUrl(website);


            MSellers model = dal.Get(x => x.Website == website);
            if (model != null)
            {
                return model.ShowOrHidden;
            }
            else
            {
                return EyouSoft.Model.Enum.ShowHidden.显示;
            }
        }
        public IList<MSellers> GetWebSite()
        {
            return dal.Select(new QueryExpressionBuilder<MSellers>());
            //return dal.(memberId);
        }
        public void Delete(string memberId)
        {
            var seller = dal.Get(x => x.Website, y => y.MemberID == memberId);

            int count = dal.Delete(x => x.MemberID == memberId);
            if (count > 0)
            {
                int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                dal.RemoveWebDomain(seller.Website, siteId);
                dal.RemoveWebDomain("m." + seller.Website, WapsiteId);

                int appSiteId = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
                dal.RemoveWebDomain("p." + seller.Website, appSiteId);
            }

            //return dal.(memberId);
        }
        /// <summary>
        /// 判断该分销商是否有该类别的销售权
        /// </summary>
        /// <param name="website">网站url</param>
        /// <param name="FeeTypes">类别</param>
        /// <returns></returns>
        public bool JudgeAuthor(string website, EyouSoft.Model.Enum.FeeTypes FeeTypes)
        {
            bool Author = false;
            if (website == null)
            {
                Author = false;
            }
            website = Utils.getPCDomainUrl(website);
            MSellers model = dal.Get(x => x.Website == website);
            if (model != null)
            {
                string[] quan = model.QuanXian.Split(',');
                for (int i = 0; i < quan.Length; i++)
                {
                    if ((int)FeeTypes == Convert.ToInt32(quan[i]))
                    {
                        Author = true;
                        break;
                    }
                }
            }
            return Author;
        }

        IDAL.AccountStructure.ISellers sedal = new DAL.AccountStructure.DSellers();
        /// <summary>
        /// 绑定代理商域名
        /// </summary>
        /// <param name="domain">域名 例如：0211.slej.cn</param>
        public void addAppDomain(string domain)
        {

            int appSiteID = int.Parse(ConfigurationManager.AppSettings["appSiteId"]);
            sedal.AddWebDomain("p." + domain, appSiteID);
        }

    }
}