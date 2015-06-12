using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;

namespace EyouSoft.Web.MasterPage
{
    public partial class Front3 : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 标题
        /// </summary>
        protected string ITitle = string.Empty;

        /// <summary>
        /// 高亮显示的头部索引值 (首页 = 0，依次+1)
        /// </summary>
        public int HeadMenuIndex { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPage();
            }
           
            
        }

        private void InitPage()
        {
            ITitle = Page.Title;
            Menu1.HeadMenuIndex = HeadMenuIndex;
        }
    }
}
