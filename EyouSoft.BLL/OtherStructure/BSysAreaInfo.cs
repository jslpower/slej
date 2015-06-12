using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.OtherStructure
{
   /// <summary>
   /// 区域省份城市区县
   /// </summary>
   public class BSysAreaInfo
   {
      private readonly EyouSoft.IDAL.ISysAreaInfo dal = new EyouSoft.DAL.DSysAreaInfo();

      #region constructure
      /// <summary>
      /// default constructor
      /// </summary>
      public BSysAreaInfo() { }
      #endregion

      #region public members

      #region  区域

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysArea(EyouSoft.Model.MSysArea model)
      {
         return dal.ExistsSysArea(model);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public int AddSysArea(EyouSoft.Model.MSysArea model)
      {
         if (model != null && !string.IsNullOrEmpty(model.AreaName))
         {
            if (ExistsSysArea(new EyouSoft.Model.MSysArea { AreaName = model.AreaName }))
            {
               return -1;
            }

            return dal.AddSysArea(model) ? 1 : -2;
         }

         return 0;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public int UpdateSysArea(EyouSoft.Model.MSysArea model)
      {
         if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.AreaName))
         {
            if (ExistsSysArea(new EyouSoft.Model.MSysArea { AreaName = model.AreaName, ID = model.ID }))
            {
               return -1;

            }

            return dal.UpdateSysArea(model) ? 1 : -2;
         }

         return 0;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysArea(int ID)
      {
         if (ID > 0)
            return dal.DeleteSysArea(ID);
         else
            return false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysArea GetSysAreaModel(int ID)
      {
         if (ID > 0)
            return dal.GetSysAreaModel(ID);
         else
            return null;
      }

      /// <summary>
      /// 更加区域编号获得区域名称
      /// </summary>
      /// <param name="ID"></param>
      /// <returns></returns>
      public string GetSysAreaName(int ID)
      {
         if (ID > 0)
            return dal.GetSysAreaName(ID);
         else
            return null;
      }

      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysArea> GetSysAreaList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysArea chaXun)
      {
         if (!Utils.ValidPaging(pageSize, pageIndex))
            return null;
         return dal.GetSysAreaList(pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysArea> GetSysAreaList(int Top, EyouSoft.Model.MSysArea chaXun)
      {
         return dal.GetSysAreaList((Top < 0 ? 0 : Top), chaXun, "");
      }

      #endregion  区域

      #region  国家

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysCountry(EyouSoft.Model.MSysCountry model)
      {
         return dal.ExistsSysCountry(model);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysCountry(EyouSoft.Model.MSysCountry model)
      {
         if (model != null && !string.IsNullOrEmpty(model.CnName))
            return dal.AddSysCountry(model);
         else
            return false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysCountry(EyouSoft.Model.MSysCountry model)
      {
         if (model != null && model.Id > 0 && !string.IsNullOrEmpty(model.CnName))
            return dal.UpdateSysCountry(model);
         else
            return false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysCountry(int ID)
      {
         if (ID > 0)
            return dal.DeleteSysCountry(ID);
         else
            return false;
      }

      public int? GetProvinceIdByName(string name)
      {
         return dal.GetProvinceIdByName(name);
      }

      public int? GetCityIdByName(string name)
      {
         return dal.GetCityIdByName(name);

      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysCountry GetSysCountryModel(int ID)
      {
         if (ID > 0)
            return dal.GetSysCountryModel(ID);
         else
            return null;
      }

      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysCountry> GetSysCountryList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysCountry chaXun)
      {
         if (!Utils.ValidPaging(pageSize, pageIndex))
            return null;
         return dal.GetSysCountryList(pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysCountry> GetSysCountryList(int Top, EyouSoft.Model.MSysCountry chaXun)
      {
         return dal.GetSysCountryList((Top < 0 ? 0 : Top), chaXun, "");
      }

      #endregion  国家

      #region  省份

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysProvince(EyouSoft.Model.MSysProvince model)
      {
         return dal.ExistsSysProvince(model);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysProvince(EyouSoft.Model.MSysProvince model)
      {
         if (model != null && !string.IsNullOrEmpty(model.Name))
            return dal.AddSysProvince(model);
         else
            return false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysProvince(EyouSoft.Model.MSysProvince model)
      {
         if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.Name))
            return dal.UpdateSysProvince(model);
         else
            return false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysProvince(int ID)
      {
         if (ID > 0)
            return dal.DeleteSysProvince(ID);
         else
            return false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysProvince GetSysProvinceModel(int ID)
      {
         if (ID > 0)
            return dal.GetSysProvinceModel(ID);
         else
            return null;
      }

      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysProvince> GetSysProvinceList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysProvince chaXun)
      {
         if (!Utils.ValidPaging(pageSize, pageIndex))
            return null;
         return dal.GetSysProvinceList(pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysProvince> GetSysProvinceList(int Top, EyouSoft.Model.MSysProvince chaXun)
      {
         return dal.GetSysProvinceList((Top < 0 ? 0 : Top), chaXun, "");
      }

      #endregion  省份

      #region  城市

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysCity(EyouSoft.Model.MSysCity model)
      {
         return dal.ExistsSysCity(model);

      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysCity(EyouSoft.Model.MSysCity model)
      {
         if (model != null && model.ProvinceId > 0 && !string.IsNullOrEmpty(model.Name))
            return dal.AddSysCity(model);
         else
            return false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysCity(EyouSoft.Model.MSysCity model)
      {
         if (model != null && model.ProvinceId > 0 && !string.IsNullOrEmpty(model.Name))
            return dal.UpdateSysCity(model);
         else
            return false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysCity(int ID)
      {
         if (ID > 0)
            return dal.DeleteSysCity(ID);
         else
            return false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysCity GetSysCityModel(int ID)
      {
         if (ID > 0)
            return dal.GetSysCityModel(ID);
         else
            return null;
      }

      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysCity> GetSysCityList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysCity chaXun)
      {
         if (!Utils.ValidPaging(pageSize, pageIndex))
            return null;
         return dal.GetSysCityList(pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysCity> GetSysCityList(int Top, EyouSoft.Model.MSysCity chaXun)
      {
         return dal.GetSysCityList((Top < 0 ? 0 : Top), chaXun, "");
      }

      #endregion  城市

      #region  县区

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysDistrict(EyouSoft.Model.MSysDistrict model)
      {
         return dal.ExistsSysDistrict(model);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysDistrict(EyouSoft.Model.MSysDistrict model)
      {
         if (model != null && model.ProvinceId > 0 && model.CityId > 0 && !string.IsNullOrEmpty(model.Name))
            return dal.AddSysDistrict(model);
         else
            return false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysDistrict(EyouSoft.Model.MSysDistrict model)
      {
         if (model != null && model.ProvinceId > 0 && model.CityId > 0 && !string.IsNullOrEmpty(model.Name))
            return dal.UpdateSysDistrict(model);
         else
            return false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysDistrict(int ID)
      {
         if (ID > 0)
            return dal.DeleteSysDistrict(ID);
         else
            return false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysDistrict GetSysDistrictModel(int ID)
      {
         if (ID > 0)
            return dal.GetSysDistrictModel(ID);
         else
            return null;
      }

      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysDistrict> GetSysDistrictList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysDistrict chaXun)
      {
         if (!Utils.ValidPaging(pageSize, pageIndex))
            return null;
         return dal.GetSysDistrictList(pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysDistrict> GetSysDistrictList(int Top, EyouSoft.Model.MSysDistrict chaXun)
      {
         return dal.GetSysDistrictList((Top < 0 ? 0 : Top), chaXun, "");
      }

      #endregion  县区

      #endregion
   }
}
