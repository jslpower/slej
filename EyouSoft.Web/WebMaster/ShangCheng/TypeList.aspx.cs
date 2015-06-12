using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class TypeList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("del") == "1") Del();
            if (!IsPostBack)
            {
                initList();
            }

        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            var serchModel = new EyouSoft.Model.MallStructure.MShangChengLeiBieSer();
            pageIndex = UtilsCommons.GetPagingIndex();
            serchModel.TypeName = Utils.GetQueryStringValue("CName");

            var list = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(pageSize, pageIndex, ref recordCount, serchModel);
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

        /// <summary>
        /// 获取类别名称
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        protected string getTypeName(string typeid)
        {
            var model = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(Utils.GetInt(typeid));
            if (model == null) return "";
            return model.TypeName;
        }
        /// <summary>
        /// 删除分类
        /// </summary>
        void Del()
        {
            int result = new EyouSoft.BLL.MallStructure.BShangChengXiLie().Delete(Utils.GetQueryStringValue("id"));
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "删除成功" : "请核查分类下是否有产品"));
            Response.End();
        }
    }
}
