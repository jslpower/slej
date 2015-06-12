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
    [Power(Menu1.财务管理, Menu2.财务管理_账户明细)]
    public partial class ZhangHuMingXi : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected int PageSize = 20;
        protected int PageIndex = 1;
        protected int RecordCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void PageInit()
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
            //Model.SearchInfo.PageInfo.PageSize = 20;
            ////Model.TransactionCate = null;
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

            var chaXun = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiChaXunInfo();
            chaXun.JiaoYiShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("StartTime"));
            chaXun.JiaoYiShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("EndTime"));

            PageIndex = UtilsCommons.GetPagingIndex();
            var items = new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().GetJiaoYiMingXis(PageSize, PageIndex, ref RecordCount, chaXun);

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
                Literal1.Text = "暂无数据!";
            }
        }

        //protected void BindExportPage()
        //{
        //    this.ExportPageInfo1.intPageSize = Model.SearchInfo.PageInfo.PageSize;
        //    this.ExportPageInfo1.CurrencyPage = Model.SearchInfo.PageInfo.PageIndex;
        //    this.ExportPageInfo1.intRecordCount = Model.SearchInfo.PageInfo.TotalCount;
        //}

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
    }
}
