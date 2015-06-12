using System;
using Linq.Common;
using Linq.Mvc3;
using Linq.MetaDataProviders;
using Linq.Bussiness;
using Linq.Web.Html;
namespace Linq.Web
{
   public class ModelViewPageBaseForWebform<T> : System.Web.UI.Page where T : class, new()
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
         this.Model = modelBinder.BindModel(modelBindingContext) as T;
         if (Model is ISearchable)
         {
            if (((ISearchable)Model).SearchInfo == null)
            {
               ((ISearchable)Model).SearchInfo = new SearchModel();
            }
           // ((ISearchable)Model).SearchInfo.PageInfo = base.PageInfo;
         }
         Html.Model = Model;
         base.OnLoad(e);
      }
   }
}
