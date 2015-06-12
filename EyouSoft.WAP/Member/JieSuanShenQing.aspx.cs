using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class JieSuanShenQing : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("type") == "jiesuan") JieSuan();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);

            if (info != null)
            {


                var peiZhiInfo = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi();

                YiJieSuan.Text = info.YiShenPiJinE.ToString("f2");
                DongJie.Text = (info.YiShenQingJinE - info.YiShenPiJinE).ToString("f2");

                if ((info.ZongJinE - info.YiShenQingJinE) >= 10)
                {
                    KeTiQuJinE.Value = (Math.Floor((info.ZongJinE - info.YiShenQingJinE) / 10) * 10).ToString();
                    KeJieSuan.Text = Convert.ToDecimal(KeTiQuJinE.Value).ToString("f2");
                }
                else
                {
                    KeTiQuJinE.Value = "0";
                    KeJieSuan.Text = "0.00";
                }
            }
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
            if (txtYongJinJinE % 10 != 0) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：申请的结算下级分销奖励佣金金额只能是10的倍数")); }

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
