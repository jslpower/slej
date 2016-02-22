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
        /// 代理商，员工，免费代理修改信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateDaiLiMemberInfo(MMember2 model)
        {
            string sql = "update tbl_Member set MemberName=@MemberName,Address=@Address,Mobile=@Mobile,Email=@Email,Contact=@Contact,qq=@qq where MemberID=@MemberID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "MemberName", DbType.String, model.MemberName);
            this._db.AddInParameter(cmd, "Email", DbType.String, model.Email);
            this._db.AddInParameter(cmd, "Contact", DbType.String, model.Contact);
            this._db.AddInParameter(cmd, "qq", DbType.String, model.qq);
            this._db.AddInParameter(cmd, "Mobile", DbType.String, model.Mobile);
            this._db.AddInParameter(cmd, "MemberID", DbType.String, model.MemberID);
            this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 代理商，员工，免费代理修改代理信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateDaiLiSellerInfo(EyouSoft.Model.AccountStructure.MSellers model)
        {
            string sql = "update tbl_JA_Sellers set CompanyName=@CompanyName,CompanyJC=@CompanyJC,SupplierType=@SupplierType,Qualifications=@Qualifications,MapX=@MapX,MapY=@MapY,CardPath=@CardPath,AccountPaht=@AccountPaht,VisitPath=@VisitPath,OtherPath=@OtherPath,FormPath=@FormPath,WapLogo=@WapLogo,WebLogo=@WebLogo where ID=@ID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "CompanyName", DbType.String, model.CompanyName);
            this._db.AddInParameter(cmd, "CompanyJC", DbType.String, model.CompanyJC);
            this._db.AddInParameter(cmd, "SupplierType", DbType.Int16, (int)model.SupplierType);
            this._db.AddInParameter(cmd, "Qualifications", DbType.String, model.Qualifications);
            this._db.AddInParameter(cmd, "MapX", DbType.String, model.MapX);
            this._db.AddInParameter(cmd, "MapY", DbType.String, model.MapY);
            this._db.AddInParameter(cmd, "CardPath", DbType.String, model.CardPath);
            this._db.AddInParameter(cmd, "AccountPaht", DbType.String, model.AccountPaht);
            this._db.AddInParameter(cmd, "VisitPath", DbType.String, model.VisitPath);
            this._db.AddInParameter(cmd, "OtherPath", DbType.String, model.OtherPath);
            this._db.AddInParameter(cmd, "FormPath", DbType.String, model.FormPath);
            this._db.AddInParameter(cmd, "ID", DbType.String, model.ID);
            this._db.AddInParameter(cmd, "WebLogo", DbType.String, model.WebLogo);
            this._db.AddInParameter(cmd, "WapLogo", DbType.String, model.WapLogo);

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
            string sql = "update tbl_Member set PassWord=@PassWord,MD5Password=@MD5Password where MemberID=@MemberID;UPDATE tbl_Webmaster set Password=@PassWord,MD5Password=@MD5Password WHERE Username=(select top 1 Account from tbl_Member where MemberID=@MemberID) AND LeiXing=2";
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
        /// <summary>
        /// 获取代理商城商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyDaiLi(string GYSId,int PageIndex,int PageSize, MTeYueSer sermodel)
        {
            IList<MTeYue> list = new List<MTeYue>();
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if(!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            if (sermodel.IsMyDaiLi > 0)
            {
                if (sermodel.IsMyDaiLi == 1)
                {
                    sqlwhere.AppendFormat(" and a.ID in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=0 ) ", GYSId);
                }
                else
                {
                    sqlwhere.AppendFormat(" and a.ID NOT in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=0 ) ", GYSId);
                }
            }
            string sql = "SELECT * from (select ROW_NUMBER() OVER(order by b.Mobile desc ) AS RowNumber,a.*,b.MemberName,b.Mobile from (select MemberID,ID,WebsiteName,CompanyName,WebSite from tbl_JA_Sellers where ID in(SELECT DISTINCT MemberId from tbl_Seller_ShangCheng where MemberId <> '" + GYSId + "' and ProductId in (select ProductID from tbl_ShangChengChanPin where GYSid='" + GYSId + "')))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString() + ") as c where  RowNumber BETWEEN " + (PageIndex - 1) * PageSize + " and " + PageIndex * PageSize;
            DbCommand cmd = this._db.GetSqlStringCommand(sql.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                   MTeYue model = new MTeYue();
                   model.ID = dr["ID"].ToString();
                   model.MemberID = dr["MemberID"].ToString();
                   model.WebsiteName = dr["WebsiteName"].ToString();
                   model.MemberName = dr["MemberName"].ToString();
                   model.CompanyName = dr["CompanyName"].ToString();
                   model.Mobile = dr["Mobile"].ToString();
                   model.WebSite = dr["WebSite"].ToString();
                   list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        /// 获取选择我的商城商品的代理总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int GetMyDaiLiNum(string GYSId, MTeYueSer sermodel)
        {
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            if (sermodel.IsMyDaiLi > 0)
            {
                if (sermodel.IsMyDaiLi == 1)
                {
                    sqlwhere.AppendFormat(" and a.ID in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=0 ) ", GYSId);
                }
                else
                {
                    sqlwhere.AppendFormat(" and a.ID NOT in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=0 ) ", GYSId);
                }
            }
            string sql = "select Count(a.MemberID) from (select MemberID,ID,WebsiteName,CompanyName from tbl_JA_Sellers where ID in(SELECT DISTINCT MemberId from tbl_Seller_ShangCheng where MemberId <> '" + GYSId + "' and ProductId in (select ProductID from tbl_ShangChengChanPin where GYSid='" + GYSId + "')))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString();
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 判断该代理商是否为我的商城下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int JudgeDaiLi(string GYSId, string DaiLiId)
        {
            string sql = "SELECT COUNT(ID) FROM tbl_GYS_Seller where GYSId='" + GYSId + "' and DaiLiId='" + DaiLiId + "'  and LeiXing=0 ";
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 添加我的商城下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int AddDaiLi(string GYSId, string DaiLiId)
        {
            string sql = "INSERT into tbl_GYS_Seller (GYSId,DaiLiId,LeiXing) VALUES('" + GYSId + "','" + DaiLiId + "',0)";
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.ExecuteSql(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 删除我的商城下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int DelDaiLi(string GYSId, string DaiLiId)
        {
            string sql = "DELETE from tbl_GYS_Seller where GYSId='" + GYSId + "' and DaiLiId='" + DaiLiId + "' and LeiXing=0 ";
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.ExecuteSql(cmd, _db);
            return Convert.ToInt32(num);
        }

        /// <summary>
        /// 获取代理团购商品的代理商列表
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyTGDaiLi(string GYSId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            IList<MTeYue> list = new List<MTeYue>();
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            if (sermodel.IsMyDaiLi > 0)
            {
                if (sermodel.IsMyDaiLi == 1)
                {
                    sqlwhere.AppendFormat(" and a.ID in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=1 ) ", GYSId);
                }
                else
                {
                    sqlwhere.AppendFormat(" and a.ID NOT in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=1 ) ", GYSId);
                }
            }
            string sql = "SELECT * from (select ROW_NUMBER() OVER(order by b.Mobile desc ) AS RowNumber,a.*,b.MemberName,b.Mobile from (select MemberID,ID,WebsiteName,CompanyName,WebSite from tbl_JA_Sellers where ID in(SELECT DISTINCT MemberId from tbl_Seller_TuanGou where  MemberId <> '" + GYSId + "' and ProductId in (select ProductID from tbl_TuanGouChanPin where SupplierID='" + GYSId + "')))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString() + ") as c where  RowNumber BETWEEN " + (PageIndex - 1) * PageSize + " and " + PageIndex * PageSize;
            DbCommand cmd = this._db.GetSqlStringCommand(sql.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MTeYue model = new MTeYue();
                    model.ID = dr["ID"].ToString();
                    model.MemberID = dr["MemberID"].ToString();
                    model.WebsiteName = dr["WebsiteName"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.CompanyName = dr["CompanyName"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.WebSite = dr["WebSite"].ToString();
                    list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        /// 获取选择我的团购商品的代理总数
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int GetMyTGDaiLiNum(string GYSId, MTeYueSer sermodel)
        {
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            if (sermodel.IsMyDaiLi > 0)
            {
                if (sermodel.IsMyDaiLi == 1)
                {
                    sqlwhere.AppendFormat(" and a.ID in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=1 ) ", GYSId);
                }
                else
                {
                    sqlwhere.AppendFormat(" and a.ID NOT in (SELECT  DailiId from tbl_GYS_Seller WHERE GYSid='{0}' and LeiXing=1 ) ", GYSId);
                }
            }
            string sql = "select Count(a.MemberID) from (select MemberID,ID,WebsiteName,CompanyName from tbl_JA_Sellers where ID in(SELECT DISTINCT MemberId from tbl_Seller_TuanGou where MemberId <> '" + GYSId + "' and  ProductId in (select ProductID from tbl_TuanGouChanPin where SupplierID='" + GYSId + "')))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString();
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 判断该代理商是否为我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int JudgeTGDaiLi(string GYSId, string DaiLiId)
        {
            string sql = "SELECT COUNT(ID) FROM tbl_GYS_Seller where GYSId='" + GYSId + "' and DaiLiId='" + DaiLiId + "'  and LeiXing=1 ";
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 添加我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int AddTGDaiLi(string GYSId, string DaiLiId)
        {
            string sql = "INSERT into tbl_GYS_Seller (GYSId,DaiLiId,LeiXing) VALUES('" + GYSId + "','" + DaiLiId + "',1)";
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.ExecuteSql(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 删除我的团购下级代理
        /// </summary>
        /// <param name="GYSId"></param>
        /// <returns></returns>
        public int DelTGDaiLi(string GYSId, string DaiLiId)
        {
            string sql = "DELETE from tbl_GYS_Seller where GYSId='" + GYSId + "' and DaiLiId='" + DaiLiId + "' and LeiXing=1 ";
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.ExecuteSql(cmd, _db);
            return Convert.ToInt32(num);
        }

        /// <summary>
        /// 获取代理商城商品的供应商列表
        /// </summary>
        /// <param name="DaiLiId">代理商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyGYS(string DaiLiId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            IList<MTeYue> list = new List<MTeYue>();
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            string sql = "SELECT * from (select ROW_NUMBER() OVER(order by b.Mobile desc ) AS RowNumber,a.*,b.MemberName,b.Mobile from (SELECT MemberID,ID,WebsiteName,CompanyName,WebSite from tbl_JA_Sellers where ID in(SELECT GYSid from tbl_ShangChengChanPin where GYSid <> '" + DaiLiId + "' and ProductID in (SELECT ProductId from tbl_Seller_ShangCheng where MemberId='" + DaiLiId + "' and ProductStatus=2)))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString() + ") as c where  RowNumber BETWEEN " + (PageIndex - 1) * PageSize + " and " + PageIndex * PageSize;
            DbCommand cmd = this._db.GetSqlStringCommand(sql.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MTeYue model = new MTeYue();
                    model.ID = dr["ID"].ToString();
                    model.MemberID = dr["MemberID"].ToString();
                    model.WebsiteName = dr["WebsiteName"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.CompanyName = dr["CompanyName"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.WebSite = dr["WebSite"].ToString();
                    list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        ///  获取代理商城商品的供应商总数
        /// </summary>
        /// <param name="DaiLiId"></param>
        /// <returns></returns>
        public int GetMyGYSNum(string DaiLiId, MTeYueSer sermodel)
        {
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            string sql = "select Count(a.MemberID) from (SELECT MemberID,ID,WebsiteName,CompanyName from tbl_JA_Sellers where ID in(SELECT GYSid from tbl_ShangChengChanPin where GYSid <> '" + DaiLiId + "' and ProductID in (SELECT ProductId from tbl_Seller_ShangCheng where MemberId='" + DaiLiId + "' and ProductStatus=2)))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString();
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 获取代理团购商品的供应商列表
        /// </summary>
        /// <param name="DaiLiId">代理商id</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyTGGYS(string DaiLiId, int PageIndex, int PageSize, MTeYueSer sermodel)
        {
            IList<MTeYue> list = new List<MTeYue>();
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            string sql = "SELECT * from (select ROW_NUMBER() OVER(order by b.Mobile desc ) AS RowNumber,a.*,b.MemberName,b.Mobile from (SELECT MemberID,ID,WebsiteName,CompanyName,WebSite from tbl_JA_Sellers where ID in(SELECT SupplierID from tbl_TuanGouChanPin where SupplierID <> '" + DaiLiId + "' and ID in (SELECT ProductId from tbl_Seller_TuanGou where MemberId='" + DaiLiId + "' and ProductStatus=2)))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString() + ") as c where  RowNumber BETWEEN " + (PageIndex - 1) * PageSize + " and " + PageIndex * PageSize;
            DbCommand cmd = this._db.GetSqlStringCommand(sql.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MTeYue model = new MTeYue();
                    model.ID = dr["ID"].ToString();
                    model.MemberID = dr["MemberID"].ToString();
                    model.WebsiteName = dr["WebsiteName"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.CompanyName = dr["CompanyName"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.WebSite = dr["WebSite"].ToString();
                    list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        ///  获取代理团购商品的供应商总数
        /// </summary>
        /// <param name="DaiLiId"></param>
        /// <returns></returns>
        public int GetMyTGGYSNum(string DaiLiId, MTeYueSer sermodel)
        {
            StringBuilder sqlwhere = new StringBuilder();
            sqlwhere.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(sermodel.CompanyName))
            {
                sqlwhere.AppendFormat(" and CompanyName like '%{0}%' ", sermodel.CompanyName);
            }
            if (!string.IsNullOrEmpty(sermodel.MemberName))
            {
                sqlwhere.AppendFormat(" and MemberName like '%{0}%' ", sermodel.MemberName);
            }
            if (!string.IsNullOrEmpty(sermodel.Mobile))
            {
                sqlwhere.AppendFormat(" and Mobile like '%{0}%' ", sermodel.Mobile);
            }
            if (!string.IsNullOrEmpty(sermodel.WebsiteName))
            {
                sqlwhere.AppendFormat(" and WebsiteName like '%{0}%' ", sermodel.WebsiteName);
            }
            string sql = "select Count(a.MemberID) from (SELECT MemberID,ID,WebsiteName,CompanyName from tbl_JA_Sellers where ID in(SELECT SupplierID from tbl_TuanGouChanPin where SupplierID <> '" + DaiLiId + "' and ID in (SELECT ProductId from tbl_Seller_TuanGou where MemberId='" + DaiLiId + "' and ProductStatus=2)))as a left JOIN tbl_Member as b on a.MemberID=b.MemberID " + sqlwhere.ToString();
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }

        /// <summary>
        /// 获取我的特约代理
        /// </summary>
        /// <param name="GYSId">供应商id</param>
        /// <param name="LeiBie">商城-0，团购-1</param>
        /// <returns></returns>
        public IList<MTeYue> GetMyTY(string GYSId,int LeiBie)
        {
            IList<MTeYue> list = new List<MTeYue>();
            StringBuilder sqlwhere = new StringBuilder();

            string sql = "SELECT ID,WebsiteName from tbl_JA_Sellers where ID in(SELECT DaiLiId from tbl_GYS_Seller where GYSId='" + GYSId + "' AND LeiXing="+LeiBie+")";
            DbCommand cmd = this._db.GetSqlStringCommand(sql.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MTeYue model = new MTeYue();
                    model.ID = dr["ID"].ToString();
                    model.WebsiteName = dr["WebsiteName"].ToString();
                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取域名（按邀请码）
        /// </summary>
        /// <param name="yaQingMa"></param>
        /// <returns></returns>
        public string GetYuMing_YaoQingMa(string yaQingMa)
        {
            var sql = "SELECT B.WebSite FROM tbl_Member AS A INNER JOIN tbl_JA_Sellers AS B ON A.MemberID=B.MemberID WHERE A.Account=@YongHuMing";

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "YongHuMing", DbType.String, yaQingMa);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr[0].ToString();
                }
            }

            return string.Empty;
        }

    }
}
