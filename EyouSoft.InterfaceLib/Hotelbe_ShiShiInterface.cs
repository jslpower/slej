using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.travelsky.hotelbesdk.invoke;
using com.travelsky.hotelbesdk.utils;
using com.travelsky.hotelbesdk.models.easyhotel.orderinfo;
using com.travelsky.hotelbesdk.models.condition;
using com.travelsky.hotelbesdk.models.easyhotel.single;
using com.travelsky.hotelbesdk.models.easyhotel.multi;
using EyouSoft.InterfaceLib.Common;
using com.travelsky.hotelbesdk.models;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Model.HotelStructure.WebModel;

namespace TravelSky.Base.Interface
{
   /// <summary>
   /// 城市，酒店，地标实时数据接口
   /// </summary>
   public class TravelSky_ShiShiInterface
   {
      /// <summary>
      /// 单酒店查询
      /// </summary>
      public SingleHotelVO GetEasySingleHotel(EasySingleHotelReqCondition condition)
      {
         try
         {
            HotelbeReq req = new EasySingleHotelReqImpl();
            req.setBasereqcondition(condition);
            object e = req.send();
            return e as com.travelsky.hotelbesdk.models.easyhotel.single.SingleHotelVO;
         }
         catch (Exception ex) { throw ex; }
      }

      /// <summary>
      /// 多酒店查询
      /// </summary>
      /// <param name="condition"></param>
      /// <returns></returns>
      public MultiHotelVO GetEasyMultiHotel(EasyMultiHotelReqCondition condition)
      {
         HotelbeReq req = new EasyMultiHotelReqImpl();

         req.setBasereqcondition(condition);
         try
         {
            object e = req.send();
            return e as MultiHotelVO;
         }
         catch (HotelbeException e)
         {
            throw e;
         }
      }



