using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.ScenicStructure;
using Common.page;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.ScenicStructure.WebModel;
using Linq.Web;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model;
using Linq.Common;
using EyouSoft.Web.MasterPage;
using EyouSoft.Common;

namespace EyouSoft.Web
{
   public partial class YouHuiMenPiao : ClientModelViewPageBase<MScenicAreaWebSearchModel>
   {
      BScenicArea2 bll = new BScenicArea2();
      BSysAdv bllAdv = new BSysAdv();
      protected override int PageSize
      {
         get
         {
            return 12;
         }
      }

      protected void Page_Load(object sender, EventArgs e)
      {
          if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("gettype")) && Utils.GetQueryStringValue("gettype") == "city")
          {
              Response.Clear();
              Response.Write(GetCity());
              Response.End();
          } 
         (Master as Front).HeadMenuIndex = 6;
         Model.SearchInfo.PageInfo = PageInfo;
         Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
         if (Model.CityId == 0)
         {
             Model.CityId = null;
         }
         var list = bll.GetScenicList(Model);

         Repeater1.DataSource = list;
         Repeater1.DataBind();
         List<MSysAdv> imgList = new List<MSysAdv>(bllAdv.GetList(5, AdvArea.优惠门票首页轮换广告));
         Repeater2.DataSource = imgList;
         Repeater2.DataBind();
      }
      protected string GetProvince()
      {
          System.Text.StringBuilder OptionList = new System.Text.StringBuilder();
          EyouSoft.BLL.OtherStructure.BSysAreaInfo bllAreaInfo = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();
          IList<EyouSoft.Model.MSysProvince> pList = bllAreaInfo.GetSysProvinceList(0, new EyouSoft.Model.MSysProvince { });
          OptionList.Append("<select name=\"ProvinceId\" id=\"ProvinceId\">");
          OptionList.Append("<option value >-请选择-</option>");
          if (pList != null)
          {
              for (int i = 0; i < pList.Count; i++)
              {
                  if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("ProvinceId")) && pList[i].ID == Utils.GetInt(Utils.GetQueryStringValue("ProvinceId")))
                  {
                      OptionList.AppendFormat("<option value=\"{0}\"  selected='selected'>{1}</option>", pList[i].ID, pList[i].Name);
                  }
                  else
                  {
                      OptionList.AppendFormat("<option value=\"{0}\">{1}</option>", pList[i].ID, pList[i].Name);
                  }
              }
          }
          OptionList.Append("</select>");
          return OptionList.ToString();
      }
      protected string GetCity()
      {
          System.Text.StringBuilder OptionList = new System.Text.StringBuilder();
          if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("ProvinceId")))
          {
              EyouSoft.BLL.OtherStructure.BSysAreaInfo bll = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();
              IList<EyouSoft.Model.MSysCity> cList = bll.GetSysCityList(0, new EyouSoft.Model.MSysCity { ProvinceId = Utils.GetInt(Utils.GetQueryStringValue("ProvinceId")) });
              OptionList.Append("<option value=\"0\" >-请选择-</option>");
              if (cList != null)
              {
                  for (int i = 0; i < cList.Count; i++)
                  {
                      if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CityId")) && cList[i].Id == Utils.GetInt(Utils.GetQueryStringValue("CityId")))
                      {
                          OptionList.AppendFormat("<option value=\"{0}\"  selected='selected'>{1}</option>", cList[i].Id, cList[i].Name);
                      }
                      else
                      {
                          OptionList.AppendFormat("<option value=\"{0}\">{1}</option>", cList[i].Id, cList[i].Name);
                      }
                  }
              }
          }
          return OptionList.ToString();
      }
   }
}
