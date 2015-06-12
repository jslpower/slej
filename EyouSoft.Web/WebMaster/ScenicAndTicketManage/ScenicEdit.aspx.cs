using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum.ScenicStructure;
using System.Text;
using EyouSoft.Model.ScenicStructure;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
   /// <summary>
   /// 刘飞
   /// 2013-4-11
   /// 新增、修改 景区
   /// </summary>
   public partial class ScenicEdit : EyouSoft.Common.Page.WebmasterPageBase
   {
      protected int ProvinceId = -1;
      protected int CityId = -1;
      protected int AreaId = -1;
      protected string ScenicLv = string.Empty;
      protected string ScenicTheme = string.Empty;
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
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         EyouSoft.Model.ScenicStructure.MScenicArea model = bll.GetScenicAreaById(id);
         int scenicLv = 0;
         if (model != null)
         {
            this.txtaddress.Text = model.CnAddress;
            this.txtcontactfax.Text = model.ContactFax;
            this.txtcontactmobile.Text = model.ContactMobile;
            this.txtcontactname.Text = model.Contact;
            this.txtContactTel.Text = model.ContactTel;
            this.txtEnName.Text = model.EnName;
            this.txtKaifangTime.Text = model.OpenTime;
            this.txtKefuTel.Text = "";
            this.txtRemark.Text = model.Notes;
            this.txtscenicdesc.Text = model.Description;
            this.txtscenicname.Text = model.ScenicName;
            this.txttraffic.Text = model.Traffic;
            this.txtYear.Text = "";
            this.txtZhoubian.Text = model.Facilities;
            this.cktuijian.Checked = model.IsRecommend;
            this.jingdu.Value = model.X;
            this.X.InnerText = model.X;
            this.Y.InnerText = model.Y;
            this.weidu.Value = model.Y;
            this.txtKefuTel.Text = model.ServiceTel;
            this.txtYear.Text = (model.Year == 0 ? "" : model.Year.ToString());
            this.NetAddress.Text = model.NetAddress;
            ProvinceId = model.ProvinceId;
            CityId = model.CityId;
            AreaId = model.CountyId;
            this.hidareaid.Value = model.CountyId.ToString();
            this.hidproid.Value = model.ProvinceId.ToString();
            this.hidcityid.Value = model.CityId.ToString();
            scenicLv = (int)model.ScenicLevel;

            if (model.JieSuanType)
            {
               this.radyuejie.Checked = true;
            }
            else
            {
               this.radxianjie.Checked = true;
            }


            #region 初始化地标
            StringBuilder str = new StringBuilder();
            List<int> listlankaid = new List<int>();
            int index = 1;
            EyouSoft.BLL.OtherStructure.BSystemLandMark bllmark = new EyouSoft.BLL.OtherStructure.BSystemLandMark();
            IList<EyouSoft.Model.OtherStructure.MSystemLandMark> listlank = bllmark.GetTopList(0, new EyouSoft.Model.OtherStructure.MSystemLandMark { CityId = model.CityId });
            if (model.MarkList != null)
            {
               foreach (var item in model.MarkList)
               {
                  if (item.LandMarkId != 0)
                     listlankaid.Add(item.LandMarkId);
               }
            }
            foreach (var item in listlank)
            {
               if (listlankaid.Contains(item.Id))
                  str.Append("<input type=\"checkbox\" name=\"chkboxLankid\" checked=\"checked\" value=\"" + item.Id + "\" id=\"cbx_" + item.Id + "\" /><label for=\"cbx_" + item.Id + "\">" + item.Por + "</label>");
               else
                  str.Append("<input type=\"checkbox\" name=\"chkboxLankid\" value=\"" + item.Id + "\" id=\"cbx_" + item.Id + "\" /><label for=\"cbx_" + item.Id + "\">" + item.Por + "</label>");
               if (index % 7 == 0) { str.Append("<br>"); }
               index = index + 1;
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "$(\"#Td_ChbLankId\").html('" + str + "')", true);
            #endregion
         }
         ScenicLv = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(ScenicLevel)), ((int)scenicLv).ToString(), true, "0", "请选择");


      }

      private string PageSave(string id, string dotype)
      {
         string msg = Utils.AjaxReturnJson("0", "操作失败!");

         #region 获取表单
         string ScenicName = Utils.GetFormValue(this.txtscenicname.UniqueID);
         string address = Utils.GetFormValue(this.txtaddress.UniqueID);
         string contactfax = Utils.GetFormValue(this.txtcontactfax.UniqueID);
         string contactmobile = Utils.GetFormValue(this.txtcontactmobile.UniqueID);
         string contactname = Utils.GetFormValue(this.txtcontactname.UniqueID);
         string contacttel = Utils.GetFormValue(this.txtContactTel.UniqueID);
         string EnName = Utils.GetFormValue(this.txtEnName.UniqueID);
         string KaifangTime = Utils.GetFormValue(this.txtKaifangTime.UniqueID);
         string kefutel = Utils.GetFormValue(this.txtKefuTel.UniqueID);
         string remark = Utils.GetFormValue(this.txtRemark.UniqueID);
         string scenicdesc = Utils.EditInputText(this.txtscenicdesc.Text);
         string traffic = Utils.GetFormValue(this.txttraffic.UniqueID);
         string year = Utils.GetFormValue(this.txtYear.UniqueID);
         string zhoubian = Utils.EditInputText(this.txtZhoubian.Text);
         bool istuijian = cktuijian.Checked;
         int provinceid = Utils.GetInt(Utils.GetFormValue(this.hidproid.UniqueID));
         int cityid = Utils.GetInt(Utils.GetFormValue(this.hidcityid.UniqueID));
         int areaid = Utils.GetInt(Utils.GetFormValue(this.hidareaid.UniqueID));
         string jingdu = this.jingdu.Value;
         string weidu = this.weidu.Value;
         string netaddress = Utils.GetFormValue(this.NetAddress.UniqueID);
         int sceniclv = Utils.GetInt(Utils.GetFormValue("sceniclv"));
         #endregion

         //t为true 新增，false 修改
         bool t = string.IsNullOrEmpty(id) && dotype == "add";
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         EyouSoft.Model.ScenicStructure.MScenicArea model = new EyouSoft.Model.ScenicStructure.MScenicArea();
         model.CityId = cityid;
         model.CnAddress = address;
         model.Contact = contactname;
         model.ContactFax = contactfax;
         model.ContactMobile = contactmobile;
         model.ServiceTel = kefutel;
         model.ContactTel = contacttel;
         model.CountyId = areaid;
         model.Description = scenicdesc;
         model.EnAddress = "";
         model.EnName = EnName;
         model.Facilities = zhoubian;
         model.IsRecommend = istuijian;
         model.IssueTime = DateTime.Now;
         model.Notes = remark;
         model.OpenTime = KaifangTime;
         model.OperatorId = UserInfo.UserId.ToString();
         model.OperatorName = UserInfo.Username;
         model.ProvinceId = provinceid;
         model.ScenicLevel = (ScenicLevel?)sceniclv;
         model.ScenicName = ScenicName;
         model.Traffic = traffic;
         model.X = jingdu;
         model.Y = weidu;
         model.Year = Utils.GetInt(year);
         model.NetAddress = netaddress;
         if (radyuejie.Checked)
         {
            model.JieSuanType = true;
         }
         else
         {
            model.JieSuanType = false;
         }

         #region 获取地标
         IList<MScenicRelationLandMark> listlank = new List<MScenicRelationLandMark>();

         foreach (string item in Utils.GetFormValues("chkboxLankid"))
         {
            MScenicRelationLandMark modelMScenicRelationLandMark = new MScenicRelationLandMark();
            modelMScenicRelationLandMark.LandMarkId = Utils.GetInt(item);
            listlank.Add(modelMScenicRelationLandMark);
         }
         model.MarkList = (List<Model.ScenicStructure.MScenicRelationLandMark>)listlank;
         #endregion
         if (t)
         {
            if (bll.AddScenicArea(model))
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
            model.ScenicId = id;
            if (bll.UpdateScenicArea(model))
            {
               msg = Utils.AjaxReturnJson("1", "修改成功");
            }
            else
            {
               msg = Utils.AjaxReturnJson("0", "修改失败");
            }
         }
         return msg;
      }

      #region 绑定地标区域
      /// <summary>
      /// 绑定地标区域
      /// </summary>
      protected string BinLankId(string[] argumentlist)
      {
         IList<EyouSoft.Model.OtherStructure.MSystemLandMark> LandMarklist = new List<EyouSoft.Model.OtherStructure.MSystemLandMark>();
         EyouSoft.BLL.OtherStructure.BSystemLandMark bll = new EyouSoft.BLL.OtherStructure.BSystemLandMark();
         EyouSoft.Model.OtherStructure.MSystemLandMark markmodel = new EyouSoft.Model.OtherStructure.MSystemLandMark();
         markmodel.CityId = Utils.GetInt(argumentlist[0]);
         LandMarklist = bll.GetTopList(0, markmodel);
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
      #endregion
   }
}
