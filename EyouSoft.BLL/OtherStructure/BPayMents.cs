using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.OtherStructure;

namespace EyouSoft.BLL.OtherStructure
{
    public class BPayMents
    {
        private readonly IPayMents dal = new EyouSoft.DAL.DPayMents();
        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BPayMents() { }
        #endregion

        public int AddInterestRate(decimal Interest)
        {
            if (Interest > 0)
            {
                return dal.AddInterestRate(Interest);
            }
            else
            {
                return 0;
            }
        }

        public int UpdateInterestRate(decimal Interest)
        {
            if (Interest > 0)
            {
                return dal.UpdateInterestRate(Interest);
            }
            else
            {
                return 0;
            }
        }

        public bool ExistsData()
        {
            return dal.ExistsData();
        }

        public EyouSoft.Model.OtherStructure.MInterestRate Get()
        {
            return dal.Get();
        }


        public IList<EyouSoft.Model.OtherStructure.MPayMentsInfo> GetList(int pageSize, int PageIndex, ref int RecordCount,EyouSoft.Model.OtherStructure.MPaySearch search)
        {
            if (!Utils.ValidPaging(pageSize,PageIndex))
            {
                return null;
            }
            return dal.GetList(pageSize, PageIndex, ref RecordCount,search);
        }

        public decimal GetHistoryRate(string memberID)
        {
            if (string.IsNullOrEmpty(memberID))
            {
                return 0;
            }
            else
            {
                return dal.GetHistoryRate(memberID);
            }
        }

    }
}
