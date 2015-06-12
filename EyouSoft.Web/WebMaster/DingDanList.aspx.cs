using System;
using System.Collections.Generic;
using EyouSoft.Model.OtherStructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Common.Page;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.WebMaster
{
    [Power(Menu1.财务管理, Menu2.财务管理_交易统计)]
    public partial class DingDanList : ModelViewPageBase<MSearchDingDan>
    {
        #region 页面参数
        protected int recordCount = 0;
        protected int pageSize = 15;
        protected int pageIndex = 0;
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInit();
        }
        public override bool IsValidatePower
        {
            get
            {
                return true;
            }
        }

        private void PageInit()
        {
            string agencyid = Utils.GetQueryStringValue("AgencyId");//分销商id
            if (!string.IsNullOrEmpty(agencyid))
            {
                    Model.fenxiaoid = agencyid;
            }
            string productid = Utils.GetQueryStringValue("ProductID");//产品id
            if (!string.IsNullOrEmpty(productid))
            {
                    Model.changpingid = productid;
            }
            string lxrmoblie = Utils.GetQueryStringValue("lxrmoblie");//联系人手机
            if (!string.IsNullOrEmpty(lxrmoblie))
            {
                    Model.lxrmoblie = lxrmoblie;
            }
            string memberid = Utils.GetQueryStringValue("memberid");//下单人id
            if (!string.IsNullOrEmpty(memberid))
            {
                    Model.xiadanrenid = memberid;
            }

            string ordertype = Utils.GetQueryStringValue("OrderType");//分销商id
            if (!string.IsNullOrEmpty(ordertype))
            {
                if (Convert.ToInt32(ordertype) >= 0)
                {
                    Model.dingdantype = (DingDanType)Utils.GetInt(ordertype);
                }
                else
                {
                    Model.dingdantype = (DingDanType)(-1);
                }
            }
            else
            {
                Model.dingdantype = (DingDanType)(-1);
            }
            

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("StartTime").Trim()) && !string.IsNullOrEmpty(Utils.GetQueryStringValue("EndTime").Trim()))
            {
                if (Convert.ToDateTime(Utils.GetQueryStringValue("StartTime").Trim()) < Convert.ToDateTime(Utils.GetQueryStringValue("EndTime").Trim()))
                {
                    Model.startime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime").Trim());
                    Model.endtime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime").Trim()).AddDays(1);
                }
                else
                {
                    Model.startime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime").Trim());
                    Model.endtime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime").Trim()).AddDays(1);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("StartTime").Trim()))
                {
                    if (Convert.ToDateTime(Utils.GetQueryStringValue("StartTime").Trim()) < DateTime.Now)
                    {
                        Model.startime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime").Trim());
                        Model.endtime = DateTime.Now;
                    }
                }
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("EndTime").Trim()))
                {
                    if (Convert.ToDateTime(Utils.GetQueryStringValue("EndTime").Trim()) > DateTime.Now)
                    {
                        Model.startime = DateTime.Now;
                        Model.endtime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime").Trim());
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

        protected string GetStatus(object status, object AgencyId, object OrderType)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)status;
            EyouSoft.Model.OtherStructure.DingDanType ordertype = (EyouSoft.Model.OtherStructure.DingDanType)OrderType;
            switch (state)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format(" <span style='background-color:#00F;color:#FFF;'>订单审核</span>");
                //return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  >订单审核</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format(" <span style='background-color:#906;color:#FFF;'>等待付款</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    return string.Format(" <span style='background-color:#060;color:#FFF;'>付款成功，<br />请通知出行!</span>");
                //return string.Format("  <a href='javascript:;' onclick=\"javascript:OrderList.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    return string.Format(" <span  style='background-color:#F08C0C;color:#FFF;'>等待收货</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                    if (!string.IsNullOrEmpty(AgencyId.ToString()) && AgencyId.ToString().Length > 20)
                    {
                        if (ordertype == DingDanType.团购订单)
                        {
                            return string.Format(" <span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                        }
                        else
                        {
                            return string.Format(" <span style='background-color:#23F111;color:#FFF;'>待返利</span>");
                        }
                    }
                    else
                    {
                        return string.Format(" <span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    return string.Format(" <span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format(" <span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span>");
                default:
                    break;
            }
            return "";
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
            if (id == "" || id == null) return "<a href=\"javascript:;\" class=\"memberID\" data-id=\"-1\">金奥</a>";
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(id);
            if (model == null) return "金奥";
            return "<span style='color:red'>" + model.UserType + "</span><br /><a href=\"javascript:;\" class=\"memberID\" data-id=\"" + memberID.ToString().Trim() + "\">" + model.MemberName + "</a><br />" + model.Mobile;

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
                id = Utils.GetString(AgencyId.ToString(), "").Trim();
            }
            if (id == "" || id == null) return "<a href=\"javascript:;\" class=\"AgencyId\" data-id=\"-1\">金奥</a>";
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
            mseller = bsells.GetWebSiteName(id);
            if (mseller == null) return "金奥";
            return "<span title=\"" + mseller.CompanyName + "\">" + mseller.CompanyJC + "</span><br />" +"<a href=\"javascript:;\" class=\"AgencyId\" data-id=\""+AgencyId.ToString().Trim()+"\">"+mseller.WebsiteName+"</a>";

        }
        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindOrderType(string selectItem)
        {
            string membertype = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(DingDanType)), selectItem.ToString(), true, "-1", "请选择");

            return membertype.ToString();

        }
        #endregion
    }
}
