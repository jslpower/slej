using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.WAP.Member
{
    public partial class UserCenter : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        MSearchDingDan Model = new MSearchDingDan();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        BMember2 bll = new BMember2();
        protected decimal mymoney = 0;
        public int isfenxiao = 0;
        protected int WeiChuLiNum = 0;
        protected int HuiYuanType = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "会员中心";
            var list = bll.Get(HuiYuanInfo.UserId);
            if (list.TotalMoney != null)
            {
                mymoney = (decimal)list.TotalMoney;
            }
            else
            {
                mymoney = (decimal)0;
            }
            HuiYuanType = (int)HuiYuanInfo.UserType;
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isfenxiao = 1;
            }

            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                AgencyId = mseller.ID;
            }

            Model.xiadanrenid = HuiYuanInfo.UserId;
            Model.OrderStatus = new List<EyouSoft.Model.Enum.XianLuStructure.OrderStatus> { EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货 };
            if (AgencyId != "")
            {
                Model.fenxiaoid = AgencyId;
                Model.OrderStatus = new List<EyouSoft.Model.Enum.XianLuStructure.OrderStatus> { EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货 };
            }
            Model.dingdantype = (DingDanType)(-1);
            Model.IsWAP = true;
            int TotalCount = 0;
            var items = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(1, 1, ref TotalCount, Model);
            WeiChuLiNum = TotalCount;
        }
        protected override void OnInit(EventArgs e)
        {
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin();
            if (!isLogin) Response.Redirect("/start.aspx?rurl=/Member/UserCenter.aspx");

            base.OnInit(e);

        }
    }
}
