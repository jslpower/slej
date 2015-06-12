using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace EyouSoft.Services.BackgroundServices
{
    public class BackgroundServicesExecutor
    {
        private IUnityContainer _container;
        private readonly List<BackgroundServiceExecutor> _executors;

        public BackgroundServicesExecutor(IUnityContainer container)
        {
            _container = container;

            //TODO: (erikpo) Once we have a plugin framework in place to load types from different assemblies, get rid of the below hardcoded values and load up all background services dynamically

            _executors = new List<BackgroundServiceExecutor>();
            _executors.Add(new BackgroundServiceExecutor(container, typeof(SysTimerServices), 1));

        }

        public void Start()
        {
            foreach (BackgroundServiceExecutor executor in _executors)
            {
                executor.Start();
            }
        }

        public void Stop()
        {
            foreach (BackgroundServiceExecutor executor in _executors)
            {
                executor.Stop();
            }
        }
    }
}
