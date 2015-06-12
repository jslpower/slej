using System;
using Common.page;
using EyouSoft.Common.Page;
using EyouSoft.Model.MemberStructure.WebModel;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.IDAL.MemberStructure;
using System.Collections.Generic;
using EyouSoft.Model.Enum;
using EyouSoft.Common;
using System.Text;


namespace EyouSoft.Web.WebMaster.MemberCenter
{
   [Power(Menu1.个人会员管理, Menu2.个人会员管理_会员管理)]
   public partial class MemberList : ModelViewPageBase<MMember2SearchModel>
   {
      BMember2 bll = new BMember2();

      public override bool IsValidatePower
      {
         get
         {
            return true;
         }
      }
      protected int pageSize = 20, pageIndex = 1, recordCount = 0, SumCount = 0;
      protected void Page_Load(object sender, EventArgs e)
      {
          string type = Utils.GetQueryStringValue("dotype");
          if (type == "enb") Utils.RCWE(UpdateState());
          string IsValid = Utils.GetQueryStringValue("type");
          Model.SearchInfo.PageInfo.PageSize = 20;
          Model.SearchInfo.PageInfo.PageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
          Model.IsPage = true;
          if (!string.IsNullOrEmpty(IsValid))
          {
              Model.ValidDate = DateTime.Now;
          }
          if (Model.UserType != MemberTypes.未注册用户 && (int)Model.UserType != -1)
          {
              Repeater1.DataSource = bll.GetMemberList(Model, new MemberTypes[] { Model.UserType });
          }
          else
          {
              Repeater1.DataSource = bll.GetMemberList(Model);
          }
         Repeater1.DataBind();
         BindPage();
      }
      /// <summary>
      /// 绑定分页控件
      /// </summary>
      protected void BindPage()
      {
         this.ExporPageInfoSelect1.intPageSize = PageInfo.PageSize;
         this.ExporPageInfoSelect1.CurrencyPage = PageInfo.PageIndex;
         this.ExporPageInfoSelect1.intRecordCount = PageInfo.TotalCount;
      }
      #region 绑定类别
      /// <summary>
      /// 绑定类别
      /// </summary>
      /// <param name="selectItem"></param>
      /// <returns></returns>
      protected string BindMemberType(string selectItem)
      {
          string membertype = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.MemberTypes)), selectItem.ToString(), true, "-1", "请选择");

          return membertype.ToString();

      }
      #endregion
      #region 会员状态
      protected string StateName(object obj, object ID)
      {
          if (obj == null && ID == null) return "";
          StringBuilder sb = new StringBuilder();
          var value = (EyouSoft.Model.Enum.UserStatus)obj;
          if (value == EyouSoft.Model.Enum.UserStatus.已停用)
          {
              sb.AppendFormat("<span>{0}</span>&nbsp;&nbsp;", EyouSoft.Model.Enum.UserStatus.已停用.ToString());
              sb.AppendFormat("<a href=\"javascript:;\" onclick=\"instance.EnState(this)\" data-id='{0}' data-en='{1}' >{2}</a>", ID.ToString(),
                 (int)EyouSoft.Model.Enum.UserStatus.正常, "启用");
          }
          else if (value == EyouSoft.Model.Enum.UserStatus.正常)
          {
              sb.AppendFormat("<a href=\"javascript:;\" onclick=\"instance.EnState(this)\"  data-id='{0}'  data-en='{1}' >{2}</a>&nbsp;&nbsp;", ID.ToString(),
                 (int)EyouSoft.Model.Enum.UserStatus.已停用, "停用");
              sb.AppendFormat("<span>{0}</span>", "正常");
          }
          return sb.ToString();
      }
      #endregion
      private string UpdateState()
      {
          string id = Utils.GetQueryStringValue("id");
          string en = Utils.GetQueryStringValue("en");
          if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(en)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
          var enstate = (EyouSoft.Model.Enum.UserStatus)Utils.GetInt(en);
          EyouSoft.BLL.MemberStructure.BMember bll = new EyouSoft.BLL.MemberStructure.BMember();
          string msg = "";
          if (bll.UpdateMemberState(id, (int)enstate))
          {
              msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
          }
          else
          {
              msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
          }
          return msg;
      }
   }
}
