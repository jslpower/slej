using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.AccountStructure;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
    public class MScenicAndOrder : MScenicArea
    {
        public MScenicAreaOrder ScenicOrder { get; set; }
        public DateTime Ordertime { get; set; }
    }
}
