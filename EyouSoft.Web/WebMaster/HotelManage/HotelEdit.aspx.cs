using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.HotelStructure;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster.HotelManage
{
   public partial class HotelEdit : EyouSoft.Common.Page.WebmasterPageBase
   {
      protected int ProvinceId = -1;
      protected int CityId = -1;
      protected int AreaId = -1;
      protected string HotelLv = string.Empty;
      protected string CityCode = "Load";
      protected string htprovice = "";
      protected string htcitycode = "";
      protected string CheckedHotelMarkId = string.Empty;

      protected void Page_Load(object sender, EventArgs e)
      {
          string id = Utils.GetQueryStringValue("id");
          string dotype = Utils.GetQueryStringValue("dotype");
          string type = Utils.GetQueryStringValue("type");
          string argument = Utils.GetQueryStringValue("arg");
          string[] argumentlist = { "" };
          if (!string.IsNullOrEmpty(argument))
          {
              if (argument.Contains('$'))
                  argumentlist = argument.Split('$');
              else
                  argumentlist[0] = argument;
          }
          if (type.Trim() != "")
          {
              switch (type)
              {
                  case "save":
                      Response.Clear();
                      Response.Write(PageSave(id, dotype));
                      Response.End();
                      break;
                  case "BinLankId":
                      Response.Clear();
                      Response.Write(BinLankId(argumentlist));
                      Response.End();
                      break;
                  default:
                      break;
              }

          }
          if (!IsPostBack)
          {
              PageInit(id, dotype);
          }
      }
      /// <summary>
      /// 初始化
      /// </summary>
      /// <param name="id"></param>
      /// <param name="dotype"></param>
      private void PageInit(string id, string dotype)
      {
         int hotellv = (int)EyouSoft.Model.Enum.HotelStar.二星级以下;
         if (id != "" && dotype == "update")
         {
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            EyouSoft.Model.HotelStructure.MHotel model = bll.GetModel(id);
            if (model != null)
            {
               //初始化
               this.txtaddress.Text = model.Address;
               this.txtEnName.Text = model.HotelNameEn;
               this.txtFitment.Text = model.Fitment;
               this.txtfloorcount.Text = model.Floor.ToString();
               this.txthoteldesc.Text = model.LongDesc;
               this.txthotelname.Text = model.HotelName;
               this.txtKefuTel.Text = model.ServiceTel;
               this.txtpost.Text = model.PostalCode;
               this.txtRemark.Text = model.AdditionalCost;
               this.txtroomcount.Text = model.RoomQuantity.ToString();
               this.txttraffic.Text = model.Transport;
               this.txtYear.Text = model.OpenDate;
               this.X.InnerText = model.Longitude;
               this.jingdu.Value = model.Longitude;
               this.Y.InnerText = model.Latitude;
               this.weidu.Value = model.Latitude;
               this.isHot.Checked = model.IsHot;
               this.isRecommend.Checked = model.IsRecommend;
               CityCode = model.CityCode;
               searchcode.Value = model.CityCode;

               htcitycode = model.CityCode;
               IList<EyouSoft.Model.HotelStructure.MHotelCityAreas> list = new EyouSoft.BLL.HotelStructure.BHotelCity().GetHoteCityList(htcitycode);
               htprovice = list[0].AreaName;


               ProvinceId = model.ProvinceId;
               CityId = model.CityId;
               AreaId = model.CountyId;
               //this.hidareaid.Value = model.CountyId.ToString();
               //this.hidproid.Value = model.ProvinceId.ToString();
               //this.hidcityid.Value = model.CityId.ToString();

               txtMobile.Text = model.Mobile;


               #region 初始化地标
               //StringBuilder str = new StringBuilder();
               //List<int> listlankaid = new List<int>();
               //int index = 1;
               //EyouSoft.BLL.HotelStructure.BHotelLandMarks bllmark = new EyouSoft.BLL.HotelStructure.BHotelLandMarks();
               //IList<EyouSoft.Model.HotelStructure.MHotelLandMarks> listlank = bllmark.GetList(0, CityId.ToString());
               //if (model.MarkList != null)
               //{
               //    foreach (var item in model.MarkList)
               //    {
               //        if (item.LandMarkId != 0)
               //            listlankaid.Add(item.LandMarkId);
               //    }
               //}
               //foreach (var item in listlank)
               //{
               //    if (listlankaid.Contains(item.Id))
               //        str.Append("<input type=\"checkbox\" name=\"chkboxLankid\" checked=\"checked\" value=\"" + item.Id + "\" id=\"cbx_" + item.Id + "\" /><label for=\"cbx_" + item.Id + "\">" + item.Por + "</label>");
               //    else
               //        str.Append("<input type=\"checkbox\" name=\"chkboxLankid\" value=\"" + item.Id + "\" id=\"cbx_" + item.Id + "\" /><label for=\"cbx_" + item.Id + "\">" + item.Por + "</label>");
               //    if (index % 7 == 0) { str.Append("<br>"); }
               //    index = index + 1;
               //}
               hotellv = (int)model.Star;
               //this.Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "$(\"#Td_ChbLankId\").html('" + str + "')", true);
               #endregion

               if (model.MarkList != null && model.MarkList.Any())
               {
                  foreach (var t in model.MarkList)
                  {
                     if (t == null || t.LandMarkId <= 0) continue;

                     CheckedHotelMarkId += t.LandMarkId + ",";
                  }
               }
               if (!string.IsNullOrEmpty(CheckedHotelMarkId)) CheckedHotelMarkId = CheckedHotelMarkId.TrimEnd(',');
            }
         }
         HotelLv = Utils.GetEnumDDL(EnumObj.GetList(typeof(HotelStar)), hotellv.ToString(), false);
      }
      private string PageSave(string id, string dotype)
      {
         bool t = string.IsNullOrEmpty(id) && dotype == "add";
         string msg = string.Empty;
         string hotelname = Utils.GetFormValue(this.txthotelname.UniqueID);
         string cnaddress = Utils.GetFormValue(this.txtaddress.UniqueID);
         string enName = Utils.GetFormValue(this.txtEnName.UniqueID);
         string hoteldesc = Utils.EditInputText(this.txthoteldesc.Text);
         string kefutel = Utils.GetFormValue(this.txtKefuTel.UniqueID);
         string post = Utils.GetFormValue(this.txtpost.UniqueID);
         string traffic = Utils.GetFormValue(this.txttraffic.UniqueID);
         string remark = Utils.GetFormValue(this.txtRemark.UniqueID);
         string year = Utils.GetFormValue(this.txtYear.UniqueID);
         int roomcount = Utils.GetInt(Utils.GetFormValue(this.txtroomcount.UniqueID));
         string floorcount = Utils.GetFormValue(this.txtfloorcount.UniqueID);
         string jingdu = this.jingdu.Value;
         string weidu = this.weidu.Value;
         int hotelLv = Utils.GetInt(Utils.GetFormValue("hotellv"));
         string Fitment = Utils.GetFormValue(this.txtFitment.UniqueID);
         bool isHot = this.isHot.Checked;
         bool isRecommend = this.isRecommend.Checked;
         string citycode = Utils.GetFormValue("SelectHotelCity");
         if (citycode != "0" && citycode != null)
         {

             //int provinceid = Utils.GetInt(Utils.GetFormValue(this.hidproid.UniqueID));
             //int cityid = Utils.GetInt(Utils.GetFormValue(this.hidcityid.UniqueID));
             //int areaid = Utils.GetInt(Utils.GetFormValue(this.hidareaid.UniqueID));

             #region 获取地标

             #endregion

             EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
             EyouSoft.Model.HotelStructure.MHotel model = new EyouSoft.Model.HotelStructure.MHotel();
             model.AdditionalCost = remark;
             model.Address = cnaddress;
             model.EnAddress = "";
             model.Fitment = Fitment;
             model.Floor = floorcount;
             model.HotelName = hotelname;
             model.HotelNameEn = enName;
             model.IssueTime = DateTime.Now;
             model.Latitude = weidu;
             model.LongDesc = hoteldesc;
             model.Longitude = jingdu;
             model.OpenDate = year;
             model.PostalCode = post;
             model.RoomQuantity = roomcount;
             model.ServiceTel = kefutel;
             model.Star = (EyouSoft.Model.Enum.HotelStar)hotelLv;
             model.Status = EyouSoft.Model.Enum.HotelStatus.正常;
             model.IsRecommend = isRecommend;
             model.IsHot = isHot;
             model.Transport = traffic;
             model.OperatorId = UserInfo.UserId;
             model.CityCode = citycode;

             model.ProvinceId = 0;
             model.CountyId = 0;
             model.CityId = 0;
             model.Mobile = Utils.GetFormValue(txtMobile.UniqueID);


             model.JieSuanType = false;

             #region 获取地标
             IList<MHotelLandMark> listlank = new List<MHotelLandMark>();

             foreach (string item in Utils.GetFormValues("chkboxLankid"))
             {
                 MHotelLandMark modelMHotelRelationLandMark = new MHotelLandMark();
                 modelMHotelRelationLandMark.LandMarkId = Utils.GetInt(item);
                 listlank.Add(modelMHotelRelationLandMark);
             }
             model.MarkList = (List<MHotelLandMark>)listlank;
             #endregion

             if (t)
             {
                 if (bll.AddHotel(model))
                 {
                     msg = Utils.AjaxReturnJson("1", "新增成功");
                 }
                 else
                 {
                     msg = Utils.AjaxReturnJson("0", "新增失败");
                 }
             }
             else
             {
                 model.HotelId = id;
                 if (bll.UpdateHotel(model))
                 {
                     msg = Utils.AjaxReturnJson("1", "修改成功");
                 }
                 else
                 {
                     msg = Utils.AjaxReturnJson("0", "修改失败!");
                 }
             }
         }
         else
         {
             msg = Utils.AjaxReturnJson("0", "请选择酒店所在城市!");
         }
         return msg;
      }


      #region 绑定地标区域
      /// <summary>
      /// 绑定地标区域
      /// </summary>
      protected string BinLankId(string[] argumentlist)
      {
         if (!string.IsNullOrEmpty(argumentlist[0]))
         {
            IList<EyouSoft.Model.HotelStructure.MHotelLandMarks> LandMarklist = new List<EyouSoft.Model.HotelStructure.MHotelLandMarks>();
            EyouSoft.BLL.HotelStructure.BHotelLandMarks bll = new EyouSoft.BLL.HotelStructure.BHotelLandMarks();
            LandMarklist = bll.GetList(0, argumentlist[0]);
            if (LandMarklist.Count > 0)
            {
               StringBuilder strLandMark = new StringBuilder("[");
               foreach (var model in LandMarklist)
               {
                  strLandMark.Append("{\"Por\":\"" + model.Por + "\",\"Id\":\"" + model.Id + "\"},");
               }
               strLandMark.Remove(strLandMark.Length - 1, 1);
               strLandMark.Append("]");
               return strLandMark.ToString();
            }
            else
               return "error";
         }
         return "[]";

      }

      /// <summary>
      /// 绑定省份
      /// </summary>
      /// <param name="selectItem"></param>
      /// <returns></returns>
      protected string BindHotelProvice(string selectItem)
      {
          System.Text.StringBuilder query = new System.Text.StringBuilder();
          IList<EyouSoft.Model.HotelStructure.MHotelCityAreas> list = new EyouSoft.BLL.HotelStructure.BHotelCity().GetCitySZMList(null);
          query.Append("<option value='0' >-请选择-</option>");
          for (int i = 0; i < list.Count; i++)
          {
              if ((list[i].AreaName).ToString().Equals(selectItem))
              {
                  query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].CityCode, list[i].AreaName);
              }
              else
              {
                  query.AppendFormat("<option value='{0}' >{1}</option>", list[i].CityCode, list[i].AreaName);

              }
          }
          return query.ToString();

      }

      #endregion
   }
}
