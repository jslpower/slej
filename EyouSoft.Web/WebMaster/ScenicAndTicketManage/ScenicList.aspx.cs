using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Model.ScenicStructure.WebModel;
using System.Text;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
   [Power(EyouSoft.Model.Enum.Privs.Menu1.景区门票管理, EyouSoft.Model.Enum.Privs.Menu2.景区门票管理_景区管理)]
   public partial class ScenicList : EyouSoft.Common.Page.WebmasterPageBase
   {
      #region 分页参数
      protected int pageIndex = 1;
      protected int recordCount;
      protected int pageSize = 20;
      #endregion
      protected void Page_Load(object sender, EventArgs e)
      {
         string id = Utils.GetQueryStringValue("id");
         string dotype = Utils.GetQueryStringValue("dotype");
         if (dotype == "delete" && id != "")
         {
            Response.Clear();
            Response.Write(DeleteDate(id));
            Response.End();
         }
         if (dotype == "isindex" && id != "")
         {
             Response.Clear();
             Response.Write(UpdateState());
             Response.End();
         }
         if (!IsPostBack)
         {
            PageInit(id, dotype);
         }
      }

      /// <summary>
      /// 初始化
      /// </summary>
      /// <param name="id"></param>
      /// <param name="dotype"></param>
      private void PageInit(string id, string dotype)
      {
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         MScenicAreaSearchModel searchmodel = new MScenicAreaSearchModel();
         searchmodel.ScenicName = Utils.GetQueryStringValue("txtScenicName");

         pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
         IList<EyouSoft.Model.ScenicStructure.MScenicArea> list = bll.GetScenicAreaList(pageSize, pageIndex, ref recordCount, searchmodel);
         Utils.Paging(pageSize, ref pageIndex, recordCount);
         if (list != null && list.Count > 0)
         {
            this.rptlist.DataSource = list;
            this.rptlist.DataBind();
            BindExportPage();
         }
         else
         {
            lbemptymsg.Text = "<tr><td colspan='8' align='center' height='30px'>暂无数据!</td></tr>";
         }
      }
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      private string DeleteDate(string id)
      {
         string msg = string.Empty;
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         if (bll.DeleteScenicArea(id))
         {
            msg = Utils.AjaxReturnJson("1", "删除成功!");
         }
         else
         {
            msg = Utils.AjaxReturnJson("0", "删除失败!");
         }
         return msg;
      }
      #region 景区状态
      /// <summary>
      /// 景区首页显示
      /// </summary>
      /// <param name="obj">景区状态</param>
      /// <param name="isbool">是否首页显示</param>
      /// <param name="ID">景区id</param>
      /// <returns></returns>
      protected string CheIsIndex(object isbool, object ID)
      {
          if (isbool == null && ID == null) return "";
          StringBuilder sb = new StringBuilder();
          sb.Append("");
          var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
          if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
          {
              sb.AppendFormat("<a href=\"javascript:;\" onclick=\"Sceniclist.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                 EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
              sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"Sceniclist.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                 EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
          }
          else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐)
          {
              sb.AppendFormat("<a href=\"javascript:;\" onclick=\"Sceniclist.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                 "取消推荐", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
              sb.AppendFormat("<a href=\"javascript:;\" onclick=\"Sceniclist.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                 EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
          }
          else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
          {
              sb.AppendFormat("<a href=\"javascript:;\" onclick=\"Sceniclist.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                "上架", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
              sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"Sceniclist.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                 EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(),(int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
          }
          return sb.ToString();
      }
      #endregion
       /// <summary>
       /// 修改状态
       /// </summary>
       /// <returns></returns>
      private string UpdateState()
      {
          string id = Utils.GetQueryStringValue("id");
          string state = Utils.GetQueryStringValue("state");
          if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(state)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
          var enstate = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)Utils.GetInt(state);
          EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
          string msg = "";
          if (bll.UpdateState(id, enstate))
          {
              new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort("jingqu", id, 1);
              msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
          }
          else
          {
              msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
          }
          return msg;
      }
      #region 绑定分页控件
      /// <summary>
      /// 绑定分页控件
      /// </summary>
      protected void BindExportPage()
      {
         this.ExporPageInfoSelect1.intPageSize = pageSize;
         this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
         this.ExporPageInfoSelect1.intRecordCount = recordCount;
      }
      #endregion
   }
}
