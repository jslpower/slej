using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EyouSoft.Toolkit
{
    #region 浏览器信息业务实体
    /// <summary>
    /// 浏览器信息业务实体
    /// </summary>
    [Serializable]
    public class BrowserInfo
    {
        string _browser, _version, _platform, _useragent;

        /// <summary>
        /// default constructor
        /// </summary>
        public BrowserInfo()
        {
            var request = HttpContext.Current.Request;
            if (request == null) return;
            var browser = request.Browser;
            if (browser == null) return;

            _useragent = request.UserAgent;
            _browser = browser.Browser;
            _version = browser.Version;
            _platform = browser.Platform;

            request = null;
            browser = null;
        }

        /// <summary>
        /// 获取由浏览器在 User-Agent 请求标头中发送的浏览器字符串（如果有）。
        /// </summary>
        public string Browser { get { return _browser; } }
        /// <summary>
        /// 获取浏览器的完整（整数和小数）版本号。
        /// </summary>
        public string Version { get { return _version; } }
        /// <summary>
        /// 获取客户端使用的平台的名称（如果已知）。
        /// </summary>
        public string Platform { get { return _platform; } }
        /// <summary>
        /// 获取客户端浏览器的原始用户代理信息。
        /// </summary>
        public string UserAgent { get { return _useragent; } }

        /// <summary>
        /// to json string
        /// </summary>
        /// <returns></returns>
        public string ToJsonString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
    #endregion
}
