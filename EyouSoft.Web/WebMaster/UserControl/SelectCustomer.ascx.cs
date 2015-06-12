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
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.UserControl
{
    public partial class SelectCustomer : System.Web.UI.UserControl
    {
        protected string NoticeHTML = "valid=\"required\"errmsg=\"游客不能为空！\"";
        /// <summary>
        /// 游客ID
        /// </summary>
        private string _hideID;
        /// <summary>
        /// 存放游客ID
        /// </summary>
        public string HideID
        {
            get { return _hideID; }
            set { _hideID = value; }
        }
        /// <summary>
        /// 游客名称
        /// </summary>
        private string _name;
        /// <summary>
        /// 存放游客名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _callback;
        /// <summary>
        /// 获取或设置回调函数方法名
        /// </summary>
        public string CallBack
        {
            get
            {
                if (string.IsNullOrEmpty(_callback)) return ClientID + "._callBack";

                return _callback;
            }
            set { _callback = value; }
        }
        /// <summary>
        /// 线路编号
        /// </summary>
        private string _routeId;
        protected string RouteId
        {
            get { return _routeId; }
            set { _routeId = value; }
        }

        /// <summary>
        /// 获取IframeID
        /// </summary>
        protected string IframeID
        {
            get { return Utils.GetQueryStringValue("iframeId"); }
        }
        /// <summary>
        /// 是否必选默认值
        /// </summary>
        private bool _ismust = true;
        /// <summary>
        /// 获取或设置是否必选（默认：false）
        /// </summary>
        public bool IsMust
        {
            get { return _ismust; }
            set { _ismust = value; }
        }
        private bool _iseEable = true;
        /// <summary>
        /// 是否可用(默认可用)
        /// </summary>
        public bool IsEnable
        {
            get { return _iseEable; }
            set { _iseEable = value; }
        }
        /// <summary>
        /// 获取选用按钮ClientID
        /// </summary>
        public string btnID { get { return "btn_" + this.ClientID + "_ID"; } }

        /// <summary>
        /// 获取游客编号ClientID
        /// </summary>
        public string ClientValue { get { return "hd_" + this.ClientID + "_ID"; } }

        /// <summary>
        /// 获取游客名称ClientID
        /// </summary>
        public string ClientText { get { return "txt_" + this.ClientID + "_Name"; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteId == "")
            {
                throw new Exception("游客选用控件的RouteId未赋值");
            }
        }
    }
}