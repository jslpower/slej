using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 下级分销奖励提成比例
    /// </summary>
    public partial class XiaJiJiangLiBiLi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi();

            txtJieSuanBiLi.Value = (info.JieSuanBiLi*100).ToString("F2");
            txtZuiXiaoJieSuanYongJinJinE.Value = info.ZuiXiaoJieSuanYongJinJinE.ToString("F2");
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = new EyouSoft.Model.MXiaJiFenXiaoJiangLiPeiZhiInfo();

            decimal txtJieSuanBiLi = Utils.GetDecimal(Utils.GetFormValue("txtJieSuanBiLi"));
            decimal txtZuiXiaoJieSuanYongJinJinE = Utils.GetDecimal(Utils.GetFormValue("txtZuiXiaoJieSuanYongJinJinE"));
            if (txtJieSuanBiLi <= 0 || txtJieSuanBiLi >= 100) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请填写正确的下级分销奖励佣金结算比例。")); }
            if (txtZuiXiaoJieSuanYongJinJinE <= 0) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请填写正确的下级分销奖励最小结算佣金。")); }

            decimal jieSuanBiLi = txtJieSuanBiLi / 100;
            jieSuanBiLi = Utils.GetDecimal(jieSuanBiLi.ToString("F4"));

            info.JieSuanBiLi = jieSuanBiLi;
            info.ZuiXiaoJieSuanYongJinJinE = txtZuiXiaoJieSuanYongJinJinE;

            var bllRetCode = new EyouSoft.BLL.OtherStructure.BKV().SheZhiXiaJiFenXiaoJiangLiPeiZhi(info);

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
        #endregion
    }
}
