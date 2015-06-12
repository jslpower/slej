using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;
using EyouSoft.Model.OtherStructure;
using Linq.Respository;
using Linq.DAL;
using EyouSoft.Toolkit.BLL;
using Linq.Expressions;
using EyouSoft.Model.Enum;
using Linq.Expressions.Extensions;
using EyouSoft.Model.MoneyStructure;

namespace EyouSoft.BLL.OtherStructure
{
    public class BApply : BLLBase
    {
        DAL.OtherStructure.DApply dal = new EyouSoft.DAL.OtherStructure.DApply();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MApply info)
        {
            if (info == null || info.MemberMoblie == "" || info.MemberName =="") return false;
            return dal.Insert(info) > 0 ? true : false;
        }
        public IList<MApply> GetApplyList(MSearchApplyUser searchModel)
        {
            QueryExpressionBuilder<MApply> query = new QueryExpressionBuilder<MApply>();
            query.OrderBy(x => x.ApplyTime);
            query.SearchInfo = searchModel.SearchInfo;
            //用户姓名：
            if (!string.IsNullOrEmpty(searchModel.uname))
            {
                query.Where(x => x.MemberName.IndexOf(searchModel.uname) > -1);
            }
            //手机号：
            if (!string.IsNullOrEmpty(searchModel.umoblie))
            {
                query.Where(x => x.MemberMoblie.IndexOf(searchModel.umoblie) > -1);
            }
            //公司名：
            if (!string.IsNullOrEmpty(searchModel.ucompany))
            {
                query.Where(x => x.CompanyName.IndexOf(searchModel.ucompany) > -1);
            }
            //开始时间
            if (searchModel.startime > Convert.ToDateTime("1900-01-01"))
            {
                query.Where(x => x.ApplyTime >= searchModel.startime);
            }
            //结束时间
            if (searchModel.endtime > Convert.ToDateTime("1900-01-01"))
            {
                query.Where(x => x.ApplyTime <= searchModel.endtime);
            }
            return dal.SelectPagedList<MApply>(query);
        }
    }
}
