using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MoneyStructure;

namespace EyouSoft.BLL.MoneyStructure
{
    public class BApplyTiXian
    {
        private readonly EyouSoft.IDAL.MoneyStructure.IApplyTiXian dal = new EyouSoft.DAL.MoneyStructure.DApplyTiXian();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MApplyTiXian info)
        {
            if (info == null || string.IsNullOrEmpty(info.UserId) || string.IsNullOrEmpty(info.KaiHuBank) ||
                string.IsNullOrEmpty(info.KaiHuName) || string.IsNullOrEmpty(info.BankNum) || info.JinE<100) return false;
            info.TiXianTime = DateTime.Now;
            info.TiXianStatus = EyouSoft.Model.Enum.TiXianState.未提现;
            info.ApplyStatus = EyouSoft.Model.Enum.TiXianShenHe.未审核;
            info.TiXianId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Add(info);

            if (dalRetCode == 1)
            {
                var tiXianInfo = GetInfo(info.TiXianId);

                var zhiFuMingXiInfo = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
                zhiFuMingXiInfo.ApiJiaoYiHao = string.Empty; ;
                zhiFuMingXiInfo.DingDanId = tiXianInfo.TiXianId;
                zhiFuMingXiInfo.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.E额宝提现;
                zhiFuMingXiInfo.HuiYuanId = tiXianInfo.UserId;
                zhiFuMingXiInfo.JiaoYiHao = tiXianInfo.TransactionID;
                zhiFuMingXiInfo.JiaoYiJinE = tiXianInfo.JinE;
                zhiFuMingXiInfo.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.提现;
                zhiFuMingXiInfo.JiaoYiMiaoShu = string.Empty;
                zhiFuMingXiInfo.JiaoYiShiJian = DateTime.Now;
                zhiFuMingXiInfo.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易冻结;
                zhiFuMingXiInfo.MingXiId = string.Empty;
                zhiFuMingXiInfo.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.E额宝;

                new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(zhiFuMingXiInfo);
            }

            return dalRetCode == 1;
        }

        /// <summary>
        /// 获取用户提现冻结总金额
        /// </summary>
        /// <param name="userid">会员id</param>
        /// <returns></returns>
        public decimal GetDongJieJinE(string userid)
        {
            if (string.IsNullOrEmpty(userid)) return 0;

            return dal.GetDongJieJinE(userid);
        }

