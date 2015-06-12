using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;
namespace EyouSoft.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CityHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string dotype = Utils.GetQueryStringValue("dotype");

            switch (dotype)
            {
                case "city": BindHotelCity(); break;
                case "SanZiMa": BindAreaName(); break;
                case "LandMarkName": BindLandMarkName(); break;
                case "LandChildName": BindLandChildName(); break;
                default: break;
            }
        }
        /// <summary>
        /// 绑定省份
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected void BindHotelCity()
        {
            string ProviceName = Utils.GetQueryStringValue("provicename");
            string query = "";
            IList<EyouSoft.Model.HotelStructure.MHotelCityAreas> list = new EyouSoft.BLL.HotelStructure.BHotelCity().GetCitySZMList(ProviceName);
            query = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            HttpContext.Current.Response.Write(query);
        }
        /// <summary>
        /// 根据城市三字码获取一级地标
        /// </summary>
        protected void BindAreaName()
        {
            string CityCode = Utils.GetQueryStringValue("CityCode");
            string query = "";
            IList<Model.OtherStructure.MLandMark> list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetAreaName(CityCode);
            query = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            HttpContext.Current.Response.Write(query);
        }
        /// <summary>
        /// 根据城市三字码和一级地标获取二级地标
        /// </summary>
        protected void BindLandMarkName()
        {
            string CityCode = Utils.GetQueryStringValue("CityCode");
            string AreaCode = Utils.GetQueryStringValue("AreaCode");
            string query = "";
            IList<Model.OtherStructure.MLandMark> list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetLandMarkName(CityCode,AreaCode);
            query = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            HttpContext.Current.Response.Write(query);
        }
        /// <summary>
        /// 根据城市三字码和一级地标二级地标获取三级级地标
        /// </summary>
        protected void BindLandChildName()
        {
            string CityCode = Utils.GetQueryStringValue("CityCode");
            string AreaCode = Utils.GetQueryStringValue("AreaCode");
            string LandMarkName = Utils.GetQueryStringValue("LandMarkName");
            string query = "";
            IList<Model.OtherStructure.MLandMark> list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetLandChildName(CityCode, AreaCode,LandMarkName);
            query = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            HttpContext.Current.Response.Write(query);
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
