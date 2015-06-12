/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.MoneyStructure.WebModel;
using EyouSoft.Model;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Common.Page;
using Common.page;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;
using System.Text;


namespace EyouSoft.Web.WebMaster.MoneyManagement
{
    [Power(Menu1.财务管理, Menu2.财务管理_交易管理)]
    public partial class JiaoYiList : ModelViewPageBase<MAccountSearchModel>
    {

        public override bool IsValidatePower
        {
            get
            {
                return true;
            }
        }
        protected int refcount = 0;//总条数
        protected decimal SumMoney = 0;//总金额
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        public void InitPage()
        {
            string username = Utils.GetQueryStringValue("UserName");//会员帐号
            if (!string.IsNullOrEmpty(username))
            {
                var usermodel = new EyouSoft.IDAL.MemberStructure.BMember2().GetByAccount(username);
                if (usermodel == null)
                {
                    Model.USerId = "0";
                }
                else
                {
                    Model.USerId = usermodel.MemberID;
                }
            }
            Model.TranUserId = Utils.GetQueryStringValue("qudaolist");
            if (Model.TranUserId =="-1")
            {
                Model.TranUserId = null;
            }
            string status = Utils.GetQueryStringValue("ddlClass");
            if (!string.IsNullOrEmpty(status) && Convert.ToInt32(status) >= 0)
            {
                Model.OrderType = (EyouSoft.Model.Enum.DingDanLeiBie)Utils.GetInt(status);
            }
            Model.SearchInfo.PageInfo.PageSize = 20;

            Model.TransactionCate = EyouSoft.Model.Enum.TCate.消费;
            var list = new EyouSoft.BLL.MoneyStructure.BAccount().GetAccountList(Model);
            if (list != null && list.Count > 0)
            {
                refcount = list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    SumMoney = SumMoney + Convert.ToDecimal(list[i].Amounts);
                }
                this.rptList.DataSource = list;
                this.rptList.DataBind();
                Literal1.Visible = false;
            }
            else
            {
                rptList.Visible = false;
                Literal1.Text = "暂无数据";
            }
            //Literal2.Text = (new EyouSoft.BLL.MemberStructure.BMember().GetSumJInE()).ToString("f2");
            BindExportPage();
        }
        protected string GetSellersHtml(string selectItem)
        {
            StringBuilder strHtml = new StringBuilder();
            BSellers bsells = new BSellers();
            var list = bsells.GetWebSite();
            if (list != null && list.Count > 0)
            {
                if (selectItem == "0")
                {
                    strHtml.Append("<option value=\"0\" selected=\"selected\">金奥</option>");
                }
                else
                {
                    strHtml.Append("<option value=\"0\" >金奥</option>");
                }
                foreach (var item in list)
                {
                    if (item.ID.ToString().Equals(selectItem))
                    {
                        strHtml.AppendFormat("<option value=\"{0}\"  selected=\"selected\">{1}</option>",
                            item.ID, item.WebsiteName);
                    }
                    else
                    {
                        strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                            item.ID, item.WebsiteName);
                    }
                }
            }
            return strHtml.ToString();
        }

        protected void BindExportPage()
        {
            this.ExportPageInfo1.intPageSize = Model.SearchInfo.PageInfo.PageSize;
            this.ExportPageInfo1.CurrencyPage = Model.SearchInfo.PageInfo.PageIndex;
            this.ExportPageInfo1.intRecordCount = Model.SearchInfo.PageInfo.TotalCount;
        }

        /// <summary>
        /// 返回网点名称
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
            if (string.IsNullOrEmpty(id)) return "金奥";
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
            mseller = bsells.GetWebSiteName(id);
            if (mseller == null) return "金奥";
            return "网点名称：" + mseller.WebsiteName;
        }
        /// <summary>
        /// 返回下单人信息
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        protected string GetMemberInfoByID(object memberID)
        {
            string id = "";
            if (memberID != null)
            {
                id = Utils.GetString(memberID.ToString(), "");
            }
            if (id == "" || id == null) return "金奥";
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(id);
            if (model == null) return "金奥";
            return "<span style='color:red'>" + model.UserType + "</span><br />" + model.MemberName + "<br />" + model.Mobile;

        }
        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindClass(string selectItem)
        {
            string StrOrderStatus = "";
            StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.DingDanLeiBie)), selectItem.ToString(), true, "-1", "请选择");
            StrOrderStatus = StrOrderStatus.Replace("<option value=\"8\">充值订单</option>", "");
            return StrOrderStatus;

        }
        #endregion
    }
}
*/