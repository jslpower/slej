using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.QianZhengStructure;
using EyouSoft.Common;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.QianZhengStructure;

namespace EyouSoft.Web.WebMaster.QianZheng
{
    public partial class DingDanEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string DingDanId = string.Empty;
        protected MQianZhengDingDanInfo DingDanInfo = null;
        protected string fukuantime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("id");
            //BindDrop();
            PageInit();
        }
        //void BindDrop()
        //{
        //    DropDownListDingDanStatus.DataValueField = "Value";
        //    DropDownListDingDanStatus.DataTextField = "Text";
        //    DropDownListDingDanStatus.DataSource = EyouSoft.Common.EnumObj.GetList(typeof(OrderStatus));
        //    DropDownListDingDanStatus.DataBind();

        //}
        void PageInit()
        {
            DingDanInfo = new BQianZhengDingDan().GetInfo(DingDanId);

            if (DingDanInfo == null)
                RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));

            txtYuDinShuLiang.Text = DingDanInfo.YuDingShuLiang.ToString()+"份";
            txtYuDinDanjia.Text = Math.Round(DingDanInfo.DanJia, 2).ToString();
            zongjine.Text = Math.Round(DingDanInfo.JinE, 2).ToString();

            if (DingDanInfo.FuKuanStatus == FuKuanStatus.已付款) fukuantime = DingDanInfo.FuKuanTime.ToString();
            txtLxrName.Text = DingDanInfo.LxrXingMing;
            txtLxrDianHua.Text = DingDanInfo.LxrDianHua;
            txtLxrdizhi.Text = DingDanInfo.LxrDiZhi;
            txtbeizhu.Text = DingDanInfo.BeiZhu;
            DingDanStatus.Text = (DingDanInfo.DingDanStatus).ToString();

        }

        //MQianZhengDingDanInfo GetUpdateInfo(MQianZhengDingDanInfo info)
        //{
        //    info.DanJia = Utils.GetDecimal(Utils.GetFormValue(txtYuDinDanjia.UniqueID));
        //    info.YuDingShuLiang = Utils.GetInt(Utils.GetFormValue(txtYuDinShuLiang.UniqueID));
        //    info.DingDanStatus = Utils.GetEnumValue<OrderStatus>(
        //        Utils.GetFormValue(DropDownListDingDanStatus.UniqueID), OrderStatus.未处理);
        //    info.LxrXingMing = Utils.GetFormValue(txtLxrName.UniqueID);
        //    info.LxrDianHua = Utils.GetFormValue(txtLxrDianHua.UniqueID);
        //    info.LxrYouXiang = Utils.GetFormValue(txtLxryouxiang.UniqueID);
        //    info.LxrDiZhi = Utils.GetFormValue(txtLxrdizhi.UniqueID);
        //    info.BeiZhu = Utils.GetFormValue(txtbeizhu.UniqueID);
        //    return info;
        //}

        protected string GetGuoJiaName(int guojiaid)
        {
            EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia bll = new BQianZhengGuoJia();
            MQianZhengGuoJiaInfo guojia = bll.GetInfo(guojiaid);
            if (guojia == null) return "未知国家";
            return guojia.Name1;
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    int shuliang =  Utils.GetInt(Utils.GetFormValue(txtYuDinShuLiang.UniqueID));
        //    if (!(shuliang>0))
        //    {
        //        RegisterAlertAndReloadScript("请填写数量");
        //        return;
        //    }
        //    MQianZhengDingDanInfo DingDanUpdate = new BQianZhengDingDan().GetInfo(DingDanId);
        //    if (DingDanInfo == null)
        //        RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));

        //    EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan bll = new BQianZhengDingDan();

        //    MQianZhengDingDanInfo updateDingDanInfo = GetUpdateInfo(DingDanUpdate);

        //    if (bll.Update(updateDingDanInfo) == 1 &&
        //        bll.SheZhiDingDanStatus(DingDanUpdate.DingDanId, DingDanUpdate.XiaDanRenId, updateDingDanInfo.DingDanStatus) ==
        //        1)
        //    {
        //        RegisterAlertAndReloadScript("操作成功");

        //    }
        //    else
        //    {
        //        RegisterAlertAndReloadScript("操作失败");

        //    }
        //}
    }
}
