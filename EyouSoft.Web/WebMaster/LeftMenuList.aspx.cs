using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using EyouSoft.Model.Enum;


namespace EyouSoft.Web.WebMaster
{
    public partial class LeftMenuList : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (UserInfo.LeiXing == WebmasterUserType.后台用户)
                {
                    WebmasterModule.Visible = true;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.线路产品管理_线路管理))
                        PlaceHolder0.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.线路产品管理_订单管理))
                    //    PlaceHolder1.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.线路产品管理_团购产品))
                        PlaceHolder2.Visible = false;

                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.景区门票管理_景区管理))
                        PlaceHolder4.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.景区门票管理_景区门票管理))
                        PlaceHolder5.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.景区门票管理_景区订单管理))
                    //    PlaceHolder7.Visible = false;

                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.酒店管理_酒店管理))
                        PlaceHolder8.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.酒店管理_酒店房型管理))
                    //    PlaceHolder9.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.酒店管理_酒店订单管理))
                    //    PlaceHolder10.Visible = false;

                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.个人会员管理_会员管理))
                        PlaceHolder11.Visible = false;

                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_公司信息))
                        PlaceHolder12.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_网站基本信息))
                        PlaceHolder56.Visible = PlaceHolder13.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_线路区域))
                        PlaceHolder14.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_城市信息))
                        PlaceHolder15.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_线路主题))
                        PlaceHolder16.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_旅游资讯类别))
                        PlaceHolder17.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_旅游资讯))
                        PlaceHolder18.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_站点广告))
                        PlaceHolder19.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_友情链接))
                    //    PlaceHolder20.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_旅游攻略主题))
                    //   PlaceHolder21.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_旅游攻略))
                    //   PlaceHolder22.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_商城产品类别管理))
                        PlaceHolder25.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.系统设置_费用相关))
                        PlaceHolder26.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.后台用户管理_个人信息))
                        PlaceHolder23.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.后台用户管理_后台用户管理))
                        PlaceHolder24.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.后台用户管理_供应商管理))
                        trMasterProviders.Visible = false;
                    if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.团购产品))
                        PlaceHolder6.Visible = false;
                    //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.团购订单))
                    //    PlaceHolder47.Visible = false;


                    PlaceHolder35.Visible = this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.财务管理_充值管理);
                    PlaceHolder36.Visible = this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.财务管理_提现管理);
                    PlaceHolder37.Visible = this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.财务管理_返利管理);

                    //tr22.Visible = PlaceHolder38.Visible = CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_地标管理);

                    tr24.Visible = CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.签证管理_签证管理);
                    //tr25.Visible = CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.签证管理_签证订单管理);
                    //div5.Visible = tr24.Visible || tr25.Visible;

                    PlaceHolder43.Visible = CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.租车产品管理);
                    //PlaceHolder3.Visible = CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.租车订单管理);
                }
                else
                {
                    PlaceHolder7.Visible = false;
                    PlaceHolder27.Visible = false;
                    PlaceHolder47.Visible = false;
                    PlaceHolder45.Visible = false;
                    PlaceHolder49.Visible = false;
                    PlaceHolder48.Visible = false;
                    PlaceHolder25.Visible = false;

                    DaiLi.Visible = true;
                    ProvidersModule.Visible = false;

                }
            }

        }
    }
}
