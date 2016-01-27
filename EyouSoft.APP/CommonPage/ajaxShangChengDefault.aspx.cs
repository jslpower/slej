using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxShangChengDefault : System.Web.UI.Page
    {
        protected int pageIndex = 1, pageSize = 6, recordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string isGet = Utils.GetQueryStringValue("isGet");

            if (isGet == "1")
            {
                initPage();
            }

        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {

            string cName = Utils.GetQueryStringValue("cName");
            int leibie = Utils.GetInt(Utils.GetQueryStringValue("lid"));
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));

            string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");

            string DaiLiId = "";
            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {

                BSellers bsells = new BSellers();
                var Daimodel = bsells.GetMSellersByWebSite(website);
                if (Daimodel != null) DaiLiId = Daimodel.ID;
                string sqlwhere = DaiLiId;
                if (Daimodel != null && Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                {
                    if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("t")))
                    {
                        EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer model = new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer();
                        model.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                        model.MemberId = DaiLiId;
                        list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, model);

                    }
                    else
                    {

                        list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, sqlWhere = sqlwhere, ProductName = cName, TypeID = leibie, isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g") });

                    }
                }
                else
                {

                    list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = cName, TypeID = leibie, isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g") });



                }
            }
            else
            {

                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = cName, TypeID = leibie, isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g") });



            }





            int isPage = 0;
            if (recordCount % pageSize != 0)
            {
                isPage = recordCount / pageSize + 1;
            }
            else
            {
                isPage = recordCount / pageSize;
            }
            if (list != null && list.Count > 0)
            {

                if (isPage >= pageIndex)
                {
                    rptlist.DataSource = list;
                    rptlist.DataBind();
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
