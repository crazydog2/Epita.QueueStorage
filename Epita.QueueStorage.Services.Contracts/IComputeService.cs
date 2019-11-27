using System.Threading.Tasks;
using Epita.QueueStorage.Model;

namespace Epita.QueueStorage.Services.Contracts
{
    public interface IComputeService
    {
        /// <summary>
        /// Send a Message to the compute-queue allowing the worker to compute the tags
        /// </summary>
        /// <param name="eventTags">The event tags to send for computation</param>
        Task LaunchAsync(EventTags eventTags);
    }
}