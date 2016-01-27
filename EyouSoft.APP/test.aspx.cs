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

namespace EyouSoft.WAP
{
    public partial class test : HuiYuanWapPageBase
    {
        protected string weixin_jsapi_config = string.Empty, yjTitle = string.Empty, youjiid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();
            if (!IsPostBack)
            {
                var weixin_jsApiList = new List<string>();
                weixin_jsApiList.Add("chooseImage");
                weixin_jsApiList.Add("uploadImage");
                weixin_jsApiList.Add("downloadImage");
                var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
                weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
                init();
            }
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
            IList<XingCheng> items = new List<XingCheng>();
            if (txtTuXiangMediaId.Length > 0)
            {
                for (int i = 0; i < txtTuXiangMediaId.Length; i++)
                {
                    var XCModel = new XingCheng();
                    if (txtTuXiangMediaId[i].StartsWith("/ufiles/"))
                    {
                        XCModel.ImgFile = txtTuXiangMediaId[i];
                    }
                    else
                    {
                        string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", Utils.get_weixin_access_token(), txtTuXiangMediaId[i]);
                        Utils.WLog(url, "/log/ce.txt");
                        string tuxiang_filename = string.Empty;
                        bool xiaZaiRetCode = EyouSoft.Toolkit.request.weixin_media_xiazaiSaveUrl(url, out tuxiang_filename);
                        if (xiaZaiRetCode) XCModel.ImgFile = tuxiang_filename;
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
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作失败，请重试"));
            }
        }

        /// <summary>
        /// 返回图片链接
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        protected string getImgSrc(object objStr, string youjiid)
        {
            string defaultImg = "/images/NoPic.jpg";
            if (objStr == null) return defaultImg;
            string src = objStr.ToString();
            if (string.IsNullOrEmpty(src)) return defaultImg;
            return TuPian.F1(src, 320, 240, youjiid);
        }
    }
}
