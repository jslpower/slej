using System;
using System.Collections.Generic;
using EyouSoft.BackgroundServices.IDAL;

namespace EyouSoft.Services.BackgroundServices
{
    /// <summary>
    /// 系统定时服务
    /// </summary>
    public class SysTimerServices : BackgroundServiceBase, IBackgroundService
    {
        private readonly ISysTimerServices dal;

        #region BackgroundServiceBase成员

        public SysTimerServices(IPluginService pluginService, ISysTimerServices smsTimerService)
            : base(pluginService)
        {
            dal = smsTimerService;
            ID = new Guid("{3caef7f7-8737-4673-9a64-b2d3fbea5da0}");
            Name = "系统-定时服务";
            Category = "Background Services";
        }

        #endregion

        #region IBackgroundService 成员
        public bool ExecuteOnAll
        {
            get
            {
                return bool.Parse(GetSetting("ExecuteOnAll"));
            }
            set
            {
                SaveSetting("ExecuteOnAll", value.ToString());
            }
        }

        public TimeSpan Interval
        {
            get
            {
                return new TimeSpan(long.Parse(GetSetting("Interval")));
            }
            set
            {
                SaveSetting("Interval", value.Ticks.ToString());
            }
        }

        public void Run()
        {
            EyouSoft.Toolkit.Utils.WLog("定时服务开启", "/log/service.timer.log");

            try
            {
                var items = dal.GetDingDans();

                if (items != null && items.Count > 0)
                {
                    EyouSoft.Toolkit.Utils.WLog(string.Format("定时服务读取到{0}个订单需要进行状态自动转换", items.Count), "/log/service.timer.log");

                    //调用API处理订单状态
                    var api = BSUtils.GetTimerApi();

                    EyouSoft.BackgroundServices.TimerApi.MTimerDingDanInfo[] _items = new EyouSoft.BackgroundServices.TimerApi.MTimerDingDanInfo[items.Count];

                    for (int i = 0; i < items.Count; i++)
                    {
                        EyouSoft.BackgroundServices.TimerApi.MTimerDingDanInfo item = new EyouSoft.BackgroundServices.TimerApi.MTimerDingDanInfo();

                        item.DingDanId = items[i].DingDanId;
                        item.DingDanLeiXing = items[i].DingDanLeiXing;

                        _items[i] = item;
                    }

                    api.HandlerDingDans(_items);                    
                }

            }
            catch (Exception e)
            {
                EyouSoft.Toolkit.Utils.WLog(e.Message + e.Source + e.StackTrace, "/log/service.timer.exception.log");
            }
        }

        #endregion
    }
}