      /// <summary>
      /// 预订酒店
      /// </summary>
      /// <returns></returns>
      public string[] HotelOrder(MHotelOrderXiangQing hotelOrder)
      {
         HotelbeReq req = new OrderHotelReqImpl();
         OrderHotelReqCondition condition = new OrderHotelReqCondition();
         //入住日期
         condition.setCheckindate(hotelOrder.CheckInDate.ToString("yyyy-MM-dd"));
         //离店日期
         condition.setCheckoutdate(hotelOrder.CheckOutDate.ToString("yyyy-MM-dd"));
         //酒店代码
         condition.setHotelcode(hotelOrder.Hotel.InterfaceId);
         
         DateTime daodianEarly = DateTime.Parse(hotelOrder.CheckInDate.ToString("yyyy-MM-dd") + " " + hotelOrder.DaoDianShiJian.Insert(2, ":") + ":00");
         DateTime daodianLate = daodianEarly.AddHours(3);

         DateTime now = DateTime.Now;
         if (now > daodianEarly)
         {
            daodianEarly = now.AddHours(1);
            if (now.AddHours(3) >= now.Date.AddDays(1).Date)
            {
               daodianLate = now.Date.AddDays(1).Date.AddSeconds(-1);
            }
            else
            {
               daodianLate = daodianEarly.AddHours(3);
            }
         }
         hotelOrder.DaoDianShiJian = daodianEarly.ToString("HHmm");
         //最早到店时间
         condition.setEarlyarrivetime(hotelOrder.DaoDianShiJian);
         //最晚到店时间 
         condition.setLatearrivetime(daodianLate.ToString("HHmm"));

         //支付方式
         //PAYMENT_COUNTER（前台现付） ，
         //PAYMENT_COMMISSION(代收代付)，
         //PAYMENT_REPAY(预付)，默认为代收代付。
         condition.setPayment("S");
         condition.SpecialRequest = "金奥";

         condition.getContact().setContactemail("");
         condition.getContact().setContactname(hotelOrder.ContactName);
         condition.getContact().setContactmobile(hotelOrder.ContactMobile);

         foreach (MHotelOrderContact contact in hotelOrder.OrderCotact)
         {
            condition.getGuests().Add(contact.ContactName);
         }

         //房型价格
         for (int i = 0; i < hotelOrder.RoomRates.Count; i++)
         {
            RoomPrice roomprice = new RoomPrice();
            roomprice.setRoomtypecode(hotelOrder.RoomRates[i].RoomTypeCode);
            roomprice.setRoomnum(hotelOrder.RoomCount);
            roomprice.setRateplancode(hotelOrder.RoomRates[i].InterfaceID);
            roomprice.setVendorCode(hotelOrder.RoomRates[i].VenderCode);
            //roomprice.setStartdate(hotelOrder.RoomRates[i].StartDate.ToString("yyyy-MM-dd"));
            //roomprice.setEnddate(hotelOrder.RoomRates[i].EndDate.ToString("yyyy-MM-dd"));
            roomprice.setStartdate(hotelOrder.CheckInDate.ToString("yyyy-MM-dd"));
            roomprice.setEnddate(hotelOrder.CheckOutDate.ToString("yyyy-MM-dd"));
            condition.getRoomprices().Add(roomprice);
         }

         condition.setLog(true);
         //担保
         condition.setGuarantee(false);
         //condition.Hotelcreditcardinfo.setCardNum("4367455038977648");
         //condition.Hotelcreditcardinfo.setCardCode(com.travelsky.hotelbesdk.models.easyhotel.order.HotelCreditCardInfo.ENUM_CARDCODE.CODE_JIANSHE);
         //condition.Hotelcreditcardinfo.setCardType(com.travelsky.hotelbesdk.models.easyhotel.order.HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_UP);
         //condition.Hotelcreditcardinfo.setCVV2("648");
         //condition.Hotelcreditcardinfo.setExpireDate("04/22");
         //condition.Hotelcreditcardinfo.setOwnerName("测试");
         //condition.Hotelcreditcardinfo.setIDNum("2012111196402016354");
         //condition.Hotelcreditcardinfo.setIDType(com.travelsky.hotelbesdk.models.easyhotel.order.HotelCreditCardInfo.ENUM_IDTYPE.IDTYPE_ID);
         //condition.Hotelcreditcardinfo.setTel("13812345678");

         req.setBasereqcondition(condition);
         try
         {
            object o = req.send();
            OTResponse response = (OTResponse)o;
            if (response.HotelResRS.Errors != null && response.HotelResRS.Errors.Count > 0)
            {
               string s = "";
               foreach (Error errmsg in response.HotelResRS.Errors)
               {
                  s += "错误信息：" + errmsg.ErrorDesc;
               }
               return new string[2] { "", s };
            }
            if (response.HotelResRS.HotelReservations != null && response.HotelResRS.HotelReservations.Count > 0)
            {
               return new string[] { response.HotelResRS.HotelReservations[0].ResOrderID, response.HotelResRS.HotelReservations[0].ResStatus };
            }
            return null;
         }
         catch (HotelbeException e)
         {
            throw e;
         }
      }

      /// <summary>
      /// 取消酒店订单
      /// </summary>
      public void CancelHotelOrder()
      {
         HotelbeReq req = new CancelOrderReqImpl();
         CancelOrderReqCondition condition = new CancelOrderReqCondition();
         condition.setOrderid("A222VFH");
         condition.setLog(true);
         req.Basereqcondition = condition;
         try
         {
            OTResponse response = (OTResponse)req.send();
            string requestString = req.request;
            string responseString = req.response;
         }
         catch (HotelbeException e)
         {
            throw e;
         }
      }

