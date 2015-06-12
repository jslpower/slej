using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Common.Page;
using Linq.Web;
using EyouSoft.Model;
using Linq.MetaDataProviders;
using Linq.Bussiness;
using Linq.Web.Html;
using Linq.Mvc3;

namespace Common.page
{
   public class ModelViewPageBase<T> : WebmasterPageBase where T : new()
   {
      /// <summary>
      /// 页面模型
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

      /// <summary>
      /// 更新页面模型
      /// </summary>
      /// <param name="model"></param>
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
         base.OnLoad(e);
         Html.Model = Model;
      }
   }
}
