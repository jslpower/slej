using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Common
{
    public class UtilsCommons
    {
        #region 格式转换 create by dyz

        /// <summary>
        /// 金额显示格式处理
        /// </summary>
        /// <param name="m">金额</param>
        /// <param name="name">预定义的 System.Globalization.CultureInfo 名称或现有 System.Globalization.CultureInfo名称</param>
        /// <returns></returns>
        public static string GetMoneyString(decimal m, string name)
        {
            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(name);

            return m.ToString("c2", cultureInfo);
        }

        /// <summary>
        /// 金额显示格式处理
        /// </summary>
        /// <param name="o">金额</param>
        /// <param name="name">预定义的 System.Globalization.CultureInfo 名称或现有 System.Globalization.CultureInfo名称</param>
        /// <returns></returns>
        public static string GetMoneyString(object o, string name)
        {
            if (o != null)
            {
                return GetMoneyString(Utils.GetDecimal(o.ToString()), name);
            }

            return string.Empty;
        }

        /// <summary>
        /// 时间显示格式处理
        /// </summary>
        /// <param name="d">时间值</param>
        /// <param name="format">格式字符串。</param>
        /// <returns></returns>
        public static string GetDateString(DateTime d, string format)
        {
            if (d == null || d.ToString() == "" || d.Equals(Utils.GetDateTime("1900-1-1 0:00:00")) || d.Equals(Utils.GetDateTime("0001-01-01 0:00:00")))
            {
                return "";
            }
            else
            {
                return d.ToString(format);
            }
        }

        /// <summary>
        /// 时间显示格式处理
        /// </summary>
        /// <param name="d">时间值</param>
        /// <param name="format">格式字符串。</param>
        /// <returns></returns>
        public static string GetDateString(object d, string format)
        {
            if (d != null)
            {
                return GetDateString(Utils.GetDateTime(d.ToString()), format);
            }

            return string.Empty;
        }

        #endregion

        #region ajax request,response josn data.  create by cyn
        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode)
        {
            return AjaxReturnJson(retCode, string.Empty);
        }
        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <param name="retMsg">return msg</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode, string retMsg)
        {
            return AjaxReturnJson(retCode, retMsg, null);
        }

        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <param name="retMsg">return msg</param>
        /// <param name="retObj">return object</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode, string retMsg, object retObj)
        {
            string output = "{}";

            if (retObj != null)
            {
                output = Newtonsoft.Json.JsonConvert.SerializeObject(retObj);
            }

            return string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\",\"obj\":{2}}}", retCode, retMsg, output);
        }
        #endregion

        /// <summary>
        /// 获取分页页索引，url页索引查询参数为Page
        /// </summary>
        /// <returns></returns>
        public static int GetPagingIndex()
        {
            return GetPagingIndex("Page");
        }

        /// <summary>
        /// 获取分页页索引
        /// </summary>
        /// <param name="s">url页索引查询参数</param>
        /// <returns></returns>
        public static int GetPagingIndex(string s)
        {
            int index = Utils.GetInt(Utils.GetQueryStringValue(s), 1);

            return index < 1 ? 1 : index;
        }

        /// <summary>
        /// 分页参数处理
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        public static void Paging(int pageSize, ref int pageIndex, int recordCount)
        {
            if (pageSize < 1) pageSize = 1;
            int pageCount = recordCount / pageSize;
            if (recordCount % pageSize > 0) pageCount++;
            if (pageIndex > pageCount) pageIndex = pageCount;
            if (pageIndex < 1) pageIndex = 1;
        }

        public static bool IsToXls()
        {
            return Utils.GetQueryStringValue("toxls") == "1";
        }
        public static int GetToXlsRecordCount()
        {
            return Utils.GetInt(Utils.GetQueryStringValue("toxlsrecordcount"));
        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选择value值</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal)
        {
            return GetEnumDDL(ls, selectedVal ?? "-1", false);

        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选择value值</param>
        /// <param name="isFirst">是否存在默认请选择项</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, bool isFirst)
        {

            return GetEnumDDL(ls, selectedVal, isFirst, "-1", "-请选择-");
        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选中的值</param>
        /// <param name="defaultKey">默认值Id</param>
        /// <param name="defaultVal">默认值文本</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, string defaultKey, string defaultVal)
        {

            return GetEnumDDL(ls, selectedVal, true, defaultKey, defaultVal);
        }
        /// <summary>
        /// 获取枚举下拉菜单(该方法isFirst为否则后2个属性无效)
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选中的值</param>
        /// <param name="isFirst">是否有默认值</param>
        /// <param name="defaultKey">默认值Id</param>
        /// <param name="defaultVal">默认值文本</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, bool isFirst, string defaultKey, string defaultVal)
        {
            StringBuilder sb = new StringBuilder();
            if (isFirst)
            {
                sb.Append("<option value=\"" + defaultKey + "\" selected=\"selected\">" + defaultVal + "</option>");
            }

            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Value != selectedVal.Trim())
                {
                    sb.Append("<option value=\"" + ls[i].Value.Trim() + "\">" + ls[i].Text.Trim() + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + ls[i].Value.Trim() + "\" selected=\"selected\">" + ls[i].Text.Trim() + "</option>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取当前人员价格显示
        /// </summary>
        /// <param name="FeeType">产品类型</param>
        /// <param name="JIESUANJIA">结算价</param>
        /// <param name="MENSHIJIA">门市价</param>
        /// <returns></returns>
        public static decimal GetGYStijia(EyouSoft.Model.Enum.FeeTypes FeeType, decimal JIESUANJIA, decimal MENSHIJIA)
        {
            EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
            bilv = new EyouSoft.BLL.SystemStructure.BFeeSettings().GetByType(FeeType);
            if (bilv == null)
            {
                bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
            }
            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);
            if (!isLogin) return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.PuTongHuiYuanJia / 100M);//未登陆用户显示价格
            switch (huiYuanInfo.UserType)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.PuTongHuiYuanJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.GuiBinJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.免费代理:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.FreeFenXiaoJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.FenXiaoJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.YuanGongJia / 100M);
                default:
                    break;
            }
            return 0;
        }
        /// <summary>
        /// 获取当前人员价格显示
        /// </summary>
        /// <param name="FeeType">产品类型</param>
        /// <param name="JIESUANJIA">结算价</param>
        /// <param name="MENSHIJIA">门市价</param>
        /// <returns></returns>
        public static decimal GetGYStijia(EyouSoft.Model.Enum.FeeTypes FeeType, decimal JIESUANJIA, decimal MENSHIJIA, EyouSoft.Model.Enum.MemberTypes userTypes)
        {
            EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
            bilv = new EyouSoft.BLL.SystemStructure.BFeeSettings().GetByType(FeeType);
            if (bilv == null)
            {
                bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
            }
            //EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            //bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);
            //if (!isLogin) return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.PuTongHuiYuanJia / 100M);//未登陆用户显示价格
            switch (userTypes)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.PuTongHuiYuanJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.GuiBinJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.免费代理:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.FreeFenXiaoJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.FenXiaoJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    return JIESUANJIA + (MENSHIJIA - JIESUANJIA) * (bilv.YuanGongJia / 100M);
                default:
                    break;
            }
            return 0;
        }
        /// <summary>
        /// 获取分销价格
        /// </summary>
        /// <param name="FeeType">产品类型</param>
        /// <param name="dingdanjine">订单金额</param>
        /// <param name="userType">分销商类型</param>
        /// <returns></returns>
        public static decimal GetGYStijia(EyouSoft.Model.Enum.FeeTypes FeeType, decimal dingdanjine, EyouSoft.Model.Enum.MemberTypes userType)
        {
            EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
            bilv = new EyouSoft.BLL.SystemStructure.BFeeSettings().GetByType(FeeType);
            if (bilv == null)
            {
                bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
            }
            switch (userType)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                    return dingdanjine;
                case EyouSoft.Model.Enum.MemberTypes.免费代理:
                    return dingdanjine + dingdanjine * (bilv.FreeFenXiaoJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    return dingdanjine + dingdanjine * (bilv.FenXiaoJia / 100M);
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    return dingdanjine + dingdanjine * (bilv.YuanGongJia / 100M); ;
                default:
                    break;
            }
            return dingdanjine + dingdanjine * (bilv.FenXiaoJia / 100M);
        }

        /// <summary>
        /// 转换对应的订单类别
        /// </summary>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public static EyouSoft.Model.Enum.DingDanLeiBie ConvterOrderType(EyouSoft.Model.OtherStructure.DingDanType ordertype)
        {
            switch (ordertype)
            {
                case EyouSoft.Model.OtherStructure.DingDanType.长线订单:
                case EyouSoft.Model.OtherStructure.DingDanType.短线订单:
                case EyouSoft.Model.OtherStructure.DingDanType.出境订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.线路订单;
                case EyouSoft.Model.OtherStructure.DingDanType.商城订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.商城订单;
                case EyouSoft.Model.OtherStructure.DingDanType.门票订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.门票订单;
                case EyouSoft.Model.OtherStructure.DingDanType.酒店订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.酒店订单;
                case EyouSoft.Model.OtherStructure.DingDanType.签证订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.签证订单;
                case EyouSoft.Model.OtherStructure.DingDanType.团购订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.团购订单;
                case EyouSoft.Model.OtherStructure.DingDanType.租车订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.租车订单;
                case EyouSoft.Model.OtherStructure.DingDanType.单团订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.自组团订单;
                case EyouSoft.Model.OtherStructure.DingDanType.机票订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.机票订单;
                case EyouSoft.Model.OtherStructure.DingDanType.充值订单:
                    return EyouSoft.Model.Enum.DingDanLeiBie.充值订单;
                default:
                    break;
            }

            return EyouSoft.Model.Enum.DingDanLeiBie.线路订单;
        }
       

    }
}
