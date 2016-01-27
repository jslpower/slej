using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP.userControl
{
    public partial class PriceInfo : ControlPageBase
    {
        Model.SSOStructure.MUserInfo userInfo = null;
        public string controlID { get { return ClientID + "price"; } }

        private FeeTypes _feetype = FeeTypes.周边线路;
        /// <summary>
        /// 产品类型
        /// </summary>
        public FeeTypes FeeType
        {
            get { return _feetype; }
            set { _feetype = value; }
        }

        private decimal _jsjcr = 0M;
        /// <summary>
        /// 成人结算价
        /// </summary>
        public decimal JSJCR
        {
            get { return _jsjcr; }
            set { _jsjcr = value; }
        }
        private decimal _jsjet = 0M;
        /// <summary>
        /// 儿童结算价
        /// </summary>
        public decimal JSJET
        {
            get { return _jsjet; }
            set { _jsjet = value; }
        }

        private decimal _crscj = 0M;
        /// <summary>
        /// 成人市场价
        /// </summary>
        public decimal CRSCJ
        {
            get { return _crscj; }
            set { _crscj = value; }
        }

        private decimal _etscj = 0M;
        /// <summary>
        /// 儿童市场价
        /// </summary>
        public decimal ETSCJ
        {
            get { return _etscj; }
            set { _etscj = value; }
        }

        protected bool _xianshi = false;
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool XIANSHI
        {
            get { return isDisplay; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {


            //litHtml.Visible = isDisplay;
            StringBuilder strbu = new StringBuilder();

            bool isLogin = Security.Membership.UserProvider.IsLogin(out userInfo);





            strbu.AppendFormat("<li><span class=\"font_yellow\">门市：</span>成人<strike class=\"font_red\">{0}元</strike>/人　儿童<strike class=\"font_red\">{1}元</strike>/人</li>", CRSCJ.ToString("F0"), ETSCJ.ToString("F0"));

            strbu.AppendFormat("<li class=\"on\"><span class=\"font_yellow\">优惠：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.普通会员).ToString("F0"));



            if (isLogin)
            {
                if (isDisplay)
                {
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
                    {
                        strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
                        strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));

                    }

                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                    {

                        strbu.AppendFormat("<li class=\"on\"><span class=\"font_yellow\">代销：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.免费代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.免费代理).ToString("F0"));

                        strbu.AppendFormat("<li ><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
                        strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
                    }

                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                    {

                        strbu.AppendFormat("<li  class=\"on\"><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
                        strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
                    }
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                    {
                        strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));

                        strbu.AppendFormat("<li class=\"on\"><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
                    }
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
 
                        strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));

                        strbu.AppendFormat("<li><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));

                        strbu.AppendFormat("<li class=\"on\"><span class=\"font_yellow\">员工：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.员工).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.员工).ToString("F0"));
                    }
                }
                else
                {
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                    {
                        strbu.AppendFormat("<li  class=\"on\"><span class=\"font_yellow\">代销：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.免费代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.免费代理).ToString("F0"));
                    }
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                    {
                        strbu.AppendFormat("<li  class=\"on\"><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
                    }
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                    {
                        strbu.AppendFormat("<li class=\"on\"><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
                    }
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        strbu.AppendFormat("<li class=\"on\"><span class=\"font_yellow\">员工：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.员工).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.员工).ToString("F0"));
                    }
                }

            }
            else
            {
                if (isDisplay)
                {
                    strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
                    strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));

                }



            }


            litHtml.Text = strbu.ToString();

        }

    }
}