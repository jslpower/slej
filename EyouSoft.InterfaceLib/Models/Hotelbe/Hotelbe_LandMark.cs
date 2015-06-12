using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.Hotelbe
{
    public class MLandMark
    {
        public MLandMark()
        { }
        #region Model
        private int _id;
        private string _citycode;
        private string _cityname;
        private string _areacode;
        private string _areaname;
        private string _areapinyin;
        private string _provicename;
        private string _landmarkname;
        private string _landmarkchildcode;
        private string _landmarkchildname;
        private string _landmarkchildpinyin;
        private string _mercatorx;
        private string _mercatory;
        private string _latitude;
        private string _longitude;

        /// <summary>
        /// 主键id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityCode
        {
            set { _citycode = value; }
            get { return _citycode; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 一级地标代码
        /// </summary>
        public string AreaCode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 一级地标名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 一级地标拼音
        /// </summary>
        public string AreaPinyin
        {
            set { _areapinyin = value; }
            get { return _areapinyin; }
        }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProviceName
        {
            set { _provicename = value; }
            get { return _provicename; }
        }
        /// <summary>
        /// 二级地标名称，“NONE”表示无二级地标，三级地标直接隶属于一级地标
        /// </summary>
        public string LandMarkName
        {
            set { _landmarkname = value; }
            get { return _landmarkname; }
        }
        /// <summary>
        /// 三级地标代码
        /// </summary>
        public string LandMarkChildCode
        {
            set { _landmarkchildcode = value; }
            get { return _landmarkchildcode; }
        }
        /// <summary>
        /// 三级地标名称
        /// </summary>
        public string LandMarkChildName
        {
            set { _landmarkchildname = value; }
            get { return _landmarkchildname; }
        }
        /// <summary>
        /// 三级地标拼音
        /// </summary>
        public string LandMarkChildPinYin
        {
            set { _landmarkchildpinyin = value; }
            get { return _landmarkchildpinyin; }
        }
        /// <summary>
        /// 墨卡托X坐标
        /// </summary>
        public string MercatorX
        {
            set { _mercatorx = value; }
            get { return _mercatorx; }
        }
        /// <summary>
        /// 墨卡托Y坐标
        /// </summary>
        public string MercatorY
        {
            set { _mercatory = value; }
            get { return _mercatory; }
        }
        /// <summary>
        /// 维度
        /// </summary>
        public string Latitude
        {
            set { _latitude = value; }
            get { return _latitude; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
        }
        #endregion Model
    }
}
