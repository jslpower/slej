using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
   public class ScenicTicketXiangQingSearchModel : MScenicTickets
   {
      public MScenicArea ScenicArea { get; set; }
      public MFeeSettings FeeSettings { get; set; }
      public bool IsShowShenQing { get; set; }
   }
}
