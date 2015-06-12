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
    /// 新增/修改房价
    /// </summary>
    public partial class RoomEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //酒店编号
            string hotelid = Utils.GetQueryStringValue("hotelid");
            //房型编号
            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            string type = Utils.GetQueryStringValue("type");
            if (type == "save")
            {
                Response.Clear();
                Response.Write(PageSave(hotelid, id, dotype));
                Response.End();
            }
            if (!IsPostBack)
            {
                PageInit(hotelid, id, dotype);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="hotelid">酒店编号</param>
        /// <param name="id">房型编号</param>
        /// <param name="dotype"></param>
        private void PageInit(string hotelid, string id, string dotype)
        {
            EyouSoft.BLL.HotelStructure.BHotel hotelBll = new EyouSoft.BLL.HotelStructure.BHotel();
            EyouSoft.Model.HotelStructure.MHotel hotelmodel = hotelBll.GetModel(hotelid);
            if (hotelmodel != null)
            {
                this.lbHotelName.Text = hotelmodel.HotelName;
            }


            //绑定酒店房型
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            IList<EyouSoft.Model.HotelStructure.MHotelRoomType> list = bll.GetHotelRoomTypeListByHotelId(hotelid);
            this.ddlRoomType.DataSource = list;
            this.ddlRoomType.DataValueField = "RoomTypeId";
            this.ddlRoomType.DataTextField = "RoomName";
            this.ddlRoomType.DataBind();


            this.ddlRoomType.Items.Insert(0, new ListItem("请选择房型", ""));

            //t 为true 新增 false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            if (!t)
            {
                EyouSoft.Model.HotelStructure.MHotelRoomRate model = bll.GetHotelRoomRateModel(id);
                if (model != null)
                {
                    this.ddlRoomType.SelectedValue = model.RoomTypeId;
                    this.txtstartdate.Text = model.StartDate.ToString("yyyy-MM-dd");
                    this.txtenddate.Text = model.EndDate.ToString("yyyy-MM-dd");
                    this.txtsellprice.Text = model.AmountPrice.ToString("f2");
                    this.txtyouhuipirce.Text = model.PreferentialPrice.ToString("f2");
                    this.txtjiesuanpirce.Text = model.SettlementPrice.ToString("f2");
                    this.txtreason.Text = model.Reason;
                    txtShuLiang.Text = model.ShuLiang.ToString();
                }
            }

        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="hotelid">酒店编号</param>
        /// <param name="id">房型编号</param>
        /// <param name="dotype"></param>
        private string PageSave(string hotelid, string id, string dotype)
        {
            string msg = string.Empty;
            //t 为true 新增 false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";

            #region 获取表单

            string hotelname = this.lbHotelName.Text;
            string roomMode = Utils.GetFormValue(this.ddlRoomType.UniqueID);
            DateTime startdate = Utils.GetDateTime(Utils.GetFormValue(this.txtstartdate.UniqueID));
            DateTime enddate = Utils.GetDateTime(Utils.GetFormValue(this.txtenddate.UniqueID));
            decimal sellprice = Utils.GetDecimal(Utils.GetFormValue(this.txtsellprice.UniqueID));
            decimal jiesuanprice = Utils.GetDecimal(Utils.GetFormValue(this.txtjiesuanpirce.UniqueID));
            decimal youhuiprice = Utils.GetDecimal(Utils.GetFormValue(this.txtyouhuipirce.UniqueID));
            string reason = Utils.GetFormValue(this.txtreason.UniqueID);

            #endregion

            EyouSoft.Model.HotelStructure.MHotelRoomRate model = new EyouSoft.Model.HotelStructure.MHotelRoomRate();
            model.HotelId = hotelid;
            model.RoomTypeId = roomMode;
            model.AmountPrice = sellprice;
            model.PreferentialPrice = youhuiprice;
            model.SettlementPrice = jiesuanprice;
            model.StartDate = startdate;
            model.EndDate = enddate;
            model.OperatorId = this.UserInfo.UserId;
            model.Reason = reason;
            model.ShuLiang = Utils.GetInt(Utils.GetFormValue(txtShuLiang.UniqueID));
            model.ShengYuShuLiang = model.ShuLiang;
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();

            if (t)
            {
                int flg = bll.AddHotelRoomRate(model);

                if (flg == -1)
                {
                    msg = Utils.AjaxReturnJson("0", "开始时间已存在价格！");
                }
                else if (flg == -2)
                {
                    msg = Utils.AjaxReturnJson("0", "结束时间已存在价格！");
                }

                else if (flg == -3)
                {
                    msg = Utils.AjaxReturnJson("0", "存在订单不允许修改！");
                }
                else if (flg == 1)
                {
                    msg = Utils.AjaxReturnJson("1", "新增成功！");
                }
                else
                {
                    msg = Utils.AjaxReturnJson("0", "新增失败！");
                }
            }
            else
            {
                model.RoomRateId = Utils.GetInt(id);

                int flg = bll.UpdateHotelRoomRate(model);

                if (flg == -1)
                {
                    msg = Utils.AjaxReturnJson("0", "开始时间已存在价格！");
                }
                else if (flg == -2)
                {
                    msg = Utils.AjaxReturnJson("0", "结束时间已存在价格！");
                }
                else if (flg == -3)
                {
                    msg = Utils.AjaxReturnJson("0", "存在订单不允许修改！");
                }
                else if (flg == 1)
                {
                    msg = Utils.AjaxReturnJson("1", "修改成功！");
                }
                else if (flg == -99)
                {
                    msg = Utils.AjaxReturnJson("0", "房间数量不能小于已预订房间数量！");
                }
                else
                {
                    msg = Utils.AjaxReturnJson("0", "修改失败！");
                }

            }

            return msg;
        }
    }
}
