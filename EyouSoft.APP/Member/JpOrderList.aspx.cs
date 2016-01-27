using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.BLL.ZuCheStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.JPStructure;
using System.Text;

namespace EyouSoft.WAP.Member
{
    public partial class JpOrderList : HuiYuanWapPageBase
    {
        BZuCheOrder bll = new BZuCheOrder();
        BSellers bsells = new BSellers();
        MSearchDingDan Model = new MSearchDingDan();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        string AgencyId = "";
        protected int PageNum = 8;//每页显示条数
        protected int orderleibie = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            if (Utils.GetQueryStringValue("dotype") == "quxiao") QuXiaoJiPiao();
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                AgencyId = mseller.ID;
                isAgency = 1;
            }

            orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.机票订单;
            WapHeader1.HeadText = "机票订单";

            Model.xiadanrenid = HuiYuanInfo.UserId;
            if (AgencyId != "")
            {
                Model.fenxiaoid = AgencyId;
            }
            Model.dingdantype = (DingDanType)orderleibie;
            int TotalCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(PageNum, 1, ref TotalCount, Model);
            if (list != null && list.Count > 0)
            {
                Repeater1.DataSource = list;
                XianShi.Text = "";
            }
            else
            {
                Repeater1.DataSource = null;
                XianShi.Text = "暂无数据！";
            }
            Repeater1.DataBind();
        }

        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId, object ordertype, object xdrid, object fukuan)
        {
            StringBuilder retStr = new StringBuilder();
            mseller = bsells.Get(HuiYuanInfo.UserId);
            string FenXiaoId = "";
            if (mseller != null)
            {
                FenXiaoId = mseller.ID;
            }
            if (string.IsNullOrEmpty(AgencyId.ToString())) { AgencyId = ""; }

            DingDanStatus type = (DingDanStatus)state;
            switch (type)
            {
                case DingDanStatus.等待支付:
                    retStr.AppendFormat("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span class=\"bg_zi\">马上付款</span></a>", orderid, (int)ordertype, HuiYuanInfo.UserId);
                    break;
                case DingDanStatus.支付成功:
                    retStr.AppendFormat("<span  class=\"bg_yellow\">等待出票</span>");
                    break;
                case DingDanStatus.出票成功:
                    retStr.AppendFormat("  <span  class=\"bg_green\">确认出行</span>");
                    break;
                default:
                    break;
            }
            EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fukuanState = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)fukuan;
            switch (fukuanState)
            {
                case EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款:
                    retStr.Append("");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款:
                    retStr.AppendFormat("<a href='javascript:;' onclick=\"javascript:pageData.QuXiao('{0}');\"  ><span class=\"bg_zi\">取消订单</span></a>", orderid);
                    break;
                default:
                    break;
            }

            return retStr.ToString();
        }

        /// <summary>
        /// 设置订单状态
        /// </summary>
        void setOrderState()
        {
            string orderid = Utils.GetQueryStringValue("id");
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)Utils.GetInt(Utils.GetQueryStringValue("state"));

            EyouSoft.Model.OtherStructure.DingDanType OrderLeiBie = (EyouSoft.Model.OtherStructure.DingDanType)Utils.GetInt(Utils.GetQueryStringValue("ordertype"));
            int result = 0;
            if (OrderLeiBie == DingDanType.租车订单)
            {
                BZuChe zubll = new BZuChe();
                result = zubll.SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.酒店订单)
            {
                BHotel bll = new BHotel();
                result = bll.SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.门票订单)
            {
                BScenicArea bll = new BScenicArea();
                result = bll.SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.商城订单)
            {
                result = new EyouSoft.BLL.MallStructure.BShangChengDingDan().SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.团购订单)
            {
                result = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().SheZhiOrderStatus(orderid, state);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }

        void QuXiaoJiPiao()
        {
            string queryID = Utils.GetQueryStringValue("id");
            var model = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(queryID);
            if (model == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失"));


            if (model.DingDanStatus == DingDanStatus.出票成功)
            {
                int A = new EyouSoft.BLL.JPStructure.BDingDan().JinRi_Api_TuiFei(model);
            }

            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "到此为止"));
            int result = new EyouSoft.BLL.JPStructure.BDingDan().JinRi_Api_QuXiao(model);
            if (result == 1)
            {
                var info = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
                info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.返利;//退票暂时计入返利
                info.JiaoYiHao = model.JiaoYiHao;
                info.HuiYuanId = model.HuiYuanId;

                new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info);
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "订单取消成功"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "订单取消失败"));
            }
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
