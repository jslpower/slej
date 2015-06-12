using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.MemberStructure.WebModel;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.Member
{
    public partial class UpdateMember : ClientModelViewPageBase<MMember2>
    {
        BMember2 bll = new BMember2();
        public int IsFenXiao = 0;//0-不是，1-是分销商
        public int DaiLiNavNum = 0;
        EyouSoft.BLL.MemberStructure.BMember membll = new EyouSoft.BLL.MemberStructure.BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            string type = Utils.GetQueryStringValue("type").Trim();

            if (type == "update")
            {
                Response.Clear();
                Response.Write(UpdateUserInfo());
                Response.End();
            }
            else
            {
                MMember2 model = bll.Get(HuiYuanInfo.UserId);
                txtaccount.Text = model.Account;
                txtaccount.Enabled = false;
                txtmoblie.Text = model.Mobile;
                Literal1.Text = (model.UserType).ToString();
                if (model.BirthDate != null && model.BirthDate.ToString() != "")
                {
                    txtBirthDate.Value = Convert.ToDateTime(model.BirthDate).ToString("yyyy-MM-dd");
                }
                if (model.Gender == null || (int)model.Gender == 0)
                {
                    Gender.SelectedIndex = 0;
                }
                else
                {
                    Gender.SelectedIndex = 1;
                }
                if (model.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || model.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || model.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    IsFenXiao = 1;
                    EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.IDAL.AccountStructure.BSellers().Get(HuiYuanInfo.UserId);
                    //if (mseller.ShowOrHidden == EyouSoft.Model.Enum.ShowHidden.显示)
                    //{
                    //    ShowHidden.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    ShowHidden.SelectedIndex = 1;
                    //}
                    DaiLiNavNum = (int)mseller.NavNum;
                    txtComanyName.Text = mseller.CompanyName;
                    txtCompanyJC.Text = mseller.CompanyJC;
                    txtCompanyJC.Enabled = false;
                    txtComanyName.Enabled = false;
                    //txtContent.Text = mseller.CompanyContent;
                }
                else
                {
                    //FenShow.Visible = false;
                }


                if (!string.IsNullOrEmpty(model.Photo))
                {
                    StringBuilder strqianzheng = new StringBuilder();
                    strqianzheng.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"PageInfo.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/webmaster/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{1}|{0}'/></span>", model.Photo, model.MemberName);
                    this.lbUploadInfo.Text = strqianzheng.ToString();
                }
                txtContact.Text = model.Contact;
                txtEmail.Text = model.Email;
                txtmember.Text = model.MemberName;
                txtqq.Text = model.qq;
                //txtnickname.Text = model.NickName;
                txtAddress.Text = model.Address;
                if (model.ValidDate.HasValue)
                {
                    lbl_validDate.Text = Convert.ToDateTime(model.ValidDate).ToString("yyyy-MM-dd");
                    TimeSpan span = model.ValidDate.Value - DateTime.Now;
                    if (span.Days < 10)
                    {
                        switch (model.UserType)
                        {
                            case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                                litNoticeMsg.Text = "<a target=\"_blank\" href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上续费</span></a>    <a target=\"_blank\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\" ><span>申请代理</span></a>";
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.代理:
                                litNoticeMsg.Text = "<a target=\"_blank\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\" ><span>马上续费</span></a>";
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.免费代理:
                            case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                            case EyouSoft.Model.Enum.MemberTypes.普通会员:
                            case EyouSoft.Model.Enum.MemberTypes.员工:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindNav(string selectItem)
        {
            string membertype = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(NavNum)), selectItem.ToString(), false, "-1", "请选择");

            return membertype.ToString();

        }
        #endregion

        private string UpdateUserInfo()
        {
            string msg = "";
            bool iscount = false;
            MMember2 Model = new MMember2();
            if (txtBirthDate.Value != "")
            {
                Model.BirthDate = Convert.ToDateTime(txtBirthDate.Value);
            }
            Model.MemberID = HuiYuanInfo.UserId;
            Model.Gender = (EyouSoft.Model.Enum.Gender)Gender.SelectedIndex;
            Model.Contact = txtContact.Text;
            Model.Email = txtEmail.Text;
            Model.MemberName = txtmember.Text;
            Model.qq = txtqq.Text;
            Model.Mobile = txtmoblie.Text;
            Model.NickName = null;
            Model.Address = txtAddress.Text;
            //membll.UpdateShowOrHidden((EyouSoft.Model.Enum.ShowHidden)ShowHidden.SelectedIndex,(NavNum)Utils.GetInt(Utils.GetFormValue("ddlNav")), Model.MemberID);
            //membll.UpdateSellerContent(Utils.EditInputText(txtContent.Text), Model.MemberID);
            //Model.ShowOrHidden = (EyouSoft.Model.Enum.ShowHidden)ShowHidden.SelectedIndex;
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

            if (HuiYuanInfo.UserType == MemberTypes.代理 || HuiYuanInfo.UserType == MemberTypes.员工)
            {
                EyouSoft.Model.SystemStructure.MSupplier supmodel = new EyouSoft.Model.SystemStructure.MSupplier();
                supmodel = new EyouSoft.BLL.SystemStructure.BSupplier().GetSupplierModel("G" + HuiYuanInfo.Username);
                if (supmodel != null)
                {
                    supmodel.ContactMail = Model.Email;
                    supmodel.ContactMobile = Model.Mobile;
                    supmodel.ContactName = Model.MemberName;
                    supmodel.ContactPhone = Model.Contact;
                    supmodel.ContactQQ = Model.qq;
                    supmodel.SuppAddress = Model.Address;
                    supmodel.SuppName = "G" + Model.Account;
                    supmodel.SuppPwd = Model.PassWord;
                    new EyouSoft.BLL.SystemStructure.BSupplier().Update(supmodel);
                }
            }


            iscount = membll.UpdateMemberInfo(Model);
            if (iscount)
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改成功！");
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "修改失败！");
            }
            return msg;
        }
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    MMember2 Model = new MMember2();
        //    if (txtBirthDate.Value != "")
        //    {
        //        Model.BirthDate = Convert.ToDateTime(txtBirthDate.Value);
        //    }
        //    Model.MemberID = HuiYuanInfo.UserId;
        //    Model.Gender = (EyouSoft.Model.Enum.Gender)Gender.SelectedIndex;
        //    Model.Contact = txtContact.Text;
        //    Model.Email = txtEmail.Text;
        //    Model.MemberName = txtmember.Text;
        //    Model.qq = txtqq.Text;
        //    Model.NickName = txtnickname.Text;
        //    membll.UpdateMemberInfo(Model);
        //}
    }
}
