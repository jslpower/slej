using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web
{
    public partial class Ebao : System.Web.UI.Page
    {
        string yue = "/UserCentent.aspx";
        string fanli = "/UserCentent.aspx";
        string chongzhi = "/UserCentent.aspx";
        string tixian = "/UserCentent.aspx";
        string jifen = "/UserCentent.aspx";
        string zonghe = "/UserCentent.aspx";
        string fenxiao = "/UserCentent.aspx";
        string mingxi = "/UserCentent.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 10;
                GetAbout();
            }
            Model.SSOStructure.MUserInfo userInfo = null;
            bool islogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            if (islogin)
            {
                gotourl.Text = "<a href=\"/Member/UpdateMember.aspx\" class=\"yudin_btn\"><span>进入我的E额宝</span></a>";
                yue = "/Member/UserTransaction.aspx";
                chongzhi = "/Member/ChongzhiList.aspx";
                tixian = "/Member/TiXianList.aspx";
                jifen = "/Member/ZengZhi.aspx";
                zonghe = "/Member/TransactionList.aspx?type=1";
                mingxi = "/Member/TransactionList.aspx";
                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    fanli = "/Member/FanLiList.aspx";
                    fenxiao = "/member/FenSiJiangLi.aspx";
                }
            }
            else
            {
                gotourl.Text = "<a href=\"/UserCentent.aspx\" class=\"yudin_btn\"><span>进入我的E额宝</span></a>";
            }
            
            LinkList.Text="<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+yue+"\"><span style=\"white-space:nowrap; color:#337FE5\">E额宝余额管理</span></a> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+chongzhi+"\"><span style=\"white-space:nowrap; color:#337FE5\">E额宝充值明细</span></a> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+fanli+"\"><span style=\"white-space:nowrap; color:#337FE5\">E额宝返利明细</span></a> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+tixian+"\"><span style=\"white-space:nowrap; color:#337FE5\">E额宝提现明细</span></a><br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+jifen+"\"><span style=\"white-space:nowrap; color:#337FE5\">E额宝积分增值</span></a> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+zonghe+"\"><span style=\"white-space:nowrap; color:#337FE5\">E额宝综合明细</span></a> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+fenxiao+"\"><span style=\"white-space:nowrap; color:#337FE5\">我的下级分销奖</span></a> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href=\""+mingxi+"\"><span style=\"white-space:nowrap; color:#337FE5\">系统交易总明细</span></a><br><br></h3>";



        }
        protected void GetAbout()
        {
            EyouSoft.BLL.OtherStructure.BKV BLL = new EyouSoft.BLL.OtherStructure.BKV();
            EyouSoft.Model.MCompanySetting model = BLL.GetCompanySetting();
            if (model == null) return;
            txtEbao.Text = model.EBao;

        }
    }
}
