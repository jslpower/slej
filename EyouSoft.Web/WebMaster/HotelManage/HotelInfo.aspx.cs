using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class HotelInfo : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("hotelid");
            if (!IsPostBack)
            {
                PageInit(id);
            }
        }
        /// <summary>
        /// 初始化酒店信息
        /// </summary>
        /// <param name="id"></param>
        private void PageInit(string id)
        {
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();

            EyouSoft.Model.HotelStructure.MHotel model = bll.GetModel(id);
            if (model != null)
            {
                Label1.Text = model.HotelName;
                Label2.Text = model.Star.ToString();
                Label3.Text = model.Address;
                if (model.MarkList != null && model.MarkList.Count > 0)
                {
                    for (int i = 0; i < model.MarkList.Count; i++)
                    {
                        Label4.Text += model.MarkList[i].Por + "    ";
                    }

                }

                Label5.Text = model.PostalCode;
                Label6.Text = model.ServiceTel;
                Label7.Text = model.OpenDate;
                Label8.Text = model.Fitment;
                Label9.Text = model.RoomQuantity.ToString();
                Label10.Text = model.Floor.ToString();
                Label12.Text = model.LongDesc;
                Label13.Text = model.Transport;
                Label14.Text = model.AdditionalCost;

                IList<EyouSoft.Model.HotelStructure.MHotelImg> imgList = model.ImgList;
                if (imgList != null && imgList.Count > 0)
                {
                    for (int i = 0; i < imgList.Count; i++)
                    {
                        if (imgList[i].ImgCategory == EyouSoft.Model.Enum.HotelImgType.酒店形象照片)
                        {
                            Label11.Text = " <img width=\"410px\" height=\"240px\" alt=\"" + imgList[i].ImgCategory + "\" src=\"" + imgList[i].FilePath + "\" />";
                        }
                    }
                }
            }
            if (model != null && model.RoomTypeList != null && model.RoomTypeList.Count > 0)
            {
                rpt_list.DataSource = model.RoomTypeList;
                rpt_list.DataBind();
            }

        }
    }
}
