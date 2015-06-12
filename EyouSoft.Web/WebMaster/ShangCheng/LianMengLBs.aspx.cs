using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class LianMengLBs : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("del") == "1") Del();
            initList();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            EyouSoft.Model.MallStructure.MLianMengLeiBieSer ser = new EyouSoft.Model.MallStructure.MLianMengLeiBieSer();
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("mt")))
            {
                ser.modelTp = (EyouSoft.Model.Enum.ModelTypes)Utils.GetInt(Utils.GetQueryStringValue("mt"));
            }
            var list = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(pageSize, pageIndex, ref recordCount, ser);
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
            int result = new EyouSoft.BLL.MallStructure.BLianMeng().DeleteLB(Utils.GetQueryStringValue("id"));
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "删除成功" : "删除失败"));
            Response.End();
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
