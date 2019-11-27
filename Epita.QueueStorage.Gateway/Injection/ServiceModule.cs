using Epita.QueueStorage.Services;
using Epita.QueueStorage.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Epita.QueueStorage.Gateway.Injection
{
    public class ServiceModule : IInjectionModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IPhotoService, PhotoService>();
            services.AddSingleton<IComputeService, ComputeService>();
            services.AddSingleton<IMetricService, MetricService>();
            services.AddSingleton<IProcessorService, ProcessorService>();
        }
    }
}