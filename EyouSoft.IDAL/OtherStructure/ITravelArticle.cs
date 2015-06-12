using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.IDAL
{
    /// <summary>
    /// 旅游资讯
    /// </summary>
    public interface ITravelArticle
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(MTravelArticle model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(MTravelArticle model);
        /// <summary>
        /// 删除数据
        /// </summary>
        bool Delete(string ArticleID);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(params string[] Ids);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MTravelArticle GetModel(string ArticleID);
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        IList<MTravelArticle> GetList(int pageSize, int pageIndex, ref int recordCount, MTravelArticleCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder);
        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        IList<MTravelArticle> GetTopList(int Top, MTravelArticleCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder);
        /// <summary>
        /// 根据类别获取资讯或公告
        /// </summary>
        /// <param name="Top">条数</param>
        /// <param name="classid">类别</param>
        /// <returns></returns>
        IList<EyouSoft.Model.MTravelArticle> GetTopList(int Top, int classid);
        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="Id"></param>
        void SetClick(string Id);

        /// <summary>
        /// 获取首页底部的四个帮助信息
        /// </summary>
        /// <returns></returns>
        IList<Model.MTravelArticle> GetHeadZiXun();

        #region 旅游资讯留言
        /// <summary>
        /// 增加一条留言
        /// </summary>
        bool AddLiuYan(EyouSoft.Model.MTravelArticleLY model);
        /// <summary>
        /// 回复留言
        /// </summary>
        bool UpdateLiuYan(EyouSoft.Model.MTravelArticleLY model);
        /// <summary>
        /// 更新留言的审核状态
        /// </summary>
        /// <param name="DianPingIds"></param>
        /// <returns></returns>
        bool UpdateLiuYan(bool IsCheck, params string[] LiuYanIds);
        /// <summary>
        /// 删除留言数据
        /// </summary>
        bool DeleteLiuYan(params string[] LiuYanIds);
        /// <summary>
        /// 得到一个留言对象实体
        /// </summary>
        EyouSoft.Model.MTravelArticleLY GetLiuYanModel(string LiuYanId);
        /// <summary>
        /// 获得留言数据列表
        /// </summary>
        IList<EyouSoft.Model.MTravelArticleLY> GetLiuYanList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MTravelArticleLYCX chaxun);
        /// <summary>
        /// 获得留言前几行数据
        /// </summary>
        IList<EyouSoft.Model.MTravelArticleLY> GetLiuYanList(int Top, EyouSoft.Model.MTravelArticleLYCX chaxun);
        #endregion
    }
}
