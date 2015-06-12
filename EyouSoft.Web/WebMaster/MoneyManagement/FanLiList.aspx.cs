using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using EyouSoft.Model.MoneyStructure.WebModel;
using EyouSoft.Model;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Common.Page;
using Common.page;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.MoneyManagement
{
   [Power(Menu1.财务管理, Menu2.财务管理_返利管理)]
    public partial class FanLi : EyouSoft.Common.Page.WebmasterPageBase
   {
       protected int PageSize = 20;
       protected int PageIndex = 1;
       protected int RecordCount = 0;

      public override bool IsValidatePower
      {
         get
         {
            return true;
         }
      }
      protected void Page_Load(object sender, EventArgs e)
      {
         InitPage();

         InitInfo();
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

      public void InitPage()
      {
          //string username = Utils.GetQueryStringValue("UserName");//会员帐号
          //if (!string.IsNullOrEmpty(username))
          //{
          //    var usermodel = new EyouSoft.IDAL.MemberStructure.BMember2().GetByAccount(username);
          //    if (usermodel == null)
          //    {
          //        Model.USerId = "0";
          //    }
          //    else
          //    {
          //        Model.USerId = usermodel.MemberID;
          //    }
          //}
          //string status = Utils.GetQueryStringValue("ddlClass");
          //if (!string.IsNullOrEmpty(status)&&Convert.ToInt32(status) >= 0)
          //{
          //    Model.OrderType = (EyouSoft.Model.Enum.DingDanLeiBie)Utils.GetInt(status);
          //}
          //Model.SearchInfo.PageInfo.PageSize = 20;
          
          //Model.TransactionCate = EyouSoft.Model.Enum.TCate.返利;
          //var list = new EyouSoft.BLL.MoneyStructure.BAccount().GetAccountList(Model);
          //if (list != null && list.Count > 0)
          //{
          //    this.rptList.DataSource = list;
          //    this.rptList.DataBind();
          //    Literal1.Visible = false;
          //}
          //else
          //{
          //    rptList.Visible = false;
          //    Literal1.Text = "暂无数据";
          //}
          //Literal2.Text = (new EyouSoft.BLL.MemberStructure.BMember().GetSumJInE()).ToString("f2");
          //BindExportPage();

          var chaXun = new EyouSoft.Model.OtherStructure.MDingDanFanLiChaXunInfo();
          chaXun.DingDanLeiXing = (EyouSoft.Model.OtherStructure.DingDanType?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.OtherStructure.DingDanType), Utils.GetQueryStringValue("ddlClass"));
          chaXun.FanLiShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("StartTime"));
          chaXun.FanLiShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("EndTime"));

          PageIndex = UtilsCommons.GetPagingIndex();
          var items = new EyouSoft.BLL.OtherStructure.BDingDanFanLi().GetDingDanFanLis(PageSize, PageIndex, ref RecordCount, chaXun);

          if (items != null && items.Count > 0)
          {
              rptList.DataSource = items;
              rptList.DataBind();

              this.ExportPageInfo1.intPageSize = PageSize;
              this.ExportPageInfo1.CurrencyPage = PageIndex;
              this.ExportPageInfo1.intRecordCount = RecordCount;
          }
          else
          {
              rptList.DataSource = null;
              rptList.DataBind();
              Literal1.Text = "暂无返利记录!";
          }
      }


      protected void BindExportPage()
      {
         //this.ExportPageInfo1.intPageSize = Model.SearchInfo.PageInfo.PageSize;
         //this.ExportPageInfo1.CurrencyPage = Model.SearchInfo.PageInfo.PageIndex;
         //this.ExportPageInfo1.intRecordCount = Model.SearchInfo.PageInfo.TotalCount;
      }

      ///// <summary>
      ///// 返回下单人姓名
      ///// </summary>
      ///// <param name="memberID"></param>
      ///// <returns></returns>
      //protected string GetMemberNameByID(object memberID)
      //{
      //    string id = "";
      //    if (memberID != null)
      //    {
      //        id = Utils.GetString(memberID.ToString(), "");
      //    }
      //    if (string.IsNullOrEmpty(id)) return "金奥";
      //    BSellers bsells = new BSellers();
      //    EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
      //    mseller = bsells.GetWebSiteName(id);
      //    if (mseller == null) return "金奥";
      //    return "网点名称："+mseller.WebsiteName;
      //}
      #region 绑定类别
      /// <summary>
      /// 绑定类别
      /// </summary>
      /// <param name="selectItem"></param>
      /// <returns></returns>
      protected string BindClass(string selectItem)
      {
          string StrOrderStatus = "";
          StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.OtherStructure.DingDanType)), selectItem.ToString(), true, "-1", "请选择");
          return StrOrderStatus;

      }
      #endregion
   }
}
