using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxTuanGou : System.Web.UI.Page
    {
        protected int type = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != "")
            {
                type = Convert.ToInt32(Request.QueryString["type"]);
            }
            if (!IsPostBack)
            {
                initList(type);
            }
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList(int type)
        {
            string orderby = "IssueTime desc";
            if (type == 0 || type >= 3)
            {
                type = 2;
            }
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            string website = HttpContext.Current.Request.Url.Host.ToLower();
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type;
            serchModel.ValiDate = DateTime.Now.AddDays(-1);
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            int recordCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(8, pageindex, orderby, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                if (recordCount > (pageindex - 1) * 8)
                {
                    Repeater1.DataSource = list;
                }
                else
                {
                    Repeater1.DataSource = null;
                }
                Repeater1.DataBind();
            }

        }
    }
}
