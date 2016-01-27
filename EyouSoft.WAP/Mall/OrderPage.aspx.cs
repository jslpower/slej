using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP.Mall
{
    public partial class OrderPage : WebPageBase
    {
        protected string pSelect = "0", cSelect = "0", xSelect = "0";
        decimal jsj = 0;
        decimal scj = 0;
        protected int goumainum = 1;
        protected int shengyu = 0;
        protected decimal danjia = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Utils.GetQueryStringValue("save") == "save") BaoCun();

            if (!IsPostBack)
            {
                initPage();
            }

        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            string id = Utils.GetQueryStringValue("id");
            int num = Utils.GetInt(Utils.GetQueryStringValue("num"), 1);
            EyouSoft.Model.SSOStructure.MUserInfo HuiYuanInfo = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out HuiYuanInfo);
            if (HuiYuanInfo != null)
            {

                var dizhis = new EyouSoft.BLL.MallStructure.BDiZhi().GetList(new EyouSoft.Model.MemberStructure.MDiZhiSer() { UserID = HuiYuanInfo.UserId, IsDefault = true });
                if (dizhis != null && dizhis.Count > 0)
                {
                    txtShouHuoRen.Value = dizhis[0].UserName;
                    txtShouJi.Value = HuiYuanInfo.Mobile;
                    txtDianHua.Value = HuiYuanInfo.Contact;
                    pSelect = dizhis[0].ProvinceID.ToString();
                    cSelect = dizhis[0].CityID.ToString();
                    xSelect = dizhis[0].DistrictID.ToString();
                    txtDiZhi.Value = dizhis[0].AddressInfo;
                    hidaddid.Value = dizhis[0].AddressID.ToString();

                }
            }
            var chanpin = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetModel(id);
            shengyushu.Text = chanpin.StockNum.ToString();
            shengyu = chanpin.StockNum;
            if (chanpin == null) RCWE("数据丢失，请重新操作");
            lblName.Text = chanpin.ProductName;
            //hidChanPinJiaGe.Value = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, chanpin.SalePrice, chanpin.MarketPrice).ToString("F2");
            lblSinglePrice.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, chanpin.SalePrice, chanpin.MarketPrice).ToString("F2") + "/" + chanpin.Unit;
            danjia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, chanpin.SalePrice, chanpin.MarketPrice);
            hidnum.Value = num.ToString();
            goumainum = num;
            jsj = danjia;
            scj = chanpin.MarketPrice;
            hidjsj.Value = chanpin.SalePrice.ToString("F2");
            hidmsj.Value = chanpin.MarketPrice.ToString("F2");
            lblSumPrice.Text = (num * jsj).ToString("F2");


        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            MShangChengDingDan model = new MShangChengDingDan();


            EyouSoft.Model.SSOStructure.MUserInfo CurrentUser = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out CurrentUser);
            if (!isLogin) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "未登录！"));



            EyouSoft.Model.MemberStructure.MDiZhi dizhi = new EyouSoft.Model.MemberStructure.MDiZhi();
            dizhi.ProvinceID = Utils.GetInt(Utils.GetFormValue("ddprovince"));
            dizhi.CityID = Utils.GetInt(Utils.GetFormValue("ddlcity"));
            dizhi.DistrictID = Utils.GetInt(Utils.GetFormValue("ddlqu"));
            if (dizhi.ProvinceID == 0 || dizhi.CityID == 0 || dizhi.DistrictID == 0)
            {
                Response.Clear();
                Response.Write(UtilsCommons.AjaxReturnJson("0", "请选择省市区！"));
                Response.End();
            }

            dizhi.AddressInfo = Utils.GetFormValue(txtDiZhi.UniqueID);
            dizhi.IsDefault = Utils.GetFormValue("isDefault") == "1" ? true : false;
            dizhi.AddressID = Utils.GetInt(Utils.GetFormValue(hidaddid.UniqueID));
            dizhi.UserName = CurrentUser.MemberName;
            dizhi.UserID = CurrentUser.UserId;


            model.ProductID = Utils.GetFormValue("hidpid");
            model.ProductNum = Utils.GetInt(Utils.GetFormValue("lblNum"));
            model.ContactID = CurrentUser.UserId;
            model.ContactName = Utils.GetFormValue(txtShouHuoRen.UniqueID);
            model.ContactPhone = Utils.GetFormValue(txtDianHua.UniqueID);
            jsj = Utils.GetDecimal(Utils.GetFormValue(hidjsj.UniqueID));
            scj = Utils.GetDecimal(Utils.GetFormValue(hidmsj.UniqueID));
            model.OrderPrice = model.ProductNum * UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, jsj, scj);
            model.PayState = EyouSoft.Model.Enum.PaymentState.未支付;
            model.Remark = "";
            model.OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
            model.Address = dizhi;

            var yuming = EyouSoft.Common.Page.HuiYuanPageBase.GetYuMingInfo();
            var JINE = model.ProductNum * UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, jsj, scj, EyouSoft.Common.Page.HuiYuanPageBase.GetYuMingInfo().UserType);
            if (model.OrderPrice < JINE)
            {
                JINE = model.OrderPrice;

            }
            model.SupplierID = yuming.GYSID;
            model.SupplierMoney = JINE;//分销商价格
            model.OrderSite = EyouSoft.Model.Enum.OrderSite.WAP;


            int result = new EyouSoft.BLL.MallStructure.BShangChengDingDan().Insert(model);
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result.ToString(), result == 1 ? "提交成功" : result == -99 ? "超出库存数量,提交失败" : "提交失败"));
            if (result == 1) HttpContext.Current.Session.Remove(CurrentUser.UserId);
            if (result == 1)
            {
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(model.OrderID, EyouSoft.Model.Enum.DingDanLeiBie.商城订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);

                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = model.OrderID;
                flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.商城订单;
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = model.ContactID;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);
            }
            Response.End();
        }
    }
}
