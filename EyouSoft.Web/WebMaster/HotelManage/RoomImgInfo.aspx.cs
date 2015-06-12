using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class RoomImgInfo : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("roomid");
            if (!IsPostBack)
            {
                PageInit(id);
            }
        }
        /// <summary>
        /// 初始化房型信息
        /// </summary>
        /// <param name="id"></param>
        private void PageInit(string id)
        {


            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            EyouSoft.Model.HotelStructure.MHotelRoomType model = bll.GetHotelRoomTypeModel(id);
            if (model != null)
            {
                lbl_hotelName.Text = new BHotel().GetModel(model.HotelId).HotelName;
                lbl_typeName.Text = model.RoomName;
                lbl_roomNum.Text = model.TotalNumber.ToString();
                lbl_bedType.Text = model.BedType.ToString();
                lbl_isAddBed.Text = string.Format("{0} {1}", model.IsAddBed.ToString(), model.IsAddBed == EyouSoft.Model.Enum.IsAddBed.不能 ? "" : "，加床费" + model.IsAddBedPrice + "元/人");
                lbl_isContainBr.Text = "";
                lbl_payType.Text = "";
                lbl_price.Text = "";
                lbl_roomTypeInfo.Text = model.Desc;
                if (model.HoteRoomImgList != null && model.HoteRoomImgList.Count > 0)
                {
                    rpt_list.DataSource = model.HoteRoomImgList;
                    rpt_list.DataBind();
                }

            }
        }
    }
}
