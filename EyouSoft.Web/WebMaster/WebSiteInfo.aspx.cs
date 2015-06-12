using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 网站信息
    /// </summary>
    public partial class WebSiteInfo : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_网站基本信息))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string action = Utils.GetQueryStringValue("action");

            if (action.ToLower() == "update")
            {
                Save();
            }

            if (!IsPostBack)
            {
                this.InitPage();
            }
        }

        private void InitPage()
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting();
            if (model == null) return;

            txtDescription.Text = model.Description;
            txtKeywords.Text = model.Keywords;
            txtTitle.Text = model.Title;
            txtHotelTatol.Text = Utils.GetInt(model.HotelTatol).ToString();
            txtRouteTatol.Text = Utils.GetInt(model.RouteTatol).ToString();
            txtScenicTatol.Text = Utils.GetInt(model.ScenicTatol).ToString();
            txtQianZhengDingDanJiFenPeiZhi.Text = Utils.GetInt(model.QianZhengDingDanJiFenPeiZhi).ToString();
            txtJiPiaoDingDanJiFenPeiZhi.Text = model.JiPiaoDingDanJiFenPeiZhi;
            Flight.Text = model.FlightSearch;
            Train.Text = model.TrainSearch;
            Transit.Text = model.TransitSearch;
            Weather.Text = model.WeatherSearch;
            Mobile.Text = model.MobileSearch;
            TravelTips.Text = model.TrainTravelTips;
            Map.Text = model.TouristMap;
            Online.Text = model.OnlineTranslation;
            ZipNumber.Text = model.ZipCode;
            MenPiaoLinks.Text = model.MenPiaoLinks;


            upload1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo> { new EyouSoft.Web.UserControl.MFileInfo { FilePath = model.Logo, FileId = "-1", FileName = "已上传的Logo" } };
        }

        protected void Save()
        {
            bool r = new BLL.OtherStructure.BKV().SetCompanySetting(this.GetFormValue());

            EyouSoft.Common.Function.MessageBox.ShowAndRedirect(
                this, string.Format("保存{0}！", r ? "成功" : "失败"), "/WebMaster/WebSiteInfo.aspx");
        }

        private EyouSoft.Model.MCompanySetting GetFormValue()
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting() ?? new EyouSoft.Model.MCompanySetting();

            model.Description = Utils.GetFormValue(txtDescription.UniqueID);
            model.Keywords = Utils.GetFormValue(txtKeywords.UniqueID);
            model.Title = Utils.GetFormValue(txtTitle.UniqueID);
            model.HotelTatol = Utils.GetInt(Utils.GetFormValue(txtHotelTatol.UniqueID)).ToString();
            model.ScenicTatol = Utils.GetInt(Utils.GetFormValue(txtScenicTatol.UniqueID)).ToString();
            model.RouteTatol = Utils.GetInt(Utils.GetFormValue(txtRouteTatol.UniqueID)).ToString();
            model.QianZhengDingDanJiFenPeiZhi = Utils.GetInt(Utils.GetFormValue(txtQianZhengDingDanJiFenPeiZhi.UniqueID)).ToString();
            model.JiPiaoDingDanJiFenPeiZhi = Utils.GetInt(Utils.GetFormValue(txtJiPiaoDingDanJiFenPeiZhi.UniqueID)).ToString();
            model.FlightSearch = Utils.GetFormValue(Flight.UniqueID);
            model.TrainSearch = Utils.GetFormValue(Train.UniqueID);
            model.TransitSearch = Utils.GetFormValue(Transit.UniqueID);
            model.WeatherSearch = Utils.GetFormValue(Weather.UniqueID);
            model.MobileSearch = Utils.GetFormValue(Mobile.UniqueID);
            model.TrainTravelTips = Utils.GetFormValue(TravelTips.UniqueID);
            model.TouristMap = Utils.GetFormValue(Map.UniqueID);
            model.OnlineTranslation = Utils.GetFormValue(Online.UniqueID);
            model.ZipCode = Utils.GetFormValue(ZipNumber.UniqueID);
            model.MenPiaoLinks = Utils.GetFormValue(MenPiaoLinks.UniqueID);

            var newFiles = upload1.Files;
            if (newFiles == null || !newFiles.Any())
            {
                var oldFiles = upload1.YuanFiles;
                if (oldFiles != null && oldFiles.Any())
                {
                    model.Logo = oldFiles[0].FilePath;
                }
                else
                {
                    model.Logo = string.Empty;
                }
            }
            else
            {
                model.Logo = newFiles[0].FilePath;
            }

            return model;
        }
    }
}
