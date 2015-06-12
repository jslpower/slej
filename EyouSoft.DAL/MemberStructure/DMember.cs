using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.MemberStructure
{
    public class DMember : DALBase, EyouSoft.IDAL.MemberStructure.IDMemInfo
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DMember()
        {
            _db = base.SystemStore;
        }
        #endregion
        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMemberInfo(MMember2 model)
        {
            string sql = "update tbl_Member set MemberName=@MemberName,Address=@Address,BirthDate=@BirthDate,Gender=@Gender,Email=@Email,Contact=@Contact,qq=@qq,NickName=@NickName,Photo=@Photo where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "MemberName", DbType.String, model.MemberName);
            this._db.AddInParameter(cmd, "Email", DbType.String, model.Email);
            this._db.AddInParameter(cmd, "Contact", DbType.String, model.Contact);
            this._db.AddInParameter(cmd, "qq", DbType.String, model.qq);
            this._db.AddInParameter(cmd, "NickName", DbType.String, model.NickName);
            this._db.AddInParameter(cmd, "MemberID", DbType.String, model.MemberID);
            this._db.AddInParameter(cmd, "Gender", DbType.Int32, model.Gender);
            this._db.AddInParameter(cmd, "BirthDate", DbType.DateTime, model.BirthDate);
            this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
            this._db.AddInParameter(cmd, "Photo", DbType.String, model.Photo);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 更新会员支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMemberZhifu(MMember2 model)
        {
            string sql = "update tbl_Member set ZhiFuPassword=@ZhiFuPassword where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "ZhiFuPassword", DbType.String, model.ZhiFuPassword);
            this._db.AddInParameter(cmd, "MemberID", DbType.String, model.MemberID);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 更新会员状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMemberState(string MemberID,int States)
        {
            string sql = "update tbl_Member set MemberState=@MemberState where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "MemberState", DbType.Int32, States);
            this._db.AddInParameter(cmd, "MemberID", DbType.String, MemberID);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMemberPass(MMember2 model)
        {
            string sql = "update tbl_Member set PassWord=@PassWord,MD5Password=@MD5Password where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "PassWord", DbType.String, model.PassWord);
            this._db.AddInParameter(cmd, "MemberID", DbType.String, model.MemberID);
            this._db.AddInParameter(cmd, "MD5Password", DbType.String, model.MD5Password);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 更新会员余额
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="money">余额</param>
        /// <returns></returns>
        public int UpdateMoney(string userId, decimal money)
        {
            string sql = "update tbl_Member set TotalMoney=@TotalMoney where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "TotalMoney", DbType.Decimal,money );
            this._db.AddInParameter(cmd, "MemberID", DbType.String, userId);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }

        /// <summary>
        /// 更改申请分销商是否显示
        /// </summary>
        /// <param name="showhidden">是否显示</param>
        /// <param name="userId">会员id</param>
        /// <returns></returns>
        public int UpdateShowOrHidden(EyouSoft.Model.Enum.ShowHidden showhidden, EyouSoft.Model.Enum.NavNum num, string userId)
        {
            string sql = "update tbl_JA_Sellers set ShowOrHidden=@ShowOrHidden,NavNum=@NavNum where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "ShowOrHidden", DbType.Int32, showhidden);
            this._db.AddInParameter(cmd, "NavNum", DbType.Int32, (int)num);
            this._db.AddInParameter(cmd, "MemberID", DbType.String, userId);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }

        /// <summary>
        /// 判断用户名是否存在，返回1存在，返回0不存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public int IsExistsUsername(string username)
        {
            string sql = "SELECT COUNT(*) FROM tbl_Member WHERE Account=@Username";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "Username", DbType.String, username);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) > 0) return 1;
                }
            }
            return 0;
        }
        
        /*/// <summary>
        /// 获取总账户金额
        /// </summary>
        /// <returns></returns>
        public decimal GetSumJInE()
        {
            string sql = "select sum(Amounts) from dbo.tbl_JA_Account where TransactionCate in(2)";
            string sql1 = "select sum(Amounts) from dbo.tbl_JA_Account where TransactionCate in(3)";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            object sum1 = DbHelper.GetSingle(cmd, _db);
            DbCommand cmd1 = this._db.GetSqlStringCommand(sql1);
            object sum2 = DbHelper.GetSingle(cmd1, _db);
            return Convert.ToDecimal(sum1)-Convert.ToDecimal(sum2);
        }*/

        /// <summary>
        /// 获取分销商的公司介绍
        /// </summary>
        /// <param name="MemberId">会员id</param>
        /// <returns></returns>
        public string GetContent(string MemberId)
        {
            string CompanyContent = "";
            string sql = "select CompanyContent from tbl_JA_Sellers where MemberID='"+ MemberId +"'";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            DataSet ds = DbHelper.Query(cmd, _db);
            if (ds != null)
            {
                CompanyContent = ds.Tables[0].Rows[0][0].ToString();
            }
            return CompanyContent;
        }
        /// <summary>
        /// 修改分销商公司介绍
        /// </summary>
        /// <param name="CompanyCon">公司介绍</param>
        /// <param name="MemberId">会员Id</param>
        /// <returns></returns>
        public int UpdateSellerContent(string CompanyCon, string MemberId)
        {
            string sql = "update tbl_JA_Sellers set CompanyContent='"+ CompanyCon +"' where MemberID='" + MemberId + "'";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            return DbHelper.ExecuteSql(cmd, _db);
        }
        /// <summary>
        /// 获取订单支付方式
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        public string GetZhiFuWay(string OrderId)
        {
            string ZhiFuWay = "暂未付款";
            string sql = "select TransactionWay from tbl_JA_Account where OrderID='" + OrderId + "'";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            EyouSoft.Model.Enum.ZhiFuFangShi zhiFuFangShi = ZhiFuFangShi.E额宝;

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    zhiFuFangShi = (ZhiFuFangShi)rdr.GetByte(rdr.GetOrdinal("TransactionWay"));
                    ZhiFuWay = zhiFuFangShi.ToString();
                }
            }

            return ZhiFuWay;
        }

    }
}
