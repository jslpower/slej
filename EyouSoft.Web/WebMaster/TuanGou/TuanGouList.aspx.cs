using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster.TuanGou
{
    public partial class TuanGouList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("del") == "1") Del();
            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "isindex" && id != "")
            {
                Response.Clear();
                Response.Write(UpdateState());
                Response.End();
            }
            initList();

        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            //serchModel.SupplierID = UserInfo.GysId;
            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            {
                serchModel.SupplierID = UserInfo.GysId;
            }
            serchModel.ProductName = Utils.GetQueryStringValue("CpName");
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CpType"))) serchModel.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.ChanPinLeiXing), Utils.GetQueryStringValue("CpType"));
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CxType"))) serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.ChanPinLeiXing), Utils.GetQueryStringValue("CxType"));
            pageIndex = UtilsCommons.GetPagingIndex();
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindExportPage();
            }
            else
            {
                litNoMsg.Text = "<tr><td align='center' colspan='10'>暂无数据</td></tr>";
            }

        }


        /// <summary>
        /// 删除分类
        /// </summary>
        void Del()
        {
            int result = new EyouSoft.BLL.OtherStructure.BTuanGou().Delete(Utils.GetInt(Utils.GetQueryStringValue("id")));
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "删除成功" : "删除失败"));
            Response.End();
        }
        #region 团购状态
        /// <summary>
        /// 团购首页显示
        /// </summary>
        /// <param name="obj">团购状态</param>
        /// <param name="isbool">是否首页显示</param>
        /// <param name="ID">团购id</param>
        /// <returns></returns>
        protected string CheIsIndex(object isbool, object ID)
        {
            if (isbool == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
            if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
            {
                sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
            }
            else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
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
            EyouSoft.BLL.OtherStructure.BTuanGou bll = new EyouSoft.BLL.OtherStructure.BTuanGou();
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
        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion
    }
}
