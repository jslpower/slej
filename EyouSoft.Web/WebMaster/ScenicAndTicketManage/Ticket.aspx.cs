using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.InterfaceLib;
using EyouSoft.InterfaceLib.Request.MTS;
using EyouSoft.InterfaceLib.Response.MTS;
using EyouSoft.Model.Enum;
using EyouSoft.Model.ScenicStructure.WebModel;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
   /// <summary>
   /// 景区门票管理
   /// </summary>
   [Power(Menu1.景区门票管理, Menu2.景区门票管理_景区门票管理)]
   public partial class Ticket : Common.Page.WebmasterPageBase
   {
      MTSServiceSeeker bll_jingqu = new MTSServiceSeeker();

      public override bool IsValidatePower
      {
         get
         {
            return true;
         }
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         // scenicId
         string action = Utils.GetQueryStringValue("action").ToLower();

         if (action == "del")
         {
            Response.Clear();
            Response.Write(this.DelTicket(Utils.GetQueryStringValue("id")));
            Response.End();
         }
         if (action == "setstate")
         {
            Response.Clear();
            Response.Write(this.SetState(Utils.GetQueryStringValue("id"), Utils.GetInt(Utils.GetQueryStringValue("state"))));
            Response.End();
         }

         if (!IsPostBack)
         {
            InitDropDownList();
            InitPage();
         }
      }

      private void InitPage()
      {
         var search = new MScenicTicketsSearchModel
         {
            ScenicId = Utils.GetQueryStringValue("scenicId"),
            TypeName = Utils.GetQueryStringValue("txtName")
         };

         int state = Utils.GetInt(Utils.GetQueryStringValue("states"));

         if (state > 0 && state < 3) search.Status = (Model.Enum.ScenicStructure.ScenicTicketsStatus)state;
         else search.Status = null;

         if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
         {
            search.ScenicId = UserInfo.GysId;
         }

         BScenicTickets bll = new BScenicTickets();
         BScenicArea2 bll2 = new BScenicArea2();
         int rowCount = 0;
         IList<MScenicTickets> list = bll.GetList(PageInfo.PageSize, PageInfo.PageIndex, ref rowCount, search);
         PageInfo.TotalCount = rowCount;
         ExporPageInfoSelect1.CurrencyPage = PageInfo.PageIndex;
         ExporPageInfoSelect1.intPageSize = PageInfo.PageSize;
         ExporPageInfoSelect1.intRecordCount = PageInfo.TotalCount;

         rptList.DataSource = list;
         rptList.DataBind();

         txtName.Value = search.TypeName;
         if (ddlState.Items.FindByValue(state.ToString()) != null) ddlState.Items.FindByValue(state.ToString()).Selected = true;
      }

      private string SetState(string id, int state)
      {
         if (string.IsNullOrEmpty(id)) return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");
         if (state != 1 && state != 2) return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");

         var t = (Model.Enum.ScenicStructure.ScenicTicketsStatus)state;

         bool r = new BLL.ScenicStructure.BScenicTickets().SetStatus(t, id);

         if (r)
         {
            return UtilsCommons.AjaxReturnJson("1", "操作成功！");
         }

         return UtilsCommons.AjaxReturnJson("0", "操作失败！");
      }

      /// <summary>
      /// 计算有效期
      /// </summary>
      /// <param name="st">开始时间</param>
      /// <param name="et">结束时间</param>
      /// <returns></returns>
      protected string GetTimeStr(object st, object et)
      {
         DateTime? s = null;
         DateTime? e = null;
         if (st != null) s = (DateTime)st;
         if (et != null) e = (DateTime)et;

         if (s.HasValue)
         {
            if (e.HasValue)
            {
               return string.Format("{0}至{1}", s.Value.ToShortDateString(), e.Value.ToShortDateString());
            }

            return string.Format("{0}开始", s.Value.ToShortDateString());
         }
         else
         {
            if (e.HasValue)
            {
               return string.Format("至{0}截止", e.Value.ToShortDateString());
            }

            return "无限制";
         }
      }

      /// <summary>
      /// 获取状态显示html
      /// </summary>
      /// <param name="state"></param>
      /// <returns></returns>
      protected string GetStateHtml(object state)
      {
         if (state == null) return string.Empty;

         var t = (Model.Enum.ScenicStructure.ScenicTicketsStatus)state;

         return t.ToString();
      }

      /// <summary>
      /// 获取设置状态的操作
      /// </summary>
      /// <param name="state"></param>
      /// <returns></returns>
      protected string GetStateHadnleHtml(object state)
      {
         if (state == null) return string.Empty;

         var t = (Model.Enum.ScenicStructure.ScenicTicketsStatus)state;
         var str = "<a href=\"javascript:;\" class=\"setTicket\" data-state=\"{1}\">{0}</a>&nbsp;&nbsp; ";

         switch (t)
         {
            case Model.Enum.ScenicStructure.ScenicTicketsStatus.下架:
               return string.Format(str, "上架", (int)Model.Enum.ScenicStructure.ScenicTicketsStatus.上架);
            default:
               return string.Format(str, "下架", (int)Model.Enum.ScenicStructure.ScenicTicketsStatus.下架);
         }
      }

      private void InitDropDownList()
      {
         var list = EnumObj.GetList(typeof(Model.Enum.ScenicStructure.ScenicTicketsStatus));

         ddlState.DataSource = list;
         ddlState.DataTextField = "Text";
         ddlState.DataValueField = "Value";
         ddlState.DataBind();

         ddlState.Items.Insert(0, new ListItem("请选择", "0"));
      }

      private string DelTicket(string id)
      {
         if (string.IsNullOrEmpty(id)) return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");

         int r = new BLL.ScenicStructure.BScenicTickets().DeleteMenPiao(id);

         if (r == 1)
         {
            return UtilsCommons.AjaxReturnJson("1", "删除成功！");
         }
         else if (r == -99)
         {
            return UtilsCommons.AjaxReturnJson("0", "已经存在订单的门票信息不可删除！");
         }

         return UtilsCommons.AjaxReturnJson("0", "删除失败！");
      }

      /// <summary>
      /// 获取行索引
      /// </summary>
      /// <param name="index"></param>
      /// <returns></returns>
      protected string GetIndex(int index)
      {
         return ((PageInfo.PageIndex - 1) * PageInfo.PageSize + index + 1).ToString();
      }
   }
}
