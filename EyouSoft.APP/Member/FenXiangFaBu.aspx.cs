using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.WeiXin;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class FenXiangFaBu : HuiYuanWapPageBase
    {
        protected string weixin_jsapi_config = string.Empty, yjTitle = string.Empty, youjiid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BaoCun();
            }
            init();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void init()
        {
            youjiid = Utils.GetQueryStringValue("youjid");
            var list = new BYouJi().GetModel(youjiid);
            if (list != null && list.YouJiType == YouJiLeiXing.图文分享)
            {
                yjTitle = list.YouJiTitle;
                rptYouJis.DataSource = list.YouJiContent;
                rptYouJis.DataBind();
            }
            else
            {
                isAdd.Visible = true;
            }
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        void BaoCun()
        {
            var info = new MYouJi();
            if (info == null) Utils.RCWE("异常请求");
            info.YouJiId = Utils.GetFormValue("hidyid");
            info.YouJiTitle = Utils.GetFormValue("txtTitle");
            info.HuiYuanId = HuiYuanInfo.UserId;
            info.IssueTime = DateTime.Now;

            //从微信服务器下载图像
            string[] txtTuXiangMediaId = Utils.GetFormValues("txtTuXiangMediaId");
            string[] txtTuXiangContent = Utils.GetFormValues("MiaoShu");
            HttpFileCollection files = HttpContext.Current.Request.Files;
            IList<XingCheng> items = new List<XingCheng>();
            if (txtTuXiangMediaId.Length > 0)
            {
                for (int i = 0; i < txtTuXiangMediaId.Length; i++)
                {
                    var XCModel = new XingCheng();
                    if (!string.IsNullOrEmpty(files[i].FileName.Trim()))
                    {
                        XCModel.ImgFile = EyouSoft.Toolkit.request.weixin_UploadOutUrl(files[i]); ;
                    }
                    else
                    {
                        XCModel.ImgFile = txtTuXiangMediaId[i];


                    }
                    XCModel.XingChengContent = txtTuXiangContent[i];
                    items.Add(XCModel);
                }
            }
            info.YouJiContent = items;
            bool bllRetCode = false;
            if (string.IsNullOrEmpty(info.YouJiId))
            {
                bllRetCode = new BYouJi().Add(info);
            }
            else
            {
                bllRetCode = new BYouJi().UpdateModel(info);
            }

            if (bllRetCode)
            {
                EyouSoft.Common.Function.MessageBox.ShowAndRedirect(this.Page, "操作成功", "FexXiangList.aspx");

            }
            else
            {
                EyouSoft.Common.Function.MessageBox.Show(this.Page, "操作失败");
            }
        }

        /// <summary>
        /// 返回图片链接
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        protected string getImgSrc(object objStr, string youjiid)
        {
            if (objStr == null) return string.Empty;
            string src = objStr.ToString();
            if (string.IsNullOrEmpty(src)) return string.Empty;
            return TuPian.F1(src, 320, 240, youjiid);
        }
    }
}
