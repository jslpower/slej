using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Newtonsoft.Json.Converters;
using System.Text;

namespace EyouSoft.Web.CommonPage
{
    public partial class XianLuRiLi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string doType = Utils.GetQueryStringValue("doType");
            if (doType == "getTours") GetTours();
        }
        /// <summary>
        /// 获取发班信息
        /// </summary>
        void GetTours()
        {
            string xianluid = Utils.GetFormValue("xianluid");
            DateTime sLDate = new DateTime(Utils.GetInt(Utils.GetFormValue("year"), DateTime.Now.Year), Utils.GetInt(Utils.GetFormValue("month"), DateTime.Now.Month), 1);
            DateTime eLDate = sLDate.AddMonths(1);

            EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 3) FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 1) FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 2) FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;
            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (model == null) return;
            #region 处理博客和广大的航班信息
            bool isxianshi = model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大 || (model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.博客 && model.LineType == EyouSoft.Model.XianLuStructure.LineType.长线);
            string hangban = string.Empty;
            if (isxianshi)
            {
                if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                {
                    hangban = model.TourTraffice[0].TrafficId;//默认加载选择第一个航班
                }
            }

            #endregion


            #region 发班信息
            string boxString = "[]";
            if (model.Tours != null && model.Tours.Count > 0)
            {


                IsoDateTimeConverter isDate = new IsoDateTimeConverter();
                isDate.DateTimeFormat = "yyyy-M-d";
                var olist = model.Tours.Where(m => m.LDate >= DateTime.Now).ToList();
                List<seraModel> nlist = new List<seraModel>();
                if (olist != null && olist.Count > 0)
                {
                    for (int i = 0; i < olist.Count; i++)
                    {
                        if (olist[i].TrafficId != hangban && isxianshi) continue;//只取一个航班号
                        nlist.Add(new seraModel() { xid = model.XianLuId, xtp = ((int)FeeType).ToString(), tid = olist[i].TourId, hyj = UtilsCommons.GetGYStijia(FeeType, olist[i].JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0"), ldate = olist[i].LDate, msj = model.SCJCR.ToString("F0"), yw = olist[i].SYRS });

                    }
                }
                boxString = Newtonsoft.Json.JsonConvert.SerializeObject(nlist, isDate);
            }
            #endregion
            Utils.RCWE(boxString);
        }
    }
}
