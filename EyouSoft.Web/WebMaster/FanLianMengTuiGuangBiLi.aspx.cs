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
    /// 返联盟推广比例管理
    /// </summary>
    public partial class FanLianMengTuiGuangBiLi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var items = new EyouSoft.BLL.OtherStructure.BTuiGuang().GetTuiGuangFanLiBiLis();

            if (items == null || items.Count == 0)
            {
                items = new List<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo>();
                items.Add(new EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo());
            }

            rpt.DataSource = items;
            rpt.DataBind();            
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var txtJinE = Utils.GetFormValues("txtJinE");
            var txtBiLi = Utils.GetFormValues("txtBiLi");

            if (txtJinE.Length == 0) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：至少要填写一个返联盟推广返利比例。")); }
            if (txtJinE.Length != txtBiLi.Length) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求。")); }

            var items = new List<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo>();

            for (var i = 0; i < txtJinE.Length; i++)
            {
                var item = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo();
                item.BiLi = Utils.GetDecimal((Utils.GetDecimal(txtBiLi[i]) / 100).ToString("F4"));
                item.JinE = Utils.GetDecimal(txtJinE[i]);
                items.Add(item);
            }

            var bllRetCode = new EyouSoft.BLL.OtherStructure.BTuiGuang().SheZhiTuiGuangFanLiBiLi(items);

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：销售金额不能有重复。"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
        #endregion
    }
}
