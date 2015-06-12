//线路产品相关信息数据访问类接口 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.XianLuStructure
{
    /// <summary>
    /// 线路产品相关信息数据访问类接口
    /// </summary>
    public interface IXianLu
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="InterfaceID"></param>
        /// <returns></returns>
        string ExistsInterfaceID(string InterfaceID, EyouSoft.Model.XianLuStructure.LineSource LineSource);
        /// <summary>
        /// 写入线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MXianLuInfo info);
        /// <summary>
        /// 获取线路产品信息业务实体
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        MXianLuInfo GetInfo(string xianLuId);
        /// <summary>
        /// 更新线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MXianLuInfo info);
        /// <summary>
        /// 更新接口线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int OutUpdate(MXianLuInfo info);
        /// <summary>
        /// 删除线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        int Delete(string xianLuId);
        /// <summary>
        /// 获取线路产品信息集合，分页
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        IList<MXianLuInfo> GetXianLus(int pageSize, int pageIndex, ref int recordCount, MXianLuChaXunInfo chaXun);
        /// <summary>
        /// 获取线路产品信息集合，SELECT TOP(expression) 
        /// </summary>
        /// <param name="topExpression">指定返回行数的数值表达式</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        IList<MXianLuInfo> GetXianLus(int topExpression, MXianLuChaXunInfo chaXun);
        /// <summary>
        /// 增加关注数
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <param name="expression">增加数量的数值表达式</param>
        /// <returns></returns>
        bool JiaGuanZhuShu(string xianLuId, int expression);
        /// <summary>
        /// 设置线路状态
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <param name="zhuangTais">状态数组</param>
        /// <returns></returns>
        bool SheZhiZhuangTai(string xianLuId, XianLuZhuangTai[] zhuangTais);
        /// <summary>
        /// 删除线路状态
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        bool DeleteZhuangTai(string xianLuId);
        /// <summary>
        /// 写入团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertTuanGou(MXianLuTuanGouInfo info);
        /// <summary>
        /// 更新团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int UpdateTuanGou(MXianLuTuanGouInfo info);
        /// <summary>
        /// 删除团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="tuanGouId">团购编号</param>
        /// <returns></returns>
        int DeleteTuanGou(string tuanGouId);
        /// <summary>
        /// 获取线路团购信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        IList<MXianLuTuanGouInfo> GetTuanGous(int pageSize, int pageIndex, ref int recordCount, MXianLuTuanGouChaXunInfo chaXun);
        /// <summary>
        /// 获取线路团购信息业务实体
        /// </summary>
        /// <param name="tuanGouId">团购编号</param>
        /// <returns></returns>
        MXianLuTuanGouInfo GetTuanGouInfo(string tuanGouId);

        /// <summary>
        /// 增加一条线路回访数据
        /// </summary>
        bool AddDianPing(MXianLuDianPing model);
        /// <summary>
        /// 更新一条线路回访数据
        /// </summary>
        bool UpdateDianPing(MXianLuDianPing model);
        /// <summary>
        /// 更新一条回访记录的审核状态
        /// </summary>
        /// <param name="DianPingIds"></param>
        /// <returns></returns>
        bool UpdateDianPing(bool IsCheck, params string[] DianPingIds);
        /// <summary>
        /// 删除线路回访数据
        /// </summary>
        bool DeleteDianPing(params string[] DianPingIds);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MXianLuDianPing GetDianPingModel(string DianPingId);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<MXianLuDianPing> GetDianPingList(int PageSize, int PageIndex, ref int RecordCount, MDianPingSeach Search);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        IList<MXianLuDianPing> GetDianPingList(int Top, string XianLuId);

        /// <summary>
        /// 根据线路编号获取满意度
        /// </summary>
        /// <param name="xianLuId"></param>
        /// <returns></returns>
        decimal GetManYiDuByXianLuId(string xianLuId);

        /// <summary>
        /// 设置线路具体发班日期差异信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">发班信息</param>
        /// <returns></returns>
        int SheZhiXianLuTourChaYi(MXianLuTourInfo info);
        /// <summary>
        /// 更新发班信息
        /// </summary>
        /// <param name="xianlu">线路</param>
        /// <returns></returns>
        int UpdateToursDataLS(MXianLuInfo xianlu);
        /// <summary>
        /// 更新航班信息
        /// </summary>
        /// <param name="xianlu">线路</param>
        /// <returns></returns>
        int UpdateToursTra(MXianLuInfo xianlu);
        /// <summary>
        /// 获取发班信息
        /// </summary>
        /// <param name="tourid">发班编号</param>
        /// <returns></returns>
        MXianLuTourInfo GetTourInfo(string tourid);
        /// <summary>
        /// 设置线路状态
        /// </summary>
        /// <param name="ids">线路编号</param>
        /// <param name="zt">线路状态</param>
        /// <returns></returns>
        int setXianLuZT(string[] ids, XianLuZT zt);
        /// <summary>
        /// 获取出发地列表
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.MSysCity> getChuFaCitys();
    }
}
