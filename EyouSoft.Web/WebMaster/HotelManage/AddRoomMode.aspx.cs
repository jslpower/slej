using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model.HotelStructure.WebModel;

namespace EyouSoft.Web.WebMaster.HotelManage
{
   /// <summary>
   /// 刘飞
   /// 2013-4-23
   /// 新增/修改房型
   /// </summary>
   public partial class AddRoomMode : EyouSoft.Common.Page.WebmasterPageBase
   {
      protected string StrRoomType = string.Empty;
      protected string StrBedType = string.Empty;
      protected string StrInternet = string.Empty;
      protected string StrIsAddbed = string.Empty;
      protected string StrPayType = string.Empty;
      protected string StrBreakfast = string.Empty;
      protected string StrChaoxiang = string.Empty;
      protected string StrWindow = string.Empty;
      protected string StrHotel = string.Empty;
      protected string IsFenXiao = "0";

      protected void Page_Load(object sender, EventArgs e)
      {
         this.UploadControl1.SetImgheight = "24";
         this.UploadControl2.SetImgheight = "24";
         this.UploadControl3.SetImgheight = "24";
         this.UploadControl1.Setimgwidth = "92";
         this.UploadControl2.Setimgwidth = "92";
         this.UploadControl3.Setimgwidth = "92";
         this.UploadControl1.FileTypes = "*.jpg;*.gif;*.jpeg;*.png;*.bmp";
         this.UploadControl2.FileTypes = "*.jpg;*.gif;*.jpeg;*.png;*.bmp";
         this.UploadControl3.FileTypes = "*.jpg;*.gif;*.jpeg;*.png;*.bmp";
         string roomid = Utils.GetQueryStringValue("roomid");
         string hotelid = Utils.GetQueryStringValue("hotelid");
         string dotype = Utils.GetQueryStringValue("dotype");
         string type = Utils.GetQueryStringValue("type");

         if (type == "save")
         {
            Response.Clear();
            Response.Write(PageSave(roomid, dotype));
            Response.End();
         }

         if (!IsPostBack)
         {
            PageInit(roomid, dotype);
         }
      }
      /// <summary>
      /// 初始化
      /// </summary>
      /// <param name="roomid"></param>
      private void PageInit(string roomid, string dotype)
      {
         int roomtype = 0;
         int bedtype = 0;
         int internet = 0;
         int addbed = 0;
         int paytype = 0;
         int breakfast = 0;
         int chaoxiang = 0;
         int window = 0;
         //if (hotelid != "")
         //{
         //    EyouSoft.BLL.HotelStructure.BHotel bllhotel = new EyouSoft.BLL.HotelStructure.BHotel();
         //    EyouSoft.Model.HotelStructure.MHotel modelhotel = bllhotel.GetModel(hotelid);
         //    this.lbHotelName.Text = modelhotel.HotelName;
         //}
         string hotelid = string.Empty;
         if (roomid != "")
         {
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            EyouSoft.Model.HotelStructure.MHotelRoomType model = bll.GetHotelRoomTypeModel(roomid);

            if (model != null)
            {
               roomtype = (int)model.RoomType;
               bedtype = (int)model.BedType;
               internet = (int)model.IsInternet;
               addbed = (int)model.IsAddBed;
               paytype = (int)model.Payment;
               breakfast = (int)model.IsBreakfast;
               chaoxiang = (int)model.Orientation;
               window = (int)model.IsWindow;
               hotelid = model.HotelId;
               BindHotel(hotelid);
               this.txtbedC.Text = model.BedHeight.ToString("f1");
               this.txtbedK.Text = model.BedWidth.ToString("f1");
               this.txtbedmoney.Text = model.IsAddBedPrice.ToString("f2");
               this.txtbreakfastprice.Text = model.IsBreakfastPrice.ToString("f2");
               this.txtcount.Text = model.TotalNumber.ToString();
               this.txtFloorCount.Text = model.Floor;
               this.txtlanmoney.Text = model.IsInternetPrice.ToString("f2");
               this.txtorderby.Text = model.SortId.ToString();
               this.txtRemark.Text = model.Desc;
               this.txtRoomMode.Text = model.RoomName;
               this.txtSquare.Text = model.RoomArea;
               this.issmoke.Checked = model.IsSmoking;
               if (model.HoteRoomImgList != null && model.HoteRoomImgList.Count > 0)
               {
                  UploadControl1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo>() { new EyouSoft.Web.UserControl.MFileInfo() { FileName = "图片", FilePath = model.HoteRoomImgList[0].FilePath } };
                  this.txtdesc1.Text = model.HoteRoomImgList[0].Desc;
               }
               if (model.HoteRoomImgList != null && model.HoteRoomImgList.Count > 1)
               {
                  UploadControl2.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo>() { new EyouSoft.Web.UserControl.MFileInfo() { FileName = "图片", FilePath = model.HoteRoomImgList[1].FilePath } };
                  this.txtdesc2.Text = model.HoteRoomImgList[1].Desc;
               }
               if (model.HoteRoomImgList != null && model.HoteRoomImgList.Count > 2)
               {
                  UploadControl3.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo>() { new EyouSoft.Web.UserControl.MFileInfo() { FileName = "图片", FilePath = model.HoteRoomImgList[2].FilePath } };
                  this.txtdesc3.Text = model.HoteRoomImgList[2].Desc;
               }
               if (model.IsFenXiao) IsFenXiao = "1";
            }
         }
         else
            BindHotel("");
         StrRoomType = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.RoomType)), roomtype.ToString(), "roomtype");
         StrBedType = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.BedType)), bedtype.ToString(), "bedtype");
         StrInternet = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.IsInternet)), internet.ToString(), "Internet");
         StrIsAddbed = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.IsAddBed)), addbed.ToString(), "addbed");
         StrPayType = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Payment)), paytype.ToString(), "paytype");
         StrBreakfast = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.IsBreakfast)), breakfast.ToString(), "breakfast");
         StrChaoxiang = Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Orientation)), chaoxiang.ToString(), true, "-1", "请选择");
         StrWindow = GetEnumRadio(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.IsWindow)), window.ToString(), "window");

         if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
         {
            ph_0_0.Visible = false;
            ph_0_1.Visible = false;
         }
      }

      private string PageSave(string id, string dotype)
      {
         string msg = "";
         bool t = string.IsNullOrEmpty(id) && dotype == "add";
         EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
         EyouSoft.Model.HotelStructure.MHotelRoomType model = new EyouSoft.Model.HotelStructure.MHotelRoomType();
         model.RoomType = (EyouSoft.Model.Enum.RoomType)Utils.GetInt(Utils.GetFormValue("roomtype"));
         model.BedType = (EyouSoft.Model.Enum.BedType)Utils.GetInt(Utils.GetFormValue("bedtype"));
         model.IsInternet = (EyouSoft.Model.Enum.IsInternet)Utils.GetInt(Utils.GetFormValue("Internet"));
         model.IsAddBed = (EyouSoft.Model.Enum.IsAddBed)Utils.GetInt(Utils.GetFormValue("addbed"));
         model.Payment = (EyouSoft.Model.Enum.Payment)Utils.GetInt(Utils.GetFormValue("paytype"));
         model.IsBreakfast = (EyouSoft.Model.Enum.IsBreakfast)Utils.GetInt(Utils.GetFormValue("breakfast"));
         model.Orientation = (EyouSoft.Model.Enum.Orientation)Utils.GetInt(Utils.GetFormValue("chaoxiang"));
         model.IsWindow = (EyouSoft.Model.Enum.IsWindow)Utils.GetInt(Utils.GetFormValue("window"));
         model.BedHeight = Utils.GetDecimal(Utils.GetFormValue(this.txtbedC.UniqueID));
         model.BedWidth = Utils.GetDecimal(Utils.GetFormValue(this.txtbedK.UniqueID));
         model.Desc = Utils.GetFormValue(this.txtRemark.UniqueID);
         model.Floor = Utils.GetFormValue(this.txtFloorCount.UniqueID);
         model.HotelId = Utils.GetFormValue("sltHotel");
         model.HoteRoomImgList = (List<MHotelRoomImg>)Getuploadimg();
         model.IsAddBedPrice = Utils.GetDecimal(Utils.GetFormValue(this.txtbedmoney.UniqueID));
         model.IsBreakfastPrice = Utils.GetDecimal(Utils.GetFormValue(this.txtbreakfastprice.UniqueID));
         model.IsInternetPrice = Utils.GetDecimal(Utils.GetFormValue(this.txtlanmoney.UniqueID));
         model.IsSmoking = this.issmoke.Checked;
         model.IssueTime = DateTime.Now;
         model.MaxGuestNum = Utils.GetInt(Utils.GetFormValue("sltpeoplecount"));
         model.OperatorId = UserInfo.UserId;
         model.RoomArea = Utils.GetFormValue(txtSquare.UniqueID);
         model.RoomName = Utils.GetFormValue(txtRoomMode.UniqueID);
         model.RoomStatus = EyouSoft.Model.Enum.RoomStatus.正常;
         model.TotalNumber = Utils.GetInt(Utils.GetFormValue(this.txtcount.UniqueID));
         model.SortId = Utils.GetInt(Utils.GetFormValue(this.txtorderby.UniqueID));
         model.IsFenXiao = Utils.GetFormValue("txtIsFenXiao") == "1";

         if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
         {
            model.HotelId = UserInfo.GysId;
         }

         if (t)
         {
            if (bll.AddHotelRoomType(model))
            {
               msg = Utils.AjaxReturnJson("1", "新增成功!");
            }
            else
            {
               msg = Utils.AjaxReturnJson("0", "新增失败!");
            }
         }
         else
         {
            model.RoomTypeId = id;
            if (bll.UpdateHotelRoomType(model))
            {
               msg = Utils.AjaxReturnJson("1", "修改成功!");
            }
            else
            {
               msg = Utils.AjaxReturnJson("0", "修改失败!");
            }
         }
         return msg;
      }


      private void BindHotel(string hotelid)
      {
         EyouSoft.BLL.HotelStructure.BHotel2 bll2 = new EyouSoft.BLL.HotelStructure.BHotel2();
         IList<Model.HotelStructure.MHotel2> list = bll2.GetSimplHotelList(new MHotelSearchModel1 { NoInterface = true });
         StringBuilder str = new StringBuilder();
         if (list != null && list.Count > 0)
         {
            for (int i = 0; i < list.Count; i++)
            {
               str.AppendFormat("<option value='{0}'{1}>{2}</option>", list[i].HotelId, (hotelid == list[i].HotelId ? "selected='selected'" : ""), list[i].HotelName);
            }
         }
         StrHotel = str.ToString();
      }

      /// <summary>
      /// 获取房型图片
      /// </summary>
      /// <returns></returns>
      private IList<MHotelRoomImg> Getuploadimg()
      {
         EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
         IList<MHotelRoomImg> imglist = new List<MHotelRoomImg>();
         var newFiles = UploadControl1.Files;
         var oldFiles = UploadControl1.YuanFiles;
         if (newFiles != null || oldFiles != null)
         {
            MHotelRoomImg model = new MHotelRoomImg();
            if (newFiles != null && newFiles.Any())
            {
               model.FilePath = newFiles[0].FilePath;
            }
            else
            {
               if (oldFiles != null && oldFiles.Any())
               {
                  model.FilePath = oldFiles[0].FilePath;
               }
            }
            model.Desc = Utils.GetFormValue(this.txtdesc1.UniqueID);
            imglist.Add(model);
         }

         var newFiles2 = UploadControl2.Files;
         var oldFiles2 = UploadControl2.YuanFiles;
         if (newFiles2 != null || oldFiles2 != null)
         {
            MHotelRoomImg model2 = new MHotelRoomImg();
            if (newFiles2 != null && newFiles2.Any())
            {
               model2.FilePath = newFiles2[0].FilePath;
            }
            else
            {
               if (oldFiles2 != null && oldFiles2.Any())
               {
                  model2.FilePath = oldFiles2[0].FilePath;
               }
            }
            model2.Desc = Utils.GetFormValue(this.txtdesc2.UniqueID);
            imglist.Add(model2);
         }

         var newFiles3 = UploadControl3.Files;
         var oldFiles3 = UploadControl3.YuanFiles;
         if (oldFiles3 != null || newFiles3 != null)
         {
            MHotelRoomImg model3 = new MHotelRoomImg();
            if (newFiles3 != null && newFiles3.Any())
            {
               model3.FilePath = newFiles3[0].FilePath;
            }
            else
            {
               if (oldFiles3 != null && oldFiles3.Any())
               {
                  model3.FilePath = oldFiles3[0].FilePath;
               }
            }
            model3.Desc = Utils.GetFormValue(this.txtdesc3.UniqueID);
            imglist.Add(model3);
         }
         return imglist;
      }


      /// <summary>
      /// 获取枚举单选按钮
      /// </summary>
      /// <param name="ls">枚举列</param>
      /// <param name="checkedVal">选中的值</param>
      /// <param name="name">单选按钮的name属性</param>
      /// <returns></returns>
      private string GetEnumRadio(List<EnumObj> ls, string checkedVal, string name)
      {
         if (string.IsNullOrEmpty(checkedVal)) checkedVal = string.Empty;

         StringBuilder sb = new StringBuilder();

         for (int i = 0; i < ls.Count; i++)
         {
            if (ls[i].Value != checkedVal.Trim())
            {
               if (checkedVal == "0" && i == 0)
               {
                  sb.Append("<label><input type='radio' name='" + name + "' checked='checked' value='" + ls[i].Value.Trim() + "' />" + ls[i].Text.Trim() + "</label>");
               }
               else
                  sb.Append("<label><input type='radio' name='" + name + "' value='" + ls[i].Value.Trim() + "' />" + ls[i].Text.Trim() + "</label>");
            }
            else
            {
               sb.Append("<label><input type='radio' name='" + name + "' checked='checked' value='" + ls[i].Value.Trim() + "' />" + ls[i].Text.Trim() + "</label>");
            }
         }
         return sb.ToString();
      }
   }
}
