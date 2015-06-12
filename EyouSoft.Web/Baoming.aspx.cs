using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Web.MasterPage;
using Common.page;
using EyouSoft.Common.Page;
using EyouSoft.Model.MemberStructure.WebModel;
using EyouSoft.Model.Enum.Privs;
using EyouSoft.IDAL.MemberStructure;
using Linq.Web;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using System.Text;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class Baoming : ClientModelViewPageBase<MMember2SearchModel>
    {
        BMember2 bll = new BMember2();
        public string BaiduMapKey = string.Empty;
        public string database = null;
        public int isfenxiao = 0;//0-显示，1-隐藏
        protected override int PageSize
        {
            get
            {
                return 10;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BaiduMapKey = Utils.GetBaiduMapKeyByXml();
            
            string url = HttpContext.Current.Request.Url.Host;
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null)
            {
                isfenxiao = 1;
                if (!string.IsNullOrEmpty(seller.MapX))
                {
                    var list = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                    database += "{ title: '" + seller.WebsiteName + "'"
                    + ", content: '联系人：" + list.MemberName + "&nbsp;手机：" + list.Mobile + "<br>电话：" + list.Contact + "<br>"
                    + "地址：" + list.Address + "<br><a href=http://" + seller.Website + "><font color=red>点击进入代理网站：" + seller.Website + "</font></a>', point: '" + seller.MapX + "|" + seller.MapY + "', isOpen: 1, icon: { w: 23, h: 25, l: 46, t: 21, x: 9, lb: 12} },";
                }
            }
            else
            {
                GetWangdian();
            }
        }
        /// <summary>
        /// 获取报名网点
        /// </summary>
        public void GetWangdian()
        {
            
            if (Utils.GetQueryStringValue("websitename") != "")
            {
                Model.WebsiteName = Utils.GetQueryStringValue("websitename");
            }
            Model.SearchInfo.PageInfo = PageInfo;
            Model.GetSellerInfo = true;
            Model.IsPage = true;
            var list = bll.GetMemberList(Model, new MemberTypes[] { MemberTypes.代理, MemberTypes.员工, MemberTypes.免费代理 });
            Repeater1.DataSource = list;
            Repeater1.DataBind();
            MMember2SearchModel memmodle = new MMember2SearchModel();
            memmodle.GetSellerInfo = true;
            memmodle.IsPage = false;
            var memberlist = bll.GetMemberList(memmodle, new MemberTypes[] { MemberTypes.代理, MemberTypes.员工, MemberTypes.免费代理 });
            
            database="{ title: '刘钊分销店', content: '联系人：刘大钊&nbsp;手机：13957140211<br>电话：0571-87290599<br>地址：中国杭州——文二西路与紫金港路交界：西溪智慧大厦北四楼整层。<br><a href=http://0211.slej.cn><font color=red>点击进入代理网站：0211.slej.cn</font></a>', point: '120.091887|30.286442', isOpen: 1, icon: { w: 23, h: 25, l: 46, t: 21, x: 9, lb: 12} },";
            
            for (int i = 0; i < memberlist.Count; i++)
            {
                if (!string.IsNullOrEmpty(memberlist[i].Seller.MapX) && !string.IsNullOrEmpty(memberlist[i].Seller.MapY) && memberlist[i].Mobile != "13957140211")
                {
                    database += "{ title: '" + memberlist[i].Seller.WebsiteName + "'"
                    + ", content: '联系人：" + memberlist[i].MemberName + "&nbsp;手机：" + memberlist[i].Mobile + "<br>电话：" + memberlist[i].Contact + "<br>"
                    + "地址：" + memberlist[i].Address + "<br><a href=http://" + memberlist[i].Seller.Website + "><font color=red>点击进入代理网站：" + memberlist[i].Seller.Website + "</font></a>', point: '" + memberlist[i].Seller.MapX + "|" + memberlist[i].Seller.MapY + "', isOpen: 1, icon: { w: 23, h: 25, l: 46, t: 21, x: 9, lb: 12} },";
                }
            }
            if (memberlist.Count > 0)
            {
                database = database.TrimEnd(',');
            }
        }
    }
}
