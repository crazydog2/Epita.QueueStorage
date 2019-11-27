using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Epita.QueueStorage.Gateway.Injection
{
    public class InjectionProviderFactory
    {
        private readonly IServiceCollection services;
        
        private static InjectionProviderFactory instance;

        private InjectionProviderFactory(IServiceCollection services)
        {
            this.services = services;

            // TODO Register your modules here

            RegisterModule<ServiceModule>();
            RegisterModule<LogicModule>();
        }

        public static IServiceCollection Register(IServiceCollection serviceCollection)
        {
            LazyInitializer.EnsureInitialized(ref instance, () => new InjectionProviderFactory(serviceCollection));

            return instance.services;
        }
        
        private void RegisterModule<T>() where T : IInjectionModule, new()
        {
            var module = new T();

            module.Register(services);
        }
    }
}