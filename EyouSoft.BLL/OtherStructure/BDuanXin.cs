using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 短信
    /// </summary>
    public class BDuanXin
    {
        /// <summary>
        /// 短信接口-登录账号
        /// </summary>
        const string TOPMIS_API_LOGIN_UID = "slejia";
        /// <summary>
        /// 短信接口-登录密码
        /// </summary>
        const string TOPMIS_API_LOGIN_PWD = "123456";
        /// <summary>
        /// 短信接口-获取TOKEN-URI
        /// </summary>
        const string TOPMIS_API_GETTOKEN_URI = "http://www.topmis.cn/app/sms/cloud/auth.form";
        /// <summary>
        /// 短信接口-发送短信-URI
        /// </summary>
        const string TOPMIS_API_SUBMIT_URI = "http://www.topmis.cn/app/sms/cloud/submit.form";
        /// <summary>
        /// 金奥接收消息提醒手机号码
        /// </summary>
        const string JINAO_DINGDANXIAOXI_SHOUJI = "15868456678";

        #region private members
        /// <summary>
        /// 获取发送短信token
        /// </summary>
        /// <returns></returns>
        string GetToken()
        {
            string api_login_uid = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("TOPMIS_LOGINKEY_UID");
            string api_login_pwd = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("TOPMIS_LOGINKEY_PWD");

            string xml = "<loginKey><accountId>{0}</accountId><password>{1}</password></loginKey>";
            //xml = string.Format(xml, TOPMIS_API_LOGIN_UID, TOPMIS_API_LOGIN_PWD);
            xml = string.Format(xml, api_login_uid, api_login_pwd);

            string cookies = string.Empty;
            string response = request.post(TOPMIS_API_GETTOKEN_URI, xml, "application/xml; charset=UTF-8");

            if (string.IsNullOrEmpty(response)) return string.Empty;

            /*var xauthToken = XElement.Parse(response);
            if (xauthToken == null) return string.Empty;
            var xtoken = Utils.GetXElement(xauthToken, "token");
            string token = Utils.GetXElementValue(xtoken);
            return token;*/

            //response xml:<?xml version="1.0" encoding="UTF-8"?><result><success>true</success><message>login success</message><data class="AuthToken"><accountId>slejia</accountId><token>slejia@00978b54-1832-48ce-ada8-207f7737e490</token></data></result>

            var xresult = XElement.Parse(response);
            if (xresult == null) return string.Empty;
            var xsuccess = Utils.GetXElement(xresult, "success");
            var xdata = Utils.GetXElement(xresult, "data");
            if (Utils.GetXElementValue(xsuccess) != "true") return string.Empty;
            var xtoken = Utils.GetXElement(xdata, "token");
            var token = Utils.GetXElementValue(xtoken);
            return token;
        }

        /// <summary>
        /// 发送线路订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin1(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(dingDanId);

            if (info == null) return 20002;
            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");

            string youKeXingMing = string.Empty;
            string youKeShouJi = string.Empty;

            youKeXingMing = info.LxrName;
            youKeShouJi = info.LxrTelephone;

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();

            if (!string.IsNullOrEmpty(info.XianLuName))
            {
                chanPingMingCheng = info.XianLuName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing ==  EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo=new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);

                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("已提交{0} {1}人", info.LDate.ToString("yyyy年MM月dd日"), info.ChengRenShu + info.ErTongShu);
                            neiRong.AppendFormat("[{0}]的线路订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("已在您的网店提交{0} {1}人", info.LDate.ToString("yyyy年MM月dd日"), info.ChengRenShu + info.ErTongShu);
                            neiRong.AppendFormat("[{0}]的线路订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您已提交{0} {1}人", info.LDate.ToString("yyyy年MM月dd日"), info.ChengRenShu + info.ErTongShu);
                            neiRong.AppendFormat("[{0}]的线路订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("已提交{0} {1}人", info.LDate.ToString("yyyy年MM月dd日"), info.ChengRenShu + info.ErTongShu);
                    neiRong.AppendFormat("[{0}]的线路订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您已提交{0} {1}人", info.LDate.ToString("yyyy年MM月dd日"), info.ChengRenShu + info.ErTongShu);
                    neiRong.AppendFormat("[{0}]的线路订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", info.LxrName);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("已为您提交{0} {1}人", info.LDate.ToString("yyyy年MM月dd日"), info.ChengRenShu + info.ErTongShu);
                neiRong.AppendFormat("[{0}]的线路订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的线路订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的线路订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的线路订单已确认。", info.OrderCode);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", info.LxrName);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的线路订单已确认。", info.OrderCode);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的线路订单已经付款{1}元。", info.OrderCode, info.JinE.ToString("F2"));
                            neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的线路订单已成功付款，请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的线路订单已成功付款。请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = info.LxrTelephone;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", info.LxrName);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的线路订单已成功付款。", info.OrderCode);
                            neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的线路订单已经付款{1}元。", info.OrderCode, info.JinE.ToString("F2"));
                    neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的线路订单已成功付款。请关注客户出行。", info.OrderCode);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的线路订单已成功付款。", info.OrderCode);
                    neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }

        /// <summary>
        /// 发送酒店订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin2(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(dingDanId);

            if (info == null) return 20002;

            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");

            string youKeXingMing=string.Empty;
            string youKeShouJi=string.Empty;

            var youKes=new EyouSoft.BLL.HotelStructure.BHotelOrder().GetContent(dingDanId);
            if(youKes!=null&&youKes.Count>0) 
            {
                youKeXingMing=youKes[0].ContactName;
                youKeShouJi=youKes[0].Mobile;
            }

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();


            if (!string.IsNullOrEmpty(info.HotelName))
            {
                chanPingMingCheng = info.HotelName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);

                if (!string.IsNullOrEmpty(info.SellerID) && !string.IsNullOrEmpty(info.SellerID.Trim()) && info.SellerID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SellerID);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("已提交{0} {1}间", info.CheckInDate.ToString("yyyy年MM月dd日"),info.RoomCount);
                            neiRong.AppendFormat("[{0}]的酒店订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("已在您的网店提交{0} {1}间", info.CheckInDate.ToString("yyyy年MM月dd日"), info.RoomCount);
                            neiRong.AppendFormat("[{0}]的酒店订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您已提交{0} {1}间", info.CheckInDate.ToString("yyyy年MM月dd日"), info.RoomCount);
                            neiRong.AppendFormat("[{0}]的酒店订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("已提交{0} {1}间", info.CheckInDate.ToString("yyyy年MM月dd日"), info.RoomCount);
                    neiRong.AppendFormat("[{0}]的酒店订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。",youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您已提交{0} {1}间", info.CheckInDate.ToString("yyyy年MM月dd日"), info.RoomCount);
                    neiRong.AppendFormat("[{0}]的酒店订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("已为您提交{0} {1}间", info.CheckInDate.ToString("yyyy年MM月dd日"), info.RoomCount);
                neiRong.AppendFormat("[{0}]的酒店订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.SellerID) && !string.IsNullOrEmpty(info.SellerID.Trim()) && info.SellerID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SellerID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的酒店订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的酒店订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的酒店订单已确认。", info.OrderCode);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的酒店订单已确认。", info.OrderCode);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.SellerID) && !string.IsNullOrEmpty(info.SellerID.Trim()) && info.SellerID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SellerID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的酒店订单已经付款{1}元。", info.OrderCode, info.TotalAmount.ToString("F2"));
                            neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的酒店订单已成功付款，请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的酒店订单已成功付款。请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = youKeShouJi;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的酒店订单已成功付款。", info.OrderCode);
                            neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的酒店订单已经付款{1}元。", info.OrderCode, info.TotalAmount.ToString("F2"));
                    neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的酒店订单已成功付款。请关注客户出行。", info.OrderCode);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的酒店订单已成功付款。", info.OrderCode);
                    neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }

        /// <summary>
        /// 发送景区订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin3(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(dingDanId);

            if (info == null) return 20002;

            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");

            string youKeXingMing = string.Empty;
            string youKeShouJi = string.Empty;

            youKeXingMing = info.ContactName;
            youKeShouJi = info.ContactTel;

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();


            if (!string.IsNullOrEmpty(info.ScenicName))
            {
                chanPingMingCheng = info.ScenicName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);

                if (!string.IsNullOrEmpty(info.SellerID) && !string.IsNullOrEmpty(info.SellerID.Trim()) && info.SellerID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SellerID);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy年MM月dd日"), info.Num);
                            neiRong.AppendFormat("[{0}]的门票订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("已在您的网店提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy年MM月dd日"), info.Num);
                            neiRong.AppendFormat("[{0}]的门票订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy年MM月dd日"), info.Num);
                            neiRong.AppendFormat("[{0}]的门票订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy年MM月dd日"), info.Num);
                    neiRong.AppendFormat("[{0}]的门票订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy年MM月dd日"), info.Num);
                    neiRong.AppendFormat("[{0}]的门票订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("已为您提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy年MM月dd日"), info.Num);
                neiRong.AppendFormat("[{0}]的门票订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.SellerID) && !string.IsNullOrEmpty(info.SellerID.Trim()) && info.SellerID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SellerID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的门票订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的门票订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的门票订单已确认。", info.OrderCode);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的门票订单已确认。", info.OrderCode);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.SellerID) && !string.IsNullOrEmpty(info.SellerID.Trim()) && info.SellerID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SellerID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的门票订单已经付款{1}元。", info.OrderCode, info.Price.ToString("F2"));
                            neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的门票订单已成功付款，请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的门票订单已成功付款。请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = youKeShouJi;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的门票订单已成功付款。", info.OrderCode);
                            neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的门票订单已经付款{1}元。", info.OrderCode, info.Price.ToString("F2"));
                    neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的门票订单已成功付款。请关注客户出行。", info.OrderCode);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的门票订单已成功付款。", info.OrderCode);
                    neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }

        /// <summary>
        /// 发送租车订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin4(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(dingDanId);

            if (info == null) return 20002;

            if (!info.LDate.HasValue) info.LDate = DateTime.Now;
            if (!info.ZuJin.HasValue) info.ZuJin = 0;

            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");

            string youKeXingMing = string.Empty;
            string youKeShouJi = string.Empty;

            youKeXingMing = info.LxrName;
            youKeShouJi = info.LxrTelephone;

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();


            if (!string.IsNullOrEmpty(info.CarName))
            {
                chanPingMingCheng = info.CarName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);

                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            if (!info.LDate.HasValue) info.LDate = DateTime.Now;
                            neiRong.AppendFormat("已提交{0} {1}台", info.LDate.Value.ToString("yyyy年MM月dd日"), info.Number);
                            neiRong.AppendFormat("[{0}]的租车订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("已在您的网店提交{0} {1}台", info.LDate.Value.ToString("yyyy年MM月dd日"), info.Number);
                            neiRong.AppendFormat("[{0}]的租车订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您已提交{0} {1}张", info.LDate.Value.ToString("yyyy年MM月dd日"), info.Number);
                            neiRong.AppendFormat("[{0}]的租车订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("已提交{0} {1}台", info.LDate.Value.ToString("yyyy年MM月dd日"), info.Number);
                    neiRong.AppendFormat("[{0}]的租车订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您已提交{0} {1}台", info.LDate.Value.ToString("yyyy年MM月dd日"), info.Number);
                    neiRong.AppendFormat("[{0}]的租车订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("已为您提交{0} {1}台", info.LDate.Value.ToString("yyyy年MM月dd日"), info.Number);
                neiRong.AppendFormat("[{0}]的租车订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的租车订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的租车订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的租车订单已确认。", info.OrderCode);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的租车订单已确认。", info.OrderCode);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.OperatorId);
                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的租车订单已经付款{1}元。", info.OrderCode, info.ZuJin.Value.ToString("F2"));
                            neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的租车订单已成功付款，请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的租车订单已成功付款。请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = youKeShouJi;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的租车订单已成功付款。", info.OrderCode);
                            neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的租车订单已经付款{1}元。", info.OrderCode, info.ZuJin.Value.ToString("F2"));
                    neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的租车订单已成功付款。请关注客户出行。", info.OrderCode);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的租车订单已成功付款。", info.OrderCode);
                    neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }

        /// <summary>
        /// 发送商城订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin5(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(dingDanId);            

            if (info == null) return 20002;

            var pinfo = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetModel(info.ProductID);

            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");
            string shangcheng_chanping_jidiao_shouji = string.Empty;
            string shangcheng_chanping_jidiao_xingming = string.Empty;

            if (pinfo != null)
            {
                var sup = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(pinfo.GYSid);
                if (sup != null)
                {
                    var memodel = new EyouSoft.IDAL.MemberStructure.BMember2().Get(sup.MemberID);
                    shangcheng_chanping_jidiao_xingming = memodel.MemberName;
                    shangcheng_chanping_jidiao_shouji = memodel.Mobile;
                }
            }

            string youKeXingMing = string.Empty;
            string youKeShouJi = string.Empty;

            youKeXingMing = info.ContactName;
            youKeShouJi = info.ContactPhone;

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();


            if (!string.IsNullOrEmpty(info.ProductName))
            {
                chanPingMingCheng = info.ProductName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.ContactID);

                if (!string.IsNullOrEmpty(info.SupplierID) && !string.IsNullOrEmpty(info.SupplierID.Trim()) && info.SupplierID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SupplierID);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            //neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("已提交 {0}份，",info.ProductNum);
                            neiRong.AppendFormat("[{0}]的商城订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);


                            duanXinInfo.JieShouShouJi = shangcheng_chanping_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            //neiRong.AppendFormat("已在您的网店提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("已在您的网店提交 {0}份", info.ProductNum);
                            neiRong.AppendFormat("[{0}]的商城订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            //neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("您已提交 {0}份", info.ProductNum);
                            neiRong.AppendFormat("[{0}]的商城订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    //neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                    neiRong.AppendFormat("已提交 {0}份", info.ProductNum);
                    neiRong.AppendFormat("[{0}]的商城订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);


                    duanXinInfo.JieShouShouJi = shangcheng_chanping_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    //neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                    neiRong.AppendFormat("您已提交 {0}份", info.ProductNum);
                    neiRong.AppendFormat("[{0}]的商城订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                //neiRong.AppendFormat("已为您提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                neiRong.AppendFormat("已为您提交 {0}份",info.ProductNum);
                neiRong.AppendFormat("[{0}]的商城订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.ContactID);
                if (!string.IsNullOrEmpty(info.SupplierID) && !string.IsNullOrEmpty(info.SupplierID.Trim()) && info.SupplierID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SupplierID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的商城订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的商城订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的商城订单已确认。", info.OrderCode);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的商城订单已确认。", info.OrderCode);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.ContactID);
                if (!string.IsNullOrEmpty(info.SupplierID) && !string.IsNullOrEmpty(info.SupplierID.Trim()) && info.SupplierID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SupplierID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的商城订单已经付款{1}元。", info.OrderCode, info.OrderPrice.ToString("F2"));
                            //neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);


                            duanXinInfo.JieShouShouJi = shangcheng_chanping_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的商城订单已成功付款。", info.OrderCode);
                            //neiRong.AppendFormat("请关注客户出行。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的商城订单已成功付款。", info.OrderCode);
                            //neiRong.AppendFormat("请关注客户出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = youKeShouJi;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的商城订单已成功付款。", info.OrderCode);
                            //neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的商城订单已经付款{1}元。", info.OrderCode, info.OrderPrice.ToString("F2"));
                    //neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);


                    duanXinInfo.JieShouShouJi = shangcheng_chanping_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的商城订单已成功付款。", info.OrderCode);
                    //neiRong.AppendFormat("请关注客户出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的商城订单已成功付款。", info.OrderCode);
                    //neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }

        /// <summary>
        /// 发送团购订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin6(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetModel(Utils.GetInt(dingDanId));

            if (info == null) return 20002;

            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");

            string youKeXingMing = string.Empty;
            string youKeShouJi = string.Empty;

            youKeXingMing = info.PeopleName;
            youKeShouJi = info.PeopleMobile;

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();


            if (!string.IsNullOrEmpty(info.ProductName))
            {
                chanPingMingCheng = info.ProductName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.PeopleID);

                if (!string.IsNullOrEmpty(info.SupplierID) && !string.IsNullOrEmpty(info.SupplierID.Trim()) && info.SupplierID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SupplierID);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            //neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("已提交 {0}份", info.ProductNum);
                            neiRong.AppendFormat("[{0}]的团购订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            //neiRong.AppendFormat("已在您的网店提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("已在您的网店提交 {0}份", info.ProductNum);
                            neiRong.AppendFormat("[{0}]的团购订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            //neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("您已提交 {0}份", info.ProductNum);
                            neiRong.AppendFormat("[{0}]的团购订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    //neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                    neiRong.AppendFormat("已提交 {0}份", info.ProductNum);
                    neiRong.AppendFormat("[{0}]的团购订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    //neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                    neiRong.AppendFormat("您已提交 {0}份", info.ProductNum);
                    neiRong.AppendFormat("[{0}]的团购订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                //neiRong.AppendFormat("已为您提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                neiRong.AppendFormat("已为您提交 {0}份", info.ProductNum);
                neiRong.AppendFormat("[{0}]的团购订单，订单号：{1}。", chanPingMingCheng, info.OrderCode);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.PeopleID);
                if (!string.IsNullOrEmpty(info.SupplierID) && !string.IsNullOrEmpty(info.SupplierID.Trim()) && info.SupplierID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SupplierID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的团购订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的团购订单已确认。", info.OrderCode);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的团购订单已确认。", info.OrderCode);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的团购订单已确认。", info.OrderCode);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.PeopleID);
                if (!string.IsNullOrEmpty(info.SupplierID) && !string.IsNullOrEmpty(info.SupplierID.Trim()) && info.SupplierID.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.SupplierID);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的团购订单已经付款{1}元。", info.OrderCode, info.OrderPrice.ToString("F2"));
                            neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的团购订单已成功付款，请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的团购订单已成功付款。请关注客户出行。", info.OrderCode);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = youKeShouJi;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的团购订单已成功付款。", info.OrderCode);
                            neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的团购订单已经付款{1}元。", info.OrderCode, info.OrderPrice.ToString("F2"));
                    neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的团购订单已成功付款。请关注客户出行。", info.OrderCode);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的团购订单已成功付款。", info.OrderCode);
                    neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }
        /// <summary>
        /// 发送签证订单短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        int FaSongDingDanDuanXin7(string dingDanId, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(dingDanId);

            if (info == null) return 20002;

            StringBuilder neiRong = new StringBuilder();
            string chanPingMingCheng = string.Empty;

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_kefu_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_XINGMING");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_xingming = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_XINGMING");

            string youKeXingMing = string.Empty;
            string youKeShouJi = string.Empty;

            youKeXingMing = info.LxrXingMing;
            youKeShouJi = info.LxrDianHua;

            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();


            if (!string.IsNullOrEmpty(info.QianZhengName))
            {
                chanPingMingCheng = info.QianZhengName;
                chanPingMingCheng = chanPingMingCheng.Replace("【", "").Replace("】", "");
                chanPingMingCheng = EyouSoft.Toolkit.Utils.HtmlDecode(chanPingMingCheng);
                chanPingMingCheng = Utils.GuoLvHtml(chanPingMingCheng);
                if (!string.IsNullOrEmpty(chanPingMingCheng) && chanPingMingCheng.Length > 4)
                {
                    chanPingMingCheng = chanPingMingCheng.Substring(0, 4) + "...";
                }
            }

            #region 下单
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.XiaDanRenId);

                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);

                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);

                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            //neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("已提交 {0}份", info.YuDingShuLiang);
                            neiRong.AppendFormat("[{0}]的签证订单，订单号：{1}。", chanPingMingCheng, info.DingDanHao);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("请及时审核确认！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：你好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("（会员{0} {1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            //neiRong.AppendFormat("已在您的网店提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("已在您的网店提交 {0}份", info.YuDingShuLiang);
                            neiRong.AppendFormat("[{0}]的签证订单，订单号：{1}。", chanPingMingCheng, info.DingDanHao);
                            //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("请等待平台审核！");

                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            //neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                            neiRong.AppendFormat("您已提交 {0}份", info.YuDingShuLiang);
                            neiRong.AppendFormat("[{0}]的签证订单，订单号：{1}。", chanPingMingCheng, info.DingDanHao);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    //neiRong.AppendFormat("已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                    neiRong.AppendFormat("已提交 {0}份", info.YuDingShuLiang);
                    neiRong.AppendFormat("[{0}]的签证订单，订单号：{1}。", chanPingMingCheng, info.DingDanHao);
                    //neiRong.AppendFormat("备注[{0}]。", info.XiaDanBeiZhu);
                    neiRong.AppendFormat("提交人：{0}，{1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("请及时审核确认！");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    //neiRong.AppendFormat("您已提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                    neiRong.AppendFormat("您已提交 {0}份", info.YuDingShuLiang);
                    neiRong.AppendFormat("[{0}]的签证订单，订单号：{1}。", chanPingMingCheng, info.DingDanHao);
                    neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180，请等待平台审核！");

                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                //neiRong.AppendFormat("已为您提交{0} {1}张", info.ChuFaRiQi.ToString("yyyy-MM-dd"), info.Num);
                neiRong.AppendFormat("已为您提交 {0}份", info.YuDingShuLiang);
                neiRong.AppendFormat("[{0}]的签证订单，订单号：{1}。", chanPingMingCheng, info.DingDanHao);
                neiRong.AppendFormat("请等待平台审核！");

                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 确认
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.XiaDanRenId);
                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的签证订单已确认。", info.DingDanHao);
                            neiRong.AppendFormat("请关注订单付款。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}，{1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的签证订单已确认。", info.DingDanHao);
                            neiRong.AppendFormat("请及时付款,谢谢！");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的签证订单已确认。", info.DingDanHao);
                    neiRong.AppendFormat("请及时付款,谢谢！");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }

                duanXinInfo.JieShouShouJi = youKeShouJi;
                neiRong = new StringBuilder();
                neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                neiRong.AppendFormat("为您提交的编号为{0}的签证订单已确认。", info.DingDanHao);
                neiRong.AppendFormat("请关注订单付款。");
                duanXinInfo.NeiRong = neiRong.ToString();
                FaSong(duanXinInfo);
            }
            #endregion

            #region 支付
            if (faSongLeiXing == EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付)
            {
                var xiaDanRenInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(info.XiaDanRenId);
                if (!string.IsNullOrEmpty(info.AgencyId) && !string.IsNullOrEmpty(info.AgencyId.Trim()) && info.AgencyId.Trim() != "-1")
                {
                    var fenXiaoShangInfo = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(info.AgencyId);
                    if (fenXiaoShangInfo != null)
                    {
                        var fenXiaoShangYongHuInfo = new EyouSoft.IDAL.MemberStructure.BMember2().Get(fenXiaoShangInfo.MemberID);
                        if (fenXiaoShangYongHuInfo != null)
                        {
                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}（{1} {2}）", fenXiaoShangInfo.WebsiteName, fenXiaoShangYongHuInfo.MemberName, fenXiaoShangYongHuInfo.Mobile);
                            neiRong.AppendFormat("生成的编号为{0}的签证订单已经付款{1}元。", info.DingDanHao, info.JinE.ToString("F2"));
                            neiRong.AppendFormat("请操作并发送出行通知。");
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = fenXiaoShangYongHuInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", fenXiaoShangYongHuInfo.MemberName);
                            neiRong.AppendFormat("您网店编号为{0}的签证订单已成功付款，请关注客户出行。", info.DingDanHao);
                            neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                            neiRong.AppendFormat("您提交的编号为{0}的签证订单已成功付款。请关注客户出行。", info.DingDanHao);
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);

                            duanXinInfo.JieShouShouJi = youKeShouJi;
                            neiRong = new StringBuilder();
                            neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                            neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                            neiRong.AppendFormat("为您提交的编号为{0}的签证订单已成功付款。", info.DingDanHao);
                            neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                            neiRong.AppendFormat("客服：{0}，{1}。", fenXiaoShangInfo.JinAoLXR, fenXiaoShangInfo.JinAoMobile);
                            neiRong.AppendFormat("总机：400-6588-180。");
                            duanXinInfo.NeiRong = neiRong.ToString();
                            FaSong(duanXinInfo);
                        }
                    }
                }
                else
                {
                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("商旅E家");
                    neiRong.AppendFormat("生成的编号为{0}的签证订单已经付款{1}元。", info.DingDanHao, info.JinE.ToString("F2"));
                    neiRong.AppendFormat("请操作并发送出行通知。");
                    neiRong.AppendFormat("提交人：会员{0}, {1}。", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("客户：{0}, {1}。", youKeXingMing, youKeShouJi);
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = xiaDanRenInfo.Mobile;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", xiaDanRenInfo.MemberName);
                    neiRong.AppendFormat("您提交的编号为{0}的签证订单已成功付款。请关注客户出行。", info.DingDanHao);
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);

                    duanXinInfo.JieShouShouJi = youKeShouJi;
                    neiRong = new StringBuilder();
                    neiRong.AppendFormat("{0}：您好！", youKeXingMing);
                    neiRong.AppendFormat("{0}（{1}）", xiaDanRenInfo.MemberName, xiaDanRenInfo.Mobile);
                    neiRong.AppendFormat("为您提交的编号为{0}的签证订单已成功付款。", info.DingDanHao);
                    neiRong.AppendFormat("请待操作完成后按新通知要求出行。");
                    neiRong.AppendFormat("客服：{0}，{1}。", jinao_dingdanxiaoxi_kefu_xingming, jinao_dingdanxiaoxi_kefu_shouji);
                    neiRong.AppendFormat("总机：400-6588-180。");
                    duanXinInfo.NeiRong = neiRong.ToString();
                    FaSong(duanXinInfo);
                }
            }
            #endregion

            return 10000;
        }
        #endregion

        #region public members
        /// <summary>
        /// 发送短信，返回10000成功，其它失败
        /// </summary>
        /// <returns></returns>
        public int FaSong(EyouSoft.Model.OtherStructure.MDuanXinInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.JieShouShouJi) || string.IsNullOrEmpty(info.NeiRong)) return 10001;

            System.Text.RegularExpressions.Regex _regShouJi = new System.Text.RegularExpressions.Regex("^(13|15|18|14)\\d{9}$");
            if (!_regShouJi.Match("15868456678").Success) return 10006;

            string token = GetToken();
            if (string.IsNullOrEmpty(token)) return 10002;

            if (info.NeiRong.IndexOf("【商旅e家】") < 0) info.NeiRong = info.NeiRong + "【商旅e家】";

            string api_login_uid = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("TOPMIS_LOGINKEY_UID");

            StringBuilder  xml = new StringBuilder();
            xml.Append("<sm>");
            //xml.AppendFormat("<accountId>{0}</accountId>", TOPMIS_API_LOGIN_UID);
            xml.AppendFormat("<accountId>{0}</accountId>", api_login_uid);
            xml.AppendFormat("<token>{0}</token>", token);
            xml.AppendFormat("<content>{0}</content>", info.NeiRong);
            xml.AppendFormat("<targetPhoneNo>{0}</targetPhoneNo>", info.JieShouShouJi);
            xml.AppendFormat("<customId>{0}</customId>",Guid.NewGuid().ToString());
            xml.AppendFormat("<isUrgent></isUrgent>");
            xml.Append("</sm>");

            string cookies = string.Empty;
            string response = request.post(TOPMIS_API_SUBMIT_URI, xml.ToString(), "application/xml; charset=UTF-8");

            if (string.IsNullOrEmpty(response)) return 10003;

            var xresult = XElement.Parse(response);
            if (xresult == null) return 10004;

            var xcode = Utils.GetXElement(xresult, "code");

            int code = Utils.GetInt(Utils.GetXElementValue(xcode), 10005);

            if (code == 0) return 10000;

            return code;
        }

        /// <summary>
        /// 发送短信，返回10000成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="faSongLeiXing">发送类型</param>
        /// <returns></returns>
        public int FaSongDingDanDuanXin(string dingDanId, EyouSoft.Model.Enum.DingDanLeiBie dingDanLeiXing, EyouSoft.Model.Enum.DuanXinFaSongLeiXing faSongLeiXing)
        {
            if (string.IsNullOrEmpty(dingDanId) || faSongLeiXing== EyouSoft.Model.Enum.DuanXinFaSongLeiXing.None) return 20000;

            int faSongRetCode = 20001;
            switch (dingDanLeiXing)
            {
                case EyouSoft.Model.Enum.DingDanLeiBie.线路订单: faSongRetCode = FaSongDingDanDuanXin1(dingDanId, faSongLeiXing); break;
                case EyouSoft.Model.Enum.DingDanLeiBie.酒店订单: faSongRetCode = FaSongDingDanDuanXin2(dingDanId, faSongLeiXing); break;
                case EyouSoft.Model.Enum.DingDanLeiBie.门票订单: faSongRetCode = FaSongDingDanDuanXin3(dingDanId, faSongLeiXing); break;
                case EyouSoft.Model.Enum.DingDanLeiBie.租车订单: faSongRetCode = FaSongDingDanDuanXin4(dingDanId, faSongLeiXing); break;
                case EyouSoft.Model.Enum.DingDanLeiBie.商城订单: faSongRetCode = FaSongDingDanDuanXin5(dingDanId, faSongLeiXing); break;
                case EyouSoft.Model.Enum.DingDanLeiBie.团购订单: faSongRetCode = FaSongDingDanDuanXin6(dingDanId, faSongLeiXing); break;
                case EyouSoft.Model.Enum.DingDanLeiBie.签证订单: faSongRetCode = FaSongDingDanDuanXin7(dingDanId, faSongLeiXing); break;
                default: break;
            }

            return faSongRetCode;
        }
        #endregion
    }
}
