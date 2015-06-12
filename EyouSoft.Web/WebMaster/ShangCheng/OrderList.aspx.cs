using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.MallStructure;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;
using System.Text;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class OrderList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex, recordCount, pageSize = 20;
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            initList();
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
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            var searchModel = new EyouSoft.Model.MallStructure.MShangChengDingDanSer();
            searchModel.OrderCode = Utils.GetQueryStringValue("CName");
            searchModel.OrderState = (EyouSoft.Model.Enum.OrderState?)Utils.GetIntNull(Utils.GetQueryStringValue("ddlType"));
            searchModel.GYSid = UserInfo.GysId;
            searchModel.SupplierID = Utils.GetQueryStringValue("qudaolist");
            if (searchModel.SupplierID == "-1")
            {
                searchModel.SupplierID = null;
            }
            var list = new BShangChengDingDan().GetList(pageSize, pageIndex, ref recordCount, searchModel);

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].SupplierID.ToString().Trim().Length > 20)
                    {
                        SumAMoney += list[i].SupplierMoney;
                        SumLiRun += list[i].OrderPrice - list[i].SupplierMoney;
                    }
                    SumMoney += list[i].OrderPrice;
                }
                rptList.DataSource = list;
                rptList.DataBind();
                BindExportPage();
            }
            else
            {
                litNoMsg.Text = "<tr><td align='center' colspan='10'>暂无数据</td></tr>";
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
        /// <summary>
        ///  显示操作选项
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected bool IsVisiableDel(object obj)
        {
            EyouSoft.Model.Enum.PaymentState state = (EyouSoft.Model.Enum.PaymentState)obj;
            if (state == EyouSoft.Model.Enum.PaymentState.已支付) return false;
            return true;

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
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{1}')\";  ><span style='background-color:#00F;color:#FFF;'>订单审核</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                //return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  >订单审核</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    //return string.Format("  <span style='background-color:#906;color:#FFF;'>等待付款</span>");
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{1}')\";  ><span style='background-color:#906;color:#FFF;'>已线下收款</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span style='background-color:#060;color:#FFF;'>付款成功，<br />请等待收货!</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                //return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    return string.Format("  <span  style='background-color:#F08C0C;color:#FFF;'>等待收货</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                    if (!string.IsNullOrEmpty(AgencyId.ToString().Trim()) && AgencyId.ToString() != "0")
                    {
                        return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span style='background-color:#F00;color:#FFF;'>确认出行,<br />现在返利</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成);
                    }
                    else
                    {
                        return string.Format("<span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    return string.Format("<span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format("<a class='table_update' href='javascript:;' data-id='" + orderid + "'><span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span></a>");
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
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{1}');\";  ><span style='background-color:#C00;color:#FFF;'>取消订单</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
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

            int result = new EyouSoft.BLL.MallStructure.BShangChengDingDan().SheZhiOrderStatus(orderid, state);
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            {
                insertDetial(orderid);
                new EyouSoft.BLL.MallStructure.BShangChengDingDan().SheZhiZhiFus(new EyouSoft.Model.MallStructure.MShangChengDingDan() { PayState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderID = orderid });
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成)
            {
                DingDanFanLi(orderid);

                /*
                #region 返利供应商
                var order = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(orderid);
                if (order != null)
                {
                    var semodel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(order.SupplierID);
                    if (semodel != null)
                    {
                        var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(semodel.MemberID);
                        if (member != null)
                        {
                            decimal fanlijine = Convert.ToDecimal(order.OrderPrice) - order.SupplierMoney + member.TotalMoney.Value;
                            //int count = new EyouSoft.BLL.MemberStructure.BMember().UpdateMoney(member.MemberID, fanlijine);
                            EyouSoft.Model.MoneyStructure.MAccount macc = new EyouSoft.Model.MoneyStructure.MAccount();
                            macc.Amounts = Convert.ToDecimal(order.OrderPrice) - order.SupplierMoney;//交易金额
                            macc.balance = fanlijine;//剩余金额
                            macc.OrderID = orderid;//订单编号
                            macc.OrderType = EyouSoft.Model.Enum.DingDanLeiBie.商城订单;//订单类型
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
                            macc.TransactionTime = DateTime.Now;
                            macc.TransactionWay = EyouSoft.Model.Enum.ChongZhiWay.返利;
                            macc.UserId = member.MemberID;
                            macc.TranUserId = order.SupplierID;
                            new EyouSoft.BLL.MoneyStructure.BAccount().Add(macc);
                        }

                    }

                }
                #endregion
                */
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
            {
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderid, EyouSoft.Model.Enum.DingDanLeiBie.商城订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }

        /// <summary>
        /// 订单返利
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        void DingDanFanLi(string dingDanId)
        {
            var dingDanInfo = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(dingDanId);
            if (dingDanInfo == null) return;
            var huiYuanDaiLiShangInfo = new EyouSoft.BLL.OtherStructure.BMember().GetHuiYuanDaiLiShangInfoByDaiLiShangId(dingDanInfo.SupplierID);
            if (huiYuanDaiLiShangInfo == null) return;

            var fanLiInfo = new EyouSoft.Model.OtherStructure.MDingDanFanLiInfo();
            fanLiInfo.DingDanId = dingDanId;
            fanLiInfo.DingDanJinE = dingDanInfo.OrderPrice;
            fanLiInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.商城订单;
            fanLiInfo.FanLiJinE = dingDanInfo.OrderPrice-dingDanInfo.SupplierMoney;
            fanLiInfo.FenXiaoJinE = dingDanInfo.SupplierMoney;
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
            info.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.商城订单;
            info.JiaoYiHao = string.Empty;
            info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
            info.JiaoYiMiaoShu = string.Empty;
            info.JiaoYiShiJian = DateTime.Now;
            info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
            info.MingXiId = string.Empty;
            info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.线下支付;

            var dingDanInfo = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(orderid);
            if (dingDanInfo != null)
            {
                info.JiaoYiHao = dingDanInfo.OrderCode;
                info.JiaoYiJinE = dingDanInfo.OrderPrice;
                info.HuiYuanId = dingDanInfo.ContactID;
            }

            return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
        }

    }
}
