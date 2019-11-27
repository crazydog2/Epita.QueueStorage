using Epita.QueueStorage.Logic;
using Epita.QueueStorage.Logic.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Epita.QueueStorage.Gateway.Injection
{
    public class LogicModule : IInjectionModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IUserLogic, UserLogic>();
            services.AddSingleton<IPhotoLogic, PhotoLogic>();
            services.AddSingleton<IMetricLogic, MetricLogic>();
        }
    }
}