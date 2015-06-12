using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.BLL.OtherStructure
{
    public class BYuMing
    {
        private readonly EyouSoft.IDAL.OtherStructure.IYuMing dal = new EyouSoft.DAL.OtherStructure.DYuMing();
        public MYuMing GetYuMingInfo(string url)
        {
            if (string.IsNullOrEmpty(url)) return new MYuMing();
            return dal.GetYuMing(url);
        }
    }
}
