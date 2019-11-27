using System.Threading.Tasks;

namespace Epita.QueueStorage.Services.Contracts
{
    public interface IProcessorService
    {
        Task ProcessAsync(string userId);
    }
}