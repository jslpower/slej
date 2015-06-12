using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class PaiXu : System.Web.UI.Page
    {
        protected int xuhao = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!string.IsNullOrEmpty(Utils.GetQueryStringValue("xuhao")))
            //{
            //    xuhao = Utils.GetInt(Utils.GetQueryStringValue("xuhao"));
            //}
            string type = Utils.GetQueryStringValue("type");
            string id = Utils.GetQueryStringValue("id");
            xuhao = new EyouSoft.BLL.OtherStructure.BTuanGou().GetProductSort(type, id);
            if (Utils.GetQueryStringValue("dotype") == "save")
            {
                
                

                Response.Clear();
                Response.Write(Update(type, id));
                Response.End();


            }
        }
        string Update(string type, string id)
        {
            string msg = "";
            int sort = Utils.GetInt(Utils.GetFormValue("XuHao"));
            int Code = new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort(type, id, sort);
            if (Code == 1)
            {
                msg = Utils.AjaxReturnJson("1", "保存成功!");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "保存失败!");
            }
            return msg;
        }
    }
}
