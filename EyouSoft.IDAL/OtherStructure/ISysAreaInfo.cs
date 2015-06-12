using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.IDAL
{
   /// <summary>
   /// 区域省份城市区县
   /// </summary>
   public interface ISysAreaInfo
   {
      #region  区域
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      bool ExistsSysArea(MSysArea model);
      /// <summary>
      /// 增加一条数据
      /// </summary>
      bool AddSysArea(MSysArea model);
      /// <summary>
      /// 更新一条数据
      /// </summary>
      bool UpdateSysArea(MSysArea model);
      /// <summary>
      /// 删除数据
      /// </summary>
      bool DeleteSysArea(int ID);
      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      MSysArea GetSysAreaModel(int ID);
      /// <summary>
      /// 更加区域编号获得区域名称
      /// </summary>
      /// <param name="ID"></param>
      /// <returns></returns>
      string GetSysAreaName(int ID);
      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      IList<MSysArea> GetSysAreaList(int pageSize, int pageIndex, ref int recordCount, MSysArea chaXun);
      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      IList<MSysArea> GetSysAreaList(int Top, MSysArea chaXun, string filedOrder);
      #endregion  区域

      #region  国家
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      bool ExistsSysCountry(MSysCountry model);
      /// <summary>
      /// 增加一条数据
      /// </summary>
      bool AddSysCountry(MSysCountry model);
      /// <summary>
      /// 更新一条数据
      /// </summary>
      bool UpdateSysCountry(MSysCountry model);
      /// <summary>
      /// 删除数据
      /// </summary>
      bool DeleteSysCountry(int ID);
      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      MSysCountry GetSysCountryModel(int ID);
      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      IList<MSysCountry> GetSysCountryList(int pageSize, int pageIndex, ref int recordCount, MSysCountry chaXun);
      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      IList<MSysCountry> GetSysCountryList(int Top, MSysCountry chaXun, string filedOrder);
      #endregion  国家

      #region  省份
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      bool ExistsSysProvince(MSysProvince model);
      /// <summary>
      /// 增加一条数据
      /// </summary>
      bool AddSysProvince(MSysProvince model);
      /// <summary>
      /// 更新一条数据
      /// </summary>
      bool UpdateSysProvince(MSysProvince model);
      /// <summary>
      /// 删除数据
      /// </summary>
      bool DeleteSysProvince(int ID);
      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      MSysProvince GetSysProvinceModel(int ID);
      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      IList<MSysProvince> GetSysProvinceList(int pageSize, int pageIndex, ref int recordCount, MSysProvince chaXun);
      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      IList<MSysProvince> GetSysProvinceList(int Top, MSysProvince chaXun, string filedOrder);
      #endregion  省份

      #region  城市
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      bool ExistsSysCity(MSysCity model);
      /// <summary>
      /// 增加一条数据
      /// </summary>
      bool AddSysCity(MSysCity model);
      /// <summary>
      /// 更新一条数据
      /// </summary>
      bool UpdateSysCity(MSysCity model);
      /// <summary>
      /// 删除数据
      /// </summary>
      bool DeleteSysCity(int ID);
      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      MSysCity GetSysCityModel(int ID);
      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      IList<MSysCity> GetSysCityList(int pageSize, int pageIndex, ref int recordCount, MSysCity chaXun);
      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      IList<MSysCity> GetSysCityList(int Top, MSysCity chaXun, string filedOrder);
      #endregion  城市

      #region  县区
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      bool ExistsSysDistrict(MSysDistrict model);
      /// <summary>
      /// 增加一条数据
      /// </summary>
      bool AddSysDistrict(MSysDistrict model);
      /// <summary>
      /// 更新一条数据
      /// </summary>
      bool UpdateSysDistrict(MSysDistrict model);
      /// <summary>
      /// 删除数据
      /// </summary>
      bool DeleteSysDistrict(int ID);
      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      MSysDistrict GetSysDistrictModel(int ID);
      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      IList<MSysDistrict> GetSysDistrictList(int pageSize, int pageIndex, ref int recordCount, MSysDistrict chaXun);
      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top"></param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      IList<MSysDistrict> GetSysDistrictList(int Top, MSysDistrict chaXun, string filedOrder);
      #endregion  县区

      int? GetProvinceIdByName(string name);
      int? GetCityIdByName(string name);
   }
}
