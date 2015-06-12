/*
using System;
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

namespace EyouSoft.BLL.MoneyStructure
{
    public class BChongZhi : BLLBase
    {
        DAL.MoneyStructure.DChongZhi dal = new EyouSoft.DAL.MoneyStructure.DChongZhi();
        public IList<MChongZhi> GetChongZhiList(MChongZhiSearchModel searchModel)
        {
            QueryExpressionBuilder<MChongZhi> query = new QueryExpressionBuilder<MChongZhi>();
            query.OrderBy(x => x.ID);
            query.SearchInfo = searchModel.SearchInfo;
            //用户名：
            if (!string.IsNullOrEmpty(searchModel.UserID))
            {
                query.Where(x => x.UserID==searchModel.UserID);
            }
            return dal.SelectPagedList<MChongZhi>(query);
        }

    }
}
*/