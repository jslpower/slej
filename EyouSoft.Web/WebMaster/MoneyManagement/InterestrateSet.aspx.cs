using System;
using System.Collections.Generic;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.Web.WebMaster.MoneyManagement
{
    public partial class InterestrateSet : EyouSoft.Common.Page.WebmasterPageBase
    {
        BPayMents bll = new BPayMents();
        MPayMentsInfo model = new MPayMentsInfo();
        MInterestRate RateInfo = new MInterestRate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }
           
         
        }

        void InitPage()
        {
            if (bll.ExistsData())
            {
                RateInfo = bll.Get();
                txtrate.Text = RateInfo.Interest.ToString();
            }
            else
            {
                txtrate.Text = "0.0000";
            }
        }

        void Save()
        {
            RateInfo = new MInterestRate();
            decimal rate=0;
            int result = 0;
             decimal.TryParse(Utils.GetFormValue(txtrate.UniqueID),out rate);
            RateInfo.Interest = rate;

            if (bll.ExistsData())
            {
               result= bll.UpdateInterestRate(rate);
               Response.Write("<script>alert('修改成功')</script>");
           
            }
            else
            {
                result = bll.AddInterestRate(rate);
                Response.Write("<script>alert('保存成功')</script>");
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
