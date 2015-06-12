//签证编辑页面 汪奇志 2013-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.Enum;
using EyouSoft.Web.UserControl;

namespace EyouSoft.Web.WebMaster.QianZheng
{
    /// <summary>
    /// 签证编辑页面
    /// </summary>
    public partial class QianZhengEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        /// <summary>
        /// 签证编号
        /// </summary>
        protected string QianZhengId = string.Empty;
        /// <summary>
        /// 签证供应商编号
        /// </summary>
        protected string GysId = string.Empty;
        /// <summary>
        /// 签证类型
        /// </summary>
        protected string QianZhengLeiXing = string.Empty;
        /// <summary>
        /// 是否分销
        /// </summary>
        protected string IsFenXiao = "0";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {            
            InitPrivs();

            QianZhengId = Utils.GetQueryStringValue("qianzhengid");

            if (Utils.GetQueryStringValue("dotype") == "submit") BaoCun();

            //InitQianZhengGys();
            InitInfo();
        }

        #region private members
        /// <summary>
        /// bao cun 
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();
            info.QianZhengId = QianZhengId;
            info.FaBuRenId = this.UserInfo.UserId;



            int bllRetCode = 0;

            if (string.IsNullOrEmpty(QianZhengId))
            {
                bllRetCode = new EyouSoft.BLL.QianZhengStructure.BQianZheng().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.QianZhengStructure.BQianZheng().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("0", "已经存在订单的签证信息不能修改"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.QianZhengStructure.MQianZhengInfo();

            info.GuoJiaId = Utils.GetInt(Utils.GetFormValue(txtGuoJiaId.UniqueID));
            info.Name = Utils.GetFormValue(txtQianZhengName.UniqueID);
            info.JiaGe = Utils.GetDecimal(Utils.GetFormValue(txtJiaGe.UniqueID));
            info.JiaGeMenShi = Utils.GetDecimal(Utils.GetFormValue(txtJiaGeMenShi.UniqueID));
            info.BanLiShiJian = Utils.GetFormValue(txtBanLiShiJian.UniqueID);
            info.YouXiaoQi = Utils.GetInt(Utils.GetFormValue(txtYouXiaoQi.UniqueID));
            info.TingLiuShiJian = Utils.GetInt(Utils.GetFormValue(txtTingLiuShiJian.UniqueID));
            info.MianShi = Utils.GetFormValue(txtMianShi.UniqueID);
            info.YaoQingHan = Utils.GetFormValue(txtYaoQingHan.UniqueID);
            info.SuoShuLingQu = Utils.GetFormValue(txtSuoShuLingQu.UniqueID);
            info.ShouLiFanWei = Utils.GetFormValue(txtShouLiFanWei.UniqueID);
            info.SuoXuCaiLiao = Utils.EditInputText(Request.Form[txtSuoXuCaiLiao.UniqueID]);
            info.TeBieTiShi = Utils.EditInputText(Request.Form[txtTeBieTiShi.UniqueID]);
            info.ZhuYiShiXiang = Utils.EditInputText(Request.Form[txtZhuYiShiXiang.UniqueID]);
            info.GysId = Utils.GetFormValue("txtGysId");
            info.QianZhengLeiXing = Utils.GetEnumValue<EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing>(Utils.GetFormValue("txtQianZhengLeiXing"), EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing.旅游签证);
            info.IsFenXiao = Utils.GetFormValue("txtIsFenXiao") == "1";

            //if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            //{
            //    info.GysId = UserInfo.GysId;
            //}

            #region 签证资料上传
            string[] qianzhengpath = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            string[] oldqianzheng = Utils.GetFormValues("hideFileInfo");
            if (oldqianzheng.Length > 0)
            {
                if (oldqianzheng[0].Split('|').Length > 1)
                {
                    info.FileUpLoad = oldqianzheng[0].ToString().Split('|')[1].ToString();
                }
            }
            if (qianzhengpath.Length > 0)
            {
                if (qianzhengpath[0].Split('|').Length > 1)
                {
                    info.FileUpLoad = qianzhengpath[0].ToString().Split('|')[1].ToString();
                }
            }
            #endregion
            return info;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(QianZhengId)) return;

            var info = new EyouSoft.BLL.QianZhengStructure.BQianZheng().GetInfo(QianZhengId);
            if (info == null) RCWE("异常请求");

            txtGuoJiaId.Value = info.GuoJiaId.ToString();
            txtQianZhengName.Value = info.Name;
            txtJiaGe.Value = info.JiaGe.ToString("F2");
            txtJiaGeMenShi.Value = info.JiaGeMenShi.ToString("F2");
            txtBanLiShiJian.Value = info.BanLiShiJian.ToString();
            txtYouXiaoQi.Value = info.YouXiaoQi.ToString();
            txtTingLiuShiJian.Value = info.TingLiuShiJian.ToString();
            txtMianShi.Value = info.MianShi;
            txtYaoQingHan.Value = info.YaoQingHan;
            txtSuoShuLingQu.Value = info.SuoShuLingQu;
            txtShouLiFanWei.Value = info.ShouLiFanWei;
            txtSuoXuCaiLiao.Text = info.SuoXuCaiLiao;
            txtTeBieTiShi.Text = info.TeBieTiShi;
            txtZhuYiShiXiang.Text = info.ZhuYiShiXiang;
            GysId = info.GysId;
            QianZhengLeiXing = ((int)info.QianZhengLeiXing).ToString();
            IsFenXiao = info.IsFenXiao ? "1" : "0";

            if (info.FileUpLoad != "")
            {
                StringBuilder strqianzheng = new StringBuilder();
                strqianzheng.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"iPage.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/webmaster/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{1}|{0}'/></span>", info.FileUpLoad, info.Name + "附件材料");
                this.lbUploadInfo.Text = strqianzheng.ToString();
            }

            var guojiainfo = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia().GetInfo(info.GuoJiaId);
            if (guojiainfo != null) txtGuoJiaName.Value = guojiainfo.Name1;

        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (UserInfo.LeiXing == 0)
            {
                if (!CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.签证管理_签证管理))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-100", "你没有操作权限"));
                }
            }
            else if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {

            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("-100", "你没有操作权限"));
            }
        }

        /// <summary>
        /// init qianzheng gys
        /// </summary>
        void InitQianZhengGys()
        {
            //StringBuilder s = new StringBuilder();
            //int recordCount = 0;
            //var items = new EyouSoft.BLL.QianZhengStructure.BQianZhengGys().GetGyss(100000, 1, ref recordCount, null);

            //if (items != null && items.Count > 0)
            //{
            //    foreach (var item in items)
            //    {
            //        s.AppendFormat("<option value=\"{0}\">{1}</option>", item.GysId, item.GysName);
            //    }
            //}

            //ltrGysIdOptions.Text = s.ToString();
        }
        #endregion
    }
}
