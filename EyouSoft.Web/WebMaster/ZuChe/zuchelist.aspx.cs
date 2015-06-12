using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.ZuCheStructure;
using System.Text;

namespace EyouSoft.Web.WebMaster.ZuChe
{
    public partial class zuchelist : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 10;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("dotype");
            if (type == "del") Utils.RCWE(Del());
            if (type == "enb") Utils.RCWE(UpdateState());
            if (type == "isindex") Utils.RCWE(UpdateIsIndex());
            if (!Page.IsPostBack)
            {
                InitInfo();
            }
        }

        protected void InitInfo()
        {
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun chaxun = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            string CarName = Utils.GetQueryStringValue("txtPathName");
            chaxun.CarName = CarName;
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            IList<MZuCheInfo> list = bll.GetList(pageSize, pageIndex, ref recordCount, chaxun);
            if (list != null&&list.Count>0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='7' align='center' height='30px'>暂无数据!</td></tr>";
            }
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

        #region 租车状态
        protected string StateName(object obj, object ID)
        {
            if (obj == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            var value = (EyouSoft.Model.Enum.ZuCheStates)obj;
            if (value == EyouSoft.Model.Enum.ZuCheStates.启用)
            {
                sb.AppendFormat("<span>{0}</span>&nbsp;&nbsp;", EyouSoft.Model.Enum.ZuCheStates.启用.ToString());
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"PageInfo.EnState(this)\" data-id='{0}' data-en='{1}' >{2}</a>", ID.ToString(),
                   (int)EyouSoft.Model.Enum.ZuCheStates.停用, EyouSoft.Model.Enum.ZuCheStates.停用.ToString());
            }
            else if (value == EyouSoft.Model.Enum.ZuCheStates.停用)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"PageInfo.EnState(this)\"  data-id='{0}'  data-en='{1}' >{2}</a>&nbsp;&nbsp;", ID.ToString(),
                   (int)EyouSoft.Model.Enum.ZuCheStates.启用, EyouSoft.Model.Enum.ZuCheStates.启用.ToString());
                sb.AppendFormat("<span>{0}</span>", EyouSoft.Model.Enum.ZuCheStates.停用.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region 租车首页显示
        /// <summary>
        /// 租车首页显示
        /// </summary>
        /// <param name="obj">租车状态</param>
        /// <param name="isbool">是否首页显示</param>
        /// <param name="ID">租车id</param>
        /// <returns></returns>
        protected string CheIsIndex(object obj, object isbool, object ID)
        {
            if (obj == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            var value = (EyouSoft.Model.Enum.ZuCheStates)obj;
            var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
            if (value == EyouSoft.Model.Enum.ZuCheStates.启用)
            {
                if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
                {
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"PageInfo.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                       EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
                }
                else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐)
                {
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"PageInfo.EnIndex(this)\" data-id='{0}' data-state='{2}'>{1}</a>", ID.ToString(),
                       "取消推荐", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
                }
            }
            return sb.ToString();
        }
        #endregion

        private string Del()
        {
            string id = Utils.GetQueryStringValue("id");
            string msg = "";
            if (string.IsNullOrEmpty(id)) return UtilsCommons.AjaxReturnJson("0", "请重新选择数据！");
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            if (bll.Delete(id))
            {
                InitInfo();
                msg = "<script>alert('删除成功！');window.parent.frames.mainFrame.location.href='/WebMaster/ZuChe/zuchelist.aspx';</script>";
                //msg = UtilsCommons.AjaxReturnJson("1", "删除成功！");
            }
            else
            {
                msg = "<script>alert('删除失败！');window.parent.frames.mainFrame.location.href='/WebMaster/ZuChe/zuchelist.aspx';</script>";
                //msg = UtilsCommons.AjaxReturnJson("0", "删除失败！");
            }
            return msg;
        }

        private string UpdateState()
        {
            string id = Utils.GetQueryStringValue("id");
            string en = Utils.GetQueryStringValue("en");
            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(en)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
            var enstate = (EyouSoft.Model.Enum.ZuCheStates)Utils.GetInt(en);
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            string msg = "";
            if (bll.updageState(id, enstate))
            {
                msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
            }
            return msg;
        }
        private string UpdateIsIndex()
        {
            string id = Utils.GetQueryStringValue("id");
            string state = Utils.GetQueryStringValue("state");
            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(state)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var enstate = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)Utils.GetInt(state);
            
            string msg = "";
            if (bll.updageIsIndex(id, enstate))
            {
                new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort("zuche", id, 1);
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
