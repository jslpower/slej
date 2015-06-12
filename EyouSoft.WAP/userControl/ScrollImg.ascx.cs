using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace EyouSoft.WAP.userControl
{
    public partial class ScrollImg : System.Web.UI.UserControl
    {
        /// <summary>
        /// 图片列表
        /// </summary>
        private List<string> _imgurls;
        public List<string> ImgUrl
        {
            get { return _imgurls; }
            set { _imgurls = value; }
        }

        /// <summary>
        /// 地址列表
        /// </summary>
        private List<string> _hrefurls;
        public List<string> HrefUrl
        {
            get { return _hrefurls; }
            set { _hrefurls = value; }
        }

        /// <summary>
        /// 图片真实高度
        /// </summary>
        private int _imggth;
        public int ImgGth
        {
            get { return _imggth; }
            set { _imggth = value; }
        }

        /// <summary>
        /// 图片真实高度
        /// </summary>
        private int _imgwid;
        public int ImgWid
        {
            get { return _imgwid; }
            set { _imgwid = value; }
        }


        protected StringBuilder strImgStr = new StringBuilder();
        protected StringBuilder strImgNum = new StringBuilder();
        protected int imgheigth = 200;
        protected int imgwidth = 640;
        protected void Page_Load(object sender, EventArgs e)
        {
            initImgList();
            imgheigth = ImgGth;
            imgwidth = ImgWid;
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initImgList()
        {

            if (ImgUrl != null && ImgUrl.Count > 0 && HrefUrl != null && HrefUrl.Count > 0 && HrefUrl.Count == ImgUrl.Count)
            {
                for (int i = 0; i < ImgUrl.Count; i++)
                {
                    strImgNum.Append("<a href=\"#\">" + (i + 1) + "</a>");
                    strImgStr.AppendFormat("<li><a href=\"" + GetUrl(HrefUrl[i]) + "\"><img src=\"" + ImgUrl[i] + "\"></a></li>");
                }
            }
        }

        string GetUrl(string oldurl)
        {
            int num = 0;
            if (oldurl.IndexOf(".cn") > -1)
            {
                num = oldurl.IndexOf(".cn");
                oldurl = oldurl.Substring(num+3);
            }
            return oldurl.ToLower().Replace("xianluyuding", "Line_Info").Replace("xianlu", "Line_List").Replace("youhuimenpiaoxiangqing", "JingQuXX").Replace("youhuimenpiao", "JingQuList").Replace("hotelxiangqing", "HotelXX").Replace("hotel", "HotelList").Replace("shangchengxiangqing", "Mall/MoDetail").Replace("shangcheng", "Mall/Default");
            
        }
    }
}