using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class TuanGouXX : System.Web.UI.Page
    {
        public int TotalSeconds = 0;
        protected string thisurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string dotype = Utils.GetQueryStringValue("dotype");
            //if (dotype == "save")
            //{
            //    SaveOrder();
            //}
            //else if (dotype == "")
            //{
            //    GotoUrl();
            //}
            string hosturl = Request.Url.Host.ToLower();
            if (hosturl.IndexOf("www") >= 0)
            {
                hosturl = "slej.cn";
            }
            thisurl = "http://m." + hosturl + "/TuanGouXX.aspx?id=" + Utils.GetQueryStringValue("id");
            if (!IsPostBack)
            {
                initPage();
            }
        }
        void initPage()
        {
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));
            var model = new EyouSoft.BLL.OtherStructure.BTuanGou().GetModel(id);
            if (model != null)
            {
                //CxType = ((int)model.SaleType).ToString();
                //CpType = ((int)model.ProductType).ToString();
                int count = model.Salevolume;
                if (count == 0)
                {
                    goumaishu.Text = "还未有人购买";
                }
                else
                {
                    goumaishu.Text = "<b class='fontred font16'>"+count+"</b> 人已购买";
                }
                int shengyuNum = model.ProductNum - count;//剩余数量
                shengyushu.Text = shengyuNum.ToString();
                ProductName.Text =model.ProductName;
                if (Convert.ToDateTime(model.ValiDate).AddDays(1) > DateTime.Now)
                {
                    TotalSeconds = Convert.ToInt32((Convert.ToDateTime(model.ValiDate).AddDays(1) - DateTime.Now).TotalSeconds);
                    if (shengyuNum > 0)
                    {
                        ydbtn.Text = "<span class='tg_ydbtn' id='QGimg'><a href='javascript:void(0);' id='QGbtn'>立即抢</a></span>";
                    }
                    else
                    {
                        ydbtn.Text = "<span class='tg_ydbtn tg_ydbtn01'><a>已结束</a></span>";
                    }
                }
                else
                {
                    ydbtn.Text = "<span class='tg_ydbtn tg_ydbtn01'><a>已结束</a></span>";
                }
                jianjie.Text =model.SimpleInfo;
                yuanjia.Text = Convert.ToInt32(model.MarketPrice).ToString();
                qianggoujia.Text = Convert.ToInt32(model.GroupPrice).ToString();
                jieshao.Text = model.DetailInfo;
                ProductTime.Text = model.ValiDate.ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(model.ProductImg)) ProductImg.Text = "<img src='"+ model.ProductImg +"' />";
            }
            

        }

        //private void SaveOrder()
        //{
        //    EyouSoft.BLL.OtherStructure.BTuanGouDingDan bll = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan();
        //    EyouSoft.Model.OtherStructure.MTuanGouDingDan Ordermodel = new EyouSoft.Model.OtherStructure.MTuanGouDingDan();
            
        //    Model.SSOStructure.MUserInfo userInfo = null;
        //    if (!Security.Membership.UserProvider.IsLogin(out userInfo)) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
        //    if (userInfo == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));

        //    string url = HttpContext.Current.Request.Url.Host;
        //    BSellers bsells = new BSellers();
        //    EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
        //    seller = bsells.GetMSellersByWebSite(url);
        //    if (seller != null)
        //    {
        //        Ordermodel.SupplierID = seller.ID;
        //    }
        //    else
        //    {
        //        Ordermodel.SupplierID = "-1";
        //    }

        //    int id = Utils.GetInt(Utils.GetQueryStringValue("id"));
        //    var model = new EyouSoft.BLL.OtherStructure.BTuanGou().GetModel(id);
        //    Ordermodel.IssueTime = DateTime.Now;
        //    Ordermodel.OrderPrice = model.GroupPrice;
        //    Ordermodel.OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
        //    Ordermodel.PayState = EyouSoft.Model.Enum.PaymentState.未支付;
        //    Ordermodel.PeopleID = userInfo.UserId;
        //    Ordermodel.PeopleMobile = userInfo.Mobile;
        //    Ordermodel.PeopleName = userInfo.MemberName;
        //    Ordermodel.ProductID = id;
        //    Ordermodel.ProductName = model.ProductName;
        //    Ordermodel.ProductNum = 1;
        //    var r = bll.Add(Ordermodel);
        //    string strReturn;
        //    if (r == 1)
        //    {
        //        int code = new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(Ordermodel.OrderID.ToString(), EyouSoft.Model.Enum.DingDanLeiBie.团购订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);
        //        strReturn = "下单成功";
        //    }
        //    else
        //    {
        //        strReturn = "下单失败";
        //    }
        //    RECW(UtilsCommons.AjaxReturnJson(r.ToString(), strReturn));
        //}
        //private void GotoUrl()
        //{
        //    Response.Clear();

        //    Model.SSOStructure.MUserInfo userInfo = null;
        //    if (Security.Membership.UserProvider.IsLogin(out userInfo))
        //    {
        //        Response.Write(UtilsCommons.AjaxReturnJson("1", "login"));
        //    }
        //    else
        //    {
        //        Response.Write(UtilsCommons.AjaxReturnJson("0", "unlogin"));

        //    }
        //    Response.End();
        //}

        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
    }
}
