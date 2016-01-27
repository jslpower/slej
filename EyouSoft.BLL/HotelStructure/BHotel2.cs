using System.Collections.Generic;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.DAL.HotelStructure;
using EyouSoft.Model.HotelStructure;
using Linq.Expressions;
using Linq.Expressions.Extensions;
using EyouSoft.IDAL.HotelStructure;
using EyouSoft.Model;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model.SystemStructure;
using System;
using EyouSoft.IDAL.HotelStructure.Interface;
using EyouSoft.Model.HotelStructure.Interface;
using EyouSoft.Model.Enum.ScenicStructure;
using TravelSky.Base.Interface;
using EyouSoft.DAL.AccountStructure;
using EyouSoft.IDAL.AccountStructure;
using System.Linq;
using com.travelsky.hotelbesdk.models.condition;
using com.travelsky.hotelbesdk.models.easyhotel.single;
using System.Collections;
using EyouSoft.BLL.OtherStructure;
using Linq.Common;
using System.Data.Common;
using System.Web;
using EyouSoft.Model.AccountStructure;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.HotelStructure
{
    public class BHotel2 : BLLBase
    {
        IDHotel2 dal = new DHotel2();
        IDHotelImg dalImg = new DHotelImg();
        IDHotelRoomType2 dalRommType = new DHotelRoomType2();
        BFeeSettings bllFeeSetting = new BFeeSettings();
        IDHotelRoomRate dalRoomRate = new DHotelRoomRate();
        IDHotelOrder dalHotelOrder = new DHotelOrder2();
        IDHotelOrderContact dalHotelOrderContact = new DHotelOrderContact();
        IDHotel_HotelAmenity dalAmenity = new DHotel_HotelAmenity();
        IDHotel_HotelTraffic dalTraffice = new DHotel_HotelTraffic();
        IDHotelOrderRoomRateId dalRoomRateId = new DHotelOrderRoomRateId();
        BSellers bsells = new BSellers();

        ISellers dalSeller = new DSellers();
        public IList<MHotelImg> GetHotelImgList()
        {
            QueryExpressionBuilder<MHotelImg> queryImg = new QueryExpressionBuilder<MHotelImg>();
            var query2 = queryImg.InnerJoin<MHotel2>().On((x, y) => x.HotelId == y.HotelId);
            queryImg.Select(x => x.FilePath);
            query2.OrderByDescending((x, y) => x.IssueTime);
            return dalImg.Select(queryImg);
        }

        /// <summary>
        /// 获取酒店（含酒店图片，房价信息）列表
        /// </summary>
        /// <param name="model">查询model</param>
        /// <param name="isPaging">GetHotelList是否用于酒店首页的</param>
        /// <param name="memberType">当前会员的类型</param>
        /// <param name="isInDefaultPage">是否是default.aspx首页的</param>
        /// <returns></returns>
        public IList<MHotelSearchModel1> GetHotelMapList(MHotelSearchModel1 searchModel, bool isPaging, MemberTypes memberType, bool isInDefaultPage)
        {
            MFeeSettings feeSetting = new BFeeSettings().GetByType(FeeTypes.酒店);
            decimal rate = GetRateByMemberType(feeSetting, memberType);
            if (searchModel.JiaGe1.HasValue && searchModel.JiaGe2.HasValue)
            {
                if (searchModel.JiaGe1.Value < 0)
                {
                    searchModel.JiaGe1 = 100;
                }
                if (searchModel.JiaGe2.Value < 0)
                {
                    searchModel.JiaGe2 = searchModel.JiaGe1.Value + 50;
                }
                if (searchModel.JiaGe2.Value < searchModel.JiaGe1.Value)
                {
                    searchModel.JiaGe2 = searchModel.JiaGe1.Value + 50;
                }
            }
            string sql = "select HotelId, RoomRateId, InterfaceID, RoomTypeId, StartDate, EndDate,(SELECT latitude  FROM tbl_hotel AS p WHERE p.hotelid=tbl_hotelroomrate.hotelid ) as latitude,(SELECT longitude  FROM tbl_hotel AS p WHERE p.hotelid=tbl_hotelroomrate.hotelid ) as longitude,(SELECT Address  FROM tbl_hotel AS p WHERE p.hotelid=tbl_hotelroomrate.hotelid ) as Address,(SELECT ServiceTel  FROM tbl_hotel AS p WHERE p.hotelid=tbl_hotelroomrate.hotelid ) as ServiceTel from {0} tbl_hotelroomrate where 1=1";
            sql += " and (Status is null or Status='' or Status='O') and  EndDate>=getdate() ";
            //status='O'


            if (isPaging) //酒店首页
            {
                if (string.IsNullOrEmpty(searchModel.CityCode))
                {
                    searchModel.CityCode = "HGH";
                }
            }
            if (!string.IsNullOrEmpty(searchModel.CityName))
            {
                BHotelCity c = new BHotelCity();
                object cc = dal.ExecuteSqlScalar(string.Format("select CityCode from tbl_HotelCity where CityName='{0}'", searchModel.CityName));
                if (cc != null && cc.ToString() != "")
                {
                    searchModel.CityCode = cc.ToString();
                }
            }
            if (!string.IsNullOrEmpty(searchModel.SanZiMa))
            {
                searchModel.CityCode = searchModel.SanZiMa;
            }

            //列表查询优化，先查出该城市下的价格计划做为数据源，非列表查询则直接查询价格计划表
            if (!string.IsNullOrEmpty(searchModel.CityCode))
            {
                string ts = string.Format("(select HotelId, RoomRateId, InterfaceID, RoomTypeId, StartDate, EndDate,Status,settlementprice,PreferentialPrice from tbl_hotelroomrate where citycode='{0}')", searchModel.CityCode);
                sql = string.Format(sql, ts);

            }
            else
            {
                sql = string.Format(sql, "");
            }

            if (!string.IsNullOrEmpty(searchModel.HotelId))
            {
                sql += string.Format(" and hotelid='{0}'", searchModel.HotelId);
            }
            if (searchModel.JiaGe1.HasValue)
            {
                sql += string.Format(" and settlementprice+((PreferentialPrice*{0}-settlementprice)-settlementprice)*{1}>={0}", BHotel2.RetialPricePercent, rate, searchModel.JiaGe1.Value);
            }
            if (searchModel.JiaGe2.HasValue)
            {
                sql += string.Format(" and settlementprice+((PreferentialPrice*{0}-settlementprice)-settlementprice)*{1}<={2}", BHotel2.RetialPricePercent, rate, searchModel.JiaGe2.Value);
            }
            if (!string.IsNullOrEmpty(searchModel.RoomTypeId))
            {
                sql += string.Format(" and roomtypeid='{0}'", searchModel.RoomTypeId);
            }
            if (!string.IsNullOrEmpty(searchModel.RoomTypeId_Except))
            {
                string[] arr = searchModel.RoomTypeId_Except.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => "'" + x + "'").ToArray();
                sql += string.Format(" and roomtypeid not in ({0})", arr);
            }
            if (searchModel.RoomRateId != null && searchModel.RoomRateId.Length > 0)
            {
                sql += string.Format(" and roomrateid in ({0})", string.Join(",", searchModel.RoomRateId.Select(x => x.ToString()).ToArray()));
            }
            if (!string.IsNullOrEmpty(searchModel.RoomRateId_Except))
            {
                string[] arr = searchModel.RoomRateId_Except.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => "'" + x + "'").ToArray();
                sql += string.Format(" and roomrateid not in ({0})", arr);
            }
            if (!string.IsNullOrEmpty(searchModel.Mudidi))
            {
                searchModel.CityName = searchModel.Mudidi;
            }
            if (!string.IsNullOrEmpty(searchModel.Latitude) && !string.IsNullOrEmpty(searchModel.Longitude))
            {
                sql += string.Format(" and hotelid in(select hotelid from tbl_hotel where ");
                sql += string.Format(" sqrt(((({0}-longitude)*PI()*12656*cos((({1}+latitude)/2)*PI()/180)/180) * (({0}-longitude)*PI()*12656*cos ((({1}+latitude)/2)*PI()/180)/180)) ", Convert.ToDecimal(searchModel.Longitude), Convert.ToDecimal(searchModel.Latitude));
                sql += string.Format(" +((({0}-latitude)*PI()*12656/180)* (({0}-latitude)*PI()*12656/180)))<3 )", Convert.ToDecimal(searchModel.Latitude));
            }
            if (!string.IsNullOrEmpty(searchModel.IsRecommend))
            {
                if (searchModel.IsRecommend == "1" || string.Equals(searchModel.IsRecommend, "true", StringComparison.OrdinalIgnoreCase))
                {
                    sql += " and (select IsRecommend from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid)='1'";
                }
                else if (searchModel.IsRecommend == "0" || string.Equals(searchModel.IsRecommend, "false", StringComparison.OrdinalIgnoreCase))
                {
                    sql += " and (select IsRecommend from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid)='0'";
                }
            }
            searchModel.SanZiMa = searchModel.CityCode;
            
            if (searchModel.Star.HasValue)
            {
                string starStr = "";
                if (searchModel.Star == HotelStar.二星级以下)
                {
                    starStr += ((int)HotelStar.一星级) + "," + ((int)HotelStar.准一星级);
                }
                else
                {
                    starStr = ((int)searchModel.Star).ToString();
                }
                sql += string.Format(" and (select star from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid) in ({0})", starStr);
            }
            sql += "";

            if (searchModel.RuZhuRiQi2.HasValue)
            {
                searchModel.RuZhuRiQi = searchModel.RuZhuRiQi2.Value;
            }
            if (searchModel.LiDianRiQi2.HasValue)
            {
                searchModel.LiDianRiQi = searchModel.LiDianRiQi2.Value;
            }
            if (!searchModel.RuZhuRiQi.HasValue)
            {
                searchModel.RuZhuRiQi = DateTime.Now.Date;
            }
            if (!searchModel.LiDianRiQi.HasValue || searchModel.LiDianRiQi <= searchModel.RuZhuRiQi)
            {
                searchModel.LiDianRiQi = searchModel.RuZhuRiQi.Value.AddDays(1).Date;
            }
            searchModel.RuZhuRiQi2 = searchModel.RuZhuRiQi;
            searchModel.LiDianRiQi2 = searchModel.LiDianRiQi;
            sql += string.Format(" and enddate>='{0}' and startdate<'{1}'", searchModel.RuZhuRiQi.Value.Date, searchModel.LiDianRiQi.Value.Date);
            if (!string.IsNullOrEmpty(searchModel.MyKeyword))
            {
                searchModel.HotelName = searchModel.MyKeyword;
            }

            if (!string.IsNullOrEmpty(searchModel.HotelName))
            {
                sql += string.Format(" and (select hotelname from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid) like '%{0}%'", searchModel.HotelName);
            }

            IList<MHotelRoomRate> roomRates = new List<MHotelRoomRate>();
            using (var timer1 = new timerRecorder("timer1"))
            {
                //符合时间段的价格信息
                DbDataReader reader = dal.ExecuteReader(sql);
                while (reader.Read())
                {
                    MHotelRoomRate roomrate = new MHotelRoomRate();
                    roomrate.HotelId = reader["HotelId"].ToString();
                    roomrate.RoomRateId = Convert.ToInt32(reader["RoomRateId"]);
                    roomrate.InterfaceID = reader["InterfaceID"].ToString();
                    roomrate.RoomTypeId = reader["RoomTypeId"].ToString();
                    roomrate.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    roomrate.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    roomRates.Add(roomrate);
                }
                reader.Close();
                //HttpContext.Current.Response.Write("<br/>3:" + timer1.getTime());
            }

            IEnumerable<IGrouping<string, MHotelRoomRate>> groups = roomRates.GroupBy(x => x.RoomTypeId);

            Dictionary<string, Dictionary<int, List<DateTime>>> availableHotelRoomRateIDs = new Dictionary<string, Dictionary<int, List<DateTime>>>();
            using (var timer2 = new timerRecorder("timer2"))
            {
                //符合指定时间段的价格id
                foreach (var g in groups) //按房型分组
                {
                    if (string.IsNullOrEmpty(g.First().InterfaceID)) //非接口数据
                    {
                        var roomRatesList = g.OrderBy(x => x.StartDate);

                        //完全匹配列表，它的每个roomRate的开始日期和结束日期都完全符合入住离店日期范围
                        var list1 = roomRatesList.Where(x => x.StartDate <= searchModel.RuZhuRiQi && x.EndDate >= searchModel.LiDianRiQi.Value.AddDays(-1));
                        foreach (var item in list1)
                        {
                            List<DateTime> list = new List<DateTime>();
                            DateTime date3 = searchModel.RuZhuRiQi.Value;
                            while (date3 < searchModel.LiDianRiQi.Value)
                            {
                                list.Add(date3);
                                date3 = date3.AddDays(1);
                            }
                            if (!availableHotelRoomRateIDs.ContainsKey(item.HotelId))
                            {
                                availableHotelRoomRateIDs.Add(item.HotelId, new Dictionary<int, List<DateTime>>());
                            }
                            if (!availableHotelRoomRateIDs[item.HotelId].ContainsKey(item.RoomRateId))
                            {
                                availableHotelRoomRateIDs[item.HotelId].Add(item.RoomRateId, list);
                            }
                        }

                        DateTime date2 = searchModel.RuZhuRiQi.Value;
                        Dictionary<int, KeyValuePair<string, List<DateTime>>> roomRate_times1 = new Dictionary<int, KeyValuePair<string, List<DateTime>>>();
                        int count = 0;
                        //部分匹配列表, 它的每个roomRate的开始日期和结束日期只与入住离店日期范围有交集，但不完全匹配
                        var needCal_list = roomRatesList.Except(list1);
                        while (date2 < searchModel.LiDianRiQi.Value) //循环以检查部分匹配列表中的价格信息是否全部都匹配每一天。
                        {
                            foreach (var roomRate in needCal_list)
                            {
                                if (roomRate.StartDate <= date2 && date2 <= roomRate.EndDate)
                                {
                                    //roomRate_times1是记录当前roomRate所符合的那一天的日期
                                    if (!roomRate_times1.ContainsKey(roomRate.RoomRateId))
                                    {
                                        roomRate_times1.Add(roomRate.RoomRateId, new KeyValuePair<string, List<DateTime>>(roomRate.HotelId, new List<DateTime> { date2 }));
                                    }
                                    else
                                    {
                                        roomRate_times1[roomRate.RoomRateId].Value.Add(date2);
                                    }
                                    count++;
                                }
                            }
                            date2 = date2.AddDays(1);
                        }
                        //如果部分匹配列表中的各个价格组合起来满足了所有日期范围
                        if (count == (searchModel.LiDianRiQi.Value - searchModel.RuZhuRiQi.Value).Days)
                        {
                            foreach (var item in roomRate_times1)
                            {
                                string hotelId = item.Value.Key;
                                int roomRateId = item.Key;
                                List<DateTime> timesList = item.Value.Value;
                                if (!availableHotelRoomRateIDs.ContainsKey(hotelId))
                                {
                                    availableHotelRoomRateIDs.Add(hotelId, new Dictionary<int, List<DateTime>>());
                                }
                                if (!availableHotelRoomRateIDs[hotelId].ContainsKey(roomRateId))
                                {
                                    availableHotelRoomRateIDs[hotelId].Add(roomRateId, timesList);
                                }
                                else
                                {
                                    availableHotelRoomRateIDs[hotelId][roomRateId].AddRange(timesList);
                                }
                            }
                        }
                    }
                    else
                    {
                        //接口的数据价格必须按x.InterfaceID + "$" + x.RoomRateName此种方式分组来保证唯一性。
                        foreach (var plan in g.GroupBy(x => x.InterfaceID + "$" + x.RoomRateName)) //foreach计划list
                        {
                            int count = 0;
                            var roomRatesList = plan.OrderBy(x => x.StartDate);
                            //完全匹配列表，如上
                            var list1 = roomRatesList.Where(x => x.StartDate <= searchModel.RuZhuRiQi && x.EndDate >= searchModel.LiDianRiQi.Value.AddDays(-1));
                            foreach (var item in list1)
                            {
                                List<DateTime> list = new List<DateTime>();
                                DateTime date3 = searchModel.RuZhuRiQi.Value;
                                while (date3 < searchModel.LiDianRiQi.Value)
                                {
                                    list.Add(date3);
                                    date3 = date3.AddDays(1);
                                }
                                if (!availableHotelRoomRateIDs.ContainsKey(item.HotelId))
                                {
                                    availableHotelRoomRateIDs.Add(item.HotelId, new Dictionary<int, List<DateTime>>());
                                }
                                if (!availableHotelRoomRateIDs[item.HotelId].ContainsKey(item.RoomRateId))
                                {
                                    availableHotelRoomRateIDs[item.HotelId].Add(item.RoomRateId, list);
                                }
                            }

                            //部分匹配列表，如上
                            var needCal_list = roomRatesList.Except(list1);
                            Dictionary<int, KeyValuePair<string, List<DateTime>>> roomRate_times2 = new Dictionary<int, KeyValuePair<string, List<DateTime>>>();
                            DateTime date2 = searchModel.RuZhuRiQi.Value;
                            while (date2 < searchModel.LiDianRiQi.Value)
                            {
                                foreach (var roomRate in needCal_list.OrderBy(x => x.StartDate)) //foreach价格list
                                {
                                    if (roomRate.StartDate <= date2 && date2 <= roomRate.EndDate)
                                    {
                                        if (!roomRate_times2.ContainsKey(roomRate.RoomRateId))
                                        {
                                            roomRate_times2.Add(roomRate.RoomRateId, new KeyValuePair<string, List<DateTime>>(roomRate.HotelId, new List<DateTime> { date2 }));
                                        }
                                        else
                                        {
                                            roomRate_times2[roomRate.RoomRateId].Value.Add(date2);
                                        }
                                        count++;
                                    }
                                }
                                date2 = date2.AddDays(1);
                            }
                            if (count == (searchModel.LiDianRiQi.Value - searchModel.RuZhuRiQi.Value).Days)
                            {
                                foreach (var item in roomRate_times2)
                                {
                                    string hotelId = item.Value.Key;
                                    int roomRateId = item.Key;
                                    List<DateTime> timesList = item.Value.Value;
                                    if (!availableHotelRoomRateIDs.ContainsKey(hotelId))
                                    {
                                        availableHotelRoomRateIDs.Add(hotelId, new Dictionary<int, List<DateTime>>());
                                    }
                                    if (!availableHotelRoomRateIDs[hotelId].ContainsKey(item.Key))
                                    {
                                        availableHotelRoomRateIDs[hotelId].Add(roomRateId, timesList);
                                    }
                                    else
                                    {
                                        availableHotelRoomRateIDs[hotelId][roomRateId].AddRange(timesList);
                                    }
                                }
                            }
                            //
                        }
                    }
                }
                //HttpContext.Current.Response.Write("<br/>4:" + timer2.getTime());
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //以下是正式构建查询，包括嵌套子查询图片，内联tbl_hotelRoomRate,内联tbl_HotelRoomType,
            QueryExpressionBuilder<MHotel2> hotelQuery2 = new QueryExpressionBuilder<MHotel2>();
            //hotelQuery2.Where(x => x.RoomQuantity > 0);
            hotelQuery2.OrderByDescending(x => x.IssueTime);

            if (searchModel.MustHasImg)
            {
                QueryExpressionBuilder<MHotelImg> roomImgQuery = new QueryExpressionBuilder<MHotelImg>();
                roomImgQuery.Where(x => x.HotelId == hotelQuery2.EntityModel.HotelId && x.FilePath != "" && x.FilePath != null).Select(x => x.FilePath).OrderBy(x => x.ImgId).Top(1);
                hotelQuery2.Select(roomImgQuery, "FirstImageAddress");
            }
            var queryRoomRate2 = hotelQuery2.InnerJoin<MHotelRoomRate>().On((x, y) => x.HotelId == y.HotelId);

            var queryRoomType = queryRoomRate2.InnerJoin2<MHotelRoomType>().On((x, y) => x.RoomTypeId == y.RoomTypeId);
            queryRoomType.Where((x, y) => y.RoomStatus == RoomStatus.正常);

            //开始组织查询条件。
            string[] hotelIds = availableHotelRoomRateIDs.Keys.OrderBy(x => x).ToArray(); //需先排序以防止每次查询结果顺序不同。

            //组织分页
            if (isPaging) //如果是酒店的首页的列表，则需分页
            {
                hotelIds = hotelIds.Skip(searchModel.SearchInfo.PageInfo.PageSize * (searchModel.SearchInfo.PageInfo.PageIndex - 1))
                     .Take(searchModel.SearchInfo.PageInfo.PageSize).OrderBy(x => x).ToArray();
                searchModel.SearchInfo.PageInfo.TotalCount = availableHotelRoomRateIDs.Keys.Count; //数据总行数
                hotelQuery2.SearchInfo = searchModel.SearchInfo; //分页信息
            }

            //组织where
            int[] temp_rateid_arr = null;
            List<int> temp_hotelId_arr2 = new List<int>(); //将分页取出来的hotelid下的价格id放入统一容器
            for (int i = 0; i < hotelIds.Length; i++)
            {
                string hotelId = hotelIds[i];
                temp_hotelId_arr2.AddRange(availableHotelRoomRateIDs[hotelId].Keys.OrderBy(x => x));
            }
            temp_rateid_arr = temp_hotelId_arr2.Distinct().ToArray(); //为防止意外做distinct处理。
            if (temp_rateid_arr.Length > 0)
            {
                queryRoomRate2.Where((x, y) => y.RoomRateId.In(temp_rateid_arr)); //放入where条件查询
            }
            else
            {
                return new List<MHotelSearchModel1>();
            }

            if (isInDefaultPage)
            {
                //在default.aspx页面需要查的几个列
                hotelQuery2.Select(x => new { x.HotelId, x.HotelName, x.Star, x.Address, x.ServiceTel, x.Latitude, x.Longitude });
            }
            else
            {
                //其他页面。主要是酒店详细页需要筛选的列
                hotelQuery2.Select(x => new { x.HotelId, x.HotelName, x.Star, x.Address, x.ServiceTel, x.LongDesc, x.IssueTime, x.Latitude, x.Longitude });
            }
            if (isInDefaultPage)//首页default.aspx加载时，价格信息需要查的几个列
            {
                queryRoomType.Select((x, y) => new
                {
                    x.SettlementPrice,
                    x.PreferentialPrice,
                });
            }
            else
            {
                //其他页面。主要是酒店详细页需要筛选的列
                queryRoomType.Select((x, y) => new
                {
                    x.RoomRateId,
                    x.SettlementPrice,
                    x.PreferentialPrice,
                    x.InterfaceID,
                    x.Breakfast,
                    x.RoomRateName,
                    x.StartDate,
                    x.EndDate,
                    y.RoomTypeId,
                    y.RoomType,
                    y.RoomName,
                    y.BedType,
                    y.BedTypeDescription,
                    y.IsInternet,
                    y.Desc,
                });
            }
            IList<MHotelSearchModel1> list2 = new List<MHotelSearchModel1>();
            using (var timer3 = new timerRecorder("timer3"))
            {
                //开始查询
                list2 = dal.Select<MHotelSearchModel1>(hotelQuery2);
                // HttpContext.Current.Response.Write("<br/>5:" + timer3.getTime());
            }
            using (var timer5 = new timerRecorder("timer5"))
            {
                //resultList每条数据代表一个酒店，每个酒店下包含多个房型，如果是酒店的首页显示，则每个房型下只插入一条价格信息
                //如果不是首页，则每个房型下有多个价格信息
                List<MHotelSearchModel1> resultList = new List<MHotelSearchModel1>();

                //重新组织酒店，房型，价格信息，这里按结算价排序以保证酒店首页显示的房型价格信息都是最低价格
                foreach (MHotelSearchModel1 item in list2.OrderBy(x => x.RoomRate1.SettlementPrice))
                {
                    item.RoomRate1.FeeSetting = feeSetting;
                    item.RoomRate1.RoomTypeInfo = item.RoomTypeInfo1;
                    item.Latitude = item.Latitude;
                    if (availableHotelRoomRateIDs[item.HotelId].ContainsKey(item.RoomRate1.RoomRateId))
                    {
                        //该价格所在的日期
                        item.RoomRate1.Time = availableHotelRoomRateIDs[item.HotelId][item.RoomRate1.RoomRateId];
                    }
                    else
                    {
                        item.RoomRate1.Time = new List<DateTime>();
                    }
                    if (!resultList.Any(x => x.HotelId == item.HotelId))
                    {
                        item.RoomRateInfo = new List<MHotelRoomRateBindModel> { item.RoomRate1 };
                        resultList.Add(item);
                    }

                    else if (!resultList.Any(x => x.RoomRateInfo.Any(y => y.RoomTypeId == item.RoomTypeId)))
                    {
                        MHotelSearchModel1 a = resultList.Find(x => x.HotelId == item.HotelId);
                        a.RoomRateInfo.Add(item.RoomRate1);
                    }
                    else
                    {
                        if (!isPaging) //如果是用于其他页面，如酒店详情页，则显示所有价格信息
                        {
                            if (!resultList.Any(x => x.RoomRateInfo.Any(y => y.RoomTypeId == item.RoomTypeId) && x.RoomRateInfo.Any(y => y.RoomRateId == item.RoomRate1.RoomRateId)))
                            {
                                MHotelSearchModel1 a = resultList.Find(x => x.RoomRateInfo.Any(y => y.RoomTypeId == item.RoomTypeId));
                                a.RoomRateInfo.Add(item.RoomRate1);
                            }
                        }
                    }
                }
                //HttpContext.Current.Response.Write("<br/>6:" + timer5.getTime());
                return resultList.OrderByDescending(x => x.IssueTime).ToList();
            }
        }

        /// <summary>
        /// 获取酒店（含酒店图片，房价信息）列表
        /// </summary>
        /// <param name="model">查询model</param>
        /// <param name="isPaging">GetHotelList是否用于酒店首页的</param>
        /// <param name="memberType">当前会员的类型</param>
        /// <param name="isInDefaultPage">是否是default.aspx首页的</param>
        /// <returns></returns>
        public IList<MHotelSearchModel1> GetHotelList(MHotelSearchModel1 searchModel, bool isPaging, MemberTypes memberType, bool isInDefaultPage)
        {
            MFeeSettings feeSetting = new BFeeSettings().GetByType(FeeTypes.酒店);
            decimal rate = GetRateByMemberType(feeSetting, memberType);
            if (searchModel.JiaGe1.HasValue && searchModel.JiaGe2.HasValue)
            {
                if (searchModel.JiaGe1.Value < 0)
                {
                    searchModel.JiaGe1 = 100;
                }
                if (searchModel.JiaGe2.Value < 0)
                {
                    searchModel.JiaGe2 = searchModel.JiaGe1.Value + 50;
                }
                if (searchModel.JiaGe2.Value < searchModel.JiaGe1.Value)
                {
                    searchModel.JiaGe2 = searchModel.JiaGe1.Value + 50;
                }
            }
            string sql = "select HotelId, RoomRateId, InterfaceID, RoomTypeId, StartDate, EndDate from {0} tbl_hotelroomrate where 1=1 and (Status is null or Status='' or Status='O') and  EndDate>=getdate()";
            //status='O'
            if (isPaging) //酒店首页
            {
                if (string.IsNullOrEmpty(searchModel.CityCode))
                {
                    searchModel.CityCode = "HGH";
                }
            }

            if (!string.IsNullOrEmpty(searchModel.SanZiMa))
            {
                searchModel.CityCode = searchModel.SanZiMa;
            }

            //列表查询优化，先查出该城市下的价格计划做为数据源，非列表查询则直接查询价格计划表
            if (!string.IsNullOrEmpty(searchModel.CityCode))
            {
                string ts = string.Format("(select HotelId, RoomRateId, InterfaceID, RoomTypeId, StartDate, EndDate,Status,settlementprice,PreferentialPrice from tbl_hotelroomrate where citycode='{0}')", searchModel.CityCode);
                sql = string.Format(sql, ts);

            }
            else
            {
                sql = string.Format(sql, "");
            }

            if (!string.IsNullOrEmpty(searchModel.HotelId))
            {
                sql += string.Format(" and hotelid='{0}'", searchModel.HotelId);
            }
            if (searchModel.JiaGe1.HasValue)
            {
                sql += string.Format(" and settlementprice+(PreferentialPrice*{0}-settlementprice)*{1}>={2}", BHotel2.RetialPricePercent, rate, searchModel.JiaGe1.Value);
            }
            if (searchModel.JiaGe2.HasValue)
            {
                sql += string.Format(" and settlementprice+(PreferentialPrice*{0}-settlementprice)*{1}<={2}", BHotel2.RetialPricePercent, rate, searchModel.JiaGe2.Value);
            }
            if (!string.IsNullOrEmpty(searchModel.RoomTypeId))
            {
                sql += string.Format(" and roomtypeid='{0}'", searchModel.RoomTypeId);
            }
            if (!string.IsNullOrEmpty(searchModel.RoomTypeId_Except))
            {
                string[] arr = searchModel.RoomTypeId_Except.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => "'" + x + "'").ToArray();
                sql += string.Format(" and roomtypeid not in ({0})", arr);
            }
            if (searchModel.RoomRateId != null && searchModel.RoomRateId.Length > 0)
            {
                sql += string.Format(" and roomrateid in ({0})", string.Join(",", searchModel.RoomRateId.Select(x => x.ToString()).ToArray()));
            }
            if (!string.IsNullOrEmpty(searchModel.RoomRateId_Except))
            {
                string[] arr = searchModel.RoomRateId_Except.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => "'" + x + "'").ToArray();
                sql += string.Format(" and roomrateid not in ({0})", arr);
            }
            if (!string.IsNullOrEmpty(searchModel.Mudidi))
            {
                searchModel.CityName = searchModel.Mudidi;
            }
            if (!string.IsNullOrEmpty(searchModel.Latitude) && !string.IsNullOrEmpty(searchModel.Longitude))
            {
                sql += string.Format(" and hotelid in(select hotelid from tbl_hotel where ");
                sql += string.Format(" sqrt(((({0}-longitude)*PI()*12656*cos((({1}+latitude)/2)*PI()/180)/180) * (({0}-longitude)*PI()*12656*cos ((({1}+latitude)/2)*PI()/180)/180)) ", Convert.ToDecimal(searchModel.Longitude), Convert.ToDecimal(searchModel.Latitude));
                sql += string.Format(" +((({0}-latitude)*PI()*12656/180)* (({0}-latitude)*PI()*12656/180)))<3 )", Convert.ToDecimal(searchModel.Latitude));
            }
            if (!string.IsNullOrEmpty(searchModel.CityName))
            {
                BHotelCity c = new BHotelCity();
                object cc = dal.ExecuteSqlScalar(string.Format("select CityCode from tbl_HotelCity where CityName='{0}'", searchModel.CityName));
                if (cc != null && cc.ToString() != "")
                {
                    searchModel.CityCode = cc.ToString();
                }
            }
            if (!string.IsNullOrEmpty(searchModel.IsRecommend))
            {
                if (searchModel.IsRecommend == "1" || string.Equals(searchModel.IsRecommend, "true", StringComparison.OrdinalIgnoreCase))
                {
                    sql += " and (select IsRecommend from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid)='1'";
                }
                else if (searchModel.IsRecommend == "0" || string.Equals(searchModel.IsRecommend, "false", StringComparison.OrdinalIgnoreCase))
                {
                    sql += " and (select IsRecommend from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid)='0'";
                }
            }
            searchModel.SanZiMa = searchModel.CityCode;
            if (searchModel.IsIndex != null && searchModel.IsIndex.Length > 0)
            {
                sql += " AND HotelId in (select tbl_Hotel.HotelId from tbl_hotel where  IsIndex IN(" + Utils.GetSqlIn(searchModel.IsIndex) + ")) ";
            }
            if (searchModel.Star.HasValue)
            {
                string starStr = "";
                if (searchModel.Star == HotelStar.二星级以下)
                {
                    starStr += ((int)HotelStar.一星级) + "," + ((int)HotelStar.准一星级);
                }
                else
                {
                    starStr = ((int)searchModel.Star).ToString();
                }
                sql += string.Format(" and (select star from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid) in ({0})", starStr);
            }
            sql += "";

            if (searchModel.RuZhuRiQi2.HasValue)
            {
                searchModel.RuZhuRiQi = searchModel.RuZhuRiQi2.Value;
            }
            if (searchModel.LiDianRiQi2.HasValue)
            {
                searchModel.LiDianRiQi = searchModel.LiDianRiQi2.Value;
            }
            if (!searchModel.RuZhuRiQi.HasValue)
            {
                searchModel.RuZhuRiQi = DateTime.Now.Date;
            }
            if (!searchModel.LiDianRiQi.HasValue || searchModel.LiDianRiQi <= searchModel.RuZhuRiQi)
            {
                searchModel.LiDianRiQi = searchModel.RuZhuRiQi.Value.AddDays(1).Date;
            }
            searchModel.RuZhuRiQi2 = searchModel.RuZhuRiQi;
            searchModel.LiDianRiQi2 = searchModel.LiDianRiQi;
            sql += string.Format(" and enddate>='{0}' and startdate<'{1}'", searchModel.RuZhuRiQi.Value.Date, searchModel.LiDianRiQi.Value.Date);
            if (!string.IsNullOrEmpty(searchModel.MyKeyword))
            {
                searchModel.HotelName = searchModel.MyKeyword;
            }

            if (!string.IsNullOrEmpty(searchModel.HotelName))
            {
                sql += string.Format(" and (select hotelname from tbl_hotel where hotelid=tbl_hotelroomrate.hotelid) like '%{0}%'", searchModel.HotelName);
            }

            IList<MHotelRoomRate> roomRates = new List<MHotelRoomRate>();
            using (var timer1 = new timerRecorder("timer1"))
            {
                //符合时间段的价格信息
                DbDataReader reader = dal.ExecuteReader(sql);
                while (reader.Read())
                {
                    MHotelRoomRate roomrate = new MHotelRoomRate();
                    roomrate.HotelId = reader["HotelId"].ToString();
                    roomrate.RoomRateId = Convert.ToInt32(reader["RoomRateId"]);
                    roomrate.InterfaceID = reader["InterfaceID"].ToString();
                    roomrate.RoomTypeId = reader["RoomTypeId"].ToString();
                    roomrate.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    roomrate.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    roomRates.Add(roomrate);
                }
                reader.Close();
                //HttpContext.Current.Response.Write("<br/>3:" + timer1.getTime());
            }

            IEnumerable<IGrouping<string, MHotelRoomRate>> groups = roomRates.GroupBy(x => x.RoomTypeId);

            Dictionary<string, Dictionary<int, List<DateTime>>> availableHotelRoomRateIDs = new Dictionary<string, Dictionary<int, List<DateTime>>>();
            using (var timer2 = new timerRecorder("timer2"))
            {
                //符合指定时间段的价格id
                foreach (var g in groups) //按房型分组
                {
                    if (string.IsNullOrEmpty(g.First().InterfaceID)) //非接口数据
                    {
                        var roomRatesList = g.OrderBy(x => x.StartDate);

                        //完全匹配列表，它的每个roomRate的开始日期和结束日期都完全符合入住离店日期范围
                        var list1 = roomRatesList.Where(x => x.StartDate <= searchModel.RuZhuRiQi && x.EndDate >= searchModel.LiDianRiQi.Value.AddDays(-1));
                        foreach (var item in list1)
                        {
                            List<DateTime> list = new List<DateTime>();
                            DateTime date3 = searchModel.RuZhuRiQi.Value;
                            while (date3 < searchModel.LiDianRiQi.Value)
                            {
                                list.Add(date3);
                                date3 = date3.AddDays(1);
                            }
                            if (!availableHotelRoomRateIDs.ContainsKey(item.HotelId))
                            {
                                availableHotelRoomRateIDs.Add(item.HotelId, new Dictionary<int, List<DateTime>>());
                            }
                            if (!availableHotelRoomRateIDs[item.HotelId].ContainsKey(item.RoomRateId))
                            {
                                availableHotelRoomRateIDs[item.HotelId].Add(item.RoomRateId, list);
                            }
                        }

                        DateTime date2 = searchModel.RuZhuRiQi.Value;
                        Dictionary<int, KeyValuePair<string, List<DateTime>>> roomRate_times1 = new Dictionary<int, KeyValuePair<string, List<DateTime>>>();
                        int count = 0;
                        //部分匹配列表, 它的每个roomRate的开始日期和结束日期只与入住离店日期范围有交集，但不完全匹配
                        var needCal_list = roomRatesList.Except(list1);
                        while (date2 < searchModel.LiDianRiQi.Value) //循环以检查部分匹配列表中的价格信息是否全部都匹配每一天。
                        {
                            foreach (var roomRate in needCal_list)
                            {
                                if (roomRate.StartDate <= date2 && date2 <= roomRate.EndDate)
                                {
                                    //roomRate_times1是记录当前roomRate所符合的那一天的日期
                                    if (!roomRate_times1.ContainsKey(roomRate.RoomRateId))
                                    {
                                        roomRate_times1.Add(roomRate.RoomRateId, new KeyValuePair<string, List<DateTime>>(roomRate.HotelId, new List<DateTime> { date2 }));
                                    }
                                    else
                                    {
                                        roomRate_times1[roomRate.RoomRateId].Value.Add(date2);
                                    }
                                    count++;
                                }
                            }
                            date2 = date2.AddDays(1);
                        }
                        //如果部分匹配列表中的各个价格组合起来满足了所有日期范围
                        if (count == (searchModel.LiDianRiQi.Value - searchModel.RuZhuRiQi.Value).Days)
                        {
                            foreach (var item in roomRate_times1)
                            {
                                string hotelId = item.Value.Key;
                                int roomRateId = item.Key;
                                List<DateTime> timesList = item.Value.Value;
                                if (!availableHotelRoomRateIDs.ContainsKey(hotelId))
                                {
                                    availableHotelRoomRateIDs.Add(hotelId, new Dictionary<int, List<DateTime>>());
                                }
                                if (!availableHotelRoomRateIDs[hotelId].ContainsKey(roomRateId))
                                {
                                    availableHotelRoomRateIDs[hotelId].Add(roomRateId, timesList);
                                }
                                else
                                {
                                    availableHotelRoomRateIDs[hotelId][roomRateId].AddRange(timesList);
                                }
                            }
                        }
                    }
                    else
                    {
                        //接口的数据价格必须按x.InterfaceID + "$" + x.RoomRateName此种方式分组来保证唯一性。
                        foreach (var plan in g.GroupBy(x => x.InterfaceID + "$" + x.RoomRateName)) //foreach计划list
                        {
                            int count = 0;
                            var roomRatesList = plan.OrderBy(x => x.StartDate);
                            //完全匹配列表，如上
                            var list1 = roomRatesList.Where(x => x.StartDate <= searchModel.RuZhuRiQi && x.EndDate >= searchModel.LiDianRiQi.Value.AddDays(-1));
                            foreach (var item in list1)
                            {
                                List<DateTime> list = new List<DateTime>();
                                DateTime date3 = searchModel.RuZhuRiQi.Value;
                                while (date3 < searchModel.LiDianRiQi.Value)
                                {
                                    list.Add(date3);
                                    date3 = date3.AddDays(1);
                                }
                                if (!availableHotelRoomRateIDs.ContainsKey(item.HotelId))
                                {
                                    availableHotelRoomRateIDs.Add(item.HotelId, new Dictionary<int, List<DateTime>>());
                                }
                                if (!availableHotelRoomRateIDs[item.HotelId].ContainsKey(item.RoomRateId))
                                {
                                    availableHotelRoomRateIDs[item.HotelId].Add(item.RoomRateId, list);
                                }
                            }

                            //部分匹配列表，如上
                            var needCal_list = roomRatesList.Except(list1);
                            Dictionary<int, KeyValuePair<string, List<DateTime>>> roomRate_times2 = new Dictionary<int, KeyValuePair<string, List<DateTime>>>();
                            DateTime date2 = searchModel.RuZhuRiQi.Value;
                            while (date2 < searchModel.LiDianRiQi.Value)
                            {
                                foreach (var roomRate in needCal_list.OrderBy(x => x.StartDate)) //foreach价格list
                                {
                                    if (roomRate.StartDate <= date2 && date2 <= roomRate.EndDate)
                                    {
                                        if (!roomRate_times2.ContainsKey(roomRate.RoomRateId))
                                        {
                                            roomRate_times2.Add(roomRate.RoomRateId, new KeyValuePair<string, List<DateTime>>(roomRate.HotelId, new List<DateTime> { date2 }));
                                        }
                                        else
                                        {
                                            roomRate_times2[roomRate.RoomRateId].Value.Add(date2);
                                        }
                                        count++;
                                    }
                                }
                                date2 = date2.AddDays(1);
                            }
                            if (count == (searchModel.LiDianRiQi.Value - searchModel.RuZhuRiQi.Value).Days)
                            {
                                foreach (var item in roomRate_times2)
                                {
                                    string hotelId = item.Value.Key;
                                    int roomRateId = item.Key;
                                    List<DateTime> timesList = item.Value.Value;
                                    if (!availableHotelRoomRateIDs.ContainsKey(hotelId))
                                    {
                                        availableHotelRoomRateIDs.Add(hotelId, new Dictionary<int, List<DateTime>>());
                                    }
                                    if (!availableHotelRoomRateIDs[hotelId].ContainsKey(item.Key))
                                    {
                                        availableHotelRoomRateIDs[hotelId].Add(roomRateId, timesList);
                                    }
                                    else
                                    {
                                        availableHotelRoomRateIDs[hotelId][roomRateId].AddRange(timesList);
                                    }
                                }
                            }
                            //
                        }
                    }
                }
                //HttpContext.Current.Response.Write("<br/>4:" + timer2.getTime());
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //以下是正式构建查询，包括嵌套子查询图片，内联tbl_hotelRoomRate,内联tbl_HotelRoomType,
            QueryExpressionBuilder<MHotel2> hotelQuery2 = new QueryExpressionBuilder<MHotel2>();
            //hotelQuery2.Where(x => x.RoomQuantity > 0);
            hotelQuery2.OrderByDescending(x => x.IssueTime);

            if (searchModel.MustHasImg)
            {
                QueryExpressionBuilder<MHotelImg> roomImgQuery = new QueryExpressionBuilder<MHotelImg>();
                roomImgQuery.Where(x => x.HotelId == hotelQuery2.EntityModel.HotelId && x.FilePath != "" && x.FilePath != null).Select(x => x.FilePath).OrderBy(x => x.ImgId).Top(1);
                hotelQuery2.Select(roomImgQuery, "FirstImageAddress");
            }
            var queryRoomRate2 = hotelQuery2.InnerJoin<MHotelRoomRate>().On((x, y) => x.HotelId == y.HotelId);

            var queryRoomType = queryRoomRate2.InnerJoin2<MHotelRoomType>().On((x, y) => x.RoomTypeId == y.RoomTypeId);
            queryRoomType.Where((x, y) => y.RoomStatus == RoomStatus.正常);

            //开始组织查询条件。
            string[] hotelIds = availableHotelRoomRateIDs.Keys.OrderBy(x => x).ToArray(); //需先排序以防止每次查询结果顺序不同。

            //组织分页
            if (isPaging) //如果是酒店的首页的列表，则需分页
            {
                hotelIds = hotelIds.Skip(searchModel.SearchInfo.PageInfo.PageSize * (searchModel.SearchInfo.PageInfo.PageIndex - 1))
                     .Take(searchModel.SearchInfo.PageInfo.PageSize).OrderBy(x => x).ToArray();
                searchModel.SearchInfo.PageInfo.TotalCount = availableHotelRoomRateIDs.Keys.Count; //数据总行数
                hotelQuery2.SearchInfo = searchModel.SearchInfo; //分页信息
            }

            //组织where
            int[] temp_rateid_arr = null;
            List<int> temp_hotelId_arr2 = new List<int>(); //将分页取出来的hotelid下的价格id放入统一容器
            for (int i = 0; i < hotelIds.Length; i++)
            {
                string hotelId = hotelIds[i];
                temp_hotelId_arr2.AddRange(availableHotelRoomRateIDs[hotelId].Keys.OrderBy(x => x));
            }
            temp_rateid_arr = temp_hotelId_arr2.Distinct().ToArray(); //为防止意外做distinct处理。
            if (temp_rateid_arr.Length > 0)
            {
                queryRoomRate2.Where((x, y) => y.RoomRateId.In(temp_rateid_arr)); //放入where条件查询
            }
            else
            {
                return new List<MHotelSearchModel1>();
            }

            if (isInDefaultPage)
            {
                //在default.aspx页面需要查的几个列
                hotelQuery2.Select(x => new { x.HotelId, x.HotelName, x.Star, x.Address, x.ProductSort });
            }
            else
            {
                //其他页面。主要是酒店详细页需要筛选的列
                hotelQuery2.Select(x => new { x.HotelId, x.HotelName, x.Star, x.LongDesc, x.IssueTime, x.ProductSort });
            }
            if (isInDefaultPage)//首页default.aspx加载时，价格信息需要查的几个列
            {
                queryRoomType.Select((x, y) => new
                {
                    x.SettlementPrice,
                    x.PreferentialPrice,
                });
            }
            else
            {
                //其他页面。主要是酒店详细页需要筛选的列
                queryRoomType.Select((x, y) => new
                {
                    x.RoomRateId,
                    x.SettlementPrice,
                    x.PreferentialPrice,
                    x.InterfaceID,
                    x.Breakfast,
                    x.RoomRateName,
                    x.StartDate,
                    x.EndDate,
                    y.RoomTypeId,
                    y.RoomType,
                    y.RoomName,
                    y.BedType,
                    y.BedTypeDescription,
                    y.IsInternet,
                    y.Desc,
                });
            }
            IList<MHotelSearchModel1> list2 = new List<MHotelSearchModel1>();
            using (var timer3 = new timerRecorder("timer3"))
            {
                //开始查询
                list2 = dal.Select<MHotelSearchModel1>(hotelQuery2);
                // HttpContext.Current.Response.Write("<br/>5:" + timer3.getTime());
            }
            using (var timer5 = new timerRecorder("timer5"))
            {
                //resultList每条数据代表一个酒店，每个酒店下包含多个房型，如果是酒店的首页显示，则每个房型下只插入一条价格信息
                //如果不是首页，则每个房型下有多个价格信息
                List<MHotelSearchModel1> resultList = new List<MHotelSearchModel1>();

                //重新组织酒店，房型，价格信息，这里按结算价排序以保证酒店首页显示的房型价格信息都是最低价格
                foreach (MHotelSearchModel1 item in list2.OrderBy(x => x.RoomRate1.SettlementPrice))
                {
                    item.RoomRate1.FeeSetting = feeSetting;
                    item.RoomRate1.RoomTypeInfo = item.RoomTypeInfo1;

                    if (availableHotelRoomRateIDs[item.HotelId].ContainsKey(item.RoomRate1.RoomRateId))
                    {
                        //该价格所在的日期
                        item.RoomRate1.Time = availableHotelRoomRateIDs[item.HotelId][item.RoomRate1.RoomRateId];
                    }
                    else
                    {
                        item.RoomRate1.Time = new List<DateTime>();
                    }
                    if (!resultList.Any(x => x.HotelId == item.HotelId))
                    {
                        item.RoomRateInfo = new List<MHotelRoomRateBindModel> { item.RoomRate1 };
                        resultList.Add(item);
                    }
                    else if (!resultList.Any(x => x.RoomRateInfo.Any(y => y.RoomTypeId == item.RoomTypeId)))
                    {
                        MHotelSearchModel1 a = resultList.Find(x => x.HotelId == item.HotelId);
                        a.RoomRateInfo.Add(item.RoomRate1);
                    }
                    else
                    {
                        if (!isPaging) //如果是用于其他页面，如酒店详情页，则显示所有价格信息
                        {
                            if (!resultList.Any(x => x.RoomRateInfo.Any(y => y.RoomTypeId == item.RoomTypeId) && x.RoomRateInfo.Any(y => y.RoomRateId == item.RoomRate1.RoomRateId)))
                            {
                                MHotelSearchModel1 a = resultList.Find(x => x.RoomRateInfo.Any(y => y.RoomTypeId == item.RoomTypeId));
                                a.RoomRateInfo.Add(item.RoomRate1);
                            }
                        }
                    }
                }
                //HttpContext.Current.Response.Write("<br/>6:" + timer5.getTime());
                return resultList.OrderByDescending(x => x.IssueTime).ToList();
            }
        }

        /// <summary>
        /// 取的是非接口的酒店
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public List<MHotel2> GetSimplHotelList(MHotelSearchModel1 searchModel)
        {
            QueryExpressionBuilder<MHotel2> query = new QueryExpressionBuilder<MHotel2>();
            query.Select(x => new { x.HotelId, x.HotelName });

            //query.Where(x => x.RoomQuantity > 0);
            if (searchModel.NoInterface)
            {
                query.Where(x => x.InterfaceId == null || x.InterfaceId == "");
            }

            var reader = dal.ExecuteReader(query.ToString());

            List<MHotel2> list = new List<MHotel2>();
            while (reader.Read())
            {
                MHotel2 model = new MHotel2();
                model.HotelId = reader["HotelId"].ToString();
                model.HotelName = reader["HotelName"].ToString();
                list.Add(model);
            }
            reader.Close();
            return list;
        }


        /// <summary>
        /// 获取酒店详情
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public MHotelXiangQingModel GetHotelDetail(MHotelXiangQingModel searchModel)
        {
            if (string.IsNullOrEmpty(searchModel.HotelId))
            {
                return null;
            }
            var model = dal.Get<MHotelXiangQingModel>(searchModel);
            if (model == null)
            {
                return null;
            }
            //取第一张图片，不定的。
            var img = dalImg.Get(x => x.HotelId == searchModel.HotelId);
            if (img != null)
            {
                model.FirstImageAddress = img.FilePath;
            }
            if (!string.IsNullOrEmpty(model.InterfaceId))
            {
                //周遍设施表
                QueryExpressionBuilder<Hotel_HotelAmenity> query2 = new QueryExpressionBuilder<Hotel_HotelAmenity>();
                query2.Where(x => x.HOTEL_CODE == model.InterfaceId);
                model.SheShi = dalAmenity.Select(query2);

                //交通信息表
                QueryExpressionBuilder<Hotel_HotelTraffic> query3 = new QueryExpressionBuilder<Hotel_HotelTraffic>();
                query3.Where(x => x.HOTEL_CODE == model.InterfaceId);
                model.Traffic = dalTraffice.Select(query3);
            }
            return model;
        }

        /// <summary>
        /// 获取酒店详情2
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public MHotelXiangQingModel2 GetHotelDetail2(MHotelXiangQingModel2 searchModel)
        {
            if (string.IsNullOrEmpty(searchModel.HotelId))
            {
                return null;
            }
            var model = dal.Get<MHotelXiangQingModel2>(searchModel);
            if (model == null)
            {
                return null;
            }
            var img = dalImg.Get(x => x.HotelId == searchModel.HotelId);
            if (img != null)
            {
                model.FirstImageAddress = img.FilePath;
            }
            if (!string.IsNullOrEmpty(searchModel.RoomTypeId))
            {
                model.RoomTypeInfo = dalRommType.Get(searchModel.RoomTypeId);
            }
            return model;
        }

        /// <summary>
        /// 分页取酒店图片
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public IList<MHotelImg> GetHotelImgList(MHotelXiangQingModel searchModel)
        {
            if (string.IsNullOrEmpty(searchModel.HotelId) || searchModel.SearchInfo == null)
            {
                return null;
            }
            QueryExpressionBuilder<MHotelImg> query = new QueryExpressionBuilder<MHotelImg>();
            query.SearchInfo = searchModel.SearchInfo;
            query.OrderByDescending(x => x.IssueTime);
            query.Where(x => x.HotelId == searchModel.HotelId);
            return dalImg.SelectPagedList<MHotelImg>(query);
        }

        /// <summary>
        /// 提交酒店订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SubmitHotelOrder(MHotelOrderXiangQing submitModel, MemberTypes memberType, out string msg)
        {
            string JiaGeList = "";//销售价格
            string FenXiaoJiaGeList = "";//分销价格
            msg = "";
            if (string.IsNullOrEmpty(submitModel.HotelId)
               || submitModel.RoomRateIds == null || submitModel.RoomRateIds.Length == 0
               || submitModel.RoomRateIds.Split(',').Length == 0
               || submitModel.OrderCotact == null || submitModel.OrderCotact.Length == 0
               || submitModel.RoomCount <= 0 || submitModel.Day <= 0
               || submitModel.CheckInDate >= submitModel.CheckOutDate)
            {
                msg = "非法操作";
                return false;
            }
            foreach (string s in submitModel.RoomRateIds.Split(','))
            {
                int ff;
                if (!int.TryParse(s, out ff) || ff <= 0)
                {
                    msg = "非法操作";
                    return false;
                }
            }

            using (dalHotelOrder.BeginTransaction())
            {
                try
                {
                    MHotel2 hotel = dal.Get(submitModel.HotelId);
                    if (hotel == null)
                    {
                        msg = "数据异常";
                        return false;
                    }

                    foreach (MHotelOrderContact contact in submitModel.OrderCotact)
                    {
                        if (string.IsNullOrEmpty(contact.ContactName) || string.IsNullOrEmpty(contact.Mobile))
                        {
                            msg = "联系人信息不能为空";
                            return false;
                        }
                    }


                    long count = dalHotelOrder.Count();
                    MHotelOrderXiangQing orderForSubmit = new MHotelOrderXiangQing();
                    orderForSubmit.BuyCompanyName = "";
                    orderForSubmit.CheckInDate = submitModel.CheckInDate;
                    orderForSubmit.CheckOutDate = submitModel.CheckOutDate;
                    orderForSubmit.ContactMobile = submitModel.ContactMobile;
                    orderForSubmit.ContactName = submitModel.ContactName;
                    //orderForSubmit.DanJia = 0;
                    orderForSubmit.Day = submitModel.Day;
                    orderForSubmit.HotelId = submitModel.HotelId;
                    orderForSubmit.IssueTime = DateTime.Now;
                    //orderForSubmit.JiaGeId = 0;
                    orderForSubmit.RoomRateIds = submitModel.RoomRateIds;
                    orderForSubmit.OperatorId = submitModel.OperatorId;
                    orderForSubmit.OrderCotact = submitModel.OrderCotact;
                    orderForSubmit.OrderCode = "JD" + orderForSubmit.IssueTime.ToString("yyyyMMdd") + (count + 1).ToString().PadLeft(4, '0');
                    orderForSubmit.OrderId = Guid.NewGuid().ToString();
                    orderForSubmit.OrderState = OrderState.未处理;
                    orderForSubmit.PaymentState = PaymentState.未支付;

                    orderForSubmit.PaymentType = submitModel.PaymentType;//接口的支付方式： （前台现付：T，代收代付：S，预付：Y）
                    orderForSubmit.Remark = submitModel.Remark;
                    orderForSubmit.RoomCount = submitModel.RoomCount;
                    orderForSubmit.RoomTypeId = submitModel.RoomTypeId;
                    //orderForSubmit.TotalAmount = submitModel.TotalAmount;
                    orderForSubmit.DaoDianShiJian = submitModel.DaoDianShiJian;
                    orderForSubmit.OrderSite = submitModel.OrderSite;

                    var searchModel = new MRoomRateSearchModel
                    {
                        RuZhuRiQi = submitModel.CheckInDate,
                        LiDianRiQi = submitModel.CheckOutDate,
                        RoomTypeId = submitModel.RoomTypeId,
                        RoomRateIds = submitModel.RoomRateIds,
                    };

                    var _orderRoomRateInfo = GetOrderRoomRateInfo(searchModel, out msg);

                    orderForSubmit.RoomRates = _orderRoomRateInfo.RoomRates;
                    
                    int hotelday = 0;
                    //for (int htime = 0; htime < orderForSubmit.RoomRates.Count; htime++)
                    //{
                    //    hotelday = hotelday + orderForSubmit.RoomRates[htime].Time.Count();
                    //}
                    hotelday = orderForSubmit.RoomRates.Count;
                    if (orderForSubmit.RoomRates == null || orderForSubmit.RoomRates.Count == 0 || hotelday != (submitModel.CheckOutDate - submitModel.CheckInDate).Days)
                    {
                        msg = "物价信息未发现！";
                        return false;
                    }
                    MFeeSettings feeSetting = bllFeeSetting.GetByType(FeeTypes.酒店);

                    decimal totalMoney = orderForSubmit.RoomRates.Sum(x =>
                    {
                        return orderForSubmit.RoomCount * CalculateFee(x.SettlementPrice, x.PreferentialPrice, memberType, feeSetting, FeeTypes.酒店);
                    });

                    orderForSubmit.TotalAmount = totalMoney;

                    for (int mday = 0; mday < orderForSubmit.RoomRates.Count; mday++)
                    {
                        JiaGeList += CalculateFee(orderForSubmit.RoomRates[mday].SettlementPrice, orderForSubmit.RoomRates[mday].PreferentialPrice, memberType, feeSetting, FeeTypes.酒店) + ",";
                    }

                    string url = HttpContext.Current.Request.Url.Host.Replace("m.","");
                    bool hasPower = new BSellers().JudgeAuthor(url, FeeTypes.酒店);
                    if (hasPower)
                    {
                        MSellers currentSellerInfo = new MSellers();
                        currentSellerInfo = bsells.GetMSellersByWebSite(url);
                        if (currentSellerInfo != null)
                        {
                            orderForSubmit.SellerID = currentSellerInfo.ID;
                        }

                        #region  计算总分销价格
                        //分销金额
                        if (!string.IsNullOrEmpty(orderForSubmit.SellerID))
                        {
                            if (currentSellerInfo != null)
                            {
                                bool flag = false;
                                if (currentSellerInfo.DengJi == MemberTypes.代理)
                                {
                                        orderForSubmit.AgencyJinE = orderForSubmit.RoomRates.Sum(item => CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.代理, item.FeeSetting, FeeTypes.酒店));
                                        flag = true;
                                }
                                else if (currentSellerInfo.DengJi == MemberTypes.免费代理)
                                {
                                        orderForSubmit.AgencyJinE = orderForSubmit.RoomRates.Sum(item => CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.免费代理, item.FeeSetting, FeeTypes.酒店));
                                        flag = true;
                                }
                                else if (currentSellerInfo.DengJi == MemberTypes.员工)
                                {
                                    orderForSubmit.AgencyJinE = orderForSubmit.RoomRates.Sum(item => CalculateFee(item.SettlementPrice, item.PreferentialPrice, MemberTypes.员工, item.FeeSetting, FeeTypes.酒店));
                                    flag = true;
                                }
                                if (flag == false)
                                {
                                    MFeeSettings fee = bllFeeSetting.GetByType(FeeTypes.酒店);
                                    if (currentSellerInfo.DengJi == MemberTypes.代理 || currentSellerInfo.DengJi == MemberTypes.免费代理)
                                    {
                                        decimal total = 0;
                                        foreach (var item in orderForSubmit.RoomRates)
                                        {
                                            total += CalculateFee(item.SettlementPrice, item.PreferentialPrice, currentSellerInfo.DengJi, fee, FeeTypes.酒店);
                                        }
                                        orderForSubmit.AgencyJinE = total;
                                    }
                                }
                            }
                            orderForSubmit.AgencyJinE = orderForSubmit.AgencyJinE * orderForSubmit.RoomCount;
                        }
                        else
                        {
                            orderForSubmit.AgencyJinE = orderForSubmit.RoomRates.Sum(x => x.SettlementPrice * orderForSubmit.RoomCount);
                        }
                        #endregion

                        #region 计算每一天的分销金额
                        if (!string.IsNullOrEmpty(orderForSubmit.SellerID))
                        {
                            if (currentSellerInfo != null)
                            {
                                bool flag = false;
                                if (currentSellerInfo.DengJi == MemberTypes.代理)
                                {
                                    for (int fmday = 0; fmday < orderForSubmit.RoomRates.Count; fmday++)
                                    {
                                        FenXiaoJiaGeList += CalculateFee(orderForSubmit.RoomRates[fmday].SettlementPrice, orderForSubmit.RoomRates[fmday].PreferentialPrice, MemberTypes.代理, orderForSubmit.RoomRates[fmday].FeeSetting, FeeTypes.酒店) + ",";
                                    }
                                    flag = true;
                                }
                                else if (currentSellerInfo.DengJi == MemberTypes.免费代理)
                                {
                                    for (int fmday = 0; fmday < orderForSubmit.RoomRates.Count; fmday++)
                                    {
                                        FenXiaoJiaGeList += CalculateFee(orderForSubmit.RoomRates[fmday].SettlementPrice, orderForSubmit.RoomRates[fmday].PreferentialPrice, MemberTypes.免费代理, orderForSubmit.RoomRates[fmday].FeeSetting, FeeTypes.酒店) + ",";
                                    }
                                    flag = true;
                                }
                                else if (currentSellerInfo.DengJi == MemberTypes.员工)
                                {
                                    for (int fmday = 0; fmday < orderForSubmit.RoomRates.Count; fmday++)
                                    {
                                        FenXiaoJiaGeList += CalculateFee(orderForSubmit.RoomRates[fmday].SettlementPrice, orderForSubmit.RoomRates[fmday].PreferentialPrice, MemberTypes.员工, orderForSubmit.RoomRates[fmday].FeeSetting, FeeTypes.酒店) + ",";
                                    }
                                    flag = true;
                                }
                                if (flag == false)
                                {
                                    MFeeSettings fee = bllFeeSetting.GetByType(FeeTypes.酒店);
                                    if (currentSellerInfo.DengJi == MemberTypes.代理 || currentSellerInfo.DengJi == MemberTypes.免费代理)
                                    {
                                        foreach (var item in orderForSubmit.RoomRates)
                                        {
                                            FenXiaoJiaGeList += CalculateFee(item.SettlementPrice, item.PreferentialPrice, currentSellerInfo.DengJi, fee, FeeTypes.酒店)+",";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            FenXiaoJiaGeList = "";
                        }
                        #endregion
                    }
                    else
                    {
                        orderForSubmit.AgencyJinE = orderForSubmit.TotalAmount;
                    }

                    if (string.IsNullOrEmpty(hotel.InterfaceId))
                    {
                        orderForSubmit.Source = ScenicAreaOrderSource.网站;
                    }
                    else
                    {
                        orderForSubmit.Source = ScenicAreaOrderSource.来自接口;
                    }

                    orderForSubmit.PaymentType = _orderRoomRateInfo.RommType.Payment;
                    submitModel.PaymentType = _orderRoomRateInfo.RommType.Payment;

                    if (submitModel.PaymentType == Payment.预付全款)
                    {
                        //hotel.InterfaceId = string.Empty;
                        if (!string.IsNullOrEmpty(hotel.InterfaceId))
                        {

                            TravelSky_ShiShiInterface hotelbe = new TravelSky_ShiShiInterface();
                            orderForSubmit.RoomRates = new List<MHotelRoomRateBindModel>();
                            foreach (var roomRateId in orderForSubmit.RoomRateIds.Split(',').Select(x => int.Parse(x)))
                            {
                                var o = dalRoomRate.Get(roomRateId);
                                var item = new MHotelRoomRateBindModel();
                                item.RoomTypeCode = o.RoomTypeCode;
                                item.InterfaceID = o.InterfaceID;
                                item.VenderCode = o.VenderCode;
                                item.StartDate = o.StartDate;
                                item.EndDate = o.EndDate;
                                item.RoomRateId = roomRateId;
                                orderForSubmit.RoomRates.Add(item);
                            }
                            orderForSubmit.Hotel = hotel;
                            string[] ret = hotelbe.HotelOrder(orderForSubmit);
                            string orderId = ret[0];
                            string errmsg = ret[1];
                            if (string.IsNullOrEmpty(orderId))
                            {
                                msg = errmsg;
                                return false;
                            }
                            orderForSubmit.InterfaceID = orderId;
                        }
                    }
                    //orderForSubmit.TotalAmount = orderForSubmit.TotalAmount * hotelday;
                    //orderForSubmit.AgencyJinE = orderForSubmit.AgencyJinE * hotelday;

                    #region 将每一天的价格记录到表

                    IList<HotelXingCheng> items = new List<HotelXingCheng>();
                    if (JiaGeList.Length > 0)
                    {
                        int RuZhuDay = (orderForSubmit.CheckOutDate - orderForSubmit.CheckInDate).Days;
                        string[] JiaGeItem = JiaGeList.Trim().TrimEnd(',').Split(',');
                        string[] FenJiaGeItem = FenXiaoJiaGeList.Trim().TrimEnd(',').Split(',');
                        for (int i = 0; i < RuZhuDay; i++)
                        {
                            var XCModel = new HotelXingCheng();
                            XCModel.ChenkInDate = orderForSubmit.CheckInDate.AddDays(i);
                            XCModel.MenShiJia = Convert.ToDecimal(JiaGeItem[i]);
                            if (FenXiaoJiaGeList.Trim().Length > 0)
                            {
                                XCModel.ChengBenJia = Convert.ToDecimal(FenJiaGeItem[i]);
                            }
                            else
                            {
                                XCModel.ChengBenJia = 0;
                            }
                            items.Add(XCModel);
                        }
                    }
                    orderForSubmit.HotelXC = EyouSoft.DAL.HotelStructure.DHotelOrder.getJsonStr(items);
                    #endregion



                    if (dalHotelOrder.Insert(orderForSubmit) != 1)
                    {
                        msg = "数据更新出错";
                        return false;
                    }

                    var model = new MHotelOrderRoomRateId
                    {
                        HotelId = hotel.HotelId,
                        OrderId = orderForSubmit.OrderId,
                        RoomRateIds = submitModel.RoomRateIds,
                    };
                    if (dalRoomRateId.Insert(model) != 1)
                    {
                        msg = "数据更新出错";
                        return false;
                    }
                    foreach (MHotelOrderContact contact in orderForSubmit.OrderCotact)
                    {
                        contact.OrderId = orderForSubmit.OrderId;
                        if (dalHotelOrderContact.Insert(contact) != 1)
                        {
                            msg = "数据更新出错";
                            return false;
                        }
                    }

                    dalHotelOrder.Complete();
                    msg = "订单已成功提交";



                    BDuanXin b = new BDuanXin();
                    if (b.FaSongDingDanDuanXin(orderForSubmit.OrderId, DingDanLeiBie.酒店订单, DuanXinFaSongLeiXing.下单) != 10000)
                    {
                        RecordError("短信发送成功。订单号" + orderForSubmit.OrderId);
                    }

                    //返联盟推广
                    var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                    flmtgInfo.DingDanId = orderForSubmit.OrderId;
                    flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.酒店订单;
                    flmtgInfo.FanLiBiLi = 0;
                    flmtgInfo.XiaDanRenId = orderForSubmit.OperatorId;
                    new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);

                    //分销比例
                    var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                    jianglibi.DingDanId = orderForSubmit.OrderId;
                    jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.酒店订单;
                    jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                    new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);




                    return true;
                }
                catch (Exception ex)
                {
                    msg = "服务器发生异常";
#if BEBUG
               throw ex;
#endif
                    RecordError(ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// 根据会员类型获取其费率
        /// </summary>
        /// <param name="feeSetting"></param>
        /// <param name="memberType"></param>
        /// <returns></returns>
        public static decimal GetRateByMemberType(MFeeSettings feeSetting, MemberTypes memberType)
        {
            if (feeSetting == null)
                return 1;

            decimal rate = 100;
            if (memberType == MemberTypes.普通会员 || memberType == MemberTypes.未注册用户)
            {
                rate = feeSetting.PuTongHuiYuanJia;
            }
            if (memberType == MemberTypes.贵宾会员)
            {
                rate = feeSetting.GuiBinJia;
            }
            if (memberType == MemberTypes.免费代理)
            {
                rate = feeSetting.FreeFenXiaoJia;
            }
            if (memberType == MemberTypes.代理)
            {
                rate = feeSetting.FenXiaoJia;
            }
            if (memberType == MemberTypes.员工)
            {
                rate = feeSetting.YuanGongJia;
            }
            rate = rate / 100;
            return rate;
        }

        public static decimal RetialPricePercent = 1.1m;
        /// <summary>
        /// 根据会员类型、费用类型计算其费用
        /// </summary>
        /// <param name="settlementPrice">结算价</param>
        /// <param name="marketPrice">门市价（门票这边传入的是网络优惠价，酒店传的和结算价一样）</param>
        /// <param name="memberType">会员类型</param>
        /// <param name="feeSetting">费用设置信息</param>
        /// <param name="type">费用类别</param>
        /// <returns></returns>
        public static decimal CalculateFee(decimal settlementPrice, decimal? marketPrice, MemberTypes memberType, MFeeSettings feeSetting, FeeTypes type)
        {
            decimal rate = 0;
            if (!marketPrice.HasValue)
            {
                marketPrice = settlementPrice;
            }
            rate = GetRateByMemberType(feeSetting, memberType);
            if (type == FeeTypes.酒店)
            {
                //接口返回的数据里，酒店的门市价和结算价是一样的
                return Math.Round(settlementPrice + ((marketPrice.Value * RetialPricePercent) - settlementPrice) * rate);
            }
            else if (type == FeeTypes.门票)
            {
                return Math.Round(settlementPrice + (marketPrice.Value - settlementPrice) * rate);
            }
            return Math.Round(settlementPrice + (marketPrice.Value - settlementPrice) * rate);
        }

        /// <summary>
        /// 接口的早餐和项目自身的早餐枚举间的转换
        /// </summary>
        /// <param name="interfaceBreakValue">来自接口的值</param>
        /// <returns></returns>
        public static IsBreakfast TransBreakFastBetweenInterfaceAndSelfProject(double interfaceBreakValue)
        {
            if (interfaceBreakValue == 1)
            {
                return IsBreakfast.含单早;
            }
            else if (interfaceBreakValue == -1)
            {
                return IsBreakfast.含早;
            }
            else if (interfaceBreakValue == 2)
            {
                return IsBreakfast.含双早;
            }
            else
            {
                return IsBreakfast.不含早;
            }
        }
        /// <summary>
        /// 接口的早餐和项目自身的早餐枚举间的转换
        /// </summary>
        public static IsBreakfast TransBreakFastBetweenInterfaceAndSelfProject(string interfaceBreakValue)
        {
            if (string.IsNullOrEmpty(interfaceBreakValue))
            {
                return IsBreakfast.不含早;
            }
            else
            {
                double tb = 0;
                if (double.TryParse(interfaceBreakValue, out tb))
                {
                    return TransBreakFastBetweenInterfaceAndSelfProject(tb);
                }
                else
                {
                    return IsBreakfast.不含早;
                }
            }
        }

        /// <summary>
        /// 获取订单初始化信息
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public MHotelOrderXiangQing GetOrderRoomRateInfo(MRoomRateSearchModel searchModel, out string msg)
        {
            msg = "";

            if (searchModel.RuZhuRiQi == null || searchModel.LiDianRiQi == null
                  || searchModel.RuZhuRiQi >= searchModel.LiDianRiQi
               || searchModel.RoomRateIds == null || searchModel.RoomRateIds.Length == 0
               || !searchModel.RoomRateIds.All(x => x > 0) || string.IsNullOrEmpty(searchModel.RoomTypeId)
               )
            {
                msg = "非法操作";
                return null;
            }

            MFeeSettings feeSetting = bllFeeSetting.GetByType(FeeTypes.酒店);
            if (feeSetting == null)
            {
                msg = "异常操作";
                return null;
            }
            MHotelOrderXiangQing model = new MHotelOrderXiangQing();

            int[] roomRateIds = new int[searchModel.RoomRateIds.Split(',').Length];

            for (int i = 0; i < searchModel.RoomRateIds.Split(',').Length; i++)
            {
                int h;
                if (!int.TryParse(searchModel.RoomRateIds.Split(',')[i], out h) || h <= 0)
                {
                    msg = "非法操作";
                    return null;
                }
                else
                {
                    roomRateIds[i] = h;
                }
            }

            //组织订单信息
            int rid = roomRateIds[0];
            MHotelRoomRate2 roomRate = dalRoomRate.Get(x => x.RoomRateId == rid);
            model.RommType = dalRommType.Get(x => x.RoomTypeId == searchModel.RoomTypeId);
            model.RoomRates = new List<MHotelRoomRateBindModel>();
            model.VenderCode = roomRate.VenderCode;
            model.HotelId = roomRate.HotelId;
            //model.JiaGeId = searchModel.RoomRateId.Value;
            model.RoomRateIds = searchModel.RoomRateIds;
            model.RoomTypeId = searchModel.RoomTypeId;
            model.CheckInDate = searchModel.RuZhuRiQi.Value;
            model.CheckOutDate = searchModel.LiDianRiQi.Value;
            model.OrderCotact = new MHotelOrderContact[1] { new MHotelOrderContact() };
            model.RoomCount = (searchModel.RoomCount <= 0 || searchModel.RoomCount > 10) ? 1 : searchModel.RoomCount;
            model.FeeSetting = feeSetting;
            model.Day = (model.CheckOutDate - model.CheckInDate).Days;


            if (string.IsNullOrEmpty(roomRate.InterfaceID)) //非接口数据
            {
                QueryExpressionBuilder<MHotel2> hotelQuery = new QueryExpressionBuilder<MHotel2>();
                hotelQuery.Where((x) => x.HotelId == roomRate.HotelId).Select(x => new { x.HotelName, x.Star, x.HotelId });
                MHotel2 mhotel = dal.Get(hotelQuery);
                if (mhotel == null)
                {
                    msg = "异常操作";
                    return null;
                }
                model.Hotel = mhotel;
                for (int i = 0; i < roomRateIds.Length; i++)
                {
                    int rid22 = roomRateIds[i];
                    MHotelRoomRate2 roomRate_temp = dalRoomRate.Get(x => x.RoomRateId == rid22);

                    if (roomRate_temp == null)
                    {
                        msg = "没有发现id为：" + rid22 + "的数据";
                        return null;
                    }
                    MHotelRoomRateBindModel roomRateBindModel = new MHotelRoomRateBindModel
                    {
                        SettlementPrice = roomRate_temp.SettlementPrice,
                        FeeSetting = feeSetting,
                        Time = new List<DateTime>(),
                        PreferentialPrice = roomRate_temp.PreferentialPrice,
                        Breakfast = model.RommType.IsBreakfast.ToString(),
                    };
                    DateTime starttime2 = searchModel.RuZhuRiQi.Value.Date;
                    while (starttime2 < searchModel.LiDianRiQi.Value.Date && starttime2<= roomRate_temp.EndDate)
                    {
                        if (starttime2 >= roomRate_temp.StartDate)
                        {
                            roomRateBindModel.Time.Add(starttime2);
                        }
                        starttime2 = starttime2.AddDays(1);
                    }
                    model.RoomRates.Add(roomRateBindModel);
                }
            }
            else
            {
                //前往接口取数据（主要是最新价格信息）
                TravelSky_ShiShiInterface it = new TravelSky_ShiShiInterface();
                EasySingleHotelReqCondition condition = new EasySingleHotelReqCondition();
                condition.setCheckindate(searchModel.RuZhuRiQi.Value.ToString("yyyy-MM-dd"));
                condition.setCheckoutdate(searchModel.LiDianRiQi.Value.ToString("yyyy-MM-dd"));
                condition.setHotelcode(roomRate.HotelCode);
                condition.RoomTypeCode = roomRate.RoomTypeCode;
                condition.RatePlanCode = roomRate.InterfaceID;
                condition.Vendorcodes = new ArrayList { model.VenderCode };
                condition.setLog(true);
                SingleHotelVO hotel;
                try
                {
                    hotel = it.GetEasySingleHotel(condition);
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    return null;
                }

                var roomType = hotel.Singlehotel.Roomtypeinfo;
                if (roomType == null)
                {
                    msg = "该搜寻条件无房，请调整查询时间或房型";
                    return null;
                }
                if (roomType.Count > 1)
                {
                    msg = "异常操作";
                    return null;
                }

                if (roomType[0].Rateplan == null || roomType[0].Rateplan.Count == 0)
                {
                    msg = "异常操作";
                    return null;
                }

                if (roomType[0].Rateplan.Count > 1)
                {
                    msg = "异常操作";
                    return null;
                }


                //注意：以上判断说明的是，客户一次只能订一个房型下的一个计划下的套餐


                //if (!string.Equals(roomType[0].Rateplan[0].Paymentmethod, "S", StringComparison.OrdinalIgnoreCase))
                //{
                //    msg = "本站只支持预付全款，当前价格支付方式不是预付全款";
                //}

                Payment fuKuanFangShi = Payment.预付全款;
                string _paymentmethod = roomType[0].Rateplan[0].Paymentmethod;
                if (!string.IsNullOrEmpty(_paymentmethod) && _paymentmethod.ToLower() == "t")
                {
                    fuKuanFangShi = Payment.前台支付;
                }

                string AvailabilityStatus = roomType[0].Rateplan[0].AvailabilityStatus.ToLower();

                //填充酒店信息（用于界面显示）
                model.Hotel = new MHotel2
                {
                    HotelName = hotel.Singlehotel.Basichotelinfo.HotelNameCN,
                    Star = string.IsNullOrEmpty(hotel.Singlehotel.Basichotelinfo.RankCode) ? new Nullable<HotelStar>() : (HotelStar)((int)Enum.Parse(typeof(Hotel_HotelInfoQueryModel.Star), "_" + hotel.Singlehotel.Basichotelinfo.RankCode)),
                };
                //填充房型信息（用于界面显示）
                model.RommType = new MBaseHotelRoomType
                {
                    IsInternet = string.IsNullOrEmpty(roomType[0].Internet) ? model.RommType.IsInternet : (IsInternet)((int)Enum.Parse(typeof(Hotel_RoomType.InternetType), roomType[0].Internet)),
                    RoomName = roomType[0].Roomtypename,
                    Payment = fuKuanFangShi
                };

                foreach (HotelRoomRate t in roomType[0].Rateplan[0].Roomrate) //注意：项目中的roomrateid和这个无法一一对应
                {
                    MHotelRoomRateBindModel roomRateBindModel = new MHotelRoomRateBindModel
                    {
                        SettlementPrice = EyouSoft.Toolkit.Utils.GetDecimal(t.Price, 0),
                        FeeSetting = feeSetting,
                        Time = new List<DateTime> { DateTime.Parse(t.Date) },
                        PreferentialPrice = EyouSoft.Toolkit.Utils.GetDecimal(t.Price, 0),
                        Breakfast = (string.IsNullOrEmpty(t.Meal) ? roomRate.Breakfast : t.Meal),
                        Status = AvailabilityStatus
                    };
                    roomRateBindModel.Breakfast = BHotel2.TransBreakFastBetweenInterfaceAndSelfProject(roomRateBindModel.Breakfast).ToString();
                    model.RoomRates.Add(roomRateBindModel);
                }
            }
            return model;
        }

    }
}