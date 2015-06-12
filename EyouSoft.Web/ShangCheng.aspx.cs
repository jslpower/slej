using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class ShangCheng : Common.Page.WebPageBase
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
            ((EyouSoft.Web.MasterPage.FrontNoFixed)(base.Master)).HeadMenuIndex = 9;
            initPage();
            InitAd();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            var menus = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, true);
            if (menus != null && menus.Count > 0)
            {
                rptMenu.DataSource = menus;
                rptMenu.DataBind();
            }
            string website = HttpContext.Current.Request.Url.Host.ToLower();
          
            string DaiLiId="";
            pageIndex = UtilsCommons.GetPagingIndex();
            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                
                BSellers bsells = new BSellers();
                var Daimodel = bsells.GetMSellersByWebSite(website);
                DaiLiId = Daimodel.ID;
                string sqlwhere = DaiLiId;
                if (Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                    if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("t")))
                    {
                        EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer model = new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer();
                        model.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                        model.MemberId = DaiLiId;
                        list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, model);
                    }
                    else
                        list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, sqlWhere = sqlwhere, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g") });
                //list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer() { isGetTrue = true, sqlWhere=sqlwhere, MemberId=DaiLiId, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐, EyouSoft.Model.Enum.ProductZT.上架 } });
                else
                    list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g") });
               

            }
            else
            {
                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g") });
                
            }

            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

            }

            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));
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
            var top = bll.GetList(5, (EyouSoft.Model.Enum.AdvArea)11);
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
        /// <summary>
        /// 返回图片路径
        /// </summary>
        /// <param name="imgs"></param>
        /// <returns></returns>
        protected string retuImgUrl(object imgs)
        {
            IList<MChanPinTuPian> tupians = (IList<MChanPinTuPian>)imgs;
            if (tupians != null && tupians.Count > 0) return tupians[0].FilePath;
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
