using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.Member
{
    /// <summary>
    /// 下级分销奖励结算
    /// </summary>
    public partial class XiaJiJiangLiJieSuan : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype")=="jiesuan") JieSuan();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);

            if (info == null)
            {
                RegisterScript(string.Format("var peiZhiInfo={0};var weiJieSuanYongJinJinE={1};", Newtonsoft.Json.JsonConvert.SerializeObject(new EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo()), 0));
                return;
            }

            var peiZhiInfo = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi();

            StringBuilder s = new StringBuilder();

            //s.AppendFormat("已结算下级分销奖励佣金：{0:F2}", info.YiShenQingYongJinJinE);
            s.AppendFormat("已结算金额：{0:F2}元", info.YiShenPiJinE);
            s.AppendFormat("，正在审核金额：{0:F2}元", info.YiShenQingJinE - info.YiShenPiJinE);
            //s.AppendFormat("未结算下级分销奖励佣金：{0:F2}", info.WeiJieSuanYongJinJinE);
            //s.AppendFormat("，当前下级分销奖励结算比例：{0}", peiZhiInfo.JieSuanBiLiBaiFenBi);

            //ltrBiLi.Text = string.Format("{0}", peiZhiInfo.JieSuanBiLiBaiFenBi);

            RegisterScript(string.Format("var peiZhiInfo={0};var weiJieSuanYongJinJinE={1};", Newtonsoft.Json.JsonConvert.SerializeObject(peiZhiInfo), info.WeiJieSuanYongJinJinE));
            if ((info.ZongJinE - info.YiShenQingJinE) >= 10)
            {
                KeTiQuJinE.Value = (Math.Floor((info.ZongJinE - info.YiShenQingJinE) / 10) * 10).ToString();
                s.AppendFormat("，可结算金额：{0:F2}元。", KeTiQuJinE.Value);
            }
            else
            {
                KeTiQuJinE.Value = "0";
                s.AppendFormat("，可结算金额：{0:F2}元。", "0.00");
            }
                ltrJinEXinXi.Text = s.ToString();
        }

        /// <summary>
        /// jiesuan 
        /// </summary>
        void JieSuan()
        {
            var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);
            var peiZhiInfo = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi();
            if (info == null) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求。")); }

            var txtYongJinJinE = Utils.GetDecimal(Utils.GetFormValue("txtYongJinJinE"));
            if (txtYongJinJinE <= 0) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请填写正确的结算下级分销奖励佣金金额。")); }
            if (txtYongJinJinE > Math.Floor((info.ZongJinE - info.YiShenQingJinE) / 10) * 10) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：结算下级分销奖励佣金金额不能大于结算下级分销奖励佣金金额。")); }
            if (txtYongJinJinE < 10) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：申请的结算下级分销奖励佣金金额不能小于10元")); }
            if (txtYongJinJinE % 10 !=0) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：申请的结算下级分销奖励佣金金额只能是10的倍数")); }

            var formInfo = new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo();
            formInfo.BiLi = peiZhiInfo.JieSuanBiLi;
            formInfo.HuiYuanId = HuiYuanInfo.UserId;
            formInfo.JiaoYiHao = string.Empty;
            formInfo.JinE = txtYongJinJinE;
            formInfo.ShiJian = DateTime.Now;
            formInfo.Status = EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.未处理;
            formInfo.TiChengId = string.Empty;
            formInfo.YongJinJinE = txtYongJinJinE;
            formInfo.ZhuanZhangCaoZuoRenId = 0;
            formInfo.ZhuanZhangShiJian = DateTime.Now;

            int bllRetCode = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().XiaJiFenXiaoTiCheng_C(formInfo);

            if (bllRetCode == 1) { Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功，请等待审核。")); }
            else { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败。")); }
            
        }
        #endregion
    }
}
