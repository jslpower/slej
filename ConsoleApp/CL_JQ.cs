using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using EyouSoft.InterfaceLib;
using EyouSoft.InterfaceLib.Request.MTS;
using EyouSoft.InterfaceLib.Response.MTS;
using EyouSoft.Common;
using System.IO;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.BLL.ScenicStructure;

namespace ConsoleApp
{
    class CL_JQ
    {
        public static string loginname = ConfigurationManager.AppSettings["ZLJRLoginName"];
        public static string password = ConfigurationManager.AppSettings["ZLJRPassword"];
        MTSServiceSeeker jingqu = new MTSServiceSeeker();
        public int AutoTongBuJingQu()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\srlog_jq_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);
            var bll = new EyouSoft.BLL.ScenicStructure.BScenicArea2();
            int c = 0;
           
                var areaBll = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();
                var r = jingqu.SelectResourceListPagecount(request1());
                if (r.Count > 0 && r[0].PageCount > 0)
                {
                    IList<MScenicTickets> list = new List<MScenicTickets>();
                    var requestTicket = new SelectProductListPagecountRequest
                    {
                        loginname = loginname,
                        pwd = password,
                    };
                    SelectProductListPagecountResponse responseTicket = jingqu.SelectProductListPagecount(requestTicket);

                    if (responseTicket[0].PageCount > 0)
                    {
                        for (int pageindex = 1; pageindex <= responseTicket[0].PageCount; pageindex++)
                        {
                            try
                            {
                                SelectProductListRequest request2 = new SelectProductListRequest();
                                request2.loginname = loginname;
                                request2.pwd = password;
                                request2.Page = new EyouSoft.InterfaceLib.Models.MTS.Page { pageIndex = pageindex };
                                SelectProductListResponse response2 = jingqu.SelectProductList(request2);

                                foreach (SelectProductListResponse.item item2 in response2)
                                {
                                    if (item2.RequireDate <= DateTime.Now)
                                        continue;
                                    //var request3 = new ProductDetailRequest();
                                    MScenicTickets model2 = new MScenicTickets();
                                    model2.Description = "<span class=title>产品说明：</span><p>" + item2.Description + "</p><br><span class=title>费用包含：</span><p>" + item2.Services + "</p><br><span class=title>游客提示：</span><p>" + item2.GuestPrompt + "</p><br><span class=title>使用说明：</span><p>" + item2.Help + "</p><br><span class=title>退票说明：</span><p>" + item2.RefundDescription + "</p>";
                                    model2.RetailPrice = (decimal)item2.SalesPrice;
                                    model2.WebsitePrices = (decimal)item2.RetailPrice;
                                    model2.DistributionPrice = (decimal)item2.SettlementPrice;
                                    model2.EndTime = item2.RequireDate;
                                    model2.EnName = item2.Name;
                                    model2.IsFenXiao = true;
                                    model2.IssueTime = DateTime.Now;
                                    model2.LastUpdateTime = DateTime.Now;
                                    model2.Limit = item2.LimitCount;
                                    model2.Number = -999;
                                    model2.OperatorId = "";
                                    model2.SaleDescription = "";
                                    model2.InterafaceScenicId = model2.ScenicId = item2.ResourceId.ToString();
                                    model2.ScenicName = item2.ResourceName;
                                    model2.StartTime = null;
                                    model2.Status = ScenicTicketsStatus.上架;
                                    model2.InterafaceTicketId = item2.Id.ToString();
                                    model2.TypeName = item2.Type.ToString();                                     
                                    list.Add(model2);
                                    Console.WriteLine(model2.InterafaceTicketId);
                                }
                            }

                            catch (Exception e)
                            {
                                System.IO.StreamWriter swe = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\" + DateTime.Now.ToFileTime().ToString() + ".log");
                                swe.WriteLine(e.Message);
                                swe.WriteLine(e.Source);
                                swe.WriteLine(e.StackTrace);
                                swe.Close();
                            }
                        }
                    }
                    for (var i = 1; i <= r[0].PageCount; i++)
                    {
                        try
                        {
                            var x = jingqu.SelectResourceList(request0(i));
                            foreach (var id in x)
                            {
                                var request = new ResourceDetailRequest();
                                request.loginname = loginname;
                                request.pwd = password;
                                request.id = Utils.GetInt(((EyouSoft.InterfaceLib.Response.MTS.SelectResourceListResponse.item)id).Id.ToString());
                                ResourceDetailResponse response = jingqu.ResourceDetail(request);
                                ResourceDetailResponse.item item = response[0];
                                int? provinceId = areaBll.GetProvinceIdByName(item.Province);
                                int? cityId = areaBll.GetCityIdByName(item.City);

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
                                model.OperatorId = "";
                                model.OperatorName = "";
                                model.ProvinceId = provinceId.HasValue ? provinceId.Value : -999;
                                model.ProvinceName = item.Province;
                                model.ScenicLevel = (ScenicLevel)item.Grade;
                                model.ScenicName = item.sightname;
                                //model.ScenicId = Guid.NewGuid().ToString();
                                model.Traffic = "公交线路：<br>" + item.BusLine + "<br>自驾车线路：<br>" + item.DriveLine;
                                model.X = item.MapX;
                                model.Y = item.Mapy;
                                model.Year = -999;
                                model.ChanPinSource = (int)ChanPinSources.外站1;
                                model.InterfaceID = item.Id.ToString();
                                model.ImgList = new List<MScenicAreaImg>();
                                foreach (ResourceDetailResponse.item.Images item2 in item.Imageslist)
                                {
                                    MScenicAreaImg image = new MScenicAreaImg();
                                    //image.Address = "/Images/JingQu_Interface/" + Path.GetFileName(item2.ImageUrl);
                                    image.Address = item2.ImageUrl;
                                    image.Description = item2.Title;
                                    image.ImgId = Guid.NewGuid().ToString();
                                    image.ImgType = ScenicImgType.景区形象;
                                    image.OperatorId = "";
                                    image.ScenicId = model.ScenicId;
                                    model.ImgList.Add(image);
                                    //if (Uri.IsWellFormedUriString(image.Address, UriKind.RelativeOrAbsolute))
                                    //{
                                    //   byte[] data = webClient.DownloadData(new Uri(item2.ImageUrl));
                                    //   File.WriteAllBytes(Server.MapPath("~" + image.Address), data);

                                    //   //Page.AddOnPreRenderCompleteAsync(new BeginEventHandler(Start), new EndEventHandler(End), new string[] { item2.ImageUrl, Server.MapPath("~/" + image.Address) });
                                    //}
                                }

                                bll.AddScenicAreasFromInterface(new List<MScenicArea>{model});

                                var tickets = list.Where(m => m.ScenicId == item.Id.ToString()).ToList();

                                if (bll.AddTicketsFromInterface(tickets))
                                {
                                    Console.WriteLine(model.ScenicName);
                                    Console.WriteLine(model.ScenicId);


                                    sw.WriteLine(model.ScenicName);
                                    sw.WriteLine(model.ScenicId);
                                    c += 1;
                                }
                                //if (bll.AddTicket(model, tickets))
                                //{
                                //    Console.WriteLine(model.ScenicName);
                                //    Console.WriteLine(model.ScenicId);


                                //    sw.WriteLine(model.ScenicName);
                                //    sw.WriteLine(model.ScenicId);
                                //    c += 1;
                                //}
                            }
                        }
                        catch (Exception e)
                        {
                            System.IO.StreamWriter swe = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\" + DateTime.Now.ToFileTime().ToString() + ".log");
                            swe.WriteLine(e.Message);
                            swe.WriteLine(e.Source);
                            swe.WriteLine(e.StackTrace);
                            swe.Close();
                        }
                    }
                }
                sw.Close();
            return c;
        }

        SelectResourceListRequest request0(int PageIndex)
        {
            return new SelectResourceListRequest()
            {
                loginname = loginname,
                pwd = password,
                Page = new EyouSoft.InterfaceLib.Models.MTS.Page { pageIndex = PageIndex }
            };
        }

        SelectResourceListPagecountRequest request1()
        {
            return new SelectResourceListPagecountRequest()
            {
                loginname = loginname,
                pwd = password,
            };
        }
    }
}
