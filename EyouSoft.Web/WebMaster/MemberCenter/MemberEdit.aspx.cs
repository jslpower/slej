using System;
using Linq.Web;
using Common.page;
using EyouSoft.Model.MemberStructure.WebModel;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.Model;
using Linq.Bussiness;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster.MemberCenter
{
    //[Power(Menu1.个人会员管理, Menu2.个人会员管理_会员管理)]
    //[NoCache]
    public partial class MemberEdit :  ModelViewPageBase<MMember2SubmitModel>
    {
        BMember2 bll = new BMember2();
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        public int IsSee = 0;//是否为查看1-查看 2-编辑
        //public int iscar = 0;//是否有车1-有车
        public int istype = 0;//是否为分销商 1-分销商
        public int usertype = -1;
        public int isAdd = 0;//0-新增，1-编辑或查看
        public override bool IsValidatePower
        {
            get
            {
                return true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //选中CheckBoxList1
            //string abc = "1,2,4,5";
            //string[] ab = abc.Split(',');
            //for (int i = 0; i < ab.Length; i++)
            //{
            //    CheckBoxList1.Items[Convert.ToInt32(ab[i])].Selected = true;
            //}
            if (Model.SearchInfo.ShowMode.HasValue)
            {
                if (Model.SearchInfo.ShowMode.Value == ShowMode.Show || Model.SearchInfo.ShowMode.Value == ShowMode.Update)
                {
                    isAdd = 1;
                    Model.UpdateFrom(bll.Get(Model.MemberID));
                    RegisterTime.Text = Model.RegisterTime.ToShortDateString();
                    Account.Text = Model.Account;
                    Account.Enabled = false;
                    Address.Text = Model.Address;
                    BirthDate.Text = Convert.ToDateTime(Model.BirthDate).ToString("yyyy-MM-dd");
                    CardNo.Text = Model.CardNo;
                    CardType.SelectedIndex = Convert.ToInt32(Model.CardType);
                    //if (Model.IsCar == "1")
                    //{
                    //    CarInfo.Value = Model.CarInfo;
                    //    iscar = 1;
                    //}
                    Contact.Text = Model.Contact;
                    Email.Text = Model.Email;
                    Fax.Text = Model.Fax;
                    if (Model.Gender != null)
                    {
                        Gender.SelectedIndex = (int)Model.Gender;
                    }
                    //Model.IsCar = IsCarH.Value;
                    UMemberName.Text = Model.MemberName;
                    MemberState.SelectedIndex = (int)Model.MemberState - 1;
                    Mobile.Text = Model.Mobile;
                    //IsCarH.Value = Model.IsCar;
                    UserTypeH.Value = Convert.ToString((int)Model.UserType);

                    qq.Text = Model.qq;
                    WeiXin.Text = Model.WeiXin;
                    Remark.Value = Model.Remark;
                    if (!string.IsNullOrEmpty(Model.ValidDate.ToString()) && Model.ValidDate > Convert.ToDateTime("1900-01-01"))
                    {
                        txt_validDate.Text = Convert.ToDateTime(Model.ValidDate).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txt_validDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    }
                    if (Model.TotalMoney == null || Model.TotalMoney.ToString() == "")
                    {
                        TotalMoney.Text = "0.00";
                    }
                    else
                    {
                        TotalMoney.Text = Convert.ToDecimal(Model.TotalMoney).ToString("f2");
                    }
                    if (Model.Mobile.Length > 6)
                    {
                        WebSite.Text = Model.Mobile.Substring(Model.Mobile.Length - 4);
                    }
                    else
                    {
                        WebSite.Text = "";
                    }
                    if ((int)Model.UserType == 3 || (int)Model.UserType == 4 || (int)Model.UserType == 5)
                    {
                        istype = 1;
                        mseller = bsells.Get(Model.MemberID);
                        string[] quan = mseller.QuanXian.Split(',');
                        for (int i = 0; i < quan.Length; i++)
                        {
                            if (quan[i].ToString() != "0")
                            {
                                QuanXian.Items[Convert.ToInt32(quan[i]) - 1].Selected = true;
                            }
                        }
                        jingdu.Value = mseller.MapX;
                        X.InnerText = mseller.MapX;
                        weidu.Value = mseller.MapY;
                        Y.InnerText = mseller.MapY;
                        WebSiteName.Text = mseller.WebsiteName;
                        XuKeZhengHao.Text = mseller.XuKeZhengHao;
                        if (mseller.Website != null && mseller.Website != "")
                        {
                            WebSite.Text = mseller.Website.Replace(".slej.cn", "");
                        }
                        SLName.Text = mseller.JinAoLXR;
                        SLMOblie.Text = mseller.JinAoMobile;
                        SLQQ.Text = mseller.JinAoQQ;
                        SLTel.Text = mseller.JinAoTel;
                        SLWeiXin.Text = mseller.JinAoWeiXin;
                        txtContent.Text = mseller.CompanyContent;
                        CompanyJC.Text = mseller.CompanyJC;
                        CompanyName.Text = mseller.CompanyName;
                        NavNum.Value = ((int)mseller.NavNum).ToString();

                        if (!string.IsNullOrEmpty(mseller.JinAoPhoto))
                        {
                            StringBuilder strqianzheng = new StringBuilder();
                            strqianzheng.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"iPage.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/webmaster/cha.gif'></a><input type=\"hidden\" name=\"jinaohideFile\" value='{1}|{0}'/></span>", mseller.JinAoPhoto, mseller.JinAoLXR);
                            this.lbjinao.Text = strqianzheng.ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(Model.Photo))
                    {
                        StringBuilder strqianzheng = new StringBuilder();
                        strqianzheng.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"iPage.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/webmaster/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{1}|{0}'/></span>", Model.Photo, Model.MemberName);
                        this.lbUploadInfo.Text = strqianzheng.ToString();
                    }
                    usertype = (int)Model.UserType;
                    UPassWord.Text = Model.PassWord;
                    UPassWord.ToolTip = "不填写则不修改密码";
                    ZhiFuPassword.ToolTip = "不填写则不修改支付密码";
                    ZhiFuPassword.Text = Model.ZhiFuPassword;

                    var shangJiDaiLiShangInfo = new EyouSoft.BLL.OtherStructure.BMember().GetShangJiDaiLiShangInfoByHuiYuanId(Model.MemberID);
                    if (shangJiDaiLiShangInfo != null)
                    {
                        ltrShangJiDaiLiShangName.Text = shangJiDaiLiShangInfo.HuiYuanXingMing;

                        if (!string.IsNullOrEmpty(shangJiDaiLiShangInfo.YuMing))
                        {
                            ltrShangJiDaiLiShangName.Text += string.Format("&nbsp;<a href=\"http://{0}\" target=\"_blank\">打开代理商网店</a>", shangJiDaiLiShangInfo.YuMing);
                        }
                    }

                    if (new EyouSoft.BLL.OtherStructure.BMember().GetXiaJiDaiLiShuLiang(Model.MemberID) > 0)
                    {
                        ltrFenSi.Text = string.Format("<a href=\"fensi.aspx?huiyuanid={0}\">查看粉丝信息</a> <a href=\"fensijiaoyi.aspx?huiyuanid={0}\">查看粉丝交易</a> ", Model.MemberID);
                    }

                    if (Model.SearchInfo.ShowMode.Value == ShowMode.Show)
                    {
                        IsSee = 1;
                        Html.IsAllControlEnabled = false;
                        RegisterTime.Enabled = false;
                        Address.Enabled = false;
                        BirthDate.Enabled = false;
                        CardNo.Enabled = false;
                        CardType.Enabled = false;
                        Contact.Enabled = false;
                        Email.Enabled = false;
                        Fax.Enabled = false;
                        Gender.Enabled = false;
                        //IsCarH.Visible = false;
                        UMemberName.Enabled = false;
                        MemberState.Enabled = false;
                        Mobile.Enabled = false;
                        UPassWord.Visible = false;
                        qq.Enabled = false;
                        WeiXin.Enabled = false;
                        WebSite.Enabled = false;
                        TotalMoney.Enabled = false;
                        txt_validDate.Enabled = false;
                        if ((int)Model.UserType == 3 || (int)Model.UserType == 4 || (int)Model.UserType == 5)
                        {
                            istype = 1;
                            mseller = bsells.Get(Model.MemberID);
                            string[] quan = mseller.QuanXian.Split(',');
                            for (int i = 0; i < quan.Length; i++)
                            {
                                if (quan[i].ToString() != "0")
                                {
                                    QuanXian.Items[Convert.ToInt32(quan[i]) - 1].Selected = true;
                                }
                            }
                            WebSiteName.Enabled = false;
                            QuanXian.Enabled = false;
                        }
                        ZhiFuPassword.Visible = false;
                        SLName.Enabled = false;
                        SLMOblie.Enabled = false;
                        SLQQ.Enabled = false;
                        SLTel.Enabled = false;
                        SLWeiXin.Enabled = false;
                        XuKeZhengHao.Enabled = false;
                        txtContent.Enabled = false;
                        CompanyJC.Enabled = false;
                        CompanyName.Enabled = false;
                    }
                    else
                    {
                        IsSee = 2;
                    }
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        QuanXian.Items[i].Selected = true;

                    }
                    //Account.Text = "请填写手机号";
                }
                Model.SearchInfo.EditMode = (EditMode)(int)Model.SearchInfo.ShowMode;
            }
            else if (Model.SearchInfo.EditMode.HasValue)
            {

                if (Model.SearchInfo.EditMode.Value == EditMode.Add)
                {
                    #region 新增
                    bool success = false;
                    Model.MemberID = Guid.NewGuid().ToString();
                    Model.RegisterTime = DateTime.Now;
                    if (Account.Text == "")
                    {
                        ReturnAjax(-1, "用户名不能为空");
                    }
                    else
                    {
                        Model.Account = Account.Text;
                    }
                    if (Address.Text == "")
                    {
                        ReturnAjax(-1, "地址不能为空");
                    }
                    else
                    {
                        Model.Address = Address.Text;
                    }
                    if (BirthDate.Text != "")
                    {
                        Model.BirthDate = Convert.ToDateTime(BirthDate.Text);
                    }
                    if (Model.BirthDate < Convert.ToDateTime("1900-01-01") || BirthDate.Text == "")
                    {
                        ReturnAjax(-1, "请正确填写生日");
                    }

                    Model.CardNo = CardNo.Text;
                    Model.CardType = Convert.ToInt32(CardType.SelectedValue);
                    //Model.CarInfo = CarInfo.Value;
                    Model.Contact = Contact.Text;
                    Model.Email = Email.Text;
                    Model.Fax = Fax.Text;
                    Model.Gender = (EyouSoft.Model.Enum.Gender)Common.Utils.GetInt(Gender.SelectedValue);
                    //Model.IsCar = IsCarH.Value;
                    Model.MemberName = UMemberName.Text;
                    Model.MemberState = (EyouSoft.Model.Enum.UserStatus)Common.Utils.GetInt(MemberState.SelectedValue);
                    Model.Mobile = Mobile.Text;
                    Model.NickName = null;
                    if (UPassWord.Text == "")
                    {
                        ReturnAjax(-1, "密码不能为空");
                    }
                    else
                    {
                        Model.PassWord = UPassWord.Text;
                    }
                    Model.MD5Password = new EyouSoft.Model.CompanyStructure.PassWord(Model.PassWord).MD5Password;
                    Model.qq = qq.Text;
                    Model.WeiXin = WeiXin.Text;
                    Model.Remark = Remark.Value;
                    if (TotalMoney.Text == "")
                    {
                        Model.TotalMoney = 0;
                    }
                    else
                    {
                        Model.TotalMoney = Convert.ToDecimal(TotalMoney.Text);
                    }
                    Model.UserType = (EyouSoft.Model.Enum.MemberTypes)Common.Utils.GetInt(UserTypeH.Value);
                    if (Model.UserType == EyouSoft.Model.Enum.MemberTypes.未注册用户)
                    {
                        Model.UserType = EyouSoft.Model.Enum.MemberTypes.普通会员;
                    }
                    Model.ZhiFuPassword = ZhiFuPassword.Text;

                    #region 头像上传
                    string touxiangpath = Utils.GetFormValue(this.UploadControl1.ClientHideID);
                    string oldqianzheng = Utils.GetFormValue("hideFileInfo");
                    if (oldqianzheng.Length > 0)
                    {
                        if (oldqianzheng.Split('|').Length > 1)
                        {
                            Model.Photo = oldqianzheng.Split('|')[1].ToString();
                        }
                    }
                    if (touxiangpath.Length > 0)
                    {
                        if (touxiangpath.Split('|').Length > 1)
                        {
                            Model.Photo = touxiangpath.Split('|')[1].ToString();
                        }
                    }
                    #endregion

                    if (UserTypeH.Value == "2" || UserTypeH.Value == "3" || UserTypeH.Value == "4" || UserTypeH.Value == "5")
                    {
                        if (txt_validDate.Text == "" || Convert.ToDateTime(txt_validDate.Text) < Convert.ToDateTime("1900-01-01"))
                        {
                            ReturnAjax(-1, "请正确填写有效日期");
                        }
                        else
                        {
                            Model.ValidDate = Convert.ToDateTime(txt_validDate.Text);
                        }
                    }

                    if (UserTypeH.Value == "" && UserTypeH.Value == "-1")
                    {
                        ReturnAjax(-1, "请选择用户类型");
                    }
                    else
                    {
                        if (UserTypeH.Value == "3" || UserTypeH.Value == "4" || UserTypeH.Value == "5")
                        {
                            foreach (System.Web.UI.WebControls.ListItem li in QuanXian.Items)
                            {
                                if (li.Selected) mseller.QuanXian += li.Value + ",";
                            }

                            if (!string.IsNullOrEmpty(mseller.QuanXian))
                            {
                                mseller.QuanXian = mseller.QuanXian.TrimEnd(',');
                            }
                            else
                            {
                                mseller.QuanXian = "1,2,3,4,5,6,7,8,9";
                            }
                            mseller.DengJi = Model.UserType;
                            mseller.MapX = jingdu.Value;
                            mseller.MapY = weidu.Value;
                            mseller.MemberID = Model.MemberID;
                            mseller.WebsiteName = WebSiteName.Text;
                            mseller.ID = Guid.NewGuid().ToString();
                            mseller.JinAoLXR = SLName.Text;
                            mseller.JinAoMobile = SLMOblie.Text;
                            mseller.JinAoQQ = SLQQ.Text;
                            mseller.JinAoTel = SLTel.Text;
                            mseller.JinAoWeiXin = SLWeiXin.Text;
                            mseller.XuKeZhengHao = XuKeZhengHao.Text;
                            mseller.CompanyContent = Utils.EditInputText(txtContent.Text);
                            mseller.CompanyJC = CompanyJC.Text;
                            mseller.CompanyName = CompanyName.Text;

                            #region 头像上传
                            string photopath = Utils.GetFormValue(this.UploadControl2.ClientHideID);
                            string oldphoto = Utils.GetFormValue("jinaohideFile");
                            if (oldphoto.Length > 0)
                            {
                                if (oldphoto.Split('|').Length > 1)
                                {
                                    mseller.JinAoPhoto = oldphoto.Split('|')[1].ToString();
                                }
                            }
                            if (photopath.Length > 0)
                            {
                                if (photopath.Split('|').Length > 1)
                                {
                                    mseller.JinAoPhoto = photopath.Split('|')[1].ToString();
                                }
                            }
                            #endregion
                            if (string.IsNullOrEmpty(mseller.WebsiteName))
                            {
                                ReturnAjax(-1, "网点名称不能为空!");
                            }
                            string erweimaname = "";
                            if (!string.IsNullOrEmpty(WebSite.Text.Trim().Replace(" ", "")))
                            {
                                if (WebSite.Text.Trim().Replace(" ", "") == "www")
                                {
                                    ReturnAjax(-1, "不能设置域名为“www”，请重新设置!");
                                }
                                else
                                {
                                    mseller.Website = WebSite.Text.ToLower().Trim().Replace(" ", "") + ".slej.cn";
                                    erweimaname = WebSite.Text.ToLower().Trim().Replace(" ", "");
                                }
                            }
                            else
                            {
                                mseller.Website = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower() + ".slej.cn";
                                erweimaname = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower();
                            }
                            EyouSoft.Model.AccountStructure.MSellers mmseller = bll.Existswebsite(mseller.Website.Trim().Replace(" ", ""));
                            if (mmseller != null && mmseller.MemberID != mseller.MemberID)
                            {
                                ReturnAjax(-1, "域名已存在，请手动设置!");
                            }
                            if (bll.GetByAccount(Model.Account) != null)
                            {
                                ReturnAjax(-1, "用户名重复");
                            }
                            else
                            {
                                mseller.ErWeiMaUrl = AddErWeiMa("http://" + mseller.Website.Trim().Replace(" ", ""), erweimaname, Model.Photo);
                                success = bll.Add(Model, mseller);
                                if (success)
                                {
                                    EyouSoft.Model.AccountStructure.MSellers succseller = new BSellers().Get(Model.MemberID);
                                    Model.MWebmaster webmodel = new MWebmaster();
                                    webmodel.CreateTime = DateTime.Now;
                                    webmodel.Fax = Model.Fax;
                                    webmodel.GysId = succseller.ID;//分销商id
                                    webmodel.IsAdmin = 0;
                                    webmodel.IsEnable = 1;
                                    webmodel.LeiXing = (int)WebmasterUserType.代理商用户;
                                    webmodel.MD5Password = Model.MD5Password;
                                    webmodel.Mobile = Model.Mobile;
                                    webmodel.Password = Model.PassWord;
                                    webmodel.Permissions = "104,508";
                                    webmodel.Realname = Model.MemberName;
                                    webmodel.Telephone = Model.Contact;
                                    webmodel.Username = Model.Account;
                                    Save(webmodel);
                                    ReturnAjax(1, "操作成功");
                                }
                                else
                                {
                                    ReturnAjax(-1, "操作失败");
                                }
                            }
                        }
                        else
                        {
                            if (bll.GetByAccount(Model.Account) != null)
                            {
                                ReturnAjax(-1, "用户名重复");
                            }
                            else
                            {
                                success = bll.Add(Model);
                                if (success)
                                {
                                    ReturnAjax(1, "操作成功");
                                }
                                else
                                {
                                    ReturnAjax(-1, "操作失败");
                                }
                            }
                        }
                    }
                    #endregion
                }
                if (Model.SearchInfo.EditMode.Value == EditMode.Update)
                {
                    #region 修改
                    bool success = false;
                    Model.MemberID = Request.QueryString["memberid"];
                    MMember2 memmodel = bll.Get(Model.MemberID);
                    Model.Account = Account.Text;
                    var webmstermodel = new BLL.OtherStructure.BWebmaster().GetModel(Model.Account);//后台表
                    if (string.IsNullOrEmpty(Address.Text))
                    {
                        ReturnAjax(-1, "地址不能为空");
                    }
                    else
                    {
                        Model.Address = Address.Text;
                    }
                    if (BirthDate.Text != "")
                    {
                        Model.BirthDate = Convert.ToDateTime(BirthDate.Text);
                    }
                    if (Model.BirthDate < Convert.ToDateTime("1900-01-01") || BirthDate.Text == "")
                    {
                        ReturnAjax(-1, "请正确填写生日");
                    }

                    if (Convert.ToDateTime(txt_validDate.Text) < Convert.ToDateTime("1900-01-01") || txt_validDate.Text == "")
                    {
                        ReturnAjax(-1, "请正确填写有效日期");
                    }
                    else
                    {
                        Model.ValidDate = Convert.ToDateTime(txt_validDate.Text);
                    }
                    Model.LoginNum = memmodel.LoginNum;
                    Model.CardNo = CardNo.Text;
                    Model.CardType = Convert.ToInt32(CardType.SelectedValue);
                    //Model.CarInfo = CarInfo.Value;
                    Model.Contact = Contact.Text;
                    Model.Email = Email.Text;
                    Model.Fax = Fax.Text;
                    Model.Gender = (EyouSoft.Model.Enum.Gender)Common.Utils.GetInt(Gender.SelectedValue);
                    //Model.IsCar = IsCarH.Value;
                    Model.MemberName = UMemberName.Text;
                    Model.MemberState = (EyouSoft.Model.Enum.UserStatus)Common.Utils.GetInt(MemberState.SelectedValue);
                    Model.Mobile = Mobile.Text;
                    Model.NickName = null;

                    if (UPassWord.Text == "")
                    {
                        Model.PassWord = memmodel.PassWord;
                    }
                    else
                    {
                        Model.PassWord = UPassWord.Text;
                    }
                    Model.MD5Password = new EyouSoft.Model.CompanyStructure.PassWord(Model.PassWord).MD5Password;
                    Model.qq = qq.Text;
                    Model.WeiXin = WeiXin.Text;
                    Model.Remark = Remark.Value;
                    Model.RegisterTime = Convert.ToDateTime(RegisterTime.Text);
                    Model.TotalMoney = Convert.ToDecimal(TotalMoney.Text);
                    Model.UserType = (EyouSoft.Model.Enum.MemberTypes)Common.Utils.GetInt(UserTypeH.Value);


                    #region 头像上传
                    string touxiangpath = Utils.GetFormValue(this.UploadControl1.ClientHideID);
                    string oldqianzheng = Utils.GetFormValue("hideFileInfo");
                    if (oldqianzheng.Length > 0)
                    {
                        if (oldqianzheng.Split('|').Length > 1)
                        {
                            Model.Photo = oldqianzheng.Split('|')[1].ToString();
                        }
                    }
                    if (touxiangpath.Length > 0)
                    {
                        if (touxiangpath.Split('|').Length > 1)
                        {
                            Model.Photo = touxiangpath.Split('|')[1].ToString();
                        }
                    }
                    #endregion
                    if (string.IsNullOrEmpty(UPassWord.Text))
                    {
                        Model.ZhiFuPassword = memmodel.ZhiFuPassword;
                    }
                    else
                    {
                        Model.ZhiFuPassword = ZhiFuPassword.Text;
                    }


                    if (UserTypeH.Value == "" && UserTypeH.Value == "-1")
                    {
                        ReturnAjax(-1, "请选择用户类型");
                    }
                    else
                    {
                        if (UserTypeH.Value == "3" || UserTypeH.Value == "4" || UserTypeH.Value == "5")
                        {
                            foreach (System.Web.UI.WebControls.ListItem li in QuanXian.Items)
                            {
                                if (li.Selected) mseller.QuanXian += li.Value + ",";
                            }
                            if (!string.IsNullOrEmpty(mseller.QuanXian))
                            {
                                mseller.QuanXian = mseller.QuanXian.TrimEnd(',');
                            }
                            else
                            {
                                mseller.QuanXian = "1,2,3,4,5,6,7,8,9";
                            }
                            mseller.DengJi = Model.UserType;
                            mseller.MapX = jingdu.Value;
                            mseller.MapY = weidu.Value;
                            mseller.MemberID = Model.MemberID;
                            mseller.WebsiteName = WebSiteName.Text;
                            mseller.JinAoWeiXin = SLWeiXin.Text;
                            mseller.JinAoTel = SLTel.Text;
                            mseller.JinAoQQ = SLQQ.Text;
                            mseller.JinAoMobile = SLMOblie.Text;
                            mseller.JinAoLXR = SLName.Text;
                            mseller.XuKeZhengHao = XuKeZhengHao.Text;
                            mseller.CompanyContent = Utils.EditInputText(txtContent.Text);
                            mseller.CompanyJC = CompanyJC.Text;
                            mseller.CompanyName = CompanyName.Text;
                            mseller.NavNum = (EyouSoft.Model.Enum.NavNum)Utils.GetInt(NavNum.Value);

                            #region 头像上传
                            string photopath = Utils.GetFormValue(this.UploadControl2.ClientHideID);
                            string oldphoto = Utils.GetFormValue("jinaohideFile");
                            if (oldphoto.Length > 0)
                            {
                                if (oldphoto.Split('|').Length > 1)
                                {
                                    mseller.JinAoPhoto = oldphoto.Split('|')[1].ToString();
                                }
                            }
                            if (photopath.Length > 0)
                            {
                                if (photopath.Split('|').Length > 1)
                                {
                                    mseller.JinAoPhoto = photopath.Split('|')[1].ToString();
                                }
                            }
                            #endregion

                            string erweimaname = "";
                            if (!string.IsNullOrEmpty(WebSite.Text.Trim().Replace(" ", "")))
                            {
                                if (WebSite.Text.Trim().Replace(" ", "") == "www")
                                {
                                    ReturnAjax(-1, "不能设置域名为“www”，请重新设置!");
                                }
                                else
                                {
                                    mseller.Website = WebSite.Text.ToLower().Trim().Replace(" ", "") + ".slej.cn";
                                    erweimaname = WebSite.Text.ToLower().Trim().Replace(" ", "");
                                }
                            }
                            else
                            {
                                mseller.Website = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower() + ".slej.cn";
                                erweimaname = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower();
                            }
                            if (string.IsNullOrEmpty(mseller.WebsiteName))
                            {
                                ReturnAjax(-1, "网点名称不能为空!");
                            }
                            EyouSoft.Model.AccountStructure.MSellers mmseller = bll.Existswebsite(mseller.Website.Trim().Replace(" ", ""));
                            if (mmseller != null && mmseller.MemberID != mseller.MemberID)
                            {
                                ReturnAjax(-1, "域名已存在，请手动设置!");
                            }
                            mseller.ErWeiMaUrl = AddErWeiMa("http://" + mseller.Website.Trim().Replace(" ", ""), erweimaname, Model.Photo);


                        }
                        else
                        {
                            //删除
                            bsells.Delete(Model.MemberID);
                            if (webmstermodel != null)
                            {
                                new EyouSoft.BLL.OtherStructure.BWebmaster().Delete(webmstermodel.Id);
                            }
                        }
                    }

                    success = bll.Update(Model, mseller);
                    if (success)
                    {
                        if (UserTypeH.Value == "3" || UserTypeH.Value == "4" || UserTypeH.Value == "5")
                        {
                            #region 修改后台用户表
                            EyouSoft.Model.AccountStructure.MSellers succseller = new BSellers().Get(Model.MemberID);
                            Model.MWebmaster webmodel = new MWebmaster();
                            webmodel.Fax = Model.Fax;
                            webmodel.GysId = succseller.ID;//分销商id
                            webmodel.CreateTime = DateTime.Now;
                            if (webmstermodel != null)
                            {
                                webmodel.Id = webmstermodel.Id;
                                webmodel.CreateTime = webmstermodel.CreateTime;
                            }
                            webmodel.IsAdmin = 0;
                            webmodel.IsEnable = 1;
                            webmodel.LeiXing = (int)WebmasterUserType.代理商用户;
                            webmodel.MD5Password = Model.MD5Password;
                            webmodel.Mobile = Model.Mobile;
                            webmodel.Password = Model.PassWord;
                            webmodel.Permissions = "104,508";
                            webmodel.Realname = Model.MemberName;
                            webmodel.Telephone = Model.Contact;
                            webmodel.Username = Model.Account;
                            webmodel.Fax = Model.qq;
                            Save(webmodel);
                            #endregion
                            #region
                            EyouSoft.Model.SystemStructure.MSupplier supmodel = new EyouSoft.Model.SystemStructure.MSupplier();
                            supmodel = new EyouSoft.BLL.SystemStructure.BSupplier().GetSupplierModel(webmodel.Username);
                            if (supmodel != null)
                            {
                                supmodel.ContactMail = Model.Email;
                                supmodel.ContactMobile = Model.Mobile;
                                supmodel.ContactName = Model.MemberName;
                                supmodel.ContactPhone = Model.Contact;
                                supmodel.ContactQQ = Model.qq;
                                supmodel.SuppAddress = Model.Address;
                                supmodel.SuppName = "G"+webmodel.Username;
                                supmodel.SuppPwd = webmodel.Password;
                                new EyouSoft.BLL.SystemStructure.BSupplier().Update(supmodel);
                            }
                            #endregion
                            ReturnAjax(1, "操作成功");
                        }
                        else
                        {
                            ReturnAjax(1, "操作成功");
                        }
                    }
                    else
                    {
                        ReturnAjax(-1, "操作失败");
                    }
                    #endregion
                }
                if (Model.SearchInfo.EditMode.Value == EditMode.Delete)
                {
                    #region 删除
                    bool success = false;
                    Model.MemberID = Request.QueryString["memberid"];
                    success = bll.Delete(Model);
                    if (success)
                    {
                        ReturnAjax(1, "操作成功");
                        Response.Redirect("/webmaster/MemberCenter/MemberList.aspx");
                    }
                    else
                    {
                        ReturnAjax(-1, "操作失败");
                    }
                    #endregion
                }
            }
            else
            {
            }
        }
        private bool Save(Model.MWebmaster webmodel)
        {

            bool r = false;
            var bll = new BLL.OtherStructure.BWebmaster();
            if (webmodel.Id != 0)
            {
                r = bll.Update(webmodel);
            }
            else
            {
                r = bll.Add(webmodel);
            }
            return r;
        }
        public string AddErWeiMa(string context, string account, string TouXiang)
        {
            if (!string.IsNullOrEmpty(TouXiang))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 8;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Image image = qrCodeEncoder.Encode(context);               

                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);

                Response.ClearContent();

                Response.ContentType = "image/Png";

                Response.BinaryWrite(MStream.ToArray());

                //FileInfo f = new FileInfo(@"d:\zl.png");

                //string erweimaurl = "\\Images\\Erweima\\" + account + ".png";
                string path = Server.MapPath("/Images/Erweima/");
                //Directory.CreateDirectory("\\Images\\Erweima");
                File.Delete(path + account + ".png");
                System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                CombinImage(image, Server.MapPath(TouXiang)).Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);
                FileStream fs = new FileStream(path + account + ".png", FileMode.CreateNew, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs, UTF8Encoding.UTF8);
                byte[] by = MStream1.ToArray();
                for (int i = 0; i < MStream1.ToArray().Length; i++)
                    bw.Write(by[i]);
                fs.Close();
                MStream.Dispose();
                MStream1.Dispose();
                return "/Images/Erweima/" + account + ".png";
            }
            else
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();


                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

                qrCodeEncoder.QRCodeScale = 4;

                qrCodeEncoder.QRCodeVersion = 8;

                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //String data = "Hello 二维码！";
                String data = context;
                Response.Write(data);

                System.Drawing.Bitmap image = qrCodeEncoder.Encode(data);

                System.IO.MemoryStream MStream = new System.IO.MemoryStream();

                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);

                Response.ClearContent();

                Response.ContentType = "image/Png";

                Response.BinaryWrite(MStream.ToArray());

                //FileInfo f = new FileInfo(@"d:\zl.png");

                //string erweimaurl = "\\Images\\Erweima\\" + account + ".png";
                string path = Server.MapPath("/Images/Erweima/");
                //Directory.CreateDirectory("\\Images\\Erweima");
                File.Delete(path + account + ".png");


                FileStream fs = new FileStream(path + account + ".png", FileMode.CreateNew, FileAccess.ReadWrite);

                BinaryWriter bw = new BinaryWriter(fs, UTF8Encoding.UTF8);
                byte[] by = MStream.ToArray();
                for (int i = 0; i < MStream.ToArray().Length; i++)
                    bw.Write(by[i]);
                fs.Close();


                return "/Images/Erweima/" + account + ".png";
            }
        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg);        //照片图片      
            if (img.Height != 42 || img.Width != 42)
            {
                img = KiResizeImage(img, 42, 42, 0);
            }

            if (imgBack.Height != 145 || imgBack.Width != 145)
            {
                imgBack = KiResizeImage(imgBack, 145, 145, 0);
            }

            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, 145, 145);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
        //protected void UserType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (UserType.SelectedValue == "3" || UserType.SelectedValue == "4" || UserType.SelectedValue == "5")
        //    {
        //        IsBool = 0;
        //    }
        //    else
        //    {
        //        IsBool = 1;
        //    }
        //}

        //protected void IsCar_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (IsCar.SelectedValue == "1")
        //    {
        //        iscarvis = 0;
        //    }
        //    else
        //    {
        //        iscarvis = 1;
        //    }
        //}
    }
}
