using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;
using EyouSoft.IDAL.AccountStructure;
namespace EyouSoft.WAP.Mall
{
    public partial class ShangChengLianMeng : System.Web.UI.Page
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 1000;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
            InitAd();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {

            var serchModel = new EyouSoft.Model.MallStructure.MLianMengSer();
            pageIndex = UtilsCommons.GetPagingIndex();
            serchModel.SiteName = Utils.GetQueryStringValue("cName");
            serchModel.modelTp = EyouSoft.Model.Enum.ModelTypes.购物广场联盟;
            IList<MLianMeng> list = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(pageSize, pageIndex, ref recordCount, serchModel);


            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

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
                    strbu.AppendFormat(" <a href=\"ShangCheng.aspx?lid={0}\">{1}</a>", item.TypeID, item.TypeName);
                }
            }

            return strbu.ToString();
        }
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, EyouSoft.Model.Enum.AdvArea.购物广场联盟);
            #region 图片处理

            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (top != null && top.Count > 0)
            {
                foreach (var item in top)
                {
                    files.Add(TuPian.F1(item.ImgPath, 640, 200));
                    hrefs.Add(item.AdvLink);
                }

            }
            ScrollImg1.ImgUrl = files;
            ScrollImg1.HrefUrl = hrefs;
            ScrollImg1.ImgGth = 200;
            ScrollImg1.ImgWid = 640;
            #endregion
        }
        /// <summary>
        /// 返回图片路径
        /// </summary>
        /// <param name="imgs"></param>
        /// <returns></returns>
        protected string retuImgUrl(object imgURL)
        {
            string img = imgURL.ToString(); ;
            if (!string.IsNullOrEmpty(img)) return TuPian.F1(img, 640, 200);
            return "/images/mall_img001.gif";
        }

    }
}
