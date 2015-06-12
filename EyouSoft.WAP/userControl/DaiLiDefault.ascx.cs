using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP.userControl
{
    public partial class DaiLiDefault : System.Web.UI.UserControl
    {
        protected string dailiId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.Host.Replace("m.","");
            //string url = "8568.slej.cn";
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(url);
            if (url.IndexOf("www.slej.cn") < 0)
            {
                if (seller != null)
                {
                    dailiId = seller.ID;
                }
            }
            InitPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            InitAd();
            InitCuXiao();
            InitMiaoSha();
            InitHuiYuanShopping();

        }
        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, (EyouSoft.Model.Enum.AdvArea)1, dailiId);
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
        /// 促销初始化
        /// </summary>
        private void InitCuXiao()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            serchModel.SaleType = EyouSoft.Model.Enum.CuXiaoLeiXing.促销;
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            serchModel.SupplierID = dailiId;
            serchModel.WeiZhi = new List<EyouSoft.Model.Enum.XianShiWeiZhi> { EyouSoft.Model.Enum.XianShiWeiZhi.网站首页 };
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(2, serchModel);
            if (list != null)
            {
                PlaceHolder2.Visible = true;
                CuXiao.DataSource = list;
                CuXiao.DataBind();
            }
            else
            {
                PlaceHolder2.Visible = false;
            }
        }
        /// <summary>
        /// 秒杀初始化
        /// </summary>
        private void InitMiaoSha()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            serchModel.SaleType = EyouSoft.Model.Enum.CuXiaoLeiXing.秒杀;
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            serchModel.WeiZhi = new List<EyouSoft.Model.Enum.XianShiWeiZhi> { EyouSoft.Model.Enum.XianShiWeiZhi.网站首页 }; ;
            serchModel.SupplierID = dailiId;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(2, serchModel);
            if (list != null)
            {
                PlaceHolder1.Visible = true;
                MiaoSha.DataSource = list;
                MiaoSha.DataBind();
            }
            else
            {
                PlaceHolder1.Visible = false;
            }
        }
        /// <summary>
        /// 会员商城初始化
        /// </summary>
        protected void InitHuiYuanShopping()
        {
            int recordCount = 0;
            if (!string.IsNullOrEmpty(dailiId))
            {
                EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer model = new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer();
                model.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                model.MemberId = dailiId;
                var list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(8, 1, ref recordCount, model);
                if (list != null && list.Count > 0)
                {
                    rpt_HuiYuanShopping.DataSource = list;
                    rpt_HuiYuanShopping.DataBind();
                }
            }
            else
            {
                EyouSoft.Model.MallStructure.MShangChengShangPinSer model = new EyouSoft.Model.MallStructure.MShangChengShangPinSer();
                model.isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 };
                var list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(8, 1, ref recordCount, model);
                if (list != null && list.Count > 0)
                {
                    rpt_HuiYuanShopping.DataSource = list;
                    rpt_HuiYuanShopping.DataBind();
                }
            }

        }
        /// <summary>
        /// 计算秒数
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        protected string GetMiaoshu(object datetime)
        {
            string miaoshu = "0";
            miaoshu = Convert.ToInt32((Convert.ToDateTime(datetime).AddDays(1) - DateTime.Now).TotalSeconds).ToString();
            return miaoshu;
        }
        /// <summary>
        /// 获取商城默认图片
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getImgs(object obj)
        {
            List<EyouSoft.Model.MallStructure.MChanPinTuPian> list = (List<EyouSoft.Model.MallStructure.MChanPinTuPian>)obj;
            if (list != null && list.Count > 0) return TuPian.F1(list[0].FilePath,640,200);
            return "";
        }
    }
}