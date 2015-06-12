
namespace Linq.Mvc3
{
   public interface IModelBinder
   {
      /// <summary>
      /// 值绑定到强类型的模型
      /// </summary>
      object BindModel(ModelBindingContext bindingContext);
   }
}