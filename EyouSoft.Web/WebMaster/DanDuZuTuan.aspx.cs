using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Model.Enum.Privs;

namespace EyouSoft.Web.WebMaster
{
    [Power(Menu1.线路产品管理, Menu2.线路产品管理_组团费用)]
    public partial class DanDuZuTuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("type").Trim();
            if (type == "save")
            {
                Update();
            }
            if (!IsPostBack)
            {
                PageInit();
            }

        }
        void PageInit()
        {
            EyouSoft.Model.OtherStructure.MZuTuan model = new EyouSoft.BLL.OtherStructure.BZuTuan().GetModel();
            if (model != null)
            {
                CarMoney.Value = Convert.ToDecimal(model.CarMoney).ToString("f2");
                ZaoCan.Value = model.ZaoCanMoney;
                WuCan.Value = model.WuCanMoney;
                WanCan.Value = model.WanCanMoney;
                RenShen.Value = model.RSYiWai;
                JiaoTong.Value = model.JTYiWai;
                DaoYou.Value = Convert.ToDecimal(model.DaoYouMoney).ToString("f2");
                CarMSJia.Value = Convert.ToDecimal(model.MSCarMoney).ToString("f2");
                ZaoCanMS.Value = model.MSZaoCanMoney;
                WuCanMS.Value = model.MSWuCanMoney;
                WanCanMS.Value = model.MSWanCanMoney;
                RenShenMS.Value = model.MSRSYiWai;
                JiaoTongMS.Value = model.MSJTYiWai;
                DaoYouMS.Value = Convert.ToDecimal(model.MSDaoYouMoney).ToString("f2");
                DuanXianRS.Value = model.DXRS.ToString();
                ChangXianRS.Value = model.CXRS.ToString();
                GuojiRS.Value = model.CJRS.ToString();
                DiPei.Value = Convert.ToDecimal(model.DiPeiDaoYou).ToString("f2");
                DiPeiMS.Value = Convert.ToDecimal(model.MSDiPeiDaoYou).ToString("f2");
                DXDaoYou.Value = Convert.ToDecimal(model.DXDaoYouMoney).ToString("f2");
                DXDaoYouMS.Value = Convert.ToDecimal(model.MSDXDaoYouMoney).ToString("f2");
                DXDiPei.Value = Convert.ToDecimal(model.DXDiPeiDaoYou).ToString("f2");
                DXDiPeiMS.Value = Convert.ToDecimal(model.MSDXDiPeiDaoYou).ToString("f2");
                CJDaoYou.Value = Convert.ToDecimal(model.CJDaoYouMoney).ToString("f2");
                CJDaoYouMS.Value = Convert.ToDecimal(model.MSCJDaoYouMoney).ToString("f2");
                CJDiPei.Value = Convert.ToDecimal(model.CJDiPeiDaoYou).ToString("f2");
                CJDiPeiMS.Value = Convert.ToDecimal(model.MSCJDiPeiDaoYou).ToString("f2");
            }
        }
        void Update()
        {
           EyouSoft.Model.OtherStructure.MZuTuan model = new EyouSoft.Model.OtherStructure.MZuTuan();
           model.CarMoney = Convert.ToDecimal(Utils.GetFormValue(this.CarMoney.UniqueID));
           model.ZaoCanMoney = Utils.GetFormValue(this.ZaoCan.UniqueID);
           model.WuCanMoney = Utils.GetFormValue(this.WuCan.UniqueID);
           model.WanCanMoney = Utils.GetFormValue(this.WanCan.UniqueID);
           model.RSYiWai = Utils.GetFormValue(this.RenShen.UniqueID);
           model.JTYiWai = Utils.GetFormValue(this.JiaoTong.UniqueID);
           model.DaoYouMoney = Convert.ToDecimal(Utils.GetFormValue(this.DaoYou.UniqueID));
           model.MSCarMoney = Convert.ToDecimal(Utils.GetFormValue(this.CarMSJia.UniqueID));
           model.MSZaoCanMoney = Utils.GetFormValue(this.ZaoCanMS.UniqueID);
           model.MSWuCanMoney = Utils.GetFormValue(this.WuCanMS.UniqueID);
           model.MSWanCanMoney = Utils.GetFormValue(this.WanCanMS.UniqueID);
           model.MSRSYiWai = Utils.GetFormValue(this.RenShenMS.UniqueID);
           model.MSJTYiWai = Utils.GetFormValue(this.JiaoTongMS.UniqueID);
           model.MSDaoYouMoney = Convert.ToDecimal(Utils.GetFormValue(this.DaoYouMS.UniqueID));
           model.CJRS = Convert.ToInt32(Utils.GetFormValue(this.GuojiRS.UniqueID));
           model.CXRS = Convert.ToInt32(Utils.GetFormValue(this.ChangXianRS.UniqueID));
           model.DXRS = Convert.ToInt32(Utils.GetFormValue(this.DuanXianRS.UniqueID));
           model.DiPeiDaoYou = Convert.ToDecimal(Utils.GetFormValue(this.DiPei.UniqueID));
           model.MSDiPeiDaoYou = Convert.ToDecimal(Utils.GetFormValue(this.DiPeiMS.UniqueID));
           model.DXDaoYouMoney = Convert.ToDecimal(Utils.GetFormValue(this.DXDaoYou.UniqueID));
           model.MSDXDaoYouMoney = Convert.ToDecimal(Utils.GetFormValue(this.DXDaoYouMS.UniqueID));
           model.DXDiPeiDaoYou = Convert.ToDecimal(Utils.GetFormValue(this.DXDiPei.UniqueID));
           model.MSDXDiPeiDaoYou = Convert.ToDecimal(Utils.GetFormValue(this.DXDiPeiMS.UniqueID));
           model.CJDaoYouMoney = Convert.ToDecimal(Utils.GetFormValue(this.CJDaoYou.UniqueID));
           model.MSCJDaoYouMoney = Convert.ToDecimal(Utils.GetFormValue(this.CJDaoYouMS.UniqueID));
           model.CJDiPeiDaoYou = Convert.ToDecimal(Utils.GetFormValue(this.CJDiPei.UniqueID));
           model.MSCJDiPeiDaoYou = Convert.ToDecimal(Utils.GetFormValue(this.CJDiPeiMS.UniqueID));


           if (model.JTYiWai.Split(',').Length != model.MSJTYiWai.Split(',').Length)
           {
               Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "交通意外保险请保持门市价和成本价数量一致！"));
               Response.End();
           }
           if (model.RSYiWai.Split(',').Length != model.MSRSYiWai.Split(',').Length)
           {
               Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "人身意外保险请保持门市价和成本价数量一致！"));
               Response.End();
           }
           if (model.WanCanMoney.Split(',').Length != model.MSWanCanMoney.Split(',').Length)
           {
               Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "晚餐费用请保持门市价和成本价数量一致！"));
               Response.End();
           }
           if (model.WuCanMoney.Split(',').Length != model.MSWuCanMoney.Split(',').Length)
           {
               Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "午餐费用请保持门市价和成本价数量一致！"));
               Response.End();
           }
           if (model.ZaoCanMoney.Split(',').Length != model.MSZaoCanMoney.Split(',').Length)
           {
               Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "早餐费用请保持门市价和成本价数量一致！"));
               Response.End();
           }

           EyouSoft.Model.OtherStructure.MZuTuan list = new EyouSoft.BLL.OtherStructure.BZuTuan().GetModel();
           if (list != null)
           {
               bool sucess = new EyouSoft.BLL.OtherStructure.BZuTuan().Update(model);
               if (sucess)
               {
                   Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "修改成功"));
               }
               else
               {
                   Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "修改失败"));
               }
           }
           else
           {
               bool sucess = new EyouSoft.BLL.OtherStructure.BZuTuan().Add(model);
               if (sucess)
               {
                   Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "添加成功"));
               }
               else
               {
                   Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "添加失败"));
               }
               
           }
        }
    }
}
