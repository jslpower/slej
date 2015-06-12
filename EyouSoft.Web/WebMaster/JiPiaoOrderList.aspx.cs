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
using Common.page;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Model.JPStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class JiPiaoOrderList : ModelViewPageBase<MSearchDingDan>
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
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.机票订单管理))
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
            string agencyid = Utils.GetQueryStringValue("qudaolist");
            if (agencyid != "-1")
            {
                Model.fenxiaoid = agencyid;
            }
            Model.dingdantype = DingDanType.机票订单;
 
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("StartTime")) && !string.IsNullOrEmpty(Utils.GetQueryStringValue("EndTime")))
            {
                Model.startime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime"));
                Model.endtime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime"));
            }
            else
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("StartTime")))
                {
                    if (Convert.ToDateTime(Utils.GetQueryStringValue("StartTime")) < DateTime.Now)
                    {
                        Model.startime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime"));
                        Model.endtime = DateTime.Now;
                    }
                }
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("EndTime")))
                {
                    if (Convert.ToDateTime(Utils.GetQueryStringValue("EndTime")) > DateTime.Now)
                    {
                        Model.startime = DateTime.Now;
                        Model.endtime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime"));
                    }
                }
            }
            pageIndex = UtilsCommons.GetPagingIndex();
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(pageSize, pageIndex, ref recordCount, Model);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SumLiRun += list[i].JinE - list[i].AgencyJinE;
                    SumMoney += list[i].JinE;
                }
                this.rptList.DataSource = list;
                this.rptList.DataBind();
                Literal1.Visible = false;
            }
            else
            {
                rptList.Visible = false;
                Literal1.Text = "暂无数据";
            }
            this.ExportPageInfo1.intPageSize = pageSize;
            this.ExportPageInfo1.CurrencyPage = pageIndex;
            this.ExportPageInfo1.intRecordCount = recordCount;
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExportPageInfo1.intPageSize = pageSize;
            this.ExportPageInfo1.CurrencyPage = pageIndex;
            this.ExportPageInfo1.intRecordCount = recordCount;
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


        protected string GetStatus(object status, object AgencyId)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)status;
            DingDanStatus type = (DingDanStatus)state;
            switch (type)
            {
                case DingDanStatus.等待支付:
                    return string.Format("<span style='background-color:#906;color:#FFF;'>等待付款</span></a>");
                case DingDanStatus.支付成功:
                    return string.Format("<span style='background-color:#060;color:#FFF;'>等待出票</span>");
                case DingDanStatus.出票成功:
                    return string.Format("  <span  style='background-color:#F08C0C;color:#FFF;'>确认出行</span>");
                default:
                    break;
            }
            //switch (state)
            //{
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
            //        return string.Format(" <span style='background-color:#00F;color:#FFF;'>订单审核</span>");
            //    //return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  >订单审核</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
            //        return string.Format(" <span style='background-color:#906;color:#FFF;'>等待付款</span>");
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
            //        return string.Format(" <span style='background-color:#060;color:#FFF;'>付款成功，<br />请通知出行!</span>");
            //    //return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
            //        return string.Format(" <span  style='background-color:#F08C0C;color:#FFF;'>等待收货</span>");
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
            //        if (!string.IsNullOrEmpty(AgencyId.ToString()) && AgencyId.ToString().Length > 20)
            //        {
            //            return string.Format(" <span style='background-color:#23F111;color:#FFF;'>待返利</span>");
            //        }
            //        else
            //        {
            //            return string.Format(" <span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
            //        }
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
            //        return string.Format(" <span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
            //    case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
            //        return string.Format(" <span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span>");
            //    default:
            //        break;
            //}
            return "";
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
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
            {
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderid, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));

        }

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

        protected string GetOrderName(object orderszm)
        {
            string OrderName = "";
            string[] Szm = orderszm.ToString().Split('-');
            if (Szm.Length > 0)
            {
                OrderName = CityNameBySZM.GetCityNameBySZM(Szm[0].Trim()) + " - " + CityNameBySZM.GetCityNameBySZM(Szm[1].Trim());
            }
            return OrderName;
        }
    }
}
