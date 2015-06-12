using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;

namespace EyouSoft.Web
{
    public partial class VisaList : System.Web.UI.Page
    {
        #region 分页参数
        public int pageIndex = 1, recordCount = 0, pageSize = 20;
        public string ClassName = "旅游资讯";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 4;
            initPage();
        }
        private void initPage()
        {
            int guojiaId = Common.Utils.GetInt(Request.QueryString["Guojiaid"]);
            EyouSoft.BLL.QianZhengStructure.BQianZheng bll = new EyouSoft.BLL.QianZhengStructure.BQianZheng();
            EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo model = new EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo();
            if (guojiaId != 0)
            {
                model.GuoJiaId = guojiaId;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["visacate"]))
            {
                model.QianZhengLeiXing = (EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)Convert.ToInt32(Request.QueryString["visacate"]);
            }
            model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            var list = bll.GetQianZhengs(pageSize, pageIndex, ref recordCount, model);
            if (list.Count > 0)
            {
                QianZheng.DataSource = list;
                QianZheng.DataBind();
            }
            else
            {
                TiShi.Text = "暂无数据!";
            }
        }
        protected string getPuTongJia(object jiage,object menshijia)
        {
            string ptjiage = "";
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.签证);
            if(!string.IsNullOrEmpty(jiage.ToString()) && !string.IsNullOrEmpty(menshijia.ToString()))
            {
                ptjiage = (Convert.ToInt32(jiage) + (Convert.ToInt32(menshijia) - Convert.ToInt32(jiage)) * feeSettings.PuTongHuiYuanJia/100).ToString();
            }
            return ptjiage;
        }
    }
}
