using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.BLL.HotelStructure;

namespace EyouSoft.Web
{
   public partial class HotelXiangQing2Room : ClientModelViewPageBase<MHotelXiangQingModel2>
   {
      BHotel2 bll = new BHotel2();
      protected void Page_Load(object sender, EventArgs e)
      {

         if (!Model.RuZhuRiQi.HasValue)
         {
            Model.RuZhuRiQi = DateTime.Now;
         }
         if (!Model.LiDianRiQi.HasValue)
         {
            Model.LiDianRiQi = DateTime.Now.AddDays(1);
         }
          
         var searchModel = new MHotelSearchModel1();
         searchModel.RuZhuRiQi = Model.RuZhuRiQi;
         searchModel.LiDianRiQi = Model.LiDianRiQi;
         searchModel.HotelId = Model.HotelId;
         searchModel.RoomTypeId = Model.RoomTypeId;
         searchModel.RoomTypeId_Except = Model.RoomTypeId_Except;
         searchModel.RoomRateId_Except = Model.RoomRateId_Except;
         if (!string.IsNullOrEmpty(Model.RoomRateIds))
         {
            try
            {
               searchModel.RoomRateId = Model.RoomRateIds.Split(',').Select(x => int.Parse(x)).ToArray();
            }
            catch
            {
               Response.End();
               return;
            }
         }
         MHotelXiangQingModel2 viewmodel = new MHotelXiangQingModel2();
         viewmodel.RuZhuRiQi = Model.RuZhuRiQi;
         viewmodel.LiDianRiQi = Model.LiDianRiQi;
         viewmodel.HotelId = Model.HotelId;
         var list =  bll.GetHotelList(searchModel, false, CurrentUser.UserType, false);
         if (list== null || list.Count == 0)
         {
            viewmodel.RoomRateInfo = null;
            viewmodel.RoomTypeId = Model.RoomTypeId;
         }
         else
         {
            viewmodel.RoomRateInfo = list[0].RoomRateInfo;
            viewmodel.RoomRateIds = string.Join(",", viewmodel.RoomRateInfo.Select(x => x.RoomRateId.ToString()).OrderBy(x => x).ToArray());
            viewmodel.RoomTypeId = viewmodel.RoomRateInfo[0].RoomTypeId;
         }
         Model = viewmodel;
      }
   }
}
