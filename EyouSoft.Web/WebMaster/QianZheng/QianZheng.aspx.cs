using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;


namespace EyouSoft.Web.WebMaster.QianZheng
{
    public partial class QianZheng : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "delete") Delete();
            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "isindex" && id != "")
            {
                Response.Clear();
                Response.Write(UpdateState());
                Response.End();
            }
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (UserInfo.LeiXing==0)
            {
                if (!CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.签证管理_签证管理))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-100", "你没有操作权限"));
                }
            }
            else if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {

            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("-100", "你没有操作权限"));
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo();
            info.Name = Utils.GetQueryStringValue("txtQianZhengName");
            info.GuoJiaId = Utils.GetIntNull(Utils.GetQueryStringValue("txtGuoJiaId"));
            info.SuoShuLingQu = Utils.GetQueryStringValue("txtSuoShuLingQu");
            info.QianZhengLeiXing = (EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing), Utils.GetQueryStringValue("txtQianZhengLeiXing"));

            if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {
                info.GysId = UserInfo.GysId;
            }

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            int pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            int pageSize = 20;

            var chaXun = GetChaXunInfo();

            var items = new EyouSoft.BLL.QianZhengStructure.BQianZheng().GetQianZhengs(pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptlist.DataSource = items;
                rptlist.DataBind();

                this.FenYe.intPageSize = pageSize;
                this.FenYe.CurrencyPage = pageIndex;
                this.FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        ///  delete
        /// </summary>
        void Delete()
        {
            string txtQianZhengId = Utils.GetFormValue("txtQianZhengId");
            int txtFaBuRenId = Utils.GetInt(Utils.GetFormValue("txtFaBuRenId"));

            if (string.IsNullOrEmpty(txtQianZhengId) || txtFaBuRenId < 1)
            {
                RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));
            }

            var bllRetCode = new EyouSoft.BLL.QianZhengStructure.BQianZheng().Delete(txtQianZhengId, txtFaBuRenId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("0", "签证下存在已预订的订单信息，不可删除。"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }


        #endregion
        #region 签证状态
        /// <summary>
        /// 签证显示
        /// </summary>
        /// <param name="obj">签证状态</param>
        /// <param name="isbool">是否首页显示</param>
        /// <param name="ID">签证id</param>
        /// <returns></returns>
        protected string CheIsIndex(object isbool, object ID)
        {
            if (isbool == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
            if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
            {
                sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"iPage.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
            }
            else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"iPage.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                  "上架", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
            }
            return sb.ToString();
        }
        #endregion
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        private string UpdateState()
        {
            string id = Utils.GetQueryStringValue("id");
            string state = Utils.GetQueryStringValue("state");
            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(state)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
            var enstate = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)Utils.GetInt(state);
            EyouSoft.BLL.QianZhengStructure.BQianZheng bll = new EyouSoft.BLL.QianZhengStructure.BQianZheng();
            string msg = "";
            if (bll.UpdateState(id, enstate))
            {
                msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
            }
            return msg;
        }
        #region protected members
        /// <summary>
        /// 根据ID获取国家名称
        /// </summary>
        /// <param name="GuojiaID"></param>
        /// <returns></returns>
        protected string GetGuojiaName(int GuojiaID)
        {
            var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia().GetInfo(GuojiaID);

            if (info != null) return info.Name1;

            return string.Empty;
        }
        #endregion
    }
}
