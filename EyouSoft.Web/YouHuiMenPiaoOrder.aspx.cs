using System;
using Common.page;
using Linq.Web;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.SystemStructure;
using Common;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Web.MasterPage;

namespace EyouSoft.Web
{
   [IsLogin]
   [NoCache]
   public partial class YouHuiMenPiaoOrder : ClientModelViewPageBase<MScenicAreaTicketsOrderWebBindModel>
   {
      BScenicArea2 bll = new BScenicArea2();
      BFeeSettings feeSettingBll = new BFeeSettings();
      BSellers bseller = new BSellers();
      protected void Page_Load(object sender, EventArgs e)
      {
         (Master as Front2).HeadMenuIndex = 6;
         if (Request.QueryString["submit"] == "1")
         {
            string msg = "";
            Model.OrderSite = OrderSite.PC;
           bool i = bll.SubmitOrder(Model, CurrentUser.UserType, out msg);
            ReturnAjax(i ? 1 : 0, msg);
         }
         else
         {
            if (!string.IsNullOrEmpty(Model.TicketsId))
            {
               Model.TicketInfo = bll.GetTicketInfo(Model.TicketsId);
               Model.AreaInfo = bll.GetScenicAreaInfo(Model.TicketInfo.ScenicId);
               Model.FeeSetting = feeSettingBll.GetByType(FeeTypes.门票);
               Model.Num = 1;
               Model.OperatorId = CurrentUser.UserId;
               Model.OperatorName = CurrentUser.MemberName;
               Model.OperatorMobile = CurrentUser.Mobile;

               if (DateTime.Now.Hour < 12)
               {
                  Model.ChuFaRiQi = DateTime.Now;
               }
               else
               {
                  Model.ChuFaRiQi = DateTime.Now.AddDays(1);
               }
               Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, CurrentUser.UserType, Model.FeeSetting, FeeTypes.门票));
               Model.Price = Model.CurrentPrice * Model.Num;
               Model.IsShowFenXiaoShenQing = (bseller.WebSiteShowOrHidden(Request.Url.Host) == ShowHidden.显示);
            }
            else
            {
               Response.End();
            }
         }
      }
   }
}
