using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.AccountStructure;

namespace EyouSoft.Model.MemberStructure.WebModel
{
    public class MMemberAndSeller : MMember2
    {
        public MSellers Seller { get; set; }
    }
}
