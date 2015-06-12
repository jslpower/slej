using System;

namespace EyouSoft.Services.BackgroundServices
{
    public interface IBackgroundService : EyouSoft.BackgroundServices.IPlugin
    {
        bool ExecuteOnAll { get; set; }
        TimeSpan Interval { get; set; }
        void Run();
    }
}
