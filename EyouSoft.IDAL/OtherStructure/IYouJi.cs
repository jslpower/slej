using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.WeiXin;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IDYouJi
    {


        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(MYouJi model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string YouJiId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MYouJi GetModel(string YouJiId);
        /// <summary>
        ///获取前一条或者后一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mark">-1 前一条，1 后一条(较早发布的消息)</param>
        /// <returns></returns>
        MYouJi GetPrevOrNextModel(MYouJi model, int mark);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        IList<MYouJi> GetList(int PageSize, int PageIndex, ref int RecordCount, MYouJiSer serModel);

        /// <summary>
        /// 修改游记内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateModel(MYouJi model);
    }
}