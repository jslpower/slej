/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;
using EyouSoft.Model.MoneyStructure;
using EyouSoft.Model.MoneyStructure.WebModel;
using Linq.Respository;
using Linq.DAL;
using EyouSoft.Toolkit.BLL;
using Linq.Expressions;
using EyouSoft.Model.Enum;
using Linq.Expressions.Extensions;
using EyouSoft.BLL.MemberStructure;

namespace EyouSoft.BLL.MoneyStructure
{
    public class BAccount : BLLBase
    {
        DAL.MoneyStructure.DAccount dal = new EyouSoft.DAL.MoneyStructure.DAccount();

        public IList<MAccount> GetAccountList(MAccountSearchModel searchModel)
        {
            QueryExpressionBuilder<MAccount> query = new QueryExpressionBuilder<MAccount>();
            query.OrderByDescending(x => x.TransactionTime);
            query.SearchInfo = searchModel.SearchInfo;
            //用户Id：
            if (!string.IsNullOrEmpty(searchModel.USerId))
            {
                query.Where(x => x.UserId == searchModel.USerId);
            }
            //交易对象
            if (!string.IsNullOrEmpty(searchModel.TranUserId))
            {
                if (searchModel.TranUserId == "0")
                {
                    query.Where(x=>x.TranUserId==null);
                }
                else
                {
                    query.Where(x => x.TranUserId == searchModel.TranUserId);
                }
                
            }
            //开始时间
            if (searchModel.StartTime > Convert.ToDateTime("1900-01-01"))
            {
                query.Where(x => x.TransactionTime >= searchModel.StartTime);
            }
            //结束时间
            if (searchModel.EndTime > Convert.ToDateTime("1900-01-01"))
            {
                query.Where(x => x.TransactionTime <= searchModel.EndTime);
            }
            if (searchModel.TransactionCate.HasValue)
            {
                if ((int)searchModel.TransactionCate >= 0)
                {
                    query.Where(x => x.TransactionCate == searchModel.TransactionCate);
                }
            }
            //起始金额
            if (searchModel.ChongZhiJinE1 > 0)
            {
                query.Where(x => x.Amounts >= searchModel.ChongZhiJinE1);
            }
            //终止金额
            if (searchModel.ChongZhiJinE2 > 0)
            {
                query.Where(x => x.Amounts <= searchModel.ChongZhiJinE2);
            }
            if (searchModel.OrderType.HasValue)
            {
                query.Where(x => x.OrderType == searchModel.OrderType);
            }
            return dal.SelectPagedList<MAccount>(query);
        }

        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MAccount info)
        {
            MAccount minfo = new MAccount();
            if (info == null || info.UserId == "") return false;
            int count = 0;
            if (info.balance > 0 && !string.IsNullOrEmpty(info.UserId))//有交易金额更新账户余额
            {
                count = new BMember().UpdateMoney(info.UserId, info.balance);
                if (count > 0)
                {
                    return dal.Insert(info) > 0 ? true : false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return dal.Insert(info) > 0 ? true : false;
            }

        }


        public int GetAccountNum(TCate cate)
        {
            try
            {
                return Convert.ToInt32(dal.Count(x => x.TransactionCate == cate
                    && x.TransactionTime >= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
                    && x.TransactionTime <= Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))));
            }
            catch (Exception ex)
            {
                return 1000;
            }
        }
    }
}
*/
