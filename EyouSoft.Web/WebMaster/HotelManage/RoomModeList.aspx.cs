using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class RoomModeList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInfo.LeiXing == 0 && !this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.酒店管理_酒店房型管理))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string hotelid = Utils.GetQueryStringValue("hotelid");
            string dotype = Utils.GetQueryStringValue("dotype");
            string roomid = Utils.GetQueryStringValue("roomid");
            if (dotype != "")
            {
                switch (dotype)
                {
                    case "delete":
                        Response.Clear();
                        Response.Write(DeleteDate(roomid));
                        Response.End();
                        break;
                    case "up":
                        Response.Clear();
                        Response.Write(Up(roomid));
                        Response.End();
                        break;
                    case "down":
                        Response.Clear();
                        Response.Write(Down(roomid));
                        Response.End();
                        break;
                    default:
                        break;
                }
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            EyouSoft.Model.HotelStructure.MHotelRoomTypeSearch searchmodel = new EyouSoft.Model.HotelStructure.MHotelRoomTypeSearch();
            searchmodel.RoomName = Utils.GetQueryStringValue("txtRoomName");
            searchmodel.HotelId = Utils.GetQueryStringValue("hotelid");
            searchmodel.HotelName = Utils.GetQueryStringValue("txtHotelName");
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {
                searchmodel.HotelId = UserInfo.GysId;
            }

            IList<EyouSoft.Model.HotelStructure.MHotelRoomType> list = bll.GetHotelRoomTypeList(pageSize, pageIndex, ref recordCount, searchmodel);
            Utils.Paging(pageSize, ref pageIndex, recordCount);
            if (list != null && list.Count > 0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                this.lbemptymsg.Text = "<tr><td colspan='20' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        private string DeleteDate(string roomid)
        {
            string msg = string.Empty;
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            int result = bll.DeleteHotelRoomType(roomid);
            if (result == 1)
            {
                msg = Utils.AjaxReturnJson("1", "已删除");
            }
            else if (result == -1)
            {
                msg = Utils.AjaxReturnJson("0", "此房型存在订单,暂不允许删除!");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "删除失败!");
            }
            return msg;
        }
        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        private string Up(string roomid)
        {
            string msg = string.Empty;
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            if (bll.UpdateHotelRoomType(roomid, EyouSoft.Model.Enum.RoomStatus.正常))
            {
                msg = Utils.AjaxReturnJson("1", "已上架");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "操作失败!");
            }
            return msg;
        }
        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        private string Down(string roomid)
        {
            string msg = string.Empty;
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            if (bll.UpdateHotelRoomType(roomid, EyouSoft.Model.Enum.RoomStatus.下架))
            {
                msg = Utils.AjaxReturnJson("1", "已下架");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "操作失败!");
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
