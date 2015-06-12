using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;
using EyouSoft.Model.Enum;


namespace EyouSoft.Web
{
    public partial class XiuXianYuLe : Common.Page.WebPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount = 0;
        protected int pageSize = 30;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 9;
            initMenu();
            string t = Utils.GetQueryStringValue("t");
            initList();
            InitAd();
        }
        /// <summary>
        /// 初始购物联盟列表
        /// </summary>
        void initList()
        {
            var serchModel = new EyouSoft.Model.MallStructure.MLianMengSer();
            pageIndex = UtilsCommons.GetPagingIndex();
            serchModel.SiteName = Utils.GetQueryStringValue("key");
            serchModel.LieBieID = Utils.GetIntNull(Utils.GetQueryStringValue("lid"));
            serchModel.modelTp = EyouSoft.Model.Enum.ModelTypes.休闲娱乐会所;
            IList<MLianMeng> list = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(pageSize, pageIndex, ref recordCount, serchModel);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);

            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

            }
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));

        }
        /// <summary>
        /// 初始化菜单
        /// </summary>
        void initMenu()
        {
            int itemCount = 0;
            IList<MLianMengLeiBie> list = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(1000, 1, ref itemCount, new MLianMengLeiBieSer() { modelTp = EyouSoft.Model.Enum.ModelTypes.休闲娱乐会所 });
            if (list != null && list.Count > 0)
            {
                rptmenus.DataSource = list;
                rptmenus.DataBind();
            }

        }

        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, AdvArea.休闲娱乐会所);
            if (top != null && top.Count > 0)
            {
                for (int i = 0; i < top.Count; i++)
                {
                    if (top.Count > 3)
                    {
                        if (i != top.Count - 1)
                        {
                            toplist += "<li style='position: absolute; left: " + (830 * i) + "px; display: block;'>"
                                + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                        }
                        else
                        {
                            toplist += "<li style='position: absolute; left: -830px; display: block;'>"
                                + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                        }
                    }
                    else
                    {

                        toplist += "<li style='position: absolute; left: " + (830 * i) + "px; display: block;'>"
                                + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                    }
                    dianlist += "<li><a href='#'>" + (i + 1) + "</a></li>";
                }
            }
        }
    }
}
