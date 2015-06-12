using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Common.Page;
using Linq.Web;
using EyouSoft.Model;
using Linq.MetaDataProviders;
using Linq.Bussiness;
using System.Web.UI;
using EyouSoft.Model.SSOStructure;
using Linq.Web.Html;
using Linq.Mvc3;

namespace Common.page
{
   public class ClientModelViewPageBase<T> : HuiYuanPageBase where T : new()
   {
      /// <summary>
      /// 页面（视图）模型
      /// </summary>
      protected T Model { get; set; }

      HtmlHelper<T> html;
      protected HtmlHelper<T> Html
      {
         get
         {
            if (html == null)
            {
               html = new HtmlHelper<T>();
            }
            return html;
         }
      }
      protected Linq.Web.UrlHelper Url { get; set; }

      protected void UpdateModel(IConvertToMModel model)
      {
         model.UpdateTo(Model);
      }

      protected override void OnLoad(EventArgs e)
      {
         ModelBindingContext modelBindingContext = new ModelBindingContext
         {
            ModelType = typeof(T),
            FallbackToEmptyPrefix = true,
            PropertyFilter = (x) => true,
            MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForType(null, typeof(T)),
         };
         DefaultModelBinder modelBinder = new DefaultModelBinder();
         this.Model = (T)modelBinder.BindModel(modelBindingContext);
         if (Model is ISearchable)
         {
            if (((ISearchable)Model).SearchInfo == null)
            {
               ((ISearchable)Model).SearchInfo = new SearchModel();
            }
            ((ISearchable)Model).SearchInfo.PageInfo = base.PageInfo;
         }
         Url = new Linq.Web.UrlHelper(Context);
         base.OnLoad(e);
         Html.Model = Model;
      }
   }
}
