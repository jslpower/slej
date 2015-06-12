using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    /// <summary>
    /// 刘飞
    /// 2013-4-20
    /// 房价列表
    /// </summary>
    public partial class RoomShenqing : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 10;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            //酒店编号
            string hotelid = Utils.GetQueryStringValue("hotelid");
            //房型编号
            string id = Utils.GetQueryStringValue("id");
            if (dotype == "delete" && id != "")
            {
                Response.Clear();
                Response.Write(DeleteDate(id));
                Response.End();
            }
            if (!IsPostBack)
            {
                PageInit(id, dotype);
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dotype"></param>
        private void PageInit(string id, string dotype)
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            EyouSoft.Model.HotelStructure.MHotelRoomRateSearch search = new EyouSoft.Model.HotelStructure.MHotelRoomRateSearch();
            search.HotelId = Utils.GetQueryStringValue("hotelid");
            search.RoomType = !string.IsNullOrEmpty(Utils.GetQueryStringValue("sltroomMode")) ? (EyouSoft.Model.Enum.RoomType?)Utils.GetInt(Utils.GetQueryStringValue("sltroomMode")) : null;
            search.RoomName = Utils.GetQueryStringValue("txtRoomName");
            search.StartDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));
            search.EndDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime"));

            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();

            IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> list = bll.GetHotelRoomRateList(pageSize, pageIndex, ref recordCount, search);
            this.rpHotelPrice.DataSource = list;
            this.rpHotelPrice.DataBind();

            BindExportPage();
        }

        /// <summary>
        /// 绑定房型
        /// </summary>
        /// <returns></returns>
        protected string BindRoomType(string selectItem)
        {
            //  EyouSoft.Model.Enum.RoomType
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value=''>-请选择房型-</option>");
            Array values = Enum.GetValues(typeof(EyouSoft.Model.Enum.RoomType));
            foreach (var item in values)
            {
                int value = (int)Enum.Parse(typeof(EyouSoft.Model.Enum.RoomType), item.ToString());
                string text = Enum.GetName(typeof(EyouSoft.Model.Enum.RoomType), item);
                if (value.ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", value, text);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", value, text);
                }
            }
            return query.ToString();
        }

        /// <summary>
        /// 酒店价格的删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string DeleteDate(string id)
        {
            string msg = string.Empty;
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            int flg = bll.DeleteHotelRoomRate(Utils.GetInt(id));
            if (flg == 1)
            {
                msg = Utils.AjaxReturnJson("1", "删除成功！");
            }
            else if (flg == -1)
            {
                msg = Utils.AjaxReturnJson("0", "操作失败：存在订单不允许删除！");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "删除失败！");
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
