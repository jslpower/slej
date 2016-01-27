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
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            var serchModel = new EyouSoft.Model.OtherStructure.MDaiLiTuanGouSer();
            IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> list = new List<EyouSoft.Model.OtherStructure.MTuanGouChanPin>();
            string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
            //string website = "m.slej.cn".ToLower().Replace("m.", "");
            int recordCount = 0;
            string DaiLiId = "";
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                BSellers bsells = new BSellers();
                var Daimodel = bsells.GetMSellersByWebSite(website);
                DaiLiId = Daimodel.ID;
                string sqlwhere = DaiLiId;
                if (Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                {
                    if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("t")))
                    {
                        serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type;
                        serchModel.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                        serchModel.MemberId = DaiLiId;
                        serchModel.isGetTrue = true;
                        list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetDaiLiList(8, 1, ref recordCount, serchModel);
                    }
                    else
                    {
                        list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(8, 1, orderby, ref recordCount, new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer { sqlWhere = DaiLiId, ProductName = Utils.GetQueryStringValue("cName"), SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type, ValiDate = DateTime.Now.AddDays(-1), IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 } });
                    }
                }
                else
                {
                    list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(8, 1, orderby, ref recordCount, new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer { sqlWhere = DaiLiId, ProductName = Utils.GetQueryStringValue("cName"), SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type, ValiDate = DateTime.Now.AddDays(-1), IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 } });
                }
            }
            else
            {
                list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(8, 1, orderby, ref recordCount, new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer { sqlWhere = DaiLiId, ProductName = Utils.GetQueryStringValue("cName"), SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type, ValiDate = DateTime.Now.AddDays(-1), IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 } });

            }




            //if (website.IndexOf("slej.cn") > 1)
            //{
            //    BSellers bsells = new BSellers();
            //    var Daimodel = bsells.GetMSellersByWebSite(website);
            //    if (Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
            //    {
            //        serchModel.SupplierID = Daimodel.ID;
            //    }
            //}
            //serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type;
            //serchModel.ValiDate = DateTime.Now.AddDays(-1);
            //serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            //int recordCount = 0;
            //var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(8, 1, orderby, ref recordCount, serchModel);
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
