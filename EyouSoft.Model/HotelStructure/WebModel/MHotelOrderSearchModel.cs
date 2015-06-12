using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.HotelStructure.WebModel
{
    public class MHotelOrderSearchModel : MHotelOrder, ISearchable
    {
        public SearchModel SearchInfo { get; set; }
    }
}
