using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.AccountStructure;
using System.Text;
using EyouSoft.Model.HotelStructure;

namespace EyouSoft.Web.WebMaster
{
   public partial class HotelOrderList : EyouSoft.Common.Page.WebmasterPageBase
   {
      protected int pageIndex = 1, pageSize = 20, RecordCount = 0;
      protected decimal SumMoney = 0;//销售金额
      protected decimal SumAMoney = 0;//分销金额
      protected decimal SumLiRun = 0;//分销利润
      protected string SourceStr = string.Empty;
      protected void Page_Load(object sender, EventArgs e)
      {
         if (UserInfo.LeiXing == 0 && !this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.酒店管理_酒店订单管理))
         {
            ToUrl("/webmaster/default.aspx");
         }

         if (!IsPostBack)
         {
            initList();
         }
         string orderid = Utils.GetQueryStringValue("orderid");
         string dotype = Utils.GetQueryStringValue("dotype");
         if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
      }
      protected string GetSellersHtml()
      {
          StringBuilder strHtml = new StringBuilder();
          BSellers bsells = new BSellers();
          var list = bsells.GetWebSite();
          if (list != null && list.Count > 0)
          {
              if (Utils.GetQueryStringValue("qudaolist") == "0")
              {
                  strHtml.Append("<option value=\"0\" selected=\"selected\">金奥</option>");
              }
              else
              {
                  strHtml.Append("<option value=\"0\" >金奥</option>");
              }
              foreach (var item in list)
              {
                  if (item.ID.ToString().Equals(Utils.GetQueryStringValue("qudaolist")))
                  {
                      strHtml.AppendFormat("<option value=\"{0}\"  selected=\"selected\">{1}</option>",
                          item.ID, item.WebsiteName);
                  }
                  else
                  {
                      strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                          item.ID, item.WebsiteName);
                  }
              }
          }
          return strHtml.ToString();
      }
      private void initList()
      {
         string hotelname = Utils.GetQueryStringValue("hotelName");
         string chktype = Utils.GetQueryStringValue("checkType");
         string startime = Utils.GetQueryStringValue("startTime");
         string endtime = Utils.GetQueryStringValue("endTime");
         string source = Utils.GetQueryStringValue("sltsource");
         string companyname = Utils.GetQueryStringValue("companyname");
         pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
         EyouSoft.Model.HotelStructure.MHotelOrderSeach serchModel = new EyouSoft.Model.HotelStructure.MHotelOrderSeach();
         serchModel.HotelName = hotelname;
         serchModel.SellerID = Utils.GetQueryStringValue("qudaolist");
         if (serchModel.SellerID == "-1")
         {
             serchModel.SellerID = null;
         }
         if (chktype == "1")
         {
            serchModel.BeginCheckInDate = Utils.GetDateTimeNullable(startime);
            serchModel.EndCheckInDate = Utils.GetDateTimeNullable(endtime);
         }
         else
         {
            serchModel.BeginIssueTime = Utils.GetDateTimeNullable(startime);
            serchModel.EndIssueTime = Utils.GetDateTimeNullable(endtime);
         }
         if (!string.IsNullOrEmpty(companyname))
         {
            serchModel.BuyCompanyName = companyname;
         }
         if (source != "" && source != "-1")
         {
            serchModel.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)Utils.GetInt(source);
         }
         serchModel.HotelId = Utils.GetQueryStringValue("hotelid");

         if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
         {
            serchModel.HotelId = UserInfo.GysId;
         }

         BHotelOrder bll = new BHotelOrder();
         IList<EyouSoft.Model.HotelStructure.MHotelOrder> list = bll.GetList(pageSize, pageIndex, ref RecordCount, serchModel);

         if (list != null && list.Count > 0)
         {
            for (int i = 0; i < list.Count; i++)
            {
               SumMoney += list[i].TotalAmount;
               if (list[i].SellerID.ToString().Trim().Length > 20)
               {
                   SumLiRun += list[i].TotalAmount - list[i].AgencyJinE;
                   SumAMoney += list[i].AgencyJinE;
               }
            }
            rpt_list.DataSource = list;
            rpt_list.DataBind();
            BindExportPage();
         }
         SourceStr = EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)), source, "-1", "请选择");
      }
       /// <summary>
       /// 获取该订单的联系人
       /// </summary>
       /// <param name="orderid"></param>
       /// <returns></returns>
      protected string GetContent(string orderid)
      {
          string content = "";
          BHotelOrder bll = new BHotelOrder();
          IList<EyouSoft.Model.HotelStructure.MHotelOrderContact> list = bll.GetContent(orderid);
          if (list != null)
          {
              for (int i = 0; i < list.Count; i++)
              {
                  content += list[i].ContactName +"："+list[i].Mobile+"<br />";
              }
          }
          return content;
      }
      /// <summary>
      /// 返回下单人姓名
      /// </summary>
      /// <param name="memberID"></param>
      /// <returns></returns>
      protected string GetMemberNameByID(object memberID)
      {
          string id = "";
          if (memberID != null)
          {
              id = Utils.GetString(memberID.ToString(), "");
          }
          if (id == "" || id == null) return "金奥";
          BSellers bsells = new BSellers();
          EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
          mseller = bsells.GetWebSiteName(id);
          if (mseller == null) return "金奥";
          EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
          EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
          model = bll.GetModel(mseller.MemberID);
          if (model == null) return "金奥";
          return model.MemberName;

      }

      /// <summary>
      /// 返回网点名称
      /// </summary>
      /// <param name="memberID"></param>
      /// <returns></returns>
      protected string GetWangDianByID(object AgencyId)
      {
          string id = "";
          if (AgencyId != null)
          {
             id = Utils.GetString(AgencyId.ToString(), "");
          }
          if (id == "" || id == null) return "金奥";
          BSellers bsells = new BSellers();
          EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
          mseller = bsells.GetWebSiteName(id);
          if (mseller == null) return "金奥";
          return "<span title=\""+mseller.CompanyName+"\">" + mseller.CompanyJC + "</span><br />" + mseller.WebsiteName;

      }


      protected string GetJinEList(object HotelXC, object RoomCount)
      {
          string JiageList = "";
          if (HotelXC !=null && RoomCount !=null && !string.IsNullOrEmpty(HotelXC.ToString()) && !string.IsNullOrEmpty(RoomCount.ToString()))
          {
              IList<HotelXingCheng> xcmodel = Utils.JsonDeserialize<HotelXingCheng>(HotelXC.ToString());
              if (xcmodel != null && xcmodel.Count > 0)
              {
                  JiageList += "<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'>"
                   + "<tr><td colspan=\"3\" style=\" font-size:16px; font-weight:bold; text-align:center\"> 酒店价格列表 </td></tr>"
                   + "<tr sizcache=\"24\"><th style=\" font-size:13px; font-weight:bold; text-align:center\">日期</th>"
                   + "<td style=\" font-size:13px; font-weight:bold; text-align:center\">金额</td>"
                   + "<td  style=\" font-size:13px; font-weight:bold; text-align:center\">分销金额</td></tr>";
                      
                      ;
                  for (int m = 0; m < xcmodel.Count; m++)
                  {
                      string CBJia = xcmodel[m].ChengBenJia == 0 ? "总站交易" : xcmodel[m].ChengBenJia.ToString("f2") + "元/间/天  *  " +  RoomCount.ToString() + "间 = " + (xcmodel[m].ChengBenJia * Convert.ToInt32(RoomCount)).ToString("f2") + "元/天";

                      JiageList += "<tr><th width=\"146\" height=\"28\" style=\"text-align:center\">" + xcmodel[m].ChenkInDate.ToShortDateString() + "</th><td height=\"28\" width=\"300\"  bgcolor=\"#E3F1FC\" style=\"text-align:center\">" + xcmodel[m].MenShiJia.ToString("f2") + "元/间/天  *  " +  RoomCount.ToString() + "间 = " + (xcmodel[m].MenShiJia *  Convert.ToInt32(RoomCount)).ToString("f2") + "元/天</td><td height=\"28\" width=\"307\"   bgcolor=\"#E3F1FC\" style=\"text-align:center\">" + CBJia + "</td></tr>";
                  }
                  JiageList += "</table>";
              }
          }
          return JiageList;
      }
      

      #region 绑定分页控件
      /// <summary>
      /// 绑定分页控件
      /// </summary>
      protected void BindExportPage()
      {
         this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
         this.ExporPageInfoSelect1.intPageSize = pageSize;
         this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
         this.ExporPageInfoSelect1.intRecordCount = RecordCount;
         this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
      }
      #endregion
      /// <summary>
      /// 初始化操作
      /// </summary>
      /// <param name="orderid"></param>
      /// <param name="setState"></param>
      /// <returns></returns>
      protected string setOptClick(string orderid, object setState, object AgencyId)
      {
          EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)setState;
          switch (state)
          {
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                  return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  ><span style='background-color:#00F;color:#FFF;'>订单审核</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
              //return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  >订单审核</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                  //return string.Format("  <span style='background-color:#906;color:#FFF;'>等待付款</span>");
                  return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  ><span style='background-color:#906;color:#FFF;'>已线下收款</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货);
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                  return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  ><span style='background-color:#060;color:#FFF;'>付款成功，<br />请通知出行!</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
              //return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                  return string.Format("  <span  style='background-color:#F08C0C;color:#FFF;'>等待收货</span>");
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                  if (!string.IsNullOrEmpty(AgencyId.ToString().Trim()) && AgencyId.ToString() != "0")
                  {
                      return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  ><span style='background-color:#F00;color:#FFF;'>确认出行,<br />现在返利</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成);
                  }
                  else
                  {
                      return string.Format("<span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                  }
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                  return string.Format("<span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                  return string.Format("<a href='HotelOrderEdit.aspx?id=" + orderid + "&dotype=show'><span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span></a>");
              default:
                  break;
          }
          return "";
      }
      /// <summary>
      /// 删除订单
      /// </summary>
      /// <param name="orderid"></param>
      /// <param name="setState"></param>
      /// <returns></returns>
      protected string DeleteUserOrder(string orderid, object setState)
      {
          EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)setState;
          switch (state)
          {
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                  return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}');\";  ><span style='background-color:#C00;color:#FFF;'>取消订单</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
              default:
                  break;
          }
          return "";
      }
      /// <summary>
      /// 设置订单状态
      /// </summary>
      void setOrderState()
      {
          string orderid = Utils.GetQueryStringValue("id");
          EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)Utils.GetInt(Utils.GetQueryStringValue("state"));

          BHotel bll = new BHotel();
          int result = bll.SheZhiOrderStatus(orderid, state);
          if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
          {
              insertDetial(orderid);
              new EyouSoft.BLL.HotelStructure.BHotelOrder().SheZhiZhiFus(new EyouSoft.Model.HotelStructure.MHotelOrder() { PaymentState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.OrderState.订单出货, OrderId = orderid });
          }
          if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成)
          {
              DingDanFanLi(orderid);
              /*
              #region 返利供应商
              var order = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(orderid);
              if (order != null)
              {
                  var semodel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(order.SellerID);
                  if (semodel != null)
                  {
                      var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(semodel.MemberID);
                      if (member != null)
                      {
                          decimal fanlijine = Convert.ToDecimal(order.TotalAmount) - order.AgencyJinE + member.TotalMoney.Value;
                          //int count = new EyouSoft.BLL.MemberStructure.BMember().UpdateMoney(semodel.MemberID, fanlijine);
                          EyouSoft.Model.MoneyStructure.MAccount macc = new EyouSoft.Model.MoneyStructure.MAccount();
                          macc.Amounts = Convert.ToDecimal(order.TotalAmount) - order.AgencyJinE;//交易金额
                          macc.balance = fanlijine;//剩余金额
                          macc.OrderID = orderid;//订单编号
                          macc.OrderType = EyouSoft.Model.Enum.DingDanLeiBie.酒店订单;//订单类型
                          macc.TransactionCate = EyouSoft.Model.Enum.TCate.返利;//交易类别
                          macc.TransactionDesc = "";//描述
                          int count = new EyouSoft.BLL.MoneyStructure.BAccount().GetAccountNum(EyouSoft.Model.Enum.TCate.返利);
                          string bianhao = "";
                          if (count >= 0 && count < 9)
                          {
                              bianhao = "000" + (count + 1);
                          }
                          else if (count >= 9 && count < 99)
                          {
                              bianhao = "00" + (count + 1);
                          }
                          else if (count >= 99 && count < 999)
                          {
                              bianhao = "0" + (count + 1);
                          }
                          else
                          {
                              bianhao = (count + 1).ToString();
                          }
                          macc.TransactionID = "FL" + DateTime.Now.ToString("yyyyMMddHHmmss") + bianhao;//交易号
                          macc.TransactionState = EyouSoft.Model.Enum.TStatus.交易成功;
                          macc.TransactionTime = DateTime.Now;
                          macc.TransactionWay = EyouSoft.Model.Enum.ChongZhiWay.返利;
                          macc.UserId = member.MemberID;
                          macc.TranUserId = order.SellerID;
                          new EyouSoft.BLL.MoneyStructure.BAccount().Add(macc);
                      }

                  }

              }
              #endregion
              */
          }
          if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
          {
              new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderid, EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
          }
          RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
      }

      protected string GetFuKuangCate(object orderid, object orderstate)
      {
          string FuKuangCate = "<span style=\"color:red;\">暂未付款</span>";
          EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)orderstate;
          switch (state)
          {
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                  FuKuangCate = "<span style=\"color:red;\">暂未付款</span>";
                  break;
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
              case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                  FuKuangCate = "<span style=\"color:#00F;\">" + new EyouSoft.BLL.MemberStructure.BMember().GetZhiFuWay(orderid.ToString()) + "</span>";
                  break;
              default:
                  break;
          }
          
          return FuKuangCate;
      }

      /// <summary>
      /// 订单返利
      /// </summary>
      /// <param name="dingDanId">订单编号</param>
      void DingDanFanLi(string dingDanId)
      {
          var dingDanInfo = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(dingDanId);
          if (dingDanInfo == null) return;
          var huiYuanDaiLiShangInfo = new EyouSoft.BLL.OtherStructure.BMember().GetHuiYuanDaiLiShangInfoByDaiLiShangId(dingDanInfo.SellerID);
          if (huiYuanDaiLiShangInfo == null) return;

          var fanLiInfo = new EyouSoft.Model.OtherStructure.MDingDanFanLiInfo();
          fanLiInfo.DingDanId = dingDanId;
          fanLiInfo.DingDanJinE = dingDanInfo.TotalAmount;
          fanLiInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.酒店订单;
          fanLiInfo.FanLiJinE = dingDanInfo.TotalAmount - dingDanInfo.AgencyJinE;
          fanLiInfo.FenXiaoJinE = dingDanInfo.AgencyJinE;
          fanLiInfo.HuiYuanId = huiYuanDaiLiShangInfo.HuiYuanId;
          fanLiInfo.IssueTime = DateTime.Now;

          new EyouSoft.BLL.OtherStructure.BDingDanFanLi().DingDanFanLi_C(fanLiInfo);
      }

      /// <summary>
      /// 写入交易记录
      /// </summary>
      /// <param name="orderid">订单编号</param>
      /// <param name="dingdanleixing">订单类型</param>
      /// <param name="jiaoyi"></param>
      bool insertDetial(string orderid)
      {
          var info = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
          info.ApiJiaoYiHao = string.Empty;
          info.DingDanId = orderid;
          info.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.酒店订单;
          info.JiaoYiHao = string.Empty;
          info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
          info.JiaoYiMiaoShu = string.Empty;
          info.JiaoYiShiJian = DateTime.Now;
          info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
          info.MingXiId = string.Empty;
          info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.线下支付;

          var dingDanInfo = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(orderid);
          if (dingDanInfo != null)
          {
              info.JiaoYiHao = dingDanInfo.OrderCode;
              info.JiaoYiJinE = dingDanInfo.TotalAmount;
              info.HuiYuanId = dingDanInfo.OperatorId;
          }

          return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
      }

   }
}
