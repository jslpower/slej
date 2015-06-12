using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Common.Page;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Toolkit;
using Utils = EyouSoft.Common.Utils;
using System.Net;
using System.IO;
using System.Threading;
using System.Configuration;
using EyouSoft.Model.Enum;
using Common.page;
using EyouSoft.InterfaceLib;
using EyouSoft.InterfaceLib.Request.MTS;
using EyouSoft.InterfaceLib.Response.MTS;
namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
   [Power(EyouSoft.Model.Enum.Privs.Menu1.景区门票管理, EyouSoft.Model.Enum.Privs.Menu2.景区门票管理_景区管理)]
   public partial class InterfaceDataList : WebmasterPageBase
   {
      public static string loginname = ConfigurationManager.AppSettings["ZLJRLoginName"];
      public static string password = ConfigurationManager.AppSettings["ZLJRPassword"];
      MTSServiceSeeker jingqu = new MTSServiceSeeker();
      BScenicArea2 bll = new EyouSoft.BLL.ScenicStructure.BScenicArea2();
      EyouSoft.BLL.OtherStructure.BSysAreaInfo areaBll = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();

      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request["submit"] == "1")
         {
            if (!Directory.Exists(Server.MapPath("~/JingQu_Interface")))
            {
               Directory.CreateDirectory(Server.MapPath("~/JingQu_Interface"));
            }
            try
            {
               MTSServiceSeeker seeker = new MTSServiceSeeker();

               if (Request["UpdateJQ"].ToUpper() == "TRUE")
               {
                  var request = new SelectResourceListPagecountRequest();
                  request.loginname = loginname;
                  request.pwd = password;
                  SelectResourceListPagecountResponse r1 = jingqu.SelectResourceListPagecount(request);
                  List<MScenicArea> lists = new List<MScenicArea>();

                  if (r1.Count == 0 || r1[0].PageCount == 0)
                  {
                     RCWE(UtilsCommons.AjaxReturnJson("-1", "无景区数据"));
                  }
                  for (int pi = 1; pi <= r1[0].PageCount; pi++)
                  {
                     SelectResourceListRequest r = new SelectResourceListRequest();
                     r.loginname = loginname;
                     r.pwd = password;
                     r.Page = new EyouSoft.InterfaceLib.Models.MTS.Page { pageIndex = pi };
                     SelectResourceListResponse r2 = jingqu.SelectResourceList(r);

                     for (int pi2 = 0; pi2 < r2.Count; pi2++)
                     {
                        var request2 = new ResourceDetailRequest();
                        request2.loginname = loginname;
                        request2.pwd = password;
                        request2.id = r2[pi2].Id; //景区id
                        ResourceDetailResponse.item item = jingqu.ResourceDetail(request2)[0]; //获取景区详情
                        int? provinceId = areaBll.GetProvinceIdByName(item.Province);
                        int? cityId = areaBll.GetCityIdByName(item.City);

                        if (!provinceId.HasValue || !cityId.HasValue)
                        {
                           string content = ("\r\n没有找到相关省市数据，：provinceName:" + item.Province + (", cityName:" + item.City));
                           File.AppendAllText(Server.MapPath("~/JingQu_Interface/error.log"), content);
                        }
                        EyouSoft.Model.ScenicStructure.MScenicArea model = new EyouSoft.Model.ScenicStructure.MScenicArea();
                        model.CityId = cityId.HasValue ? cityId.Value : -999;
                        model.CityName = item.City;
                        model.CnAddress = item.Address;
                        model.Contact = "";
                        model.ContactFax = "";
                        model.ContactMobile = item.Tel;
                        model.ServiceTel = item.Tel;
                        model.ContactTel = item.Tel;
                        model.CountyId = -999;
                        model.Description = item.Description;
                        model.EnName = "";
                        model.Facilities = "";
                        model.IsRecommend = true;
                        model.IssueTime = Utils.GetDateTime(item.UpdateTime);
                        model.Notes = item.Notice;
                        model.OpenTime = item.OpenTime;
                        model.OperatorId = UserInfo.UserId.ToString();
                        model.OperatorName = UserInfo.Username;
                        model.ProvinceId = provinceId.HasValue ? provinceId.Value : -999;
                        model.ProvinceName = item.Province;
                        model.ScenicLevel = (ScenicLevel)item.Grade.ToInt();
                        model.ScenicName = item.sightname;
                        model.ScenicId = Guid.NewGuid().ToString();
                        model.Traffic = "公交线路：" + item.BusLine + "，自驾车线路：" + item.DriveLine;
                        model.X = item.MapX;
                        model.Y = item.Mapy;
                        model.Year = -999;
                        model.ChanPinSource = ChanPinSources.外站1.ToInt();
                        model.InterfaceID = item.Id.ToString();
                        model.ImgList = new List<MScenicAreaImg>();
                        foreach (ResourceDetailResponse.item.Images item2 in item.Imageslist)
                        {
                           MScenicAreaImg image = new MScenicAreaImg();
                           image.Address = item2.ImageUrl;
                           image.Description = item2.Title;
                           image.ImgId = Guid.NewGuid().ToString();
                           image.ImgType = ScenicImgType.景区形象;
                           image.OperatorId = UserInfo.UserId.ToString();
                           image.ScenicId = model.ScenicId;
                           model.ImgList.Add(image);
                        }
                        lists.Add(model);
                     }
                  }
                  if (!bll.AddScenicAreasFromInterface(lists))
                  {
                     RCWE(UtilsCommons.AjaxReturnJson("-1", "发生错误"));
                     return;
                  }
               }

               if (Request["UpdateP"].ToUpper() == "TRUE")
               {
                  IList<MScenicTickets> list = new List<MScenicTickets>();
                  var requestTicket = new SelectProductListPagecountRequest
                  {
                     loginname = InterfaceDataList.loginname,
                     pwd = InterfaceDataList.password,
                  };
                  SelectProductListPagecountResponse responseTicket = jingqu.SelectProductListPagecount(requestTicket);

                  if (responseTicket[0].PageCount > 0)
                  {
                     for (int pageindex = 1; pageindex <= responseTicket[0].PageCount; pageindex++)
                     {
                        SelectProductListRequest request2 = new SelectProductListRequest();
                        request2.loginname = InterfaceDataList.loginname;
                        request2.pwd = InterfaceDataList.password;
                        request2.Page = new EyouSoft.InterfaceLib.Models.MTS.Page { pageIndex = pageindex };
                        SelectProductListResponse response2 = jingqu.SelectProductList(request2);

                        foreach (SelectProductListResponse.item item2 in response2)
                        {
                           var request3 = new ProductDetailRequest();
                           MScenicTickets model2 = new MScenicTickets();
                           model2.Description = item2.Services + "<br>" + item2.GuestPrompt + "<br>" + item2.RefundDescription; ;
                           model2.RetailPrice = (decimal)item2.SalesPrice;
                           model2.WebsitePrices = (decimal)item2.RetailPrice;
                           model2.DistributionPrice = (decimal)item2.SettlementPrice;
                           model2.EndTime = item2.RequireDate;
                           model2.EnName = item2.Name;
                           model2.InterafaceTicketId = item2.Id.ToString();
                           model2.InterafaceScenicId = item2.ResourceId.ToString();
                           model2.IsFenXiao = true;
                           model2.IssueTime = DateTime.Now;
                           model2.LastUpdateTime = DateTime.Now;
                           model2.Limit = item2.LimitCount;
                           model2.Number = -999;
                           model2.OperatorId = UserInfo.UserId.ToString();
                           model2.SaleDescription = string.Empty;
                           //model2.ScenicId = model.ScenicId;
                           model2.ScenicName = item2.ResourceName;
                           model2.StartTime = null;
                           model2.Status = ScenicTicketsStatus.上架;
                           model2.TypeName = item2.Type.ToString();
                           list.Add(model2);
                        }
                     }
                  }
                  if (!bll.AddTicketsFromInterface(list))
                  {
                     RCWE(UtilsCommons.AjaxReturnJson("-1", "发生错误"));
                     return;
                  }
                  RCWE(UtilsCommons.AjaxReturnJson("1", "保存成功"));
               }
            }
            catch (Exception ex)
            {
               File.AppendAllText(Server.MapPath("~/JingQu_Interface/error.log"), ex.ToString());
               RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败，请联系管理员"));
            }
         }
      }
   }
}
