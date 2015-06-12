using EyouSoft.Model.AccountStructure;
using Linq.Respository;

namespace EyouSoft.IDAL.AccountStructure
{
   public interface ISellers : IRepository<MSellers>
   {
       void AddWebDomain(string website, int siteId);
       void RemoveWebDomain(string website, int siteId);
      void UpdateWebDomain(string oldsite ,string newsite);
   }
}
