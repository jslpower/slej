using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common.Page;
using EyouSoft.BLL.XianLuStructure;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class OrderInfo : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 页面变量
        protected string getID = "";
        protected string rutoName = "";//线路类型
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            getID = Utils.GetQueryStringValue("id");
            GetOrderByID(getID);
        }
        protected void GetOrderByID(string id)
        {

            MOrderInfo model = new MOrderInfo();
            BOrder bll = new BOrder();
            if (id == "") return;



            model = bll.GetInfo(id);
            if (model == null) return;

            string ChengRenJia = model.JiaoYiCR.ToString("f2");
            string ErTongJia = model.JiaoYiET.ToString("f2");
            //if (model.RouteType == EyouSoft.Model.Enum.AreaType.周边短线)
            //{
            //    ChengRenJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.周边线路, model.JSJCR, model.SCJCR, model.UserType).ToString("f2");
            //    ErTongJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.周边线路, model.JSJER, model.SCJET, model.UserType).ToString("f2");
            //}
            //else if (model.RouteType == EyouSoft.Model.Enum.AreaType.国内长线)
            //{
            //    ChengRenJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国内线路, model.JSJCR, model.SCJCR, model.UserType).ToString("f2");
            //    ErTongJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国内线路, model.JSJER, model.SCJET, model.UserType).ToString("f2");
            //}
            //else if (model.RouteType == EyouSoft.Model.Enum.AreaType.出境线路)
            //{
            //    ChengRenJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国际线路, model.JSJCR, model.SCJCR, model.UserType).ToString("f2");
            //    ErTongJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国际线路, model.JSJER, model.SCJET, model.UserType).ToString("f2");
            //}

            lbordercode.Text = model.OrderCode;
            lborderdate.Text = model.IssueTime.ToString("yyyy-MM-dd");
            lbleavedate.Text = model.LDate.ToString("yyyy-MM-dd");
            lbadultcount.Text = model.ChengRenShu.ToString();
            lblertongshu.Text = model.ErTongShu.ToString();
            lbcontactname.Text = model.LxrName;
            lbcontactsex.Text = model.LxrGender.ToString();
            lbcontactmobile.Text = model.LxrTelephone;
            lbadultprice.Text = ChengRenJia;
            lbchildprice.Text = ErTongJia;
            lbhetongmoney.Text = model.JinE.ToString("C2");
            lborderstatus.Text = model.Status.ToString();
            lbpaystatus.Text = model.FuKuanStatus.ToString();
            lborderremark.Text = model.XiaDanBeiZhu;
            lbchuliremark.Text = model.QiTaBeiZhu;
            rutoName = (model.RouteType).ToString();
            lbother.Text = model.QiTaBeiZhu;
            if (model.YouKes != null && model.YouKes.Count > 0)
            {
                rptcustomlist.DataSource = model.YouKes;
                rptcustomlist.DataBind();
            }




        }

    }
}
