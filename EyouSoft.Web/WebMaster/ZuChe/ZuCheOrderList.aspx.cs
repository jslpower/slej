using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.BLL.ZuCheStructure;
using System.Text;

namespace EyouSoft.Web.WebMaster.ZuChe
{
    public partial class ZuCheOrderList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页变量
        protected int pageSize = 20, pageIndex = 1, recordCount = 0, SumCount = 0;
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        #endregion
        protected string StrOrderStatus = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageInit();
            }
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.租车订单管理))
            {
                ToUrl("/webmaster/default.aspx");
            }
            string orderid = Utils.GetQueryStringValue("orderid");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            
            
        }

        protected string GetSellersHtml(string selectItem)
        {
            StringBuilder strHtml = new StringBuilder();
            BSellers bsells = new BSellers();
            var list = bsells.GetWebSite();
            if (list != null && list.Count > 0)
            {
                if (selectItem == "0")
                {
                    strHtml.Append("<option value=\"0\" selected=\"selected\">金奥</option>");
                }
                else
                {
                    strHtml.Append("<option value=\"0\" >金奥</option>");
                }
                foreach (var item in list)
                {
                    if (item.ID.ToString().Equals(selectItem))
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


        private void PageInit()
        {
            string status = Utils.GetQueryStringValue("orderstatus");
            StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), status.ToString(), true, "-1", "请选择");

            EyouSoft.Model.ZuCheStructure.MZuCheOrderChaXun searchModel = new EyouSoft.Model.ZuCheStructure.MZuCheOrderChaXun();
            EyouSoft.BLL.ZuCheStructure.BZuCheOrder bll = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder();
            searchModel.SXiaDanTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));
            searchModel.EXiaDanTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime"));
            if (searchModel.EXiaDanTime.HasValue)
            {
                searchModel.EXiaDanTime = Convert.ToDateTime(searchModel.EXiaDanTime).AddDays(1);
            }
            searchModel.OrderStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus), Utils.GetQueryStringValue("orderstatus"));
            searchModel.OrderCode = Utils.GetQueryStringValue("txtOrderCode");
            searchModel.CarName = Utils.GetQueryStringValue("CarName");
            searchModel.AgencyId = Utils.GetQueryStringValue("qudaolist");
            if (searchModel.AgencyId == "-1")
            {
                searchModel.AgencyId = null;
            }
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            var list= bll.GetOrders(pageSize, pageIndex, ref recordCount, searchModel);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SumMoney = SumMoney + Convert.ToDecimal(list[i].ZuJin);
                    if (list[i].AgencyId.ToString().Trim().Length > 20)
                    {
                        SumAMoney += list[i].AgencyJinE;
                        SumLiRun += Convert.ToDecimal(list[i].ZuJin) - list[i].AgencyJinE;
                    }
                }
                this.rpt_orders.DataSource = list;
                this.rpt_orders.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='10' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion

        protected string GetOpeartor(object obj)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)obj;
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            if (status != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理)
            {
                str.AppendFormat("<a href='javascript:;' class='update'>修改</a>");
            }
            return str.ToString();
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
            return "<span title=\"" + mseller.CompanyName + "\">" + mseller.CompanyJC + "</span><br />" + mseller.WebsiteName;

        }


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
                    return string.Format("<a href='javascript:;' class='info'><span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span></a>");
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
            BZuChe bll = new BZuChe();
            int result = bll.SheZhiOrderStatus(orderid, state);
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            {
                insertDetial(orderid);
                new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().SheZhiZhiFus(new EyouSoft.Model.ZuCheStructure.MZuCheOrder() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = orderid });
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成)
            {
                DingDanFanLi(orderid);
                /*
                #region 返利供应商
                var order = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(orderid);
                if (order != null)
                {
                    var semodel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(order.AgencyId);
                    if (semodel != null)
                    { 
                        var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(semodel.MemberID);
                    if (member != null)
                    {
                        decimal fanlijine = Convert.ToDecimal(order.ZuJin) - order.AgencyJinE + member.TotalMoney.Value;
                        //int count = new EyouSoft.BLL.MemberStructure.BMember().UpdateMoney(semodel.MemberID, fanlijine);
                        EyouSoft.Model.MoneyStructure.MAccount macc = new EyouSoft.Model.MoneyStructure.MAccount();
                        macc.Amounts = Convert.ToDecimal(order.ZuJin) - order.AgencyJinE;//交易金额
                        macc.balance = fanlijine;//剩余金额
                        macc.OrderID = orderid;//订单编号
                        macc.OrderType = EyouSoft.Model.Enum.DingDanLeiBie.租车订单;//订单类型
                        macc.TransactionCate = EyouSoft.Model.Enum.TCate.返利;//交易类别
                        macc.TransactionDesc = "";//描述
                        int count = new EyouSoft.BLL.MoneyStructure.BAccount().GetAccountNum(EyouSoft.Model.Enum.TCate.返利);
                        string bianhao = "";
                        if (count>=0 && count<9)
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
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderid, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));

        }
        /// <summary>
        /// 删除未审核订单
        /// </summary>
        //void DeleteThisOrder()
        //{
        //    string orderid = Utils.GetQueryStringValue("id");
        //    int result = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().DeleteOrder(orderid);
        //    if (result > 0)
        //    {
        //        RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        //    }
        //    else 
        //    {
        //        RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败，请重试"));
        //    }
        //}

        /// <summary>
        /// 订单返利
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        void DingDanFanLi(string dingDanId)
        {
            var dingDanInfo = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(dingDanId);
            if (dingDanInfo == null) return;
            var huiYuanDaiLiShangInfo = new EyouSoft.BLL.OtherStructure.BMember().GetHuiYuanDaiLiShangInfoByDaiLiShangId(dingDanInfo.AgencyId);
            if (huiYuanDaiLiShangInfo == null) return;

            var fanLiInfo = new EyouSoft.Model.OtherStructure.MDingDanFanLiInfo();
            fanLiInfo.DingDanId = dingDanId;
            fanLiInfo.DingDanJinE = dingDanInfo.ZuJin.Value;
            fanLiInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.租车订单;
            fanLiInfo.FanLiJinE = dingDanInfo.ZuJin.Value - dingDanInfo.AgencyJinE;
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
            info.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.租车订单;
            info.JiaoYiHao = string.Empty;
            info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
            info.JiaoYiMiaoShu = string.Empty;
            info.JiaoYiShiJian = DateTime.Now;
            info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
            info.MingXiId = string.Empty;
            info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.线下支付;

            var dingDanInfo = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(orderid);
            if (dingDanInfo != null)
            {
                info.JiaoYiHao = dingDanInfo.OrderCode;
                info.JiaoYiJinE = Convert.ToDecimal(dingDanInfo.ZuJin);
                info.HuiYuanId = dingDanInfo.OperatorId;
            }

            return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
        }
    }
}
