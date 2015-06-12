using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.OtherStructure;
using Common.page;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.Common.Page;
using EyouSoft.Model.MoneyStructure;
//using EyouSoft.Model.MoneyStructure.WebModel;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.WebMaster.MoneyManagement
{
   [Power(Menu1.财务管理, Menu2.财务管理_提现管理)]
    public partial class TiXianList : EyouSoft.Common.Page.WebmasterPageBase
   {
      BMember memberBll = new BMember();
      #region 页面参数
      protected int recordCount = 0;
      protected int pageSize = 20;
      protected int pageIndex = 0;
      #endregion
      protected void Page_Load(object sender, EventArgs e)
      {
          //审核通过
         if (Utils.GetQueryStringValue("setState") == "1") SetShenHeStates();
         //提现成功
         if (Utils.GetQueryStringValue("setState") == "2") SetTiXianStates();
         PageInit();
         InitInfo();
      }
      public override bool IsValidatePower
      {
         get
         {
            return true;
         }
      }

      /// <summary>
      /// init info
      /// </summary>
      void InitInfo()
      {
          var info = new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().GetYuEInfo();
          if (info == null) return;

          Literal2.Text = info.YuE.ToString("F2");
      }

      void SetShenHeStates()
      {
          string id = Utils.GetQueryStringValue("id");
          if (!string.IsNullOrEmpty(id))
          {
              int count = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().SheZhiTiXianShenHeStatus(id, TiXianShenHe.已审核,string.Empty);
              Utils.RCWE(UtilsCommons.AjaxReturnJson(count == 1 ? "1" : "0", count == 1 ? "提现审核通过！" : "提现审核失败！"));
          }
          else
          {
              Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请选择要审核的提现记录！"));
          }
      }

      void SetTiXianStates()
      {
          string id = Utils.GetQueryStringValue("id");
          if (!string.IsNullOrEmpty(id))
          {
              int count = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().SheZhiTiXianStatus(id, TiXianState.已提现,string.Empty);
              Utils.RCWE(UtilsCommons.AjaxReturnJson(count == 1 ? "1" : "0", count == 1 ? "提现审核通过！" : "提现审核失败！"));
          }
          else
          {
              Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请选择要审核的提现记录！"));
          }
      }

      private void PageInit()
      {
          MApplyTiXianSer Model = new MApplyTiXianSer();
          string username = Utils.GetQueryStringValue("UserName");//会员帐号
          if (!string.IsNullOrEmpty(username))
          {
              var usermodel = new EyouSoft.IDAL.MemberStructure.BMember2().GetByAccount(username);
              if (usermodel != null)
              {
                  Model.UserId = usermodel.MemberID;
              }
          }
          if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("StartTime")) && !string.IsNullOrEmpty(Utils.GetQueryStringValue("EndTime")))
          {
              Model.TiXianStartTime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime"));
              Model.TiXianEndTime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime"));
          }
          else
          {
              if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("StartTime")))
              {
                  if (Convert.ToDateTime(Utils.GetQueryStringValue("StartTime")) < DateTime.Now)
                  {
                      Model.TiXianStartTime = Convert.ToDateTime(Utils.GetQueryStringValue("StartTime"));
                      Model.TiXianEndTime = DateTime.Now;
                  }
              }
              if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("EndTime")))
              {
                  if (Convert.ToDateTime(Utils.GetQueryStringValue("EndTime")) > DateTime.Now)
                  {
                      Model.TiXianStartTime = DateTime.Now;
                      Model.TiXianEndTime = Convert.ToDateTime(Utils.GetQueryStringValue("EndTime"));
                  }
              }
          }
          pageIndex = UtilsCommons.GetPagingIndex();
          var list = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetList(pageSize, pageIndex, "", ref recordCount, Model);
          if (list != null && list.Count > 0)
          {
              this.rptList.DataSource = list;
              this.rptList.DataBind();
              Literal1.Visible = false;
          }
          else
          {
              rptList.Visible = false;
              Literal1.Text = "暂无数据";
          }

          this.ExportPageInfo1.intPageSize = pageSize;
          this.ExportPageInfo1.CurrencyPage = pageIndex;
          this.ExportPageInfo1.intRecordCount = recordCount;
      }


      /// <summary>
      /// 返回下单人姓名
      /// </summary>
      /// <param name="memberID"></param>
      /// <returns></returns>
      protected string GetMemberNameByID(object memberID)
      {
          string id = "";
          if (memberID != null)
          {
              id = Utils.GetString(memberID.ToString(), "");
          }
          if (id == "" || id == null) return "金奥";
          EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
          EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
          model = bll.GetModel(memberID.ToString());
          if (model == null) return "金奥";
          return "会员姓名：" + model.MemberName + "<br />会员帐号：" + model.Account;

      }


      protected string GetCaoZuo(object ApplyStatus, object TiXianStatus, object TiXianId)
      {
          string caozuourl = "";
          if ((int)ApplyStatus == (int)EyouSoft.Model.Enum.TiXianShenHe.未审核)
          {
              caozuourl = "<a href=\"javascript:;\" class=\"ShenHeTG\" data-id=\"" + TiXianId + "\">审核通过</a><br /><a href=\"javascript:;\" class=\"ShenHeSB\" data-id=\"" + TiXianId + "\">审核失败</a>";
          }
          else if ((int)ApplyStatus == (int)EyouSoft.Model.Enum.TiXianShenHe.未通过)
          {
              caozuourl = "<span style=\"color:red;\">审核未通过</span>";
          }
          else if ((int)ApplyStatus == (int)EyouSoft.Model.Enum.TiXianShenHe.已审核)
          {
              if ((int)TiXianStatus == (int)EyouSoft.Model.Enum.TiXianState.未提现)
              {
                  caozuourl = "<a href=\"javascript:;\" class=\"QueRenTX\" data-id=\"" + TiXianId + "\">确认提现</a><br /><a href=\"javascript:;\" class=\"QuXiaoTX\" data-id=\"" + TiXianId + "\">取消提现</a>";
              }
              else if ((int)TiXianStatus == (int)EyouSoft.Model.Enum.TiXianState.提现失败)
              {
                  caozuourl = "提现失败";
              }
              else
              {
                  caozuourl = "提现完成";
              }
          }
          return caozuourl;
      }
   }
}
