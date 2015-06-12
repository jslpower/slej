using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using EyouSoft.Model.Enum;
using EyouSoft.Toolkit.BLL;
using Linq.Respository;
using EyouSoft.Model.SystemStructure;
using Linq.DAL;
using EyouSoft.IDAL.SystemStructure;

namespace EyouSoft.DAL.SystemStructure
{
   public class DFeeSettings : DALBase<MFeeSettings>, IDFeeSettings
   {
   }
}
