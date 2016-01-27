using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.WAP
{
    public partial class searchlist : Common.Page.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "旅游线路";
            PageInit();
        }
        private void PageInit()
        {
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo searchmodel = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
            searchmodel.Xianluzt = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            searchmodel.RouteName = Utils.GetQueryStringValue("keyword");
            int cityid = Utils.GetInt(Utils.GetQueryStringValue("cityid"));
            if (cityid > 0)
            {
                hidcityid.Value = cityid.ToString();
                searchmodel.DepCityIds = new int[] { cityid };
            }
            else
            {
                var citymodel = EyouSoft.Security.Membership.UserProvider.GetCityInfo();
                if (citymodel != null)
                {
                    hidcityid.Value = citymodel.Id.ToString();
                    searchmodel.DepCityIds = new int[] { citymodel.Id };
                }
            }
            searchmodel.isNoTour = true;

            int recordCount = 0;
            IList<MXianLuInfo> list = bll.GetXianLus(8, 1, ref recordCount, searchmodel);
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

            }

        }
        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getCityName(object obj)
        {
            int cid = Utils.GetInt(obj.ToString());
            if (cid == 0) return "待定";
            var model = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(cid);
            if (model == null) return "待定";
            return model.Name;
        }
        /// <summary>
        /// 获取最近发班日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getLastDate(object obj)
        {
            List<MXianLuTourInfo> items = (List<MXianLuTourInfo>)obj;

            if (items == null) return "暂无发班信息";
            var lastList = items.OrderBy(j => j.LDate).Where(i => Utils.GetDateTime(i.LDate.ToString("yyyy-MM-dd")) > DateTime.Now).ToList();

            if (lastList == null || lastList.Count == 0) return "暂无发班信息";
            int top = 0;
            System.Text.StringBuilder BackHtml = new System.Text.StringBuilder();
            BackHtml.Append("<span class=\"font_yellow\">");
            for (int i = 0; i < lastList.Count; i++)
            {
                if (i != 0 && (lastList[i].LDate == lastList[0].LDate || lastList[i].LDate == lastList[i - 1].LDate)) continue;
                top++;
                BackHtml.AppendFormat("{0},", lastList[i].LDate.ToString("MM-dd"));
                if (top == 3) break;

            }
            string bkString = BackHtml.ToString().TrimEnd(',').Replace("-", "/").Replace(",", "、");
            bkString += string.Format("</span><br/><a href=\"/XianLuYuDing.aspx?id={0}&type={1}\">更多团期</a> ", lastList[0].XianLuID, Utils.GetQueryStringValue("type"));
            return bkString;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="lineType"></param>
        /// <returns></returns>
        protected string getSourceJP(object lineType)
        {
            LineSource source = (LineSource)lineType;
            if (source == LineSource.系统) return "JA";
            if (source == LineSource.博客) return "BK";
            if (source == LineSource.光大) return "GD";
            if (source == LineSource.欢途) return "HT";
            if (source == LineSource.省中旅) return "SZL";
            return "JA";
        }
        /// <summary>
        /// 获取会员等级价格
        /// </summary>
        /// <returns></returns>
        protected string getHYJ(string pType, string t, object tours)
        {
            List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo> list = (List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo>)tours;

            if (list == null || list.Count == 0)
            {
                return "待定";
            }
            var firstModel = list.OrderBy(m => m.JSJCR).First();
            EyouSoft.Model.Enum.FeeTypes type = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (t == "3") type = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (t == "1") type = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (t == "2") type = EyouSoft.Model.Enum.FeeTypes.国际线路;
            if (pType == "门市")
                return firstModel.CRSCJ.ToString("F0");
            else
                return UtilsCommons.GetGYStijia(type, firstModel.JSJCR, firstModel.CRSCJ, MemberTypes.普通会员).ToString("F0");
        }
        /// <summary>
        /// 返回景区图片
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        protected string getImgSrc(object objStr)
        {
            string defaultImg = "/images/line-img001.jpg";
            if (objStr == null) return defaultImg;
            string src = objStr.ToString();
            if (string.IsNullOrEmpty(src)) return defaultImg;
            return src;
        }
    }
}
