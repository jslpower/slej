using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class ProductList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("del") == "1") Del();

            if (Utils.GetQueryStringValue("dotype") == "xiajia")
            {
                xiajia();
            }

            if (Utils.GetQueryStringValue("dotype") == "isindex")
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
            initDDL();
            initList();

        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            var serchModel = new EyouSoft.Model.MallStructure.MShangChengShangPinSer();
            pageIndex = UtilsCommons.GetPagingIndex();
            serchModel.ProductName = Utils.GetQueryStringValue("CName");
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CompanyName")))
            {
                serchModel.CompanyName = Utils.GetQueryStringValue("CompanyName");
            }
            serchModel.GYSid = UserInfo.GysId;
            if (Utils.GetQueryStringValue("type") == "s")
            {
                serchModel.GYSid = null;
                serchModel.isGetTrue = true;
                serchModel.isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            }
            string typeid = Utils.GetQueryStringValue("ddlType");
            if (!string.IsNullOrEmpty(typeid))
            {
                serchModel.TypeID = Convert.ToInt32(typeid);
            }
            var list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, serchModel);
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
        /// 绑定分类
        /// </summary>
        protected void initDDL()
        {
            var typeList = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, false);

            System.Text.StringBuilder strbu = new System.Text.StringBuilder();

            string dataJson = string.Format("pageData.dataJson={0}", Newtonsoft.Json.JsonConvert.SerializeObject(typeList));

            RegisterScript(dataJson);



            //strbu.Append("<option value='0'>请选择</option>");
            //if (typeList != null && typeList.Count > 0)
            //{
            //    for (int i = 0; i < typeList.Count; i++)
            //    {
            //        if (typeList[i].TypeID.ToString() == defaultValue)
            //        {
            //            strbu.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", typeList[i].TypeID, typeList[i].TypeName);
            //        }
            //        else
            //        {
            //            strbu.AppendFormat("<option value=\"{0}\" >{1}</option>", typeList[i].TypeID, typeList[i].TypeName);
            //        }
            //    }
            //}

            //return strbu.ToString();
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        void Del()
        {
            new EyouSoft.BLL.MallStructure.BShangChengShangPin().DelDaiLiPro(Utils.GetQueryStringValue("id"));
            int result = new EyouSoft.BLL.MallStructure.BShangChengShangPin().Delete(Utils.GetQueryStringValue("id"));
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "删除成功" : "删除失败"));
            Response.End();
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


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        private string UpdateState()
        {
            string id = Utils.GetQueryStringValue("id");
            string state = Utils.GetQueryStringValue("state");
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(state)) return UtilsCommons.AjaxReturnJson("0", "修改失败！");
            var enstate = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)Utils.GetInt(state);
            EyouSoft.BLL.MallStructure.BShangChengShangPin bll = new EyouSoft.BLL.MallStructure.BShangChengShangPin();
            string msg = "";
            if (enstate == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
            {
                new EyouSoft.BLL.MallStructure.BShangChengShangPin().DelDaiLiPro(id);
            }
            if (bll.UpDateUp(id, enstate) > 0)
            {
                new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort("shangcheng", id, 1);
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
            EyouSoft.BLL.MallStructure.BShangChengShangPin bll = new EyouSoft.BLL.MallStructure.BShangChengShangPin();
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
        protected string GetIsTrue(object isbool, object endtime, object ID)
        {
            if (isbool == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            if (Convert.ToDateTime(endtime) > DateTime.Now.AddDays(-1))
            {
                var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
                if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
                {
                    //sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                    //   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                       EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
                }
                else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐)
                {
                    //sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                    //   "取消推荐", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                       EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
                }
                else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
                {
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                      "上架", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
                    //sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"pageData.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                    //   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
                }
            }
            return sb.ToString();

        }
        protected string GetDaiLiPro(object isbool, object endtime, object ID)
        {
            if (ID == null) return "暂无该商品";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            if (Convert.ToDateTime(endtime) > DateTime.Now.AddDays(-1))
            {
                int Pstatus = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiPro(ID.ToString(), UserInfo.GysId);
                if (Pstatus == -1)//表示上架中
                {
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='0' >{1}</a>", ID.ToString(),
                       EyouSoft.Model.Enum.ProductZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.ProductZT.首页推荐);
                    sb.AppendFormat("&nbsp;");
                    sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='0' >{1}</a>", ID.ToString(),
                         "下架", (int)EyouSoft.Model.Enum.ProductZT.下架);
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
                           EyouSoft.Model.Enum.ProductZT.下架.ToString(), (int)EyouSoft.Model.Enum.ProductZT.下架);
                    }
                    else if (isindex == EyouSoft.Model.Enum.ProductZT.首页推荐)
                    {
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           "取消推荐", (int)EyouSoft.Model.Enum.ProductZT.上架);
                        sb.AppendFormat("&nbsp;");
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                           EyouSoft.Model.Enum.ProductZT.下架.ToString(), (int)EyouSoft.Model.Enum.ProductZT.下架);
                        sb.AppendFormat("&nbsp;<a data-class=\"paixu\" href=\"javascript:;\" data-id=\"{0}\">排序</a>", ID.ToString());
                    }
                    else if (isindex == EyouSoft.Model.Enum.ProductZT.下架)
                    {
                        sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                          "上架", (int)EyouSoft.Model.Enum.ProductZT.上架);
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
                         "上架", (int)EyouSoft.Model.Enum.ProductZT.上架);
                                sb.AppendFormat("&nbsp;");
                                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"pageData.SheZhiStatus(this)\" data-id='{0}' data-state='{2}' data-bool='1' >{1}</a>", ID.ToString(),
                                   EyouSoft.Model.Enum.ProductZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.ProductZT.首页推荐);
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
                return DaiLiModel.CompanyName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 下架产品
        /// </summary>
        void xiajia()
        {

            string[] ids = Utils.GetFormValues("arrid[]");
            EyouSoft.Model.Enum.ProductZT enstate = EyouSoft.Model.Enum.ProductZT.下架;
            EyouSoft.BLL.MallStructure.BShangChengShangPin bll = new EyouSoft.BLL.MallStructure.BShangChengShangPin();

            //修改
            int num = bll.UpDateDaiLiUp(ids, enstate, UserInfo.GysId);
            if (num > 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "修改成功！"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "修改失败！"));




        }



    }
}
