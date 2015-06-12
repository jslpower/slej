using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BKV
    {
        private readonly EyouSoft.IDAL.OtherStructure.IKV dal = new EyouSoft.DAL.OtherStructure.DKV();


        #region IKV 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> 
        public bool SetCompanySetting(EyouSoft.Model.MCompanySetting model)
        {
            return dal.SetCompanySetting(model);
        }

        ///// <summary>
        ///// 获取指定公司的配置信息
        ///// </summary>
        ///// <param name="companyId"></param>
        ///// <param name="fileKey"></param>
        ///// <returns></returns>
        //public string GetValue(string K)
        //{
        //    if (string.IsNullOrEmpty(K)) return null;
        //    return dal.GetValue(K);
        //}

        ///// <summary>
        ///// 设置指定公司的配置信息
        ///// </summary>
        ///// <param name="companyId">公司编号</param>
        ///// <param name="fieldKey">配置key</param>
        ///// <param name="fieldValue">配置value</param>
        ///// <returns></returns>
        //public bool SetValue(string K, string V)
        //{
        //    if (string.IsNullOrEmpty(K)) return false;
        //    return dal.SetValue(K, V);
        //}

        /// <summary>
        /// 获取公司配置信息
        /// </summary>
        public EyouSoft.Model.MCompanySetting GetCompanySetting()
        {
            return dal.GetCompanySetting();
        }



        /// <summary>
        /// 获取公司配置信息
        /// </summary>
        public string GetMenPiaoLinks()
        {
           return dal.GetMenPiaoLinks();
        }

        /// <summary>
        /// 设置下级分销奖励配置信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiXiaJiFenXiaoJiangLiPeiZhi(EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo info)
        {
            if (info == null) return 0;
            if (info.JieSuanBiLi <= 0 || info.JieSuanBiLi >= 1) return 0;
            if (info.ZuiXiaoJieSuanYongJinJinE < 0) return 0;

            int dalRetCode = dal.SheZhiXiaJiFenXiaoJiangLiPeiZhi(info);
            return dalRetCode;
        }

        /// <summary>
        /// 获取下级分销奖励配置信息
        /// </summary>
        /// <returns></returns>
        public EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo GetXiaJiFenXiaoJiangLiPeiZhi()
        {
            var info = dal.GetXiaJiFenXiaoJiangLiPeiZhi();
            if (info == null) info = new EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo();
            return info;
        }

        #endregion


    }
}
