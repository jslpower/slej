using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.MallStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP.Mall
{
    public partial class ModList : System.Web.UI.Page
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 16;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {


            pageIndex = UtilsCommons.GetPagingIndex();
            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();
            var serchModel = new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g"), GYSid = Utils.GetQueryStringValue("gid") };

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("t")))
            {
                string url = HttpContext.Current.Request.Url.Host.Replace("m.", "");
                //string url = "8568.slej.cn";
                EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(url);
                if (seller != null)
                {
                    EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer model = new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer();
                    model.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                    model.MemberId = seller.ID;
                    list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, model);
                }
                lblTypeName.Text = "热销宝贝";
            }
            else
            {
                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, serchModel);
            }

            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

            }


            var menus = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, false);
            var menuList = menus.Where(i => i.ParentID == 0).ToList();
            if (menuList != null && menuList.Count > 0)
            {
                rptMenu.DataSource = menuList;
                rptMenu.DataBind();
            }
            if (serchModel != null && serchModel.TypeID > 0)
            {
                lblTypeName.Text = menus.Where(i => i.TypeID == serchModel.TypeID).First().TypeName;
            }
            if (serchModel != null && !string.IsNullOrEmpty(serchModel.GYSid))
            {
                var item = new EyouSoft.BLL.SystemStructure.BSupplier().GetModel(serchModel.GYSid);
                lblTypeName.Text = item.SupplierName;
            }

        }
        /// <summary>
        /// 获取二级目录
        /// </summary>
        /// <param name="id">父节点</param>
        /// <returns></returns>
        protected string getMenu(object id)
        {
            int pid = Utils.GetInt(id.ToString());
            System.Text.StringBuilder strbu = new System.Text.StringBuilder();
            var list = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { ParentID = pid }, false);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    strbu.AppendFormat(" <a href=\"ModList.aspx?lid={0}\">{1}</a>", item.TypeID, item.TypeName);
                }
            }

            return strbu.ToString();
        }
        /// <summary>
        /// 返回图片路径
        /// </summary>
        /// <param name="imgs"></param>
        /// <returns></returns>
        protected string retuImgUrl(object imgs)
        {
            IList<MChanPinTuPian> tupians = (IList<MChanPinTuPian>)imgs;
            if (tupians != null && tupians.Count > 0) return TuPian.F1(tupians[0].FilePath, 640, 200);
            return "/images/mall_img001.gif";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="youhuijia"></param>
        /// <param name="menshijia"></param>
        /// <returns></returns>
        protected string GetJINE(object youhuijia, object menshijia)
        {
            decimal n = Utils.GetDecimal(youhuijia.ToString());
            decimal m = Utils.GetDecimal(menshijia.ToString());
            return UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, n, m, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0");
        }
    }
}
