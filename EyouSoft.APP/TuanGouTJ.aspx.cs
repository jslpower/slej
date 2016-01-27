using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;
using Common.page;

namespace EyouSoft.WAP
{
    public partial class TuanGouTJ : HuiYuanWapPageBase
    {
        protected int jsj = 0;
        protected int shengyu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "配送信息";
            if (!IsPostBack)
            {
                initPage();
            }
            if (Utils.GetQueryStringValue("dotype") == "save") BaoCun();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            string id = Utils.GetQueryStringValue("id");
            if (HuiYuanInfo != null)
            {
                hidpid.Value = id;
                var chanpin = new EyouSoft.BLL.OtherStructure.BTuanGou().GetModel(Convert.ToInt32(id));
                if (chanpin == null) RCWE("数据丢失，请重新操作");
                lblChanPinMingCheng.Text = chanpin.ProductName;
                hidChanPinJiaGe.Value = lblChanPinJiaGe.Text = Convert.ToInt32(chanpin.GroupPrice).ToString();
                jsj = Convert.ToInt32(chanpin.GroupPrice);
                int shengyuNum = chanpin.ProductNum - chanpin.Salevolume;//剩余数量
                shengyushu.Text = shengyuNum.ToString();
                shengyu = shengyuNum;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            EyouSoft.BLL.OtherStructure.BTuanGouDingDan bll = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan();
            EyouSoft.Model.OtherStructure.MTuanGouDingDan Ordermodel = new EyouSoft.Model.OtherStructure.MTuanGouDingDan();

            string url = HttpContext.Current.Request.Url.Host;
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null)
            {
                Ordermodel.SupplierID = seller.ID;
            }
            else
            {
                Ordermodel.SupplierID = "-1";
            }

            int id = Convert.ToInt32(Utils.GetFormValue(hidpid.UniqueID));
            var model = new EyouSoft.BLL.OtherStructure.BTuanGou().GetModel(id);
            Ordermodel.ProductNum = Utils.GetInt(Utils.GetFormValue("GouMaiShu"));
            if (Ordermodel.ProductNum > Convert.ToInt32(shengyushu.Text))
            {
                RECW(UtilsCommons.AjaxReturnJson("0", "您填写的数量大于最大可购买量，<br />请确认后重新填写！"));
            }
            Ordermodel.IssueTime = DateTime.Now;
            Ordermodel.OrderPrice = model.GroupPrice * Ordermodel.ProductNum;
            Ordermodel.OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
            Ordermodel.PayState = EyouSoft.Model.Enum.PaymentState.未支付;
            Ordermodel.PeopleID = HuiYuanInfo.UserId;
            Ordermodel.PeopleMobile = Utils.GetFormValue("GouMaiMoblie");
            Ordermodel.PeopleName = Utils.GetFormValue("GouMaiName");
            Ordermodel.ProductID = id;
            Ordermodel.Peopleaddress = Utils.GetFormValue("GouMaiAddress");
            Ordermodel.ProductName = model.ProductName;
            Ordermodel.OrderSite = EyouSoft.Model.Enum.OrderSite.APP;

            var r = bll.Add(Ordermodel);
            string strReturn;
            if (r == 1)
            {
                int code = new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(Ordermodel.OrderID.ToString(), EyouSoft.Model.Enum.DingDanLeiBie.团购订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);
                strReturn = "下单成功，请前往订单中心查看";

                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = Ordermodel.OrderID.ToString();
                flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.团购订单;
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = Ordermodel.PeopleID;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);
                //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                jianglibi.DingDanId = Ordermodel.OrderID.ToString();
                jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.团购订单;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);
            }
            else
            {
                strReturn = "下单失败";
            }
            RECW(UtilsCommons.AjaxReturnJson(r.ToString(), strReturn));
        }

        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
    }
}
