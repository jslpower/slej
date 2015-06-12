using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Common.Page;

namespace EyouSoft.Web.Member
{
    public partial class TransactionList : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected int PageSize = 20;
        protected int PageIndex = 1;
        protected int RecordCount = 0;
        protected string biaoti = "系统交易总明细";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            
            
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var chaXun = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("type")))
            {
                chaXun.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.E额宝;
                biaoti = "E额宝综合明细";
            }

            PageIndex = UtilsCommons.GetPagingIndex();
            var items = new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().GetJiaoYiMingXis(PageSize, PageIndex, ref RecordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                Repeater1.DataSource = items;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                XianShi.Text = "暂无交易记录!";
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取金额操作符号
        /// </summary>
        /// <param name="zhiFuFangShi">支付方式</param>
        /// <param name="jiaoYiLeiBie">交易类别</param>
        /// <returns></returns>
        protected string GetJinECaoZuoFu(object zhiFuFangShi,object jiaoYiLeiBie)
        {
            var _zhiFuFangShi = (EyouSoft.Model.Enum.ZhiFuFangShi)zhiFuFangShi;
            var _jiaoYiLeiBie = (EyouSoft.Model.Enum.JiaoYiLeiBie)jiaoYiLeiBie;

            string s = string.Empty;

            if (_zhiFuFangShi == EyouSoft.Model.Enum.ZhiFuFangShi.E额宝)
            {
                switch (_jiaoYiLeiBie)
                {
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.E额宝增值: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.充值: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.返利: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.返联盟推广返利: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.提现: s = "-"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.分销奖金: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.消费: s = "-"; break;
                }
            }

            if (_zhiFuFangShi == EyouSoft.Model.Enum.ZhiFuFangShi.快钱)
            {
                switch (_jiaoYiLeiBie)
                {
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.E额宝增值: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.充值: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.返利: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.返联盟推广返利: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.提现: s = "-"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.分销奖金: s = "+"; break;
                    case EyouSoft.Model.Enum.JiaoYiLeiBie.消费: s = "-"; break;
                }
            }

            return s;
        }
        #endregion

    }
}
