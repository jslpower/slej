using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model;
using Common.page;
using EyouSoft.Model.SystemStructure;
using EyouSoft.Model.SystemStructure.WebModel;
using Linq.Bussiness;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.SystemStructure;

namespace EyouSoft.Web
{
   public partial class FeeSetting : ModelViewPageBase<MFeeSettingsSearchModel>
   {
      BFeeSettings bll = new BFeeSettings();
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Model.SearchInfo.ShowMode.HasValue)
         {
            if (Model.SearchInfo.ShowMode.Value == ShowMode.Update)
            {
               if (Model.LeiBie == 0)
               {
                  Model.LeiBie = FeeTypes.周边线路;
               }
               MFeeSettings model = bll.GetByType(Model.LeiBie);
               if (model != null)
               {
                  UpdateModel(model);
               }
            }
         }
         else if (Model.SearchInfo.EditMode.HasValue)
         {
            Model.UpdateTime = DateTime.Now;
            if (Model.SearchInfo.EditMode.Value == EditMode.Update)
            {
               if (bll.Update(Model))
               {
                  ReturnAjax(1, "保存成功");
               }
               else
               {
                  ReturnAjax(-1, "保存失败");
               }
            }
         }
      }
   }
}
