using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;
using System.Text;
using EyouSoft.Model.SystemStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP
{
    public partial class HotelXX : System.Web.UI.Page
    {
        BHotel2 bll = new BHotel2();
        MHotelXiangQingModel2 Model = new MHotelXiangQingModel2();
        protected string Ruzhuriqi = "";
        protected string Lidianriqi = "";
        protected string ruzhutime = "";
        protected string lidiantime = "";
        protected string Longitude = "";
        protected string Latitude = "";
        protected string HotelMing = "";
        protected string Address = "";
        protected string Mobile = "";
        protected string jiudianid = "";
        protected string fangxin = "";
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.isfx = true;
            WapHeader1.HeadText = "酒店详情";

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);

            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("RuZhuRiQi")))
            {
                Model.RuZhuRiQi = DateTime.Now.Date;
            }
            else
            {
                Model.RuZhuRiQi = Convert.ToDateTime(Utils.GetQueryStringValue("RuZhuRiQi"));
            }
            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("LiDianRiQi")))
            {
                Model.LiDianRiQi = Model.RuZhuRiQi.Value.AddDays(1).Date;
            }
            else
            {
                Model.LiDianRiQi = Convert.ToDateTime(Utils.GetQueryStringValue("LiDianRiQi"));
            }
            if (Model.LiDianRiQi <= Model.RuZhuRiQi)
            {
                Model.LiDianRiQi = Model.RuZhuRiQi.Value.AddDays(1).Date;
            }
            Model.HotelId = Utils.GetQueryStringValue("HotelId");
            jiudianid = Model.HotelId;
            MHotelXiangQingModel model = bll.GetHotelDetail(Model);
            if (model == null)
            {
                Response.End();
            }
            HotelName.Text = model.HotelName;
            KeFuTel.Text = model.ServiceTel;
            HotelMing = model.HotelName;
            Longitude = model.Longitude;
            Latitude = model.Latitude;
            Address = model.Address;
            Mobile = model.Mobile;
            HotelStar.Text = ((EyouSoft.Model.Enum.HotelStar)model.Star).ToString();
            HotelAddress.Text = model.Address;
            HotelJianJie.Text = Utils.GetText2(model.LongDesc, 45, true);
            Ruzhuriqi = Model.RuZhuRiQi.Value.ToString("MM月dd日");
            Lidianriqi = Model.LiDianRiQi.Value.ToString("MM月dd日");
            ruzhutime = Model.RuZhuRiQi.Value.ToString("yyyy-MM-dd");
            lidiantime = Model.LiDianRiQi.Value.ToString("yyyy-MM-dd");
            MHotelSearchModel1 searchmodel = new MHotelSearchModel1();
            searchmodel.RuZhuRiQi = Model.RuZhuRiQi;
            searchmodel.LiDianRiQi = Model.LiDianRiQi;
            searchmodel.HotelId = Model.HotelId;
            MHotelXiangQingModel imgmodel = new MHotelXiangQingModel() { SearchInfo = new Linq.Bussiness.SearchModel() { PageInfo = new Linq.Bussiness.PageInfo() { PageIndex = 1, PageSize = 5 } } };
            imgmodel.HotelId = searchmodel.HotelId;
            var imglist = bll.GetHotelImgList(imgmodel);


            WapHeader1.FenXiangBiaoTi = model.HotelName.Trim();
            WapHeader1.FenXiangMiaoShu = Utils.GetText2(model.LongDesc, 30, true).Trim();
            if (imglist.Count > 0 && !string.IsNullOrEmpty(imglist[0].FilePath))
            {
                //WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(imglist[0].FilePath, 640, 400);
            }
            WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString().Replace("p.", "m."));

            #region 图片处理

            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (imglist != null && imglist.Count > 0)
            {
                foreach (var item in imglist)
                {
                    files.Add(TuPian.F1(item.FilePath, 640, 400));
                    hrefs.Add("javascript:;");
                }

            }
            ScrollImg1.ImgUrl = files;
            ScrollImg1.HrefUrl = hrefs;
            ScrollImg1.ImgGth = 400;
            ScrollImg1.ImgWid = 640;
            #endregion
            var list = bll.GetHotelList(searchmodel, false, EyouSoft.Model.Enum.MemberTypes.普通会员, false);
            if (list != null && list.Count > 0)
            {
                if (list[0].RoomRateInfo.Count > 0)
                {


                    DateTime checkInDate = Model.RuZhuRiQi.Value.Date;
                    DateTime checkOutDate = Model.LiDianRiQi.Value.Date;

                    var group = list[0].RoomRateInfo.OrderBy(x => x.RoomTypeInfo.RoomTypeId).ThenByDescending(x => x.RoomRateId).GroupBy(x => x.RoomTypeInfo.RoomTypeId);
                    foreach (var g in group)
                    {
                        string RoomIdLists = "";
                        var roomTypeInfo = list[0].RoomRateInfo.FirstOrDefault(x => x.RoomTypeInfo.RoomTypeId == g.Key).RoomTypeInfo;
                        var currentGroupArr = g.OrderBy(x => x.StartDate).ToArray();

                        Dictionary<string, TempClass> rooRateInfo = new Dictionary<string, TempClass>();

                        //对价格按rate_plan_code进行组合
                        for (int k = 0; k < currentGroupArr.Length; k++)
                        {
                            MHotelRoomRateBindModel currentRoomRate = currentGroupArr[k];
                            string rate_plan_code = string.IsNullOrEmpty(currentGroupArr[k].InterfaceID) ? "" : (currentGroupArr[k].InterfaceID + "$" + currentGroupArr[k].RoomRateName);

                            //完全匹配列表
                            if (currentRoomRate.StartDate <= checkInDate && currentRoomRate.EndDate >= checkOutDate.AddDays(-1))
                            {
                                if (!rooRateInfo.ContainsKey(rate_plan_code))
                                {
                                    rooRateInfo.Add(rate_plan_code, new TempClass
                                    {
                                        RoomRateIds = new List<int> { currentRoomRate.RoomRateId },
                                        FeeSetting = currentRoomRate.FeeSetting,
                                        PreferentialPrice = new List<decimal> { currentRoomRate.PreferentialPrice },
                                        RoomRateName = new List<string> { currentRoomRate.RoomRateName },
                                        SettlementPrice = new List<decimal> { currentRoomRate.SettlementPrice },
                                        BreakFasts = new List<string> { currentRoomRate.Breakfast },
                                    });
                                    for (int mday = 0; mday < (checkOutDate - checkInDate).Days; mday++)
                                    {
                                        RoomIdLists += currentRoomRate.RoomRateId + ",";
                                    }
                                }
                                else
                                {
                                    Response.Write("数据错误：计划重复了"); //同一个rate_plan_code下有多个价格计划都满足当前日期条件，这是不应当的，表示源数据有问题。
                                    Response.End();
                                }
                            }
                            else //部分匹配列表
                            {
                                if (!rooRateInfo.ContainsKey(rate_plan_code))
                                {
                                    rooRateInfo.Add(rate_plan_code,
                                        new TempClass
                                        {
                                            RoomRateIds = new List<int> { currentRoomRate.RoomRateId },
                                            FeeSetting = currentRoomRate.FeeSetting,
                                            PreferentialPrice = new List<decimal> { currentRoomRate.PreferentialPrice },
                                            RoomRateName = new List<string> { currentRoomRate.RoomRateName },
                                            SettlementPrice = new List<decimal> { currentRoomRate.SettlementPrice },
                                            BreakFasts = new List<string> { currentRoomRate.Breakfast },
                                        });
                                    for (DateTime SInDate = checkInDate; SInDate < checkOutDate && SInDate <= currentRoomRate.EndDate; SInDate = SInDate.AddDays(1))
                                    {
                                        RoomIdLists += currentRoomRate.RoomRateId + ",";
                                    }
                                }
                                else
                                {
                                    for (DateTime SInDate = checkInDate; SInDate < checkOutDate; SInDate = SInDate.AddDays(1))
                                    {
                                        if (SInDate >= currentRoomRate.StartDate)
                                        {
                                            RoomIdLists += currentRoomRate.RoomRateId + ",";
                                        }
                                    }
                                    rooRateInfo[rate_plan_code].RoomRateIds.Add(currentRoomRate.RoomRateId);
                                    rooRateInfo[rate_plan_code].PreferentialPrice.Add(currentRoomRate.PreferentialPrice);
                                    rooRateInfo[rate_plan_code].SettlementPrice.Add(currentRoomRate.SettlementPrice);
                                    rooRateInfo[rate_plan_code].BreakFasts.Add(currentRoomRate.Breakfast);
                                    rooRateInfo[rate_plan_code].RoomRateName.Add(currentRoomRate.RoomRateName);
                                }
                            }
                        }
                        foreach (var item in rooRateInfo)
                        {
                            int index;
                            decimal min_settlementprice = SearchMin(item.Value.SettlementPrice, out index);
                            decimal min_preferentialprice = item.Value.PreferentialPrice[index];
                            fangxin += "<div class=\"hotel_fx\"><div class=\"fx_name\"><i class=\"minus\"></i>" + roomTypeInfo.RoomName + "--" + item.Value.RoomRateName[0] + "<span class=\"price_R\">¥ " + (min_preferentialprice * BHotel2.RetialPricePercent).ToString("0") + "</span></div><div class=\"fx_more\" ><div class=\"fx_box\"><ul>";
                            if (roomTypeInfo.BedType == 0)
                            {
                                fangxin += "<li>床型：" + roomTypeInfo.BedTypeDescription + "</li>";
                            }
                            else
                            {
                                fangxin += "<li>床型：" + roomTypeInfo.BedType.ToString() + "</li>";
                            }
                            fangxin += "<li class=\"right_txt\">楼层：" + roomTypeInfo.Floor + "</li>";
                            if (item.Value.BreakFasts.Count > 0)
                            {
                                string bf = BHotel2.TransBreakFastBetweenInterfaceAndSelfProject(item.Value.BreakFasts[0]).ToString();
                                fangxin += "<li class=\"wid50\">早餐：" + bf + "</li>";
                            }

                            fangxin += "<li class=\"wid50 right_txt\">上网：" + (EyouSoft.Model.Enum.IsInternet)roomTypeInfo.IsInternet + "</li>";
                            string RoomRateIdslist = "";
                            for (int m = 0; m < item.Value.RoomRateIds.Count; m++)
                            {
                                RoomRateIdslist += item.Value.RoomRateIds[m] + ",";
                            }
                            RoomRateIdslist = RoomRateIdslist.TrimEnd(',');
                            string jiage = BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, MemberTypes.普通会员, item.Value.FeeSetting, FeeTypes.酒店).ToString("0");
                            string TypeName = "优惠价";
                            Model.SSOStructure.MUserInfo userInfo = null;
                            Security.Membership.UserProvider.IsLogin(out userInfo);
                            if (userInfo != null)
                            {
                                jiage = BHotel2.CalculateFee(min_settlementprice, min_preferentialprice, userInfo.UserType, item.Value.FeeSetting, FeeTypes.酒店).ToString("0");
                                if (userInfo.UserType == MemberTypes.代理)
                                {
                                    TypeName = "代理价";
                                }
                                else if (userInfo.UserType == MemberTypes.贵宾会员)
                                {
                                    TypeName = "贵宾价";
                                }
                                else if (userInfo.UserType == MemberTypes.免费代理)
                                {
                                    TypeName = "代销价";
                                }
                                else if (userInfo.UserType == MemberTypes.员工)
                                {
                                    TypeName = "员工价";
                                }
                            }
                            fangxin += "<li class=\"font13 mt10\"><a href=\"javascript:void(0);\" data-roomTypeId=\"" + roomTypeInfo.RoomTypeId + "\" data-RoomRateIds=\"" + RoomIdLists.Trim().TrimEnd(',') + "\" class=\"yudin_btn\">预订</a><i class=\"line_x font_gray\">销售价:¥" + (min_preferentialprice * BHotel2.RetialPricePercent).ToString("0") + "元</i>　" + TypeName + "：<span class=\"font_yellow\">¥<i class=\"font18\">" + jiage + "</i></span>元</li>";
                            fangxin += "</ul></div></div></div>";
                        }

                    }
                }

            }

            //Repeater1.DataSource = rooRateInfo;
            //Repeater1.DataBind();
            getHtmlStr();
        }
        /// <summary>
        /// 获取最近六个月的日期
        /// </summary>
        void getHtmlStr()
        {
            StringBuilder strMonthHtml = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                DateTime dt = DateTime.Now.AddMonths(i);
                if (i == 0)
                {
                    strMonthHtml.Append("<div class=\"riqi_box\">");
                }
                else
                {
                    strMonthHtml.Append("<div class=\"riqi_box mt10\">");
                }
                strMonthHtml.AppendFormat("<div class=\"riqi_month\">{0}</div>", dt.ToString("yyyy年MM月"));
                strMonthHtml.Append("<div class=\"riqi_week\">");
                strMonthHtml.Append("<ul>");
                strMonthHtml.Append("<li>日</li>");
                strMonthHtml.Append("<li>一</li>");
                strMonthHtml.Append("<li>二</li>");
                strMonthHtml.Append("<li>三</li>");
                strMonthHtml.Append("<li>四</li>");
                strMonthHtml.Append("<li>五</li>");
                strMonthHtml.Append("<li>六</li>");
                strMonthHtml.Append("</ul>");
                strMonthHtml.Append("</div>");
                strMonthHtml.Append("<div class=\"riqi_day\">");
                strMonthHtml.Append("<ul class=\"clearfix\">");

                int days = DateTime.DaysInMonth(dt.Year, dt.Month);
                int firstLi = (int)Utils.GetDateTime(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, 1)).DayOfWeek;
                for (int j = 0; j < firstLi; j++)
                {
                    strMonthHtml.Append("<li></li>");//补全空白
                }
                for (int m = 1; m <= days; m++)
                {
                    strMonthHtml.Append(getMonthStr(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, m)));
                }
                strMonthHtml.Append("</ul></div></div>");
            }
            litMonth.Text = strMonthHtml.ToString();
        }
        /// <summary>
        /// 返回表格样式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        string getMonthStr(string dataStr)
        {
            DateTime dt = Utils.GetDateTime(dataStr);
            if (dt < DateTime.Now)
            {
                return string.Format("<li da class=\"riqi_day_pass\" >{0}</li>", dt.Day);
            }
            else
            {
                return string.Format("<li class=\"riqi_day_select\" data-date=\"{1}\" data-week=\"{2}\">{0}</li>", dt.Day, dt.ToString("yyyy-MM-dd"), dt.DayOfWeek);
            }
        }

        public class TempClass
        {
            public List<int> RoomRateIds { get; set; }
            /// <summary>
            /// 套餐名称
            /// </summary>
            public List<string> RoomRateName { get; set; }
            public List<decimal> PreferentialPrice { get; set; }
            public List<decimal> SettlementPrice { get; set; }
            public MFeeSettings FeeSetting { get; set; }
            public List<string> BreakFasts { get; set; }
        }
        protected decimal SearchMin(IList<decimal> arr, out int index)
        {
            if (arr != null && arr.Count > 0)
            {
                index = -1;
                decimal min = decimal.MaxValue;
                for (int i = 0, k = arr.Count; i < k; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                        index = i;
                    }
                }
                return min;
            }
            throw new InvalidOperationException();
        }
    }
}
