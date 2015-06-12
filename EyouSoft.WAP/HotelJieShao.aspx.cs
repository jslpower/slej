using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.HotelStructure.WebModel;

namespace EyouSoft.WAP
{
    public partial class HotelJieShao : System.Web.UI.Page
    {
        BHotel2 bll = new BHotel2();
        MHotelXiangQingModel2 Model = new MHotelXiangQingModel2();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "酒店详情";

            Model.HotelId = Utils.GetQueryStringValue("HotelId");
            MHotelXiangQingModel model = bll.GetHotelDetail(Model);
            if (model != null)
            {
                HotelName.Text = model.HotelName;
                DiZhi.Text = model.Address;
                KaiYe.Text = string.IsNullOrEmpty(model.OpenDate) == true ? "未知" : model.OpenDate;
                LouCeng.Text = string.IsNullOrEmpty(model.Floor) == true ? "未知" : model.Floor;
                ZhuangXiu.Text = string.IsNullOrEmpty(model.Fitment) == true ? "未知" : model.Fitment;
                FangJian.Text = string.IsNullOrEmpty(model.RoomQuantity.ToString()) == true ? "未知" : model.RoomQuantity.ToString();
                XingJi.Text = model.Star.ToString();
                DianHua.Text = model.ServiceTel;
                JIngGuang.Text = "未知";
                JieShao.Text = model.LongDesc;
                JiaoTong.Text = model.Transport;
            }
        }
    }
}
