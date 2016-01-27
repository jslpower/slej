using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxShangChengList : System.Web.UI.Page
    {
        protected int pageIndex = 1, pageSize = 12, recordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string isGet = Utils.GetQueryStringValue("isGet");

            if (isGet == "1")
            {
                initPage();
            }
        }

        void initPage()
        {

            string cName = Utils.GetQueryStringValue("cName");
            int leibie = Utils.GetInt(Utils.GetQueryStringValue("lid"));
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"), 1);
            string url = HttpContext.Current.Request.Url.Host.Replace("m.", "");
            //string url = "8766.slej.cn";
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(url);
            string sqlwhere = "";
            if (seller != null)
            {
                sqlwhere = seller.ID;
            }

            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();
            var serchModel = new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, sqlWhere = sqlwhere, ProductName = cName, TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g"), GYSid = Utils.GetQueryStringValue("gid") };

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("t")))
            {
                EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer model = new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer();
                model.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                if (seller != null)
                {
                    model.MemberId = seller.ID;
                }
                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, model);
            }
            else
            {
                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, serchModel);
            }
            
            if (list != null && list.Count > 0)
            {
                if (recordCount > (pageIndex - 1) * 6)
                {
                    rptlist.DataSource = list;
                }
                else
                {
                    rptlist.DataSource = null;
                }
                
                rptlist.DataBind();

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