      /// <summary>
      /// 促销酒店查询
      /// </summary>
      /// <param name="condition"></param>
      /// <returns><城市code,MultiHotelVO></returns>
      public Dictionary<string, MultiHotelVO> GetPromotionHotels(PromotionHotelReqCondition condition)
      {
         try
         {
            HotelbeReq req = new PromotionHotelReqImpl();
            req.setBasereqcondition(condition);
            object e = req.send();
            return Transformer.TransformToDic<string, MultiHotelVO>(e as HashtableSerailizable);
         }
         catch (Exception ex) { throw ex; }

      }

      /// <summary>
      /// 查找订单状态查询
      /// </summary>
      public CheckedInfo GetOrderState(SearchCheckedOrderReqCondition condition)
      {
         HotelbeReq req = new SearchCheckedOrderReqImpl();
         req.setBasereqcondition(condition);
         try
         {
            object e = req.send();
            CheckedInfo response = e as CheckedInfo;
            LogHelper.SystemLog("订单审核查询请求xml=" + req.request);
            LogHelper.SystemLog("订单审核查询返回xml=" + req.response);
            return response;
         }
         catch (HotelbeException e) { throw e; }
      }

      /// <summary>
      /// 订单详细信息查询
      /// </summary>
      public OrderInfo GetOrderInfo(HotelResDetailReqCondition condition)
      {
         HotelbeReq req = new HotelResDetailSearchImpl();
         req.setBasereqcondition(condition);
         try
         {
            object e = req.send();
            LogHelper.SystemLog("订单详细查询请求xml=" + req.request);
            LogHelper.SystemLog("订单详细查询返回xml=" + req.response);
            return e as OrderInfo;
         }
         catch (HotelbeException e)
         {
            throw e;
         }
      }

      /// <summary>
      /// 订单备注信息查询
      /// </summary>
      /// <param name="condition"></param>
      public List<OrderRemarkInfo> GetOrderRemark(OrderRemarkReqCondition condition)
      {
         HotelbeReq req = new HotelResProcessReqImpl();
         req.setBasereqcondition(condition);
         try
         {
            object e = req.send();
            return e as List<OrderRemarkInfo>;
         }
         catch (HotelbeException e)
         {
            throw e;
         }
      }

