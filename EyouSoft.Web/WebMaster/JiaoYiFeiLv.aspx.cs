using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class JiaoYiFeiLv : System.Web.UI.Page
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
            var info = new EyouSoft.BLL.OtherStructure.BKV().GetCompanySetting();
            txtJiaoYiFeiLv.Value = info.JiaoYiLv.ToString("F2");
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            decimal txtJiaoYiFeiLv = Utils.GetDecimal(Utils.GetFormValue("txtJiaoYiFeiLv"));
            if (txtJiaoYiFeiLv <= 0 || txtJiaoYiFeiLv >= 100) { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请填写正确的平台交易费率。")); }

            decimal JiaoYiFeiLv = txtJiaoYiFeiLv / 100;
            JiaoYiFeiLv = Utils.GetDecimal(txtJiaoYiFeiLv.ToString("F4"));


            var bllRetCode = new EyouSoft.BLL.OtherStructure.BKV().SheZhiJiaoYiFeiLv(JiaoYiFeiLv);

            if (bllRetCode==1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
        #endregion
    }
}
