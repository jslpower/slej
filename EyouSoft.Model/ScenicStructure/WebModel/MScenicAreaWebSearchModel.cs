using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.SystemStructure;
using Linq.Bussiness;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
    public class MScenicAreaWebSearchModel : MScenicArea, ISearchable
    {
        public IList<MScenicTicketsWebBindModel> TicketInfo { get; set; }



        public MScenicTicketsWebBindModel TicketFirst { get; set; }

        public MScenicAreaImg ImgFirst { get; set; }

        public new int? CityId { get; set; }
        public new int? ProvinceId { get; set; }

        /// <summary>
        /// 左边搜索框用的
        /// </summary>
        public string JingQuName { get; set; }
        /// <summary>
        /// 左边搜索框用的
        /// </summary>
        public int? CityId2 { get; set; }
        /// <summary>
        /// 左边搜索框用的
        /// </summary>
        public int? ProvinceId2 { get; set; }
        /// <summary>
        /// 左边搜索框用的
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 状态（首页推荐、上下架）
        /// </summary>
        public XianLuZT[] IsIndex { get; set; }

        public SearchModel SearchInfo
        {
            get;
            set;
        }

        public string bindtxtinfo { get; set; }
    }
}
