using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class PaiXu : EyouSoft.Common.Page.WebmasterPageBase
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
            if (type == "shangcheng")
            {
                xuhao = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetProductSort(UserInfo.GysId, id);
            }
            else
            {
                xuhao = new EyouSoft.BLL.OtherStructure.BTuanGou().GetProductSort(type, id);
            }
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
            int Code =0;
            if (type == "shangcheng")
            {
                Code = new EyouSoft.BLL.MallStructure.BShangChengShangPin().UpdateProductSort(UserInfo.GysId, id, sort);
            }
            else
            {
                Code = new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort(type, id, sort);

            }
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
