using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster
{
   /// <summary>
   /// 用户列表
   /// </summary>
   public partial class UserList : Common.Page.WebmasterPageBase
   {
      private const int PageSize = 20;

      private int _pageIndex = 1;

      private int _recordCount = 0;

      protected void Page_Load(object sender, EventArgs e)
      {
         string action = Utils.GetQueryStringValue("action").ToLower();
         int uid = Utils.GetInt(Utils.GetQueryStringValue("id"));
         string st = Utils.GetQueryStringValue("st");
         if (action == "del")
         {
            Response.Clear();
            Response.Write(this.DelUser(uid));
            Response.End();
         }
         else if (action == "set")
         {
            Response.Clear();
            Response.Write(this.SetUserState(uid, st));
            Response.End();
         }

         if (!IsPostBack)
         {
            InitPage();
         }
      }

      private void InitPage()
      {
         _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
         var search = new Model.MWebmasterSearchModel
         {
            Username = Utils.GetQueryStringValue("un"),
            Realname = Utils.GetQueryStringValue("cn"),
            LeiXing = Utils.GetIntNull(Utils.GetQueryStringValue("txtLeiXing"))
         };

         var list = new BLL.OtherStructure.BWebmaster().GetList(PageSize, _pageIndex, ref _recordCount, search);

         UtilsCommons.Paging(PageSize, ref _pageIndex, _recordCount);

         rptEmployee.DataSource = list;
         rptEmployee.DataBind();

         ExporPageInfoSelect1.intPageSize = PageSize;
         ExporPageInfoSelect1.intRecordCount = _recordCount;
         ExporPageInfoSelect1.CurrencyPage = _pageIndex;
      }


      private string DelUser(int uid)
      {
         if (uid <= 0) return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");

         bool r = new BLL.OtherStructure.BWebmaster().Delete(uid);

         return UtilsCommons.AjaxReturnJson(r ? "1" : "0", r ? "删除成功！" : "删除失败！");
      }

      private string SetUserState(int uid, string oldState)
      {
         if (uid <= 0) return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");

         //true改false,false改true
         int r = new BLL.OtherStructure.BWebmaster().SetUserSatae(uid, oldState != "1");

         switch (r)
         {
            case 0:
               return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");
            case 1:
               return UtilsCommons.AjaxReturnJson("1", "操作成功！");
            default:
               return UtilsCommons.AjaxReturnJson("0", "操作失败！");
         }
      }


      protected string GetLeiXingName(object LeiXing)
      {
         if (LeiXing != null)
         {
            WebmasterUserType s = (WebmasterUserType)int.Parse(LeiXing.ToString());
            return s.ToString();
         }
         return string.Empty;
      }


      protected string GetLeiXingQuanXian(object LeiXing)
      {
         var _html = new System.Text.StringBuilder();
         if (LeiXing != null)
         {
            if ((int)LeiXing == 0)
            {
               _html.Append("<a href='javascript:;' class='perUser'>权限</a> &nbsp;&nbsp;");
            }

            _html.Append("<a href='javascript:;' class='editUser'>修改</a>&nbsp;&nbsp; <a href='javascript:;' class='delUser'>删除</a>");


         }
         return _html.ToString();
      }
   }
}
