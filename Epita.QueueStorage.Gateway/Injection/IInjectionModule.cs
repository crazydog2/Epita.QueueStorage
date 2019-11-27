using Microsoft.Extensions.DependencyInjection;

namespace Epita.QueueStorage.Gateway.Injection
{
    public interface IInjectionModule
    {
        void Register(IServiceCollection services);
    }
}