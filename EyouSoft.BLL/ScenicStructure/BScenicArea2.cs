using System;
using System.Collections.Generic;
using System.Linq;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.DAL.SystemStructure;
using EyouSoft.Model.SystemStructure;
using Linq.Expressions;
using EyouSoft.DAL.ScenicStructure;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.SystemStructure;
using EyouSoft.IDAL.ScenicStructure;
using EyouSoft.Toolkit.BLL;
using Linq.Expressions.Extensions;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.InterfaceLib;
using EyouSoft.InterfaceLib.Request.MTS;
using System.Configuration;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum.ScenicStructure;
using Linq.Bussiness;
using Linq.Web;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.DAL.AccountStructure;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.BLL.HotelStructure;
using System.Web;
using Linq.Common;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.ScenicStructure
{
    public class BScenicArea2 : BLLBase
    {
        IDScenicArea dalArea = new DScenicArea2();
        IDScenicTickets2 dalTicket = new DScenicTickets2();
        IDScenicAreaOrder dalOrder = new DScenicAreaOrder();
        IDScenicAreaImg dalImg = new DScenicAreaImg();
        BFeeSettings bllFeeSetting = new BFeeSettings();
        IDSysCity dalCity = new DSysCity();
        IDSysProvince dalProvince = new DSysProvince();
        ISellers dalSeller = new DSellers();
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public IList<MScenicAndOrder> GetScenicAreaOrderList(MScenicAreaOrderSearchModel searchModel)
        {
            QueryExpressionBuilder<MScenicAreaOrder> query = new QueryExpressionBuilder<MScenicAreaOrder>();
            if (!string.IsNullOrEmpty(searchModel.ScenicName))
            {
                query.LeftOuterJoin<MScenicArea>().On((x, y) => x.ScenicId == y.ScenicId)
                     .Where((x, y) => y.ScenicName.IndexOf(searchModel.ScenicName) > -1).SelectAll();
            }
            else
            {
                query.LeftOuterJoin<MScenicArea>().On((x, y) => x.ScenicId == y.ScenicId).SelectAll().SelectAs(x => x.IssueTime, "Ordertime");
            }
            query.OrderBy(x => x.IssueTime);
            query.SearchInfo = searchModel.SearchInfo;
            //用户Id：
            if (!string.IsNullOrEmpty(searchModel.UserId))
            {
                query.Where(x => x.OperatorId == searchModel.UserId);
            }
            //开始时间
            if (searchModel.BeginTime.HasValue && searchModel.BeginTime > Convert.ToDateTime("1900-01-01"))
            {
                query.Where(x => x.IssueTime >= searchModel.BeginTime);
            }
            //结束时间
            if (searchModel.EndTime.HasValue && searchModel.EndTime > Convert.ToDateTime("1900-01-01"))
            {
                query.Where(x => x.IssueTime <= searchModel.EndTime);
            }
            return dalOrder.SelectPagedList<MScenicAndOrder>(query);
        }

        public IList<MScenicAndOrder> GetScenicAreaOrderDetail(MScenicAreaOrderSearchModel searchModel)
        {
            QueryExpressionBuilder<MScenicAreaOrder> query = new QueryExpressionBuilder<MScenicAreaOrder>();
            query.LeftOuterJoin<MScenicArea>().On((x, y) => x.ScenicId == y.ScenicId).SelectAll().SelectAs(x => x.IssueTime, "Ordertime");
            //用户Id：
            if (!string.IsNullOrEmpty(searchModel.UserId))
            {
                query.Where(x => x.OperatorId == searchModel.UserId);
            }
            //订单Id：
            if (!string.IsNullOrEmpty(searchModel.OrderId))
            {
                query.Where(x => x.OrderId == searchModel.OrderId);
            }
            return dalOrder.Select<MScenicAndOrder>(query);
        }

        /// <summary>
        /// 获取景点门票
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public MScenicAreaWebSearchModel GetScenicTicketsInfo(string scenicId)
        {

            if (string.IsNullOrEmpty(scenicId))
            {
                return null;
            }
            QueryExpressionBuilder<MScenicTickets> query1 = new QueryExpressionBuilder<MScenicTickets>();
            var query3 = query1.Select((y) => new { y.WebsitePrices, y.DistributionPrice, y.EnName, y.RetailPrice, y.TicketsId, y.EndTime, y.TypeName, y.Description })
                .Where((y) => y.EndTime >= DateTime.Now && y.ScenicId == scenicId && y.Status == ScenicTicketsStatus.上架);

            query1.OrderByDescending(x => x.IssueTime);
            query1.Select(x => new { x });

            var ticketList = dalTicket.Select<MScenicTicketsWebBindModel>(query1);

            if (ticketList.Count == 0)
            {
                return null;
            }
            else
            {
                MScenicAreaWebSearchModel area = dalArea.Get<MScenicAreaWebSearchModel>(scenicId);
                area.TicketInfo = ticketList;

                MFeeSettings feeSetting = new DFeeSettings().Get(x => x.LeiBie == FeeTypes.门票);

                if (feeSetting == null)
                {
                    throw new NullReferenceException("费用提价信息不能为空");
                }
                if (area.TicketInfo != null)
                {
                    foreach (var item in area.TicketInfo)
                    {
                        item.FeeSetting = feeSetting;
                    }
                }

                QueryExpressionBuilder<MScenicAreaImg> imgQuery = new QueryExpressionBuilder<MScenicAreaImg>();
                imgQuery.Where(x => x.ScenicId == scenicId);
                imgQuery.SearchInfo = new SearchModel { PageInfo = new PageInfo { PageSize = 3, PageIndex = 1 } };
                imgQuery.OrderBy(x => x.ImgId);
                IList<MScenicAreaImg> ImageList = dalImg.SelectPagedList<MScenicAreaImg>(imgQuery);

                area.ImgList = ImageList.ToList();
                return area;
            }
        }

        /// <summary>
        /// 获取景区信息（包含门票，图片） (此方法因为内联了表，比较慢，待改进,建议嵌套子查询)
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="getAllTickets"></param>
        /// <returns></returns>
        public IList<MScenicAreaWebSearchModel> GetScenicList(MScenicAreaWebSearchModel searchModel)
        {
            string sql = @"select rrrrrrraaaaaa from tbl_ScenicArea as aa where 1=1 and (select count(DistributionPrice) from tbl_ScenicTickets where scenicId=aa.scenicId and DistributionPrice>0 and EndTime>=getdate() and Status=1)>0 and (select count(Address) from tbl_ScenicAreaImg where scenicid=aa.scenicid and address is not null and address!='')>0";

            //说明：如果传入了景区名，就不限制城市了。
            //如果传入了城市名，就不限制只搜索 杭州的了。
            if (string.IsNullOrEmpty(searchModel.ScenicName) &&
                  string.IsNullOrEmpty(searchModel.JingQuName) &&
                  string.IsNullOrEmpty(searchModel.Keyword) &&
                  !searchModel.ProvinceId.HasValue && !searchModel.ProvinceId2.HasValue
                  && !searchModel.CityId.HasValue && !searchModel.CityId2.HasValue)
            {
                if (string.IsNullOrEmpty(searchModel.CityName))
                {
                    sql += " and aa.ProvinceId=11";
                }
            }

            if (!string.IsNullOrEmpty(searchModel.ScenicId))
            {
                sql += " and aa.ScenicId='" + searchModel.ScenicId + "'";
            }
            int? provinceId = null;
            if (searchModel.ProvinceId.HasValue)
            {
                provinceId = searchModel.ProvinceId.Value;
            }
            if (searchModel.ProvinceId2.HasValue)
            {
                provinceId = searchModel.ProvinceId2.Value;
            }
            if (provinceId.HasValue)
            {
                sql += " and aa.ProvinceId=" + provinceId;
            }
            int? cityId = null;
            if (searchModel.CityId.HasValue)
            {
                cityId = searchModel.CityId.Value;
            }
            if (searchModel.CityId2.HasValue)
            {
                cityId = searchModel.CityId2.Value;
            }
            if (cityId.HasValue)
            {
                sql += " and aa.CityId=" + cityId;
            }
            string scenicName = null;
            if (!string.IsNullOrEmpty(searchModel.ScenicName))
            {
                scenicName = searchModel.ScenicName;
            }
            if (!string.IsNullOrEmpty(searchModel.JingQuName))
            {
                scenicName = searchModel.JingQuName;
            }

            if (!string.IsNullOrEmpty(searchModel.Keyword))
            {
                scenicName = searchModel.Keyword;
            }
            if (!string.IsNullOrEmpty(scenicName))
            {
                sql += " and aa.ScenicName like '%" + scenicName + "%'";
            }
            if (searchModel.IsIndex != null && searchModel.IsIndex.Length > 0)
            {
                sql += " AND aa.IsIndex IN(" + Utils.GetSqlIn(searchModel.IsIndex) + ") ";
            }
            IList<MScenicAreaWebSearchModel> areas;
            using (var timer = new timerRecorder("timer1"))
            {
                string countsql = sql.Replace("rrrrrrraaaaaa", "count(1)");
                string infosql = sql.Replace("rrrrrrraaaaaa", " aa.ScenicId,aa.ScenicName,ScenicLevel,(select top 1 cast(bb.TicketsId as varchar)+','+cast(bb.RetailPrice as varchar)+','+ cast(bb.WebsitePrices as varchar)+','+cast(bb.DistributionPrice as varchar) from tbl_ScenicTickets as bb where bb.scenicId=aa.scenicId and DistributionPrice=(select min(DistributionPrice) from tbl_ScenicTickets as cc where cc.scenicId=bb.scenicId and (cc.EndTime is not null and cc.EndTime>=getdate()) and cc.Status=1 and DistributionPrice>0)) as bindtxtinfo,(select top 1 Address from tbl_ScenicAreaImg where ScenicId=aa.ScenicId and Address!='' and Address is not null) as Address, row_number() over(order by aa.IssueTime desc) as RowNumber ");
                string pagesql = "declare @count int;set @count=(" + countsql + ");select @count as RowTotalCount;select * from (" + infosql + ") rr where rr.RowNumber between " + ((searchModel.SearchInfo.PageInfo.PageIndex - 1) * searchModel.SearchInfo.PageInfo.PageSize + 1) + " and " + (searchModel.SearchInfo.PageInfo.PageIndex) * searchModel.SearchInfo.PageInfo.PageSize;
                areas = dalArea.SelectPagedList<MScenicAreaWebSearchModel>(pagesql, searchModel.SearchInfo.PageInfo);
                if (areas.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < areas.Count; i++)
                {
                    string s = areas[i].bindtxtinfo;
                    if (!string.IsNullOrEmpty(s))
                    {
                        areas[i].TicketFirst = new MScenicTicketsWebBindModel
                        {
                            TicketsId = s.Split(',')[0],
                            RetailPrice = decimal.Parse(s.Split(',')[1]),
                            WebsitePrices = decimal.Parse(s.Split(',')[2]),
                            DistributionPrice = decimal.Parse(s.Split(',')[3])
                        };
                    }
                }
                //HttpContext.Current.Response.Write("<br/>1:" + timer.getTime());
            }
            using (var timer2 = new timerRecorder("timer2"))
            {
                MFeeSettings fees = new DFeeSettings().Get(x => x.LeiBie == FeeTypes.门票);

                if (fees == null)
                {
                    throw new NullReferenceException("费用提价信息不能为空");
                }

                List<MScenicAreaWebSearchModel> result = new List<MScenicAreaWebSearchModel>();

                //填充门票和图片信息
                foreach (MScenicAreaWebSearchModel area in areas)
                {
                    area.TicketFirst.FeeSetting = fees;
                    result.Add(area);
                }
                //HttpContext.Current.Response.Write("<br/>2:" + timer2.getTime());
                return result;
            }
        }

        /// <summary>
        /// 根据景区id获取同省的其他城市
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public IList<MSysCity> GetProvinceCity(string scenicId)
        {
            MScenicArea areaInfo = dalArea.Get(x => x.ProvinceId, x => x.ScenicId == scenicId);
            if (areaInfo == null)
            {
                return null;
            }
            QueryExpressionBuilder<MSysCity> cityQuery = new QueryExpressionBuilder<MSysCity>();
            cityQuery.Where(x => x.ProvinceId == areaInfo.ProvinceId);
            return dalCity.Select(cityQuery);
        }

        /// <summary>
        /// 添加景区的门票（接口）
        /// </summary>
        public bool AddTicketsFromInterface(IList<MScenicTickets> tickets)
        {
            for (int i = 0; i < tickets.Count; i++)
            {
                MScenicTickets item = tickets[i];

                var scenicArea = dalArea.Get(x => x.InterfaceID == item.InterafaceScenicId);
                if (scenicArea != null)
                {

                    item.ScenicId = scenicArea.ScenicId;

                    MScenicTickets existsTicket = dalTicket.Get(x => x.InterafaceTicketId == item.InterafaceTicketId && x.ScenicId == item.ScenicId);

                    if (existsTicket != null)
                    {
                        item.TicketsId = existsTicket.TicketsId;
                        if (dalTicket.Update(item) != 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        item.TicketsId = Guid.NewGuid().ToString();
                        if (dalTicket.Insert(item) != 1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    RecordError("景区接口id为" + item.InterafaceScenicId + "的景区信息未找到");
                }
            }
            return true;
        }

        /// <summary>
        /// 添加景区（接口）
        /// </summary>
        public bool AddScenicAreasFromInterface(List<MScenicArea> list)
        {
            foreach (var item in list)
            {
                MScenicArea existsArea = dalArea.Get(x => x.ScenicName == item.ScenicName);
                if (existsArea != null)
                {
                    item.ScenicId = existsArea.ScenicId;
                    if (dalArea.Update(item) != 1)
                    {
                        return false;
                    }
                }
                else
                {

                    item.ScenicId = Guid.NewGuid().ToString();
                    if (dalArea.Insert(item) != 1)
                    {
                        return false;
                    }
                }
                for (int img = 0; img < item.ImgList.Count; img++)
                {
                    item.ImgList[img].ScenicId = item.ScenicId;
                    item.ImgList[img].IssueTime = DateTime.Now;
                    AddImg(item.ImgList[img]);
                }
            }
            return true;
        }

        public MScenicTickets GetTicketInfo(string ticketId)
        {
            return dalTicket.Get(ticketId);
        }

        public MScenicArea GetScenicAreaInfo(string scenicId)
        {
            return dalArea.Get(scenicId);
        }

        /// <summary>
        /// 提交景区订单
        /// </summary>
        public bool SubmitOrder(MScenicAreaTicketsOrderWebBindModel model, MemberTypes memberType, out string msg)
        {
            if (model == null || string.IsNullOrEmpty(model.TicketsId))
            {
                msg = "数据异常";
                return false;
            }
            if (model.Num <= 0 || model.ChuFaRiQi < DateTime.Now.Date)
            {
                msg = "非法操作";
                return false;
            }
            // using (dalOrder.BeginTransaction())
            // {
            try
            {
                MScenicTickets ticketInfo = dalTicket.Get(model.TicketsId);
                MScenicArea areaInfo = dalArea.Get(ticketInfo.ScenicId);
                MScenicAreaTicketsOrderWebBindModel orderForSubmit = new MScenicAreaTicketsOrderWebBindModel();
                model.OrderId = Guid.NewGuid().ToString();
                //    if (!string.IsNullOrEmpty(areaInfo.InterfaceID))
                //    {
                //        MTSServiceSeeker mts = new MTSServiceSeeker();
                //        SubmitOrderRequest request = new SubmitOrderRequest
                //        {
                //            loginname = ConfigurationManager.AppSettings["ZLJRLoginName"],
                //            pwd = ConfigurationManager.AppSettings["ZLJRPassword"],
                //            arglist = new SubmitOrderRequestArgumentList
                //            {
                //                amount = model.Num,
                //                bz = model.Remark,
                //                date = model.ChuFaRiQi,
                //                mobile = model.ContactTel,
                //                name_linkman = model.OperatorName,
                //                orderid = model.OrderId,
                //                phone_linkman = model.OperatorMobile,
                //                username = model.ContactName,
                //                productid = int.Parse(ticketInfo.InterafaceTicketId),
                //            },
                //        };
                //        int orderId = mts.SubmitOrder(request);
                //        if (orderId > 0)
                //        {
                //            orderForSubmit.ApiOrderId = orderId.ToString();
                //            goto A;
                //        }
                //        else
                //        {
                //            msg = "数据异常";
                //            return false;
                //        }
                //    }
                //    else
                //    {
                //        if (model.Num > ticketInfo.Number)
                //        {
                //            msg = "订购数量不能超过" + ticketInfo.Number + "";
                //            return false;
                //        }
                //    }
                //A:
                long count = dalOrder.Count();
                orderForSubmit.BuyCompanyName = "";
                orderForSubmit.ChuFaRiQi = model.ChuFaRiQi;
                orderForSubmit.ContactName = model.ContactName;
                orderForSubmit.ContactTel = model.ContactTel;
                orderForSubmit.FuKuanStatus = FuKuanStatus.未付款;
                orderForSubmit.IssueTime = DateTime.Now;
                orderForSubmit.Num = model.Num;
                orderForSubmit.OperatorId = model.OperatorId;
                orderForSubmit.OperatorMobile = model.OperatorMobile;
                orderForSubmit.OperatorName = model.OperatorName;
                orderForSubmit.OrderCode = "MP" + DateTime.Now.ToString("yyyyMMdd") + count.ToString().PadLeft(4, '0');
                orderForSubmit.OrderId = model.OrderId;
                orderForSubmit.Price = model.Price;
                orderForSubmit.Remark = model.Remark;
                orderForSubmit.ScenicId = areaInfo.ScenicId;
                orderForSubmit.ScenicName = areaInfo.ScenicName;
                orderForSubmit.Status = OrderStatus.待付款;
                orderForSubmit.TicketsId = ticketInfo.TicketsId;
                orderForSubmit.TypeName = ticketInfo.TypeName;
                orderForSubmit.OrderSite = model.OrderSite;

                string url = HttpContext.Current.Request.Url.Host;
                if (url.IndexOf("m.") > -1)
                {
                    url = url.Replace("m.", "");
                }
                bool hasPower = new BSellers().JudgeAuthor(url, FeeTypes.门票);
                if (hasPower)
                {
                    BSellers bsells = new BSellers();
                    EyouSoft.Model.AccountStructure.MSellers currentSellerInfo = new EyouSoft.Model.AccountStructure.MSellers();
                    currentSellerInfo = bsells.GetMSellersByWebSite(url);
                    if (currentSellerInfo != null)
                    {
                        orderForSubmit.SellerID = currentSellerInfo.ID;
                    }

                    //分销金额
                    if (!string.IsNullOrEmpty(orderForSubmit.SellerID))
                    {
                        MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.门票);
                        model.FeeSetting = feeSettings;
                        if (currentSellerInfo != null)
                        {
                            bool flag = false;
                            if (currentSellerInfo.DengJi == MemberTypes.代理)
                            {
                                if (memberType == MemberTypes.员工 || memberType == MemberTypes.代理)
                                {
                                    orderForSubmit.AgencyJinE = model.Num * BHotel2.CalculateFee(ticketInfo.DistributionPrice, ticketInfo.WebsitePrices, MemberTypes.代理, model.FeeSetting, FeeTypes.门票);
                                    flag = true;
                                }
                            }
                            else if (currentSellerInfo.DengJi == MemberTypes.免费代理)
                            {
                                if (memberType == MemberTypes.员工 || memberType == MemberTypes.代理 || memberType == MemberTypes.免费代理)
                                {
                                    orderForSubmit.AgencyJinE = model.Num * BHotel2.CalculateFee(ticketInfo.DistributionPrice, ticketInfo.WebsitePrices, MemberTypes.免费代理, model.FeeSetting, FeeTypes.门票);
                                    flag = true;
                                }
                            }
                            if (flag == false)
                            {
                                MFeeSettings fee = bllFeeSetting.GetByType(FeeTypes.门票);
                                if (currentSellerInfo.DengJi == MemberTypes.代理 || currentSellerInfo.DengJi == MemberTypes.免费代理)
                                {
                                    orderForSubmit.AgencyJinE = model.Num * BHotel2.CalculateFee(ticketInfo.DistributionPrice, ticketInfo.WebsitePrices, currentSellerInfo.DengJi, model.FeeSetting, FeeTypes.门票);
                                }
                            }
                        }
                    }
                    else
                    {
                        orderForSubmit.AgencyJinE = model.TicketInfo.DistributionPrice * model.Num;
                    }
                }
                else
                {
                    orderForSubmit.AgencyJinE = orderForSubmit.Price;
                }

                if (string.IsNullOrEmpty(areaInfo.InterfaceID))
                {
                    orderForSubmit.Source = ScenicAreaOrderSource.网站;
                }
                else
                {
                    orderForSubmit.Source = ScenicAreaOrderSource.来自接口;
                }
                if (dalOrder.Insert(orderForSubmit) != 1)
                {

                    msg = "数据异常";
                    return false;
                }
                //  dalOrder.Complete();
                msg = "订单成功提交";

                BDuanXin b = new BDuanXin();
                if (b.FaSongDingDanDuanXin(orderForSubmit.OrderId, DingDanLeiBie.门票订单, DuanXinFaSongLeiXing.确认) != 10000)
                {
                    RecordError("短信发送成功。订单号" + orderForSubmit.OrderId);
                }

                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = orderForSubmit.OrderId;
                flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.门票订单;
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = orderForSubmit.OperatorId;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);

                //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                jianglibi.DingDanId = orderForSubmit.OrderId;
                jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.门票订单;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);



                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
#if DEBUG
                throw ex;
#endif
                RecordError(ex);
                return false;
            }
            //}

            return true;
        }

        public bool SubmitTicketsInterface(string OrderID)
        {
            MScenicAreaOrder model = new MScenicAreaOrder();
            model = dalOrder.Get(x => x.OrderId == OrderID);
            
            MScenicTickets ticketInfo = dalTicket.Get(model.TicketsId);
            MScenicArea areaInfo = dalArea.Get(ticketInfo.ScenicId);
            if (!string.IsNullOrEmpty(areaInfo.InterfaceID))
            {
                MTSServiceSeeker mts = new MTSServiceSeeker();
                SubmitOrderRequest request = new SubmitOrderRequest
                {
                    loginname = ConfigurationManager.AppSettings["ZLJRLoginName"],
                    pwd = ConfigurationManager.AppSettings["ZLJRPassword"],
                    arglist = new SubmitOrderRequestArgumentList
                    {
                        amount = model.Num,
                        bz = model.Remark,
                        date = model.ChuFaRiQi,
                        mobile = model.ContactTel,
                        name_linkman = model.OperatorName,
                        orderid = model.OrderId,
                        phone_linkman = model.OperatorMobile,
                        username = model.ContactName,
                        productid = int.Parse(ticketInfo.InterafaceTicketId),
                    },
                };
                int orderId = mts.SubmitOrder(request);
                if (orderId > 0)
                {
                    model.ApiOrderId = orderId.ToString();
                    dalOrder.Update(model);
                    return true;
                }
                else
                {
                  
                    return false;
                }
            }
            else
            {
                if (model.Num > ticketInfo.Number)
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool UpdateScenicArea(MScenicArea model)
        {
            return dalArea.Update(model) == 1;
        }

        /// <summary>
        /// 添加景区图片
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public bool? AddImg(MScenicAreaImg image)
        {
            return dalImg.Insert(image) == 1;
        }
    }
}
