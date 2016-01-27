using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class CarXX : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "车辆详情";
            string id = Utils.GetQueryStringValue("id");
            if (string.IsNullOrEmpty(id)) Utils.RCWE("异常请求！");
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var model = bll.GetModel(id);
            if (model == null) Utils.RCWE("异常请求");
            CarName.Text = model.CarName;
            CarJieSao.Text = model.Remark;
            #region 图片处理

            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (model.ZucheInfoImg != null && model.ZucheInfoImg.Count > 0)
            {
                foreach (var item in model.ZucheInfoImg)
                {
                    files.Add(TuPian.F1(item.FilePath, 640, 400));
                    hrefs.Add("javascript:;");
                }

            }
            ScrollImg1.ImgUrl = files;
            ScrollImg1.HrefUrl = hrefs;
            ScrollImg1.ImgGth = 400;
            ScrollImg1.ImgWid = 640;
            #endregion
        }
    }
}
