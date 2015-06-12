using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web
{
    public partial class Visa : System.Web.UI.Page
    {
        #region 分页参数
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 4;
            initPage();
            InitAd();

        }
        private void initPage()
        {
            EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia bll = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia();
            EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaChaXunInfo model = new EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaChaXunInfo();
            model.Zhou = EyouSoft.Model.Enum.QianZhengStructure.Zhou.亚洲;
            YaZhou.DataSource = bll.GetGuoJias(model);
            YaZhou.DataBind();
            model.Zhou = EyouSoft.Model.Enum.QianZhengStructure.Zhou.欧洲;
            OuZhou.DataSource = bll.GetGuoJias(model);
            OuZhou.DataBind();
            model.Zhou = EyouSoft.Model.Enum.QianZhengStructure.Zhou.美洲;
            MeiZhou.DataSource = bll.GetGuoJias(model);
            MeiZhou.DataBind();
            model.Zhou = EyouSoft.Model.Enum.QianZhengStructure.Zhou.大洋洲;
            DaYang.DataSource = bll.GetGuoJias(model);
            DaYang.DataBind();
            model.Zhou = EyouSoft.Model.Enum.QianZhengStructure.Zhou.非洲;
            FeiZhou.DataSource = bll.GetGuoJias(model);
            FeiZhou.DataBind();
        }

        /// 绑s定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, (EyouSoft.Model.Enum.AdvArea)12);
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
