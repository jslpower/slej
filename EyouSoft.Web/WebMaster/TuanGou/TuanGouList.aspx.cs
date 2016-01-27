using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster.TuanGou
{
    public partial class TuanGouList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("del") == "1") Del();
            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "isindex" && id != "")
            {
                Response.Clear();
                Response.Write(UpdateState());
                Response.End();
            }
            if (Utils.GetQueryStringValue("dotype") == "isdaili")
            {
                Response.Clear();
                Response.Write(UpdateDaiLiState());
                Response.End();
            }
            initList();

        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            //serchModel.SupplierID = UserInfo.GysId;
            //if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            //{
            //    serchModel.SupplierID = UserInfo.GysId;
            //}
            serchModel.SupplierID = UserInfo.GysId;
            serchModel.IsWebmaster = true;
            if (Utils.GetQueryStringValue("type") =="s")
            {
                serchModel.SupplierID = null;
                serchModel.ValiDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CompanyName")))
            {
               serchModel.CompanyName  = Utils.GetQueryStringValue("CompanyName");
            }
            serchModel.ProductName = Utils.GetQueryStringValue("CpName");
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CpType"))) serchModel.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.ChanPinLeiXing), Utils.GetQueryStringValue("CpType"));
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CxType"))) serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.ChanPinLeiXing), Utils.GetQueryStringValue("CxType"));
            pageIndex = UtilsCommons.GetPagingIndex();
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindExportPage();
            }
            else
            {
                litNoMsg.Text = "<tr><td align='center' colspan='10'>暂无数据</td></tr>";
            }

        }


        /// <summary>
        /// 删除分类
        /// </summary>
        void Del()
        {
            int result = new EyouSoft.BLL.OtherStructure.BTuanGou().Delete(Utils.GetInt(Utils.GetQueryStringValue("id")));
            if (result == 1)
            {
                new EyouSoft.BLL.OtherStructure.BTuanGou().DelDaiLiPro(Utils.GetQueryStringValue("id"));
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "删除成功" : "删除失败"));
            Response.End();
        }
        #region 团购状态
        /// <summary>
        /// 团购首页显示
        /// </summary>
        /// <param name="obj">团购状态</param>
        /// <param name="isbool">是否首页显示</param>
        /// <param name="ID">团购id</param>
        /// <returns></returns>
        protected string CheIsIndex(object isbool, object ID)
        {
            if (isbool == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
            if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
            {
                sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
            }
            else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                  "上架", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
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
            EyouSoft.BLL.OtherStructure.BTuanGou bll = new EyouSoft.BLL.OtherStructure.BTuanGou();
            string msg = "";
            if (bll.UpdateState(id, enstate))
            {
                if (enstate == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
                {
                    new EyouSoft.BLL.OtherStructure.BTuanGou().DelDaiLiPro(id);
                }
                msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
            }
            return msg;
        }

        private string UpdateDaiLiState()
        {
            string id = Utils.GetQueryStringValue("id");
            string state = Utils.GetQueryStringValue("state");
            string probool = Utils.GetQueryStringValue("probool");
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(probool)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
            var enstate = (EyouSoft.Model.Enum.ProductZT)Utils.GetInt(state);
            EyouSoft.BLL.OtherStructure.BTuanGou bll = new EyouSoft.BLL.OtherStructure.BTuanGou();
            string msg = "";
            if (probool == "1")
            {
                //修改
                int num = bll.UpDateDaiLiUp(id, enstate, UserInfo.GysId);
                if (num > 0)
                {
                    msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
                }
                else
                {
                    msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
                }
            }
            else
            {
                //增加
                int num = bll.AddDaiLiPro(UserInfo.GysId, id, Utils.GetInt(state));
                if (num > 0)
                {
                    msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
                }
                else
                {
                    msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
                }
            }
            return msg;
        }
        /// <summary>
        /// 获取代理商的公司名称
        /// </summary>
        /// <param name="DaiLiID"></param>
        /// <returns></returns>
        protected string GetCompanyName(object DaiLiID)
        {
            var DaiLiModel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(DaiLiID.ToString());
            if (DaiLiModel != null)
            {
                return "<a href=\"/webmaster/Supplier/SupplierD.aspx?dlsid="+DaiLiID+"\">"+DaiLiModel.CompanyName+"</a>";
            }
            else
            {
                return "金奥";
            }
        }
        protected string GetDaiLiPro(object isbool, object endtime, object ID)
        {
            if (ID == null) return "暂无该商品";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            if (Convert.ToDateTime(endtime) > DateTime.Now.AddDays(-1))
            {
                int Pstatus = new EyouSoft.BLL.OtherStructure.BTuanGou().GetDaiLiPro(ID.ToString(), UserInfo.GysId);
                if (Pstatus == -1)//表示上架中
                {
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='0' >{1}</a>", ID.ToString(),
                       EyouSoft.Model.Enum.ProductZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.ProductZT.首页推荐);
                    sb.AppendFormat("&nbsp;");
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='0' >{1}</a>", ID.ToString(),
                         "取消代理", (int)EyouSoft.Model.Enum.ProductZT.下架);
                }
                else if (Pstatus != -2 && Pstatus != -1)//表示已下架
                {
                    var isindex = (EyouSoft.Model.Enum.ProductZT)Pstatus;
                    if (isindex == EyouSoft.Model.Enum.ProductZT.上架)
                    {
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           EyouSoft.Model.Enum.ProductZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.ProductZT.首页推荐);
                        sb.AppendFormat("&nbsp;");
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           "取消代理", (int)EyouSoft.Model.Enum.ProductZT.下架);
                    }
                    else if (isindex == EyouSoft.Model.Enum.ProductZT.首页推荐)
                    {
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           "取消推荐", (int)EyouSoft.Model.Enum.ProductZT.上架);
                        sb.AppendFormat("&nbsp;");
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           "取消代理", (int)EyouSoft.Model.Enum.ProductZT.下架);
                    }
                    else if (isindex == EyouSoft.Model.Enum.ProductZT.下架)
                    {
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                          "我要代理", (int)EyouSoft.Model.Enum.ProductZT.上架);
                        sb.AppendFormat("&nbsp;");
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           EyouSoft.Model.Enum.ProductZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.ProductZT.首页推荐);
                    }
                    else if (isindex == EyouSoft.Model.Enum.ProductZT.暂无该商品)
                    {
                        if (isbool == null)
                        {
                            sb.Append("暂无该商品");
                        }
                        else
                        {
                            if ((EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
                            {
                                sb.Append("暂无该商品");
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                         "我要代理", (int)EyouSoft.Model.Enum.ProductZT.上架);
                                sb.AppendFormat("&nbsp;");
                                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                                   "首页推荐", (int)EyouSoft.Model.Enum.ProductZT.首页推荐);
                            }
                        }
                    }
                }
                else
                {
                    sb.Append("暂无该商品");
                }
            }
            else
            {
                sb.Append("暂无该商品");
            }
            return sb.ToString();
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