      /// <summary>
      /// 订单信息概要查询
      /// </summary>
      public List<OrderOutLineInfo> GetHotelOutLine(HotelResOutLineReqCondition condition)
      {
         HotelbeReq req = new HotelResOutLineSearchImpl();
         req.setBasereqcondition(condition);
         try
         {
            object e = req.send();
            return e as List<OrderOutLineInfo>;
         }
         catch (HotelbeException ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// 可定制供应商查询
      /// </summary>
      public void GetVendorEnable()
      {
         //HotelbeReq req = new HotelVendorEnableSearchImpl();
         //HotelVendorEnableSearchCondition hotelVendorEnableSearchCondition = new
         //HotelVendorEnableSearchCondition();
         //hotelVendorEnableSearchCondition.setLog(true);
         //req.setBasereqcondition(hotelVendorEnableSearchCondition);
         //try
         //{
         //    VendorResponse result = req.send();
         //    string res = req.response;
         //    string re = req.request;
         //}
         //catch (HotelbeException e)
         //{
         //    throw e;
         //}
      }

      /// <summary>
      /// 已定制供应商查询
      /// </summary>
      public void Get()
      {
         //HotelbeReq<VendorResponse> req = new HotelVendorSelectedSearchImpl<VendorResponse>();
         //HotelVendorSelectedSearchCondition hotelVendorEnableSearchCondition = new
         //HotelVendorSelectedSearchCondition();
         //hotelVendorEnableSearchCondition.setLog(true);
         //req.setBasereqcondition(hotelVendorEnableSearchCondition);
         //try
         //{
         //    VendorResponse result = req.send();
         //}
         //catch (HotelbeException e)
         //{
         //    throw e;
         //}
      }

      /// <summary>
      /// 国际多酒店查询
      /// </summary>
      public com.travelsky.hotelbesdk.models.easyhotel.i18nmulti.MultiHotelVO GetEasyI18NMultiHotel(EasyI18NMultiHotelReqCondition condition)
      {
         HotelbeReq req = new EasyI18NMultiHotelReqImpl();
         req.setBasereqcondition(condition);
         try
         {
            object e = req.send();
            return e as com.travelsky.hotelbesdk.models.easyhotel.i18nmulti.MultiHotelVO;
         }
         catch (HotelbeException e)
         {
            throw e;
         }
      }

      /// <summary>
      /// 国际单酒店查询
      /// </summary>
      public void GetEasyI18NSingleHotel()
      {
         //HotelbeReq<EasyI18NSingleHotelResponse> req = new EasyI18NSingleHotelReqImpl<EasyI18NSingleHotelResponse>();
         //EasyI18NSingleHotelReqCondition condition = new
         //EasyI18NSingleHotelReqCondition();
         //condition.setCheckindate("2013-05-24");
         //condition.setCheckoutdate("2013-05-25");
         //condition.setHotelcode("USLAS00253");
         //condition.setAdultnum(2);
         //// condition.setBedtype(ENUM_BED.BED_TB);
         //// condition.setChildnum(0);
         ////condition.setRoomnum(1);
         //// condition.setPayment(ENUM_PAYMENT.PAYMENT_ADVANCED);
         //condition.setVendorCode("IHG");
         //condition.setAvailReqType(EasyI18NSingleHotelReqCondition.ENUM_REQ.REQ_INCLUDE);
         //condition.setLog(true);
         //condition.setRatePlanCode("IGCOR");
         //condition.setRoomTypeCode("O1KN");
         //req.setBasereqcondition(condition);
         //try
         //{
         //    EasyI18NSingleHotelResponse multihotelvo = req.send();
         //    string requestString = req.request;
         //    string responseString = req.response;
         //}
         //catch (Exception e)
         //{
         //    throw e;
         //}
      }

      /// <summary>
      /// 酒店代码查询
      /// </summary>
      public void GetMultiHotelCodes()
      {
         //HotelbeReq req = new MultiHotelCodesReqImpl();
         //MultiHotelCodesReqCondition condition = new MultiHotelCodesReqCondition();
         //condition.setCityCode("PEK");
         //condition.setPageSize(10);
         //condition.setPageno(1);
         //condition.setVendorCode("SOHOTO");
         //condition.setLog(true);
         //req.setBasereqcondition(condition); ;
         //try
         //{
         //    OTResponse response = req.send();
         //    // String str1 = HotelbeUtils.Object2Xml(response);
         //    // System.out.println(str);
         //}
         //catch (Hotelbe_Sys_Exception e)
         //{
         //}
         //catch (Hotelbe_Biz_Exception e)
         //{
         //}
      }

      /// <summary>
      /// 查询客户评价接口
      /// </summary>
      public void GetHotelComment()
      {
         //HotelbeReq req = new HotelCommentSearchReqImpl();
         //HotelCommentSearchReqCondition condition = new
         //HotelCommentSearchReqCondition();
         //condition.setHotelCode("SOHOTO3008");
         //condition.setLog(true);
         //req.setBasereqcondition(condition);
         //try
         //{
         //    OTResponse response = req.send();
         //}
         //catch (Hotelbe_Sys_Exception e)
         //{
         //}
      }
      /// <summary>
      /// 查询指定office的支付帐号信息
      /// </summary>
      public void GetPaymentAccount()
      {
         //HotelbeReq req = new PaymentAccountReqImpl();
         //PaymentAccountReqCondition condition = new PaymentAccountReqCondition();
         //condition.setOfficeCode("SOHOTO2");
         //condition.setLog(true);
         //req.setBasereqcondition(condition);
         //try
         //{
         //    OTResponse result = req.send();
         //}
         //catch (Hotelbe_Sys_Exception e)
         //{
         //}
         //catch (Hotelbe_Biz_Exception e)
         //{
         //}

      }

   }
}
