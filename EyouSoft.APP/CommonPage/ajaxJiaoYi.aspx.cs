using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxJiaoYi : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetChongZhiList();
        }
        public void GetChongZhiList()
        {

            var chaXun = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("type")) && Utils.GetQueryStringValue("type")=="1")
            {
                chaXun.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.E额宝;
            }
            int RecordCount = 0;
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            var items = new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().GetJiaoYiMingXis(20, pageindex, ref RecordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                if (RecordCount > (pageindex - 1) * 20)
                {
                    Repeater1.DataSource = items;
                }
                else
                {
                    Repeater1.DataSource = null;
                }
                Repeater1.DataBind();
            }
        }
        /// <summary>
        /// 获取金额操作符号
        /// </summary>
        /// <param name="zhiFuFangShi">支付方式</param>
        /// <param name="jiaoYiLeiBie">交易类别</param>
        /// <returns></returns>
        protected string GetJinECaoZuoFu(object zhiFuFangShi, object jiaoYiLeiBie)
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
    }
}
