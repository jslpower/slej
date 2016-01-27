using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;
using System.Text;

namespace EyouSoft.Web.WebMaster
{
    public partial class OrderList : EyouSoft.Common.Page.WebmasterPageBase
    {

        #region 页面变量
        protected int pageSize = 20, pageIndex = 1, recordCount = 0;
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        protected EyouSoft.Model.Enum.FeeTypes feetype = EyouSoft.Model.Enum.FeeTypes.周边线路;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.线路产品管理_订单管理))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string orderid = Utils.GetQueryStringValue("orderid");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            //if (orderid != "" && dotype == "cencer")
            //{
            //    Response.Clear();
            //    Response.Write(cencerDate(orderid));
            //    Response.End();
            //}
            InitPage();

        }
        protected string GetSellersHtml()
        {
            StringBuilder strHtml = new StringBuilder();
            BSellers bsells = new BSellers();
            var list = bsells.GetWebSite();
            if (list != null && list.Count > 0)
            {
                if (Utils.GetQueryStringValue("qudaoS") == "0")
                {
                    strHtml.Append("<option value=\"0\" selected=\"selected\">金奥</option>");
                }
                else
                {
                    strHtml.Append("<option value=\"0\" >金奥</option>");
                }
                foreach (var item in list)
                {
                    if (item.ID.ToString().Equals(Utils.GetQueryStringValue("qudaoS")))
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
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void InitPage()
        {

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            #region 查询实体
            EyouSoft.Model.XianLuStructure.MOrderChaXunInfo serchModel = new EyouSoft.Model.XianLuStructure.MOrderChaXunInfo();
            string type = Utils.GetQueryStringValue("type");
            serchModel.SXiaDanTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("startE"));
            serchModel.EXiaDanTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("endE"));
            if (serchModel.EXiaDanTime != null)
            {
                serchModel.EXiaDanTime = Convert.ToDateTime(serchModel.EXiaDanTime).AddDays(1);
            }
            serchModel.OrderStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus), Utils.GetQueryStringValue("orderS"));
            serchModel.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus), Utils.GetQueryStringValue("payS"));
            serchModel.OrderCode = Utils.GetQueryStringValue("orderCode");
            serchModel.AgencyId = Utils.GetQueryStringValue("qudaoS");
            if (!string.IsNullOrEmpty(type))
            {
                if (type == "3")
                {
                    serchModel.RouteType = EyouSoft.Model.Enum.AreaType.周边短线;
                    feetype = EyouSoft.Model.Enum.FeeTypes.周边线路;
                }
                else if (type == "1")
                {
                    serchModel.RouteType = EyouSoft.Model.Enum.AreaType.国内长线;
                    feetype = EyouSoft.Model.Enum.FeeTypes.国内线路;
                }
                else if (type == "2")
                {
                    serchModel.RouteType = EyouSoft.Model.Enum.AreaType.出境线路;
                    feetype = EyouSoft.Model.Enum.FeeTypes.国际线路;
                }
                else
                {
                    serchModel.RouteType = EyouSoft.Model.Enum.AreaType.周边短线;
                    feetype = EyouSoft.Model.Enum.FeeTypes.周边线路;
                }
            }
            if (serchModel.AgencyId == "-1")
            {
                serchModel.AgencyId = null;
            }
            serchModel.XiaDanRenName = Utils.GetQueryStringValue("orderMan");
            string tuangouid = Utils.GetQueryStringValue("tuangouId");
            if (tuangouid != "")
                serchModel.TuanGouId = tuangouid;
            #endregion


            EyouSoft.BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
            IList<EyouSoft.Model.XianLuStructure.MOrderInfo> list = bll.GetOrders(pageSize, pageIndex, ref recordCount, serchModel);

            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AgencyId.ToString().Trim().Length > 20)
                {
                    SumAMoney += list[i].AgencyJinE;
                    SumLiRun += list[i].JinE - list[i].AgencyJinE
                        ;
                }
                SumMoney += list[i].JinE;
            }
            rpt_orders.DataSource = list;
            rpt_orders.DataBind();
            BindPage();


        }
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        }

        /// <summary>
        /// 返回线路名称
        /// </summary>
        /// <param name="xianluID"></param>
        /// <returns></returns>
        protected string GetXianLuNameByID(object xianluID)
        {
            string id = Utils.GetString(xianluID.ToString(), "");
            if (id == "" || id == null) return "";
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuInfo model = new EyouSoft.Model.XianLuStructure.MXianLuInfo();
            model = bll.GetInfo(id);
            if (model == null) return "";
            return model.RouteName;

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
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(id);
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
            return "<span title=\"" + mseller.CompanyName + "\">" + mseller.CompanyJC + "</span><br />" + mseller.WebsiteName;


        }

        /// <summary>
        /// 返回分销金额
        /// </summary>
        /// <param name="feetype">线路类型</param>
        /// <param name="JSJ">结算价</param>
        /// <param name="SCJ">门市价</param>
        /// <param name="AgencyId">分销商id</param>
        /// <returns></returns>
        protected decimal GetDengJiByID(EyouSoft.Model.Enum.FeeTypes feetype,object JSJ, object SCJ, object AgencyId)
        {
            string id = "";
            if (AgencyId != null)
            {
                id = Utils.GetString(AgencyId.ToString(), "");
            }
            if (id == "" || id == null) return Convert.ToDecimal(JSJ);
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
            mseller = bsells.GetWebSiteName(id);
            if (mseller == null) return Convert.ToDecimal(JSJ);
            
           return  UtilsCommons.GetGYStijia(feetype, Convert.ToDecimal(JSJ), Convert.ToDecimal(SCJ), mseller.DengJi);
        }
        ///// <summary>
        ///// 取消订单
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //private string cencerDate(string id)
        //{
        //    string msg = string.Empty;
        //    EyouSoft.BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
        //    EyouSoft.Model.XianLuStructure.MOrderHistoryInfo model = new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo();
        //    model.OperatorId = UserInfo.UserId.ToString();
        //    model.OrderId = id;
        //    int result = 0;
        //    result = bll.SheZhiOrderStatus(id, UserInfo.UserId.ToString(), EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理, model);
        //    switch (result)
        //    {
        //        case 1:
        //            msg = Utils.AjaxReturnJson("1", "已取消!");
        //            break;
        //        default:
        //            msg = Utils.AjaxReturnJson("0", "取消失败!");
        //            break;
        //    }
        //    return msg;
        //}
        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="setState"></param>
        /// <returns></returns>
        protected string setOptClick(string orderid, object setState,object AgencyId)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)setState;
            switch (state)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  ><span style='background-color:#00F;color:#FFF;'>订单审核</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                //return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  >订单审核</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    //return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span style='background-color:#906;color:#FFF;'>马上付款</span></a>", orderid, (int)EyouSoft.Model.Enum.DingDanLeiBie.线路订单, HuiYuanInfo.UserId);
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  ><span style='background-color:#906;color:#FFF;'>已线下收款</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货);
                    //return string.Format("  <span style='background-color:#906;color:#FFF;'>等待付款</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  ><span style='background-color:#060;color:#FFF;'>付款成功，<br />请通知出行!</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                //return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    return string.Format("  <span  style='background-color:#F08C0C;color:#FFF;'>等待出行</span>");
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
                    return string.Format("<a href='javascript:;' class='info' data-id='" + orderid + "'><span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span></a>");
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

            int result = new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiOrderStatus(orderid, state, new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo() { OperatorId = UserInfo.UserId.ToString() });
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            {
                insertDetial(orderid);
                new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiZhiFus(new EyouSoft.Model.XianLuStructure.MOrderInfo() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = orderid });
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成)
            {
                DingDanFanLi(orderid);
                /*
                #region 返利供应商
                var order = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(orderid);
                if (order != null)
                {
                    var semodel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(order.AgencyId);
                    if (semodel != null)
                    {
                        var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(semodel.MemberID);
                        if (member != null)
                        {
                            decimal fanlijine = order.JinE - order.AgencyJinE + member.TotalMoney.Value;
                            //int count = new EyouSoft.BLL.MemberStructure.BMember().UpdateMoney(member.MemberID, fanlijine);
                            EyouSoft.Model.MoneyStructure.MAccount macc = new EyouSoft.Model.MoneyStructure.MAccount();
                            macc.Amounts = Convert.ToDecimal(order.JinE) - order.AgencyJinE;//交易金额
                            macc.balance = fanlijine;//剩余金额
                            macc.OrderID = orderid;//订单编号
                            macc.OrderType = EyouSoft.Model.Enum.DingDanLeiBie.线路订单;//订单类型
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
                            macc.TranUserId = order.AgencyId;
                            new EyouSoft.BLL.MoneyStructure.BAccount().Add(macc);
                        }

                    }

                }
                #endregion
                */
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
            {
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderid, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }


        /// <summary>
        /// 订单返利
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        void DingDanFanLi(string dingDanId)
        {
            var dingDanInfo = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(dingDanId);
            if (dingDanInfo == null) return;
            var huiYuanDaiLiShangInfo = new EyouSoft.BLL.OtherStructure.BMember().GetHuiYuanDaiLiShangInfoByDaiLiShangId(dingDanInfo.AgencyId);
            if (huiYuanDaiLiShangInfo == null) return;

            var dingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.出境订单;
            if (dingDanInfo.RouteType == EyouSoft.Model.Enum.AreaType.出境线路)
            {
                dingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.出境订单;
            }
            else if (dingDanInfo.RouteType == EyouSoft.Model.Enum.AreaType.国内长线)
            {
                dingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.长线订单;
            }
            else if (dingDanInfo.RouteType == EyouSoft.Model.Enum.AreaType.周边短线)
            {
                dingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.短线订单;
            }

            var fanLiInfo = new EyouSoft.Model.OtherStructure.MDingDanFanLiInfo();
            fanLiInfo.DingDanId = dingDanId;
            fanLiInfo.DingDanJinE = dingDanInfo.JinE;
            fanLiInfo.DingDanLeiXing = dingDanLeiXing;
            fanLiInfo.FanLiJinE = dingDanInfo.JinE - dingDanInfo.AgencyJinE;
            fanLiInfo.FenXiaoJinE = dingDanInfo.AgencyJinE;
            fanLiInfo.HuiYuanId = huiYuanDaiLiShangInfo.HuiYuanId;
            fanLiInfo.IssueTime = DateTime.Now;

            new EyouSoft.BLL.OtherStructure.BDingDanFanLi().DingDanFanLi_C(fanLiInfo);
        }
        /// <summary>
        /// 获取付款方式
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <param name="orderstate">订单状态</param>
        /// <returns></returns>
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
            info.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.线路订单;
            info.JiaoYiHao = string.Empty;
            info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
            info.JiaoYiMiaoShu = string.Empty;
            info.JiaoYiShiJian = DateTime.Now;
            info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
            info.MingXiId = string.Empty;
            info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.线下支付;

            var dingDanInfo = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(orderid);
            if (dingDanInfo != null)
            {
                info.JiaoYiHao = dingDanInfo.OrderCode;
                info.JiaoYiJinE = dingDanInfo.JinE;
                info.HuiYuanId = dingDanInfo.OperatorId;
            }

            return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
        }

    }
}
