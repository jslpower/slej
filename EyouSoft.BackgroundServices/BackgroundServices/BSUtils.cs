using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EyouSoft.Services.BackgroundServices
{
    /// <summary>
    /// 短信服务通用方法类
    /// </summary>
    public class BSUtils
    {
        /// <summary>
        /// 获取安全调用后的短信服务对象
        /// </summary>
        /// <returns></returns>
        public static EyouSoft.BackgroundServices.TimerApi.TimerApi GetTimerApi()
        {
            var api = new EyouSoft.BackgroundServices.TimerApi.TimerApi();
            var apiHeader = new EyouSoft.BackgroundServices.TimerApi.ApiSoapHeader
            {
                SecretKey = Toolkit.ConfigHelper.ConfigClass.GetConfigString("BJZT_APIKey")
            };
            api.ApiSoapHeaderValue = apiHeader;

            return api;
        }
    }
}
