using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
   public interface IKV
   {
      #region IKV 成员

      /// <summary>
      /// 增加一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns> 
      bool SetCompanySetting(EyouSoft.Model.MCompanySetting model);

      string GetMenPiaoLinks();
      ///// <summary>
      ///// 获取指定公司的配置信息
      ///// </summary>
      ///// <param name="companyId"></param>
      ///// <param name="fileKey"></param>
      ///// <returns></returns>
      //string GetValue(string K);


      ///// <summary>
      ///// 设置指定公司的配置信息
      ///// </summary>
      ///// <param name="companyId">公司编号</param>
      ///// <param name="fieldKey">配置key</param>
      ///// <param name="fieldValue">配置value</param>
      ///// <returns></returns>
      //bool SetValue(string K, string V);

      /// <summary>
      /// 获取公司配置信息
      /// </summary>
      EyouSoft.Model.MCompanySetting GetCompanySetting();

       /// <summary>
       /// 设置下级分销奖励配置信息，返回1成功，其它失败
       /// </summary>
       /// <param name="info">实体</param>
       /// <returns></returns>
       int SheZhiXiaJiFenXiaoJiangLiPeiZhi(EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo info);

       /// <summary>
       /// 获取下级分销奖励配置信息
       /// </summary>
       /// <returns></returns>
       EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo GetXiaJiFenXiaoJiangLiPeiZhi();
       /// <summary>
       /// 设置交易费率
       /// </summary>
       /// <param name="FeiLv"></param>
       /// <returns></returns>
       int SheZhiJiaoYiFeiLv(decimal FeiLv);
       
      #endregion
   }
}
