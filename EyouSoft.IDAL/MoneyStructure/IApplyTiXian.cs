using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.Model.MoneyStructure;

namespace EyouSoft.IDAL.MoneyStructure
{
    public interface IApplyTiXian
    {
        /// <summary>
        /// 增加提现申请
        /// </summary>
        /// <param name="model">提现model</param>
        /// <returns>返回1成功，0-失败</returns>
        int Add(MApplyTiXian model);
        /// <summary>
        /// 获取用户提现冻结总金额
        /// </summary>
        /// <param name="userid">会员id</param>
        /// <returns></returns>
        decimal GetDongJieJinE(string userid);
        /// <summary>
        /// 获取提现分页列表
        /// </summary>
        /// <param name="PageSize">页面显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序（name desc）</param>
        /// <param name="RecordCount">总数（output）</param>
        /// <param name="serModel">查询条件</param>
        /// <returns></returns>
        IList<EyouSoft.Model.MoneyStructure.MApplyTiXian> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount, EyouSoft.Model.MoneyStructure.MApplyTiXianSer serModel);
        
        /*/// <summary>
        /// 获得提现实体Model
        /// </summary>
        /// <param name="TiXianID">提现id</param>
        /// <returns></returns>
        MApplyTiXian GetModel(string TiXianID);
        /// <summary>
        /// 更新提现状态
        /// </summary>
        /// <param name="id">提现表主id</param>
        /// <param name="tixianstate">状态</param>
        /// <returns></returns>
        int UpdateTiXianStatus(int id,EyouSoft.Model.Enum.TiXianState tixianstate);
        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="id">提现id</param>
        /// <param name="applystate">状态</param>
        /// <returns></returns>
        int UpdateShenHeStatus(int id, EyouSoft.Model.Enum.TiXianShenHe applystate);
        /// <summary>
        /// 提现失败更新提现状态及原因
        /// </summary>
        /// <param name="id">提现表主id</param>
        /// <param name="tixianstate">状态</param>
        /// <param name="ShenHeBeiZhu">审核备注</param>
        /// <returns></returns>
        int UpdateTiXianSB(int id, EyouSoft.Model.Enum.TiXianState tixianstate, string ShenHeBeiZhu);
        /// <summary>
        /// 审核失败更新审核状态及原因
        /// </summary>
        /// <param name="id">提现id</param>
        /// <param name="applystate">状态</param>
        /// <param name="ShenHeBeiZhu">审核备注</param>
        /// <returns></returns>
        int UpdateShenHeSB(int id, EyouSoft.Model.Enum.TiXianShenHe applystate, string ShenHeBeiZhu);*/

        /// <summary>
        /// 获取提现信息业务实体
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <returns></returns>
        MApplyTiXian GetInfo(string tiXianId);

        /// <summary>
        /// 设置提现状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <param name="fs">0:审核 1:提现</param>
        /// <param name="status">(int)状态</param>
        /// <param name="beiZhu">备注</param>
        /// <returns></returns>
        int SheZhiTiXianStatus(string tiXianId, int fs, int status, string beiZhu);
    }
}
