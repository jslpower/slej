using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.MasterPage
{
   public partial class FrontNoFixed : System.Web.UI.MasterPage
   {
      /// <summary>
      /// 标题
      /// </summary>
      protected string ITitle = string.Empty;
      protected string diad = string.Empty;

      /// <summary>
      /// 高亮显示的头部索引值 (首页 = 0，依次+1)
      /// </summary>
      public int HeadMenuIndex { get; set; }

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            InitPage();
            InitAd();
         }
      }

      private void InitPage()
      {
         ITitle = Page.Title;
         Menu1.HeadMenuIndex = HeadMenuIndex;
      }
      /// <summary>
      /// 绑定页面广告
      /// </summary>
      private void InitAd()
      {
          EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();

          var top4 = bll.GetList(1, (EyouSoft.Model.Enum.AdvArea)5);
          if (top4 != null && top4.Count > 0)
          {
              diad = "<a target='_blank' href='" + top4[0].AdvLink + "'><img src='" + top4[0].ImgPath + "'></a>";
          }

      }
   }
}
