using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Model;

namespace EyouSoft.DAL.OtherStructure
{
    public class DKV : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.IKV
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DKV()
        {
            _db = base.SystemStore;
        }
        #endregion

        private const string SqlBcthSetSeting = "if not exists(select 1 from tbl_KV where K = '{0}' ) begin insert into tbl_KV(K,V) values('{0}','{1}') end else begin update tbl_KV set V='{1}' where K = '{0}'  end ;";

        //private const string SqlGetValue = "select V from tbl_KV where  and K = @K";

        //private const string SqlSetSetting = " delete tbl_KV where  K= @K; insert into tbl_KV(K,V) values(@K,@V);";

        #region IKV 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> 
        public bool SetCompanySetting(EyouSoft.Model.MCompanySetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(SqlBcthSetSeting, "CompanyIntroduce", model.CompanyIntroduce);
            strSql.AppendFormat(SqlBcthSetSeting, "About", model.About);
            strSql.AppendFormat(SqlBcthSetSeting, "Contact", model.Contact);
            strSql.AppendFormat(SqlBcthSetSeting, "Join", model.Join);
            strSql.AppendFormat(SqlBcthSetSeting, "LegalNotices", model.LegalNotices);
            strSql.AppendFormat(SqlBcthSetSeting, "Copyright", model.Copyright);
            strSql.AppendFormat(SqlBcthSetSeting, "Code", model.Code);
            strSql.AppendFormat(SqlBcthSetSeting, "Description", model.Description);
            strSql.AppendFormat(SqlBcthSetSeting, "Keywords", model.Keywords);
            strSql.AppendFormat(SqlBcthSetSeting, "Title", model.Title);
            strSql.AppendFormat(SqlBcthSetSeting, "Logo", model.Logo);
            strSql.AppendFormat(SqlBcthSetSeting, "RouteTatol", model.RouteTatol);
            strSql.AppendFormat(SqlBcthSetSeting, "ScenicTatol", model.ScenicTatol);
            strSql.AppendFormat(SqlBcthSetSeting, "HotelTatol", model.HotelTatol);
            strSql.AppendFormat(SqlBcthSetSeting, "QianZhengDingDanJiFenPeiZhi", model.QianZhengDingDanJiFenPeiZhi);
            strSql.AppendFormat(SqlBcthSetSeting, "JiPiaoDingDanJiFenPeiZhi", model.JiPiaoDingDanJiFenPeiZhi);
            strSql.AppendFormat(SqlBcthSetSeting, "TouristMap", model.TouristMap);
            strSql.AppendFormat(SqlBcthSetSeting, "TrainSearch", model.TrainSearch);
            strSql.AppendFormat(SqlBcthSetSeting, "TrainTravelTips", model.TrainTravelTips);
            strSql.AppendFormat(SqlBcthSetSeting, "TransitSearch", model.TransitSearch);
            strSql.AppendFormat(SqlBcthSetSeting, "WeatherSearch", model.WeatherSearch);
            strSql.AppendFormat(SqlBcthSetSeting, "ZipCode", model.ZipCode);
            strSql.AppendFormat(SqlBcthSetSeting, "OnlineTranslation", model.OnlineTranslation);
            strSql.AppendFormat(SqlBcthSetSeting, "MobileSearch", model.MobileSearch);
            strSql.AppendFormat(SqlBcthSetSeting, "FlightSearch", model.FlightSearch);
            strSql.AppendFormat(SqlBcthSetSeting, "MakeFenXiao", model.MakeFenXiao);
            strSql.AppendFormat(SqlBcthSetSeting, "MakeGongYing", model.MakeGongYing);
            strSql.AppendFormat(SqlBcthSetSeting, "MakeGuiBin", model.MakeGuiBin);
            strSql.AppendFormat(SqlBcthSetSeting, "MakePuTong", model.MakePuTong);
            strSql.AppendFormat(SqlBcthSetSeting, "MakeYingPing", model.MakeYingPing);
            strSql.AppendFormat(SqlBcthSetSeting, "MenPiaoLinks", model.MenPiaoLinks);
            strSql.AppendFormat(SqlBcthSetSeting, "XieYi", model.XieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "EBao", model.EBao);
            strSql.AppendFormat(SqlBcthSetSeting, "VisaXieYi", model.VisaXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "TicketXieYi", model.TicketXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "ShopXieYi", model.ShopXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "ZuCheXieyi", model.ZuCheXieyi);
            strSql.AppendFormat(SqlBcthSetSeting, "HotelXieYi", model.HotelXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "ChuJingXieYi", model.ChuJingXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "DuanXianXieYi", model.DuanXianXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "TuanGouXieYi", model.TuanGouXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "BaoJiaXieYi", model.BaoJiaXieYi);
            strSql.AppendFormat(SqlBcthSetSeting, "SLEJText", model.SLEJText);
            strSql.AppendFormat(SqlBcthSetSeting, "MoblieSLEJText", model.MoblieSLEJText);
            strSql.AppendFormat(SqlBcthSetSeting, "MoblieEBao", model.MoblieEBao);

            strSql.AppendFormat(SqlBcthSetSeting, "EBaoSSM", model.EBaoSSM);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoYEGL", model.EBaoYEGL);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoCZMX", model.EBaoCZMX);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoGMMX", model.EBaoGMMX);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoFLMX", model.EBaoFLMX);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoTXMX", model.EBaoTXMX);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoFXJ", model.EBaoFXJ);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoZHMX", model.EBaoZHMX);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoZMX", model.EBaoZMX);
            strSql.AppendFormat(SqlBcthSetSeting, "EBaoJFZZ", model.EBaoJFZZ);


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            return DbHelper.ExecuteSqlTrans(cmd, this._db) == 0 ? false : true;
        }

        public string GetMenPiaoLinks()
        {
            MCompanySetting m = GetCompanySetting("MenPiaoLinks");
            if (m == null)
            {
                return "";
            }
            return m.MenPiaoLinks ?? "";
        }

        public EyouSoft.Model.MCompanySetting GetCompanySetting()
        {
            return GetCompanySetting(null);
        }
        /// <summary>
        /// 获取公司配置信息
        /// </summary>
        public EyouSoft.Model.MCompanySetting GetCompanySetting(string type)
        {
            var strSql = new StringBuilder();

            if (string.IsNullOrEmpty(type))
            {
                strSql.Append(" select * from tbl_KV ");
            }
            else
            {
                strSql.Append(" select * from tbl_KV where K='" + type + "'");
            }

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            var model = new EyouSoft.Model.MCompanySetting();
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    string _k = dr["K"].ToString();
                    string _v = dr["V"].ToString();

                    if (string.IsNullOrEmpty(_k)) continue;

                    switch (dr.GetString(dr.GetOrdinal("K")))
                    {
                        case "CompanyIntroduce": model.CompanyIntroduce = _v; break;
                        case "About": model.About = _v; break;
                        case "Contact": model.Contact = _v; break;
                        case "Join": model.Join = _v; break;
                        case "LegalNotices": model.LegalNotices = _v; break;
                        case "Copyright": model.Copyright = _v; break;
                        case "Code": model.Code = _v; break;
                        case "Description": model.Description = _v; break;
                        case "Keywords": model.Keywords = _v; break;
                        case "Title": model.Title = _v; break;
                        case "Logo": model.Logo = _v; break;
                        case "RouteTatol": model.RouteTatol = _v; break;
                        case "ScenicTatol": model.ScenicTatol = _v; break;
                        case "HotelTatol": model.HotelTatol = _v; break;
                        case "ApdXianLuTime": model.ApdXianLuTime = Utils.GetInt(_v); break;
                        case "ApdJiuDianTime": model.ApdJiuDianTime = Utils.GetInt(_v); break;
                        case "ApdJingDianTime": model.ApdJingDianTime = Utils.GetInt(_v); break;
                        case "AdpXianLuHaoMa": model.AdpXianLuHaoMa = _v; break;
                        case "AdpJiuDianHaoMa": model.AdpJiuDianHaoMa = _v; break;
                        case "AdpJingDianHaoMa": model.AdpJingDianHaoMa = _v; break;
                        case "QianZhengDingDanJiFenPeiZhi": model.QianZhengDingDanJiFenPeiZhi = _v; break;
                        case "JiPiaoDingDanJiFenPeiZhi": model.JiPiaoDingDanJiFenPeiZhi = _v; break;
                        case "TouristMap": model.TouristMap = _v; break;
                        case "TrainSearch": model.TrainSearch = _v; break;
                        case "TrainTravelTips": model.TrainTravelTips = _v; break;
                        case "TransitSearch": model.TransitSearch = _v; break;
                        case "WeatherSearch": model.WeatherSearch = _v; break;
                        case "ZipCode": model.ZipCode = _v; break;
                        case "OnlineTranslation": model.OnlineTranslation = _v; break;
                        case "MobileSearch": model.MobileSearch = _v; break;
                        case "FlightSearch": model.FlightSearch = _v; break;
                        case "MakeYingPing": model.MakeYingPing = _v; break;
                        case "MakePuTong": model.MakePuTong = _v; break;
                        case "MakeGuiBin": model.MakeGuiBin = _v; break;
                        case "MakeGongYing": model.MakeGongYing = _v; break;
                        case "MakeFenXiao": model.MakeFenXiao = _v; break;
                        case "MenPiaoLinks": model.MenPiaoLinks = _v; break;
                        case "XieYi": model.XieYi = _v; break;
                        case "EBao": model.EBao = _v; break;
                        case "VisaXieYi": model.VisaXieYi = _v; break;
                        case "TicketXieYi": model.TicketXieYi = _v; break;
                        case "DuanXianXieYi": model.DuanXianXieYi = _v; break;
                        case "ChuJingXieYi": model.ChuJingXieYi = _v; break;
                        case "ZuCheXieyi": model.ZuCheXieyi = _v; break;
                        case "HotelXieYi": model.HotelXieYi = _v; break;
                        case "ShopXieYi": model.ShopXieYi = _v; break;
                        case "TuanGouXieYi": model.TuanGouXieYi = _v; break;
                        case "BaoJiaXieYi": model.BaoJiaXieYi = _v; break;
                        case "SLEJText": model.SLEJText = _v; break;
                        case "MoblieEBao": model.MoblieEBao = _v; break;
                        case "MoblieSLEJText": model.MoblieSLEJText = _v; break;

                        case "EBaoSSM": model.EBaoSSM = _v; break;
                        case "EBaoYEGL": model.EBaoYEGL = _v; break;
                        case "EBaoCZMX": model.EBaoCZMX = _v; break;
                        case "EBaoGMMX": model.EBaoGMMX = _v; break;
                        case "EBaoFLMX": model.EBaoFLMX = _v; break;
                        case "EBaoTXMX": model.EBaoTXMX = _v; break;
                        case "EBaoFXJ": model.EBaoFXJ = _v; break;
                        case "EBaoZHMX": model.EBaoZHMX = _v; break;
                        case "EBaoZMX": model.EBaoZMX = _v; break;
                        case "EBaoJFZZ": model.EBaoJFZZ = _v; break;

                        default: break;
                    }
                }
            }

            return model;
        }



        ///// <summary>
        ///// 获取指定公司的配置信息
        ///// </summary>
        ///// <param name="companyId"></param>
        ///// <param name="fileKey"></param>
        ///// <returns></returns>
        //public string GetValue(string K)
        //{
        //    string V = string.Empty;
        //    DbCommand cmd = this._db.GetSqlStringCommand(SqlGetValue);
        //    this._db.AddInParameter(cmd, "K", DbType.String, K);


        //    using (IDataReader rdr = Toolkit.DAL.DbHelper.ExecuteReader(cmd, this._db))
        //    {
        //        if (rdr.Read())
        //        {
        //            V = rdr.IsDBNull(rdr.GetOrdinal("V"))
        //                             ? string.Empty
        //                             : rdr.GetString(rdr.GetOrdinal("V"));
        //        }
        //    }

        //    return V;
        //}

        ///// <summary>
        ///// 设置指定公司的配置信息
        ///// </summary>
        ///// <param name="companyId">公司编号</param>
        ///// <param name="fieldKey">配置key</param>
        ///// <param name="fieldValue">配置value</param>
        ///// <returns></returns>
        //public bool SetValue(string K, string V)
        //{
        //    DbCommand dc = this._db.GetSqlStringCommand(SqlSetSetting);
        //    this._db.AddInParameter(dc, "K", DbType.String, K);
        //    this._db.AddInParameter(dc, "V", DbType.String, V);
        //    return Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        //}

        /// <summary>
        /// 设置下级分销奖励配置信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiXiaJiFenXiaoJiangLiPeiZhi(EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(SqlBcthSetSeting, "XiaJiFenXiaoJiangLiYongJinJieSuanBiLi", info.JieSuanBiLi);
            sql.AppendFormat(SqlBcthSetSeting, "XiaJiFenXiaoJiangLiZuiXiaoJieSuanYongJinJinE", info.ZuiXiaoJieSuanYongJinJinE);

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 获取下级分销奖励配置信息
        /// </summary>
        /// <returns></returns>
        public EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo GetXiaJiFenXiaoJiangLiPeiZhi()
        {
            var info = new EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo();
            string sql = "SELECT * FROM tbl_KV WHERE K IN(@K1,@K2)";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "K1", DbType.String, "XiaJiFenXiaoJiangLiYongJinJieSuanBiLi");
            _db.AddInParameter(cmd, "K2", DbType.String, "XiaJiFenXiaoJiangLiZuiXiaoJieSuanYongJinJinE");

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    string _k = rdr["K"].ToString();
                    string _v = rdr["V"].ToString();

                    switch (_k)
                    {
                        case "XiaJiFenXiaoJiangLiYongJinJieSuanBiLi": info.JieSuanBiLi = Utils.GetDecimal(_v); break;
                        case "XiaJiFenXiaoJiangLiZuiXiaoJieSuanYongJinJinE": info.ZuiXiaoJieSuanYongJinJinE = Utils.GetDecimal(_v); break;
                        default: break;
                    }
                }
            }

            return info;
        }
        #endregion
    }
}
