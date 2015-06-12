using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    /// <summary>
    /// 刘飞
    /// 2013-4-22
    /// 酒店列表
    /// </summary>
    public partial class HotelList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.酒店管理_酒店管理))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "delete")
            {
                Response.Clear();
                Response.Write(DeleteDate(id));
                Response.End();
            }
            if (dotype == "isindex" && id != "")
            {
                Response.Clear();
                Response.Write(UpdateState());
                Response.End();
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            EyouSoft.Model.HotelStructure.MHotelSearch searchmodel = new EyouSoft.Model.HotelStructure.MHotelSearch();
            searchmodel.HotelName = Utils.GetQueryStringValue("hotelname");
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            IList<EyouSoft.Model.HotelStructure.MHotel> list = bll.GetHotelList(pageIndex, pageSize, ref recordCount, searchmodel);
            Utils.Paging(pageSize, ref pageIndex, recordCount);
            if (list != null && list.Count > 0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                this.lbemptymsg.Text = "<tr><td colspan='7' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }
        private string DeleteDate(string id)
        {
            string msg = string.Empty;
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            if (bll.DeleteHotel(id))
            {
                msg = Utils.AjaxReturnJson("1", "删除成功!");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "删除失败!");
            }
            return msg;
        }

        protected string GetRoomMode(object obj)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            IList<EyouSoft.Model.HotelStructure.MHotelRoomType> roomlist = (IList<EyouSoft.Model.HotelStructure.MHotelRoomType>)obj;
            str.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'><tr class='pp-table-title'><th>房型</th><th>网络价</th><th>挂牌价</th><th>早餐</th><th>床型</th><th>宽带</th><th>支付</th><th>数量</th><th>状态</th><th>管理</th></tr>");
            if (roomlist != null && roomlist.Count > 0)
            {
                roomlist = roomlist.Where(c => c.RoomStatus == EyouSoft.Model.Enum.RoomStatus.正常).ToList();
                for (int i = 0; i < roomlist.Count; i++)
                {
                    str.AppendFormat("<tr><td><a href='RoomImgInfo.aspx?roomid={10}'>{0}</a></td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td><a href='RoomShenqing.aspx?hotelid={11}'>{9}</a></td></tr>", roomlist[i].RoomName, roomlist[i].SettlementPrice.ToString("f2"), roomlist[i].AmountPrice.ToString("f2"), roomlist[i].IsBreakfast.ToString(), roomlist[i].BedType.ToString(), roomlist[i].IsInternet.ToString(), roomlist[i].Payment.ToString(), roomlist[i].TotalNumber.ToString(), roomlist[i].RoomStatus.ToString(), "房价申请", roomlist[i].RoomTypeId, roomlist[i].HotelId);
                }
            }
            str.Append("</table>");
            return str.ToString();
        }

        #region 景区状态
        /// <summary>
        /// 酒店首页显示
        /// </summary>
        /// <param name="obj">酒店状态</param>
        /// <param name="isbool">是否首页显示</param>
        /// <param name="ID">酒店id</param>
        /// <returns></returns>
        protected string CheIsIndex(object isbool, object ID)
        {
            if (isbool == null && ID == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            var isindex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)isbool;
            if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"HotelList.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
                sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"HotelList.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
            }
            else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"HotelList.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                   "取消推荐", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"HotelList.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架);
            }
            else if (isindex == EyouSoft.Model.Enum.XianLuStructure.XianLuZT.下架)
            {
                sb.AppendFormat("<a href=\"javascript:;\" onclick=\"HotelList.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>  ", ID.ToString(),
                  "上架", (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态);
                sb.AppendFormat("  <a href=\"javascript:;\" onclick=\"HotelList.EnIndex(this)\" data-id='{0}' data-state='{2}' >{1}</a>", ID.ToString(),
                   EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐.ToString(), (int)EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐);
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
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            string msg = "";
            if (bll.UpdateState(id, enstate))
            {
                new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort("jiudian", id, 1);
                msg = UtilsCommons.AjaxReturnJson("1", "修改成功！");
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "修改失败！");
            }
            return msg;
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