        /// <summary>
        /// 获取提现分页列表
        /// </summary>
        /// <param name="PageSize">页面显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序（name desc）</param>
        /// <param name="RecordCount">总数（output）</param>
        /// <param name="serModel">查询条件</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MoneyStructure.MApplyTiXian> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount, EyouSoft.Model.MoneyStructure.MApplyTiXianSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, null, ref RecordCount, serModel);
        }

        /*/// <summary>
        /// 获得提现实体Model
        /// </summary>
        /// <param name="TiXianID">提现id</param>
        /// <returns></returns>
        public MApplyTiXian GetModel(string TiXianID)
        {
            if (string.IsNullOrEmpty(TiXianID)) return null;
            return dal.GetModel(TiXianID);
        }

        /// <summary>
        /// 更新提现状态
        /// </summary>
        /// <param name="id">提现表主id</param>
        /// <param name="tixianstate">状态</param>
        /// <returns></returns>
        public int UpdateTiXianStatus(int id,EyouSoft.Model.Enum.TiXianState tixianstate)
        {
            if (string.IsNullOrEmpty(id.ToString())) return 0;
            return dal.UpdateTiXianStatus(id,tixianstate);
        }

        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="id">提现id</param>
        /// <param name="applystate">状态</param>
        /// <returns></returns>
        public int UpdateShenHeStatus(int id, EyouSoft.Model.Enum.TiXianShenHe applystate)
        {
            if (string.IsNullOrEmpty(id.ToString())) return 0;
            return dal.UpdateShenHeStatus(id, applystate);
        }

        /// <summary>
        /// 提现失败更新提现状态及原因
        /// </summary>
        /// <param name="id">提现表主id</param>
        /// <param name="tixianstate">状态</param>
        /// <param name="ShenHeBeiZhu">审核备注</param>
        /// <returns></returns>
        public int UpdateTiXianSB(int id, EyouSoft.Model.Enum.TiXianState tixianstate, string ShenHeBeiZhu)
        {
            if (string.IsNullOrEmpty(id.ToString())) return 0;
            return dal.UpdateTiXianSB(id, tixianstate, ShenHeBeiZhu);
        }

        /// <summary>
        /// 审核失败更新审核状态及原因
        /// </summary>
        /// <param name="id">提现id</param>
        /// <param name="applystate">状态</param>
        /// <param name="ShenHeBeiZhu">审核备注</param>
        /// <returns></returns>
        public int UpdateShenHeSB(int id, EyouSoft.Model.Enum.TiXianShenHe applystate, string ShenHeBeiZhu)
        {
            if (string.IsNullOrEmpty(id.ToString())) return 0;
            return dal.UpdateShenHeSB(id, applystate, ShenHeBeiZhu);
        }*/

        /// <summary>
        /// 获取提现信息业务实体
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <returns></returns>
        public MApplyTiXian GetInfo(string tiXianId)
        {
            if (string.IsNullOrEmpty(tiXianId)) return null;

            return dal.GetInfo(tiXianId);
        }

        /// <summary>
        /// 设置提现审核状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <param name="status">审核状态</param>
        /// <param name="beiZhu">备注</param>
        /// <returns></returns>
        public int SheZhiTiXianShenHeStatus(string tiXianId, EyouSoft.Model.Enum.TiXianShenHe status, string beiZhu)
        {
            if (string.IsNullOrEmpty(tiXianId)) return 0;

            int dalRetCode = dal.SheZhiTiXianStatus(tiXianId, 0, (int)status, beiZhu);

            if (dalRetCode == 1)
            {
                if (status == EyouSoft.Model.Enum.TiXianShenHe.未通过)
                {
                    var info = GetInfo(tiXianId);
                    new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().SheZhiMingXiStatus(info.UserId, info.TiXianId, EyouSoft.Model.Enum.DingDanLeiBie.E额宝提现, EyouSoft.Model.Enum.JiaoYiLeiBie.提现, EyouSoft.Model.Enum.ZhiFuFangShi.E额宝, EyouSoft.Model.Enum.JiaoYiStatus.交易失败);
                }
            }

            return dalRetCode;
        }

        /// <summary>
        /// 设置提现状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <param name="status">提现状态</param>
        /// <param name="beiZhu">备注</param>
        /// <returns></returns>
        public int SheZhiTiXianStatus(string tiXianId, EyouSoft.Model.Enum.TiXianState status, string beiZhu)
        {
            if (string.IsNullOrEmpty(tiXianId)) return 0;

            int dalRetCode = dal.SheZhiTiXianStatus(tiXianId, 1, (int)status, beiZhu);

            if (dalRetCode == 1)
            {
                var info = GetInfo(tiXianId);
                if (status == EyouSoft.Model.Enum.TiXianState.提现失败)
                {                    
                    new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().SheZhiMingXiStatus(info.UserId, info.TiXianId, EyouSoft.Model.Enum.DingDanLeiBie.E额宝提现, EyouSoft.Model.Enum.JiaoYiLeiBie.提现, EyouSoft.Model.Enum.ZhiFuFangShi.E额宝, EyouSoft.Model.Enum.JiaoYiStatus.交易失败);
                }

                if (status == EyouSoft.Model.Enum.TiXianState.已提现)
                {
                    new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().SheZhiMingXiStatus(info.UserId, info.TiXianId, EyouSoft.Model.Enum.DingDanLeiBie.E额宝提现, EyouSoft.Model.Enum.JiaoYiLeiBie.提现, EyouSoft.Model.Enum.ZhiFuFangShi.E额宝, EyouSoft.Model.Enum.JiaoYiStatus.交易成功);
                }
            }

            return dalRetCode;
        }
    }
}
