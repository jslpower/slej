using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class EditRouteDate : Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("type") == "save")
            {
                PageSave();
            }

            PageInit();
        }

        private void PageInit()
        {
            string xianluid = Utils.GetQueryStringValue("xianluid");
            string tourid=Utils.GetQueryStringValue("tourid");
            if (string.IsNullOrEmpty(xianluid)
                ||string.IsNullOrEmpty(tourid))
                Utils.RCWE(Utils.AjaxReturnJson("0", "初始化失败!"));

            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            MXianLuInfo model = bll.GetInfo(xianluid);
            if (model == null) Utils.RCWE(Utils.AjaxReturnJson("0", "初始化失败!"));
            //if (model.Line_Source != LineSource.系统)
            //{
            //    txtJieadultprice.Enabled = false;
            //    txtJiechlidprice.Enabled = false;
            //}
            EyouSoft.Model.XianLuStructure.MXianLuTourInfo tourInfo = null;
            if (model.Tours != null && model.Tours.Count > 0)
            {
                foreach (var item in model.Tours)
                {
                    if (item.TourId == tourid) { tourInfo = item; break; }
                }
            }
            if (tourInfo == null) Utils.RCWE(Utils.AjaxReturnJson("0", "初始化失败!"));

            this.txtJieadultprice.Text = tourInfo.JSJCR.ToString("f2");
            this.txtJiechlidprice.Text = tourInfo.JSJET.ToString("f2");
            this.txtPlanCount.Text = model.JiHuaRenShu.ToString();

            this.txtShiadultprice.Text = tourInfo.CRSCJ.ToString("f2");
            this.txtShichildprice.Text = tourInfo.ETSCJ.ToString("f2");
            if (model.Line_Source != LineSource.系统)
            {
                this.txtShiadultprice.Enabled = false;
                this.txtShichildprice.Enabled = false;
            }
            this.txtTiqiandays.Text = model.TingTianShu.ToString();
        }

        private void PageSave()
        {
            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("tourid"))) return;

            string jieadultprice = Utils.GetFormValue(this.txtJieadultprice.UniqueID);
            string jiechildprice = Utils.GetFormValue(this.txtJiechlidprice.UniqueID);
            string shiadultprice = Utils.GetFormValue(this.txtShiadultprice.UniqueID);
            string shichildprice = Utils.GetFormValue(this.txtShichildprice.UniqueID);
            
            MXianLuTourInfo modeltourinfo=new MXianLuTourInfo();
            modeltourinfo.TourId = Utils.GetQueryStringValue("tourid");
            modeltourinfo.JSJCR=Utils.GetDecimal(jieadultprice);
            modeltourinfo.JSJET=Utils.GetDecimal(jiechildprice);
            modeltourinfo.CRSCJ = Utils.GetDecimal(shiadultprice);
            modeltourinfo.ETSCJ = Utils.GetDecimal(shichildprice);

            if (new EyouSoft.BLL.XianLuStructure.BXianLu().SheZhiXianLuTourChaYi(modeltourinfo) == 1)
            {
                Utils.RCWE(Utils.AjaxReturnJson("1", "修改成功!"));
            }
            else
            {
                Utils.RCWE(Utils.AjaxReturnJson("0", "修改失败!"));
            }

        }
    }
}
