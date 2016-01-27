using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common;
using System.Collections.Generic;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.WAP.Mall
{
    public partial class MallType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Mtype =Utils.GetQueryStringValue("MType");
            string TypeList="";
            int itemCount = 0;
            if (Mtype == "1")
            {
                IList<MLianMengLeiBie> menus = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(1000, 1, ref itemCount, new MLianMengLeiBieSer() { modelTp = EyouSoft.Model.Enum.ModelTypes.购物广场联盟 });
                if (menus != null && menus.Count > 0)
                {
                    for (int i = 0; i < menus.Count; i++)
                    {
                        TypeList += "<dl><dt><a href=\"/Mall/ShangChengLianMeng.aspx?lid="+menus[i].LeiBieID+"\">"+ menus[i].LeiBieMingCheng +"</a></dt></dl>";
                    }
     
                   // TypeList.DataSource = menus;
                    //TypeList.DataBind();
                }
            }
            else if (Mtype == "2")
            {
                IList<MLianMengLeiBie> menus = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(1000, 1, ref itemCount, new MLianMengLeiBieSer() { modelTp = EyouSoft.Model.Enum.ModelTypes.休闲娱乐会所 });
                if (menus != null && menus.Count > 0)
                {
                    for (int i = 0; i < menus.Count; i++)
                    {
                        TypeList += "<dl><dt><a href=\"/Mall/XiuXianYuLe.aspx?lid=" + menus[i].LeiBieID + "\">" + menus[i].LeiBieMingCheng + "</a></dt></dl>";
                    }
                }
            }
            else if (Mtype == "3")
            {
                IList<MLianMengLeiBie> menus = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(1000, 1, ref itemCount, new MLianMengLeiBieSer() { modelTp = EyouSoft.Model.Enum.ModelTypes.天下商旅E家 });
                if (menus != null && menus.Count > 0)
                {
                    for (int i = 0; i < menus.Count; i++)
                    {
                        TypeList += "<dl><dt><a href=\"/Mall/ShangLvEJia.aspx?lid=" + menus[i].LeiBieID + "\">" + menus[i].LeiBieMingCheng + "</a></dt></dl>";
                    }
                }
            }
            else
            {
                var menus = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, false);
                var menuList = menus.Where(i => i.ParentID == 0).ToList();
                if (menuList != null && menuList.Count > 0)
                {

                    for (int i = 0; i < menuList.Count; i++)
                    {
                        TypeList += "<dl><dt>" + menuList[i].TypeName + "</dt>" + getMenu(menuList[i].TypeID) + "</dl>";
                    }
                }
            }
            MTypeList.Text = TypeList;
        }
        /// <summary>
        /// 获取二级目录
        /// </summary>
        /// <param name="id">父节点</param>
        /// <returns></returns>
        protected string getMenu(object id)
        {
            int pid = Utils.GetInt(id.ToString());
            System.Text.StringBuilder strbu = new System.Text.StringBuilder();
            var list = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { ParentID = pid }, false);
            if (list != null && list.Count > 0)
            {

                foreach (var item in list)
                {
                    strbu.AppendFormat(" <dd><a href=\"ModList.aspx?lid={0}\">{1}</a></dd>", item.TypeID, item.TypeName);
                }
            }

            return strbu.ToString();
        }
    }
}
