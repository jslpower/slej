using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.GDWX.Interface;
using EyouSoft.InterfaceLib.Models.GDWX;
using EyouSoft.InterfaceLib.Response.GDWX;
using EyouSoft.InterfaceLib.Request.GDWX;
using EyouSoft.InterfaceLib.Common;
using System.Configuration;
namespace EyouSoft.InterfaceLib.GDWX.Lib
{
   /// <summary>
   /// 光大微信接口
   /// </summary>
   public class GDWXSeeker
   {
      /// <summary>
      /// 接口地址
      /// </summary>
      public string InterfaceAddress
      {
         get
         {
            return System.Configuration.ConfigurationManager.AppSettings["GDWXAddress"];
         }
      }

      /// <summary>
      /// 获取线路列表
      /// </summary>
      /// <returns></returns>
      public GetXianLuListResponse GetXianLuList(GetXianLuListRequest request)
      {
         return WebInvoker.Invoke<GetXianLuListRequest, GetXianLuListResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 获取线路分类
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetXianLuFenLeiListResponse GetXianLuFenLeiList(GetXianLuFenLeiRquest request)
      {
         return WebInvoker.Invoke<GetXianLuFenLeiRquest, GetXianLuFenLeiListResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 获取线路详细
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetXianLuXiangXiResponse GetXianLuXiangXi(GetXianLuXiangXiRequest request)
      {
         return WebInvoker.Invoke<GetXianLuXiangXiRequest, GetXianLuXiangXiResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 路线预订
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public int LuXianYuDing(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo, EyouSoft.Model.XianLuStructure.MOrderInfo OrderInfo)
      {
          LuXianYuDingRequest request = new LuXianYuDingRequest();
          
          request.usercd = ConfigurationManager.AppSettings["GDWXLoginName"];
          request.authno = ConfigurationManager.AppSettings["GDWXPassword"];
          request.querytype = "lineorder";
          request.type = EyouSoft.InterfaceLib.Enums.GDWX.DengluLeiXing.同行;
          request.tourid = Convert.ToInt32(OrderInfo.TrafficId);
          request.password = ConfigurationManager.AppSettings["GDWXOrderPassword"];
          request.username = ConfigurationManager.AppSettings["GDWXOrderName"];
          request.order_name = OrderInfo.LxrName;
          request.order_tel = OrderInfo.LxrTelephone;
          request.order_content = OrderInfo.XiaDanBeiZhu;
          request.num1 = OrderInfo.ChengRenShu;
          request.num2 = OrderInfo.ErTongShu;

          var result = WebInvoker.Invoke<LuXianYuDingRequest, LuXianYuDingResponse>(InterfaceAddress, request);


          if (result.success == EyouSoft.InterfaceLib.Enums.GDWX.Success.成功)
          {
              OrderInfo.Api_OrderId = result.data[0].id.ToString();
          }

          return Convert.ToInt32(OrderInfo.Api_OrderId);
      }
      /// <summary>
      /// 用户登录
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public YongHuDengLuResponse YongHuDengLu(YongHuDengLuRequest request)
      {
         return WebInvoker.Invoke<YongHuDengLuRequest, YongHuDengLuResponse>(InterfaceAddress, request);

      }
      /// <summary>
      /// 修改订单
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public XiuGaiDingDanResponse XiuGaiDingDan(XiuGaiDingDanRequest request)
      {
         return WebInvoker.Invoke<XiuGaiDingDanRequest, XiuGaiDingDanResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 取消订单
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public QuXiaoDingDanResponse QuXiaoDingDan(QuXiaoDingDanRequest request)
      {
         return WebInvoker.Invoke<QuXiaoDingDanRequest, QuXiaoDingDanResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 签证国家
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetQianZhengGuoJiaResponse GetQianZhengGuoJia(GetQianZhengGuoJiaRequest request)
      {
         return WebInvoker.Invoke<GetQianZhengGuoJiaRequest, GetQianZhengGuoJiaResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 签证列表
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetQianZhengListResponse GetQianZhengList(GetQianZhengListRequest request)
      {
         return WebInvoker.Invoke<GetQianZhengListRequest, GetQianZhengListResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 签证详细
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetQianZhengXiangXiResponse GetQianZhengXiangXi(GetQianZhengXiangXiRequest request)
      {
         return WebInvoker.Invoke<GetQianZhengXiangXiRequest, GetQianZhengXiangXiResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 签证预订
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public QianZhengYuDingResponse QianZhengYuDing(QianZhengYuDingRequest request)
      {
         return WebInvoker.Invoke<QianZhengYuDingRequest, QianZhengYuDingResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 签证订单详细
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetQianZhengDingDanXiangXigResponse GetQianZhengDingDanXiangXi(GetQianZhengDingDanXiangXiRequest request)
      {
         return WebInvoker.Invoke<GetQianZhengDingDanXiangXiRequest, GetQianZhengDingDanXiangXigResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 修改签证订单
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public XiuGaiQianZhengDingDanResponse XiuGaiQianZhengDingDan(XiuGaiQianZhengDingDanRequest request)
      {
         return WebInvoker.Invoke<XiuGaiQianZhengDingDanRequest, XiuGaiQianZhengDingDanResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 取消签证订单
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public QuXiaoQianZhengDingDanResponse QuXiaoQianZhengDingDan(QuXiaoQianZhengDingDanRequest request)
      {
         return WebInvoker.Invoke<QuXiaoQianZhengDingDanRequest, QuXiaoQianZhengDingDanResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 团购列表
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetTuanGouListResponse GetTuanGouList(GetTuanGouListRequest request)
      {
         return WebInvoker.Invoke<GetTuanGouListRequest, GetTuanGouListResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 团购详细
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GetTuanGouXiangXiResponse GetTuanGouXiangXi(GetTuanGouXiangXiRequest request)
      {
         return WebInvoker.Invoke<GetTuanGouXiangXiRequest, GetTuanGouXiangXiResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 量身定制
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public LiangShenDingZhiResponse LiangShenDingZhi(LiangShenDingZhiRequest request)
      {
         return WebInvoker.Invoke<LiangShenDingZhiRequest, LiangShenDingZhiResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 量身订制详细
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public LiangShenDingZhiXiangXiResponse LiangShenDingZhiXiangXi(LiangShenDingZhiXiangXiRequest request)
      {
         return WebInvoker.Invoke<LiangShenDingZhiXiangXiRequest, LiangShenDingZhiXiangXiResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 公告中心
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GongGaoZhongXinResponse GongGaoZhongXin(GongGaoZhongXinRequest request)
      {
         return WebInvoker.Invoke<GongGaoZhongXinRequest, GongGaoZhongXinResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 公告中心详细
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      public GongGaoZhongXinXiangXiResponse GongGaoZhongXinXiangXi(GongGaoZhongXinXiangXiRequest request)
      {
         return WebInvoker.Invoke<GongGaoZhongXinXiangXiRequest, GongGaoZhongXinXiangXiResponse>(InterfaceAddress, request);
      }
      /// <summary>
      /// 联系我们
      /// </summary>
      public LianXiWoMenResponse LianXiWoMen(LianXiWoMenRequest request)
      {
         return WebInvoker.Invoke<LianXiWoMenRequest, LianXiWoMenResponse>(InterfaceAddress, request);
      }
   }
}
