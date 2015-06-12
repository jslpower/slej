using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.AccountStructure;


namespace EyouSoft.Web.WebMaster.QianZheng
{
    public partial class DingDan : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPrivs();
                InitRpt();
            }
            string orderid = Utils.GetQueryStringValue("orderid");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (UserInfo.LeiXing == 0)
            {
                if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.签证管理_签证订单管理))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-100", "你没有操作权限"));
                }
            }
            else if (UserInfo.LeiXing ==  WebmasterUserType.供应商用户)
            {
            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("-100", "你没有操作权限"));
            }
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
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengDingDanChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanChaXunInfo();

            info.DingDanHao = Utils.GetQueryStringValue("txtDingDanHao");
            info.DingDanHaoUniqueID = string.Empty;
            info.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus), Utils.GetQueryStringValue("txtDingDanStatus"));
            info.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus), Utils.GetQueryStringValue("txtFuKuanStatus"));
            info.GysId = string.Empty;
            info.LaiYuan = null;
            info.LxrXingMing = Utils.GetQueryStringValue("txtLxrXingMing");
            info.QianZhengId = Utils.GetQueryStringValue("qianzhengid");
            info.AgencyId = Utils.GetQueryStringValue("qudaolist");
            if (info.AgencyId == "-1")
            {
                info.AgencyId = null;
            }
            info.XiaDanETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanETime"));
            info.XiaDanRenId = string.Empty;
            info.XiaDanSTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanSTime"));

            if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {
                info.GysId = UserInfo.GysId;
            }

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            int pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            int pageSize = 20;

            var chaXun = GetChaXunInfo();

            var items = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetDingDans(pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {

                for (int i = 0; i < items.Count; i++)
                {
                    SumMoney += items[i].JinE;
                    if (items[i].AgencyId.ToString().Trim().Length > 20)
                    {
                        SumLiRun += items[i].JinE - items[i].AgencyJinE;
                        SumAMoney += items[i].AgencyJinE;
                    }
                }

                rptlist.DataSource = items;
                rptlist.DataBind();

                this.FenYe.intPageSize = pageSize;
                this.FenYe.CurrencyPage = pageIndex;
                this.FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion

        #region protected members
        #endregion
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
            return "<span style='color:red'>"+model.UserType+"</span><br />"+ model.MemberName+"<br />"+model.Mobile;

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

            EyouSoft.BLL.QianZhengStructure.BQianZheng bll = new EyouSoft.BLL.QianZhengStructure.BQianZheng();
            int result = bll.SheZhiOrderStatus(orderid, state);
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            {
                insertDetial(orderid);
                new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiZhiFus(new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, DingDanStatus = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, DingDanId = orderid });
            }
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成)
            {
                DingDanFanLi(orderid);
                /*
                #region 返利供应商
                var order = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(orderid);
                if (order != null)
                {
                    var semodel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(order.AgencyId);
                    if (semodel != null)
                    {
                        var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(semodel.MemberID);
                        if (member != null)
                        {
                            decimal fanlijine = Convert.ToDecimal(order.JinE) - order.AgencyJinE + member.TotalMoney.Value;
                            //int count = new EyouSoft.BLL.MemberStructure.BMember().UpdateMoney(semodel.MemberID, fanlijine);
                            EyouSoft.Model.MoneyStructure.MAccount macc = new EyouSoft.Model.MoneyStructure.MAccount();
                            macc.Amounts = Convert.ToDecimal(order.JinE) - order.AgencyJinE;//交易金额
                            macc.balance = fanlijine;//剩余金额
                            macc.OrderID = orderid;//订单编号
                            macc.OrderType = EyouSoft.Model.Enum.DingDanLeiBie.签证订单;//订单类型
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
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderid, EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }

        /// <summary>
        /// 订单返利
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        void DingDanFanLi(string dingDanId)
        {
            var dingDanInfo = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(dingDanId);
            if (dingDanInfo == null) return;
            var huiYuanDaiLiShangInfo = new EyouSoft.BLL.OtherStructure.BMember().GetHuiYuanDaiLiShangInfoByDaiLiShangId(dingDanInfo.AgencyId);
            if (huiYuanDaiLiShangInfo == null) return;

            var fanLiInfo = new EyouSoft.Model.OtherStructure.MDingDanFanLiInfo();
            fanLiInfo.DingDanId = dingDanId;
            fanLiInfo.DingDanJinE = dingDanInfo.JinE;
            fanLiInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.签证订单;
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
            info.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.签证订单;
            info.JiaoYiHao = string.Empty;
            info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
            info.JiaoYiMiaoShu = string.Empty;
            info.JiaoYiShiJian = DateTime.Now;
            info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
            info.MingXiId = string.Empty;
            info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.线下支付;

            var dingDanInfo = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(orderid);
            if (dingDanInfo != null)
            {
                info.JiaoYiHao = dingDanInfo.DingDanHao;
                info.JiaoYiJinE = dingDanInfo.JinE;
                info.HuiYuanId = dingDanInfo.XiaDanRenId;
            }

            return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
        }
    }
}
