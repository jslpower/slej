using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IYuMing
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.OtherStructure.MYuMing GetYuMing(string URL);
    }
}
