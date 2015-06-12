using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class TuanGou : ClientModelViewPageBase<EyouSoft.Model.OtherStructure.MTuanGouChanPinSer>
    {
        #region 分页参数
        protected int PageIndex = 1;
        protected int recordCount;
        protected int PageSize = 9;
        int type = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != "")
            {
                type =Convert.ToInt32(Request.QueryString["type"]);
                if (type == 3)
                {
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 15;
                }
                else
                {
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 16;
                }
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
            if (type == 0 || type>=3)
            {
                type = 2;
            }
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            //serchModel.SupplierID = UserInfo.GysId;
            //string CpName = Utils.GetFormValue("CpName");
            if (CpName.Value.Trim() != "")
            {
                serchModel.ProductName = CpName.Value.Trim();
            }
            if (Request.QueryString["classid"] == "1")
            {
                orderby = "Salevolume desc";
            }
            string website = HttpContext.Current.Request.Url.Host.ToLower();

            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                BSellers bsells = new BSellers();
                var Daimodel = bsells.GetMSellersByWebSite(website);
                if (Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航 )
                {
                    serchModel.SupplierID = Daimodel.ID;
                }
            }

            //if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CpType"))) serchModel.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.ChanPinLeiXing), Utils.GetQueryStringValue("CpType"));
            serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type;
            if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
            {
                PageIndex = Convert.ToInt32(Common.Utils.GetQueryStringValue("page"));
            }
            serchModel.ValiDate = DateTime.Now.AddDays(-1);
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(PageSize, PageIndex, orderby, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
            }
            else
            {
                litNoMsg.Text = "<tr><td align='center' colspan='10'>暂无数据</td></tr>";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != "")
            {
               type = Convert.ToInt32(Request.QueryString["type"]);
            }
            initList(type);
        }
    }
}
