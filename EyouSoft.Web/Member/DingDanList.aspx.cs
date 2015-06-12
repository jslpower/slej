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
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.Member
{
    public partial class DingDanList : ClientModelViewPageBase<MSearchDingDan>
    {
        #region 页面参数
        protected int recordCount = 0;
        protected int pageSize = 20;
        protected int pageIndex = 0;
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        #endregion
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInit();
        }

        private void PageInit()
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("dingdanid")))
            {
                Model.DingDanId = Utils.GetQueryStringValue("dingdanid");
            }
            else
            {
                mseller = bsells.Get(HuiYuanInfo.UserId);
                if (mseller != null)
                {
                    Model.fenxiaoid = mseller.ID;
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                    Response.End();
                }
                if (!string.IsNullOrEmpty(starttime.Value.Trim()) && !string.IsNullOrEmpty(endtime.Value.Trim()))
                {
                    if (Convert.ToDateTime(starttime.Value.Trim()) < Convert.ToDateTime(endtime.Value.Trim()))
                    {
                        Model.startime = Convert.ToDateTime(starttime.Value.Trim());
                        Model.endtime = Convert.ToDateTime(endtime.Value.Trim()).AddDays(1);
                    }
                    else
                    {
                        Model.startime = Convert.ToDateTime(starttime.Value.Trim());
                        Model.endtime = Convert.ToDateTime(endtime.Value.Trim()).AddDays(1);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(starttime.Value.Trim()))
                    {
                        if (Convert.ToDateTime(starttime.Value.Trim()) < DateTime.Now)
                        {
                            Model.startime = Convert.ToDateTime(starttime.Value.Trim());
                            Model.endtime = DateTime.Now;
                        }
                    }
                    if (!string.IsNullOrEmpty(endtime.Value.Trim()))
                    {
                        if (Convert.ToDateTime(endtime.Value.Trim()) > DateTime.Now)
                        {
                            Model.startime = DateTime.Now;
                            Model.endtime = Convert.ToDateTime(endtime.Value.Trim());
                        }
                    }
                }
               
            }
            Model.dingdantype = (DingDanType)(-1);
            pageIndex = UtilsCommons.GetPagingIndex();
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(pageSize, pageIndex, ref recordCount, Model);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SumAMoney += list[i].AgencyJinE;
                    SumLiRun += list[i].JinE - list[i].AgencyJinE;
                    SumMoney += list[i].JinE;
                }
                Repeater1.Visible = true;
                this.Repeater1.DataSource = list;
                this.Repeater1.DataBind();
                XianShi.Text = "";
            }
            else
            {
                Repeater1.Visible = false;
                XianShi.Text = "暂无订单记录!";
            }
        }

        protected string GetStatus(object status)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)status;
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
                    return string.Format(" <span style='background-color:#23F111;color:#FFF;'>待返利</span>");
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
            if (id == "" || id == null) return "金奥";
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(id);
            if (model == null) return "金奥";
            return "<span style='color:red'>" + model.UserType + "</span><br />" + model.MemberName + "<br />" + model.Mobile;

        }
    }
}
