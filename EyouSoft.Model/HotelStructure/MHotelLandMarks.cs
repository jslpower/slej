using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.HotelStructure
{
    /// <summary>
    /// 酒店-地理位置（地标）
    /// </summary>
   [Table("tbl_HotelLandMarks")]
    public class MHotelLandMarks
    {
        public MHotelLandMarks() { }
        /// <summary>
        /// 编号
        /// </summary>
        [PrimaryKey]
        [Identity(IdentityType.Increment)]
        public int Id { get; set; }
        /// <summary>
        /// 地标
        /// </summary>
        public string Por { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 城市三字码
        /// </summary>
        public string CityCode { get; set; }
    }
}
